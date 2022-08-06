using Mancala.Core.Interfaces;
using Mancala.ViewModels;
using System.Windows;

namespace Mancala.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public MainWindow(IBoardBl boardBl)
        {
            InitializeComponent();

            _mainWindowViewModel = new MainWindowViewModel(boardBl);

            PlayerOneNameTextBlock.DataContext = _mainWindowViewModel;
            BannerTextBlock.DataContext = _mainWindowViewModel;
            StoreOneTextBlock.DataContext = _mainWindowViewModel;
            Pit11.DataContext = _mainWindowViewModel;
            Pit10.DataContext = _mainWindowViewModel;
            Pit9.DataContext = _mainWindowViewModel;
            Pit8.DataContext = _mainWindowViewModel;
            Pit7.DataContext = _mainWindowViewModel;
            Pit6.DataContext = _mainWindowViewModel;
            Pit0.DataContext = _mainWindowViewModel;
            Pit1.DataContext = _mainWindowViewModel;
            Pit2.DataContext = _mainWindowViewModel;
            Pit3.DataContext = _mainWindowViewModel;
            Pit4.DataContext = _mainWindowViewModel;
            Pit5.DataContext = _mainWindowViewModel;
            StoreTwoTextBlock.DataContext = _mainWindowViewModel;
            PlayerTwoNameTextBlock.DataContext = _mainWindowViewModel;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            var playerOneName = "";
            var inputDialogPlayerOne = new InputDialog("Please enter your name:", "Player One");
            if (inputDialogPlayerOne.ShowDialog() == true)
            {
                playerOneName = inputDialogPlayerOne.Answer;
            }

            if (string.IsNullOrWhiteSpace(playerOneName))
            {
                return;
            }

            var playerTwoName = "";
            var inputDialogPlayerTwo = new InputDialog("Please enter your name:", "Player Two");
            if (inputDialogPlayerTwo.ShowDialog() == true)
            {
                playerTwoName = inputDialogPlayerTwo.Answer;
            }

            if (string.IsNullOrWhiteSpace(playerTwoName))
            {
                return;
            }

            _mainWindowViewModel.StartNewGame(playerOneName, playerTwoName);
        }
    }
}
