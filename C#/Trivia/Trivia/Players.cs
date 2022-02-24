using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Players
    {
        public readonly List<string> _players = new List<string>();
        public readonly int[] _places = new int[6];
        public readonly int[] _purses = new int[6];
        public readonly bool[] _inPenaltyBox = new bool[6];
        public int _currentPlayer;

        public Players()
        {
        }

        public void Add(string playerName)
        {
            _players.Add(playerName);
            _places[HowManyPlayers()] = 0;
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
        }

        private int HowManyPlayers()
        {
            return _players.Count;
        }
    }
}