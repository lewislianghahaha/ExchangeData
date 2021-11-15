using System;
using System.Data;

namespace ExchangeData.Dt
{
    //临时表
    public class TempDt
    {
        /// <summary>
        /// 导入模板
        /// </summary>
        /// <returns></returns>
        public DataTable ImportDt()
        {
            var dt = new DataTable();
            for (var i = 0; i < 13; i++)
            {
                var dc = new DataColumn();

                switch (i)
                {
                    case 0:
                        dc.ColumnName = "ProductCode";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 1:
                        dc.ColumnName = "Code";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 2:
                        dc.ColumnName = "Name";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 3:
                        dc.ColumnName = "Desc";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 4:
                        dc.ColumnName = "Curr";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 5:
                        dc.ColumnName = "Curr1";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 6:
                        dc.ColumnName = "Curr2";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 7:
                        dc.ColumnName = "Curr3";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 8:
                        dc.ColumnName = "Curr5";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 9:
                        dc.ColumnName = "Curr6";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 10:
                        dc.ColumnName = "Curr7";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 11:
                        dc.ColumnName = "Curr8";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 12:
                        dc.ColumnName = "Curr9";
                        dc.DataType = Type.GetType("System.String");
                        break;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }


        /// <summary>
        /// 导出模板
        /// </summary>
        /// <returns></returns>
        public DataTable ExportDt()
        {
            var dt = new DataTable();

            for (var i = 0; i < 6; i++)
            {
                var dc = new DataColumn();

                switch (i)
                {
                    case 0:
                        dc.ColumnName = "产品系列";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 1:
                        dc.ColumnName = "色母编号";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 2:
                        dc.ColumnName = "色母名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 3:
                        dc.ColumnName = "描述";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 4:
                        dc.ColumnName = "体积名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 5:
                        dc.ColumnName = "单价";
                        dc.DataType = Type.GetType("System.Decimal"); 
                        break;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }
    }
}
