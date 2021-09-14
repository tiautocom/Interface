using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAT
{
    public partial class frmAvisoProibido : Form
    {
        frmVenda frmVenda;

        public frmAvisoProibido(frmVenda fVenda)
        {
            InitializeComponent();
            this.frmVenda = fVenda;
        }

        DateTime dataServidor;
        public string dt = "";
        //TEMPO
        private int time = -1;

        private void frmAvisoProibido_Load(object sender, EventArgs e)
        {
            IniciarTempo();
        }

        public void IniciarTempo()
        {
            timer1.Interval = 100;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmAvisoProibido fAviso = new frmAvisoProibido(frmVenda);

            if (time >= 10)
            {
                timer1.Enabled = false;
                this.Close();
                timer1.Stop();
            }
            else
            {
                time = (time + 1);
            }
        }
    }
}
