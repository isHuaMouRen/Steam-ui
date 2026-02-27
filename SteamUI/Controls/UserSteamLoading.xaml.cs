using System;
using System.Collections.Generic;
using System.Drawing.Imaging.Effects;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SteamUI.Controls
{
    /// <summary>
    /// UserSteamLoading.xaml 的交互逻辑
    /// </summary>
    public partial class UserSteamLoading : UserControl
    {
        public UserSteamLoading()
        {
            InitializeComponent();
            Loaded += (async (s, e) =>
            {
                var animation1 = new DoubleAnimation
                {
                    From = 1,
                    To = 0.9,
                    Duration = TimeSpan.FromSeconds(2),
                    EasingFunction = new PowerEase { Power = 5, EasingMode = EasingMode.EaseInOut }
                };
                var animation2 = new DoubleAnimation
                {
                    From = 0.9,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(2),
                    EasingFunction = new PowerEase { Power = 5, EasingMode = EasingMode.EaseInOut }
                };

                while (true)
                {
                    var trans = (ScaleTransform)icon.RenderTransform;

                    trans.BeginAnimation(ScaleTransform.ScaleXProperty, animation1);
                    trans.BeginAnimation(ScaleTransform.ScaleYProperty, animation1);

                    await Task.Delay(2000);

                    trans.BeginAnimation(ScaleTransform.ScaleXProperty, animation2);
                    trans.BeginAnimation(ScaleTransform.ScaleYProperty, animation2);

                    await Task.Delay(2000);
                }
            });
        }
    }
}
