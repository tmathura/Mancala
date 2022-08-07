using Mancala.Core.Interfaces;
using Mancala.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mancala.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
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
            BannerText = $"{playerOneName} can click any \"Pit\" to start playing.";
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
                    OnPropertyChanged();
                }
            }
        }

        private bool _aiEnabled;
        public bool AiEnabled
        {
            get => _aiEnabled;
            set
            {
                _aiEnabled = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
