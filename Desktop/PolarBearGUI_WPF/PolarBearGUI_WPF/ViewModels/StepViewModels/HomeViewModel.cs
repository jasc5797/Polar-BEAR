﻿using PolarBearGUI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public class HomeViewModel : StepViewModel
    {
        public HomeViewModel() : this (new Home(Home.ComponentType.Extension)) { }
        
        public HomeViewModel(Home home) : base(home) { }
    }
}
