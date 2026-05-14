using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EntreTuSilencio.Systems
{
    [DisallowMultipleComponent]
    public class ChapterCompletePopupController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup rootCanvasGroup;
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text bodyText;
        [SerializeField] private TMP_Text confirmButtonText;
        [SerializeField] private Button confirmButton;
        [SerializeField] private float fadeDuration = 0.24f;

        private Coroutine fadeRoutine;

        public event Action Confirmed;

        public bool IsVisible => rootCanvasGroup != null && rootCanvasGroup.alpha > 0.99f;

        private void Awake()
        {
            if (rootCanvasGroup == null)
            {
                rootCanvasGroup = GetComponent<CanvasGroup>();
            }

            if (confirmButton != null)
            {
                confirmButton.onClick.AddListener(HandleConfirmPressed);
            }

            HideInstant();
        }

        private void OnDestroy()
        {
            if (confirmButton != null)
            {
                confirmButton.onClick.RemoveListener(HandleConfirmPressed);
            }
        }

        public void Show(string title, string body, string confirmLabel)
        {
            if (titleText != null)
            {
                titleText.text = title ?? string.Empty;
            }

            if (bodyText != null)
            {
                bodyText.text = body ?? string.Empty;
            }

            if (confirmButtonText != null)
            {
                confirmButtonText.text = string.IsNullOrWhiteSpace(confirmLabel) ? "Volver al inicio" : confirmLabel;
            }

            FadeTo(true);
        }

        public void Hide()
        {
            FadeTo(false);
        }

        public void HideInstant()
        {
            StopFadeRoutine();
            SetCanvasGroupState(0f, false, false);
        }

        private void HandleConfirmPressed()
        {
            Confirmed?.Invoke();
        }

        private void FadeTo(bool visible)
        {
            if (rootCanvasGroup == null)
            {
                gameObject.SetActive(visible);
                return;
            }

            StopFadeRoutine();
            fadeRoutine = StartCoroutine(FadeRoutine(
                visible ? 1f : 0f,
                fadeDuration,
                visible,
                visible,
                !visible));
        }

        private IEnumerator FadeRoutine(
            float targetAlpha,
            float duration,
            bool blocksRaycastsAtEnd,
            bool interactableAtEnd,
            bool disableAtEnd)
        {
            if (rootCanvasGroup == null)
            {
                yield break;
            }

            float startAlpha = rootCanvasGroup.alpha;
            float safeDuration = duration > 0f ? duration : 0.01f;
            float elapsed = 0f;

            rootCanvasGroup.blocksRaycasts = false;
            rootCanvasGroup.interactable = false;

            while (elapsed < safeDuration)
            {
                elapsed += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(elapsed / safeDuration);
                float eased = Mathf.SmoothStep(0f, 1f, t);
                rootCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, eased);
                yield return null;
            }

            SetCanvasGroupState(targetAlpha, blocksRaycastsAtEnd, interactableAtEnd);

            if (disableAtEnd)
            {
                rootCanvasGroup.alpha = 0f;
            }

            fadeRoutine = null;
        }

        private void StopFadeRoutine()
        {
            if (fadeRoutine == null)
            {
                return;
            }

            StopCoroutine(fadeRoutine);
            fadeRoutine = null;
        }

        private void SetCanvasGroupState(float alpha, bool blocksRaycasts, bool interactable)
        {
            if (rootCanvasGroup == null)
            {
                return;
            }

            rootCanvasGroup.alpha = alpha;
            rootCanvasGroup.blocksRaycasts = blocksRaycasts;
            rootCanvasGroup.interactable = interactable;
        }
    }
}
