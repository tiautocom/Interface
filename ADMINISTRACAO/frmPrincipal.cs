using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMINISTRACAO
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public int idUsuario = 0;

        private void pRODUTOSCtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadProduto frmCadProduto = new frmCadProduto(this);
            frmCadProduto.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmRelatorioVendas frmRelatorioVendas = new frmRelatorioVendas(this);
            frmRelatorioVendas.ShowDialog();
        }

        private void uSUÁRIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadUsuarios frmCadUsuarios = new frmCadUsuarios(this);
            frmCadUsuarios.ShowDialog();
        }

        private void tipoDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoUsuario frmTipoUsuario = new frmTipoUsuario(this);
            frmTipoUsuario.ShowDialog();
        }

        private void cLIENTESCtrl2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadClientes frmCadClientes = new frmCadClientes(this);
            frmCadClientes.ShowDialog();
        }

        private void setorCtrl5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadSetor frmCadSetor = new frmCadSetor(this);
            frmCadSetor.Show();
        }

        private void uNIDADEPRODUTOCtrl6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadUnidades frmCadUnidades = new frmCadUnidades(this);
            frmCadUnidades.ShowDialog();
        }

        private void dEPARTAMENTOSCtrl7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadDepartamentos frmCadDepartamentos = new frmCadDepartamentos(this);
            frmCadDepartamentos.ShowDialog();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Realmente Deseja Mudar o Login ???", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmLogin login = new frmLogin(this);
                    login.ShowDialog();

                    if (login.DialogResult == DialogResult.OK)
                    {
                        idUsuario = login.idUsuario;

                        this.OnLoad(e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
