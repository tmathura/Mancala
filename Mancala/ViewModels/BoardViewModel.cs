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
                var takePlayerTurnAgain = _boardBl.TakePlayerTurn(pit.SequenceId, pit.PlayerId, out _, out _);

                if (takePlayerTurnAgain)
                {
                    _mainWindowViewModel.BannerText = $"{Players.First(player => player.Id == pit.PlayerId).PlayerName} can play again.";
                }
                else
                {
                    _mainWindowViewModel.BannerText = $"{Players.First(player => player.Id != pit.PlayerId).PlayerName} it is your turn now.";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
