using PolarBearGUI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels
{
    class TiltViewModel : StepViewModel
    {
        public TiltViewModel()
        {
            Step = new Tilt(5.4);
        }
    }
}
