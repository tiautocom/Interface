using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADM
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void tsmProdutos_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CADASTRO.frmProdutos frmCadProdutos = new CADASTRO.frmProdutos(this);
            frmCadProdutos.ShowDialog();
        }

        private void cadaastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CADASTRO.Departametos frmDepartamento = new CADASTRO.Departametos(this);
            frmDepartamento.ShowDialog();
        }
    }
}
