﻿using PolarBearGUI_WPF.Utilities;
using PolarBearGUI_WPF.ViewModels.StepViewModels;
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

        public RelayCommand RemoveCommand;

        public PathEditorViewModel()
        {
            //RemoveCommand = new RelayCommand()
            stepViewModelList = new List<StepViewModel>();
            stepViewModelList.Add(new TiltViewModel());
            stepViewModelList.Add(new DelayViewModel());
            stepViewModelList.Add(new RotationViewModel());
            stepViewModelList.Add(new DelayViewModel());
            stepViewModelList.Add(new ExtensionViewModel());
        }
    }
}
