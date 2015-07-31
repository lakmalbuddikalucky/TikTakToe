using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tictacktoe.DB;

namespace tictacktoe
{
    public partial class OnePlayer : Form
    {
        public OnePlayer()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Player p1 = new Player();
            p1.Name = "Vijini";
            
            MainForm form1 = new MainForm(p1);
            form1.Show();
            this.Hide();
        }
    }
}
