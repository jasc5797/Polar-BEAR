﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PolarBearGUI_WPF.ViewModels.Commands
{
    class PathEditorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action action;

        public PathEditorCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action.Invoke();
        }
    }
}