using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.Models
{
    public class Extension : Step
    {
        public override string Type
        {
            get
            {
                return "Extension";
            }
        }

        private double distance;

        public double Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
                NotifyPropertyChanged("Distance");
            }
        }

        public Extension(double distance) : base()
        {
            this.distance = distance;
        }

        public override bool Equals(Model model)
        {
            if (model is Extension)
            {
                Extension extension = model as Extension;
                return Distance == extension.Distance &&
                     CreationTime == extension.CreationTime;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashTime = CreationTime == null ? 0 : CreationTime.GetHashCode();
            int hashType = Type == null ? 0 : Type.GetHashCode();
            int hashInterval = Distance.GetHashCode();
            return hashTime ^ hashType ^ hashInterval;
        }
    }
}
