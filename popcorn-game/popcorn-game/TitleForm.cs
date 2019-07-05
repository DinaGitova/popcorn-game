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
    public partial class TitleForm : Form
    {
        GameForm gameForm;
        HelpMenuForm help;
        public static String text;
        public TitleForm()
        {
            InitializeComponent();
            this.ActiveControl = playerName;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            text = playerName.Text;
            gameForm = new GameForm();
            if (gameForm.ShowDialog(this) == DialogResult.Cancel) this.Show();
        }

        private void playerName_TextChanged(object sender, EventArgs e)
        {
            text = playerName.Text;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
              help = new HelpMenuForm();
              help.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
