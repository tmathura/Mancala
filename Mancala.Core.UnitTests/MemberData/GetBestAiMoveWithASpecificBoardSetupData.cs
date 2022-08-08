using Mancala.Domain.Enums;
using Mancala.Domain.Models;

namespace Mancala.Core.UnitTests.MemberData
{
    public class GetBestAiMoveWithASpecificBoardSetupData
    {
        public static IEnumerable<object?[]> GetData()
        {
            // With the default board setup the pit that the ai should select is pit with sequence id 8
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 0), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 0) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEleven)
                    }
                ), // Board setup
                (int)PlayerPitSequenceId.PitEight // The sequence id of the best pit to select
            };

            // All the ai pits are able to have the last seed stowed in the store but the one that should be selected is the closed pit to the store and that is pit with sequence id 8
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 26), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 0) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 6, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 3, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 2, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitEleven)
                    }
                ), // Board setup
                (int)PlayerPitSequenceId.PitEleven // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store then the pit that must be selected is a pit that can cause an opponent pit to be captured and that is pit with sequence id 9
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 12), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 25) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 3, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 3, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ), // Board setup
                (int)PlayerPitSequenceId.PitNine // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store and multiple pits can allow capture then the pit that must be selected is a pit that can cause an opponent pit to be captured (captures the most) and that is pit with sequence id 10
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 11), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 20) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 3, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 3, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 2, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ), // Board setup
                (int)PlayerPitSequenceId.PitTen // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store and multiple pits can allow capture then the pit that must be selected is a pit that can cause an opponent pit to be captured (captures the most) and that is pit with sequence id 6
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 11), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 20) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 7, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 8, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ), // Board setup
                (int)PlayerPitSequenceId.PitSix // The sequence id of the best pit to select
            };

            // If the seed can be sowed in the store and multiple pits can allow capture then the pit that must be selected is a pit closet to the store that can sowed and that is pit with sequence id 9
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 11), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 18) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 3, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 3, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 2, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 3, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ), // Board setup
                (int)PlayerPitSequenceId.PitNine // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store and no pits can be captured then choose the pit with the highest seed count that could be capture by the opponent and that is pit with sequence id 9
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 4), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 6) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEleven)
                    }
                ), // Board setup
                (int)PlayerPitSequenceId.PitNine // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store and no pits can be captured then choose the pit with the highest seed count that could be capture by the opponent and that is pit with sequence id 7
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 4), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 8) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 9, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEleven)
                    }
                ), // Board setup
                (int)PlayerPitSequenceId.PitSeven // The sequence id of the best pit to select
            };
        }
    }
}
