using Mancala.Core.Interfaces;
using Mancala.Domain.Models;

namespace Mancala.Core.Implementations
{
    /// <summary>
    /// Board business logic
    /// </summary>
    /// <seealso cref="IBoardBl" />
    public class BoardBl : IBoardBl
    {
        public Board Board { get; }

        public BoardBl(Board? board)
        {
            board ??= SetUpDefaultBoard();

            Board = board;
        }

        /// <summary>
        /// Starts a new instance of the game.
        /// </summary>
        /// <param name="playerOneName">The name of the first player.</param>
        /// <param name="playerTwoName">The name of the second player.</param>
        public void StartNewGame(string playerOneName, string playerTwoName)
        {
            Board.Players[0].PlayerName = playerOneName;
            Board.Players[1].PlayerName = playerTwoName;

            foreach (var player in Board.Players)
            {
                player.Enabled = true;
            }

            foreach (var store in Board.Stores)
            {
                store.Seeds = 0;
            }

            foreach (var pit in Board.Pits)
            {
                pit.Seeds = 4;
            }
        }

        /// <summary>
        /// Set up the default board.
        /// </summary>
        /// <returns>A new instance of the <see cref="Board"/></returns>
        private static Board SetUpDefaultBoard()
        {
            var players = new List<Player> { new(0, "Player 1", true), new(1, "Player 2", true) };

            var stores = new List<Store>();
            var pits = new List<Pit>();
            const int totalPitsPerPlayer = 6;

            foreach (var player in players)
            {
                stores.Add(new Store(stores.Count, player.Id, 0));

                for (var pit = 0; pit < totalPitsPerPlayer; pit++)
                {
                    pits.Add(new Pit(pit, player.Id, 4, pits.Count));
                }
            }
            
            return new Board(players, stores, pits);
        }

        /// <summary>
        /// Takes a turn for a specific player. The seeds of the specific pit is distributed to the following pits.
        /// </summary>
        /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        /// <param name="isGameOver">Out parameter to see if the game is over.</param>
        /// <param name="winningPlayerId">Out parameter of the winners player id.</param>
        /// <returns>True or false if the player must take a turn again.</returns>
        public bool TakePlayerTurn(int sequenceId, int playerId, out bool isGameOver, out int? winningPlayerId)
        {
            TakePlayerTurnValidation(sequenceId, playerId);

            var isLastSeedSowedInStore = false;
            var selectedPit = Board.Pits.First(pit => pit.SequenceId == sequenceId);
            var selectedPitSeedCount = selectedPit.Seeds;
            selectedPit.Seeds = 0;

            DistributeSeeds(playerId, selectedPitSeedCount, sequenceId + 1, ref isLastSeedSowedInStore);

            isGameOver = CheckIfGameIsOver(out winningPlayerId);

            if (isLastSeedSowedInStore)
            {
                foreach (var player in Board.Players)
                {
                    player.Enabled = player.Id == playerId;
                }
            }
            else
            {
                foreach (var player in Board.Players)
                {
                    player.Enabled = player.Id != playerId;
                }
            }

            return isLastSeedSowedInStore;
        }

        /// <summary>
        /// Distribute the seeds across the pits on the board.
        /// </summary>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        /// <param name="selectedPitSeedCount">The number of seeds to distribute.</param>
        /// <param name="skipIndex">At which index to start the for each loop.</param>
        /// <param name="isLastSeedSowedInStore">Reference variable to see if the last seed sowed was in the store</param>
        private void DistributeSeeds(int playerId, int? selectedPitSeedCount, int skipIndex, ref bool isLastSeedSowedInStore)
        {
            if (selectedPitSeedCount > 0)
            {
                foreach (var pit in Board.Pits.Skip(skipIndex))
                {
                    if (selectedPitSeedCount > 0)
                    {
                        if (pit.PlayerId != playerId && pit.Id == 0)
                        {
                            if (selectedPitSeedCount == 1)
                            {
                                isLastSeedSowedInStore = true;
                            }
                            Board.Stores.First(store => store.PlayerId == playerId).Seeds += 1;
                            selectedPitSeedCount -= 1;
                        }

                        if (selectedPitSeedCount > 0)
                        {
                            var correspondingOpponentPitSequenceId = Board.Pits.Count - pit.SequenceId - 1;
                            var correspondingOpponentPit = Board.Pits.First(opponentPit => opponentPit.SequenceId == correspondingOpponentPitSequenceId);

                            if (pit.PlayerId == playerId && pit.Seeds == 0 && correspondingOpponentPit.Seeds > 0 && selectedPitSeedCount == 1)
                            {
                                Board.Stores.First(store => store.PlayerId == playerId).Seeds += 1 + correspondingOpponentPit.Seeds;
                                correspondingOpponentPit.Seeds = 0;
                                selectedPitSeedCount -= 1;
                            }
                            else
                            {
                                pit.Seeds += 1;
                                selectedPitSeedCount -= 1;
                            }
                        }
                    }

                    if (selectedPitSeedCount == 0)
                    {
                        break;
                    }
                }

                DistributeSeeds(playerId, selectedPitSeedCount, 0, ref isLastSeedSowedInStore);
            }
        }

        /// <summary>
        /// Checks if the game is over.
        /// </summary>
        /// <param name="winningPlayerId">Out parameter of the winners player id.</param>
        private bool CheckIfGameIsOver(out int? winningPlayerId)
        {
            winningPlayerId = null;
            var isGameOver = false;

            var playerOnePitSeedsCount = Board.Pits.Where(pit => pit.PlayerId == 0).Sum(pit => pit.Seeds);
            var playerTwoPitSeedsCount = Board.Pits.Where(pit => pit.PlayerId == 1).Sum(pit => pit.Seeds);

            if (playerOnePitSeedsCount == 0 || playerTwoPitSeedsCount == 0)
            {
                foreach (var pit in Board.Pits.Where(pit => pit.Seeds > 0))
                {
                    Board.Stores.First(store => store.PlayerId == pit.PlayerId).Seeds += pit.Seeds;
                    pit.Seeds = 0;
                }

                isGameOver = true;
            }

            if (isGameOver)
            {
                var playerOneStoreSeedsCount = Board.Stores.Where(pit => pit.PlayerId == 0).Sum(pit => pit.Seeds);
                var playerTwoStoreSeedsCount = Board.Stores.Where(pit => pit.PlayerId == 1).Sum(pit => pit.Seeds);

                if (playerOneStoreSeedsCount > playerTwoStoreSeedsCount)
                {
                    winningPlayerId = 0;
                }
                else if (playerTwoStoreSeedsCount > playerOneStoreSeedsCount)
                {
                    winningPlayerId = 1;
                }
            }

            return isGameOver;
        }

        /// <summary>
        /// Validate the player turn.
        /// </summary>
        /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        private void TakePlayerTurnValidation(int sequenceId, int playerId)
        {
            if (Board == null)
            {
                throw new NullReferenceException("The board is not instantiated.");
            }

            var selectedPit = Board.Pits.FirstOrDefault(pit => pit.SequenceId == sequenceId && pit.PlayerId == playerId);

            if (selectedPit == null)
            {
                throw new Exception("The selected player is not allowed to sow from this pit.");
            }

            if (selectedPit.Seeds <= 0)
            {
                throw new Exception("The selected pit has no seeds.");
            }
        }
    }
}