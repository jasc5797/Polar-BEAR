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

namespace PolarBearGUI_WPF.CustomUserControls
{
    /// <summary>
    /// Interaction logic for StatusView.xaml
    /// </summary>
    public partial class StatusView : UserControl
    {
        
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status",
                typeof(string),
                typeof(StatusView),
                new FrameworkPropertyMetadata("Disconnected"));

        public string Status
        {
            get
            {
                return (string)GetValue(StatusProperty);
            }
            set
            {
                SetValue(StatusProperty, value);
            }
        }
        

        public StatusView()
        {
            InitializeComponent();
            Root.DataContext = this;
        }
    }
}
