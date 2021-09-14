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

namespace ADM.CADASTRO
{
    public partial class frmProdutos : Form
    {
        frmPrincipal frmPrincipal;

        public frmProdutos(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;

            this.gdvProduto.AutoGenerateColumns = false;
        }

        ProdutoRegraNegocios produtoRegraNegocios;
        DepartamentoRegraNegocios departamentoRegraNegocios;

        public int ultCodInterno = 0;
        public int idDepartamento = 0;

        private void btnComposto_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblOrigem_Click(object sender, EventArgs e)
        {

        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            LoadTela();
        }

        public void LoadTela()
        {
            PesquisarCodigoInterno();
            PesquisarDepartamentos();
        }

        public int descricao = 0;

        public void PesquisarProdutoAll()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                produtoRegraNegocios = new ProdutoRegraNegocios();

                try
                {
                    descricao = Convert.ToInt32(txtPesquisaProdutoDesc.Text);

                    dadosTabela = produtoRegraNegocios.PesquisarCodBarrasProd(descricao.ToString());
                }
                catch
                {
                    dadosTabela = produtoRegraNegocios.PesquisarDescricao(descricao.ToString());
                }

                if (dadosTabela.Rows.Count > 0)
                {
                    gdvProduto.DataSource = null;
                    gdvProduto.DataSource = dadosTabela;
                }
                else
                {
                    gdvProduto.DataSource = null;
                }

                lblQtdeProduto.Text = gdvProduto.Rows.Count.ToString().PadLeft(6, '0');
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarCodigoInterno()
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                produtoRegraNegocios = new ProdutoRegraNegocios();

                dadosTabela = produtoRegraNegocios.PesquisarCodigoInterno();

                if (dadosTabela.Rows.Count > 0)
                {
                    ultCodInterno = Convert.ToInt32(dadosTabela.Rows[0]["COD_INT"].ToString().Trim()) + 1;
                }

                txtCodBarra.Text = ultCodInterno.ToString().PadLeft(13, '0');

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarDepartamentos()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = departamentoRegraNegocios.CarreagarComboDepartamento();

                if (dadosTabela.Rows.Count > 0)
                {
                    cbDepartamento.DataSource = null;
                    cbDepartamento.DataSource = dadosTabela;

                    cbDepartamento.ValueMember = "ID";
                    cbDepartamento.DisplayMember = "DESCRICAO";

                    cbPesquisar1.DataSource = null;
                    cbPesquisar1.DataSource = dadosTabela;

                    cbPesquisar1.ValueMember = "ID";
                    cbPesquisar1.DisplayMember = "DESCRICAO";
                }
                else
                {
                    cbDepartamento.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNovoDepartamento_Click(object sender, EventArgs e)
        {
            CADASTRO.Departametos frmDeparatmento = new Departametos(frmPrincipal);
            frmDeparatmento.ShowDialog();
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtNumDep.Text = cbDepartamento.SelectedValue.ToString();

                idDepartamento = Convert.ToInt32(txtNumDep.Text);

                if (idDepartamento > 0)
                {
                    PesquisarDepartamentoId();
                }
            }
            catch
            {
                txtNumDep.Text = "0";
            }
        }

        public void PesquisarDepartamentoId()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = departamentoRegraNegocios.PesquisarEstoqueDepartamentoId(idDepartamento);

                if (dadosTabela.Rows.Count > 0)
                {
                    cbNcm.Text = dadosTabela.Rows[0]["NCM"].ToString().Trim();
                    txtCest.Text = dadosTabela.Rows[0]["CEST"].ToString().Trim();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPesquisaProdutoDesc_TextChanged(object sender, EventArgs e)
        {
            PesquisarProdutoAll();
        }
    }
}
