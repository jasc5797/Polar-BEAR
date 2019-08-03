using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public class DelayViewModel : StepViewModel
    {
        public DelayViewModel() : this(new Delay(100)) { }

        public DelayViewModel(Delay delay) : base (delay) { }
    }
}
