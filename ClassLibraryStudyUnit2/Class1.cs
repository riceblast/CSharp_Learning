using Autodesk.Windows;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;

namespace ClassLibraryStudyUnit2 {
    public class Class1 {
        [CommandMethod("PosiontionWindow")]
        public static void PositionWindow() {
            Point p = new Point(50, 50);
            Application.MainWindow.DeviceIndependentLocation = p;

            var size = new Size(400,400);
            Application.MainWindow.DeviceIndependentSize = size;
        }


    }
}
