namespace Mancala.Domain.Models
{
    public class Store
    {
        public Store(int id, int playerId, int seeds)
        {
            Id = id;
            PlayerId = playerId;
            Seeds = seeds;
        }

        public int Id { get; }
        public int PlayerId { get; }
        public int Seeds { get; set; }
    }
}