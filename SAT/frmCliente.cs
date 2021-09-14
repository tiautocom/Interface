using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PVe
{
    public partial class frmCliente : Form
    {

        string impressora = "";

        public decimal LimiteCliente, gastoCliente, somaTotalCompra, gastoAtual = 0;
        public int idCliente = 0;

        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
        }

        private void frmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void frmCliente_Load_1(object sender, EventArgs e)
        {

        }
    }
}