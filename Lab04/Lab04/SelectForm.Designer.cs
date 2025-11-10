namespace Lab04
{
    partial class SelectForm
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
            this.components = new System.ComponentModel.Container();
            this.cmsSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsiCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTable = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsSelect
            // 
            this.cmsSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiCategory,
            this.tsiInvoice,
            this.tsiAccount,
            this.tsiTable});
            this.cmsSelect.Name = "cmsSelect";
            this.cmsSelect.Size = new System.Drawing.Size(123, 92);
            // 
            // tsiCategory
            // 
            this.tsiCategory.Name = "tsiCategory";
            this.tsiCategory.Size = new System.Drawing.Size(122, 22);
            this.tsiCategory.Text = "Category";
            this.tsiCategory.Click += new System.EventHandler(this.tsiCategory_Click);
            // 
            // tsiInvoice
            // 
            this.tsiInvoice.Name = "tsiInvoice";
            this.tsiInvoice.Size = new System.Drawing.Size(122, 22);
            this.tsiInvoice.Text = "Invoice";
            this.tsiInvoice.Click += new System.EventHandler(this.tsiInvoice_Click);
            // 
            // tsiAccount
            // 
            this.tsiAccount.Name = "tsiAccount";
            this.tsiAccount.Size = new System.Drawing.Size(122, 22);
            this.tsiAccount.Text = "Account";
            this.tsiAccount.Click += new System.EventHandler(this.tsiAccount_Click);
            // 
            // tsiTable
            // 
            this.tsiTable.Name = "tsiTable";
            this.tsiTable.Size = new System.Drawing.Size(122, 22);
            this.tsiTable.Text = "Table";
            this.tsiTable.Click += new System.EventHandler(this.tsiTable_Click);
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 161);
            this.ContextMenuStrip = this.cmsSelect;
            this.Name = "SelectForm";
            this.Text = "SelectForm";
            this.cmsSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsSelect;
        private System.Windows.Forms.ToolStripMenuItem tsiCategory;
        private System.Windows.Forms.ToolStripMenuItem tsiInvoice;
        private System.Windows.Forms.ToolStripMenuItem tsiAccount;
        private System.Windows.Forms.ToolStripMenuItem tsiTable;
    }
}