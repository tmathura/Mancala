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
        private Board _board = null!;

        /// <summary>
        /// Starts a new instance of the game.
        /// </summary>
        /// <param name="playerOneName">The name of the first player.</param>
        /// <param name="playerTwoName">The name of the second player.</param>
        /// <returns>A new instance of the <see cref="Board"/></returns>
        public Board StartNewGame(string playerOneName, string playerTwoName)
        {
            var players = new List<Player> { new( 0, playerOneName), new(1, playerTwoName) };

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

            return _board = new Board(players, stores, pits);
        }

        /// <summary>
        /// Takes a turn for a specific player. The seeds of the specific pit is distributed to the following pits.
        /// </summary>
        /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        /// <returns>The current instance of the <see cref="Board"/></returns>
        public Board TakePlayerTurn(int sequenceId, int playerId)
        {
            TakePlayerTurnValidation(sequenceId, playerId);

            var skipIndex = sequenceId;
            var selectedPitSeedCount = _board.Pits.FirstOrDefault(pit => pit.SequenceId == sequenceId)?.Seeds;

            while (selectedPitSeedCount > 0)
            {
                foreach (var pit in _board.Pits.Skip(skipIndex))
                {
                    if (pit.SequenceId == sequenceId)
                    {
                        pit.Seeds = 0;
                        continue;
                    }

                    if (selectedPitSeedCount > 0)
                    {
                        if (pit.PlayerId != playerId)
                        {
                            _board.Stores.FirstOrDefault(store => store.PlayerId == playerId)!.Seeds += 1;
                            selectedPitSeedCount -= 1;
                        }

                        if (selectedPitSeedCount > 0)
                        {
                            pit.Seeds += 1;
                            selectedPitSeedCount -= 1;
                        }
                    }

                    if (selectedPitSeedCount == 0)
                    {
                        break;
                    }
                }

                skipIndex = 0;
            }

            return _board;
        }

        /// <summary>
        /// Validate the player turn.
        /// </summary>
        /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        private void TakePlayerTurnValidation(int sequenceId, int playerId)
        {
            if (_board == null)
            {
                throw new NullReferenceException("The board is not instantiated.");
            }

            var selectedPit = _board.Pits.FirstOrDefault(pit => pit.SequenceId == sequenceId && pit.PlayerId == playerId);

            if (selectedPit == null)
            {
                throw new Exception("The selected player is not allowed to sow from this pit.");
            }

            if (selectedPit.Seeds <= 0)
            {
                throw new Exception("The selected pit has no seed.");
            }
        }
    }
}