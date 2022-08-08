using FluentAssertions;
using Mancala.Core.Implementations;
using Mancala.Core.UnitTests.MemberData;
using Mancala.Domain.Enums;
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
            Assert.Equal(Enum.GetNames(typeof(PlayerStoreId)).Length, _boardBl.Board.Stores.Count);

            Assert.NotNull(_boardBl.Board.Pits);
            Assert.Equal(Enum.GetNames(typeof(PlayerPitSequenceId)).Length, _boardBl.Board.Pits.Count);

            for (var playerId = 0; playerId < playerNames.Count; playerId++)
            {
                var currentPlayer = _boardBl.Board.Players[playerId];
                Assert.Equal((PlayerId)playerId, currentPlayer.Id);
                Assert.Equal(playerNames[playerId], currentPlayer.PlayerName);

                var currentStore = _boardBl.Board.Stores[playerId];
                Assert.Equal((PlayerStoreId)playerId, currentStore.Id);
                Assert.Equal((PlayerId)playerId, currentStore.PlayerId);
                Assert.Equal((int)PitSeedsCount.Zero, currentStore.Seeds);

                var currentPlayerPits = _boardBl.Board.Pits.Where(pit => pit.PlayerId == (PlayerId)playerId).ToList();
                Assert.Equal((int)PitsCount.Max, currentPlayerPits.Count);
                
                for (var pitId = 0; pitId < (int)PitsCount.Max; pitId++)
                {
                    Assert.Equal((int)PitSeedsCount.Default, currentPlayerPits[pitId].Seeds);

                    // Check that the pit id is correct for the specific player
                    Assert.Equal((PlayerPitId)pitId, currentPlayerPits[pitId].Id);

                    // Check that the sequence is correct within the list of pits
                    var pitSequence = currentPlayerPits[pitId].SequenceId;
                    Assert.Equal(_boardBl.Board.Pits.FindIndex(pit => pit.SequenceId == pitSequence), pitSequence);
                }
            }

            var totalSeedInGame = (int)PitsCount.Max * (int)PitSeedsCount.Default * Enum.GetNames(typeof(PlayerStoreId)).Length;
            Assert.Equal(totalSeedInGame, _boardBl.Board.Stores.Sum(store => store.Seeds) + _boardBl.Board.Pits.Sum(pit => pit.Seeds));
        }

        /// <summary>
        /// Test a player playing a turn.
        /// </summary>
        /// <param name="sequenceId">The pit sequence id to pick all the seeds from.</param>
        /// <param name="playerId">The player id of the player who is sowing.</param>
        /// <param name="expectedBoard">The board expected that must be asserted against.</param>
        /// <param name="expectedMustPlayerTakeTurnAgain">The expected boolean if the player must take a turn again.</param>
        /// <param name="expectedNextPlayerId">The expected id of the player that must play.</param>
        /// <param name="expectedIsGameOver">The expected boolean if the game is over or not.</param>
        /// <param name="expectedWinningPlayerId">The expected winning player id if the game is over.</param>
        [Theory]
        [MemberData(nameof(PlayData.GetData), MemberType = typeof(PlayData))]
        public void Play(int sequenceId, PlayerId playerId, Board expectedBoard, bool expectedMustPlayerTakeTurnAgain, PlayerId expectedNextPlayerId, bool expectedIsGameOver, PlayerId? expectedWinningPlayerId)
        {
            // Act
            var mustPlayerTakeTurnAgain = _boardBl.Play(sequenceId, playerId, false, out var nextPlayerId, out var isGameOver, out var winningPlayerId);

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

            var totalSeedInGame = (int)PitsCount.Max * (int)PitSeedsCount.Default * Enum.GetNames(typeof(PlayerStoreId)).Length;
            Assert.Equal(totalSeedInGame, _boardBl.Board.Stores.Sum(store => store.Seeds) + _boardBl.Board.Pits.Sum(pit => pit.Seeds));

            Assert.Equal(expectedMustPlayerTakeTurnAgain, mustPlayerTakeTurnAgain);
            Assert.Equal(expectedNextPlayerId, nextPlayerId);
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
        /// <param name="expectedNextPlayerId">The expected id of the player that must play.</param>
        /// <param name="expectedIsGameOver">The expected boolean if the game is over or not.</param>
        /// <param name="expectedWinningPlayerId">The expected winning player id if the game is over.</param>
        [Theory]
        [MemberData(nameof(PlayWithASpecificBoardSetupData.GetData), MemberType = typeof(PlayWithASpecificBoardSetupData))]
        public void Play_WithASpecificBoardSetup(int sequenceId, PlayerId playerId, Board boardSetup, Board expectedBoard, bool expectedMustPlayerTakeTurnAgain, PlayerId expectedNextPlayerId, bool expectedIsGameOver, PlayerId? expectedWinningPlayerId)
        {
            // Arrange
            _boardBl = new BoardBl(boardSetup);

            // Act
            var mustPlayerTakeTurnAgain = _boardBl.Play(sequenceId, playerId, false, out var nextPlayerId, out var isGameOver, out var winningPlayerId);

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

            var totalSeedInGame = (int)PitsCount.Max * (int)PitSeedsCount.Default * Enum.GetNames(typeof(PlayerStoreId)).Length;
            Assert.Equal(totalSeedInGame, _boardBl.Board.Stores.Sum(store => store.Seeds) + _boardBl.Board.Pits.Sum(pit => pit.Seeds));

            Assert.Equal(expectedMustPlayerTakeTurnAgain, mustPlayerTakeTurnAgain);
            Assert.Equal(expectedNextPlayerId, nextPlayerId);
            Assert.Equal(expectedIsGameOver, isGameOver);
            Assert.Equal(expectedWinningPlayerId, winningPlayerId);
        }

        /// <summary>
        /// Test that when a player takes a turn and an invalid pit is selected an error is thrown.
        /// </summary>
        [Fact]
        public void Play_Error_InvalidPitSelected()
        {
            // Act
            void Action() => _boardBl.Play((int)PlayerPitSequenceId.PitZero, PlayerId.PlayerTwo, false, out _, out _, out _);

            // Assert
            var exception = Assert.Throws<Exception>(Action);
            Assert.Equal("The selected player is not allowed to sow from this pit.", exception.Message);
        }

        /// <summary>
        /// Test that when a player takes a turn and the pit has no seeds an error is thrown.
        /// </summary>
        [Fact]
        public void Play_Error_PitHasNoSeed()
        {
            // Arrange
            _boardBl.Play(0, 0, false, out _, out _, out _);

            // Act
            void Action() => _boardBl.Play((int)PlayerPitSequenceId.PitZero, (int)PlayerId.PlayerOne, false, out _, out _, out _);

            // Assert
            var exception = Assert.Throws<Exception>(Action);
            Assert.Equal("The selected pit has no seeds.", exception.Message);
        }

        /// <summary>
        /// Test the ai selects the best pit with a specific board setup.
        /// </summary>
        /// <param name="boardSetup">The starting board setup</param>
        /// <param name="expectedPitSequenceId">The expected best pit that the ai should choose.</param>
        [Theory]
        [MemberData(nameof(GetBestAiMoveWithASpecificBoardSetupData.GetData), MemberType = typeof(GetBestAiMoveWithASpecificBoardSetupData))]
        public void GetBestAiMove_WithASpecificBoardSetup(Board boardSetup, int expectedPitSequenceId)
        {
            // Arrange
            _boardBl = new BoardBl(boardSetup);

            // Act
            var pitSequenceId = _boardBl.GetBestAiMove();

            // Assert
            Assert.Equal(expectedPitSequenceId, pitSequenceId);
        }
    }
}