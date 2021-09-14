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
    public partial class frmPlaca : Form
    {
        frmVenda frmVenda;

        public frmPlaca(frmVenda fVenda)
        {
            InitializeComponent();
            this.frmVenda = fVenda;
        }

        #region VARIAVEIS

        int numVenda = 0;
        int idPlaca = 0;
        string placa, Km = "";

        #endregion

        #region CLASSES E OBJETOS

        PlacaC placaC = new PlacaC();
        PlacaRegraNegocios placaRegraNegocios = new PlacaRegraNegocios();

        #endregion

        private void txtPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKm.Focus();
            }
        }

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }

            if ((Keys)e.KeyChar == Keys.Enter)
            {
                txtCondutor.Focus();
                txtCondutor.SelectAll();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (btnSalvar.Text == "Cadastrar")
            {
                CadastrarPlaca();
            }
            else
            {
                AlterarPlaca();
            }
        }

        public void CadastrarPlaca()
        {
            try
            {
                if (txtPlaca.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo Placa não Podeser Vazio ou Nulo", "Campo Nulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPlaca.Focus();
                }
                else if (txtKm.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo KM não Podeser Vazio ou Nulo", "Campo Nulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKm.Focus();
                }
                else
                {
                    placaC = new PlacaC();
                    placaRegraNegocios = new PlacaRegraNegocios();

                    placaC.idVenda = numVenda;
                    placaC.placa = txtPlaca.Text.Trim();
                    placaC.km = txtKm.Text.Trim() + " -" + txtCondutor.Text.Trim();
                    placaC.dtCadastro = DateTime.Now.Date;

                    frmVenda.condutor = txtCondutor.Text.Trim();

                    string idRetorno = placaRegraNegocios.CadastrarPlaca(placaC);

                    MessageBox.Show("Placa Cadastrado com Sucesso.!!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                    try
                    {
                         int idret = Convert.ToInt32(idRetorno);

                        frmVenda.condutor = txtCondutor.Text.Trim();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Cadastrar Placa do Veiculo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPlaca.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void frmPlaca_Load(object sender, EventArgs e)
        {
            numVenda = frmVenda.numVenda;
            PesquisarPlaca();

            txtPlaca.Mask = ">???-####".ToUpper();
        }

        public void PesquisarPlaca()
        {
            try
            {
                placaC = new PlacaC();
                placaRegraNegocios = new PlacaRegraNegocios();
                DataTable dadosTabelaPlaca = new DataTable();

                dadosTabelaPlaca = placaRegraNegocios.PesquisarPlaca(numVenda);

                if (dadosTabelaPlaca.Rows.Count > 0)
                {
                    txtPlaca.Text = dadosTabelaPlaca.Rows[0]["PLACA"].ToString();
                    txtKm.Text = dadosTabelaPlaca.Rows[0]["KM"].ToString();
                    idPlaca = Convert.ToInt32(dadosTabelaPlaca.Rows[0]["ID"].ToString());

                    btnSalvar.Text = "Alterar";
                }
                else
                {
                    btnSalvar.Text = "Cadastrar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void cbxPlaca_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPlaca.Checked == true)
            {
                txtPlaca.Mask = ">???#?###".ToUpper();
            }
            else
            {
                txtPlaca.Mask = ">???-####".ToUpper();
            }

            txtPlaca.Focus();
            txtPlaca.SelectAll();
        }

        private void txtCondutor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar_Click(sender, e);
            }
        }

        public void AlterarPlaca()
        {
            try
            {
                if (MessageBox.Show("Realmente Deseja Alterar Placa ?", "Alterar Placa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    placaC = new PlacaC();
                    placaRegraNegocios = new PlacaRegraNegocios();

                    if (txtPlaca.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Campo Placa não Podeser Vazio ou Nulo", "Campo Nulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPlaca.Focus();
                    }
                    else if (txtKm.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Campo KM não Podeser Vazio ou Nulo", "Campo Nulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtKm.Focus();
                    }
                    else
                    {
                        placaC.placa = txtPlaca.Text.Trim();
                        placaC.km = txtKm.Text.Trim() + " -" + txtCondutor.Text.Trim();
                        placaC.idVenda = numVenda;

                        string idRetorno = placaRegraNegocios.AlterarPlaca(placaC);

                        try
                        {
                            int idRet = Convert.ToInt32(idRetorno);
                            MessageBox.Show("Placa foi Alterado com Sucesso.!!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Alterar Placa do Veiculo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPlaca.Focus();
                        }
                    }
                }
                else
                {
                    txtPlaca.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }
    }
}
