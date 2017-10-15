using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallPostgre.DAO;


namespace CallPostgre
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Divisao div = new Divisao();

            div = DivisaoDAO.ObterDivisaoId(1);
            if (div != null)
            {
                MessageBox.Show(div.nome);
            }
        }
    }
}
