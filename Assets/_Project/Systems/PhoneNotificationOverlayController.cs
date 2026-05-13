using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EntreTuSilencio.Systems
{
    [DisallowMultipleComponent]
    public class PhoneNotificationOverlayController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup rootCanvasGroup;
        [SerializeField] private TMP_Text senderText;
        [SerializeField] private TMP_Text bodyText;
        [SerializeField] private Button tapButton;

        public event Action Clicked;

        public bool IsVisible => rootCanvasGroup != null && rootCanvasGroup.alpha > 0.99f;

        private void Awake()
        {
            if (rootCanvasGroup == null)
            {
                rootCanvasGroup = GetComponent<CanvasGroup>();
            }

            if (tapButton != null)
            {
                tapButton.onClick.AddListener(HandleClicked);
            }

            SetVisibility(false);
        }

        private void OnDestroy()
        {
            if (tapButton != null)
            {
                tapButton.onClick.RemoveListener(HandleClicked);
            }
        }

        public void Show(string sender, string body)
        {
            if (senderText != null)
            {
                senderText.text = sender ?? string.Empty;
            }

            if (bodyText != null)
            {
                bodyText.text = body ?? string.Empty;
            }

            SetVisibility(true);
        }

        public void Hide()
        {
            SetVisibility(false);
        }

        private void HandleClicked()
        {
            Hide();
            Clicked?.Invoke();
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
