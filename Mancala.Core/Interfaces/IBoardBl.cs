using Mancala.Domain.Models;

namespace Mancala.Core.Interfaces;

public interface IBoardBl
{
    /// <summary>
    /// Starts a new instance of the game.
    /// </summary>
    /// <param name="playerOneName">The name of the first player.</param>
    /// <param name="playerTwoName">The name of the second player.</param>
    /// <returns>A new instance of <see cref="Board"/></returns>
    Board StartNewGame(string playerOneName, string playerTwoName);

    /// <summary>
    /// Takes a turn for a specific player. The seeds of the specific pit is distributed to the following pits.
    /// </summary>
    /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
    /// <param name="playerId">The player id of the player who is sowing.</param>
    /// <returns>The current instance of the <see cref="Board"/></returns>
    Board TakePlayerTurn(int sequenceId, int playerId);
}