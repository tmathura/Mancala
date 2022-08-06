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
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.StartNewGame("Player One", "Player Two");
        }
    }
}
