using REGRA_NEGOCIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONTROLE.OTICA
{
    public partial class frmSaida : Form
    {
        frmPrincipal frmPrincipal;

        public frmSaida(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.dgvSaida.AutoGenerateColumns = false;
            this.dgvSaida.RowTemplate.Height = 70;
        }

        PedidoRegraNegocios pedidoRegraNegocios;

        private void frmSaida_Load(object sender, EventArgs e)
        {
            txtDataHora.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtUsuarioLogado.Text = frmPrincipal.usuarioLogado.Trim();

            PesquisarPedido();
        }

        public void PesquisarPedido()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                pedidoRegraNegocios = new PedidoRegraNegocios();

                dadosTabela = pedidoRegraNegocios.PesquisarPedidoAberto(txtPesquisar.Text, "2 - SAIDA");

                if (dadosTabela.Rows.Count > 0)
                {
                    dgvSaida.DataSource = null;
                    dgvSaida.DataSource = dadosTabela;
                }
                else
                {
                    dgvSaida.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
