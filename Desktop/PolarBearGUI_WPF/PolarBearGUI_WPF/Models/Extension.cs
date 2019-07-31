using System.ComponentModel;

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

        [Description("Distance to Extend")]
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
            int hashDistance = Distance.GetHashCode();
            return hashTime ^ hashType ^ hashDistance;
        }
    }
}
