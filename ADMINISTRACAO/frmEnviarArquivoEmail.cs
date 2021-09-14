using System;
using System.Collections;
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
    public partial class frmEnviarArquivoEmail : Form
    {
        public frmEnviarArquivoEmail()
        {
            InitializeComponent();
        }

        ArrayList aAnexosEmail;

        EnviarEmail enviarEmail;

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] arr = ofd1.FileNames;
                    aAnexosEmail = new ArrayList();
                    txtAnexos.Text = string.Empty;
                    aAnexosEmail.AddRange(arr);

                    foreach (string s in aAnexosEmail)
                    {
                        txtAnexos.Text += s + "; ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        public void EnviarEmail()
        {
            try
            {

                if (String.IsNullOrEmpty(txtEnviarPara.Text))
                {
                    MessageBox.Show("Endereço de email do destinatário inválido.", "Erro ");
                    return;
                }
                if (String.IsNullOrEmpty(txtEnviadoPor.Text))
                {
                    MessageBox.Show("Endereço de email do remetente inválido.", "Erro ");
                    return;
                }
                if (String.IsNullOrEmpty(txtAssuntoTitulo.Text))
                {
                    MessageBox.Show("Definição do assunto inválida.", "Erro ");
                    return;
                }
                if (String.IsNullOrEmpty(txtMensagem.Text))
                {
                    MessageBox.Show("Mensagem inválida.", "Erro ");
                    return;
                }

                //separa os anexos em um array de string
                string[] arr = txtAnexos.Text.Split(';');
                //cria um novo arraylist
                aAnexosEmail = new ArrayList();
                //percorre o array de string e inclui os anexos
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arr[i].ToString().Trim()))
                    {
                        aAnexosEmail.Add(arr[i].ToString().Trim());
                    }
                }

                // Se existirem anexos , envia a mensagem com 
                // a chamada a EnviaMensagemComAnexos senão
                // usa o método enviaMensagemEmail
                if (aAnexosEmail.Count > 0)
                {
                    enviarEmail = new REGRA_NEGOCIOS.EnviarEmail();

                    //string resultado = enviarEmail.EnviaEmail.EnviaMensagemComAnexos(txtEnviarPara.Text, txtEnviadoPor.Text, txtAssuntoTitulo.Text, txtMensagem.Text, aAnexosEmail);

                    //MessageBox.Show(resultado, "Email enviado com sucesso");
                }
                else
                {
                    //string resultado = EnviaEmail.EnviaEmail.EnviaMensagemEmail(txtEnviarPara.Text, txtEnviadoPor.Text, txtAssuntoTitulo.Text, txtMensagem.Text);

                    //MessageBox.Show(resultado, "Email enviado com sucesso");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmEnviarArquivoEmail_Load(object sender, EventArgs e)
        {

        }
    }
}
