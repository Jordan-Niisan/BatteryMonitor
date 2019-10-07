using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace BatteryMonitor
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
		
        public Form1()
        {
            InitializeComponent();
            Refresh();

            this.myTimer.Interval = 100;
            this.myTimer.Tick += new System.EventHandler(myTimer_Tick);
            this.myTimer.Start();//start timer1
        }

        
        private void myTimer_Tick(object sender, EventArgs e){
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Refresh()
        {
            this.Text = "Battery Status: " + GetBatteryStatus().ToString() + "%";
            label3.Text = GetBatteryStatus().ToString() + "%";
            label4.Text = GetPowerSource();
            label6.Text = GetTime();
        }

        public String GetPowerSource()
        {
            string strPowerLineStatus = "Default";
            // Getting the current system power status.
            switch (SystemInformation.PowerStatus.PowerLineStatus)
            {
                case PowerLineStatus.Offline:
                    strPowerLineStatus = "Battery";
                    break;
                case PowerLineStatus.Online:
                    strPowerLineStatus = "AC Power";
                    break;
                case PowerLineStatus.Unknown:
                    strPowerLineStatus = "Unknown";
                    break;
            }
            return strPowerLineStatus;
        }

        public String GetTime()
        {
            string strtime = "Default";
            strtime = DateTime.Now.ToString();
            return strtime;
        }

        public float GetBatteryStatus()
        {
            float batterylife;
            batterylife = SystemInformation.PowerStatus.BatteryLifePercent;
            batterylife *= 100.0f;
            return batterylife;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
