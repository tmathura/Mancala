using Mancala.Core.Extensions;
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
                player.Enabled = player.PlayerName == playerOneName;
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
        /// Make a play in the game.
        /// </summary>
        /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        /// <param name="aiEnabled">Enable ai automatically</param>
        /// <param name="nextPlayerId">Out parameter of the next player id</param>
        /// <param name="isGameOver">Out parameter to see if the game is over.</param>
        /// <param name="winningPlayerId">Out parameter of the winners player id.</param>
        /// <returns>True or false if the player must take a turn again.</returns>
        public bool Play(int sequenceId, int playerId, bool aiEnabled, out int nextPlayerId, out bool isGameOver, out int? winningPlayerId)
        {
            var isLastSeedSowedInStore = TakePlayerTurn(sequenceId, playerId, out isGameOver, out winningPlayerId);
            nextPlayerId = isLastSeedSowedInStore ? playerId : Board.Players.First(player => player.Id != playerId).Id;

            if (aiEnabled && !isLastSeedSowedInStore && !isGameOver)
            {
                isLastSeedSowedInStore = TakeAiTurn(out isGameOver, out winningPlayerId);
                nextPlayerId = playerId;
            }
            
            return isLastSeedSowedInStore;
        }

        /// <summary>
        /// Takes a turn for a specific player.
        /// </summary>
        /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        /// <param name="isGameOver">Out parameter to see if the game is over.</param>
        /// <param name="winningPlayerId">Out parameter of the winners player id.</param>
        /// <returns>True or false if the player must take a turn again.</returns>
        private bool TakePlayerTurn(int sequenceId, int playerId, out bool isGameOver, out int? winningPlayerId)
        {
            TakePlayerTurnValidation(sequenceId, playerId);

            var isLastSeedSowedInStore = false;
            int? capturedOpponentPitSequenceId = null;
            var selectedPit = Board.Pits.First(pit => pit.SequenceId == sequenceId);
            var selectedPitSeedCount = selectedPit.Seeds;
            selectedPit.Seeds = 0;

            DistributeSeeds(Board, playerId, selectedPitSeedCount, sequenceId + 1, ref isLastSeedSowedInStore, ref capturedOpponentPitSequenceId);

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
        /// Takes a turn for the ai player.
        /// </summary>
        /// <param name="isGameOver">Out parameter to see if the game is over.</param>
        /// <param name="winningPlayerId">Out parameter of the winners player id.</param>
        /// <returns>True or false if the player must take a turn again.</returns>
        private bool TakeAiTurn(out bool isGameOver, out int? winningPlayerId)
        {
            var bestAiPitSequenceId = GetBestAiMove();
            const int playerId = 1;

            TakePlayerTurnValidation(bestAiPitSequenceId, playerId);

            var isLastSeedSowedInStore = false;
            int? capturedOpponentPitSequenceId = null;
            var selectedPit = Board.Pits.First(pit => pit.SequenceId == bestAiPitSequenceId);
            var selectedPitSeedCount = selectedPit.Seeds;
            selectedPit.Seeds = 0;

            DistributeSeeds(Board, playerId, selectedPitSeedCount, bestAiPitSequenceId + 1, ref isLastSeedSowedInStore, ref capturedOpponentPitSequenceId);

            isGameOver = CheckIfGameIsOver(out winningPlayerId);

            if (isLastSeedSowedInStore)
            {
                foreach (var player in Board.Players)
                {
                    player.Enabled = false;
                }
                
                isLastSeedSowedInStore = TakeAiTurn(out isGameOver, out winningPlayerId);
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
        /// <param name="board">The board to distribute the seeds.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        /// <param name="selectedPitSeedCount">The number of seeds to distribute.</param>
        /// <param name="skipIndex">At which index to start the for each loop.</param>
        /// <param name="isLastSeedSowedInStore">Reference variable to see if the last seed sowed was in the store.</param>
        /// <param name="capturedOpponentPitSequenceId">Reference variable to the opponents pit sequence id if it was captured.</param>
        private static void DistributeSeeds(Board board, int playerId, int? selectedPitSeedCount, int skipIndex, ref bool isLastSeedSowedInStore, ref int? capturedOpponentPitSequenceId)
        {
            if (selectedPitSeedCount > 0)
            {
                foreach (var pit in board.Pits.Skip(skipIndex))
                {
                    if (selectedPitSeedCount > 0)
                    {
                        if (pit.PlayerId != playerId && pit.Id == 0)
                        {
                            // Distribute one seed from the selected pit to the store
                            board.Stores.First(store => store.PlayerId == playerId).Seeds += 1;
                            if (selectedPitSeedCount == 1)
                            {
                                isLastSeedSowedInStore = true;
                            }
                            selectedPitSeedCount -= 1;
                        }

                        if (selectedPitSeedCount > 0)
                        {
                            var correspondingOpponentPit = GetCorrespondingOpponentPit(board, pit);

                            if (pit.PlayerId == playerId && pit.Seeds == 0 && correspondingOpponentPit.Seeds > 0 && selectedPitSeedCount == 1)
                            {
                                // Capture opponents pit seeds into the store
                                board.Stores.First(store => store.PlayerId == playerId).Seeds += 1 + correspondingOpponentPit.Seeds;
                                correspondingOpponentPit.Seeds = 0;
                                capturedOpponentPitSequenceId = correspondingOpponentPit.SequenceId;
                                selectedPitSeedCount -= 1;
                            }
                            else
                            {
                                // Distribute one seed from the selected pit to the next pit
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

                DistributeSeeds(board, playerId, selectedPitSeedCount, 0, ref isLastSeedSowedInStore, ref capturedOpponentPitSequenceId);
            }
        }

        private static Pit GetCorrespondingOpponentPit(Board board, Pit pit)
        {
            var correspondingOpponentPitSequenceId = board.Pits.Count - pit.SequenceId - 1;
            var correspondingOpponentPit =
                board.Pits.First(opponentPit => opponentPit.SequenceId == correspondingOpponentPitSequenceId);
            return correspondingOpponentPit;
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
        /// <summary>
        /// Get the sequence id to the best move the ai could make
        /// </summary>
        public int GetBestAiMove()
        {
            var pitSequenceId = -1;
            var currentBoard = Board.Copy();

            while (pitSequenceId < 0)
            {
                // Try and find a pit that gets the ai a free turn
                var isLastSeedSowedInStorePitSequenceIds = new List<int>();
                foreach (var pit in currentBoard.Pits.Where(pit => pit.PlayerId == 1))
                {
                    var isLastSeedSowedInStore = false;
                    int? capturedOpponentPitSequenceId = null;

                    DistributeSeeds(Board.Copy(), pit.PlayerId, pit.Seeds, pit.SequenceId + 1, ref isLastSeedSowedInStore, ref capturedOpponentPitSequenceId);

                    if (isLastSeedSowedInStore)
                    {
                        isLastSeedSowedInStorePitSequenceIds.Add(pit.SequenceId);
                    }
                }

                if (isLastSeedSowedInStorePitSequenceIds.Count > 0)
                {
                    // Choose the closest pit to the store
                    pitSequenceId = isLastSeedSowedInStorePitSequenceIds.Max();
                    break;
                }

                // Try and find a pit that captures the opponents pit
                var captorPits = new List<Pit>();
                foreach (var pit in currentBoard.Pits.Where(pit => pit.PlayerId == 1))
                {
                    var isLastSeedSowedInStore = false;
                    int? capturedOpponentPitSequenceId = null;

                    DistributeSeeds(Board.Copy(), pit.PlayerId, pit.Seeds, pit.SequenceId + 1, ref isLastSeedSowedInStore, ref capturedOpponentPitSequenceId);

                    if (capturedOpponentPitSequenceId != null)
                    {
                        var correspondingOpponentPit = currentBoard.Pits[(int)capturedOpponentPitSequenceId];
                        captorPits.Add(new Pit(pit.Id, pit.PlayerId, correspondingOpponentPit.Seeds, pit.SequenceId)); // seed count is set to the opponents to help determine highest capturing pit
                    }
                }

                if (captorPits.Count > 0)
                {
                    // Choose a pit that captures the most seeds
                    pitSequenceId = captorPits.OrderByDescending(pit => pit.Seeds).ThenByDescending(pit => pit.SequenceId).First().SequenceId;
                    break;
                }

                // Try and find a pit that the opponent might try and capture - choose a pit with the highest seed count
                var aiPits = new List<Pit>();
                foreach (var pit in currentBoard.Pits.Where(pit => pit.PlayerId == 0))
                {
                    var isLastSeedSowedInStore = false;
                    int? capturedOpponentPitSequenceId = null;

                    DistributeSeeds(Board.Copy(), pit.PlayerId, pit.Seeds, pit.SequenceId + 1, ref isLastSeedSowedInStore, ref capturedOpponentPitSequenceId);

                    if (capturedOpponentPitSequenceId != null)
                    {
                        var correspondingOpponentPit = currentBoard.Pits[(int)capturedOpponentPitSequenceId];
                        aiPits.Add(new Pit(correspondingOpponentPit.Id, correspondingOpponentPit.PlayerId, correspondingOpponentPit.Seeds, correspondingOpponentPit.SequenceId)); // seed count is set to the opponents to help determine highest capturing pit
                    }
                }

                if (aiPits.Count > 0)
                {
                    // Choose a pit that captures the most seeds
                    pitSequenceId = aiPits.OrderByDescending(pit => pit.Seeds).ThenByDescending(pit => pit.SequenceId).First().SequenceId;
                    break;
                }

                // If none of the above gets a pit sequence id then choose the closet pit to the store that has seeds
                pitSequenceId = currentBoard.Pits.Where(pit => pit.PlayerId == 1 && pit.Seeds > 0).OrderByDescending(pit => pit.SequenceId).First().SequenceId;

            }

            return pitSequenceId;
        }
    }
}