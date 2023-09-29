using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFileRemarkEditer.Core;

namespace WinFileRemarkEditer.UI
{
    public partial class QuickEditForm : Form
    {
        public QuickEditForm()
        {
            InitializeComponent();
        }

        public string Path { get => textBox_路径.Text; set => textBox_路径.Text = value; }
        public bool IsFile { get; set; }


        private async void button_设置_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Path))
            {
                return;
            }
            string remark = textBox_备注编辑框.Text;
            var result = await FileRemarkHelper.SetPathRemark(IsFile, Path, remark);
            if (result.IsSuccess)
            {
                //MessageBox.Show(this, result.Info, "获取备注完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show(this, result.Info, "设置备注失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_取消_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var result = await FileRemarkHelper.GetPathRemark(IsFile, Path);
            textBox_备注编辑框.Text = result.IsSuccess ? result.Data : "";
            textBox_备注编辑框.Focus();
        }

    }
}
