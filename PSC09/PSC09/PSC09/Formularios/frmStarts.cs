using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;  // libreria para utilizar SQL

namespace PSC09
{
    public partial class frmStarts : Form
    {
        string password;

        public frmStarts()
        {
            InitializeComponent();
        }

        private void frmStarts_Load(object sender, EventArgs e)
        {
            this.Text = "Login";      // cambiamos el titulo del formulario
            this.KeyPreview = true;   // activamos las teclas de funciones
        }

        private void frmStarts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)  // preguntaos que si la tecla que presionaste es igual ESC
            {
                Application.Exit();   // cierra toda la aplicacion
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // pregunta que si presionaste la tecla Enter
            {
                e.Handled = true;   // indica que se ejecuto enter

                if (txtUsuario.Text.Trim() != string.Empty)  // pregunta que si el textbox es diferente de vacio
                {
                    txtPassword.Focus();  // movera el cursor hacia el textbox password
                }
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != string.Empty)  // pregunta que si el textbox es diferente de vacio
            {
                BuscarUsuario(txtUsuario.Text);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // pregunta que si presionaste la tecla Enter
            {
                e.Handled = true;   // indica que se ejecuto enter

                if (txtPassword.Text.Trim() != string.Empty)  // pregunta que si el textbox es diferente de vacio
                {
                    btnAceptar.Focus();  // movera el cursor hacia el textbox password
                }
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != string.Empty)  // pregunta que si el textbox es diferente de vacio
            {
                btnAceptar.PerformClick();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != string.Empty)  // pregunta que si el textbox es diferente de vacio
            {
                if (txtPassword.Text.Trim() != string.Empty)  // pregunta que si el textbox es diferente de vacio
                {
                    if (txtPassword.Text.Trim() == password)  // pregunta que si el textbox es diferente de vacio
                    {
                        frmMenu frm = new frmMenu();  // cargamos el formulario a un objeto llamado frm
                        frm.Show();  // mostramos el menu

                        this.Hide();   // escondemos el formulario frmStarts
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // cierro el formulario
        }


        // --------------------------------------------------
        // METODOS
        // --------------------------------------------------
        private void BuscarUsuario(string cualUsuario)
        {
            string miQuery = "SELECT NOMBRECORTO, " +
                             "       CLAVE " +
                             "  FROM USUARIO " +
                             " WHERE NOMBRECORTO ='" + cualUsuario + "'";

            SqlConnection cnxn = new SqlConnection(cnn.db);  // indicamos la conexion a la base de datos
            cnxn.Open();   // abrimos la base de datos

            SqlCommand cmd = new SqlCommand(miQuery, cnxn);  // aqui enviamos el script al motor de SQL
            SqlDataReader rdr = cmd.ExecuteReader();  // ejucatamos el script enviado

            if (rdr.Read())  // aqui va a preguntar si trajo registro
            {
                password = rdr["CLAVE"].ToString();
            }
        }
    }
}
