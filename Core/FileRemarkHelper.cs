using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WinFileRemarkEditer.Datas;
using WinFileRemarkEditer.Util;
using FileInfo = System.IO.FileInfo;

namespace WinFileRemarkEditer.Core
{
    public static class FileRemarkHelper
    {


#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        public static async Task<GetResult> GetPathRemark(bool isFile, string filePath)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        {
            try
            {
                ShellObject? obj;
                if (isFile) 
                {
                    obj = ShellFile.FromFilePath(filePath);
                }
                else
                {
                    obj = ShellObject.FromParsingName(filePath);
                }

                return GetResult.Success(obj?.Properties?.System?.Comment.Value);
            }
            catch (Exception ex)
            {
                return "获取备注发生异常: " + ex.Message;
            }
        }
#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        public static async Task<SetResult> SetPathRemark(bool isFile, string path, string remark)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        {
            try
            {
                if (isFile)
                {
                    return SetFileRemark1(path, remark);
                }
                else
                {
                    return SetFolderRemark2(path, remark);
                }
            }
            catch (Exception ex)
            {
                return "设置备注发生异常: " + ex.Message;
            }
        }

        #region 设置备注
        private static SetResult SetFileRemark1(string path, string remark)
        {
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                return "文件不存在";
            }
            var obj = ShellFile.FromFilePath(path);
            if (obj == null)
            {
                return "未能打开文件对象";
            }
            try
            {
                obj.Properties.System.Comment.Value = remark;
            }
            catch
            {
                return "无法写入备注到指定文件";
            }
            //var writer = obj.Properties?.GetPropertyWriter();
            //if (writer == null)
            //{
            //    return "未能获取到属性写入对象";
            //}
            //try
            //{
            //    writer.WriteProperty(SystemProperties.System.Comment, remark);
            //}
            //catch (Exception ex)
            //{
            //    return "写入属性发生异常: " + ex.Message;
            //}
            //finally
            //{
            //    writer.Close();
            //}
            return true;
        }
        //private static SetResult SetFileRemark2(string path, string remark)
        //{
        //    FileInfo file = new FileInfo(path);
        //    if (!file.Exists)
        //    {
        //        return "文件不存在";
        //    }
        //    DSOFile.OleDocumentProperties dsoFile = new DSOFile.OleDocumentProperties();
        //    try
        //    {
        //        dsoFile.Open(file.FullName, false, DSOFile.dsoFileOpenOptions.dsoOptionDefault);
        //        dsoFile.SummaryProperties.Comments = remark;
        //    } 
        //    catch (Exception ex)
        //    {
        //        return "设置备注发生异常: " + ex.Message;
        //    }
        //    finally
        //    {
        //        dsoFile.Save();
        //        dsoFile.Close(false);
        //    }

        //    return true;
        //}

        [Obsolete]
        private static SetResult SetFolderRemark1(string path, string remark)
        {
            DirectoryInfo folder = new DirectoryInfo(path);
            if (!folder.Exists)
            {
                return "文件夹不存在";
            }

            const string DesktopIni = "Desktop.ini";
            const string Section1 = ".ShellClassInfo";
            const string Key_Remark = "InfoTip";
            const string Key_IconResource = "IconResource";
            const string DefaultValue_IconResource = "C:\\WINDOWS\\System32\\SHELL32.dll,4";
            const string Section2 = "ViewState";
            const string Key_Mode = "Mode";
            const string Key_Vid = "Vid";
            const string Key_FolderType = "FolderType";
            const string DefaultValue_FolderType = "Generic";

            string iniFile = folder.FullName + "/" + DesktopIni;
            var helper = new InitFileHelper(iniFile, true);
            List<bool> results = new List<bool>();
            results.Add(helper.Write(Key_Remark, remark, Section1));
            results.Add(helper.WriteDefault(Key_IconResource, DefaultValue_IconResource, Section1));
            results.Add(helper.WriteDefault(Key_Mode, "", Section2));
            results.Add(helper.WriteDefault(Key_Vid, "", Section2));
            results.Add(helper.WriteDefault(Key_FolderType, DefaultValue_FolderType, Section2));

            if (results.Any(i => !i))
            {
                return "写入备注失败!";
            }

            FileInfo file = new FileInfo(helper.Path);
            file.Attributes = FileAttributes.System | FileAttributes.Hidden;

            //bool refreshResult = await RefreshSystemIcons(helper.Path);


            return true;
        }

        private static SetResult SetFolderRemark2(string path, string remark)
        {
            LPSHFOLDERCUSTOMSETTINGS FolderSettings = new LPSHFOLDERCUSTOMSETTINGS();
            FolderSettings.dwMask = MaskEnum.FCSM_INFOTIP;
            FolderSettings.cchInfoTip = 0;
            FolderSettings.pszInfoTip = remark;

            string pszPath = path;
            uint HRESULT = SHGetSetFolderCustomSettings(ref FolderSettings, pszPath, FCSEnum.FCS_FORCEWRITE);
            return HRESULT >= 0;
        }
        private enum FCSEnum : uint
        {
            FCS_READ = 0x00000001,
            FCS_FORCEWRITE = 0x00000002,
            FCS_WRITE = (FCS_READ | FCS_FORCEWRITE),
        }
        [Flags]
        private enum MaskEnum : uint
        {
            /// <summary>
            /// 已弃用。 pvid 包含文件夹的 GUID。
            /// </summary>
            [Obsolete]
            FCSM_VIEWID = 0x00000001,
            /// <summary>
            /// 已弃用。 pszWebViewTemplate 包含指向包含文件夹 WebView 模板路径的缓冲区的指针。
            /// </summary>
            [Obsolete]
            FCSM_WEBVIEWTEMPLATE = 0x00000002,
            /// <summary>
            /// pszInfoTip 包含指向包含文件夹信息提示的缓冲区的指针。
            /// </summary>
            FCSM_INFOTIP = 0x00000004,
            /// <summary>
            /// pclsid 包含文件夹的 CLSID。
            /// </summary>
            FCSM_CLSID = 0x00000008,
            /// <summary>
            /// pszIconFile 包含包含文件夹图标的文件的路径。
            /// </summary>
            FCSM_ICONFILE = 0x00000010,
            /// <summary>
            /// pszLogo 包含包含文件夹缩略图图标的文件的路径。
            /// </summary>
            FCSM_LOGO = 0x00000020,
            /// <summary>
            /// 未使用。
            /// </summary>
            FCSM_FLAGS = 0x00000040,
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Auto)]
        static extern uint SHGetSetFolderCustomSettings(ref LPSHFOLDERCUSTOMSETTINGS pfcs, string pszPath, FCSEnum dwReadWrite);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct LPSHFOLDERCUSTOMSETTINGS
        {
            /// <summary>
            /// 结构大小（以字节为单位）
            /// </summary>
            public uint dwSize;
            /// <summary>
            /// 一个 DWORD 值，指定要从此结构读取或写入的文件夹属性。
            /// </summary>
            public MaskEnum dwMask;
            /// <summary>
            /// 文件夹的 GUID
            /// </summary>
            public IntPtr pvid;
            /// <summary>
            /// 指向包含文件夹 WebView 模板路径的以 null 结尾的字符串的指针。
            /// </summary>
            public string pszWebViewTemplate;
            /// <summary>
            /// 如果 SHGetSetFolderCustomSettings 参数 dwReadWriteFCS_READ，则这是 pszWebViewTemplate 缓冲区的大小（以字符为单位）。 否则，这是要从该缓冲区写入的字符数。 将此参数设置为 0 可写入整个字符串。
            /// </summary>
            public uint cchWebViewTemplate;
            /// <summary>
            /// 指向包含 WebView 模板版本的以 null 结尾的缓冲区的指针。
            /// </summary>
            public string pszWebViewTemplateVersion;
            /// <summary>
            /// 指向以 null 结尾的缓冲区的指针，该缓冲区包含文件夹的信息提示的文本。
            /// </summary>
            public string pszInfoTip;
            /// <summary>
            /// 如果 SHGetSetFolderCustomSettings 参数 dwReadWrite为FCS_READ，则为 pszInfoTip 缓冲区的大小（以字符为单位）。 否则，这是要从该缓冲区写入的字符数。 将此参数设置为 0 可写入整个字符串。
            /// </summary>
            public uint cchInfoTip;
            /// <summary>
            /// 指向 CLSID 的指针，用于标识 Windows 注册表中的文件夹。 其他文件夹信息存储在该 CLSID 条目下的注册表中。
            /// </summary>
            public IntPtr pclsid;
            /// <summary>
            /// 未使用。
            /// </summary>
            public uint dwFlags;
            /// <summary>
            /// 指向以 null 结尾的缓冲区的指针，该缓冲区包含包含文件夹图标的文件的路径。
            /// </summary>
            public string pszIconFile;
            /// <summary>
            /// 如果 SHGetSetFolderCustomSettings 参数 dwReadWriteFCS_READ，则这是 pszIconFile 缓冲区的大小（以字符为单位）。 否则，这是要从该缓冲区写入的字符数。 将此参数设置为 0 可写入整个字符串。
            /// </summary>
            public uint cchIconFile;
            /// <summary>
            /// pszIconFile 中名为 的文件中图标的索引。
            /// </summary>
            public int iIconIndex;
            /// <summary>
            /// 指向以 null 结尾的缓冲区的指针，该缓冲区包含包含文件夹徽标图像的文件的路径。 这是缩略图视图中使用的图像。
            /// </summary>
            public string pszLogo;
            /// <summary>
            /// 如果 SHGetSetFolderCustomSettings 参数 dwReadWrite为FCS_READ，则为 pszLogo 缓冲区的大小（以字符为单位）。 否则，这是要从该缓冲区写入的字符数。 将此参数设置为 0 可写入整个字符串。
            /// </summary>
            public uint cchLogo;
        }

        #endregion


    }
}
