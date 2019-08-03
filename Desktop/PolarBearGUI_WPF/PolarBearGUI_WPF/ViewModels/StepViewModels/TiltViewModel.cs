using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    class TiltViewModel : StepViewModel
    {
        public TiltViewModel() : base(new Tilt(5.4)) { }

        public TiltViewModel(Tilt tilt) : base(tilt) { }
    }
}
