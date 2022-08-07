using Mancala.Core.Implementations;
using Mancala.Domain.Models;
using Mancala.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mancala.UnitTests.ViewModels
{
    [TestClass]
    public class BoardViewModelTests
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly BoardViewModel _boardViewModel;

        public BoardViewModelTests()
        {
            var boardBl = new BoardBl(null);
            _mainWindowViewModel = new MainWindowViewModel(boardBl);
            _boardViewModel = new BoardViewModel(boardBl, _mainWindowViewModel);
        }

        /// <summary>
        /// Test that the banner text is correct when player one can play again.
        /// </summary>
        [TestMethod]
        public void Play_PlayerOneCanPlayAgain()
        {
            // Arrange
            var pit = new Pit(2, 0, 4, 2);


            // Act
            _boardViewModel.TakePlayerTurnCommand.Execute(pit);

            // Assert
            Assert.AreEqual("Player 1 can play again.", _mainWindowViewModel.BannerText);
        }

        /// <summary>
        /// Test that the banner text is correct when player two can play again.
        /// </summary>
        [TestMethod]
        public void Play_PlayerTwoCanPlayAgain()
        {
            // Arrange
            var pit = new Pit(2, 1, 4, 8);


            // Act
            _boardViewModel.TakePlayerTurnCommand.Execute(pit);

            // Assert
            Assert.AreEqual("Player 2 can play again.", _mainWindowViewModel.BannerText);
        }

        /// <summary>
        /// Test that the banner text is correct when it is player ones turn.
        /// </summary>
        [TestMethod]
        public void Play_PlayerOneTurn()
        {
            // Arrange
            var pit = new Pit(2, 0, 4, 1);


            // Act
            _boardViewModel.TakePlayerTurnCommand.Execute(pit);

            // Assert
            Assert.AreEqual("Player 2 it is your turn now.", _mainWindowViewModel.BannerText);
        }

        /// <summary>
        /// Test that the banner text is correct when it is player twos turn.
        /// </summary>
        [TestMethod]
        public void Play_PlayerTwoTurn()
        {
            // Arrange
            var pit = new Pit(2, 1, 4, 7);


            // Act
            _boardViewModel.TakePlayerTurnCommand.Execute(pit);

            // Assert
            Assert.AreEqual("Player 1 it is your turn now.", _mainWindowViewModel.BannerText);
        }
    }
}