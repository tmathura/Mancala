namespace Mancala.Domain.Models
{
    public class Player
    {
        public Player(int id, string playerName)
        {
            Id = id;
            PlayerName = playerName;
        }

        public int Id { get; }
        public string PlayerName { get; }
    }
}