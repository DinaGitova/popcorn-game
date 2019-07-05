using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace popcorn_game
{
    public partial class HelpMenuForm : Form
    {
        public HelpMenuForm()
        {
            InitializeComponent();
            btnBack.Enabled = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "GameForm") btnBack.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
          
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
