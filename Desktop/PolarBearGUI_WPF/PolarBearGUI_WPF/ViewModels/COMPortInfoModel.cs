using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PolarBearGUI_WPF
{
    public class COMPortInfoModel : Models.Model
    {
        private List<COMPortInfo> comPortInfoList;

        public List<COMPortInfo> COMPortInfoList
        {
            get
            {
                return comPortInfoList;
            }
            private set
            {
                comPortInfoList = value;
                NotifyPropertyChanged("COMPortInfoList");
            }
        }

        private DispatcherTimer dispatcherTimer;


        public COMPortInfoModel()
        {
            comPortInfoList = new List<COMPortInfo>();
            
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            List<COMPortInfo> newCOMPortInfoList = COMPortInfo.GetCOMPortInfoList();
            if (newCOMPortInfoList.Count != COMPortInfoList.Count || newCOMPortInfoList.Except(COMPortInfoList).Any())
            {
                COMPortInfoList = newCOMPortInfoList;
            }
        }
    }
}
