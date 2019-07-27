using PolarBearGUI_WPF.Dialogs.Service;
using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PolarBearGUI_WPF.ViewModels.StepViewModels.StepEditViewModels
{
    public class StepEditorViewModel : Dialogs.Service.DialogViewModelBase<Step>
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
                //NotifyPropertyChanged("Step");
            }
        }

        public ICommand SaveCommand { get; private set; }

        public StepEditorViewModel()
        {
            SaveCommand = new RelayCommand<IDialogWindow>(Save);
        }

        private void Save(IDialogWindow dialogWindow)
        {
            Console.WriteLine("Saving");
            CloseDialogWithResult(dialogWindow, Step);
        }
    }
}
