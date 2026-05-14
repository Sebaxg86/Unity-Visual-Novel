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
        [SerializeField] private bool captureSpeakerNameTextColorOnAwake = true;
        [SerializeField] private Color activePortraitColor = Color.white;
        [SerializeField] private Color inactivePortraitColor = new Color(1f, 1f, 1f, 0.45f);
        [SerializeField] private bool animatePortraitEntrances = true;
        [SerializeField] private float portraitEntranceDuration = 0.22f;
        [SerializeField] private float portraitEntranceOffset = 160f;

        private readonly List<DialogueLine> activeLines = new List<DialogueLine>();
        private Coroutine typingRoutine;
        private Coroutine leftPortraitSequenceRoutine;
        private Coroutine rightPortraitSequenceRoutine;
        private Coroutine leftPortraitEntranceRoutine;
        private Coroutine rightPortraitEntranceRoutine;
        private int currentIndex = -1;
        private bool sequenceCompleted;
        private string currentRenderedText = string.Empty;
        private Vector2 leftPortraitDefaultPosition;
        private Vector2 rightPortraitDefaultPosition;

        public event Action<int, DialogueLine> LineShown;
        public event Action SequenceFinished;

        public bool IsTyping { get; private set; }
        public DialogueLine CurrentLine => currentIndex >= 0 && currentIndex < activeLines.Count ? activeLines[currentIndex] : null;
        public Sprite LeftPortraitSprite => leftPortraitImage != null ? leftPortraitImage.sprite : null;
        public Sprite RightPortraitSprite => rightPortraitImage != null ? rightPortraitImage.sprite : null;

        private void Awake()
        {
            if (rootCanvasGroup == null)
            {
                rootCanvasGroup = GetComponent<CanvasGroup>();
            }

            if (captureSpeakerNameTextColorOnAwake && speakerNameText != null)
            {
                defaultSpeakerColor = speakerNameText.color;
            }

            leftPortraitDefaultPosition = GetPortraitAnchoredPosition(leftPortraitImage);
            rightPortraitDefaultPosition = GetPortraitAnchoredPosition(rightPortraitImage);
        }

        public void Show()
        {
            SetVisibility(true);
        }

        public void Hide()
        {
            StopTyping();
            StopPortraitSequences();
            StopPortraitEntranceAnimations();
            activeLines.Clear();
            currentIndex = -1;

            if (speakerNameText != null)
            {
                speakerNameText.text = string.Empty;
                speakerNameText.gameObject.SetActive(false);
            }

            if (bodyText != null)
            {
                bodyText.text = string.Empty;
            }

            if (leftPortraitImage != null)
            {
                leftPortraitImage.gameObject.SetActive(false);
            }

            if (rightPortraitImage != null)
            {
                rightPortraitImage.gameObject.SetActive(false);
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
            StopPortraitSequences();
            StopPortraitEntranceAnimations();

            if (line == null)
            {
                ApplyPortrait(leftPortraitImage, null);
                ApplyPortrait(rightPortraitImage, null);
                return;
            }

            if (line.speakerMode == DialogueSpeakerMode.Narration || line.speakerMode == DialogueSpeakerMode.Thought)
            {
                ApplyPortrait(leftPortraitImage, null);
                ApplyPortrait(rightPortraitImage, null);
                return;
            }

            bool leftWasVisible = leftPortraitImage != null && leftPortraitImage.gameObject.activeSelf;
            bool rightWasVisible = rightPortraitImage != null && rightPortraitImage.gameObject.activeSelf;

            Sprite leftPortrait = GetPortraitStartSprite(line.leftPortrait, line.leftPortraitSequence);
            Sprite rightPortrait = GetPortraitStartSprite(line.rightPortrait, line.rightPortraitSequence);

            ApplyPortrait(leftPortraitImage, leftPortrait);
            ApplyPortrait(rightPortraitImage, rightPortrait);

            AnimatePortraitEntranceIfNeeded(leftPortraitImage, leftWasVisible, leftPortrait, true);
            AnimatePortraitEntranceIfNeeded(rightPortraitImage, rightWasVisible, rightPortrait, false);

            if (line.speakerMode == DialogueSpeakerMode.Signed && IsSpeaker(line, "Jihuun"))
            {
                SetPortraitTint(leftPortraitImage, inactivePortraitColor);
                SetPortraitTint(rightPortraitImage, inactivePortraitColor);
            }
            else
            {
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

            StartPortraitSequence(leftPortraitImage, line.leftPortraitSequence, line.portraitSequenceFrameDuration, true);
            StartPortraitSequence(rightPortraitImage, line.rightPortraitSequence, line.portraitSequenceFrameDuration, false);
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

        private Vector2 GetPortraitAnchoredPosition(Image portraitImage)
        {
            if (portraitImage == null)
            {
                return Vector2.zero;
            }

            RectTransform rectTransform = portraitImage.transform as RectTransform;
            if (rectTransform == null)
            {
                return Vector2.zero;
            }

            return rectTransform.anchoredPosition;
        }

        private void AnimatePortraitEntranceIfNeeded(Image targetImage, bool wasVisible, Sprite portrait, bool isLeftPortrait)
        {
            if (targetImage == null || portrait == null)
            {
                return;
            }

            RectTransform rectTransform = targetImage.transform as RectTransform;
            if (rectTransform == null)
            {
                return;
            }

            Vector2 defaultPosition = isLeftPortrait ? leftPortraitDefaultPosition : rightPortraitDefaultPosition;

            if (!animatePortraitEntrances || wasVisible)
            {
                rectTransform.anchoredPosition = defaultPosition;
                return;
            }

            float direction = isLeftPortrait ? -1f : 1f;
            Vector2 startPosition = defaultPosition + new Vector2(direction * portraitEntranceOffset, 0f);
            rectTransform.anchoredPosition = startPosition;

            Coroutine entranceRoutine = StartCoroutine(PlayPortraitEntranceRoutine(rectTransform, startPosition, defaultPosition));
            if (isLeftPortrait)
            {
                leftPortraitEntranceRoutine = entranceRoutine;
            }
            else
            {
                rightPortraitEntranceRoutine = entranceRoutine;
            }
        }

        private Sprite GetPortraitStartSprite(Sprite fallbackPortrait, Sprite[] portraitSequence)
        {
            if (portraitSequence != null)
            {
                for (int i = 0; i < portraitSequence.Length; i++)
                {
                    if (portraitSequence[i] != null)
                    {
                        return portraitSequence[i];
                    }
                }
            }

            return fallbackPortrait;
        }

        private void StartPortraitSequence(Image targetImage, Sprite[] portraitSequence, float frameDuration, bool isLeftPortrait)
        {
            if (targetImage == null || !targetImage.gameObject.activeSelf)
            {
                return;
            }

            if (portraitSequence == null || portraitSequence.Length <= 1)
            {
                return;
            }

            Coroutine sequenceRoutine = StartCoroutine(PlayPortraitSequenceRoutine(targetImage, portraitSequence, frameDuration));

            if (isLeftPortrait)
            {
                leftPortraitSequenceRoutine = sequenceRoutine;
            }
            else
            {
                rightPortraitSequenceRoutine = sequenceRoutine;
            }
        }

        private IEnumerator PlayPortraitSequenceRoutine(Image targetImage, Sprite[] portraitSequence, float frameDuration)
        {
            if (targetImage == null || portraitSequence == null || portraitSequence.Length == 0)
            {
                yield break;
            }

            float safeFrameDuration = frameDuration > 0f ? frameDuration : 0.12f;

            for (int i = 0; i < portraitSequence.Length; i++)
            {
                Sprite frame = portraitSequence[i];
                if (frame != null)
                {
                    targetImage.sprite = frame;
                }

                if (i < portraitSequence.Length - 1)
                {
                    yield return new WaitForSecondsRealtime(safeFrameDuration);
                }
            }
        }

        private void StopPortraitSequences()
        {
            if (leftPortraitSequenceRoutine != null)
            {
                StopCoroutine(leftPortraitSequenceRoutine);
                leftPortraitSequenceRoutine = null;
            }

            if (rightPortraitSequenceRoutine != null)
            {
                StopCoroutine(rightPortraitSequenceRoutine);
                rightPortraitSequenceRoutine = null;
            }
        }

        private IEnumerator PlayPortraitEntranceRoutine(RectTransform portraitTransform, Vector2 startPosition, Vector2 targetPosition)
        {
            if (portraitTransform == null)
            {
                yield break;
            }

            float duration = portraitEntranceDuration > 0f ? portraitEntranceDuration : 0.01f;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(elapsed / duration);
                float eased = Mathf.SmoothStep(0f, 1f, t);
                portraitTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, eased);
                yield return null;
            }

            portraitTransform.anchoredPosition = targetPosition;
        }

        private void StopPortraitEntranceAnimations()
        {
            StopPortraitEntranceAnimation(ref leftPortraitEntranceRoutine, leftPortraitImage, leftPortraitDefaultPosition);
            StopPortraitEntranceAnimation(ref rightPortraitEntranceRoutine, rightPortraitImage, rightPortraitDefaultPosition);
        }

        private void StopPortraitEntranceAnimation(ref Coroutine entranceRoutine, Image portraitImage, Vector2 defaultPosition)
        {
            if (entranceRoutine != null)
            {
                StopCoroutine(entranceRoutine);
                entranceRoutine = null;
            }

            if (portraitImage != null)
            {
                RectTransform rectTransform = portraitImage.transform as RectTransform;
                if (rectTransform != null)
                {
                    rectTransform.anchoredPosition = defaultPosition;
                }
            }
        }

        private bool IsSpeaker(DialogueLine line, string speakerName)
        {
            return line != null
                && !string.IsNullOrWhiteSpace(line.speakerName)
                && line.speakerName.Equals(speakerName, StringComparison.OrdinalIgnoreCase);
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
