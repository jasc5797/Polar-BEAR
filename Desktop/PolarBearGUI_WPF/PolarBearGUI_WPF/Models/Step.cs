using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PolarBearGUI_WPF.Models
{
    public class Step : Model
    {
        public enum Type
        {
            DELAY,
            TILT,
            ROTATE,
            EXTEND,
            MOVE
        }

        private Type stepType;

        public string StepType
        {
            get
            {
                switch(stepType)
                {
                    case Type.DELAY:
                        return "Delay";
                    case Type.EXTEND:
                        return "Extend";
                    case Type.MOVE:
                        return "Move";
                    case Type.ROTATE:
                        return "Rotate";
                    case Type.TILT:
                        return "Tilt";
                    default:
                        return "Error";
                }
            }
        }

        public const string TiltDegrees1 = "15.3";
        public const string TiltDegrees2 = "-5.6";
        public const string DelayLength1 = "5";
        public const string DelayLength2 = "1";
        public const string MoveX = "2.5";
        public const string MoveY = "1";
        public const string MoveZ = "1.75";
        public const string RotateDegrees = "180";

        public Step(Type type)
        {
            stepType = type; 
        }

        public override bool Equals(Model model)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
