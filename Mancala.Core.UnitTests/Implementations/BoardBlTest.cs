using FluentAssertions;
using Mancala.Core.Implementations;
using Mancala.Core.UnitTests.MemberData;
using Mancala.Domain.Models;

namespace Mancala.Core.UnitTests.Implementations
{
    public class BoardBlTest
    {
        private BoardBl _boardBl;

        public BoardBlTest()
        {
            _boardBl = new BoardBl(null);
        }

        /// <summary>
        /// Test that the board is set up correctly.
        /// </summary>
        [Fact]
        public void StartNewGame()
        {
            // Arrange
            var playerNames = new List<string> { "Player One", "Player Two" };

            // Act
            _boardBl.StartNewGame(playerNames.First(), playerNames.Last());

            // Assert
            Assert.NotNull(_boardBl.Board);

            Assert.NotNull(_boardBl.Board.Players);
            Assert.Equal(playerNames.Count, _boardBl.Board.Players.Count);

            Assert.NotNull(_boardBl.Board.Stores);
            Assert.Equal(2, _boardBl.Board.Stores.Count);

            Assert.NotNull(_boardBl.Board.Pits);
            Assert.Equal(12, _boardBl.Board.Pits.Count);

            for (var playerId = 0; playerId < playerNames.Count; playerId++)
            {
                var currentPlayer = _boardBl.Board.Players[playerId];
                Assert.Equal(playerId, currentPlayer.Id);
                Assert.Equal(playerNames[playerId], currentPlayer.PlayerName);

                var currentBoard = _boardBl.Board.Stores[playerId];
                Assert.Equal(playerId, currentBoard.Id);
                Assert.Equal(playerId, currentBoard.PlayerId);
                Assert.Equal(0, currentBoard.Seeds);

                var currentPlayerPits = _boardBl.Board.Pits.Where(pit => pit.PlayerId == playerId).ToList();
                Assert.Equal(6, currentPlayerPits.Count);

                const int totalPitsPerPlayer = 6;

                for (var pitId = 0; pitId < totalPitsPerPlayer; pitId++)
                {
                    Assert.Equal(4, currentPlayerPits[pitId].Seeds);

                    // Check that the pit id is correct for the specific player
                    Assert.Equal(pitId, currentPlayerPits[pitId].Id);

                    // Check that the sequence is correct within the list of pits
                    var pitSequence = currentPlayerPits[pitId].SequenceId;
                    Assert.Equal(_boardBl.Board.Pits.FindIndex(pit => pit.SequenceId == pitSequence), pitSequence);
                }
            }

            Assert.Equal(48, _boardBl.Board.Stores.Sum(store => store.Seeds) + _boardBl.Board.Pits.Sum(pit => pit.Seeds));
        }

        /// <summary>
        /// Test a player taking a turn.
        /// </summary>
        /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        /// <param name="expectedBoard">The board expected that must be asserted against.</param>
        /// <param name="expectedMustPlayerTakeTurnAgain">The expected boolean if the player must take a turn again.</param>
        /// <param name="expectedIsGameOver">The expected boolean if the game is over or not.</param>
        /// <param name="expectedWinningPlayerId">The expected winning player id if the game is over.</param>
        [Theory]
        [MemberData(nameof(TakePlayerTurnData.GetData), MemberType = typeof(TakePlayerTurnData))]
        public void TakePlayerTurn(int sequenceId, int playerId, Board expectedBoard, bool expectedMustPlayerTakeTurnAgain, bool expectedIsGameOver, int? expectedWinningPlayerId)
        {
            // Act
            var mustPlayerTakeTurnAgain = _boardBl.TakePlayerTurn(sequenceId, playerId, out var isGameOver, out var winningPlayerId);

            // Assert
            Assert.Equal(expectedBoard.Players.Count, _boardBl.Board.Players.Count);

            // Check that the expected players matched the actual players
            for (var playerIndex = 0; playerIndex < expectedBoard.Players.Count; playerIndex++)
            {
                expectedBoard.Players[playerIndex].Should().BeEquivalentTo(_boardBl.Board.Players[playerIndex]);
            }

            Assert.Equal(expectedBoard.Stores.Count, _boardBl.Board.Stores.Count);

            // Check that the expected stores matched the actual stores
            for (var storeIndex = 0; storeIndex < expectedBoard.Stores.Count; storeIndex++)
            {
                expectedBoard.Stores[storeIndex].Should().BeEquivalentTo(_boardBl.Board.Stores[storeIndex]);
            }

            Assert.Equal(expectedBoard.Pits.Count, _boardBl.Board.Pits.Count);

            // Check that the expected pits matched the actual pits
            for (var pitIndex = 0; pitIndex < expectedBoard.Pits.Count; pitIndex++)
            {
                expectedBoard.Pits[pitIndex].Should().BeEquivalentTo(_boardBl.Board.Pits[pitIndex]);
            }

            Assert.Equal(48, _boardBl.Board.Stores.Sum(store => store.Seeds) + _boardBl.Board.Pits.Sum(pit => pit.Seeds));
            Assert.Equal(expectedMustPlayerTakeTurnAgain, mustPlayerTakeTurnAgain);
            Assert.Equal(expectedIsGameOver, isGameOver);
            Assert.Equal(expectedWinningPlayerId, winningPlayerId);
        }

