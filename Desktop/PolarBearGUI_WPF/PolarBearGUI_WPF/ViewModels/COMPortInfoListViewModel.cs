using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarBearGUI_WPF.ViewModels
{
    public class COMPortInfoListViewModel
    {
        private COMPortInfoList comPortInfoList;

        public COMPortInfoList COMPortInfoList
        {
            get
            {
                return comPortInfoList;
            }
        }
        public COMPortInfoListViewModel()
        {
            comPortInfoList = new COMPortInfoList();
        }
    }
}
