using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolarBearGUI_WPF.Dialogs;

namespace PolarBearGUI_WPF.Dialogs.Service
{
    public class StepAddDialogService : IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> dialogViewModelBase)
        {
            IDialogWindow dialogWindow = new StepAddDialogWindow();
            dialogWindow.DataContext = dialogViewModelBase;
            dialogWindow.ShowDialog();
            return dialogViewModelBase.DialogResult;
        }
    }
}
