using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using REGRA_NEGOCIOS;

namespace CONTROLE.OTICA
{
    public partial class frmEntrada : Form
    {
        frmPrincipal frmPrincipal;

        public frmEntrada(frmPrincipal fPrincipal, string usuarioLogado)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.dgvSaida.AutoGenerateColumns = false;
            this.dgvSaida.RowTemplate.Height = 70;

        }

        PedidoRegraNegocios pedidoRegraNegocios;

        private void frmEntrada_Load(object sender, EventArgs e)
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

                dadosTabela = pedidoRegraNegocios.PesquisarPedidoAberto(txtPesquisar.Text, "1 - ENTRADA");

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

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            PesquisarPedido();
        }

        public string EsfODLonge, EsfODPerto, EsfOELonge, EsfOEPerto = "";
        public string CiliODLonge, CiliOELonge, CiliODPerto, CiliOEPerto = "";
        public string EixoODLonge, EixoOElonge, EixoOEPerto, EixoODPerto = "";
        public string DpODLonge, DpOELonge, DpODPerto, DpOEPerto = "";

        private void dgvSaida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int numPedido = Convert.ToInt32(dgvSaida.Rows[e.RowIndex].Cells["colNumSaida"].Value.ToString());
                string nome = dgvSaida.Rows[e.RowIndex].Cells["colNome"].Value.ToString().Trim();
                string email = dgvSaida.Rows[e.RowIndex].Cells["colEmail"].Value.ToString().Trim();
                string tel = dgvSaida.Rows[e.RowIndex].Cells["colTelefone"].Value.ToString().Trim();

                EsfODLonge = dgvSaida.Rows[e.RowIndex].Cells["colEsfODLonge"].Value.ToString().Trim();
                EsfODPerto = dgvSaida.Rows[e.RowIndex].Cells["colEsfODPerto"].Value.ToString().Trim();
                EsfOELonge = dgvSaida.Rows[e.RowIndex].Cells["colEsfOELonge"].Value.ToString().Trim();
                EsfOEPerto = dgvSaida.Rows[e.RowIndex].Cells["colEsfOEPerto"].Value.ToString().Trim();

                CiliODLonge = dgvSaida.Rows[e.RowIndex].Cells["colCiliODLonge"].Value.ToString().Trim();
                CiliOELonge = dgvSaida.Rows[e.RowIndex].Cells["colCiliOELonge"].Value.ToString().Trim();
                CiliODPerto = dgvSaida.Rows[e.RowIndex].Cells["colCiliODPerto"].Value.ToString().Trim();
                CiliOEPerto = dgvSaida.Rows[e.RowIndex].Cells["colCiliODPerto"].Value.ToString().Trim();

                EixoODLonge = dgvSaida.Rows[e.RowIndex].Cells["colEixoODLonge"].Value.ToString().Trim();
                EixoOElonge = dgvSaida.Rows[e.RowIndex].Cells["colEixoOELonge"].Value.ToString().Trim();
                EixoOEPerto = dgvSaida.Rows[e.RowIndex].Cells["colEixoOELonge"].Value.ToString().Trim();
                EixoODPerto = dgvSaida.Rows[e.RowIndex].Cells["colEixoOEPerto"].Value.ToString().Trim();

                DpODLonge = dgvSaida.Rows[e.RowIndex].Cells["colDpODLonge"].Value.ToString().Trim();
                DpOELonge = dgvSaida.Rows[e.RowIndex].Cells["colDPOELonge"].Value.ToString().Trim();
                DpODPerto = dgvSaida.Rows[e.RowIndex].Cells["colDPODPerto"].Value.ToString().Trim();
                DpOEPerto = dgvSaida.Rows[e.RowIndex].Cells["colDpOEPerto"].Value.ToString().Trim();

                frmSaidaPedido frmSaidaPedido = new frmSaidaPedido(numPedido, nome, email, tel, frmPrincipal.idUsuario, EsfODLonge, EsfODPerto, EsfOELonge, EsfOEPerto, CiliODLonge, CiliOELonge, CiliODPerto, CiliOEPerto, EixoODLonge, EixoOElonge, EixoOEPerto, EixoODPerto, DpODLonge, DpOELonge, DpODPerto, DpOEPerto, this);
                frmSaidaPedido.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
