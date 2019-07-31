using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels
{
    public abstract class StepViewModel : NotifyPropertyChangedObject
    {
        private Step step;

        public Step Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
                NotifyPropertyChanged("Step");
            }
        }
    }
}
