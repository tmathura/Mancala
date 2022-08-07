using Mancala.Core.Interfaces;
using Mancala.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mancala.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged, IMainWindowViewModel
    {
        private readonly IBoardBl _boardBl;
        public List<Player> Players => _boardBl.Board.Players;

        public MainWindowViewModel(IBoardBl boardBl)
        {
            _boardBl = boardBl;
        }

        public void StartNewGame(string playerOneName, string playerTwoName)
        {
            _boardBl.StartNewGame(playerOneName, playerTwoName);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _bannerText = "Click \"New Game\" to get started!";
        public string BannerText
        {
            get => _bannerText;
            set
            {
                if (_bannerText != value)
                {
                    _bannerText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BannerText)));
                }
            }
        }
    }
}
