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
}