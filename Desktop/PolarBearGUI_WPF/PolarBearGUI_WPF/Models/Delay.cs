using System.ComponentModel;

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

        private int length;

        [Description("Length of the Delay")]
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                NotifyPropertyChanged("Length");
            }
        }

        public Delay(int length) : base()
        {
            this.length = length;

        }

        public override bool Equals(Model model)
        {
            if (model is Delay)
            {
                Delay delay = model as Delay;
                return Length == delay.Length &&
                    CreationTime == delay.CreationTime;
            }
            return false;
        }

        public override int GetHashCode()
        {

            int hashTime = CreationTime == null ? 0 : CreationTime.GetHashCode();
            int hashType = Type == null ? 0 : Type.GetHashCode();
            int hashLength = Length.GetHashCode();
            return hashTime ^ hashType ^ hashLength;
        }
    }
}
