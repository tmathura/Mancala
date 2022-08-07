using Mancala.Domain.Models;

namespace Mancala.Core.UnitTests.MemberData
{
    public class PlayWithASpecificBoardSetupData
    {
        public static IEnumerable<object?[]> GetData()
        {
            yield return new object?[]
            {
                11,
                1,
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 19), new(1, 1, 19) },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 10, 11)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(0, "Player One", true),
                        new(1, "Player Two", false)
                    },
                    new List<Store>
                    {
                        new(0, 0, 19),
                        new(1, 1, 22)
                    },
                    new List<Pit>
                    {
                        new (0, 0, 1, 0),
                        new (1, 0, 1, 1),
                        new (2, 0, 1, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 1, 4),
                        new (5, 0, 1, 5),
                        new (0, 1, 1, 6),
                        new (1, 1, 1, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                false,
                0,
                false,
                null
            };
            yield return new object?[]
            {
                9,
                1,
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 20), new(1, 1, 12) },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 16, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(0, "Player One", false),
                        new(1, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(0, 0, 20),
                        new(1, 1, 14)
                    },
                    new List<Pit>
                    {
                        new (0, 0, 1, 0),
                        new (1, 0, 1, 1),
                        new (2, 0, 1, 2),
                        new (3, 0, 1, 3),
                        new (4, 0, 1, 4),
                        new (5, 0, 1, 5),
                        new (0, 1, 1, 6),
                        new (1, 1, 1, 7),
                        new (2, 1, 1, 8),
                        new (3, 1, 1, 9),
                        new (4, 1, 2, 10),
                        new (5, 1, 2, 11)
                    }
                ),
                true,
                1,
                false,
                null
            };
            yield return new object?[]
            {
                5,
                0,
                new Board(
                    new List<Player> { new(0, "Player One", true), new(1, "Player Two", false) },
                    new List<Store> { new(0, 0, 19), new(1, 1, 19) },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 10, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(0, "Player One", false),
                        new(1, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(0, 0, 22),
                        new(1, 1, 19)
                    },
                    new List<Pit>
                    {
                        new (0, 0, 1, 0),
                        new (1, 0, 1, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 1, 6),
                        new (1, 1, 1, 7),
                        new (2, 1, 1, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 1, 10),
                        new (5, 1, 1, 11)
                    }
                ),
                false,
                1,
                false,
                null
            };
            yield return new object?[]
            {
                3,
                0,
                new Board(
                    new List<Player> { new(0, "Player One", true), new(1, "Player Two", false) },
                    new List<Store> { new(0, 0, 0), new(1, 1, 0) },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 48, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(0, "Player One", false),
                        new(1, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(0, 0, 4),
                        new(1, 1, 0)
                    },
                    new List<Pit>
                    {
                        new (0, 0, 3, 0),
                        new (1, 0, 3, 1),
                        new (2, 0, 3, 2),
                        new (3, 0, 3, 3),
                        new (4, 0, 4, 4),
                        new (5, 0, 4, 5),
                        new (0, 1, 4, 6),
                        new (1, 1, 4, 7),
                        new (2, 1, 4, 8),
                        new (3, 1, 4, 9),
                        new (4, 1, 4, 10),
                        new (5, 1, 4, 11)
                    }
                ),
                false,
                1,
                false,
                null
            };
            yield return new object[]
            {
                8,
                1,
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 20), new(1, 1, 20) },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 7, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 1, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(0, "Player One", true),
                        new(1, "Player Two", false)
                    },
                    new List<Store>
                    {
                        new(0, 0, 20),
                        new(1, 1, 28)
                    },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                false,
                0,
                true,
                1
            };
            yield return new object[]
            {
                5,
                0,
                new Board(
                    new List<Player> { new(0, "Player One", true), new(1, "Player Two", false) },
                    new List<Store> { new(0, 0, 20), new(1, 1, 3) },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 1, 5),
                        new (0, 1, 4, 6),
                        new (1, 1, 5, 7),
                        new (2, 1, 8, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 5, 10),
                        new (5, 1, 2, 11)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(0, "Player One", true),
                        new(1, "Player Two", false)
                    },
                    new List<Store>
                    {
                        new(0, 0, 21),
                        new(1, 1, 27)
                    },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                true,
                0,
                true,
                1
            };
            yield return new object[]
            {
                11,
                1,
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 3), new(1, 1, 20) },
                    new List<Pit>
                    {
                        new (0, 0, 4, 0),
                        new (1, 0, 5, 1),
                        new (2, 0, 8, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 5, 4),
                        new (5, 0, 2, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 1, 11)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(0, "Player One", false),
                        new(1, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(0, 0, 27),
                        new(1, 1, 21)
                    },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                true,
                1,
                true,
                0
            };
            yield return new object[]
            {
                11,
                1,
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 12), new(1, 1, 24) },
                    new List<Pit>
                    {
                        new (0, 0, 4, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 5, 4),
                        new (5, 0, 2, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 1, 11)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(0, "Player One", false),
                        new(1, "Player Two", true)
                    },
                    new List<Store>
                    {
                        new(0, 0, 23),
                        new(1, 1, 25)
                    },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                true,
                1,
                true,
                1
            };

            // Game is over but it is a draw
            yield return new object?[]
            {
                5,
                0,
                new Board(
                    new List<Player> { new(0, "Player One", true), new(1, "Player Two", false) },
                    new List<Store> { new(0, 0, 23), new(1, 1, 23) },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 1, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 1, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                new Board(
                    new List<Player>
                    {
                        new(0, "Player One", true),
                        new(1, "Player Two", false)
                    },
                    new List<Store>
                    {
                        new(0, 0, 24),
                        new(1, 1, 24)
                    },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 0, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ),
                true,
                0,
                true,
                null
            };
        }
    }
}
