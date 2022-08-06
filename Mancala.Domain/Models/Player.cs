using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mancala.Domain.Models
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Player(int id, string playerName)
        {
            Id = id;
            PlayerName = playerName;
        }

        public int Id { get; }

        private string _playerName;
        public string PlayerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}