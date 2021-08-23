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
    /// AllRelic.xaml 的互動邏輯
    /// </summary>
    public partial class AllRelic : UserControl
    {
        string[] relicTitle = { "生之花", "死之羽", "時之沙", "空之杯", "理之冠"};
        StorageFrame[] relics = new StorageFrame[5];

        public AllRelic()
        {
            InitializeComponent();
            
            
            for(int i=0; i<relics.Length; i++)
            {
                relics[i] = new StorageFrame(new EachRelic(), relicTitle[i]);

                

            }
            relicFrame0.Content = relics[0];
            relicFrame1.Content = relics[1];
            relicFrame2.Content = relics[2];
            relicFrame3.Content = relics[3];
            relicFrame4.Content = relics[4];
        }
    }
}
