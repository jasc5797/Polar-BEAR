using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.ViewModels.StepViewModels.StepEditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public class RotationViewModel : StepViewModel
    {
        public RotationViewModel()
        {
            Step = new Rotation(180.0);
            StepEditViewModel = new RotationEditViewModel(Step as Rotation);
        }
    }
}
