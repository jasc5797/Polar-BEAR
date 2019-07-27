using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using PolarBearGUI_WPF.ViewModels.StepViewModels.StepEditViewModels;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public abstract class StepViewModel : NotifyPropertyChangedObject
    {
        private Step step;

        public Step Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
                NotifyPropertyChanged("Step");
            }
        }

        public StepEditViewModel StepEditViewModel { get; set; }
    }
}
