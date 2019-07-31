using PolarBearGUI_WPF.Utilities;

namespace PolarBearGUI_WPF.Models
{
    public abstract class Model : NotifyPropertyChangedObject
    {
        public override bool Equals(object obj)
        {
            return obj is Model && Equals(obj as Model);
        }

        public abstract bool Equals(Model model);

        public abstract override int GetHashCode();
    }
    /*
    public class ModelComparer : IEqualityComparer<Model>
    {
        public bool Equals(Model x, Model y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return x.Equals(y);
        }

        public int GetHashCode(Model model)
        {
            if (ReferenceEquals(model, null))
                return 0;
            return model.GetHashCode();
        }
        
    }
    */
}
