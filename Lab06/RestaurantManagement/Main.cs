using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frmAccount = new frmAccount();
            frmAccount.Show();
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRole frmRole = new frmRole();
            frmRole.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frmCategory = new frmCategory();
            frmCategory.Show();
        }

        private void foodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFood frmFood = new frmFood();
            frmFood.Show();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoice frmInvoice = new frmInvoice();
            frmInvoice.Show();
        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRestaurant frmRestaurant = new frmRestaurant();
            frmRestaurant.Show();
        }

        private void hallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHall frmHall = new frmHall();
            frmHall.Show();
        }

        private void invoiceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceDetail frmInvoiceDetail = new frmInvoiceDetail();
            frmInvoiceDetail.Show();
        }

        private void roleAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoleAccount frmRoleAccount = new frmRoleAccount();
            frmRoleAccount.Show();
        }
    
        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTable frmTable = new frmTable();
            frmTable.Show();
        }
    }
}
