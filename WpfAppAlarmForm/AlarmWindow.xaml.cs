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


namespace WpfAppAlarmForm {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }



        public void setAlarm(string alarmText) {
            //输入要警告的句子，让警告窗口显示
            label_Alarm.Content = alarmText;//在WpfAppAlarmForm里的xaml文件中将label_Alarm设置为public
            Visibility = Visibility.Visible;
        }

        private void button_OK_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
