using Mancala.Domain.Models;
using System;
using System.Windows.Input;

namespace Mancala
{
    public class TakePlayerTurnCommand : ICommand
    {
        private readonly Action<Pit> _execute;

        public TakePlayerTurnCommand(Action<Pit> execute)
        {
            _execute = execute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object? parameter)
        {
            _execute((Pit)parameter!);
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }
    }

}
