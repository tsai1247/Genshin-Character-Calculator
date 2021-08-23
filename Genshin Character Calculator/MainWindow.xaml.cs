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
        private CharacterWhiteValue characterWhiteValue = new CharacterWhiteValue();
        private WeaponWhiteValue weaponWhiteValue       = new WeaponWhiteValue();
        private AllRelic allRelic                       = new AllRelic();
        private Result result                           = new Result();


        private StorageFrame Storage_characterWhiteValue;
        private StorageFrame Storage_weaponWhiteValue;
        private StorageFrame Storage_allRelic;
        private StorageFrame Storage_result;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            #region initalize
            Storage_characterWhiteValue = new StorageFrame(characterWhiteValue, "角色", true);
            Storage_weaponWhiteValue = new StorageFrame(weaponWhiteValue, "武器", true);
            Storage_allRelic = new StorageFrame(allRelic, "聖遺物", true);
            Storage_result = new StorageFrame(result, "結果");


            CharacterWhiteValueFrame.Content = Storage_characterWhiteValue;
            WeaponWhiteValueFrame.Content = Storage_weaponWhiteValue;
            AllRelicFrame.Content = Storage_allRelic;
            ResultFrame.Content = Storage_result;
            #endregion
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

            #region initialize
            //角色攻擊力 + 武器主詞條)*所有攻擊 % +羽毛主詞條 + 所有攻擊副詞條
            
            hp = Get(characterWhiteValue.hp);
            atk = Get(characterWhiteValue.atk) + Get(weaponWhiteValue.atk);
            def = Get(characterWhiteValue.def);
            energy_recharge = 100;

            #endregion
            // TODO: calculate

            #region Put result in TextBox

            Set(result.hp, hp);
            Set(result.atk, atk);
            Set(result.def, def);
            Set(result.elemental_mastery, elemental_mastery);
            Set(result.crit_rate, crit_rate, true);
            Set(result.crit_dmg, crit_dmg, true);
            Set(result.healing_bonus, healing_bonus, true);
            Set(result.energy_recharge, energy_recharge, true);
            Set(result.dmg_bonus_name0, dmg_bonus_name[0]);
            Set(result.dmg_bonus_name1, dmg_bonus_name[1]);

            if (dmg_bonus_name[0] != "")
                Set(result.dmg_bonus0, dmg_bonus[0], true);
            else
                result.dmg_bonus_panel0.Visibility = Visibility.Collapsed;
            if (dmg_bonus_name[1] != "")
                Set(result.dmg_bonus1, dmg_bonus[1], true);
            else
                result.dmg_bonus_panel1.Visibility = Visibility.Collapsed;

            #endregion
        }

        #region Get Function
        private float Get(TextBox hp)
        {
            return float.Parse(hp.Text);
        }
        #endregion

        #region Set Function
        private void Set(TextBox tb, float val, bool percent = false)
        {
            if (!percent)
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
