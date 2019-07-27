using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.ViewModels.StepViewModels.StepEditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public class DelayViewModel : StepViewModel
    {

        public DelayViewModel()
        {
            Step = new Delay(100);
            StepEditViewModel = new DelayEditViewModel(Step as Delay);
        }
    }
}
