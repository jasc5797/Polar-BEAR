﻿using PolarBearGUI_WPF.ViewModels;
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

namespace PolarBearGUI_WPF.Views
{
    /// <summary>
    /// Interaction logic for ManualControlView.xaml
    /// </summary>
    public partial class ManualControlView : UserControl
    {
        public ManualControlView()
        {
            InitializeComponent();
            DataContext = new ManualControlViewModel();
        }
    }
}
