using System;
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

        public event Action Opened;
        public event Action Closed;

        public bool IsVisible => rootCanvasGroup != null && rootCanvasGroup.alpha > 0.99f;

        private void Awake()
        {
            if (rootCanvasGroup == null)
            {
                rootCanvasGroup = GetComponent<CanvasGroup>();
            }

            if (closeButton != null)
            {
                closeButton.onClick.AddListener(Hide);
            }

            SetVisibility(false);
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

            SetVisibility(true);
            Opened?.Invoke();
        }

        public void Hide()
        {
            SetVisibility(false);
            Closed?.Invoke();
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
    }
}
