using Mancala.Commands;
using Mancala.Core.Interfaces;
using Mancala.Domain.Enums;
using Mancala.Domain.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Mancala.ViewModels
{
    public class BoardViewModel
    {
        private readonly IBoardBl _boardBl;
        private readonly MainWindowViewModel _mainWindowViewModel;
        public Player PlayerOne => _boardBl.Board.Players[(int)PlayerId.PlayerOne];
        public Player PlayerTwo => _boardBl.Board.Players[(int)PlayerId.PlayerTwo];
        public Store PlayerOneStore => _boardBl.Board.Stores[(int)PlayerStoreId.PlayerOne];
        public Store PlayerTwoStore => _boardBl.Board.Stores[(int)PlayerStoreId.PlayerTwo];
        public Pit PlayerOnePitZero => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitZero];
        public Pit PlayerOnePitOne => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitOne];
        public Pit PlayerOnePitTwo => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitTwo];
        public Pit PlayerOnePitThree => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitThree];
        public Pit PlayerOnePitFour => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitFour];
        public Pit PlayerOnePitFive => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitFive];
        public Pit PlayerOnePitSix => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitSix];
        public Pit PlayerOnePitSeven => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitSeven];
        public Pit PlayerOnePitEight => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitEight];
        public Pit PlayerOnePitNine => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitNine];
        public Pit PlayerOnePitTen => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitTen];
        public Pit PlayerPitEleven => _boardBl.Board.Pits[(int)PlayerPitSequenceId.PitEleven];
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
                    MessageBox.Show($"{_boardBl.Board.Players.First(player => player.Id == winningPlayerId).PlayerName} is the winner!", "Winner!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

                var nextPlayerName = _boardBl.Board.Players.First(player => player.Id == nextPlayerId).PlayerName;

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
            }
        }
    }
}
