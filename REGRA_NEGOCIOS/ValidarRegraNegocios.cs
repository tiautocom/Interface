using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace REGRA_NEGOCIOS
{
    public class ValidarRegraNegocios
    {
        #region VARIAVEL

        private static string ErroValidadorXML;
        bool ret;
        string message = "";

        #endregion

        public bool ValidarEnvio(string arquivoXML, string schemaXML)
        {
            try
            {
                XmlReaderSettings xmlSettings = new XmlReaderSettings();
                xmlSettings.ValidationType = ValidationType.Schema;
                xmlSettings.Schemas.Add(null, schemaXML);
                xmlSettings.ValidationEventHandler += new ValidationEventHandler(xmlSettingsValidationEventHandler);

                XmlReader xml = XmlReader.Create(arquivoXML, xmlSettings);
                ErroValidadorXML = string.Empty;
                while (xml.Read()) { }
                xml.Close();

                if (!string.IsNullOrEmpty(ErroValidadorXML))
                    throw new SchemaXmlException(ErroValidadorXML);

                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw new Exception(ex.Message + ErroValidadorXML + "Falha do Schema");
            }

            return ret;
        }

        public class SchemaXmlException : Exception
        {
            private string ErroValidadorXML;

            public SchemaXmlException(string ErroValidadorXML)
            {
                // TODO: Complete member initialization
                this.ErroValidadorXML = ErroValidadorXML;
            }
        }

        private void xmlSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.Severity == XmlSeverityType.Warning)
                    ErroValidadorXML += "Cuidado: \n" + e.Message + "\n";

                else if (e.Severity == XmlSeverityType.Error)
                    ErroValidadorXML += "ERRO: \n" + e.Message + "\n";

                else
                    ErroValidadorXML += "ERRO: \n" + e.Message + "\n";

                message = ErroValidadorXML.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsCpf(string cpf)
        {
            try
            {
                bool ret = TratarCpf(cpf);

                if (ret == false)
                {
                    return false;
                }
                else
                {
                    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    string tempCpf;
                    string digito;
                    int soma;
                    int resto;

                    cpf = cpf.Trim();
                    cpf = cpf.Replace(",", "").Replace("-", "");

                    if (cpf.Length != 11)
                        return false;

                    tempCpf = cpf.Substring(0, 9);
                    soma = 0;
                    for (int i = 0; i < 9; i++)
                        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                    resto = soma % 11;
                    if (resto < 2)
                        resto = 0;
                    else
                        resto = 11 - resto;

                    digito = resto.ToString();

                    tempCpf = tempCpf + digito;

                    soma = 0;
                    for (int i = 0; i < 10; i++)
                        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                    resto = soma % 11;
                    if (resto < 2)
                        resto = 0;
                    else
                        resto = 11 - resto;

                    digito = digito + resto.ToString();

                    return cpf.EndsWith(digito);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool TratarCpf(string cpf)
        {
            try
            {
                string um = "";
                string dois = "";
                string tres = "";
                string quatro = "";
                string cinco = "";
                string seis = "";
                string sete = "";
                string oito = "";
                string nove = "";
                string zero = "";

                um = um.PadLeft(11, '1');
                dois = dois.PadLeft(11, '2');
                tres = tres.PadLeft(11, '3');
                quatro = quatro.PadLeft(11, '4');
                cinco = cinco.PadLeft(11, '5');
                seis = seis.PadLeft(11, '6');
                sete = sete.PadLeft(11, '7');
                oito = oito.PadLeft(11, '8');
                nove = nove.PadLeft(11, '9');
                zero = zero.PadLeft(11, '0');

                if ((cpf.Trim() == um) || (cpf.Trim() == dois) || (cpf.Trim() == tres) || (cpf.Trim() == quatro) || (cpf.Trim() == cinco) || (cpf.Trim() == seis) || (cpf.Trim() == seis) || (cpf.Trim() == oito) || (cpf.Trim() == nove) || (cpf.Trim() == zero))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public bool IsCnpj(string cnpj)
        {
            try
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;

                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

                if (cnpj.Length != 14)
                    return false;

                tempCnpj = cnpj.Substring(0, 12);

                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cnpj.EndsWith(digito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
