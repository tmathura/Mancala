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
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 0), new(1, 1, 0) },
                    new List<Pit>
                    {
                        new (0, 0, 4, 0),
                        new (1, 0, 4, 1),
                        new (2, 0, 4, 2),
                        new (3, 0, 4, 3),
                        new (4, 0, 4, 4),
                        new (5, 0, 4, 5),
                        new (0, 1, 4, 6),
                        new (1, 1, 4, 7),
                        new (2, 1, 4, 8),
                        new (3, 1, 4, 9),
                        new (4, 1, 4, 10),
                        new (5, 1, 4, 11)
                    }
                ), // Board setup
                8 // The sequence id of the best pit to select
            };

            // All the ai pits are able to have the last seed stowed in the store but the one that should be selected is the closed pit to the store and that is pit with sequence id 8
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 26), new(1, 1, 0) },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 1, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 6, 6),
                        new (1, 1, 5, 7),
                        new (2, 1, 4, 8),
                        new (3, 1, 3, 9),
                        new (4, 1, 2, 10),
                        new (5, 1, 1, 11)
                    }
                ), // Board setup
                11 // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store then the pit that must be selected is a pit that can cause an opponent pit to be captured and that is pit with sequence id 9
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 12), new(1, 1, 25) },
                    new List<Pit>
                    {
                        new (0, 0, 0, 0),
                        new (1, 0, 4, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 1, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 3, 5),
                        new (0, 1, 3, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 1, 9),
                        new (4, 1, 0, 10),
                        new (5, 1, 0, 11)
                    }
                ), // Board setup
                9 // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store and multiple pits can allow capture then the pit that must be selected is a pit that can cause an opponent pit to be captured (captures the most) and that is pit with sequence id 10
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 11), new(1, 1, 20) },
                    new List<Pit>
                    {
                        new (0, 0, 1, 0),
                        new (1, 0, 4, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 1, 3),
                        new (4, 0, 3, 4),
                        new (5, 0, 3, 5),
                        new (0, 1, 2, 6),
                        new (1, 1, 1, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 1, 9),
                        new (4, 1, 1, 10),
                        new (5, 1, 0, 11)
                    }
                ), // Board setup
                10 // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store and multiple pits can allow capture then the pit that must be selected is a pit that can cause an opponent pit to be captured (captures the most) and that is pit with sequence id 6
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 11), new(1, 1, 20) },
                    new List<Pit>
                    {
                        new (0, 0, 7, 0),
                        new (1, 0, 0, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 0, 3),
                        new (4, 0, 8, 4),
                        new (5, 0, 0, 5),
                        new (0, 1, 1, 6),
                        new (1, 1, 0, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 0, 9),
                        new (4, 1, 1, 10),
                        new (5, 1, 0, 11)
                    }
                ), // Board setup
                6 // The sequence id of the best pit to select
            };

            // If the seed can be sowed in the store and multiple pits can allow capture then the pit that must be selected is a pit closet to the store that can sowed and that is pit with sequence id 9
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 11), new(1, 1, 18) },
                    new List<Pit>
                    {
                        new (0, 0, 1, 0),
                        new (1, 0, 4, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 1, 3),
                        new (4, 0, 3, 4),
                        new (5, 0, 3, 5),
                        new (0, 1, 2, 6),
                        new (1, 1, 1, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 3, 9),
                        new (4, 1, 1, 10),
                        new (5, 1, 0, 11)
                    }
                ), // Board setup
                9 // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store and no pits can be captured then choose the pit with the highest seed count that could be capture by the opponent and that is pit with sequence id 9
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 4), new(1, 1, 6) },
                    new List<Pit>
                    {
                        new (0, 0, 4, 0),
                        new (1, 0, 1, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 4, 3),
                        new (4, 0, 4, 4),
                        new (5, 0, 4, 5),
                        new (0, 1, 4, 6),
                        new (1, 1, 4, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 5, 9),
                        new (4, 1, 4, 10),
                        new (5, 1, 4, 11)
                    }
                ), // Board setup
                9 // The sequence id of the best pit to select
            };

            // If the seed cannot be sowed in the store and no pits can be captured then choose the pit with the highest seed count that could be capture by the opponent and that is pit with sequence id 7
            yield return new object?[]
            {
                new Board(
                    new List<Player> { new(0, "Player One", false), new(1, "Player Two", true) },
                    new List<Store> { new(0, 0, 4), new(1, 1, 8) },
                    new List<Pit>
                    {
                        new (0, 0, 4, 0),
                        new (1, 0, 1, 1),
                        new (2, 0, 0, 2),
                        new (3, 0, 1, 3),
                        new (4, 0, 0, 4),
                        new (5, 0, 4, 5),
                        new (0, 1, 4, 6),
                        new (1, 1, 9, 7),
                        new (2, 1, 0, 8),
                        new (3, 1, 5, 9),
                        new (4, 1, 4, 10),
                        new (5, 1, 4, 11)
                    }
                ), // Board setup
                7 // The sequence id of the best pit to select
            };
        }
    }
}
