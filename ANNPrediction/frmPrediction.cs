using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANNPrediction.Entities;
using ANNPrediction.Utils;
using BaseEntity.Utils;
using Microsoft.Office.Interop.Excel;
using ZedGraph;

namespace WindowsFormsApplication1
{
    public partial class frmPrediction : Form
    {
        private PredictIndicators _predictor;

        public frmPrediction()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _nudHiddenUnits_ValueChanged(sender, e);
            GraphInit(DoThi_GiaiTri);
        }

        #region doc xls/
        private void btnDocDL_Click(object sender, EventArgs e)
        {
            object[,] mangTraning = new object[200, 8];
            int i = 0;
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;


            xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();

            xlWorkBook = xlApp.Workbooks.Open(@"F:\Cao hoc\Luan van\ProjectANN\long mdc\LongMDC\ANNPrediction\bin\x86\Debug\TrainingInput.xls");
            try
            {

                Worksheet sheet = (Worksheet)xlWorkBook.Worksheets[1];

                Range excelRange = sheet.UsedRange;
                foreach (Microsoft.Office.Interop.Excel.Range coloun in excelRange.Columns)
                {
                    var columindex = 1;

                    var arr = (System.Array)coloun.Value2;
                    if (arr.GetValue(1, columindex) == null) break;
                    mangTraning[i, 0] = (arr.GetValue(1, columindex).ToString());
                    mangTraning[i, 1] = (arr.GetValue(2, columindex).ToString());
                    mangTraning[i, 2] = (arr.GetValue(3, columindex).ToString());
                    mangTraning[i, 3] = (arr.GetValue(4, columindex).ToString());
                    mangTraning[i, 4] = (arr.GetValue(5, columindex).ToString());
                    mangTraning[i, 5] = (arr.GetValue(6, columindex).ToString());
                    i++;
                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                xlApp.Quit();
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
            }
            ////////

            Microsoft.Office.Interop.Excel.Application xlApp2;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook2;


            xlApp2 = new Microsoft.Office.Interop.Excel.ApplicationClass();
            xlWorkBook2 = xlApp2.Workbooks.Open(@"F:\Cao hoc\Luan van\ProjectANN\long mdc\LongMDC\ANNPrediction\bin\x86\Debug\Target.xls");
            try
            {

                Worksheet sheet = (Worksheet)xlWorkBook2.Worksheets[1];
                int k = 0;
                Range excelRange = sheet.UsedRange;
                foreach (Microsoft.Office.Interop.Excel.Range coloun in excelRange.Columns)
                {
                    var columindex = 1;

                    var arr = (System.Array)coloun.Value2;
                    if (arr.GetValue(1, columindex) == null) break;
                    mangTraning[k, 6] = (arr.GetValue(1, columindex).ToString());

                    k++;
                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                xlApp2.Quit();
                ReleaseObject(xlWorkBook2);
                ReleaseObject(xlApp2);
            }

            //save file csv
            var csvw = new CSVWriter(DirectionIO.GetPath() + "/DataTranning.csv");
            csvw.Write(mangTraning);

        }
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                // MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        
        #endregion

        #region Double client text box
        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { FileName = "", Filter = @"(*.csv)|*.csv" };
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDataTrainning.Text = Path.GetFullPath(ofd.FileName);
            }
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { FileName = "", Filter = @"(*.csv)|*.csv" };
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDataTest.Text = Path.GetFullPath(ofd.FileName);
            }
        } 
        #endregion
        private int GetIntValue(decimal value)
        {
            try
            {
                return (int) value;
            }
            catch (Exception){}
            return 0;
        }
        #region Action Trainning

        /// <summary>
        /// Training callback, invoked at each iteration
        /// </summary>
        /// <param name="epoch">Epoch number</param>
        /// <param name="error">Current error</param>
        private void TrainingCallback(int epoch, double error )
        {
            Invoke(addAction, new object[] { epoch, error, _dgvTrainingResults });

        }


        private void LoadDataFile(string urlFile,string urlTestFile)
        {
            int inputCount = 0;
            int outputCount = 0;
            int hiddenLayers = GetIntValue(_nudHiddenUnits.Value);
            List<int> neuralHidden= new List<int>();
            double maxError=0;
            int maxepoch = 0;


            for (int i = 0; i < hiddenLayers; i++)
            {
                if (i ==0)
                    neuralHidden.Add(GetIntValue(nudHiddenLayers1.Value));
                if (i == 1)
                    neuralHidden.Add(GetIntValue(nudHiddenLayers2.Value));
                if (i == 2)
                    neuralHidden.Add(GetIntValue(nudHiddenLayers3.Value));
                if (i == 3)
                    neuralHidden.Add(GetIntValue(nudHiddenLayers4.Value));
                if (i == 4)
                    neuralHidden.Add(GetIntValue(nudHiddenLayers5.Value));
                if (i == 5)
                    neuralHidden.Add(GetIntValue(nudHiddenLayers6.Value));
                if (i == 6)
                    neuralHidden.Add(GetIntValue(nudHiddenLayers7.Value));
                if (i == 7)
                    neuralHidden.Add(GetIntValue(nudHiddenLayers8.Value));
            }
           
            try
            {
                maxError = Convert.ToDouble(txtMaxError.Text);
                maxepoch = Convert.ToInt32(txtMaxRepeat.Text);

                inputCount = Convert.ToInt32(txtInputCount.Text);
                outputCount = Convert.ToInt32(TxtOutputCount.Text);
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_predictor != null)
            {
                _predictor.ReloadData(urlFile);
            }
            else
            {
                _predictor = new PredictIndicators(urlFile,urlTestFile, hiddenLayers, neuralHidden, maxError, maxepoch);
            }
             
        }
        private void _btnStartTraining_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Enabled = false;
                txtInputCount.Enabled = false;
                txtDataTrainning.Enabled = false;
                txtDataTest.Enabled = false;

                LoadDataFile(txtDataTrainning.Text, txtDataTest.Text);
                //cap nha lai so dau vao
                txtInputCount.Text = _predictor.InputCount.ToString();

                TrainingStatus callback = TrainingCallback;
                _predictor.TrainNetworkAsync(callback);
            }
            catch (Exception)
            {
                
            }
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            txtInputCount.Enabled = true;
            txtDataTrainning.Enabled = true;
            txtDataTest.Enabled = true;
            _predictor.AbortTraining();
        }

        private void _btnExport_Click(object sender, EventArgs e)
        {

        } 
        #endregion

        private void _nudHiddenUnits_ValueChanged(object sender, EventArgs e)
        {
            int hiddenLayers = GetIntValue(_nudHiddenUnits.Value);
            {
                nudHiddenLayers1.Visible = false;
                label6.Visible = false;
                nudHiddenLayers2.Visible = false;
                label7.Visible = false;
                nudHiddenLayers3.Visible = false;
                label8.Visible = false;
                nudHiddenLayers4.Visible = false;
                label9.Visible = false;
                nudHiddenLayers5.Visible = false;
                label10.Visible = false;
                nudHiddenLayers6.Visible = false;
                label11.Visible = false;
                nudHiddenLayers7.Visible = false;
                label12.Visible = false;
                nudHiddenLayers8.Visible = false;
                label13.Visible = false;
            }
            for (int i = 0; i < hiddenLayers; i++)
            {
                if (i == 0)
                {
                    nudHiddenLayers1.Visible = true;
                    label6.Visible = true;
                }
                if (i == 1)
                {
                    nudHiddenLayers2.Visible = true;
                    label7.Visible = true;
                }
                if (i == 2)
                {
                    nudHiddenLayers3.Visible = true;
                    label8.Visible = true;
                }
                if (i == 3)
                {
                    nudHiddenLayers4.Visible = true;
                    label9.Visible = true;
                }
                if (i == 4)
                {
                    nudHiddenLayers5.Visible = true;
                    label10.Visible = true;
                }
                if (i == 5)
                {
                    nudHiddenLayers6.Visible = true;
                    label11.Visible = true;
                }
                if (i == 6)
                {
                    nudHiddenLayers7.Visible = true;
                    label12.Visible = true;
                }
                if (i == 7)
                {
                    nudHiddenLayers8.Visible = true;
                    label13.Visible = true;
                }
            }
           
        }

        private void _btnPredict_Click(object sender, EventArgs e)
        {
            try
            {
                _dgvPredictionResults.Rows.Clear();
                List<PredictionResults> results = new List<PredictionResults>();
                try
                {

                    results = _predictor.Predict();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var item in results)
                {
                    _dgvPredictionResults.Rows.Add(item.ActualValue,
                                                   item.PredictedValue.ToString("F6", CultureInfo.InvariantCulture),
                                                   item.Error.ToString("F6", CultureInfo.InvariantCulture));
                }

                DrawGraph(DoThi_GiaiTri, results);
            }
            catch (Exception)
            {

            }
        }

        private void GraphInit(ZedGraphControl DoThi)
        {
            GraphPane myPane1 = DoThi.GraphPane; // Khai báo sửa dụng Graph loại GraphPane;

            myPane1.Title.Text = "Đồ thị dự đoán";
            myPane1.XAxis.Title.Text = "Ngày dự đoán";
            myPane1.YAxis.Title.Text = "Giá trị dự đoán";
            // Định nghĩa list để vẽ đồ thị. Để các bạn hiểu rõ cơ chế làm việc ở đây khai báo 2 list điểm <=> 2 đường đồ thị
            RollingPointPairList list6_1 = new RollingPointPairList(1000);
            RollingPointPairList list6_2 = new RollingPointPairList(1000);
            // dòng dưới là định nghĩa curve để vẽ.
            myPane1.AddCurve("Giá trị thực đo", list6_1, Color.Red, SymbolType.Diamond);
            myPane1.AddCurve("Giá trị tính toán bởi mạng", list6_2, Color.Blue, SymbolType.Star);

            // Định hiện thị cho trục thời gian (Trục X)
            //myPane1.XAxis.Scale.Min = 0;
            //myPane1.XAxis.Scale.Max = 10;
            //myPane1.XAxis.Scale.MinorStep = 1;
            //myPane1.XAxis.Scale.MajorStep = 1;
            myPane1.XAxis.Type = AxisType.Log;
            //myPane1.XAxis.Scale.Min = new XDate(_predictFrom);  // We want to use time from now
            //myPane1.XAxis.Scale.Max = new XDate(_predictTo);  // to 5 minutes per default
            //myPane1.XAxis.Scale.MinorUnit = DateUnit.Day;         // set the minimum x unit to time/seconds
            //myPane1.XAxis.Scale.MajorUnit = DateUnit.Day;         // set the maximum x unit to time/minutes
            //myPane1.XAxis.Scale.Format = "MM/dd/yyyy";
            // Gọi hàm xác định cỡ trục
            myPane1.AxisChange();

        }

        private void DrawGraph(ZedGraphControl DoThi, List<PredictionResults> results)
        {
            //ve gia tri
            LineItem curve2_1 = DoThi.GraphPane.CurveList[0] as LineItem;
            LineItem curve2_2 = DoThi.GraphPane.CurveList[1] as LineItem;

            //init do thi.

            // Get the PointPairList
            IPointListEdit list21 = curve2_1.Points as IPointListEdit;
            IPointListEdit list22 = curve2_2.Points as IPointListEdit;
            list21.Clear();
            list22.Clear();
            DoThi.AxisChange();
            DoThi.Invalidate();
            int i = 0;
            foreach (var item in results)
            {
                list21.Add(i, item.ActualValue);
                list22.Add(i, item.PredictedValue);
                // đoạn chương trình thực hiện vẽ đồ thị
                Scale xScale = DoThi.GraphPane.XAxis.Scale;
                i++;
            }
            // Vẽ đồ thị
            DoThi.AxisChange();
            // Force a redraw
            DoThi.Invalidate();
        }

        private void _btnSaveResults_Click(object sender, EventArgs e)
        {
            try
            {
                var dgvResults = _dgvPredictionResults;
                SaveFileDialog ofd = new SaveFileDialog { Filter = @"(*.csv)|*.csv", FileName = "results.csv" };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    CSVWriter writer = null;
                    try
                    {
                        writer = new CSVWriter(ofd.FileName);
                    }
                    catch (System.Security.SecurityException)
                    {
                        MessageBox.Show("SecurityExceptionFolderLevel", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    object[,] values = new object[dgvResults.Rows.Count + 2, dgvResults.Columns.Count];
                    int rowIndex = 0;
                    int colIndex = 0;
                    foreach (DataGridViewColumn col in dgvResults.Columns) /*Writing Column Headers*/
                    {
                        values[rowIndex, colIndex] = col.HeaderText;
                        colIndex++;
                    }
                    rowIndex++; /*1*/

                    foreach (DataGridViewRow row in dgvResults.Rows) /*Writing the values*/
                    {
                        colIndex = 0;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            values[rowIndex, colIndex] = cell.Value;
                            colIndex++;
                        }
                        rowIndex++;
                    }

                    /*Writing the results in the last row*/
                    writer.Write(values);
                }
            }
            catch (Exception)
            {
               
            }
        }
    }
}
