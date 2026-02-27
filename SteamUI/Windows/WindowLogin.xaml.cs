using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SteamUI.Windows
{
    /// <summary>
    /// WindowLogin.xaml 的交互逻辑
    /// </summary>
    public partial class WindowLogin : Window
    {
        public bool isCanExit = true;

        public WindowLogin()
        {
            InitializeComponent();
            Closed += ((s, e) => { if (isCanExit) Application.Current.Shutdown(0); });
            ModernWpf.ThemeManager.Current.ApplicationTheme = ModernWpf.ApplicationTheme.Dark;

            Loaded += (async (s, e) =>
            {
                var animX = new DoubleAnimation
                {
                    Duration = TimeSpan.FromMinutes(1),
                };

                var animY = new DoubleAnimation
                {
                    Duration = TimeSpan.FromMinutes(1),
                };

                while (true)
                {
                    animX.From = -50;
                    animX.To = -350;
                    animY.From = -200;
                    animY.To = -50;

                    trans.BeginAnimation(TranslateTransform.XProperty, animX);
                    trans.BeginAnimation(TranslateTransform.YProperty, animY);

                    await Task.Delay(TimeSpan.FromMinutes(1));

                    animX.To = -50;
                    animX.From = -350;
                    animY.To = -200;
                    animY.From = -50;

                    trans.BeginAnimation(TranslateTransform.XProperty, animX);
                    trans.BeginAnimation(TranslateTransform.YProperty, animY);

                    await Task.Delay(TimeSpan.FromMinutes(1));
                }
            });
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            grid_Loading.Visibility = Visibility.Visible;
            grid_Login.Visibility = Visibility.Hidden;


            await Task.Delay(new Random().Next(1, 5) * 1000);
            isCanExit = false;
            this.Close();

            await Task.Delay(new Random().Next(1, 5) * 1000);

            var windowMain = new WindowMain();
            windowMain.Show();
        }
    }
}
