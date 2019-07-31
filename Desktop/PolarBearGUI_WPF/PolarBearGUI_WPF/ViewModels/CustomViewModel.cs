using PolarBearGUI_WPF.Models;
using PolarBearGUI_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels
{
    public abstract class CustomViewModel : NotifyPropertyChangedObject
    {
        protected bool EqualsModelLists(IEnumerable<Model> x, IEnumerable<Model> y)
        {
            return x.Count() == y.Count() && !x.Except(y).Any();
        }
    }
}
