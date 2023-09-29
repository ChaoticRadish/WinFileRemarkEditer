namespace WinFileRemarkEditer.UI
{
    partial class QuickEditForm
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
            button_设置 = new Button();
            label2 = new Label();
            textBox_备注编辑框 = new TextBox();
            textBox_路径 = new TextBox();
            label1 = new Label();
            button_取消 = new Button();
            SuspendLayout();
            // 
            // button_设置
            // 
            button_设置.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_设置.Location = new Point(395, 34);
            button_设置.Name = "button_设置";
            button_设置.Size = new Size(75, 23);
            button_设置.TabIndex = 11;
            button_设置.Text = "设置";
            button_设置.UseVisualStyleBackColor = true;
            button_设置.Click += button_设置_Click;
            // 
            // label2
            // 
            label2.Location = new Point(12, 37);
            label2.Name = "label2";
            label2.Size = new Size(74, 17);
            label2.TabIndex = 10;
            label2.Text = "当前备注: ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_备注编辑框
            // 
            textBox_备注编辑框.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_备注编辑框.Location = new Point(88, 34);
            textBox_备注编辑框.MaxLength = 255;
            textBox_备注编辑框.Name = "textBox_备注编辑框";
            textBox_备注编辑框.Size = new Size(301, 23);
            textBox_备注编辑框.TabIndex = 9;
            // 
            // textBox_路径
            // 
            textBox_路径.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_路径.Location = new Point(88, 6);
            textBox_路径.Name = "textBox_路径";
            textBox_路径.ReadOnly = true;
            textBox_路径.Size = new Size(463, 23);
            textBox_路径.TabIndex = 8;
            // 
            // label1
            // 
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(70, 23);
            label1.TabIndex = 7;
            label1.Text = "路径: ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button_取消
            // 
            button_取消.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_取消.Location = new Point(476, 34);
            button_取消.Name = "button_取消";
            button_取消.Size = new Size(75, 23);
            button_取消.TabIndex = 12;
            button_取消.Text = "取消";
            button_取消.UseVisualStyleBackColor = true;
            button_取消.Click += button_取消_Click;
            // 
            // QuickEditForm
            // 
            AcceptButton = button_设置;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 66);
            Controls.Add(button_取消);
            Controls.Add(button_设置);
            Controls.Add(label2);
            Controls.Add(textBox_备注编辑框);
            Controls.Add(textBox_路径);
            Controls.Add(label1);
            Name = "QuickEditForm";
            Text = "快速编辑窗口";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_设置;
        private Label label2;
        private TextBox textBox_备注编辑框;
        private TextBox textBox_路径;
        private Label label1;
        private Button button_取消;
    }
}