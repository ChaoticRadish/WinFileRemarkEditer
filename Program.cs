using WinFileRemarkEditer.Datas;
using WinFileRemarkEditer.UI;

namespace WinFileRemarkEditer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            //args = new string[] { ModeEnum.QuickFile.ToString(), "D:\\工作\\资料\\项目资料\\XM23019-1 AGV中层系统 TGFP AGV RCS系统\\讲解截图\\20230504 步骤表示例.png" };

            ApplicationConfiguration.Initialize();
            if (args != null)
            {
                if (args.Length >= 2)
                {
                    if (args[0] == ModeEnum.QuickFile.ToString())
                    {
                        string path = args[1];
                        QuickEditForm form = new QuickEditForm()
                        {
                            Path = path,
                            IsFile = true
                        };
                        Application.Run(form);
                        return;
                    }
                    else if (args[0] == ModeEnum.QuickFolder.ToString())
                    {
                        string path = args[1];
                        QuickEditForm form = new QuickEditForm()
                        {
                            Path = path,
                            IsFile = false,
                        };
                        Application.Run(form);
                        return;
                    }
                }
            }
            NormalStart(args);
        }

        private static void NormalStart(params string[]? args)
        {
            //获得当前登录的Windows用户标示 
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            //创建Windows用户主题 
            Application.EnableVisualStyles();

            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员 
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //如果是管理员，则直接运行 

                Application.EnableVisualStyles();
                Application.Run(new EditForm());
            }
            else if (args == null || args.Length == 0 || args[1] != ModeEnum.TryAdmin.ToString())
            {
                if (args == null || args.Length == 0)
                {
                    args = new string[] { ModeEnum.TryAdmin.ToString() };
                }
                else
                {
                    args[1] = ModeEnum.TryAdmin.ToString();
                }

                //创建启动对象 
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                //设置运行文件 
                startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                //设置启动参数 
                startInfo.Arguments = string.Join(" ", args);
                //设置启动动作,确保以管理员身份运行 
                startInfo.Verb = "runas";
                //如果不是管理员，则启动UAC 
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                    //退出 
                    System.Windows.Forms.Application.Exit();
                }
                catch { }
            }
        }
    }
}