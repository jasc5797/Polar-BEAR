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
    /// Interaction logic for LabeledTextbox.xaml
    /// </summary>
    public partial class LabeledTextbox : UserControl
    {
        public static readonly DependencyProperty NameLabelProperty =
            DependencyProperty.Register("NameLabel",
                typeof(string), 
                typeof(LabeledTextbox),
                new FrameworkPropertyMetadata("Unknown Name"));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text",
                typeof(object),
                typeof(LabeledTextbox),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty UnitsLabelProperty =
            DependencyProperty.Register("UnitsLabel",
            typeof(string),
            typeof(LabeledTextbox),
            new FrameworkPropertyMetadata("Unknown Units"));

        public LabeledTextbox()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        public string NameLabel
        {
            get
            {
                return (string)GetValue(NameLabelProperty);
            }
            set
            {
                SetValue(NameLabelProperty, value);
            }
        }

        public object Text
        {
            get
            {
                return GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public string UnitsLabel
        {
            get
            {
                return (string)GetValue(UnitsLabelProperty);
            }
            set
            {
                SetValue(UnitsLabelProperty, value);
            }
        }
    }
}
