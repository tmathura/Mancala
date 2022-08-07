using System.Linq;
using Mancala.Core.Interfaces;
using Mancala.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Mancala.UnitTests.ViewModels
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public MainWindowViewModelTests()
        {
            var boardBl = new Mock<IBoardBl>();
            _mainWindowViewModel = new MainWindowViewModel(boardBl.Object);
        }

        /// <summary>
        /// Test that the initial banner text is correct.
        /// </summary>
        [TestMethod]
        public void BannerText_InitialValue()
        {
            // Assert
            Assert.AreEqual("Click \"New Game\" to get started!", _mainWindowViewModel.BannerText);
        }

        /// <summary>
        /// Test that the banner text is correct when a new game is started.
        /// </summary>
        [TestMethod]
        public void StartNewGame()
        {
            // Arrange
            const string playerOneName = "Player 1";

            // Act
            _mainWindowViewModel.StartNewGame(playerOneName, "Player 2");

            // Assert
            Assert.AreEqual($"{playerOneName} can click any \"Pit\" to start playing.", _mainWindowViewModel.BannerText);
        }
    }
}