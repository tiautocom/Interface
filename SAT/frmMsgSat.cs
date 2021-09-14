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
    public partial class frmMsgSat : Form
    {
        public frmMsgSat(string ret)
        {
            InitializeComponent();

            this.ret = ret;
        }

        string ret = "";

        private void frmMsgSat_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
            {
                lbConsultarSat.Items.Add(Sep_Delimitador('|', i, ret));
            }
        }

        private string Sep_Delimitador(char sep, int posicao, string dados)
        {
            try
            {
                string[] ret_dados = dados.Split(sep);
                return ret_dados[posicao];
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
