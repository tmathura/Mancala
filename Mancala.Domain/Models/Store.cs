using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mancala.Domain.Models
{
    public class Store : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Store(int id, int playerId, int seeds)
        {
            Id = id;
            PlayerId = playerId;
            Seeds = seeds;
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

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}