using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    class TiltViewModel : StepViewModel
    {
        public TiltViewModel()
        {
            Step = new Tilt(5.4);
        }
    }
}
