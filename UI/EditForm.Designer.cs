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
            label1 = new Label();
            textBox_当前选择文件或文件夹 = new TextBox();
            button_选择文件 = new Button();
            button_选择文件夹 = new Button();
            textBox_备注编辑框 = new TextBox();
            label2 = new Label();
            button_设置 = new Button();
            menuStrip1 = new MenuStrip();
            注册系统右键菜单_ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(11, 34);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "选择文件/文件夹: ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_当前选择文件或文件夹
            // 
            textBox_当前选择文件或文件夹.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_当前选择文件或文件夹.Location = new Point(121, 31);
            textBox_当前选择文件或文件夹.Name = "textBox_当前选择文件或文件夹";
            textBox_当前选择文件或文件夹.ReadOnly = true;
            textBox_当前选择文件或文件夹.Size = new Size(438, 23);
            textBox_当前选择文件或文件夹.TabIndex = 1;
            // 
            // button_选择文件
            // 
            button_选择文件.Location = new Point(121, 60);
            button_选择文件.Name = "button_选择文件";
            button_选择文件.Size = new Size(75, 23);
            button_选择文件.TabIndex = 2;
            button_选择文件.Text = "选择文件";
            button_选择文件.UseVisualStyleBackColor = true;
            button_选择文件.Click += button_选择文件_Click;
            // 
            // button_选择文件夹
            // 
            button_选择文件夹.Location = new Point(202, 60);
            button_选择文件夹.Name = "button_选择文件夹";
            button_选择文件夹.Size = new Size(95, 23);
            button_选择文件夹.TabIndex = 3;
            button_选择文件夹.Text = "选择文件夹";
            button_选择文件夹.UseVisualStyleBackColor = true;
            button_选择文件夹.Click += button_选择文件夹_Click;
            // 
            // textBox_备注编辑框
            // 
            textBox_备注编辑框.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_备注编辑框.Location = new Point(121, 89);
            textBox_备注编辑框.MaxLength = 255;
            textBox_备注编辑框.Name = "textBox_备注编辑框";
            textBox_备注编辑框.Size = new Size(358, 23);
            textBox_备注编辑框.TabIndex = 4;
            // 
            // label2
            // 
            label2.Location = new Point(12, 92);
            label2.Name = "label2";
            label2.Size = new Size(104, 17);
            label2.TabIndex = 5;
            label2.Text = "当前备注: ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button_设置
            // 
            button_设置.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_设置.Location = new Point(484, 89);
            button_设置.Name = "button_设置";
            button_设置.Size = new Size(75, 23);
            button_设置.TabIndex = 6;
            button_设置.Text = "设置";
            button_设置.UseVisualStyleBackColor = true;
            button_设置.Click += button_设置_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 注册系统右键菜单_ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(571, 25);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // 注册系统右键菜单_ToolStripMenuItem
            // 
            注册系统右键菜单_ToolStripMenuItem.Name = "注册系统右键菜单_ToolStripMenuItem";
            注册系统右键菜单_ToolStripMenuItem.Size = new Size(116, 21);
            注册系统右键菜单_ToolStripMenuItem.Text = "注册系统右键菜单";
            注册系统右键菜单_ToolStripMenuItem.Click += 注册系统右键菜单_ToolStripMenuItem_Click;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 124);
            Controls.Add(button_设置);
            Controls.Add(label2);
            Controls.Add(textBox_备注编辑框);
            Controls.Add(button_选择文件夹);
            Controls.Add(button_选择文件);
            Controls.Add(textBox_当前选择文件或文件夹);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "EditForm";
            Text = "文件备注编辑";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_当前选择文件或文件夹;
        private Button button_选择文件;
        private Button button_选择文件夹;
        private TextBox textBox_备注编辑框;
        private Label label2;
        private Button button_设置;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 注册系统右键菜单_ToolStripMenuItem;
    }
}