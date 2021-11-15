using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using ExchangeData.Task;

namespace ExchangeData
{
    public partial class Main : Form
    {
        Load load=new Load();
        TaskLogic taskLogic=new TaskLogic();

        public Main()
        {
            InitializeComponent();
            OnRegisterEvents();
        }

        private void OnRegisterEvents()
        {
            tmclose.Click += Tmclose_Click;
            btn_import.Click += Btn_import_Click;
        }

        /// <summary>
        /// 导入(注:当有导出结果时执行导出)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_import_Click(object sender,EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog { Filter = $"Xlsx文件|*.xlsx" };
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                taskLogic.FileAddress = openFileDialog.FileName;

                //子线程调用
                new Thread(Import).Start();
                load.StartPosition = FormStartPosition.CenterScreen;
                load.ShowDialog();

                var sourcedt = taskLogic.ResultTable.Copy();

                if(sourcedt.Rows.Count==0) throw new Exception("导入异常,请联系管理员");
                else
                {
                    MessageBox.Show($"导入成功!请按确定键继续进行运算", $"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    taskLogic.Sourcedt = sourcedt.Copy();

                    //子线程调用
                    new Thread(Generate).Start();
                    load.StartPosition = FormStartPosition.CenterScreen;
                    load.ShowDialog();

                    var exportdt = taskLogic.ResultTable.Copy();

                    if(exportdt.Rows.Count==0) throw new Exception("运算异常,请联系管理员");
                    else
                    {
                        //获取输出地址
                        var saveFileDialog = new SaveFileDialog { Filter = $"Xlsx文件|*.xlsx" };
                        if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                        taskLogic.FileAddress = saveFileDialog.FileName;
                        taskLogic.Exportdt = exportdt.Copy();

                        //子线程调用
                        new Thread(Export).Start();
                        load.StartPosition = FormStartPosition.CenterScreen;
                        load.ShowDialog();

                        if (!taskLogic.ResultMark) throw new Exception("导出异常,请联系管理员");
                        else
                        {
                            MessageBox.Show($"导出成功!可从EXCEL中查阅导出效果", $"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 导入-子线程
        /// </summary>
        private void Import()
        {
            taskLogic.ImportExcelToDt();

            //当完成后将Load子窗体关闭
            this.Invoke((ThreadStart)(() =>
            {
                load.Close();
            }));
        }

        /// <summary>
        /// 运算-子线程
        /// </summary>
        private void Generate()
        {
            taskLogic.GenerateDt();

            //当完成后将Load子窗体关闭
            this.Invoke((ThreadStart)(() =>
            {
                load.Close();
            }));
        }

        /// <summary>
        /// 导出
        /// </summary>
        private void Export()
        {
            taskLogic.ExportDtToExcel();

            //当完成后将Load子窗体关闭
            this.Invoke((ThreadStart)(() =>
            {
                load.Close();
            }));
        }

    }
}
