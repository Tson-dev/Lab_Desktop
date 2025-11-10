namespace RestaurantManagement
{
    partial class frmRoleAccount
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
            this.dgvRoleAccount = new System.Windows.Forms.DataGridView();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.chkActived = new System.Windows.Forms.CheckBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoleAccount
            // 
            this.dgvRoleAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoleAccount.Location = new System.Drawing.Point(12, 12);
            this.dgvRoleAccount.Name = "dgvRoleAccount";
            this.dgvRoleAccount.Size = new System.Drawing.Size(600, 200);
            this.dgvRoleAccount.TabIndex = 0;
            this.dgvRoleAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoleAccount_CellClick);
            // 
            // Labels
            // 
            this.lblAccount.Text = "Tài khoản:";
            this.lblAccount.Location = new System.Drawing.Point(12, 225);

            this.lblRole.Text = "Quyền:";
            this.lblRole.Location = new System.Drawing.Point(12, 255);

            this.lblNotes.Text = "Ghi chú:";
            this.lblNotes.Location = new System.Drawing.Point(12, 315);
            // 
            // ComboBoxes
            // 
            this.cboAccount.Location = new System.Drawing.Point(90, 222);
            this.cboAccount.Size = new System.Drawing.Size(200, 23);

            this.cboRole.Location = new System.Drawing.Point(90, 252);
            this.cboRole.Size = new System.Drawing.Size(200, 23);
            // 
            // CheckBox
            // 
            this.chkActived.Text = "Kích hoạt";
            this.chkActived.Checked = true;
            this.chkActived.Location = new System.Drawing.Point(310, 222);
            // 
            // TextBox Notes
            // 
            this.txtNotes.Location = new System.Drawing.Point(90, 312);
            this.txtNotes.Size = new System.Drawing.Size(300, 23);
            // 
            // Buttons
            // 
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Location = new System.Drawing.Point(12, 350);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(100, 350);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new System.Drawing.Point(190, 350);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Location = new System.Drawing.Point(280, 350);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmRoleAccount
            // 
            this.ClientSize = new System.Drawing.Size(624, 391);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvRoleAccount, this.cboAccount, this.cboRole, this.chkActived,
                this.txtNotes, this.lblAccount, this.lblRole, this.lblNotes,
                this.btnAdd, this.btnSave, this.btnDelete, this.btnRefresh
            });
            this.Name = "frmRoleAccount";
            this.Text = "Phân quyền tài khoản";
            this.Load += new System.EventHandler(this.frmRoleAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoleAccount;
        private System.Windows.Forms.ComboBox cboAccount, cboRole;
        private System.Windows.Forms.CheckBox chkActived;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblAccount, lblRole, lblNotes;
        private System.Windows.Forms.Button btnAdd, btnSave, btnDelete, btnRefresh;
    }
}