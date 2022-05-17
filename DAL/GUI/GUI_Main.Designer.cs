namespace GUI
{
    partial class GUI_Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kếtNốiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nướcUốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaChữaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.kếtNốiToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.nướcUốngToolStripMenuItem,
            this.báoCáoToolStripMenuItem,
            this.sửaChữaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(735, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngNhậpToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // đăngNhậpToolStripMenuItem
            // 
            this.đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            this.đăngNhậpToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.đăngNhậpToolStripMenuItem.Text = "Đăng Nhập";
            // 
            // kếtNốiToolStripMenuItem
            // 
            this.kếtNốiToolStripMenuItem.Name = "kếtNốiToolStripMenuItem";
            this.kếtNốiToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.kếtNốiToolStripMenuItem.Text = "Kết Nối";
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.báoCáoToolStripMenuItem.Text = "Báo Cáo";
            // 
            // nướcUốngToolStripMenuItem
            // 
            this.nướcUốngToolStripMenuItem.Name = "nướcUốngToolStripMenuItem";
            this.nướcUốngToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.nướcUốngToolStripMenuItem.Text = "Thiết Bị";
            // 
            // sửaChữaToolStripMenuItem
            // 
            this.sửaChữaToolStripMenuItem.Name = "sửaChữaToolStripMenuItem";
            this.sửaChữaToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.sửaChữaToolStripMenuItem.Text = "Sửa Chữa";
            // 
            // GUI_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 478);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI_Main";
            this.Text = "GUI_Main";
            this.Load += new System.EventHandler(this.GUI_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kếtNốiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nướcUốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaChữaToolStripMenuItem;
    }
}