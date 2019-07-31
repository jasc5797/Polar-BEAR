using PolarBearGUI_WPF.ViewModels;
using System.Windows.Controls;


namespace PolarBearGUI_WPF.Views
{
    /// <summary>
    /// Interaction logic for PathEditorView.xaml
    /// </summary>
    public partial class PathEditorView : UserControl
    {
 
               
        public PathEditorView()
        {
            InitializeComponent();
            DataContext = new PathEditorViewModel();

        }
          
    }
}
