namespace RestaurantManagement
{
    partial class frmHall
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

        private void InitializeComponent()
        {
            this.lsvHall = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRestaurant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));

            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();

            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbbRestaurant = new System.Windows.Forms.ComboBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lsvHall
            // 
            this.lsvHall.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colName,
            this.colRestaurant});
            this.lsvHall.FullRowSelect = true;
            this.lsvHall.GridLines = true;
            this.lsvHall.HideSelection = false;
            this.lsvHall.Location = new System.Drawing.Point(20, 150);
            this.lsvHall.MultiSelect = false;
            this.lsvHall.Name = "lsvHall";
            this.lsvHall.Size = new System.Drawing.Size(500, 250);
            this.lsvHall.TabIndex = 0;
            this.lsvHall.UseCompatibleStateImageBehavior = false;
            this.lsvHall.View = System.Windows.Forms.View.Details;
            this.lsvHall.SelectedIndexChanged += new System.EventHandler(this.lsvHall_SelectedIndexChanged);

            // 
            // Columns
            // 
            this.colID.Text = "ID";
            this.colID.Width = 50;
            this.colName.Text = "Tên Sảnh";
            this.colName.Width = 200;
            this.colRestaurant.Text = "Nhà hàng";
            this.colRestaurant.Width = 200;

            // 
            // Labels
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Text = "Mã Sảnh:";

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Text = "Tên Sảnh:";

            // 
            // TextBoxes
            // 
            this.txtID.Location = new System.Drawing.Point(120, 22);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(150, 22);

            this.txtName.Location = new System.Drawing.Point(120, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);

            // 
            // ComboBox Restaurant
            // 
            this.cbbRestaurant.Location = new System.Drawing.Point(120, 92);
            this.cbbRestaurant.Name = "cbbRestaurant";
            this.cbbRestaurant.Size = new System.Drawing.Size(200, 24);

            // 
            // Buttons
            // 
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Location = new System.Drawing.Point(350, 20);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Location = new System.Drawing.Point(350, 55);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new System.Drawing.Point(350, 90);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClose.Text = "Đóng";
            this.btnClose.Location = new System.Drawing.Point(450, 420);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // frmHall
            // 
            this.ClientSize = new System.Drawing.Size(550, 460);
            this.Controls.Add(this.lsvHall);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cbbRestaurant);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "frmHall";
            this.Text = "Quản lý Sảnh (Hall)";
            this.Load += new System.EventHandler(this.frmHall_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView lsvHall;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colRestaurant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbbRestaurant;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}