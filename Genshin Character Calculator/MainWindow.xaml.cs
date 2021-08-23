using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Frame declaration
        private readonly StorageFrame characterWhiteValue = new StorageFrame(new CharacterWhiteValue(), "角色");
        private readonly StorageFrame weaponWhiteValue = new StorageFrame(new WeaponWhiteValue(), "武器");
        private readonly StorageFrame allRelic = new StorageFrame(new AllRelic(), "聖遺物");
        private readonly StorageFrame result = new StorageFrame(new Result(), "結果");
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            CharacterWhiteValueFrame.Content = characterWhiteValue;
            WeaponWhiteValueFrame.Content = weaponWhiteValue;
            AllRelicFrame.Content = allRelic;
            ResultFrame.Content = result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            #region variable declaration
            float hp =0; // 生命上限
            float atk=0; // 攻擊
            float def=0; // 防禦
            float elemental_mastery=0; // 元素精通
            float crit_rate=0; // 暴率
            float crit_dmg=0; // 暴傷
            float healing_bonus=0; // 治療加成
            float energy_recharge=0; // 充能效率
            string[] dmg_bonus_name = {"", ""}; // 傷害加成
            float[] dmg_bonus = {0, 0}; // 傷害加成
            #endregion

            // TODO: calculate

            #region Put result in TextBox
            Result resultList = (Result)(result.curFrame.Content);

            Set(resultList.hp, hp);
            Set(resultList.atk, atk);
            Set(resultList.def, def);
            Set(resultList.elemental_mastery, elemental_mastery);
            Set(resultList.crit_rate, crit_rate);
            Set(resultList.crit_dmg, crit_dmg);
            Set(resultList.healing_bonus, healing_bonus);
            Set(resultList.energy_recharge, energy_recharge);
            Set(resultList.dmg_bonus_name0, dmg_bonus_name[0]);
            Set(resultList.dmg_bonus_name1, dmg_bonus_name[1]);

            if (dmg_bonus_name[0] != "")
                Set(resultList.dmg_bonus0, dmg_bonus[0]);
            else
                resultList.dmg_bonus_panel0.Visibility = Visibility.Collapsed;
            if (dmg_bonus_name[1] != "")
                Set(resultList.dmg_bonus1, dmg_bonus[1]);
            else
                resultList.dmg_bonus_panel1.Visibility = Visibility.Collapsed;

            #endregion
        }

        #region Functions for "Put result in TextBox"
        private void Set(TextBox tb, float val, bool percent = true)
        {
            if (percent)
                tb.Text = string.Format("{0}", val);
            else
                tb.Text = string.Format("{0}%", val);
        }
        private void Set(TextBox tb, string val)
        {
            tb.Text = val;
        }
        #endregion
    }
}
