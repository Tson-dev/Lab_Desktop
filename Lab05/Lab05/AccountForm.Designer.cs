namespace Lab05
{
    partial class AccountForm
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
            this.gbxAccount = new System.Windows.Forms.GroupBox();
            this.cbxActive = new System.Windows.Forms.CheckBox();
            this.lvAccount = new System.Windows.Forms.ListView();
            this.colAName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctmAccount = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiViewRole = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDeselect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAName = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.gbxAccount.SuspendLayout();
            this.ctmAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAccount
            // 
            this.gbxAccount.Controls.Add(this.cbxActive);
            this.gbxAccount.Controls.Add(this.lvAccount);
            this.gbxAccount.Location = new System.Drawing.Point(12, 12);
            this.gbxAccount.Name = "gbxAccount";
            this.gbxAccount.Size = new System.Drawing.Size(549, 236);
            this.gbxAccount.TabIndex = 2;
            this.gbxAccount.TabStop = false;
            this.gbxAccount.Text = "List";
            // 
            // cbxActive
            // 
            this.cbxActive.AutoSize = true;
            this.cbxActive.Location = new System.Drawing.Point(481, 19);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(56, 17);
            this.cbxActive.TabIndex = 2;
            this.cbxActive.Text = "Active";
            this.cbxActive.UseVisualStyleBackColor = true;
            this.cbxActive.CheckedChanged += new System.EventHandler(this.cbxActive_CheckedChanged);
            // 
            // lvAccount
            // 
            this.lvAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAName,
            this.colPass,
            this.colName,
            this.colEmail,
            this.colPhone,
            this.colDate});
            this.lvAccount.ContextMenuStrip = this.ctmAccount;
            this.lvAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvAccount.FullRowSelect = true;
            this.lvAccount.GridLines = true;
            this.lvAccount.HideSelection = false;
            this.lvAccount.Location = new System.Drawing.Point(3, 51);
            this.lvAccount.MultiSelect = false;
            this.lvAccount.Name = "lvAccount";
            this.lvAccount.Size = new System.Drawing.Size(543, 182);
            this.lvAccount.TabIndex = 1;
            this.lvAccount.UseCompatibleStateImageBehavior = false;
            this.lvAccount.View = System.Windows.Forms.View.Details;
            this.lvAccount.SelectedIndexChanged += new System.EventHandler(this.lvAccount_SelectedIndexChanged);
            // 
            // colAName
            // 
            this.colAName.Text = "Account Name";
            this.colAName.Width = 96;
            // 
            // colPass
            // 
            this.colPass.Text = "Password";
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            // 
            // colPhone
            // 
            this.colPhone.Text = "Phone";
            // 
            // colDate
            // 
            this.colDate.Text = "Date Created";
            // 
            // ctmAccount
            // 
            this.ctmAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiSave,
            this.tsiDelete,
            this.tsiViewRole,
            this.tsiDeselect});
            this.ctmAccount.Name = "ctmAccount";
            this.ctmAccount.Size = new System.Drawing.Size(126, 92);
            // 
            // tsiSave
            // 
            this.tsiSave.Name = "tsiSave";
            this.tsiSave.Size = new System.Drawing.Size(125, 22);
            this.tsiSave.Text = "Add";
            this.tsiSave.Click += new System.EventHandler(this.tsiSave_Click);
            // 
            // tsiDelete
            // 
            this.tsiDelete.Enabled = false;
            this.tsiDelete.Name = "tsiDelete";
            this.tsiDelete.Size = new System.Drawing.Size(125, 22);
            this.tsiDelete.Text = "Delete";
            this.tsiDelete.Visible = false;
            this.tsiDelete.Click += new System.EventHandler(this.tsiDelete_Click);
            // 
            // tsiViewRole
            // 
            this.tsiViewRole.Enabled = false;
            this.tsiViewRole.Name = "tsiViewRole";
            this.tsiViewRole.Size = new System.Drawing.Size(125, 22);
            this.tsiViewRole.Text = "View Role";
            this.tsiViewRole.Visible = false;
            this.tsiViewRole.Click += new System.EventHandler(this.tsiViewRole_Click);
            // 
            // tsiDeselect
            // 
            this.tsiDeselect.Enabled = false;
            this.tsiDeselect.Name = "tsiDeselect";
            this.tsiDeselect.Size = new System.Drawing.Size(125, 22);
            this.tsiDeselect.Text = "Deselect";
            this.tsiDeselect.Visible = false;
            this.tsiDeselect.Click += new System.EventHandler(this.tsiDeselect_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(398, 307);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(59, 23);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(463, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAName
            // 
            this.txtAName.Enabled = false;
            this.txtAName.Location = new System.Drawing.Point(107, 265);
            this.txtAName.Name = "txtAName";
            this.txtAName.Size = new System.Drawing.Size(100, 20);
            this.txtAName.TabIndex = 5;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(107, 291);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 5;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(422, 265);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(264, 294);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(264, 268);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblAName
            // 
            this.lblAName.AutoSize = true;
            this.lblAName.Location = new System.Drawing.Point(23, 268);
            this.lblAName.Name = "lblAName";
            this.lblAName.Size = new System.Drawing.Size(78, 13);
            this.lblAName.TabIndex = 6;
            this.lblAName.Text = "Account Name";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(23, 294);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(53, 13);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Password";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(223, 271);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(223, 297);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(381, 271);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 13);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 341);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblAName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtAName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.gbxAccount);
            this.Name = "Account";
            this.Text = "Account";
            this.Load += new System.EventHandler(this.Account_Load);
            this.gbxAccount.ResumeLayout(false);
            this.gbxAccount.PerformLayout();
            this.ctmAccount.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbxAccount;
        private System.Windows.Forms.ListView lvAccount;
        private System.Windows.Forms.ContextMenuStrip ctmAccount;
        private System.Windows.Forms.ToolStripMenuItem tsiSave;
        private System.Windows.Forms.ToolStripMenuItem tsiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsiViewRole;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAName;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.ColumnHeader colAName;
        private System.Windows.Forms.ColumnHeader colPass;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.CheckBox cbxActive;
        private System.Windows.Forms.ToolStripMenuItem tsiDeselect;
    }
}