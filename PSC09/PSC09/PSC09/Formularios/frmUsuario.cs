using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace PSC09
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            this.Text = "Maestro de usuario";      // cambiamos el titulo del formulario
            this.KeyPreview = true;   // activamos las teclas de funciones
        }

        private void frmUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)  // preguntaos que si la tecla que presionaste es igual ESC
            {
                this.Close();  // cierra el formulario
            }
        }

        // ------------------------------------------------------
        // BOTONES
        // ------------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtUsuario.Focus();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // CIERRA FORM
        }

        // ------------------------------------------------------
        // TEXTBOX
        // ------------------------------------------------------
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPuesto_Leave(object sender, EventArgs e)
        {

        }

        // ------------------------------------------------------
        // METODOS
        // ------------------------------------------------------
        private void LimpiarFormulario()
        {
            txtUsuario.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
            txtPassword.Clear();
            txtPuesto.Clear();
            lblPuesto.Text = "";
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
