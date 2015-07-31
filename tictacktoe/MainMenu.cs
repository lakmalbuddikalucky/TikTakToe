using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tictacktoe
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            OnePlayer form1 = new OnePlayer();
            form1.Show();
            this.Hide();
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            TwoPlayers form2 = new TwoPlayers();
            form2.Show();
            this.Hide();
        }
    }
}
