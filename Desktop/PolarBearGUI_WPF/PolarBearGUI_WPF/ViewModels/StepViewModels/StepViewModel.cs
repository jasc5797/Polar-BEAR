using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using System.Collections.Generic;
using System;

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

        public StepViewModel(Step step)
        {
            Step = step;
        }

        public static List<Step> ConvertStepViewModelsToSteps(IEnumerable<StepViewModel> stepViewModels)
        {

            return ConvertStepViewModelsToSteps(new List<StepViewModel>(stepViewModels));
        }

        public static List<Step> ConvertStepViewModelsToSteps(List<StepViewModel> stepViewModels)
        {
 
            return stepViewModels.ConvertAll(new Converter<StepViewModel, Step>(StepViewModelToStep));
        }

        private static Step StepViewModelToStep(StepViewModel stepViewModel)
        {
            return stepViewModel.Step;
        }


        public static List<StepViewModel> ConvertStepsToStepViewModels(List<Step> steps)
        {
            return steps.ConvertAll(new Converter<Step, StepViewModel>(StepsToStepViewModels));
        }

        private static StepViewModel StepsToStepViewModels(Step step)
        {
            if (step is Delay)
            {
                return new DelayViewModel(step as Delay);
            }
            else if (step is Tilt)
            {
                return new TiltViewModel(step as Tilt);
            }
            else if (step is Rotation)
            {
                return new RotationViewModel(step as Rotation);
            }
            else if (step is Extension)
            {
                return new ExtensionViewModel(step as Extension);
            }
            return null;
        }
     
    }
}
