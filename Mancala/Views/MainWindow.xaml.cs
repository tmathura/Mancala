using Mancala.ViewModels;
using System;
using System.Windows;

namespace Mancala.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BoardViewModel boardViewModel;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            boardViewModel = new BoardViewModel();
            GameBoard.DataContext = boardViewModel;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
