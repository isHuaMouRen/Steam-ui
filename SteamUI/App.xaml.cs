using SteamUI.Utils;
using SteamUI.Windows;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SteamUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                //更新窗口
                var windowUpdate = new WindowUpdate();
                windowUpdate.Show();
                await Task.Delay(new Random().Next(2, 5) * 1000);
                windowUpdate.isCanExit = false;
                windowUpdate.Close();

                await Task.Delay(new Random().Next(1, 2) * 1000);

                //登录窗口
                var windowLogin = new WindowLogin();
                windowLogin.Show();
            }
            catch (Exception ex)
            {
                ErrorReportDialog.Show(ex);
            }
        }
    }

}
