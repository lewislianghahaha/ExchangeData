using System.Data;

namespace ExchangeData.Task
{
    public class TaskLogic
    {
        ImportDt importDt=new ImportDt();
        ExportDt exportDt=new ExportDt();
        GenerateDt generate=new GenerateDt();

        #region 变量定义

            #region Excel导入
            private string _fileAddress;             //文件地址
            #endregion

            #region 生成
            private DataTable _sourcedt;             //将导入过来的EXCEL Dt放入并生成
            #endregion

            #region 返回变量
            private DataTable _resultTable;          //返回DT类型
            private bool _resultMark;                //返回是否成功标记
            #endregion

            #region 导出EXCEL
            private DataTable _exportdt;             //获取Dt记录集(用于导出至EXCEL)
            #endregion

        #endregion

        #region Set
            /// <summary>
            /// 文件地址
            /// </summary>
            public string FileAddress { set { _fileAddress = value; } }
            
            /// <summary>
            /// 生成DT使用
            /// </summary>
            public DataTable Sourcedt {set { _sourcedt = value; }}

            /// <summary>
            /// 获取Dt记录集(用于导出至EXCEL)
            /// </summary>
            public DataTable Exportdt { set { _exportdt = value; } }
        #endregion

        #region Get
            /// <summary>
            ///返回DataTable至主窗体
            /// </summary>
            public DataTable ResultTable => _resultTable;

            /// <summary>
            /// 返回结果标记
            /// </summary>
            public bool ResultMark => _resultMark;
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        public void ImportExcelToDt()
        {
            //若_resultTable有值,即先将其清空,再进行赋值
            if (_resultTable?.Rows.Count > 0)
            {
                _resultTable.Rows.Clear();
                _resultTable.Columns.Clear();
            }
            _resultTable = importDt.ImportExcelToDt(_fileAddress).Copy(); 
        }

        /// <summary>
        /// 生成
        /// </summary>
        public void GenerateDt()
        {
            //若_resultTable有值,即先将其清空,再进行赋值
            if (_resultTable?.Rows.Count > 0)
            {
                _resultTable.Rows.Clear();
                _resultTable.Columns.Clear();
            }
            _resultTable = generate.GenerateExcelToDt(_sourcedt);
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void ExportDtToExcel()
        {
            _resultMark = exportDt.ExportDtToExcel(_fileAddress, _exportdt);
        }

    }
}
