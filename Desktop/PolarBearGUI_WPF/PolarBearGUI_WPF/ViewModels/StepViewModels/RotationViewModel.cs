using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public class RotationViewModel : StepViewModel
    {
        public RotationViewModel() : base(new Rotation(180.0)) { }
        public RotationViewModel(Rotation rotation) : base(rotation) { }
    }
}
