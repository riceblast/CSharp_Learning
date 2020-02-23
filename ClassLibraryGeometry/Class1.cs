using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGeometry{
    public class House{
        [CommandMethod("MyHouse")]
        public void MyHouse() {
            Database db = HostApplicationServices.WorkingDatabase;

            //房屋的四个框架
            Line lBottom = Tool.L(100, 0, 300, 0);
            Line lTop = Tool.L(100, 100, 300, 100);
            Line lLeft = Tool.L(100, 0, 100, 100);
            Line lRight = Tool.L(300, 0, 300, 100);
            Tool.AddEntity(db, lBottom, lRight, lLeft, lTop);

            //屋顶
            Arc aTop = new Arc(new Point3d(200, 100, 0), 100, 0, Math.PI);
            Tool.AddEntity(db, aTop);

            //门
            Line doorLeft = Tool.L(125, 0, 125, 75);
            Line doorTop = Tool.L(125, 75, 175, 75);
            Line doorRight = Tool.L(175, 75, 175, 0);
            Tool.AddEntity(db, doorLeft, doorTop, doorRight);

            //窗子
            Circle windowLeft = new Circle(new Point3d(225, 75,0), new Vector3d(0, 0, 1), 15);
            Circle windowRight = new Circle(new Point3d(260, 75,0), new Vector3d(0, 0, 1), 15);
            Line lineLeftCol = Tool.L(225, 60, 225, 90);
            Line lineLeftRow = Tool.L(210, 75, 240, 75);
            Line lineRightCol = Tool.L(260,60,260,90);
            Line lineRightRow = Tool.L(245,75,275,75);
            Tool.AddEntity(db, windowLeft, windowRight,lineLeftCol,lineLeftRow,lineRightCol,lineRightRow);

            //门把手
            Line lineDown = Tool.L(160, 40, 170, 40);
            Line lineLeft = Tool.L(160, 40, 165, 45);
            Line lineRight = Tool.L(170, 40, 165, 45);
            Tool.AddEntity(db, lineDown, lineLeft, lineRight);
        }
    }

    public class Tool {
        public static ObjectId[] AddEntity(Database db,params Entity[] ent) {
            ///<summary>
            ///将图形对象添加到图形文件中
            /// </summary>
            /// <param name="db">图形数据库</param>
            /// <param name="ent">图形实体对象</param>
            /// <returns>图形的objectId</returns>
            //用于后期修改
            ObjectId[] entId = new ObjectId[ent.Length];

            using (Transaction trans = db.TransactionManager.StartTransaction()) {

                //打开块表
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //打开块表记录
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                //添加图形到块表记录
                for (int i = 0; i < ent.Length; i++) {
                    entId[i] = btr.AppendEntity(ent[i]);
                    //更新数据信息
                    trans.AddNewlyCreatedDBObject(ent[i], true);
                }
                //提交
                trans.Commit();

            }
            return entId;

        }
        public static Line L(int x1,int y1,int x2,int y2) {
            Point3d startPoint = new Point3d(x1, y1, 0);
            Point3d endPoint = new Point3d(x2, y2, 0);
            return new Line(startPoint, endPoint);
        }
    }
}
