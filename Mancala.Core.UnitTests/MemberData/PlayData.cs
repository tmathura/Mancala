using Mancala.Domain.Enums;
using Mancala.Domain.Models;

namespace Mancala.Core.UnitTests.MemberData
{
    public class PlayData
    {
        public static IEnumerable<object?[]> GetData()
        {
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitOne,
                PlayerId.PlayerOne,
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player 1", false),
                        new(PlayerId.PlayerTwo, "Player 2", true)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 0),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 0)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitFive),
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
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitTwo,
                PlayerId.PlayerOne,
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player 1", true),
                        new(PlayerId.PlayerTwo, "Player 2", false)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 1),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 0)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                true,
                PlayerId.PlayerOne,
                false,
                null
            };
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitThree,
                PlayerId.PlayerOne,
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player 1", false),
                        new(PlayerId.PlayerTwo, "Player 2", true)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 1),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 0)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 0, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 5, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitSix),
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
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitSix,
                PlayerId.PlayerTwo,
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player 1", true),
                        new(PlayerId.PlayerTwo, "Player 2", false)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 0),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 0)
                    },
                    new List<Pit>
                    {
                        new (PlayerPitId.PitZero, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitZero),
                        new (PlayerPitId.PitOne, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitOne),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitTwo),
                        new (PlayerPitId.PitThree, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitThree),
                        new (PlayerPitId.PitFour, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitFour),
                        new (PlayerPitId.PitFive, PlayerId.PlayerOne, 4, (int)PlayerPitSequenceId.PitFive),
                        new (PlayerPitId.PitZero, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitSix),
                        new (PlayerPitId.PitOne, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitSeven),
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 4, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                false,
                PlayerId.PlayerOne,
                false,
                null
            };
            yield return new object?[]
            {
                (int)PlayerPitSequenceId.PitEight,
                PlayerId.PlayerTwo,
                new Board(
                    new List<Player>
                    {
                        new(PlayerId.PlayerOne, "Player 1", false),
                        new(PlayerId.PlayerTwo, "Player 2", true)
                    },
                    new List<Store>
                    {
                        new(PlayerStoreId.PlayerOne, PlayerId.PlayerOne, 0),
                        new(PlayerStoreId.PlayerTwo, PlayerId.PlayerTwo, 1)
                    },
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
                        new (PlayerPitId.PitTwo, PlayerId.PlayerTwo, 0, (int)PlayerPitSequenceId.PitEight),
                        new (PlayerPitId.PitThree, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitNine),
                        new (PlayerPitId.PitFour, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitTen),
                        new (PlayerPitId.PitFive, PlayerId.PlayerTwo, 5, (int)PlayerPitSequenceId.PitEleven)
                    }
                ),
                true,
                PlayerId.PlayerTwo,
                false,
                null
            };
        }
    }
}
