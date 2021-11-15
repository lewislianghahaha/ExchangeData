using System;
using System.Data;
using ExchangeData.Dt;

namespace ExchangeData.Task
{
    //运算
    public class GenerateDt
    {
        TempDt tempDt=new TempDt();

        //运算并输出指定格式至DT
        public DataTable GenerateExcelToDt(DataTable sourcedt)
        {
            var dt = tempDt.ExportDt();
            var tempdt = tempDt.ImportDt();

            try
            {
                //循环读取sourcedt记录,若碰到第二列(Code)为空即插入至tempdt内
                foreach (DataRow rows in sourcedt.Rows)
                {
                    if (Convert.ToString(rows[1]) != "") continue;
                    tempdt.Merge(InsertTitleRecord(tempdt,rows));
                }

                //以tempdt作为条件进行循环,将获取相关值至对应项内
                foreach (DataRow rows in tempdt.Rows)
                {
                    //获取体积信息->如:1L 3.57L等
                    var tempsizename=InsertSizeName(rows);
                    //以tempsizename分裂并作内循环
                    var size = tempsizename.Split(',');
                    var dtlrows = sourcedt.Select("ProductCode='"+Convert.ToString(rows[0])+"'");
                    if (dtlrows.Length > 0)
                    {
                        //将标题行排除;从第二行开始;故变量i从1开始
                        for (var i = 1; i < dtlrows.Length; i++)
                        {
                            for (var j = 0; j < size.Length; j++)
                            {
                                //设置获取单价ID(因为单价坐标从第4位开始,故对应关系是从4+tempsizename分裂起始值组合获得)
                                var id = 4+j;

                                var newrow = dt.NewRow();
                                newrow[0] = dtlrows[i][0];  //产品系列
                                newrow[1] = dtlrows[i][1];  //色母编号
                                newrow[2] = dtlrows[i][2];  //色母名称
                                newrow[3] = dtlrows[i][3];  //描述
                                newrow[4] = size[j];        //体积名称
                                newrow[5] = Convert.ToString(dtlrows[i][id]) == "-"? 0 : Convert.ToDecimal(dtlrows[i][id]);  //单价
                                dt.Rows.Add(newrow);
                            }
                        }
                        // 插入空白行
                        dt.Merge(InsertEmptyRow(dt));
                    }

                    //将相关中转变量清空
                    tempsizename = "";
                }
            }
            catch (Exception)
            {
                dt.Columns.Clear();
                dt.Rows.Clear();
            }
            return dt;
        }

        /// <summary>
        /// 获取标题记录
        /// </summary>
        /// <returns></returns>
        private DataTable InsertTitleRecord(DataTable tempdt,DataRow rows)
        {
            var newrow = tempdt.NewRow();

            for (var i = 0; i < tempdt.Columns.Count; i++)
            {
                newrow[i] = rows[i];
            }
            tempdt.Rows.Add(newrow);
            return tempdt;
        }

        /// <summary>
        /// 获取体积名称
        /// </summary>
        /// <returns></returns>
        private string InsertSizeName(DataRow rows)
        {
            var tempsizename = string.Empty;

            for (var i = 4; i < 12; i++)
            {
                if(Convert.ToString(rows[i])=="")continue;

                if (tempsizename == "")
                {
                    tempsizename = Convert.ToString(rows[i]);
                }
                else
                {
                    tempsizename += ',' +Convert.ToString(rows[i]);
                }
            }
            return tempsizename;
        }

        /// <summary>
        /// 插入空白行
        /// </summary>
        /// <param name="sourcedt"></param>
        /// <returns></returns>
        private DataTable InsertEmptyRow(DataTable sourcedt)
        {
            var newrow = sourcedt.NewRow();
            for (var i = 0; i < sourcedt.Columns.Count; i++)
            {
                newrow[i] = DBNull.Value;
            }
            sourcedt.Rows.Add(newrow);
            return sourcedt;
        }

    }
}
