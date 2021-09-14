using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;

namespace CONTROLE.OTICA
{
    public partial class frmPedido : Form
    {
        frmPrincipal frmPrincipal;

        public frmPedido(frmPrincipal fPrincipal, int idCliente, string nomeCliente, string tel, string email, int idPed)
        {
            InitializeComponent();

            this.frmPrincipal = fPrincipal;
            this.idCliente = idCliente;
            this.nomeCliente = nomeCliente;
            this.telefone = tel;
            this.email = email;
            this.numPedido = frmPrincipal.numPedido;
            this.idPedido = idPed;
        }

        Pedido pedido;
        PedidoRegraNegocios pedidoRegraNegocios;

        OpenFileDialog openFileDialog = new OpenFileDialog();

        public int idCliente = 0;
        public string nomeCliente, telefone, email = "";
        public int numPedido = 0;
        public string ticket, Pasta = "";
        public int idPedido = 0;
        public int IdUsuario;
        public string url = "";

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        public void PesquisarPedidoNum()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                pedidoRegraNegocios = new PedidoRegraNegocios();

                dadosTabela = pedidoRegraNegocios.PesquisarPedidoNum(idPedido);

                if (dadosTabela.Rows.Count > 0)
                {
                    txtEsfODLonge.Text = dadosTabela.Rows[0]["ESF_OD_LONGE"].ToString().Trim();
                    txtEsfOELonge.Text = dadosTabela.Rows[0]["ESF_OE_LONGE"].ToString().Trim();
                    txtEsfODPerto.Text = dadosTabela.Rows[0]["ESF_OD_PERTO"].ToString().Trim();
                    txtEsfOEPerto.Text = dadosTabela.Rows[0]["ESF_OE_PERTO"].ToString().Trim();

                    txtCiliODLonge.Text = dadosTabela.Rows[0]["CILI_OD_LONGE"].ToString().Trim();
                    txtCiliOELonge.Text = dadosTabela.Rows[0]["CILI_OE_LONGE"].ToString().Trim();
                    txtCiliODPerto.Text = dadosTabela.Rows[0]["CILI_OD_PERTO"].ToString().Trim();
                    txtCiliOEPerto.Text = dadosTabela.Rows[0]["CILI_OE_PERTO"].ToString().Trim();

                    txtEixoODLonge.Text = dadosTabela.Rows[0]["EIXO_OD_LONGE"].ToString().Trim();
                    txtEixoOELonge.Text = dadosTabela.Rows[0]["EIXO_OE_LONGE"].ToString().Trim();
                    txtEixoODPerto.Text = dadosTabela.Rows[0]["EIXO_OD_PERTO"].ToString().Trim();
                    txtEixoOEPerto.Text = dadosTabela.Rows[0]["EIXO_OE_PERTO"].ToString().Trim();

                    txtDpODLonge.Text = dadosTabela.Rows[0]["DP_OD_LONGE"].ToString().Trim();
                    txtDpOELonge.Text = dadosTabela.Rows[0]["DP_OE_LONGE"].ToString().Trim();
                    txtDpODPerto.Text = dadosTabela.Rows[0]["DP_OD_PERTO"].ToString().Trim();
                    txtDpOEPerto.Text = dadosTabela.Rows[0]["DP_OE_PERTO"].ToString().Trim();

                    txtAltODLonge.Text = dadosTabela.Rows[0]["ALT_OD_LONGE"].ToString().Trim();
                    txtAltOELonge.Text = dadosTabela.Rows[0]["ALT_OE_LONGE"].ToString().Trim();
                    txtAltODPerto.Text = dadosTabela.Rows[0]["ALT_OD_PERTO"].ToString().Trim();
                    txtAltOEPerto.Text = dadosTabela.Rows[0]["ALT_OE_PERTO"].ToString().Trim();

                    txtOtico.Text = dadosTabela.Rows[0]["OTICO"].ToString().Trim();
                    txtNumReceita.Text = dadosTabela.Rows[0]["NUM_RECEITA"].ToString().Trim();

                    lblData.Text = dadosTabela.Rows[0]["DATA_CAD"].ToString().Trim();
                    lblNumPedido.Text = dadosTabela.Rows[0]["NUMERO"].ToString().Trim().PadLeft(5, '0');
                    txtNomeMedico.Text = dadosTabela.Rows[0]["MEDICO"].ToString().Trim();
                    txtCrmMedico.Text = dadosTabela.Rows[0]["CRM"].ToString().Trim();
                    txttelefoneMedico.Text = dadosTabela.Rows[0]["TEL_MEDICO"].ToString().Trim();
                    lblStatus.Text = dadosTabela.Rows[0]["STATUS"].ToString().Trim();

                    lblArquivos.Text = url = dadosTabela.Rows[0]["URL"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetCliente()
        {
            try
            {
                lblCliente.Text = nomeCliente.ToString().Trim();
                lblTel.Text = telefone.Trim();
                lblEmail.Text = email.Trim();
                lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblNumPedido.Text = numPedido.ToString().PadLeft(5, '0');

            }
            catch
            {
                lblCliente.Text = frmPrincipal.nomeCliente.ToString().Trim();
                lblTel.Text = frmPrincipal.TelefoneCliente.Trim();
                lblEmail.Text = frmPrincipal.emailCliente.Trim();
                lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblNumPedido.Text = frmPrincipal.numPedido.ToString().PadLeft(5, '0');
            }

            if (idPedido > 0)
            {
                PesquisarPedidoNum();

                btnNovo.Enabled = false;
                btnAddPdf.Enabled = true;
            }
            else
            {
                btnNovo.Enabled = true;
                btnAddPdf.Enabled = false;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente Deseja Realizar Novo Pedido?", "Conformação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                LimpaCampos();
            }
        }

        public void LimpaCampos()
        {
            try
            {
                txtCiliODLonge.Text = "";
                txtCiliODPerto.Text = "";
                txtCiliOELonge.Text = "";
                txtCiliOEPerto.Text = "";
                txtCrmMedico.Text = "";
                txtDpODPerto.Text = "";
                txtDpODLonge.Text = "";
                txtDpOELonge.Text = "";
                txtDpOEPerto.Text = "";
                txtEixoODLonge.Text = "";
                txtEixoODPerto.Text = "";
                txtEixoOELonge.Text = "";
                txtEixoOEPerto.Text = "";
                txtEsfODLonge.Text = "";
                txtEsfOELonge.Text = "";
                txtEsfOEPerto.Text = "";
                txtNomeMedico.Text = "";
                txtObservacao.Text = "";
                txtEsfODPerto.Text = "";

                txtNomeMedico.Text = "";
                txtCrmMedico.Text = "";
                txtObservacao.Text = "";

                txtEsfODLonge.Focus();
                txtEsfODLonge.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar(sender, e);
        }

        public void Salvar(object sender, EventArgs e)
        {
            try
            {
                if (txtEsfODLonge.Text.Trim().Equals("") && txtEsfODPerto.Text.Trim().Equals("") && txtEsfOELonge.Text.Trim().Equals("") && txtEsfOEPerto.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Algum dos Campos Esférico do Olho Deve ser Preenchido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtEsfODLonge.Focus();
                    txtEsfODLonge.SelectAll();
                }
                else if (txtCiliODLonge.Text.Trim().Equals("") && txtCiliODPerto.Text.Trim().Equals("") && txtCiliOELonge.Text.Trim().Equals("") && txtCiliOEPerto.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Algum dos Campos Cilíndrico do Olho Deve ser Preenchido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtEixoODLonge.Focus();
                    txtEixoODLonge.SelectAll();
                }
                else if (txtEixoODLonge.Text.Trim().Equals("") && txtEixoODPerto.Text.Trim().Equals("") && txtEsfOELonge.Text.Trim().Equals("") && txtEixoOEPerto.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Algum dos Campos Eixo do Olho Deve ser Preenchido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtEixoODLonge.Focus();
                    txtEixoODLonge.SelectAll();
                }
                else
                {
                    bool aut = false;

                    if (lblArquivos.Text.Trim().Equals("...") && idPedido == 0)
                    {
                        if (MessageBox.Show("Não foi Localizado Arquivo PDF Receita Médica para Cadastro de Pedido!!!.\n\nAinda Deseja Realizar Cadastro do Pedido?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes && lblArquivos.Text.Trim().Equals("..."))
                        {
                            aut = true;
                        }
                        else
                        {
                            aut = true;

                            btnSelArquivo_Click_1(sender, e);
                        }
                    }
                    else
                    {
                        aut = true;
                    }

                    if (aut == true)
                    {
                        pedido = new Pedido();

                        pedido.Id = idPedido;
                        pedido.idCliente = idCliente;
                        pedido.IdUsuario = IdUsuario;
                        pedido.DataCadastro = DateTime.Now;
                        pedido.Observacao = txtObservacao.Text.Trim();
                        pedido.Numero = Convert.ToInt32(lblNumPedido.Text);

                        pedido.EsfODLonge = txtEsfODLonge.Text.Trim();
                        pedido.EsfODPerto = txtEsfODPerto.Text.Trim();
                        pedido.EsfOELonge = txtEsfOELonge.Text.Trim();
                        pedido.EsfOEPerto = txtEsfOEPerto.Text.Trim();

                        pedido.CiliODLonge = txtCiliODLonge.Text.Trim();
                        pedido.CiliOELonge = txtCiliOELonge.Text.Trim();
                        pedido.CiliODPerto = txtCiliODPerto.Text.Trim();
                        pedido.CiliOEPerto = txtCiliOEPerto.Text.Trim();

                        pedido.EixoODLonge = txtEixoODLonge.Text.Trim();
                        pedido.EixoOElonge = txtEixoOELonge.Text.Trim();
                        pedido.EixoOEPerto = txtEixoOEPerto.Text.Trim();
                        pedido.EixoODPerto = txtEixoODPerto.Text.Trim();

                        pedido.DpODLonge = txtDpODLonge.Text.Trim();
                        pedido.DpOELonge = txtDpOELonge.Text.Trim();
                        pedido.DpODPerto = txtDpODPerto.Text.Trim();
                        pedido.DpOEPerto = txtDpOEPerto.Text.Trim();

                        pedido.AltODLonge = txtAltODLonge.Text.Trim();
                        pedido.AltODPerto = txtAltODPerto.Text.Trim();
                        pedido.AltOELonge = txtAltOELonge.Text.Trim();
                        pedido.AltOEPerto = txtAltOEPerto.Text.Trim();

                        pedido.Otico = txtOtico.Text.Trim();

                        pedido.Url = lblArquivos.Text.Trim();
                        pedido.StatusDesc = "1 - ENTRADA";
                        pedido.NumReceita = txtNumReceita.Text.Trim();

                        pedido.Medico = new Medico();
                        pedido.Medico.Nome = txtNomeMedico.Text.Trim();
                        pedido.Medico.NumCrm = txtCrmMedico.Text.Trim();

                        pedidoRegraNegocios = new PedidoRegraNegocios();

                        int idRet = pedidoRegraNegocios.Salvar(pedido);

                        if (idRet > 0)
                        {
                            string end = (frmPrincipal.path + "\\IMAGENS\\" + numPedido.ToString().PadLeft(5, '0'));

                            if (!Directory.Exists(end))
                            {
                                Directory.CreateDirectory(end);
                            }

                            File.Delete(lblArquivos.Text.Trim());
                            File.Copy(openFileDialog.FileName, lblArquivos.Text.Trim());

                            frmPrincipal.PesquisarPedido();

                            MessageBox.Show("Pedido Numero: " + lblNumPedido.Text.Trim() + " Foi Realizado com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelArquivo_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (idPedido == 0)
                {
                    openFileDialog = new OpenFileDialog();
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.AddExtension = true;
                    openFileDialog.Multiselect = true;

                    openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Text Files (*.txt)|*.txt|Word Documents|*.doc|All Files|*.*";

                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        lblArquivos.Text = frmPrincipal.path + "\\IMAGENS\\" + numPedido.ToString().PadLeft(5, '0') + "\\" + openFileDialog.SafeFileName;

                        string end = openFileDialog.FileName;
                    }
                }
                else
                {
                    System.Diagnostics.Process.Start(url.ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {
            LimpaCampos();
            GetCliente();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
