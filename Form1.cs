/*
 * Software License Agreement:
 *
 * The software supplied herewith by Microchip Technology Incorporated
 * (the "Company") for use with its PICmicro® Microcontroller is intended and
 * supplied to you, the Company's customer, for use solely and
 * exclusively with Microchip PICmicro Microcontroller products. The
 * software is owned by the Company and/or its supplier, and is
 * protected under applicable copyright laws. All rights are reserved.
 * Any use in violation of the foregoing restrictions may subject the
 * user to criminal sanctions under applicable laws, as well as to
 * civil liability for the breach of the terms and conditions of this
 * license.
 *
 * THIS SOFTWARE IS PROVIDED IN AN "AS IS" CONDITION. NO WARRANTIES,
 * WHETHER EXPRESS, IMPLIED OR STATUTORY, INCLUDING, BUT NOT LIMITED
 * TO, IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE APPLY TO THIS SOFTWARE. THE COMPANY SHALL NOT,
 * IN ANY CIRCUMSTANCES, BE LIABLE FOR SPECIAL, INCIDENTAL OR
 * CONSEQUENTIAL DAMAGES, FOR ANY REASON WHATSOEVER.
 */

/*
 * Things to do, or improve:
 * Need the calibration values to adjust according to the type of reference design is being used. Look
 *  at the values of vinrange and vbatrange for example
 *  
 * Would be nice if the GUI would warn the user if the code was compiled to use a fixed configuration
 *  because the #define ENABLE_GUI is disabled in the firmware.
 * 
 * Dynamically change the calibration range based on the number of cells
 */

 /************************************************************************************/
 /* System Declarations Below                                                        */
 /************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace MCP19111BatteryChargerGUI
{
    public partial class Form1 : Form
    {
        #region Definitions and Declarations
        /*************************************************************************************/
        /* Serial communication declarations                                                 */
        /*************************************************************************************/

        enum ProcessStates
        {
            ConfigMCP2221,
            CheckSlave,
            Running,
        };
        ProcessStates statesProcess = ProcessStates.ConfigMCP2221;
        System.IntPtr MCPHandle;
        byte SlaveAddr = 1;
        uint SlaveSpeed = 100000;
        byte[] I2CWriteBuffer = new byte[1024];

        byte SlaveAddress_Register = 0x05;  //%%BRYAN%% Straighten Out
        byte Payload_Register = 0x07;       //%BRYAN%% Straighten Out
        bool initialized = false;
        byte serial_device = 0;             //Value of 1 is Pickit Serial, 2 is MCP2221A
        IntPtr handle;                      //Pointer for MCP2221A devices
        uint USBindex = 0;                  // for MCP2221A connections this is the open index
        byte smbusaddr = 0x20;              //%%BRYAN%% make this user selectable, and add a scan routine for the address.
        ushort Flash_Access = 0x8000;
        ushort SFR_Access = 0x4000;
        ushort Profile_Access = 0x0000;
        ushort Settings_Access = 0xC000;
        ushort Temp_Cal_Addr = 0x0040;
        ushort Flash_Config_Offset = 0x0020;

        /*************************************************************************************/
        /* Variable Definitions Below                                                        */
        /*************************************************************************************/

        short max_firmware_rev = 0x0404;    // Update this to reflect support for new firmware revesions
        short min_firmware_rev = 0x0400;    // Update this to reflect support for new firmware revisions
        bool profilerunning = false;
        bool calibrating = false;
        byte[] profile_data = new byte[32]; /* This corresponds to the charger_data_t struct     */
                                            /* in the firmware and contains the charger_status_t */
                                            /* and eoc_charger_status_t struct.                  */
        int last_charge_time;
        string script = "";
        string[] default_values_line_titles = {
        "// 0 uvlo_threshold_off          // UVLO off threshold",
        "// 2 uvlo_threshold_on           // UVLO on threshold",
        "// 4 vbat_ov;                    // Output overvoltage shutdown threshold",
        "// 6 vbat_pc;                    // Battery voltage PRE to CC",
        "// 8 vbat_cv;                    // Battery voltage CC to CV",
        "// 10 ibat_pc;                    // Preconditioning battery current",
        "// 12 ibat_cc;                    // Charge current",
        "// 14 ibat_ct;                    // Charge termination current",
        "// 16 charge_time_max;            // Maximum charge time before shut-off, Low Byte",
        "// 18 charge_time_max;            // Maximum charge time before shut-off, High Byte",
        "// 20 ovcfcon_min;                // Minimum setting for output DAC",
        "// 22 ovcfcon_max;                // Maximum setting for output DAC",
        "// 24 uvlo_adc_threshold_off;     // Input UV threshold for turn off (ADC)",
        "// 26 uvlo_adc_threshold_on;      // Input UV threshold to allow turn-on (ADC)",
        "// 28 restore_time_max;           // RESTORE charge maximum time",
        "// 30 dvdt_blank_time;            // dV/dt blank time",
        "// 32 rapid_time_max;             // RAPID charge maximum time",
        "// 34 dtdt_slope;                 // dT/dt slope to terminate charge",
        "// 36 pack_temp_min;              // Minimum pack temperature",
        "// 38 pack_temp_max;              // Maximum pack temperature",
        "// 40 chemistry;                  // Chemistry (0 = Li-ion, 1 = NiMH, 2 = VRLA CCCP, 3 = VRLA Fast, 4 = LiFePO4)",
        "// 42 ovrefcon_ov;                // OVREFCON_OV sets the reference for OV comparator when enabled MCP19125 specific",
        "// 44 ovrefcon_cv;                // OVREFCON_CV sets the reference for EA1 when enabled MCP19125 specific",
        "// 46 vrefcon_max;                // Maximum value allowed for VREFCON",
        "// 48",
        "// 50",
        "// 52",
        "// 54",
        "// 56",
        "// 58",
        "// 60",
        "// 62",
        "// 64 cell voltage",
        "// 66 # of Cells",
        "// 68 Precondition Voltage",
        "// 70 Precondition Current",
        "// 72 Charge Current",
        "// 74 Termination Current",
        "// 76 Maximum Charge Time",
        "// 78 Rapid Time Max",
        "// 80 Restore Time Max",
        "// 82 Minimum Temperature",
        "// 84 Maximum Temperautre",
        "// 86 Termination Voltage",
        "// 88 Approximate Wire Resistance in Ohms",
        "// 90",
        "// 92",
        "// 94",
        "// 96",
        "// 98",
        "// 100",
        "// 102",
        "// 104",
        "// 106",
        "// 108",
        "// 110",
        "// 112",
        "// 114",
        "// 116",
        "// 118",
        "// 120",
        "// 122",
        "// 124",
        "// 126"};
        byte[] verification_data = new byte[128]; /* This corresponds to the charger_settings_t */
                                                  /* struct in the firmware.  Really only the   */
                                                  /* lower 32B are used by the firmware at this */
                                                  /* time.  The rest is there for the charger   */
                                                  /* to store useful parameters for the GUI or  */
                                                  /* for user software to retrieve.             */

        /*************************************************************************************/
        /* Configuration information that the charger firmware uses for operation            */
        /*************************************************************************************/
        byte[] configuration_data = new byte[128];  // Changed from 96 for 32-byte programming of PIC16F1716
        ushort cf_vbat_ov;                          // Output overvoltage shutdown threshold
        ushort cf_vbat_pc;                          // Battery voltage PRE to CC
        ushort cf_vbat_cv;                          // Battery voltage CC to CV
        ushort cf_ibat_pc;                          // Preconditioning battery current
        ushort cf_ibat_cc;                          // Charge current
        ushort cf_ibat_ct;                          // Charge termination current
        ushort cf_charge_time_max;                  // Maximum charge time before shut-off
        byte cf_uvlo_threshold_off;                 // Input UV threshold for turn off
        byte cf_uvlo_threshold_on;                  // Input UV threshold to allow turn-on (NOT USED)
        byte cf_ovcfcon_min;                        // Minimum setting for output DAC
        byte cf_ovcfcon_max;                        // Maximum setting for output DAC
        ushort cf_adc_uvlo_threshold_off;           // Input UV threshold for turn off (ADC)
        ushort cf_adc_uvlo_threshold_on;            // Input UV threshold to allow turn-on (ADC)
        ushort cf_restore_time_max;                 // RESTORE charge maximum time
        ushort cf_dvdt_blank_time;                  // dV/dt blank time
        ushort cf_rapid_time_max;                   // RAPID charge maximum time
        short cf_dtdt_slope;                        // dT/dt slope to terminate charge
        ushort cf_pack_temp_min;                    // Minimum pack temperature
        ushort cf_pack_temp_max;                    // Maximum pack temperature
        byte cf_chemistry;                          // Chemistry (0 = Li-ion, 1 = NiMH, 2 = VRLA CCCP, 3 = VRLA Fast, 4 = LiFePO4)
        ushort cf_ovrefcon_ov;                      // MCP19125 specific, Reference for OV Comparator when enabled
        ushort cf_ovrefcon_cv;                      // MCP19125 specific, Reference for EA1 when enabled
        ushort cf_vrefcon_max;                      // MCP19125 specific, Maximum VREFCON value. Basically a max current setting

        /*************************************************************************************/
        /* Settings stored on the charger's flash that are used by the GUI.  For instance    */
        /* they could be absolute values of charge current for populating fields in the GUI  */
        /* rather than the calibrated threshold value represented by the corresponding cf_   */
        /* parameter above.                                                                  */
        /*************************************************************************************/

        /*************************************************************************************/
        /* For most of these values below the flow is:                                       */
        /* 1) GUI opens and when the "configure" tab is selected the defaults presented are  */
        /*    based on the battery type and PCB type corresponding to Case 0. That would be  */
        /*    MCP19111 and Lithium Ion. These defaults populate the d_st_#### params and the */
        /*    corresponding Text Boxes.                                                      */
        /* 2) Changes to the battery chemistry or PCB type will load new default values into */
        /*    the d_st_#### params and Text Boxes. The user can then change the Text Boxes.  */
        /* 3) When Write Configuration button is selected the calibration data will be read  */
        /*    from Flash.  That data along with the values currently in the Text Boxes       */
        /*    either from defaults or user changes will be used to calculate the correct     */
        /*    values for the cf_#### params to load into Flash.  Also working values in the  */
        /*    GUI will be calculated and st_#### copies of the d_st_#### values will be      */
        /*    cast for writing to the flash.                                                 */
        /*************************************************************************************/
        ushort st_cell_voltage;
        ushort st_number_of_cells;
        ushort st_chemistry = 65535; //This value is preloaded so that the GUI when first calling UpdateSettingsTab will force a pre-population of the d_st_#### variables and corresponding TextBoxes
        ushort st_precondition_voltage;
        ushort st_precondition_current;
        ushort st_charge_current;
        ushort st_termination_current;
        ushort st_maximum_charge_time;
        ushort st_rapid_time_max;
        ushort st_restore_time_max;
        short st_minimum_temperature;
        short st_maximum_temperature;
        ushort st_termination_voltage;
        ushort st_UVLO_rising_voltage;
        ushort st_UVLO_falling_voltage;
        ushort st_wire_resistance;

        /*************************************************************************************/
        /* Calibration Data                                                                  */
        /*************************************************************************************/

        byte[] cal_data = new byte[64];
        double[] ibatslope = new double[4];
        double[] ibatintercept = new double[4];
        double[] vinslope = new double[4];
        double[] vinintercept = new double[4];
        double[] vbatslope = new double[4];
        double[] vbatintercept = new double[4];
        byte[] thermintercept = new byte[2];
        double[] ibat = new double[3];
        double[] vin = new double[3];
        double[] vbat = new double[3];
        double[] irange = new double[3];
        double[] vinrange = new double[3];
        double[] vbatrange = new double[3];
        //double thermistor_slope = (-37.459); //%%BRYAN%% Figure out where these constants are from
        double thermistor_intercept = 0; //
        double thermistor_slope = 14;  //%%BRYAN%% referencing the slope from MCP19125 internal temp sensor
        double thermistor_cal_temp = 28;

       #endregion

        #region GUI Control
        /*************************************************************************************/
        /* Below are the main functions for handling the GUI                                 */
        /*************************************************************************************/

        public Form1()
        {
            InitializeComponent();

            comboBoxNumberOfCells.Items.Add("1");
            comboBoxNumberOfCells.Items.Add("2");
            comboBoxNumberOfCells.Items.Add("3");
            comboBoxNumberOfCells.Items.Add("4");
            comboBoxNumberOfCells.Items.Add("5");
            comboBoxNumberOfCells.SelectedIndex = 1;

            comboBoxChemistry.Items.Add("Li-ion");
            comboBoxChemistry.Items.Add("NiMH");
            comboBoxChemistry.Items.Add("VRLA CCCP");
            comboBoxChemistry.Items.Add("VRLA Fast");
            comboBoxChemistry.Items.Add("LiFePO4");
            comboBoxChemistry.Items.Add("Super Capacitor");
            comboBoxChemistry.SelectedIndex = 0;

            comboBoxPCBType.Items.Add("MCP19125 ADM00745 Charger EVK");
            comboBoxPCBType.Items.Add("MCP19123 Buck-Boost Reference");
            comboBoxPCBType.Items.Add("MCP19111 Charger Reference");
            comboBoxPCBType.Items.Add("MCP19118 4-Switch Buck-Boost");
            comboBoxPCBType.Items.Add("MCP19119 4A Charger");
            comboBoxPCBType.Items.Add("PIC16F1716 + MCP1631 SEPIC");
            comboBoxPCBType.Items.Add("PIC16F886 + MCP1631 SEPIC");
            comboBoxPCBType.SelectedIndex = 0;

            textBoxUVLORising.Text = string.Format("{0:F3}", 1);    // Default value, non-zero

            buttonProfileStart.Enabled = true;
            //%%BRYAN%% changing the below to true from false so that the option to stop the charger is never grayed out for safety purposes.
            buttonProfileStop.Enabled = true;
            buttonSaveData.Enabled = true;

            labelProfilePackVoltage.Text = "";
            labelProfilePackCurrent.Text = "";
            labelProfileInputVoltage.Text = "";
            labelProfileChargerState.Text = "Not Connected";
            labelProfileChargeTime.Text = "";
            labelChargerStatus.Text = "";
            labelPackTemperatureRead.Text = "";
        }

        private void handlerSelectedIndexChanged(object sender, EventArgs e)  //This is the main handling function for moving between GUI tabs
        {
            if (tabControl1.SelectedTab == tabPageConfigure)
            {
                switch (comboBoxChemistry.Text)
                {
                    case ("Li-ion"):
                        if ((profilerunning == true) || (calibrating == true))
                        {
                            buttonReadConfiguration.Enabled = false;
                            buttonWriteConfiguration.Enabled = false;
                            comboBoxPCBType.Enabled = false;
                            comboBoxChemistry.Enabled = false;
                            checkBoxThermistor.Enabled = false;
                            textBoxCellVoltage.Enabled = false;
                            textBoxPreconditionCellVoltage.Enabled = false;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = false;
                            textBoxChargeCurrent.Enabled = false;
                            textBoxPreconditionCurrent.Enabled = false;
                            textBoxTerminationCurrent.Enabled = false;
                            textBoxMaximumChargeTime.Enabled = false;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = false;
                            textBoxUVLOFalling.Enabled = false;
                            textBoxWireRes.Enabled = false;
                        }
                        else
                        {
                            buttonReadConfiguration.Enabled = true;
                            buttonWriteConfiguration.Enabled = true;
                            comboBoxPCBType.Enabled = true;
                            comboBoxChemistry.Enabled = true;
                            checkBoxThermistor.Enabled = true;
                            textBoxCellVoltage.Enabled = true;
                            textBoxPreconditionCellVoltage.Enabled = true;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = true;
                            textBoxChargeCurrent.Enabled = true;
                            textBoxPreconditionCurrent.Enabled = true;
                            textBoxTerminationCurrent.Enabled = true;
                            textBoxMaximumChargeTime.Enabled = true;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = true;
                            textBoxUVLOFalling.Enabled = true;
                            textBoxWireRes.Enabled = true;

                            //%%BRYAN%% cleanup up the Input Voltage Supply Min: box and it's purpose.  It's backwards now. Set it to UVLO with a check if need be.
                        }
                        break;
                    case ("NiMH"):
                        if ((profilerunning == true) || (calibrating == true))
                        {
                            buttonReadConfiguration.Enabled = false;
                            buttonWriteConfiguration.Enabled = false;
                            comboBoxPCBType.Enabled = false;
                            comboBoxChemistry.Enabled = false;
                            checkBoxThermistor.Enabled = false;
                            textBoxCellVoltage.Enabled = false;
                            textBoxPreconditionCellVoltage.Enabled = false;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = false;
                            textBoxChargeCurrent.Enabled = false;
                            textBoxPreconditionCurrent.Enabled = false;
                            textBoxTerminationCurrent.Enabled = false;
                            textBoxMaximumChargeTime.Enabled = false;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = false;
                            textBoxUVLOFalling.Enabled = false;
                            textBoxWireRes.Enabled = false;
                        }
                        else
                        {
                            buttonReadConfiguration.Enabled = true;
                            buttonWriteConfiguration.Enabled = true;
                            comboBoxPCBType.Enabled = true;
                            comboBoxChemistry.Enabled = true;
                            checkBoxThermistor.Enabled = true;
                            textBoxCellVoltage.Enabled = true;
                            textBoxPreconditionCellVoltage.Enabled = true;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = true;
                            textBoxChargeCurrent.Enabled = true;
                            textBoxPreconditionCurrent.Enabled = true;
                            textBoxTerminationCurrent.Enabled = true;
                            textBoxMaximumChargeTime.Enabled = true;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = checkBoxThermistor.Checked;
                            textBoxMaximumTemperature.Enabled = checkBoxThermistor.Checked;
                            textBoxUVLOFalling.Enabled = true;
                            textBoxUVLORising.Enabled = true;
                            textBoxWireRes.Enabled = true;

                            //%%BRYAN%% cleanup up the Input Voltage Supply Min: box and it's purpose.  It's backwards now. Set it to UVLO with a check if need be.
                        }
                        break;
                    case ("VRLA CCCP"):
                        if ((profilerunning == true) || (calibrating == true))
                        {
                            buttonReadConfiguration.Enabled = false;
                            buttonWriteConfiguration.Enabled = false;
                            comboBoxPCBType.Enabled = false;
                            comboBoxChemistry.Enabled = false;
                            checkBoxThermistor.Enabled = false;
                            textBoxCellVoltage.Enabled = false;
                            textBoxPreconditionCellVoltage.Enabled = false;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = false;
                            textBoxChargeCurrent.Enabled = false;
                            textBoxPreconditionCurrent.Enabled = false;
                            textBoxTerminationCurrent.Enabled = false;
                            textBoxMaximumChargeTime.Enabled = false;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = false;
                            textBoxUVLOFalling.Enabled = false;
                            textBoxWireRes.Enabled = false;
                        }
                        else
                        {
                            buttonReadConfiguration.Enabled = true;
                            buttonWriteConfiguration.Enabled = true;
                            comboBoxPCBType.Enabled = true;
                            comboBoxChemistry.Enabled = true;
                            checkBoxThermistor.Enabled = true;
                            textBoxCellVoltage.Enabled = true;
                            textBoxPreconditionCellVoltage.Enabled = true;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = true;
                            textBoxChargeCurrent.Enabled = true;
                            textBoxPreconditionCurrent.Enabled = true;
                            textBoxTerminationCurrent.Enabled = true;
                            textBoxMaximumChargeTime.Enabled = true;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLOFalling.Enabled = true;
                            textBoxUVLORising.Enabled = true;
                            textBoxWireRes.Enabled = true;
                            //%%BRYAN%% cleanup up the Input Voltage Supply Min: box and it's purpose.  It's backwards now. Set it to UVLO with a check if need be.
                        }
                        break;
                    case ("VRLA Fast"):
                        if ((profilerunning == true) || (calibrating == true))
                        {
                            buttonReadConfiguration.Enabled = false;
                            buttonWriteConfiguration.Enabled = false;
                            comboBoxPCBType.Enabled = false;
                            comboBoxChemistry.Enabled = false;
                            checkBoxThermistor.Enabled = false;
                            textBoxCellVoltage.Enabled = false;
                            textBoxPreconditionCellVoltage.Enabled = false;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = false;
                            textBoxChargeCurrent.Enabled = false;
                            textBoxPreconditionCurrent.Enabled = false;
                            textBoxTerminationCurrent.Enabled = false;
                            textBoxMaximumChargeTime.Enabled = false;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = false;
                            textBoxUVLOFalling.Enabled = false;
                            textBoxWireRes.Enabled = false;
                        }
                        else
                        {
                            buttonReadConfiguration.Enabled = true;
                            buttonWriteConfiguration.Enabled = true;
                            comboBoxPCBType.Enabled = true;
                            comboBoxChemistry.Enabled = true;
                            checkBoxThermistor.Enabled = true;
                            textBoxCellVoltage.Enabled = true;
                            textBoxPreconditionCellVoltage.Enabled = true;
                            textBoxTerminationVoltage.Enabled = true;
                            comboBoxNumberOfCells.Enabled = true;
                            textBoxChargeCurrent.Enabled = true;
                            textBoxPreconditionCurrent.Enabled = true;
                            textBoxTerminationCurrent.Enabled = true;
                            textBoxMaximumChargeTime.Enabled = true;
                            textBoxRapidChargeTime.Enabled = true;
                            textBoxRestorationChargeTime.Enabled = true;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = true;
                            textBoxUVLOFalling.Enabled = true;
                            textBoxWireRes.Enabled = true;
                            //%%BRYAN%% cleanup up the Input Voltage Supply Min: box and it's purpose.  It's backwards now. Set it to UVLO with a check if need be.
                        }
                        break;
                    case ("LiFePO4"):
                        if ((profilerunning == true) || (calibrating == true))
                        {
                            buttonReadConfiguration.Enabled = false;
                            buttonWriteConfiguration.Enabled = false;
                            comboBoxPCBType.Enabled = false;
                            comboBoxChemistry.Enabled = false;
                            checkBoxThermistor.Enabled = false;
                            textBoxCellVoltage.Enabled = false;
                            textBoxPreconditionCellVoltage.Enabled = false;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = false;
                            textBoxChargeCurrent.Enabled = false;
                            textBoxPreconditionCurrent.Enabled = false;
                            textBoxTerminationCurrent.Enabled = false;
                            textBoxMaximumChargeTime.Enabled = false;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = false;
                            textBoxUVLOFalling.Enabled = false;
                            textBoxWireRes.Enabled = false;
                        }
                        else
                        {
                            buttonReadConfiguration.Enabled = true;
                            buttonWriteConfiguration.Enabled = true;
                            comboBoxPCBType.Enabled = true;
                            comboBoxChemistry.Enabled = true;
                            checkBoxThermistor.Enabled = true;
                            textBoxCellVoltage.Enabled = true;
                            textBoxPreconditionCellVoltage.Enabled = true;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = true;
                            textBoxChargeCurrent.Enabled = true;
                            textBoxPreconditionCurrent.Enabled = true;
                            textBoxTerminationCurrent.Enabled = true;
                            textBoxMaximumChargeTime.Enabled = true;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = true;
                            textBoxUVLOFalling.Enabled = true;
                            textBoxWireRes.Enabled = true;
                            //%%BRYAN%% cleanup up the Input Voltage Supply Min: box and it's purpose.  It's backwards now. Set it to UVLO with a check if need be.
                        }
                        break;
                    case ("Super Capacitor"):
                        if ((profilerunning == true) || (calibrating == true))
                        {
                            buttonReadConfiguration.Enabled = false;
                            buttonWriteConfiguration.Enabled = false;
                            comboBoxPCBType.Enabled = false;
                            comboBoxChemistry.Enabled = false;
                            checkBoxThermistor.Enabled = false;
                            textBoxCellVoltage.Enabled = false;
                            textBoxPreconditionCellVoltage.Enabled = false;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = false;
                            textBoxChargeCurrent.Enabled = false;
                            textBoxPreconditionCurrent.Enabled = false;
                            textBoxTerminationCurrent.Enabled = false;
                            textBoxMaximumChargeTime.Enabled = false;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = false;
                            textBoxUVLOFalling.Enabled = false;
                            textBoxWireRes.Enabled = false;
                        }
                        else
                        {
                            buttonReadConfiguration.Enabled = true;
                            buttonWriteConfiguration.Enabled = true;
                            comboBoxPCBType.Enabled = true;
                            comboBoxChemistry.Enabled = true;
                            checkBoxThermistor.Enabled = true;
                            textBoxCellVoltage.Enabled = true;
                            textBoxPreconditionCellVoltage.Enabled = false;
                            textBoxTerminationVoltage.Enabled = false;
                            comboBoxNumberOfCells.Enabled = true;
                            textBoxChargeCurrent.Enabled = true;
                            textBoxPreconditionCurrent.Enabled = false;
                            textBoxTerminationCurrent.Enabled = true;
                            textBoxMaximumChargeTime.Enabled = true;
                            textBoxRapidChargeTime.Enabled = false;
                            textBoxRestorationChargeTime.Enabled = false;
                            textBoxMinimumTemperature.Enabled = false;
                            textBoxMaximumTemperature.Enabled = false;
                            textBoxUVLORising.Enabled = true;
                            textBoxUVLOFalling.Enabled = true;
                            textBoxWireRes.Enabled = true;

                            //%%BRYAN%% cleanup up the Input Voltage Supply Min: box and it's purpose.  It's backwards now. Set it to UVLO with a check if need be.
                        }
                        break;
                    default:
                        //%%BRYAN%%// Add something here to handle default case
                        break;
                }
            }

            if (tabControl1.SelectedTab == tabPageProfile)
            {
                if (profilerunning == true)
                {
                    buttonProfileStart.Enabled = false;
                    //%%BRYAN%% changing the below to true from !calibrating so that the option to stop the charger is never grayed out for safety purposes.
                    buttonProfileStop.Enabled = true;
                }
                else
                {
                    buttonProfileStart.Enabled = !calibrating;
                    //%%BRYAN%% changing the below to true from false so that the option to stop the charger is never grayed out for safety purposes.
                    buttonProfileStop.Enabled = true;
                }
            }

            if (tabControl1.SelectedTab == tabPageCalibrate)
            {
                if (profilerunning == true)
                {
                    buttonReadCalibration.Enabled = false;
                    buttonWriteCalibration.Enabled = false;
                    buttonBeginCalibration.Enabled = false;

                    buttonLowA.Enabled = false;
                    buttonMidA.Enabled = false;
                    buttonHighA.Enabled = false;
                    buttonLowVbat.Enabled = false;
                    buttonMidVbat.Enabled = false;
                    buttonHighVbat.Enabled = false;
                    ButtonLowVin.Enabled = false;
                    ButtonMidVin.Enabled = false;
                    ButtonHighVin.Enabled = false;

                    textBoxLowAmp.Enabled = false;
                    textBoxMidAmp.Enabled = false;
                    textBoxHighAmp.Enabled = false;

                    textBoxLowVbat.Enabled = false;
                    textBoxMidVbat.Enabled = false;
                    textBoxHighVbat.Enabled = false;

                    textBoxLowVin.Enabled = false;
                    textBoxMidVin.Enabled = false;
                    textBoxHighVin.Enabled = false;

                    textBoxSetLowAmp.Enabled = false;
                    textBoxSetMidAmp.Enabled = false;
                    textBoxSetHighAmp.Enabled = false;

                    textBoxSetLowVbat.Enabled = false;
                    textBoxSetMidVbat.Enabled = false;
                    textBoxSetHighVbat.Enabled = false;

                    textBoxSetLowVin.Enabled = false;
                    textBoxSetMidVin.Enabled = false;
                    textBoxSetHighVin.Enabled = false;
                }
                else
                {
                    buttonBeginCalibration.Enabled = true;

                    if (calibrating)
                    {
                        buttonReadCalibration.Enabled = false;
                        buttonWriteCalibration.Enabled = true;
                        buttonLowA.Enabled = true;
                        buttonMidA.Enabled = true;
                        buttonHighA.Enabled = true;
                        buttonLowVbat.Enabled = true;
                        buttonMidVbat.Enabled = true;
                        buttonHighVbat.Enabled = true;
                        ButtonLowVin.Enabled = true;
                        ButtonMidVin.Enabled = true;
                        ButtonHighVin.Enabled = true;

                        textBoxLowAmp.Enabled = true;
                        textBoxMidAmp.Enabled = true;
                        textBoxHighAmp.Enabled = true;

                        textBoxLowVbat.Enabled = true;
                        textBoxMidVbat.Enabled = true;
                        textBoxHighVbat.Enabled = true;

                        textBoxLowVin.Enabled = true;
                        textBoxMidVin.Enabled = true;
                        textBoxHighVin.Enabled = true;

                        textBoxSetLowAmp.Enabled = true;
                        textBoxSetMidAmp.Enabled = true;
                        textBoxSetHighAmp.Enabled = true;

                        textBoxSetLowVbat.Enabled = true;
                        textBoxSetMidVbat.Enabled = true;
                        textBoxSetHighVbat.Enabled = true;

                        textBoxSetLowVin.Enabled = true;
                        textBoxSetMidVin.Enabled = true;
                        textBoxSetHighVin.Enabled = true;
                    }
                    else
                    {
                        buttonReadCalibration.Enabled = true;
                        buttonWriteCalibration.Enabled = false;
                        buttonLowA.Enabled = false;
                        buttonMidA.Enabled = false;
                        buttonHighA.Enabled = false;
                        buttonLowVbat.Enabled = false;
                        buttonMidVbat.Enabled = false;
                        buttonHighVbat.Enabled = false;
                        ButtonLowVin.Enabled = false;
                        ButtonMidVin.Enabled = false;
                        ButtonHighVin.Enabled = false;

                        textBoxLowAmp.Enabled = false;
                        textBoxMidAmp.Enabled = false;
                        textBoxHighAmp.Enabled = false;

                        textBoxLowVbat.Enabled = false;
                        textBoxMidVbat.Enabled = false;
                        textBoxHighVbat.Enabled = false;

                        textBoxLowVin.Enabled = false;
                        textBoxMidVin.Enabled = false;
                        textBoxHighVin.Enabled = false;

                        textBoxSetLowAmp.Enabled = false;
                        textBoxSetMidAmp.Enabled = false;
                        textBoxSetHighAmp.Enabled = false;

                        textBoxSetLowVbat.Enabled = false;
                        textBoxSetMidVbat.Enabled = false;
                        textBoxSetHighVbat.Enabled = false;

                        textBoxSetLowVin.Enabled = false;
                        textBoxSetMidVin.Enabled = false;
                        textBoxSetHighVin.Enabled = false;
                    }
                }
            }
        }

        private void UpdateSettingsTab()  // Called by changes to Battery Chemistry or PCB Type or a ReadConfiguration()
        {
            int chemistry;

            if (comboBoxChemistry.Text == "Li-ion")
            {
                chemistry = 0;
            }
            else if (comboBoxChemistry.Text == "NiMH")
            {
                chemistry = 1;
            }
            else if (comboBoxChemistry.Text == "VRLA CCCP")
            {
                chemistry = 2;
            }
            else if (comboBoxChemistry.Text == "VRLA Fast")
            {
                chemistry = 3;
            }
            else if (comboBoxChemistry.Text == "LiFePO4")
            {
                chemistry = 4;
            }
            else if (comboBoxChemistry.Text == "Super Capacitor")
            {
                chemistry = 5;
            }
            else
            {
                return;
            }

            //**BRYAN** commenting out to be compatible with new peak/poke SFR_DROP_DOWN list
            //if (profile_data[27] == 0)//Check and See if the Profile_Data[27] is lost, but the ComboBox is selected and fix.
            {
                if (comboBoxPCBType.Text == "MCP19111 Charger Reference")
                    profile_data[27] = 1;
                if (comboBoxPCBType.Text == "PIC16F1716 + MCP1631 SEPIC")
                    profile_data[27] = 2;
                if (comboBoxPCBType.Text == "PIC16F886 + MCP1631 SEPIC")
                    profile_data[27] = 3;
                if (comboBoxPCBType.Text == "MCP19118 4-Switch Buck-Boost")
                    profile_data[27] = 4;
                if (comboBoxPCBType.Text == "MCP19123 Buck-Boost Reference")
                    profile_data[27] = 5;
                if (comboBoxPCBType.Text == "MCP19125 ADM00745 Charger EVK")
                    profile_data[27] = 6;
                if (comboBoxPCBType.Text == "MCP19119 4A Charger")
                    profile_data[27] = 7;
            }
            if (profile_data[27] == 1)
            {
                labelPCBtype.Text = "MCP19111 Charger Reference";
                comboBoxPCBType.Text = string.Format("MCP19111 Charger Reference");
                SFR_Drop_Down.Items.Add("");
                SFR_Drop_Down.Items.Add("BUFFCON");
                SFR_Drop_Down.Items.Add("PE1");
                SFR_Drop_Down.Items.Add("DEADCON");
                SFR_Drop_Down.Items.Add("ABECON");
                SFR_Drop_Down.Items.Add("VZCCON");
                SFR_Drop_Down.Items.Add("CMPZCON");
                SFR_Drop_Down.Items.Add("SLPCRCON");
                SFR_Drop_Down.Items.Add("SLVGNCON");
                SFR_Drop_Down.Items.Add("CSGSCON");
                SFR_Drop_Down.Items.Add("CSDGCON");
                SFR_Drop_Down.Items.Add("OCCON");
                SFR_Drop_Down.Items.Add("OVCCON");
                SFR_Drop_Down.Items.Add("OVFCON");
                SFR_Drop_Down.SelectedIndex = 0;
            }
            if (profile_data[27] == 2)
            {
                labelPCBtype.Text = "PIC16F1716 + MCP1631 SEPIC";
                comboBoxPCBType.Text = string.Format("PIC16F1716 + MCP1631 SEPIC");
                SFR_Drop_Down.Items.Clear();
            }
            if (profile_data[27] == 3)
            {
                labelPCBtype.Text = "PIC16F886 + MCP1631 SEPIC";
                comboBoxPCBType.Text = string.Format("PIC16F886 + MCP1631 SEPIC");
                SFR_Drop_Down.Items.Clear();
            }
            if (profile_data[27] == 4)
            {
                labelPCBtype.Text = "MCP19118 4-Switch Buck-Boost";
                comboBoxPCBType.Text = string.Format("MCP19118 4-Switch Buck-Boost");
                SFR_Drop_Down.Items.Add("");
                SFR_Drop_Down.Items.Add("BUFFCON");
                SFR_Drop_Down.Items.Add("PE1");
                SFR_Drop_Down.Items.Add("DEADCON");
                SFR_Drop_Down.Items.Add("ABECON");
                SFR_Drop_Down.Items.Add("VZCCON");
                SFR_Drop_Down.Items.Add("CMPZCON");
                SFR_Drop_Down.Items.Add("SLPCRCON");
                SFR_Drop_Down.Items.Add("SLVGNCON");
                SFR_Drop_Down.Items.Add("CSGSCON");
                SFR_Drop_Down.Items.Add("CSDGCON");
                SFR_Drop_Down.Items.Add("OCCON");
                SFR_Drop_Down.Items.Add("OVCCON");
                SFR_Drop_Down.Items.Add("OVFCON");
                SFR_Drop_Down.SelectedIndex = 0;
            }
            if (profile_data[27] == 5)
            {
                labelPCBtype.Text = "MCP19123 Buck-Boost Reference";
                comboBoxPCBType.Text = string.Format("MCP19123 Buck-Boost Reference");
                SFR_Drop_Down.Items.Clear();
            }
            if (profile_data[27] == 6)
            {
                labelPCBtype.Text = "MCP19125 ADM00745 Charger EVK";
                comboBoxPCBType.Text = string.Format("MCP19125 ADM00745 Charger EVK");
                SFR_Drop_Down.Items.Clear();
            }
            if (profile_data[27] == 7)
            {
                labelPCBtype.Text = "MCP19119 4A Charger";
                comboBoxPCBType.Text = string.Format("MCP19119 4A Charger");
                SFR_Drop_Down.Items.Add("");
                SFR_Drop_Down.Items.Add("BUFFCON");
                SFR_Drop_Down.Items.Add("PE1");
                SFR_Drop_Down.Items.Add("DEADCON");
                SFR_Drop_Down.Items.Add("ABECON");
                SFR_Drop_Down.Items.Add("VZCCON");
                SFR_Drop_Down.Items.Add("CMPZCON");
                SFR_Drop_Down.Items.Add("SLPCRCON");
                SFR_Drop_Down.Items.Add("SLVGNCON");
                SFR_Drop_Down.Items.Add("CSGSCON");
                SFR_Drop_Down.Items.Add("CSDGCON");
                SFR_Drop_Down.Items.Add("OCCON");
                SFR_Drop_Down.Items.Add("OVCCON");
                SFR_Drop_Down.Items.Add("OVFCON");
                SFR_Drop_Down.SelectedIndex = 0;
            }

            double d_st_cell_voltage;
            double d_st_number_of_cells;
            double d_st_precondition_voltage;
            double d_st_precondition_current;
            double d_st_charge_current;
            double d_st_termination_current;
            double d_st_termination_voltage;
            double d_st_maximum_charge_time;
            double d_st_rapid_time_max;
            double d_st_restore_time_max;
            double d_st_minimum_temperature;
            double d_st_maximum_temperature;
            double d_st_UVLO_rising_voltage;
            double d_st_UVLO_falling_voltage;
            double d_st_wire_resistance = 0;
            double temp1;
            temp1 = ReadConfigurationDataU16(26); //Loads the UVLO ON threshold the ADC needs to measure.
            d_st_UVLO_rising_voltage = (double)((temp1 - vinintercept[3]) / vinslope[3]); //Use the calibration values to approximate UVLO_On
            textBoxUVLORising.Text = string.Format("{0:F2}", d_st_UVLO_rising_voltage);      // Input Undervoltage lockout setpoint
            temp1 = ReadConfigurationDataU16(24); //Loads the UVLO OFF threshold the ADC needs to measure.
            d_st_UVLO_falling_voltage = (double)((temp1 - vinintercept[3]) / vinslope[3]); //Use the calibration values to approximate UVLO_On
            textBoxUVLOFalling.Text = string.Format("{0:F2}", d_st_UVLO_falling_voltage);      // Input Undervoltage lockout setpoint

            /* Is this a current setting? Then leave everything alone based on the (presumably) already read configuration from Flash. */
            if (chemistry == st_chemistry)
            {
                d_st_cell_voltage = (double)st_cell_voltage / 1000.0;
                d_st_number_of_cells = (double)st_number_of_cells;
                d_st_precondition_voltage = (double)st_precondition_voltage / 1000.0;
                d_st_precondition_current = (double)st_precondition_current / 1000.0;
                d_st_charge_current = (double)st_charge_current / 1000.0;
                d_st_termination_current = (double)st_termination_current / 1000.0;
                d_st_termination_voltage = (double)st_termination_voltage / 1000.0;
                d_st_maximum_charge_time = (double)st_maximum_charge_time;
                d_st_rapid_time_max = (double)st_rapid_time_max;
                d_st_restore_time_max = (double)st_restore_time_max;
                d_st_minimum_temperature = (double)st_minimum_temperature;
                d_st_maximum_temperature = (double)st_maximum_temperature;
                d_st_wire_resistance = (double)st_wire_resistance;

            }
            /* If not then put in some default values for the chemistry selected. */
            else
            {
                if (chemistry == 0) /* Li-ion */
                {
                    d_st_cell_voltage = 4.2;
                    d_st_number_of_cells = 2;
                    d_st_precondition_voltage = 3.0;
                    d_st_precondition_current = 0.100;
                    d_st_charge_current = 1.00;
                    d_st_termination_current = 0.100;
                    d_st_termination_voltage = 0.00;
                    d_st_maximum_charge_time = 60 * 2.5;
                    d_st_rapid_time_max = 0;
                    d_st_restore_time_max = 0;
                    d_st_minimum_temperature = 0;
                    d_st_maximum_temperature = 0;
                }
                else if (chemistry == 2) /* VRLA CCCP */
                {
                    d_st_cell_voltage = 2.0;
                    d_st_number_of_cells = 3;
                    d_st_precondition_voltage = 1.8;
                    d_st_precondition_current = 0.20;   //Aug. 25 2014 0.675;  // 0.1CA
                    d_st_charge_current = 1.800;            // 0.4CA
                    d_st_termination_current = 0.100;       // 0.02CA(0.05CA) or > 0.1A
                    d_st_termination_voltage = 0.00;
                    d_st_maximum_charge_time = 60 * 12;
                    d_st_rapid_time_max = 0;
                    d_st_restore_time_max = 0;
                    d_st_minimum_temperature = 0;
                    d_st_maximum_temperature = 0;
                }
                else if (chemistry == 3) /* VRLA Fast */ /*0.3CA is best*/
                {
                    d_st_cell_voltage = 2.0;
                    d_st_number_of_cells = 3;
                    d_st_precondition_voltage = 1.8;    /* 1.5V */
                    d_st_precondition_current = 0.20;   // Aug. 25 2014 0.450;      // 0.1CA
                    d_st_charge_current = 1.800;            // 0.4CA
                    d_st_termination_current = 0.675;       // 0.15CA
                    d_st_termination_voltage = 2.69;        // 2.72;    // Aug. 25 2014 modified
                    d_st_maximum_charge_time = 60 * 10;
                    d_st_rapid_time_max = 120;
                    d_st_restore_time_max = 180;
                    d_st_minimum_temperature = 0;
                    d_st_maximum_temperature = 0;
                }
                else if (chemistry == 4) /* LiFePO4 */
                {
                    d_st_cell_voltage = 3.7;
                    d_st_number_of_cells = 1;
                    d_st_precondition_voltage = 1.7;
                    d_st_precondition_current = 0.100;
                    d_st_charge_current = 1.00;
                    d_st_termination_current = 0.100;
                    d_st_termination_voltage = 3.80;
                    d_st_maximum_charge_time = 60 * 2.5;
                    d_st_rapid_time_max = 0;
                    d_st_restore_time_max = 0;
                    d_st_minimum_temperature = 0;
                    d_st_maximum_temperature = 0;
                }
                else if (chemistry == 5) /* Super Capacitor */
                {
                    d_st_cell_voltage = 2.7;
                    d_st_number_of_cells = 2;
                    d_st_precondition_voltage = 0;
                    d_st_precondition_current = 0;
                    d_st_charge_current = 1.00;
                    d_st_termination_current = 0.100;
                    d_st_termination_voltage = 0.00;
                    d_st_maximum_charge_time = 60 * 2.5;
                    d_st_rapid_time_max = 0;
                    d_st_restore_time_max = 0;
                    d_st_minimum_temperature = 0;
                    d_st_maximum_temperature = 0;
                }
                else /* NiMH */ //%%BRYAN%% Why not just call out an else if (chemistry == 1)?  This seems like it could be an error.
                {
                    d_st_cell_voltage = 1.2;
                    d_st_number_of_cells = 7;
                    d_st_precondition_voltage = 0.8;
                    d_st_precondition_current = 0.100;
                    d_st_charge_current = 1.00;
                    d_st_termination_current = 0.100;
                    d_st_termination_voltage = 1.8;
                    d_st_maximum_charge_time = 60 * 15;
                    d_st_rapid_time_max = 90;
                    d_st_restore_time_max = 60;
                    d_st_minimum_temperature = 0;
                    d_st_maximum_temperature = 50;
                }
            }

            if (chemistry == 0) /* Li-ion */
            {
                labelPreconditionCurrent.Text = "Precondition Current:";
                labelChargeCurrent.Text = "Charge Current:";
                labelTermination.Text = "Termination Current:";

                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");

                textBoxTerminationVoltage.Text = "";
                textBoxRapidChargeTime.Text = "";
                textBoxRestorationChargeTime.Text = "";
                textBoxMinimumTemperature.Text = "";
                textBoxMaximumTemperature.Text = "";

                buttonReadConfiguration.Enabled = true;
                buttonWriteConfiguration.Enabled = true;
                comboBoxPCBType.Enabled = true;
                comboBoxChemistry.Enabled = true;
                checkBoxThermistor.Enabled = true;
                textBoxCellVoltage.Enabled = true;
                textBoxPreconditionCellVoltage.Enabled = true;
                comboBoxNumberOfCells.Enabled = true;
                textBoxChargeCurrent.Enabled = true;
                textBoxPreconditionCurrent.Enabled = true;
                textBoxTerminationCurrent.Enabled = true;
                textBoxMaximumChargeTime.Enabled = true;
                textBoxMinimumTemperature.Enabled = false;
                textBoxMaximumTemperature.Enabled = false;
                textBoxUVLORising.Enabled = true;
                textBoxUVLOFalling.Enabled = true;
                textBoxWireRes.Enabled = true;

                labelPreconditionCellVoltage.Enabled = true;
                labelPreconditionVoltageUnits.Enabled = true;
                labelPreconditionCurrent.Enabled = true;
                labelPreconditionCurrentUnits.Enabled = true;
                labelRapidTime.Enabled = false;
                labelRestorationTime.Enabled = false;
                textBoxRapidChargeTime.Enabled = false;
                textBoxRestorationChargeTime.Enabled = false;
                labelRapidChargeTimeUnits.Enabled = false;
                labelRestorationChargeTimeUnits.Enabled = false;
                textBoxTerminationVoltage.Enabled = false;
                labelTerminationVoltage.Enabled = false;
                labelTerminationVoltageUnits.Enabled = false;
                checkBoxThermistor.Checked = false;
            }
            else if (chemistry == 1) /* NiMH */
            {
                labelPreconditionCurrent.Text = "Restoration Current:";
                labelChargeCurrent.Text = "Rapid Charge Current:";
                labelTermination.Text = "Trickle Charge Current:";

                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");
                comboBoxNumberOfCells.Items.Add("6");
                comboBoxNumberOfCells.Items.Add("7");
                comboBoxNumberOfCells.Items.Add("8");

                textBoxTerminationVoltage.Text = string.Format("{0:F3}", d_st_termination_voltage);
                textBoxRapidChargeTime.Text = string.Format("{0:F0}", d_st_rapid_time_max);
                textBoxRestorationChargeTime.Text = string.Format("{0:F0}", d_st_restore_time_max);

                /* Temperature detection disabled */
                if ((d_st_minimum_temperature > 100.0) || (d_st_maximum_temperature > 100.0))
                {
                    checkBoxThermistor.Checked = false;
                    textBoxMinimumTemperature.Text = string.Format("{0}", "0");
                    textBoxMaximumTemperature.Text = string.Format("{0}", "50");
                }
                else
                {
                    checkBoxThermistor.Checked = false;
                    textBoxMinimumTemperature.Text = string.Format("{0}", d_st_minimum_temperature);
                    textBoxMaximumTemperature.Text = string.Format("{0}", d_st_maximum_temperature);
                }

                buttonReadConfiguration.Enabled = true;
                buttonWriteConfiguration.Enabled = true;
                comboBoxPCBType.Enabled = true;
                comboBoxChemistry.Enabled = true;
                checkBoxThermistor.Enabled = true;
                textBoxCellVoltage.Enabled = true;
                textBoxPreconditionCellVoltage.Enabled = true;
                comboBoxNumberOfCells.Enabled = true;
                textBoxChargeCurrent.Enabled = true;
                textBoxPreconditionCurrent.Enabled = true;
                textBoxTerminationCurrent.Enabled = true;
                textBoxMaximumChargeTime.Enabled = true;
                textBoxMinimumTemperature.Enabled = checkBoxThermistor.Checked;
                textBoxMaximumTemperature.Enabled = checkBoxThermistor.Checked;
                textBoxUVLOFalling.Enabled = true;
                textBoxUVLORising.Enabled = true;
                textBoxWireRes.Enabled = true;

                labelPreconditionCellVoltage.Enabled = true;
                labelPreconditionVoltageUnits.Enabled = true;
                labelPreconditionCurrent.Enabled = true;
                labelPreconditionCurrentUnits.Enabled = true;
                labelRapidTime.Enabled = true;
                labelRestorationTime.Enabled = true;
                textBoxRapidChargeTime.Enabled = true;
                textBoxRestorationChargeTime.Enabled = true;
                labelRapidChargeTimeUnits.Enabled = true;
                labelRestorationChargeTimeUnits.Enabled = true;
                textBoxTerminationVoltage.Enabled = true;
                labelTerminationVoltage.Enabled = true;
                labelTerminationVoltageUnits.Enabled = true;
            }
            else if (chemistry == 2) /* VRLA CCCP */
            {
                labelPreconditionCurrent.Text = "Precondition Current:";
                labelChargeCurrent.Text = "Charge Current:";
                labelTermination.Text = "Termination Current:";

                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");
                comboBoxNumberOfCells.Items.Add("6");

                textBoxTerminationVoltage.Text = "";
                textBoxRapidChargeTime.Text = "";
                textBoxRestorationChargeTime.Text = "";
                textBoxMinimumTemperature.Text = "";
                textBoxMaximumTemperature.Text = "";

                buttonReadConfiguration.Enabled = true;
                buttonWriteConfiguration.Enabled = true;
                comboBoxPCBType.Enabled = true;
                comboBoxChemistry.Enabled = true;
                checkBoxThermistor.Enabled = true;
                textBoxCellVoltage.Enabled = true;
                textBoxPreconditionCellVoltage.Enabled = true;
                comboBoxNumberOfCells.Enabled = true;
                textBoxChargeCurrent.Enabled = true;
                textBoxPreconditionCurrent.Enabled = true;
                textBoxTerminationCurrent.Enabled = true;
                textBoxMaximumChargeTime.Enabled = true;
                textBoxMinimumTemperature.Enabled = false;
                textBoxMaximumTemperature.Enabled = false;
                textBoxUVLOFalling.Enabled = true;
                textBoxUVLORising.Enabled = true;
                textBoxWireRes.Enabled = true;

                labelPreconditionCellVoltage.Enabled = true;
                labelPreconditionVoltageUnits.Enabled = true;
                labelPreconditionCurrent.Enabled = true;
                labelPreconditionCurrentUnits.Enabled = true;
                labelRapidTime.Enabled = false;
                labelRestorationTime.Enabled = false;
                textBoxRapidChargeTime.Enabled = false;
                textBoxRestorationChargeTime.Enabled = false;
                labelRapidChargeTimeUnits.Enabled = false;
                labelRestorationChargeTimeUnits.Enabled = false;
                textBoxTerminationVoltage.Enabled = false;
                labelTerminationVoltage.Enabled = false;
                labelTerminationVoltageUnits.Enabled = false;
                checkBoxThermistor.Checked = false;
            }
            else if (chemistry == 3) /* VRLA Fast */
            {
                labelPreconditionCurrent.Text = "Restoration Current:";
                labelChargeCurrent.Text = "Rapid Charge Current:";
                labelTermination.Text = "Trickle Charge Current:";

                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");
                comboBoxNumberOfCells.Items.Add("6");

                textBoxTerminationVoltage.Text = string.Format("{0:F3}", d_st_termination_voltage);
                textBoxRapidChargeTime.Text = string.Format("{0:F0}", d_st_rapid_time_max);
                textBoxRestorationChargeTime.Text = string.Format("{0:F0}", d_st_restore_time_max);
                textBoxMinimumTemperature.Text = "";
                textBoxMaximumTemperature.Text = "";

                buttonReadConfiguration.Enabled = true;
                buttonWriteConfiguration.Enabled = true;
                comboBoxPCBType.Enabled = true;
                comboBoxChemistry.Enabled = true;
                checkBoxThermistor.Enabled = true;
                textBoxCellVoltage.Enabled = true;
                textBoxPreconditionCellVoltage.Enabled = true;
                comboBoxNumberOfCells.Enabled = true;
                textBoxChargeCurrent.Enabled = true;
                textBoxPreconditionCurrent.Enabled = true;
                textBoxTerminationCurrent.Enabled = true;
                textBoxMaximumChargeTime.Enabled = true;
                textBoxMinimumTemperature.Enabled = false;
                textBoxMaximumTemperature.Enabled = false;
                textBoxUVLORising.Enabled = true;
                textBoxUVLOFalling.Enabled = true;
                textBoxWireRes.Enabled = true;

                labelPreconditionCellVoltage.Enabled = true;
                labelPreconditionVoltageUnits.Enabled = true;
                labelPreconditionCurrent.Enabled = true;
                labelPreconditionCurrentUnits.Enabled = true;
                labelRapidTime.Enabled = true;
                labelRestorationTime.Enabled = true;
                textBoxRapidChargeTime.Enabled = true;
                textBoxRestorationChargeTime.Enabled = true;
                labelRapidChargeTimeUnits.Enabled = true;
                labelRestorationChargeTimeUnits.Enabled = true;
                textBoxTerminationVoltage.Enabled = true;
                labelTerminationVoltage.Enabled = true;
                labelTerminationVoltageUnits.Enabled = true;
                checkBoxThermistor.Checked = false;
            }
            else if (chemistry == 4) /* LiFePO4 */
            {
                labelPreconditionCurrent.Text = "Precondition Current:";
                labelChargeCurrent.Text = "Charge Current:";
                labelTermination.Text = "Termination Current:";

                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");

                textBoxTerminationVoltage.Text = "";
                textBoxRapidChargeTime.Text = "";
                textBoxRestorationChargeTime.Text = "";
                textBoxMinimumTemperature.Text = "";
                textBoxMaximumTemperature.Text = "";

                buttonReadConfiguration.Enabled = true;
                buttonWriteConfiguration.Enabled = true;
                comboBoxPCBType.Enabled = true;
                comboBoxChemistry.Enabled = true;
                checkBoxThermistor.Enabled = true;
                textBoxCellVoltage.Enabled = true;
                textBoxPreconditionCellVoltage.Enabled = true;
                comboBoxNumberOfCells.Enabled = true;
                textBoxChargeCurrent.Enabled = true;
                textBoxPreconditionCurrent.Enabled = true;
                textBoxTerminationCurrent.Enabled = true;
                textBoxMaximumChargeTime.Enabled = true;
                textBoxMinimumTemperature.Enabled = false;
                textBoxMaximumTemperature.Enabled = false;
                textBoxUVLORising.Enabled = true;
                textBoxUVLOFalling.Enabled = true;
                textBoxWireRes.Enabled = true;

                labelPreconditionCellVoltage.Enabled = true;
                labelPreconditionVoltageUnits.Enabled = true;
                labelPreconditionCurrent.Enabled = true;
                labelPreconditionCurrentUnits.Enabled = true;
                labelRapidTime.Enabled = false;
                labelRestorationTime.Enabled = false;
                textBoxRapidChargeTime.Enabled = false;
                textBoxRestorationChargeTime.Enabled = false;
                labelRapidChargeTimeUnits.Enabled = false;
                labelRestorationChargeTimeUnits.Enabled = false;
                textBoxTerminationVoltage.Enabled = false;
                labelTerminationVoltage.Enabled = false;
                labelTerminationVoltageUnits.Enabled = false;
                checkBoxThermistor.Checked = false;
            }
            else if (chemistry == 5) /* Super Capacitor */
            {
                labelChargeCurrent.Text = "Charge Current:";
                labelTermination.Text = "Termination Current:";

                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");

                textBoxTerminationVoltage.Text = "";
                textBoxRapidChargeTime.Text = "";
                textBoxRestorationChargeTime.Text = "";
                textBoxMinimumTemperature.Text = "";
                textBoxMaximumTemperature.Text = "";

                buttonReadConfiguration.Enabled = true;
                buttonWriteConfiguration.Enabled = true;
                comboBoxPCBType.Enabled = true;
                comboBoxChemistry.Enabled = true;
                checkBoxThermistor.Enabled = true;
                textBoxCellVoltage.Enabled = true;
                textBoxPreconditionCellVoltage.Enabled = false;
                comboBoxNumberOfCells.Enabled = true;
                textBoxChargeCurrent.Enabled = true;
                textBoxPreconditionCurrent.Enabled = false;
                textBoxTerminationCurrent.Enabled = true;
                textBoxMaximumChargeTime.Enabled = true;
                textBoxMinimumTemperature.Enabled = false;
                textBoxMaximumTemperature.Enabled = false;
                textBoxUVLORising.Enabled = true;
                textBoxUVLOFalling.Enabled = true;
                textBoxWireRes.Enabled = true;


                labelPreconditionCellVoltage.Enabled = false;
                labelPreconditionVoltageUnits.Enabled = false;
                labelPreconditionCurrent.Enabled = false;
                labelPreconditionCurrentUnits.Enabled = false;
                labelRapidTime.Enabled = false;
                labelRestorationTime.Enabled = false;
                textBoxRapidChargeTime.Enabled = false;
                textBoxRestorationChargeTime.Enabled = false;
                labelRapidChargeTimeUnits.Enabled = false;
                labelRestorationChargeTimeUnits.Enabled = false;
                textBoxTerminationVoltage.Enabled = false;
                labelTerminationVoltage.Enabled = false;
                labelTerminationVoltageUnits.Enabled = false;
                checkBoxThermistor.Checked = false;
            }
            textBoxCellVoltage.Text = string.Format("{0:F3}", d_st_cell_voltage);
            textBoxPreconditionCellVoltage.Text = string.Format("{0:F3}", d_st_precondition_voltage);
            textBoxPreconditionCurrent.Text = string.Format("{0:F3}", d_st_precondition_current);
            textBoxChargeCurrent.Text = string.Format("{0:F3}", d_st_charge_current);
            textBoxTerminationCurrent.Text = string.Format("{0:F3}", d_st_termination_current);
            textBoxMaximumChargeTime.Text = string.Format("{0:F0}", d_st_maximum_charge_time);
            comboBoxNumberOfCells.Text = string.Format("{0:F0}", d_st_number_of_cells);
            textBoxWireRes.Text = string.Format("{0:F0}", d_st_wire_resistance);
        }

        private void comboBoxChemistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSettingsTab();
            checkBoxThermistor_CheckedChanged(sender, e);
        } 

        private void comboBoxPCBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSettingsTab();
            checkBoxThermistor_CheckedChanged(sender, e);
        }

        private void checkBoxThermistor_CheckedChanged(object sender, EventArgs e)  // Called by changes to battery chemistry or PCB type selections
        {
            /* ew, et, and en are tokens that are used in various functions to turn GUI Configuration label boxes on and off for a particular chemistry. */
            /* %%BRYAN%% I suppose it's nice if it can be logically grouped to do this rather than keep track of a bunch of TRUE and FALSE settings. */
            /* ew is associated with an external thermistor being enabled and the associated min and max charging temperatures.  NiMH actually requires it. */
            /* et is associated with timers for rapid charge and restoration charge.  And also termination voltage.*/
            /* en is associated with just about everything else not listed above.*/
            bool ew = false;

            if ((comboBoxChemistry.Text == "NiMH") && (checkBoxThermistor.Checked == true))
            {
                ew = true;
            }

            labelMinimumTemperatureUnits.Enabled = ew;
            labelMaximumTemperatureUnits.Enabled = ew;
            textBoxMinimumTemperature.Enabled = ew;
            textBoxMaximumTemperature.Enabled = ew;
            labelMinimumTemperature.Enabled = ew;
            labelMaximumTemperature.Enabled = ew;
        }

        /* handlerCellVoltageChanged takes care of the text display that makes a "reccomendation for input range" on the configuration tab based on the inputs. */
        /* This is hardly an important piece of code, but we should check this our for accuracy later %%BRYAN%%.  */

        private void handlerCellVoltageChanged(object sender, EventArgs e)  // Called when the number of cells or charge current are altered.
        {
            bool b = true;
            string pv;

            double cell_voltage = ToDouble(textBoxCellVoltage.Text);
            double number_of_cells = ToDouble(comboBoxNumberOfCells.Text);
            double Intern_A1 = ToDouble(textBoxChargeCurrent.Text);
            double termination_voltage = ToDouble(textBoxTerminationVoltage.Text);

            if ((cell_voltage > 5.0) || (cell_voltage < 1.0))
            {
                b = false;
            }

            if (b)
            {
                pv = string.Format("{0:F3} V", cell_voltage * number_of_cells);  // Calculate the new pack voltage
            }
            else
            {
                pv = "Invalid";
            }

            labelPackVoltage.Text = pv;

            if (comboBoxChemistry.Text == "Li-ion")
            {
                double Intern_V1 = ((number_of_cells * cell_voltage) + 0.200);
                double Intern_V2 = Intern_V1 + 2.0;
                if (Intern_V2 < 6.0) Intern_V2 = 6.0;
                double Intern_P1 = (Intern_V1 * Intern_A1) / 0.85;
                labelInputRangeCalculation.Text = string.Format("{0:F1} - 32.0 V / {2:F1} - {1:F1} A", Intern_V2, (Intern_P1 / Intern_V2), (Intern_P1 / 32.0));
            }
            else if (comboBoxChemistry.Text == "NiMH")
            {
                double Intern_V1 = ((number_of_cells * termination_voltage) + 0.200);
                double Intern_V2 = Intern_V1 + 2.0;
                if (Intern_V2 < 6.0) Intern_V2 = 6.0;
                double Intern_P1 = (Intern_V1 * Intern_A1) / 0.85;
                labelInputRangeCalculation.Text = string.Format("{0:F1} - 32.0 V / {2:F1} - {1:F1} A", Intern_V2, (Intern_P1 / Intern_V2), (Intern_P1 / 32.0));
            }
            else if (comboBoxChemistry.Text == "VRLA CCCP")
            {
                double Intern_V1 = ((number_of_cells * cell_voltage + 0.792) + 0.200);
                double Intern_V2 = Intern_V1 + 2.0;
                if (Intern_V2 < 6.0) Intern_V2 = 6.0;
                double Intern_P1 = (Intern_V1 * Intern_A1) / 0.85;
                labelInputRangeCalculation.Text = string.Format("{0:F1} - 32.0 V / {2:F1} - {1:F1} A", Intern_V2, (Intern_P1 / Intern_V2), (Intern_P1 / 32.0));
            }
            else if (comboBoxChemistry.Text == "VRLA Fast")
            {
                double Intern_V1 = ((number_of_cells * termination_voltage * 1.03) + 0.200);
                double Intern_V2 = Intern_V1 + 2.0;
                if (Intern_V2 < 6.0) Intern_V2 = 6.0;
                double Intern_P1 = (Intern_V1 * Intern_A1) / 0.85;
                labelInputRangeCalculation.Text = string.Format("{0:F1} - 32.0 V / {2:F1} - {1:F1} A", Intern_V2, (Intern_P1 / Intern_V2), (Intern_P1 / 32.0));
            }
            else if (comboBoxChemistry.Text == "LiFePO4")
            {
                double Intern_V1 = ((number_of_cells * cell_voltage) + 0.200);
                double Intern_V2 = Intern_V1 + 2.0;
                if (Intern_V2 < 6.0) Intern_V2 = 6.0;
                double Intern_P1 = (Intern_V1 * Intern_A1) / 0.85;
                labelInputRangeCalculation.Text = string.Format("{0:F1} - 32.0 V / {2:F1} - {1:F1} A", Intern_V2, (Intern_P1 / Intern_V2), (Intern_P1 / 32.0));
            }
            else if (comboBoxChemistry.Text == "Super Capacitor")
            {
                double Intern_V1 = ((number_of_cells * cell_voltage) + 0.200);
                double Intern_V2 = Intern_V1 + 2.0;
                if (Intern_V2 < 6.0) Intern_V2 = 6.0;
                double Intern_P1 = (Intern_V1 * Intern_A1) / 0.85;
                labelInputRangeCalculation.Text = string.Format("{0:F1} - 32.0 V / {2:F1} - {1:F1} A", Intern_V2, (Intern_P1 / Intern_V2), (Intern_P1 / 32.0));
            }
            else
            {
                double Intern_V1 = ((number_of_cells * cell_voltage) + 0.500);
                double Intern_V2 = Intern_V1 + 2.0;
                if (Intern_V2 < 6.0) Intern_V2 = 6.0;
                double Intern_P1 = (Intern_V1 * Intern_A1) / 0.85;
                labelInputRangeCalculation.Text = string.Format("{0:F1} - 32.0 V / {2:F1} - {1:F1} A", Intern_V2, (Intern_P1 / Intern_V2), (Intern_P1 / 32.0));
            }
        }

        private void NumberOfCellsChanged(object sender, EventArgs e)
        {
            handlerCellVoltageChanged(sender, e);
        }

        private void ChargeCurrentChanged(object sender, EventArgs e)
        {
            handlerCellVoltageChanged(sender, e);
        }
        #endregion

        #region Charger Control
        /*************************************************************************************/
        /* Below are the functions for controlling the charger and charting the performance. */
        /*************************************************************************************/

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateProfileData(true);
        }

        private void ButtonUpdateCurrentValues_Click_1(object sender, EventArgs e)
        {
            UpdateProfileData(false);
        }

        private void UpdateProfileData(bool ticker)
        {
            int i;
            bool b;

            for (i = 0; i < 32; i++)
            {
                profile_data[i] = 0;
            }

            //b = PICkitS.I2CM.Read(smbusaddr, 0, 32, ref profile_data, ref script);
            //Debug.WriteLine(script);
            b = Serial_Read(Profile_Access, 0x20, ref profile_data);
            if (b == false)
            {
                EndProfile();
                MessageBox.Show("Communications lost with battery charger.");
                SerialClose(handle);
                EndProfile();
                return;
            }

            /* profile_data[32] definitions as loaded by charger firmware out of cd.### struct */
            /* These are measured */
            // [0-1] Input voltage
            // [2-3] Output (battery) voltage
            // [4-5] Output (battery) current
            // [6-7] Internal current vref
            // [8-9] Temperature

            /* State information */
            // [10-11] Charge timer (time to shut-off)
            // [12] State of the battery charger
            // [13] ADC channel reading
            // [14-15] Voltage restore timer
            // [16-17] Rapid charge timer
            // [18-19] dV/dt detection
            // [20-21] dT/dt detection
            // [22] Counter for negative dV/dt
            // [23] Counter for negative dT/dt
            // [24] Live status of charger
            //      Byte[24] Status = {CELLVOLTAGEHIGH, CONFIGERROR, SHUTDOWN, OFFSWITCH, OUTPUTOVERVOLTAGE, UNDERTEMPERATURE, OVERTEMPERATURE, UVLO}
            // [25] End of Charge status
            //      Byte[25] EOC_Status = {DTDT, DVDT, TIMEOUT, USERTERMINATED, OUTPUTOVERVOLTAGE, UNDERTEMPERATURE, OVERTEMPERATURE, UVLO}
            // [26] Counter for positive dV/dt %%BRYAN%% Train added this, trace out why.
            // [27] Reference design number

            // The following are all added for user interface functionality. %%BRYAN%% needed?
            // [28] Flag to identify reason for most recent shutdown event //!! Might not need this at all because of new system
            // [29] Flag that the charge routine reached full charge

            /* GUI Variables */
            // [30] Which LEDs are active
            // [31] UI mode (Fuel Gauge vs. Status Mode vs. Inactive)
            // [32]!!INVALID Analog Debug Channel BUFFCON selection  %%BRYAN%% This is 1 Byte past the declaration.  Since it's unused, it's commented out of firmware
            //..............................................................

            double input_voltage = ((ushort)profile_data[0] | ((ushort)profile_data[1] << 8));
            double pack_voltage = ((ushort)profile_data[2] | ((ushort)profile_data[3] << 8));
            double pack_current = ((ushort)profile_data[4] | ((ushort)profile_data[5] << 8));
            double pack_temperature = ((ushort)profile_data[8] | ((ushort)profile_data[9] << 8));
            int charge_time = ((ushort)profile_data[10] | ((ushort)profile_data[11] << 8));
            byte charger_state = profile_data[12];
            int restore_timer = ((ushort)profile_data[14] | ((ushort)profile_data[15] << 8));
            int rapid_charge_timer = ((ushort)profile_data[16] | ((ushort)profile_data[17] << 8));
            short idvbat_dt = (short)((((short)profile_data[19]) << 8) | ((ushort)profile_data[18]));
            short idtemp_dt = (short)((((short)profile_data[21]) << 8) | ((ushort)profile_data[20]));
            int dvbat_dt_count = profile_data[22];
            int dtdt_count = profile_data[23];
            byte status = profile_data[24];
            byte eoc_status = profile_data[25];
            byte PCB_reference_type = profile_data[27]; // Type of PCB connected
            int ipack_voltage = (int)pack_voltage;
            int iinput_voltage = (int)input_voltage;
            int ipack_current = (int)pack_current;
            int ipack_temperature = (int)pack_temperature;
            double dvbat_dt = idvbat_dt;
            double dtemp_dt = idtemp_dt / (-37.459);
            dvbat_dt = dvbat_dt / vbatslope[3];
            input_voltage = (input_voltage - vinintercept[3]) / vinslope[3];
            pack_voltage = (pack_voltage - vbatintercept[3]) / vbatslope[3];
            pack_current = (pack_current - ibatintercept[3]) / ibatslope[3];

            if (ticker == true)
            {
                labelProfilePackVoltage.Text = string.Format("{0:F2} V", pack_voltage - (pack_current * pack_current * (st_wire_resistance)) / 1000);
                labelChargerOutputVoltage.Text = string.Format("{0:F2} V", pack_voltage);
                labelProfilePackCurrent.Text = string.Format("{0:F3} A", pack_current);
                labelProfileInputVoltage.Text = string.Format("{0:F2} V", input_voltage); ;
                labelProfileChargeTime.Text = string.Format("{0} s", charge_time);
                // Presently there are 6 defined boards as set in the GUI Battery Charger code.  If more are added then add them here. 
                if (PCB_reference_type > 7)
                {
                    labelPCBtype.Text = "Undefined PCB Type";
                }
                if (PCB_reference_type == 1)
                {
                    labelPCBtype.Text = "MCP19111 Charger Reference";
                }
                if (PCB_reference_type == 2)
                {
                    labelPCBtype.Text = "PIC16F1716 + MCP1631 SEPIC";
                }
                if (PCB_reference_type == 3)
                {
                    labelPCBtype.Text = "PIC16F866 + MCP1631 SEPIC";
                }
                if (PCB_reference_type == 4)
                {
                    labelPCBtype.Text = "MCP19118 4-Switch Buck-Boost";
                }
                if (PCB_reference_type == 5)
                {
                    labelPCBtype.Text = "MCP19123 Buck-Boost Reference";
                }
                if (PCB_reference_type == 6)
                {
                    labelPCBtype.Text = "MCP19125 ADM00745 Charger EVK";
                }
                if (PCB_reference_type == 7)
                {
                    labelPCBtype.Text = "MCP19119 4A Charger";
                }
            }
            else
            {
                labelProfilePackVoltageLive.Text = string.Format("{0:F2} V", pack_voltage - (pack_current * pack_current * (st_wire_resistance)) / 1000);
                labelProfilePackCurrentLive.Text = string.Format("{0:F3} A", pack_current);
                labelProfileInputVoltageLive.Text = string.Format("{0:F2} V", input_voltage);
                labeldTdtLive.Text = string.Format("{0:F2} deg C / sec", dtemp_dt); 
                labeldtdtCountLive.Text = string.Format("{0:F2}", dtdt_count);
                label44.Text = string.Format("{0:F2}", rapid_charge_timer);
                label42.Text = string.Format("{0:F2}", charge_time);
                // Presently there are 6 defined boards as set in the GUI Battery Charger code.  If more are added then add them here. 
                if (PCB_reference_type == 0 | PCB_reference_type > 7)
                {
                    labelPCBtypeLive.Text = "Undefined PCB Type";
                }
                if (PCB_reference_type == 1)
                {
                    labelPCBtypeLive.Text = "MCP19111 Charger Reference";
                }
                if (PCB_reference_type == 2)
                {
                    labelPCBtypeLive.Text = "PIC16F1716 + MCP1631 SEPIC";
                }
                if (PCB_reference_type == 3)
                {
                    labelPCBtypeLive.Text = "PIC16F866 + MCP1631 SEPIC";
                }
                if (PCB_reference_type == 4)
                {
                    labelPCBtypeLive.Text = "MCP19118 4-Switch Buck-Boost";
                }
                if (PCB_reference_type == 5)
                {
                    labelPCBtypeLive.Text = "MCP19123 Buck-Boost Reference";
                }
                if (PCB_reference_type == 6)
                {
                    labelPCBtypeLive.Text = "MCP19125 ADM00745 Charger EVK";
                }
                if (PCB_reference_type == 7)
                {
                    labelPCBtypeLive.Text = "MCP19119 4A Charger";
                }
            }

            Debug.WriteLine(string.Format("Input Voltage Counts: {0}", iinput_voltage));
            Debug.WriteLine(string.Format("Pack Voltage Counts: {0}", ipack_voltage));
            Debug.WriteLine(string.Format("Pack Current Counts: {0}", ipack_current));
            Debug.WriteLine(string.Format("Pack Temperature Counts: {0}", ipack_temperature));
            Debug.WriteLine(string.Format("Pack Temperature: {0:F3} ({1})", ((pack_temperature - thermistor_intercept) / thermistor_slope) + thermistor_cal_temp, pack_temperature));
            Debug.WriteLine(string.Format("dT/dt {0:F3} ({1})", dtemp_dt, idtemp_dt));
            Debug.WriteLine(string.Format("dT/dt_count {0}", dtdt_count));
            Debug.WriteLine(string.Format("Pack Voltage: {0:F3} ({1})", pack_voltage, ipack_voltage));
            Debug.WriteLine(string.Format("dV/dt {0:F6} ({1})", dvbat_dt, idvbat_dt));
            Debug.WriteLine(string.Format("dV/dt_count {0}", dvbat_dt_count));
            Debug.WriteLine(string.Format("restore_timer {0}", restore_timer));
            Debug.WriteLine(string.Format("rapid_charge_timer {0}", rapid_charge_timer));
            Debug.WriteLine(string.Format("Charger Status: {0:x2}", status));
            Debug.WriteLine(string.Format("EOC Status: {0:x2}", eoc_status));
            Debug.WriteLine(string.Format("PCB Type connected {0} {1}", PCB_reference_type, labelProfileInputVoltageLive.Text));
            Debug.WriteLine(string.Format(""));
            for (i = 0; i < 32; i++)
            {
                Debug.WriteLine(string.Format("Profile_Data [{0}] = {1}", i, profile_data[i]));
            }
            if (ticker == true)
            {
                if ((((pack_temperature - thermistor_intercept) / thermistor_slope) + thermistor_cal_temp) < 95)
                {
                    labelPackTemperatureRead.Text = string.Format("{0:F3} °C",
                    //(pack_temperature - thermistor_intercept) / thermistor_slope);
                    ((pack_temperature - thermistor_intercept) / thermistor_slope) + thermistor_cal_temp);
                }
                else
                {
                    labelPackTemperatureRead.Text = "Open Circuit";
                }
            }
            else if (ticker == false)
            {
                if ((((pack_temperature - thermistor_intercept) / thermistor_slope) + thermistor_cal_temp ) < 95)
                {
                    labelPackTemperatureReadLive.Text = string.Format("{0:F3} °C",
                    //(pack_temperature - thermistor_intercept)  thermistor_slope);
                    ((pack_temperature - thermistor_intercept) / thermistor_slope) + thermistor_cal_temp);
                }
                else
                {
                    labelPackTemperatureReadLive.Text = "Open Circuit";
                }
            }

            string charger_status = "";
            string term_status = "";

            //          Byte[24] Status = {CELLVOLTAGEHIGH, CONFIGERROR, SHUTDOWN, OFFSWITCH, OUTPUTOVERVOLTAGE, UNDERTEMPERATURE, OVERTEMPERATURE, UVLO}
            if (status == 0x00)
            {
                charger_status += "HEALTHY ";
            }
            if ((status & 0x01) != 0)
            {
                charger_status += "UVLO ";
            }
            if ((status & 0x02) != 0)
            {
                charger_status += "OVER TEMP ";
            }
            if ((status & 0x04) != 0)
            {
                charger_status += "UNDER TEMP ";
            }
            if ((status & 0x08) != 0)
            {
                charger_status += "OUTPUT OVER VOLT ";
            }
            if ((status & 0x10) != 0)
            {
                charger_status += "OFF SWITCH ";
            }
            if ((status & 0x20) != 0)
            {
                charger_status += "SHUTDOWN ";
            }
            if ((status & 0x40) != 0)
            {
                charger_status += "CONFIG ERR ";
            }
            if ((status & 0x80) != 0)
            {
                charger_status += "CELL VOLTAGE HIGH ";
            }

            labelChargerStatus.Text = charger_status;
            labelChargerStatusLive.Text = charger_status;

            switch (charger_state)
            {
                case 0x00: //Charger OFF
                    term_status = "OFF: ";

                    //                  Byte[25] EOC_Status = {DTDT, DVDT, TIMEOUT, USERTERMINATED, OUTPUTOVERVOLTAGE, UNDERTEMPERATURE, OVERTEMPERATURE, UVLO}
                    if ((eoc_status & 0x01) != 0)
                    {
                        term_status += "Input UVLO ";
                    }
                    if ((eoc_status & 0x02) != 0)
                    {
                        term_status += "OVER TEMP ";
                    }
                    if ((eoc_status & 0x04) != 0)
                    {
                        term_status += "UNDER TEMP ";
                    }
                    if ((eoc_status & 0x08) != 0)
                    {
                        term_status += "OUTPUT OVER VOLTAGE ";
                    }
                    if ((eoc_status & 0x10) != 0)
                    {
                        term_status += "USER BUTTON ABORTED ";
                    }
                    if ((eoc_status & 0x20) != 0)
                    {
                        term_status += "TIMEOUT ";
                    }
                    if ((eoc_status & 0x40) != 0)
                    {
                        term_status += "dV/dt ";
                    }
                    if ((eoc_status & 0x80) != 0)
                    {
                        term_status += "dT/dt ";
                    }

                    if (ticker == true)
                    {
                        labelProfileChargerState.Text = term_status;
                    }
                    else
                    {
                        labelProfileChargerStateLive.Text = term_status;
                    }
                    if (last_charge_time > 0)
                    {
                        EndProfile();
                    }
                    break;

                case 0x01: // Lithium Ion Start
                    labelProfileChargerState.Text = "Li+ Start";
                    labelProfileChargerStateLive.Text = "Li+ Start";
                    break;
                case 0x02: // Lithium Ion Recondition
                    labelProfileChargerState.Text = "Li+ Recondition";
                    labelProfileChargerStateLive.Text = "Li+ Recondition";
                    break;
                case 0x03: // Lithium Ion Constant Current
                    labelProfileChargerState.Text = "Li+ Constant Current";
                    labelProfileChargerStateLive.Text = "Li+ Constant Current";
                    break;
                case 0x04: // Lithium Ion Constant Voltage
                    labelProfileChargerState.Text = "Li+ Constant Voltage";
                    labelProfileChargerStateLive.Text = "Li+ Constant Voltage";
                    break;
                case 0x05: // NiMH Start
                    labelProfileChargerState.Text = "NiMH Start";
                    labelProfileChargerStateLive.Text = "NiMH Start";
                    break;
                case 0x06: // NiMH Restore Charge
                    labelProfileChargerState.Text = "NiMH Restore";
                    labelProfileChargerStateLive.Text = "NiMH Restore";
                    break;
                case 0x07: // NiMH Rapid Charge
                    labelProfileChargerState.Text = "NiMH Rapid";
                    labelProfileChargerStateLive.Text = "NiMH Rapid";
                    break;
                case 0x08: // NiMH Trickle Charge
                    labelProfileChargerState.Text = "NiMH Trickle";
                    labelProfileChargerStateLive.Text = "NiMH Trickle";
                    break;
                case 0x09: // VRLA Start
                    labelProfileChargerState.Text = "VRLA Start";
                    labelProfileChargerStateLive.Text = "VRLA Start";
                    break;
                case 0x0a: // VRLA Precondition
                    labelProfileChargerState.Text = "VRLA Precondition";
                    labelProfileChargerStateLive.Text = "VRLA Precondition";
                    break;
                case 0x0b: // VRLA Constant Current
                    labelProfileChargerState.Text = "VRLA Constant Current";
                    labelProfileChargerStateLive.Text = "VRLA Constant Current";
                    break;
                case 0x0c: // VRLA Constant Voltage
                    labelProfileChargerState.Text = "VRLA Constant Voltage";
                    labelProfileChargerStateLive.Text = "VRLA Constant Voltage";
                    break;
                case 0x0d: // VRLA Fast Charge Start
                    labelProfileChargerState.Text = "VRLA Fast Start";
                    labelProfileChargerStateLive.Text = "VRLA Fast Start";
                    break;
                case 0x0e: // VRLA Fast Charge Restore
                    labelProfileChargerState.Text = "VRLA Fast Restore";
                    labelProfileChargerStateLive.Text = "VRLA Fast Restore";
                    break;
                case 0x0f: // VRLA Fast Charge Rapid Charge
                    labelProfileChargerState.Text = "VRLA Fast Rapid Charge";
                    labelProfileChargerStateLive.Text = "VRLA Fast Rapid Charge";
                    break;
                case 0x10: // VRLA Fast Charge Trickle Charge
                    labelProfileChargerState.Text = "VRLA Fast Trickle Charge";
                    labelProfileChargerStateLive.Text = "VRLA Fast Trickle Charge";
                    break;
                case 0x11: // VRLA Fast Charge Float Charge
                    labelProfileChargerState.Text = "VRLA Fast Float Charge";
                    labelProfileChargerStateLive.Text = "VRLA Fast Float Charge";
                    break;
                case 0x12: // LiFePO4 Start
                    labelProfileChargerState.Text = "LiFePO4 Start";
                    labelProfileChargerStateLive.Text = "LiFePO4 Start";
                    break;
                case 0x13: // LiFePO4 Precondition
                    labelProfileChargerState.Text = "LiFePO4 Precondition";
                    labelProfileChargerStateLive.Text = "LiFePO4 Precondition";
                    break;
                case 0x14: // LiFePO4 Constant Current
                    labelProfileChargerState.Text = "LiFePO4 Constant Current";
                    labelProfileChargerStateLive.Text = "LiFePO4 Constant Current";
                    break;
                case 0x15: // LiFePO4 Constant Voltage
                    labelProfileChargerState.Text = "LiFePO4 Constant Voltage";
                    labelProfileChargerStateLive.Text = "LiFePO4 Constant Voltage";
                    break;
                case 0x16: // Super Capacitor Start
                    labelProfileChargerState.Text = "Super Capacitor Start";
                    labelProfileChargerStateLive.Text = "Super Capacitor Constant Current";
                    break;
                case 0x17: // LiFePO4 Constant Current
                    labelProfileChargerState.Text = "Super Capacitor Constant Voltage";
                    labelProfileChargerStateLive.Text = "Super Capacitor Constant Voltage";
                    break;
                case 0x18: // LiFePO4 Constant Voltage
                    labelProfileChargerState.Text = "LiFePO4 Constant Voltage";
                    labelProfileChargerStateLive.Text = "LiFePO4 Constant Voltage";
                    break;
                default:
                    labelProfileChargerState.Text = string.Format("{0}", charger_state);
                    labelProfileChargerStateLive.Text = string.Format("{0}", charger_state);
                    break;
            }
            if ((ticker == true) && (charge_time > last_charge_time))
            {
                chartProfile.Series["Pack Voltage"].Points.AddXY(charge_time, pack_voltage);
                chartProfile.Series["Pack Current"].Points.AddXY(charge_time, pack_current);
                chartProfile.Series["Input Voltage"].Points.AddXY(charge_time, input_voltage);
                //%%BRYAN%% Removing Pack Temperature for a while.  It works, but is not at all accurate using the internal sensor.
                if (pack_temperature < 4000)
                {
                    chartProfile.Series["Pack Temperature"].Points.AddXY(charge_time,
                        //(pack_temperature - thermistor_intercept) / thermistor_slope);
                        ((pack_temperature - thermistor_intercept) / thermistor_slope) + thermistor_cal_temp);
                }
                else
                {
                    chartProfile.Series["Pack Temperature"].Points.AddXY(charge_time, 0);
                }
                last_charge_time = charge_time;
            }
        }

        private void buttonProfileStart_Click(object sender, EventArgs e)
        {
            if (VerifyFWRev() == false)  //this pulls the FW revision level hardcoded in the battery charger project.  
                return;

            if (ReadCalibration() == false)
                return;

            if (ReadConfiguration(true) == false)
                return;

            last_charge_time = (-1);

            chartProfile.Series["Pack Voltage"].Points.Clear();
            chartProfile.Series["Pack Current"].Points.Clear();
            //%%BRYAN%% Removing Temperature for a while.  It's not accurate using internal sensor
            chartProfile.Series["Pack Temperature"].Points.Clear();
            chartProfile.Series["Input Voltage"].Points.Clear();

            chartProfile.ChartAreas[0].AxisX.Minimum = 0;
            chartProfile.ChartAreas[1].AxisX.Minimum = 0;
            chartProfile.ChartAreas[2].AxisX.Minimum = 0;
            //%%BRYAN%% Removing Temperature for a while.  It's not accurate using internal sensor
            chartProfile.ChartAreas[3].AxisX.Minimum = 0;

            Cursor.Current = Cursors.WaitCursor;

            System.Threading.Thread.Sleep(100);

            /* Turn on the charger */
            ChargerCommand(1);

            System.Threading.Thread.Sleep(500);

            Cursor.Current = Cursors.Default;

            /* Update everything */
            timer1_Tick(sender, e);

            buttonProfileStart.Enabled = false;
            buttonProfileStop.Enabled = true;
            buttonSaveData.Enabled = false;
            profilerunning = true;

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void buttonProfileStop_Click(object sender, EventArgs e)
        {
            if (!Init_Serial())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            /* Turn off the charger */
            ChargerCommand(0);

            Cursor.Current = Cursors.Default;

            buttonProfileStart.Enabled = true;
            //%%BRYAN%% changing the below to true from false so that the option to stop the charger is never grayed out for safety purposes.
            buttonProfileStop.Enabled = true;
            buttonSaveData.Enabled = true;
            profilerunning = false;

            timer1.Stop();
        }

        private void EndProfile()
        {
            timer1.Stop();
            buttonProfileStart.Enabled = true;
            //%%BRYAN%% changing the below to true from false so that the option to stop the charger is never grayed out for safety purposes.
            buttonProfileStop.Enabled = true;
            buttonSaveData.Enabled = true;
            profilerunning = false;

            labelProfilePackVoltage.Text = "";
            labelProfilePackCurrent.Text = "";
            labelProfileInputVoltage.Text = "";
            labelProfileChargerState.Text = "Not Connected";
            labelProfileChargeTime.Text = "";
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter stream;
            SaveFileDialog d = new SaveFileDialog();

            if (chartProfile.Series["Pack Voltage"].Points.Count == 0)
            {
                MessageBox.Show("There are no data points to save.");
                return;
            }

            d.DefaultExt = ".csv";
            d.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            if (d.ShowDialog() == DialogResult.OK)
            {
                int i, count;
                string s;

                if ((stream = System.IO.File.CreateText(d.FileName)) != null)
                {
                    stream.WriteLine("Time,Voltage,Current,Temperature");

                    count = chartProfile.Series["Pack Voltage"].Points.Count;
                    for (i = 0; i < count; i++)
                    {
                        System.Windows.Forms.DataVisualization.Charting.DataPoint pack_voltage;
                        System.Windows.Forms.DataVisualization.Charting.DataPoint pack_current;
                        System.Windows.Forms.DataVisualization.Charting.DataPoint pack_temperature;

                        pack_voltage = chartProfile.Series["Pack Voltage"].Points[i];
                        pack_current = chartProfile.Series["Pack Current"].Points[i];
                        //%%BRYAN%% Removing Temperature for a while.  It's not accurate using internal sensor
                        pack_temperature = chartProfile.Series["Pack Temperature"].Points[i];

                        //Debug.WriteLine("{0} {1} {2} {3}", pack_voltage.XValue, pack_voltage.YValues[0], pack_current.YValues[0], pack_temperature.YValues[0]);
                        //s = string.Format("{0},{1},{2},{3}", pack_voltage.XValue, pack_voltage.YValues[0], pack_current.YValues[0], pack_temperature.YValues[0]);
                        Debug.WriteLine("{0} {1} {2}", pack_voltage.XValue, pack_voltage.YValues[0], pack_current.YValues[0]);
                        s = string.Format("{0},{1},{2}", pack_voltage.XValue, pack_voltage.YValues[0], pack_current.YValues[0]);
                        stream.WriteLine(s);
                    }

                    stream.Close();
                }
            }
            else
            {
                MessageBox.Show("Could not open file.");
            }
        }
        #endregion

        #region Calibration Routines and Read and Write to Flash Functions
        /*************************************************************************************/
        /* Below are the functions for calibrating the charger.                              */
        /*************************************************************************************/

        private void ClearCalibrationData() //Clears the results of the local math variables
        {
            int i;

            for (i = 0; i < 4; i++)
            {
                ibatslope[i] = 0;
                ibatintercept[i] = 0;
                vinslope[i] = 0;
                vinintercept[i] = 0;
                vbatslope[i] = 0;
                vbatintercept[i] = 0;
            }
        }

        private void buttonReadCalibration_Click(object sender, EventArgs e)  //Calls ReadCalibration() and passes a TRUE to update the text boxes with read values.
        {
            ReadCalibration(true);
        }

        private bool ReadCalibration(bool updatedialog = false) //Reads the flash values from the device, checks their validity, and if passed a true value will update the calibration value text-boxes.
        {
            ClearCalibrationData();

            if (!Init_Serial())
            {
                return false;
            }

            int i;
            bool b;

            for (i = 0; i < 64; i++)
                cal_data[i] = 0xff;

            //b = PICkitS.I2CM.Read(smbusaddr, Flash_Access, 64, ref cal_data, ref script);  // Flash_Access is 0x80 with an offset of 0x00 in the lower 7 bits.
            b = Serial_Read(Flash_Access, 64, ref cal_data); // Flash_Access is 0x80 with an offset of 0x00 in the lower 7 bits.
            Debug.WriteLine(script);

            if (b == false)
            {
                MessageBox.Show("Could not read calibration data from battery charger.");
                if (serial_device == 1)
                {
                    SerialClose(handle);
                }
                return false;
            }

            b = Serial_Read((ushort)(Flash_Access | Temp_Cal_Addr), 2, ref thermintercept); 
            Debug.WriteLine(script);

            if (b == false)
            {
                MessageBox.Show("Could not read calibration data from battery charger.");
                if (serial_device == 1)
                {
                    SerialClose(handle);
                }
                return false;
            }

            ibat[0] = Convert.ToDouble(((ushort)cal_data[0]) | ((ushort)cal_data[1] << 8));
            ibat[1] = Convert.ToDouble(((ushort)cal_data[2]) | ((ushort)cal_data[3] << 8));
            ibat[2] = Convert.ToDouble(((ushort)cal_data[4]) | ((ushort)cal_data[5] << 8));

            irange[0] = Convert.ToDouble(((ushort)cal_data[18]) | ((ushort)cal_data[19] << 8)) / 1000;
            irange[1] = Convert.ToDouble(((ushort)cal_data[20]) | ((ushort)cal_data[21] << 8)) / 1000;
            irange[2] = Convert.ToDouble(((ushort)cal_data[22]) | ((ushort)cal_data[23] << 8)) / 1000;

            vin[0] = Convert.ToDouble(((ushort)cal_data[6]) | ((ushort)cal_data[7] << 8));
            vin[1] = Convert.ToDouble(((ushort)cal_data[8]) | ((ushort)cal_data[9] << 8));
            vin[2] = Convert.ToDouble(((ushort)cal_data[10]) | ((ushort)cal_data[11] << 8));

            vbatrange[0] = Convert.ToDouble(((ushort)cal_data[24]) | ((ushort)cal_data[25] << 8)) / 100;
            vbatrange[1] = Convert.ToDouble(((ushort)cal_data[26]) | ((ushort)cal_data[27] << 8)) / 100;
            vbatrange[2] = Convert.ToDouble(((ushort)cal_data[28]) | ((ushort)cal_data[29] << 8)) / 100;

            vbat[0] = Convert.ToDouble(((ushort)cal_data[12]) | ((ushort)cal_data[13] << 8));
            vbat[1] = Convert.ToDouble(((ushort)cal_data[14]) | ((ushort)cal_data[15] << 8));
            vbat[2] = Convert.ToDouble(((ushort)cal_data[16]) | ((ushort)cal_data[17] << 8));

            vinrange[0] = Convert.ToDouble(((ushort)cal_data[30]) | ((ushort)cal_data[31] << 8)) / 100;
            vinrange[1] = Convert.ToDouble(((ushort)cal_data[32]) | ((ushort)cal_data[33] << 8)) / 100;
            vinrange[2] = Convert.ToDouble(((ushort)cal_data[34]) | ((ushort)cal_data[35] << 8)) / 100;

            // %%BRYAN%% Below pulls in the MCP19125 temp intercept for 30C. The calword is wacked out in silicon so we're going to hardcode it to 0x14B
            //thermistor_intercept = Convert.ToDouble(((ushort)thermintercept[0]) | ((ushort)thermintercept[1] << 8));
            //thermistor_intercept *= 4;
            thermistor_intercept = 0x3C4; //%%BRYAN%% this is here to overwrite suspicious values from the GUI.

            for (i = 0; i < 3; i++)
            {
                if ((ibat[i] > 4095) || (vin[i] > 4095) || (vbat[i] > 4095)) //%%BRYAN%% add a check here for the ranges as well
                {
                    MessageBox.Show("The battery charger has not been properly calibrated.");
                    ClearCalibrationData();
                    return false;
                }
            }

            if (CheckCalibration() == false)
            {
                ClearCalibrationData();
                return false;
            }

            if (updatedialog)
            {
                textBoxLowAmp.Text = Convert.ToString(ibat[0]);
                textBoxMidAmp.Text = Convert.ToString(ibat[1]);
                textBoxHighAmp.Text = Convert.ToString(ibat[2]);

                textBoxSetLowAmp.Text = Convert.ToString(irange[0]);
                textBoxSetMidAmp.Text = Convert.ToString(irange[1]);
                textBoxSetHighAmp.Text = Convert.ToString(irange[2]);

                textBoxSetLowAmp.Text = string.Format("{0:F3}", irange[0]);
                textBoxSetMidAmp.Text = string.Format("{0:F3}", irange[1]);
                textBoxSetHighAmp.Text = string.Format("{0:F3}", irange[2]);

                textBoxLowVbat.Text = Convert.ToString(vbat[0]);
                textBoxMidVbat.Text = Convert.ToString(vbat[1]);
                textBoxHighVbat.Text = Convert.ToString(vbat[2]);

                textBoxSetLowVbat.Text = Convert.ToString(vbatrange[0]);
                textBoxSetMidVbat.Text = Convert.ToString(vbatrange[1]);
                textBoxSetHighVbat.Text = Convert.ToString(vbatrange[2]);

                textBoxSetLowVbat.Text = string.Format("{0:F2}", vbatrange[0]);
                textBoxSetMidVbat.Text = string.Format("{0:F2}", vbatrange[1]);
                textBoxSetHighVbat.Text = string.Format("{0:F2}", vbatrange[2]);

                textBoxLowVin.Text = Convert.ToString(vin[0]);
                textBoxMidVin.Text = Convert.ToString(vin[1]);
                textBoxHighVin.Text = Convert.ToString(vin[2]);

                textBoxSetLowVin.Text = Convert.ToString(vinrange[0]);
                textBoxSetMidVin.Text = Convert.ToString(vinrange[1]);
                textBoxSetHighVin.Text = Convert.ToString(vinrange[2]);

                textBoxSetLowVin.Text = string.Format("{0:F2}", vinrange[0]);
                textBoxSetMidVin.Text = string.Format("{0:F2}", vinrange[1]);
                textBoxSetHighVin.Text = string.Format("{0:F2}", vinrange[2]);
            }

            return b;
        }

        private bool CheckCalibration(bool notify = true)  //Checks calibration values for realistic values. Has a default input to display a message box error on bad results.
        {
            int i;
            bool b = true;

            ibatslope[0] = (ibat[1] - ibat[0]) / (irange[1] - irange[0]);
            ibatslope[1] = (ibat[2] - ibat[0]) / (irange[2] - irange[0]);
            ibatslope[2] = (ibat[2] - ibat[1]) / (irange[2] - irange[1]);
            ibatslope[3] = (ibatslope[0] + ibatslope[1] + ibatslope[2]) / 3.0;

            ibatintercept[0] = ibat[1] - (ibatslope[0] * irange[1]);
            ibatintercept[1] = ibat[2] - (ibatslope[1] * irange[2]);
            ibatintercept[2] = ibat[2] - (ibatslope[2] * irange[2]);
            ibatintercept[3] = (ibatintercept[0] + ibatintercept[1] + ibatintercept[2]) / 3.0;

            vbatslope[0] = (vbat[1] - vbat[0]) / (vbatrange[1] - vbatrange[0]);
            vbatslope[1] = (vbat[2] - vbat[0]) / (vbatrange[2] - vbatrange[0]);
            vbatslope[2] = (vbat[2] - vbat[1]) / (vbatrange[2] - vbatrange[1]);
            vbatslope[3] = (vbatslope[0] + vbatslope[1] + vbatslope[2]) / 3.0;

            vbatintercept[0] = vbat[1] - (vbatslope[0] * vbatrange[1]);
            vbatintercept[1] = vbat[2] - (vbatslope[1] * vbatrange[2]);
            vbatintercept[2] = vbat[2] - (vbatslope[2] * vbatrange[2]);
            vbatintercept[3] = (vbatintercept[0] + vbatintercept[1] + vbatintercept[2]) / 3.0;

            vinslope[0] = (vin[1] - vin[0]) / (vinrange[1] - vinrange[0]);
            vinslope[1] = (vin[2] - vin[0]) / (vinrange[2] - vinrange[0]);
            vinslope[2] = (vin[2] - vin[1]) / (vinrange[2] - vinrange[1]);
            vinslope[3] = (vinslope[0] + vinslope[1] + vinslope[2]) / 3.0;

            vinintercept[0] = vin[1] - (vinslope[0] * vinrange[1]);
            vinintercept[1] = vin[2] - (vinslope[1] * vinrange[2]);
            vinintercept[2] = vin[2] - (vinslope[2] * vinrange[2]);
            vinintercept[3] = (vinintercept[0] + vinintercept[1] + vinintercept[2]) / 3.0;

            b = true;

            for (i = 0; i < 3; i++)
            {
                if (ibat[i] < 10)
                {
                    Debug.WriteLine("Battery current calibration data invalid.");
                    b = false;
                }

                if (ibatslope[3] < (ibatslope[i] * 0.9))
                {
                    Debug.WriteLine("Battery current calibration data invalid.");
                    b = false;
                }

                if (ibatslope[3] > (ibatslope[i] * 1.1))
                {
                    Debug.WriteLine("Battery current calibration data invalid.");
                    b = false;
                }
            }

            for (i = 0; i < 3; i++)
            {
                if (vbat[i] < 10)
                {
                    Debug.WriteLine("Battery voltage calibration data invalid.");
                    b = false;
                }

                if (vbatslope[3] < (vbatslope[i] * 0.9))
                {
                    Debug.WriteLine("Battery voltage calibration data invalid.");
                    b = false;
                }

                if (vbatslope[3] > (vbatslope[i] * 1.1))
                {
                    Debug.WriteLine("Battery voltage calibration data invalid.");
                    b = false;
                }
            }

            for (i = 0; i < 3; i++)
            {
                if (vin[i] < 10)
                {
                    Debug.WriteLine("Input voltage calibration data invalid.");
                    b = false;
                }

                if (vinslope[3] < (vinslope[i] * 0.9))
                {
                    Debug.WriteLine("Input voltage calibration data invalid.");
                    b = false;
                }

                if (vinslope[3] > (vinslope[i] * 1.1))
                {
                    Debug.WriteLine("Input voltage calibration data invalid.");
                    b = false;
                }
            }

            if ((b == false) && (notify))
            {
                MessageBox.Show("Calibration data is invalid.");
                ClearCalibrationData();
            }

            return b;
        }

        private void buttonWriteCalibration_Click(object sender, EventArgs e)
        {
            bool b;
            int i;

            if (!Init_Serial())
            {
                return;
            }

            ibat[0] = ToDouble(textBoxLowAmp.Text);
            ibat[1] = ToDouble(textBoxMidAmp.Text);
            ibat[2] = ToDouble(textBoxHighAmp.Text);

            vbat[0] = ToDouble(textBoxLowVbat.Text);
            vbat[1] = ToDouble(textBoxMidVbat.Text);
            vbat[2] = ToDouble(textBoxHighVbat.Text);

            vin[0] = ToDouble(textBoxLowVin.Text);
            vin[1] = ToDouble(textBoxMidVin.Text);
            vin[2] = ToDouble(textBoxHighVin.Text);

            irange[0] = ToDouble(textBoxSetLowAmp.Text) * 1000;
            irange[1] = ToDouble(textBoxSetMidAmp.Text) * 1000;
            irange[2] = ToDouble(textBoxSetHighAmp.Text) * 1000;

            vbatrange[0] = ToDouble(textBoxSetLowVbat.Text) * 100;
            vbatrange[1] = ToDouble(textBoxSetMidVbat.Text) * 100;
            vbatrange[2] = ToDouble(textBoxSetHighVbat.Text) * 100;

            vinrange[0] = ToDouble(textBoxSetLowVin.Text) * 100;
            vinrange[1] = ToDouble(textBoxSetMidVin.Text) * 100;
            vinrange[2] = ToDouble(textBoxSetHighVin.Text) * 100;

            if (CheckCalibration() == false)
            {
                return;
            }

            for (i = 0; i < 64; i++) cal_data[i] = 0xff;

            cal_data[0] = LSB(ibat[0]);
            cal_data[1] = MSB(ibat[0]);
            cal_data[2] = LSB(ibat[1]);
            cal_data[3] = MSB(ibat[1]);
            cal_data[4] = LSB(ibat[2]);
            cal_data[5] = MSB(ibat[2]);

            cal_data[6] = LSB(vin[0]);
            cal_data[7] = MSB(vin[0]);
            cal_data[8] = LSB(vin[1]);
            cal_data[9] = MSB(vin[1]);
            cal_data[10] = LSB(vin[2]);
            cal_data[11] = MSB(vin[2]);

            cal_data[12] = LSB(vbat[0]);
            cal_data[13] = MSB(vbat[0]);
            cal_data[14] = LSB(vbat[1]);
            cal_data[15] = MSB(vbat[1]);
            cal_data[16] = LSB(vbat[2]);
            cal_data[17] = MSB(vbat[2]);

            cal_data[18] = LSB(irange[0]);
            cal_data[19] = MSB(irange[0]);
            cal_data[20] = LSB(irange[1]);
            cal_data[21] = MSB(irange[1]);
            cal_data[22] = LSB(irange[2]);
            cal_data[23] = MSB(irange[2]);

            cal_data[24] = LSB(vbatrange[0]);
            cal_data[25] = MSB(vbatrange[0]);
            cal_data[26] = LSB(vbatrange[1]);
            cal_data[27] = MSB(vbatrange[1]);
            cal_data[28] = LSB(vbatrange[2]);
            cal_data[29] = MSB(vbatrange[2]);

            cal_data[30] = LSB(vinrange[0]);
            cal_data[31] = MSB(vinrange[0]);
            cal_data[32] = LSB(vinrange[1]);
            cal_data[33] = MSB(vinrange[1]);
            cal_data[34] = LSB(vinrange[2]);
            cal_data[35] = MSB(vinrange[2]);

            //b = PICkitS.I2CM.Write(smbusaddr, Flash_Access, 64, ref cal_data, ref script);
            //Debug.WriteLine(script);
            b = Serial_Write(Flash_Access, 64, ref cal_data); 

            if (b == false)
            {
                b = false;
                MessageBox.Show("Could not write calibration data to battery charger..");
                return;
            }

            // b = PICkitS.I2CM.Read(smbusaddr, Flash_Access, 64, ref verification_data, ref script);
            // Debug.WriteLine(script);
            b = Serial_Read(Flash_Access, 64, ref verification_data);

            if (b == false)
            {
                b = false;
                MessageBox.Show("Verification of calibration data failed (readback).");
                SerialClose(handle);
                return;
            }
            Debug.WriteLine(script);

            b = true;
            for (i = 0; i < 64; i++)
            {
                if ((i & 0x01) == 0)
                {
                    if (cal_data[i] != verification_data[i])
                    {
                        b = false;
                    }
                }
                else
                {
                    if ((cal_data[i] & 0x3f) != verification_data[i])
                    {
                        b = false;
                    }
                }
            }

            if (b == false)
            {
                b = false;
                MessageBox.Show("Verification of calibration data failed.");
            }
            else
            {
                MessageBox.Show("Calibration succeeded.");
                buttonBeginCalibration_Click(sender, e);
                buttonReadCalibration_Click(sender, e);
            }
        }

        private void buttonBeginCalibration_Click(object sender, EventArgs e)
        {
            if (!Init_Serial())
            {
                return;
            }

            if (calibrating == true)
            {
                calibrating = false;
                buttonBeginCalibration.Text = "Begin Calibration";

                /* Turn off the charger (this re-enables it) */
                ChargerCommand(0);
            }
            else
            {
                buttonBeginCalibration.Text = "Abort Calibration";
                calibrating = true;
                ClearCalibrationData();

                /* Disable the charger */
                ChargerCommand(3);
            }

            /* Update dialog */
            handlerSelectedIndexChanged(sender, e);
        }

        private bool ReadCalibrationPoint()
        {
            bool b = true;
            int i;

            if (!Init_Serial())
            {
                return false;
            }

            for (i = 0; i < 32; i++)
            {
                profile_data[i] = 0;
            }

            //b = PICkitS.I2CM.Read(smbusaddr, 0, 32, ref profile_data, ref script);
            //Debug.WriteLine(script);
            b = Serial_Read(Profile_Access, 32, ref profile_data);

            if (b == false)
            {
                MessageBox.Show("Communications lost with battery charger.");
                SerialClose(handle);
            }

            return b;
        }

        private void ButtonDefaultCalValues_Click(object sender, EventArgs e) //These are default values loaded from the Advanced Tab of the GUI. //%%BRYAN%% Check this out
        {
            //!! These need to made into an option in the GUI for the PIC16F1769 reference design

            ibat[0] = (72);
            ibat[1] = (443);
            ibat[2] = (864);

            vbat[0] = (1096);
            vbat[1] = (1308);
            vbat[2] = (1691);

            vin[0] = (728);
            vin[1] = (1676);
            vin[2] = (2876);

            textBoxLowAmp.Text = Convert.ToString(ibat[0]);
            textBoxMidAmp.Text = Convert.ToString(ibat[1]);
            textBoxHighAmp.Text = Convert.ToString(ibat[2]);

            textBoxLowVbat.Text = Convert.ToString(vbat[0]);
            textBoxMidVbat.Text = Convert.ToString(vbat[1]);
            textBoxHighVbat.Text = Convert.ToString(vbat[2]);

            textBoxLowVin.Text = Convert.ToString(vin[0]);
            textBoxMidVin.Text = Convert.ToString(vin[1]);
            textBoxHighVin.Text = Convert.ToString(vin[2]);
            /*
                        ibat[0] = (341);
                        ibat[1] = (582);
                        ibat[2] = (1180);

                        vbat[0] = (1474);
                        vbat[1] = (2196);
                        vbat[2] = (2936);

                        vin[0] = (540);
                        vin[1] = (800);
                        vin[2] = (1067);

                        textBox200mA.Text = Convert.ToString(ibat[0]);
                        textBox1A.Text = Convert.ToString(ibat[1]);
                        textBox3A.Text = Convert.ToString(ibat[2]);

                        textBox84Vbat.Text = Convert.ToString(vbat[0]);
                        textBox126Vbat.Text = Convert.ToString(vbat[1]);
                        textBox168Vbat.Text = Convert.ToString(vbat[2]);

                        textBox84Vin.Text = Convert.ToString(vin[0]);
                        textBox126Vin.Text = Convert.ToString(vin[1]);
                        textBox168Vin.Text = Convert.ToString(vin[2]);
              */
        }

        private void buttonLowA_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int pack_current = ((ushort)profile_data[4] | ((ushort)profile_data[5] << 8));
                textBoxLowAmp.Text = Convert.ToString(pack_current);
            }
        }

        private void buttonMidA_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int pack_current = ((ushort)profile_data[4] | ((ushort)profile_data[5] << 8));
                textBoxMidAmp.Text = Convert.ToString(pack_current);
            }
        }

        private void buttonHighA_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int pack_current = ((ushort)profile_data[4] | ((ushort)profile_data[5] << 8));
                textBoxHighAmp.Text = Convert.ToString(pack_current);
            }
        }

        private void ButtonLowVbat_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int pack_voltage = ((ushort)profile_data[2] | ((ushort)profile_data[3] << 8));
                textBoxLowVbat.Text = Convert.ToString(pack_voltage);
            }
        }

        private void ButtonMidVbat_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int pack_voltage = ((ushort)profile_data[2] | ((ushort)profile_data[3] << 8));
                textBoxMidVbat.Text = Convert.ToString(pack_voltage);
            }
        }

        private void ButtonHighVbat_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int pack_voltage = ((ushort)profile_data[2] | ((ushort)profile_data[3] << 8));
                textBoxHighVbat.Text = Convert.ToString(pack_voltage);
            }
        }

        private void ButtonLowVin_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int input_voltage = ((ushort)profile_data[0] | ((ushort)profile_data[1] << 8));
                textBoxLowVin.Text = Convert.ToString(input_voltage);
            }
        }

        private void ButtonMidVin_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int input_voltage = ((ushort)profile_data[0] | ((ushort)profile_data[1] << 8));
                textBoxMidVin.Text = Convert.ToString(input_voltage);
            }
        }

        private void ButtonHighVin_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int input_voltage = ((ushort)profile_data[0] | ((ushort)profile_data[1] << 8));
                textBoxHighVin.Text = Convert.ToString(input_voltage);
            }
        }

        private void ButtonWriteHFileClick(object sender, EventArgs e) //Creates a *.h file to include in the project with hard-coded calibration and configuration_data
        {
            System.IO.StreamWriter stream;
            SaveFileDialog d = new SaveFileDialog();

            if (ReadCalibration() == false)
                return;

            if (ReadConfiguration(true) == false)
                return;

            d.FileName = "MultiChemCharger_Values.h";
            d.DefaultExt = ".h";
            d.Filter = ".h files (*.h)|*.h|All files (*.*)|*.*";

            if (d.ShowDialog() == DialogResult.OK)
            {
                int i;
                string s;
                int count;

                if ((stream = System.IO.File.CreateText(d.FileName)) != null)
                {
                    stream.WriteLine("// MultiChemCharger_Values.h");
                    stream.WriteLine("// slurpee This file provides the hard-coded configuration file required when");
                    stream.WriteLine("// you want a fixed-function charger and don't want to use the GUI to");
                    stream.WriteLine("// configure the system in manufacturing. ");
                    stream.WriteLine("// ");
                    stream.WriteLine("// To use this file, please disable the #define in MultiChemCharger_Main.h");
                    stream.WriteLine("// labeled '#define USE_GUI_CONFIG'.  This will activate #define USE_FIXED_CONFIG");
                    stream.WriteLine("// ");
                    stream.WriteLine("// Note that the only data used by the PIC Firmware is the block below that includes");
                    stream.WriteLine("// descriptions.  All others are used by the GUI to re-populate the configuration there.");
                    stream.WriteLine("//");
                    stream.WriteLine("// Also note that all values below are in ADC counts and represent for the most part the key");
                    stream.WriteLine("// transtion point in the charging algorithm such as the CC/CV transition.");
                    stream.WriteLine("// You can manually edit this file instead of using the GUI by changing these parameters");
                    stream.WriteLine("// based on proper analysis of the circuit.  Changing voltage divider ratios on inputs would");
                    stream.WriteLine("// be a good example of why this would be necessary.");
                    stream.WriteLine("// ");
                    stream.WriteLine("// The Cal_Data_Array is not used by the firmware at all, only by the GUI to determine what");
                    stream.WriteLine("// the ADC counts should be to realize the desired value entered in the GUI.");
                    stream.WriteLine("// ");
                    stream.WriteLine("// ");
                    stream.WriteLine(" ");
                    stream.WriteLine("#ifdef ENABLE_FIXED_CONFIG");
                    stream.WriteLine(" ");

                    stream.WriteLine("#asm");
                    stream.WriteLine(" ");
                    stream.WriteLine("psect text,class=CODE,local,abs,ovrld,delta=2");
                    stream.WriteLine("org 0xe60        // Change this line if you change the location in memory for the config/cal data");
                    stream.WriteLine("_Cal_Data_Array:");

                    Debug.WriteLine("Calibration Data 0xE60");

                    for (i = 0; i < 64; i++)
                    {
                        s = string.Format("    dw {0:X2}{1:X2}h", cal_data[i + 1], cal_data[i]);
                        //                        s = s.PadLeft(s.Length + 1, '0');
                        stream.WriteLine(s);
                        Debug.WriteLine(s);
                        i++;    // Increment by twos
                    }
                    stream.WriteLine("#endasm");


                    stream.WriteLine("// Configuration Data: 0xE80");
                    stream.WriteLine("#asm");
                    stream.WriteLine(" ");
                    stream.WriteLine("psect text,class=CODE,local,abs,ovrld,delta=2");
                    stream.WriteLine("org 0xe80");
                    stream.WriteLine("_Config_Data_Array:");

                    Debug.WriteLine("Configuration Data: 0xE80");

                    count = 0;
                    for (i = 0; i < 128; i++) //changed from 96 to 128
                    {
                        s = string.Format("    dw {0:X2}{1:X2}h  {2}", configuration_data[i + 1], configuration_data[i], default_values_line_titles[count]);
                        stream.WriteLine(s);
                        Debug.WriteLine(s);
                        i++;        // Increment by twos
                        count++;    // Increment titles counter
                    }
                    stream.WriteLine("#endasm");
                    stream.WriteLine(" ");
                    stream.WriteLine(" ");
                    stream.WriteLine("#endif");

                    stream.Close();
                }
            }
            else
            {
                MessageBox.Show("Could not save file.");
            }
        }
        #endregion

        #region Read and Write Configuration to Flash Functions
        /*************************************************************************************/
        /* Below are the functions for configuring the charger.                              */
        /*************************************************************************************/

        private void buttonReadConfiguration_Click(object sender, EventArgs e)
        {
            if (VerifyFWRev() == false) //this pulls the FW revision level hardcoded in the battery charger project.  
                return;

            if (ReadConfiguration(true) == false)
                return;
        }

        private bool ReadConfiguration(bool updatedialog = false)
        {
            bool b;
            int i;
            b = true;

            if (!Init_Serial())
            {
                return false;
            }

            for (i = 0; i < 128; i++)
                configuration_data[i] = 0;

            //b = PICkitS.I2CM.Read(smbusaddr, (byte)(Flash_Access | 0x20), 128, ref configuration_data, ref script); //The offset 0x20 is for configuration data
            b = Serial_Read((ushort)(Flash_Access | Flash_Config_Offset), 128, ref configuration_data);  //The offset 0x20 is for configuration data
            if (b == false)
            {
                MessageBox.Show("Could not read configuration data from battery charger.");
                SerialClose(handle);
                return b;
            }

            /* Check that the charger has been calibrated */
            /*if (ReadCalibration() == false) //%%BRYAN%% kinda pointless since it doesn't actually process the calibration data into the GUI for now.  Just use the read cal button on the cal tab.
            {
                MessageBox.Show("Could not read calibration data from battery charger.");
                SerialClose(handle);
                return b;
            }*/

            /* Read Profile Data Once to get the PCB ID */
            for (i = 0; i < 32; i++)
            {
                profile_data[i] = 0;
            }
            b = Serial_Read(Profile_Access, 32, ref profile_data);
            if (b == false)
            {
                EndProfile();
                MessageBox.Show("Communications lost with battery charger.");
                SerialClose(handle);
                return false;
            }

            /* Populate the GUI settings with the Configuration Data read from Flash*/
            st_cell_voltage = ReadConfigurationDataU16(64);
            st_number_of_cells = (ushort)(ReadConfigurationDataU16(66) & 0x00ff);
            st_chemistry = (byte)(ReadConfigurationDataU16(40));
            st_precondition_voltage = ReadConfigurationDataU16(68);
            st_precondition_current = ReadConfigurationDataU16(70);
            st_charge_current = ReadConfigurationDataU16(72);
            st_termination_current = ReadConfigurationDataU16(74);
            st_maximum_charge_time = ReadConfigurationDataU16(76);
            st_rapid_time_max = ReadConfigurationDataU16(78);
            st_restore_time_max = ReadConfigurationDataU16(80);
            st_minimum_temperature = ReadConfigurationDataI16(82);
            st_maximum_temperature = ReadConfigurationDataI16(84);
            st_termination_voltage = ReadConfigurationDataU16(86);
            st_wire_resistance = ReadConfigurationDataU16(88);
            //            st_UVLO_rising_voltage = temporary - vinintercept[3]
            //cf_adc_uvlo_threshold_off = Convert.ToUInt16(pack_uvlo_falling * vinslope[3] + vinintercept[3]);
            //st_UVLO_falling_voltage = ReadConfigurationDataU16(24); //UVLO_OFF threshold
            if (st_chemistry > 5) //return false; 
            {
                MessageBox.Show(string.Format("Could not read configuration data from battery charger - Unknown Chemistry {0}.", st_chemistry));
                return false;
            }

            if (updatedialog) UpdateSettingsTab();

            if (st_chemistry == 0)
            {
                comboBoxChemistry.Text = "Li-ion";
            }
            else if (st_chemistry == 1)
            {
                comboBoxChemistry.Text = "NiMH";
            }
            else if (st_chemistry == 2)
            {
                comboBoxChemistry.Text = "VRLA CCCP";
            }
            else if (st_chemistry == 3)
            {
                comboBoxChemistry.Text = "VRLA Fast";
            }
            else if (st_chemistry == 4)
            {
                comboBoxChemistry.Text = "LiFePO4";
            }
            else if (st_chemistry == 5)
            {
                comboBoxChemistry.Text = "Super Capacitor";
            }
            return b;
        }

        ushort ReadConfigurationDataU16(int index)
        {
            ushort n;
            n = (ushort)((((ushort)configuration_data[index + 1]) << 8) | ((ushort)configuration_data[index]));
            return n;
        }

        short ReadConfigurationDataI16(int index)
        {
            int n;

            n = ReadConfigurationDataU16(index);

            if ((n & 0x2000) != 0)
                n |= 0xc000;

            return (short)n;
        }

        private void SetConfigurationData(int index, ushort b)
        {
            configuration_data[(index << 1) + 0] = Convert.ToByte(b & 0x00ff);
            configuration_data[(index << 1) + 1] = Convert.ToByte((b >> 8) & 0x00ff);
        }

        private void buttonWriteConfiguration_Click(object sender, EventArgs e)
        {
            bool b;
            int i;

            /* Check the firmware revision */
            if (VerifyFWRev() == false) //this pulls the FW revision level hardcoded in the battery charger project.  
                return;

            /* Check that the charger has been calibrated */
            if (ReadCalibration() == false)
                return;

            string Chemistry = comboBoxChemistry.Text;
            bool thermistor = checkBoxThermistor.Checked;
            double cell_voltage = ToDouble(textBoxCellVoltage.Text);
            double precondition_voltage = ToDouble(textBoxPreconditionCellVoltage.Text);
            double termination_voltage = ToDouble(textBoxTerminationVoltage.Text);
            double number_of_cells = ToDouble(comboBoxNumberOfCells.Text);
            double charge_current = ToDouble(textBoxChargeCurrent.Text);
            double precondition_current = ToDouble(textBoxPreconditionCurrent.Text);
            double termination_current = ToDouble(textBoxTerminationCurrent.Text);
            double maximum_charge_time = ToDouble(textBoxMaximumChargeTime.Text);
            double rapid_charge_time = ToDouble(textBoxRapidChargeTime.Text);
            double restoration_time = ToDouble(textBoxRestorationChargeTime.Text);
            double minimum_temperature = ToDouble(textBoxMinimumTemperature.Text);
            double maximum_temperature = ToDouble(textBoxMaximumTemperature.Text);
            double UVLO_Rising_Box = ToDouble(textBoxUVLORising.Text);
            double UVLO_Falling_Box = ToDouble(textBoxUVLOFalling.Text);
            double wire_resistance = ToDouble(textBoxWireRes.Text);

            if (double.IsInfinity(UVLO_Rising_Box) | double.IsNaN(UVLO_Rising_Box))
                UVLO_Rising_Box = 0;    // Check if the UVLO Rising is currently at Infinity and correct
            if (double.IsInfinity(UVLO_Falling_Box) | double.IsNaN(UVLO_Falling_Box))
                UVLO_Falling_Box = 0;    // Check if the UVLO Falling is currently at Infinity and correct

            /* It is dangerous to change these. Be very, very careful before doing so.
             * This is why they are not settable from the GUI. */
            //%%BRYAN%% That's nice, but everything needs to be settable from the GUI. Address this.
            double dvdt_blank_time = 2.5; /* Minutes */
            double dtdt_slope = 1.5; /* °C/min */

            /* This data is only valid for the Microchip specified thermistor */
            //%%BRYAN%% What is the MCHP specified thermistor. Add some interface to configure and calibrate this.
            //double thermistor_slope = (-37.459);
            //double thermistor_intercept = (3037.8);

            if (Chemistry == "Li-ion")
            {
                st_chemistry = 0;

                if ((cell_voltage > 4.3) || (cell_voltage < 2.0))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (2.0 to 4.3).");
                    return;
                }

                if ((number_of_cells > 5.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 5).");
                    return;
                }

                if ((precondition_voltage > 4.0) || (precondition_voltage < 2.0))
                {
                    MessageBox.Show("The entered precondition voltage is out of range (2.0 to 4.0).");
                    return;
                }

                if ((charge_current > 6.0) || (charge_current < 0.400))
                {
                    MessageBox.Show("The entered charge current is out of range (0.400 to 6.0).");
                    return;
                }

                if ((precondition_current > charge_current) || (precondition_current < 0.050))
                {
                    MessageBox.Show("The entered precondition current is out of range (0.050 to Charge Current).");
                    return;
                }

                if ((termination_current > charge_current) || (termination_current < 0.050))
                {
                    MessageBox.Show("The entered termination current is out of range (0.050 to Charge Current).");
                    return;
                }

                if ((maximum_charge_time > 1080) || (maximum_charge_time < 1))
                //if ((maximum_charge_time > 600) || (maximum_charge_time < 1))     // 07222014 Test
                {
                    MessageBox.Show("The entered maximum charge time is out of range (1 to 1080).");
                    return;
                }

                //label31.Text = string.Format("{0:F1} Vmin.", (((number_of_cells * cell_voltage) + 0.200) + 2.0));

                minimum_temperature = 200.0;
                maximum_temperature = 200.0;
            }
            else if (Chemistry == "VRLA CCCP")
            {
                st_chemistry = 2;

                // if ((cell_voltage > 2.9) || (cell_voltage < 1.5))
                if ((cell_voltage > 2.45) || (cell_voltage < 1.5))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (1.5 to 2.45).");
                    return;
                }

                if ((number_of_cells > 6.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 6).");
                    return;
                }

                if ((precondition_voltage > 2.0) || (precondition_voltage < 1.1))     //1.5
                {
                    MessageBox.Show("The entered precondition voltage is out of range (1.1 to 2.0).");
                    return;
                }

                if ((charge_current > 6.0) || (charge_current < 0.400))
                {
                    MessageBox.Show("The entered charge current is out of range (0.400 to 6.0).");
                    return;
                }

                if ((precondition_current > charge_current) || (precondition_current < 0.100))
                {
                    MessageBox.Show("The entered precondition current is out of range (0.100 to Charge Current).");
                    return;
                }

                if ((termination_current > charge_current) || (termination_current < 0.100))
                {
                    MessageBox.Show("The entered termination current is out of range (0.100 to Charge Current).");
                    return;
                }

                //          if ((maximum_charge_time > 1200) || (maximum_charge_time < 1))
                if ((maximum_charge_time > 1080) || (maximum_charge_time < 1))    // 1080 * 60 = 64800 < 65535(2 bytes)
                {
                    MessageBox.Show("The entered maximum charge time is out of range (1 to 1080).");
                    return;
                }

                //label31.Text = string.Format("{0:F1} Vmin.", (((number_of_cells * cell_voltage) + 0.200) + 2.0));

                minimum_temperature = 200.0;
                maximum_temperature = 200.0;
            }
            else if (Chemistry == "VRLA Fast")
            {
                st_chemistry = 3;

                // if ((cell_voltage > 2.9) || (cell_voltage < 1.5))
                if ((cell_voltage > 2.45) || (cell_voltage < 1.5))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (1.5 to 2.45).");
                    return;
                }

                if ((number_of_cells > 6.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 6).");
                    return;
                }

                if ((precondition_voltage > 2.0) || (precondition_voltage < 1.5))
                {
                    MessageBox.Show("The entered precondition voltage is out of range (1.5 to 2.0).");
                    return;
                }

                // if ((termination_voltage > 3.0) || (termination_voltage < cell_voltage))
                if ((termination_voltage > 2.7) || (termination_voltage < cell_voltage))
                {
                    MessageBox.Show("The entered termination voltage is out of the range (Cell Voltage to 2.7).");
                    return;
                }

                if ((charge_current > 6.0) || (charge_current < 0.400))
                {
                    MessageBox.Show("The entered charge current is out of range (0.400 to 6.0).");
                    return;
                }

                if ((precondition_current > charge_current) || (precondition_current < 0.100))
                {
                    MessageBox.Show("The entered restoration current is out of range (0.100 to Charge Current).");
                    return;
                }

                if ((termination_current > charge_current) || (termination_current < 0.100))
                {
                    MessageBox.Show("The entered trickle current is out of range (0.100 to Charge Current).");
                    return;
                }

                if ((maximum_charge_time > 1080) || (maximum_charge_time < 1))
                {
                    MessageBox.Show("The entered maximum charge time is out of range (1 to 1080).");
                    return;
                }
                if ((rapid_charge_time > 240) || (rapid_charge_time < 1))
                {
                    MessageBox.Show("The entered rapid charge time is out of range (1 to 240).");
                    return;
                }

                if ((restoration_time > maximum_charge_time) || (restoration_time < 1))
                {
                    MessageBox.Show("The entered trickle time is out of range (1 to Maximum Charge Time).");
                    return;
                }

                //label31.Text = string.Format("{0:F1} Vmin.", (((number_of_cells * cell_voltage) + 0.200) + 2.0));

                minimum_temperature = 200.0;
                maximum_temperature = 200.0;
            }
            else if (Chemistry == "LiFePO4")
            {
                st_chemistry = 4;

                //        if ((cell_voltage > 4.2) || (cell_voltage < 3.0))     // 07222014 test

                if ((cell_voltage > 3.7) || (cell_voltage < 2.0))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (2.0 to 3.7).");
                    return;
                }

                if ((number_of_cells > 6.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 6).");
                    return;
                }

                if ((precondition_voltage > 3.2) || (precondition_voltage < 1.5))
                {
                    MessageBox.Show("The entered precondition voltage is out of range (1.5 to 3.2).");
                    return;
                }

                if ((charge_current > 6.0) || (charge_current < 0.400))
                {
                    MessageBox.Show("The entered charge current is out of range (0.400 to 6.0).");
                    return;
                }

                if ((precondition_current > charge_current) || (precondition_current < 0.050))
                {
                    MessageBox.Show("The entered precondition current is out of range (0.050 to Charge Current).");
                    return;
                }

                if ((termination_current > charge_current) || (termination_current < 0.050))
                {
                    MessageBox.Show("The entered termination current is out of range (0.050 to Charge Current).");
                    return;
                }

                if ((maximum_charge_time > 1080) || (maximum_charge_time < 1))
                //if ((maximum_charge_time > 600) || (maximum_charge_time < 1))     // 07222014 Test
                {
                    MessageBox.Show("The entered maximum charge time is out of range (1 to 1080).");
                    return;
                }

                //label31.Text = string.Format("{0:F1} Vmin.", (((number_of_cells * cell_voltage) + 0.200) + 2.0));

                minimum_temperature = 200.0;
                maximum_temperature = 200.0;
            }
            else if (Chemistry == "NiMH")
            {
                st_chemistry = 1;

                if ((cell_voltage > 2.0) || (cell_voltage < 1.0))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (1.0 to 2.0).");
                    return;
                }

                if ((termination_voltage > 2.0) || (termination_voltage < cell_voltage))
                {
                    MessageBox.Show("The entered termination voltage is out of the range (Cell Votlage to 2.0).");
                    return;
                }

                if ((number_of_cells > 8.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 8).");
                    return;
                }

                if ((precondition_voltage > 1.0) || (precondition_voltage < 0.7))
                {
                    MessageBox.Show("The entered precondition voltage is out of range (0.7 to 1.0).");
                    return;
                }

                if ((charge_current > 6.0) || (charge_current < 0.400))
                {
                    MessageBox.Show("The entered charge current is out of range (0.400 to 6.0).");
                    return;
                }

                if ((precondition_current > charge_current) || (precondition_current < 0.100))
                {
                    MessageBox.Show("The entered restoration current is out of range (0.100 to Charge Current).");
                    return;
                }

                if ((termination_current > charge_current) || (termination_current < 0.0))
                {
                    MessageBox.Show("The entered trickle current is out of range (0 to Charge Current).");
                    return;
                }

                // if ((maximum_charge_time > 900) || (maximum_charge_time < 1))
                if ((maximum_charge_time > 1080) || (maximum_charge_time < 1))
                {
                    MessageBox.Show("The entered maximum charge time is out of range (1 to 1080).");
                    return;
                }

                if ((rapid_charge_time > maximum_charge_time) || (rapid_charge_time < 1))
                {
                    MessageBox.Show("The entered rapid charge time is out of range (1 to Maximum Charge Time).");
                    return;
                }

                if ((restoration_time > maximum_charge_time) || (restoration_time < 1))
                {
                    MessageBox.Show("The entered restoration time is out of range (1 to Maximum Charge Time).");
                    return;
                }

                //label31.Text = string.Format("{0:F1} Vmin.", (((number_of_cells * cell_voltage) + 0.200) + 2.0));

                if (thermistor)
                {
                    if ((minimum_temperature < 0) || (minimum_temperature >= maximum_temperature) || (minimum_temperature > 65.0))
                    {
                        MessageBox.Show("The minimum temperature is out of range (0 °C to Maximum Temperature or 65 °C).");
                        return;
                    }

                    if ((maximum_temperature < 0) || (maximum_temperature > 65.0))
                    {
                        MessageBox.Show("The minimum temperature is out of range (Minimum Temperature to 65 °C).");
                        return;
                    }
                }
                else
                {
                    minimum_temperature = 200;
                    maximum_temperature = 200;
                }
            }
            else if (Chemistry == "Super Capacitor")
            {
                st_chemistry = 5;

                if ((cell_voltage > 2.8) || (cell_voltage < 1.0))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (1.0 to 2.8).");
                    return;
                }

                //There is no termination stage for super-capacitors
                //if ((termination_voltage > 2.8) || (termination_voltage < cell_voltage))
                //{
                //    MessageBox.Show("The entered termination voltage is out of the range (Cell Votlage to 2.8).");
                //    return;
                //}

                if ((number_of_cells > 8.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 8).");
                    return;
                }

                //There is no precondition stage for super-capacitors
                //if ((precondition_voltage > 1.0) || (precondition_voltage < 0.7))
                //{
                //    MessageBox.Show("The entered precondition voltage is out of range (0.7 to 1.0).");
                //    return;
                //}

                if ((charge_current > 6.0) || (charge_current < 0.100))
                {
                    MessageBox.Show("The entered charge current is out of range (0.100 to 6.0).");
                    return;
                }

                //There is no precondition stage for super-capacitors
                //if ((precondition_current > charge_current) || (precondition_current < 0.100))
                //{
                //    MessageBox.Show("The entered restoration current is out of range (0.100 to Charge Current).");
                //    return;
                //}

                //There is no precondition stage for super-capacitors
                //if ((termination_current > charge_current) || (termination_current < 0.0))
                //{
                //   MessageBox.Show("The entered trickle current is out of range (0 to Charge Current).");
                //    return;
                //}

                if ((maximum_charge_time > 720) || (maximum_charge_time < 1))
                {
                    MessageBox.Show("The entered maximum charge time is out of range (1 to 720).");
                    return;
                }

                //There is no rapid charge cycle for super-capacitors
                //if ((rapid_charge_time > maximum_charge_time) || (rapid_charge_time < 1))
                //{
                //    MessageBox.Show("The entered rapid charge time is out of range (1 to Maximum Charge Time).");
                //    return;
                //}

                //There is no precondition stage for super-capacitors
                //if ((restoration_time > maximum_charge_time) || (restoration_time < 1))
                //{
                //    MessageBox.Show("The entered restoration time is out of range (1 to Maximum Charge Time).");
                //    return;
                //}

                //label31.Text = string.Format("{0:F1} Vmin.", (((number_of_cells * cell_voltage) + 0.200) + 2.0));

                if (thermistor)
                {
                    if ((minimum_temperature < 0) || (minimum_temperature >= maximum_temperature) || (minimum_temperature > 65.0))
                    {
                        MessageBox.Show("The minimum temperature is out of range (0 °C to Maximum Temperature or 65 °C).");
                        return;
                    }

                    if ((maximum_temperature < 0) || (maximum_temperature > 65.0))
                    {
                        MessageBox.Show("The minimum temperature is out of range (Minimum Temperature to 65 °C).");
                        return;
                    }
                }
                else
                {
                    minimum_temperature = 200;
                    maximum_temperature = 200;
                }
            }
            else
            {
                MessageBox.Show("Unknown chemistry chosen.");
                return;
            }

            /* Now the configuration settings for the charger (what the charger uses) */
            double pack_ov;
            double pack_conditioned;
            double pack_termvoltage;
            double pack_uvlo_rising;
            double pack_uvlo_falling;
            double temp;

            /* Settings for the GUI or regenerating run constants in EEPROM */
            st_cell_voltage = Convert.ToUInt16(cell_voltage * 1000.0);
            st_number_of_cells = Convert.ToUInt16(number_of_cells);
            st_precondition_voltage = Convert.ToUInt16(precondition_voltage * 1000.0);
            st_precondition_current = Convert.ToUInt16(precondition_current * 1000.0);
            st_charge_current = Convert.ToUInt16(charge_current * 1000.0);
            st_termination_current = Convert.ToUInt16(termination_current * 1000.0);
            st_maximum_charge_time = Convert.ToUInt16(maximum_charge_time);
            st_rapid_time_max = Convert.ToUInt16(rapid_charge_time);
            st_restore_time_max = Convert.ToUInt16(restoration_time);
            st_minimum_temperature = Convert.ToInt16(minimum_temperature);
            st_maximum_temperature = Convert.ToInt16(maximum_temperature);
            st_termination_voltage = Convert.ToUInt16(termination_voltage * 1000.0);
            st_wire_resistance = Convert.ToUInt16(wire_resistance);
            pack_uvlo_rising = (double)Convert.ToUInt16(UVLO_Rising_Box * 10) / 10; //**BRYAN** what the *10 / 10?
            pack_uvlo_falling = (double)Convert.ToUInt16(UVLO_Falling_Box * 10) / 10; //**BRYAN** what the *10 / 10?

            if ((pack_uvlo_rising > 30.0) || (pack_uvlo_rising < 4.0))
            {
                MessageBox.Show("UVLO Rising is out of the range (4.0 to 30.0).");
                return;
            }

            if ((pack_uvlo_falling > 30.0) || (pack_uvlo_falling < 4.0))
            {
                MessageBox.Show("UVLO Falling is out of the range (4.0 to 30.0).");
                return;
            }

            if (pack_uvlo_rising < pack_uvlo_falling)
            {
                MessageBox.Show("UVLO Rising must be higher than UVLO Falling.");
                return;
            }

            //%%BRYAN%% Check the cell chemistries out for correct pack_ov formulas
            if (st_chemistry == 0) /* Li-ion */
            {
                pack_ov = (number_of_cells * cell_voltage) + 0.200;
                pack_conditioned = (number_of_cells * precondition_voltage);
                pack_termvoltage = (number_of_cells * cell_voltage);
            }
            else if (st_chemistry == 1) /* NiMH */
            {
                pack_ov = (number_of_cells * termination_voltage) + 0.200;
                pack_conditioned = (number_of_cells * precondition_voltage);
                pack_termvoltage = (number_of_cells * termination_voltage);
            }
            else if (st_chemistry == 2) /* VRLA CCCP */
            {
                pack_ov = (number_of_cells * (cell_voltage + 0.72 + 0.072));
                pack_conditioned = (number_of_cells * precondition_voltage);
                pack_termvoltage = (number_of_cells * (cell_voltage + 0.45));
            }
            else if (st_chemistry == 3) /* VRLA Fast */
            {
                pack_ov = (number_of_cells * (termination_voltage * 1.03));
                pack_conditioned = (number_of_cells * precondition_voltage);
                pack_termvoltage = (number_of_cells * termination_voltage);
            }
            else if (st_chemistry == 4) /* LiFePO4 */
            {
                pack_ov = (number_of_cells * cell_voltage) + 0.200;
                pack_conditioned = (number_of_cells * precondition_voltage);
                pack_termvoltage = (number_of_cells * cell_voltage);
            }
            else if (st_chemistry == 5) /* Super-Capacitor */
            {
                pack_ov = (number_of_cells * cell_voltage) + 0.200;
                //There is no precondition stage for super capacitors
                pack_conditioned = 0;
                pack_termvoltage = (number_of_cells * cell_voltage);
            }
            else
            {
                pack_ov = 0.0;
                pack_conditioned = 0.0;
                pack_termvoltage = 0.0;
            }

            //double Inter_V3;                      // UVLO limit at 6.0V to guarentee good self-power
            //Inter_V3 = pack_termvoltage + 2.0;
            //if (Inter_V3 < 6.0) Inter_V3 = 6.0;

            //%%BRYAN%% Oh boy, this needs to get tweaked something awful especially for buck boost designs.
            //Stop being smarter than the user here for the GUI and just take the input they put in.
            //cf_uvlo_threshold_off = Convert.ToByte(26.5 * Math.Log(Inter_V3 / 4.0));
            //cf_uvlo_threshold_on = Convert.ToByte(26.5 * Math.Log(Inter_V3 / 4.0));
            //pack_uvlo_rising = (double)st_UVLO_rising_voltage;
            //pack_uvlo_falling = (double)st_UVLO_falling_voltage;
            cf_uvlo_threshold_off = Convert.ToByte(26.5 * Math.Log(pack_uvlo_falling / 4.0)); //formula per MCP1911X datasheet
            cf_uvlo_threshold_on = Convert.ToByte(26.5 * Math.Log(pack_uvlo_rising / 4.0)); //formula per MCP1911X datasheet

            cf_vbat_ov = Convert.ToUInt16(pack_ov * vbatslope[3] + vbatintercept[3]);
            if (st_chemistry == 5) // Super Capacitor
            {
                cf_vbat_pc = 0;
                cf_ibat_pc = Convert.ToUInt16((charge_current * 0.1) * ibatslope[3] + ibatintercept[3]);
            }
            else
            {
                cf_vbat_pc = Convert.ToUInt16(pack_conditioned * vbatslope[3] + vbatintercept[3]);
                cf_ibat_pc = Convert.ToUInt16(precondition_current * ibatslope[3] + ibatintercept[3]);
            }
            cf_vbat_cv = Convert.ToUInt16(pack_termvoltage * vbatslope[3] + vbatintercept[3]);
            cf_ibat_cc = Convert.ToUInt16(charge_current * ibatslope[3] + ibatintercept[3]);
            cf_ibat_ct = Convert.ToUInt16(termination_current * ibatslope[3] + ibatintercept[3]);
            cf_charge_time_max = Convert.ToUInt16(maximum_charge_time * 60.0);

            //%%BRYAN%% this is going to be ugly below and needs to be broken out to a hardware specific routine.  For now we're going to switch
            //this so that it will use the correct setting for calculating the OVFCON and OVCCON values.  The MCP19118 four switch board doesn't 
            //feed a current into that amplifier, but an output voltage instead.
            double d;
            switch (profile_data[27])
            {
                case 4:
                    d = Convert.ToDouble(cf_vbat_ov) * 5.0 / 4095.0;
                    d = (d * 1000.0 / 15.8) + 2.0; //%%BRYAN%% This doesn't agree with the datasheet.  The datasheet has a -1 isntead of a +2.
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_max = Convert.ToByte(d);

                    d = Convert.ToDouble(cf_vbat_pc) * 5.0 / 4095.0;
                    d = (d * 1000.0 / 15.8) - 2.0; //%%BRYAN%% This doesn't agree with the datasheet. The datasheet has a -1 isntead of a -2.
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_min = Convert.ToByte(d); break;

                case 6: //This is the ADM00745 MCP19125 Flyback Charger. Setup for 3S Li+. //%%BRYAN%% Warning this can break any other battery combination on startup.
                    d = Convert.ToDouble(cf_ibat_cc) * 4.096 / 4096.0;
                    d = (d * 255) / (1.23 * 2); //N = (VREF * 255) / (1.23V_BG * 10_Gain) //%%BRYAN%% The datasheet says 1.23V, but the HW is scaling to 2.46V like it does for OVREFCON.
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_max = Convert.ToByte(d);
                    //cf_ovcfcon_max = 0xff;

                    temp = (pack_termvoltage * 255 * 0.1304) / (2 * 1.23);
                    cf_ovrefcon_cv = Convert.ToUInt16(temp);
                    //cf_ovrefcon_cv = 0xff;
                    temp = (pack_ov * 255 * 0.1304) / (2 * 1.23);
                    cf_ovrefcon_ov = Convert.ToUInt16(temp);
                    cf_vrefcon_max = cf_ovcfcon_max;
                    break;

                default:
                    d = Convert.ToDouble(cf_ibat_cc) * 5.0 / 4095.0;
                    d = (d * 1000.0 / 15.8) + 2.0; //%%BRYAN%% This doesn't agree with the datasheet.  The datasheet has a -1 isntead of a +2.
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_max = Convert.ToByte(d);

                    d = ibatintercept[3] * 5.0 / 4095.0;
                    d = (d * 1000.0 / 15.8) - 2.0; //%%BRYAN%% This doesn't agree with the datasheet. The datasheet has a -1 isntead of a -2.
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_min = Convert.ToByte(d);
                    break;
            }


            //%%BRYAN%% What's so special about NiMH
            /*if (profile_data[27] == 1) 
            {
                cf_adc_uvlo_threshold_off = Convert.ToUInt16(Inter_V3 * vinslope[3] + vinintercept[3]);
                cf_adc_uvlo_threshold_on = Convert.ToUInt16((Inter_V3 + 0.5) * vinslope[3] + vinintercept[3]);
            }*/
            //else
            //{
            cf_adc_uvlo_threshold_off = Convert.ToUInt16(pack_uvlo_falling * vinslope[3] + vinintercept[3]);
            cf_adc_uvlo_threshold_on = Convert.ToUInt16(pack_uvlo_rising * vinslope[3] + vinintercept[3]);
            //}


            cf_restore_time_max = Convert.ToUInt16(60.0 * restoration_time);
            cf_dvdt_blank_time = Convert.ToUInt16(60.0 * dvdt_blank_time);
            cf_rapid_time_max = Convert.ToUInt16(60.0 * rapid_charge_time);

            if (minimum_temperature >= 100.0)
            {
                cf_dtdt_slope = 0;
                cf_pack_temp_min = 4095;
                cf_pack_temp_max = 0;
            }
            else
            {
                cf_dtdt_slope = Convert.ToInt16(thermistor_slope * dtdt_slope);
                //cf_pack_temp_min = Convert.ToUInt16(minimum_temperature * thermistor_slope + thermistor_intercept);
                cf_pack_temp_min = Convert.ToUInt16((minimum_temperature - thermistor_cal_temp) * thermistor_slope + thermistor_intercept);
                //cf_pack_temp_max = Convert.ToUInt16(maximum_temperature * thermistor_slope + thermistor_intercept);
                cf_pack_temp_max = Convert.ToUInt16((maximum_temperature - thermistor_cal_temp) * thermistor_slope + thermistor_intercept);
            }

            cf_chemistry = Convert.ToByte(st_chemistry);

            Debug.WriteLine(string.Format("UVLO Off Threshold: {0}", cf_uvlo_threshold_off));
            Debug.WriteLine(string.Format("UVLO On Threshold: {0}", cf_uvlo_threshold_on));
            Debug.WriteLine(string.Format("Battery Overvoltage: {0}", cf_vbat_ov));
            Debug.WriteLine(string.Format("Precondition Voltage: {0}", cf_vbat_pc));
            Debug.WriteLine(string.Format("Charge Voltage: {0}", cf_vbat_cv));
            Debug.WriteLine(string.Format("Precondition Current: {0}", cf_ibat_pc));
            Debug.WriteLine(string.Format("Charge Current: {0}", cf_ibat_cc));
            Debug.WriteLine(string.Format("Charge Term Current: {0}", cf_ibat_ct));
            Debug.WriteLine(string.Format("Charge Time: {0}", cf_charge_time_max));
            Debug.WriteLine(string.Format("Output Reference Max: {0}", cf_ovcfcon_max));
            Debug.WriteLine(string.Format("Output Reference Min: {0}", cf_ovcfcon_min));
            Debug.WriteLine(string.Format("Input UVLO off (ADC): {0}", cf_adc_uvlo_threshold_off));
            Debug.WriteLine(string.Format("Input UVLO on (ADC): {0}", cf_adc_uvlo_threshold_on));
            Debug.WriteLine(string.Format("Restoration voltage timeout: {0}", cf_restore_time_max));
            Debug.WriteLine(string.Format("dV/dt detection blanking interval: {0}", cf_dvdt_blank_time));
            Debug.WriteLine(string.Format("Maximum rapid charge time: {0}", cf_rapid_time_max));
            Debug.WriteLine(string.Format("dT/dt slope: {0}", cf_dtdt_slope));
            Debug.WriteLine(string.Format("Pack Temp Minimum: {0}", cf_pack_temp_min));
            Debug.WriteLine(string.Format("Pack Temp Maximum: {0}", cf_pack_temp_max));
            Debug.WriteLine(string.Format("Chemistry: {0}", cf_chemistry));
            Debug.WriteLine(string.Format("OVREFCON_OV: {0}", cf_ovrefcon_ov)); //MCP19125 specific
            Debug.WriteLine(string.Format("OVREFCON_CV: {0}", cf_ovrefcon_cv)); //MCP19125 specific
            Debug.WriteLine(string.Format("VREFCON_MAX: {0}", cf_vrefcon_max)); //MCP19125 specific


            for (i = 0; i < 128; i++)
                configuration_data[i] = 0x00;

            SetConfigurationData(0, cf_uvlo_threshold_off);
            SetConfigurationData(1, cf_uvlo_threshold_on);
            SetConfigurationData(2, cf_vbat_ov);
            SetConfigurationData(3, cf_vbat_pc);
            SetConfigurationData(4, cf_vbat_cv);
            SetConfigurationData(5, cf_ibat_pc);
            SetConfigurationData(6, cf_ibat_cc);
            SetConfigurationData(7, cf_ibat_ct);
            SetConfigurationData(8, (ushort)(cf_charge_time_max & 0x00ff));
            SetConfigurationData(9, (ushort)((cf_charge_time_max >> 8) & 0x00ff));
            SetConfigurationData(10, cf_ovcfcon_min);
            SetConfigurationData(11, cf_ovcfcon_max);
            SetConfigurationData(12, cf_adc_uvlo_threshold_off);
            SetConfigurationData(13, cf_adc_uvlo_threshold_on);
            SetConfigurationData(14, cf_restore_time_max);
            SetConfigurationData(15, cf_dvdt_blank_time);
            SetConfigurationData(16, cf_rapid_time_max);
            SetConfigurationData(17, (ushort)cf_dtdt_slope);
            SetConfigurationData(18, cf_pack_temp_min);
            SetConfigurationData(19, cf_pack_temp_max);
            SetConfigurationData(20, cf_chemistry);
            SetConfigurationData(21, cf_ovrefcon_ov);
            SetConfigurationData(22, cf_ovrefcon_cv);
            SetConfigurationData(23, cf_vrefcon_max);
            SetConfigurationData(32, st_cell_voltage);
            SetConfigurationData(33, (ushort)(st_number_of_cells | (((ushort)st_chemistry) << 8)));
            SetConfigurationData(34, st_precondition_voltage);
            SetConfigurationData(35, st_precondition_current);
            SetConfigurationData(36, st_charge_current);
            SetConfigurationData(37, st_termination_current);
            SetConfigurationData(38, st_maximum_charge_time);
            SetConfigurationData(39, st_rapid_time_max);
            SetConfigurationData(40, st_restore_time_max);
            SetConfigurationData(41, (ushort)st_minimum_temperature);
            SetConfigurationData(42, (ushort)st_maximum_temperature);
            SetConfigurationData(43, st_termination_voltage);
            SetConfigurationData(44, st_wire_resistance);


            /* For flash writes the DEPA/PIC expects the second byte to set the 7th bit in the word (0x40) for flash writes. */
            /* The actual offset desired from the CAL_BASE_ADDR set up in the hardware is masked by 0x7F.  So 0x20 is the conifuration data. */

            //Debug.WriteLine(script);
            b = Serial_Write((ushort)(Flash_Access | Flash_Config_Offset), 128, ref configuration_data);

            if (b == false)
            {
                b = false;   // Debugging breakpoint
                MessageBox.Show("Could not write configuration data to battery charger.");
                return;
            }

            //Debug.WriteLine(script);
            b = Serial_Read((ushort)(Flash_Access | Flash_Config_Offset), 128, ref verification_data);

            if (b == false)
            {
                b = false;   // Debugging breakpoint
                MessageBox.Show("Verification of configuration data failed (readback).");
                SerialClose(handle);
                return;
            }

            b = true;

            for (i = 0; i < 128; i++)
            {
                if ((i & 0x01) == 0)
                {
                    if (configuration_data[i] != verification_data[i])
                        b = false;
                }
                else
                {
                    if ((configuration_data[i] & 0x3f) != verification_data[i])
                        b = false;  // 12-bit data compare only
                }
                //               Debug.WriteLine(string.Format("{0} verification_data {1}, {2} configuration_data", i, verification_data[i], configuration_data[i]));
            }

            if (b == false)
            {
                b = false;   // Debugging breakpoint
                MessageBox.Show("Verification of configuration data failed.");
            }
            else
            {
                b = true;   // Debugging breakpoint
                MessageBox.Show("Configuration succeeded.");
            }

            /* Request charger to re-read configuration */
            ChargerCommand(0x02);
        }
        #endregion

        #region Utility Functions
        /********************************************************************************/
        /* Utility Functions                                                            */
        /********************************************************************************/

        private bool Init_Serial()
        {
            ushort a;
            bool b;
            int c;
            uint nMCP2221 = 0;
            string e;

            if (initialized == true)
            {
                return initialized;
            }

            a = PICkitS.Device.How_Many_Of_MyDevices_Are_Attached(0x0036); //0x36 is the Microchip Pickit Serial PID
            if (a > 0)
            {
                serial_device = 1;
                if (a > 1)
                {
                    MessageBox.Show("More than one Pickit Serial is attached via USB.");
                }
            }
            c = mcp2221_dll_m.MCP2221.M_Mcp2221_GetConnectedDevices(0x4d8, 0xDD, ref nMCP2221);
            if (c == 0)
            {
                serial_device = 2;
                if (nMCP2221 > 1)
                {
                    MessageBox.Show("More than one MCP2221A is attached via USB.");
                }
            }

            switch (serial_device)
            {
                case (1): //Initialization routine for the Pickit serial
                    b = PICkitS.Basic.Initialize_PICkitSerial();
                    if (b == false)
                    {
                        MessageBox.Show("Could not initialize PICkit Serial.");
                        initialized = false;
                        return initialized;
                    }

                    b = PICkitS.I2CM.Configure_PICkitSerial_For_I2CMaster(false, false, true, true, true, 5);
                    if (b == false)
                    {
                        MessageBox.Show("Could not configure PICkit Serial for I2C Master.");
                        initialized = false;
                        return initialized;
                    }

                    b = PICkitS.I2CM.Tell_PKSA_To_Use_External_Voltage_Source();
                    if (b == false)
                    {
                        MessageBox.Show("Could not set PICkit Serial to Use External Voltage Source.");
                        initialized = false;
                        return initialized;
                    }

                    b = PICkitS.Device.Set_Buffer_Flush_Time(0x0A);
                    if (b == false)
                    {
                        MessageBox.Show("Could not set Pickit Serial Buffer Flush Time.");
                        initialized = false;
                        return initialized;
                    }

                    b = PICkitS.I2CM.Set_I2C_Bit_Rate(100);
                    if (b == false)
                    {
                        MessageBox.Show("Could not set PICkit Serial I2C Bit Rate.");
                        initialized = false;
                        return initialized;
                    }

                    PICkitS.Device.Clear_Comm_Errors();
                    break;

                case (2): //Initialization routine for the MCP2221A

                    //c = mcp.Settings.GetConnectionStatus();
                    //if (!isDeviceConnected())

                    handle = mcp2221_dll_m.MCP2221.M_Mcp2221_OpenByIndex(0x04D8, 0x00DD, nMCP2221 - 1);
                    if ((int)(handle) < 0)
                    {
                        MessageBox.Show("Could not initialize MCP2221A Device.");
                        initialized = false;
                        return initialized;
                    }
                    e = mcp2221_dll_m.MCP2221.M_Mcp2221_GetFirmwareRevision(handle);
                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_SetSpeed(handle, 50000);
                    if (c != 0)
                    {
                        MessageBox.Show(string.Format("Could not set MCP2221A Speed. {0}", c));
                        SerialClose(handle);
                        initialized = false;
                        return initialized;
                    }
                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_SetAdvancedCommParams(handle, 10, 10);
                    if (c != 0)
                    {
                        MessageBox.Show(string.Format("Could not set MCP2221A advanced comm parameters. {0}", c));
                        SerialClose(handle);
                        initialized = false;
                        return initialized;
                    }
                    break;

                default:
                    MessageBox.Show("Nothing to Initialize");
                    initialized = false;
                    return initialized;
            }
            initialized = true;
            return initialized;
        }

        private void SerialClose(IntPtr handle) //%%BRYAN%% Revisit this.  PKSA uses it as a recover and MCP2221A uses it to gracefully shutdown.  
        {
            int c;
            switch (serial_device)
            {
                case (1):
                    {
                        PICkitS.Device.Clear_Comm_Errors();
                        break;
                    }
                case (2):
                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_Close(handle);
                    if (c != 0)
                    {
                        Debug.WriteLine(string.Format("Could not Close MCP2221A. {0} failed to close", c));
                    }
                    initialized = false;
                    break;
                default:
                    break;
            }
        }

        public bool Process() //%%BRYAN%% Trying to mimic some of Erick's C# methodology.  This isn't functional for the GUI yet.
        {
            if (initialized)
            {
                switch (statesProcess)
                {
                    case ProcessStates.ConfigMCP2221:
                        statesProcess = ProcessStates.CheckSlave;
                        return false;
                    case ProcessStates.CheckSlave:
                        I2CWriteBuffer[0] = 0;
                        //if (serial_device == 1)
                        //{
                        //if (PICkitS.I2CM.Read(smbusaddr, Flash_Access, 1, ref I2CWriteBuffer, ref script)) //%%BRYAN%% change this to a write once you get some RAM access working in the firmware.  Or feed it another placebo op-code.
                        if (Serial_Read(Flash_Access, 1, ref I2CWriteBuffer))
                        {
                            statesProcess = ProcessStates.Running;
                            break;
                        }
                        //else
                        //{
                        //    ;
                        //}
                        //}
                        //if (serial_device == 2)
                        //{
                        //if (mcp.Functions.WriteI2cData(smbusaddr, I2CWriteBuffer, 1, SlaveSpeed) == 0)
                        //{
                        //    statesProcess = ProcessStates.Running;
                        //    break;
                        //}
                        //else
                        //{
                        //    mcp.Functions.StopI2cDataTransfer();
                        //}
                        //}
                        break;
                    case ProcessStates.Running:
                        return true;
                }
            }
            else
            {
                statesProcess = ProcessStates.ConfigMCP2221;
                //Make GBox disabled                
            }
            return false;
        }

        private bool Serial_Read(ushort memaddress, byte bytestoread, ref byte[] dataarray)
        {
            bool b;
            int c;


            /* memaddress will come in as 0x00 for Profile-Data (aka the charger_data structure in the FW)
             * or as 0x20 for the charger_settings structure in the FW.  And lastly any address in RAM 
             * can be read.  Such as direct reads of the SFRs. */

            if (initialized != true)
            {
                MessageBox.Show("Serial Device Not Initialized");
                return false;
            }


            switch (serial_device)
            {
                case (1):
                    //b = PICkitS.I2CM.Read(smbusaddr, memaddress, bytestoread, ref dataarray, ref script);
                    b = PICkitS.I2CM.Read(smbusaddr, (byte) ((memaddress >> 8) & 0xFF), (byte) (memaddress & 0xFF), bytestoread, ref dataarray, ref script);
                    if (b == false)
                    {
                        //MessageBox.Show("Could not complete Read.");
                        return false;
                    }
                    break;
                    //%%BRYAN%% above I changed the read command to a two byte address, it needs to be done for the MCP2221 case below as well still.
                case (2):
                    byte[] InBuff = new byte[1];
                    InBuff[0] = (byte)memaddress; //%%BRYAN%% cast it to make it compile after changing above.
                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_I2cWrite(handle, 1, smbusaddr, 0, InBuff);
                    if (c != 0)
                    {
                        MessageBox.Show(string.Format("Could not complete Write to Start Read. {0}", c));
                        return false;
                    }
                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_I2cRead(handle, bytestoread, smbusaddr, 0, dataarray);
                    if (c != 0)
                    {
                        MessageBox.Show(string.Format("Could not complete Read. {0}", c));
                        return false;
                    }
                    break;

                default:
                    //MessageBox.Show("Nothing to Read");
                    return false;
            }

            return true;
        }

        private bool Serial_Write(ushort memaddress, byte bytestowrite, ref byte[] dataarray)
        {
            bool b;
            int c;

            if (initialized != true)
            {
                MessageBox.Show("Serial Device Not Initialized");
                return false;
            }

            switch (serial_device)
            {
                case (1):
                    //b = PICkitS.I2CM.Write(smbusaddr, memaddress, bytestowrite, ref dataarray, ref script);
                    b = PICkitS.I2CM.Write(smbusaddr, (byte)((memaddress >> 8) & 0xFF), (byte)(memaddress & 0xFF), bytestowrite, ref dataarray, ref script);
                    if (b == false)
                    {
                        //MessageBox.Show("Could not complete Write.");
                        return false;
                    }
                    break;
                //%%BRYAN%% above I changed the read command to a two byte address, it needs to be done for the MCP2221 case below as well still.
                case (2):
                    byte[] OutBuff = new byte[dataarray.Length + 1];
                    OutBuff[0] = (byte) memaddress;//%%BRYAN%% cast it to make it compile after changing above.
                    for (int i = 1; i < OutBuff.Length; i++)
                    {
                        OutBuff[i] = dataarray[i - 1];
                    }
                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_I2cWrite(handle, (byte)(bytestowrite + 1), smbusaddr, 0, OutBuff);
                    if (c != 0)
                    {
                        MessageBox.Show(string.Format("Could not complete Write. {0}", c));
                        return false;
                    }
                    break;

                default:
                    //MessageBox.Show("Nothing to Write");
                    return false;
            }

            return true;
        }

        private double ToDouble(string s)
        {
            double d;

            try
            {
                d = Convert.ToDouble(s);
            }
            catch
            {
                d = 0.0;
            }

            return d;
        }

        private bool ChargerCommand(int cmd)
        {
            bool b;
            /*************************************************************************************/
            /* Charger Commands to be put in cmd_charger[0]:                                     */
            /* 0x00 = Off                                                                        */
            /* 0x01 = ON                                                                         */
            /* 0x02 = Force a re-read of config, presumably to follow new variables              */
            /* 0x03 = Disable                                                                    */
            /* 0x07 = Fuel Gauge Mode, LED user interface configuration commands                 */
            /* 0x08 = Status LED Mode                                                            */
            /* 0x09 = Analog Debug Mode                                                          */
            /*************************************************************************************/

            byte[] cmd_charger = new byte[1];

            if (!Init_Serial())
            {
                return false;
            }

            cmd_charger[0] = (byte)cmd;
            b = Serial_Write(Profile_Access, 1, ref cmd_charger);
            Debug.WriteLine(script);

            return b;
        }

        byte LSB(double d)
        {
            return Convert.ToByte((Convert.ToUInt16(d) & 0x00ff));
        }

        byte MSB(double d)
        {
            return Convert.ToByte(((Convert.ToUInt16(d) >> 8) & 0x00ff));
        }

        private bool VerifyFWRev() //This is called in three places.  Start Button, Read_Configuration, and Write_Configuration
        {
            bool b = true;
            int i;

            if (!Init_Serial())
            {
                return false;
            }

            for (i = 0; i < 4; i++)
            {
                configuration_data[i] = 0xff;
            }
            Serial_Read((ushort)(Profile_Access | Settings_Access), 4, ref configuration_data);

            //Debug.WriteLine(script);

            if (b == false)
            {
                MessageBox.Show("Could not read firmware revision from battery charger.");
                SerialClose(handle);
                return false;
            }

            int fwrev = ((ushort)configuration_data[2] | ((ushort)configuration_data[3] << 8));

            if (fwrev > max_firmware_rev)
            {
                b = false;
                MessageBox.Show("The board has newer firmware than this application supports.");
            }
            else if (fwrev < min_firmware_rev)
            {
                b = false;
                MessageBox.Show("The board has older firmware than this application supports.");
            }

            return b;
        }

        #region Code for the register Peak and Poke is here.

        private void buttonPeakSFR_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(textBoxSFRAddress.Text))
            {
                return;
            }
            ushort SFRaddr = Convert.ToUInt16(textBoxSFRAddress.Text, 16);
            byte[] SFRread = new byte[1];
            if (initialized != true)
            {
                if (!Init_Serial())
                {
                    return;
                }
            }
            Serial_Read((ushort)(SFR_Access | SFRaddr), 1, ref SFRread);
            textBoxSFRData.Text = string.Format("0x{0:X2}", SFRread[0]);
        }

        private void buttonPokeSFR_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxSFRAddress.Text))
            {
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxSFRData.Text))
            {
                return;
            }
            ushort SFRaddr = Convert.ToUInt16(textBoxSFRAddress.Text, 16);
            byte[] SFRwrite = new byte[1];
            SFRwrite[0] = (byte)(Convert.ToUInt16(textBoxSFRData.Text, 16));
            if (initialized != true)
            {
                if (!Init_Serial())
                {
                    return;
                }
            }
            Serial_Write((ushort)(SFR_Access | SFRaddr), 1, ref SFRwrite);
        }

        private void buttonPeakFlash_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxFlashAddress.Text))
            {
                return;
            }
            byte[] Flashread = new byte[4];
            ushort FlashAddr = Convert.ToUInt16(textBoxFlashAddress.Text, 16);  // anything but 0x40 (which acts as an opcode to read the temp cal value)
            ushort[] Flashbuffer = new ushort[1];                               // is added to the calibration address ofset of 0x0E60 in the serial stack. 
            if ((FlashAddr & 0x01) == 1)
            {
                FlashAddr--;
                Serial_Read((ushort)(Flash_Access | FlashAddr), 4, ref Flashread);
                Flashbuffer[0] = Flashread[3];
                Flashbuffer[0] <<= 8;
                Flashbuffer[0] |= Flashread[2];
            }
            else
            {
                Serial_Read((ushort)(Flash_Access | FlashAddr), 4, ref Flashread);
                Flashbuffer[0] = Flashread[1];
                Flashbuffer[0] <<= 8;
                Flashbuffer[0] |= Flashread[0];
            }
            if (initialized != true)
            {
                if (!Init_Serial())
                {
                    return;
                }
            }
            Serial_Read((ushort)(Flash_Access | FlashAddr), 4, ref Flashread);
            textBoxFlashData.Text = string.Format("0x{0:X4}",Flashbuffer[0]);
        }

        private void buttonPokeFlash_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxFlashAddress.Text))
            {
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxFlashData.Text))
            {
                return;
            }
            ushort FlashAddr = Convert.ToUInt16(textBoxFlashAddress.Text, 16);
            ushort[] Flashbuffer = new ushort[1];
            byte[] Flashwrite = new byte[64];
            byte[] Flashread = new byte[64];
            int i;
            Serial_Read((ushort)(Flash_Access | (FlashAddr & 0xE0)), 64, ref Flashread);
            for (i = 0; i < 64; i++)
            {
                Flashwrite[i] = Flashread[i];
            }
            Flashbuffer[0] = Convert.ToUInt16(textBoxFlashData.Text, 16);
            Flashwrite[((FlashAddr*2) & 0x3F) +1] = (byte)(Flashbuffer[0] >> 8);
            Flashwrite[((FlashAddr*2) & 0x3F)] = (byte)(Flashbuffer[0] & 0xFF);
            if (initialized != true)
            {
                if (!Init_Serial())
                {
                    return;
                }
            }
            Serial_Write((ushort)(Flash_Access | (FlashAddr & 0xE0)), 64, ref Flashwrite);
            Serial_Read((ushort)(Flash_Access | (FlashAddr & 0xE0)), 64, ref Flashread);
            for (i=0; i<64; i++)
            {
                if (Flashwrite[i] != Flashread[i])
                {
                    i = 64;
                    MessageBox.Show("Error: Verification Read shows unexpected value");
                }
            }
        }
        #endregion

        private void SFR_Drop_Down_SelectedIndexChanged(object sender, EventArgs e)
        {
            //#123
            if ((profile_data[27] == 7) | (profile_data[27] == 1) | (profile_data[27] == 4))
            {
                if (SFR_Drop_Down.Text == "")
                    textBoxSFRAddress.Text = string.Format("");
                if (SFR_Drop_Down.Text == "BUFFCON")
                    textBoxSFRAddress.Text = string.Format("0x108");
                if (SFR_Drop_Down.Text == "PE1")
                    textBoxSFRAddress.Text = string.Format("0x107");
                if (SFR_Drop_Down.Text == "DEADCON")
                    textBoxSFRAddress.Text = string.Format("0x9B");
                if (SFR_Drop_Down.Text == "ABECON")
                    textBoxSFRAddress.Text = string.Format("0x109");
                if (SFR_Drop_Down.Text == "VZCCON")
                    textBoxSFRAddress.Text = string.Format("0x97");
                if (SFR_Drop_Down.Text == "CMPZCON")
                    textBoxSFRAddress.Text = string.Format("0x98");

                if (SFR_Drop_Down.Text == "SLPCRCON")
                    textBoxSFRAddress.Text = string.Format("0x9C");
                if (SFR_Drop_Down.Text == "SLVGNCON")
                    textBoxSFRAddress.Text = string.Format("0x9D");
                if (SFR_Drop_Down.Text == "CSGSCON")
                    textBoxSFRAddress.Text = string.Format("0x93");
                if (SFR_Drop_Down.Text == "CSDGCON")
                    textBoxSFRAddress.Text = string.Format("0x95");
                if (SFR_Drop_Down.Text == "OCCON")
                    textBoxSFRAddress.Text = string.Format("0x91");
                if (SFR_Drop_Down.Text == "OVCCON")
                    textBoxSFRAddress.Text = string.Format("0x19");
                if (SFR_Drop_Down.Text == "OVFCON")
                    textBoxSFRAddress.Text = string.Format("0x1A");
            }
        }
        #endregion
    }
}