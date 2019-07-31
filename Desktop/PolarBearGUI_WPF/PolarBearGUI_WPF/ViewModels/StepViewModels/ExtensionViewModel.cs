using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    class ExtensionViewModel : StepViewModel
    {
        public ExtensionViewModel()
        {
            Step = new Extension(0.5);
        }
    }
}
