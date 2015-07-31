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
    public partial class TwoPlayers : Form
    {
        public TwoPlayers()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Player p1 = new Player();
            p1.Name = "Vijini";

            Player p2 = new Player();
            p2.Name = "Gimhani";

            MainForm form1 = new MainForm(p1,p2);
            form1.Show();
            this.Hide();
        }
    }
}
