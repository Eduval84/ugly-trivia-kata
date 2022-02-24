using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Players
    {
        public List<string> PlayersList { get; } = new List<string>();
        public int[] Places { get; } = new int[6];
        public int[] Purses { get; } = new int[6];
        public bool[] IsInPenaltyBox { get; } = new bool[6];
        public int CurrentPlayer { get; set; }

        public Players()
        {
        }

        public void Add(string playerName)
        {
            PlayersList.Add(playerName);
            Places[HowManyPlayers()] = 0;
            Purses[HowManyPlayers()] = 0;
            IsInPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + PlayersList.Count);
        }

        private int HowManyPlayers()
        {
            return PlayersList.Count;
        }
    }
}