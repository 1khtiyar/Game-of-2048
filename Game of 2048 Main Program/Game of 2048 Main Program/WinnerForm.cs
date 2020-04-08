using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_2048_Main_Program
{
    public partial class WinnerForm : Form
    {
        public WinnerForm()
        {
            InitializeComponent();
        }

        

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Close();
            this.Close();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.RestartEvent();
            this.Close();
        }
    }
}
