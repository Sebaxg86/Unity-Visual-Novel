using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EntreTuSilencio.Systems
{
    [DisallowMultipleComponent]
    public class PhoneOverlayController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup rootCanvasGroup;
        [SerializeField] private Image messageImage;
        [SerializeField] private Sprite defaultMessageSprite;
        [SerializeField] private Button closeButton;
        [SerializeField] private RectTransform phoneTransform;
        [SerializeField] private float slideDuration = 0.24f;
        [SerializeField] private float hiddenYOffset = 1200f;

        public event Action Opened;
        public event Action Closed;

        public bool IsVisible => rootCanvasGroup != null && rootCanvasGroup.alpha > 0.99f;

        private Coroutine currentSlideRoutine;
        private Vector2 visibleAnchoredPosition;

        private void Awake()
        {
            if (rootCanvasGroup == null)
            {
                rootCanvasGroup = GetComponent<CanvasGroup>();
            }

            if (phoneTransform == null)
            {
                phoneTransform = transform as RectTransform;
            }

            if (phoneTransform != null)
            {
                visibleAnchoredPosition = phoneTransform.anchoredPosition;
            }

            if (closeButton != null)
            {
                closeButton.onClick.AddListener(HandleClosePressed);
            }

            SetVisibility(false);
            SetHiddenPosition();
        }

        public void ShowDefault()
        {
            Show(defaultMessageSprite);
        }

        public void Show(Sprite messageSprite)
        {
            if (messageImage != null && messageSprite != null)
            {
                messageImage.sprite = messageSprite;
            }

            StopSlideAnimation();
            SetVisibility(true);
            StartSlideAnimation(GetHiddenPosition(), visibleAnchoredPosition, notifyClosedOnComplete: false, onComplete: null);
            Opened?.Invoke();
        }

        public void SetCloseButtonVisible(bool visible)
        {
            if (closeButton == null)
            {
                return;
            }

            closeButton.gameObject.SetActive(visible);
        }

        public void Hide()
        {
            HideAnimated(null, true);
        }

        public void HideInstant()
        {
            StopSlideAnimation();
            SetVisibility(false);
            SetHiddenPosition();
        }

        public void HideAfterAnimation(Action onHidden)
        {
            HideAnimated(onHidden, false);
        }

        private void HandleClosePressed()
        {
            HideAnimated(null, true);
        }

        private void HideAnimated(Action onHidden, bool notifyClosed)
        {
            if (!IsVisible)
            {
                SetVisibility(false);
                SetHiddenPosition();
                onHidden?.Invoke();

                if (notifyClosed)
                {
                    Closed?.Invoke();
                }

                return;
            }

            StopSlideAnimation();
            StartSlideAnimation(GetCurrentAnchoredPosition(), GetHiddenPosition(), notifyClosed, onHidden);
        }

        private void SetVisibility(bool visible)
        {
            if (rootCanvasGroup == null)
            {
                gameObject.SetActive(visible);
                return;
            }

            rootCanvasGroup.alpha = visible ? 1f : 0f;
            rootCanvasGroup.blocksRaycasts = visible;
            rootCanvasGroup.interactable = visible;
        }

        private void StartSlideAnimation(Vector2 from, Vector2 to, bool notifyClosedOnComplete, Action onComplete)
        {
            if (phoneTransform == null || slideDuration <= 0f)
            {
                if (phoneTransform != null)
                {
                    phoneTransform.anchoredPosition = to;
                }

                if (notifyClosedOnComplete)
                {
                    SetVisibility(false);
                    Closed?.Invoke();
                }
                else
                {
                    SetVisibility(true);
                }

                onComplete?.Invoke();
                return;
            }

            currentSlideRoutine = StartCoroutine(SlideRoutine(from, to, notifyClosedOnComplete, onComplete));
        }

        private IEnumerator SlideRoutine(Vector2 from, Vector2 to, bool notifyClosedOnComplete, Action onComplete)
        {
            if (phoneTransform == null)
            {
                yield break;
            }

            float duration = slideDuration > 0f ? slideDuration : 0.01f;
            float elapsed = 0f;
            phoneTransform.anchoredPosition = from;

            while (elapsed < duration)
            {
                elapsed += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(elapsed / duration);
                float eased = Mathf.SmoothStep(0f, 1f, t);
                phoneTransform.anchoredPosition = Vector2.Lerp(from, to, eased);
                yield return null;
            }

            phoneTransform.anchoredPosition = to;
            currentSlideRoutine = null;

            if (notifyClosedOnComplete)
            {
                SetVisibility(false);
                Closed?.Invoke();
            }
            else
            {
                SetVisibility(true);
            }

            onComplete?.Invoke();
        }

        private void StopSlideAnimation()
        {
            if (currentSlideRoutine == null)
            {
                return;
            }

            StopCoroutine(currentSlideRoutine);
            currentSlideRoutine = null;
        }

        private Vector2 GetHiddenPosition()
        {
            return visibleAnchoredPosition + new Vector2(0f, -Mathf.Abs(hiddenYOffset));
        }

        private Vector2 GetCurrentAnchoredPosition()
        {
            return phoneTransform != null ? phoneTransform.anchoredPosition : visibleAnchoredPosition;
        }

        private void SetHiddenPosition()
        {
            if (phoneTransform == null)
            {
                return;
            }

            phoneTransform.anchoredPosition = GetHiddenPosition();
        }
    }
}
