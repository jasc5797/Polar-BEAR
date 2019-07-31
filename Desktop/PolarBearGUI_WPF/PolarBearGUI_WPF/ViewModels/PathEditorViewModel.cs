using PolarBearGUI_WPF.Dialogs.Service;
using PolarBearGUI_WPF.Utilities;
using PolarBearGUI_WPF.ViewModels.StepViewModels;
using System.Collections.ObjectModel;

namespace PolarBearGUI_WPF.ViewModels
{
    class PathEditorViewModel : NotifyPropertyChangedObject
    {
        private IDialogService dialogService;

        public RelayCommand AddStepCommand { get; private set; }
        public RelayCommand RemoveStepCommand { get; private set; }


        public StepViewModel SelectedStepViewModel { get; set; }
        

        private ObservableCollection<StepViewModel> stepViewModelList;

        public ObservableCollection<StepViewModel> StepViewModelList
        {
            get
            {
                return stepViewModelList;
            }
            set
            {
                stepViewModelList = value;
                NotifyPropertyChanged("StepViewModelList");
            }
        }



        public PathEditorViewModel()
        {
            dialogService = new StepAddDialogService();
            
            StepViewModelList = new ObservableCollection<StepViewModel>();
            StepViewModelList.Add(new TiltViewModel());
            StepViewModelList.Add(new DelayViewModel());
            StepViewModelList.Add(new RotationViewModel());
            StepViewModelList.Add(new DelayViewModel());
            StepViewModelList.Add(new ExtensionViewModel());

            AddStepCommand = new RelayCommand(AddStep, CanAddStep);
            RemoveStepCommand = new RelayCommand(RemoveStep, CanRemoveStep);
        }

        public void AddStep()
        {
            var dialogViewModel = new StepAddDialogViewModel();

            StepViewModel stepViewModel = dialogService.OpenDialog(dialogViewModel);
            if (stepViewModel != null)
            {
                StepViewModelList.Add(stepViewModel as StepViewModel);
            }
        }

        public bool CanAddStep()
        {
            return true;
        }

        public void RemoveStep()
        {
            StepViewModelList.Remove(SelectedStepViewModel);
        }

        public bool CanRemoveStep()
        {
            return StepViewModelList.Count > 0 && SelectedStepViewModel != null;
        }
    }
}
