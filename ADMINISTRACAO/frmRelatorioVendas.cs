using OBJETO_TRANSFERENCIA;
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

namespace ADMINISTRACAO
{
    public partial class frmRelatorioVendas : Form
    {
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

        frmPrincipal frmPrincipal;

        public frmRelatorioVendas(frmPrincipal fPrincipal)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;
        }

        #region VARIAVEIS

        public string dtIni, dtFim = "";
        public decimal somatotal = 0;

        public int tipoPesquisaRel = 0;
        public int idUsuario = 0;
        public bool autBroupBy = true;
        public int tipoAgrupado = 0;

        #endregion

        #region CLASSES E OBJETOS

        VendaC venda = new VendaC();
        VendaRegraNegocios vendaRegraNegocios;
        UsuarioRegraNegocios usuarioRegraNegocios;

        #endregion

        private void frmRelatorioVendas_Load(object sender, EventArgs e)
        {
            PesquisaRelatorioGeral();

            ListarUsuarios();
        }

        private void btnGerarRelatorios_Click(object sender, EventArgs e)
        {
            PesquisarVendaRelatorios();
        }

        public void ListarUsuarios()
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                usuarioRegraNegocios = new UsuarioRegraNegocios();

                dadosTabela = usuarioRegraNegocios.ListarUsuariosAll();

