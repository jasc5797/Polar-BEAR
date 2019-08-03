using PolarBearGUI_WPF.Dialogs.Service;
using System.Windows;

namespace PolarBearGUI_WPF.Dialogs
{
    /// <summary>
    /// Interaction logic for StepAddDialogWindow.xaml
    /// </summary>
    public partial class StepAddDialogWindow : Window, IDialogWindow
    {
        public StepAddDialogWindow()
        {
            InitializeComponent();
        }

        private void AddStepWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Work around for having the combobox starting on an actual value instead of being empty
            // Need to do it this way because the data context is set outside of this class and 
            // when it's set it overrides the isSelected property for combobox items
            TypeComboBox.SelectedIndex = 0;
        }
    }
}
