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
        TitleForm title;
        public HelpMenuForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            title = new TitleForm();
            title.Show();
            this.Hide();
        }
    }
}
