using ACESSO_DADOS;
using OBJETO_TRANSFERENCIA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace REGRA_NEGOCIOS
{
    public class ESCPOS
    {
        Conexao conexaoSqlServer = new Conexao();

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

        public string CabecalhoCupomComum(CABECALHO cabecalho)
        {
            try
            {
                GetDadosEmpresa(cabecalho);

                sb = new StringBuilder();

                sb.AppendLine("==============================================================");
                sb.AppendLine(NOME_RAZAO_SOCIAL + "                                          ");
                sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                sb.AppendLine("==============================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
                CPF_CNPJ_CONSUMIDOR = cab.CnpjCliente.Trim() ?? null ?? "";
                nCFe = cab.nCFe.Trim() ?? null ?? "";
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

                sb.AppendLine("================================================================");
                sb.AppendLine("                  *** RELATORIO SETOR(ES) ***                   ");
                sb.AppendLine("================================================================");
                sb.AppendLine("SETOR  DESCRICAO                                           TOTAL");

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
                    sb.AppendLine(item.DesSetor + "    " + item.Descricao.PadRight(38, ' ').Substring(0, 38) + " " + item.Valor.ToString().PadLeft(18, ' '));
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
                sb.AppendLine("============================================================");
                sb.AppendLine("TOTAL" + somaTotal.ToString("C2").Trim().PadLeft(59, '.'));
                sb.Append("Nº CAIXA: " + numCaixa.ToString().Trim().PadLeft(3, '0'));
                sb.AppendLine(" - OPERADOR: " + nomeOperador.Trim());
                sb.AppendLine("DATA: " + DateTime.Now.Date.ToLongDateString());
                sb.AppendLine("                         *** FIM ***                         ");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioDepartamento(List<DepartamentoC> listaDepartamento)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaDepartamento)
                {
                    sb.AppendLine(item.idDepartamento.PadLeft(0, '3').Substring(0, 3) + "    " + item.descricaoDep.PadRight(38, ' ').Substring(0, 38) + " " + item.Valor.ToString().PadLeft(18, ' '));
                }

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

                sb.AppendLine("================================================================");
                sb.AppendLine("                *** RELATORIO DEPARTAMENTO ***                  ");
                sb.AppendLine("================================================================");
                sb.AppendLine("DEP    DESCRICAO                                           TOTAL");

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

                sb.AppendLine("================================================================");
                sb.AppendLine("             *** RELATORIO VENDA(S) CANCELADA(S) ***            ");
                sb.AppendLine("================================================================");
                sb.AppendLine("COD   DESCRICAO           UNID  PRECO    QTDE    TOTAL   ESTOQUE");

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
                    sb.AppendLine(item.codoBarra.PadLeft(13, '0').Substring(8, 5) + " " + item.descricao.Replace("VENDA CANC. -", "").Trim().PadRight(20, ' ').Substring(0, 18) + " " + item.unid.Trim() + " " + item.precoProd.ToString().PadLeft(8, ' ') + " " + " " + item.qtde.ToString().PadLeft(7, ' ') + " " + item.precoProd.ToString().PadLeft(7, ' ') + " " + item.subTotal.PadLeft(8, ' '));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string CorpoRelatorioVenda(List<VENDAS> listaRelatorioVendaCancelada)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaRelatorioVendaCancelada)
                {
                    sb.AppendLine(item.codoBarra.PadLeft(13, '0').Substring(8, 5) + " " + item.descricao.Replace("VENDA CANC. -", "").Trim().PadRight(40, ' ').Substring(0, 36) + " " + " " + item.qtde.ToString().PadLeft(9, ' ') + " " + item.subTotal.ToString().PadLeft(8, ' '));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioVendas(List<VENDAS> listaRelatorioVendaCancelada)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaRelatorioVendaCancelada)
                {
                    sb.AppendLine(item.codoBarra.PadLeft(13, '0').Substring(8, 5) + " " + item.descricao.Replace("VENDA CANC. -", "").Trim().PadRight(30, ' ').Substring(0, 30) + " " + item.unid.Trim() + " " + item.precoProd.ToString().PadLeft(8, ' ') + " " + " " + item.qtde.ToString().PadLeft(7, ' ') + " " + item.precoProd.ToString().PadLeft(7, ' '));
                }

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

                sb.AppendLine("================================================================");
                sb.AppendLine("                 *** RELATORIO VENDA TOTAL ***                  ");
                sb.AppendLine("================================================================");
                sb.AppendLine("COD   DESCRICAO           UNID   PRECO   QTDE    TOTAL   ESTOQUE");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioVenda()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("==============================================================");
                sb.AppendLine("                *** RELATORIO VENDA TOTAL ***                 ");
                sb.AppendLine("==============================================================");
                sb.AppendLine("COD   DESCRICAO                                QTDE     TOTAL ");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioVendaDetalhes()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("================================================================");
                sb.AppendLine("                 *** RELATORIO VENDA TOTAL ***                  ");
                sb.AppendLine("================================================================");
                sb.AppendLine("COD   DESCRICAO            UNID        PRECO    QTDE     TOTAL  ");

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

                sb.AppendLine("================================================================");
                sb.AppendLine("                  *** RELATORIO ESTOQUE ***                     ");
                sb.AppendLine("================================================================");
                sb.AppendLine("COD   DESCRICAO                          PRECO    QTDE     TOTAL");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioEstoques()
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("================================================================");
                sb.AppendLine("                  *** RELATORIO ESTOQUE ***                     ");
                sb.AppendLine("================================================================");
                sb.AppendLine("COD   DESCRICAO                                      QTDE       ");

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
                    sb.AppendLine(item.codoBarra.PadLeft(13, '0').Substring(8, 5) + " " + item.descricao.Replace("VENDA CANC. -", "").Trim().PadRight(30, ' ').Substring(0, 28) + " " + item.precoProd.ToString().PadLeft(9, ' ') + " " + " " + item.qtde.ToString().PadLeft(9, ' ') + " " + item.subTotal.ToString().PadLeft(8, ' '));
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioEstoquesTotal(List<VENDAS> listaRelatorio)
        {
            try
            {
                sb = new StringBuilder();

                foreach (var item in listaRelatorio)
                {
                    sb.AppendLine(item.codoBarra.PadLeft(13, '0').Substring(8, 5) + " " + item.descricao.Replace("VENDA CANC. -", "").Trim().PadRight(45, ' ').Substring(0, 45) + " " + item.estoque.ToString().PadLeft(9, ' '));
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
                    sb.AppendLine("===============================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL + "                                           ");
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("================================================================");
                    sb.AppendLine("CPF CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                    sb.AppendLine("================================================================");
                    sb.AppendLine("                 CUPOM FISCAL ELETRONICO - SAT                  ");
                    sb.AppendLine("                       EXTRATO Nº: " + nCFe + "                 ");
                    sb.AppendLine("                      *** SEGUNDA VIA ***                       ");
                    sb.AppendLine("================================================================");
                    sb.AppendLine("ITEM CODIGO DESCRICAO             UNID   PRECO X QTDE TOTAL(R$) ");
                    sb.AppendLine("----------------------------------------------------------------");
                }
                else
                {
                    sb.AppendLine("===============================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL.PadRight(44, '-').Trim().Substring(0, 44) + linha);
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("================================================================");
                    sb.AppendLine("CPF CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                    sb.AppendLine("================================================================");
                    sb.AppendLine("                      *** SEGUNDA VIA ***                       ");
                    sb.AppendLine("================================================================");
                    sb.AppendLine("ITEM CODIGO DESCRICAO             UNID   PRECO X QTDE TOTAL(R$) ");
                    sb.AppendLine("----------------------------------------------------------------");
                }

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
                    string cod = item.codoBarra.PadLeft(13, '0').Substring(7, 5);
                    string unid = item.unid.Trim();
                    string desc = item.descricao.PadRight(28, ' ').Substring(0, 24);
                    string q = item.qtde.ToString().PadLeft(8, ' ');
                    string p = item.precoProd.ToString().PadLeft(7, ' ');
                    string tt = item.subTotal.ToString().PadLeft(7, ' ');
                    decimal tot = Convert.ToDecimal(item.subTotal);

                    descricaoVenda += (itens + "  " + cod + " " + desc + " " + unid + " " + q + " " + p + "  " + tt + "\r");
                }

                sb.Append(descricaoVenda);
                sb.AppendLine("===============================================================");

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

                    des = item.Descricao.PadRight(51, ' ');
                    valor = item.Valor.Trim().PadLeft(10, ' ');
                    troco = Convert.ToDecimal(item.Troco);

                    cont++;

                    descricaoPagamentos += (des + " " + valor + "\n");
                }

                sb.Append(descricaoPagamentos);

                sb.AppendLine("TOTAL: " + total.ToString("N2").Trim().PadLeft(55, ' '));
                sb.AppendLine("_____________________".Trim().PadLeft(63, ' '));
                sb.AppendLine("TROCO: " + troco.ToString("N2").Trim().PadLeft(55, ' '));
                sb.AppendLine("QTDE ITEM: " + cont.ToString().PadLeft(3, '0'));

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DadosFinaisCupom(VENDA_DETALHES vendaDetalhes, bool bandeira, int tipoVenda)
        {
            try
            {
                sb = new StringBuilder();

                if (tipoVenda == 1)
                {
                    if (bandeira == true)
                    {
                        sb.Append("================================================================" + linha);
                        sb.Append("       Consulte seu QRCode Cupom no App de Olho na Nota.        " + linha);
                        sb.Append("================================================================" + linha);
                        sb.Append("               *** OBSERVACAO DO CONTRIBUINTE ***               " + linha);
                        sb.Append("Fonte IBPT R$ Aproximado Conforme a Lei: 12.741/12              " + linha);
                        sb.Append("Valor Aproximado Tributo: " + vendaDetalhes.valorAliquota.ToString("C2") + "." + linha);
                        sb.Append("OPERADOR: " + vendaDetalhes.nomeOperador.Trim() + " - TURNO: " + vendaDetalhes.periodo);
                        sb.Append(" - CAIXA: " + vendaDetalhes.numCaixa.ToString().Trim().PadLeft(3, '0'));
                        sb.Append(" - Nº VENDA: " + vendaDetalhes.numVenda.ToString().Trim().PadLeft(7, '0') + linha);
                    }
                    else
                    {
                        sb.Append("================================================================" + linha);
                        sb.Append("               *** OBSERVACAO DO CONTRIBUINTE ***               " + linha);
                        sb.Append("Valor Aproximado Tributo: " + vendaDetalhes.valorAliquota.ToString("C2") + "." + linha);
                        sb.Append("OPERADOR: " + vendaDetalhes.nomeOperador.Trim() + " - TURNO: " + vendaDetalhes.periodo);
                        sb.Append(" - CAIXA: " + vendaDetalhes.numCaixa.ToString().Trim().PadLeft(3, '0'));
                        sb.Append(" - Nº VENDA: " + vendaDetalhes.numVenda.ToString().Trim().PadLeft(7, '0') + linha);
                    }

                    if (vendaDetalhes.desPlaca != "")
                    {
                        sb.Append(vendaDetalhes.desPlaca + " " + vendaDetalhes.placa + "  KM - " + vendaDetalhes.km + linha);
                    }

                    sb.Append(vendaDetalhes.msg + linha);
                }
                else
                {
                    sb.Append("================================================================" + linha);
                    sb.Append("Numero: " + vendaDetalhes.numVenda.ToString().Trim().PadLeft(7, '0'));
                    sb.Append(" - Serie: " + vendaDetalhes.serie.ToString().Trim().PadLeft(3, '0'));
                    sb.Append(" - Emissao: " + Convert.ToDateTime(vendaDetalhes.dhRecbto).ToString("dd/MM/yyyy HH:mm:ss").Trim() + linha);
                    sb.Append("================================================================" + linha);
                    sb.Append("Protocolo de Autorização: " + vendaDetalhes.nProt + " - " + DateTime.Now.ToString() + linha);
                    sb.Append("================================================================" + linha);
                }

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

                sb.Append("================================================================" + linha);
                sb.Append("                   DATA: " + data + linha);
                sb.Append("                     SAT NUMERO : " + nserieSAT.Trim() + linha);
                sb.Append("================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoCupom(CABECALHO cabecalho, string nCFe, bool bandeira, int tipoVenda)
        {
            try
            {
                GetDadosEmpresa(cabecalho);

                sb = new StringBuilder();

                if (tipoVenda == 1)
                {
                    if (bandeira == true)
                    {
                        sb.AppendLine("===============================================================");
                        sb.AppendLine(NOME_RAZAO_SOCIAL + "                                           ");
                        sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                        sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                        sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                        sb.AppendLine("================================================================");
                        sb.AppendLine("CPF/CNPJ CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                        sb.AppendLine("================================================================");
                        sb.AppendLine("                 CUPOM FISCAL ELETRONICO - SAT                  ");
                        sb.AppendLine("                      EXTRATO Nº: " + nCFe + "                  ");
                        sb.AppendLine("================================================================");
                        sb.AppendLine("ITEM CODIGO DESCRICAO             UNID   QTDE X PRECO TOTAL(R$) ");
                        sb.AppendLine("----------------------------------------------------------------");
                    }
                    else
                    {
                        sb.AppendLine("===============================================================");
                        sb.AppendLine(NOME_RAZAO_SOCIAL + "                                           ");
                        sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                        sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                        sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                        sb.AppendLine("================================================================");
                        sb.AppendLine("CPF/CNPJ CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                        sb.AppendLine("================================================================");
                        sb.AppendLine("ITEM CODIGO DESCRICAO             UNID   QTDE X PRECO TOTAL(R$) ");
                        sb.AppendLine("----------------------------------------------------------------");
                    }
                }
                else
                {
                    //NFCE
                    sb.AppendLine("===============================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL.PadRight(44, '-').Trim().Substring(0, 44) + linha);
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("================================================================");
                    sb.AppendLine("                       DANFE NFC-E                              ");
                    sb.AppendLine("         Documento Auxiliar de Nota Fiscal de Consumeidor       ");
                    sb.AppendLine("           NÃO PERMITE APROVEITAMENTO DE CREDITO ICMS           ");
                    sb.AppendLine("================================================================");
                    sb.AppendLine("ITEM CODIGO DESCRICAO             UNID   QTDE X PRECO TOTAL(R$) ");
                    sb.AppendLine("----------------------------------------------------------------");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoCupomVendaAberto(CABECALHO cabecalho, string chave, bool cupomFiscal)
        {
            try
            {
                GetDadosEmpresa(cabecalho);

                sb = new StringBuilder();

                if (cupomFiscal == true)
                {
                    sb.AppendLine("===============================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL + "                                           ");
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("================================================================");
                    sb.AppendLine("CPF/CNPJ CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                    sb.AppendLine("================================================================");
                    sb.AppendLine("              CHAVE CUPOM FISCAL ELETRONICO - SAT               ");
                    sb.AppendLine("                  NUMERO: " + chave);
                    sb.AppendLine("================================================================");
                }
                else
                {
                    sb.AppendLine("===============================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL + "                                           ");
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("================================================================");
                    sb.AppendLine("CPF/CNPJ CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                    sb.AppendLine("================================================================");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoRelatorioFormaPagamento(List<PAGAMENTO_VENDA> listaRelatorioFormaPagamento)
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("================================================================");
                sb.AppendLine("               *** RELATORIO FORMA PAGAMENTO ***                ");
                sb.AppendLine("================================================================");
                sb.AppendLine("COD   DESCRICAO                                            TOTAL");

                foreach (var item in listaRelatorioFormaPagamento)
                {
                    sb.AppendLine(item.Id.ToString().PadLeft(0, '3') + "    " + item.Descricao.PadRight(40, ' ').Substring(0, 40) + " " + item.Valor.ToString().PadLeft(18, ' '));
                }

                return sb.ToString();

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

                sb.AppendLine("                 CUPOM FISCAL ELETRONICO - SAT                  ");
                sb.AppendLine("                    EXTRATO Nº: " + nCFe + "                    ");
                sb.AppendLine("================================================================");

                return sb.ToString();
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

                sb.AppendLine("================================================================");
                sb.AppendLine(NOME_RAZAO_SOCIAL + "                                           ");
                sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TELEFONE: " + TELEFONE);
                sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                sb.AppendLine("================================================================");

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
                sb.AppendLine(sangria.valor.ToString("C2").PadLeft(45, '.'));

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

        public string CabecalhoCancelamentoSat(string nserieSAT, string nCFe)
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine("                  CUPOM FISCAL ELETRONICO - SAT                 ");
                sb.AppendLine("                     CANCELAMENTO DE CUPOM                      ");
                sb.AppendLine("                       EXTRATO Nº: " + nCFe + "                 ");
                sb.AppendLine("================================================================");
                sb.AppendLine("                    SAT NUMERO: " + nserieSAT);
                sb.AppendLine("================================================================");
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

                sb.AppendLine("");
                sb.AppendLine(("TOTAL" + valorCancel.ToString().PadLeft(58, '.')));
                sb.AppendLine("================================================================");
                sb.AppendLine("OBSERVACAO DO CONTRIBUINTE                                      ");
                sb.Append("Nº CAIXA: " + numCaixa.ToString().PadLeft(3, '0'));
                sb.Append(" - Nº VENDA: " + (numVenda).ToString().PadLeft(8, '0'));
                sb.AppendLine(" - OPERADOR: " + nomeOperador.Trim());
                sb.Append("================================================================");

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
                    sb.AppendLine(item.Trib.PadLeft(0, '3') + "    " + item.Valor.PadLeft(56, ' ').Substring(0, 56));
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

                sb.AppendLine("================================================================");
                sb.AppendLine("                  *** RELATORIO TRIBUTOS ***                    ");
                sb.AppendLine("================================================================");
                sb.AppendLine("TRIB                                                     TOTAL  ");

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

                sb.Append("              *** COMPROVANTE DE COMPRA EM ABERTO ***           " + linha);
                sb.Append("================================================================" + linha);
                sb.Append(linha);
                sb.Append("VALOR TOTAL............................................" + valorAberto.ToString("C2").Trim() + linha);
                sb.AppendLine("EU " + nomeCliente.Trim() + ".");
                sb.AppendLine("RECONHEÇO E PAGAREI A DIVIDA AQUI REPRESENTADA");
                sb.Append("NO VALOR DE:" + valorAberto.ToString("C2").Trim() + "." + linha);
                sb.Append("ASS:__________________________________________________" + linha);
                sb.Append(linha);
                sb.Append("CAIXA:" + numCaixa.ToString().PadLeft(3, '0').Trim());
                sb.Append("- Nº CUPOM:" + numVenda.ToString().PadLeft(3, '0').Trim() + " - Operador: " + nomeOperador.Trim());
                sb.Append("DATA: " + DateTime.Now.ToString());
                sb.Append(linha);
                sb.Append(linha);
                sb.Append(linha);
                sb.Append(linha);

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DadosChaveCupomAberto(string chave)
        {
            try
            {
                sb = new StringBuilder();

                sb.AppendLine(chave);
                sb.AppendLine("================================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoSegundaViaVendaMp2500(CABECALHO cabecalho, bool cupomFiscal)
        {
            try
            {
                sb = new StringBuilder();

                GetDadosEmpresa(cabecalho);

                if (cupomFiscal == true)
                {
                    sb.AppendLine("==================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL);
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + "/" + UF + ". TEl:" + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("==================================================");
                    sb.AppendLine("CPF CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                    sb.AppendLine("==================================================");
                    sb.AppendLine("           CUPOM FISCAL ELETRONICO - SAT          ");
                    sb.AppendLine("                EXTRATO Nº: " + nCFe + "         ");
                    sb.AppendLine("                *** SEGUNDA VIA ***               ");
                    sb.AppendLine("==================================================");
                    sb.AppendLine("ITEM COD DESCRIC      UNID  PRECO X QTDE TOTAL(R$)");
                    sb.AppendLine("--------------------------------------------------");
                }
                else
                {
                    sb.AppendLine("==================================================");
                    sb.AppendLine(NOME_RAZAO_SOCIAL);
                    sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                    sb.AppendLine("CEP: " + CEP + " - " + CIDADE + "/" + UF + ". TEL:" + TELEFONE);
                    sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                    sb.AppendLine("==================================================");
                    sb.AppendLine("               *** SEGUNDA VIA ***                ");
                    sb.AppendLine("==================================================");
                    sb.AppendLine("ITEM COD DESCRIC      UNID  PRECO X QTDE TOTAL(R$)");
                    sb.AppendLine("--------------------------------------------------");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CorpoCupomMp2500(List<VENDAS> listaVenda, VendaC vendaC)
        {
            try
            {
                sb = new StringBuilder();

                string descricaoVenda = "";

                foreach (var item in listaVenda)
                {
                    string itens = item.itemVenda.ToString().PadLeft(3, '0');
                    string cod = item.codoBarra.PadLeft(13, '0').Substring(7, 5);
                    string unid = item.unid.Trim();
                    string desc = item.descricao.PadRight(28, ' ').Substring(0, 18);
                    string q = item.qtde.ToString().PadLeft(4, ' ');
                    string p = item.precoProd.ToString().PadLeft(5, ' ');
                    string tt = item.subTotal.ToString().PadLeft(5, ' ');
                    decimal tot = Convert.ToDecimal(item.subTotal);

                    descricaoVenda += (itens + " " + cod + " " + desc + " " + unid + " " + q + " " + p + " " + tt + "\t\r");
                }

                sb.Append(descricaoVenda);
                sb.AppendLine("==================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string FormaPagamentoMp2500(List<FORMA_PAGAMENTOS> listaFomaPagamentos, decimal totalVenda)
        {
            try
            {
                sb = new StringBuilder();

                string descricaoPagamentos = "";
                string des, valor = "";
                decimal totalPagamento = 0;
                decimal troco = 0;
                int cont = 0;

                foreach (var item in listaFomaPagamentos)
                {
                    des = item.Descricao.PadRight(43, ' ');
                    valor = item.Valor.Trim().PadLeft(10, ' ');
                    troco = Convert.ToDecimal(item.Troco);

                    cont++;

                    descricaoPagamentos += (des + " " + Convert.ToDecimal(valor).ToString("N2") + "\n");
                }

                sb.Append(descricaoPagamentos);

                sb.AppendLine("TOTAL: " + totalVenda.ToString("N2").Trim().PadLeft(42, ' '));
                sb.AppendLine("_____________________".Trim().PadLeft(49, ' '));
                sb.AppendLine("TROCO: " + troco.ToString("N2").Trim().PadLeft(42, ' '));
                sb.AppendLine("QTDE ITEM: " + cont.ToString().PadLeft(3, '0'));

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DadosFinaisCupomMp2500(VENDA_DETALHES vendaDetalhe, bool cupomFiscal)
        {
            try
            {
                sb = new StringBuilder();

                if (cupomFiscal == true)
                {
                    sb.Append("==================================================" + linha);
                    sb.Append("Consulte seu QRCode Cupom no App de Olho na Nota  " + linha);
                    sb.Append("==================================================" + linha);
                    sb.Append("         *** OBSERVACAO DO CONTRIBUINTE ***       " + linha);
                    sb.Append("==================================================" + linha);
                    sb.Append("Fonte IBPT R$ Aproximado Conforme a Lei: 12.741/12" + linha);
                    sb.Append("Valor Aproximado Tributo: " + vendaDetalhe.valorAliquota.ToString("C2") + "." + linha);
                    sb.Append("OPERADOR: " + vendaDetalhe.nomeOperador.Trim() + " - TURNO: " + vendaDetalhe.periodo);
                    sb.Append(" - CAIXA: " + vendaDetalhe.numCaixa.ToString().Trim().PadLeft(3, '0') + linha);
                    sb.Append("Nº VENDA: " + vendaDetalhe.numVenda.ToString().Trim().PadLeft(7, '0') + linha);
                    sb.Append("DATA: " + DateTime.Now.ToString() + linha);
                }
                else
                {
                    sb.Append("==================================================" + linha);
                    sb.Append("         *** OBSERVACAO DO CONTRIBUINTE ***       " + linha);
                    sb.Append("==================================================" + linha);
                    sb.Append("OPERADOR: " + vendaDetalhe.nomeOperador.Trim() + " - TURNO: " + vendaDetalhe.periodo);
                    sb.Append(" - CAIXA: " + vendaDetalhe.numCaixa.ToString().Trim().PadLeft(3, '0') + linha);
                    sb.Append("Nº VENDA: " + vendaDetalhe.numVenda.ToString().Trim().PadLeft(7, '0') + linha);
                    sb.Append("DATA: " + DateTime.Now.ToString() + linha);
                    sb.Append("                   *** FIM ***                   ");
                }

                if (vendaDetalhe.desPlaca != "")
                {
                    sb.Append(vendaDetalhe.desPlaca + "  - " + vendaDetalhe.km + linha);
                }

                sb.Append(vendaDetalhe.msg + linha);

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DadosSatMp2500(string nserieSAT, string dataVenda)
        {
            try
            {
                sb = new StringBuilder();

                sb.Append("==================================================" + linha);
                sb.Append("             DATA: " + dataVenda + linha);
                sb.Append("               SAT NUMERO : " + nserieSAT.Trim() + linha);
                sb.Append("==================================================");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoCupomMp2500(CABECALHO cabecalhos, string nCFe, bool cupomFiscal)
        {
            try
            {
                GetDadosEmpresa(cabecalhos);

                sb = new StringBuilder();

                sb.AppendLine("==================================================");
                sb.AppendLine(NOME_RAZAO_SOCIAL + "                              ");
                sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + " - TEL: " + TELEFONE);
                sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                sb.AppendLine("==================================================");
                sb.AppendLine("CPF/CNPJ CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);
                sb.AppendLine("==================================================");
                sb.AppendLine("          CUPOM FISCAL ELETRONICO - SAT           ");
                sb.AppendLine("               EXTRATO Nº: " + nCFe + "           ");
                sb.AppendLine("==================================================");
                sb.AppendLine("ITEM COD DESCRI        UNID QTDE X PRECO TOTAL(R$)");
                sb.AppendLine("--------------------------------------------------");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CupomVendaAbertoMp2500(decimal valorAberto, string nomeCliente, int numCaixa, int numVenda, string nomeOperador)
        {
            try
            {
                sb = new StringBuilder();

                sb.Append("      *** COMPROVANTE DE COMPRA EM ABERTO ***     " + linha);
                sb.Append("==================================================" + linha);
                sb.Append(linha);
                sb.Append("VALOR TOTAL..............................." + valorAberto.ToString("C2").Trim() + linha);
                sb.AppendLine("EU " + nomeCliente.Trim() + ".");
                sb.AppendLine("RECONHEÇO E PAGAREI A DIVIDA AQUI REPRESENTADA");
                sb.Append("NO VALOR DE:" + valorAberto.ToString("C2").Trim() + "." + linha);
                sb.Append("ASS:_____________________________________________" + linha);
                sb.Append(linha);
                sb.Append("CAIXA: " + numCaixa.ToString().PadLeft(3, '0').Trim());
                sb.Append("Nº CUPOM: " + numVenda.ToString().PadLeft(3, '0').Trim());
                sb.Append(" - OPERADOR: " + nomeOperador.Trim());
                sb.Append("DATA : " + DateTime.Now.ToString().Trim());
                sb.Append(linha);
                sb.Append(linha);
                sb.Append(linha);
                sb.Append(linha);
                sb.Append(linha);

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CabecalhoCupomVendaAbertoMp2500(CABECALHO cabecalho, string nCFe, bool cupomFiscal)
        {
            try
            {
                GetDadosEmpresa(cabecalho);

                sb = new StringBuilder();

                sb.AppendLine("==================================================");
                sb.AppendLine(NOME_RAZAO_SOCIAL + "                              ");
                sb.AppendLine(ENDERECO + ", " + NUMERO + " - " + BAIRRO);
                sb.AppendLine("CEP: " + CEP + " - " + CIDADE + " " + UF + "TEL: " + TELEFONE);
                sb.AppendLine("CNPJ: " + CNPJ + " - " + IE);
                sb.AppendLine("==================================================");
                sb.AppendLine("     CPF/CNPJ CONSUMIDOR: " + CPF_CNPJ_CONSUMIDOR);

                if (cupomFiscal == true)
                {
                    sb.AppendLine("==================================================");
                    sb.AppendLine("       CHAVE CUPOM FISCAL ELETRONICO - SAT        ");
                    sb.AppendLine("          " + nCFe);
                    sb.AppendLine("==================================================");
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
