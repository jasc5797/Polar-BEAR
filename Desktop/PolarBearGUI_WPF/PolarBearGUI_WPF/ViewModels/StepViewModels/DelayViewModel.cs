using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public class DelayViewModel : StepViewModel
    {
        public DelayViewModel()
        {
            Step = new Delay(100);
        }
    }
}
