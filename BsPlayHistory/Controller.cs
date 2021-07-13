using System;
using UnityEngine;
using BS_Utils.Utilities;
using BsPlayHistory.socket;

namespace BsPlayHistory
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class BsPlayHistoryController : MonoBehaviour
    {
        public static BsPlayHistoryController Instance { get; private set; }

        protected string songName;
        protected string songAuthorName;
        protected string levelAuthorName;
        protected string levelHash;
        protected float duration;
        protected float bpm;
        protected Int32 modifiedScore;
        protected Single energy;
        protected LevelCompletionResults.LevelEndStateType levelEndStateType;

        protected int maxScore;

        protected Int32 maxCombo;
        protected bool fullCombo;

        protected string rank;
        protected int miss;
        protected double acc;
        protected WebSocket socket;


        public static int calculateMaxScore(int blockCount)
        {
            int maxScore;
            if (blockCount < 14)
            {
                if (blockCount == 1)
                {
                    maxScore = 115;
                }
                else if (blockCount < 5)
                {
                    maxScore = (blockCount - 1) * 230 + 115;
                }
                else
                {
                    maxScore = (blockCount - 5) * 460 + 1035;
                }
            }
            else
            {
                maxScore = (blockCount - 13) * 920 + 4715;
            }
            return maxScore;
        }

        // These methods are automatically called by Unity, you should remove any you aren't using.
        #region Monobehaviour Messages
        /// <summary>
        /// Only ever called once, mainly used to initialize variables.
        /// </summary>
        private void Awake()
        {
            // For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
            //   and destroy any that are created while one already exists.
            if (Instance != null)
            {
                Plugin.Log?.Warn($"Instance of {GetType().Name} already exists, destroying.");
                GameObject.DestroyImmediate(this);
                return;
            }
            GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
            Instance = this;
            Plugin.Log?.Debug($"{name}: Awake()");
        }
        /// <summary>
        /// Only ever called once on the first frame the script is Enabled. Start is called after any other script's Awake() and before Update().
        /// </summary>
        private void Start()
        {
            //BSEvents.gameSceneLoaded += onLevelStart;
            BSEvents.levelCleared += onLevelCleared;
            BSEvents.levelFailed += onLevelCleared;
            Plugin.Log.Info("Metodos adicionados no invoke");
            CreateServer();
        }

        private void onLevelCleared(StandardLevelScenesTransitionSetupDataSO arg1, LevelCompletionResults arg2)
        {
               //----------------------------------Informações da música
            IPreviewBeatmapLevel levelData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData.previewBeatmapLevel;
            //Informações da música
            GameplayModifiers modifiers = arg2.gameplayModifiers;// Modifiers
            BeatmapDifficulty difficulty = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData.difficultyBeatmap.difficulty;// Dificuldade
            songName = levelData.songName; // Nome da música
            songAuthorName = levelData.songAuthorName; // Autor da música
            levelAuthorName = levelData.levelAuthorName; // Autor do mapa
            levelHash = levelData.levelID.StartsWith("custom_level_") && !levelData.levelID.EndsWith(" WIP") ? levelData.levelID.Substring(13, 40) : null; // Hash do mada
            duration = levelData.songDuration; // Duração
            bpm = levelData.beatsPerMinute; // Bpm
            levelEndStateType = arg2.levelEndStateType; // Passou ou falhou
            //----------------------------------Informações de Dentro da música
            modifiedScore = arg2.modifiedScore; // Score Total
            energy = arg2.energy; // Energia?

            maxCombo = arg2.maxCombo; // Combo máximo
            fullCombo = arg2.fullCombo; // Foi full combo?

            rank = RankModel.GetRankName(arg2.rank); // Qual rank pegou
            miss = arg2.missedCount; // Miss

            bool withoutModifiers = arg2.gameplayModifiers.IsWithoutModifiers(); // Foi sem modifiers?
            //----------------------------------Acc
            BeatmapData beatmapData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData.difficultyBeatmap.beatmapData;
            maxScore = calculateMaxScore(beatmapData.cuttableNotesType);

            int rawScore = arg2.rawScore;
            double percentage = Math.Round((double)(100 / (double)maxScore * (double)rawScore), 2); // Acc
            //---------------------------------- Envio
            socket.SendSong(songName, songAuthorName, levelAuthorName, levelHash, rank, duration, bpm, miss, modifiedScore, maxCombo, fullCombo, acc, levelEndStateType, difficulty);
        }

        private void CreateServer()
        {
            socket = new WebSocket();
            socket.StartServer();
        }

        /// <summary>
        /// Called every frame if the script is enabled.
        /// </summary>
        private void Update()
        {
        }

        /// <summary>
        /// Called every frame after every other enabled script's Update().
        /// </summary>
        private void LateUpdate()
        {

        }

        /// <summary>
        /// Called when the script becomes enabled and active
        /// </summary>
        private void OnEnable()
        {

        }

        /// <summary>
        /// Called when the script becomes disabled or when it is being destroyed.
        /// </summary>
        private void OnDisable()
        {

        }

        /// <summary>
        /// Called when the script is being destroyed.
        /// </summary>
        private void OnDestroy()
        {
            Plugin.Log?.Debug($"{name}: OnDestroy()");
            if (Instance == this)
                Instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.

        }
        #endregion
    }
    /*public class TestViewController : BSMLResourceViewController
    {
        public override string ResourceName => "BullShitPlugin.UI.test.bsml";

        [UIComponent("some-text")]
        private TextMeshProUGUIHandler text;

        [UIAction("press")]
        private void ButtonPress()
        {
            text.
            text.dic = "Hey look, the text changed";
        }
    }*/
}
