using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EntreTuSilencio.Dialogue
{
    [DisallowMultipleComponent]
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup rootCanvasGroup;
        [SerializeField] private TMP_Text speakerNameText;
        [SerializeField] private TMP_Text bodyText;
        [SerializeField] private Image leftPortraitImage;
        [SerializeField] private Image rightPortraitImage;
        [SerializeField] private Button nextButton;
        [SerializeField] private float charactersPerSecond = 40f;
        [SerializeField] private Color defaultSpeakerColor = Color.white;
        [SerializeField] private Color activePortraitColor = Color.white;
        [SerializeField] private Color inactivePortraitColor = new Color(1f, 1f, 1f, 0.45f);

        private readonly List<DialogueLine> activeLines = new List<DialogueLine>();
        private Coroutine typingRoutine;
        private int currentIndex = -1;
        private bool sequenceCompleted;
        private string currentRenderedText = string.Empty;

        public event Action<int, DialogueLine> LineShown;
        public event Action SequenceFinished;

        public bool IsTyping { get; private set; }
        public DialogueLine CurrentLine => currentIndex >= 0 && currentIndex < activeLines.Count ? activeLines[currentIndex] : null;

        private void Awake()
        {
            if (rootCanvasGroup == null)
            {
                rootCanvasGroup = GetComponent<CanvasGroup>();
            }
        }

        public void Show()
        {
            SetVisibility(true);
        }

        public void Hide()
        {
            StopTyping();
            activeLines.Clear();
            currentIndex = -1;
            if (bodyText != null)
            {
                bodyText.text = string.Empty;
            }
            SetVisibility(false);
        }

        public void PlayLines(IList<DialogueLine> lines)
        {
            activeLines.Clear();
            sequenceCompleted = false;
            currentIndex = -1;

            if (lines == null || lines.Count == 0)
            {
                if (bodyText != null)
                {
                    bodyText.text = string.Empty;
                }
                return;
            }

            for (int i = 0; i < lines.Count; i++)
            {
                activeLines.Add(lines[i]);
            }

            Show();
            ShowLine(0);
        }

        public void OnNextPressed()
        {
            if (IsTyping)
            {
                CompleteTyping();
                return;
            }

            if (activeLines.Count == 0)
            {
                return;
            }

            int nextIndex = currentIndex + 1;
            if (nextIndex < activeLines.Count)
            {
                ShowLine(nextIndex);
                return;
            }

            if (sequenceCompleted)
            {
                return;
            }

            sequenceCompleted = true;
            SequenceFinished?.Invoke();
        }

        public void ShowLine(int index)
        {
            if (index < 0 || index >= activeLines.Count)
            {
                Debug.LogWarning($"Dialogue line index {index} is out of range.", this);
                return;
            }

            currentIndex = index;
            sequenceCompleted = false;

            DialogueLine line = activeLines[index];
            ApplySpeaker(line);
            ApplyPortraits(line);
            StartTyping(FormatBodyText(line));
            LineShown?.Invoke(index, line);
        }

        private void ApplySpeaker(DialogueLine line)
        {
            if (speakerNameText == null)
            {
                return;
            }

            bool showSpeaker = line.speakerMode != DialogueSpeakerMode.Narration && !string.IsNullOrWhiteSpace(line.speakerName);
            speakerNameText.gameObject.SetActive(showSpeaker);

            if (!showSpeaker)
            {
                speakerNameText.text = string.Empty;
                return;
            }

            speakerNameText.text = line.speakerName;
            speakerNameText.color = line.useSpeakerColor ? line.speakerColor : defaultSpeakerColor;
        }

        private void ApplyPortraits(DialogueLine line)
        {
            ApplyPortrait(leftPortraitImage, line.leftPortrait);
            ApplyPortrait(rightPortraitImage, line.rightPortrait);

            switch (line.portraitFocus)
            {
                case PortraitFocus.Left:
                    SetPortraitTint(leftPortraitImage, activePortraitColor);
                    SetPortraitTint(rightPortraitImage, inactivePortraitColor);
                    break;
                case PortraitFocus.Right:
                    SetPortraitTint(leftPortraitImage, inactivePortraitColor);
                    SetPortraitTint(rightPortraitImage, activePortraitColor);
                    break;
                default:
                    SetPortraitTint(leftPortraitImage, activePortraitColor);
                    SetPortraitTint(rightPortraitImage, activePortraitColor);
                    break;
            }
        }

        private void ApplyPortrait(Image targetImage, Sprite portrait)
        {
            if (targetImage == null)
            {
                return;
            }

            bool hasPortrait = portrait != null;
            targetImage.gameObject.SetActive(hasPortrait);

            if (hasPortrait)
            {
                targetImage.sprite = portrait;
            }
        }

        private void SetPortraitTint(Image targetImage, Color tint)
        {
            if (targetImage == null || !targetImage.gameObject.activeSelf)
            {
                return;
            }

            targetImage.color = tint;
        }

        private string FormatBodyText(DialogueLine line)
        {
            if (line == null || string.IsNullOrWhiteSpace(line.text))
            {
                return string.Empty;
            }

            switch (line.speakerMode)
            {
                case DialogueSpeakerMode.Signed:
                    return $"\"{line.text}\"";
                default:
                    return line.text;
            }
        }

        private void StartTyping(string fullText)
        {
            StopTyping();

            currentRenderedText = fullText ?? string.Empty;
            if (bodyText == null)
            {
                IsTyping = false;
                return;
            }

            bodyText.text = string.Empty;

            if (charactersPerSecond <= 0f)
            {
                bodyText.text = currentRenderedText;
                IsTyping = false;
                return;
            }

            typingRoutine = StartCoroutine(TypeTextRoutine());
        }

        private IEnumerator TypeTextRoutine()
        {
            IsTyping = true;

            float delay = 1f / charactersPerSecond;
            for (int i = 0; i < currentRenderedText.Length; i++)
            {
                bodyText.text += currentRenderedText[i];
                yield return new WaitForSeconds(delay);
            }

            IsTyping = false;
            typingRoutine = null;
        }

        private void CompleteTyping()
        {
            StopTyping();
            bodyText.text = currentRenderedText;
        }

        private void StopTyping()
        {
            if (typingRoutine != null)
            {
                StopCoroutine(typingRoutine);
                typingRoutine = null;
            }

            IsTyping = false;
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
