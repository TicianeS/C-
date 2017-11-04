using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallPostgre.View
{
    public partial class FrmPretensao : Form
    {
        FrmPrincipal pri;
        public FrmPretensao(FrmPrincipal x)
        {
            pri = x;
            InitializeComponent();
        }
    }
}
