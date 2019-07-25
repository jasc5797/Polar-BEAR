using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PolarBearGUI_WPF.Models;

namespace PolarBearGUI_WPF
{
    public class StepViewModel : NotifyPropertyChangedObject
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

        public StepViewModel()
        {
            step = new Step(Step.Type.DELAY);
        }

    }
}
