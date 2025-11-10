namespace Lab05
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
            this.msSelect = new System.Windows.Forms.MenuStrip();
            this.foodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiFood = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.msSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // msSelect
            // 
            this.msSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foodToolStripMenuItem});
            this.msSelect.Location = new System.Drawing.Point(0, 0);
            this.msSelect.Name = "msSelect";
            this.msSelect.Size = new System.Drawing.Size(243, 24);
            this.msSelect.TabIndex = 0;
            this.msSelect.Text = "menuStrip1";
            // 
            // foodToolStripMenuItem
            // 
            this.foodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiFood,
            this.tsiOrder,
            this.tsiAccount});
            this.foodToolStripMenuItem.Name = "foodToolStripMenuItem";
            this.foodToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.foodToolStripMenuItem.Text = "Form";
            // 
            // tsiFood
            // 
            this.tsiFood.Name = "tsiFood";
            this.tsiFood.Size = new System.Drawing.Size(180, 22);
            this.tsiFood.Text = "Food";
            this.tsiFood.Click += new System.EventHandler(this.tsiFood_Click);
            // 
            // tsiOrder
            // 
            this.tsiOrder.Name = "tsiOrder";
            this.tsiOrder.Size = new System.Drawing.Size(180, 22);
            this.tsiOrder.Text = "Order";
            this.tsiOrder.Click += new System.EventHandler(this.tsiOrder_Click);
            // 
            // tsiAccount
            // 
            this.tsiAccount.Name = "tsiAccount";
            this.tsiAccount.Size = new System.Drawing.Size(180, 22);
            this.tsiAccount.Text = "Account";
            this.tsiAccount.Click += new System.EventHandler(this.tsiAccount_Click);
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 150);
            this.Controls.Add(this.msSelect);
            this.MainMenuStrip = this.msSelect;
            this.Name = "SelectForm";
            this.Text = "SelectForm";
            this.msSelect.ResumeLayout(false);
            this.msSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msSelect;
        private System.Windows.Forms.ToolStripMenuItem foodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiFood;
        private System.Windows.Forms.ToolStripMenuItem tsiOrder;
        private System.Windows.Forms.ToolStripMenuItem tsiAccount;
    }
}