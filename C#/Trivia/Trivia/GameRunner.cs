using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _notAWinner;
        private static readonly GameRunner _instance;
        private static int _seed;

        public GameRunner(int seed)
        {
            _seed = seed;
        }

        public static void Main()
        {
            _instance.CrateNewGame();
        }

        public void CrateNewGame()
        {
            var aGame = new Game();

            AddPlayersToGame(aGame);
            StartNewGame(aGame);
        }

        private static void AddPlayersToGame(Game aGame)
        {
            aGame.Players.Add("Chet");
            aGame.Players.Add("Pat");
            aGame.Players.Add("Sue");
        }

        private static void StartNewGame(Game aGame)
        {
            var rand = new Random(_seed);

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                _notAWinner = rand.Next(9) == 7 ? aGame.WrongAnswer() : aGame.WasCorrectlyAnswered();
            } while (_notAWinner);
        }


    }
}