using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    partial class frmPrediction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaxRepeat = new System.Windows.Forms.TextBox();
            this.txtMaxError = new System.Windows.Forms.TextBox();
            this.nudHiddenLayers1 = new System.Windows.Forms.NumericUpDown();
            this._nudHiddenUnits = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataTrainning = new System.Windows.Forms.TextBox();
            this.txtDataTest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this._btnStop = new System.Windows.Forms.Button();
            this._btnStartTraining = new System.Windows.Forms.Button();
            this._dgvTrainingResults = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._btnExport = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this._btnSaveResults = new System.Windows.Forms.Button();
            this._btnPredict = new System.Windows.Forms.Button();
            this._dgvPredictionResults = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Predicted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DoThi_GiaiTri = new ZedGraph.ZedGraphControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDocDL = new System.Windows.Forms.Button();
            this.nudHiddenLayers2 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudHiddenLayers3 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudHiddenLayers4 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudHiddenLayers5 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudHiddenLayers6 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudHiddenLayers7 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nudHiddenLayers8 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtInputCount = new System.Windows.Forms.TextBox();
            this.TxtOutputCount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label16 = new System.Windows.Forms.Label();
            this.lblsolanlap = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblloidattoi = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudHiddenUnits)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvTrainingResults)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPredictionResults)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers8)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lần lặp tối đa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sai số mạng";
            // 
            // txtMaxRepeat
            // 
            this.txtMaxRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxRepeat.Location = new System.Drawing.Point(153, 49);
            this.txtMaxRepeat.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaxRepeat.Name = "txtMaxRepeat";
            this.txtMaxRepeat.Size = new System.Drawing.Size(90, 23);
            this.txtMaxRepeat.TabIndex = 0;
            this.txtMaxRepeat.Text = "1000";
            // 
            // txtMaxError
            // 
            this.txtMaxError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxError.Location = new System.Drawing.Point(153, 17);
            this.txtMaxError.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaxError.Name = "txtMaxError";
            this.txtMaxError.Size = new System.Drawing.Size(90, 23);
            this.txtMaxError.TabIndex = 0;
            this.txtMaxError.Text = "0.0002";
            // 
            // nudHiddenLayers1
            // 
            this.nudHiddenLayers1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHiddenLayers1.Location = new System.Drawing.Point(153, 114);
            this.nudHiddenLayers1.Margin = new System.Windows.Forms.Padding(4);
            this.nudHiddenLayers1.Name = "nudHiddenLayers1";
            this.nudHiddenLayers1.Size = new System.Drawing.Size(91, 23);
            this.nudHiddenLayers1.TabIndex = 14;
            this.nudHiddenLayers1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // _nudHiddenUnits
            // 
            this._nudHiddenUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nudHiddenUnits.Location = new System.Drawing.Point(153, 82);
            this._nudHiddenUnits.Margin = new System.Windows.Forms.Padding(4);
            this._nudHiddenUnits.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this._nudHiddenUnits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudHiddenUnits.Name = "_nudHiddenUnits";
            this._nudHiddenUnits.Size = new System.Drawing.Size(91, 23);
            this._nudHiddenUnits.TabIndex = 13;
            this._nudHiddenUnits.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._nudHiddenUnits.ValueChanged += new System.EventHandler(this._nudHiddenUnits_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số lớp ẩn";
            // 
            // txtDataTrainning
            // 
            this.txtDataTrainning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataTrainning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataTrainning.Location = new System.Drawing.Point(428, 6);
            this.txtDataTrainning.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataTrainning.Name = "txtDataTrainning";
            this.txtDataTrainning.Size = new System.Drawing.Size(495, 23);
            this.txtDataTrainning.TabIndex = 0;
            // 
            // txtDataTest
            // 
            this.txtDataTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataTest.Location = new System.Drawing.Point(428, 38);
            this.txtDataTest.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataTest.Name = "txtDataTest";
            this.txtDataTest.Size = new System.Drawing.Size(495, 23);
            this.txtDataTest.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(277, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tệp dữ liệu học";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(277, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tệp dữ liệu kiểm tra";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(280, 70);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(703, 502);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this._btnStop);
            this.tabPage1.Controls.Add(this._btnStartTraining);
            this.tabPage1.Controls.Add(this._dgvTrainingResults);
            this.tabPage1.Controls.Add(this._btnExport);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(695, 473);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Học mạng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(11, 440);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 8;
            this.button4.Text = "Học lại";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // _btnStop
            // 
            this._btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnStop.Location = new System.Drawing.Point(585, 440);
            this._btnStop.Margin = new System.Windows.Forms.Padding(4);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(100, 28);
            this._btnStop.TabIndex = 6;
            this._btnStop.Text = "Dừng học";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
            // 
            // _btnStartTraining
            // 
            this._btnStartTraining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnStartTraining.Location = new System.Drawing.Point(477, 440);
            this._btnStartTraining.Margin = new System.Windows.Forms.Padding(4);
            this._btnStartTraining.Name = "_btnStartTraining";
            this._btnStartTraining.Size = new System.Drawing.Size(100, 28);
            this._btnStartTraining.TabIndex = 5;
            this._btnStartTraining.Text = "Bắt đầu học";
            this._btnStartTraining.UseVisualStyleBackColor = true;
            this._btnStartTraining.Click += new System.EventHandler(this._btnStartTraining_Click);
            // 
            // _dgvTrainingResults
            // 
            this._dgvTrainingResults.AllowUserToAddRows = false;
            this._dgvTrainingResults.AllowUserToDeleteRows = false;
            this._dgvTrainingResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvTrainingResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvTrainingResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this._dgvTrainingResults.Location = new System.Drawing.Point(8, 7);
            this._dgvTrainingResults.Margin = new System.Windows.Forms.Padding(4);
            this._dgvTrainingResults.Name = "_dgvTrainingResults";
            this._dgvTrainingResults.ReadOnly = true;
            this._dgvTrainingResults.RowHeadersWidth = 10;
            this._dgvTrainingResults.Size = new System.Drawing.Size(677, 425);
            this._dgvTrainingResults.TabIndex = 4;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Số lần lặp";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Lỗi";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // _btnExport
            // 
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(119, 440);
            this._btnExport.Margin = new System.Windows.Forms.Padding(4);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(100, 28);
            this._btnExport.TabIndex = 7;
            this._btnExport.Text = "Lưu mạng";
            this._btnExport.UseVisualStyleBackColor = true;
            this._btnExport.Click += new System.EventHandler(this._btnExport_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this._btnSaveResults);
            this.tabPage2.Controls.Add(this._btnPredict);
            this.tabPage2.Controls.Add(this._dgvPredictionResults);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(695, 473);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dự báo lún";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(8, 440);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "Tải mạng";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // _btnSaveResults
            // 
            this._btnSaveResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveResults.Location = new System.Drawing.Point(429, 440);
            this._btnSaveResults.Margin = new System.Windows.Forms.Padding(4);
            this._btnSaveResults.Name = "_btnSaveResults";
            this._btnSaveResults.Size = new System.Drawing.Size(148, 28);
            this._btnSaveResults.TabIndex = 8;
            this._btnSaveResults.Text = "Xuất kết quả";
            this._btnSaveResults.UseVisualStyleBackColor = true;
            this._btnSaveResults.Click += new System.EventHandler(this._btnSaveResults_Click);
            // 
            // _btnPredict
            // 
            this._btnPredict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPredict.Location = new System.Drawing.Point(585, 440);
            this._btnPredict.Margin = new System.Windows.Forms.Padding(4);
            this._btnPredict.Name = "_btnPredict";
            this._btnPredict.Size = new System.Drawing.Size(100, 28);
            this._btnPredict.TabIndex = 6;
            this._btnPredict.Text = "Dự báo";
            this._btnPredict.UseVisualStyleBackColor = true;
            this._btnPredict.Click += new System.EventHandler(this._btnPredict_Click);
            // 
            // _dgvPredictionResults
            // 
            this._dgvPredictionResults.AllowUserToAddRows = false;
            this._dgvPredictionResults.AllowUserToDeleteRows = false;
            this._dgvPredictionResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvPredictionResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvPredictionResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Actual,
            this.Predicted,
            this.ErrorDifference});
            this._dgvPredictionResults.Location = new System.Drawing.Point(8, 7);
            this._dgvPredictionResults.Margin = new System.Windows.Forms.Padding(4);
            this._dgvPredictionResults.Name = "_dgvPredictionResults";
            this._dgvPredictionResults.ReadOnly = true;
            this._dgvPredictionResults.RowHeadersWidth = 20;
            this._dgvPredictionResults.Size = new System.Drawing.Size(677, 425);
            this._dgvPredictionResults.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Actual
            // 
            this.Actual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Actual.HeaderText = "Giá trị thực";
            this.Actual.Name = "Actual";
            this.Actual.ReadOnly = true;
            // 
            // Predicted
            // 
            this.Predicted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Predicted.HeaderText = "Giá trị dự báo";
            this.Predicted.Name = "Predicted";
            this.Predicted.ReadOnly = true;
            // 
            // ErrorDifference
            // 
            this.ErrorDifference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ErrorDifference.HeaderText = "Độ lệch";
            this.ErrorDifference.Name = "ErrorDifference";
            this.ErrorDifference.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DoThi_GiaiTri);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(695, 473);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Biểu đồ lún";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DoThi_GiaiTri
            // 
            this.DoThi_GiaiTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoThi_GiaiTri.Location = new System.Drawing.Point(0, 0);
            this.DoThi_GiaiTri.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.DoThi_GiaiTri.Name = "DoThi_GiaiTri";
            this.DoThi_GiaiTri.ScrollGrace = 0D;
            this.DoThi_GiaiTri.ScrollMaxX = 0D;
            this.DoThi_GiaiTri.ScrollMaxY = 0D;
            this.DoThi_GiaiTri.ScrollMaxY2 = 0D;
            this.DoThi_GiaiTri.ScrollMinX = 0D;
            this.DoThi_GiaiTri.ScrollMinY = 0D;
            this.DoThi_GiaiTri.ScrollMinY2 = 0D;
            this.DoThi_GiaiTri.Size = new System.Drawing.Size(695, 473);
            this.DoThi_GiaiTri.TabIndex = 5;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.zedGraphControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(695, 473);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "BĐ Tương quan";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.IsEnableHPan = false;
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVPan = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.IsEnableWheelZoom = false;
            this.zedGraphControl1.IsPrintScaleAll = false;
            this.zedGraphControl1.IsShowCursorValues = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(111, 2);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(510, 464);
            this.zedGraphControl1.TabIndex = 6;
            this.zedGraphControl1.SizeChanged += new System.EventHandler(this.zedGraphControl1_SizeChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(695, 473);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Tổng hợp kết quả";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.textBox10);
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Location = new System.Drawing.Point(61, 23);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(439, 134);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lỗi";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(40, 96);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 17);
            this.label23.TabIndex = 0;
            this.label23.Text = "Lỗi MAE:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(40, 64);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 17);
            this.label25.TabIndex = 0;
            this.label25.Text = "Lỗi RMSE:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(40, 32);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 17);
            this.label27.TabIndex = 0;
            this.label27.Text = "Lỗi MSE:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(152, 28);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(203, 23);
            this.textBox9.TabIndex = 0;
            this.textBox9.Text = "0.0002";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(152, 60);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(203, 23);
            this.textBox10.TabIndex = 0;
            this.textBox10.Text = "0.0002";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(152, 92);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(203, 23);
            this.textBox11.TabIndex = 0;
            this.textBox11.Text = "0.0002";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(61, 188);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(439, 203);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Độ lệch";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(40, 159);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(128, 17);
            this.label26.TabIndex = 0;
            this.label26.Text = "Độ lệch trung bình:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(40, 127);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(103, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Độ lệch chuẩn:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(40, 95);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(149, 17);
            this.label22.TabIndex = 0;
            this.label22.Text = "Giá trị lệnh trung bình:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(40, 63);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(136, 17);
            this.label20.TabIndex = 0;
            this.label20.Text = "Giá trị lệnh lớn nhất:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(40, 31);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(141, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "Giá trị lệnh nhỏ nhất:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(244, 159);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(153, 23);
            this.textBox6.TabIndex = 0;
            this.textBox6.Text = "0.0002";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(244, 128);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(153, 23);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "0.0002";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(244, 95);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(153, 23);
            this.textBox4.TabIndex = 0;
            this.textBox4.Text = "0.0002";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(244, 63);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(153, 23);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "0.0002";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(244, 31);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(153, 23);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "0.0002";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.zedGraphControl2);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(695, 473);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Biểu đồ lỗi";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl2.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(695, 473);
            this.zedGraphControl2.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 529);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(256, 20);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Số neuron lớp 1";
            // 
            // btnDocDL
            // 
            this.btnDocDL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocDL.Location = new System.Drawing.Point(108, 557);
            this.btnDocDL.Margin = new System.Windows.Forms.Padding(4);
            this.btnDocDL.Name = "btnDocDL";
            this.btnDocDL.Size = new System.Drawing.Size(100, 28);
            this.btnDocDL.TabIndex = 5;
            this.btnDocDL.Text = "tong hop dl";
            this.btnDocDL.UseVisualStyleBackColor = true;
            this.btnDocDL.Visible = false;
            this.btnDocDL.Click += new System.EventHandler(this.btnDocDL_Click);
            // 
            // nudHiddenLayers2
            // 
            this.nudHiddenLayers2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHiddenLayers2.Location = new System.Drawing.Point(153, 146);
            this.nudHiddenLayers2.Margin = new System.Windows.Forms.Padding(4);
            this.nudHiddenLayers2.Name = "nudHiddenLayers2";
            this.nudHiddenLayers2.Size = new System.Drawing.Size(91, 23);
            this.nudHiddenLayers2.TabIndex = 14;
            this.nudHiddenLayers2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Số neuron lớp 2";
            // 
            // nudHiddenLayers3
            // 
            this.nudHiddenLayers3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHiddenLayers3.Location = new System.Drawing.Point(153, 178);
            this.nudHiddenLayers3.Margin = new System.Windows.Forms.Padding(4);
            this.nudHiddenLayers3.Name = "nudHiddenLayers3";
            this.nudHiddenLayers3.Size = new System.Drawing.Size(91, 23);
            this.nudHiddenLayers3.TabIndex = 14;
            this.nudHiddenLayers3.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 180);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Số neuron lớp 3";
            // 
            // nudHiddenLayers4
            // 
            this.nudHiddenLayers4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHiddenLayers4.Location = new System.Drawing.Point(153, 210);
            this.nudHiddenLayers4.Margin = new System.Windows.Forms.Padding(4);
            this.nudHiddenLayers4.Name = "nudHiddenLayers4";
            this.nudHiddenLayers4.Size = new System.Drawing.Size(91, 23);
            this.nudHiddenLayers4.TabIndex = 14;
            this.nudHiddenLayers4.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 212);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Số neuron lớp 4";
            // 
            // nudHiddenLayers5
            // 
            this.nudHiddenLayers5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHiddenLayers5.Location = new System.Drawing.Point(153, 242);
            this.nudHiddenLayers5.Margin = new System.Windows.Forms.Padding(4);
            this.nudHiddenLayers5.Name = "nudHiddenLayers5";
            this.nudHiddenLayers5.Size = new System.Drawing.Size(91, 23);
            this.nudHiddenLayers5.TabIndex = 14;
            this.nudHiddenLayers5.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 244);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Số neuron lớp 5";
            // 
            // nudHiddenLayers6
            // 
            this.nudHiddenLayers6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHiddenLayers6.Location = new System.Drawing.Point(153, 274);
            this.nudHiddenLayers6.Margin = new System.Windows.Forms.Padding(4);
            this.nudHiddenLayers6.Name = "nudHiddenLayers6";
            this.nudHiddenLayers6.Size = new System.Drawing.Size(91, 23);
            this.nudHiddenLayers6.TabIndex = 14;
            this.nudHiddenLayers6.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 276);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Số neuron lớp 6";
            // 
            // nudHiddenLayers7
            // 
            this.nudHiddenLayers7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHiddenLayers7.Location = new System.Drawing.Point(153, 306);
            this.nudHiddenLayers7.Margin = new System.Windows.Forms.Padding(4);
            this.nudHiddenLayers7.Name = "nudHiddenLayers7";
            this.nudHiddenLayers7.Size = new System.Drawing.Size(91, 23);
            this.nudHiddenLayers7.TabIndex = 14;
            this.nudHiddenLayers7.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 308);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Số neuron lớp 7";
            // 
            // nudHiddenLayers8
            // 
            this.nudHiddenLayers8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHiddenLayers8.Location = new System.Drawing.Point(153, 338);
            this.nudHiddenLayers8.Margin = new System.Windows.Forms.Padding(4);
            this.nudHiddenLayers8.Name = "nudHiddenLayers8";
            this.nudHiddenLayers8.Size = new System.Drawing.Size(91, 23);
            this.nudHiddenLayers8.TabIndex = 14;
            this.nudHiddenLayers8.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 340);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Số neuron lớp 8";
            // 
            // txtInputCount
            // 
            this.txtInputCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputCount.Location = new System.Drawing.Point(170, 6);
            this.txtInputCount.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputCount.Name = "txtInputCount";
            this.txtInputCount.Size = new System.Drawing.Size(90, 23);
            this.txtInputCount.TabIndex = 0;
            this.txtInputCount.Text = "0";
            // 
            // TxtOutputCount
            // 
            this.TxtOutputCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOutputCount.Location = new System.Drawing.Point(169, 38);
            this.TxtOutputCount.Margin = new System.Windows.Forms.Padding(4);
            this.TxtOutputCount.Name = "TxtOutputCount";
            this.TxtOutputCount.ReadOnly = true;
            this.TxtOutputCount.Size = new System.Drawing.Size(90, 23);
            this.TxtOutputCount.TabIndex = 0;
            this.TxtOutputCount.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(31, 10);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 17);
            this.label14.TabIndex = 1;
            this.label14.Text = "Số đầu vào";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(31, 41);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "Số đầu ra";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudHiddenLayers8);
            this.groupBox1.Controls.Add(this.nudHiddenLayers7);
            this.groupBox1.Controls.Add(this.nudHiddenLayers6);
            this.groupBox1.Controls.Add(this.nudHiddenLayers5);
            this.groupBox1.Controls.Add(this.nudHiddenLayers4);
            this.groupBox1.Controls.Add(this.nudHiddenLayers3);
            this.groupBox1.Controls.Add(this.nudHiddenLayers2);
            this.groupBox1.Controls.Add(this.nudHiddenLayers1);
            this.groupBox1.Controls.Add(this.txtMaxRepeat);
            this.groupBox1.Controls.Add(this._nudHiddenUnits);
            this.groupBox1.Controls.Add(this.txtMaxError);
            this.groupBox1.Location = new System.Drawing.Point(16, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(256, 378);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(931, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 28);
            this.button1.TabIndex = 17;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.textBox3_DoubleClick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(931, 37);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 28);
            this.button2.TabIndex = 17;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.textBox4_DoubleClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(15, 15);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Số lần đã lặp ";
            // 
            // lblsolanlap
            // 
            this.lblsolanlap.AutoSize = true;
            this.lblsolanlap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsolanlap.Location = new System.Drawing.Point(118, 17);
            this.lblsolanlap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblsolanlap.Name = "lblsolanlap";
            this.lblsolanlap.Size = new System.Drawing.Size(73, 13);
            this.lblsolanlap.TabIndex = 0;
            this.lblsolanlap.Text = "Số lần đã lặp:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(15, 44);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 17);
            this.label19.TabIndex = 0;
            this.label19.Text = "Lỗi đạt tới";
            // 
            // lblloidattoi
            // 
            this.lblloidattoi.AutoSize = true;
            this.lblloidattoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloidattoi.Location = new System.Drawing.Point(118, 49);
            this.lblloidattoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblloidattoi.Name = "lblloidattoi";
            this.lblloidattoi.Size = new System.Drawing.Size(73, 13);
            this.lblloidattoi.TabIndex = 0;
            this.lblloidattoi.Text = "Số lần đã lặp:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblloidattoi);
            this.groupBox4.Controls.Add(this.lblsolanlap);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(16, 446);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(256, 76);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // frmPrediction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 596);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtDataTrainning);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDocDL);
            this.Controls.Add(this.txtDataTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TxtOutputCount);
            this.Controls.Add(this.txtInputCount);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1012, 634);
            this.Name = "frmPrediction";
            this.Text = "Dự báo lún";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudHiddenUnits)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvTrainingResults)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvPredictionResults)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiddenLayers8)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private readonly Action<int, double, DataGridView> addAction = new Action<int, double, DataGridView>((epoch, error, dgvTrainingResults) =>
        {
            if (dgvTrainingResults.Rows.Count == 500) dgvTrainingResults.Rows.Clear();
            int rowIndex = dgvTrainingResults.Rows.Add(epoch, error);
            dgvTrainingResults.FirstDisplayedScrollingRowIndex = rowIndex;
        });

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaxRepeat;
        private System.Windows.Forms.TextBox txtMaxError;
        private System.Windows.Forms.NumericUpDown nudHiddenLayers1;
        private System.Windows.Forms.NumericUpDown _nudHiddenUnits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataTrainning;
        private System.Windows.Forms.TextBox txtDataTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button _btnExport;
        private System.Windows.Forms.Button _btnStop;
        private System.Windows.Forms.Button _btnStartTraining;
        private System.Windows.Forms.DataGridView _dgvTrainingResults;
        private System.Windows.Forms.Button _btnSaveResults;
        private System.Windows.Forms.Button _btnPredict;
        private System.Windows.Forms.DataGridView _dgvPredictionResults;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnDocDL;
        private System.Windows.Forms.NumericUpDown nudHiddenLayers2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudHiddenLayers3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudHiddenLayers4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudHiddenLayers5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudHiddenLayers6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudHiddenLayers7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudHiddenLayers8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtInputCount;
        private System.Windows.Forms.TextBox TxtOutputCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private ZedGraph.ZedGraphControl DoThi_GiaiTri;
        private TabPage tabPage4;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TabPage tabPage5;
        private Label label26;
        private Label label24;
        private Label label22;
        private Label label20;
        private Label label18;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private GroupBox groupBox3;
        private Label label23;
        private Label label25;
        private Label label27;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Actual;
        private DataGridViewTextBoxColumn Predicted;
        private DataGridViewTextBoxColumn ErrorDifference;
        private TabPage tabPage6;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private ProgressBar progressBar1;
        private Label lblloidattoi;
        private Label label19;
        private Label lblsolanlap;
        private Label label16;
        private GroupBox groupBox4;
    }
}