                if (dadosTabela.Rows.Count > 0)
                {
                    cbUsuario.DataSource = null;
                    cbUsuario.DataSource = dadosTabela;
                    cbUsuario.DisplayMember = "NOME";
                    cbUsuario.ValueMember = "ID_USUARIO";
                }
                else
                {
                    cbUsuario.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarVendaRelatorios()
        {
            try
            {
                dtIni = txtDtInici.Text.Trim();
                dtFim = txtDtFim.Text.Trim();

                somatotal = 0;

                dtIni = dtIni.Replace("/", "");
                dtFim = dtFim.Replace("/", "");

                if (dtIni.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Inicio não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtInici.Focus();
                }
                else if (dtFim.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Fim não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtFim.Focus();
                }
                else
                {
                    dtIni = txtDtInici.Text.Trim();
                    dtFim = txtDtFim.Text.Trim();

                    tipoPesquisaRel = Convert.ToInt32(cbTipoRelatorios.Text.Substring(0, 2).Trim());

                    vendaRegraNegocios = new VendaRegraNegocios();

                    DataTable dadosTabela = new DataTable();

                    dadosTabela = vendaRegraNegocios.PesquisarVendaRelatorios(dtIni, dtFim, tipoPesquisaRel);

                    if (dadosTabela.Rows.Count > 0)
                    {
                        dgvPesquisaVendas.DataSource = dadosTabela;

                        for (int i = 0; i < dadosTabela.Rows.Count; i++)
                        {
                            somatotal += Convert.ToDecimal(dadosTabela.Rows[i]["TOTAL"].ToString());
                        }
                    }
                    else
                    {
                        dgvPesquisaVendas.DataSource = null;
                    }

                    txtTotal.Text = somatotal.ToString("C2");

                    lblQtde.Text = dgvPesquisaVendas.Rows.Count.ToString().PadLeft(5, '0');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detalhes: " + ex.Message, "Erro Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PesquisarVendaUsuarios()
        {
            try
            {
                dtIni = txtDtInici.Text.Trim();
                dtFim = txtDtFim.Text.Trim();

                somatotal = 0;

                dtIni = dtIni.Replace("/", "");
                dtFim = dtFim.Replace("/", "");

                if (dtIni.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Inicio não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtInici.Focus();
                }
                else if (dtFim.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Fim não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtFim.Focus();
                }
                else
                {
                    vendaRegraNegocios = new VendaRegraNegocios();

                    DataTable dadosTabela = new DataTable();

                    dtIni = txtDtInici.Text.Trim();
                    dtFim = txtDtFim.Text.Trim();

                    var idUser = (int)cbUsuario.SelectedValue;

                    if (idUser > 0)
                    {
                        dadosTabela = vendaRegraNegocios.PesquisaVendaIdUsuario(dtIni, dtFim, idUser);

                        if (dadosTabela.Rows.Count > 0)
                        {
                            dgvPesquisaVendas.DataSource = dadosTabela;

                            for (int i = 0; i < dadosTabela.Rows.Count; i++)
                            {
                                somatotal += Convert.ToDecimal(dadosTabela.Rows[i]["TOTAL"].ToString());
                            }
                        }
                        else
                        {
                            dgvPesquisaVendas.DataSource = null;
                        }

                        txtTotal.Text = somatotal.ToString("C2");

                        lblQtde.Text = dgvPesquisaVendas.Rows.Count.ToString().PadLeft(10, '0');
                    }
                    else
                    {
                        MessageBox.Show("Selecione Usuário Desejado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        cbUsuario.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PesquisarVendaNumCaixas()
        {
            try
            {
                dtIni = txtDtInici.Text.Trim();
                dtFim = txtDtFim.Text.Trim();

                somatotal = 0;

                dtIni = dtIni.Replace("/", "");
                dtFim = dtFim.Replace("/", "");

                if (dtIni.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Inicio não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtInici.Focus();
                }
                else if (dtFim.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Fim não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtFim.Focus();
                }
                else
                {
                    vendaRegraNegocios = new VendaRegraNegocios();

                    DataTable dadosTabela = new DataTable();

                    dtIni = txtDtInici.Text.Trim();
                    dtFim = txtDtFim.Text.Trim();

                    int numCaixa = Convert.ToInt32(cbNumCaixa.Text);

                    if (numCaixa > 0)
                    {
                        dadosTabela = vendaRegraNegocios.PesquisaVendaNumCaixa(dtIni, dtFim, numCaixa);

                        if (dadosTabela.Rows.Count > 0)
                        {
                            dgvPesquisaVendas.DataSource = dadosTabela;

                            for (int i = 0; i < dadosTabela.Rows.Count; i++)
                            {
                                somatotal += Convert.ToDecimal(dadosTabela.Rows[i]["TOTAL"].ToString());
                            }
                        }
                        else
                        {
                            dgvPesquisaVendas.DataSource = null;
                        }

                        txtTotal.Text = somatotal.ToString("C2");

                        lblQtde.Text = dgvPesquisaVendas.Rows.Count.ToString().PadLeft(10, '0');
                    }
                    else
                    {
                        MessageBox.Show("Selecione numero da Caixa Desejado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        cbUsuario.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPesquisarGerais_Click(object sender, EventArgs e)
        {
            PesquisarVendaUsuarios();
        }

        private void btnPesquisarNumCAixa_Click(object sender, EventArgs e)
        {
            PesquisarVendaNumCaixas();
        }

        private void btnExportarDados_Click(object sender, EventArgs e)
        {
            ExportarDados();
        }

        public void ExportarDados()
        {
            try
            {
                if (cbImports.Text.Substring(0, 1).Trim().Equals("1"))
                {
                    ExportarExcel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportarExcel()
        {
            try
            {
                if (dgvPesquisaVendas.Rows.Count > 0)
                {
                    try
                    {
                        XcelApp.Application.Workbooks.Add(Type.Missing);

                        for (int i = 1; i < dgvPesquisaVendas.Columns.Count + 1; i++)
                        {
                            XcelApp.Cells[1, i] = dgvPesquisaVendas.Columns[i - 1].HeaderText;
                        }

                        for (int i = 0; i < dgvPesquisaVendas.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < dgvPesquisaVendas.Columns.Count; j++)
                            {
                                XcelApp.Cells[i + 2, j + 1] = dgvPesquisaVendas.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        XcelApp.Columns.AutoFit();

                        XcelApp.Visible = true;

                        MessageBox.Show("Dados Exportado em Excel com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro : " + ex.Message);

                        XcelApp.Quit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbGBDescricao_CheckedChanged(object sender, EventArgs e)
        {
            if (autBroupBy == true)
            {
                tipoAgrupado = 1;

                PesquisarDadosVendaAgrupados();
            }
        }

        public void PesquisaRelatorioGeral()
        {
            try
            {
                dtIni = txtDtInici.Text.Trim();
                dtFim = txtDtFim.Text.Trim();

                somatotal = 0;

                dtIni = Convert.ToDateTime(dtIni).ToString("yyyy-MM-dd");
                dtFim = Convert.ToDateTime(dtFim).ToString("yyyy-MM-dd");

                if (dtIni.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Inicio não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtInici.Focus();
                }
                else if (dtFim.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Fim não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtFim.Focus();
                }
                else
                {
                    dtIni = txtDtInici.Text.Trim();
                    dtFim = txtDtFim.Text.Trim();

                    vendaRegraNegocios = new VendaRegraNegocios();

                    DataTable dadosTabela = new DataTable();

                    dadosTabela = vendaRegraNegocios.PesquisaVenda(dtIni, dtFim);

                    if (dadosTabela.Rows.Count > 0)
                    {
                        dgvPesquisaVendas.DataSource = dadosTabela;

                        for (int i = 0; i < dadosTabela.Rows.Count; i++)
                        {
                            somatotal += Convert.ToDecimal(dadosTabela.Rows[i]["TOTAL"].ToString());

                            if (Convert.ToDecimal(dadosTabela.Rows[i]["TOTAL"].ToString()) < 0)
                            {
                                dgvPesquisaVendas.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        dgvPesquisaVendas.DataSource = null;
                    }

                    txtTotal.Text = somatotal.ToString("C2");

                    lblQtde.Text = dgvPesquisaVendas.Rows.Count.ToString().PadLeft(5, '0');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detalhes: " + ex.Message, "Erro Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbGBCodBarras_CheckedChanged(object sender, EventArgs e)
        {
            if (autBroupBy == true)
            {
                tipoAgrupado = 2;

                PesquisarDadosVendaAgrupados();
            }
        }

        private void rbGBUsuarios_CheckedChanged(object sender, EventArgs e)
        {
            if (autBroupBy == true)
            {
                tipoAgrupado = 3;

                PesquisarDadosVendaAgrupados();
            }
        }

        public void PesquisarDadosVendaAgrupados()
        {
            try
            {
                dtIni = txtDtInici.Text.Trim();
                dtFim = txtDtFim.Text.Trim();

                somatotal = 0;

                dtIni = dtIni.Replace("/", "");
                dtFim = dtFim.Replace("/", "");

                if (dtIni.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Inicio não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtInici.Focus();
                }
                else if (dtFim.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Data de Fim não Pode ser Vazio. Informe Data Desejada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtDtFim.Focus();
                }
                else
                {
                    dtIni = txtDtInici.Text.Trim();
                    dtFim = txtDtFim.Text.Trim();

                    vendaRegraNegocios = new VendaRegraNegocios();

                    DataTable dadosTabela = new DataTable();

                    if (tipoAgrupado == 1)
                    {
                        dadosTabela = vendaRegraNegocios.PesquisaVendaAgrupadoDescricao(dtIni, dtFim);
                    }
                    else if (tipoAgrupado == 2)
                    {
                        dadosTabela = vendaRegraNegocios.PesquisaVendaAgrupadoCodBarras(dtIni, dtFim);
                    }
                    else if (tipoAgrupado == 3)
                    {
                        dadosTabela = vendaRegraNegocios.PesquisaVendaAgrupadoUsuarios(dtIni, dtFim);
                    }

                    if (dadosTabela.Rows.Count > 0)
                    {
                        dgvPesquisaVendas.DataSource = dadosTabela;

                        for (int i = 0; i < dadosTabela.Rows.Count; i++)
                        {
                            somatotal += Convert.ToDecimal(dadosTabela.Rows[i]["TOTAL"].ToString());
                        }
                    }
                    else
                    {
                        dgvPesquisaVendas.DataSource = null;
                    }

                    txtTotal.Text = somatotal.ToString("C2");

                    lblQtde.Text = dgvPesquisaVendas.Rows.Count.ToString().PadLeft(5, '0');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detalhes: " + ex.Message, "Erro Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
