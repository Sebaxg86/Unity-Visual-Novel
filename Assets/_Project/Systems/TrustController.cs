using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EntreTuSilencio.Systems
{
    public enum TrustHudFocus
    {
        None,
        Seongsu,
        Jeongho
    }

    [DisallowMultipleComponent]
    public class TrustController : MonoBehaviour
    {
        [SerializeField] private int minValue = 0;
        [SerializeField] private int maxValue = 3;
        [SerializeField] private int seongsuTrust;
        [SerializeField] private int jeonghoTrust;
        [SerializeField] private CanvasGroup hudCanvasGroup;
        [SerializeField] private Image seongsuFillImage;
        [SerializeField] private Image jeonghoFillImage;
        [SerializeField] private TMP_Text seongsuValueText;
        [SerializeField] private TMP_Text jeonghoValueText;
        [SerializeField] private CanvasGroup tutorialCanvasGroup;
        [SerializeField] private Button tutorialCloseButton;
        [SerializeField] private float tutorialFadeDuration = 0.2f;
        [SerializeField] private float hudFadeDuration = 0.16f;

        public event Action<int, int> TrustChanged;
        public event Action TutorialClosed;

        public int SeongsuTrust => seongsuTrust;
        public int JeonghoTrust => jeonghoTrust;
        public bool HasHud => hudCanvasGroup != null;
        public bool HasTutorial => tutorialCanvasGroup != null;
        public bool IsHudVisible => hudCanvasGroup != null && hudCanvasGroup.alpha > 0.99f;
        public bool IsTutorialVisible => tutorialCanvasGroup != null && tutorialCanvasGroup.alpha > 0.99f;
        public TrustHudFocus CurrentHudFocus => currentHudFocus;

        private TrustHudFocus currentHudFocus = TrustHudFocus.None;
        private Coroutine tutorialFadeRoutine;
        private Coroutine hudFadeRoutine;

        private void Awake()
        {
            if (tutorialCloseButton != null)
            {
                tutorialCloseButton.onClick.AddListener(DismissTutorial);
            }

            UpdateVisuals();
            HideHudImmediate();
            HideTutorialImmediate();
        }

        private void OnDestroy()
        {
            if (tutorialCloseButton != null)
            {
                tutorialCloseButton.onClick.RemoveListener(DismissTutorial);
            }
        }

        public void ResetTrust()
        {
            seongsuTrust = minValue;
            jeonghoTrust = minValue;
            currentHudFocus = TrustHudFocus.None;
            UpdateVisuals();
            HideHudImmediate();
            HideTutorialImmediate();
            TrustChanged?.Invoke(seongsuTrust, jeonghoTrust);
        }

        public void ApplyDeltas(int seongsuDelta, int jeonghoDelta)
        {
            seongsuTrust = Mathf.Clamp(seongsuTrust + seongsuDelta, minValue, maxValue);
            jeonghoTrust = Mathf.Clamp(jeonghoTrust + jeonghoDelta, minValue, maxValue);
            UpdateVisuals();
            TrustChanged?.Invoke(seongsuTrust, jeonghoTrust);
        }

        public void ShowTutorial()
        {
            HideHudImmediate();
            FadeTutorialTo(true);
        }

        public void HideTutorial()
        {
            HideTutorialImmediate();
        }

        public void ShowHud()
        {
            UpdateHudFocusVisibility();
            FadeHudTo(true);
        }

        public void HideHud()
        {
            HideHudImmediate();
        }

        public void SetHudFocus(TrustHudFocus focus)
        {
            currentHudFocus = focus;
            UpdateHudFocusVisibility();
        }

        public void ShowTutorialOrHud()
        {
            if (HasTutorial)
            {
                ShowTutorial();
                return;
            }

            ShowHud();
        }

        public void DismissTutorial()
        {
            StartCoroutine(DismissTutorialRoutine());
        }

        private void UpdateVisuals()
        {
            UpdateFill(seongsuFillImage, seongsuTrust);
            UpdateFill(jeonghoFillImage, jeonghoTrust);

            if (seongsuValueText != null)
            {
                seongsuValueText.text = seongsuTrust.ToString();
            }

            if (jeonghoValueText != null)
            {
                jeonghoValueText.text = jeonghoTrust.ToString();
            }

            UpdateHudFocusVisibility();
        }

        private void UpdateFill(Image targetImage, int currentValue)
        {
            if (targetImage == null)
            {
                return;
            }

            float normalized = maxValue <= minValue ? 0f : Mathf.InverseLerp(minValue, maxValue, currentValue);
            targetImage.fillAmount = normalized;
        }

        private void SetCanvasGroupState(CanvasGroup canvasGroup, bool visible)
        {
            if (canvasGroup == null)
            {
                return;
            }

            canvasGroup.alpha = visible ? 1f : 0f;
            canvasGroup.blocksRaycasts = visible;
            canvasGroup.interactable = visible;
        }

        private IEnumerator DismissTutorialRoutine()
        {
            if (tutorialCanvasGroup != null)
            {
                yield return FadeCanvasGroupRoutine(tutorialCanvasGroup, 0f, tutorialFadeDuration, false, false, true);
            }
            else
            {
                HideTutorialImmediate();
            }

            ShowHud();
            TutorialClosed?.Invoke();
        }

        private void FadeTutorialTo(bool visible)
        {
            if (tutorialCanvasGroup == null)
            {
                return;
            }

            StopTutorialFade();
            tutorialFadeRoutine = StartCoroutine(FadeCanvasGroupRoutine(
                tutorialCanvasGroup,
                visible ? 1f : 0f,
                tutorialFadeDuration,
                visible,
                visible,
                !visible));
        }

        private void FadeHudTo(bool visible)
        {
            if (hudCanvasGroup == null)
            {
                return;
            }

            StopHudFade();
            hudFadeRoutine = StartCoroutine(FadeCanvasGroupRoutine(
                hudCanvasGroup,
                visible ? 1f : 0f,
                hudFadeDuration,
                visible,
                visible,
                !visible));
        }

        private IEnumerator FadeCanvasGroupRoutine(
            CanvasGroup canvasGroup,
            float targetAlpha,
            float duration,
            bool blocksRaycastsAtEnd,
            bool interactableAtEnd,
            bool disableAtEnd)
        {
            if (canvasGroup == null)
            {
                yield break;
            }

            float startAlpha = canvasGroup.alpha;
            float safeDuration = duration > 0f ? duration : 0.01f;
            float elapsed = 0f;

            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;

            while (elapsed < safeDuration)
            {
                elapsed += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(elapsed / safeDuration);
                float eased = Mathf.SmoothStep(0f, 1f, t);
                canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, eased);
                yield return null;
            }

            canvasGroup.alpha = targetAlpha;
            canvasGroup.blocksRaycasts = blocksRaycastsAtEnd;
            canvasGroup.interactable = interactableAtEnd;

            if (disableAtEnd)
            {
                canvasGroup.alpha = 0f;
            }

            if (canvasGroup == tutorialCanvasGroup)
            {
                tutorialFadeRoutine = null;
            }
            else if (canvasGroup == hudCanvasGroup)
            {
                hudFadeRoutine = null;
            }
        }

        private void HideTutorialImmediate()
        {
            StopTutorialFade();
            SetCanvasGroupState(tutorialCanvasGroup, false);
        }

        private void HideHudImmediate()
        {
            StopHudFade();
            SetCanvasGroupState(hudCanvasGroup, false);
        }

        private void StopTutorialFade()
        {
            if (tutorialFadeRoutine == null)
            {
                return;
            }

            StopCoroutine(tutorialFadeRoutine);
            tutorialFadeRoutine = null;
        }

        private void StopHudFade()
        {
            if (hudFadeRoutine == null)
            {
                return;
            }

            StopCoroutine(hudFadeRoutine);
            hudFadeRoutine = null;
        }

        private void UpdateHudFocusVisibility()
        {
            SetGraphicState(seongsuFillImage, currentHudFocus == TrustHudFocus.Seongsu);
            SetGraphicState(jeonghoFillImage, currentHudFocus == TrustHudFocus.Jeongho);
            SetTextState(seongsuValueText, currentHudFocus == TrustHudFocus.Seongsu);
            SetTextState(jeonghoValueText, currentHudFocus == TrustHudFocus.Jeongho);
        }

        private void SetGraphicState(Graphic targetGraphic, bool visible)
        {
            if (targetGraphic == null)
            {
                return;
            }

            targetGraphic.gameObject.SetActive(visible);
        }

        private void SetTextState(TMP_Text targetText, bool visible)
        {
            if (targetText == null)
            {
                return;
            }

            targetText.gameObject.SetActive(visible);
        }
    }
}
