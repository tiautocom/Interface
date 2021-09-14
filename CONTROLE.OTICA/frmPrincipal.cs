using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;
using System.IO;

namespace CONTROLE.OTICA
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal(int idUsuario, string userLog)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            this.usuarioLogado = userLog.Trim();
        }

        public string path = Path.GetDirectoryName(Application.ExecutablePath);

        PedidoRegraNegocios pedidoRegraNegocios;

        public int numPedido = 0;
        public int idCliente, idUsuario = 0;
        public string nomeCliente, emailCliente, TelefoneCliente, usuarioLogado = "";

        private void btnPesquisarClientes_Click(object sender, EventArgs e)
        {
            frmCadCliente frmCadCliente = new frmCadCliente(this);
            frmCadCliente.ShowDialog();
        }

        private void tsmClientes_Click(object sender, EventArgs e)
        {
            frmCadCliente frmCadCliente = new frmCadCliente(this);
            frmCadCliente.ShowDialog();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            PesquisarPedido();
            GetDados();
        }

        public void GetDados()
        {
            lblUsuarioLogado.Text = usuarioLogado.Trim();
            lblCodigo.Text = idUsuario.ToString().Trim().PadLeft(3, '0');
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            frmSaida frmSaida = new frmSaida(this);
            frmSaida.ShowDialog();
        }

        private void btnCadProduto_Click(object sender, EventArgs e)
        {
            frmCadProduto frmCadProduto = new frmCadProduto();
            frmCadProduto.ShowDialog();
        }

        private void produtosCtrl3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCadProduto_Click(sender, e);
        }

        private void pRODUTOESTOQUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorioEstoque frmRelatorioEstoque = new frmRelatorioEstoque();
            frmRelatorioEstoque.ShowDialog();
        }

        public void PesquisarPedido()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                pedidoRegraNegocios = new PedidoRegraNegocios();

                dadosTabela = pedidoRegraNegocios.PesquisarNumPedido();

                if (dadosTabela.Rows.Count > 0)
                {
                    numPedido = Convert.ToInt32(dadosTabela.Rows[0]["NUMERO"].ToString());
                }
                else
                {
                    numPedido = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPesquisarClientes frmPesquisarClientes = new frmPesquisarClientes(this);
            frmPesquisarClientes.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPedidoSaida frmPedidoSaida = new frmPedidoSaida();
            frmPedidoSaida.ShowDialog();
        }

        public void LimparDados()
        {
            idCliente = 0;
            nomeCliente = "";
            emailCliente = "";
            TelefoneCliente = "";
        }
    }
}
