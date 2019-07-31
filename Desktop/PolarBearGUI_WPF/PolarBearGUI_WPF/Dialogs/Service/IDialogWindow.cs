﻿namespace PolarBearGUI_WPF.Dialogs.Service
{
    public interface IDialogWindow
    {
        bool? DialogResult { get; set; }
        object DataContext { get; set; }

        bool? ShowDialog();
    }
}
