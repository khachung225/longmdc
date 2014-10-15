using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using ANNPrediction.Entities;
using ANNPrediction.Utils;
using BaseEntity.Utils;
using Encog.Util;
using Microsoft.Office.Interop.Excel;
using ZedGraph;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace WindowsFormsApplication1
{
    public partial class frmPrediction : Form
    {
        private List<MPoint> _listPoint = new List<MPoint>
            {
                new MPoint(0, 17.842598),
                new MPoint(0.29, 6.944764),
                new MPoint(0, 0.000146),
                new MPoint(8153.87, 8264.424915),
                new MPoint(6407.44, 6496.23054),
            };

        private PredictIndicators _predictor;

        private Queue localBankQueue = new Queue();

        private List<ReportLog> myDataTable = new List<ReportLog>();

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

            lblloidattoi.Text = "";
            lblsolanlap.Text = "";

           //LoadDefault();
        }

        private void LoadDefault()
        {
            button4.Enabled = false;
            _btnExport.Enabled = false;
            _btnStartTraining.Enabled = false;
            _btnStop.Enabled = false;
            _btnPredict.Enabled = false;
        }

        private int GetIntValue(decimal value)
        {
            try
            {
                return (int) value;
            }
            catch (Exception)
            {
            }
            return 0;
        }

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
            if (_predictor == null)
            {
                MessageBox.Show("Mạng chưa được khởi tạo! \n\r Hãy bắt đầu quá trình học hoặc nhấn nút tải mạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _dgvPredictionResults.Rows.Clear();

                _predictor.LoadDataTest(txtDataTest.Text);


                var results = new List<PredictionResults>();
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
                foreach (PredictionResults item in results)
                {
                    _dgvPredictionResults.Rows.Add(k, item.ActualValue,
                                                   item.PredictedValue.ToString("F3", CultureInfo.InvariantCulture),
                                                   item.Error.ToString("F3", CultureInfo.InvariantCulture));
                    k++;
                }
                //ve bieu do
                DrawGraph(DoThi_GiaiTri, results);
                //ve bieu do tuong quan.
                DrawGraphTQ(zedGraphControl1, results);
               

                //tong hop dl
                var st = new StaticReporting();
                st.Add(results);
                textBox2.Text = string.Format("{0}", st.Min.ToString("F3", CultureInfo.InvariantCulture));
                textBox3.Text = string.Format("{0}", st.Max.ToString("F3", CultureInfo.InvariantCulture));
                textBox4.Text = string.Format("{0}", st.GetMVD().ToString("F3", CultureInfo.InvariantCulture));
                textBox5.Text = string.Format("{0}", st.GetSDD().ToString("F3", CultureInfo.InvariantCulture));
                textBox6.Text = string.Format("{0}", st.GetMDD().ToString("F3", CultureInfo.InvariantCulture));

                textBox9.Text = string.Format("{0}",
                                              _predictor.CalculateMSE(results)
                                                        .ToString("F3", CultureInfo.InvariantCulture));
                textBox10.Text = string.Format("{0}",
                                               _predictor.CalculateRMS(results)
                                                         .ToString("F3", CultureInfo.InvariantCulture));
                textBox11.Text = string.Format("{0}",
                                               _predictor.CalculateMAE(results)
                                                         .ToString("F3", CultureInfo.InvariantCulture));


                // textBox1.Text = _predictor.CalculateRMS(results).ToString("F6", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GraphInit(ZedGraphControl DoThi)
        {
            GraphPane myPane1 = DoThi.GraphPane; // Khai báo sửa dụng Graph loại GraphPane;

            myPane1.Title.Text = "Đồ thị dự báo lún";
            myPane1.XAxis.Title.Text = "Khoảng cách";
            myPane1.YAxis.Title.Text = "Độ lún";
            // Định nghĩa list để vẽ đồ thị. Để các bạn hiểu rõ cơ chế làm việc ở đây khai báo 2 list điểm <=> 2 đường đồ thị
            var list6_1 = new RollingPointPairList(1000);
            var list6_2 = new RollingPointPairList(1000);
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

            int cout = Convert.ToInt32(txtMaxRepeat.Text);
            if (cout < 1000) cout = 1000;
            myPane1.Title.Text = "Đồ thị lỗi trong quá trình học";
            myPane1.XAxis.Title.Text = "Số lần học";
            myPane1.YAxis.Title.Text = "Lỗi đạt được";
            // Định nghĩa list để vẽ đồ thị. Để các bạn hiểu rõ cơ chế làm việc ở đây khai báo 2 list điểm <=> 2 đường đồ thị
            var list6_1 = new RollingPointPairList(cout);

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

            myPane1.Title.Text = "BIỂU ĐỒ TƯƠNG QUAN";
            myPane1.XAxis.Title.Text = "Giá trị thực";
            myPane1.YAxis.Title.Text = "Giá trị dự báo";
            // Định nghĩa list để vẽ đồ thị. Để các bạn hiểu rõ cơ chế làm việc ở đây khai báo 2 list điểm <=> 2 đường đồ thị
            //PointPairList list6_1 = new PointPairList();
            var list6_2 = new RollingPointPairList(1000);


            // dòng dưới là định nghĩa curve để vẽ.
            LineItem myCurve = myPane1.AddCurve("Tương quan", list6_2, Color.Blue, SymbolType.Circle);
            myCurve.Symbol.Size = 12;
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
            myPane1.XAxis.Scale.Min = 0;
            myPane1.YAxis.Scale.Min = 0;

            
            //myPane1.XAxis.Scale.Max = 10000;
            //myPane1.XAxis.Scale.MinorStep = 1;
            //myPane1.XAxis.Scale.MajorStep = 1;
            //myPane1.YAxis.Scale.MinorStep = 1;
            //myPane1.YAxis.Scale.MajorStep = 1;
            

            // Fill the background of the chart rect and pane
            myPane1.Chart.Fill = new Fill(Color.White, Color.White, 45.0f);
            myPane1.Fill = new Fill(Color.White, Color.White, 45.0f);

            myPane1.XAxis.Type = AxisType.Exponent;
            myPane1.YAxis.Type = AxisType.Exponent;
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
            if (results == null) return;

            //ve gia tri
            var curve2_1 = DoThi.GraphPane.CurveList[0] as LineItem;
            var curve2_2 = DoThi.GraphPane.CurveList[1] as LineItem;

            //init do thi.

            // Get the PointPairList
            var list21 = curve2_1.Points as IPointListEdit;
            var list22 = curve2_2.Points as IPointListEdit;
            list21.Clear();
            list22.Clear();
            DoThi.AxisChange();
            DoThi.Invalidate();
            int i = 0;
            foreach (PredictionResults item in results)
            {
                list21.Add(i, item.ActualValue*(-1));
                list22.Add(i, item.PredictedValue*(-1));
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
            if (results == null) return;
            //ve gia tri
            var curve2_1 = DoThi.GraphPane.CurveList[0] as LineItem;


            //init do thi.

            // Get the PointPairList
            var list21 = curve2_1.Points as IPointListEdit;

            list21.Clear();

            DoThi.AxisChange();
            DoThi.Invalidate();

            foreach (MyError item in results)
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
            if (results == null) return;
            DoThi.MasterPane.Border.Width = 0;
            DoThi.MasterPane.Border.IsVisible = false;

            //ve gia tri
            var curve2_1 = DoThi.GraphPane.CurveList[0] as LineItem;
            //LineItem curve2_2 = DoThi.GraphPane.CurveList[1] as LineItem;

            int minx = Math.Min(DoThi.Width, DoThi.Height);
            DoThi.Width = DoThi.Height = minx;
            //DoThi.Width += 50;

            //init do thi.
            //tinh he so tuong quan.
            var corre = new Correlation();
            corre.Clean();
            corre.Add(results);
            double r = corre.GetCorrelation();
            //DoThi.GraphPane.Title.Text = string.Format("Đồ thị tương quan (r ={0})", r.ToString("F5", CultureInfo.InvariantCulture));
            DoThi.GraphPane.CurveList[0].Label.Text = string.Format("Tương quan r = {0}",
                                                                    r.ToString("F5", CultureInfo.InvariantCulture));

            // Get the PointPairList
            var list21 = curve2_1.Points as IPointListEdit;
            // IPointListEdit list22 = curve2_2.Points as IPointListEdit;
            list21.Clear();
            // list22.Clear();
            int i = 0;
            double imax = 0;
            foreach (PredictionResults item in results)
            {
                list21.Add(item.ActualValue, item.PredictedValue);
                var m = Math.Max(item.ActualValue, item.PredictedValue);
                if (imax < m)
                    imax = m;
                // đoạn chương trình thực hiện vẽ đồ thị
                Scale xScale = DoThi.GraphPane.XAxis.Scale;
                i++;
            }
           // imax = Math.Round(imax, 1, MidpointRounding.AwayFromZero);
            var a1 = Math.Max(DoThi.GraphPane.XAxis.Scale.Max, DoThi.GraphPane.YAxis.Scale.Max);
            DoThi.GraphPane.XAxis.Scale.Max = DoThi.GraphPane.YAxis.Scale.Max = imax+0.5;
            double myrate;
            imax = GetRoundMax(imax, out myrate);

            DoThi.GraphPane.XAxis.Scale.Max = DoThi.GraphPane.YAxis.Scale.Max = imax;

            DoThi.GraphPane.XAxis.Scale.MinorStep = myrate;
            DoThi.GraphPane.XAxis.Scale.MajorStep = myrate;
            DoThi.GraphPane.YAxis.Scale.MinorStep = myrate;
            DoThi.GraphPane.YAxis.Scale.MajorStep = myrate;

            //draw.
            var a = Math.Min(DoThi.GraphPane.Rect.Width, DoThi.GraphPane.Rect.Height);
            DoThi.GraphPane.Rect = new RectangleF(DoThi.GraphPane.Rect.X, DoThi.GraphPane.Rect.Y, a , a);
            

            DoThi.Invalidate();
            // Vẽ đồ thị
            DoThi.AxisChange();
            // Force a redraw
            // DoThi.Invalidate();



        }

        private double RoutTo(double imax)
        {
            if (imax > 1)
            {
                var value = Math.Round(imax, 0, MidpointRounding.ToEven);
                var lent = value.ToString(CultureInfo.InvariantCulture).Length;

                for (int i = 0; i < lent - 1; i++)
                {
                    value = value*0.1;
                }

                var newvalue = Math.Round(value, 0, MidpointRounding.ToEven);
                for (int i = 0; i < lent - 1; i++)
                {
                    newvalue = newvalue * 10;
                }
                return newvalue;
            }
           
            return imax;
        }
        private double GetRoundMax(double imax,out double myrate)
        {
            myrate = 0.1;
            if (imax >= 1)
            {
                
                myrate = Math.Round(imax, 0, MidpointRounding.ToEven) * 0.1;

                myrate = Math.Round(imax + myrate, 0, MidpointRounding.AwayFromZero) * 0.1;
                myrate = RoutTo(myrate);
                //round lan 2
                return myrate * 10;
            }
            else
            {
                var dental = imax;
                double anpha = 0.3;
                myrate = 0.1;
                while (dental < 1)
                {
                    dental = dental*10;
                    anpha = anpha*0.1;
                    myrate = myrate*0.1;
                }
               
                var plusplus = Math.Round(dental, 0, MidpointRounding.ToEven) * 0.1;

                var ia = (dental + plusplus);
                myrate = Math.Round(ia, 0, MidpointRounding.ToEven) * myrate;

                return myrate*10 ;
            }
        }

        private void CleanGrapth(ZedGraphControl DoThi)
        {
            //ve gia tri
            var curve2_1 = DoThi.GraphPane.CurveList[0] as LineItem;
            if (DoThi.GraphPane.CurveList.Count > 1)
            {
                LineItem curve2_2 = DoThi.GraphPane.CurveList[1] as LineItem;
                var list22 = curve2_2.Points as IPointListEdit;

                list22.Clear();
            }

       
            // Get the PointPairList
            var list21 = curve2_1.Points as IPointListEdit;
            list21.Clear();
            DoThi.Invalidate();
            // Vẽ đồ thị
            DoThi.AxisChange();
        }
        private void _btnSaveResults_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dgvPredictionResults.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để kết xuất", "Lỗi", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                DataGridView dgvResults = _dgvPredictionResults;
                var ofd = new SaveFileDialog {Filter = @"(*.csv)|*.csv", FileName = "results.csv"};
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    CSVWriter writer = null;
                    try
                    {
                        writer = new CSVWriter(ofd.FileName);
                    }
                    catch (SecurityException)
                    {
                        MessageBox.Show("SecurityExceptionFolderLevel", "Exception", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var values = new object[dgvResults.Rows.Count + 2,dgvResults.Columns.Count];
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            CleanGrapth(DoThi_GiaiTri);
            CleanGrapth(zedGraphControl1);
            CleanGrapth(zedGraphControl2);
            lblloidattoi.Text = "";
            lblsolanlap.Text = "";

            //reset tong hop.
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
        }

        //vẽ do thi,
        private void button5_Click(object sender, EventArgs e)
        {
            // add 5 so the bars fit properly
            //int x = 240; // the position of the X axis
            //int y = 0; // the position of the Y axis

            //Bitmap bmp = new Bitmap(360, 290);
            //Graphics g = Graphics.FromImage(bmp);
            //g.DrawLine (new Pen(Color.Red, 2), 5,5, 5,250);
            //g.DrawLine (new Pen(Color.Red, 2), 5,250, 300,250);
            //// let's draw a coordinate equivalent to (20,30) (20 up, 30 across)
            //g.DrawString("X", new Font("Calibri", 12), new SolidBrush(Color.Black), y+30,x-20);

            //PictureBox display = new PictureBox();
            //display.Width = 360;
            //display.Height = 290;
            //this.Controls.Add(display);

            //display.Image = bmp;

            //int x = 240; // the position of the X axis
            //int y = 0; // the position of the Y axis
            //var mywidth = pictureBox1.Width;
            //var myheight = pictureBox1.Height;
            //Bitmap bmp = new Bitmap(pictureBox1.Width , pictureBox1.Height);
            //Graphics g = Graphics.FromImage(bmp);
            //g.DrawLine(new Pen(Color.Red, 2), 25, 25, 25, myheight - 25);
            ////g.DrawString("X", new System.Drawing.Font("Calibri", 12), new SolidBrush(Color.Black), y + 30, x - 20);

            //g.DrawLine(new Pen(Color.Red, 2), 25, myheight - 25, mywidth, myheight - 25);
            //// let's draw a coordinate equivalent to (20,30) (20 up, 30 across)
            //g.DrawString("X", new System.Drawing.Font("Calibri", 12), new SolidBrush(Color.Black), y + 30, x - 20);


            //pictureBox1.Image = bmp;
        }

        #region Action Trainning

        /// <summary>
        ///     Training callback, invoked at each iteration
        /// </summary>
        /// <param name="epoch">Epoch number</param>
        /// <param name="error">Current error</param>
        private void TrainingCallback(int epoch, double error)
        {
            //Invoke(addAction, new object[] {epoch, error, _dgvTrainingResults});
            //localBankQueue.Enqueue(new ReportLog(epoch, error));
            if (epoch == -1)
            {
                //hiển thị dl.
               
                if (_dgvTrainingResults.InvokeRequired)
                    _dgvTrainingResults.BeginInvoke(new MethodInvoker(delegate
                        {
                            int inde = 0;
                        _dgvTrainingResults.Rows.Clear();
                        foreach (var reportLog in myDataTable)
                        {
                            inde = _dgvTrainingResults.Rows.Add(reportLog.Epoch, reportLog.Error);
                        }
                         _dgvTrainingResults.FirstDisplayedScrollingRowIndex = inde;
                       // _dgvTrainingResults.DataSource = myDataTable;
                       // _dgvTrainingResults.FirstDisplayedScrollingRowIndex = myDataTable.Count;
                        //_dgvTrainingResults.Columns[0].HeaderText = "Số lần lặp";
                        //_dgvTrainingResults.Columns[1].Width = ;
                         _btnStartTraining.Enabled = true;
                         progressBar1.Visible = false;

                         _btnExport.Enabled = true;
                         button4.Enabled = true;
                         _btnSaveResults.Enabled = true;
                         _btnPredict.Enabled = true;
                         button3.Enabled = true;

                         //list Error.
                         if (_predictor != null)
                             DrawGraphLog(zedGraphControl2, _predictor.ListError);
                    }));
                else
                {
                    int inde = 0;
                    _dgvTrainingResults.Rows.Clear();
                    foreach (var reportLog in myDataTable)
                    {
                        inde = _dgvTrainingResults.Rows.Add(reportLog.Epoch, reportLog.Error);
                    }
                    _dgvTrainingResults.FirstDisplayedScrollingRowIndex = inde;
                    _btnStartTraining.Enabled = true;
                    progressBar1.Visible = false;

                    _btnExport.Enabled = true;
                    button4.Enabled = true;
                    _btnSaveResults.Enabled = true;
                    _btnPredict.Enabled = true;
                    button3.Enabled = true;

                    //list Error.
                    if (_predictor != null)
                        DrawGraphLog(zedGraphControl2, _predictor.ListError);
                }

            }
            else
            {
                myDataTable.Add(new ReportLog(epoch, error));

                if (this.InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate
                        {
                            lblloidattoi.Text = error.ToString("F12", CultureInfo.InvariantCulture);
                            lblsolanlap.Text = epoch.ToString(CultureInfo.InvariantCulture);
                            if (_maxepoch >= epoch)
                                progressBar1.Value = epoch;
                        }));

                }
                else
                {
                    lblloidattoi.Text = error.ToString("F12",CultureInfo.InvariantCulture);
                    lblsolanlap.Text = epoch.ToString(CultureInfo.InvariantCulture);
                    if (_maxepoch >= epoch)
                        progressBar1.Value = epoch;
                }
            }
        }

        private int _maxepoch = 0;
        private void LoadDataFile(string urlFile, string urlTestFile)
        {
            int inputCount = 0;
            int outputCount = 0;
            int hiddenLayers = GetIntValue(_nudHiddenUnits.Value);
            var neuralHidden = new List<int>();
            double maxError = 0;
            int maxepoch = 0;


            for (int i = 0; i < hiddenLayers; i++)
            {
                if (i == 0)
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
                    DialogResult re =
                        MessageBox.Show(
                            "Lỗi đạt tới:" + maxError.ToString(CultureInfo.InvariantCulture) +
                            "\r\n Bạn muốn mạng thực hiện học với lỗi tối đa này?", "Chú ý", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                    if (re == DialogResult.No)
                        return;
                }
                if (string.IsNullOrEmpty(txtMaxRepeat.Text))
                    maxepoch = -1;
                else
                    maxepoch = Int32.Parse(txtMaxRepeat.Text, CultureInfo.InvariantCulture);

                _maxepoch = maxepoch;
            }
            catch (Exception exx)
            {
                MessageBox.Show("Không lấy được số 'Lỗi đạt tới' hoặc 'Số lần lặp tối đa'.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_predictor != null)
            {
                _predictor.ReloadData(urlFile);
            }
            else
            {
                _predictor = new PredictIndicators(urlFile, urlTestFile, hiddenLayers, neuralHidden, maxError, maxepoch);
            }
        }

        private void _btnStartTraining_Click(object sender, EventArgs e)
        {
           try
            {

                //if (!backgroundWorker1.IsBusy)
                //    backgroundWorker1.RunWorkerAsync();
      
                LoadDataFile(txtDataTrainning.Text, txtDataTest.Text);
                //cap nha lai so dau vao
                txtInputCount.Text = _predictor.InputCount.ToString(CultureInfo.InvariantCulture);

                #region enable button.
                groupBox1.Enabled = false;
                txtInputCount.Enabled = false;
                txtDataTrainning.Enabled = false;
                button1.Enabled = false;

                progressBar1.Visible = true;
                _btnStartTraining.Enabled = false;
                _btnExport.Enabled = false;
                button4.Enabled = false;
                _btnSaveResults.Enabled = false;
                _btnPredict.Enabled = false;
                button3.Enabled = false; 
                #endregion

                #region progress
                if (_maxepoch >= 0)
                {
                    progressBar1.Value = 0;
                    progressBar1.Maximum = _maxepoch;
                    progressBar1.Minimum = 0;
                    progressBar1.Style = ProgressBarStyle.Continuous;
                }
                else
                {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                }
                #endregion

                TrainingStatus callback = TrainingCallback;
                _predictor.TrainNetworkAsync(callback);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {
            if (_predictor != null)
                _predictor.AbortTraining();
            _btnStartTraining.Enabled = true;
            progressBar1.Visible = false;

            _btnExport.Enabled = true;
            button4.Enabled = true;
            _btnSaveResults.Enabled = true;
            _btnPredict.Enabled = true;
            button3.Enabled = true;


            //list Error.
            if (_predictor !=null)
            DrawGraphLog(zedGraphControl2, _predictor.ListError);
        }

        //export mang
        private void _btnExport_Click(object sender, EventArgs e)
        {
            
            if (_predictor == null)
            {
                MessageBox.Show("Không tìm thấy thông tin mạng để thực hiện lưu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _btnExport.Enabled = false;
            try
            {
                var ofd = new SaveFileDialog {FileName = "", Filter = @"(*.Lng)|*.Lng"};
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string pathsavefile = Path.GetFullPath(ofd.FileName);
                    SerializeObject.Save(pathsavefile, _predictor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _btnExport.Enabled = true;
        }

        //inport mang
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            try
            {
                var ofd = new OpenFileDialog {FileName = "", Filter = @"(*.Lng)|*.Lng"};
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string pathsavefile = Path.GetFullPath(ofd.FileName);
                    _predictor = (PredictIndicators) SerializeObject.Load(pathsavefile);

                    //hien thị lại ket qua theo mạng
                    txtInputCount.Text = _predictor.InputCount.ToString(CultureInfo.InvariantCulture);
                    txtMaxError.Text = _predictor.MaxErrorTrainning.ToString(CultureInfo.InvariantCulture);
                    txtMaxRepeat.Text = _predictor.MaxEpochTrainning.ToString(CultureInfo.InvariantCulture);
                    _nudHiddenUnits.Value = _predictor.HiddenLayers;
                    int k = 1;
                    foreach (int i in _predictor.NeuralHidden)
                    {
                        if (k == 1)
                            nudHiddenLayers1.Value = i;
                        if (k == 2)
                            nudHiddenLayers2.Value = i;
                        if (k == 3)
                            nudHiddenLayers3.Value = i;
                        if (k == 4)
                            nudHiddenLayers4.Value = i;
                        if (k == 5)
                            nudHiddenLayers5.Value = i;
                        if (k == 6)
                            nudHiddenLayers6.Value = i;
                        if (k == 7)
                            nudHiddenLayers7.Value = i;
                        if (k == 8)
                            nudHiddenLayers8.Value = i;
                        k++;
                    }
                    txtDataTrainning.Enabled = false;
                    button1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button3.Enabled = true;
        }

        #endregion

        #region doc xls/

        private void btnDocDL_Click(object sender, EventArgs e)
        {
            var mangTraning = new object[200,8];
            int i = 0;
            Application xlApp;
            Workbook xlWorkBook;


            xlApp = new ApplicationClass();

            xlWorkBook =
                xlApp.Workbooks.Open(
                    @"F:\Cao hoc\Luan van\ProjectANN\long mdc\LongMDC\ANNPrediction\bin\x86\Debug\TrainingInput.xls");
            try
            {
                var sheet = (Worksheet) xlWorkBook.Worksheets[1];

                Range excelRange = sheet.UsedRange;
                foreach (Range coloun in excelRange.Columns)
                {
                    int columindex = 1;

                    var arr = (Array) coloun.Value2;
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

            Application xlApp2;
            Workbook xlWorkBook2;


            xlApp2 = new ApplicationClass();
            xlWorkBook2 =
                xlApp2.Workbooks.Open(
                    @"F:\Cao hoc\Luan van\ProjectANN\long mdc\LongMDC\ANNPrediction\bin\x86\Debug\Target.xls");
            try
            {
                var sheet = (Worksheet) xlWorkBook2.Worksheets[1];
                int k = 0;
                Range excelRange = sheet.UsedRange;
                foreach (Range coloun in excelRange.Columns)
                {
                    int columindex = 1;

                    var arr = (Array) coloun.Value2;
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
                Marshal.ReleaseComObject(obj);
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
            var ofd = new OpenFileDialog {FileName = "", Filter = @"(*.csv)|*.csv"};
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDataTrainning.Text = Path.GetFullPath(ofd.FileName);
            }
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog {FileName = "", Filter = @"(*.csv)|*.csv"};
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDataTest.Text = Path.GetFullPath(ofd.FileName);
            }
        }

        #endregion

        #region Thuc hien fill dl len grid.
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Invoke(addAction, new object[] { epoch, error, _dgvTrainingResults });
            do
            {
                if (localBankQueue.Count > 0)
                {
                    var vate = localBankQueue.Dequeue();
                    var myobj = vate as ReportLog;

                    Invoke(addAction, new object[] { myobj.Epoch, myobj.Error, _dgvTrainingResults });
                }
            } while (true);
        } 
        #endregion
        
        private void zedGraphControl1_SizeChanged(object sender, EventArgs e)
        {
            int minx = Math.Min(tabPage4.Width, tabPage4.Height);
            zedGraphControl1.Width = zedGraphControl1.Height = minx-4;


            //draw.
            var a = Math.Min(zedGraphControl1.GraphPane.Rect.Width, zedGraphControl1.GraphPane.Rect.Height);
            zedGraphControl1.GraphPane.Rect = new RectangleF(zedGraphControl1.GraphPane.Rect.X, zedGraphControl1.GraphPane.Rect.Y, minx - 4, minx - 4);

            zedGraphControl1.Invalidate();
            // Vẽ đồ thị
            zedGraphControl1.AxisChange();
        }
    }

    public class MPoint
    {
        public MPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
    public class ReportLog
    {
        public ReportLog(int epoch, double y)
        {
            Epoch = epoch;
           Error = y;
        }
        [DisplayName("Số lần lặp")]
        public int Epoch { get; set; }
        [DisplayName("Lỗi")]
        public double Error { get; set; }
    }
}