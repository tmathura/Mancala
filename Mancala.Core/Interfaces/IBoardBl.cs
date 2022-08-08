using Mancala.Domain.Enums;
using Mancala.Domain.Models;

namespace Mancala.Core.Interfaces;

public interface IBoardBl
{
    Board Board { get; }

    /// <summary>
    /// Starts a new instance of the game.
    /// </summary>
    /// <param name="playerOneName">The name of the first player.</param>
    /// <param name="playerTwoName">The name of the second player.</param>
    void StartNewGame(string playerOneName, string playerTwoName);

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
    bool Play(int sequenceId, PlayerId playerId, bool aiEnabled, out PlayerId nextPlayerId, out bool isGameOver, out PlayerId? winningPlayerId);
}