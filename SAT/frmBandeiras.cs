using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAT
{
    public partial class frmBandeiras : Form
    {
        frmVenda frmVenda;

        public frmBandeiras(frmVenda fVenda)
        {
            InitializeComponent();

            this.frmVenda = fVenda;
            this.bandeira = frmVenda.cupomFiscal;
            this.cnpj = frmVenda.cnpj.Trim();
        }

        #region VARIAVEIS

        public bool bandeira;
        public string cnpj = ""; 

        #endregion

        private void frmBandeiras_Load(object sender, EventArgs e)
        {
            if (bandeira == true)
            {
                pbBandRed.Visible = true;
                pbBandVerde.Visible = false;
            }
            else
            {
                pbBandRed.Visible = false;
                pbBandVerde.Visible = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCnpj.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Campo não Pode ser Nulo ou vázio...\nInforme Senha para Alteração", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    txtCnpj.Focus();
                    txtCnpj.SelectAll();
                }
                else
                {
                    if (txtCnpj.Text.Trim().Equals(cnpj))
                    {
                        frmVenda.altBandeira = true;
                    }
                    else
                    {
                        frmVenda.altBandeira = false;
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCnpj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
