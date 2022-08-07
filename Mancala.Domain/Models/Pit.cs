﻿using System.ComponentModel;
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
                Enabled = _seeds > 0;
                OnPropertyChanged();
            }
        }

        public int SequenceId { get; }

        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}