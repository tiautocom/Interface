using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAT
{
    public partial class frmListarCancelarItem : Form
    {
        public frmListarCancelarItem(DataTable dados)
        {
            InitializeComponent();

            this.dadosTabela = dados;
            this.dgvVendas.AutoGenerateColumns = false;
        }

        DataTable dadosTabela = new DataTable();

        private void frmListarCancelarItem_Load(object sender, EventArgs e)
        {
            try
            {
                dgvVendas.DataSource = null;
                dgvVendas.DataSource = this.dadosTabela;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
