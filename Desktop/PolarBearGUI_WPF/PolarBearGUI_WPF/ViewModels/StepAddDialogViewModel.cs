using PolarBearGUI_WPF.Dialogs.Service;
using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using PolarBearGUI_WPF.ViewModels.StepViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PolarBearGUI_WPF.ViewModels
{
    public class StepAddDialogViewModel : DialogViewModelBase<StepViewModel>
    {
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        //private StepViewModel StepViewModel { get; set; }

        private ComboBoxItem stepType;
        public ComboBoxItem StepType
        {
            get
            {
                return stepType;
            }
            set
            {
                stepType = value;
                NotifyPropertyChanged("StepType");
            }
        }


        public StepAddDialogViewModel() : base("Add Step")
        {
            OKCommand = new RelayCommand<IDialogWindow>(OK);
            CancelCommand = new RelayCommand<IDialogWindow>(Cancel);

           
        }

        private void OK(IDialogWindow window)
        {
            if (StepType == null)
            {
                return;
            }

            StepViewModel stepViewModel;
            
            switch(StepType.Content)
            {
                case "Delay":
                    stepViewModel = new DelayViewModel();
                    break;
                case "Tilt":
                    stepViewModel = new TiltViewModel();
                    break;
                case "Rotation":
                    stepViewModel = new RotationViewModel();
                    break;
                case "Extension":
                    stepViewModel = new ExtensionViewModel();
                    break;
                default:
                    stepViewModel = null;
                    break;
            }
            CloseDialogWithResult(window, stepViewModel);
        }

        private void Cancel(IDialogWindow window)
        {
            CloseDialogWithResult(window, null);
        }
    }
}
