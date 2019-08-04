using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.Models
{
    public class EndEffector : Step
    {
        public override string Type
        {
            get
            {
                return "End Effector";
            }
        }

        private double tiltDegrees;

        [DisplayName("Tilt Degrees")]
        [Description("Degrees to Tilt the End Effector")]
        public double TiltDegrees
        {
            get
            {
                return tiltDegrees;
            }
            set
            {
                tiltDegrees = value;
                NotifyPropertyChanged("TiltDegrees");
            }
        }

        private double rotationDegrees;

        [DisplayName("Rotation Degrees")]
        [Description("Degrees to Rotate the End Effector")]
        public double RotationDegrees
        {
            get
            {
                return rotationDegrees;
            }
            set
            {
                rotationDegrees = value;
                NotifyPropertyChanged("RotationDegrees");
            }
        }

        public EndEffector(double tiltDegrees, double rotationDegrees)
        {
            TiltDegrees = tiltDegrees;
            RotationDegrees = rotationDegrees;
        }

        public override bool Equals(Model model)
        {
            if (model is EndEffector)
            {
                EndEffector endEffector = model as EndEffector;
                return CreationTime == endEffector.CreationTime &&
                    Type == endEffector.Type &&
                    TiltDegrees == endEffector.TiltDegrees &&
                    RotationDegrees == endEffector.RotationDegrees;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCreationTime = CreationTime == null ? 0 : CreationTime.GetHashCode();
            int hashType = Type == null ? 0 : Type.GetHashCode();
            int hashTiltDegrees = TiltDegrees.GetHashCode();
            int hashRotationDegrees = RotationDegrees.GetHashCode();
            return hashCreationTime ^ hashType ^ hashTiltDegrees ^ hashRotationDegrees;
        }
    }
}
