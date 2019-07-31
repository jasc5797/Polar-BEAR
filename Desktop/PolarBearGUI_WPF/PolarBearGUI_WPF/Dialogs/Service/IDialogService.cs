namespace PolarBearGUI_WPF.Dialogs.Service
{
    public interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> dialogViewModelBase);
    }
}
