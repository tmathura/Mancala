using Mancala.Core.Interfaces;
using Mancala.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Mancala.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IBoardBl _boardBl;
        public List<Player> Players => _boardBl.Board.Players;
        public List<Store> Stores => _boardBl.Board.Stores;
        public List<Pit> Pits => _boardBl.Board.Pits;
        public ICommand TakePlayerTurnCommand { get; set; }

        public MainWindowViewModel(IBoardBl boardBl)
        {
            _boardBl = boardBl;
            TakePlayerTurnCommand = new TakePlayerTurnCommand(Play);
        }

        private void Play(Pit pit)
        {
            try
            {
                var takePlayerTurnAgain = _boardBl.TakePlayerTurn(pit.SequenceId, pit.PlayerId, out _, out _);

                if (takePlayerTurnAgain)
                {
                    BannerText = $"{Players.First(player => player.Id == pit.PlayerId).PlayerName} can play again.";
                }
                else
                {
                    BannerText = $"{Players.First(player => player.Id != pit.PlayerId).PlayerName} it is your turn now.";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
