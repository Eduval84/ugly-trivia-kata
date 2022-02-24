using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        public bool IsGettingOutOfPenaltyBox { get; private set; }
        private readonly Players players;
        private readonly Questions questions;

        public Game()
        {
            questions = new Questions();
            for (var i = 0; i < 50; i++)
            {
                questions.PopQuestions.AddLast("Pop Question " + i);
                questions.ScienceQuestions.AddLast(("Science Question " + i));
                questions.SportsQuestions.AddLast(("Sports Question " + i));
                questions.RockQuestions.AddLast(CreateRockQuestion(i));
            }

            players = new Players();
        }

        public Players Players
        {
            get { return players; }
        }

        private static string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(Players.PlayersList[Players.CurrentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (Players.IsInPenaltyBox[Players.CurrentPlayer])
            {
                if (roll % 2 == 0)
                {
                    Console.WriteLine(Players.PlayersList[Players.CurrentPlayer] +
                                      " is not getting out of the penalty box");
                    IsGettingOutOfPenaltyBox = false;
                    return;
                }
                else
                {
                    IsGettingOutOfPenaltyBox = true;

                    Console.WriteLine(Players.PlayersList[Players.CurrentPlayer] +
                                      " is getting out of the penalty box");
                }
            }
            MoveToNextPlace(roll);
            AskQuestion();
        }

        private void MoveToNextPlace(int roll)
        {
            Players.Places[Players.CurrentPlayer] += roll;
            if (Players.Places[Players.CurrentPlayer] > 11) Players.Places[Players.CurrentPlayer] -= 12;

            Console.WriteLine(Players.PlayersList[Players.CurrentPlayer]
                              + "'s new location is "
                              + Players.Places[Players.CurrentPlayer]);
            Console.WriteLine("The category is " + CurrentCategory());
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(questions.PopQuestions.First());
                questions.PopQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(questions.ScienceQuestions.First());
                questions.ScienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(questions.SportsQuestions.First());
                questions.SportsQuestions.RemoveFirst();
            }
            if (CurrentCategory() != "Rock") return;
            Console.WriteLine(questions.RockQuestions.First());
            questions.RockQuestions.RemoveFirst();
        }

        private string CurrentCategory()
        {
            return Players.Places[Players.CurrentPlayer] == 0 ? "Pop" :
                Players.Places[Players.CurrentPlayer] == 4 ? "Pop" :
                Players.Places[Players.CurrentPlayer] == 8 ? "Pop" :
                Players.Places[Players.CurrentPlayer] == 1 ? "Science" :
                Players.Places[Players.CurrentPlayer] == 5 ? "Science" :
                Players.Places[Players.CurrentPlayer] == 9 ? "Science" :
                Players.Places[Players.CurrentPlayer] == 2 ? "Sports" :
                Players.Places[Players.CurrentPlayer] == 6 ? "Sports" :
                Players.Places[Players.CurrentPlayer] == 10 ? "Sports" : "Rock";
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;

            if (Players.IsInPenaltyBox[Players.CurrentPlayer])
            {
                if (IsGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    Players.Purses[Players.CurrentPlayer]++;
                    Console.WriteLine(Players.PlayersList[Players.CurrentPlayer]
                                      + " now has "
                                      + Players.Purses[Players.CurrentPlayer]
                                      + " Gold Coins.");

                    winner = DidPlayerWin();
                    Players.CurrentPlayer++;
                    if (Players.CurrentPlayer != Players.PlayersList.Count) return winner;
                    Players.CurrentPlayer = 0;

                    return winner;
                }

                Players.CurrentPlayer++;
                if (Players.CurrentPlayer != Players.PlayersList.Count) return true;
                Players.CurrentPlayer = 0;

                return true;
            }

            Console.WriteLine("Answer was correct!!!!");
            Players.Purses[Players.CurrentPlayer]++;
            Console.WriteLine(Players.PlayersList[Players.CurrentPlayer]
                              + " now has "
                              + Players.Purses[Players.CurrentPlayer]
                              + " Gold Coins.");

            winner = DidPlayerWin();
            Players.CurrentPlayer++;
            if (Players.CurrentPlayer == Players.PlayersList.Count) Players.CurrentPlayer = 0;

            return winner;

        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(Players.PlayersList[Players.CurrentPlayer] + " was sent to the penalty box");
            Players.IsInPenaltyBox[Players.CurrentPlayer] = true;

            Players.CurrentPlayer++;
            if (Players.CurrentPlayer == Players.PlayersList.Count) Players.CurrentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return Players.Purses[Players.CurrentPlayer] != 6;
        }
    }

}
