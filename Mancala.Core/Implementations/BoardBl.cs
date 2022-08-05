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
        private Board? _board;

        /// <summary>
        /// Starts a new instance of the game.
        /// </summary>
        /// <param name="playerOneName">The name of the first player.</param>
        /// <param name="playerTwoName">The name of the second player.</param>
        /// <returns>A new instance of <see cref="Board"/></returns>
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
    }
}