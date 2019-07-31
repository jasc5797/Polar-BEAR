namespace PolarBearGUI_WPF.Dialogs.Service
{
    public class StepAddDialogService : IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> dialogViewModelBase)
        {
            IDialogWindow dialogWindow = new StepAddDialogWindow
            {
                DataContext = dialogViewModelBase
            };
            dialogWindow.ShowDialog();
            return dialogViewModelBase.DialogResult;
        }
    }
}
