namespace Lab04
{
    partial class Invoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.gbxList = new System.Windows.Forms.GroupBox();
            this.lvInvoice = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTableID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiscount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCheckout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubtotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiscountAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbxList.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(67, 29);
            this.dtpFrom.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(102, 20);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(67, 55);
            this.dtpTo.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(97, 20);
            this.dtpTo.TabIndex = 0;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(26, 36);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(26, 61);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // gbxList
            // 
            this.gbxList.Controls.Add(this.lvInvoice);
            this.gbxList.Controls.Add(this.dtpFrom);
            this.gbxList.Controls.Add(this.lblTo);
            this.gbxList.Controls.Add(this.dtpTo);
            this.gbxList.Controls.Add(this.lblFrom);
            this.gbxList.Location = new System.Drawing.Point(5, 7);
            this.gbxList.Name = "gbxList";
            this.gbxList.Size = new System.Drawing.Size(671, 291);
            this.gbxList.TabIndex = 3;
            this.gbxList.TabStop = false;
            this.gbxList.Text = "List";
            // 
            // lvInvoice
            // 
            this.lvInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colName,
            this.colTableID,
            this.colDiscount,
            this.colTax,
            this.colDiscountAmount,
            this.colSubtotal,
            this.colTotal,
            this.colStatus,
            this.colAccount,
            this.colCheckout});
            this.lvInvoice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvInvoice.FullRowSelect = true;
            this.lvInvoice.GridLines = true;
            this.lvInvoice.HideSelection = false;
            this.lvInvoice.Location = new System.Drawing.Point(3, 110);
            this.lvInvoice.Name = "lvInvoice";
            this.lvInvoice.Size = new System.Drawing.Size(665, 178);
            this.lvInvoice.TabIndex = 3;
            this.lvInvoice.UseCompatibleStateImageBehavior = false;
            this.lvInvoice.View = System.Windows.Forms.View.Details;
            this.lvInvoice.DoubleClick += new System.EventHandler(this.lvInvoice_DoubleClick);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colTableID
            // 
            this.colTableID.Text = "Table ID";
            // 
            // colTotal
            // 
            this.colTotal.Text = "Total";
            // 
            // colDiscount
            // 
            this.colDiscount.Text = "Discount";
            // 
            // colTax
            // 
            this.colTax.Text = "Tax";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // colAccount
            // 
            this.colAccount.Text = "Account";
            // 
            // colCheckout
            // 
            this.colCheckout.Text = "Date Checkout";
            // 
            // colSubtotal
            // 
            this.colSubtotal.Text = "Subtotal";
            // 
            // colDiscountAmount
            // 
            this.colDiscountAmount.Text = "DiscountAmount";
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 301);
            this.Controls.Add(this.gbxList);
            this.Name = "Invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Invoice_Load);
            this.gbxList.ResumeLayout(false);
            this.gbxList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.GroupBox gbxList;
        private System.Windows.Forms.ListView lvInvoice;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colTableID;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.ColumnHeader colDiscount;
        private System.Windows.Forms.ColumnHeader colTax;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colAccount;
        private System.Windows.Forms.ColumnHeader colCheckout;
        private System.Windows.Forms.ColumnHeader colSubtotal;
        private System.Windows.Forms.ColumnHeader colDiscountAmount;
    }
}