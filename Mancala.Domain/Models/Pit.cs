using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mancala.Domain.Models
{
    public class Pit : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Pit(int id, int playerId, int seeds, int sequenceId)
        {
            Id = id;
            PlayerId = playerId;
            Seeds = seeds;
            SequenceId = sequenceId;
        }

        public int Id { get; }
        public int PlayerId { get; }

        private int _seeds;
        public int Seeds
        {
            get => _seeds;
            set
            {
                _seeds = value;
                OnPropertyChanged();
            }
        }

        public int SequenceId { get; }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}