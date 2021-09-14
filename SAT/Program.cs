using OBJETO_TRANSFERENCIA;
using REGRA_NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace SAT
{
    static class Program
    {
        #region PATH

        public static string pathNumCaixa = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\NUM_CAIXA.xml";

        #endregion

        #region CLASSES O OBJETOS

        public static frmLogin frmlogin;
        public static frmPesquisarCliente frmCliente;
        public static frmVenda frmVenda;

        static DataTable dadosTabela;

        #endregion

        #region VARIAVEIS

        public static int numCaixa, _tipoVenda, _idTipoAmbiente = 0;

        public static string _versao, _url, _metodo, _servico, _uri, _ibge, _actions, razaoScoailEmitente = "";
        public static int _cUF = 0;

        #endregion

        public static void PesquisarNumCaixa_numBalanca_numPortaCom_Xml()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(pathNumCaixa);

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Num")
                        numCaixa = Convert.ToInt32(x.ReadString());
                }

                x.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void PesquisarNumVenda()
        {
            try
            {
                VendaRegraNegocios vendaRegraNegocios = new VendaRegraNegocios();

                var nVenda = vendaRegraNegocios.PesquisarNumVenda(numCaixa);

                _tipoVenda = Convert.ToInt32(nVenda.Rows[0]["TIPO_VENDA"].ToString().Trim().Substring(0, 1));
                _idTipoAmbiente = Convert.ToInt32(nVenda.Rows[0]["NFCE_AMBIENTE"].ToString().Trim().Substring(0, 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencao");
            }
        }

        public static void PesquisarDados()
        {
            try
            {
                UrlRegraNegocios urlRegraNegocios = new UrlRegraNegocios();

                dadosTabela = new DataTable();

                Url url = new Url();

                url.IdAmbiente = _idTipoAmbiente;
                url.Servico = "NFeStatusServico4";
                url.CodNumerico = 1;

                dadosTabela = urlRegraNegocios.PesquisaUrl(url);

                if (dadosTabela.Rows.Count > 0)
                {
                    //ATRIBUIR O VALORES AOS OBJETOS
                    _versao = dadosTabela.Rows[0]["VERSAO"].ToString().Trim();
                    _idTipoAmbiente = Convert.ToInt32(dadosTabela.Rows[0]["ID_AMBIENTE"].ToString());
                    _url = dadosTabela.Rows[0]["URL"].ToString().Trim();
                    _cUF = Convert.ToInt32(dadosTabela.Rows[0]["COD_UF"].ToString().Trim().Substring(0, 2));
                    _metodo = "STATUS";
                    _servico = dadosTabela.Rows[0]["SERVICO"].ToString().Trim();
                    _uri = "http://www.portalfiscal.inf.br/nfe";
                    _ibge = dadosTabela.Rows[0]["COD_UF"].ToString().Trim();

                    //_actions = "";
                }
                else
                {
                    MessageBox.Show("Endereço de URL de Serviço não foi Localizado..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [STAThread]
        static void Main()
        {
            //Pega o nome do processo deste programa
            string nomeProcesso = Process.GetCurrentProcess().ProcessName;

            //Busca os processos com este nome que estão em execução
            Process[] processos = Process.GetProcessesByName(nomeProcesso);

            //Se já houver um aberto
            if (processos.Length > 1)
            {
                //Mostra mensagem de erro e finaliza
                MessageBox.Show("Não é possível abrir o Sistema. \nVerifique se o Programa já está sendo Executado.", "Sistema Executando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Application.Exit();
            }
            else
            {
                PesquisarNumCaixa_numBalanca_numPortaCom_Xml();

                PesquisarNumVenda();

                if (_tipoVenda == 2)
                {
                    PesquisarDados();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    frmNFCeLogin frmNFCeLogin = new frmNFCeLogin(frmVenda, _versao, _idTipoAmbiente, _url, _cUF, _servico, _uri, _ibge, razaoScoailEmitente, _tipoVenda);
                    frmNFCeLogin.ShowDialog();

                    if (frmNFCeLogin.DialogResult == DialogResult.OK)
                    {
                        Application.Run(new frmVenda(frmCliente, _versao, _idTipoAmbiente, _url, _cUF, _servico, _uri, _ibge, razaoScoailEmitente, _tipoVenda, _actions));
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmVenda(frmCliente, _versao, _idTipoAmbiente, _url, _cUF, _servico, _uri, _ibge, "", _tipoVenda, _actions));
                }
            }
        }
    }
}

