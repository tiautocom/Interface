using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REGRA_NEGOCIOS
{
    public class GerarChaveRegraNegocios
    {
        public int digitoRetorno = 0;

        public string GerarChave(int numVenda, string cnpjEmitente, string cUf, int sessao)
        {
            try
            {
                String AA = DateTime.Now.Year.ToString().Substring(2).Trim();
                String MM = DateTime.Now.Month.ToString().PadLeft(3, '0').Substring(1, 2).Trim();

                String dataAAMM = (AA + MM);

                digitoRetorno = 0;

                String mod = "65";
                String serie = "001";
                String tpEmis = "1";
                String cNF = sessao.ToString();
                String nNF = numVenda.ToString().Trim();

                StringBuilder str_chave = new StringBuilder();

                str_chave.Append(lpadTo(cUf, 2, '0'));
                str_chave.Append(lpadTo(dataAAMM, 4, '0'));
                str_chave.Append(lpadTo(cnpjEmitente.Replace(".", "").Replace("/", "").Replace("-", "").Trim(), 14, '0'));
                str_chave.Append(lpadTo(mod, 2, '0'));
                str_chave.Append(lpadTo(serie, 3, '0'));
                str_chave.Append(lpadTo(nNF, 9, '0'));
                str_chave.Append(lpadTo(tpEmis, 1, '0'));
                str_chave.Append(lpadTo(cNF, 8, '0'));

                string chave = str_chave.ToString();

                int soma = 0;

                int resto = 0;

                int[] peso = { 4, 3, 2, 9, 8, 7, 6, 5 };

                for (int i = 0; i < str_chave.Length; i++)
                {
                    soma += peso[i % 8] * (int.Parse(chave.Substring(i, 1)));
                }

                resto = soma % 11;

                if (resto == 0 || resto == 1)
                {
                    digitoRetorno = 0;
                }
                else
                {
                    digitoRetorno = 11 - resto;
                }

                return str_chave.ToString() + digitoRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static String lpadTo(String input, int width, char ch)
        {
            String strPad = "";

            StringBuilder sb = new StringBuilder();
            sb = new StringBuilder(input.Trim());

            while (sb.Length < width)
                sb.Insert(0, ch);
            strPad = sb.ToString();

            if (strPad.Length > width)
            {
                strPad = strPad.Substring(0, width);
            }

            return strPad;
        }
    }
}
