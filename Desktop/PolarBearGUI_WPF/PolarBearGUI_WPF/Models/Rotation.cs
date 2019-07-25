using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.Models
{
    public class Rotation : Step
    {
        public override string Type
        {
            get
            {
                return "Rotation";
            }
        }

        private double degrees;

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

        public Rotation(double degrees) : base()
        {
            this.degrees = degrees;
        }

        public override bool Equals(Model model)
        {
            if (model is Rotation)
            {
                Rotation rotation = model as Rotation;
                return Degrees == rotation.Degrees &&
                     CreationTime == rotation.CreationTime;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashTime = CreationTime == null ? 0 : CreationTime.GetHashCode();
            int hashType = Type == null ? 0 : Type.GetHashCode();
            int hashInterval = Degrees.GetHashCode();
            return hashTime ^ hashType ^ hashInterval;
        }
    }
}
