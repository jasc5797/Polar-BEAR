using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.Dialogs.Service
{
    public class StepEditorDialogService : IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> dialogViewModelBase)
        {
            IDialogWindow dialogWindow = new StepEditorDialogWindow();
            dialogWindow.DataContext = dialogViewModelBase;
            dialogWindow.ShowDialog();
            return dialogViewModelBase.DialogResult;
        }
    }
}
