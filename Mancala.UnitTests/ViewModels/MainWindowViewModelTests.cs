using Mancala.Core.Interfaces;
using Mancala.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Mancala.UnitTests.ViewModels
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private readonly Mock<IBoardBl> _boardBl;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private const string DefaultBannerText = "Click any \"Pit\" to get started!";

        public MainWindowViewModelTests()
        {
            _boardBl = new Mock<IBoardBl>();
            _mainWindowViewModel = new MainWindowViewModel(_boardBl.Object);
        }

        /// <summary>
        /// Test that the default banner text is correct.
        /// </summary>
        [TestMethod]
        public void BannerText_DefaultValue()
        {
            // Assert
            Assert.AreEqual(DefaultBannerText, _mainWindowViewModel.BannerText);
        }

        /// <summary>
        /// Test that the default banner text is correct when a new game is started and the banner text was changed.
        /// </summary>
        [TestMethod]
        public void BannerText_DefaultValueAfterStartGame()
        {
            // Arrange
            _mainWindowViewModel.BannerText = "Not the default banner text";


            // Act
            _mainWindowViewModel.StartNewGame("Player 1", "Player 2");

            // Assert
            Assert.AreEqual(DefaultBannerText, _mainWindowViewModel.BannerText);
        }
    }
}