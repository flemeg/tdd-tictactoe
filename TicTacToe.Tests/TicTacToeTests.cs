using NUnit.Framework;
using System;


namespace TicTacToe.Tests
{
    [TestFixture]
    class TicTacToeTests
    {
        [Test]
        public void CreateGame_GameIsInCorrectState()
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
        public void MakeInvalidMove_ThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var game = new Game();
                game.MakeMove(0);
            });
        }

        [Test]
        public void MoveOnTheSameSquare_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var game = new Game();
                game.MakeMove(1);
                game.MakeMove(1);
            });
        }

        [Test]
        public void MakingMoves_SetStateCorrectly()
        {
            Game game = new Game();
            MakeMoves(game, 1, 2, 3, 4);

            for (int i = 1; i <= game.MovesCounter; i++)
            {
                Assert.AreEqual(i % 2 == 0 ? State.Zero : State.Cross, game.GetState(i));
            }
        }

        [Test]
        public void GetWinner_ZeroesWinVertically_ReturnZeroes()
        {
            var game = new Game();

            //2, 5, 8 - zero win
            MakeMoves(game, 1, 2, 3, 5, 7, 8);
            
            Assert.AreEqual(Winner.Zeroes, game.GetWinner());
        }

        [Test]
        public void GetWinner_CrossesWinDiagonal_ReturnCrosses()
        {
            var game = new Game();

            //1, 5, 9 - crosses win
            MakeMoves(game, 1, 4, 5, 2, 9);

            Assert.AreEqual(Winner.Crosses, game.GetWinner());
        }

        [Test]
        public void GetWinner_GameIsUnfinished_ReturnsGameIsUnfinished()
        {
            var game = new Game();

            MakeMoves(game, 1, 2, 4);

            Assert.AreEqual(Winner.GameIsUnfinished, game.GetWinner());
        }

        private void MakeMoves(Game game, params int[] indexes)
        {
            foreach (var index in indexes)
            {
                game.MakeMove(index);
            }
        }

    }

   

}
