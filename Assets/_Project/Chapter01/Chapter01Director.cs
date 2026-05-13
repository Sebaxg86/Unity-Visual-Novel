using System;
using System.Collections;
using EntreTuSilencio.Core;
using EntreTuSilencio.Dialogue;
using EntreTuSilencio.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace EntreTuSilencio.Chapter01
{
    [Serializable]
    public class ChapterChoiceBeat
    {
        [TextArea(2, 4)]
        public string prompt;

        public ChoiceOption[] options;
    }

    public enum Chapter01Beat
    {
        None,
        Intro,
        WaitingForPhoneClose,
        Room,
        RoomExploration,
        Friends,
        FirstChoice,
        Hallway,
        SecondChoice,
        Cafeteria,
        ThirdChoice,
        Ending,
        Completed
    }

    [DisallowMultipleComponent]
    public class Chapter01Director : MonoBehaviour
    {
        [Header("Boot")]
        [SerializeField] private bool playOnStart = true;
        [SerializeField] private float openingFadeDuration = 0.45f;
        [SerializeField] private float endingFadeDuration = 0.75f;
        [SerializeField] private bool useFallbackDataWhenEmpty = true;
        [SerializeField] private float firstChoiceTutorialDuration = 2.75f;

        [Header("Scene References")]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private FadeOverlayController fadeOverlayController;
        [SerializeField] private SceneFlowController sceneFlowController;
        [SerializeField] private DialogueController dialogueController;
        [SerializeField] private ChoiceController choiceController;
        [SerializeField] private PhoneOverlayController phoneOverlayController;
        [SerializeField] private TrustController trustController;
        [SerializeField] private CanvasGroup roomExitCanvasGroup;
        [SerializeField] private Button roomExitButton;

        [Header("Backgrounds")]
        [SerializeField] private Sprite introBackground;
        [SerializeField] private Sprite roomBackground;
        [SerializeField] private Sprite friendsBackground;
        [SerializeField] private Sprite hallwayBackground;
        [SerializeField] private Sprite cafeteriaBackground;

        [Header("Phone")]
        [SerializeField] private Sprite firstPhoneMessage;

        [Header("Dialogue")]
        [SerializeField] private DialogueLine[] introLines;
        [SerializeField] private DialogueLine[] roomLines;
        [SerializeField] private DialogueLine[] friendsLines;
        [SerializeField] private DialogueLine[] hallwayLines;
        [SerializeField] private DialogueLine[] cafeteriaLines;
        [SerializeField] private DialogueLine[] endingLines;

        [Header("Choices")]
        [SerializeField] private ChapterChoiceBeat firstChoice;
        [SerializeField] private ChapterChoiceBeat secondChoice;
        [SerializeField] private ChapterChoiceBeat thirdChoice;

        public Chapter01Beat CurrentBeat { get; private set; }

        private void OnEnable()
        {
            if (dialogueController != null)
            {
                dialogueController.SequenceFinished += HandleDialogueFinished;
            }

            if (choiceController != null)
            {
                choiceController.ChoiceSelected += HandleChoiceSelected;
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.Closed += HandlePhoneClosed;
            }

            if (roomExitButton != null)
            {
                roomExitButton.onClick.AddListener(HandleRoomExitClicked);
            }
        }

        private void OnDisable()
        {
            if (dialogueController != null)
            {
                dialogueController.SequenceFinished -= HandleDialogueFinished;
            }

            if (choiceController != null)
            {
                choiceController.ChoiceSelected -= HandleChoiceSelected;
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.Closed -= HandlePhoneClosed;
            }

            if (roomExitButton != null)
            {
                roomExitButton.onClick.RemoveListener(HandleRoomExitClicked);
            }
        }

        private void Start()
        {
            if (playOnStart)
            {
                BeginChapter();
            }
        }

        public void BeginChapter()
        {
            StopAllCoroutines();
            CurrentBeat = Chapter01Beat.None;

            if (choiceController != null)
            {
                choiceController.Hide();
            }

            if (phoneOverlayController != null)
            {
                phoneOverlayController.Hide();
            }

            if (trustController != null)
            {
                trustController.ResetTrust();
                trustController.HideTutorial();
            }

            SetCanvasGroupState(roomExitCanvasGroup, false);

            StartCoroutine(BeginChapterRoutine());
        }

        public void ReturnToMainMenu()
        {
            if (sceneFlowController != null)
            {
                sceneFlowController.LoadMainMenu();
            }
        }

        private IEnumerator BeginChapterRoutine()
        {
            SetBackground(introBackground);

            if (fadeOverlayController != null)
            {
                fadeOverlayController.ShowInstant();
                yield return fadeOverlayController.PlayFadeFromBlack(openingFadeDuration);
            }

            BeginIntro();
        }

        private void BeginIntro()
        {
            CurrentBeat = Chapter01Beat.Intro;
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Intro), BeginPhoneBeat);
        }

        private void BeginPhoneBeat()
        {
            SetBackground(roomBackground);
            CurrentBeat = Chapter01Beat.WaitingForPhoneClose;

            if (phoneOverlayController != null && firstPhoneMessage != null)
            {
                phoneOverlayController.Show(firstPhoneMessage);
                return;
            }

            BeginRoomDialogue();
        }

        private void HandlePhoneClosed()
        {
            if (CurrentBeat == Chapter01Beat.WaitingForPhoneClose)
            {
                BeginRoomDialogue();
            }
        }

        private void BeginRoomDialogue()
        {
            CurrentBeat = Chapter01Beat.Room;
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Room), BeginRoomExploration);
        }

        private void BeginRoomExploration()
        {
            if (roomExitCanvasGroup == null && roomExitButton == null)
            {
                BeginFriendsDialogue();
                return;
            }

            CurrentBeat = Chapter01Beat.RoomExploration;
            SetCanvasGroupState(roomExitCanvasGroup, true);

            if (dialogueController != null)
            {
                dialogueController.Hide();
            }
        }

        private void BeginFriendsDialogue()
        {
            SetBackground(friendsBackground);
            CurrentBeat = Chapter01Beat.Friends;
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Friends), BeginFirstChoice);
        }

        private void BeginFirstChoice()
        {
            CurrentBeat = Chapter01Beat.FirstChoice;

            if (trustController != null)
            {
                StartCoroutine(ShowFirstChoiceAfterTutorialRoutine());
                return;
            }

            ShowChoiceOrContinue(GetChoiceBeatFor(Chapter01Beat.FirstChoice), BeginHallwayDialogue);
        }

        private void BeginHallwayDialogue()
        {
            if (trustController != null)
            {
                trustController.HideTutorial();
            }

            SetBackground(hallwayBackground);
            CurrentBeat = Chapter01Beat.Hallway;
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Hallway), BeginSecondChoice);
        }

        private void BeginSecondChoice()
        {
            CurrentBeat = Chapter01Beat.SecondChoice;
            ShowChoiceOrContinue(GetChoiceBeatFor(Chapter01Beat.SecondChoice), BeginCafeteriaDialogue);
        }

        private void BeginCafeteriaDialogue()
        {
            SetBackground(cafeteriaBackground);
            CurrentBeat = Chapter01Beat.Cafeteria;
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Cafeteria), BeginThirdChoice);
        }

        private void BeginThirdChoice()
        {
            CurrentBeat = Chapter01Beat.ThirdChoice;
            ShowChoiceOrContinue(GetChoiceBeatFor(Chapter01Beat.ThirdChoice), BeginEndingDialogue);
        }

        private void BeginEndingDialogue()
        {
            CurrentBeat = Chapter01Beat.Ending;
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Ending), CompleteChapter);
        }

        private void CompleteChapter()
        {
            if (CurrentBeat == Chapter01Beat.Completed)
            {
                return;
            }

            CurrentBeat = Chapter01Beat.Completed;
            StartCoroutine(CompleteChapterRoutine());
        }

        private IEnumerator CompleteChapterRoutine()
        {
            if (fadeOverlayController != null)
            {
                yield return fadeOverlayController.PlayFadeToBlack(endingFadeDuration);
            }
        }

        private void HandleDialogueFinished()
        {
            switch (CurrentBeat)
            {
                case Chapter01Beat.Intro:
                    BeginPhoneBeat();
                    break;
                case Chapter01Beat.Room:
                    BeginRoomExploration();
                    break;
                case Chapter01Beat.Friends:
                    BeginFirstChoice();
                    break;
                case Chapter01Beat.Hallway:
                    BeginSecondChoice();
                    break;
                case Chapter01Beat.Cafeteria:
                    BeginThirdChoice();
                    break;
                case Chapter01Beat.Ending:
                    CompleteChapter();
                    break;
            }
        }

        private void HandleChoiceSelected(ChoiceOption selectedOption)
        {
            if (selectedOption != null && trustController != null)
            {
                trustController.ApplyDeltas(selectedOption.seongsuTrustDelta, selectedOption.jeonghoTrustDelta);
            }

            switch (CurrentBeat)
            {
                case Chapter01Beat.FirstChoice:
                    BeginHallwayDialogue();
                    break;
                case Chapter01Beat.SecondChoice:
                    BeginCafeteriaDialogue();
                    break;
                case Chapter01Beat.ThirdChoice:
                    BeginEndingDialogue();
                    break;
            }
        }

        private void PlayDialogueOrContinue(DialogueLine[] lines, Action onEmpty)
        {
            if (dialogueController == null)
            {
                onEmpty?.Invoke();
                return;
            }

            if (lines == null || lines.Length == 0)
            {
                onEmpty?.Invoke();
                return;
            }

            dialogueController.PlayLines(lines);
        }

        private void ShowChoiceOrContinue(ChapterChoiceBeat beat, Action onEmpty)
        {
            if (choiceController == null || beat == null || beat.options == null || beat.options.Length == 0)
            {
                onEmpty?.Invoke();
                return;
            }

            choiceController.ShowChoice(beat.prompt, beat.options);
        }

        private void SetBackground(Sprite backgroundSprite)
        {
            if (backgroundImage == null || backgroundSprite == null)
            {
                return;
            }

            backgroundImage.sprite = backgroundSprite;
        }

        private void HandleRoomExitClicked()
        {
            if (CurrentBeat != Chapter01Beat.RoomExploration)
            {
                return;
            }

            SetCanvasGroupState(roomExitCanvasGroup, false);
            BeginFriendsDialogue();
        }

        private IEnumerator ShowFirstChoiceAfterTutorialRoutine()
        {
            trustController.ShowTutorial();

            if (firstChoiceTutorialDuration > 0f)
            {
                yield return new WaitForSeconds(firstChoiceTutorialDuration);
            }

            trustController.HideTutorial();
            ShowChoiceOrContinue(GetChoiceBeatFor(Chapter01Beat.FirstChoice), BeginHallwayDialogue);
        }

        private void SetCanvasGroupState(CanvasGroup canvasGroup, bool visible)
        {
            if (canvasGroup == null)
            {
                return;
            }

            canvasGroup.alpha = visible ? 1f : 0f;
            canvasGroup.interactable = visible;
            canvasGroup.blocksRaycasts = visible;
        }

        private DialogueLine[] GetDialogueLinesForBeat(Chapter01Beat beat)
        {
            DialogueLine[] configuredLines = beat switch
            {
                Chapter01Beat.Intro => introLines,
                Chapter01Beat.Room => roomLines,
                Chapter01Beat.Friends => friendsLines,
                Chapter01Beat.Hallway => hallwayLines,
                Chapter01Beat.Cafeteria => cafeteriaLines,
                Chapter01Beat.Ending => endingLines,
                _ => null
            };

            if (configuredLines != null && configuredLines.Length > 0)
            {
                return configuredLines;
            }

            return useFallbackDataWhenEmpty ? BuildFallbackLines(beat) : null;
        }

        private ChapterChoiceBeat GetChoiceBeatFor(Chapter01Beat beat)
        {
            ChapterChoiceBeat configuredChoice = beat switch
            {
                Chapter01Beat.FirstChoice => firstChoice,
                Chapter01Beat.SecondChoice => secondChoice,
                Chapter01Beat.ThirdChoice => thirdChoice,
                _ => null
            };

            if (configuredChoice != null && configuredChoice.options != null && configuredChoice.options.Length > 0)
            {
                return configuredChoice;
            }

            return useFallbackDataWhenEmpty ? BuildFallbackChoice(beat) : null;
        }

        private DialogueLine[] BuildFallbackLines(Chapter01Beat beat)
        {
            Sprite leftPortrait = dialogueController != null ? dialogueController.LeftPortraitSprite : null;
            Sprite rightPortrait = dialogueController != null ? dialogueController.RightPortraitSprite : null;

            switch (beat)
            {
                case Chapter01Beat.Intro:
                    return new[]
                    {
                        CreateLine(string.Empty, "Otro dia. Otro intento de salir de casa sin sentir que el pecho pesa demasiado.", DialogueSpeakerMode.Thought),
                        CreateLine(string.Empty, "Tal vez hoy pueda soportarlo un poco mejor.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.Room:
                    return new[]
                    {
                        CreateLine(string.Empty, "Seongsu ya empezo con su energia de siempre.", DialogueSpeakerMode.Thought),
                        CreateLine(string.Empty, "Si no me apuro, va a venir a arrastrarme ella misma.", DialogueSpeakerMode.Thought),
                        CreateLine(string.Empty, "Bien. Respiro. Me cambio. Salgo.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.Friends:
                    return new[]
                    {
                        CreateLine("Seongsu", "Sabia que ibas a tardarte. Por eso te escribi temprano.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine("Jeongho", "Igual llego antes de que tuvieras que ir por ella.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Los dos estan aqui. Eso deberia tranquilizarme.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                    };
                case Chapter01Beat.Hallway:
                    return new[]
                    {
                        CreateLine(string.Empty, "El ruido del pasillo siempre llega primero que el valor.", DialogueSpeakerMode.Thought),
                        CreateLine("Seongsu", "Vamos juntos. Solo es el primer dia.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                    };
                case Chapter01Beat.Cafeteria:
                    return new[]
                    {
                        CreateLine("Seongsu", "Si sobrevivimos a la mañana, merecemos algo rico en la cafeteria.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine("Jeongho", "Eso sono mas dramatico de lo necesario.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Aun asi, la idea de sentarnos un rato no suena mal.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                    };
                case Chapter01Beat.Ending:
                    return new[]
                    {
                        CreateLine(string.Empty, "Por un segundo, siento que alguien me observa desde lejos.", DialogueSpeakerMode.Thought),
                        CreateLine(string.Empty, "Capitulo 1 terminado.", DialogueSpeakerMode.Narration),
                    };
                default:
                    return null;
            }
        }

        private ChapterChoiceBeat BuildFallbackChoice(Chapter01Beat beat)
        {
            switch (beat)
            {
                case Chapter01Beat.FirstChoice:
                    return new ChapterChoiceBeat
                    {
                        prompt = "¿Como reacciona Jihuun al ver a sus amigos?",
                        options = new[]
                        {
                            CreateChoice("smile_softly", "Sonrie ligeramente.", 1, 1),
                            CreateChoice("just_watch", "Solo observa.", 0, 0),
                            CreateChoice("sign_to_jeongho", "Hace una sena a Jeongho.", 0, 1),
                        }
                    };
                case Chapter01Beat.SecondChoice:
                    return new ChapterChoiceBeat
                    {
                        prompt = "¿Como procesa el ruido del pasillo?",
                        options = new[]
                        {
                            CreateChoice("look_around", "Mirar a la gente.", 0, 0),
                            CreateChoice("look_down", "Bajar la mirada.", 0, 0),
                            CreateChoice("ignore_everything", "Ignorar todo.", 0, 0),
                        }
                    };
                case Chapter01Beat.ThirdChoice:
                    return new ChapterChoiceBeat
                    {
                        prompt = "¿Como participa Jihuun en la conversacion?",
                        options = new[]
                        {
                            CreateChoice("propose_weekend_plan", "Propone un plan para el fin de semana.", 1, 1),
                            CreateChoice("just_watch_again", "Solo observa.", 0, 0),
                            CreateChoice("write_on_phone", "Escribe su idea en el celular.", 1, 1),
                        }
                    };
                default:
                    return null;
            }
        }

        private DialogueLine CreateLine(
            string speakerName,
            string text,
            DialogueSpeakerMode speakerMode,
            PortraitFocus portraitFocus = PortraitFocus.None,
            Sprite leftPortrait = null,
            Sprite rightPortrait = null)
        {
            return new DialogueLine
            {
                speakerName = speakerName,
                speakerMode = speakerMode,
                portraitFocus = portraitFocus,
                leftPortrait = leftPortrait,
                rightPortrait = rightPortrait,
                text = text
            };
        }

        private ChoiceOption CreateChoice(string optionId, string label, int seongsuDelta, int jeonghoDelta)
        {
            return new ChoiceOption
            {
                optionId = optionId,
                label = label,
                seongsuTrustDelta = seongsuDelta,
                jeonghoTrustDelta = jeonghoDelta
            };
        }
    }
}
