using Mancala.Core.Implementations;

namespace Mancala.Core.UnitTests.Implementations
{
    public class BoardBlTest
    {
        private readonly BoardBl _boardBl;

        public BoardBlTest()
        {
            _boardBl = new BoardBl();
        }

        /// <summary>
        /// Test that the board is set up correctly.
        /// </summary>
        [Fact]
        public void StartNewGame()
        {
            // Arrange
            var playerNames = new List<string> { "Player 1", "Player 2" };

            // Act
            var board = _boardBl.StartNewGame(playerNames.First(), playerNames.Last());

            // Assert
            Assert.NotNull(board);

            Assert.NotNull(board.Players);
            Assert.Equal(playerNames.Count, board.Players.Count);

            Assert.NotNull(board.Stores);
            Assert.Equal(2, board.Stores.Count);

            Assert.NotNull(board.Pits);
            Assert.Equal(12, board.Pits.Count);

            for (var playerId = 0; playerId < playerNames.Count; playerId++)
            {
                var currentPlayer = board.Players[playerId];
                Assert.Equal(playerId, currentPlayer.Id);
                Assert.Equal(playerNames[playerId], currentPlayer.PlayerName);

                var currentBoard = board.Stores[playerId];
                Assert.Equal(playerId, currentBoard.Id);
                Assert.Equal(playerId, currentBoard.PlayerId);
                Assert.Equal(0, currentBoard.Seeds);

                var currentPlayerPits = board.Pits.Where(pit => pit.PlayerId == playerId).ToList();
                Assert.Equal(6, currentPlayerPits.Count);

                const int totalPitsPerPlayer = 6;

                for (var pitId = 0; pitId < totalPitsPerPlayer; pitId++)
                {
                    Assert.Equal(4, currentPlayerPits[pitId].Seeds);

                    // Check that the pit id is correct for the specific player
                    Assert.Equal(pitId, currentPlayerPits[pitId].Id);

                    // Check that the sequence is correct within the list of pits
                    var pitSequence = currentPlayerPits[pitId].Sequence;
                    Assert.Equal(board.Pits.FindIndex(pit => pit.Sequence == pitSequence), pitSequence);
                }
            }
        }
    }
}