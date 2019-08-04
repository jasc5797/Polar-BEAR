using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public class EndEffectorViewModel : StepViewModel
    {
        public EndEffectorViewModel() : this(new EndEffector(5, 10)) { }

        public EndEffectorViewModel(EndEffector endEffector) : base (endEffector) { }
    }
}
