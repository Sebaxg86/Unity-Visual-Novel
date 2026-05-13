using System;
using System.Collections;
using EntreTuSilencio.Core;
using EntreTuSilencio.Dialogue;
using EntreTuSilencio.Systems;
using TMPro;
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
        RoomInspectingBonsai,
        RoomInspectingProteinBar,
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

        [Header("Canonical Intro")]
        [SerializeField] private bool useCanonicalIntroSequence = true;
        [SerializeField] private CanvasGroup introSavingCanvasGroup;
        [SerializeField] private CanvasGroup introChapterTitleCanvasGroup;
        [SerializeField] private CanvasGroup introMonologueCanvasGroup;
        [SerializeField] private TMP_Text introSavingText;
        [SerializeField] private TMP_Text introChapterNumberText;
        [SerializeField] private TMP_Text introChapterNameText;
        [SerializeField] private TMP_Text introMonologueText;
        [SerializeField] private float introBlackHoldDuration = 2f;
        [SerializeField] private float introSavingDuration = 4f;
        [SerializeField] private float introChapterTitleDuration = 4.5f;
        [SerializeField] private float introMonologuePauseDuration = 1.35f;
        [SerializeField] private float introWakeRevealDuration = 0.7f;
        [SerializeField] private float introMonologueCharactersPerSecond = 34f;

        [TextArea(1, 2)]
        [SerializeField] private string introSavingLabel = "Guardando...";

        [TextArea(1, 2)]
        [SerializeField] private string introChapterNumberLabel = "Capitulo 1";

        [TextArea(1, 2)]
        [SerializeField] private string introChapterNameLabel = "UN NUEVO COMIENZO";

        [TextArea(2, 5)]
        [SerializeField] private string introMonologueLine1 = "Uno pensaria que con los anos la vida se haria mas sencilla, que con cada dia el peso seria mas liviano, y vivir seria menos una carga.";

        [TextArea(2, 3)]
        [SerializeField] private string introMonologueLine2 = "Pero al parecer no.";

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
        [SerializeField] private Button roomBonsaiButton;
        [SerializeField] private Button roomProteinBarButton;

        [Header("Backgrounds")]
        [SerializeField] private Sprite introBackground;
        [SerializeField] private Sprite roomBackground;
        [SerializeField] private Sprite friendsBackground;
        [SerializeField] private Sprite hallwayBackground;
        [SerializeField] private Sprite cafeteriaBackground;

        [Header("Phone")]
        [SerializeField] private Sprite firstPhoneMessage;

        [Header("Audio")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioClip introMusic;
        [SerializeField] private AudioClip roomMusic;
        [SerializeField] private AudioClip hallwayMusic;
        [SerializeField] private AudioClip cafeteriaMusic;
        [SerializeField] private AudioClip phoneNotificationSfx;
        [SerializeField] private AudioClip roomExitSfx;
        [SerializeField] private AudioClip choiceSelectedSfx;
        [SerializeField] private AudioClip chapterCompleteSfx;

        [Header("Dialogue")]
        [SerializeField] private DialogueLine[] introLines;
        [SerializeField] private DialogueLine[] roomLines;
        [SerializeField] private DialogueLine[] roomBonsaiLines;
        [SerializeField] private DialogueLine[] roomProteinBarLines;
        [SerializeField] private DialogueLine[] friendsLines;
        [SerializeField] private DialogueLine[] hallwayLines;
        [SerializeField] private DialogueLine[] cafeteriaLines;
        [SerializeField] private DialogueLine[] endingLines;

        [Header("Choices")]
        [SerializeField] private ChapterChoiceBeat firstChoice;
        [SerializeField] private ChapterChoiceBeat secondChoice;
        [SerializeField] private ChapterChoiceBeat thirdChoice;

        public Chapter01Beat CurrentBeat { get; private set; }

        private Action pendingDialogueCompletion;

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

            if (roomBonsaiButton != null)
            {
                roomBonsaiButton.onClick.AddListener(HandleRoomBonsaiClicked);
            }

            if (roomProteinBarButton != null)
            {
                roomProteinBarButton.onClick.AddListener(HandleRoomProteinBarClicked);
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

            if (roomBonsaiButton != null)
            {
                roomBonsaiButton.onClick.RemoveListener(HandleRoomBonsaiClicked);
            }

            if (roomProteinBarButton != null)
            {
                roomProteinBarButton.onClick.RemoveListener(HandleRoomProteinBarClicked);
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
            pendingDialogueCompletion = null;

            if (dialogueController != null)
            {
                dialogueController.Hide();
            }

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

            HideCanonicalIntroVisuals();
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
            CurrentBeat = Chapter01Beat.Intro;
            PlayMusicIfNeeded(introMusic);

            if (ShouldUseCanonicalIntroSequence())
            {
                yield return PlayCanonicalIntroSequence();
                yield break;
            }

            SetBackground(introBackground);

            if (fadeOverlayController != null)
            {
                fadeOverlayController.ShowInstant();
                yield return fadeOverlayController.PlayFadeFromBlack(openingFadeDuration);
            }

            BeginIntro();
        }

        private bool ShouldUseCanonicalIntroSequence()
        {
            return useCanonicalIntroSequence
                && introSavingCanvasGroup != null
                && introChapterTitleCanvasGroup != null
                && introMonologueCanvasGroup != null
                && introSavingText != null
                && introChapterNumberText != null
                && introChapterNameText != null
                && introMonologueText != null
                && fadeOverlayController != null;
        }

        private IEnumerator PlayCanonicalIntroSequence()
        {
            ConfigureCanonicalIntroTexts();
            SetBackground(introBackground);
            fadeOverlayController.ShowInstant();

            if (introBlackHoldDuration > 0f)
            {
                yield return new WaitForSecondsRealtime(introBlackHoldDuration);
            }

            yield return ShowIntroGroupRoutine(introSavingCanvasGroup, introSavingDuration);
            yield return ShowIntroGroupRoutine(introChapterTitleCanvasGroup, introChapterTitleDuration);
            yield return ShowIntroMonologueRoutine();
            yield return BeginWakeIntoPhoneRoutine();
        }

        private IEnumerator ShowIntroGroupRoutine(CanvasGroup targetGroup, float visibleDuration)
        {
            SetCanvasGroupState(targetGroup, true);
            yield return fadeOverlayController.PlayFadeFromBlack(openingFadeDuration);

            if (visibleDuration > 0f)
            {
                yield return new WaitForSecondsRealtime(visibleDuration);
            }

            yield return fadeOverlayController.PlayFadeToBlack(openingFadeDuration);
            SetCanvasGroupState(targetGroup, false);
        }

        private IEnumerator ShowIntroMonologueRoutine()
        {
            SetCanvasGroupState(introMonologueCanvasGroup, true);
            introMonologueText.text = string.Empty;

            yield return fadeOverlayController.PlayFadeFromBlack(openingFadeDuration);
            yield return TypeTextRoutine(introMonologueText, introMonologueLine1, introMonologueCharactersPerSecond);

            if (introMonologuePauseDuration > 0f)
            {
                yield return new WaitForSecondsRealtime(introMonologuePauseDuration);
            }

            introMonologueText.text += "\n\n";
            yield return TypeTextRoutine(introMonologueText, introMonologueLine2, introMonologueCharactersPerSecond);
            yield return new WaitForSecondsRealtime(0.4f);
            yield return fadeOverlayController.PlayFadeToBlack(openingFadeDuration);
            SetCanvasGroupState(introMonologueCanvasGroup, false);
            introMonologueText.text = string.Empty;
        }

        private IEnumerator BeginWakeIntoPhoneRoutine()
        {
            SetBackground(roomBackground);
            PlayMusicIfNeeded(roomMusic);
            PlaySfx(phoneNotificationSfx);
            yield return fadeOverlayController.PlayFadeFromBlack(introWakeRevealDuration);
            BeginPhoneBeatInternal(false);
        }

        private IEnumerator TypeTextRoutine(TMP_Text targetText, string content, float charactersPerSecond)
        {
            if (targetText == null || string.IsNullOrEmpty(content))
            {
                yield break;
            }

            if (charactersPerSecond <= 0f)
            {
                targetText.text += content;
                yield break;
            }

            float delay = 1f / charactersPerSecond;
            for (int i = 0; i < content.Length; i++)
            {
                targetText.text += content[i];
                yield return new WaitForSecondsRealtime(delay);
            }
        }

        private void ConfigureCanonicalIntroTexts()
        {
            if (introSavingText != null)
            {
                introSavingText.text = introSavingLabel;
            }

            if (introChapterNumberText != null)
            {
                introChapterNumberText.text = introChapterNumberLabel;
            }

            if (introChapterNameText != null)
            {
                introChapterNameText.text = introChapterNameLabel;
            }

            if (introMonologueText != null)
            {
                introMonologueText.text = string.Empty;
            }
        }

        private void HideCanonicalIntroVisuals()
        {
            SetCanvasGroupState(introSavingCanvasGroup, false);
            SetCanvasGroupState(introChapterTitleCanvasGroup, false);
            SetCanvasGroupState(introMonologueCanvasGroup, false);

            if (introMonologueText != null)
            {
                introMonologueText.text = string.Empty;
            }
        }

        private void BeginIntro()
        {
            CurrentBeat = Chapter01Beat.Intro;
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.Intro), BeginPhoneBeat);
        }

        private void BeginPhoneBeat()
        {
            BeginPhoneBeatInternal(true);
        }

        private void BeginPhoneBeatInternal(bool playNotificationSfx)
        {
            SetBackground(roomBackground);
            CurrentBeat = Chapter01Beat.WaitingForPhoneClose;
            PlayMusicIfNeeded(roomMusic);

            if (dialogueController != null)
            {
                dialogueController.Hide();
            }

            if (playNotificationSfx)
            {
                PlaySfx(phoneNotificationSfx);
            }

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
            PlayMusicIfNeeded(roomMusic);
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
            PlayMusicIfNeeded(hallwayMusic);
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
            PlayMusicIfNeeded(cafeteriaMusic);
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
            PlaySfx(chapterCompleteSfx);

            if (fadeOverlayController != null)
            {
                yield return fadeOverlayController.PlayFadeToBlack(endingFadeDuration);
            }
        }

        private void HandleDialogueFinished()
        {
            if (pendingDialogueCompletion != null)
            {
                Action completion = pendingDialogueCompletion;
                pendingDialogueCompletion = null;
                completion.Invoke();
                return;
            }

            switch (CurrentBeat)
            {
                case Chapter01Beat.Intro:
                    BeginPhoneBeat();
                    break;
                case Chapter01Beat.Room:
                    BeginRoomExploration();
                    break;
                case Chapter01Beat.RoomInspectingBonsai:
                    BeginRoomExploration();
                    break;
                case Chapter01Beat.RoomInspectingProteinBar:
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
            PlaySfx(choiceSelectedSfx);

            if (selectedOption != null && trustController != null)
            {
                trustController.ApplyDeltas(selectedOption.seongsuTrustDelta, selectedOption.jeonghoTrustDelta);
            }

            switch (CurrentBeat)
            {
                case Chapter01Beat.FirstChoice:
                    PlayPostChoiceDialogueOrContinue(
                        Chapter01Beat.FirstChoice,
                        selectedOption,
                        BeginHallwayDialogue);
                    break;
                case Chapter01Beat.SecondChoice:
                    PlayPostChoiceDialogueOrContinue(
                        Chapter01Beat.SecondChoice,
                        selectedOption,
                        BeginCafeteriaDialogue);
                    break;
                case Chapter01Beat.ThirdChoice:
                    PlayPostChoiceDialogueOrContinue(
                        Chapter01Beat.ThirdChoice,
                        selectedOption,
                        BeginEndingDialogue);
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

        private void PlayPostChoiceDialogueOrContinue(
            Chapter01Beat choiceBeat,
            ChoiceOption selectedOption,
            Action onEmptyOrFinished)
        {
            DialogueLine[] lines = GetPostChoiceLines(choiceBeat, selectedOption);

            if (dialogueController == null || lines == null || lines.Length == 0)
            {
                onEmptyOrFinished?.Invoke();
                return;
            }

            pendingDialogueCompletion = onEmptyOrFinished;
            dialogueController.PlayLines(lines);
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
            PlaySfx(roomExitSfx);
            BeginFriendsDialogue();
        }

        private void HandleRoomBonsaiClicked()
        {
            if (CurrentBeat != Chapter01Beat.RoomExploration)
            {
                return;
            }

            CurrentBeat = Chapter01Beat.RoomInspectingBonsai;
            SetCanvasGroupState(roomExitCanvasGroup, false);
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.RoomInspectingBonsai), BeginRoomExploration);
        }

        private void HandleRoomProteinBarClicked()
        {
            if (CurrentBeat != Chapter01Beat.RoomExploration)
            {
                return;
            }

            CurrentBeat = Chapter01Beat.RoomInspectingProteinBar;
            SetCanvasGroupState(roomExitCanvasGroup, false);
            PlayDialogueOrContinue(GetDialogueLinesForBeat(Chapter01Beat.RoomInspectingProteinBar), BeginRoomExploration);
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

        private void PlayMusicIfNeeded(AudioClip clip)
        {
            if (musicSource == null || clip == null)
            {
                return;
            }

            if (musicSource.clip == clip && musicSource.isPlaying)
            {
                return;
            }

            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }

        private void PlaySfx(AudioClip clip)
        {
            if (sfxSource == null || clip == null)
            {
                return;
            }

            sfxSource.PlayOneShot(clip);
        }

        private DialogueLine[] GetDialogueLinesForBeat(Chapter01Beat beat)
        {
            DialogueLine[] configuredLines = beat switch
            {
                Chapter01Beat.Intro => introLines,
                Chapter01Beat.Room => roomLines,
                Chapter01Beat.RoomInspectingBonsai => roomBonsaiLines,
                Chapter01Beat.RoomInspectingProteinBar => roomProteinBarLines,
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

        private DialogueLine[] GetPostChoiceLines(Chapter01Beat beat, ChoiceOption selectedOption)
        {
            if (!useFallbackDataWhenEmpty || selectedOption == null)
            {
                return null;
            }

            return BuildFallbackPostChoiceLines(beat, selectedOption);
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
                        CreateLine(string.Empty, "Uno pensaria que con los anos la vida se haria mas sencilla, que con cada dia el peso seria mas liviano, y vivir seria menos una carga.", DialogueSpeakerMode.Thought),
                        CreateLine(string.Empty, "Pero al parecer no.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.Room:
                    return new[]
                    {
                        CreateLine(string.Empty, "Por que me cuesta tanto? Lo intento, de verdad lo intento, pero siempre siento que estoy un paso atras, como si nunca pudiera alcanzar lo que se espera de mi.", DialogueSpeakerMode.Thought),
                        CreateLine(string.Empty, "No entiendo por que todo parece tan sencillo para los demas y yo sigo aqui, atrapada en mi propio ritmo.", DialogueSpeakerMode.Thought),
                        CreateLine(string.Empty, "...Supongo que no tengo otra opcion.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.RoomInspectingBonsai:
                    return new[]
                    {
                        CreateLine(string.Empty, "El bonsai sigue aqui, impecable.", DialogueSpeakerMode.Thought),
                        CreateLine(string.Empty, "Cuidarlo siempre me obliga a bajar el ritmo un poco.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.RoomInspectingProteinBar:
                    return new[]
                    {
                        CreateLine(string.Empty, "La barra de proteina sigue donde la deje.", DialogueSpeakerMode.Thought),
                        CreateLine(string.Empty, "Tal vez deberia llevarmela. Con Seongsu nunca se sabe cuanto va a durar la salida.", DialogueSpeakerMode.Thought),
                    };
                case Chapter01Beat.Friends:
                    return new[]
                    {
                        CreateLine("Seongsu", "Hasta que te dignas en salir! Se me iba a quemar la cabeza aqui afuera.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine("Jeongho", "Ya, ya salio, no generes mas drama.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                        CreateLine("Jeongho", "Ya ya, ten. Se nota que lo necesitas.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Una barra de proteina, muy creativo jajaja.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                    };
                case Chapter01Beat.Hallway:
                    return new[]
                    {
                        CreateLine(string.Empty, "Me alegra estar con ellos... Aqui no siento que falte algo.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Estar con ellos la hacia olvidar sus problemas, aunque fuera por un rato. Eran como su pequeno refugio.", DialogueSpeakerMode.Narration, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine("Seongsu", "Estas bien?", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine("Jihuun", "\"Estoy cansada\"", DialogueSpeakerMode.Signed, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine("Jeongho", "\"Mentirosa\"", DialogueSpeakerMode.Signed, PortraitFocus.Right, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "A veces... me siento atrapada en mi propia cabeza.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine("Jeongho", "Pero te dejaremos tranquila... por ahora.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Todos hablan... Todos rien... Y yo... estoy aqui. Pero no me siento presente.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                    };
                case Chapter01Beat.Cafeteria:
                    return new[]
                    {
                        CreateLine(string.Empty, "La manana paso como todas las demas: clases, notas, miradas rapidas entre los companeros.", DialogueSpeakerMode.Narration, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine("Seongsu", "Sabes que se me antoja? Un pastel de mango.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine("Jeongho", "Te tropezaste con una planta, no salvaste el mundo.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                        CreateLine("Seongsu", "Y tu que vas a pedir?", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine("Jihuun", "\"Jugo de durazno\"", DialogueSpeakerMode.Signed, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine("Jeongho", "Obvio. Desde que te conozco, la mas adicta al jugo de durazno.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Seongsu sonrio con carino y fue a hacer el pedido.", DialogueSpeakerMode.Narration, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Jeongho saco su celular para ensenarle a Jihuun un video absurdo de un gato atrapado en una bolsa de papel.", DialogueSpeakerMode.Narration, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Seongsu volvio con la bandeja: dos pasteles, un cafe americano y su jugo de durazno.", DialogueSpeakerMode.Narration, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine("Seongsu", "Ahi tienes. Tu dosis de vida liquida.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Sin decir nada mas, Seongsu partio su pastelito por la mitad y le ofrecio un pedazo a Jihuun.", DialogueSpeakerMode.Narration, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine("Seongsu", "Apostaria a que ni siquiera tiene subtitulos.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine("Seongsu", "Es mas, apuesto a que ni el director se acuerda que la hizo.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine("Jihuun", "\"Ni yo la conozco\"", DialogueSpeakerMode.Signed, PortraitFocus.None, leftPortrait, rightPortrait),
                        CreateLine("Seongsu", "Ya ves? Hasta Jihuun lo dice, y ella es la mas cool de nosotros.", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                        CreateLine(string.Empty, "Aqui... es facil. No necesito hablar.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                    };
                case Chapter01Beat.Ending:
                    return new[]
                    {
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
                        prompt = "Como reacciona Jihuun al ver a sus amigos?",
                        options = new[]
                        {
                            CreateChoice("smile_softly", "Sonrie ligeramente", 1, 1),
                            CreateChoice("just_watch", "Solo observa", 0, 0),
                            CreateChoice("sign_to_jeongho", "Hace una sena a Jeongho", 0, 1),
                        }
                    };
                case Chapter01Beat.SecondChoice:
                    return new ChapterChoiceBeat
                    {
                        prompt = "Como procesa Jihuun el ruido del pasillo?",
                        options = new[]
                        {
                            CreateChoice("look_around", "Mirar a la gente", 0, 0),
                            CreateChoice("look_down", "Bajar la mirada", 0, 0),
                            CreateChoice("ignore_everything", "Ignorar todo", 0, 0),
                        }
                    };
                case Chapter01Beat.ThirdChoice:
                    return new ChapterChoiceBeat
                    {
                        prompt = "Como participa Jihuun en la conversacion?",
                        options = new[]
                        {
                            CreateChoice("propose_weekend_plan", "Propone idea de salir el fin de semana", 1, 1),
                            CreateChoice("just_watch_again", "Solo observa", 0, 0),
                            CreateChoice("write_on_phone", "Escribe en celular", 1, 1),
                        }
                    };
                default:
                    return null;
            }
        }

        private DialogueLine[] BuildFallbackPostChoiceLines(Chapter01Beat beat, ChoiceOption selectedOption)
        {
            Sprite leftPortrait = dialogueController != null ? dialogueController.LeftPortraitSprite : null;
            Sprite rightPortrait = dialogueController != null ? dialogueController.RightPortraitSprite : null;

            switch (beat)
            {
                case Chapter01Beat.FirstChoice:
                    if (selectedOption.optionId == "sign_to_jeongho")
                    {
                        return new[]
                        {
                            CreateLine("Jihuun", "\"Ya lo tenias preparado?\"", DialogueSpeakerMode.Signed, PortraitFocus.None, leftPortrait, rightPortrait),
                            CreateLine("Jeongho", "Para que veas jajaja, era predecible.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                        };
                    }

                    return null;

                case Chapter01Beat.SecondChoice:
                    switch (selectedOption.optionId)
                    {
                        case "look_around":
                            return new[]
                            {
                                CreateLine(string.Empty, "Levanto la mirada.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                                CreateLine(string.Empty, "Por un segundo, todo se vuelve mas claro. Rostros. Movimiento. Ruido. Demasiado.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                                CreateLine(string.Empty, "Y entonces... alguien me esta mirando. No es como los demas. No se aparta de inmediato.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                            };
                        case "look_down":
                            return new[]
                            {
                                CreateLine(string.Empty, "Bajo la mirada.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                                CreateLine(string.Empty, "Es mas facil asi. Nadie se detiene. Nadie pregunta. Solo pasos y ruido.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                            };
                        case "ignore_everything":
                            return new[]
                            {
                                CreateLine(string.Empty, "...", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                            };
                    }

                    return null;

                case Chapter01Beat.ThirdChoice:
                    switch (selectedOption.optionId)
                    {
                        case "propose_weekend_plan":
                            return new[]
                            {
                                CreateLine(string.Empty, "Levanto las manos antes de pensarlo demasiado. Hago la sena torpemente... pero suficiente.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                                CreateLine("Seongsu", "Burbujas?! Me encanta!", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                                CreateLine("Jeongho", "Ok, eso si no me lo esperaba.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                                CreateLine(string.Empty, "Alguien me estaba mirando otra vez. Levante la vista, y ahi estaba el. No me gustaba sentirme observada asi.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                            };
                        case "just_watch_again":
                            return new[]
                            {
                                CreateLine(string.Empty, "Alguien me estaba mirando otra vez. Levante la vista, y ahi estaba el.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                                CreateLine(string.Empty, "Su mirada no era cruel, pero igual se sentia pesada. Baje la cabeza rapidamente.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                            };
                        case "write_on_phone":
                            return new[]
                            {
                                CreateLine(string.Empty, "Escribo rapido en el celular y les enseno la pantalla.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                                CreateLine("Seongsu", "Burbujas?! Me encanta!", DialogueSpeakerMode.Spoken, PortraitFocus.Left, leftPortrait, rightPortrait),
                                CreateLine("Jeongho", "Ok, eso si no me lo esperaba.", DialogueSpeakerMode.Spoken, PortraitFocus.Right, leftPortrait, rightPortrait),
                                CreateLine(string.Empty, "Alguien me estaba mirando otra vez. No sabia que hacer con esa curiosidad ajena.", DialogueSpeakerMode.Thought, PortraitFocus.None, leftPortrait, rightPortrait),
                            };
                    }

                    return null;
            }

            return null;
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
