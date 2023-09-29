using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFileRemarkEditer.Datas
{
    public struct GetResult
    {
        public bool IsSuccess { get; set; }
        public string Info { get; set; }
        public string Data { get; set; }

        public static GetResult Success(string? remark)
        {
            return new GetResult { IsSuccess = true, Info = "获取成功", Data = remark ?? "" };
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
}
