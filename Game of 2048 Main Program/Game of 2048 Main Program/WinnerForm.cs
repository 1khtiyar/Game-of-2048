using System;
using System.Windows.Forms;

namespace Game_of_2048_Main_Program
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
            this.KeyDown += KeyDownProcess;
        }
        private void Rules_Load(object sender, EventArgs e)
        {

        }
        private void KeyDownProcess(object sender,KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                Form1.rulesFormEnabled = false;
                this.Close();
            }
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            Form1.rulesFormEnabled = false;
            this.Close();
        }
    }
}
