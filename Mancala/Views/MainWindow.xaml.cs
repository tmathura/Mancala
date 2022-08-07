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

            DataContext = _mainWindowViewModel;
            var boardViewModel = new BoardViewModel(boardBl, _mainWindowViewModel);
            GameBoard.DataContext = boardViewModel;
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
