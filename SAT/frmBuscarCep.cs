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
    public partial class frmBuscarCep : Form
    {
        public frmBuscarCep()
        {
            InitializeComponent();
        }

        public void PesquisarCepWs()
        {
            try
            {
                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", txtBuscarCep.Text);

                DataSet ds = new DataSet();
                ds.ReadXml(xml);
                gdvBuscaCep.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atençao");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cep = txtBuscarCep.Text;

            //limpar variavel replace

            cep = cep.Replace("-", "");

            if (cep.Trim().Equals(""))
            {
                MessageBox.Show("Campo Buscar Cep nao Pode ser Nulo ou Vazio", "Informação");
                txtBuscarCep.Focus();
            }
            else
            {
                PesquisarCepWs();
            }
        }

        private void frmBuscarCep_Load(object sender, EventArgs e)
        {
            
        }
    }
}
