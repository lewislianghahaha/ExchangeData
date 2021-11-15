namespace ExchangeData
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_import = new System.Windows.Forms.Button();
            this.Mean = new System.Windows.Forms.MenuStrip();
            this.tmclose = new System.Windows.Forms.ToolStripMenuItem();
            this.Mean.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(56, 42);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(132, 23);
            this.btn_import.TabIndex = 0;
            this.btn_import.Text = "导入Excel";
            this.btn_import.UseVisualStyleBackColor = true;
            // 
            // Mean
            // 
            this.Mean.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Mean.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmclose});
            this.Mean.Location = new System.Drawing.Point(0, 0);
            this.Mean.Name = "Mean";
            this.Mean.Size = new System.Drawing.Size(238, 25);
            this.Mean.TabIndex = 1;
            this.Mean.Text = "menuStrip1";
            // 
            // tmclose
            // 
            this.tmclose.Name = "tmclose";
            this.tmclose.Size = new System.Drawing.Size(44, 21);
            this.tmclose.Text = "关闭";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 88);
            this.ControlBox = false;
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.Mean);
            this.MainMenuStrip = this.Mean;
            this.Name = "Main";
            this.Text = "数据整理";
            this.Mean.ResumeLayout(false);
            this.Mean.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.MenuStrip Mean;
        private System.Windows.Forms.ToolStripMenuItem tmclose;
    }
}

