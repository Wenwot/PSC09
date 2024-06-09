
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC09
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.Text = "Menu General";
            this.KeyPreview = true;
        }

        private void frmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();  // cierra la aplicacion
        }

        private void puestoDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuesto frm = new frmPuesto();
            frm.Show();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
    }
}
