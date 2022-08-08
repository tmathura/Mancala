using Mancala.Domain.Enums;
using Mancala.Domain.Models;

namespace Mancala.Core.UnitTests.MemberData
{
    public class PlayWithASpecificBoardSetupData
    {
        public static IEnumerable<object?[]> GetData()
        {
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitEleven,
                PlayerId.PlayerTwo,
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 19), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 19) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 10, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player One", true),
                        new(PlayerId.PlayerTwo, "Player Two", false)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 19),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 22)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                false,
                PlayerId.PlayerOne,
                false,
                null
            };
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitNine,
                PlayerId.PlayerTwo,
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 20), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 12) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 16, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player One", false),
                        new(PlayerId.PlayerTwo, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 20),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 14)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 2, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 2, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                true,
                PlayerId.PlayerTwo,
                false,
                null
            };
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitFive,
                PlayerId.PlayerOne,
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", true), new(PlayerId.PlayerTwo, "Player Two", false) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 19), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 19) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 10, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player One", false),
                        new(PlayerId.PlayerTwo, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 22),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 19)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                false,
                PlayerId.PlayerTwo,
                false,
                null
            };
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitThree,
                PlayerId.PlayerOne,
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", true), new(PlayerId.PlayerTwo, "Player Two", false) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 0), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 0) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 48, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player One", false),
                        new(PlayerId.PlayerTwo, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 4),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 0)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 3, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 3, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 3, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 3, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                false,
                PlayerId.PlayerTwo,
                false,
                null
            };
            yield return new object[]
            {
                (int)PlayerPitSequenceId.PitEight,
                PlayerId.PlayerTwo,
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 20), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 20) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 7, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player One", true),
                        new(PlayerId.PlayerTwo, "Player Two", false)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 20),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 28)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                false,
                PlayerId.PlayerOne,
                true,
                PlayerId.PlayerTwo
            };
            yield return new object[]
            {
                (int)PlayerPitSequenceId.PitFive,
                PlayerId.PlayerOne,
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", true), new(PlayerId.PlayerTwo, "Player Two", false) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 20), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 3) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 8, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 2, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player One", true),
                        new(PlayerId.PlayerTwo, "Player Two", false)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 21),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 27)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                true,
                PlayerId.PlayerOne,
                true,
                PlayerId.PlayerTwo
            };
            yield return new object[]
            {
                (int)PlayerPitSequenceId.PitEleven,
                PlayerId.PlayerTwo,
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 3), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 20) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 8, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 2, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player One", false),
                        new(PlayerId.PlayerTwo, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 27),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 21)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                true,
                PlayerId.PlayerTwo,
                true,
                PlayerId.PlayerOne
            };
            yield return new object[]
            {
                (int)PlayerPitSequenceId.PitEleven,
                PlayerId.PlayerTwo,
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", false), new(PlayerId.PlayerTwo, "Player Two", true) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 12), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 24) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 2, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player One", false),
                        new(PlayerId.PlayerTwo, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 23),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 25)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                true,
                PlayerId.PlayerTwo,
                true,
                PlayerId.PlayerTwo
            };

            // Game is over but it is a draw
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitFive,
                PlayerId.PlayerOne,
                new Board(
                    new List<Player> { new(PlayerId.PlayerOne, "Player One", true), new(PlayerId.PlayerTwo, "Player Two", false) },
                    new List<Store> { new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 23), new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 23) },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 1, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 1, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player One", true),
                        new(PlayerId.PlayerTwo, "Player Two", false)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 24),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 24)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                true,
                PlayerId.PlayerOne,
                true,
                null
            };
        }
    }
}
