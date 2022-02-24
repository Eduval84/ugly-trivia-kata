using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        private bool _isGettingOutOfPenaltyBox;
        private readonly Players _players;

        public Game()
        {
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }

            _players = new Players();
        }

        public Players Players
        {
            get { return _players; }
        }

        private static string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(Players._players[Players._currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (Players._inPenaltyBox[Players._currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(Players._players[Players._currentPlayer] + " is getting out of the penalty box");
                    Players._places[Players._currentPlayer] = Players._places[Players._currentPlayer] + roll;
                    if (Players._places[Players._currentPlayer] > 11) Players._places[Players._currentPlayer] = Players._places[Players._currentPlayer] - 12;

                    Console.WriteLine(Players._players[Players._currentPlayer]
                                      + "'s new location is "
                                      + Players._places[Players._currentPlayer]);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(Players._players[Players._currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                Players._places[Players._currentPlayer] += roll;
                if (Players._places[Players._currentPlayer] > 11) Players._places[Players._currentPlayer] -= 12;

                Console.WriteLine(Players._players[Players._currentPlayer]
                                  + "'s new location is "
                                  + Players._places[Players._currentPlayer]);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory() != "Rock") return;
            Console.WriteLine(_rockQuestions.First());
            _rockQuestions.RemoveFirst();
        }

        private string CurrentCategory()
        {
            return Players._places[Players._currentPlayer] == 0 ? "Pop" :
                Players._places[Players._currentPlayer] == 4 ? "Pop" :
                Players._places[Players._currentPlayer] == 8 ? "Pop" :
                Players._places[Players._currentPlayer] == 1 ? "Science" :
                Players._places[Players._currentPlayer] == 5 ? "Science" :
                Players._places[Players._currentPlayer] == 9 ? "Science" :
                Players._places[Players._currentPlayer] == 2 ? "Sports" :
                Players._places[Players._currentPlayer] == 6 ? "Sports" :
                Players._places[Players._currentPlayer] == 10 ? "Sports" : "Rock";
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;

            if (Players._inPenaltyBox[Players._currentPlayer])
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    Players._purses[Players._currentPlayer]++;
                    Console.WriteLine(Players._players[Players._currentPlayer]
                                      + " now has "
                                      + Players._purses[Players._currentPlayer]
                                      + " Gold Coins.");

                    winner = DidPlayerWin();
                    Players._currentPlayer++;
                    if (Players._currentPlayer != Players._players.Count) return winner;
                    Players._currentPlayer = 0;

                    return winner;
                }

                Players._currentPlayer++;
                if (Players._currentPlayer != Players._players.Count) return true;
                Players._currentPlayer = 0;

                return true;
            }

            Console.WriteLine("Answer was correct!!!!");
            Players._purses[Players._currentPlayer]++;
            Console.WriteLine(Players._players[Players._currentPlayer]
                              + " now has "
                              + Players._purses[Players._currentPlayer]
                              + " Gold Coins.");

            winner = DidPlayerWin();
            Players._currentPlayer++;
            if (Players._currentPlayer == Players._players.Count) Players._currentPlayer = 0;

            return winner;

        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(Players._players[Players._currentPlayer] + " was sent to the penalty box");
            Players._inPenaltyBox[Players._currentPlayer] = true;

            Players._currentPlayer++;
            if (Players._currentPlayer == Players._players.Count) Players._currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return Players._purses[Players._currentPlayer] != 6;
        }
    }

}
