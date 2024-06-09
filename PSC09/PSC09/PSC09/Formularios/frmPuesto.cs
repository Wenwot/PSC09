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
    public partial class frmPuesto : Form
    {
        public frmPuesto()
        {
            InitializeComponent();
        }

        private void frmPuesto_Load(object sender, EventArgs e)
        {
            this.Text = "Maestro de Puesto de trabajo";
            this.KeyPreview = true;
        }

        private void frmPuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPosicion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

    private void txtPosicion_Leave(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtDepartamento.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtDepartamento.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtFabrica.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtDepartamento_Leave(object sender, EventArgs e)
        {

        }

        private void txtFabrica_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFabrica_Leave(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtPosicion.Focus();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarFormulario()
        {
            txtDepartamento.Clear();
            txtFabrica.Clear();
            txtNombre.Clear();
            txtPosicion.Clear();

            lblDepartamento.Text = "";
            lblFabrica.Text = "";
        }

        private void BuscarPosicion(string numPuesto)
        {
            SqlConnection cnx = new SqlConnection(cnn.db);
            cnx.Open();

            string stQuery = "SELECT T1.NombreDePosicion, T1.Fabrica, T1.Departamento, T2.NombreDefabrica, T3.NombreDepartamento\r\n" +
                             "FROM POSICIONES T1 \r\n" +
                             "INNER JOIN FABRICA T2 ON T1.Fabrica = T2.IDfabrica\r\n" +
                             "INNER JOIN DEPARTAMENTO T3 ON T1.Departamento = T3.IDdepartamento\r\n" +
                             "WHERE T1.IDposicion =";

            SqlCommand cmd = new SqlCommand(stQuery, cnx);   // enviamos el script al motor de SQL
            cmd.Parameters.AddWithValue("@A1", numPuesto);  // Declaro la variable y le asigno su valor correspondiente
            SqlDataReader rcd = cmd.ExecuteReader();  // ejecuta el script que le enviamos

            if (rcd.Read())  // aqui pregunta HasRow = true
            {
                txtPosicion.Text = rcd["IDposicion"].ToString();
                txtNombre.Text = rcd["NombreDePosicion"].ToString();
                txtDepartamento.Text = rcd["NombreDepartamento"].ToString();
                txtFabrica.Text = rcd["NombreDefabrica"].ToString();
                lblFabrica.Text = rcd["Fabrica"].ToString();
                lblDepartamento.Text = rcd["Departamento"].ToString();
            }
        }

        private void departamento(string numDepartamento)
        {
            SqlConnection cnx = new SqlConnection(cnn.db);
            cnx.Open();

            string stQuery = "SELECT nombredepartamento FROM DEPARTAMENTO WHERE IDDEPARTAMENTO = @A1";

            SqlCommand cmd = new SqlCommand(stQuery, cnx);   // enviamos el script al motor de SQL
            cmd.Parameters.AddWithValue("@A1", numDepartamento); // Declaro la variable y le asigno su valor correspondiente
            SqlDataReader rcd = cmd.ExecuteReader();  // ejecuta el script que le enviamos

            if (rcd.Read())  // aqui pregunta HasRow = true
            {
                lblDepartamento.Text = rcd[""].ToString();
            }
        }

        private void Fabrica(string numFabrica)
        {
            SqlConnection cnx = new SqlConnection(cnn.db);
            cnx.Open();

            string stQuery = "SELECT nombrefabrica FROM FABRICA WHERE IDFABRICA = @A1";

            SqlCommand cmd = new SqlCommand(stQuery, cnx);   // enviamos el script al motor de SQL
            cmd.Parameters.AddWithValue("@A1", numFabrica); // Declaro la variable y le asigno su valor correspondiente
            SqlDataReader rcd = cmd.ExecuteReader();  // ejecuta el script que le enviamos

            if (rcd.Read())  // aqui pregunta HasRow = true
            {
                lblFabrica.Text = rcd[""].ToString();
            }
        }

        private void txtPosicion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFabrica_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
