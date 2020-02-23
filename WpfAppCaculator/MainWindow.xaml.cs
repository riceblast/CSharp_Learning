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
using WpfAppAlarmForm;


namespace WpfAppCaculator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow () {
            InitializeComponent();
            //alarmWindow = new WpfAppAlarmForm.MainWindow();//新建一个错误提示窗口但是不显示
        }

        private WpfAppAlarmForm.MainWindow alarmWindow;//用于显示错误提示

        public void Clear() {
            //清空所有输入，将运算符也清空
            TextBox_Operator1.Text = "";
            TextBox_Operator2.Text = "";
            Label_ShowResult.Content = "";
            ComboBox_Operand.SelectedIndex = -1;//回到运算符未选择的状态
        }



        private void Button_Commit_Click(object sender, RoutedEventArgs e) {
            try {//包含了所有的计算
                int operand = ComboBox_Operand.SelectedIndex;
                int num1, num2;
                num1 = Int32.Parse(TextBox_Operator1.Text);
                num2 = Int32.Parse(TextBox_Operator2.Text);
                switch (operand) {
                    case 0:
                        Label_ShowResult.Content = num1 + num2;
                        break;
                    case 1:
                        Label_ShowResult.Content = num1 - num2;
                        break;
                    case 2:
                        Label_ShowResult.Content = num1 * num2;
                        break;
                    case 3:
                        if (num2 == 0) {
                            alarmWindow = new WpfAppAlarmForm.MainWindow();
                            alarmWindow.setAlarm("0不能作为除数");
                            alarmWindow.ShowDialog();
                        }
                        else
                            Label_ShowResult.Content = ((double)num1) / num2;
                        break;
                }
            }
            catch (FormatException) {//所输入的数字格式不对
                alarmWindow = new WpfAppAlarmForm.MainWindow();
                alarmWindow.setAlarm("输入数字格式错误");
                alarmWindow.ShowDialog();
            }
            catch (OverflowException) {//输入数字过大
                alarmWindow = new WpfAppAlarmForm.MainWindow();
                alarmWindow.setAlarm("输入数字过大");
                alarmWindow.ShowDialog();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {//清空按钮
            Clear();//清空
        }
    }
}
