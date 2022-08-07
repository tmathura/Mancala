using Mancala.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mancala.UnitTests.ViewModels
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void BannerText_DefaultValue()
        {
            Assert.AreEqual("Click any \"Pit\" to get started!", new MainWindowViewModel(null!).BannerText);
        }
    }
}