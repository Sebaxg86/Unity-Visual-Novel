using System.Collections;
using UnityEngine;

namespace EntreTuSilencio.Core
{
    [DisallowMultipleComponent]
    public class FadeOverlayController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup overlayCanvasGroup;
        [SerializeField] private float defaultDuration = 0.35f;

        private Coroutine currentFadeRoutine;

        public bool IsVisible => overlayCanvasGroup != null && overlayCanvasGroup.alpha > 0.99f;

        private void Awake()
        {
            if (overlayCanvasGroup == null)
            {
                overlayCanvasGroup = GetComponent<CanvasGroup>();
            }
        }

        public void ShowInstant()
        {
            StopCurrentFade();
            SetState(1f);
        }

        public void HideInstant()
        {
            StopCurrentFade();
            SetState(0f);
        }

        public void FadeToBlack()
        {
            StartFade(1f, defaultDuration, true);
        }

        public void FadeFromBlack()
        {
            StartFade(0f, defaultDuration, true);
        }

        public IEnumerator PlayFadeToBlack(float duration, bool useUnscaledTime = true)
        {
            yield return FadeRoutine(1f, Mathf.Max(0.01f, duration), useUnscaledTime);
        }

        public IEnumerator PlayFadeFromBlack(float duration, bool useUnscaledTime = true)
        {
            yield return FadeRoutine(0f, Mathf.Max(0.01f, duration), useUnscaledTime);
        }

        public void StartFade(float targetAlpha, float duration, bool useUnscaledTime = true)
        {
            if (overlayCanvasGroup == null)
            {
                Debug.LogWarning("FadeOverlayController needs a CanvasGroup reference.", this);
                return;
            }

            StopCurrentFade();
            currentFadeRoutine = StartCoroutine(FadeRoutine(targetAlpha, Mathf.Max(0.01f, duration), useUnscaledTime));
        }

        private IEnumerator FadeRoutine(float targetAlpha, float duration, bool useUnscaledTime)
        {
            if (overlayCanvasGroup == null)
            {
                yield break;
            }

            float startAlpha = overlayCanvasGroup.alpha;
            float elapsed = 0f;

            overlayCanvasGroup.gameObject.SetActive(true);

            while (elapsed < duration)
            {
                elapsed += useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / duration);
                SetState(Mathf.Lerp(startAlpha, targetAlpha, t));
                yield return null;
            }

            SetState(targetAlpha);
            currentFadeRoutine = null;
        }

        private void StopCurrentFade()
        {
            if (currentFadeRoutine == null)
            {
                return;
            }

            StopCoroutine(currentFadeRoutine);
            currentFadeRoutine = null;
        }

        private void SetState(float alpha)
        {
            if (overlayCanvasGroup == null)
            {
                return;
            }

            overlayCanvasGroup.alpha = Mathf.Clamp01(alpha);
            bool visible = overlayCanvasGroup.alpha > 0.001f;
            overlayCanvasGroup.blocksRaycasts = visible;
            overlayCanvasGroup.interactable = visible;
        }
    }
}
