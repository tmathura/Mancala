namespace Mancala.Domain.Models
{
    public class Board
    {
        public Board(List<Player> players, List<Store> stores, List<Pit> pits)
        {
            Id = new Guid();
            Players = players;
            Stores = stores;
            Pits = pits;
        }

        public Guid Id { get; set; }
        public List<Player> Players { get; }
        public List<Store> Stores { get; }
        public List<Pit> Pits { get; }
    }
}