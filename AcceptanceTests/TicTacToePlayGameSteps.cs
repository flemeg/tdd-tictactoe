using NUnit.Framework;
using TechTalk.SpecFlow;
using TicTacToe;

namespace AcceptanceTests
{
    [Binding]
    public class TicTacToePlayGameSteps
    {
        private Game _game;

        [Given(@"I started a new game")]
        public void GivenIStartedANewGame()
        {
            _game = new Game();
        }
        
        [When(@"I put three crosses in a row")]
        public void WhenIPutThreeCrossesInARow()
        {
            _game.MakeMove(1); //X
            _game.MakeMove(4);
            _game.MakeMove(2); //X
            _game.MakeMove(5);
            _game.MakeMove(3); //X
        }
        
        [Then(@"I should win")]
        public void ThenIShouldWin()
        {
            Assert.AreEqual(Winner.Crosses, _game.GetWinner());
        }
    }
}
