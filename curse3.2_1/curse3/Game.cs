using System;

namespace curse3
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public int PlayerCount { get; set; }
        public bool IsMultiplayer { get; set; }

        public Game()
        {
        }

        public Game(string gamename, int playercount, bool isMultiplayer)
        {
            GameName = gamename;
            PlayerCount = playercount;
            IsMultiplayer = isMultiplayer;
        }

        public Game(int id, string gamename, int playercount, bool isMultiplayer)
        {
            Id = id;
            GameName = gamename;
            PlayerCount = playercount;
            IsMultiplayer = isMultiplayer;
        }
    }
}