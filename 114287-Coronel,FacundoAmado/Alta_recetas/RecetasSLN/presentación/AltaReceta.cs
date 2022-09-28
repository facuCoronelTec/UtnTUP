using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecetasSLN.datos;
using RecetasSLN.dominio;
using RecetasSLN.Properties;



namespace RecetasSLN.presentación
{
    public partial class AltaReceta : Form
    {
        Receta NuevaReceta;
        Gestor gestor;
        public AltaReceta()
        {
            InitializeComponent();
            gestor = new Gestor();
            NuevaReceta = new Receta();
        }

        private void lblNro_Click(object sender, EventArgs e)
        {
            ProximaReceta();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCheff.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Chef", "Controls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCheff.Focus();
                return;
            }

            if (dgvDetalles.Rows.Count < 3)
            {
                MessageBox.Show("Debe ingresar 3 ingredientes como mínimo", "Controls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProducto.Focus();
                return;

            }
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Nombre", "Controls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return;
            }
            NuevaReceta.recetaNro = gestor.ProximaReceta();
            NuevaReceta.Nombre = txtNombre.Text;
            NuevaReceta.Cheff = txtCheff.Text;
            NuevaReceta.tipoReceta = Convert.ToInt32(cboTipo.SelectedIndex);
            if (gestor.EjecutarInsert(NuevaReceta))
            {
                MessageBox.Show("Receta guardada");
                LimpiarCampos();

            }
            else
            {
                MessageBox.Show("Receta NO guardada");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro que quiere salir?", "Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        //metodos

        private void ProximaReceta()
        {
            lblNro.Text = "Receta #: " + gestor.ProximaReceta();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtNombre.Focus();
            txtCheff.Text = string.Empty;
            cboTipo.Text = string.Empty;
            lblTotalIngredientes.Text = "Total Ingredientes:";
            dgvDetalles.Rows.Clear();

            UltimaReceta();


        }


        private void UltimaReceta()
        {
            lblNro.Text = "Receta #: " + gestor.ProximaReceta();
        }


    }
}
