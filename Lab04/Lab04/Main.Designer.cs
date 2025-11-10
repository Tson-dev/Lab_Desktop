namespace Lab04
{
    partial class Main
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
            this.lvTable = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeats = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHallID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiViewInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiInvoiceHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTableCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtSeat = new System.Windows.Forms.TextBox();
            this.txtHallID = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTableCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSeat = new System.Windows.Forms.Label();
            this.lblHallID = new System.Windows.Forms.Label();
            this.tsiDeselect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvTable
            // 
            this.lvTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colTCode,
            this.colName,
            this.colStatus,
            this.colSeats,
            this.colHallID});
            this.lvTable.ContextMenuStrip = this.cmsTable;
            this.lvTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvTable.FullRowSelect = true;
            this.lvTable.GridLines = true;
            this.lvTable.HideSelection = false;
            this.lvTable.Location = new System.Drawing.Point(0, 0);
            this.lvTable.MultiSelect = false;
            this.lvTable.Name = "lvTable";
            this.lvTable.Size = new System.Drawing.Size(612, 228);
            this.lvTable.TabIndex = 0;
            this.lvTable.UseCompatibleStateImageBehavior = false;
            this.lvTable.View = System.Windows.Forms.View.Details;
            this.lvTable.SelectedIndexChanged += new System.EventHandler(this.lvTable_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // colTCode
            // 
            this.colTCode.Text = "Table Code";
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // colSeats
            // 
            this.colSeats.Text = "Seats";
            // 
            // colHallID
            // 
            this.colHallID.Text = "Hall ID";
            // 
            // cmsTable
            // 
            this.cmsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiSave,
            this.tsiDelete,
            this.tsiViewInvoice,
            this.tsiInvoiceHistory,
            this.tsiDeselect});
            this.cmsTable.Name = "cmsTable";
            this.cmsTable.Size = new System.Drawing.Size(154, 114);
            // 
            // tsiSave
            // 
            this.tsiSave.Name = "tsiSave";
            this.tsiSave.Size = new System.Drawing.Size(180, 22);
            this.tsiSave.Text = "Add";
            this.tsiSave.Click += new System.EventHandler(this.tsiSave_Click);
            // 
            // tsiDelete
            // 
            this.tsiDelete.Enabled = false;
            this.tsiDelete.Name = "tsiDelete";
            this.tsiDelete.Size = new System.Drawing.Size(180, 22);
            this.tsiDelete.Text = "Delete";
            this.tsiDelete.Visible = false;
            this.tsiDelete.Click += new System.EventHandler(this.tsiDelete_Click);
            // 
            // tsiViewInvoice
            // 
            this.tsiViewInvoice.Enabled = false;
            this.tsiViewInvoice.Name = "tsiViewInvoice";
            this.tsiViewInvoice.Size = new System.Drawing.Size(180, 22);
            this.tsiViewInvoice.Text = "View Invoice";
            this.tsiViewInvoice.Visible = false;
            // 
            // tsiInvoiceHistory
            // 
            this.tsiInvoiceHistory.Name = "tsiInvoiceHistory";
            this.tsiInvoiceHistory.Size = new System.Drawing.Size(180, 22);
            this.tsiInvoiceHistory.Text = "Invoice History";
            this.tsiInvoiceHistory.Click += new System.EventHandler(this.tsiInvoiceHistory_Click);
            // 
            // txtTableCode
            // 
            this.txtTableCode.Location = new System.Drawing.Point(79, 267);
            this.txtTableCode.Name = "txtTableCode";
            this.txtTableCode.Size = new System.Drawing.Size(100, 20);
            this.txtTableCode.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 293);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(232, 267);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 20);
            this.txtStatus.TabIndex = 1;
            // 
            // txtSeat
            // 
            this.txtSeat.Location = new System.Drawing.Point(232, 293);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.Size = new System.Drawing.Size(100, 20);
            this.txtSeat.TabIndex = 1;
            // 
            // txtHallID
            // 
            this.txtHallID.Location = new System.Drawing.Point(408, 267);
            this.txtHallID.Name = "txtHallID";
            this.txtHallID.Size = new System.Drawing.Size(100, 20);
            this.txtHallID.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(408, 293);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(51, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(465, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTableCode
            // 
            this.lblTableCode.AutoSize = true;
            this.lblTableCode.Location = new System.Drawing.Point(12, 270);
            this.lblTableCode.Name = "lblTableCode";
            this.lblTableCode.Size = new System.Drawing.Size(62, 13);
            this.lblTableCode.TabIndex = 3;
            this.lblTableCode.Text = "Table Code";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 300);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(185, 270);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status";
            // 
            // lblSeat
            // 
            this.lblSeat.AutoSize = true;
            this.lblSeat.Location = new System.Drawing.Point(185, 293);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(34, 13);
            this.lblSeat.TabIndex = 3;
            this.lblSeat.Text = "Seats";
            // 
            // lblHallID
            // 
            this.lblHallID.AutoSize = true;
            this.lblHallID.Location = new System.Drawing.Point(350, 274);
            this.lblHallID.Name = "lblHallID";
            this.lblHallID.Size = new System.Drawing.Size(39, 13);
            this.lblHallID.TabIndex = 3;
            this.lblHallID.Text = "Hall ID";
            // 
            // tsiDeselect
            // 
            this.tsiDeselect.Name = "tsiDeselect";
            this.tsiDeselect.Size = new System.Drawing.Size(180, 22);
            this.tsiDeselect.Text = "Deselect";
            this.tsiDeselect.Click += new System.EventHandler(this.tsiDeselect_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 351);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.lblHallID);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTableCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtHallID);
            this.Controls.Add(this.txtSeat);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtTableCode);
            this.Controls.Add(this.lvTable);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.cmsTable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.ContextMenuStrip cmsTable;
        private System.Windows.Forms.ToolStripMenuItem tsiSave;
        private System.Windows.Forms.ToolStripMenuItem tsiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsiViewInvoice;
        private System.Windows.Forms.ToolStripMenuItem tsiInvoiceHistory;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colTCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colSeats;
        private System.Windows.Forms.ColumnHeader colHallID;
        private System.Windows.Forms.TextBox txtTableCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtSeat;
        private System.Windows.Forms.TextBox txtHallID;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTableCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.Label lblHallID;
        private System.Windows.Forms.ToolStripMenuItem tsiDeselect;
    }
}