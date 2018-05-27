using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithreading_Timer
{

    public partial class Form1 : Form
    {
       public System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
        
      public Form1()
        {
            InitializeComponent();
           
        }
        private void DoWork(object obj, EventArgs e)
        {
           
            progressBar1.Increment(1);
            label1.Text = progressBar1.Value.ToString() + " % Completed";
            if (progressBar1.Value == progressBar1.Maximum)
            {
                time.Stop();
            }

        }

        private void Start_Click(object sender, EventArgs e)
        {
            time.Interval = 250;
            time.Tick += new EventHandler(DoWork);
            time.Start();
            System.Threading.Timer Timer = new System.Threading.Timer(_ListBox,null,0,3000);
        }

        private void _ListBox(object sender)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            if(progressBar1.Value !=0 && progressBar1.Value != progressBar1.Maximum )
            {
                listBox1.Items.Add(progressBar1.Value.ToString() + " % Completed   " + DateTime.Now.TimeOfDay);
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            time.Stop();
            progressBar1.Value = 0;
            label1.Text = progressBar1.Value.ToString() + " % Completed";
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            time.Stop();
        }
    }
}
