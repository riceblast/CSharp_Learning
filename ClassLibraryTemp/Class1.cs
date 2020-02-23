using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.BoundaryRepresentation;
//using Autodesk.AutoCAD.Interop
//using Autodesk.AutoCAD.Interop.Common

[assembly: CommandClass(typeof(ClassLibraryTemp.Program))]
namespace ClassLibraryTemp{
    public class Program{
        [CommandMethod("MyCommmand")]
        public static ObjectId AddEntity(Database db, Entity ent) {
            ///<summary>
            ///将图形对象添加到图形文件中
            /// </summary>
            /// <param name="db">图形数据库</param>
            /// <param name="ent">图形实体对象</param>
            /// <returns>图形的objectId</returns>
            //用于后期修改
            ObjectId entId = ObjectId.Null;

            using (Transaction trans = db.TransactionManager.StartTransaction()) {
                
                //打开块表
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //打开块表记录
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                //添加图形到块表记录
                entId = btr.AppendEntity(ent);
                //更新数据信息
                trans.AddNewlyCreatedDBObject(ent, true);
                //提交
                trans.Commit();

            }
            return entId;

        }

        public static ObjectId[] AddEntity(Database db, params Entity[] ent) {
            ///<summary>
            ///将图形对象添加到图形文件中
            /// </summary>
            /// <param name="db">图形数据库</param>
            /// <param name="ent">图形实体对象,可变参数</param>
            /// <returns>图形的objectId，数组返回</returns>
            ObjectId[] entId = new ObjectId[ent.Length];

            using (Transaction trans = db.TransactionManager.StartTransaction()) {

                //打开块表
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //打开块表记录
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                //添加图形到块表记录
                for(int i = 0; i < ent.Length; i++) {
                    entId[i] = btr.AppendEntity(ent[i]);
                    trans.AddNewlyCreatedDBObject(ent[i], true);
                }
                trans.Commit();

            }
            return entId;
        }


            public void MyCommand() {
            Database db = HostApplicationServices.WorkingDatabase;

            Line a = new Line(new Point3d(40,40,0),)

        }


    }

}

