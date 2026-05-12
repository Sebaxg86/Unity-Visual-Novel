using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EntreTuSilencio.Systems
{
    [DisallowMultipleComponent]
    public class TrustController : MonoBehaviour
    {
        [SerializeField] private int minValue = 0;
        [SerializeField] private int maxValue = 3;
        [SerializeField] private int seongsuTrust;
        [SerializeField] private int jeonghoTrust;
        [SerializeField] private Image seongsuFillImage;
        [SerializeField] private Image jeonghoFillImage;
        [SerializeField] private TMP_Text seongsuValueText;
        [SerializeField] private TMP_Text jeonghoValueText;
        [SerializeField] private CanvasGroup tutorialCanvasGroup;

        public event Action<int, int> TrustChanged;

        public int SeongsuTrust => seongsuTrust;
        public int JeonghoTrust => jeonghoTrust;

        private void Awake()
        {
            UpdateVisuals();
            HideTutorial();
        }

        public void ResetTrust()
        {
            seongsuTrust = minValue;
            jeonghoTrust = minValue;
            UpdateVisuals();
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
            SetCanvasGroupState(tutorialCanvasGroup, true);
        }

        public void HideTutorial()
        {
            SetCanvasGroupState(tutorialCanvasGroup, false);
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
    }
}
