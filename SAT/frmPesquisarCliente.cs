using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using REGRA_NEGOCIOS;
using OBJETO_TRANSFERENCIA;

namespace SAT
{
    public partial class frmPesquisarCliente : Form
    {
        frmFechamentoVenda frmFechamentoVenda;

        public frmPesquisarCliente(frmFechamentoVenda fFechamentoVenda)
        {
            InitializeComponent();

            gdvCliente.AutoGenerateColumns = false;

            this.frmFechamentoVenda = fFechamentoVenda;
            this.debitoCliente = frmFechamentoVenda.valorAberto;
            this.gdvCliente.RowTemplate.Height = 30;
        }

        #region CLASSES E OBJETOS

        ClienteC clienteC = new ClienteC();
        ClienteRegraNegocios clienteRegraNegocios = new ClienteRegraNegocios();

        #endregion

        #region VARIAVEIS

        string nome, rgIe, CpfCnpj, telefone = "";
        public decimal valorVenda = 0;

        public decimal debitoCliente = 0;

        #endregion

        private void frmPesquisarCliente_Load(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        public void PesquisarCliente()
        {
            try
            {
                clienteRegraNegocios = new ClienteRegraNegocios();
                DataTable dadosTabelaCliente = new DataTable();

                nome = txtPesquisa.Text.Trim();

                dadosTabelaCliente = clienteRegraNegocios.PesquisarCliente(nome);

                if (dadosTabelaCliente.Rows.Count > 0)
                {
                    gdvCliente.DataSource = null;
                    gdvCliente.DataSource = dadosTabelaCliente;

                    decimal limite = 0;
                    decimal gasto = 0;

                    for (int i = 0; i < gdvCliente.Rows.Count; i++)
                    {
                        try
                        {
                            limite = Convert.ToDecimal(gdvCliente.Rows[i].Cells["LIMITE"].Value.ToString());
                        }
                        catch
                        {
                            limite = 0;
                        }
                        try
                        {
                            gasto = Convert.ToDecimal(gdvCliente.Rows[i].Cells["GASTO"].Value.ToString());
                        }
                        catch
                        {
                            gasto = 0;
                        }

                        if (gasto > limite)
                        {
                            gdvCliente.Rows[i].Cells["colstatus"].Value = "NÃO AUTORIZADO";
                        }
                        else
                        {
                            gdvCliente.Rows[i].Cells["colstatus"].Value = "AUTORIZADO";
                        }
                    }

                    lblTotalCliente.Text = gdvCliente.Rows.Count.ToString().Trim().PadLeft(3, '0');
                }
                else
                {
                    gdvCliente.DataSource = null;

                    lblTotalCliente.Text = "000";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarClienteRg()
        {
            try
            {
                clienteRegraNegocios = new ClienteRegraNegocios();
                DataTable dadosTabelaCliente = new DataTable();

                rgIe = txtPesquisa.Text.Trim();

                dadosTabelaCliente = clienteRegraNegocios.PesquisarClienteRg(rgIe);

                if (dadosTabelaCliente.Rows.Count > 0)
                {
                    gdvCliente.DataSource = null;
                    gdvCliente.DataSource = dadosTabelaCliente;

                    lblTotalCliente.Text = gdvCliente.Rows.Count.ToString().Trim().PadLeft(3, '0');
                }
                else
                {
                    gdvCliente.DataSource = null;
                    lblTotalCliente.Text = "000";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarCpjCnpj()
        {
            try
            {
                clienteRegraNegocios = new ClienteRegraNegocios();
                DataTable dadosTabelaCliente = new DataTable();

                CpfCnpj = txtPesquisa.Text.Trim();

                dadosTabelaCliente = clienteRegraNegocios.PesquisarCpjCnpj(CpfCnpj);

                if (dadosTabelaCliente.Rows.Count > 0)
                {
                    gdvCliente.DataSource = null;
                    gdvCliente.DataSource = dadosTabelaCliente;

                    lblTotalCliente.Text = gdvCliente.Rows.Count.ToString().Trim().PadLeft(3, '0');
                }
                else
                {
                    gdvCliente.DataSource = null;
                    lblTotalCliente.Text = "000";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void PesquisarClienteTelefone()
        {
            try
            {
                clienteRegraNegocios = new ClienteRegraNegocios();
                DataTable dadosTabelaCliente = new DataTable();

                telefone = txtPesquisa.Text.Trim();

                dadosTabelaCliente = clienteRegraNegocios.PesquisarClienteTelefone(telefone);

                if (dadosTabelaCliente.Rows.Count > 0)
                {
                    gdvCliente.DataSource = null;
                    gdvCliente.DataSource = dadosTabelaCliente;

                    lblTotalCliente.Text = gdvCliente.Rows.Count.ToString().Trim().PadLeft(3, '0');
                }
                else
                {
                    gdvCliente.DataSource = null;
                    lblTotalCliente.Text = "000";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void gdvCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Realmente Deseja Selecionar Cliente: " + gdvCliente.Rows[e.RowIndex].Cells["FANTASIA"].Value.ToString().Trim() + "???", "Confirmação do Cliente Selecionado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmFechamentoVenda._idCliente = frmFechamentoVenda.idCliente = Convert.ToInt32(gdvCliente.Rows[e.RowIndex].Cells["CLIENTE_ID"].Value.ToString());
                    frmFechamentoVenda.nomeCliente = gdvCliente.Rows[e.RowIndex].Cells["FANTASIA"].Value.ToString() ?? null ?? "";
                    frmFechamentoVenda.cnpjCliente = gdvCliente.Rows[e.RowIndex].Cells["CPF_CNPJ"].Value.ToString() ?? null ?? "";
                    frmFechamentoVenda.limiteCliente = Convert.ToDecimal(gdvCliente.Rows[e.RowIndex].Cells["LIMITE"].Value.ToString() ?? null ?? "0,00");
                    frmFechamentoVenda.gastoCliente = Convert.ToDecimal(gdvCliente.Rows[e.RowIndex].Cells["GASTO"].Value.ToString() ?? null ?? "0,00");

                    frmFechamentoVenda.PesquidarTipoPagamentoAberto();

                    frmFechamentoVenda.btnFecharVenda_Click(sender, e);

                    this.Close();
                }
                else
                {
                    txtPesquisa.Focus();
                    txtPesquisa.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Down)
            {
                gdvCliente.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                gdvCliente.Focus();
            }
        }

        private void gdvCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal gasto = 0;

                try
                {
                    int n = Convert.ToInt32(gdvCliente.CurrentRow.Index);

                    if (MessageBox.Show("Realmente Deseja Selecionar Cliente: " + gdvCliente.Rows[n].Cells["FANTASIA"].Value.ToString().Trim() + "???", "Confirmação do Cliente Selecionado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        try
                        {
                            frmFechamentoVenda.valorDebitoCliente = Convert.ToDecimal(gdvCliente.Rows[n].Cells["LIMITE"].Value.ToString());
                        }
                        catch
                        {
                            frmFechamentoVenda.valorDebitoCliente = 0;
                        }

                        try
                        {
                            gasto = Convert.ToDecimal(gdvCliente.Rows[n].Cells["GASTO"].Value.ToString() ?? "0");
                        }
                        catch
                        {
                            gasto = 0;
                        }

                        decimal valor = (gasto + frmFechamentoVenda.valorAberto);

                        if (valor <= frmFechamentoVenda.valorDebitoCliente)
                        {
                            frmFechamentoVenda._idCliente = frmFechamentoVenda.idCliente = Convert.ToInt32(gdvCliente.Rows[n].Cells["CLIENTE_ID"].Value.ToString());
                            frmFechamentoVenda.nomeCliente = gdvCliente.Rows[n].Cells["FANTASIA"].Value.ToString().Trim();
                            frmFechamentoVenda.cnpjCliente = gdvCliente.Rows[n].Cells["CPF_CNPJ"].Value.ToString() ?? null ?? "";
                            frmFechamentoVenda.limiteCliente = Convert.ToDecimal(gdvCliente.Rows[n].Cells["LIMITE"].Value.ToString() ?? null ?? "0,00");
                            frmFechamentoVenda.gastoCliente = Convert.ToDecimal(gdvCliente.Rows[n].Cells["GASTO"].Value.ToString() ?? null ?? "0,00");

                            frmFechamentoVenda.PesquidarTipoPagamentoAberto();

                            frmFechamentoVenda.btnFecharVenda_Click(sender, e);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("LIMITE DO CLIENTE: " + gdvCliente.Rows[n].Cells["FANTASIA"].Value.ToString().Trim() + "\nESTÁ ACIMA DO VALOR PERMITIDO.\n\n\nVALOR DO LIMITE: " + frmFechamentoVenda.valorDebitoCliente.ToString("C3") + ".\n\nVALOR GASTO: " + Convert.ToDecimal(gdvCliente.Rows[n].Cells["GASTO"].Value.ToString()).ToString("C2"), "VENDA NÃO REALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            frmFechamentoVenda._idCliente = 0;
                        }

                        this.Refresh();
                        this.Close();
                    }
                    else
                    {
                        txtPesquisa.Focus();
                        txtPesquisa.SelectAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                txtPesquisa.Text = "";
                txtPesquisa.Focus();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (rbNome.Checked == true)
            {
                PesquisarCliente();
            }
            else if (rbRgIe.Checked == true)
            {
                PesquisarClienteRg();
            }
            else if (rbCpf.Checked == true)
            {
                PesquisarCpjCnpj();
            }
            else if (rbTelefone.Checked == true)
            {
                PesquisarClienteTelefone();
            }
        }

        private void rbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            txtPesquisa.Focus();
        }

        private void gdvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbCpf_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            txtPesquisa.Focus();
        }

        private void rbRgIe_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            txtPesquisa.Focus();
        }

        private void rbTelefone_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            txtPesquisa.Focus();
        }
    }
}
