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
    public partial class frmAviso : Form
    {
        public frmAviso()
        {
            InitializeComponent();
        }

        int milesegundos = 0;
        long tempoTotal;

        private void frmAviso_Load(object sender, EventArgs e)
        {
            Espera();
        }

        public void Espera()
        {
            long t = DateTime.Now.Millisecond;

            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine(i);
                milesegundos = Convert.ToInt32(i);
            }

            tempoTotal = (DateTime.Now.Millisecond - t);
            Application.Exit();
        }
    }
}
