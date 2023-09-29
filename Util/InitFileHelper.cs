using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFileRemarkEditer.Util
{
    internal class InitFileHelper
    {
        #region DLL
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string? Key, string? Value, string FilePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        #endregion

        public string Path { get; private set; }

        public InitFileHelper(string IniPath, bool create = true)
        {
            var fileInfo = new FileInfo(IniPath);
            Path = fileInfo.FullName;
            if (!fileInfo.Exists)
            {
                if (create)
                {
                    var stream = fileInfo.Create();
                    //fileInfo.Attributes = FileAttributes.System | FileAttributes.Hidden;
                    stream.Close();
                }
                else
                {
                    throw new FileNotFoundException($"未能找到文件:{IniPath}");
                }
            }
        }
        public string Read(string? Key, string Section)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key ?? "", "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public bool Write(string? Key, string? Value, string Section)
        {
            var result = WritePrivateProfileString(Section, Key, Value, Path);
            return result > 0;
        }
        public bool WriteDefault(string? Key, string? DefaultValue, string Section)
        {
            string exist = Read(Key, Section);
            if (exist.Length == 0)
            {
                var result = WritePrivateProfileString(Section, Key, DefaultValue, Path);
                return result > 0;
            }
            return true;
        }
        public bool DeleteKey(string Key, string Section)
        {
            return Write(Key, null, Section);
        }
        public bool DeleteSection(string Section)
        {
            return Write(null, null, Section);
        }
        public bool KeyExists(string Key, string Section)
        {
            return Read(Key, Section).Length > 0;
        }

    }
}
