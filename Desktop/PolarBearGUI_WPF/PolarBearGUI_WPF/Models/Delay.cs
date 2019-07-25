using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.Models
{
    public class Delay : Step
    {
        public override string Type
        {
            get
            {
                return "Delay";
            }
        }

        private int interval;

        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
                NotifyPropertyChanged("Interval");
            }
        }

        public Delay(int interval) : base()
        {
            this.interval = interval;

        }

        public override bool Equals(Model model)
        {
            if (model is Delay)
            {
                Delay delay = model as Delay;
                return Interval == delay.Interval &&
                    CreationTime == delay.CreationTime;
            }
            return false;
        }

        public override int GetHashCode()
        {

            int hashTime = CreationTime == null ? 0 : CreationTime.GetHashCode();
            int hashType = Type == null ? 0 : Type.GetHashCode();
            int hashInterval = Interval.GetHashCode();
            return hashTime ^ hashType ^ hashInterval;
        }
    }
}
