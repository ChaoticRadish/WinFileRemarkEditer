namespace WinFileRemarkEditer.UI
{
    partial class EditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_当前选择文件或文件夹 = new System.Windows.Forms.TextBox();
            this.button_选择文件 = new System.Windows.Forms.Button();
            this.button_选择文件夹 = new System.Windows.Forms.Button();
            this.textBox_备注编辑框 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_设置 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择文件/文件夹: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_当前选择文件或文件夹
            // 
            this.textBox_当前选择文件或文件夹.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_当前选择文件或文件夹.Location = new System.Drawing.Point(121, 8);
            this.textBox_当前选择文件或文件夹.Name = "textBox_当前选择文件或文件夹";
            this.textBox_当前选择文件或文件夹.ReadOnly = true;
            this.textBox_当前选择文件或文件夹.Size = new System.Drawing.Size(354, 23);
            this.textBox_当前选择文件或文件夹.TabIndex = 1;
            // 
            // button_选择文件
            // 
            this.button_选择文件.Location = new System.Drawing.Point(121, 37);
            this.button_选择文件.Name = "button_选择文件";
            this.button_选择文件.Size = new System.Drawing.Size(75, 23);
            this.button_选择文件.TabIndex = 2;
            this.button_选择文件.Text = "选择文件";
            this.button_选择文件.UseVisualStyleBackColor = true;
            this.button_选择文件.Click += new System.EventHandler(this.button_选择文件_Click);
            // 
            // button_选择文件夹
            // 
            this.button_选择文件夹.Location = new System.Drawing.Point(202, 37);
            this.button_选择文件夹.Name = "button_选择文件夹";
            this.button_选择文件夹.Size = new System.Drawing.Size(95, 23);
            this.button_选择文件夹.TabIndex = 3;
            this.button_选择文件夹.Text = "选择文件夹";
            this.button_选择文件夹.UseVisualStyleBackColor = true;
            this.button_选择文件夹.Click += new System.EventHandler(this.button_选择文件夹_Click);
            // 
            // textBox_备注编辑框
            // 
            this.textBox_备注编辑框.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_备注编辑框.Location = new System.Drawing.Point(121, 66);
            this.textBox_备注编辑框.Name = "textBox_备注编辑框";
            this.textBox_备注编辑框.Size = new System.Drawing.Size(274, 23);
            this.textBox_备注编辑框.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "当前备注: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_设置
            // 
            this.button_设置.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_设置.Location = new System.Drawing.Point(400, 66);
            this.button_设置.Name = "button_设置";
            this.button_设置.Size = new System.Drawing.Size(75, 23);
            this.button_设置.TabIndex = 6;
            this.button_设置.Text = "设置";
            this.button_设置.UseVisualStyleBackColor = true;
            this.button_设置.Click += new System.EventHandler(this.button_设置_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 96);
            this.Controls.Add(this.button_设置);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_备注编辑框);
            this.Controls.Add(this.button_选择文件夹);
            this.Controls.Add(this.button_选择文件);
            this.Controls.Add(this.textBox_当前选择文件或文件夹);
            this.Controls.Add(this.label1);
            this.Name = "EditForm";
            this.Text = "文件备注编辑";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox_当前选择文件或文件夹;
        private Button button_选择文件;
        private Button button_选择文件夹;
        private TextBox textBox_备注编辑框;
        private Label label2;
        private Button button_设置;
    }
}