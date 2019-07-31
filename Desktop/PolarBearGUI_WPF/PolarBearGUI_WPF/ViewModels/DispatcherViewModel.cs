using System;
using System.Windows.Threading;

namespace PolarBearGUI_WPF.ViewModels
{
    public abstract class DispatcherViewModel : CustomViewModel
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



    }
}
