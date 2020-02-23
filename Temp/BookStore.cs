using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Temp {

    public class StudyUnit3 {
        [CommandMethod("CheckForPickFirstSelection",CommandFlags.UsePickSet)]
        public static void TestForPickFirst() {

            //获取当前文档
            Document doc = Application.DocumentManager.MdiActiveDocument;

            //获取当前文档的编辑器（命令行）
            Editor acEditor = Application.DocumentManager.MdiActiveDocument.Editor;

            //从当前编辑器获取命令行选择集
            PromptSelectionResult promptSelectionResult = acEditor.SelectImplied();



            ////获取当前选择集内选择工具的数量
            //if(promptSelectionResult.Status == PromptStatus.OK) {
            //    //输出选择对象的数量
            //    Application.ShowAlertDialog($"num is {set.Count}");
            //}
            //else {
            //    Application.ShowAlertDialog("No");
            //}

            //清空选择集内对象
            ObjectId[] objectIds = new ObjectId[0];
            acEditor.SetImpliedSelection(objectIds);

            //提示用户选择对象
            promptSelectionResult = acEditor.GetSelection();

            //声明一个选择集变量用于存放从命令行获取的选择集
            SelectionSet set = promptSelectionResult.Value;

            //输出选择集的圆心
            if (promptSelectionResult.Status == PromptStatus.OK) {
                ObjectId[] o = set.GetObjectIds();
                //启动事物处理
                using (Transaction acTrans = doc.TransactionManager.StartTransaction()) {
                    //获取块表
                    BlockTable blkTable = acTrans.GetObject(doc.Database.BlockTableId, OpenMode.ForRead)
                        as BlockTable;

                    //获取块表记录
                    BlockTableRecord record = acTrans.GetObject(blkTable[BlockTableRecord.ModelSpace], OpenMode.ForRead)
                        as BlockTableRecord;

                    Circle c = acTrans.GetObject(o[0], OpenMode.ForRead) as Circle;
                    doc.Editor.WriteMessage($"圆心：{c.Center}；半径：{c.Radius}");
                }
            }
            else {
                Application.ShowAlertDialog("未发现选中对象");
            }
        }
    }
}
