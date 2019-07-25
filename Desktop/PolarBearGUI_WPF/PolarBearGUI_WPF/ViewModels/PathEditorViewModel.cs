using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels
{
    class PathEditorViewModel : NotifyPropertyChangedObject
    {
        private List<StepViewModel> stepViewModelList;

        public List<StepViewModel> StepViewModelList
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
            stepViewModelList = new List<StepViewModel>();
            stepViewModelList.Add(new DelayViewModel());
            stepViewModelList.Add(new TiltViewModel());
            stepViewModelList.Add(new TiltViewModel());
        }
    }
}
