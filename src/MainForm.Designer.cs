namespace filezilla_efficient_tools
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblImportPath = new System.Windows.Forms.Label();
            this.btnXls = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            this.radWin = new System.Windows.Forms.RadioButton();
            this.radLinux = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkMkdir = new System.Windows.Forms.LinkLabel();
            this.linkAddUsers = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblImportPath
            // 
            resources.ApplyResources(this.lblImportPath, "lblImportPath");
            this.lblImportPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblImportPath.Name = "lblImportPath";
            // 
            // btnXls
            // 
            resources.ApplyResources(this.btnXls, "btnXls");
            this.btnXls.Name = "btnXls";
            this.btnXls.UseVisualStyleBackColor = true;
            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Name = "label1";
            // 
            // txtRootPath
            // 
            resources.ApplyResources(this.txtRootPath, "txtRootPath");
            this.txtRootPath.Name = "txtRootPath";
            // 
            // radWin
            // 
            resources.ApplyResources(this.radWin, "radWin");
            this.radWin.Checked = true;
            this.radWin.Name = "radWin";
            this.radWin.TabStop = true;
            this.radWin.UseVisualStyleBackColor = true;
            // 
            // radLinux
            // 
            resources.ApplyResources(this.radLinux, "radLinux");
            this.radLinux.Name = "radLinux";
            this.radLinux.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Name = "label2";
            // 
            // lnkMkdir
            // 
            resources.ApplyResources(this.lnkMkdir, "lnkMkdir");
            this.lnkMkdir.Name = "lnkMkdir";
            this.lnkMkdir.TabStop = true;
            this.lnkMkdir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMkdir_LinkClicked);
            // 
            // linkAddUsers
            // 
            resources.ApplyResources(this.linkAddUsers, "linkAddUsers");
            this.linkAddUsers.Name = "linkAddUsers";
            this.linkAddUsers.TabStop = true;
            this.linkAddUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddUsers_LinkClicked);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkAddUsers);
            this.Controls.Add(this.lnkMkdir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radLinux);
            this.Controls.Add(this.radWin);
            this.Controls.Add(this.txtRootPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.lblImportPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImportPath;
        private System.Windows.Forms.Button btnXls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.RadioButton radWin;
        private System.Windows.Forms.RadioButton radLinux;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkMkdir;
        private System.Windows.Forms.LinkLabel linkAddUsers;
    }
}

