using System;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BsPlayHistory.socket
{
	public class WebSocket
	{
        public WebSocket(){}
		protected WebSocketServer socket;
		private List<Song> songs = new List<Song>();
		public void StartServer()
		{
			socket = new WebSocketServer("ws://127.0.0.1:7890");
            socket.AddWebSocketService<Echo>("/Echo");
            socket.Start();
            if (socket.IsListening)
            {
                Plugin.Log.Info("Socket Started at port:" + socket.Port);
            }
		}

        public void SendSong(string SongName, string SongAuthorName, string LevelAuthorName, string LevelHash, string Rank, float Duration, float Bpm, 
            int Miss, Int32 ModifiedScore, Int32 MaxCombo, bool FullCombo, double Acc, LevelCompletionResults.LevelEndStateType LevelEndStateType, BeatmapDifficulty Difficulty)
        {
            Song song = new Song
            {
                songName = SongName,
                songAuthorName = SongAuthorName,
                levelAuthorName = LevelAuthorName,
                levelHash = LevelHash,
                rank = Rank,

                duration = Duration,
                bpm = Bpm,

                miss = Miss,

                modifiedScore = ModifiedScore,
                maxCombo = MaxCombo,
                fullCombo = FullCombo,
                acc = Acc,
                levelEndStateType = LevelEndStateType,
                difficulty = Difficulty

            };
            string json = JsonConvert.SerializeObject(song, Formatting.Indented);
            socket.WebSocketServices.Broadcast(json);
            Plugin.Log.Info("Sent.");
        }
	}

    class Echo : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Send(e.Data);
        }
    }
	public class Song
    {
        public string songName, songAuthorName, levelAuthorName, levelHash, rank;
        public float duration, bpm;

        public int miss;

        public Int32 modifiedScore, maxCombo;
        public bool fullCombo;

        public double acc;
        public LevelCompletionResults.LevelEndStateType levelEndStateType;
        public BeatmapDifficulty difficulty;
    }
}
