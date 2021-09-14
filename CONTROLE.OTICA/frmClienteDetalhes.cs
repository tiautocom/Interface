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
    public partial class frmClienteDetalhes : Form
    {
        frmPrincipal frmPrincipal;

        public frmClienteDetalhes(int idCliente, frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;
            this.idCliente = idCliente;
            this.dgvPedidos.AutoGenerateColumns = false;
            this.dgvPedidos.RowTemplate.Height = 50;
        }

        public int idCliente, idPed = 0;
        public string nomeCliente, email, telefone = "";

        PedidoRegraNegocios pedidoRegraNegocios;
        ClienteRegraNegocios clienteRegraNegocios;

        public void PesquisarClienteId()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                pedidoRegraNegocios = new PedidoRegraNegocios();

                dadosTabela = pedidoRegraNegocios.PesquisarPedidoIdCliente(idCliente);

                if (dadosTabela.Rows.Count > 0)
                {
                    txtNomeMedico.Text = dadosTabela.Rows[0]["MEDICO"].ToString().Trim();
                    txtCrmMedico.Text = dadosTabela.Rows[0]["CRM"].ToString().Trim();
                    txtTelMedico.Text = dadosTabela.Rows[0]["TEL_MEDICO"].ToString().Trim();

                    dgvPedidos.DataSource = null;
                    dgvPedidos.DataSource = dadosTabela;
                }
                else
                {
                    dgvPedidos.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarDadosCliente()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                clienteRegraNegocios = new ClienteRegraNegocios();

                dadosTabela = clienteRegraNegocios.PesquisarClienteId(idCliente);

                if (dadosTabela.Rows.Count > 0)
                {
                    txtNome.Text = dadosTabela.Rows[0]["NOME"].ToString().Trim();
                    txtCpf_Cnpj.Text = dadosTabela.Rows[0]["CPF_CNPJ"].ToString().Trim();
                    txtRg_Ie.Text = dadosTabela.Rows[0]["RG_INSC_EST"].ToString().Trim();
                    txtDtNasc.Text = dadosTabela.Rows[0]["DT_NASC"].ToString().Trim();
                    txtEmail.Text = dadosTabela.Rows[0]["EMAIL"].ToString().Trim();
                    telefone = dadosTabela.Rows[0]["TELEFONE3"].ToString().Trim();
                    txtTelefone1.Text = dadosTabela.Rows[0]["TELEFONE2"].ToString().Trim();
                    txtCelular.Text = dadosTabela.Rows[0]["TELEFONE"].ToString().Trim();
                    txtApelido.Text = dadosTabela.Rows[0]["APELIDO_FANTAZIA"].ToString().Trim();

                    txtEndereco.Text = dadosTabela.Rows[0]["LOGRADOURO"].ToString().Trim();
                    txtNumero.Text = dadosTabela.Rows[0]["NUM"].ToString().Trim();
                    txtCep.Text = dadosTabela.Rows[0]["CEP"].ToString().Trim();
                    txtBairro.Text = dadosTabela.Rows[0]["BAIRO"].ToString().Trim();
                    txtCidade.Text = dadosTabela.Rows[0]["CIDADE"].ToString().Trim();
                    cbUF.Text = dadosTabela.Rows[0]["UF"].ToString().Trim();
                    txtComplemento.Text = dadosTabela.Rows[0]["COMPLEMENTO"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            frmPedido frmPedido = new frmPedido(frmPrincipal, idCliente, txtNome.Text.Trim(), txtCelular.Text.Trim(), txtEmail.Text.Trim(), idPed);
            frmPedido.ShowDialog();

            this.OnLoad(e);
        }

        private void txtCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void frmClienteDetalhes_Load(object sender, EventArgs e)
        {
            PesquisarClienteId();
            PesquisarDadosCliente();
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPedidos.Columns[e.ColumnIndex].Name.Trim().Equals("colReceita"))
            {
                if (dgvPedidos.Rows[e.RowIndex].Cells["colUrl"].Value.ToString().Trim() != "")
                {
                    System.Diagnostics.Process.Start(dgvPedidos.Rows[e.RowIndex].Cells["colUrl"].Value.ToString().Trim());
                }
                else
                {
                    MessageBox.Show("Não Contém Receita Anexada para ser Exibido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (dgvPedidos.Columns[e.ColumnIndex].Name.Trim().Equals("colSel"))
            {
                idCliente = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["colIdCliente"].Value.ToString());
                idPed = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["colId"].Value.ToString());

                frmPedido frmPedido = new frmPedido(frmPrincipal, idCliente, txtNome.Text.Trim(), txtCelular.Text.Trim(), txtEmail.Text.Trim(), idPed);
                frmPedido.ShowDialog();
            }
        }
    }
}
