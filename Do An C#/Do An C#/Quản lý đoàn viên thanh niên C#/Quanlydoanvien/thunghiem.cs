using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quanlydoanvien
{
    public partial class thunghiem : Form
    {
        public thunghiem()
        {
            InitializeComponent();
        }

        private void thunghiem_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();               
                this.Hide();
                Welcome w = new Welcome();
                w.Show();
            }
            else
            {

                progressBar1.Value += 1;
                this.label2.Text = "Loading....." + progressBar1.Value + "%";


            }
            ///chay nhap nhay
            //if (pictureBox1.BackColor == Color.Red)
            //    pictureBox1.BackColor = Color.Lime;
            //else
            //    pictureBox1.BackColor = Color.Red;
            
        }
    }
}