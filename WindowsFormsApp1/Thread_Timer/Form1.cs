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

namespace Timer
{
    public partial class Form1 : Form
    {
      public int i { set; get; }
        public System.Threading.Timer Timer;
     
        public Form1()
        {
            InitializeComponent();
           
        }

        public void DoWork()
        {
            
            for( int  j=0;  j<101; j++)
            {
           
                i = j;
                Thread.Sleep(500);
                this.Invoke((Action)delegate
                {
                    this.Text = string.Format("Processing {0}  % Completed ", i.ToString());
                });

                if (i == 100 ) { return; }
               
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
        Task.Factory.StartNew(() =>
            {
                DoWork();
            });
           
           Timer =  new System.Threading.Timer(_ListBox,100,0,10000);
            if(i==100)
            {
               // Timer.Change(Timeout.Infinite, Timeout.Infinite); 
               //or
               Timer.Dispose();
            }
           
        }
        private void _ListBox(object sender)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
          if(i != 0 && i<101)
            {
                 listBox1.Items.Add(i.ToString() + " % Completed   ");
            }
         if(i==100)
            {
                // listBox1.Items.Add("Progress completed!");
                Timer.Change(Timeout.Infinite, Timeout.Infinite);
            }

             
        }
        private void Stop_Click(object sender, EventArgs e)
        {
               this.Close();
        }
    }
}
