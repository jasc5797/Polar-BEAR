using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.ViewModels.StepViewModels.StepEditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    class ExtensionViewModel : StepViewModel
    {
        public ExtensionViewModel()
        {
            Step = new Extension(0.5);
            StepEditViewModel = new ExtensionEditViewModel(Step as Extension);
        }
    }
}
