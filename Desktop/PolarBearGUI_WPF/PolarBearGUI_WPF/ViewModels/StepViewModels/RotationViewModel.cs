using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public class RotationViewModel : StepViewModel
    {
        public RotationViewModel()
        {
            Step = new Rotation(180.0);
        }
    }
}
