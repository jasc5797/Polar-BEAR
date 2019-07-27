using PolarBearGUI_WPF.ViewModels;
using PolarBearGUI_WPF.ViewModels.StepViewModels;
using System.Windows.Controls;


namespace PolarBearGUI_WPF.Views.StepViews
{
    /// <summary>
    /// Interaction logic for StepView.xaml
    /// </summary>
    public partial class StepView : UserControl
    {
        public StepView()
        {
            InitializeComponent();
            DataContext = new TiltViewModel();
        }
    }
}
