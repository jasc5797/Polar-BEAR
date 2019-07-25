using PolarBearGUI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels
{
    class ExtensionViewModel : StepViewModel
    {
        public ExtensionViewModel()
        {
            Step = new Extension(0.5);
        }
    }
}
