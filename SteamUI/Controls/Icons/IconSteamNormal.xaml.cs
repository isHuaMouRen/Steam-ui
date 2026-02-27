using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SteamUI.Controls.Icons
{
    /// <summary>
    /// IconSteamNormal.xaml 的交互逻辑
    /// </summary>
    public partial class IconSteamNormal : UserControl
    {
        public Color IconColor { get; set; } = Colors.Black;

        public IconSteamNormal()
        {
            InitializeComponent();
            Loaded += ((s, e) =>
            {
                path.Fill = new SolidColorBrush(IconColor);
            });
        }
    }
}
