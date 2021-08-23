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

namespace Genshin_Character_Calculator
{
    /// <summary>
    /// StorageFrame.xaml 的互動邏輯
    /// </summary>
    public partial class StorageFrame : UserControl
    {
        private bool isFold;

        public StorageFrame(object content, string titleText)
        {
            InitializeComponent();
            curFrame.Content = content;

            isFold = false;
            setFold();

            title.Content = titleText;
        }

        private void folder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isFold = !isFold;
            setFold();
        }

        private void setFold()
        {
            if (isFold)
            {
                status.Content = "▶";
                curFrame.Visibility = Visibility.Hidden;
            }
            else
            {
                status.Content = "▼";
                curFrame.Visibility = Visibility.Visible;
            }
        }
    }
}
