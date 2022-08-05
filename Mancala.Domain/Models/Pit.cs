namespace Mancala.Domain.Models
{
    public class Pit
    {
        public Pit(int id, int playerId, int seeds, int sequenceId)
        {
            Id = id;
            PlayerId = playerId;
            Seeds = seeds;
            SequenceId = sequenceId;
        }

        public int Id { get; }
        public int PlayerId { get; }
        public int Seeds { get; set; }
        public int SequenceId { get; }
    }
}