using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.DatabaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;

namespace ClassLibraryAutoCADStudyUnit2{
    public class StudyUnit2 {
        [CommandMethod("MaxAppWindow")]
        public void MaxAppWindow() {
            //窗口最大化
            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.WindowState = Window.State.Maximized;
            MessageBox.Show("Max", "MinMax", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

        }

        [CommandMethod("MinAppWindow")]
        public void MinAppWindow() {
            //窗口最小化
            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.WindowState = Window.State.Minimized;
            MessageBox.Show("Min", "MinMax");
        }

        [CommandMethod("ShowWinState")]
        public void ShowWinState() {
            System.Windows.Forms.MessageBox.Show("The Application Window is " +
                Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.WindowState);
        }

        [CommandMethod("SetVisible")]
        public void SetVisible() {
            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Visible = true;
        }

        [CommandMethod("SetInvisible")]
        public void SetInvisible() {
            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Visible
                = false;
            MessageBox.Show("Mindow is now invisible", "hide/show");
        }

        [CommandMethod("SetLocAndSizeOfDoc")]
        public void SetLocAndSizeOfDoc() {
            //获取当前活动文档
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            //设置位置
            Point acPoint = new Point(100, 100);
            acDoc.Window.DeviceIndependentLocation = acPoint;

            //设置大小
            Size acSize = new Size(400, 400);
            acDoc.Window.DeviceIndependentSize = acSize;
        }

        [CommandMethod("MinDoc")]
        public void MinDoc() {
            //获取当前文档
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            //最大化
            acDoc.Window.WindowState = Window.State.Minimized;
            MessageBox.Show("doc has been minimized", "max/min");
        }

        [CommandMethod("invisibleDoc")]
        public void InvisibleDoc() {
            //获取当前文档
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            //不可见
            acDoc.Window.Visible = false;
        }

        [CommandMethod("VisibleDoc")]
        public void VisibleDoc() {
            //获取当前文档
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            //不可见
            acDoc.Window.Visible = true;
        }

        [CommandMethod("DocWinState")]
        public void DocWinState() {
            //获取当前文档
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            //窗体状态
            MessageBox.Show("State of activeDocument is " + acDoc.Window.WindowState);
        }


        [CommandMethod("NewDrawing", CommandFlags.Session)]
        public void NewDraing() {
            //新建一个图形问价
            string strTemplatePath = "acad.dwt";//以指定模板建立图形对象

            //获取DocumentManager对象
            DocumentCollection documentCollection
                = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager;

            //利用add方法添加图形文件
            documentCollection.Add(strTemplatePath);
        }

        [CommandMethod("OpenDrawing", CommandFlags.Session)]//打开文件
        public void OpenDrawing() {
            //首先找到要打开文件的路径
            string filePath = "C:\\User\\ASUS\\Documents\\autocad实例图形 杨翕然.dwg";

            //利用Document Collection类的对象打开文件
            DocumentCollection docCollection = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager;

            //判断图形是否存在
            if (File.Exists(filePath))
                docCollection.Open(filePath, false);//并不是只“可读”
            else//如果不存在
                MessageBox.Show("File didn't exist", "can't find file", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        [CommandMethod("SaveActiveDrawing")]//保存用户正在操作的文档，如果没有重命名要记得重命名
        public void SaveActiveDrawing() {
            //首先获取文件的名字
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            string acName = acDoc.Name;//获取当前文档的名字

            //判断该文档是否重命名，如果没有重命名则将名字进行更改
            //系统变量DWGTITED，若为0，则文件尚未进行重命名，默认为：Drawing1、Drawing2等等
            if (Convert.ToInt32(Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("DWGTITLED")) == 0) {
                //图形文件未重命名，未其重新命名
                acName = "d:\\MyDrawing";
            }

            //保存图形
            acDoc.Database.SaveAs(acName, true, Autodesk.AutoCAD.DatabaseServices.DwgVersion.Current, acDoc.Database.SecurityParameters);

        }

        [CommandMethod("DrawingSaved")]//查看用户当前图形是否保存，并询问用户是否进行保存
        public void DrawingSaved() {
            //利用系统变量DBMOD查看用户当前所做修改是否保存
            Object bdmod = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("DBMOD");

            if(Convert.ToInt32(bdmod) != 0) {//如果等于0则表示所有修改均已经保存
                if(MessageBox.Show("Do you want to save?","save changes",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)
                    == DialogResult.Yes) {
                    //如果用户想要保存修改
                    Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                    acDoc.Database.SaveAs(acDoc.Name, true, DwgVersion.Current, acDoc.Database.SecurityParameters);
                }
            }
            else {
                MessageBox.Show("There is no need to save");//如果所有修改均保存则无需保存
            }

        }




    }
}
