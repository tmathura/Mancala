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
        [Theory]
        [MemberData(nameof(TakePlayerTurnData.GetData), MemberType = typeof(TakePlayerTurnData))]
        public void TakePlayerTurn(int sequenceId, int playerId, List<Store> expectedStores, List<Pit> expectedPits, bool expectedMustPlayerTakeTurnAgain)
        {
            // Act
            var mustPlayerTakeTurnAgain = _boardBl.TakePlayerTurn(sequenceId, playerId);
            
            // Assert
            Assert.Equal(expectedStores.Count, _boardBl.Board.Stores.Count);

            // Check that the expected stores matched the actual stores
            for (var storeIndex = 0; storeIndex < expectedStores.Count; storeIndex++)
            {
                expectedStores[storeIndex].Should().BeEquivalentTo(_boardBl.Board.Stores[storeIndex]);
            }
            
            Assert.Equal(expectedPits.Count, _boardBl.Board.Pits.Count);

            // Check that the expected pits matched the actual pits
            for (var pitIndex = 0; pitIndex < expectedPits.Count; pitIndex++)
            {
                expectedPits[pitIndex].Should().BeEquivalentTo(_boardBl.Board.Pits[pitIndex]);
            }

            Assert.Equal(48, _boardBl.Board.Stores.Sum(store => store.Seeds) + _boardBl.Board.Pits.Sum(pit => pit.Seeds));
            Assert.Equal(expectedMustPlayerTakeTurnAgain, mustPlayerTakeTurnAgain);
        }

        /// <summary>
        /// Test a player taking a turn with a specific board setup.
        /// </summary>
        [Theory]
        [MemberData(nameof(TakePlayerTurn_WithASpecificBoardSetupData.GetData), MemberType = typeof(TakePlayerTurn_WithASpecificBoardSetupData))]
        public void TakePlayerTurn_WithASpecificBoardSetup(int sequenceId, int playerId, Board boardSetup, List<Store> expectedStores, List<Pit> expectedPits, bool expectedMustPlayerTakeTurnAgain)
        {
            // Arrange
            _boardBl = new BoardBl(boardSetup);

            // Act
            var mustPlayerTakeTurnAgain = _boardBl.TakePlayerTurn(sequenceId, playerId);

            // Assert
            Assert.Equal(expectedStores.Count, _boardBl.Board.Stores.Count);

            // Check that the expected stores matched the actual stores
            for (var storeIndex = 0; storeIndex < expectedStores.Count; storeIndex++)
            {
                expectedStores[storeIndex].Should().BeEquivalentTo(_boardBl.Board.Stores[storeIndex]);
            }

            Assert.Equal(expectedPits.Count, _boardBl.Board.Pits.Count);

            // Check that the expected pits matched the actual pits
            for (var pitIndex = 0; pitIndex < expectedPits.Count; pitIndex++)
            {
                expectedPits[pitIndex].Should().BeEquivalentTo(_boardBl.Board.Pits[pitIndex]);
            }
            
            Assert.Equal(48, _boardBl.Board.Stores.Sum(store => store.Seeds) + _boardBl.Board.Pits.Sum(pit => pit.Seeds));
            Assert.Equal(expectedMustPlayerTakeTurnAgain, mustPlayerTakeTurnAgain);
        }

        /// <summary>
        /// Test that when a player takes a turn and an invalid pit is selected an error is thrown.
        /// </summary>
        [Fact]
        public void TakePlayerTurn_Error_InvalidPitSelected()
        {
            // Act
            void Action() => _boardBl.TakePlayerTurn(0, 1);

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
            _boardBl.TakePlayerTurn(0, 0);

            // Act
            void Action() => _boardBl.TakePlayerTurn(0, 0);

            // Assert
            var exception = Assert.Throws<Exception>(Action);
            Assert.Equal("The selected pit has no seed.", exception.Message);
        }
    }
}