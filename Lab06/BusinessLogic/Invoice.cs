using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class InvoiceBL
    {
        InvoiceDA da = new InvoiceDA();
        public DataTable GetAll() => da.GetAll();
        public int Insert(Invoice inv) => da.InsertUpdateDelete(inv, 0);
        public int Update(Invoice inv) => da.InsertUpdateDelete(inv, 1);
        public int Delete(Invoice inv) => da.InsertUpdateDelete(inv, 2);
        public int CreateForTable(int tableID, string accountID, out int invoiceID) => da.CreateForTable(tableID, accountID, out invoiceID);
        public int Checkout(int invoiceID, double discount, double tax, double paidAmount, string accountID) => da.Checkout(invoiceID, discount, tax, paidAmount, accountID);
    }
}
