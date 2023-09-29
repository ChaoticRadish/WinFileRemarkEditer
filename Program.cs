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
            //args = new string[] { ModeEnum.QuickFile.ToString(), "D:\\����\\����\\��Ŀ����\\XM23019-1 AGV�в�ϵͳ TGFP AGV RCSϵͳ\\�����ͼ\\20230504 �����ʾ��.png" };

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
            //��õ�ǰ��¼��Windows�û���ʾ 
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            //����Windows�û����� 
            Application.EnableVisualStyles();

            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //�жϵ�ǰ��¼�û��Ƿ�Ϊ����Ա 
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //����ǹ���Ա����ֱ������ 

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

                //������������ 
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                //���������ļ� 
                startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                //������������ 
                startInfo.Arguments = string.Join(" ", args);
                //������������,ȷ���Թ���Ա������� 
                startInfo.Verb = "runas";
                //������ǹ���Ա��������UAC 
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                    //�˳� 
                    System.Windows.Forms.Application.Exit();
                }
                catch { }
            }
        }
    }
}