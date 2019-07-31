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
    public partial class LabeledDoubleUpDown: UserControl
    {
        public static readonly DependencyProperty NameLabelProperty =
            DependencyProperty.Register("DoubleUpDownNameLabel",
                typeof(string), 
                typeof(LabeledTextbox),
                new FrameworkPropertyMetadata("Unknown Name"));

        public static readonly DependencyProperty DoubleValueProperty =
            DependencyProperty.Register("DoubleUpDownValue",
                typeof(object),
                typeof(LabeledTextbox),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty UnitsLabelProperty =
            DependencyProperty.Register("DoubleUpDownUnitsLabel",
            typeof(string),
            typeof(LabeledTextbox),
            new FrameworkPropertyMetadata("Unknown Units"));

        public LabeledDoubleUpDown()
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

        public object DoubleValue
        {
            get
            {
                return GetValue(DoubleValueProperty);
            }
            set
            {
                SetValue(DoubleValueProperty, value);
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
