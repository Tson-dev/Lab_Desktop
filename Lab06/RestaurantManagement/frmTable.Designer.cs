namespace RestaurantManagement
{
    partial class frmTable
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
            this.lsvTable = new System.Windows.Forms.ListView();
            this.colSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTableCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeats = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblID = new System.Windows.Forms.Label();
            this.lblTableCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSeats = new System.Windows.Forms.Label();
            this.lblHall = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtTableCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtSeats = new System.Windows.Forms.TextBox();
            this.cbbHall = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvTable
            // 
            this.lsvTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSTT,
            this.colID,
            this.colTableCode,
            this.colName,
            this.colStatus,
            this.colSeats,
            this.colHall});
            this.lsvTable.FullRowSelect = true;
            this.lsvTable.GridLines = true;
            this.lsvTable.HideSelection = false;
            this.lsvTable.Location = new System.Drawing.Point(12, 180);
            this.lsvTable.MultiSelect = false;
            this.lsvTable.Name = "lsvTable";
            this.lsvTable.Size = new System.Drawing.Size(720, 260);
            this.lsvTable.TabIndex = 0;
            this.lsvTable.UseCompatibleStateImageBehavior = false;
            this.lsvTable.View = System.Windows.Forms.View.Details;
            this.lsvTable.Click += new System.EventHandler(this.lsvTable_Click);
            // 
            // colSTT
            // 
            this.colSTT.Text = "STT";
            this.colSTT.Width = 50;
            // 
            // colID
            // 
            this.colID.Text = "Mã";
            this.colID.Width = 50;
            // 
            // colTableCode
            // 
            this.colTableCode.Text = "Mã bàn";
            this.colTableCode.Width = 100;
            // 
            // colName
            // 
            this.colName.Text = "Tên bàn";
            this.colName.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Trạng thái";
            this.colStatus.Width = 100;
            // 
            // colSeats
            // 
            this.colSeats.Text = "Số ghế";
            this.colSeats.Width = 80;
            // 
            // colHall
            // 
            this.colHall.Text = "Sảnh";
            this.colHall.Width = 150;
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(20, 20);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(100, 23);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Mã:";
            // 
            // lblTableCode
            // 
            this.lblTableCode.Location = new System.Drawing.Point(20, 50);
            this.lblTableCode.Name = "lblTableCode";
            this.lblTableCode.Size = new System.Drawing.Size(100, 23);
            this.lblTableCode.TabIndex = 1;
            this.lblTableCode.Text = "Mã bàn:";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Tên bàn:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 110);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // lblSeats
            // 
            this.lblSeats.Location = new System.Drawing.Point(20, 140);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(100, 23);
            this.lblSeats.TabIndex = 4;
            this.lblSeats.Text = "Số ghế:";
            // 
            // lblHall
            // 
            this.lblHall.Location = new System.Drawing.Point(400, 20);
            this.lblHall.Name = "lblHall";
            this.lblHall.Size = new System.Drawing.Size(100, 23);
            this.lblHall.TabIndex = 5;
            this.lblHall.Text = "Sảnh:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(120, 17);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 6;
            // 
            // txtTableCode
            // 
            this.txtTableCode.Location = new System.Drawing.Point(120, 47);
            this.txtTableCode.Name = "txtTableCode";
            this.txtTableCode.Size = new System.Drawing.Size(100, 22);
            this.txtTableCode.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 77);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 8;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(120, 107);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 22);
            this.txtStatus.TabIndex = 9;
            // 
            // txtSeats
            // 
            this.txtSeats.Location = new System.Drawing.Point(120, 137);
            this.txtSeats.Name = "txtSeats";
            this.txtSeats.Size = new System.Drawing.Size(100, 22);
            this.txtSeats.TabIndex = 10;
            // 
            // cbbHall
            // 
            this.cbbHall.Location = new System.Drawing.Point(403, 45);
            this.cbbHall.Name = "cbbHall";
            this.cbbHall.Size = new System.Drawing.Size(200, 24);
            this.cbbHall.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(403, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(483, 80);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(563, 80);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(643, 80);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Làm mới";
            this.btnClear.Click += new System.EventHandler(this.frmTable_Load);
            // 
            // frmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 460);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblTableCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSeats);
            this.Controls.Add(this.lblHall);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtTableCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtSeats);
            this.Controls.Add(this.cbbHall);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lsvTable);
            this.Name = "frmTable";
            this.Text = "Quản lý bàn ăn";
            this.Load += new System.EventHandler(this.frmTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvTable;
        private System.Windows.Forms.ColumnHeader colSTT;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colTableCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colSeats;
        private System.Windows.Forms.ColumnHeader colHall;

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblTableCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.Label lblHall;

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtTableCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtSeats;
        private System.Windows.Forms.ComboBox cbbHall;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
    }
}