using Mancala.Domain.Models;

namespace Mancala.Core.UnitTests.MemberData
{
    public class TakePlayerTurnData
    {
        public static IEnumerable<object?[]> GetData()
        {
            yield return new object[]
            {
                1,
                0,
                new List<Store>
                {
                    new(0, 0, 0),
                    new(1, 1, 0)
                },
                new List<Pit>
                {
                    new (0, 0, 4, 0),
                    new (1, 0, 0, 1),
                    new (2, 0, 5, 2),
                    new (3, 0, 5, 3),
                    new (4, 0, 5, 4),
                    new (5, 0, 5, 5),
                    new (0, 1, 4, 6),
                    new (1, 1, 4, 7),
                    new (2, 1, 4, 8),
                    new (3, 1, 4, 9),
                    new (4, 1, 4, 10),
                    new (5, 1, 4, 11)
                },
                false
            };
            yield return new object[]
            {
                2,
                0,
                new List<Store>
                {
                    new(0, 0, 1),
                    new(1, 1, 0)
                },
                new List<Pit>
                {
                    new (0, 0, 4, 0),
                    new (1, 0, 4, 1),
                    new (2, 0, 0, 2),
                    new (3, 0, 5, 3),
                    new (4, 0, 5, 4),
                    new (5, 0, 5, 5),
                    new (0, 1, 4, 6),
                    new (1, 1, 4, 7),
                    new (2, 1, 4, 8),
                    new (3, 1, 4, 9),
                    new (4, 1, 4, 10),
                    new (5, 1, 4, 11)
                },
                true
            };
            yield return new object[]
            {
                3,
                0,
                new List<Store>
                {
                    new(0, 0, 1),
                    new(1, 1, 0)
                },
                new List<Pit>
                {
                    new (0, 0, 4, 0),
                    new (1, 0, 4, 1),
                    new (2, 0, 4, 2),
                    new (3, 0, 0, 3),
                    new (4, 0, 5, 4),
                    new (5, 0, 5, 5),
                    new (0, 1, 5, 6),
                    new (1, 1, 4, 7),
                    new (2, 1, 4, 8),
                    new (3, 1, 4, 9),
                    new (4, 1, 4, 10),
                    new (5, 1, 4, 11)
                },
                false
            };
            yield return new object[]
            {
                6,
                1,
                new List<Store>
                {
                    new(0, 0, 0),
                    new(1, 1, 0)
                },
                new List<Pit>
                {
                    new (0, 0, 4, 0),
                    new (1, 0, 4, 1),
                    new (2, 0, 4, 2),
                    new (3, 0, 4, 3),
                    new (4, 0, 4, 4),
                    new (5, 0, 4, 5),
                    new (0, 1, 0, 6),
                    new (1, 1, 5, 7),
                    new (2, 1, 5, 8),
                    new (3, 1, 5, 9),
                    new (4, 1, 5, 10),
                    new (5, 1, 4, 11)
                },
                false
            };
            yield return new object[]
            {
                8,
                1,
                new List<Store>
                {
                    new(0, 0, 0),
                    new(1, 1, 1)
                },
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
                    new (2, 1, 0, 8),
                    new (3, 1, 5, 9),
                    new (4, 1, 5, 10),
                    new (5, 1, 5, 11)
                },
                true
            };
        }
    }
}
