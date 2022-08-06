using Mancala.Core.Interfaces;
using Mancala.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Mancala.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IBoardBl _boardBl;
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
                _boardBl.TakePlayerTurn(pit.SequenceId, pit.PlayerId, out _, out _);
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
