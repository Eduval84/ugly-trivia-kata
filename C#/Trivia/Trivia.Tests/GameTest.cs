using System;
using System.IO;
using System.Text;
using Xunit;

namespace Trivia.Tests
{
    public class GameTest
    {
        #region GoldenMasterExpectedResults

        private string expectedResult_0711 = @"Chet was added
They are player number 1
Pat was added
They are player number 2
Sue was added
They are player number 3
Chet is the current player
They have rolled a 1
Chet's new location is 1
The category is Science
Science Question 0
Answer was correct!!!!
Chet now has 1 Gold Coins.
Pat is the current player
They have rolled a 4
Pat's new location is 4
The category is Pop
Pop Question 0
Answer was correct!!!!
Pat now has 1 Gold Coins.
Sue is the current player
They have rolled a 2
Sue's new location is 2
The category is Sports
Sports Question 0
Answer was correct!!!!
Sue now has 1 Gold Coins.
Chet is the current player
They have rolled a 3
Chet's new location is 4
The category is Pop
Pop Question 1
Answer was correct!!!!
Chet now has 2 Gold Coins.
Pat is the current player
They have rolled a 5
Pat's new location is 9
The category is Science
Science Question 1
Answer was correct!!!!
Pat now has 2 Gold Coins.
Sue is the current player
They have rolled a 1
Sue's new location is 3
The category is Rock
Rock Question 0
Answer was correct!!!!
Sue now has 2 Gold Coins.
Chet is the current player
They have rolled a 3
Chet's new location is 7
The category is Rock
Rock Question 1
Answer was correct!!!!
Chet now has 3 Gold Coins.
Pat is the current player
They have rolled a 4
Pat's new location is 1
The category is Science
Science Question 2
Answer was correct!!!!
Pat now has 3 Gold Coins.
Sue is the current player
They have rolled a 4
Sue's new location is 7
The category is Rock
Rock Question 2
Question was incorrectly answered
Sue was sent to the penalty box
Chet is the current player
They have rolled a 5
Chet's new location is 0
The category is Pop
Pop Question 2
Answer was correct!!!!
Chet now has 4 Gold Coins.
Pat is the current player
They have rolled a 2
Pat's new location is 3
The category is Rock
Rock Question 3
Answer was correct!!!!
Pat now has 4 Gold Coins.
Sue is the current player
They have rolled a 1
Sue is getting out of the penalty box
Sue's new location is 8
The category is Pop
Pop Question 3
Answer was correct!!!!
Sue now has 3 Gold Coins.
Chet is the current player
They have rolled a 2
Chet's new location is 2
The category is Sports
Sports Question 1
Question was incorrectly answered
Chet was sent to the penalty box
Pat is the current player
They have rolled a 2
Pat's new location is 5
The category is Science
Science Question 3
Answer was correct!!!!
Pat now has 5 Gold Coins.
Sue is the current player
They have rolled a 5
Sue is getting out of the penalty box
Sue's new location is 1
The category is Science
Science Question 4
Answer was correct!!!!
Sue now has 4 Gold Coins.
Chet is the current player
They have rolled a 4
Chet is not getting out of the penalty box
Pat is the current player
They have rolled a 2
Pat's new location is 7
The category is Rock
Rock Question 4
Question was incorrectly answered
Pat was sent to the penalty box
Sue is the current player
They have rolled a 5
Sue is getting out of the penalty box
Sue's new location is 6
The category is Sports
Sports Question 2
Answer was correct!!!!
Sue now has 5 Gold Coins.
Chet is the current player
They have rolled a 5
Chet is getting out of the penalty box
Chet's new location is 7
The category is Rock
Rock Question 5
Answer was correct!!!!
Chet now has 5 Gold Coins.
Pat is the current player
They have rolled a 1
Pat is getting out of the penalty box
Pat's new location is 8
The category is Pop
Pop Question 4
Answer was correct!!!!
Pat now has 6 Gold Coins.
";
        private string expectedResult_19101984 = @"Chet was added
They are player number 1
Pat was added
They are player number 2
Sue was added
They are player number 3
Chet is the current player
They have rolled a 1
Chet's new location is 1
The category is Science
Science Question 0
Answer was correct!!!!
Chet now has 1 Gold Coins.
Pat is the current player
They have rolled a 4
Pat's new location is 4
The category is Pop
Pop Question 0
Answer was correct!!!!
Pat now has 1 Gold Coins.
Sue is the current player
They have rolled a 2
Sue's new location is 2
The category is Sports
Sports Question 0
Answer was correct!!!!
Sue now has 1 Gold Coins.
Chet is the current player
They have rolled a 3
Chet's new location is 4
The category is Pop
Pop Question 1
Answer was correct!!!!
Chet now has 2 Gold Coins.
Pat is the current player
They have rolled a 5
Pat's new location is 9
The category is Science
Science Question 1
Answer was correct!!!!
Pat now has 2 Gold Coins.
Sue is the current player
They have rolled a 1
Sue's new location is 3
The category is Rock
Rock Question 0
Answer was correct!!!!
Sue now has 2 Gold Coins.
Chet is the current player
They have rolled a 3
Chet's new location is 7
The category is Rock
Rock Question 1
Answer was correct!!!!
Chet now has 3 Gold Coins.
Pat is the current player
They have rolled a 4
Pat's new location is 1
The category is Science
Science Question 2
Answer was correct!!!!
Pat now has 3 Gold Coins.
Sue is the current player
They have rolled a 4
Sue's new location is 7
The category is Rock
Rock Question 2
Question was incorrectly answered
Sue was sent to the penalty box
Chet is the current player
They have rolled a 5
Chet's new location is 0
The category is Pop
Pop Question 2
Answer was correct!!!!
Chet now has 4 Gold Coins.
Pat is the current player
They have rolled a 2
Pat's new location is 3
The category is Rock
Rock Question 3
Answer was correct!!!!
Pat now has 4 Gold Coins.
Sue is the current player
They have rolled a 1
Sue is getting out of the penalty box
Sue's new location is 8
The category is Pop
Pop Question 3
Answer was correct!!!!
Sue now has 3 Gold Coins.
Chet is the current player
They have rolled a 2
Chet's new location is 2
The category is Sports
Sports Question 1
Question was incorrectly answered
Chet was sent to the penalty box
Pat is the current player
They have rolled a 2
Pat's new location is 5
The category is Science
Science Question 3
Answer was correct!!!!
Pat now has 5 Gold Coins.
Sue is the current player
They have rolled a 5
Sue is getting out of the penalty box
Sue's new location is 1
The category is Science
Science Question 4
Answer was correct!!!!
Sue now has 4 Gold Coins.
Chet is the current player
They have rolled a 4
Chet is not getting out of the penalty box
Pat is the current player
They have rolled a 2
Pat's new location is 7
The category is Rock
Rock Question 4
Question was incorrectly answered
Pat was sent to the penalty box
Sue is the current player
They have rolled a 5
Sue is getting out of the penalty box
Sue's new location is 6
The category is Sports
Sports Question 2
Answer was correct!!!!
Sue now has 5 Gold Coins.
Chet is the current player
They have rolled a 5
Chet is getting out of the penalty box
Chet's new location is 7
The category is Rock
Rock Question 5
Answer was correct!!!!
Chet now has 5 Gold Coins.
Pat is the current player
They have rolled a 1
Pat is getting out of the penalty box
Pat's new location is 8
The category is Pop
Pop Question 4
Answer was correct!!!!
Pat now has 6 Gold Coins.
";

        #endregion

        [Fact]
        public void GoldenMasterTest_seed0711()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.SetOut(new StringWriter(stringBuilder));

            GameRunner.seed = 0711;
            GameRunner.Main();
            string gameResult = stringBuilder.ToString();
            Assert.Equal(expectedResult_0711, gameResult);
        }

        [Fact]
        public void GoldenMasterTest_seed19101984()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.SetOut(new StringWriter(stringBuilder));

            GameRunner.seed = 19101984;
            GameRunner.Main();
            string gameResult = stringBuilder.ToString();
            Assert.Equal(expectedResult_19101984, gameResult);
        }
    }
}