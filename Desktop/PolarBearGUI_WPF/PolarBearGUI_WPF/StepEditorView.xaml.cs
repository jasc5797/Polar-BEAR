using PolarBearGUI_WPF.ViewModels;
using PolarBearGUI_WPF.ViewModels.StepViewModels.StepEditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolarBearGUI_WPF
{
    /// <summary>
    /// Interaction logic for StepEditorView.xaml
    /// </summary>
    public partial class StepEditorView : UserControl
    {
        public StepEditorView()
        {
            InitializeComponent();
            DataContext = new StepEditorViewModel();
        }
    }
}
