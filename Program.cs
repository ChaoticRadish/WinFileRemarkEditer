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
            Application.Run(new EditForm());
        }
    }
}