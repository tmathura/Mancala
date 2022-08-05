namespace Mancala.Domain.Models
{
    public class Pit
    {
        public Pit(int id, int playerId, int seeds, int sequence)
        {
            Id = id;
            PlayerId = playerId;
            Seeds = seeds;
            Sequence = sequence;
        }

        public int Id { get; }
        public int PlayerId { get; }
        public int Seeds { get; set; }
        public int Sequence { get; }
    }
}