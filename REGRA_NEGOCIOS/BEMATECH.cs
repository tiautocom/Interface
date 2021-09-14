using OBJETO_TRANSFERENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REGRA_NEGOCIOS
{
    public class BEMATECH
    {
        #region VARIAVEIS

        StringBuilder sb = new StringBuilder();

        public int idRetorno = 0;

        string esquerda = "" + (char)27 + (char)97 + (char)0;
        string centrarlizar = "" + (char)27 + (char)97 + (char)1;
        string direita = "" + (char)27 + (char)97 + (char)2;

        public string linha = "\n";
        public string NOME_RAZAO_SOCIAL, ENDERECO, NUMERO, BAIRRO, CEP, CIDADE, UF, TELEFONE, CNPJ, IE, IM = "";
        public string CPF_CNPJ_CONSUMIDOR, nCFe = "";

        #endregion

        public void GetDadosEmpresa(CABECALHO cab)
        {
            try
            {
                NOME_RAZAO_SOCIAL = cab.NomeRazao.Trim();
                ENDERECO = cab.Endereco.Trim();
                NUMERO = cab.Numero.Trim();
                BAIRRO = cab.Bairro.Trim();
                CEP = cab.Cep.Trim();
                CIDADE = cab.Cidade.Trim();
                UF = cab.Uf.Trim();
                TELEFONE = cab.Telefone.Trim();
                CNPJ = cab.CNPJ.Trim();
                IE = cab.IE.Trim();
                IM = cab.IM.Trim();
                CPF_CNPJ_CONSUMIDOR = cab.CnpjCliente.Trim();
                nCFe = cab.nCFe.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoDadosEmpresa(CABECALHO cabecalho)
        {
            try
            {
                GetDadosEmpresa(cabecalho);

                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine(NOME_RAZAO_SOCIAL + "                                           ");
                sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                sb.AppendLine("==================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoCupom(CABECALHO cabecalho, string nCFe, bool cupomFiscal)
        {
            try
            {
                GetDadosEmpresa(cabecalho);

                sb = new StringBuilder();

                if (cupomFiscal == true)
                {
                    sb.Append("===================================================================");
                    sb.Append("\n");
                    sb.AppendLine(NOME_RAZAO_SOCIAL + "                                           ");
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("CPF/CNPJ CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR.ToString().Replace("/", ""));
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("                  CUPOM FISCAL ELETRONICO - SAT                   ");
                    sb.AppendLine("                        EXTRATO Nº: " + nCFe + "                  ");
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("ITEM CODIGO DESCRICAO               UNID   QTDE X PRECO TOTAL(R$) ");
                    sb.AppendLine("------------------------------------------------------------------");
                }
                else
                {
                    sb.Append("===================================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL + "                                           ");
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("CPF/CNPJ CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("ITEM CODIGO DESCRICAO               UNID   QTDE X PRECO TOTAL(R$) ");
                    sb.AppendLine("------------------------------------------------------------------");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoSegundaViaVenda(CABECALHO cabecalho, bool cupomFiscal)
        {
            try
            {
                sb = new StringBuilder();

                GetDadosEmpresa(cabecalho);

                if (cupomFiscal == true)
                {
                    sb.AppendLine("=================================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL + "                                             ");
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("CPF CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR.Replace("/", "").Trim());
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("                  CUPOM FISCAL ELETRONICO - SAT                   ");
                    sb.AppendLine("                        EXTRATO Nº: " + nCFe + "                  ");
                    sb.AppendLine("                       *** SEGUNDA VIA ***                        ");
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("ITEM CODIGO DESCRICAO               UNID   PRECO X QTDE TOTAL(R$) ");
                    sb.AppendLine("------------------------------------------------------------------");
                }
                else
                {
                    sb.AppendLine("=================================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL + "                                             ");
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("CPF CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("                       *** SEGUNDA VIA ***                        ");
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("ITEM CODIGO DESCRICAO               UNID   PRECO X QTDE TOTAL(R$) ");
                    sb.AppendLine("------------------------------------------------------------------");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoSat()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("                  CUPOM FISCAL ELETRONICO - SAT                   ");
                sb.AppendLine("                     EXTRATO Nº: " + nCFe + "                     ");
                sb.AppendLine("==================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoCancelamentoSat(string nserieSAT, string nCFe)
        {
            try
            {
                sb = new StringBuilder();
                sb.AppendLine("==================================================================");
                sb.AppendLine("                   CUPOM FISCAL ELETRONICO - SAT                  ");
                sb.AppendLine("                      CANCELAMENTO DE CUPOM                       ");
                sb.AppendLine("                        EXTRATO Nº: " + nCFe + "                  ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("                     SAT NUMERO: " + nserieSAT);
                sb.AppendLine("==================================================================");
                sb.AppendLine("DATA: " + DateTime.Now.ToString());

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DadosFinaisCancelamento(string valorCancel, string numVenda, string numCaixa, string nomeOperador)
        {
            try
            {
                sb = new StringBuilder();

                sb.Append("");
                sb.Append(("TOTAL" + valorCancel.ToString().PadLeft(60, '.')));
                sb.Append("==================================================================");
                sb.Append("OBSERVACAO DO CONTRIBUINTE                                        ");
                sb.Append("Nº CAIXA: " + numCaixa.ToString().PadLeft(3, '0'));
                sb.Append(" - Nº VENDA: " + (numVenda).ToString().PadLeft(8, '0'));
                sb.Append(" - OPERADOR: " + nomeOperador.Trim());
                sb.Append("DATA: " + DateTime.Now.ToString());
                sb.Append("\n");
                sb.Append("==================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoCupom(List<VENDAS> listaVenda, VendaC venda)
        {
            try
            {
                sb = new StringBuilder();

                string descricaoVenda = "";

                foreach (var item in listaVenda)
                {
                    string itens = item.itemVenda.ToString().PadLeft(3, '0');
                    string cod = item.codoBarra.PadLeft(13, '0').Substring(8, 5);
                    string unid = item.unid.Trim();
                    string desc = item.descricao.PadRight(30, ' ').Substring(0, 24);
                    string q = item.qtde.ToString().PadLeft(8, ' ');
                    string p = item.precoProd.ToString().PadLeft(8, ' ');
                    string tt = item.subTotal.ToString().PadLeft(8, ' ');
                    decimal tot = Convert.ToDecimal(item.subTotal);

                    descricaoVenda += (itens + "  " + cod + " " + desc + " " + unid + " " + q + " " + p + " " + tt + "\t\r");
                }

                sb.Append(descricaoVenda);
                sb.AppendLine("===================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string FormaPagamento(List<FORMA_PAGAMENTOS> ListaFormaPagamentos, decimal total)
        {
            try
            {
                sb = new StringBuilder();

                string descricaoPagamentos = "";
                string des, valor = "";
                decimal totalPagamento = 0;
                decimal troco = 0;
                int cont = 0;

                foreach (var item in ListaFormaPagamentos)
                {
                    des = item.Descricao.PadRight(53, ' ');
                    valor = item.Valor.Trim().PadLeft(10, ' ');
                    troco = Convert.ToDecimal(item.Troco);

                    cont++;

                    descricaoPagamentos += (des + " " + valor + "\n");
                }

                sb.Append(descricaoPagamentos);

                sb.AppendLine("TOTAL: " + total.ToString("N2").Trim().PadLeft(57, ' '));
                sb.AppendLine("_____________________".Trim().PadLeft(65, ' '));
                sb.AppendLine("TROCO: " + troco.ToString("N2").Trim().PadLeft(57, ' '));
                sb.AppendLine("QTDE ITEM: " + cont.ToString().PadLeft(3, '0'));

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DadosFinaisCupom(VENDA_DETALHES vendaDetalhes)
        {
            try
            {
                sb = new StringBuilder();

                sb.Append("==================================================================" + linha);
                sb.Append("        Consulte seu QRCode Cupom no App de Olho na Nota.         " + linha);
                sb.Append("==================================================================" + linha);
                sb.Append("                 *** OBSERVACAO DO CONTRIBUINTE ***               " + linha);
                sb.Append("Fonte IBPT R$ Aproximado Conforme a Lei: 12.741/12                " + linha);
                sb.Append("Valor Aproximado Tributo: " + vendaDetalhes.valorAliquota.ToString("C2") + "." + linha);
                sb.Append("OPERADOR: " + vendaDetalhes.nomeOperador.Trim() + " - TURNO: " + vendaDetalhes.periodo);
                sb.Append(" - CAIXA: " + vendaDetalhes.numCaixa.ToString().Trim().PadLeft(3, '0'));
                sb.Append(" - Nº VENDA: " + vendaDetalhes.numVenda.ToString().Trim().PadLeft(7, '0') + linha);
                sb.Append("==================================================================" + linha);
                sb.Append("DATA: " + DateTime.Now.ToString());

                if (vendaDetalhes.desPlaca != "")
                {
                    sb.Append(" PLACA:" + vendaDetalhes.placa + " - " + "KM: " + vendaDetalhes.km + " - ");
                }
                else
                {
                }

                sb.Append(vendaDetalhes.msg + linha);

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DadosSat(string nserieSAT, string data)
        {
            try
            {
                sb = new StringBuilder();

                sb.Append("==================================================================" + linha);
                sb.Append("                    DATA: " + data + linha);
                sb.Append("                     SAT NUMERO : " + nserieSAT.Trim() + linha);
                sb.Append("==================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CupomVendaAberto(decimal valorAberto, string nomeCliente, int numCaixa, int numVenda, string nomeOperador)
        {
            try
            {
                sb = new StringBuilder();

                sb.Append("==================================================================");
                sb.Append("               *** COMPROVANTE DE COMPRA EM ABERTO ***            " + linha);
                sb.Append("==================================================================" + linha);
                sb.Append(linha);
                sb.Append("VALOR TOTAL..........................................." + valorAberto.ToString("C2").Trim() + linha);
                sb.Append("EU " + nomeCliente.Trim() + " RECONHEÇO E PAGAREI A DIVIDA AQUI REPRESENTADA" + linha);
                sb.Append("NO VALOR DE:" + valorAberto.ToString("C2").Trim() + "." + linha);
                sb.Append("ASS:_____________________________________________" + linha);
                sb.Append(linha);
                sb.Append("CAIXA:" + numCaixa.ToString().PadLeft(3, '0').Trim());
                sb.Append("- Nº CUPOM:" + numVenda.ToString().PadLeft(3, '0').Trim() + " - Operador: " + nomeOperador.Trim());
                sb.Append(linha);
                sb.Append("DATA: " + DateTime.Now.ToString());
                sb.Append(linha);
                sb.Append(linha);

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoCupomComum(CABECALHO cabecalho)
        {
            try
            {
                GetDadosEmpresa(cabecalho);

                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine(NOME_RAZAO_SOCIAL.PadRight(44, ' ').Substring(0, 40) + "           ");
                sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                sb.AppendLine("==================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioSetor()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("                   *** RELATORIO SETOR(ES) ***                    ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("SETOR  DESCRICAO                                             TOTAL");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioDepartamento()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("                 *** RELATORIO DEPARTAMENTO ***                   ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("DEP    DESCRICAO                                              TOTAL");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioVendaCancelada()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("              *** RELATORIO VENDA(S) CANCELADA(S) ***             ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("COD   DESCRICAO           UNID PRECO   QTDE     TOTAL      ESTOQUE");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioVendas()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("                  *** RELATORIO VENDA TOTAL ***                   ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("COD   DESCRICAO            UNID  PRECO    QTDE      TOTAL  ESTOQUE");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioVendasRZ(int tag)
        {
            try
            {
                sb = new StringBuilder();

                if (tag == 1)
                {
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("                        *** REDUÇÃO Z ***                         ");
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("                  *** RELATORIO VENDA TOTAL ***                   ");
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("COD   DESCRICAO                                  QTDE      TOTAL  ");
                }
                else
                {
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("               *** RELATORIO ESTOQUE PRODUTOS ***                 ");
                    sb.AppendLine("==================================================================");
                    sb.AppendLine("COD   DESCRICAO                               ESTOQUE       QTDE  ");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioSetor(List<Setor> listaSetor)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaSetor)
                {
                    sb.AppendLine(item.DesSetor + "    " + item.Descricao.PadRight(40, ' ').Substring(0, 40) + " " + item.Valor.ToString().PadLeft(18, ' '));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioFormaPagamento()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("                *** RELATORIO FORMA PAGAMENTO ***                 ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("COD   DESCRICAO                                            TOTAL  ");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioFormaPagamento(List<PAGAMENTO_VENDA> listaRelatorioStor)
        {
            sb = new StringBuilder();

            foreach (var item in listaRelatorioStor)
            {
                sb.AppendLine(item.Id.ToString().PadLeft(0, '3') + "    " + item.Descricao.PadRight(40, ' ').Substring(0, 40) + " " + item.Valor.ToString().PadLeft(18, ' '));
            }

            return sb.ToString();
        }

        public string CorpoRelatorioDepartamento(List<DepartamentoC> listaDepartamento)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaDepartamento)
                {
                    sb.AppendLine(item.idDepartamento.PadLeft(0, '3').Substring(0, 3) + "    " + item.descricaoDep.PadRight(40, ' ').Substring(0, 40) + " " + item.Valor.ToString().PadLeft(18, ' '));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DadosFinaisSetor(decimal somaTotal, int numCaixa, string nomeOperador)
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("");
                sb.AppendLine("==================================================================");
                sb.AppendLine("TOTAL" + somaTotal.ToString("C2").Trim().PadLeft(61, '.'));
                sb.Append("Nº CAIXA: " + numCaixa.ToString().Trim().PadLeft(3, '0'));
                sb.AppendLine(" - OPERADOR: " + nomeOperador.Trim());
                sb.AppendLine("DATA: " + DateTime.Now.Date.ToLongDateString());
                sb.AppendLine("                            *** FIM ***                          ");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioVendaCancelada(List<VENDAS> listaRelatorioVendaCancelada)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaRelatorioVendaCancelada)
                {
                    sb.AppendLine(item.codoBarra.PadLeft(13, '0').Substring(8, 5) + " " + item.descricao.Replace("VENDA CANC. -", "").Trim().PadRight(20, ' ').Substring(0, 20) + " " + item.unid.Trim() + " " + item.precoProd.ToString().PadLeft(9, ' ') + " " + " " + item.qtde.ToString().PadLeft(9, ' '));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioEstoqueTotal(List<VENDAS> listaRelatorio)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaRelatorio)
                {
                    try
                    {
                        sb.AppendLine(item.codoBarra.PadLeft(13, '0').Substring(8, 5) + " " + item.descricao.Replace("VENDA CANC. -", "").Trim().PadRight(49, ' ').Substring(0, 49) + " " + item.estoque.ToString().PadLeft(9, ' '));
                    }
                    catch
                    {
                        sb.AppendLine(item.codoBarra.PadLeft(13, '0').Substring(8, 5) + " " + item.descricao.Replace("VENDA CANC. -", "").Trim().PadRight(30, ' ').Substring(0, 30) + " " + item.precoProd.ToString().PadLeft(9, ' ') + " " + " " + item.qtde.ToString().PadLeft(9, ' ') + " " + item.subTotal.ToString().PadLeft(8, ' '));
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioFechamentoCaixa(string moeda, string dinheiro, string cartao, string cheque, string convenio, string loja, string sangria, string despesa, string lavaRapido, string total, string diferenca)
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("MOEDA           :" + moeda.Trim().PadLeft(47, '.'));
                sb.AppendLine("DINHEIRO        :" + dinheiro.Trim().PadLeft(47, '.'));
                sb.AppendLine("CARTÃO          :" + cartao.Trim().PadLeft(47, '.'));
                sb.AppendLine("CHEQUE          :" + cheque.Trim().PadLeft(47, '.'));
                sb.AppendLine("CONVÊNIO        :" + convenio.Trim().PadLeft(47, '.'));
                sb.AppendLine("LOJA            :" + loja.Trim().PadLeft(47, '.'));
                sb.AppendLine("SANGRIA         :" + sangria.Trim().PadLeft(47, '.'));
                sb.AppendLine("DESPESA         :" + despesa.Trim().PadLeft(47, '.'));
                sb.AppendLine("LAVA RÁRIDO     :" + lavaRapido.Trim().PadLeft(47, '.'));
                sb.Append("\n\n");
                sb.AppendLine("TOTAL           :" + total.Trim().PadLeft(47, '.'));
                sb.AppendLine("DIFERENÇA CAIXA :" + diferenca.Trim().PadLeft(47, '.'));

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioFechamentoCaixa()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("                    *** FECHAMENTO CAIXA ***                      ");
                sb.AppendLine("==================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioTributos(List<TRIBUTOS> listaRelatorioTributos)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaRelatorioTributos)
                {
                    sb.AppendLine(item.Trib.PadLeft(0, '3') + "    " + Convert.ToDecimal(item.Valor).ToString("N2").PadLeft(60, ' '));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioTributos()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("                    *** RELATORIO TRIBUTOS ***                    ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("TRIB                                                       TOTAL  ");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioEstoqueTotal()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("                   *** RELATORIO ESTOQUE ***                      ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("COD   DESCRICAO                            PRECO    QTDE     TOTAL");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioEstoque()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("                   *** RELATORIO ESTOQUE ***                      ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("COD   DESCRICAO                                             QTDE  ");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string DespesaSangria(SangriaC sangria)
        {
            try
            {
                sb = new StringBuilder();

                sb.Append(sangria.descricao.ToString() + " - Nº: " + sangria.Qtde.ToString().PadLeft(3, '0'));
                sb.AppendLine(sangria.valor.ToString("C2").PadLeft(47, '.'));

                sb.AppendLine("");
                sb.AppendLine("MOTIVO:" + sangria.Motivo);
                sb.Append("Nº CAIXA: " + sangria.numCaixa.ToString().PadLeft(3, '0'));
                sb.AppendLine(" - OPERADOR(A): " + sangria.nomeUsuario);
                sb.AppendLine("");
                sb.AppendLine("");
                sb.AppendLine("Ass: ______________________________________________");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioVendaRZ(List<VENDAS> listaRelatorioVendaCancelada)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaRelatorioVendaCancelada)
                {
                    sb.AppendLine(item.codoBarra.PadLeft(13, '0').Substring(8, 5) + " " + item.descricao.Trim().PadRight(40, ' ').Substring(0, 36) + " " + item.qtde.ToString().PadLeft(9, ' ') + " " + item.subTotal.PadLeft(10, ' '));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoCupomAberto(CABECALHO cabecalhos)
        {
            try
            {
                GetDadosEmpresa(cabecalhos);

                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine(NOME_RAZAO_SOCIAL.PadRight(44, ' ').Substring(0, 40) + "           ");
                sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                sb.AppendLine("==================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioFechamentoDia()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==================================================================");
                sb.AppendLine("                 *** FORMAS DE PAGAMENTOS ***                     ");
                sb.AppendLine("==================================================================");
                sb.AppendLine("TIPO                                                       VALOR  ");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioDeparatmento(List<FECHAMENTO_DIA> listaFechamento)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaFechamento)
                {
                    sb.AppendLine(item.Tipo.PadRight(45, ' ').Substring(0, 45) + " " + item.Valor.ToString().PadLeft(18, ' '));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
