using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    class ExtensionViewModel : StepViewModel
    {
        public ExtensionViewModel() : base (new Extension(0.5)) { }

        public ExtensionViewModel(Extension extension) : base(extension) { }
    }
}
