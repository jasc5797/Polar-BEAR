using PolarBearGUI_WPF.Utilities;

namespace PolarBearGUI_WPF.Dialogs.Service
{
    public abstract class DialogViewModelBase<T> : NotifyPropertyChangedObject
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public T DialogResult { get; set; }

        public DialogViewModelBase() : this (string.Empty, string.Empty)
        {

        }

        public DialogViewModelBase(string title) : this (title, string.Empty)
        {

        }

        public DialogViewModelBase(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public void CloseDialogWithResult(IDialogWindow dialogWindow, T result)
        {
            DialogResult = result;
            if (dialogWindow != null)
            {
                dialogWindow.DialogResult = true;
            }
        }
    }
}
