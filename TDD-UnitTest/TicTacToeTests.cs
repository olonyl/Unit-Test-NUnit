using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDD_UnitTest.TicTacToe;

namespace TDD_UnitTest
{

    public class TicTacToeTests
    {
        [Test]
        public void CreateGame_GameIsIncorrectState()
        {
            Game game = new Game();

            Assert.AreEqual(0, game.MovesCounter);
            Assert.AreEqual(State.Unset, game.GetState(1));
        }

        [Test]
        public void MakeMove_CounterShifts()
        {
            Game game = new Game();
            game.MakeMove(1);

            Assert.AreEqual(1, game.MovesCounter);
        }

        [Test]
        public void MakeInvalidMove_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var game = new Game();
                game.MakeMove(0);
            });
        }

        [Test]
        public void MoveOnTheSameSquare_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var game = new Game();
                game.MakeMove(1);
                game.MakeMove(1);
            });
        }

        [TestCase(State.Cross, 1)]
        [TestCase(State.Zero, 2)]
        [TestCase(State.Cross, 3)]
        [TestCase(State.Zero, 4)]
        public void MakingMoves_SetStateCorrectly(State expected, int movement)
        {
            Game game = new Game();
            MakeMoves(game, 1, 2, 3, 4);

            Assert.AreEqual(expected, game.GetState(movement));
        }

        [Test]
        public void GetWinner_CrossesWinDiagonal_ReturnsCrosses()
        {
            Game game = new Game();

            //1, 5, 9
            MakeMoves(game, 1, 4, 5, 2, 9);

            Assert.AreEqual(Winner.Crosses, game.GetWinner());

        }
        [Test]
        public void GetWinner_ZeroesWinVertically_ReturnsZeroes()
        {
            Game game = new Game();

            //2, 5, 8
            MakeMoves(game, 1, 2, 3, 5, 7, 8);

            Assert.AreEqual(Winner.Zeroes, game.GetWinner());
        }
        
        [Test]
        public void GetWinner_GameIsUnfinished_ReturnsGameIsUnfinished()
        {
            Game game = new Game();

            //2, 5, 8
            MakeMoves(game, 1, 2);

            Assert.AreEqual(Winner.GameIsUnfinished, game.GetWinner());
        }

        [Test]
        public void GetWinner_GameIsDraw_ReturnsGameDraw()
        {
            Game game = new Game();

            //2, 5, 8
            MakeMoves(game, 1,2,3,4,5,7,8,9,6);

            Assert.AreEqual(Winner.Draw, game.GetWinner());
        }

        [TestCase("This game is Draw", 1, 2, 3, 4, 5, 7, 8, 9, 6)]
        [TestCase("Result: Zeroes wins the Game!!", 1, 2, 3, 5, 7, 8)] 
        [TestCase("Result: Crosses wins the Game!!", 1, 4, 5, 2, 9)]
        public void ToString_GetGameStatusWhenZeroesWins_ReturnsCorrectMessage(string expectedMessage, params int[] movements)
        {
            Game game = new Game();

            //2, 5, 8
            MakeMoves(game, movements);

            Assert.AreEqual(expectedMessage, game.ToString());
        }
        private void MakeMoves(Game game, params int[] indexes)
        {
            foreach(var index in indexes)
                game.MakeMove(index);
        }
    }
}
