using PolarBearGUI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PolarBearGUI_WPF.ViewModels
{
    public abstract class DispatcherViewModel : NotifyPropertyChangedObject
    {
        private DispatcherTimer dispatcherTimer;

        public DispatcherViewModel()//TimeSpan interval)
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        protected abstract void DispatcherTimer_Tick(object sender, EventArgs e);

        protected bool EqualsModelLists(IEnumerable<Model> x, IEnumerable<Model> y)
        {
            return x.Count() == y.Count() && !x.Except(y).Any();
        }

    }
}
