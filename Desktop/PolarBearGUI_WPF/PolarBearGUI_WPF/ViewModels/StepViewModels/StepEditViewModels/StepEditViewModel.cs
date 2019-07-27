using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels.StepEditViewModels
{
    public abstract class StepEditViewModel : StepViewModel
    {
        public StepEditViewModel(Step step)
        {
            Step = step;
        }

    }
}
