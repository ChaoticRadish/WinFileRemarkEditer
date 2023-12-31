﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFileRemarkEditer.Core;
using WinFileRemarkEditer.Datas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFileRemarkEditer.UI
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();

            ClearSelect();

        }

        #region 当前输入
        private bool IsFile;
        private string FullPath = string.Empty;

        public void ClearSelect()
        {
            textBox_备注编辑框.ReadOnly = true;
            textBox_备注编辑框.Clear();
            textBox_当前选择文件或文件夹.Clear();
            button_设置.Enabled = false;
        }
        public async void SelectFile(string path)
        {
            IsFile = true;
            FullPath = path;

            button_设置.Enabled = true;
            textBox_备注编辑框.ReadOnly = false;
            textBox_备注编辑框.Text = string.Empty;
            textBox_当前选择文件或文件夹.Text = path;

            var result = await FileRemarkHelper.GetPathRemark(IsFile, path);
            if (result.IsSuccess)
            {
                textBox_备注编辑框.Text = result.Data;
            }
            else
            {
                MessageBox.Show(this, result.Info, "获取备注失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public async void SelectDir(string path)
        {
            IsFile = false;
            FullPath = path;

            button_设置.Enabled = true;
            textBox_备注编辑框.ReadOnly = false;
            textBox_备注编辑框.Text = string.Empty;
            textBox_当前选择文件或文件夹.Text = path;

            var result = await FileRemarkHelper.GetPathRemark(IsFile, path);
            if (result.IsSuccess)
            {
                textBox_备注编辑框.Text = result.Data;
            }
            else
            {
                MessageBox.Show(this, result.Info, "获取备注失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void button_选择文件_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,
            };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                if (File.Exists(fileName))
                {
                    SelectFile(fileName);
                }
            }
        }

        private void button_选择文件夹_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = dialog.SelectedPath;
                if (Directory.Exists(fileName))
                {
                    SelectDir(fileName);
                }
            }
        }

        private async void button_设置_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FullPath))
            {
                return;
            }
            string remark = textBox_备注编辑框.Text;
            var result = await FileRemarkHelper.SetPathRemark(IsFile, FullPath, remark);
            if (result.IsSuccess)
            {
                MessageBox.Show(this, result.Info, "设置备注完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, result.Info, "设置备注失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 注册系统右键菜单_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isRegister = RegisterSystemRightButtonMenu.CheckRegister();
            SetResult result = false;
            string action;
            if (isRegister)
            {
                action = "注册";
                result = RegisterSystemRightButtonMenu.Unregister();
            }
            else
            {
                action = "解除注册";
                result = RegisterSystemRightButtonMenu.Register();
            }
            if (result.IsSuccess)
            {
                MessageBox.Show(this, result.Info, $"{action}成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateShowing_注册系统右键菜单();
            }
            else
            {
                MessageBox.Show(this, result.Info, $"{action}失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 重载
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            UpdateShowing_注册系统右键菜单();
        }
        #endregion

        private void UpdateShowing_注册系统右键菜单()
        {
            注册系统右键菜单_ToolStripMenuItem.Text = !RegisterSystemRightButtonMenu.CheckRegister() ? "注册系统右键菜单" : "解除注册系统右键菜单";
        }
    }
}
