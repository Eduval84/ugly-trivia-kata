using System;

namespace Trivia
{
    public static class GameRunner
    {
        private static bool _notAWinner;
        public static int seed;

        public static void Main()
        {
            CrateNewGame();
        }

        private static void CrateNewGame()
        {
            var aGame = new Game();

            AddPlayersToGame(aGame);

            StartNewGame(aGame);
        }

        private static void AddPlayersToGame(Game aGame)
        {
            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");
        }

        private static void StartNewGame(Game aGame)
        {
            var rand = new Random(seed);

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                _notAWinner = rand.Next(9) == 7 ? aGame.WrongAnswer() : aGame.WasCorrectlyAnswered();
            } while (_notAWinner);
        }


    }
}