        /// <summary>
        /// Test a player taking a turn with a specific board setup.
        /// </summary>
        /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        /// <param name="boardSetup">The starting board setup</param>
        /// <param name="expectedBoard">The board expected that must be asserted against.</param>
        /// <param name="expectedMustPlayerTakeTurnAgain">The expected boolean if the player must take a turn again.</param>
        /// <param name="expectedIsGameOver">The expected boolean if the game is over or not.</param>
        /// <param name="expectedWinningPlayerId">The expected winning player id if the game is over.</param>
        [Theory]
        [MemberData(nameof(TakePlayerTurnWithASpecificBoardSetupData.GetData), MemberType = typeof(TakePlayerTurnWithASpecificBoardSetupData))]
        public void TakePlayerTurn_WithASpecificBoardSetup(int sequenceId, int playerId, Board boardSetup, Board expectedBoard, bool expectedMustPlayerTakeTurnAgain, bool expectedIsGameOver, int? expectedWinningPlayerId)
        {
            // Arrange
            _boardBl = new BoardBl(boardSetup);

            // Act
            var mustPlayerTakeTurnAgain = _boardBl.TakePlayerTurn(sequenceId, playerId, out var isGameOver, out var winningPlayerId);

            // Assert
            Assert.Equal(expectedBoard.Players.Count, _boardBl.Board.Players.Count);

            // Check that the expected players matched the actual players
            for (var playerIndex = 0; playerIndex < expectedBoard.Players.Count; playerIndex++)
            {
                expectedBoard.Players[playerIndex].Should().BeEquivalentTo(_boardBl.Board.Players[playerIndex]);
            }

            Assert.Equal(expectedBoard.Stores.Count, _boardBl.Board.Stores.Count);

            // Check that the expected stores matched the actual stores
            for (var storeIndex = 0; storeIndex < expectedBoard.Stores.Count; storeIndex++)
            {
                expectedBoard.Stores[storeIndex].Should().BeEquivalentTo(_boardBl.Board.Stores[storeIndex]);
            }

            Assert.Equal(expectedBoard.Pits.Count, _boardBl.Board.Pits.Count);

            // Check that the expected pits matched the actual pits
            for (var pitIndex = 0; pitIndex < expectedBoard.Pits.Count; pitIndex++)
            {
                expectedBoard.Pits[pitIndex].Should().BeEquivalentTo(_boardBl.Board.Pits[pitIndex]);
            }

            Assert.Equal(48, _boardBl.Board.Stores.Sum(store => store.Seeds) + _boardBl.Board.Pits.Sum(pit => pit.Seeds));
            Assert.Equal(expectedMustPlayerTakeTurnAgain, mustPlayerTakeTurnAgain);
            Assert.Equal(expectedIsGameOver, isGameOver);
            Assert.Equal(expectedWinningPlayerId, winningPlayerId);
        }

        /// <summary>
        /// Test that when a player takes a turn and an invalid pit is selected an error is thrown.
        /// </summary>
        [Fact]
        public void TakePlayerTurn_Error_InvalidPitSelected()
        {
            // Act
            void Action() => _boardBl.TakePlayerTurn(0, 1, out _, out _);

            // Assert
            var exception = Assert.Throws<Exception>(Action);
            Assert.Equal("The selected player is not allowed to sow from this pit.", exception.Message);
        }

        /// <summary>
        /// Test that when a player takes a turn and the pit has no seeds an error is thrown.
        /// </summary>
        [Fact]
        public void TakePlayerTurn_Error_PitHasNoSeed()
        {
            // Arrange
            _boardBl.TakePlayerTurn(0, 0, out _, out _);

            // Act
            void Action() => _boardBl.TakePlayerTurn(0, 0, out _, out _);

            // Assert
            var exception = Assert.Throws<Exception>(Action);
            Assert.Equal("The selected pit has no seeds.", exception.Message);
        }
    }
}