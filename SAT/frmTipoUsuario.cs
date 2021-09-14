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
    public partial class frmTipoUsuario : Form
    {
        public frmTipoUsuario()
        {
            InitializeComponent();
            gdvTipoUsuario.AutoGenerateColumns = false;
        }

        #region VARIAVEIS

        string tipo = "";
        int codigo = 0;
        bool permissao;

        #endregion

        #region OBJETO E CLASSES

        TipoUsuarioC tipoUsuarioC = new TipoUsuarioC();
        TipoUsuarioRegraNegocios tipoUsuarioRegraNegocios = new TipoUsuarioRegraNegocios();

        #endregion

        private void cbxPermissao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPermissao.Checked == true)
            {
                permissao = true;
                cbxPermissao.Text = "Sim";
            }
            else
            {
                permissao = false;
                cbxPermissao.Text = "Não";
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTipoUsuario_Load(object sender, EventArgs e)
        {
            ListarTipoUsuario();

            if (Convert.ToInt32(txtCodigo.Text) > 0)
            {
                btnManter.Text = "Alterar";
            }
            else
            {
                btnManter.Text = "Cadastrar";
            }
        }

        public void ListarTipoUsuario()
        {
            try
            {
                tipoUsuarioC = new TipoUsuarioC();
                tipoUsuarioRegraNegocios = new TipoUsuarioRegraNegocios();
                DataTable dadosTabelaTipoUsuario = new DataTable();

                dadosTabelaTipoUsuario = tipoUsuarioRegraNegocios.PopularCbTipoUsuario();

                if (dadosTabelaTipoUsuario.Rows.Count > 0)
                {
                    gdvTipoUsuario.DataSource = null;
                    gdvTipoUsuario.DataSource = dadosTabelaTipoUsuario;
                    lblQtde.Text = gdvTipoUsuario.Rows.Count.ToString();
                }
                else
                {
                    gdvTipoUsuario.DataSource = null;
                    lblQtde.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnManter_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCodigo.Text) > 0)
            {
                AlterarTipoUsuario();
            }
            else
            {
                CadastrarTipoUsuario();
            }
        }

        private void gdvTipoUsuario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCodigo.Text = gdvTipoUsuario.Rows[e.RowIndex].Cells["colCodigo"].Value.ToString();
                txtTipoUsuario.Text = gdvTipoUsuario.Rows[e.RowIndex].Cells["colTipoUsuario"].Value.ToString();
                try
                {
                    permissao = Convert.ToBoolean(gdvTipoUsuario.Rows[e.RowIndex].Cells["colPermissao"].Value.ToString());
                }
                catch
                {
                    permissao = false;
                }

                codigo = Convert.ToInt32(txtCodigo.Text);

                tipo = txtTipoUsuario.Text;

                if (permissao == true)
                {
                    cbxPermissao.Checked = true;
                }
                else
                {
                    cbxPermissao.Checked = false;
                }

                if (Convert.ToInt32(txtCodigo.Text) > 0)
                {
                    btnManter.Text = "Alterar";
                }
                else
                {
                    btnManter.Text = "Cadastrar";
                }

                txtTipoUsuario.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void AlterarTipoUsuario()
        {
            try
            {
                if (MessageBox.Show("Realmente Deseja Alterar Tipo de Usuário.", "Alterar Tipo de Usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    tipoUsuarioC = new TipoUsuarioC();
                    tipoUsuarioRegraNegocios = new TipoUsuarioRegraNegocios();

                    if (Convert.ToInt32(txtCodigo.Text) <= 0)
                    {
                        MessageBox.Show("Campo Código não Pode ser Menor ou gual a Zero", "Campo Menor ou Igual a Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtTipoUsuario.Focus();
                    }
                    else if (txtTipoUsuario.Text.Equals(""))
                    {
                        MessageBox.Show("Campo Tipo de Usuário não P0de ser Nulo ou Vázio", "Campo Menor ou Igual a Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtTipoUsuario.Focus();
                    }
                    else
                    {
                        tipoUsuarioC.tipoUsuario = txtTipoUsuario.Text;
                        tipoUsuarioC.idTipoUsuario = Convert.ToInt32(txtCodigo.Text);

                        if (cbxPermissao.Checked == true)
                        {
                            tipoUsuarioC.permissao = true;
                        }
                        else
                        {
                            tipoUsuarioC.permissao = false;
                        }

                        string idRetorno = tipoUsuarioRegraNegocios.AlterarTipoUsuario(tipoUsuarioC);

                        try
                        {
                            int idRet = Convert.ToInt32(idRetorno);
                            MessageBox.Show("Tipo de Usuário foi Alterado com Sucesso.", "Alteração com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarTipoUsuario();
                            LimparCampos();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Alterar Tipo de Usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LimparCampos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        public void CadastrarTipoUsuario()
        {
            try
            {
                tipoUsuarioC = new TipoUsuarioC();
                tipoUsuarioRegraNegocios = new TipoUsuarioRegraNegocios();

                if (txtTipoUsuario.Text.Equals(""))
                {
                    MessageBox.Show("Campo Tipo de Usuário não Pode ser Nulo ou Vázio", "Campo Menor ou Igual a Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTipoUsuario.Focus();
                }
                else
                {
                    tipoUsuarioC.tipoUsuario = txtTipoUsuario.Text;
                    tipoUsuarioC.idTipoUsuario = Convert.ToInt32(txtCodigo.Text);

                    if (cbxPermissao.Checked == true)
                    {
                        tipoUsuarioC.permissao = true;
                    }
                    else
                    {
                        tipoUsuarioC.permissao = false;
                    }

                    string idRetorno = tipoUsuarioRegraNegocios.CadastrarTipoUsuario(tipoUsuarioC);

                    try
                    {
                        int idRet = Convert.ToInt32(idRetorno);
                        MessageBox.Show("Tipo de Usuário foi Cadastrado com Sucesso.", "Cadastrado com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarTipoUsuario();
                        LimparCampos();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Cadastrar Tipo de Usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "0";
            txtTipoUsuario.Text = "";
            btnManter.Text = "Cadastrar";
            txtTipoUsuario.Focus();
        }
    }
}
