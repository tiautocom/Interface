using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OBJETO_TRANSFERENCIA
{
    public class FILTRAR
    {
        public string RemoverAcentos(string texto)
        {
            try
            {
                string s = texto.Normalize(NormalizationForm.FormD);

                StringBuilder sb = new StringBuilder();

                for (int k = 0; k < s.Length; k++)
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);

                    if (uc != UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(s[k]);
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RemoverCaracteres(string valor)
        {
            valor = Regex.Replace(valor, "[ÁÀÂÃ]", "A");
            valor = Regex.Replace(valor, "[ÉÈÊ]", "E");
            valor = Regex.Replace(valor, "[Í]", "I");
            valor = Regex.Replace(valor, "[ÓÒÔÕ]", "O");
            valor = Regex.Replace(valor, "[ÚÙÛÜ]", "U");
            valor = Regex.Replace(valor, "[Ç]", "C");
            valor = Regex.Replace(valor, "[áàâã]", "a");
            valor = Regex.Replace(valor, "[éèê]", "e");
            valor = Regex.Replace(valor, "[í]", "i");
            valor = Regex.Replace(valor, "[óòôõ]", "o");
            valor = Regex.Replace(valor, "[úùûü]", "u");
            valor = Regex.Replace(valor, "[ç]", "c");
            valor = Regex.Replace(valor, "[&]", " E ");
            valor = Regex.Replace(valor, "[']", " ");
            valor = Regex.Replace(valor, "[,]", " ");
            valor = Regex.Replace(valor, "[.]", " ");
            valor = Regex.Replace(valor, "[-]", "");
            valor = Regex.Replace(valor, "[/]", "");
            valor = Regex.Replace(valor, "[(]", "");
            valor = Regex.Replace(valor, "[)]", "");
            valor = Regex.Replace(valor, "[.]", "");
            valor = Regex.Replace(valor, " ", "");

            return valor;
        }
    }
}
