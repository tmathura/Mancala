using Mancala.Commands;
using Mancala.Core.Interfaces;
using Mancala.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Mancala.ViewModels
{
    public class BoardViewModel
    {
        private readonly IBoardBl _boardBl;
        private readonly MainWindowViewModel _mainWindowViewModel;
        public List<Player> Players => _boardBl.Board.Players;
        public List<Store> Stores => _boardBl.Board.Stores;
        public List<Pit> Pits => _boardBl.Board.Pits;
        public ICommand TakePlayerTurnCommand { get; set; }

        public BoardViewModel(IBoardBl boardBl, MainWindowViewModel mainWindowViewModel)
        {
            _boardBl = boardBl;
            _mainWindowViewModel = mainWindowViewModel;
            TakePlayerTurnCommand = new TakePlayerTurnCommand(Play);
        }

        private void Play(Pit pit)
        {
            try
            {
                var takePlayerTurnAgain = _boardBl.Play(pit.SequenceId, pit.PlayerId, _mainWindowViewModel.AiEnabled, out var nextPlayerId, out var isGameOver, out var winningPlayerId);

                if (isGameOver)
                {
                    MessageBox.Show($"{Players.First(player => player.Id == winningPlayerId).PlayerName} is the winner!", "Winner!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

                var nextPlayerName = Players.First(player => player.Id == nextPlayerId).PlayerName;
                if (takePlayerTurnAgain)
                {
                    _mainWindowViewModel.BannerText = $"{nextPlayerName} can play again.";
                }
                else
                {
                    _mainWindowViewModel.BannerText = $"{nextPlayerName} it is your turn now.";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
    }
}
