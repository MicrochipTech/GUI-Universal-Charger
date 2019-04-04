namespace MCP19111BatteryChargerGUI
{
    partial class Form1
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
            System.Windows.Forms.Label labelFlashData;
            System.Windows.Forms.Label labelFlashAddress;
            System.Windows.Forms.Label labelFlashPeakPoke;
            System.Windows.Forms.Label labelSFRData;
            System.Windows.Forms.Label labelSFRAddress;
            System.Windows.Forms.Label labelSFRPeakPoke;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProfile = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.labelChargerOutputVoltage = new System.Windows.Forms.Label();
            this.labelPCBtype = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.labelPackTemperatureRead = new System.Windows.Forms.Label();
            this.labelPackTemperature = new System.Windows.Forms.Label();
            this.labelChargerStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonProfileStop = new System.Windows.Forms.Button();
            this.buttonProfileStart = new System.Windows.Forms.Button();
            this.chartProfile = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelProfileChargerState = new System.Windows.Forms.Label();
            this.labelProfileChargeTime = new System.Windows.Forms.Label();
            this.labelProfileInputVoltage = new System.Windows.Forms.Label();
            this.labelProfilePackCurrent = new System.Windows.Forms.Label();
            this.labelProfilePackVoltage = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPageConfigure = new System.Windows.Forms.TabPage();
            this.labelUVLOFalling = new System.Windows.Forms.Label();
            this.labelUVLOFallingUnits = new System.Windows.Forms.Label();
            this.textBoxUVLOFalling = new System.Windows.Forms.TextBox();
            this.labelApproximateResistanceUnits = new System.Windows.Forms.Label();
            this.textBoxWireRes = new System.Windows.Forms.TextBox();
            this.labelUVLORising = new System.Windows.Forms.Label();
            this.labelUVLORisingUnits = new System.Windows.Forms.Label();
            this.labelReferenceDesignType = new System.Windows.Forms.Label();
            this.comboBoxPCBType = new System.Windows.Forms.ComboBox();
            this.textBoxUVLORising = new System.Windows.Forms.TextBox();
            this.labelWireRes = new System.Windows.Forms.Label();
            this.labelRecommendedInputRange = new System.Windows.Forms.Label();
            this.labelInputRangeCalculation = new System.Windows.Forms.Label();
            this.labelTerminationVoltageUnits = new System.Windows.Forms.Label();
            this.labelTerminationVoltage = new System.Windows.Forms.Label();
            this.textBoxTerminationVoltage = new System.Windows.Forms.TextBox();
            this.checkBoxThermistor = new System.Windows.Forms.CheckBox();
            this.labelMaximumTemperatureUnits = new System.Windows.Forms.Label();
            this.labelMinimumTemperatureUnits = new System.Windows.Forms.Label();
            this.textBoxMaximumTemperature = new System.Windows.Forms.TextBox();
            this.labelRestorationChargeTimeUnits = new System.Windows.Forms.Label();
            this.textBoxRestorationChargeTime = new System.Windows.Forms.TextBox();
            this.labelRestorationTime = new System.Windows.Forms.Label();
            this.labelRapidChargeTimeUnits = new System.Windows.Forms.Label();
            this.textBoxRapidChargeTime = new System.Windows.Forms.TextBox();
            this.labelRapidTime = new System.Windows.Forms.Label();
            this.labelMaximumTemperature = new System.Windows.Forms.Label();
            this.labelMinimumTemperature = new System.Windows.Forms.Label();
            this.textBoxMinimumTemperature = new System.Windows.Forms.TextBox();
            this.labelBatteryChemistry = new System.Windows.Forms.Label();
            this.comboBoxChemistry = new System.Windows.Forms.ComboBox();
            this.labelPreconditionVoltageUnits = new System.Windows.Forms.Label();
            this.labelPreconditionCellVoltage = new System.Windows.Forms.Label();
            this.textBoxPreconditionCellVoltage = new System.Windows.Forms.TextBox();
            this.labelPreconditionCurrentUnits = new System.Windows.Forms.Label();
            this.textBoxPreconditionCurrent = new System.Windows.Forms.TextBox();
            this.labelPreconditionCurrent = new System.Windows.Forms.Label();
            this.labelPackVoltage = new System.Windows.Forms.Label();
            this.labelMaximumChargeTimeUnits = new System.Windows.Forms.Label();
            this.textBoxMaximumChargeTime = new System.Windows.Forms.TextBox();
            this.labelChargeCurrentUnits = new System.Windows.Forms.Label();
            this.labelTerminationCurrentUnits = new System.Windows.Forms.Label();
            this.labelCellVoltageUnits = new System.Windows.Forms.Label();
            this.labelPackVoltageDisplay = new System.Windows.Forms.Label();
            this.buttonWriteConfiguration = new System.Windows.Forms.Button();
            this.buttonReadConfiguration = new System.Windows.Forms.Button();
            this.labelMaximumChargeTime = new System.Windows.Forms.Label();
            this.comboBoxNumberOfCells = new System.Windows.Forms.ComboBox();
            this.textBoxTerminationCurrent = new System.Windows.Forms.TextBox();
            this.textBoxChargeCurrent = new System.Windows.Forms.TextBox();
            this.labelTermination = new System.Windows.Forms.Label();
            this.labelChargeCurrent = new System.Windows.Forms.Label();
            this.labelNumberSeriesCells = new System.Windows.Forms.Label();
            this.labelCellVoltage = new System.Windows.Forms.Label();
            this.textBoxCellVoltage = new System.Windows.Forms.TextBox();
            this.tabPageCalibrate = new System.Windows.Forms.TabPage();
            this.textBoxSetHighVin = new System.Windows.Forms.TextBox();
            this.textBoxSetHighVbat = new System.Windows.Forms.TextBox();
            this.textBoxSetHighAmp = new System.Windows.Forms.TextBox();
            this.textBoxSetMidVin = new System.Windows.Forms.TextBox();
            this.textBoxSetMidVbat = new System.Windows.Forms.TextBox();
            this.textBoxSetLowVin = new System.Windows.Forms.TextBox();
            this.textBoxSetLowVbat = new System.Windows.Forms.TextBox();
            this.textBoxSetMidAmp = new System.Windows.Forms.TextBox();
            this.textBoxSetLowAmp = new System.Windows.Forms.TextBox();
            this.ButtonHighVin = new System.Windows.Forms.Button();
            this.ButtonMidVin = new System.Windows.Forms.Button();
            this.ButtonLowVin = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.buttonBeginCalibration = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHighVbat = new System.Windows.Forms.TextBox();
            this.textBoxMidVbat = new System.Windows.Forms.TextBox();
            this.textBoxLowVbat = new System.Windows.Forms.TextBox();
            this.textBoxHighVin = new System.Windows.Forms.TextBox();
            this.textBoxMidVin = new System.Windows.Forms.TextBox();
            this.textBoxLowVin = new System.Windows.Forms.TextBox();
            this.textBoxHighAmp = new System.Windows.Forms.TextBox();
            this.textBoxMidAmp = new System.Windows.Forms.TextBox();
            this.textBoxLowAmp = new System.Windows.Forms.TextBox();
            this.buttonHighVbat = new System.Windows.Forms.Button();
            this.buttonMidVbat = new System.Windows.Forms.Button();
            this.buttonLowVbat = new System.Windows.Forms.Button();
            this.buttonHighA = new System.Windows.Forms.Button();
            this.buttonMidA = new System.Windows.Forms.Button();
            this.buttonLowA = new System.Windows.Forms.Button();
            this.buttonReadCalibration = new System.Windows.Forms.Button();
            this.buttonWriteCalibration = new System.Windows.Forms.Button();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.labelRapidChargeTimerLive = new System.Windows.Forms.Label();
            this.labelRestoreTimerLive = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.labeldtdtCountLive = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.labeldTdtLive = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.labelPCBtypeLive = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.labelPackTemperatureReadLive = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.labelChargerStatusLive = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.labelProfileChargerStateLive = new System.Windows.Forms.Label();
            this.labelProfileInputVoltageLive = new System.Windows.Forms.Label();
            this.labelProfilePackCurrentLive = new System.Windows.Forms.Label();
            this.labelProfilePackVoltageLive = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.ButtonUpdateCurrentValues = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ButtonDefaultCalValues = new System.Windows.Forms.Button();
            this.ButtonWriteHFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TabPagePeakPoke = new System.Windows.Forms.TabPage();
            this.textBoxFlashData = new System.Windows.Forms.TextBox();
            this.textBoxFlashAddress = new System.Windows.Forms.TextBox();
            this.buttonPokeFlash = new System.Windows.Forms.Button();
            this.buttonPeakFlash = new System.Windows.Forms.Button();
            this.textBoxSFRData = new System.Windows.Forms.TextBox();
            this.textBoxSFRAddress = new System.Windows.Forms.TextBox();
            this.buttonPokeSFR = new System.Windows.Forms.Button();
            this.buttonPeakSFR = new System.Windows.Forms.Button();
            this.SFR_Drop_Down = new System.Windows.Forms.ComboBox();
            labelFlashData = new System.Windows.Forms.Label();
            labelFlashAddress = new System.Windows.Forms.Label();
            labelFlashPeakPoke = new System.Windows.Forms.Label();
            labelSFRData = new System.Windows.Forms.Label();
            labelSFRAddress = new System.Windows.Forms.Label();
            labelSFRPeakPoke = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfile)).BeginInit();
            this.tabPageConfigure.SuspendLayout();
            this.tabPageCalibrate.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.TabPagePeakPoke.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFlashData
            // 
            labelFlashData.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            labelFlashData.AutoSize = true;
            labelFlashData.CausesValidation = false;
            labelFlashData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelFlashData.Location = new System.Drawing.Point(344, 243);
            labelFlashData.Name = "labelFlashData";
            labelFlashData.Size = new System.Drawing.Size(44, 20);
            labelFlashData.TabIndex = 13;
            labelFlashData.Text = "Data";
            // 
            // labelFlashAddress
            // 
            labelFlashAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            labelFlashAddress.AutoSize = true;
            labelFlashAddress.CausesValidation = false;
            labelFlashAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelFlashAddress.Location = new System.Drawing.Point(101, 243);
            labelFlashAddress.Name = "labelFlashAddress";
            labelFlashAddress.Size = new System.Drawing.Size(68, 20);
            labelFlashAddress.TabIndex = 12;
            labelFlashAddress.Text = "Address";
            // 
            // labelFlashPeakPoke
            // 
            labelFlashPeakPoke.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            labelFlashPeakPoke.AutoSize = true;
            labelFlashPeakPoke.CausesValidation = false;
            labelFlashPeakPoke.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelFlashPeakPoke.Location = new System.Drawing.Point(191, 195);
            labelFlashPeakPoke.Name = "labelFlashPeakPoke";
            labelFlashPeakPoke.Size = new System.Drawing.Size(197, 25);
            labelFlashPeakPoke.TabIndex = 11;
            labelFlashPeakPoke.Text = "Flash Peak & Poke";
            // 
            // labelSFRData
            // 
            labelSFRData.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            labelSFRData.AutoSize = true;
            labelSFRData.CausesValidation = false;
            labelSFRData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelSFRData.Location = new System.Drawing.Point(344, 78);
            labelSFRData.Name = "labelSFRData";
            labelSFRData.Size = new System.Drawing.Size(44, 20);
            labelSFRData.TabIndex = 6;
            labelSFRData.Text = "Data";
            // 
            // labelSFRAddress
            // 
            labelSFRAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            labelSFRAddress.AutoSize = true;
            labelSFRAddress.CausesValidation = false;
            labelSFRAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelSFRAddress.Location = new System.Drawing.Point(101, 78);
            labelSFRAddress.Name = "labelSFRAddress";
            labelSFRAddress.Size = new System.Drawing.Size(68, 20);
            labelSFRAddress.TabIndex = 5;
            labelSFRAddress.Text = "Address";
            // 
            // labelSFRPeakPoke
            // 
            labelSFRPeakPoke.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            labelSFRPeakPoke.AutoSize = true;
            labelSFRPeakPoke.CausesValidation = false;
            labelSFRPeakPoke.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelSFRPeakPoke.Location = new System.Drawing.Point(154, 33);
            labelSFRPeakPoke.Name = "labelSFRPeakPoke";
            labelSFRPeakPoke.Size = new System.Drawing.Size(279, 25);
            labelSFRPeakPoke.TabIndex = 4;
            labelSFRPeakPoke.Text = "SFR Register Peak & Poke";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageProfile);
            this.tabControl1.Controls.Add(this.tabPageConfigure);
            this.tabControl1.Controls.Add(this.tabPageCalibrate);
            this.tabControl1.Controls.Add(this.tabPageAdvanced);
            this.tabControl1.Controls.Add(this.TabPagePeakPoke);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 754);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.handlerSelectedIndexChanged);
            // 
            // tabPageProfile
            // 
            this.tabPageProfile.Controls.Add(this.label32);
            this.tabPageProfile.Controls.Add(this.labelChargerOutputVoltage);
            this.tabPageProfile.Controls.Add(this.labelPCBtype);
            this.tabPageProfile.Controls.Add(this.label3);
            this.tabPageProfile.Controls.Add(this.buttonSaveData);
            this.tabPageProfile.Controls.Add(this.labelPackTemperatureRead);
            this.tabPageProfile.Controls.Add(this.labelPackTemperature);
            this.tabPageProfile.Controls.Add(this.labelChargerStatus);
            this.tabPageProfile.Controls.Add(this.label12);
            this.tabPageProfile.Controls.Add(this.buttonProfileStop);
            this.tabPageProfile.Controls.Add(this.buttonProfileStart);
            this.tabPageProfile.Controls.Add(this.chartProfile);
            this.tabPageProfile.Controls.Add(this.labelProfileChargerState);
            this.tabPageProfile.Controls.Add(this.labelProfileChargeTime);
            this.tabPageProfile.Controls.Add(this.labelProfileInputVoltage);
            this.tabPageProfile.Controls.Add(this.labelProfilePackCurrent);
            this.tabPageProfile.Controls.Add(this.labelProfilePackVoltage);
            this.tabPageProfile.Controls.Add(this.label19);
            this.tabPageProfile.Controls.Add(this.label18);
            this.tabPageProfile.Controls.Add(this.label17);
            this.tabPageProfile.Controls.Add(this.label16);
            this.tabPageProfile.Controls.Add(this.label15);
            this.tabPageProfile.Location = new System.Drawing.Point(4, 22);
            this.tabPageProfile.Name = "tabPageProfile";
            this.tabPageProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProfile.Size = new System.Drawing.Size(630, 728);
            this.tabPageProfile.TabIndex = 1;
            this.tabPageProfile.Text = "Profile";
            this.tabPageProfile.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(6, 36);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(153, 15);
            this.label32.TabIndex = 21;
            this.label32.Text = "Estimated Pack Voltage:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChargerOutputVoltage
            // 
            this.labelChargerOutputVoltage.AutoSize = true;
            this.labelChargerOutputVoltage.Location = new System.Drawing.Point(159, 18);
            this.labelChargerOutputVoltage.Name = "labelChargerOutputVoltage";
            this.labelChargerOutputVoltage.Size = new System.Drawing.Size(38, 13);
            this.labelChargerOutputVoltage.TabIndex = 20;
            this.labelChargerOutputVoltage.Text = "88.8 V";
            this.labelChargerOutputVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPCBtype
            // 
            this.labelPCBtype.AutoSize = true;
            this.labelPCBtype.Location = new System.Drawing.Point(159, 101);
            this.labelPCBtype.Name = "labelPCBtype";
            this.labelPCBtype.Size = new System.Drawing.Size(60, 13);
            this.labelPCBtype.TabIndex = 19;
            this.labelPCBtype.Text = "MCP19111";
            this.labelPCBtype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "PCB Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.Location = new System.Drawing.Point(531, 67);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveData.TabIndex = 3;
            this.buttonSaveData.Text = "Save Data";
            this.buttonSaveData.UseVisualStyleBackColor = true;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // labelPackTemperatureRead
            // 
            this.labelPackTemperatureRead.AutoSize = true;
            this.labelPackTemperatureRead.Location = new System.Drawing.Point(398, 17);
            this.labelPackTemperatureRead.Name = "labelPackTemperatureRead";
            this.labelPackTemperatureRead.Size = new System.Drawing.Size(51, 13);
            this.labelPackTemperatureRead.TabIndex = 17;
            this.labelPackTemperatureRead.Text = "3600 sec";
            this.labelPackTemperatureRead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPackTemperature
            // 
            this.labelPackTemperature.Location = new System.Drawing.Point(258, 17);
            this.labelPackTemperature.Name = "labelPackTemperature";
            this.labelPackTemperature.Size = new System.Drawing.Size(136, 15);
            this.labelPackTemperature.TabIndex = 16;
            this.labelPackTemperature.Text = "Pack Temperature:";
            this.labelPackTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChargerStatus
            // 
            this.labelChargerStatus.AutoSize = true;
            this.labelChargerStatus.Location = new System.Drawing.Point(159, 146);
            this.labelChargerStatus.Name = "labelChargerStatus";
            this.labelChargerStatus.Size = new System.Drawing.Size(37, 13);
            this.labelChargerStatus.TabIndex = 15;
            this.labelChargerStatus.Text = "Active";
            this.labelChargerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(51, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 15);
            this.label12.TabIndex = 14;
            this.label12.Text = "Charger Status:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonProfileStop
            // 
            this.buttonProfileStop.Location = new System.Drawing.Point(531, 38);
            this.buttonProfileStop.Name = "buttonProfileStop";
            this.buttonProfileStop.Size = new System.Drawing.Size(75, 23);
            this.buttonProfileStop.TabIndex = 2;
            this.buttonProfileStop.Text = "Stop";
            this.buttonProfileStop.UseVisualStyleBackColor = true;
            this.buttonProfileStop.Click += new System.EventHandler(this.buttonProfileStop_Click);
            // 
            // buttonProfileStart
            // 
            this.buttonProfileStart.Location = new System.Drawing.Point(531, 9);
            this.buttonProfileStart.Name = "buttonProfileStart";
            this.buttonProfileStart.Size = new System.Drawing.Size(75, 23);
            this.buttonProfileStart.TabIndex = 1;
            this.buttonProfileStart.Text = "Start";
            this.buttonProfileStart.UseVisualStyleBackColor = true;
            this.buttonProfileStart.Click += new System.EventHandler(this.buttonProfileStart_Click);
            // 
            // chartProfile
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Title = "Charge Voltage (V)";
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            chartArea2.AxisY.Title = "Charge Current (A)";
            chartArea2.Name = "ChartArea2";
            chartArea3.AxisY.Title = "Input Voltage (V)";
            chartArea3.Name = "ChartArea3";
            chartArea4.AxisY.Title = "Pack Temperature (C)";
            chartArea4.Name = "ChartArea4";
            this.chartProfile.ChartAreas.Add(chartArea1);
            this.chartProfile.ChartAreas.Add(chartArea2);
            this.chartProfile.ChartAreas.Add(chartArea3);
            this.chartProfile.ChartAreas.Add(chartArea4);
            this.chartProfile.Location = new System.Drawing.Point(-1, 202);
            this.chartProfile.Name = "chartProfile";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Pack Voltage";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Pack Current";
            series3.ChartArea = "ChartArea3";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Input Voltage";
            series4.ChartArea = "ChartArea4";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Pack Temperature";
            this.chartProfile.Series.Add(series1);
            this.chartProfile.Series.Add(series2);
            this.chartProfile.Series.Add(series3);
            this.chartProfile.Series.Add(series4);
            this.chartProfile.Size = new System.Drawing.Size(631, 526);
            this.chartProfile.TabIndex = 10;
            this.chartProfile.Text = "Profile";
            // 
            // labelProfileChargerState
            // 
            this.labelProfileChargerState.AutoSize = true;
            this.labelProfileChargerState.Location = new System.Drawing.Point(159, 122);
            this.labelProfileChargerState.Name = "labelProfileChargerState";
            this.labelProfileChargerState.Size = new System.Drawing.Size(79, 13);
            this.labelProfileChargerState.TabIndex = 9;
            this.labelProfileChargerState.Text = "Prequalification";
            this.labelProfileChargerState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfileChargeTime
            // 
            this.labelProfileChargeTime.AutoSize = true;
            this.labelProfileChargeTime.Location = new System.Drawing.Point(398, 38);
            this.labelProfileChargeTime.Name = "labelProfileChargeTime";
            this.labelProfileChargeTime.Size = new System.Drawing.Size(51, 13);
            this.labelProfileChargeTime.TabIndex = 8;
            this.labelProfileChargeTime.Text = "3600 sec";
            this.labelProfileChargeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfileInputVoltage
            // 
            this.labelProfileInputVoltage.AutoSize = true;
            this.labelProfileInputVoltage.Location = new System.Drawing.Point(159, 80);
            this.labelProfileInputVoltage.Name = "labelProfileInputVoltage";
            this.labelProfileInputVoltage.Size = new System.Drawing.Size(38, 13);
            this.labelProfileInputVoltage.TabIndex = 7;
            this.labelProfileInputVoltage.Text = "25.6 V";
            this.labelProfileInputVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfilePackCurrent
            // 
            this.labelProfilePackCurrent.AutoSize = true;
            this.labelProfilePackCurrent.Location = new System.Drawing.Point(159, 59);
            this.labelProfilePackCurrent.Name = "labelProfilePackCurrent";
            this.labelProfilePackCurrent.Size = new System.Drawing.Size(44, 13);
            this.labelProfilePackCurrent.TabIndex = 6;
            this.labelProfilePackCurrent.Text = "6.023 A";
            this.labelProfilePackCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfilePackVoltage
            // 
            this.labelProfilePackVoltage.AutoSize = true;
            this.labelProfilePackVoltage.Location = new System.Drawing.Point(159, 38);
            this.labelProfilePackVoltage.Name = "labelProfilePackVoltage";
            this.labelProfilePackVoltage.Size = new System.Drawing.Size(38, 13);
            this.labelProfilePackVoltage.TabIndex = 5;
            this.labelProfilePackVoltage.Text = "88.8 V";
            this.labelProfilePackVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(67, 122);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 15);
            this.label19.TabIndex = 4;
            this.label19.Text = "Charger State:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(312, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 15);
            this.label18.TabIndex = 3;
            this.label18.Text = "Charge Time:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(77, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Input Voltage:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(77, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Pack Current:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(23, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Charger Output Voltage:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPageConfigure
            // 
            this.tabPageConfigure.Controls.Add(this.labelUVLOFalling);
            this.tabPageConfigure.Controls.Add(this.labelUVLOFallingUnits);
            this.tabPageConfigure.Controls.Add(this.textBoxUVLOFalling);
            this.tabPageConfigure.Controls.Add(this.labelApproximateResistanceUnits);
            this.tabPageConfigure.Controls.Add(this.textBoxWireRes);
            this.tabPageConfigure.Controls.Add(this.labelUVLORising);
            this.tabPageConfigure.Controls.Add(this.labelUVLORisingUnits);
            this.tabPageConfigure.Controls.Add(this.labelReferenceDesignType);
            this.tabPageConfigure.Controls.Add(this.comboBoxPCBType);
            this.tabPageConfigure.Controls.Add(this.textBoxUVLORising);
            this.tabPageConfigure.Controls.Add(this.labelWireRes);
            this.tabPageConfigure.Controls.Add(this.labelRecommendedInputRange);
            this.tabPageConfigure.Controls.Add(this.labelInputRangeCalculation);
            this.tabPageConfigure.Controls.Add(this.labelTerminationVoltageUnits);
            this.tabPageConfigure.Controls.Add(this.labelTerminationVoltage);
            this.tabPageConfigure.Controls.Add(this.textBoxTerminationVoltage);
            this.tabPageConfigure.Controls.Add(this.checkBoxThermistor);
            this.tabPageConfigure.Controls.Add(this.labelMaximumTemperatureUnits);
            this.tabPageConfigure.Controls.Add(this.labelMinimumTemperatureUnits);
            this.tabPageConfigure.Controls.Add(this.textBoxMaximumTemperature);
            this.tabPageConfigure.Controls.Add(this.labelRestorationChargeTimeUnits);
            this.tabPageConfigure.Controls.Add(this.textBoxRestorationChargeTime);
            this.tabPageConfigure.Controls.Add(this.labelRestorationTime);
            this.tabPageConfigure.Controls.Add(this.labelRapidChargeTimeUnits);
            this.tabPageConfigure.Controls.Add(this.textBoxRapidChargeTime);
            this.tabPageConfigure.Controls.Add(this.labelRapidTime);
            this.tabPageConfigure.Controls.Add(this.labelMaximumTemperature);
            this.tabPageConfigure.Controls.Add(this.labelMinimumTemperature);
            this.tabPageConfigure.Controls.Add(this.textBoxMinimumTemperature);
            this.tabPageConfigure.Controls.Add(this.labelBatteryChemistry);
            this.tabPageConfigure.Controls.Add(this.comboBoxChemistry);
            this.tabPageConfigure.Controls.Add(this.labelPreconditionVoltageUnits);
            this.tabPageConfigure.Controls.Add(this.labelPreconditionCellVoltage);
            this.tabPageConfigure.Controls.Add(this.textBoxPreconditionCellVoltage);
            this.tabPageConfigure.Controls.Add(this.labelPreconditionCurrentUnits);
            this.tabPageConfigure.Controls.Add(this.textBoxPreconditionCurrent);
            this.tabPageConfigure.Controls.Add(this.labelPreconditionCurrent);
            this.tabPageConfigure.Controls.Add(this.labelPackVoltage);
            this.tabPageConfigure.Controls.Add(this.labelMaximumChargeTimeUnits);
            this.tabPageConfigure.Controls.Add(this.textBoxMaximumChargeTime);
            this.tabPageConfigure.Controls.Add(this.labelChargeCurrentUnits);
            this.tabPageConfigure.Controls.Add(this.labelTerminationCurrentUnits);
            this.tabPageConfigure.Controls.Add(this.labelCellVoltageUnits);
            this.tabPageConfigure.Controls.Add(this.labelPackVoltageDisplay);
            this.tabPageConfigure.Controls.Add(this.buttonWriteConfiguration);
            this.tabPageConfigure.Controls.Add(this.buttonReadConfiguration);
            this.tabPageConfigure.Controls.Add(this.labelMaximumChargeTime);
            this.tabPageConfigure.Controls.Add(this.comboBoxNumberOfCells);
            this.tabPageConfigure.Controls.Add(this.textBoxTerminationCurrent);
            this.tabPageConfigure.Controls.Add(this.textBoxChargeCurrent);
            this.tabPageConfigure.Controls.Add(this.labelTermination);
            this.tabPageConfigure.Controls.Add(this.labelChargeCurrent);
            this.tabPageConfigure.Controls.Add(this.labelNumberSeriesCells);
            this.tabPageConfigure.Controls.Add(this.labelCellVoltage);
            this.tabPageConfigure.Controls.Add(this.textBoxCellVoltage);
            this.tabPageConfigure.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfigure.Name = "tabPageConfigure";
            this.tabPageConfigure.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfigure.Size = new System.Drawing.Size(630, 728);
            this.tabPageConfigure.TabIndex = 0;
            this.tabPageConfigure.Text = "Configure";
            this.tabPageConfigure.UseVisualStyleBackColor = true;
            // 
            // labelUVLOFalling
            // 
            this.labelUVLOFalling.Location = new System.Drawing.Point(6, 476);
            this.labelUVLOFalling.Name = "labelUVLOFalling";
            this.labelUVLOFalling.Size = new System.Drawing.Size(161, 17);
            this.labelUVLOFalling.TabIndex = 66;
            this.labelUVLOFalling.Text = "UVLO Falling Threshold:";
            this.labelUVLOFalling.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelUVLOFallingUnits
            // 
            this.labelUVLOFallingUnits.AutoSize = true;
            this.labelUVLOFallingUnits.Location = new System.Drawing.Point(223, 476);
            this.labelUVLOFallingUnits.Name = "labelUVLOFallingUnits";
            this.labelUVLOFallingUnits.Size = new System.Drawing.Size(30, 13);
            this.labelUVLOFallingUnits.TabIndex = 65;
            this.labelUVLOFallingUnits.Text = "Volts";
            // 
            // textBoxUVLOFalling
            // 
            this.textBoxUVLOFalling.Location = new System.Drawing.Point(173, 473);
            this.textBoxUVLOFalling.Name = "textBoxUVLOFalling";
            this.textBoxUVLOFalling.Size = new System.Drawing.Size(41, 20);
            this.textBoxUVLOFalling.TabIndex = 64;
            this.textBoxUVLOFalling.Text = "10";
            // 
            // labelApproximateResistanceUnits
            // 
            this.labelApproximateResistanceUnits.AutoSize = true;
            this.labelApproximateResistanceUnits.Location = new System.Drawing.Point(223, 502);
            this.labelApproximateResistanceUnits.Name = "labelApproximateResistanceUnits";
            this.labelApproximateResistanceUnits.Size = new System.Drawing.Size(42, 13);
            this.labelApproximateResistanceUnits.TabIndex = 63;
            this.labelApproximateResistanceUnits.Text = "mOhms";
            // 
            // textBoxWireRes
            // 
            this.textBoxWireRes.Location = new System.Drawing.Point(173, 500);
            this.textBoxWireRes.Name = "textBoxWireRes";
            this.textBoxWireRes.Size = new System.Drawing.Size(41, 20);
            this.textBoxWireRes.TabIndex = 62;
            this.textBoxWireRes.Text = "10";
            // 
            // labelUVLORising
            // 
            this.labelUVLORising.Location = new System.Drawing.Point(6, 450);
            this.labelUVLORising.Name = "labelUVLORising";
            this.labelUVLORising.Size = new System.Drawing.Size(161, 17);
            this.labelUVLORising.TabIndex = 61;
            this.labelUVLORising.Text = "UVLO Rising Threshold:";
            this.labelUVLORising.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelUVLORisingUnits
            // 
            this.labelUVLORisingUnits.AutoSize = true;
            this.labelUVLORisingUnits.Location = new System.Drawing.Point(223, 450);
            this.labelUVLORisingUnits.Name = "labelUVLORisingUnits";
            this.labelUVLORisingUnits.Size = new System.Drawing.Size(30, 13);
            this.labelUVLORisingUnits.TabIndex = 60;
            this.labelUVLORisingUnits.Text = "Volts";
            // 
            // labelReferenceDesignType
            // 
            this.labelReferenceDesignType.AutoSize = true;
            this.labelReferenceDesignType.Location = new System.Drawing.Point(42, 15);
            this.labelReferenceDesignType.Name = "labelReferenceDesignType";
            this.labelReferenceDesignType.Size = new System.Drawing.Size(123, 13);
            this.labelReferenceDesignType.TabIndex = 59;
            this.labelReferenceDesignType.Text = "Reference Design Type:";
            this.labelReferenceDesignType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPCBType
            // 
            this.comboBoxPCBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPCBType.FormattingEnabled = true;
            this.comboBoxPCBType.Location = new System.Drawing.Point(181, 13);
            this.comboBoxPCBType.Name = "comboBoxPCBType";
            this.comboBoxPCBType.Size = new System.Drawing.Size(179, 21);
            this.comboBoxPCBType.TabIndex = 58;
            this.comboBoxPCBType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPCBType_SelectedIndexChanged);
            // 
            // textBoxUVLORising
            // 
            this.textBoxUVLORising.Location = new System.Drawing.Point(173, 447);
            this.textBoxUVLORising.Name = "textBoxUVLORising";
            this.textBoxUVLORising.Size = new System.Drawing.Size(41, 20);
            this.textBoxUVLORising.TabIndex = 48;
            this.textBoxUVLORising.Text = "10";
            // 
            // labelWireRes
            // 
            this.labelWireRes.Location = new System.Drawing.Point(6, 502);
            this.labelWireRes.Name = "labelWireRes";
            this.labelWireRes.Size = new System.Drawing.Size(161, 17);
            this.labelWireRes.TabIndex = 52;
            this.labelWireRes.Text = "Approximate Resistance:";
            this.labelWireRes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRecommendedInputRange
            // 
            this.labelRecommendedInputRange.AutoSize = true;
            this.labelRecommendedInputRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelRecommendedInputRange.Location = new System.Drawing.Point(39, 105);
            this.labelRecommendedInputRange.Name = "labelRecommendedInputRange";
            this.labelRecommendedInputRange.Size = new System.Drawing.Size(169, 15);
            this.labelRecommendedInputRange.TabIndex = 47;
            this.labelRecommendedInputRange.Text = "Recommended Input Range :";
            // 
            // labelInputRangeCalculation
            // 
            this.labelInputRangeCalculation.AutoSize = true;
            this.labelInputRangeCalculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelInputRangeCalculation.Location = new System.Drawing.Point(214, 105);
            this.labelInputRangeCalculation.Name = "labelInputRangeCalculation";
            this.labelInputRangeCalculation.Size = new System.Drawing.Size(71, 15);
            this.labelInputRangeCalculation.TabIndex = 46;
            this.labelInputRangeCalculation.Text = "Volt ~ Amps";
            // 
            // labelTerminationVoltageUnits
            // 
            this.labelTerminationVoltageUnits.AutoSize = true;
            this.labelTerminationVoltageUnits.Location = new System.Drawing.Point(220, 186);
            this.labelTerminationVoltageUnits.Name = "labelTerminationVoltageUnits";
            this.labelTerminationVoltageUnits.Size = new System.Drawing.Size(30, 13);
            this.labelTerminationVoltageUnits.TabIndex = 44;
            this.labelTerminationVoltageUnits.Text = "Volts";
            // 
            // labelTerminationVoltage
            // 
            this.labelTerminationVoltage.Location = new System.Drawing.Point(39, 187);
            this.labelTerminationVoltage.Name = "labelTerminationVoltage";
            this.labelTerminationVoltage.Size = new System.Drawing.Size(128, 13);
            this.labelTerminationVoltage.TabIndex = 42;
            this.labelTerminationVoltage.Text = "Termination Cell Voltage:";
            this.labelTerminationVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxTerminationVoltage
            // 
            this.textBoxTerminationVoltage.Location = new System.Drawing.Point(173, 184);
            this.textBoxTerminationVoltage.Name = "textBoxTerminationVoltage";
            this.textBoxTerminationVoltage.Size = new System.Drawing.Size(41, 20);
            this.textBoxTerminationVoltage.TabIndex = 4;
            this.textBoxTerminationVoltage.Text = "1.8";
            // 
            // checkBoxThermistor
            // 
            this.checkBoxThermistor.AutoSize = true;
            this.checkBoxThermistor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxThermistor.Location = new System.Drawing.Point(67, 72);
            this.checkBoxThermistor.Name = "checkBoxThermistor";
            this.checkBoxThermistor.Size = new System.Drawing.Size(114, 17);
            this.checkBoxThermistor.TabIndex = 1;
            this.checkBoxThermistor.Text = "Enable Thermistor:";
            this.checkBoxThermistor.UseVisualStyleBackColor = true;
            this.checkBoxThermistor.CheckedChanged += new System.EventHandler(this.checkBoxThermistor_CheckedChanged);
            // 
            // labelMaximumTemperatureUnits
            // 
            this.labelMaximumTemperatureUnits.AutoSize = true;
            this.labelMaximumTemperatureUnits.Location = new System.Drawing.Point(220, 422);
            this.labelMaximumTemperatureUnits.Name = "labelMaximumTemperatureUnits";
            this.labelMaximumTemperatureUnits.Size = new System.Drawing.Size(18, 13);
            this.labelMaximumTemperatureUnits.TabIndex = 40;
            this.labelMaximumTemperatureUnits.Text = "°C";
            // 
            // labelMinimumTemperatureUnits
            // 
            this.labelMinimumTemperatureUnits.AutoSize = true;
            this.labelMinimumTemperatureUnits.Location = new System.Drawing.Point(220, 396);
            this.labelMinimumTemperatureUnits.Name = "labelMinimumTemperatureUnits";
            this.labelMinimumTemperatureUnits.Size = new System.Drawing.Size(18, 13);
            this.labelMinimumTemperatureUnits.TabIndex = 39;
            this.labelMinimumTemperatureUnits.Text = "°C";
            // 
            // textBoxMaximumTemperature
            // 
            this.textBoxMaximumTemperature.Location = new System.Drawing.Point(173, 420);
            this.textBoxMaximumTemperature.Name = "textBoxMaximumTemperature";
            this.textBoxMaximumTemperature.Size = new System.Drawing.Size(41, 20);
            this.textBoxMaximumTemperature.TabIndex = 13;
            this.textBoxMaximumTemperature.Text = "10";
            // 
            // labelRestorationChargeTimeUnits
            // 
            this.labelRestorationChargeTimeUnits.AutoSize = true;
            this.labelRestorationChargeTimeUnits.Location = new System.Drawing.Point(220, 370);
            this.labelRestorationChargeTimeUnits.Name = "labelRestorationChargeTimeUnits";
            this.labelRestorationChargeTimeUnits.Size = new System.Drawing.Size(44, 13);
            this.labelRestorationChargeTimeUnits.TabIndex = 37;
            this.labelRestorationChargeTimeUnits.Text = "Minutes";
            // 
            // textBoxRestorationChargeTime
            // 
            this.textBoxRestorationChargeTime.Location = new System.Drawing.Point(173, 367);
            this.textBoxRestorationChargeTime.Name = "textBoxRestorationChargeTime";
            this.textBoxRestorationChargeTime.Size = new System.Drawing.Size(41, 20);
            this.textBoxRestorationChargeTime.TabIndex = 11;
            this.textBoxRestorationChargeTime.Text = "10";
            // 
            // labelRestorationTime
            // 
            this.labelRestorationTime.Location = new System.Drawing.Point(39, 372);
            this.labelRestorationTime.Name = "labelRestorationTime";
            this.labelRestorationTime.Size = new System.Drawing.Size(128, 13);
            this.labelRestorationTime.TabIndex = 35;
            this.labelRestorationTime.Text = "Restoration Charge Time:";
            this.labelRestorationTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRapidChargeTimeUnits
            // 
            this.labelRapidChargeTimeUnits.AutoSize = true;
            this.labelRapidChargeTimeUnits.Location = new System.Drawing.Point(220, 342);
            this.labelRapidChargeTimeUnits.Name = "labelRapidChargeTimeUnits";
            this.labelRapidChargeTimeUnits.Size = new System.Drawing.Size(44, 13);
            this.labelRapidChargeTimeUnits.TabIndex = 34;
            this.labelRapidChargeTimeUnits.Text = "Minutes";
            // 
            // textBoxRapidChargeTime
            // 
            this.textBoxRapidChargeTime.Location = new System.Drawing.Point(173, 341);
            this.textBoxRapidChargeTime.Name = "textBoxRapidChargeTime";
            this.textBoxRapidChargeTime.Size = new System.Drawing.Size(41, 20);
            this.textBoxRapidChargeTime.TabIndex = 10;
            this.textBoxRapidChargeTime.Text = "10";
            // 
            // labelRapidTime
            // 
            this.labelRapidTime.Location = new System.Drawing.Point(39, 344);
            this.labelRapidTime.Name = "labelRapidTime";
            this.labelRapidTime.Size = new System.Drawing.Size(128, 13);
            this.labelRapidTime.TabIndex = 32;
            this.labelRapidTime.Text = "Rapid Charge Time:";
            this.labelRapidTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMaximumTemperature
            // 
            this.labelMaximumTemperature.Location = new System.Drawing.Point(39, 424);
            this.labelMaximumTemperature.Name = "labelMaximumTemperature";
            this.labelMaximumTemperature.Size = new System.Drawing.Size(128, 13);
            this.labelMaximumTemperature.TabIndex = 31;
            this.labelMaximumTemperature.Text = "Maximum Temperature:";
            this.labelMaximumTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMinimumTemperature
            // 
            this.labelMinimumTemperature.Location = new System.Drawing.Point(39, 398);
            this.labelMinimumTemperature.Name = "labelMinimumTemperature";
            this.labelMinimumTemperature.Size = new System.Drawing.Size(128, 13);
            this.labelMinimumTemperature.TabIndex = 30;
            this.labelMinimumTemperature.Text = "Minimum Temperature:";
            this.labelMinimumTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMinimumTemperature
            // 
            this.textBoxMinimumTemperature.Location = new System.Drawing.Point(173, 394);
            this.textBoxMinimumTemperature.Name = "textBoxMinimumTemperature";
            this.textBoxMinimumTemperature.Size = new System.Drawing.Size(41, 20);
            this.textBoxMinimumTemperature.TabIndex = 12;
            this.textBoxMinimumTemperature.Text = "10";
            // 
            // labelBatteryChemistry
            // 
            this.labelBatteryChemistry.AutoSize = true;
            this.labelBatteryChemistry.Location = new System.Drawing.Point(76, 48);
            this.labelBatteryChemistry.Name = "labelBatteryChemistry";
            this.labelBatteryChemistry.Size = new System.Drawing.Size(91, 13);
            this.labelBatteryChemistry.TabIndex = 27;
            this.labelBatteryChemistry.Text = "Battery Chemistry:";
            // 
            // comboBoxChemistry
            // 
            this.comboBoxChemistry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChemistry.FormattingEnabled = true;
            this.comboBoxChemistry.Location = new System.Drawing.Point(181, 45);
            this.comboBoxChemistry.Name = "comboBoxChemistry";
            this.comboBoxChemistry.Size = new System.Drawing.Size(92, 21);
            this.comboBoxChemistry.TabIndex = 0;
            this.comboBoxChemistry.SelectedIndexChanged += new System.EventHandler(this.comboBoxChemistry_SelectedIndexChanged);
            // 
            // labelPreconditionVoltageUnits
            // 
            this.labelPreconditionVoltageUnits.AutoSize = true;
            this.labelPreconditionVoltageUnits.Location = new System.Drawing.Point(220, 162);
            this.labelPreconditionVoltageUnits.Name = "labelPreconditionVoltageUnits";
            this.labelPreconditionVoltageUnits.Size = new System.Drawing.Size(30, 13);
            this.labelPreconditionVoltageUnits.TabIndex = 25;
            this.labelPreconditionVoltageUnits.Text = "Volts";
            // 
            // labelPreconditionCellVoltage
            // 
            this.labelPreconditionCellVoltage.Location = new System.Drawing.Point(39, 164);
            this.labelPreconditionCellVoltage.Name = "labelPreconditionCellVoltage";
            this.labelPreconditionCellVoltage.Size = new System.Drawing.Size(128, 13);
            this.labelPreconditionCellVoltage.TabIndex = 2;
            this.labelPreconditionCellVoltage.Text = "Precondition Cell Voltage:";
            this.labelPreconditionCellVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPreconditionCellVoltage
            // 
            this.textBoxPreconditionCellVoltage.Location = new System.Drawing.Point(173, 160);
            this.textBoxPreconditionCellVoltage.Name = "textBoxPreconditionCellVoltage";
            this.textBoxPreconditionCellVoltage.Size = new System.Drawing.Size(41, 20);
            this.textBoxPreconditionCellVoltage.TabIndex = 3;
            this.textBoxPreconditionCellVoltage.Text = "3.0";
            // 
            // labelPreconditionCurrentUnits
            // 
            this.labelPreconditionCurrentUnits.AutoSize = true;
            this.labelPreconditionCurrentUnits.Location = new System.Drawing.Point(220, 266);
            this.labelPreconditionCurrentUnits.Name = "labelPreconditionCurrentUnits";
            this.labelPreconditionCurrentUnits.Size = new System.Drawing.Size(33, 13);
            this.labelPreconditionCurrentUnits.TabIndex = 22;
            this.labelPreconditionCurrentUnits.Text = "Amps";
            // 
            // textBoxPreconditionCurrent
            // 
            this.textBoxPreconditionCurrent.Location = new System.Drawing.Point(173, 263);
            this.textBoxPreconditionCurrent.Name = "textBoxPreconditionCurrent";
            this.textBoxPreconditionCurrent.Size = new System.Drawing.Size(41, 20);
            this.textBoxPreconditionCurrent.TabIndex = 7;
            this.textBoxPreconditionCurrent.Text = "0.100";
            // 
            // labelPreconditionCurrent
            // 
            this.labelPreconditionCurrent.Location = new System.Drawing.Point(39, 268);
            this.labelPreconditionCurrent.Name = "labelPreconditionCurrent";
            this.labelPreconditionCurrent.Size = new System.Drawing.Size(128, 13);
            this.labelPreconditionCurrent.TabIndex = 8;
            this.labelPreconditionCurrent.Text = "Precondition Current:";
            this.labelPreconditionCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPackVoltage
            // 
            this.labelPackVoltage.AutoSize = true;
            this.labelPackVoltage.Location = new System.Drawing.Point(524, 107);
            this.labelPackVoltage.Name = "labelPackVoltage";
            this.labelPackVoltage.Size = new System.Drawing.Size(43, 13);
            this.labelPackVoltage.TabIndex = 15;
            this.labelPackVoltage.Text = "Voltage";
            // 
            // labelMaximumChargeTimeUnits
            // 
            this.labelMaximumChargeTimeUnits.AutoSize = true;
            this.labelMaximumChargeTimeUnits.Location = new System.Drawing.Point(220, 318);
            this.labelMaximumChargeTimeUnits.Name = "labelMaximumChargeTimeUnits";
            this.labelMaximumChargeTimeUnits.Size = new System.Drawing.Size(44, 13);
            this.labelMaximumChargeTimeUnits.TabIndex = 18;
            this.labelMaximumChargeTimeUnits.Text = "Minutes";
            // 
            // textBoxMaximumChargeTime
            // 
            this.textBoxMaximumChargeTime.Location = new System.Drawing.Point(173, 315);
            this.textBoxMaximumChargeTime.Name = "textBoxMaximumChargeTime";
            this.textBoxMaximumChargeTime.Size = new System.Drawing.Size(41, 20);
            this.textBoxMaximumChargeTime.TabIndex = 9;
            this.textBoxMaximumChargeTime.Text = "10";
            // 
            // labelChargeCurrentUnits
            // 
            this.labelChargeCurrentUnits.AutoSize = true;
            this.labelChargeCurrentUnits.Location = new System.Drawing.Point(220, 240);
            this.labelChargeCurrentUnits.Name = "labelChargeCurrentUnits";
            this.labelChargeCurrentUnits.Size = new System.Drawing.Size(33, 13);
            this.labelChargeCurrentUnits.TabIndex = 16;
            this.labelChargeCurrentUnits.Text = "Amps";
            // 
            // labelTerminationCurrentUnits
            // 
            this.labelTerminationCurrentUnits.AutoSize = true;
            this.labelTerminationCurrentUnits.Location = new System.Drawing.Point(220, 292);
            this.labelTerminationCurrentUnits.Name = "labelTerminationCurrentUnits";
            this.labelTerminationCurrentUnits.Size = new System.Drawing.Size(33, 13);
            this.labelTerminationCurrentUnits.TabIndex = 15;
            this.labelTerminationCurrentUnits.Text = "Amps";
            // 
            // labelCellVoltageUnits
            // 
            this.labelCellVoltageUnits.AutoSize = true;
            this.labelCellVoltageUnits.Location = new System.Drawing.Point(220, 136);
            this.labelCellVoltageUnits.Name = "labelCellVoltageUnits";
            this.labelCellVoltageUnits.Size = new System.Drawing.Size(30, 13);
            this.labelCellVoltageUnits.TabIndex = 14;
            this.labelCellVoltageUnits.Text = "Volts";
            // 
            // labelPackVoltageDisplay
            // 
            this.labelPackVoltageDisplay.AutoSize = true;
            this.labelPackVoltageDisplay.Location = new System.Drawing.Point(444, 107);
            this.labelPackVoltageDisplay.Name = "labelPackVoltageDisplay";
            this.labelPackVoltageDisplay.Size = new System.Drawing.Size(74, 13);
            this.labelPackVoltageDisplay.TabIndex = 14;
            this.labelPackVoltageDisplay.Text = "Pack Voltage:";
            // 
            // buttonWriteConfiguration
            // 
            this.buttonWriteConfiguration.Location = new System.Drawing.Point(447, 40);
            this.buttonWriteConfiguration.Name = "buttonWriteConfiguration";
            this.buttonWriteConfiguration.Size = new System.Drawing.Size(134, 23);
            this.buttonWriteConfiguration.TabIndex = 15;
            this.buttonWriteConfiguration.Text = "Write Configuration";
            this.buttonWriteConfiguration.UseVisualStyleBackColor = true;
            this.buttonWriteConfiguration.Click += new System.EventHandler(this.buttonWriteConfiguration_Click);
            // 
            // buttonReadConfiguration
            // 
            this.buttonReadConfiguration.Location = new System.Drawing.Point(447, 11);
            this.buttonReadConfiguration.Name = "buttonReadConfiguration";
            this.buttonReadConfiguration.Size = new System.Drawing.Size(134, 23);
            this.buttonReadConfiguration.TabIndex = 14;
            this.buttonReadConfiguration.Text = "Read Configuration";
            this.buttonReadConfiguration.UseVisualStyleBackColor = true;
            this.buttonReadConfiguration.Click += new System.EventHandler(this.buttonReadConfiguration_Click);
            // 
            // labelMaximumChargeTime
            // 
            this.labelMaximumChargeTime.Location = new System.Drawing.Point(39, 318);
            this.labelMaximumChargeTime.Name = "labelMaximumChargeTime";
            this.labelMaximumChargeTime.Size = new System.Drawing.Size(128, 13);
            this.labelMaximumChargeTime.TabIndex = 12;
            this.labelMaximumChargeTime.Text = "Maximum Charge time:";
            this.labelMaximumChargeTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxNumberOfCells
            // 
            this.comboBoxNumberOfCells.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumberOfCells.FormattingEnabled = true;
            this.comboBoxNumberOfCells.Location = new System.Drawing.Point(173, 210);
            this.comboBoxNumberOfCells.Name = "comboBoxNumberOfCells";
            this.comboBoxNumberOfCells.Size = new System.Drawing.Size(58, 21);
            this.comboBoxNumberOfCells.TabIndex = 5;
            this.comboBoxNumberOfCells.SelectedValueChanged += new System.EventHandler(this.NumberOfCellsChanged);
            // 
            // textBoxTerminationCurrent
            // 
            this.textBoxTerminationCurrent.Location = new System.Drawing.Point(173, 289);
            this.textBoxTerminationCurrent.Name = "textBoxTerminationCurrent";
            this.textBoxTerminationCurrent.Size = new System.Drawing.Size(41, 20);
            this.textBoxTerminationCurrent.TabIndex = 8;
            this.textBoxTerminationCurrent.Text = "0.100";
            // 
            // textBoxChargeCurrent
            // 
            this.textBoxChargeCurrent.Location = new System.Drawing.Point(173, 237);
            this.textBoxChargeCurrent.Name = "textBoxChargeCurrent";
            this.textBoxChargeCurrent.Size = new System.Drawing.Size(41, 20);
            this.textBoxChargeCurrent.TabIndex = 6;
            this.textBoxChargeCurrent.Text = "0.932";
            this.textBoxChargeCurrent.TextChanged += new System.EventHandler(this.ChargeCurrentChanged);
            // 
            // labelTermination
            // 
            this.labelTermination.Location = new System.Drawing.Point(39, 292);
            this.labelTermination.Name = "labelTermination";
            this.labelTermination.Size = new System.Drawing.Size(128, 13);
            this.labelTermination.TabIndex = 10;
            this.labelTermination.Text = "Termination Current:";
            this.labelTermination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChargeCurrent
            // 
            this.labelChargeCurrent.Location = new System.Drawing.Point(39, 240);
            this.labelChargeCurrent.Name = "labelChargeCurrent";
            this.labelChargeCurrent.Size = new System.Drawing.Size(128, 13);
            this.labelChargeCurrent.TabIndex = 6;
            this.labelChargeCurrent.Text = "Charge Current:";
            this.labelChargeCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNumberSeriesCells
            // 
            this.labelNumberSeriesCells.Location = new System.Drawing.Point(19, 213);
            this.labelNumberSeriesCells.Name = "labelNumberSeriesCells";
            this.labelNumberSeriesCells.Size = new System.Drawing.Size(148, 18);
            this.labelNumberSeriesCells.TabIndex = 4;
            this.labelNumberSeriesCells.Text = "# Series Connected Cells:";
            this.labelNumberSeriesCells.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCellVoltage
            // 
            this.labelCellVoltage.Location = new System.Drawing.Point(39, 138);
            this.labelCellVoltage.Name = "labelCellVoltage";
            this.labelCellVoltage.Size = new System.Drawing.Size(128, 13);
            this.labelCellVoltage.TabIndex = 0;
            this.labelCellVoltage.Text = "Cell Voltage:";
            this.labelCellVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCellVoltage
            // 
            this.textBoxCellVoltage.Location = new System.Drawing.Point(173, 134);
            this.textBoxCellVoltage.Name = "textBoxCellVoltage";
            this.textBoxCellVoltage.Size = new System.Drawing.Size(41, 20);
            this.textBoxCellVoltage.TabIndex = 2;
            this.textBoxCellVoltage.Text = "4.2";
            this.textBoxCellVoltage.TextChanged += new System.EventHandler(this.handlerCellVoltageChanged);
            // 
            // tabPageCalibrate
            // 
            this.tabPageCalibrate.Controls.Add(this.textBoxSetHighVin);
            this.tabPageCalibrate.Controls.Add(this.textBoxSetHighVbat);
            this.tabPageCalibrate.Controls.Add(this.textBoxSetHighAmp);
            this.tabPageCalibrate.Controls.Add(this.textBoxSetMidVin);
            this.tabPageCalibrate.Controls.Add(this.textBoxSetMidVbat);
            this.tabPageCalibrate.Controls.Add(this.textBoxSetLowVin);
            this.tabPageCalibrate.Controls.Add(this.textBoxSetLowVbat);
            this.tabPageCalibrate.Controls.Add(this.textBoxSetMidAmp);
            this.tabPageCalibrate.Controls.Add(this.textBoxSetLowAmp);
            this.tabPageCalibrate.Controls.Add(this.ButtonHighVin);
            this.tabPageCalibrate.Controls.Add(this.ButtonMidVin);
            this.tabPageCalibrate.Controls.Add(this.ButtonLowVin);
            this.tabPageCalibrate.Controls.Add(this.label30);
            this.tabPageCalibrate.Controls.Add(this.buttonBeginCalibration);
            this.tabPageCalibrate.Controls.Add(this.label11);
            this.tabPageCalibrate.Controls.Add(this.label13);
            this.tabPageCalibrate.Controls.Add(this.label10);
            this.tabPageCalibrate.Controls.Add(this.label35);
            this.tabPageCalibrate.Controls.Add(this.label6);
            this.tabPageCalibrate.Controls.Add(this.label27);
            this.tabPageCalibrate.Controls.Add(this.label5);
            this.tabPageCalibrate.Controls.Add(this.label9);
            this.tabPageCalibrate.Controls.Add(this.label23);
            this.tabPageCalibrate.Controls.Add(this.label21);
            this.tabPageCalibrate.Controls.Add(this.label20);
            this.tabPageCalibrate.Controls.Add(this.label8);
            this.tabPageCalibrate.Controls.Add(this.label14);
            this.tabPageCalibrate.Controls.Add(this.label4);
            this.tabPageCalibrate.Controls.Add(this.label7);
            this.tabPageCalibrate.Controls.Add(this.label2);
            this.tabPageCalibrate.Controls.Add(this.label1);
            this.tabPageCalibrate.Controls.Add(this.textBoxHighVbat);
            this.tabPageCalibrate.Controls.Add(this.textBoxMidVbat);
            this.tabPageCalibrate.Controls.Add(this.textBoxLowVbat);
            this.tabPageCalibrate.Controls.Add(this.textBoxHighVin);
            this.tabPageCalibrate.Controls.Add(this.textBoxMidVin);
            this.tabPageCalibrate.Controls.Add(this.textBoxLowVin);
            this.tabPageCalibrate.Controls.Add(this.textBoxHighAmp);
            this.tabPageCalibrate.Controls.Add(this.textBoxMidAmp);
            this.tabPageCalibrate.Controls.Add(this.textBoxLowAmp);
            this.tabPageCalibrate.Controls.Add(this.buttonHighVbat);
            this.tabPageCalibrate.Controls.Add(this.buttonMidVbat);
            this.tabPageCalibrate.Controls.Add(this.buttonLowVbat);
            this.tabPageCalibrate.Controls.Add(this.buttonHighA);
            this.tabPageCalibrate.Controls.Add(this.buttonMidA);
            this.tabPageCalibrate.Controls.Add(this.buttonLowA);
            this.tabPageCalibrate.Controls.Add(this.buttonReadCalibration);
            this.tabPageCalibrate.Controls.Add(this.buttonWriteCalibration);
            this.tabPageCalibrate.Location = new System.Drawing.Point(4, 22);
            this.tabPageCalibrate.Name = "tabPageCalibrate";
            this.tabPageCalibrate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCalibrate.Size = new System.Drawing.Size(630, 728);
            this.tabPageCalibrate.TabIndex = 2;
            this.tabPageCalibrate.Text = "Calibrate";
            this.tabPageCalibrate.UseVisualStyleBackColor = true;
            // 
            // textBoxSetHighVin
            // 
            this.textBoxSetHighVin.Location = new System.Drawing.Point(69, 382);
            this.textBoxSetHighVin.MaxLength = 10;
            this.textBoxSetHighVin.Name = "textBoxSetHighVin";
            this.textBoxSetHighVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetHighVin.TabIndex = 48;
            this.textBoxSetHighVin.Text = "16.8";
            this.textBoxSetHighVin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetHighVbat
            // 
            this.textBoxSetHighVbat.Location = new System.Drawing.Point(69, 260);
            this.textBoxSetHighVbat.MaxLength = 10;
            this.textBoxSetHighVbat.Name = "textBoxSetHighVbat";
            this.textBoxSetHighVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetHighVbat.TabIndex = 48;
            this.textBoxSetHighVbat.Text = "16.8";
            this.textBoxSetHighVbat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetHighAmp
            // 
            this.textBoxSetHighAmp.Location = new System.Drawing.Point(68, 148);
            this.textBoxSetHighAmp.MaxLength = 10;
            this.textBoxSetHighAmp.Name = "textBoxSetHighAmp";
            this.textBoxSetHighAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetHighAmp.TabIndex = 48;
            this.textBoxSetHighAmp.Text = "2.000";
            this.textBoxSetHighAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetMidVin
            // 
            this.textBoxSetMidVin.Location = new System.Drawing.Point(69, 353);
            this.textBoxSetMidVin.MaxLength = 10;
            this.textBoxSetMidVin.Name = "textBoxSetMidVin";
            this.textBoxSetMidVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetMidVin.TabIndex = 47;
            this.textBoxSetMidVin.Text = "12.6";
            this.textBoxSetMidVin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetMidVbat
            // 
            this.textBoxSetMidVbat.Location = new System.Drawing.Point(69, 231);
            this.textBoxSetMidVbat.MaxLength = 10;
            this.textBoxSetMidVbat.Name = "textBoxSetMidVbat";
            this.textBoxSetMidVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetMidVbat.TabIndex = 47;
            this.textBoxSetMidVbat.Text = "12.6";
            this.textBoxSetMidVbat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetLowVin
            // 
            this.textBoxSetLowVin.Location = new System.Drawing.Point(69, 324);
            this.textBoxSetLowVin.MaxLength = 10;
            this.textBoxSetLowVin.Name = "textBoxSetLowVin";
            this.textBoxSetLowVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetLowVin.TabIndex = 46;
            this.textBoxSetLowVin.Text = "8.4";
            this.textBoxSetLowVin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetLowVbat
            // 
            this.textBoxSetLowVbat.Location = new System.Drawing.Point(69, 202);
            this.textBoxSetLowVbat.MaxLength = 10;
            this.textBoxSetLowVbat.Name = "textBoxSetLowVbat";
            this.textBoxSetLowVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetLowVbat.TabIndex = 46;
            this.textBoxSetLowVbat.Text = "8.4";
            this.textBoxSetLowVbat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetMidAmp
            // 
            this.textBoxSetMidAmp.Location = new System.Drawing.Point(68, 119);
            this.textBoxSetMidAmp.MaxLength = 10;
            this.textBoxSetMidAmp.Name = "textBoxSetMidAmp";
            this.textBoxSetMidAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetMidAmp.TabIndex = 47;
            this.textBoxSetMidAmp.Text = "1.000";
            this.textBoxSetMidAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetLowAmp
            // 
            this.textBoxSetLowAmp.Location = new System.Drawing.Point(68, 90);
            this.textBoxSetLowAmp.MaxLength = 10;
            this.textBoxSetLowAmp.Name = "textBoxSetLowAmp";
            this.textBoxSetLowAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetLowAmp.TabIndex = 46;
            this.textBoxSetLowAmp.Text = "0.100";
            this.textBoxSetLowAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ButtonHighVin
            // 
            this.ButtonHighVin.Location = new System.Drawing.Point(205, 379);
            this.ButtonHighVin.Name = "ButtonHighVin";
            this.ButtonHighVin.Size = new System.Drawing.Size(75, 23);
            this.ButtonHighVin.TabIndex = 45;
            this.ButtonHighVin.Text = "High";
            this.ButtonHighVin.UseVisualStyleBackColor = true;
            this.ButtonHighVin.Click += new System.EventHandler(this.ButtonHighVin_Click);
            // 
            // ButtonMidVin
            // 
            this.ButtonMidVin.Location = new System.Drawing.Point(205, 350);
            this.ButtonMidVin.Name = "ButtonMidVin";
            this.ButtonMidVin.Size = new System.Drawing.Size(75, 23);
            this.ButtonMidVin.TabIndex = 44;
            this.ButtonMidVin.Text = "Middle";
            this.ButtonMidVin.UseVisualStyleBackColor = true;
            this.ButtonMidVin.Click += new System.EventHandler(this.ButtonMidVin_Click);
            // 
            // ButtonLowVin
            // 
            this.ButtonLowVin.Location = new System.Drawing.Point(205, 321);
            this.ButtonLowVin.Name = "ButtonLowVin";
            this.ButtonLowVin.Size = new System.Drawing.Size(75, 23);
            this.ButtonLowVin.TabIndex = 43;
            this.ButtonLowVin.Text = "Low";
            this.ButtonLowVin.UseVisualStyleBackColor = true;
            this.ButtonLowVin.Click += new System.EventHandler(this.ButtonLowVin_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(66, 307);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(70, 13);
            this.label30.TabIndex = 41;
            this.label30.Text = "Input Voltage";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBeginCalibration
            // 
            this.buttonBeginCalibration.Location = new System.Drawing.Point(452, 87);
            this.buttonBeginCalibration.Name = "buttonBeginCalibration";
            this.buttonBeginCalibration.Size = new System.Drawing.Size(108, 42);
            this.buttonBeginCalibration.TabIndex = 7;
            this.buttonBeginCalibration.Text = "Begin the Calibration Process";
            this.buttonBeginCalibration.UseVisualStyleBackColor = true;
            this.buttonBeginCalibration.Click += new System.EventHandler(this.buttonBeginCalibration_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(66, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Battery Voltage";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(53, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "Test Points Below:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(58, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Enter Calibration";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(201, 44);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(84, 13);
            this.label35.TabIndex = 41;
            this.label35.Text = "Calibrated Value";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Push Buttons to Read";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(110, 385);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(30, 13);
            this.label27.TabIndex = 40;
            this.label27.Text = "Volts";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Charge Current";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(110, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Volts";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(110, 356);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 13);
            this.label23.TabIndex = 40;
            this.label23.Text = "Volts";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(332, 44);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 41;
            this.label21.Text = "Calibrated Count";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(332, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 41;
            this.label20.Text = "Resulting ADC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Volts";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(110, 327);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Volts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Amps";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Volts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Amps";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Amps";
            // 
            // textBoxHighVbat
            // 
            this.textBoxHighVbat.Location = new System.Drawing.Point(353, 260);
            this.textBoxHighVbat.MaxLength = 10;
            this.textBoxHighVbat.Name = "textBoxHighVbat";
            this.textBoxHighVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxHighVbat.TabIndex = 17;
            // 
            // textBoxMidVbat
            // 
            this.textBoxMidVbat.Location = new System.Drawing.Point(353, 231);
            this.textBoxMidVbat.MaxLength = 10;
            this.textBoxMidVbat.Name = "textBoxMidVbat";
            this.textBoxMidVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxMidVbat.TabIndex = 15;
            // 
            // textBoxLowVbat
            // 
            this.textBoxLowVbat.Location = new System.Drawing.Point(353, 202);
            this.textBoxLowVbat.MaxLength = 10;
            this.textBoxLowVbat.Name = "textBoxLowVbat";
            this.textBoxLowVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxLowVbat.TabIndex = 13;
            // 
            // textBoxHighVin
            // 
            this.textBoxHighVin.Location = new System.Drawing.Point(353, 382);
            this.textBoxHighVin.MaxLength = 10;
            this.textBoxHighVin.Name = "textBoxHighVin";
            this.textBoxHighVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxHighVin.TabIndex = 16;
            // 
            // textBoxMidVin
            // 
            this.textBoxMidVin.Location = new System.Drawing.Point(353, 353);
            this.textBoxMidVin.MaxLength = 10;
            this.textBoxMidVin.Name = "textBoxMidVin";
            this.textBoxMidVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxMidVin.TabIndex = 14;
            // 
            // textBoxLowVin
            // 
            this.textBoxLowVin.Location = new System.Drawing.Point(353, 324);
            this.textBoxLowVin.MaxLength = 10;
            this.textBoxLowVin.Name = "textBoxLowVin";
            this.textBoxLowVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxLowVin.TabIndex = 12;
            // 
            // textBoxHighAmp
            // 
            this.textBoxHighAmp.Location = new System.Drawing.Point(353, 147);
            this.textBoxHighAmp.MaxLength = 10;
            this.textBoxHighAmp.Name = "textBoxHighAmp";
            this.textBoxHighAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxHighAmp.TabIndex = 11;
            // 
            // textBoxMidAmp
            // 
            this.textBoxMidAmp.Location = new System.Drawing.Point(353, 118);
            this.textBoxMidAmp.MaxLength = 10;
            this.textBoxMidAmp.Name = "textBoxMidAmp";
            this.textBoxMidAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxMidAmp.TabIndex = 10;
            // 
            // textBoxLowAmp
            // 
            this.textBoxLowAmp.Location = new System.Drawing.Point(353, 89);
            this.textBoxLowAmp.MaxLength = 10;
            this.textBoxLowAmp.Name = "textBoxLowAmp";
            this.textBoxLowAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxLowAmp.TabIndex = 9;
            // 
            // buttonHighVbat
            // 
            this.buttonHighVbat.Location = new System.Drawing.Point(205, 258);
            this.buttonHighVbat.Name = "buttonHighVbat";
            this.buttonHighVbat.Size = new System.Drawing.Size(75, 23);
            this.buttonHighVbat.TabIndex = 5;
            this.buttonHighVbat.Text = "High";
            this.buttonHighVbat.UseVisualStyleBackColor = true;
            this.buttonHighVbat.Click += new System.EventHandler(this.ButtonHighVbat_Click);
            // 
            // buttonMidVbat
            // 
            this.buttonMidVbat.Location = new System.Drawing.Point(205, 229);
            this.buttonMidVbat.Name = "buttonMidVbat";
            this.buttonMidVbat.Size = new System.Drawing.Size(75, 23);
            this.buttonMidVbat.TabIndex = 4;
            this.buttonMidVbat.Text = "Middle";
            this.buttonMidVbat.UseVisualStyleBackColor = true;
            this.buttonMidVbat.Click += new System.EventHandler(this.ButtonMidVbat_Click);
            // 
            // buttonLowVbat
            // 
            this.buttonLowVbat.Location = new System.Drawing.Point(205, 200);
            this.buttonLowVbat.Name = "buttonLowVbat";
            this.buttonLowVbat.Size = new System.Drawing.Size(75, 23);
            this.buttonLowVbat.TabIndex = 3;
            this.buttonLowVbat.Text = "Low";
            this.buttonLowVbat.UseVisualStyleBackColor = true;
            this.buttonLowVbat.Click += new System.EventHandler(this.ButtonLowVbat_Click);
            // 
            // buttonHighA
            // 
            this.buttonHighA.Location = new System.Drawing.Point(204, 145);
            this.buttonHighA.Name = "buttonHighA";
            this.buttonHighA.Size = new System.Drawing.Size(75, 23);
            this.buttonHighA.TabIndex = 2;
            this.buttonHighA.Text = "High";
            this.buttonHighA.UseVisualStyleBackColor = true;
            this.buttonHighA.Click += new System.EventHandler(this.buttonHighA_Click);
            // 
            // buttonMidA
            // 
            this.buttonMidA.Location = new System.Drawing.Point(204, 116);
            this.buttonMidA.Name = "buttonMidA";
            this.buttonMidA.Size = new System.Drawing.Size(75, 23);
            this.buttonMidA.TabIndex = 1;
            this.buttonMidA.Text = "Middle";
            this.buttonMidA.UseVisualStyleBackColor = true;
            this.buttonMidA.Click += new System.EventHandler(this.buttonMidA_Click);
            // 
            // buttonLowA
            // 
            this.buttonLowA.Location = new System.Drawing.Point(204, 87);
            this.buttonLowA.Name = "buttonLowA";
            this.buttonLowA.Size = new System.Drawing.Size(75, 23);
            this.buttonLowA.TabIndex = 0;
            this.buttonLowA.Text = "Low";
            this.buttonLowA.UseVisualStyleBackColor = true;
            this.buttonLowA.Click += new System.EventHandler(this.buttonLowA_Click);
            // 
            // buttonReadCalibration
            // 
            this.buttonReadCalibration.Location = new System.Drawing.Point(452, 30);
            this.buttonReadCalibration.Name = "buttonReadCalibration";
            this.buttonReadCalibration.Size = new System.Drawing.Size(108, 42);
            this.buttonReadCalibration.TabIndex = 6;
            this.buttonReadCalibration.Text = "Read Calibration from Flash";
            this.buttonReadCalibration.UseVisualStyleBackColor = true;
            this.buttonReadCalibration.Click += new System.EventHandler(this.buttonReadCalibration_Click);
            // 
            // buttonWriteCalibration
            // 
            this.buttonWriteCalibration.Location = new System.Drawing.Point(452, 148);
            this.buttonWriteCalibration.Name = "buttonWriteCalibration";
            this.buttonWriteCalibration.Size = new System.Drawing.Size(108, 42);
            this.buttonWriteCalibration.TabIndex = 8;
            this.buttonWriteCalibration.Text = "Write Calibration to Flash";
            this.buttonWriteCalibration.UseVisualStyleBackColor = true;
            this.buttonWriteCalibration.Click += new System.EventHandler(this.buttonWriteCalibration_Click);
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Controls.Add(this.label42);
            this.tabPageAdvanced.Controls.Add(this.label43);
            this.tabPageAdvanced.Controls.Add(this.label44);
            this.tabPageAdvanced.Controls.Add(this.labelRapidChargeTimerLive);
            this.tabPageAdvanced.Controls.Add(this.labelRestoreTimerLive);
            this.tabPageAdvanced.Controls.Add(this.label33);
            this.tabPageAdvanced.Controls.Add(this.labeldtdtCountLive);
            this.tabPageAdvanced.Controls.Add(this.label29);
            this.tabPageAdvanced.Controls.Add(this.labeldTdtLive);
            this.tabPageAdvanced.Controls.Add(this.label25);
            this.tabPageAdvanced.Controls.Add(this.labelPCBtypeLive);
            this.tabPageAdvanced.Controls.Add(this.label24);
            this.tabPageAdvanced.Controls.Add(this.labelPackTemperatureReadLive);
            this.tabPageAdvanced.Controls.Add(this.label26);
            this.tabPageAdvanced.Controls.Add(this.labelChargerStatusLive);
            this.tabPageAdvanced.Controls.Add(this.label28);
            this.tabPageAdvanced.Controls.Add(this.labelProfileChargerStateLive);
            this.tabPageAdvanced.Controls.Add(this.labelProfileInputVoltageLive);
            this.tabPageAdvanced.Controls.Add(this.labelProfilePackCurrentLive);
            this.tabPageAdvanced.Controls.Add(this.labelProfilePackVoltageLive);
            this.tabPageAdvanced.Controls.Add(this.label36);
            this.tabPageAdvanced.Controls.Add(this.label38);
            this.tabPageAdvanced.Controls.Add(this.label39);
            this.tabPageAdvanced.Controls.Add(this.label40);
            this.tabPageAdvanced.Controls.Add(this.ButtonUpdateCurrentValues);
            this.tabPageAdvanced.Controls.Add(this.textBox3);
            this.tabPageAdvanced.Controls.Add(this.textBox2);
            this.tabPageAdvanced.Controls.Add(this.ButtonDefaultCalValues);
            this.tabPageAdvanced.Controls.Add(this.ButtonWriteHFile);
            this.tabPageAdvanced.Controls.Add(this.textBox1);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(630, 728);
            this.tabPageAdvanced.TabIndex = 3;
            this.tabPageAdvanced.Text = "Advanced";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(157, 429);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(0, 13);
            this.label42.TabIndex = 49;
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(20, 429);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(136, 15);
            this.label43.TabIndex = 48;
            this.label43.Text = "Charge Time:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(157, 406);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(0, 13);
            this.label44.TabIndex = 47;
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRapidChargeTimerLive
            // 
            this.labelRapidChargeTimerLive.Location = new System.Drawing.Point(20, 406);
            this.labelRapidChargeTimerLive.Name = "labelRapidChargeTimerLive";
            this.labelRapidChargeTimerLive.Size = new System.Drawing.Size(136, 15);
            this.labelRapidChargeTimerLive.TabIndex = 46;
            this.labelRapidChargeTimerLive.Text = "Rapid Charge Timer:";
            this.labelRapidChargeTimerLive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRestoreTimerLive
            // 
            this.labelRestoreTimerLive.AutoSize = true;
            this.labelRestoreTimerLive.Location = new System.Drawing.Point(157, 406);
            this.labelRestoreTimerLive.Name = "labelRestoreTimerLive";
            this.labelRestoreTimerLive.Size = new System.Drawing.Size(0, 13);
            this.labelRestoreTimerLive.TabIndex = 43;
            this.labelRestoreTimerLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(20, 406);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(136, 15);
            this.label33.TabIndex = 42;
            this.label33.Text = "Restore Timer:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labeldtdtCountLive
            // 
            this.labeldtdtCountLive.AutoSize = true;
            this.labeldtdtCountLive.Location = new System.Drawing.Point(157, 383);
            this.labeldtdtCountLive.Name = "labeldtdtCountLive";
            this.labeldtdtCountLive.Size = new System.Drawing.Size(0, 13);
            this.labeldtdtCountLive.TabIndex = 41;
            this.labeldtdtCountLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(20, 383);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(136, 15);
            this.label29.TabIndex = 40;
            this.label29.Text = "dT/dt Count:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labeldTdtLive
            // 
            this.labeldTdtLive.AutoSize = true;
            this.labeldTdtLive.Location = new System.Drawing.Point(157, 360);
            this.labeldTdtLive.Name = "labeldTdtLive";
            this.labeldTdtLive.Size = new System.Drawing.Size(0, 13);
            this.labeldTdtLive.TabIndex = 39;
            this.labeldTdtLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(20, 360);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(136, 15);
            this.label25.TabIndex = 38;
            this.label25.Text = "dT/dt:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPCBtypeLive
            // 
            this.labelPCBtypeLive.AutoSize = true;
            this.labelPCBtypeLive.Location = new System.Drawing.Point(402, 242);
            this.labelPCBtypeLive.Name = "labelPCBtypeLive";
            this.labelPCBtypeLive.Size = new System.Drawing.Size(60, 13);
            this.labelPCBtypeLive.TabIndex = 37;
            this.labelPCBtypeLive.Text = "MCP19111";
            this.labelPCBtypeLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(333, 242);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 13);
            this.label24.TabIndex = 36;
            this.label24.Text = "PCB Type:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPackTemperatureReadLive
            // 
            this.labelPackTemperatureReadLive.AutoSize = true;
            this.labelPackTemperatureReadLive.Location = new System.Drawing.Point(157, 337);
            this.labelPackTemperatureReadLive.Name = "labelPackTemperatureReadLive";
            this.labelPackTemperatureReadLive.Size = new System.Drawing.Size(49, 13);
            this.labelPackTemperatureReadLive.TabIndex = 35;
            this.labelPackTemperatureReadLive.Text = "25.4 deg";
            this.labelPackTemperatureReadLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(20, 337);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(136, 15);
            this.label26.TabIndex = 34;
            this.label26.Text = "Pack Temperature:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChargerStatusLive
            // 
            this.labelChargerStatusLive.AutoSize = true;
            this.labelChargerStatusLive.Location = new System.Drawing.Point(402, 287);
            this.labelChargerStatusLive.Name = "labelChargerStatusLive";
            this.labelChargerStatusLive.Size = new System.Drawing.Size(36, 13);
            this.labelChargerStatusLive.TabIndex = 33;
            this.labelChargerStatusLive.Text = "UVLO";
            this.labelChargerStatusLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(288, 287);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(108, 15);
            this.label28.TabIndex = 32;
            this.label28.Text = "Charger Status:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelProfileChargerStateLive
            // 
            this.labelProfileChargerStateLive.AutoSize = true;
            this.labelProfileChargerStateLive.Location = new System.Drawing.Point(402, 263);
            this.labelProfileChargerStateLive.Name = "labelProfileChargerStateLive";
            this.labelProfileChargerStateLive.Size = new System.Drawing.Size(79, 13);
            this.labelProfileChargerStateLive.TabIndex = 31;
            this.labelProfileChargerStateLive.Text = "Prequalification";
            this.labelProfileChargerStateLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfileInputVoltageLive
            // 
            this.labelProfileInputVoltageLive.AutoSize = true;
            this.labelProfileInputVoltageLive.Location = new System.Drawing.Point(157, 289);
            this.labelProfileInputVoltageLive.Name = "labelProfileInputVoltageLive";
            this.labelProfileInputVoltageLive.Size = new System.Drawing.Size(38, 13);
            this.labelProfileInputVoltageLive.TabIndex = 29;
            this.labelProfileInputVoltageLive.Text = "25.6 V";
            this.labelProfileInputVoltageLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfilePackCurrentLive
            // 
            this.labelProfilePackCurrentLive.AutoSize = true;
            this.labelProfilePackCurrentLive.Location = new System.Drawing.Point(157, 265);
            this.labelProfilePackCurrentLive.Name = "labelProfilePackCurrentLive";
            this.labelProfilePackCurrentLive.Size = new System.Drawing.Size(44, 13);
            this.labelProfilePackCurrentLive.TabIndex = 28;
            this.labelProfilePackCurrentLive.Text = "6.023 A";
            this.labelProfilePackCurrentLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfilePackVoltageLive
            // 
            this.labelProfilePackVoltageLive.AutoSize = true;
            this.labelProfilePackVoltageLive.Location = new System.Drawing.Point(157, 242);
            this.labelProfilePackVoltageLive.Name = "labelProfilePackVoltageLive";
            this.labelProfilePackVoltageLive.Size = new System.Drawing.Size(38, 13);
            this.labelProfilePackVoltageLive.TabIndex = 27;
            this.labelProfilePackVoltageLive.Text = "88.8 V";
            this.labelProfilePackVoltageLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(304, 263);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(92, 15);
            this.label36.TabIndex = 26;
            this.label36.Text = "Charger State:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(74, 288);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(82, 13);
            this.label38.TabIndex = 24;
            this.label38.Text = "Input Voltage:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(74, 265);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(82, 13);
            this.label39.TabIndex = 23;
            this.label39.Text = "Pack Current:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(74, 242);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(82, 13);
            this.label40.TabIndex = 22;
            this.label40.Text = "Pack Voltage:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonUpdateCurrentValues
            // 
            this.ButtonUpdateCurrentValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUpdateCurrentValues.Location = new System.Drawing.Point(64, 179);
            this.ButtonUpdateCurrentValues.Name = "ButtonUpdateCurrentValues";
            this.ButtonUpdateCurrentValues.Size = new System.Drawing.Size(215, 34);
            this.ButtonUpdateCurrentValues.TabIndex = 21;
            this.ButtonUpdateCurrentValues.Text = "Update Live Board Data";
            this.ButtonUpdateCurrentValues.UseVisualStyleBackColor = true;
            this.ButtonUpdateCurrentValues.Click += new System.EventHandler(this.ButtonUpdateCurrentValues_Click_1);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(288, 178);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(191, 35);
            this.textBox3.TabIndex = 20;
            this.textBox3.Text = "Update current live data from PCB";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(288, 86);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(191, 35);
            this.textBox2.TabIndex = 20;
            this.textBox2.Text = "Load Default calibrations values for MCP19111 Reference Design PCB";
            // 
            // ButtonDefaultCalValues
            // 
            this.ButtonDefaultCalValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDefaultCalValues.Location = new System.Drawing.Point(64, 85);
            this.ButtonDefaultCalValues.Name = "ButtonDefaultCalValues";
            this.ButtonDefaultCalValues.Size = new System.Drawing.Size(218, 36);
            this.ButtonDefaultCalValues.TabIndex = 19;
            this.ButtonDefaultCalValues.Text = "Use Default Calibration Values";
            this.ButtonDefaultCalValues.UseVisualStyleBackColor = true;
            this.ButtonDefaultCalValues.Click += new System.EventHandler(this.ButtonDefaultCalValues_Click);
            // 
            // ButtonWriteHFile
            // 
            this.ButtonWriteHFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonWriteHFile.Location = new System.Drawing.Point(64, 39);
            this.ButtonWriteHFile.Name = "ButtonWriteHFile";
            this.ButtonWriteHFile.Size = new System.Drawing.Size(186, 32);
            this.ButtonWriteHFile.TabIndex = 18;
            this.ButtonWriteHFile.Text = "Write .H Configuration File";
            this.ButtonWriteHFile.UseVisualStyleBackColor = true;
            this.ButtonWriteHFile.Click += new System.EventHandler(this.ButtonWriteHFileClick);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(256, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 35);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Export Configuration and Calibration data to a .H file for Hard-Coded Designs";
            // 
            // TabPagePeakPoke
            // 
            this.TabPagePeakPoke.Controls.Add(this.SFR_Drop_Down);
            this.TabPagePeakPoke.Controls.Add(labelFlashData);
            this.TabPagePeakPoke.Controls.Add(labelFlashAddress);
            this.TabPagePeakPoke.Controls.Add(labelFlashPeakPoke);
            this.TabPagePeakPoke.Controls.Add(this.textBoxFlashData);
            this.TabPagePeakPoke.Controls.Add(this.textBoxFlashAddress);
            this.TabPagePeakPoke.Controls.Add(this.buttonPokeFlash);
            this.TabPagePeakPoke.Controls.Add(this.buttonPeakFlash);
            this.TabPagePeakPoke.Controls.Add(labelSFRData);
            this.TabPagePeakPoke.Controls.Add(labelSFRAddress);
            this.TabPagePeakPoke.Controls.Add(labelSFRPeakPoke);
            this.TabPagePeakPoke.Controls.Add(this.textBoxSFRData);
            this.TabPagePeakPoke.Controls.Add(this.textBoxSFRAddress);
            this.TabPagePeakPoke.Controls.Add(this.buttonPokeSFR);
            this.TabPagePeakPoke.Controls.Add(this.buttonPeakSFR);
            this.TabPagePeakPoke.Location = new System.Drawing.Point(4, 22);
            this.TabPagePeakPoke.Name = "TabPagePeakPoke";
            this.TabPagePeakPoke.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePeakPoke.Size = new System.Drawing.Size(630, 728);
            this.TabPagePeakPoke.TabIndex = 4;
            this.TabPagePeakPoke.Text = "Peak-Poke";
            this.TabPagePeakPoke.UseVisualStyleBackColor = true;
            // 
            // textBoxFlashData
            // 
            this.textBoxFlashData.Location = new System.Drawing.Point(316, 266);
            this.textBoxFlashData.MaxLength = 16;
            this.textBoxFlashData.Name = "textBoxFlashData";
            this.textBoxFlashData.Size = new System.Drawing.Size(100, 20);
            this.textBoxFlashData.TabIndex = 6;
            // 
            // textBoxFlashAddress
            // 
            this.textBoxFlashAddress.Location = new System.Drawing.Point(86, 266);
            this.textBoxFlashAddress.MaxLength = 8;
            this.textBoxFlashAddress.Name = "textBoxFlashAddress";
            this.textBoxFlashAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxFlashAddress.TabIndex = 4;
            // 
            // buttonPokeFlash
            // 
            this.buttonPokeFlash.Location = new System.Drawing.Point(436, 264);
            this.buttonPokeFlash.Name = "buttonPokeFlash";
            this.buttonPokeFlash.Size = new System.Drawing.Size(75, 23);
            this.buttonPokeFlash.TabIndex = 7;
            this.buttonPokeFlash.Text = "Write";
            this.buttonPokeFlash.UseVisualStyleBackColor = true;
            this.buttonPokeFlash.Click += new System.EventHandler(this.buttonPokeFlash_Click);
            // 
            // buttonPeakFlash
            // 
            this.buttonPeakFlash.Location = new System.Drawing.Point(206, 264);
            this.buttonPeakFlash.Name = "buttonPeakFlash";
            this.buttonPeakFlash.Size = new System.Drawing.Size(75, 23);
            this.buttonPeakFlash.TabIndex = 5;
            this.buttonPeakFlash.Text = "Read";
            this.buttonPeakFlash.UseVisualStyleBackColor = true;
            this.buttonPeakFlash.Click += new System.EventHandler(this.buttonPeakFlash_Click);
            // 
            // textBoxSFRData
            // 
            this.textBoxSFRData.Location = new System.Drawing.Point(316, 101);
            this.textBoxSFRData.MaxLength = 16;
            this.textBoxSFRData.Name = "textBoxSFRData";
            this.textBoxSFRData.Size = new System.Drawing.Size(100, 20);
            this.textBoxSFRData.TabIndex = 2;
            // 
            // textBoxSFRAddress
            // 
            this.textBoxSFRAddress.Location = new System.Drawing.Point(86, 101);
            this.textBoxSFRAddress.MaxLength = 8;
            this.textBoxSFRAddress.Name = "textBoxSFRAddress";
            this.textBoxSFRAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxSFRAddress.TabIndex = 0;
            // 
            // buttonPokeSFR
            // 
            this.buttonPokeSFR.Location = new System.Drawing.Point(436, 99);
            this.buttonPokeSFR.Name = "buttonPokeSFR";
            this.buttonPokeSFR.Size = new System.Drawing.Size(75, 23);
            this.buttonPokeSFR.TabIndex = 3;
            this.buttonPokeSFR.Text = "Write";
            this.buttonPokeSFR.UseVisualStyleBackColor = true;
            this.buttonPokeSFR.Click += new System.EventHandler(this.buttonPokeSFR_Click);
            // 
            // buttonPeakSFR
            // 
            this.buttonPeakSFR.Location = new System.Drawing.Point(206, 99);
            this.buttonPeakSFR.Name = "buttonPeakSFR";
            this.buttonPeakSFR.Size = new System.Drawing.Size(75, 23);
            this.buttonPeakSFR.TabIndex = 1;
            this.buttonPeakSFR.Text = "Read";
            this.buttonPeakSFR.UseVisualStyleBackColor = true;
            this.buttonPeakSFR.Click += new System.EventHandler(this.buttonPeakSFR_Click);
            // 
            // SFR_Drop_Down
            // 
            this.SFR_Drop_Down.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SFR_Drop_Down.FormattingEnabled = true;
            this.SFR_Drop_Down.Location = new System.Drawing.Point(86, 141);
            this.SFR_Drop_Down.Name = "SFR_Drop_Down";
            this.SFR_Drop_Down.Size = new System.Drawing.Size(195, 21);
            this.SFR_Drop_Down.TabIndex = 14;
            this.SFR_Drop_Down.SelectedIndexChanged += new System.EventHandler(this.SFR_Drop_Down_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 778);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "DEPA Battery Charger GUI R4.0";
            this.tabControl1.ResumeLayout(false);
            this.tabPageProfile.ResumeLayout(false);
            this.tabPageProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfile)).EndInit();
            this.tabPageConfigure.ResumeLayout(false);
            this.tabPageConfigure.PerformLayout();
            this.tabPageCalibrate.ResumeLayout(false);
            this.tabPageCalibrate.PerformLayout();
            this.tabPageAdvanced.ResumeLayout(false);
            this.tabPageAdvanced.PerformLayout();
            this.TabPagePeakPoke.ResumeLayout(false);
            this.TabPagePeakPoke.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageConfigure;
        private System.Windows.Forms.TabPage tabPageProfile;
        private System.Windows.Forms.Label labelPackVoltageDisplay;
        private System.Windows.Forms.Button buttonWriteConfiguration;
        private System.Windows.Forms.Button buttonReadConfiguration;
        private System.Windows.Forms.Label labelMaximumChargeTime;
        private System.Windows.Forms.ComboBox comboBoxNumberOfCells;
        private System.Windows.Forms.TextBox textBoxTerminationCurrent;
        private System.Windows.Forms.TextBox textBoxChargeCurrent;
        private System.Windows.Forms.Label labelTermination;
        private System.Windows.Forms.Label labelChargeCurrent;
        private System.Windows.Forms.Label labelNumberSeriesCells;
        private System.Windows.Forms.Label labelCellVoltage;
        private System.Windows.Forms.TextBox textBoxCellVoltage;
        private System.Windows.Forms.Label labelPreconditionCellVoltage;
        private System.Windows.Forms.TextBox textBoxPreconditionCellVoltage;
        private System.Windows.Forms.TextBox textBoxPreconditionCurrent;
        private System.Windows.Forms.Label labelPreconditionCurrent;
        private System.Windows.Forms.Label labelPackVoltage;
        private System.Windows.Forms.TextBox textBoxMaximumChargeTime;
        private System.Windows.Forms.Button buttonProfileStop;
        private System.Windows.Forms.Button buttonProfileStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProfile;
        private System.Windows.Forms.Label labelProfileChargerState;
        private System.Windows.Forms.Label labelProfileChargeTime;
        private System.Windows.Forms.Label labelProfileInputVoltage;
        private System.Windows.Forms.Label labelProfilePackCurrent;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelProfilePackVoltage;
        private System.Windows.Forms.TabPage tabPageCalibrate;
        private System.Windows.Forms.Button buttonBeginCalibration;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxHighVbat;
        private System.Windows.Forms.TextBox textBoxMidVbat;
        private System.Windows.Forms.TextBox textBoxLowVbat;
        private System.Windows.Forms.TextBox textBoxHighVin;
        private System.Windows.Forms.TextBox textBoxMidVin;
        private System.Windows.Forms.TextBox textBoxLowVin;
        private System.Windows.Forms.TextBox textBoxHighAmp;
        private System.Windows.Forms.TextBox textBoxMidAmp;
        private System.Windows.Forms.TextBox textBoxLowAmp;
        private System.Windows.Forms.Button buttonHighVbat;
        private System.Windows.Forms.Button buttonMidVbat;
        private System.Windows.Forms.Button buttonLowVbat;
        private System.Windows.Forms.Button buttonHighA;
        private System.Windows.Forms.Button buttonMidA;
        private System.Windows.Forms.Button buttonLowA;
        private System.Windows.Forms.Button buttonReadCalibration;
        private System.Windows.Forms.Button buttonWriteCalibration;
        private System.Windows.Forms.ComboBox comboBoxChemistry;
        private System.Windows.Forms.TextBox textBoxMaximumTemperature;
        private System.Windows.Forms.TextBox textBoxRestorationChargeTime;
        private System.Windows.Forms.Label labelRestorationTime;
        private System.Windows.Forms.TextBox textBoxRapidChargeTime;
        private System.Windows.Forms.Label labelRapidTime;
        private System.Windows.Forms.Label labelMaximumTemperature;
        private System.Windows.Forms.Label labelMinimumTemperature;
        private System.Windows.Forms.TextBox textBoxMinimumTemperature;
        private System.Windows.Forms.Label labelBatteryChemistry;
        private System.Windows.Forms.CheckBox checkBoxThermistor;
        private System.Windows.Forms.Label labelTerminationVoltage;
        private System.Windows.Forms.TextBox textBoxTerminationVoltage;
        private System.Windows.Forms.Label labelChargerStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelPackTemperatureRead;
        private System.Windows.Forms.Label labelPackTemperature;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.Label labelRecommendedInputRange;
        private System.Windows.Forms.Label labelInputRangeCalculation;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ButtonWriteHFile;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button ButtonDefaultCalValues;
        private System.Windows.Forms.Label labelPCBtype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button ButtonUpdateCurrentValues;
        private System.Windows.Forms.Label labelPCBtypeLive;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label labelPackTemperatureReadLive;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label labelChargerStatusLive;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label labelProfileChargerStateLive;
        private System.Windows.Forms.Label labelProfileInputVoltageLive;
        private System.Windows.Forms.Label labelProfilePackCurrentLive;
        private System.Windows.Forms.Label labelProfilePackVoltageLive;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Button ButtonHighVin;
        private System.Windows.Forms.Button ButtonMidVin;
        private System.Windows.Forms.Button ButtonLowVin;
        private System.Windows.Forms.Label labeldTdtLive;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label labelRapidChargeTimerLive;
        private System.Windows.Forms.Label labelRestoreTimerLive;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label labeldtdtCountLive;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBoxUVLORising;
        private System.Windows.Forms.Label labelWireRes;
        private System.Windows.Forms.Label labelReferenceDesignType;
        private System.Windows.Forms.ComboBox comboBoxPCBType;
        private System.Windows.Forms.Label labelUVLORisingUnits;
        private System.Windows.Forms.Label labelTerminationVoltageUnits;
        private System.Windows.Forms.Label labelMaximumTemperatureUnits;
        private System.Windows.Forms.Label labelMinimumTemperatureUnits;
        private System.Windows.Forms.Label labelRestorationChargeTimeUnits;
        private System.Windows.Forms.Label labelRapidChargeTimeUnits;
        private System.Windows.Forms.Label labelPreconditionVoltageUnits;
        private System.Windows.Forms.Label labelPreconditionCurrentUnits;
        private System.Windows.Forms.Label labelMaximumChargeTimeUnits;
        private System.Windows.Forms.Label labelChargeCurrentUnits;
        private System.Windows.Forms.Label labelTerminationCurrentUnits;
        private System.Windows.Forms.Label labelCellVoltageUnits;
        private System.Windows.Forms.Label labelApproximateResistanceUnits;
        private System.Windows.Forms.TextBox textBoxWireRes;
        private System.Windows.Forms.Label labelUVLORising;
        private System.Windows.Forms.Label labelChargerOutputVoltage;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label labelUVLOFalling;
        private System.Windows.Forms.Label labelUVLOFallingUnits;
        private System.Windows.Forms.TextBox textBoxUVLOFalling;
        private System.Windows.Forms.TextBox textBoxSetHighAmp;
        private System.Windows.Forms.TextBox textBoxSetMidAmp;
        private System.Windows.Forms.TextBox textBoxSetLowAmp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSetHighVbat;
        private System.Windows.Forms.TextBox textBoxSetMidVbat;
        private System.Windows.Forms.TextBox textBoxSetLowVbat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSetHighVin;
        private System.Windows.Forms.TextBox textBoxSetMidVin;
        private System.Windows.Forms.TextBox textBoxSetLowVin;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage TabPagePeakPoke;
        private System.Windows.Forms.TextBox textBoxSFRData;
        private System.Windows.Forms.TextBox textBoxSFRAddress;
        private System.Windows.Forms.Button buttonPokeSFR;
        private System.Windows.Forms.Button buttonPeakSFR;
        private System.Windows.Forms.TextBox textBoxFlashData;
        private System.Windows.Forms.TextBox textBoxFlashAddress;
        private System.Windows.Forms.Button buttonPokeFlash;
        private System.Windows.Forms.Button buttonPeakFlash;
        private System.Windows.Forms.ComboBox SFR_Drop_Down;
    }
}

