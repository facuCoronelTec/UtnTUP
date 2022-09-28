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
    public partial class FrmConsultarRecetas : Form
    {
        
        Gestor Gestor;
        public FrmConsultarRecetas()
        {
            InitializeComponent();
            Gestor = new Gestor();
        }

        private void cboTipoReceta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCombo();
        }


        //metodos 

        private void CargarCombo()
        {
            DataTable tabla = Gestor.ListarTipoReceta();
            cboTipoReceta.DataSource = tabla;
            cboTipoReceta.ValueMember = tabla.Columns[0].ColumnName;
            cboTipoReceta.ValueMember = tabla.Columns[1].ColumnName;
            cboTipoReceta.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AltaReceta alta = new AltaReceta();
            alta.Show();
        }
    }
}
