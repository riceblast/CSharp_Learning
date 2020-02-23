using Autodesk.Windows;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autodesk.AutoCAD.ApplicationServices;

namespace RibbonDemo {
    public class Class1 {
        [CommandMethod("RibbonDemo")]
        public static void RibbonDemo() {


            //新建新的Ribbon
            RibbonControl ribbonCtrl = ComponentManager.Ribbon;
            RibbonTab tab = new RibbonTab();
            tab.Title = "MyRibbon";
            tab.UID = "ACAD.MY_RibbonTab";
            ribbonCtrl.Tabs.Add(tab);

            //新建RibbonPanelSource存放按钮，title等
            RibbonPanelSource ribbonPanelSource = new RibbonPanelSource();
            ribbonPanelSource.Title = "测试";//选项卡名字

            //新建RibbonPanel，并将Pannelsource添加到RibbonPanel中
            RibbonPanel ribbonPanel = new RibbonPanel();
            ribbonPanel.Source = ribbonPanelSource;

            //将选项卡（RibbonPanel）添加到tab中
            tab.Panels.Add(ribbonPanel);

            //添加按钮
            RibbonButton btn = new RibbonButton();
            btn.Name = "我是一个按钮提示";//按钮提示标题
            btn.Text = "按一下有惊喜";//按钮文字
            btn.ShowText = true;//让Button把准备好的文字显示出来
            btn.IsVisible = true;//让按钮可见;

            //添加按钮帮助
            RibbonToolTip toolTip = new RibbonToolTip();//按钮提示对象
            toolTip.Title = "我是按钮提示的标题";//按钮提示标题
            toolTip.Content = "我是按钮提示的内容";//按钮提示内容
            toolTip.Command = "AAAA";//该按钮对应命令

            //将按钮提示绑定到按钮上
            btn.ToolTip = toolTip;

            //为按钮添加事件处理器
            btn.CommandHandler = new Handler();
            ////将按钮对应一个命令
            //btn.CommandParameter = "AAAA ";        （存疑！！！！）

            ribbonPanelSource.Items.Add(btn);//将按钮添加到PannelSource中






            //在winform绘图需要一个GDI+类

        }


    }

    internal class Handler :ICommand{
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {//判断当前情况下能否执行该命令
            return true;
        }

        public void Execute(object parameter) {//如何执行该命令
            if(parameter is RibbonButton) {//如果传进来ribbonbutton对象
                Document doc = Application.DocumentManager.MdiActiveDocument;
                doc.Editor.WriteMessage("Hi,这是点击之后的效果哦！");
            }
        }
    }
}
