using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private void tsiCategory_Click(object sender, EventArgs e)
        {
            frmCategory frmCategory = new frmCategory();
            frmCategory.Show();
        }

        private void tsiInvoice_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Show();
        }

        private void tsiAccount_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
        }

        private void tsiTable_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
        }
    }
}
