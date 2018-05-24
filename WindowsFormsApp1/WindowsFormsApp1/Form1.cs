using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Timer time = new Timer();
        private System.Threading.Timer Timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {

            time.Interval = 250;
            time.Tick += new EventHandler(DoWork);
            time.Start();

        }
        private void DoWork(object sender,EventArgs e)
        {
            progressBar1.Increment(1);
           label1.Text = progressBar1.Value.ToString() + " % Completed";
            if(progressBar1.Value == progressBar1.Maximum)
            {
                time.Stop();
            }
        }
       
        private void Stop_Click(object sender, EventArgs e)
        {
            time.Stop();
            progressBar1.Value = 0;
            label1.Text= progressBar1.Value.ToString() + " % Completed";
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            time.Stop();
        }
    }
}
