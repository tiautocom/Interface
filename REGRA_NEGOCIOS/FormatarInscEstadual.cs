using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REGRA_NEGOCIOS
{
    public class FormatarInscEstadual
    {
        string ret = "";

        public string FormatarIe(string uf)
        {
            try
            {
                if (uf.ToUpper().Equals("AC"))
                {
                    ret = "00.000.000/000-00";
                }
                else if (uf.ToUpper().Equals("AL"))
                {
                    ret = "000000000";
                }
                else if (uf.ToUpper().Equals("AP"))
                {
                    ret = "000000000";
                }
                else if (uf.ToUpper().Equals("AM"))
                {
                    ret = "00.000.000-0";
                }
                else if (uf.ToUpper().Equals("BA"))
                {
                    ret = "00000-00";
                }
                else if (uf.ToUpper().Equals("CE"))
                {
                    ret = "00000000-0";
                }
                else if (uf.ToUpper().Equals("DF"))
                {
                    ret = "00000000000-00";
                }
                else if (uf.ToUpper().Equals("ES"))
                {
                    ret = "00000000-0";
                }
                else if (uf.ToUpper().Equals("GO"))
                {
                    ret = "00.000.000-0";
                }
                else if (uf.ToUpper().Equals("MA"))
                {
                    ret = "00000000-0";
                }
                else if (uf.ToUpper().Equals("MT"))
                {
                    ret = "0000000000-0";
                }
                else if (uf.ToUpper().Equals("MS"))
                {
                    ret = "00000000-0";
                }
                else if (uf.ToUpper().Equals("MG"))
                {
                    ret = "000.000.000/0000";
                }
                else if (uf.ToUpper().Equals("PR"))
                {
                    ret = "000.00000-00";
                }
                else if (uf.ToUpper().Equals("PE"))
                {
                    ret = "0000000-00";
                }
                else if (uf.ToUpper().Equals("PI"))
                {
                    ret = "00000000-0";
                }
                else if (uf.ToUpper().Equals("RJ"))
                {
                    ret = "00.000.00-0";
                }
                else if (uf.ToUpper().Equals("RN"))
                {
                    ret = "00.000.000-0";
                }
                else if (uf.ToUpper().Equals("RS"))
                {
                    ret = "000/0000000";
                }
                else if (uf.ToUpper().Equals("RO"))
                {
                    ret = "0000000000000-0";
                }
                else if (uf.ToUpper().Equals("RR"))
                {
                    ret = "00000000-0";
                }
                else if (uf.ToUpper().Equals("SP"))
                {
                    ret = "000.000.000.000";
                }
                else if (uf.ToUpper().Equals("SC"))
                {
                    ret = "000.000.000";
                }
                else if (uf.ToUpper().Equals("SE"))
                {
                    ret = "00000000-0";
                }
                else if (uf.ToUpper().Equals("TO"))
                {
                    ret = "0000000000-0";
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
