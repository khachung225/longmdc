using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANNPrediction.Entities;
using ANNPrediction.Properties;
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
            GraphTQInit(zedGraphControl1);
            GraphInitLog(zedGraphControl2);
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

                maxError = double.Parse(txtMaxError.Text, CultureInfo.InvariantCulture);
                if (maxError >= 1)
                {
                   var re= MessageBox.Show("Lỗi đạt tới:" + maxError.ToString(CultureInfo.InvariantCulture) + "\r\n Bạn muốn mạng thực hiện học với lỗi tối đa này?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(re == DialogResult.No)
                        return;
                }
                maxepoch = Int32.Parse(txtMaxRepeat.Text, CultureInfo.InvariantCulture);

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
                button2.Enabled = false;
                button1.Enabled = false;
                LoadDataFile(txtDataTrainning.Text, txtDataTest.Text);
                //cap nha lai so dau vao
                txtInputCount.Text = _predictor.InputCount.ToString(CultureInfo.InvariantCulture);

                TrainingStatus callback = TrainingCallback;
                _predictor.TrainNetworkAsync(callback);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {
            _predictor.AbortTraining();

        }

        //export mang
        private void _btnExport_Click(object sender, EventArgs e)
        {
            
        }
        //inport mang
        private void button3_Click(object sender, EventArgs e)
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
                int k = 1;
                foreach (var item in results)
                {
                    _dgvPredictionResults.Rows.Add(k,item.ActualValue,
                                                   item.PredictedValue.ToString("F6", CultureInfo.InvariantCulture),
                                                   item.Error.ToString("F6", CultureInfo.InvariantCulture));
                    k++;
                }
                //ve bieu do
                DrawGraph(DoThi_GiaiTri, results);
                //ve bieu do tuong quan.
                DrawGraphTQ(zedGraphControl1, results);
                //list Error.
                DrawGraphLog(zedGraphControl2, _predictor.ListError);

                //tinh he so tuong quan.
                var corre = new Correlation(); corre.Clean();
                corre.Add(results);
                var r = corre.GetCorrelation();
                label17.Text = string.Format("Hệ số tương quan:{0}", r.ToString("F5", CultureInfo.InvariantCulture));

                //tong hop dl
                var st = new StaticReporting();
                st.Add(results);
                textBox2.Text = string.Format("{0}", st.Min.ToString("F3", CultureInfo.InvariantCulture));
                textBox3.Text = string.Format("{0}", st.Max.ToString("F3", CultureInfo.InvariantCulture));
                textBox4.Text = string.Format("{0}", st.GetMVD().ToString("F3", CultureInfo.InvariantCulture));
                textBox5.Text = string.Format("{0}", st.GetSDD().ToString("F3", CultureInfo.InvariantCulture));
                textBox6.Text = string.Format("{0}", st.GetMDD().ToString("F3", CultureInfo.InvariantCulture));

                textBox9.Text = string.Format("{0}", _predictor.CalculateMSE(results).ToString("F3", CultureInfo.InvariantCulture));
                textBox10.Text = string.Format("{0}", _predictor.CalculateRMS(results).ToString("F3", CultureInfo.InvariantCulture));
                textBox11.Text = string.Format("{0}", _predictor.CalculateMAE(results).ToString("F3", CultureInfo.InvariantCulture));


               // textBox1.Text = _predictor.CalculateRMS(results).ToString("F6", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {

            }
        }

        private void GraphInit(ZedGraphControl DoThi)
        {
            GraphPane myPane1 = DoThi.GraphPane; // Khai báo sửa dụng Graph loại GraphPane;

            myPane1.Title.Text = "Đồ thị dự báo lún";
            myPane1.XAxis.Title.Text = "Khoảng cách";
            myPane1.YAxis.Title.Text = "Độ lún";
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

        private void GraphInitLog(ZedGraphControl DoThi)
        {
            GraphPane myPane1 = DoThi.GraphPane; // Khai báo sửa dụng Graph loại GraphPane;

            var cout = Convert.ToInt32(txtMaxRepeat.Text);
            if (cout < 1000) cout = 1000;
            myPane1.Title.Text = "Đồ thị lỗi trong quá trình học";
            myPane1.XAxis.Title.Text = "Số lần học";
            myPane1.YAxis.Title.Text = "Lỗi đạt được";
            // Định nghĩa list để vẽ đồ thị. Để các bạn hiểu rõ cơ chế làm việc ở đây khai báo 2 list điểm <=> 2 đường đồ thị
            RollingPointPairList list6_1 = new RollingPointPairList(cout);
           
            // dòng dưới là định nghĩa curve để vẽ.
            myPane1.AddCurve("Giá trị lỗi", list6_1, Color.Red, SymbolType.None);
 

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

        private void GraphTQInit(ZedGraphControl DoThi)
        {
            GraphPane myPane1 = DoThi.GraphPane; // Khai báo sửa dụng Graph loại GraphPane;

            myPane1.Title.Text = "Đồ thị tương quan";
            myPane1.XAxis.Title.Text = "Giá trị thực";
            myPane1.YAxis.Title.Text = "Giá trị dự đoán";
            // Định nghĩa list để vẽ đồ thị. Để các bạn hiểu rõ cơ chế làm việc ở đây khai báo 2 list điểm <=> 2 đường đồ thị
            //PointPairList list6_1 = new PointPairList();
            RollingPointPairList list6_2 = new RollingPointPairList(1000);

             
            // dòng dưới là định nghĩa curve để vẽ.
            var myCurve = myPane1.AddCurve("Tương quan", list6_2, Color.Blue, SymbolType.Circle);
           myCurve.Symbol.Size = 10;
           // Set up a red-blue color gradient to be used for the fill 
           myCurve.Symbol.Fill = new Fill(Color.Blue, Color.Blue);
           // Turn off the symbol borders 
           myCurve.Symbol.Border.IsVisible = false;
           // Instruct ZedGraph to fill the symbols by selecting a color out of the 
           // red-blue gradient based on the Z value.  A value of 19 or less will be red, 
           // a value of 34 or more will be blue, and values in between will be a 
           // linearly apportioned color between red and blue. 
           // myCurve.Symbol.Fill.Type = FillType.GradientByZ;
           //myCurve.Symbol.Fill.RangeMin = 1;
           //myCurve.Symbol.Fill.RangeMax = 1;
           // Turn off the line, so the curve will by symbols only 
           myCurve.Line.IsVisible = false; 
            //myPane1.AddCurve("Đường tương quan", list6_2, Color.Chocolate, SymbolType.Square);
           // myPane1.AddStick("Đường tương quan", list6_1, Color.Blue);

            // Định hiện thị cho trục thời gian (Trục X)
           //myPane1.XAxis.Scale.Min = 0;
           //myPane1.XAxis.Scale.Max = 10000;
           //myPane1.XAxis.Scale.MinorStep = 1000;
           //myPane1.XAxis.Scale.MajorStep = 1000;

          

           // Fill the background of the chart rect and pane
           myPane1.Chart.Fill = new Fill(Color.White, Color.White, 45.0f);
           myPane1.Fill = new Fill(Color.White, Color.White, 45.0f);

            //myPane1.XAxis.Type = AxisType.Log;
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
                list21.Add(i, item.ActualValue *(-1));
                list22.Add(i, item.PredictedValue * (-1));
                // đoạn chương trình thực hiện vẽ đồ thị
                Scale xScale = DoThi.GraphPane.XAxis.Scale;
                i++;
            }
            // Vẽ đồ thị
            DoThi.AxisChange();
            // Force a redraw
            DoThi.Invalidate();
        }

        private void DrawGraphLog(ZedGraphControl DoThi, List<MyError> results)
        {
            //ve gia tri
            LineItem curve2_1 = DoThi.GraphPane.CurveList[0] as LineItem;
         

            //init do thi.

            // Get the PointPairList
            IPointListEdit list21 = curve2_1.Points as IPointListEdit;
             
            list21.Clear();
             
            DoThi.AxisChange();
            DoThi.Invalidate();
            
            foreach (var item in results)
            {
                list21.Add(item.index, item.value);
                
                // đoạn chương trình thực hiện vẽ đồ thị
                Scale xScale = DoThi.GraphPane.XAxis.Scale;
               
            }
            // Vẽ đồ thị
            DoThi.AxisChange();
            // Force a redraw
            DoThi.Invalidate();
        }

        private void DrawGraphTQ(ZedGraphControl DoThi, List<PredictionResults> results)
        {
            //ve gia tri
            LineItem curve2_1 = DoThi.GraphPane.CurveList[0] as LineItem;
            //LineItem curve2_2 = DoThi.GraphPane.CurveList[1] as LineItem;

            //init do thi.

            // Get the PointPairList
            IPointListEdit list21 = curve2_1.Points as IPointListEdit;
           // IPointListEdit list22 = curve2_2.Points as IPointListEdit;
            list21.Clear();
           // list22.Clear();
            int i = 0;
            
            foreach (var item in results)
            {
                list21.Add(item.ActualValue, item.PredictedValue);
                // đoạn chương trình thực hiện vẽ đồ thị
                Scale xScale = DoThi.GraphPane.XAxis.Scale;
                i++;
            }
           

             DoThi.Invalidate();
            // Vẽ đồ thị
            DoThi.AxisChange();
            // Force a redraw
           // DoThi.Invalidate();
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

        //học lại.
        private void button4_Click(object sender, EventArgs e)
        {
            //if (_predictor!=null && _predictor.IsTrainning()) return;
            groupBox1.Enabled = true;
            txtInputCount.Enabled = true;
            txtDataTrainning.Enabled = true;
            txtDataTest.Enabled = true;
            button2.Enabled = true;
            button1.Enabled = true;

            //clean dl mạng
            if (_predictor != null)
            {
                _predictor.Dispose();
                _predictor = null;
            }

            _dgvTrainingResults.Rows.Clear();
            _dgvPredictionResults.Rows.Clear();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        
        
    }
}
