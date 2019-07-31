using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.Models
{
    public class Tilt : Step
    {
        public override string Type
        {
            get
            {
                return "Tilt";
            }
        }

        private double degrees;

        [Description("Degrees to Tilt")]
        public double Degrees
        {
            get
            {
                return degrees;
            }
            set
            {
                degrees = value;
                NotifyPropertyChanged("Degrees");
            }
        }

        public Tilt(double degrees): base()
        {
            this.degrees = degrees;
        }

        public override bool Equals(Model model)
        {
            if (model is Tilt)
            {
                Tilt tilt = model as Tilt;
                return Degrees == tilt.Degrees &&
                     CreationTime == tilt.CreationTime;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashTime = CreationTime == null ? 0 : CreationTime.GetHashCode();
            int hashType = Type == null ? 0 : Type.GetHashCode();
            int hashDegrees = Degrees.GetHashCode();
            return hashTime ^ hashType ^ hashDegrees;
        }
    }
}
