using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class InvoiceDetailBL
    {
        InvoiceDetailDA da = new InvoiceDetailDA();
        public DataTable GetByInvoiceID(int invoiceID) => da.GetByInvoiceID(invoiceID);
        public int Insert(InvoiceDetail d) => da.InsertUpdateDelete(d, 0);
        public int Update(InvoiceDetail d) => da.InsertUpdateDelete(d, 1);
        public int Delete(InvoiceDetail d) => da.InsertUpdateDelete(d, 2);
        public int DeleteByInvoice(int invoiceID) => da.DeleteByInvoice(invoiceID);
    }
}
