using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFileRemarkEditer.Datas;
namespace WinFileRemarkEditer.Core
{
    internal class RegisterSystemRightButtonMenu
    {
        private static RegistryKey ClassesRoot { get => Registry.ClassesRoot; }
        private static RegistryKey CurrentUser { get => Registry.CurrentUser; }
        private static RegistryKey File_ShellRegistry 
        {
            get
            {
                if (_file_shellRegistry == null)
                {
                    string[] subs = new string[]
                    {
                        "Software", "Classes", "*", "shell",
                    };
                    _file_shellRegistry = Create(CurrentUser, subs);
                }
                return _file_shellRegistry;
            }
        }
        private static RegistryKey? _file_shellRegistry;
        private static RegistryKey Folder_ShellRegistry
        {
            get
            {
                if (_folder_shellRegistry == null)
                {
                    string[] subs = new string[]
                    {
                        "Directory", "shell",
                    };
                    _folder_shellRegistry = Create(ClassesRoot, subs);
                }
                return _folder_shellRegistry;
            }
        }
        private static RegistryKey? _folder_shellRegistry;
        private static RegistryKey Create(RegistryKey root, string[] nodes)
        {
            var temp = root;
            foreach (string s in nodes)
            {
                var temp2 = temp.OpenSubKey(s, true);
                if (temp2 == null)
                {
                    temp2 = temp.CreateSubKey(s);
                }
                temp = temp2;
            }
            return temp;
        }


        private const string KeyName_SetRemark = "WFRE_SetRemark";
        private const string ShowName_SetRemark = "设置备注";
        private const string KeyName_Command = "command";

        public static bool CheckRegister()
        {
            return _checkRegister(File_ShellRegistry) || _checkRegister(Folder_ShellRegistry);
        }
        private static bool _checkRegister(RegistryKey node)
        {
            return node?.GetSubKeyNames().Contains(KeyName_SetRemark) ?? false;
        }
        public static SetResult Register()
        {
            SetResult result;
            result = _register(File_ShellRegistry, ModeEnum.QuickFile);
            if (!result.IsSuccess) return result;
            result = _register(Folder_ShellRegistry, ModeEnum.QuickFolder);
            if (!result.IsSuccess) return result;
            return result;
        }
        private static SetResult _register(RegistryKey node, ModeEnum mode)
        {
            var shellRegistry = node;
            if (shellRegistry == null) return $"未能找到注册表节点";
            RegistryKey rightButtonMenuItemRegister = shellRegistry.CreateSubKey(KeyName_SetRemark);
            rightButtonMenuItemRegister.SetValue("", ShowName_SetRemark);
            RegistryKey commonRegister = rightButtonMenuItemRegister.CreateSubKey(KeyName_Command);
            commonRegister.SetValue("", $"\"{Application.ExecutablePath}\" \"{mode}\" \"%1\"");

            return true;
        }

        public static SetResult Unregister()
        {
            SetResult result;
            result = _unregister(File_ShellRegistry);
            if (!result.IsSuccess) return result;
            result = _unregister(Folder_ShellRegistry);
            if (!result.IsSuccess) return result;
            return result;
        }
        private static SetResult _unregister(RegistryKey node)
        {
            var shellRegistry = node;
            if (shellRegistry == null) return true;
            bool exist = node.GetSubKeyNames().Contains(KeyName_SetRemark);
            if (!exist) return true;
            RegistryKey? rightButtonMenuItemRegister = shellRegistry.OpenSubKey(KeyName_SetRemark, true);
            RegistryKey? commonRegister = rightButtonMenuItemRegister?.OpenSubKey(KeyName_Command, true);
            if (commonRegister != null)
            {
                rightButtonMenuItemRegister?.DeleteSubKey(KeyName_Command);
            }
            if (rightButtonMenuItemRegister != null)
            {
                shellRegistry?.DeleteSubKey(KeyName_SetRemark);
            }
            return true;
        }
    }
}
