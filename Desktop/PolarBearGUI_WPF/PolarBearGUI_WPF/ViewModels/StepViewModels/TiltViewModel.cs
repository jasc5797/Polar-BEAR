using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.ViewModels.StepViewModels.StepEditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    class TiltViewModel : StepViewModel
    {
        public TiltViewModel()
        {
            Step = new Tilt(5.4);
            StepEditViewModel = new TiltEditViewModel(Step as Tilt);
        }
    }
}
