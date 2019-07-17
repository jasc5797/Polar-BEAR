using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace PolarBEAR_GUI
{
    public partial class Form1 : Form
    {

        private const string ArduinoMegaName = "Arduino Mega 2560";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            InitializeComboBoxPortInfo();

            /*
            GetArduinoMega();
            foreach (String name in SerialPort.GetPortNames())
            {
                Console.WriteLine(name);
            }
            */
        }

        private void InitializeComboBoxPortInfo()
        {
            ComboBox comboBoxPortInfo = toolStripComboBoxPortInfo.ComboBox;
            List<PortInfo> portInfos = PortInfo.GetPortInfos();
           // if (comboBoxPortInfo.DataSource == null)
            {
                comboBoxPortInfo.DisplayMember = "FullName";
                comboBoxPortInfo.DataSource = portInfos;
            }
            if(!comboBoxPortInfo.DataSource.Equals(portInfos))
            {
                
            }


        }

        private string GetArduinoMega()
        {
            List<PortInfo> portInfos = PortInfo.GetPortInfos();
            return "";
           
        }

        private void ToolStripComboBoxPortInfo_DropDown(object sender, EventArgs e)
        {
            InitializeComboBoxPortInfo();
        }

        private void TimerCheckPortInfo_Tick(object sender, EventArgs e)
        {
            InitializeComboBoxPortInfo();
        }
    }
}
