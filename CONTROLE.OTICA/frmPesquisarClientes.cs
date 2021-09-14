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
    public partial class frmPesquisarClientes : Form
    {
        frmPrincipal frmPrincipal;

        public frmPesquisarClientes(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;
            this.dgvClientes.AutoGenerateColumns = false;
            this.dgvClientes.RowTemplate.Height = 50;
        }

        ClienteRegraNegocios clienteRegraNegocios;

        public int tag = 0;
        public int idCliente = 0;
        public string nomeCliente, email, tel = "";

        private void btnPEsquisarNome_Click(object sender, EventArgs e)
        {
            lblDadosPesquisa.Text = "DADOS DE PESQUISA NOME";

            tag = 1;

            txtPesquisar.Text = "";
            txtPesquisar.Focus();
            txtPesquisar.SelectAll();
        }

        private void btnPesquisarCpfCnpj_Click(object sender, EventArgs e)
        {
            lblDadosPesquisa.Text = "DADOS DE PESQUISA CPF/CNPJ";

            tag = 2;

            txtPesquisar.Text = "";
            txtPesquisar.Focus();
            txtPesquisar.SelectAll();
        }

        private void btnPesquisarEmail_Click(object sender, EventArgs e)
        {
            lblDadosPesquisa.Text = "DADOS DE PESQUISA E-MAIL";

            tag = 3;

            txtPesquisar.Text = "";
            txtPesquisar.Focus();
            txtPesquisar.SelectAll();
        }

        private void btnPEsquisarCelular_Click(object sender, EventArgs e)
        {
            lblDadosPesquisa.Text = "DADOS DE PESQUISA CELULAR";

            tag = 4;

            txtPesquisar.Text = "";
            txtPesquisar.Focus();
            txtPesquisar.SelectAll();
        }

        private void frmPesquisarClientes_Load(object sender, EventArgs e)
        {
            tag = 1;

            Pesquisar();
        }

        public void Pesquisar()
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                clienteRegraNegocios = new ClienteRegraNegocios();

                if (tag == 1)
                {
                    dadosTabela = clienteRegraNegocios.PesquisarCliente(txtPesquisar.Text);
                }
                else if (tag == 2)
                {
                    dadosTabela = clienteRegraNegocios.PesquisarCpjCnpj(txtPesquisar.Text);
                }
                else if (tag == 3)
                {
                    dadosTabela = clienteRegraNegocios.PesquisarEmail(txtPesquisar.Text);
                }
                else if (tag == 4)
                {
                    dadosTabela = clienteRegraNegocios.PesquisarClienteTelefone(txtPesquisar.Text);
                }
                else if (tag == 5)
                {
                    dadosTabela = clienteRegraNegocios.PesquisarClienteId(idCliente);
                }

                if (dadosTabela.Rows.Count > 0)
                {
                    dgvClientes.DataSource = null;
                    dgvClientes.DataSource = dadosTabela;
                }
                else
                {
                    dgvClientes.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tag = 5;

            frmPrincipal.LimparDados();

            frmCadCliente frmCadCliente = new frmCadCliente(frmPrincipal);
            frmCadCliente.ShowDialog();

            if (frmPrincipal.idCliente > 0)
            {
                frmPedido frmPedido = new frmPedido(frmPrincipal, idCliente, nomeCliente, tel, email, 0);
                frmPedido.ShowDialog();

                OnLoad(e);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvClientes.Columns[e.ColumnIndex].Name.Trim().Equals("colReceitas"))
                {
                    idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["colIdCliente"].Value.ToString());
                    nomeCliente = dgvClientes.Rows[e.RowIndex].Cells["colNomeRazao"].Value.ToString().Trim();
                    tel = dgvClientes.Rows[e.RowIndex].Cells["colTel"].Value.ToString().Trim();
                    email = dgvClientes.Rows[e.RowIndex].Cells["colEmail"].Value.ToString().Trim();

                    frmPedido frmPedido = new frmPedido(frmPrincipal, idCliente, nomeCliente, tel, email, 0);
                    frmPedido.ShowDialog();
                }

                if (dgvClientes.Columns[e.ColumnIndex].Name.Trim().Equals("colDetalhes"))
                {
                    idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["colIdCliente"].Value.ToString());

                    frmClienteDetalhes frmClienteDetalhes = new frmClienteDetalhes(idCliente, frmPrincipal);
                    frmClienteDetalhes.ShowDialog();
                }

                txtPesquisar.Text = "";
                txtPesquisar.Focus();
                txtPesquisar.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
