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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelFlashData = new System.Windows.Forms.Label();
            this.labelFlashAddress = new System.Windows.Forms.Label();
            this.labelFlashPeakPoke = new System.Windows.Forms.Label();
            this.labelSFRData = new System.Windows.Forms.Label();
            this.labelSFRAddress = new System.Windows.Forms.Label();
            this.labelSFRPeakPoke = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProfile = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.labelProfileChargerOutputVoltage = new System.Windows.Forms.Label();
            this.labelProfilePCBtype = new System.Windows.Forms.Label();
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
            this.panelTempSettings = new System.Windows.Forms.Panel();
            this.textBoxADCVref = new System.Windows.Forms.TextBox();
            this.textBoxADCSize = new System.Windows.Forms.TextBox();
            this.labelADCVref = new System.Windows.Forms.Label();
            this.labelTempADCSize = new System.Windows.Forms.Label();
            this.labelADCSizeUnits = new System.Windows.Forms.Label();
            this.labelADCVrefUnits = new System.Windows.Forms.Label();
            this.labelTempSlopeUnits = new System.Windows.Forms.Label();
            this.labelTempSlope = new System.Windows.Forms.Label();
            this.textBoxTempSlope = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTempCoeff = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMaximumTemperatureUnits = new System.Windows.Forms.Label();
            this.labelMinimumTemperatureUnits = new System.Windows.Forms.Label();
            this.textBoxMaximumTemperature = new System.Windows.Forms.TextBox();
            this.labelMaximumTemperature = new System.Windows.Forms.Label();
            this.labelMinimumTemperature = new System.Windows.Forms.Label();
            this.textBoxMinimumTemperature = new System.Windows.Forms.TextBox();
            this.panelConfigurationControl = new System.Windows.Forms.Panel();
            this.labelFWRev = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxNumberOfCells = new System.Windows.Forms.ComboBox();
            this.labelNumberSeriesCells = new System.Windows.Forms.Label();
            this.labelReferenceDesignType = new System.Windows.Forms.Label();
            this.comboBoxPCBType = new System.Windows.Forms.ComboBox();
            this.checkBoxThermistor = new System.Windows.Forms.CheckBox();
            this.labelBatteryChemistry = new System.Windows.Forms.Label();
            this.comboBoxChemistry = new System.Windows.Forms.ComboBox();
            this.buttonWriteConfiguration = new System.Windows.Forms.Button();
            this.buttonReadConfiguration = new System.Windows.Forms.Button();
            this.panelBasicSettings = new System.Windows.Forms.Panel();
            this.labelPreconditionTimeUnits = new System.Windows.Forms.Label();
            this.labelPreconditionTime = new System.Windows.Forms.Label();
            this.textBoxPreConditionTime = new System.Windows.Forms.TextBox();
            this.labelRestorationChargeTimeUnits = new System.Windows.Forms.Label();
            this.textBoxRestorationChargeTime = new System.Windows.Forms.TextBox();
            this.labelRestorationTime = new System.Windows.Forms.Label();
            this.labelRapidChargeTimeUnits = new System.Windows.Forms.Label();
            this.textBoxRapidChargeTime = new System.Windows.Forms.TextBox();
            this.labelRapidTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMaximumChargeTimeUnits = new System.Windows.Forms.Label();
            this.textBoxMaximumChargeTime = new System.Windows.Forms.TextBox();
            this.labelMaximumChargeTime = new System.Windows.Forms.Label();
            this.labelPreconditionCurrentUnits = new System.Windows.Forms.Label();
            this.textBoxPreconditionCurrent = new System.Windows.Forms.TextBox();
            this.labelPreconditionCurrent = new System.Windows.Forms.Label();
            this.labelChargeCurrentUnits = new System.Windows.Forms.Label();
            this.labelTerminationCurrentUnits = new System.Windows.Forms.Label();
            this.textBoxTerminationCurrent = new System.Windows.Forms.TextBox();
            this.textBoxChargeCurrent = new System.Windows.Forms.TextBox();
            this.labelTermination = new System.Windows.Forms.Label();
            this.labelChargeCurrent = new System.Windows.Forms.Label();
            this.labelTerminationVoltageUnits = new System.Windows.Forms.Label();
            this.labelTerminationVoltage = new System.Windows.Forms.Label();
            this.textBoxTerminationVoltage = new System.Windows.Forms.TextBox();
            this.labelPreconditionVoltageUnits = new System.Windows.Forms.Label();
            this.labelPreconditionCellVoltage = new System.Windows.Forms.Label();
            this.textBoxPreconditionCellVoltage = new System.Windows.Forms.TextBox();
            this.labelCellVoltageUnits = new System.Windows.Forms.Label();
            this.labelCellVoltage = new System.Windows.Forms.Label();
            this.textBoxCellVoltage = new System.Windows.Forms.TextBox();
            this.labelOverVoltageUnits = new System.Windows.Forms.Label();
            this.labelOverVoltage = new System.Windows.Forms.Label();
            this.textBoxOverVoltage = new System.Windows.Forms.TextBox();
            this.panelSystemSettings = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.labelUVLOFalling = new System.Windows.Forms.Label();
            this.labelUVLOFallingUnits = new System.Windows.Forms.Label();
            this.textBoxUVLOFalling = new System.Windows.Forms.TextBox();
            this.labelApproximateResistanceUnits = new System.Windows.Forms.Label();
            this.textBoxWireRes = new System.Windows.Forms.TextBox();
            this.labelUVLORising = new System.Windows.Forms.Label();
            this.labelUVLORisingUnits = new System.Windows.Forms.Label();
            this.textBoxUVLORising = new System.Windows.Forms.TextBox();
            this.labelWireRes = new System.Windows.Forms.Label();
            this.panelVRLANiMH = new System.Windows.Forms.Panel();
            this.labelFloatCurrentUnits = new System.Windows.Forms.Label();
            this.textBoxFloatCurrent = new System.Windows.Forms.TextBox();
            this.labelFloatCurrent = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelFloatVoltageUnits = new System.Windows.Forms.Label();
            this.labelFloatVoltage = new System.Windows.Forms.Label();
            this.textBoxFloatVoltage = new System.Windows.Forms.TextBox();
            this.panelAdvancedUser = new System.Windows.Forms.Panel();
            this.labelPCdVdtCountUnits = new System.Windows.Forms.Label();
            this.labelPCdVdtCount = new System.Windows.Forms.Label();
            this.textBoxPCdVdtCount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labeldtdtSlopeUnits = new System.Windows.Forms.Label();
            this.labeldtdtSlope = new System.Windows.Forms.Label();
            this.textBoxdtdtSlope = new System.Windows.Forms.TextBox();
            this.labeldVdtBlankTimeUnits = new System.Windows.Forms.Label();
            this.labeldVdtBlankTime = new System.Windows.Forms.Label();
            this.textBoxdVdtBlankTime = new System.Windows.Forms.TextBox();
            this.labelCVNegativedIdtUnits = new System.Windows.Forms.Label();
            this.labelCVNegativedIdtCount = new System.Windows.Forms.Label();
            this.textBoxCVNegativedIdtCount = new System.Windows.Forms.TextBox();
            this.labelCCPositivedVdtUnits = new System.Windows.Forms.Label();
            this.labelCCPositivedVdtCount = new System.Windows.Forms.Label();
            this.textBoxCCPositivedVdtCount = new System.Windows.Forms.TextBox();
            this.labelNegativedVdtUnits = new System.Windows.Forms.Label();
            this.labelNegativedVdtCount = new System.Windows.Forms.Label();
            this.textBoxNegativedVdtCount = new System.Windows.Forms.TextBox();
            this.tabPageCalibrate = new System.Windows.Forms.TabPage();
            this.buttonBeginCalibration = new System.Windows.Forms.Button();
            this.buttonReadCalibration = new System.Windows.Forms.Button();
            this.buttonWriteCalibration = new System.Windows.Forms.Button();
            this.panelCalibrationStuff = new System.Windows.Forms.Panel();
            this.textBoxCalTemp = new System.Windows.Forms.TextBox();
            this.buttonCalTemp = new System.Windows.Forms.Button();
            this.labelCalTemp = new System.Windows.Forms.Label();
            this.labelCalTempUnits = new System.Windows.Forms.Label();
            this.textBoxCalTempReading = new System.Windows.Forms.TextBox();
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
            this.labelCalInputVoltage = new System.Windows.Forms.Label();
            this.labelCalBatteryVoltage = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCalVinHighUnits = new System.Windows.Forms.Label();
            this.labelCalChargerCurrent = new System.Windows.Forms.Label();
            this.labelCalVbatHighUnits = new System.Windows.Forms.Label();
            this.labelCalVinMiddleUnits = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.labelCalVbatMiddleUnits = new System.Windows.Forms.Label();
            this.labelCalVinLowUnits = new System.Windows.Forms.Label();
            this.labelCalIoutHighUnits = new System.Windows.Forms.Label();
            this.labelCalVbatLowUnits = new System.Windows.Forms.Label();
            this.labelCalIoutMiddleUnits = new System.Windows.Forms.Label();
            this.labelCalIoutLowUnits = new System.Windows.Forms.Label();
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
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.labelPackTemperatureCountsLive = new System.Windows.Forms.Label();
            this.labelInputVoltageCounts = new System.Windows.Forms.Label();
            this.labelPackCurrentCounts = new System.Windows.Forms.Label();
            this.labelOutputVoltageCounts = new System.Windows.Forms.Label();
            this.labelPreconditionTimerLive = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.labelProfileChargerOutputVoltageLive = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelPosdVbat_dtCountLive = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.labelNegdVbat_dtLive = new System.Windows.Forms.Label();
            this.labelNegdVbat_dtCountLive = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.labeldIdtLive = new System.Windows.Forms.Label();
            this.labeldIdtCountLive = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.labeldtemp_dtLive = new System.Windows.Forms.Label();
            this.labelChargeTimeLive = new System.Windows.Forms.Label();
            this.labelRapidChargeTimerLive = new System.Windows.Forms.Label();
            this.labelRestoreTimerLive = new System.Windows.Forms.Label();
            this.labeldTdtCountLive = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
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
            this.buttonReadSettingsStructure = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.SFR_Drop_Down = new System.Windows.Forms.ComboBox();
            this.textBoxFlashData = new System.Windows.Forms.TextBox();
            this.textBoxFlashAddress = new System.Windows.Forms.TextBox();
            this.buttonPokeFlash = new System.Windows.Forms.Button();
            this.buttonPeakFlash = new System.Windows.Forms.Button();
            this.textBoxSFRData = new System.Windows.Forms.TextBox();
            this.textBoxSFRAddress = new System.Windows.Forms.TextBox();
            this.buttonPokeSFR = new System.Windows.Forms.Button();
            this.buttonPeakSFR = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfile)).BeginInit();
            this.tabPageConfigure.SuspendLayout();
            this.panelTempSettings.SuspendLayout();
            this.panelConfigurationControl.SuspendLayout();
            this.panelBasicSettings.SuspendLayout();
            this.panelSystemSettings.SuspendLayout();
            this.panelVRLANiMH.SuspendLayout();
            this.panelAdvancedUser.SuspendLayout();
            this.tabPageCalibrate.SuspendLayout();
            this.panelCalibrationStuff.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.TabPagePeakPoke.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFlashData
            // 
            this.labelFlashData.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.labelFlashData.AutoSize = true;
            this.labelFlashData.CausesValidation = false;
            this.labelFlashData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFlashData.Location = new System.Drawing.Point(344, 243);
            this.labelFlashData.Name = "labelFlashData";
            this.labelFlashData.Size = new System.Drawing.Size(44, 20);
            this.labelFlashData.TabIndex = 13;
            this.labelFlashData.Text = "Data";
            // 
            // labelFlashAddress
            // 
            this.labelFlashAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.labelFlashAddress.AutoSize = true;
            this.labelFlashAddress.CausesValidation = false;
            this.labelFlashAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFlashAddress.Location = new System.Drawing.Point(101, 243);
            this.labelFlashAddress.Name = "labelFlashAddress";
            this.labelFlashAddress.Size = new System.Drawing.Size(68, 20);
            this.labelFlashAddress.TabIndex = 12;
            this.labelFlashAddress.Text = "Address";
            // 
            // labelFlashPeakPoke
            // 
            this.labelFlashPeakPoke.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.labelFlashPeakPoke.AutoSize = true;
            this.labelFlashPeakPoke.CausesValidation = false;
            this.labelFlashPeakPoke.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFlashPeakPoke.Location = new System.Drawing.Point(191, 195);
            this.labelFlashPeakPoke.Name = "labelFlashPeakPoke";
            this.labelFlashPeakPoke.Size = new System.Drawing.Size(197, 25);
            this.labelFlashPeakPoke.TabIndex = 11;
            this.labelFlashPeakPoke.Text = "Flash Peak & Poke";
            // 
            // labelSFRData
            // 
            this.labelSFRData.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.labelSFRData.AutoSize = true;
            this.labelSFRData.CausesValidation = false;
            this.labelSFRData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSFRData.Location = new System.Drawing.Point(344, 78);
            this.labelSFRData.Name = "labelSFRData";
            this.labelSFRData.Size = new System.Drawing.Size(44, 20);
            this.labelSFRData.TabIndex = 6;
            this.labelSFRData.Text = "Data";
            // 
            // labelSFRAddress
            // 
            this.labelSFRAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.labelSFRAddress.AutoSize = true;
            this.labelSFRAddress.CausesValidation = false;
            this.labelSFRAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSFRAddress.Location = new System.Drawing.Point(101, 78);
            this.labelSFRAddress.Name = "labelSFRAddress";
            this.labelSFRAddress.Size = new System.Drawing.Size(68, 20);
            this.labelSFRAddress.TabIndex = 5;
            this.labelSFRAddress.Text = "Address";
            // 
            // labelSFRPeakPoke
            // 
            this.labelSFRPeakPoke.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.labelSFRPeakPoke.AutoSize = true;
            this.labelSFRPeakPoke.CausesValidation = false;
            this.labelSFRPeakPoke.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSFRPeakPoke.Location = new System.Drawing.Point(154, 33);
            this.labelSFRPeakPoke.Name = "labelSFRPeakPoke";
            this.labelSFRPeakPoke.Size = new System.Drawing.Size(279, 25);
            this.labelSFRPeakPoke.TabIndex = 4;
            this.labelSFRPeakPoke.Text = "SFR Register Peak & Poke";
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
            this.tabControl1.Size = new System.Drawing.Size(638, 810);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.handlerSelectedIndexChanged);
            // 
            // tabPageProfile
            // 
            this.tabPageProfile.Controls.Add(this.label32);
            this.tabPageProfile.Controls.Add(this.labelProfileChargerOutputVoltage);
            this.tabPageProfile.Controls.Add(this.labelProfilePCBtype);
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
            this.tabPageProfile.Size = new System.Drawing.Size(630, 784);
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
            // labelProfileChargerOutputVoltage
            // 
            this.labelProfileChargerOutputVoltage.AutoSize = true;
            this.labelProfileChargerOutputVoltage.Location = new System.Drawing.Point(159, 18);
            this.labelProfileChargerOutputVoltage.Name = "labelProfileChargerOutputVoltage";
            this.labelProfileChargerOutputVoltage.Size = new System.Drawing.Size(38, 13);
            this.labelProfileChargerOutputVoltage.TabIndex = 20;
            this.labelProfileChargerOutputVoltage.Text = "88.8 V";
            this.labelProfileChargerOutputVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfilePCBtype
            // 
            this.labelProfilePCBtype.AutoSize = true;
            this.labelProfilePCBtype.Location = new System.Drawing.Point(159, 101);
            this.labelProfilePCBtype.Name = "labelProfilePCBtype";
            this.labelProfilePCBtype.Size = new System.Drawing.Size(60, 13);
            this.labelProfilePCBtype.TabIndex = 19;
            this.labelProfilePCBtype.Text = "MCP19111";
            this.labelProfilePCBtype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.labelPackTemperatureRead.Size = new System.Drawing.Size(27, 13);
            this.labelPackTemperatureRead.TabIndex = 17;
            this.labelPackTemperatureRead.Text = "0 °C";
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
            this.tabPageConfigure.Controls.Add(this.panelTempSettings);
            this.tabPageConfigure.Controls.Add(this.panelConfigurationControl);
            this.tabPageConfigure.Controls.Add(this.panelBasicSettings);
            this.tabPageConfigure.Controls.Add(this.panelSystemSettings);
            this.tabPageConfigure.Controls.Add(this.panelVRLANiMH);
            this.tabPageConfigure.Controls.Add(this.panelAdvancedUser);
            this.tabPageConfigure.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfigure.Name = "tabPageConfigure";
            this.tabPageConfigure.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfigure.Size = new System.Drawing.Size(630, 784);
            this.tabPageConfigure.TabIndex = 0;
            this.tabPageConfigure.Text = "Configure";
            this.tabPageConfigure.UseVisualStyleBackColor = true;
            // 
            // panelTempSettings
            // 
            this.panelTempSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTempSettings.Controls.Add(this.textBoxADCVref);
            this.panelTempSettings.Controls.Add(this.textBoxADCSize);
            this.panelTempSettings.Controls.Add(this.labelADCVref);
            this.panelTempSettings.Controls.Add(this.labelTempADCSize);
            this.panelTempSettings.Controls.Add(this.labelADCSizeUnits);
            this.panelTempSettings.Controls.Add(this.labelADCVrefUnits);
            this.panelTempSettings.Controls.Add(this.labelTempSlopeUnits);
            this.panelTempSettings.Controls.Add(this.labelTempSlope);
            this.panelTempSettings.Controls.Add(this.textBoxTempSlope);
            this.panelTempSettings.Controls.Add(this.label9);
            this.panelTempSettings.Controls.Add(this.label1);
            this.panelTempSettings.Controls.Add(this.textBoxTempCoeff);
            this.panelTempSettings.Controls.Add(this.label2);
            this.panelTempSettings.Controls.Add(this.labelMaximumTemperatureUnits);
            this.panelTempSettings.Controls.Add(this.labelMinimumTemperatureUnits);
            this.panelTempSettings.Controls.Add(this.textBoxMaximumTemperature);
            this.panelTempSettings.Controls.Add(this.labelMaximumTemperature);
            this.panelTempSettings.Controls.Add(this.labelMinimumTemperature);
            this.panelTempSettings.Controls.Add(this.textBoxMinimumTemperature);
            this.panelTempSettings.Location = new System.Drawing.Point(28, 547);
            this.panelTempSettings.Name = "panelTempSettings";
            this.panelTempSettings.Size = new System.Drawing.Size(277, 222);
            this.panelTempSettings.TabIndex = 100;
            // 
            // textBoxADCVref
            // 
            this.textBoxADCVref.Location = new System.Drawing.Point(172, 163);
            this.textBoxADCVref.Name = "textBoxADCVref";
            this.textBoxADCVref.Size = new System.Drawing.Size(44, 20);
            this.textBoxADCVref.TabIndex = 24;
            this.textBoxADCVref.Text = "5.0";
            // 
            // textBoxADCSize
            // 
            this.textBoxADCSize.Location = new System.Drawing.Point(172, 136);
            this.textBoxADCSize.Name = "textBoxADCSize";
            this.textBoxADCSize.Size = new System.Drawing.Size(44, 20);
            this.textBoxADCSize.TabIndex = 23;
            this.textBoxADCSize.Text = "10";
            // 
            // labelADCVref
            // 
            this.labelADCVref.AutoSize = true;
            this.labelADCVref.Location = new System.Drawing.Point(45, 166);
            this.labelADCVref.Name = "labelADCVref";
            this.labelADCVref.Size = new System.Drawing.Size(124, 13);
            this.labelADCVref.TabIndex = 183;
            this.labelADCVref.Text = "ADC Voltage Reference:";
            // 
            // labelTempADCSize
            // 
            this.labelTempADCSize.AutoSize = true;
            this.labelTempADCSize.Location = new System.Drawing.Point(74, 139);
            this.labelTempADCSize.Name = "labelTempADCSize";
            this.labelTempADCSize.Size = new System.Drawing.Size(95, 13);
            this.labelTempADCSize.TabIndex = 182;
            this.labelTempADCSize.Text = "ADC Counter Size:";
            // 
            // labelADCSizeUnits
            // 
            this.labelADCSizeUnits.AutoSize = true;
            this.labelADCSizeUnits.Location = new System.Drawing.Point(219, 139);
            this.labelADCSizeUnits.Name = "labelADCSizeUnits";
            this.labelADCSizeUnits.Size = new System.Drawing.Size(23, 13);
            this.labelADCSizeUnits.TabIndex = 181;
            this.labelADCSizeUnits.Text = "bits";
            this.labelADCSizeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelADCVrefUnits
            // 
            this.labelADCVrefUnits.AutoSize = true;
            this.labelADCVrefUnits.Location = new System.Drawing.Point(219, 166);
            this.labelADCVrefUnits.Name = "labelADCVrefUnits";
            this.labelADCVrefUnits.Size = new System.Drawing.Size(26, 13);
            this.labelADCVrefUnits.TabIndex = 180;
            this.labelADCVrefUnits.Text = "Vref";
            this.labelADCVrefUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTempSlopeUnits
            // 
            this.labelTempSlopeUnits.AutoSize = true;
            this.labelTempSlopeUnits.Location = new System.Drawing.Point(219, 113);
            this.labelTempSlopeUnits.Name = "labelTempSlopeUnits";
            this.labelTempSlopeUnits.Size = new System.Drawing.Size(30, 13);
            this.labelTempSlopeUnits.TabIndex = 179;
            this.labelTempSlopeUnits.Text = "V/°C";
            this.labelTempSlopeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTempSlope
            // 
            this.labelTempSlope.Location = new System.Drawing.Point(41, 113);
            this.labelTempSlope.Name = "labelTempSlope";
            this.labelTempSlope.Size = new System.Drawing.Size(128, 13);
            this.labelTempSlope.TabIndex = 178;
            this.labelTempSlope.Text = "Temperature Slope:";
            this.labelTempSlope.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxTempSlope
            // 
            this.textBoxTempSlope.Location = new System.Drawing.Point(172, 110);
            this.textBoxTempSlope.Name = "textBoxTempSlope";
            this.textBoxTempSlope.Size = new System.Drawing.Size(44, 20);
            this.textBoxTempSlope.TabIndex = 22;
            this.textBoxTempSlope.Text = "0.010";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(223, 23);
            this.label9.TabIndex = 176;
            this.label9.Text = "Temperature Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "mV/°C";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTempCoeff
            // 
            this.textBoxTempCoeff.Location = new System.Drawing.Point(172, 84);
            this.textBoxTempCoeff.Name = "textBoxTempCoeff";
            this.textBoxTempCoeff.Size = new System.Drawing.Size(44, 20);
            this.textBoxTempCoeff.TabIndex = 21;
            this.textBoxTempCoeff.Text = "0.05";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-5, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 17);
            this.label2.TabIndex = 89;
            this.label2.Text = "Float Voltage Temp Coefficient:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMaximumTemperatureUnits
            // 
            this.labelMaximumTemperatureUnits.AutoSize = true;
            this.labelMaximumTemperatureUnits.Location = new System.Drawing.Point(219, 63);
            this.labelMaximumTemperatureUnits.Name = "labelMaximumTemperatureUnits";
            this.labelMaximumTemperatureUnits.Size = new System.Drawing.Size(18, 13);
            this.labelMaximumTemperatureUnits.TabIndex = 87;
            this.labelMaximumTemperatureUnits.Text = "°C";
            this.labelMaximumTemperatureUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMinimumTemperatureUnits
            // 
            this.labelMinimumTemperatureUnits.AutoSize = true;
            this.labelMinimumTemperatureUnits.Location = new System.Drawing.Point(219, 38);
            this.labelMinimumTemperatureUnits.Name = "labelMinimumTemperatureUnits";
            this.labelMinimumTemperatureUnits.Size = new System.Drawing.Size(18, 13);
            this.labelMinimumTemperatureUnits.TabIndex = 86;
            this.labelMinimumTemperatureUnits.Text = "°C";
            this.labelMinimumTemperatureUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMaximumTemperature
            // 
            this.textBoxMaximumTemperature.Location = new System.Drawing.Point(172, 60);
            this.textBoxMaximumTemperature.Name = "textBoxMaximumTemperature";
            this.textBoxMaximumTemperature.Size = new System.Drawing.Size(44, 20);
            this.textBoxMaximumTemperature.TabIndex = 20;
            this.textBoxMaximumTemperature.Text = "60";
            // 
            // labelMaximumTemperature
            // 
            this.labelMaximumTemperature.Location = new System.Drawing.Point(41, 63);
            this.labelMaximumTemperature.Name = "labelMaximumTemperature";
            this.labelMaximumTemperature.Size = new System.Drawing.Size(128, 13);
            this.labelMaximumTemperature.TabIndex = 85;
            this.labelMaximumTemperature.Text = "Maximum Temperature:";
            this.labelMaximumTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMinimumTemperature
            // 
            this.labelMinimumTemperature.Location = new System.Drawing.Point(41, 38);
            this.labelMinimumTemperature.Name = "labelMinimumTemperature";
            this.labelMinimumTemperature.Size = new System.Drawing.Size(128, 13);
            this.labelMinimumTemperature.TabIndex = 84;
            this.labelMinimumTemperature.Text = "Minimum Temperature:";
            this.labelMinimumTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMinimumTemperature
            // 
            this.textBoxMinimumTemperature.Location = new System.Drawing.Point(172, 35);
            this.textBoxMinimumTemperature.Name = "textBoxMinimumTemperature";
            this.textBoxMinimumTemperature.Size = new System.Drawing.Size(44, 20);
            this.textBoxMinimumTemperature.TabIndex = 19;
            this.textBoxMinimumTemperature.Text = "10";
            // 
            // panelConfigurationControl
            // 
            this.panelConfigurationControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConfigurationControl.Controls.Add(this.labelFWRev);
            this.panelConfigurationControl.Controls.Add(this.label4);
            this.panelConfigurationControl.Controls.Add(this.comboBoxNumberOfCells);
            this.panelConfigurationControl.Controls.Add(this.labelNumberSeriesCells);
            this.panelConfigurationControl.Controls.Add(this.labelReferenceDesignType);
            this.panelConfigurationControl.Controls.Add(this.comboBoxPCBType);
            this.panelConfigurationControl.Controls.Add(this.checkBoxThermistor);
            this.panelConfigurationControl.Controls.Add(this.labelBatteryChemistry);
            this.panelConfigurationControl.Controls.Add(this.comboBoxChemistry);
            this.panelConfigurationControl.Controls.Add(this.buttonWriteConfiguration);
            this.panelConfigurationControl.Controls.Add(this.buttonReadConfiguration);
            this.panelConfigurationControl.Location = new System.Drawing.Point(28, 16);
            this.panelConfigurationControl.Name = "panelConfigurationControl";
            this.panelConfigurationControl.Size = new System.Drawing.Size(572, 147);
            this.panelConfigurationControl.TabIndex = 99;
            // 
            // labelFWRev
            // 
            this.labelFWRev.AutoSize = true;
            this.labelFWRev.Location = new System.Drawing.Point(341, 47);
            this.labelFWRev.Name = "labelFWRev";
            this.labelFWRev.Size = new System.Drawing.Size(34, 13);
            this.labelFWRev.TabIndex = 155;
            this.labelFWRev.Text = "v4.66";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(192, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 23);
            this.label4.TabIndex = 154;
            this.label4.Text = "Hardware Configuration";
            // 
            // comboBoxNumberOfCells
            // 
            this.comboBoxNumberOfCells.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumberOfCells.FormattingEnabled = true;
            this.comboBoxNumberOfCells.Location = new System.Drawing.Point(155, 105);
            this.comboBoxNumberOfCells.Name = "comboBoxNumberOfCells";
            this.comboBoxNumberOfCells.Size = new System.Drawing.Size(61, 21);
            this.comboBoxNumberOfCells.TabIndex = 3;
            // 
            // labelNumberSeriesCells
            // 
            this.labelNumberSeriesCells.Location = new System.Drawing.Point(16, 105);
            this.labelNumberSeriesCells.Name = "labelNumberSeriesCells";
            this.labelNumberSeriesCells.Size = new System.Drawing.Size(136, 18);
            this.labelNumberSeriesCells.TabIndex = 151;
            this.labelNumberSeriesCells.Text = "# Series Connected Cells:";
            this.labelNumberSeriesCells.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelReferenceDesignType
            // 
            this.labelReferenceDesignType.AutoSize = true;
            this.labelReferenceDesignType.Location = new System.Drawing.Point(29, 40);
            this.labelReferenceDesignType.Name = "labelReferenceDesignType";
            this.labelReferenceDesignType.Size = new System.Drawing.Size(123, 13);
            this.labelReferenceDesignType.TabIndex = 66;
            this.labelReferenceDesignType.Text = "Reference Design Type:";
            this.labelReferenceDesignType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPCBType
            // 
            this.comboBoxPCBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPCBType.FormattingEnabled = true;
            this.comboBoxPCBType.Location = new System.Drawing.Point(155, 40);
            this.comboBoxPCBType.Name = "comboBoxPCBType";
            this.comboBoxPCBType.Size = new System.Drawing.Size(179, 21);
            this.comboBoxPCBType.TabIndex = 1;
            this.comboBoxPCBType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPCBType_SelectedIndexChanged);
            // 
            // checkBoxThermistor
            // 
            this.checkBoxThermistor.AutoSize = true;
            this.checkBoxThermistor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxThermistor.Location = new System.Drawing.Point(366, 107);
            this.checkBoxThermistor.Name = "checkBoxThermistor";
            this.checkBoxThermistor.Size = new System.Drawing.Size(169, 17);
            this.checkBoxThermistor.TabIndex = 4;
            this.checkBoxThermistor.Text = "Enable External Temp Sensor:";
            this.checkBoxThermistor.UseVisualStyleBackColor = true;
            this.checkBoxThermistor.CheckedChanged += new System.EventHandler(this.checkBoxThermistor_CheckedChanged);
            // 
            // labelBatteryChemistry
            // 
            this.labelBatteryChemistry.AutoSize = true;
            this.labelBatteryChemistry.Location = new System.Drawing.Point(61, 75);
            this.labelBatteryChemistry.Name = "labelBatteryChemistry";
            this.labelBatteryChemistry.Size = new System.Drawing.Size(91, 13);
            this.labelBatteryChemistry.TabIndex = 63;
            this.labelBatteryChemistry.Text = "Battery Chemistry:";
            // 
            // comboBoxChemistry
            // 
            this.comboBoxChemistry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChemistry.FormattingEnabled = true;
            this.comboBoxChemistry.Location = new System.Drawing.Point(155, 72);
            this.comboBoxChemistry.Name = "comboBoxChemistry";
            this.comboBoxChemistry.Size = new System.Drawing.Size(92, 21);
            this.comboBoxChemistry.TabIndex = 2;
            this.comboBoxChemistry.SelectedIndexChanged += new System.EventHandler(this.comboBoxChemistry_SelectedIndexChanged);
            // 
            // buttonWriteConfiguration
            // 
            this.buttonWriteConfiguration.Location = new System.Drawing.Point(401, 72);
            this.buttonWriteConfiguration.Name = "buttonWriteConfiguration";
            this.buttonWriteConfiguration.Size = new System.Drawing.Size(134, 23);
            this.buttonWriteConfiguration.TabIndex = 33;
            this.buttonWriteConfiguration.Text = "Write Configuration";
            this.buttonWriteConfiguration.UseVisualStyleBackColor = true;
            this.buttonWriteConfiguration.Click += new System.EventHandler(this.buttonWriteConfiguration_Click);
            // 
            // buttonReadConfiguration
            // 
            this.buttonReadConfiguration.Location = new System.Drawing.Point(401, 40);
            this.buttonReadConfiguration.Name = "buttonReadConfiguration";
            this.buttonReadConfiguration.Size = new System.Drawing.Size(134, 23);
            this.buttonReadConfiguration.TabIndex = 32;
            this.buttonReadConfiguration.Text = "Read Configuration";
            this.buttonReadConfiguration.UseVisualStyleBackColor = true;
            this.buttonReadConfiguration.Click += new System.EventHandler(this.buttonReadConfiguration_Click);
            // 
            // panelBasicSettings
            // 
            this.panelBasicSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBasicSettings.Controls.Add(this.labelPreconditionTimeUnits);
            this.panelBasicSettings.Controls.Add(this.labelPreconditionTime);
            this.panelBasicSettings.Controls.Add(this.textBoxPreConditionTime);
            this.panelBasicSettings.Controls.Add(this.labelRestorationChargeTimeUnits);
            this.panelBasicSettings.Controls.Add(this.textBoxRestorationChargeTime);
            this.panelBasicSettings.Controls.Add(this.labelRestorationTime);
            this.panelBasicSettings.Controls.Add(this.labelRapidChargeTimeUnits);
            this.panelBasicSettings.Controls.Add(this.textBoxRapidChargeTime);
            this.panelBasicSettings.Controls.Add(this.labelRapidTime);
            this.panelBasicSettings.Controls.Add(this.label5);
            this.panelBasicSettings.Controls.Add(this.labelMaximumChargeTimeUnits);
            this.panelBasicSettings.Controls.Add(this.textBoxMaximumChargeTime);
            this.panelBasicSettings.Controls.Add(this.labelMaximumChargeTime);
            this.panelBasicSettings.Controls.Add(this.labelPreconditionCurrentUnits);
            this.panelBasicSettings.Controls.Add(this.textBoxPreconditionCurrent);
            this.panelBasicSettings.Controls.Add(this.labelPreconditionCurrent);
            this.panelBasicSettings.Controls.Add(this.labelChargeCurrentUnits);
            this.panelBasicSettings.Controls.Add(this.labelTerminationCurrentUnits);
            this.panelBasicSettings.Controls.Add(this.textBoxTerminationCurrent);
            this.panelBasicSettings.Controls.Add(this.textBoxChargeCurrent);
            this.panelBasicSettings.Controls.Add(this.labelTermination);
            this.panelBasicSettings.Controls.Add(this.labelChargeCurrent);
            this.panelBasicSettings.Controls.Add(this.labelTerminationVoltageUnits);
            this.panelBasicSettings.Controls.Add(this.labelTerminationVoltage);
            this.panelBasicSettings.Controls.Add(this.textBoxTerminationVoltage);
            this.panelBasicSettings.Controls.Add(this.labelPreconditionVoltageUnits);
            this.panelBasicSettings.Controls.Add(this.labelPreconditionCellVoltage);
            this.panelBasicSettings.Controls.Add(this.textBoxPreconditionCellVoltage);
            this.panelBasicSettings.Controls.Add(this.labelCellVoltageUnits);
            this.panelBasicSettings.Controls.Add(this.labelCellVoltage);
            this.panelBasicSettings.Controls.Add(this.textBoxCellVoltage);
            this.panelBasicSettings.Controls.Add(this.labelOverVoltageUnits);
            this.panelBasicSettings.Controls.Add(this.labelOverVoltage);
            this.panelBasicSettings.Controls.Add(this.textBoxOverVoltage);
            this.panelBasicSettings.Location = new System.Drawing.Point(28, 178);
            this.panelBasicSettings.Name = "panelBasicSettings";
            this.panelBasicSettings.Size = new System.Drawing.Size(572, 222);
            this.panelBasicSettings.TabIndex = 98;
            // 
            // labelPreconditionTimeUnits
            // 
            this.labelPreconditionTimeUnits.AutoSize = true;
            this.labelPreconditionTimeUnits.Location = new System.Drawing.Point(511, 192);
            this.labelPreconditionTimeUnits.Name = "labelPreconditionTimeUnits";
            this.labelPreconditionTimeUnits.Size = new System.Drawing.Size(44, 13);
            this.labelPreconditionTimeUnits.TabIndex = 194;
            this.labelPreconditionTimeUnits.Text = "Minutes";
            this.labelPreconditionTimeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPreconditionTime
            // 
            this.labelPreconditionTime.Location = new System.Drawing.Point(297, 192);
            this.labelPreconditionTime.Name = "labelPreconditionTime";
            this.labelPreconditionTime.Size = new System.Drawing.Size(161, 13);
            this.labelPreconditionTime.TabIndex = 193;
            this.labelPreconditionTime.Text = "Maximum Precondition Time:";
            this.labelPreconditionTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPreConditionTime
            // 
            this.textBoxPreConditionTime.Location = new System.Drawing.Point(464, 189);
            this.textBoxPreConditionTime.Name = "textBoxPreConditionTime";
            this.textBoxPreConditionTime.Size = new System.Drawing.Size(44, 20);
            this.textBoxPreConditionTime.TabIndex = 192;
            this.textBoxPreConditionTime.Text = "5";
            // 
            // labelRestorationChargeTimeUnits
            // 
            this.labelRestorationChargeTimeUnits.AutoSize = true;
            this.labelRestorationChargeTimeUnits.Location = new System.Drawing.Point(511, 165);
            this.labelRestorationChargeTimeUnits.Name = "labelRestorationChargeTimeUnits";
            this.labelRestorationChargeTimeUnits.Size = new System.Drawing.Size(44, 13);
            this.labelRestorationChargeTimeUnits.TabIndex = 191;
            this.labelRestorationChargeTimeUnits.Text = "Minutes";
            this.labelRestorationChargeTimeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxRestorationChargeTime
            // 
            this.textBoxRestorationChargeTime.Location = new System.Drawing.Point(464, 162);
            this.textBoxRestorationChargeTime.Name = "textBoxRestorationChargeTime";
            this.textBoxRestorationChargeTime.Size = new System.Drawing.Size(44, 20);
            this.textBoxRestorationChargeTime.TabIndex = 187;
            this.textBoxRestorationChargeTime.Text = "60";
            // 
            // labelRestorationTime
            // 
            this.labelRestorationTime.Location = new System.Drawing.Point(333, 165);
            this.labelRestorationTime.Name = "labelRestorationTime";
            this.labelRestorationTime.Size = new System.Drawing.Size(128, 13);
            this.labelRestorationTime.TabIndex = 190;
            this.labelRestorationTime.Text = "Restoration Charge Time:";
            this.labelRestorationTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRapidChargeTimeUnits
            // 
            this.labelRapidChargeTimeUnits.AutoSize = true;
            this.labelRapidChargeTimeUnits.Location = new System.Drawing.Point(511, 139);
            this.labelRapidChargeTimeUnits.Name = "labelRapidChargeTimeUnits";
            this.labelRapidChargeTimeUnits.Size = new System.Drawing.Size(44, 13);
            this.labelRapidChargeTimeUnits.TabIndex = 189;
            this.labelRapidChargeTimeUnits.Text = "Minutes";
            this.labelRapidChargeTimeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxRapidChargeTime
            // 
            this.textBoxRapidChargeTime.Location = new System.Drawing.Point(464, 136);
            this.textBoxRapidChargeTime.Name = "textBoxRapidChargeTime";
            this.textBoxRapidChargeTime.Size = new System.Drawing.Size(44, 20);
            this.textBoxRapidChargeTime.TabIndex = 186;
            this.textBoxRapidChargeTime.Text = "120";
            // 
            // labelRapidTime
            // 
            this.labelRapidTime.Location = new System.Drawing.Point(333, 139);
            this.labelRapidTime.Name = "labelRapidTime";
            this.labelRapidTime.Size = new System.Drawing.Size(128, 13);
            this.labelRapidTime.TabIndex = 188;
            this.labelRapidTime.Text = "Rapid Charge Time:";
            this.labelRapidTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(201, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 23);
            this.label5.TabIndex = 174;
            this.label5.Text = "Battery Configuration";
            // 
            // labelMaximumChargeTimeUnits
            // 
            this.labelMaximumChargeTimeUnits.AutoSize = true;
            this.labelMaximumChargeTimeUnits.Location = new System.Drawing.Point(511, 113);
            this.labelMaximumChargeTimeUnits.Name = "labelMaximumChargeTimeUnits";
            this.labelMaximumChargeTimeUnits.Size = new System.Drawing.Size(44, 13);
            this.labelMaximumChargeTimeUnits.TabIndex = 173;
            this.labelMaximumChargeTimeUnits.Text = "Minutes";
            this.labelMaximumChargeTimeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMaximumChargeTime
            // 
            this.textBoxMaximumChargeTime.Location = new System.Drawing.Point(464, 110);
            this.textBoxMaximumChargeTime.Name = "textBoxMaximumChargeTime";
            this.textBoxMaximumChargeTime.Size = new System.Drawing.Size(44, 20);
            this.textBoxMaximumChargeTime.TabIndex = 12;
            this.textBoxMaximumChargeTime.Text = "600";
            // 
            // labelMaximumChargeTime
            // 
            this.labelMaximumChargeTime.Location = new System.Drawing.Point(333, 113);
            this.labelMaximumChargeTime.Name = "labelMaximumChargeTime";
            this.labelMaximumChargeTime.Size = new System.Drawing.Size(128, 13);
            this.labelMaximumChargeTime.TabIndex = 172;
            this.labelMaximumChargeTime.Text = "Maximum Charge time:";
            this.labelMaximumChargeTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPreconditionCurrentUnits
            // 
            this.labelPreconditionCurrentUnits.AutoSize = true;
            this.labelPreconditionCurrentUnits.Location = new System.Drawing.Point(511, 61);
            this.labelPreconditionCurrentUnits.Name = "labelPreconditionCurrentUnits";
            this.labelPreconditionCurrentUnits.Size = new System.Drawing.Size(33, 13);
            this.labelPreconditionCurrentUnits.TabIndex = 170;
            this.labelPreconditionCurrentUnits.Text = "Amps";
            this.labelPreconditionCurrentUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPreconditionCurrent
            // 
            this.textBoxPreconditionCurrent.Location = new System.Drawing.Point(464, 58);
            this.textBoxPreconditionCurrent.Name = "textBoxPreconditionCurrent";
            this.textBoxPreconditionCurrent.Size = new System.Drawing.Size(44, 20);
            this.textBoxPreconditionCurrent.TabIndex = 10;
            this.textBoxPreconditionCurrent.Text = "0.200";
            // 
            // labelPreconditionCurrent
            // 
            this.labelPreconditionCurrent.Location = new System.Drawing.Point(330, 61);
            this.labelPreconditionCurrent.Name = "labelPreconditionCurrent";
            this.labelPreconditionCurrent.Size = new System.Drawing.Size(131, 13);
            this.labelPreconditionCurrent.TabIndex = 163;
            this.labelPreconditionCurrent.Text = "Precondition Current:";
            this.labelPreconditionCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChargeCurrentUnits
            // 
            this.labelChargeCurrentUnits.AutoSize = true;
            this.labelChargeCurrentUnits.Location = new System.Drawing.Point(511, 35);
            this.labelChargeCurrentUnits.Name = "labelChargeCurrentUnits";
            this.labelChargeCurrentUnits.Size = new System.Drawing.Size(33, 13);
            this.labelChargeCurrentUnits.TabIndex = 169;
            this.labelChargeCurrentUnits.Text = "Amps";
            this.labelChargeCurrentUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTerminationCurrentUnits
            // 
            this.labelTerminationCurrentUnits.AutoSize = true;
            this.labelTerminationCurrentUnits.Location = new System.Drawing.Point(511, 87);
            this.labelTerminationCurrentUnits.Name = "labelTerminationCurrentUnits";
            this.labelTerminationCurrentUnits.Size = new System.Drawing.Size(33, 13);
            this.labelTerminationCurrentUnits.TabIndex = 168;
            this.labelTerminationCurrentUnits.Text = "Amps";
            this.labelTerminationCurrentUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTerminationCurrent
            // 
            this.textBoxTerminationCurrent.Location = new System.Drawing.Point(464, 84);
            this.textBoxTerminationCurrent.Name = "textBoxTerminationCurrent";
            this.textBoxTerminationCurrent.Size = new System.Drawing.Size(44, 20);
            this.textBoxTerminationCurrent.TabIndex = 11;
            this.textBoxTerminationCurrent.Text = "0.500";
            // 
            // textBoxChargeCurrent
            // 
            this.textBoxChargeCurrent.Location = new System.Drawing.Point(464, 32);
            this.textBoxChargeCurrent.Name = "textBoxChargeCurrent";
            this.textBoxChargeCurrent.Size = new System.Drawing.Size(44, 20);
            this.textBoxChargeCurrent.TabIndex = 9;
            this.textBoxChargeCurrent.Text = "2.000";
            // 
            // labelTermination
            // 
            this.labelTermination.Location = new System.Drawing.Point(330, 87);
            this.labelTermination.Name = "labelTermination";
            this.labelTermination.Size = new System.Drawing.Size(131, 13);
            this.labelTermination.TabIndex = 165;
            this.labelTermination.Text = "Termination Current:";
            this.labelTermination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChargeCurrent
            // 
            this.labelChargeCurrent.Location = new System.Drawing.Point(330, 35);
            this.labelChargeCurrent.Name = "labelChargeCurrent";
            this.labelChargeCurrent.Size = new System.Drawing.Size(131, 13);
            this.labelChargeCurrent.TabIndex = 162;
            this.labelChargeCurrent.Text = "Charge Current:";
            this.labelChargeCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTerminationVoltageUnits
            // 
            this.labelTerminationVoltageUnits.AutoSize = true;
            this.labelTerminationVoltageUnits.Location = new System.Drawing.Point(219, 87);
            this.labelTerminationVoltageUnits.Name = "labelTerminationVoltageUnits";
            this.labelTerminationVoltageUnits.Size = new System.Drawing.Size(30, 13);
            this.labelTerminationVoltageUnits.TabIndex = 161;
            this.labelTerminationVoltageUnits.Text = "Volts";
            this.labelTerminationVoltageUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTerminationVoltage
            // 
            this.labelTerminationVoltage.Location = new System.Drawing.Point(38, 87);
            this.labelTerminationVoltage.Name = "labelTerminationVoltage";
            this.labelTerminationVoltage.Size = new System.Drawing.Size(131, 13);
            this.labelTerminationVoltage.TabIndex = 160;
            this.labelTerminationVoltage.Text = "Cell Termination Voltage:";
            this.labelTerminationVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxTerminationVoltage
            // 
            this.textBoxTerminationVoltage.Location = new System.Drawing.Point(172, 84);
            this.textBoxTerminationVoltage.Name = "textBoxTerminationVoltage";
            this.textBoxTerminationVoltage.Size = new System.Drawing.Size(44, 20);
            this.textBoxTerminationVoltage.TabIndex = 7;
            this.textBoxTerminationVoltage.Text = "1.8";
            // 
            // labelPreconditionVoltageUnits
            // 
            this.labelPreconditionVoltageUnits.AutoSize = true;
            this.labelPreconditionVoltageUnits.Location = new System.Drawing.Point(219, 61);
            this.labelPreconditionVoltageUnits.Name = "labelPreconditionVoltageUnits";
            this.labelPreconditionVoltageUnits.Size = new System.Drawing.Size(30, 13);
            this.labelPreconditionVoltageUnits.TabIndex = 159;
            this.labelPreconditionVoltageUnits.Text = "Volts";
            this.labelPreconditionVoltageUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPreconditionCellVoltage
            // 
            this.labelPreconditionCellVoltage.Location = new System.Drawing.Point(38, 61);
            this.labelPreconditionCellVoltage.Name = "labelPreconditionCellVoltage";
            this.labelPreconditionCellVoltage.Size = new System.Drawing.Size(131, 13);
            this.labelPreconditionCellVoltage.TabIndex = 154;
            this.labelPreconditionCellVoltage.Text = "Cell Precondition Voltage:";
            this.labelPreconditionCellVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPreconditionCellVoltage
            // 
            this.textBoxPreconditionCellVoltage.Location = new System.Drawing.Point(172, 58);
            this.textBoxPreconditionCellVoltage.Name = "textBoxPreconditionCellVoltage";
            this.textBoxPreconditionCellVoltage.Size = new System.Drawing.Size(44, 20);
            this.textBoxPreconditionCellVoltage.TabIndex = 6;
            this.textBoxPreconditionCellVoltage.Text = "3.0";
            // 
            // labelCellVoltageUnits
            // 
            this.labelCellVoltageUnits.AutoSize = true;
            this.labelCellVoltageUnits.Location = new System.Drawing.Point(219, 35);
            this.labelCellVoltageUnits.Name = "labelCellVoltageUnits";
            this.labelCellVoltageUnits.Size = new System.Drawing.Size(30, 13);
            this.labelCellVoltageUnits.TabIndex = 158;
            this.labelCellVoltageUnits.Text = "Volts";
            this.labelCellVoltageUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCellVoltage
            // 
            this.labelCellVoltage.Location = new System.Drawing.Point(38, 35);
            this.labelCellVoltage.Name = "labelCellVoltage";
            this.labelCellVoltage.Size = new System.Drawing.Size(131, 13);
            this.labelCellVoltage.TabIndex = 153;
            this.labelCellVoltage.Text = "Cell Typical Voltage:";
            this.labelCellVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCellVoltage
            // 
            this.textBoxCellVoltage.Location = new System.Drawing.Point(172, 32);
            this.textBoxCellVoltage.Name = "textBoxCellVoltage";
            this.textBoxCellVoltage.Size = new System.Drawing.Size(44, 20);
            this.textBoxCellVoltage.TabIndex = 5;
            this.textBoxCellVoltage.Text = "4.2";
            // 
            // labelOverVoltageUnits
            // 
            this.labelOverVoltageUnits.AutoSize = true;
            this.labelOverVoltageUnits.Location = new System.Drawing.Point(219, 113);
            this.labelOverVoltageUnits.Name = "labelOverVoltageUnits";
            this.labelOverVoltageUnits.Size = new System.Drawing.Size(30, 13);
            this.labelOverVoltageUnits.TabIndex = 152;
            this.labelOverVoltageUnits.Text = "Volts";
            this.labelOverVoltageUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOverVoltage
            // 
            this.labelOverVoltage.Location = new System.Drawing.Point(38, 113);
            this.labelOverVoltage.Name = "labelOverVoltage";
            this.labelOverVoltage.Size = new System.Drawing.Size(131, 13);
            this.labelOverVoltage.TabIndex = 151;
            this.labelOverVoltage.Text = "Cell Over Voltage:";
            this.labelOverVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxOverVoltage
            // 
            this.textBoxOverVoltage.Location = new System.Drawing.Point(172, 110);
            this.textBoxOverVoltage.Name = "textBoxOverVoltage";
            this.textBoxOverVoltage.Size = new System.Drawing.Size(44, 20);
            this.textBoxOverVoltage.TabIndex = 8;
            this.textBoxOverVoltage.Text = "2.5";
            // 
            // panelSystemSettings
            // 
            this.panelSystemSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSystemSettings.Controls.Add(this.label7);
            this.panelSystemSettings.Controls.Add(this.labelUVLOFalling);
            this.panelSystemSettings.Controls.Add(this.labelUVLOFallingUnits);
            this.panelSystemSettings.Controls.Add(this.textBoxUVLOFalling);
            this.panelSystemSettings.Controls.Add(this.labelApproximateResistanceUnits);
            this.panelSystemSettings.Controls.Add(this.textBoxWireRes);
            this.panelSystemSettings.Controls.Add(this.labelUVLORising);
            this.panelSystemSettings.Controls.Add(this.labelUVLORisingUnits);
            this.panelSystemSettings.Controls.Add(this.textBoxUVLORising);
            this.panelSystemSettings.Controls.Add(this.labelWireRes);
            this.panelSystemSettings.Location = new System.Drawing.Point(28, 416);
            this.panelSystemSettings.Name = "panelSystemSettings";
            this.panelSystemSettings.Size = new System.Drawing.Size(277, 116);
            this.panelSystemSettings.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 23);
            this.label7.TabIndex = 175;
            this.label7.Text = "System Configuration";
            // 
            // labelUVLOFalling
            // 
            this.labelUVLOFalling.Location = new System.Drawing.Point(19, 60);
            this.labelUVLOFalling.Name = "labelUVLOFalling";
            this.labelUVLOFalling.Size = new System.Drawing.Size(150, 17);
            this.labelUVLOFalling.TabIndex = 75;
            this.labelUVLOFalling.Text = "Input UVLO Falling Threshold:";
            this.labelUVLOFalling.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelUVLOFallingUnits
            // 
            this.labelUVLOFallingUnits.AutoSize = true;
            this.labelUVLOFallingUnits.Location = new System.Drawing.Point(219, 62);
            this.labelUVLOFallingUnits.Name = "labelUVLOFallingUnits";
            this.labelUVLOFallingUnits.Size = new System.Drawing.Size(30, 13);
            this.labelUVLOFallingUnits.TabIndex = 74;
            this.labelUVLOFallingUnits.Text = "Volts";
            this.labelUVLOFallingUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxUVLOFalling
            // 
            this.textBoxUVLOFalling.Location = new System.Drawing.Point(172, 59);
            this.textBoxUVLOFalling.Name = "textBoxUVLOFalling";
            this.textBoxUVLOFalling.Size = new System.Drawing.Size(44, 20);
            this.textBoxUVLOFalling.TabIndex = 14;
            this.textBoxUVLOFalling.Text = "11";
            // 
            // labelApproximateResistanceUnits
            // 
            this.labelApproximateResistanceUnits.AutoSize = true;
            this.labelApproximateResistanceUnits.Location = new System.Drawing.Point(219, 88);
            this.labelApproximateResistanceUnits.Name = "labelApproximateResistanceUnits";
            this.labelApproximateResistanceUnits.Size = new System.Drawing.Size(42, 13);
            this.labelApproximateResistanceUnits.TabIndex = 73;
            this.labelApproximateResistanceUnits.Text = "mOhms";
            this.labelApproximateResistanceUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxWireRes
            // 
            this.textBoxWireRes.Location = new System.Drawing.Point(172, 85);
            this.textBoxWireRes.Name = "textBoxWireRes";
            this.textBoxWireRes.Size = new System.Drawing.Size(44, 20);
            this.textBoxWireRes.TabIndex = 15;
            this.textBoxWireRes.Text = "100";
            // 
            // labelUVLORising
            // 
            this.labelUVLORising.Location = new System.Drawing.Point(19, 35);
            this.labelUVLORising.Name = "labelUVLORising";
            this.labelUVLORising.Size = new System.Drawing.Size(150, 17);
            this.labelUVLORising.TabIndex = 72;
            this.labelUVLORising.Text = "Input UVLO Rising Threshold:";
            this.labelUVLORising.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelUVLORisingUnits
            // 
            this.labelUVLORisingUnits.AutoSize = true;
            this.labelUVLORisingUnits.Location = new System.Drawing.Point(219, 36);
            this.labelUVLORisingUnits.Name = "labelUVLORisingUnits";
            this.labelUVLORisingUnits.Size = new System.Drawing.Size(30, 13);
            this.labelUVLORisingUnits.TabIndex = 71;
            this.labelUVLORisingUnits.Text = "Volts";
            this.labelUVLORisingUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxUVLORising
            // 
            this.textBoxUVLORising.Location = new System.Drawing.Point(172, 33);
            this.textBoxUVLORising.Name = "textBoxUVLORising";
            this.textBoxUVLORising.Size = new System.Drawing.Size(44, 20);
            this.textBoxUVLORising.TabIndex = 13;
            this.textBoxUVLORising.Text = "12";
            // 
            // labelWireRes
            // 
            this.labelWireRes.Location = new System.Drawing.Point(39, 86);
            this.labelWireRes.Name = "labelWireRes";
            this.labelWireRes.Size = new System.Drawing.Size(130, 17);
            this.labelWireRes.TabIndex = 70;
            this.labelWireRes.Text = "Approximate Resistance:";
            this.labelWireRes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelVRLANiMH
            // 
            this.panelVRLANiMH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVRLANiMH.Controls.Add(this.labelFloatCurrentUnits);
            this.panelVRLANiMH.Controls.Add(this.textBoxFloatCurrent);
            this.panelVRLANiMH.Controls.Add(this.labelFloatCurrent);
            this.panelVRLANiMH.Controls.Add(this.label8);
            this.panelVRLANiMH.Controls.Add(this.labelFloatVoltageUnits);
            this.panelVRLANiMH.Controls.Add(this.labelFloatVoltage);
            this.panelVRLANiMH.Controls.Add(this.textBoxFloatVoltage);
            this.panelVRLANiMH.Location = new System.Drawing.Point(322, 417);
            this.panelVRLANiMH.Name = "panelVRLANiMH";
            this.panelVRLANiMH.Size = new System.Drawing.Size(278, 115);
            this.panelVRLANiMH.TabIndex = 96;
            // 
            // labelFloatCurrentUnits
            // 
            this.labelFloatCurrentUnits.AutoSize = true;
            this.labelFloatCurrentUnits.Location = new System.Drawing.Point(217, 61);
            this.labelFloatCurrentUnits.Name = "labelFloatCurrentUnits";
            this.labelFloatCurrentUnits.Size = new System.Drawing.Size(33, 13);
            this.labelFloatCurrentUnits.TabIndex = 179;
            this.labelFloatCurrentUnits.Text = "Amps";
            this.labelFloatCurrentUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxFloatCurrent
            // 
            this.textBoxFloatCurrent.Location = new System.Drawing.Point(170, 58);
            this.textBoxFloatCurrent.Name = "textBoxFloatCurrent";
            this.textBoxFloatCurrent.Size = new System.Drawing.Size(44, 20);
            this.textBoxFloatCurrent.TabIndex = 177;
            this.textBoxFloatCurrent.Text = "0.200";
            // 
            // labelFloatCurrent
            // 
            this.labelFloatCurrent.Location = new System.Drawing.Point(39, 61);
            this.labelFloatCurrent.Name = "labelFloatCurrent";
            this.labelFloatCurrent.Size = new System.Drawing.Size(128, 13);
            this.labelFloatCurrent.TabIndex = 178;
            this.labelFloatCurrent.Text = "Maximum Float Current:";
            this.labelFloatCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(51, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 23);
            this.label8.TabIndex = 176;
            this.label8.Text = "VRLA Configuration";
            // 
            // labelFloatVoltageUnits
            // 
            this.labelFloatVoltageUnits.AutoSize = true;
            this.labelFloatVoltageUnits.Location = new System.Drawing.Point(217, 36);
            this.labelFloatVoltageUnits.Name = "labelFloatVoltageUnits";
            this.labelFloatVoltageUnits.Size = new System.Drawing.Size(30, 13);
            this.labelFloatVoltageUnits.TabIndex = 148;
            this.labelFloatVoltageUnits.Text = "Volts";
            this.labelFloatVoltageUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFloatVoltage
            // 
            this.labelFloatVoltage.Location = new System.Drawing.Point(36, 36);
            this.labelFloatVoltage.Name = "labelFloatVoltage";
            this.labelFloatVoltage.Size = new System.Drawing.Size(131, 13);
            this.labelFloatVoltage.TabIndex = 147;
            this.labelFloatVoltage.Text = "Cell Float Voltage:";
            this.labelFloatVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxFloatVoltage
            // 
            this.textBoxFloatVoltage.Location = new System.Drawing.Point(170, 33);
            this.textBoxFloatVoltage.Name = "textBoxFloatVoltage";
            this.textBoxFloatVoltage.Size = new System.Drawing.Size(44, 20);
            this.textBoxFloatVoltage.TabIndex = 16;
            this.textBoxFloatVoltage.Text = "1.8";
            // 
            // panelAdvancedUser
            // 
            this.panelAdvancedUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAdvancedUser.Controls.Add(this.labelPCdVdtCountUnits);
            this.panelAdvancedUser.Controls.Add(this.labelPCdVdtCount);
            this.panelAdvancedUser.Controls.Add(this.textBoxPCdVdtCount);
            this.panelAdvancedUser.Controls.Add(this.label11);
            this.panelAdvancedUser.Controls.Add(this.labeldtdtSlopeUnits);
            this.panelAdvancedUser.Controls.Add(this.labeldtdtSlope);
            this.panelAdvancedUser.Controls.Add(this.textBoxdtdtSlope);
            this.panelAdvancedUser.Controls.Add(this.labeldVdtBlankTimeUnits);
            this.panelAdvancedUser.Controls.Add(this.labeldVdtBlankTime);
            this.panelAdvancedUser.Controls.Add(this.textBoxdVdtBlankTime);
            this.panelAdvancedUser.Controls.Add(this.labelCVNegativedIdtUnits);
            this.panelAdvancedUser.Controls.Add(this.labelCVNegativedIdtCount);
            this.panelAdvancedUser.Controls.Add(this.textBoxCVNegativedIdtCount);
            this.panelAdvancedUser.Controls.Add(this.labelCCPositivedVdtUnits);
            this.panelAdvancedUser.Controls.Add(this.labelCCPositivedVdtCount);
            this.panelAdvancedUser.Controls.Add(this.textBoxCCPositivedVdtCount);
            this.panelAdvancedUser.Controls.Add(this.labelNegativedVdtUnits);
            this.panelAdvancedUser.Controls.Add(this.labelNegativedVdtCount);
            this.panelAdvancedUser.Controls.Add(this.textBoxNegativedVdtCount);
            this.panelAdvancedUser.Enabled = false;
            this.panelAdvancedUser.Location = new System.Drawing.Point(322, 547);
            this.panelAdvancedUser.Name = "panelAdvancedUser";
            this.panelAdvancedUser.Size = new System.Drawing.Size(278, 222);
            this.panelAdvancedUser.TabIndex = 94;
            // 
            // labelPCdVdtCountUnits
            // 
            this.labelPCdVdtCountUnits.AutoSize = true;
            this.labelPCdVdtCountUnits.Location = new System.Drawing.Point(217, 166);
            this.labelPCdVdtCountUnits.Name = "labelPCdVdtCountUnits";
            this.labelPCdVdtCountUnits.Size = new System.Drawing.Size(40, 13);
            this.labelPCdVdtCountUnits.TabIndex = 183;
            this.labelPCdVdtCountUnits.Text = "Counts";
            this.labelPCdVdtCountUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPCdVdtCount
            // 
            this.labelPCdVdtCount.Location = new System.Drawing.Point(-1, 166);
            this.labelPCdVdtCount.Name = "labelPCdVdtCount";
            this.labelPCdVdtCount.Size = new System.Drawing.Size(165, 13);
            this.labelPCdVdtCount.TabIndex = 181;
            this.labelPCdVdtCount.Text = "Minimum  PC dV/dt Count:";
            this.labelPCdVdtCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPCdVdtCount
            // 
            this.textBoxPCdVdtCount.Location = new System.Drawing.Point(170, 163);
            this.textBoxPCdVdtCount.Name = "textBoxPCdVdtCount";
            this.textBoxPCdVdtCount.Size = new System.Drawing.Size(44, 20);
            this.textBoxPCdVdtCount.TabIndex = 179;
            this.textBoxPCdVdtCount.Text = "5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(38, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(226, 23);
            this.label11.TabIndex = 177;
            this.label11.Text = "Advanced Setting (Careful!)";
            // 
            // labeldtdtSlopeUnits
            // 
            this.labeldtdtSlopeUnits.AutoSize = true;
            this.labeldtdtSlopeUnits.Location = new System.Drawing.Point(217, 138);
            this.labeldtdtSlopeUnits.Name = "labeldtdtSlopeUnits";
            this.labeldtdtSlopeUnits.Size = new System.Drawing.Size(45, 13);
            this.labeldtdtSlopeUnits.TabIndex = 111;
            this.labeldtdtSlopeUnits.Text = "°C / min";
            this.labeldtdtSlopeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labeldtdtSlope
            // 
            this.labeldtdtSlope.Location = new System.Drawing.Point(36, 138);
            this.labeldtdtSlope.Name = "labeldtdtSlope";
            this.labeldtdtSlope.Size = new System.Drawing.Size(128, 13);
            this.labeldtdtSlope.TabIndex = 109;
            this.labeldtdtSlope.Text = "dt/dt Slope:";
            this.labeldtdtSlope.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxdtdtSlope
            // 
            this.textBoxdtdtSlope.Location = new System.Drawing.Point(170, 135);
            this.textBoxdtdtSlope.Name = "textBoxdtdtSlope";
            this.textBoxdtdtSlope.Size = new System.Drawing.Size(44, 20);
            this.textBoxdtdtSlope.TabIndex = 31;
            this.textBoxdtdtSlope.Text = "-1.5";
            // 
            // labeldVdtBlankTimeUnits
            // 
            this.labeldVdtBlankTimeUnits.AutoSize = true;
            this.labeldVdtBlankTimeUnits.Location = new System.Drawing.Point(217, 113);
            this.labeldVdtBlankTimeUnits.Name = "labeldVdtBlankTimeUnits";
            this.labeldVdtBlankTimeUnits.Size = new System.Drawing.Size(44, 13);
            this.labeldVdtBlankTimeUnits.TabIndex = 110;
            this.labeldVdtBlankTimeUnits.Text = "Minutes";
            this.labeldVdtBlankTimeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labeldVdtBlankTime
            // 
            this.labeldVdtBlankTime.Location = new System.Drawing.Point(36, 113);
            this.labeldVdtBlankTime.Name = "labeldVdtBlankTime";
            this.labeldVdtBlankTime.Size = new System.Drawing.Size(128, 13);
            this.labeldVdtBlankTime.TabIndex = 108;
            this.labeldVdtBlankTime.Text = "dV/dt Blank Time:";
            this.labeldVdtBlankTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxdVdtBlankTime
            // 
            this.textBoxdVdtBlankTime.Location = new System.Drawing.Point(170, 110);
            this.textBoxdVdtBlankTime.Name = "textBoxdVdtBlankTime";
            this.textBoxdVdtBlankTime.Size = new System.Drawing.Size(44, 20);
            this.textBoxdVdtBlankTime.TabIndex = 30;
            this.textBoxdVdtBlankTime.Text = "1";
            // 
            // labelCVNegativedIdtUnits
            // 
            this.labelCVNegativedIdtUnits.AutoSize = true;
            this.labelCVNegativedIdtUnits.Location = new System.Drawing.Point(217, 88);
            this.labelCVNegativedIdtUnits.Name = "labelCVNegativedIdtUnits";
            this.labelCVNegativedIdtUnits.Size = new System.Drawing.Size(40, 13);
            this.labelCVNegativedIdtUnits.TabIndex = 103;
            this.labelCVNegativedIdtUnits.Text = "Counts";
            this.labelCVNegativedIdtUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCVNegativedIdtCount
            // 
            this.labelCVNegativedIdtCount.Location = new System.Drawing.Point(36, 88);
            this.labelCVNegativedIdtCount.Name = "labelCVNegativedIdtCount";
            this.labelCVNegativedIdtCount.Size = new System.Drawing.Size(128, 13);
            this.labelCVNegativedIdtCount.TabIndex = 102;
            this.labelCVNegativedIdtCount.Text = "CV Negative dI/dt Count:";
            this.labelCVNegativedIdtCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCVNegativedIdtCount
            // 
            this.textBoxCVNegativedIdtCount.Location = new System.Drawing.Point(170, 85);
            this.textBoxCVNegativedIdtCount.Name = "textBoxCVNegativedIdtCount";
            this.textBoxCVNegativedIdtCount.Size = new System.Drawing.Size(44, 20);
            this.textBoxCVNegativedIdtCount.TabIndex = 27;
            this.textBoxCVNegativedIdtCount.Text = "3";
            // 
            // labelCCPositivedVdtUnits
            // 
            this.labelCCPositivedVdtUnits.AutoSize = true;
            this.labelCCPositivedVdtUnits.Location = new System.Drawing.Point(217, 63);
            this.labelCCPositivedVdtUnits.Name = "labelCCPositivedVdtUnits";
            this.labelCCPositivedVdtUnits.Size = new System.Drawing.Size(40, 13);
            this.labelCCPositivedVdtUnits.TabIndex = 101;
            this.labelCCPositivedVdtUnits.Text = "Counts";
            this.labelCCPositivedVdtUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCCPositivedVdtCount
            // 
            this.labelCCPositivedVdtCount.Location = new System.Drawing.Point(36, 63);
            this.labelCCPositivedVdtCount.Name = "labelCCPositivedVdtCount";
            this.labelCCPositivedVdtCount.Size = new System.Drawing.Size(128, 13);
            this.labelCCPositivedVdtCount.TabIndex = 99;
            this.labelCCPositivedVdtCount.Text = "CC Positive dV/dt Count:";
            this.labelCCPositivedVdtCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCCPositivedVdtCount
            // 
            this.textBoxCCPositivedVdtCount.Location = new System.Drawing.Point(170, 60);
            this.textBoxCCPositivedVdtCount.Name = "textBoxCCPositivedVdtCount";
            this.textBoxCCPositivedVdtCount.Size = new System.Drawing.Size(44, 20);
            this.textBoxCCPositivedVdtCount.TabIndex = 26;
            this.textBoxCCPositivedVdtCount.Text = "5";
            // 
            // labelNegativedVdtUnits
            // 
            this.labelNegativedVdtUnits.AutoSize = true;
            this.labelNegativedVdtUnits.Location = new System.Drawing.Point(217, 38);
            this.labelNegativedVdtUnits.Name = "labelNegativedVdtUnits";
            this.labelNegativedVdtUnits.Size = new System.Drawing.Size(40, 13);
            this.labelNegativedVdtUnits.TabIndex = 100;
            this.labelNegativedVdtUnits.Text = "Counts";
            this.labelNegativedVdtUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNegativedVdtCount
            // 
            this.labelNegativedVdtCount.Location = new System.Drawing.Point(36, 38);
            this.labelNegativedVdtCount.Name = "labelNegativedVdtCount";
            this.labelNegativedVdtCount.Size = new System.Drawing.Size(128, 13);
            this.labelNegativedVdtCount.TabIndex = 98;
            this.labelNegativedVdtCount.Text = "Negative dV/dt Count:";
            this.labelNegativedVdtCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNegativedVdtCount
            // 
            this.textBoxNegativedVdtCount.Location = new System.Drawing.Point(170, 35);
            this.textBoxNegativedVdtCount.Name = "textBoxNegativedVdtCount";
            this.textBoxNegativedVdtCount.Size = new System.Drawing.Size(44, 20);
            this.textBoxNegativedVdtCount.TabIndex = 25;
            this.textBoxNegativedVdtCount.Text = "-2";
            // 
            // tabPageCalibrate
            // 
            this.tabPageCalibrate.Controls.Add(this.buttonBeginCalibration);
            this.tabPageCalibrate.Controls.Add(this.buttonReadCalibration);
            this.tabPageCalibrate.Controls.Add(this.buttonWriteCalibration);
            this.tabPageCalibrate.Controls.Add(this.panelCalibrationStuff);
            this.tabPageCalibrate.Location = new System.Drawing.Point(4, 22);
            this.tabPageCalibrate.Name = "tabPageCalibrate";
            this.tabPageCalibrate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCalibrate.Size = new System.Drawing.Size(630, 784);
            this.tabPageCalibrate.TabIndex = 2;
            this.tabPageCalibrate.Text = "Calibrate";
            this.tabPageCalibrate.UseVisualStyleBackColor = true;
            // 
            // buttonBeginCalibration
            // 
            this.buttonBeginCalibration.Location = new System.Drawing.Point(463, 109);
            this.buttonBeginCalibration.Name = "buttonBeginCalibration";
            this.buttonBeginCalibration.Size = new System.Drawing.Size(108, 42);
            this.buttonBeginCalibration.TabIndex = 59;
            this.buttonBeginCalibration.Text = "Begin the Calibration Process";
            this.buttonBeginCalibration.UseVisualStyleBackColor = true;
            this.buttonBeginCalibration.Click += new System.EventHandler(this.buttonBeginCalibration_Click);
            // 
            // buttonReadCalibration
            // 
            this.buttonReadCalibration.Location = new System.Drawing.Point(463, 52);
            this.buttonReadCalibration.Name = "buttonReadCalibration";
            this.buttonReadCalibration.Size = new System.Drawing.Size(108, 42);
            this.buttonReadCalibration.TabIndex = 58;
            this.buttonReadCalibration.Text = "Read Calibration from Flash";
            this.buttonReadCalibration.UseVisualStyleBackColor = true;
            this.buttonReadCalibration.Click += new System.EventHandler(this.buttonReadCalibration_Click);
            // 
            // buttonWriteCalibration
            // 
            this.buttonWriteCalibration.Location = new System.Drawing.Point(463, 170);
            this.buttonWriteCalibration.Name = "buttonWriteCalibration";
            this.buttonWriteCalibration.Size = new System.Drawing.Size(108, 42);
            this.buttonWriteCalibration.TabIndex = 60;
            this.buttonWriteCalibration.Text = "Write Calibration to Flash";
            this.buttonWriteCalibration.UseVisualStyleBackColor = true;
            this.buttonWriteCalibration.Click += new System.EventHandler(this.buttonWriteCalibration_Click);
            // 
            // panelCalibrationStuff
            // 
            this.panelCalibrationStuff.Controls.Add(this.textBoxCalTemp);
            this.panelCalibrationStuff.Controls.Add(this.buttonCalTemp);
            this.panelCalibrationStuff.Controls.Add(this.labelCalTemp);
            this.panelCalibrationStuff.Controls.Add(this.labelCalTempUnits);
            this.panelCalibrationStuff.Controls.Add(this.textBoxCalTempReading);
            this.panelCalibrationStuff.Controls.Add(this.textBoxSetHighVin);
            this.panelCalibrationStuff.Controls.Add(this.textBoxSetHighVbat);
            this.panelCalibrationStuff.Controls.Add(this.textBoxSetHighAmp);
            this.panelCalibrationStuff.Controls.Add(this.textBoxSetMidVin);
            this.panelCalibrationStuff.Controls.Add(this.textBoxSetMidVbat);
            this.panelCalibrationStuff.Controls.Add(this.textBoxSetLowVin);
            this.panelCalibrationStuff.Controls.Add(this.textBoxSetLowVbat);
            this.panelCalibrationStuff.Controls.Add(this.textBoxSetMidAmp);
            this.panelCalibrationStuff.Controls.Add(this.textBoxSetLowAmp);
            this.panelCalibrationStuff.Controls.Add(this.ButtonHighVin);
            this.panelCalibrationStuff.Controls.Add(this.ButtonMidVin);
            this.panelCalibrationStuff.Controls.Add(this.ButtonLowVin);
            this.panelCalibrationStuff.Controls.Add(this.labelCalInputVoltage);
            this.panelCalibrationStuff.Controls.Add(this.labelCalBatteryVoltage);
            this.panelCalibrationStuff.Controls.Add(this.label13);
            this.panelCalibrationStuff.Controls.Add(this.label10);
            this.panelCalibrationStuff.Controls.Add(this.label35);
            this.panelCalibrationStuff.Controls.Add(this.label6);
            this.panelCalibrationStuff.Controls.Add(this.labelCalVinHighUnits);
            this.panelCalibrationStuff.Controls.Add(this.labelCalChargerCurrent);
            this.panelCalibrationStuff.Controls.Add(this.labelCalVbatHighUnits);
            this.panelCalibrationStuff.Controls.Add(this.labelCalVinMiddleUnits);
            this.panelCalibrationStuff.Controls.Add(this.label21);
            this.panelCalibrationStuff.Controls.Add(this.label20);
            this.panelCalibrationStuff.Controls.Add(this.labelCalVbatMiddleUnits);
            this.panelCalibrationStuff.Controls.Add(this.labelCalVinLowUnits);
            this.panelCalibrationStuff.Controls.Add(this.labelCalIoutHighUnits);
            this.panelCalibrationStuff.Controls.Add(this.labelCalVbatLowUnits);
            this.panelCalibrationStuff.Controls.Add(this.labelCalIoutMiddleUnits);
            this.panelCalibrationStuff.Controls.Add(this.labelCalIoutLowUnits);
            this.panelCalibrationStuff.Controls.Add(this.textBoxHighVbat);
            this.panelCalibrationStuff.Controls.Add(this.textBoxMidVbat);
            this.panelCalibrationStuff.Controls.Add(this.textBoxLowVbat);
            this.panelCalibrationStuff.Controls.Add(this.textBoxHighVin);
            this.panelCalibrationStuff.Controls.Add(this.textBoxMidVin);
            this.panelCalibrationStuff.Controls.Add(this.textBoxLowVin);
            this.panelCalibrationStuff.Controls.Add(this.textBoxHighAmp);
            this.panelCalibrationStuff.Controls.Add(this.textBoxMidAmp);
            this.panelCalibrationStuff.Controls.Add(this.textBoxLowAmp);
            this.panelCalibrationStuff.Controls.Add(this.buttonHighVbat);
            this.panelCalibrationStuff.Controls.Add(this.buttonMidVbat);
            this.panelCalibrationStuff.Controls.Add(this.buttonLowVbat);
            this.panelCalibrationStuff.Controls.Add(this.buttonHighA);
            this.panelCalibrationStuff.Controls.Add(this.buttonMidA);
            this.panelCalibrationStuff.Controls.Add(this.buttonLowA);
            this.panelCalibrationStuff.Location = new System.Drawing.Point(21, 17);
            this.panelCalibrationStuff.Name = "panelCalibrationStuff";
            this.panelCalibrationStuff.Size = new System.Drawing.Size(423, 472);
            this.panelCalibrationStuff.TabIndex = 49;
            // 
            // textBoxCalTemp
            // 
            this.textBoxCalTemp.Location = new System.Drawing.Point(51, 434);
            this.textBoxCalTemp.MaxLength = 10;
            this.textBoxCalTemp.Name = "textBoxCalTemp";
            this.textBoxCalTemp.Size = new System.Drawing.Size(39, 20);
            this.textBoxCalTemp.TabIndex = 101;
            this.textBoxCalTemp.Text = "8.4";
            this.textBoxCalTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonCalTemp
            // 
            this.buttonCalTemp.Location = new System.Drawing.Point(187, 431);
            this.buttonCalTemp.Name = "buttonCalTemp";
            this.buttonCalTemp.Size = new System.Drawing.Size(75, 23);
            this.buttonCalTemp.TabIndex = 100;
            this.buttonCalTemp.Text = "Temperature";
            this.buttonCalTemp.UseVisualStyleBackColor = true;
            this.buttonCalTemp.Click += new System.EventHandler(this.buttonCalTemp_Click);
            // 
            // labelCalTemp
            // 
            this.labelCalTemp.AutoSize = true;
            this.labelCalTemp.Location = new System.Drawing.Point(48, 417);
            this.labelCalTemp.Name = "labelCalTemp";
            this.labelCalTemp.Size = new System.Drawing.Size(108, 13);
            this.labelCalTemp.TabIndex = 99;
            this.labelCalTemp.Text = "Ambient Temperature";
            this.labelCalTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCalTempUnits
            // 
            this.labelCalTempUnits.AutoSize = true;
            this.labelCalTempUnits.Location = new System.Drawing.Point(92, 437);
            this.labelCalTempUnits.Name = "labelCalTempUnits";
            this.labelCalTempUnits.Size = new System.Drawing.Size(18, 13);
            this.labelCalTempUnits.TabIndex = 98;
            this.labelCalTempUnits.Text = "°C";
            // 
            // textBoxCalTempReading
            // 
            this.textBoxCalTempReading.Location = new System.Drawing.Point(335, 434);
            this.textBoxCalTempReading.MaxLength = 10;
            this.textBoxCalTempReading.Name = "textBoxCalTempReading";
            this.textBoxCalTempReading.Size = new System.Drawing.Size(39, 20);
            this.textBoxCalTempReading.TabIndex = 97;
            // 
            // textBoxSetHighVin
            // 
            this.textBoxSetHighVin.Location = new System.Drawing.Point(52, 377);
            this.textBoxSetHighVin.MaxLength = 10;
            this.textBoxSetHighVin.Name = "textBoxSetHighVin";
            this.textBoxSetHighVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetHighVin.TabIndex = 96;
            this.textBoxSetHighVin.Text = "16.8";
            this.textBoxSetHighVin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetHighVbat
            // 
            this.textBoxSetHighVbat.Location = new System.Drawing.Point(52, 255);
            this.textBoxSetHighVbat.MaxLength = 10;
            this.textBoxSetHighVbat.Name = "textBoxSetHighVbat";
            this.textBoxSetHighVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetHighVbat.TabIndex = 95;
            this.textBoxSetHighVbat.Text = "16.8";
            this.textBoxSetHighVbat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetHighAmp
            // 
            this.textBoxSetHighAmp.Location = new System.Drawing.Point(51, 143);
            this.textBoxSetHighAmp.MaxLength = 10;
            this.textBoxSetHighAmp.Name = "textBoxSetHighAmp";
            this.textBoxSetHighAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetHighAmp.TabIndex = 94;
            this.textBoxSetHighAmp.Text = "2.000";
            this.textBoxSetHighAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetMidVin
            // 
            this.textBoxSetMidVin.Location = new System.Drawing.Point(52, 348);
            this.textBoxSetMidVin.MaxLength = 10;
            this.textBoxSetMidVin.Name = "textBoxSetMidVin";
            this.textBoxSetMidVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetMidVin.TabIndex = 93;
            this.textBoxSetMidVin.Text = "12.6";
            this.textBoxSetMidVin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetMidVbat
            // 
            this.textBoxSetMidVbat.Location = new System.Drawing.Point(52, 226);
            this.textBoxSetMidVbat.MaxLength = 10;
            this.textBoxSetMidVbat.Name = "textBoxSetMidVbat";
            this.textBoxSetMidVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetMidVbat.TabIndex = 92;
            this.textBoxSetMidVbat.Text = "12.6";
            this.textBoxSetMidVbat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetLowVin
            // 
            this.textBoxSetLowVin.Location = new System.Drawing.Point(52, 319);
            this.textBoxSetLowVin.MaxLength = 10;
            this.textBoxSetLowVin.Name = "textBoxSetLowVin";
            this.textBoxSetLowVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetLowVin.TabIndex = 89;
            this.textBoxSetLowVin.Text = "8.4";
            this.textBoxSetLowVin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetLowVbat
            // 
            this.textBoxSetLowVbat.Location = new System.Drawing.Point(52, 197);
            this.textBoxSetLowVbat.MaxLength = 10;
            this.textBoxSetLowVbat.Name = "textBoxSetLowVbat";
            this.textBoxSetLowVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetLowVbat.TabIndex = 88;
            this.textBoxSetLowVbat.Text = "8.4";
            this.textBoxSetLowVbat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetMidAmp
            // 
            this.textBoxSetMidAmp.Location = new System.Drawing.Point(51, 114);
            this.textBoxSetMidAmp.MaxLength = 10;
            this.textBoxSetMidAmp.Name = "textBoxSetMidAmp";
            this.textBoxSetMidAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetMidAmp.TabIndex = 91;
            this.textBoxSetMidAmp.Text = "1.000";
            this.textBoxSetMidAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSetLowAmp
            // 
            this.textBoxSetLowAmp.Location = new System.Drawing.Point(51, 85);
            this.textBoxSetLowAmp.MaxLength = 10;
            this.textBoxSetLowAmp.Name = "textBoxSetLowAmp";
            this.textBoxSetLowAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxSetLowAmp.TabIndex = 90;
            this.textBoxSetLowAmp.Text = "0.100";
            this.textBoxSetLowAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ButtonHighVin
            // 
            this.ButtonHighVin.Location = new System.Drawing.Point(188, 374);
            this.ButtonHighVin.Name = "ButtonHighVin";
            this.ButtonHighVin.Size = new System.Drawing.Size(75, 23);
            this.ButtonHighVin.TabIndex = 87;
            this.ButtonHighVin.Text = "High";
            this.ButtonHighVin.UseVisualStyleBackColor = true;
            this.ButtonHighVin.Click += new System.EventHandler(this.ButtonHighVin_Click);
            // 
            // ButtonMidVin
            // 
            this.ButtonMidVin.Location = new System.Drawing.Point(188, 345);
            this.ButtonMidVin.Name = "ButtonMidVin";
            this.ButtonMidVin.Size = new System.Drawing.Size(75, 23);
            this.ButtonMidVin.TabIndex = 86;
            this.ButtonMidVin.Text = "Middle";
            this.ButtonMidVin.UseVisualStyleBackColor = true;
            this.ButtonMidVin.Click += new System.EventHandler(this.ButtonMidVin_Click);
            // 
            // ButtonLowVin
            // 
            this.ButtonLowVin.Location = new System.Drawing.Point(188, 316);
            this.ButtonLowVin.Name = "ButtonLowVin";
            this.ButtonLowVin.Size = new System.Drawing.Size(75, 23);
            this.ButtonLowVin.TabIndex = 85;
            this.ButtonLowVin.Text = "Low";
            this.ButtonLowVin.UseVisualStyleBackColor = true;
            this.ButtonLowVin.Click += new System.EventHandler(this.ButtonLowVin_Click);
            // 
            // labelCalInputVoltage
            // 
            this.labelCalInputVoltage.AutoSize = true;
            this.labelCalInputVoltage.Location = new System.Drawing.Point(49, 302);
            this.labelCalInputVoltage.Name = "labelCalInputVoltage";
            this.labelCalInputVoltage.Size = new System.Drawing.Size(70, 13);
            this.labelCalInputVoltage.TabIndex = 83;
            this.labelCalInputVoltage.Text = "Input Voltage";
            this.labelCalInputVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCalBatteryVoltage
            // 
            this.labelCalBatteryVoltage.AutoSize = true;
            this.labelCalBatteryVoltage.Location = new System.Drawing.Point(49, 180);
            this.labelCalBatteryVoltage.Name = "labelCalBatteryVoltage";
            this.labelCalBatteryVoltage.Size = new System.Drawing.Size(79, 13);
            this.labelCalBatteryVoltage.TabIndex = 82;
            this.labelCalBatteryVoltage.Text = "Battery Voltage";
            this.labelCalBatteryVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 81;
            this.label13.Text = "Test Points Below:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "Enter Calibration";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(184, 39);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(84, 13);
            this.label35.TabIndex = 79;
            this.label35.Text = "Calibrated Value";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "Push Buttons to Read";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCalVinHighUnits
            // 
            this.labelCalVinHighUnits.AutoSize = true;
            this.labelCalVinHighUnits.Location = new System.Drawing.Point(93, 380);
            this.labelCalVinHighUnits.Name = "labelCalVinHighUnits";
            this.labelCalVinHighUnits.Size = new System.Drawing.Size(30, 13);
            this.labelCalVinHighUnits.TabIndex = 71;
            this.labelCalVinHighUnits.Text = "Volts";
            // 
            // labelCalChargerCurrent
            // 
            this.labelCalChargerCurrent.AutoSize = true;
            this.labelCalChargerCurrent.Location = new System.Drawing.Point(48, 65);
            this.labelCalChargerCurrent.Name = "labelCalChargerCurrent";
            this.labelCalChargerCurrent.Size = new System.Drawing.Size(78, 13);
            this.labelCalChargerCurrent.TabIndex = 77;
            this.labelCalChargerCurrent.Text = "Charge Current";
            this.labelCalChargerCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCalVbatHighUnits
            // 
            this.labelCalVbatHighUnits.AutoSize = true;
            this.labelCalVbatHighUnits.Location = new System.Drawing.Point(93, 258);
            this.labelCalVbatHighUnits.Name = "labelCalVbatHighUnits";
            this.labelCalVbatHighUnits.Size = new System.Drawing.Size(30, 13);
            this.labelCalVbatHighUnits.TabIndex = 69;
            this.labelCalVbatHighUnits.Text = "Volts";
            // 
            // labelCalVinMiddleUnits
            // 
            this.labelCalVinMiddleUnits.AutoSize = true;
            this.labelCalVinMiddleUnits.Location = new System.Drawing.Point(93, 351);
            this.labelCalVinMiddleUnits.Name = "labelCalVinMiddleUnits";
            this.labelCalVinMiddleUnits.Size = new System.Drawing.Size(30, 13);
            this.labelCalVinMiddleUnits.TabIndex = 68;
            this.labelCalVinMiddleUnits.Text = "Volts";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(315, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 76;
            this.label21.Text = "Calibrated Count";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(315, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 84;
            this.label20.Text = "Resulting ADC";
            // 
            // labelCalVbatMiddleUnits
            // 
            this.labelCalVbatMiddleUnits.AutoSize = true;
            this.labelCalVbatMiddleUnits.Location = new System.Drawing.Point(93, 229);
            this.labelCalVbatMiddleUnits.Name = "labelCalVbatMiddleUnits";
            this.labelCalVbatMiddleUnits.Size = new System.Drawing.Size(30, 13);
            this.labelCalVbatMiddleUnits.TabIndex = 73;
            this.labelCalVbatMiddleUnits.Text = "Volts";
            // 
            // labelCalVinLowUnits
            // 
            this.labelCalVinLowUnits.AutoSize = true;
            this.labelCalVinLowUnits.Location = new System.Drawing.Point(93, 322);
            this.labelCalVinLowUnits.Name = "labelCalVinLowUnits";
            this.labelCalVinLowUnits.Size = new System.Drawing.Size(30, 13);
            this.labelCalVinLowUnits.TabIndex = 75;
            this.labelCalVinLowUnits.Text = "Volts";
            // 
            // labelCalIoutHighUnits
            // 
            this.labelCalIoutHighUnits.AutoSize = true;
            this.labelCalIoutHighUnits.Location = new System.Drawing.Point(92, 146);
            this.labelCalIoutHighUnits.Name = "labelCalIoutHighUnits";
            this.labelCalIoutHighUnits.Size = new System.Drawing.Size(33, 13);
            this.labelCalIoutHighUnits.TabIndex = 67;
            this.labelCalIoutHighUnits.Text = "Amps";
            // 
            // labelCalVbatLowUnits
            // 
            this.labelCalVbatLowUnits.AutoSize = true;
            this.labelCalVbatLowUnits.Location = new System.Drawing.Point(93, 200);
            this.labelCalVbatLowUnits.Name = "labelCalVbatLowUnits";
            this.labelCalVbatLowUnits.Size = new System.Drawing.Size(30, 13);
            this.labelCalVbatLowUnits.TabIndex = 74;
            this.labelCalVbatLowUnits.Text = "Volts";
            // 
            // labelCalIoutMiddleUnits
            // 
            this.labelCalIoutMiddleUnits.AutoSize = true;
            this.labelCalIoutMiddleUnits.Location = new System.Drawing.Point(92, 117);
            this.labelCalIoutMiddleUnits.Name = "labelCalIoutMiddleUnits";
            this.labelCalIoutMiddleUnits.Size = new System.Drawing.Size(33, 13);
            this.labelCalIoutMiddleUnits.TabIndex = 72;
            this.labelCalIoutMiddleUnits.Text = "Amps";
            // 
            // labelCalIoutLowUnits
            // 
            this.labelCalIoutLowUnits.AutoSize = true;
            this.labelCalIoutLowUnits.Location = new System.Drawing.Point(92, 88);
            this.labelCalIoutLowUnits.Name = "labelCalIoutLowUnits";
            this.labelCalIoutLowUnits.Size = new System.Drawing.Size(33, 13);
            this.labelCalIoutLowUnits.TabIndex = 70;
            this.labelCalIoutLowUnits.Text = "Amps";
            // 
            // textBoxHighVbat
            // 
            this.textBoxHighVbat.Location = new System.Drawing.Point(336, 255);
            this.textBoxHighVbat.MaxLength = 10;
            this.textBoxHighVbat.Name = "textBoxHighVbat";
            this.textBoxHighVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxHighVbat.TabIndex = 66;
            // 
            // textBoxMidVbat
            // 
            this.textBoxMidVbat.Location = new System.Drawing.Point(336, 226);
            this.textBoxMidVbat.MaxLength = 10;
            this.textBoxMidVbat.Name = "textBoxMidVbat";
            this.textBoxMidVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxMidVbat.TabIndex = 64;
            // 
            // textBoxLowVbat
            // 
            this.textBoxLowVbat.Location = new System.Drawing.Point(336, 197);
            this.textBoxLowVbat.MaxLength = 10;
            this.textBoxLowVbat.Name = "textBoxLowVbat";
            this.textBoxLowVbat.Size = new System.Drawing.Size(39, 20);
            this.textBoxLowVbat.TabIndex = 62;
            // 
            // textBoxHighVin
            // 
            this.textBoxHighVin.Location = new System.Drawing.Point(336, 377);
            this.textBoxHighVin.MaxLength = 10;
            this.textBoxHighVin.Name = "textBoxHighVin";
            this.textBoxHighVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxHighVin.TabIndex = 65;
            // 
            // textBoxMidVin
            // 
            this.textBoxMidVin.Location = new System.Drawing.Point(336, 348);
            this.textBoxMidVin.MaxLength = 10;
            this.textBoxMidVin.Name = "textBoxMidVin";
            this.textBoxMidVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxMidVin.TabIndex = 63;
            // 
            // textBoxLowVin
            // 
            this.textBoxLowVin.Location = new System.Drawing.Point(336, 319);
            this.textBoxLowVin.MaxLength = 10;
            this.textBoxLowVin.Name = "textBoxLowVin";
            this.textBoxLowVin.Size = new System.Drawing.Size(39, 20);
            this.textBoxLowVin.TabIndex = 61;
            // 
            // textBoxHighAmp
            // 
            this.textBoxHighAmp.Location = new System.Drawing.Point(336, 142);
            this.textBoxHighAmp.MaxLength = 10;
            this.textBoxHighAmp.Name = "textBoxHighAmp";
            this.textBoxHighAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxHighAmp.TabIndex = 60;
            // 
            // textBoxMidAmp
            // 
            this.textBoxMidAmp.Location = new System.Drawing.Point(336, 113);
            this.textBoxMidAmp.MaxLength = 10;
            this.textBoxMidAmp.Name = "textBoxMidAmp";
            this.textBoxMidAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxMidAmp.TabIndex = 59;
            // 
            // textBoxLowAmp
            // 
            this.textBoxLowAmp.Location = new System.Drawing.Point(336, 84);
            this.textBoxLowAmp.MaxLength = 10;
            this.textBoxLowAmp.Name = "textBoxLowAmp";
            this.textBoxLowAmp.Size = new System.Drawing.Size(39, 20);
            this.textBoxLowAmp.TabIndex = 58;
            // 
            // buttonHighVbat
            // 
            this.buttonHighVbat.Location = new System.Drawing.Point(188, 253);
            this.buttonHighVbat.Name = "buttonHighVbat";
            this.buttonHighVbat.Size = new System.Drawing.Size(75, 23);
            this.buttonHighVbat.TabIndex = 54;
            this.buttonHighVbat.Text = "High";
            this.buttonHighVbat.UseVisualStyleBackColor = true;
            this.buttonHighVbat.Click += new System.EventHandler(this.ButtonHighVbat_Click);
            // 
            // buttonMidVbat
            // 
            this.buttonMidVbat.Location = new System.Drawing.Point(188, 224);
            this.buttonMidVbat.Name = "buttonMidVbat";
            this.buttonMidVbat.Size = new System.Drawing.Size(75, 23);
            this.buttonMidVbat.TabIndex = 53;
            this.buttonMidVbat.Text = "Middle";
            this.buttonMidVbat.UseVisualStyleBackColor = true;
            this.buttonMidVbat.Click += new System.EventHandler(this.ButtonMidVbat_Click);
            // 
            // buttonLowVbat
            // 
            this.buttonLowVbat.Location = new System.Drawing.Point(188, 195);
            this.buttonLowVbat.Name = "buttonLowVbat";
            this.buttonLowVbat.Size = new System.Drawing.Size(75, 23);
            this.buttonLowVbat.TabIndex = 52;
            this.buttonLowVbat.Text = "Low";
            this.buttonLowVbat.UseVisualStyleBackColor = true;
            this.buttonLowVbat.Click += new System.EventHandler(this.ButtonLowVbat_Click);
            // 
            // buttonHighA
            // 
            this.buttonHighA.Location = new System.Drawing.Point(187, 140);
            this.buttonHighA.Name = "buttonHighA";
            this.buttonHighA.Size = new System.Drawing.Size(75, 23);
            this.buttonHighA.TabIndex = 51;
            this.buttonHighA.Text = "High";
            this.buttonHighA.UseVisualStyleBackColor = true;
            this.buttonHighA.Click += new System.EventHandler(this.buttonHighA_Click);
            // 
            // buttonMidA
            // 
            this.buttonMidA.Location = new System.Drawing.Point(187, 111);
            this.buttonMidA.Name = "buttonMidA";
            this.buttonMidA.Size = new System.Drawing.Size(75, 23);
            this.buttonMidA.TabIndex = 50;
            this.buttonMidA.Text = "Middle";
            this.buttonMidA.UseVisualStyleBackColor = true;
            this.buttonMidA.Click += new System.EventHandler(this.buttonMidA_Click);
            // 
            // buttonLowA
            // 
            this.buttonLowA.Location = new System.Drawing.Point(187, 82);
            this.buttonLowA.Name = "buttonLowA";
            this.buttonLowA.Size = new System.Drawing.Size(75, 23);
            this.buttonLowA.TabIndex = 49;
            this.buttonLowA.Text = "Low";
            this.buttonLowA.UseVisualStyleBackColor = true;
            this.buttonLowA.Click += new System.EventHandler(this.buttonLowA_Click);
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Controls.Add(this.labelPackTemperatureCountsLive);
            this.tabPageAdvanced.Controls.Add(this.labelInputVoltageCounts);
            this.tabPageAdvanced.Controls.Add(this.labelPackCurrentCounts);
            this.tabPageAdvanced.Controls.Add(this.labelOutputVoltageCounts);
            this.tabPageAdvanced.Controls.Add(this.labelPreconditionTimerLive);
            this.tabPageAdvanced.Controls.Add(this.label37);
            this.tabPageAdvanced.Controls.Add(this.labelProfileChargerOutputVoltageLive);
            this.tabPageAdvanced.Controls.Add(this.label31);
            this.tabPageAdvanced.Controls.Add(this.label14);
            this.tabPageAdvanced.Controls.Add(this.labelPosdVbat_dtCountLive);
            this.tabPageAdvanced.Controls.Add(this.label30);
            this.tabPageAdvanced.Controls.Add(this.labelNegdVbat_dtLive);
            this.tabPageAdvanced.Controls.Add(this.labelNegdVbat_dtCountLive);
            this.tabPageAdvanced.Controls.Add(this.label41);
            this.tabPageAdvanced.Controls.Add(this.labeldIdtLive);
            this.tabPageAdvanced.Controls.Add(this.labeldIdtCountLive);
            this.tabPageAdvanced.Controls.Add(this.label23);
            this.tabPageAdvanced.Controls.Add(this.label27);
            this.tabPageAdvanced.Controls.Add(this.labeldtemp_dtLive);
            this.tabPageAdvanced.Controls.Add(this.labelChargeTimeLive);
            this.tabPageAdvanced.Controls.Add(this.labelRapidChargeTimerLive);
            this.tabPageAdvanced.Controls.Add(this.labelRestoreTimerLive);
            this.tabPageAdvanced.Controls.Add(this.labeldTdtCountLive);
            this.tabPageAdvanced.Controls.Add(this.label43);
            this.tabPageAdvanced.Controls.Add(this.label34);
            this.tabPageAdvanced.Controls.Add(this.label33);
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
            this.tabPageAdvanced.Size = new System.Drawing.Size(630, 784);
            this.tabPageAdvanced.TabIndex = 3;
            this.tabPageAdvanced.Text = "Advanced";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // labelPackTemperatureCountsLive
            // 
            this.labelPackTemperatureCountsLive.AutoSize = true;
            this.labelPackTemperatureCountsLive.Location = new System.Drawing.Point(214, 333);
            this.labelPackTemperatureCountsLive.Name = "labelPackTemperatureCountsLive";
            this.labelPackTemperatureCountsLive.Size = new System.Drawing.Size(13, 13);
            this.labelPackTemperatureCountsLive.TabIndex = 77;
            this.labelPackTemperatureCountsLive.Text = "0";
            this.labelPackTemperatureCountsLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInputVoltageCounts
            // 
            this.labelInputVoltageCounts.AutoSize = true;
            this.labelInputVoltageCounts.Location = new System.Drawing.Point(214, 309);
            this.labelInputVoltageCounts.Name = "labelInputVoltageCounts";
            this.labelInputVoltageCounts.Size = new System.Drawing.Size(13, 13);
            this.labelInputVoltageCounts.TabIndex = 78;
            this.labelInputVoltageCounts.Text = "0";
            this.labelInputVoltageCounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPackCurrentCounts
            // 
            this.labelPackCurrentCounts.AutoSize = true;
            this.labelPackCurrentCounts.Location = new System.Drawing.Point(214, 286);
            this.labelPackCurrentCounts.Name = "labelPackCurrentCounts";
            this.labelPackCurrentCounts.Size = new System.Drawing.Size(13, 13);
            this.labelPackCurrentCounts.TabIndex = 79;
            this.labelPackCurrentCounts.Text = "0";
            this.labelPackCurrentCounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOutputVoltageCounts
            // 
            this.labelOutputVoltageCounts.AutoSize = true;
            this.labelOutputVoltageCounts.Location = new System.Drawing.Point(214, 242);
            this.labelOutputVoltageCounts.Name = "labelOutputVoltageCounts";
            this.labelOutputVoltageCounts.Size = new System.Drawing.Size(13, 13);
            this.labelOutputVoltageCounts.TabIndex = 80;
            this.labelOutputVoltageCounts.Text = "0";
            this.labelOutputVoltageCounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPreconditionTimerLive
            // 
            this.labelPreconditionTimerLive.AutoSize = true;
            this.labelPreconditionTimerLive.Location = new System.Drawing.Point(402, 309);
            this.labelPreconditionTimerLive.Name = "labelPreconditionTimerLive";
            this.labelPreconditionTimerLive.Size = new System.Drawing.Size(25, 13);
            this.labelPreconditionTimerLive.TabIndex = 76;
            this.labelPreconditionTimerLive.Text = "999";
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(260, 309);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(136, 15);
            this.label37.TabIndex = 75;
            this.label37.Text = "Precondition Timer:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelProfileChargerOutputVoltageLive
            // 
            this.labelProfileChargerOutputVoltageLive.AutoSize = true;
            this.labelProfileChargerOutputVoltageLive.Location = new System.Drawing.Point(159, 242);
            this.labelProfileChargerOutputVoltageLive.Name = "labelProfileChargerOutputVoltageLive";
            this.labelProfileChargerOutputVoltageLive.Size = new System.Drawing.Size(38, 13);
            this.labelProfileChargerOutputVoltageLive.TabIndex = 74;
            this.labelProfileChargerOutputVoltageLive.Text = "88.8 V";
            this.labelProfileChargerOutputVoltageLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(76, 242);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(82, 13);
            this.label31.TabIndex = 73;
            this.label31.Text = "Output Voltage:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(22, 533);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 15);
            this.label14.TabIndex = 72;
            this.label14.Text = "Negative dV/dt Count:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPosdVbat_dtCountLive
            // 
            this.labelPosdVbat_dtCountLive.AutoSize = true;
            this.labelPosdVbat_dtCountLive.Location = new System.Drawing.Point(159, 509);
            this.labelPosdVbat_dtCountLive.Name = "labelPosdVbat_dtCountLive";
            this.labelPosdVbat_dtCountLive.Size = new System.Drawing.Size(13, 13);
            this.labelPosdVbat_dtCountLive.TabIndex = 71;
            this.labelPosdVbat_dtCountLive.Text = "4";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(22, 508);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(136, 15);
            this.label30.TabIndex = 70;
            this.label30.Text = "Positive dV/dt Count:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNegdVbat_dtLive
            // 
            this.labelNegdVbat_dtLive.AutoSize = true;
            this.labelNegdVbat_dtLive.Location = new System.Drawing.Point(159, 556);
            this.labelNegdVbat_dtLive.Name = "labelNegdVbat_dtLive";
            this.labelNegdVbat_dtLive.Size = new System.Drawing.Size(22, 13);
            this.labelNegdVbat_dtLive.TabIndex = 68;
            this.labelNegdVbat_dtLive.Text = "1.5";
            // 
            // labelNegdVbat_dtCountLive
            // 
            this.labelNegdVbat_dtCountLive.AutoSize = true;
            this.labelNegdVbat_dtCountLive.Location = new System.Drawing.Point(159, 534);
            this.labelNegdVbat_dtCountLive.Name = "labelNegdVbat_dtCountLive";
            this.labelNegdVbat_dtCountLive.Size = new System.Drawing.Size(13, 13);
            this.labelNegdVbat_dtCountLive.TabIndex = 67;
            this.labelNegdVbat_dtCountLive.Text = "4";
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(22, 555);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(136, 15);
            this.label41.TabIndex = 65;
            this.label41.Text = "dV/dt:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labeldIdtLive
            // 
            this.labeldIdtLive.AutoSize = true;
            this.labeldIdtLive.Location = new System.Drawing.Point(159, 467);
            this.labeldIdtLive.Name = "labeldIdtLive";
            this.labeldIdtLive.Size = new System.Drawing.Size(22, 13);
            this.labeldIdtLive.TabIndex = 64;
            this.labeldIdtLive.Text = "1.5";
            // 
            // labeldIdtCountLive
            // 
            this.labeldIdtCountLive.AutoSize = true;
            this.labeldIdtCountLive.Location = new System.Drawing.Point(159, 445);
            this.labeldIdtCountLive.Name = "labeldIdtCountLive";
            this.labeldIdtCountLive.Size = new System.Drawing.Size(13, 13);
            this.labeldIdtCountLive.TabIndex = 63;
            this.labeldIdtCountLive.Text = "4";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(22, 444);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(136, 15);
            this.label23.TabIndex = 62;
            this.label23.Text = "dI/dt Count:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(22, 466);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(136, 15);
            this.label27.TabIndex = 61;
            this.label27.Text = "dI/dt:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labeldtemp_dtLive
            // 
            this.labeldtemp_dtLive.AutoSize = true;
            this.labeldtemp_dtLive.Location = new System.Drawing.Point(159, 406);
            this.labeldtemp_dtLive.Name = "labeldtemp_dtLive";
            this.labeldtemp_dtLive.Size = new System.Drawing.Size(22, 13);
            this.labeldtemp_dtLive.TabIndex = 60;
            this.labeldtemp_dtLive.Text = "1.5";
            // 
            // labelChargeTimeLive
            // 
            this.labelChargeTimeLive.AutoSize = true;
            this.labelChargeTimeLive.Location = new System.Drawing.Point(402, 382);
            this.labelChargeTimeLive.Name = "labelChargeTimeLive";
            this.labelChargeTimeLive.Size = new System.Drawing.Size(25, 13);
            this.labelChargeTimeLive.TabIndex = 59;
            this.labelChargeTimeLive.Text = "999";
            // 
            // labelRapidChargeTimerLive
            // 
            this.labelRapidChargeTimerLive.AutoSize = true;
            this.labelRapidChargeTimerLive.Location = new System.Drawing.Point(402, 333);
            this.labelRapidChargeTimerLive.Name = "labelRapidChargeTimerLive";
            this.labelRapidChargeTimerLive.Size = new System.Drawing.Size(25, 13);
            this.labelRapidChargeTimerLive.TabIndex = 58;
            this.labelRapidChargeTimerLive.Text = "999";
            // 
            // labelRestoreTimerLive
            // 
            this.labelRestoreTimerLive.AutoSize = true;
            this.labelRestoreTimerLive.Location = new System.Drawing.Point(402, 358);
            this.labelRestoreTimerLive.Name = "labelRestoreTimerLive";
            this.labelRestoreTimerLive.Size = new System.Drawing.Size(25, 13);
            this.labelRestoreTimerLive.TabIndex = 57;
            this.labelRestoreTimerLive.Text = "999";
            // 
            // labeldTdtCountLive
            // 
            this.labeldTdtCountLive.AutoSize = true;
            this.labeldTdtCountLive.Location = new System.Drawing.Point(159, 384);
            this.labeldTdtCountLive.Name = "labeldTdtCountLive";
            this.labeldTdtCountLive.Size = new System.Drawing.Size(13, 13);
            this.labeldTdtCountLive.TabIndex = 56;
            this.labeldTdtCountLive.Text = "4";
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(260, 382);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(136, 15);
            this.label43.TabIndex = 48;
            this.label43.Text = "Charge Time:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(260, 333);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(136, 15);
            this.label34.TabIndex = 46;
            this.label34.Text = "Rapid Charge Timer:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(260, 358);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(136, 15);
            this.label33.TabIndex = 42;
            this.label33.Text = "Restore Timer:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(22, 383);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(136, 15);
            this.label29.TabIndex = 40;
            this.label29.Text = "dT/dt Count:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labeldTdtLive
            // 
            this.labeldTdtLive.Location = new System.Drawing.Point(0, 0);
            this.labeldTdtLive.Name = "labeldTdtLive";
            this.labeldTdtLive.Size = new System.Drawing.Size(100, 23);
            this.labeldTdtLive.TabIndex = 55;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(22, 405);
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
            this.labelPackTemperatureReadLive.Location = new System.Drawing.Point(159, 333);
            this.labelPackTemperatureReadLive.Name = "labelPackTemperatureReadLive";
            this.labelPackTemperatureReadLive.Size = new System.Drawing.Size(49, 13);
            this.labelPackTemperatureReadLive.TabIndex = 35;
            this.labelPackTemperatureReadLive.Text = "25.4 deg";
            this.labelPackTemperatureReadLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(22, 333);
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
            this.labelProfileInputVoltageLive.Location = new System.Drawing.Point(159, 310);
            this.labelProfileInputVoltageLive.Name = "labelProfileInputVoltageLive";
            this.labelProfileInputVoltageLive.Size = new System.Drawing.Size(38, 13);
            this.labelProfileInputVoltageLive.TabIndex = 29;
            this.labelProfileInputVoltageLive.Text = "25.6 V";
            this.labelProfileInputVoltageLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfilePackCurrentLive
            // 
            this.labelProfilePackCurrentLive.AutoSize = true;
            this.labelProfilePackCurrentLive.Location = new System.Drawing.Point(159, 286);
            this.labelProfilePackCurrentLive.Name = "labelProfilePackCurrentLive";
            this.labelProfilePackCurrentLive.Size = new System.Drawing.Size(44, 13);
            this.labelProfilePackCurrentLive.TabIndex = 28;
            this.labelProfilePackCurrentLive.Text = "6.023 A";
            this.labelProfilePackCurrentLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProfilePackVoltageLive
            // 
            this.labelProfilePackVoltageLive.AutoSize = true;
            this.labelProfilePackVoltageLive.Location = new System.Drawing.Point(159, 263);
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
            this.label38.Location = new System.Drawing.Point(76, 309);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(82, 13);
            this.label38.TabIndex = 24;
            this.label38.Text = "Input Voltage:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(76, 286);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(82, 13);
            this.label39.TabIndex = 23;
            this.label39.Text = "Pack Current:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(25, 263);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(133, 15);
            this.label40.TabIndex = 22;
            this.label40.Text = "Estimated Pack Voltage:";
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
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(256, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 35);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Export Configuration and Calibration data to a .H file for Hard-Coded Designs";
            // 
            // TabPagePeakPoke
            // 
            this.TabPagePeakPoke.Controls.Add(this.buttonReadSettingsStructure);
            this.TabPagePeakPoke.Controls.Add(this.label22);
            this.TabPagePeakPoke.Controls.Add(this.SFR_Drop_Down);
            this.TabPagePeakPoke.Controls.Add(this.labelFlashData);
            this.TabPagePeakPoke.Controls.Add(this.labelFlashAddress);
            this.TabPagePeakPoke.Controls.Add(this.labelFlashPeakPoke);
            this.TabPagePeakPoke.Controls.Add(this.textBoxFlashData);
            this.TabPagePeakPoke.Controls.Add(this.textBoxFlashAddress);
            this.TabPagePeakPoke.Controls.Add(this.buttonPokeFlash);
            this.TabPagePeakPoke.Controls.Add(this.buttonPeakFlash);
            this.TabPagePeakPoke.Controls.Add(this.labelSFRData);
            this.TabPagePeakPoke.Controls.Add(this.labelSFRAddress);
            this.TabPagePeakPoke.Controls.Add(this.labelSFRPeakPoke);
            this.TabPagePeakPoke.Controls.Add(this.textBoxSFRData);
            this.TabPagePeakPoke.Controls.Add(this.textBoxSFRAddress);
            this.TabPagePeakPoke.Controls.Add(this.buttonPokeSFR);
            this.TabPagePeakPoke.Controls.Add(this.buttonPeakSFR);
            this.TabPagePeakPoke.Location = new System.Drawing.Point(4, 22);
            this.TabPagePeakPoke.Name = "TabPagePeakPoke";
            this.TabPagePeakPoke.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePeakPoke.Size = new System.Drawing.Size(630, 784);
            this.TabPagePeakPoke.TabIndex = 4;
            this.TabPagePeakPoke.Text = "Peak-Poke";
            this.TabPagePeakPoke.UseVisualStyleBackColor = true;
            // 
            // buttonReadSettingsStructure
            // 
            this.buttonReadSettingsStructure.Location = new System.Drawing.Point(436, 347);
            this.buttonReadSettingsStructure.Name = "buttonReadSettingsStructure";
            this.buttonReadSettingsStructure.Size = new System.Drawing.Size(75, 23);
            this.buttonReadSettingsStructure.TabIndex = 16;
            this.buttonReadSettingsStructure.Text = "Refresh";
            this.buttonReadSettingsStructure.UseVisualStyleBackColor = true;
            this.buttonReadSettingsStructure.Click += new System.EventHandler(this.buttonReadSettingsStructure_Click);
            // 
            // label22
            // 
            this.label22.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.label22.AutoSize = true;
            this.label22.CausesValidation = false;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(132, 347);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(284, 25);
            this.label22.TabIndex = 15;
            this.label22.Text = "Charge Settings Structure";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(662, 834);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Universal Battery Charger GUI R4.69";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageProfile.ResumeLayout(false);
            this.tabPageProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfile)).EndInit();
            this.tabPageConfigure.ResumeLayout(false);
            this.panelTempSettings.ResumeLayout(false);
            this.panelTempSettings.PerformLayout();
            this.panelConfigurationControl.ResumeLayout(false);
            this.panelConfigurationControl.PerformLayout();
            this.panelBasicSettings.ResumeLayout(false);
            this.panelBasicSettings.PerformLayout();
            this.panelSystemSettings.ResumeLayout(false);
            this.panelSystemSettings.PerformLayout();
            this.panelVRLANiMH.ResumeLayout(false);
            this.panelVRLANiMH.PerformLayout();
            this.panelAdvancedUser.ResumeLayout(false);
            this.panelAdvancedUser.PerformLayout();
            this.tabPageCalibrate.ResumeLayout(false);
            this.panelCalibrationStuff.ResumeLayout(false);
            this.panelCalibrationStuff.PerformLayout();
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
        private System.Windows.Forms.Label labelChargerStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelPackTemperatureRead;
        private System.Windows.Forms.Label labelPackTemperature;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.Label labelProfilePCBtype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelProfileChargerOutputVoltage;
        private System.Windows.Forms.Label label32;
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
        private System.Windows.Forms.Label labelFlashData;
        private System.Windows.Forms.Label labelFlashAddress;
        private System.Windows.Forms.Label labelFlashPeakPoke;
        private System.Windows.Forms.Label labelSFRData;
        private System.Windows.Forms.Label labelSFRAddress;
        private System.Windows.Forms.Label labelSFRPeakPoke;
        private System.Windows.Forms.Panel panelAdvancedUser;
        private System.Windows.Forms.Label labeldtdtSlopeUnits;
        private System.Windows.Forms.Label labeldtdtSlope;
        private System.Windows.Forms.TextBox textBoxdtdtSlope;
        private System.Windows.Forms.Label labeldVdtBlankTimeUnits;
        private System.Windows.Forms.Label labeldVdtBlankTime;
        private System.Windows.Forms.TextBox textBoxdVdtBlankTime;
        private System.Windows.Forms.Label labelCVNegativedIdtUnits;
        private System.Windows.Forms.Label labelCVNegativedIdtCount;
        private System.Windows.Forms.TextBox textBoxCVNegativedIdtCount;
        private System.Windows.Forms.Label labelCCPositivedVdtUnits;
        private System.Windows.Forms.Label labelCCPositivedVdtCount;
        private System.Windows.Forms.TextBox textBoxCCPositivedVdtCount;
        private System.Windows.Forms.Label labelNegativedVdtUnits;
        private System.Windows.Forms.Label labelNegativedVdtCount;
        private System.Windows.Forms.TextBox textBoxNegativedVdtCount;
        private System.Windows.Forms.Panel panelSystemSettings;
        private System.Windows.Forms.Label labelUVLOFalling;
        private System.Windows.Forms.Label labelUVLOFallingUnits;
        private System.Windows.Forms.TextBox textBoxUVLOFalling;
        private System.Windows.Forms.Label labelApproximateResistanceUnits;
        private System.Windows.Forms.TextBox textBoxWireRes;
        private System.Windows.Forms.Label labelUVLORising;
        private System.Windows.Forms.Label labelUVLORisingUnits;
        private System.Windows.Forms.TextBox textBoxUVLORising;
        private System.Windows.Forms.Label labelWireRes;
        private System.Windows.Forms.Panel panelBasicSettings;
        private System.Windows.Forms.Label labelMaximumChargeTimeUnits;
        private System.Windows.Forms.TextBox textBoxMaximumChargeTime;
        private System.Windows.Forms.Label labelMaximumChargeTime;
        private System.Windows.Forms.Label labelPreconditionCurrentUnits;
        private System.Windows.Forms.TextBox textBoxPreconditionCurrent;
        private System.Windows.Forms.Label labelPreconditionCurrent;
        private System.Windows.Forms.Label labelChargeCurrentUnits;
        private System.Windows.Forms.Label labelTerminationCurrentUnits;
        private System.Windows.Forms.TextBox textBoxTerminationCurrent;
        private System.Windows.Forms.TextBox textBoxChargeCurrent;
        private System.Windows.Forms.Label labelTermination;
        private System.Windows.Forms.Label labelChargeCurrent;
        private System.Windows.Forms.Label labelTerminationVoltageUnits;
        private System.Windows.Forms.Label labelTerminationVoltage;
        private System.Windows.Forms.TextBox textBoxTerminationVoltage;
        private System.Windows.Forms.Label labelPreconditionVoltageUnits;
        private System.Windows.Forms.Label labelPreconditionCellVoltage;
        private System.Windows.Forms.TextBox textBoxPreconditionCellVoltage;
        private System.Windows.Forms.Label labelCellVoltageUnits;
        private System.Windows.Forms.Label labelCellVoltage;
        private System.Windows.Forms.TextBox textBoxCellVoltage;
        private System.Windows.Forms.Label labelOverVoltageUnits;
        private System.Windows.Forms.Label labelOverVoltage;
        private System.Windows.Forms.TextBox textBoxOverVoltage;
        private System.Windows.Forms.Panel panelConfigurationControl;
        private System.Windows.Forms.Label labelReferenceDesignType;
        private System.Windows.Forms.ComboBox comboBoxPCBType;
        private System.Windows.Forms.CheckBox checkBoxThermistor;
        private System.Windows.Forms.Label labelBatteryChemistry;
        private System.Windows.Forms.ComboBox comboBoxChemistry;
        private System.Windows.Forms.Button buttonWriteConfiguration;
        private System.Windows.Forms.Button buttonReadConfiguration;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label labeldTdtLive;
        private System.Windows.Forms.Label label25;
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
        private System.Windows.Forms.Button ButtonUpdateCurrentValues;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button ButtonDefaultCalValues;
        private System.Windows.Forms.Button ButtonWriteHFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labeldTdtCountLive;
        private System.Windows.Forms.Label labelRestoreTimerLive;
        private System.Windows.Forms.Label labelRapidChargeTimerLive;
        private System.Windows.Forms.Label labelChargeTimeLive;
        private System.Windows.Forms.Label labeldtemp_dtLive;
        private System.Windows.Forms.Panel panelVRLANiMH;
        private System.Windows.Forms.Label labelFloatVoltageUnits;
        private System.Windows.Forms.Label labelFloatVoltage;
        private System.Windows.Forms.TextBox textBoxFloatVoltage;
        private System.Windows.Forms.Panel panelCalibrationStuff;
        private System.Windows.Forms.TextBox textBoxSetHighVin;
        private System.Windows.Forms.TextBox textBoxSetHighVbat;
        private System.Windows.Forms.TextBox textBoxSetHighAmp;
        private System.Windows.Forms.TextBox textBoxSetMidVin;
        private System.Windows.Forms.TextBox textBoxSetMidVbat;
        private System.Windows.Forms.TextBox textBoxSetLowVin;
        private System.Windows.Forms.TextBox textBoxSetLowVbat;
        private System.Windows.Forms.TextBox textBoxSetMidAmp;
        private System.Windows.Forms.TextBox textBoxSetLowAmp;
        private System.Windows.Forms.Button ButtonHighVin;
        private System.Windows.Forms.Button ButtonMidVin;
        private System.Windows.Forms.Button ButtonLowVin;
        private System.Windows.Forms.Label labelCalInputVoltage;
        private System.Windows.Forms.Label labelCalBatteryVoltage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelCalVinHighUnits;
        private System.Windows.Forms.Label labelCalChargerCurrent;
        private System.Windows.Forms.Label labelCalVbatHighUnits;
        private System.Windows.Forms.Label labelCalVinMiddleUnits;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label labelCalVbatMiddleUnits;
        private System.Windows.Forms.Label labelCalVinLowUnits;
        private System.Windows.Forms.Label labelCalIoutHighUnits;
        private System.Windows.Forms.Label labelCalVbatLowUnits;
        private System.Windows.Forms.Label labelCalIoutMiddleUnits;
        private System.Windows.Forms.Label labelCalIoutLowUnits;
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
        private System.Windows.Forms.Panel panelTempSettings;
        private System.Windows.Forms.Label labelMaximumTemperatureUnits;
        private System.Windows.Forms.Label labelMinimumTemperatureUnits;
        private System.Windows.Forms.TextBox textBoxMaximumTemperature;
        private System.Windows.Forms.Label labelMaximumTemperature;
        private System.Windows.Forms.Label labelMinimumTemperature;
        private System.Windows.Forms.TextBox textBoxMinimumTemperature;
        private System.Windows.Forms.TextBox textBoxCalTemp;
        private System.Windows.Forms.Button buttonCalTemp;
        private System.Windows.Forms.Label labelCalTemp;
        private System.Windows.Forms.Label labelCalTempUnits;
        private System.Windows.Forms.TextBox textBoxCalTempReading;
        private System.Windows.Forms.Button buttonBeginCalibration;
        private System.Windows.Forms.Button buttonReadCalibration;
        private System.Windows.Forms.Button buttonWriteCalibration;
        private System.Windows.Forms.ComboBox comboBoxNumberOfCells;
        private System.Windows.Forms.Label labelNumberSeriesCells;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTempCoeff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxADCVref;
        private System.Windows.Forms.TextBox textBoxADCSize;
        private System.Windows.Forms.Label labelADCVref;
        private System.Windows.Forms.Label labelTempADCSize;
        private System.Windows.Forms.Label labelADCSizeUnits;
        private System.Windows.Forms.Label labelADCVrefUnits;
        private System.Windows.Forms.Label labelTempSlopeUnits;
        private System.Windows.Forms.Label labelTempSlope;
        private System.Windows.Forms.TextBox textBoxTempSlope;
        private System.Windows.Forms.Label labelNegdVbat_dtLive;
        private System.Windows.Forms.Label labelNegdVbat_dtCountLive;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label labeldIdtLive;
        private System.Windows.Forms.Label labeldIdtCountLive;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label labelPosdVbat_dtCountLive;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelFloatCurrentUnits;
        private System.Windows.Forms.TextBox textBoxFloatCurrent;
        private System.Windows.Forms.Label labelFloatCurrent;
        private System.Windows.Forms.Label labelProfileChargerOutputVoltageLive;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label labelPCdVdtCountUnits;
        private System.Windows.Forms.Label labelPCdVdtCount;
        private System.Windows.Forms.TextBox textBoxPCdVdtCount;
        private System.Windows.Forms.Label labelPreconditionTimerLive;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label labelFWRev;
        private System.Windows.Forms.Button buttonReadSettingsStructure;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label labelRestorationChargeTimeUnits;
        private System.Windows.Forms.TextBox textBoxRestorationChargeTime;
        private System.Windows.Forms.Label labelRestorationTime;
        private System.Windows.Forms.Label labelRapidChargeTimeUnits;
        private System.Windows.Forms.TextBox textBoxRapidChargeTime;
        private System.Windows.Forms.Label labelRapidTime;
        private System.Windows.Forms.Label labelPreconditionTimeUnits;
        private System.Windows.Forms.Label labelPreconditionTime;
        private System.Windows.Forms.TextBox textBoxPreConditionTime;
        private System.Windows.Forms.Label labelPackTemperatureCountsLive;
        private System.Windows.Forms.Label labelInputVoltageCounts;
        private System.Windows.Forms.Label labelPackCurrentCounts;
        private System.Windows.Forms.Label labelOutputVoltageCounts;
    }
}

