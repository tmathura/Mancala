using Mancala.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MancalaTests.ViewModelTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void BannerText_DefaultValue()
        {
            Assert.AreEqual("Click \"New Game\" to get started!", new MainWindowViewModel(null!).BannerText);
        }
    }
}