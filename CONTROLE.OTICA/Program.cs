using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONTROLE.OTICA
{
    static class Program
    {
        public static frmPrincipal fprincipal;

        [STAThread]
       public static void Main()
        {
            try
            {

                //Pega o nome do processo deste programa
                string nomeProcesso = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

                //Busca os processos com este nome que estão em execução
                Process[] processos = Process.GetProcessesByName(nomeProcesso);

                //Se já houver um aberto
                if (processos.Length > 1)
                {
                    //Mostra mensagem de erro e finaliza
                    MessageBox.Show("Não é possível abrir o Sistema. \nVerifique se o Programa já está sendo Executado.", "Sistema Executando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
                //Caso contrário continue normalmente
                else
                {

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    frmLogin formularioLogin = new frmLogin(fprincipal);
                    formularioLogin.ShowDialog(); //Carrega o formulário frmLogin.

                    //Se o resultado do dados do login estiverem certos, o formulário frmPrincipal será carregado.
                    if (formularioLogin.DialogResult == DialogResult.OK)
                    {
                        Application.Run(new frmPrincipal(formularioLogin.idUsuario, formularioLogin.usuario));
                    }
                    else //Caso contrário, a aplicação será finalizada.
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
