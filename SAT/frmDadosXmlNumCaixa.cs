using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace SAT
{
    public partial class frmDadosXmlNumCaixa : Form
    {
        public frmDadosXmlNumCaixa()
        {
            InitializeComponent();
        }

        #region CLASSES E OBJETOS

        #endregion

        #region VARIAVEIS

        string idDados = "";

        #endregion

        #region PATH

        public string pathDados = Path.GetDirectoryName(Application.ExecutablePath) + "\\BANCO\\NUM_CAIXA.xml";

        #endregion

        private void frmDadosXmlNumCaixa_Load(object sender, EventArgs e)
        {
            LerConfiglXml();
        }

        public void LerConfiglXml()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(pathDados);

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "ID")
                        txtCodigoXml.Text = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "Num")
                        txtNumCaixa.Text = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "NumComBal")
                        txtComBalanca.Text = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "BoundRoute")
                        txtBondRoute.Text = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "NumComImp")
                        txtComImpressora.Text = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "Impressora")
                        txtImpressora.Text = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "PathXmlCupom")
                        txtPahtXmlCupom.Text = (x.ReadString());

                    if (x.NodeType == XmlNodeType.Element && x.Name == "PathXmlCupomResp")
                        txtPathXmlCupomResp.Text = (x.ReadString());
                }

                x.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarDadosXml()
        {
            try
            {
                XElement xml = XElement.Load(pathDados);
                XElement x = xml.Elements().Where(pXml => pXml.Element("ID_COD").Value.Equals("1")).FirstOrDefault();

                if (x != null)
                {
                    x.Element("Num").SetValue(txtNumCaixa.Text.Trim());
                    x.Element("NumComBal").SetValue(txtComBalanca.Text.Trim());
                    x.Element("BoundRoute").SetValue(txtBondRoute.Text.Trim());
                    x.Element("NumComImp").SetValue(txtComImpressora.Text.Trim());
                    x.Element("Impressora").SetValue(txtImpressora.Text.Trim());
                    x.Element("PathXmlCupom").SetValue(txtPahtXmlCupom.Text.Trim());
                    x.Element("PathXmlCupomResp").SetValue(txtPathXmlCupomResp.Text.Trim());
                }

                xml.Save(pathDados);

                MessageBox.Show("Dados XML foi Alterado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarDadosXml();
        }
    }
}
