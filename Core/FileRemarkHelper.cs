using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFileRemarkEditer.Core
{
    public static class FileRemarkHelper
    {
        public struct GetResult
        {
            public bool IsSuccess { get; set; }
            public string Info { get; set; }
            public string Data { get; set; }   

            public static GetResult Success(string remark)
            {
                return new GetResult { IsSuccess = true, Info = "获取成功", Data = remark };
            }
            public static implicit operator GetResult(string failureInfo)
            {
                return new GetResult { IsSuccess = false, Info = string.IsNullOrEmpty(failureInfo) ? "设置失败" : failureInfo };
            }
        }
        public struct SetResult
        {
            public bool IsSuccess { get; set; }
            public string Info { get; set; }

            public static implicit operator SetResult(bool b)
            {
                return new SetResult { IsSuccess = b, Info = b ? "设置成功" : "设置失败" };
            }
            public static implicit operator SetResult(string failureInfo)
            {
                return new SetResult { IsSuccess = false, Info = string.IsNullOrEmpty(failureInfo) ? "设置失败" : failureInfo };
            }
        }


#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        public static async Task<GetResult> GetPathRemark(bool isFile, string filePath)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        {
            try
            {
                ShellObject obj;
                if (isFile) 
                {
                    obj = ShellFile.FromFilePath(filePath);
                }
                else
                {
                    obj = ShellObject.FromParsingName(filePath);
                }

                return GetResult.Success(obj.Properties.System.Comment.Value);
            }
            catch (Exception ex)
            {
                return "获取备注发生异常: " + ex.Message;
            }
        }
#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        public static async Task<SetResult> SetPathRemark(bool isFile, string filePath, string remark)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        {
            try
            {
                ShellObject obj;
                if (isFile)
                {
                    obj = ShellFile.FromFilePath(filePath);
                }
                else
                {
                    obj = ShellObject.FromParsingName(filePath);
                }
                obj.Properties.System.Comment.Value = remark;
                return true;
            }
            catch (Exception ex)
            {
                return "设置备注发生异常: " + ex.Message;
            }
        }
        
    }
}
