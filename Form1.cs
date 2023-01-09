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

#region System Declarations
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
#endregion

namespace MCP19111BatteryChargerGUI
{
    public partial class Form1 : Form
    {
        #region Definitions and Declarations

        #region Serial Communmications Variables, Opcodes, and Offsets
        /*************************************************************************************/
        /* Serial communication declarations                                                 */
        /*************************************************************************************/

        bool    initialized         = false;
        byte    serial_device       = 0;            //Value of 1 is Pickit Serial, 2 is MCP2221A
        IntPtr  handle;                             //Pointer for MCP2221A devices
        byte    smbusaddr           = 0x20;         //%%BRYAN%% make this user selectable, and add a scan routine for the address.
        ushort  Flash_Access        = 0x8000;
        ushort SFR_Access           = 0x4000;
        ushort  Profile_Access      = 0x0000;
        ushort  Settings_Access     = 0xC000;
        ushort  Flash_Config_Offset = 0x0020;
        #endregion

        #region Run time arrays for polling data as well as settings for firmware level allowed
        /*************************************************************************************/
        /* Variable Definitions Below                                                        */
        /*************************************************************************************/

        short  max_firmware_rev     = 0x0499;    // Update this to reflect support for new firmware revesions
        short  min_firmware_rev     = 0x0460;    // Update this to reflect support for new firmware revisions
        bool   profilerunning       = false;
        bool   calibrating          = false;
        int    last_charge_time;
        byte   tot_num_chems        = 5;        // Set the total number of chemistries coded in the GUI
        byte[] profile_data         = new byte[63]; 
        /* This corresponds to the charger_data_t struct     */
                                                    /* in the firmware and contains the charger_status_t */
                                                    /* and eoc_charger_status_t struct.                  */
        string script = "";
        #region Default Header File Script
        string[] default_values_line_titles = {
        "// 0 uvlo_threshold_off;      // SFR Setting - UVLO off threshold",
        "// 2 uvlo_threshold_on;       // SFR Setting - UVLO on threshold",
        "// 4 vbat_ov;                 // ADC Value - Output overvoltage shutdown threshold",
        "// 6 vbat_pc;                 // ADC Value - Battery voltage PRE to CC",
        "// 8 vbat_cv;                 // ADC Value - Battery voltage CC to CV",
        "// 10 ibat_pc;                // ADC Value - Preconditioning battery current",
        "// 12 ibat_cc;                // ADC Value - Charge current",
        "// 14 ibat_ct;                // ADC Value - Charge termination current",
        "// 16 ovcfcon_min;            // SFR Comparison - Minimum setting for output DAC",
        "// 18 ovcfcon_max;            // SFR Comparison - Maximum setting for output DAC",
        "// 20 uvlo_adc_threshold_off; // ADC Value - Input UV threshold for turn off (ADC)",
        "// 22 uvlo_adc_threshold_on;  // ADC Value - Input UV threshold to allow turn-on (ADC)",
        "// 24 restore_time_max;       // Counter Value & TextBox - RESTORE charge maximum time (in seconds, the GUI displays minutes)",
        "// 26 dvdt_blank_time;        // Counter Value & TextBox - dV/dt blank time (in seconds, the GUI displays minutes)",
        "// 28 rapid_time_max;         // Counter Value & TextBox - RAPID charge maximum time (in seconds, the GUI displays minutes)",
        "// 30 dtdt_slope;             // ADC Value - dt/dt negative delta_t ADC change to terminate charge",
        "// 32 pack_temp_min;          // ADC Value - Minimum pack temperature threshold",
        "// 34 pack_temp_max;          // ADC Value - Maximum pack temperature threshold",
        "// 36 chemistry;              // Constant & TextBox - Chemistry (0 = Li-Ion, 1 = NiMH, 2 = VRLA CCCP, 3 = VRLA Fast, 4 = LiFePO4)",
        "// 38 ovrefcon_ov;            // SFR Setting - MCP19125 specific - OVREFCON_OV sets the reference for OV comparator when enabled",
        "// 40 ovrefcon_cv;            // SFR Setting - MCP19125 specific - OVREFCON_CV sets the reference for EA1 when enabled",
        "// 42 vrefcon_max;            // SFR Setting - MCP19125 specific - Maximum value allowed for VREFCON - Basically max output current",
        "// 44 vbat_fv;                // ADC Value - Battery voltage for float",
        "// 46 neg_dvdt;               // Constant & TextBox - Threshold for Negative dV/dt",
        "// 48 pos_dvdt_cc;            // Constant & TextBox - Threshold for Positive dV/dt in CC mode",
        "// 50 neg_didt_cv;            // Constant & TextBox - Threshold for Negative dI/dt in CV mode",
        "// 52 pack_temp_25C;          // ADC Value - The calculated value for a 25C reading for reference",
        "// 54 temp_1C;                // ADC Value - Represents the number of counts for a calculated 1C change",
        "// 56 temp_sense_en;          // Constant & TextBox - Is temperature Enabled",
        "// 58 ibat_fc;                // ADC Value - Maximum allowed Float Current",
        "// 60 precondition_max_time   // Counter Value & TextBox - Maximum time charger will try to restore/precondition a battery",
        "// 62 pc_dvdt                 // Constant & TextBox - Threshold for Positive dV/dt in PC mode",
        "// 64 vbat_1C_adjust          // ADC Value - The adjustment to float voltage for every 1C change from 25C",
        "// 66 charge_time_max;        // Counter Value & TextBox - Low Byte Maximum total charge time (in seconds, the GUI displays in minutes)",
        "// 68 charge_time_max;        // Counter Value & TextBox - High Byte Maximum charge time before shut-off",
        "// 70",
        "// 72",
        "// 74",
        "// 76 cell voltage            // TextBox",
        "// 78 # of Cells              // TextBox",
        "// 80 Precondition Voltage    // TextBox",
        "// 82 Precondition Current    // TextBox",
        "// 84 Charge Current          // TextBox",
        "// 86 Termination Current     // TextBox",
        "// 88 ADC Vref                // TextBox",
        "// 90 ADC Size                // TextBox",
        "// 92 Temp Slope V/C          // TextBox",
        "// 94 Minimum Temperature     // TextBox",
        "// 96 Maximum Temperautre     // TextBox",
        "// 98 Termination Voltage     // TextBox",
        "// 100 Wire Resistance in Ohms // TextBox",
        "// 102 Float Voltage           // TextBox",
        "// 104 Over Voltage            // TextBox",
        "// 106 dtdt Slope              // TextBox",
        "// 108 UVLO Rising             // TextBox",
        "// 110 UVLO Falling            // TextBox",
        "// 112 Maximum Float Current   // TextBox",
        "// 114",
        "// 116",
        "// 118",
        "// 120",
        "// 122",
        "// 124",
        "// 126"};
        #endregion

        #endregion

        #region Configuration Variables cf_*
        /*************************************************************************************/
        /* Configuration information that the charger firmware uses for operation            */
        /*************************************************************************************/
        byte[] configuration_data = new byte[128];
        byte[] configuration_data_offset = new byte[128];
        byte[] verification_data  = new byte[128];   
        ushort cf_vbat_ov;                          // Output overvoltage shutdown threshold
        ushort cf_vbat_pc;                          // Battery voltage PRE to CC
        ushort cf_vbat_cv;                          // Battery voltage CC to CV
        ushort cf_ibat_pc;                          // Preconditioning battery current
        ushort cf_ibat_cc;                          // Charge current
        ushort cf_ibat_ct;                          // Charge termination current
        ushort cf_ibat_fc;                          // Maximum allowed float current
        ushort cf_charge_time_max;                  // Maximum charge time before shut-off
        byte   cf_uvlo_threshold_off;               // Input UV threshold for turn off
        byte   cf_uvlo_threshold_on;                // Input UV threshold to allow turn-on (NOT USED)
        byte   cf_ovcfcon_min;                      // Minimum setting for output DAC
        ushort cf_ovcfcon_max;                      // Maximum setting for output DAC
        ushort cf_adc_uvlo_threshold_off;           // Input UV threshold for turn off (ADC)
        ushort cf_adc_uvlo_threshold_on;            // Input UV threshold to allow turn-on (ADC)
        ushort cf_restore_time_max;                 // RESTORE charge maximum time
        ushort cf_dvdt_blank_time;                  // dV/dt blank time
        ushort cf_rapid_time_max;                   // RAPID charge maximum time
        short  cf_dtdt_slope;                       // dT/dt slope to terminate charge
        ushort cf_pack_temp_min;                    // Minimum pack temperature
        ushort cf_pack_temp_max;                    // Maximum pack temperature
        byte   cf_chemistry;                        // Chemistry (0 = Li-Ion, 1 = NiMH, 2 = VRLA CCCP, 3 = VRLA Fast, 4 = LiFePO4)
        ushort cf_ovrefcon_ov;                      // MCP19125 specific, Reference for OV Comparator when enabled
        ushort cf_ovrefcon_cv;                      // MCP19125 specific, Reference for EA1 when enabled
        ushort cf_vrefcon_max;                      // MCP19125 specific, Maximum VREFCON value. Basically a max current setting
        ushort cf_vbat_fv;                          // Battery voltage in the VRLA float state
        short  cf_neg_dvdt;                         // Threshold for Negative dV/dt
        ushort cf_pos_dvdt_cc;                      // Threshold for Positive dV/dt in CC mode
        short  cf_neg_didt_cv;                      // Threshold for Positive dV/dt in CV mode
        byte   cf_temp_sense_en;                    // Flag for whether a temp sensor is present
        ushort cf_precondition_time_max;            // Maximum time spent in precondition before timeout
        ushort cf_dvdt_pc;                          // Threshold for minimum positive dV/dt in PC mode
        ushort cf_pack_temp_25C;
        ushort cf_temp_1C;
        ushort cf_vbat_1C_adjust;
        #endregion

        #region Local copies of the configuration variables st_*
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
        //The below value is set so that the first call of UpdateSettings will force a pre-population of the d_st_#### variables and TextBoxes
        ushort st_chemistry = 0xFF; 
        ushort st_precondition_voltage;
        ushort st_precondition_current;
        ushort st_charge_current;
        ushort st_termination_current;
        ushort st_maximum_charge_time;
        ushort st_rapid_time_max;
        ushort st_restore_time_max;
        short  st_minimum_temperature;
        short  st_maximum_temperature;
        ushort st_termination_voltage;
        ushort st_UVLO_rising_voltage;
        ushort st_UVLO_falling_voltage;
        ushort st_wire_resistance;
        ushort st_float_voltage;
        ushort st_float_current;
        ushort st_over_voltage;
        short  st_negative_dvdt_count;
        ushort st_cc_positive_dvdt_count;
        short  st_cv_negative_didt_count;
        ushort st_dvdt_blank_time;
        short  st_dtdt_slope;
        ushort st_temperature_cal_ADC_vref;
        ushort st_temperature_cal_ADC_size;
        ushort st_temperature_cal_slope;
        ushort st_precondition_time_max;
        ushort st_dvdt_pc_count;
        #endregion

        #region Calibration Arrays
        /*************************************************************************************/
        /* Calibration Data                                                                  */
        /*************************************************************************************/

        byte[]   cal_data       = new byte[64];
        double[] ibatslope      = new double[4];
        double[] ibatintercept  = new double[4];
        double[] vinslope       = new double[4];
        double[] vinintercept   = new double[4];
        double[] vbatslope      = new double[4];
        double[] vbatintercept  = new double[4];
        double[] ibat           = new double[3];
        double[] vin            = new double[3];
        double[] vbat           = new double[3];
        double[] irange         = new double[3];
        double[] vinrange       = new double[3];
        double[] vbatrange      = new double[3];
        #endregion

        #region Temperature Calibration Values 
        double temperature_cal;
        double temperature_cal_celsius;
        double temperature_adc_slope; //this value is the conversion factor (slope) for temperature to an ADC value used for the Configuration Calculations
        #endregion

        #endregion

        #region GUI Control
        /*************************************************************************************/
        /* Below are the main functions for handling the GUI                                 */
        /*************************************************************************************/
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
             switch (serial_device)
             {
                case (1):
                    {
                        SerialClose(handle);
                        break;
                    }
                case (2):
                    {
                        mcp2221_dll_m.MCP2221.M_Mcp2221_I2cCancelCurrentTransfer(handle);
                        mcp2221_dll_m.MCP2221.M_Mcp2221_Reset(handle);
                        mcp2221_dll_m.MCP2221.M_Mcp2221_CloseAll();
                        break;
                    }
                default:
                    {
                        /*if (string.Equals((sender as Button).Name, @"CloseButton"))
                        { }
                        // Do something proper to CloseButton.
                        else
                        { }
                        // Then assume that X has been clicked and act accordingly.*/
                        break;
                    }
              }
        }

        public Form1()
        {
            InitializeComponent();

            comboBoxNumberOfCells.Items.Add("1");
            comboBoxNumberOfCells.Items.Add("2");
            comboBoxNumberOfCells.Items.Add("3");
            comboBoxNumberOfCells.Items.Add("4");
            comboBoxNumberOfCells.Items.Add("5");
            comboBoxNumberOfCells.Items.Add("6");
            comboBoxNumberOfCells.SelectedIndex = 0;
             
            comboBoxChemistry.Items.Add("Li-Ion");
            comboBoxChemistry.Items.Add("NiMH");
            comboBoxChemistry.Items.Add("VRLA CCCP");
            comboBoxChemistry.Items.Add("VRLA Fast");
            comboBoxChemistry.Items.Add("LiFePO4");
            comboBoxChemistry.Items.Add("Super Capacitor");
            //comboBoxChemistry.SelectedIndex = 0;

            comboBoxPCBType.Items.Add("MCP19111 Charger Reference");
            comboBoxPCBType.Items.Add("PIC16F1716 + MCP1631 SEPIC");
            comboBoxPCBType.Items.Add("PIC16F886 + MCP1631 SEPIC");
            comboBoxPCBType.Items.Add("MCP19118 4-Switch Buck-Boost");
            comboBoxPCBType.Items.Add("MCP19123 Buck-Boost Reference");
            comboBoxPCBType.Items.Add("MCP19125 ADM00745 Charger EVK");
            comboBoxPCBType.Items.Add("MCP19119 4A Charger");
            comboBoxPCBType.Items.Add("PIC16F1779 Hybrid CIP Starter Kit");
            comboBoxPCBType.Items.Add("PIC16F1769 MPPT Solar");
            //comboBoxPCBType.SelectedIndex = 0;

            buttonProfileStart.Enabled = true;
            //The Enabled button below is set to true so the option to stop the charger is never grayed out for safety purposes.
            buttonProfileStop.Enabled = true;
            buttonSaveData.Enabled = true;

            labelProfileChargerOutputVoltage.Text   = "";
            labelProfileChargerOutputVoltageLive.Text = "";
            labelProfilePackVoltage.Text            = "";
            labelProfilePackVoltageLive.Text        = "";
            labelProfilePackCurrent.Text            = "";
            labelProfilePackCurrentLive.Text        = "";
            labelProfileInputVoltage.Text           = "";
            labelProfileInputVoltageLive.Text       = "";
            labelProfileChargerState.Text           = "Not Connected";
            labelProfileChargerStateLive.Text       = "Not Connected";
            labelProfileChargeTime.Text             = "";
            labelChargeTimeLive.Text                = "";
            labelChargerStatus.Text                 = "";
            labelChargerStatusLive.Text             = "";
            labelPackTemperatureRead.Text           = "";
            labelPackTemperatureReadLive.Text       = "";
            labeldtemp_dtLive.Text                  = "";
            labeldTdtCountLive.Text                 = "";
            labelRestoreTimerLive.Text              = "";
            labelRapidChargeTimerLive.Text          = "";
            labelPreconditionTimerLive.Text         = "";
        }

         #region Code for directing any user input changes from Chemistry, PCB Type, Thermistor Checked
        private void handlerSelectedIndexChanged(object sender, EventArgs e)  //This is the main handling function for moving between GUI tabs
        {
            if (tabControl1.SelectedTab == tabPageConfigure)
            {
                if ((profilerunning == true) || (calibrating == true))
                {
                    panelConfigurationControl.Enabled = false;
                    panelSystemSettings.Enabled = false;
                    panelBasicSettings.Enabled = false;
                    panelVRLANiMH.Enabled = false;
                    panelAdvancedUser.Enabled = false;
                    panelTempSettings.Enabled = false;
                }
                else
                {
                    panelConfigurationControl.Enabled = true;
                    panelSystemSettings.Enabled = true;
                    panelBasicSettings.Enabled = true;
                    checkBoxThermistor_CheckedChanged(sender, e);
                    switch (comboBoxChemistry.Text)
                    {
                        case ("Li-Ion"):
                            panelVRLANiMH.Enabled = false;
                            panelAdvancedUser.Enabled = false;
                            labelTermination.Text = "Termination Current";
                            break;
                        case ("NiMH"):
                            panelVRLANiMH.Enabled = true;
                            panelAdvancedUser.Enabled = true;
                            labelTermination.Text = "Trickle Current";
                            break;
                        case ("VRLA CCCP"):
                            panelVRLANiMH.Enabled = false;
                            panelAdvancedUser.Enabled = false;
                            labelTermination.Text = "Termination Current";
                            break;
                        case ("VRLA Fast"):
                            panelVRLANiMH.Enabled = true;
                            panelAdvancedUser.Enabled = true;
                            labelTermination.Text = "Trickle Current";
                            break;
                        case ("LiFePO4"):
                            panelVRLANiMH.Enabled = false;
                            panelAdvancedUser.Enabled = false;
                            labelTermination.Text = "Termination Current";
                            break;
                        case ("Super Capacitor"):
                            panelVRLANiMH.Enabled = false;
                            panelAdvancedUser.Enabled = false;
                            labelTermination.Text = "Termination Current";
                            break;
                        default:
                            panelVRLANiMH.Enabled = true;
                            panelAdvancedUser.Enabled = true;
                            labelTermination.Text = "Termination Current";
                            break;
                    }
                }
            }

            if (tabControl1.SelectedTab == tabPageProfile)
            {
                if (profilerunning == true)
                {
                    buttonProfileStart.Enabled = false;
                    //Stop Button below set to true to always give the option to stop the charger for safety in case of a manual start.
                    buttonProfileStop.Enabled = true;
                }
                else
                {
                    buttonProfileStart.Enabled = !calibrating;
                    //Stop Button below set to true to always give the option to stop the charger for safety in case of a manual start.
                    buttonProfileStop.Enabled = true;
                }
            }

            if (tabControl1.SelectedTab == tabPageCalibrate)
            {
                if (profilerunning == true)
                {
                    panelCalibrationStuff.Enabled = false;
                    buttonReadCalibration.Enabled = false;
                    buttonBeginCalibration.Enabled = false;
                    buttonWriteCalibration.Enabled = false;
                }
                else
                {
                    buttonBeginCalibration.Enabled = true;
                    if (calibrating)
                    {
                        panelCalibrationStuff.Enabled = true;
                        buttonReadCalibration.Enabled = false;
                        buttonWriteCalibration.Enabled = true;
                    }
                    else
                    {
                        panelCalibrationStuff.Enabled = false;
                        buttonReadCalibration.Enabled = true;
                        buttonWriteCalibration.Enabled = false;
                    }
                }
            }
        }

        private void comboBoxChemistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSettingsTab();
            checkBoxThermistor_CheckedChanged(sender, e);
        } 

        private void comboBoxPCBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Assign the correct value to the profile_data[27] based on the comboBoxPCBType
            if (comboBoxPCBType.Text == "MCP19111 Charger Reference")
            {
                profile_data[27] = 1;
            }
            else if (comboBoxPCBType.Text == "PIC16F1716 + MCP1631 SEPIC")
            {
                profile_data[27] = 2;
            }
            else if (comboBoxPCBType.Text == "PIC16F886 + MCP1631 SEPIC")
            {
                profile_data[27] = 3;
            }
            else if (comboBoxPCBType.Text == "MCP19118 4-Switch Buck-Boost")
            {
                profile_data[27] = 4;
            }
            else if (comboBoxPCBType.Text == "MCP19123 Buck-Boost Reference")
            {
                profile_data[27] = 5;
            }
            else if (comboBoxPCBType.Text == "MCP19125 ADM00745 Charger EVK")
            {
                profile_data[27] = 6;
            }
            else if (comboBoxPCBType.Text == "MCP19119 4A Charger")
            {
                profile_data[27] = 7;
            }
            else if (comboBoxPCBType.Text == "PIC16F1779 Hybrid CIP Starter Kit")
            {
                profile_data[27] = 10;
            }
            else if (comboBoxPCBType.Text == "PIC16F1769 MPPT Solar")
            {
                profile_data[27] = 11;
            }
            else
            {
                return;
            }
            #endregion
            UpdateSettingsTab();
            checkBoxThermistor_CheckedChanged(sender, e);
        }

        private void checkBoxThermistor_CheckedChanged(object sender, EventArgs e)  // Called by changes to battery chemistry or PCB type selections
        {
            if (checkBoxThermistor.CheckState == CheckState.Checked) 
            {
                panelTempSettings.Enabled = true;
            }
            else
            {
                panelTempSettings.Enabled = false;
            }
        }
        #endregion

        #region UpdateSettingTab() is a major routine for handling all of the GUI refresh when anything is changed
        private void UpdateSettingsTab()  // Called by changes to Battery Chemistry or PCB Type or a ReadConfiguration()
        {
            int chemistry;

            #region read the Chemistry comboBox and assign the proper value to the chemistry variable
            if (comboBoxChemistry.Text == "Li-Ion")
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
            #endregion

            #region SFR Drop Down Box Auto-Fill in the Peak-Poke Section
            SFR_Drop_Down.Items.Clear();
            if ((profile_data[27] == 1) | (profile_data[27] == 4) | (profile_data[27] == 7)) //MCP19111 derivatives with the same register map
            {
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
            if (profile_data[27] == 1)
            {
                labelProfilePCBtype.Text = "MCP19111 Charger Reference";
                comboBoxPCBType.Text = string.Format("MCP19111 Charger Reference");
            }
            if (profile_data[27] == 2)
            {
                labelProfilePCBtype.Text = "PIC16F1716 + MCP1631 SEPIC";
                comboBoxPCBType.Text = string.Format("PIC16F1716 + MCP1631 SEPIC");
            }
            if (profile_data[27] == 3)
            {
                labelProfilePCBtype.Text = "PIC16F886 + MCP1631 SEPIC";
                comboBoxPCBType.Text = string.Format("PIC16F886 + MCP1631 SEPIC");
            }
            if (profile_data[27] == 4)
            {
                labelProfilePCBtype.Text = "MCP19118 4-Switch Buck-Boost";
                comboBoxPCBType.Text = string.Format("MCP19118 4-Switch Buck-Boost");
            }
            if (profile_data[27] == 5)
            {
                labelProfilePCBtype.Text = "MCP19123 Buck-Boost Reference";
                comboBoxPCBType.Text = string.Format("MCP19123 Buck-Boost Reference");
            }
            if (profile_data[27] == 6)
            {
                labelProfilePCBtype.Text = "MCP19125 ADM00745 Charger EVK";
                comboBoxPCBType.Text = string.Format("MCP19125 ADM00745 Charger EVK");
            }
            if (profile_data[27] == 7)
            {
                labelProfilePCBtype.Text = "MCP19119 4A Charger";
                comboBoxPCBType.Text = string.Format("MCP19119 4A Charger");
            }
            if (profile_data[27] == 10)
            {
                labelProfilePCBtype.Text = "PIC16F1779 Hybrid CIP Starter Kit";
                comboBoxPCBType.Text = string.Format("PIC16F1779 Hybrid CIP Starter Kit");
            }
            if (profile_data[27] == 11)
            {
                labelProfilePCBtype.Text = "PIC16F1769 MPPT Solar";
                comboBoxPCBType.Text = string.Format("PIC16F1769 MPPT Solar");
            }
            #endregion

            #region Declarations of the d_st_# variables for configuration
            // Declarations below will have some default values that can be changed in the chemistryt specific sections if needed
            string Chemistry                	= comboBoxChemistry.Text;
			double d_st_cell_voltage            = 0;
            double d_st_number_of_cells         = 0;
            double d_st_precondition_voltage    = 0;
            double d_st_precondition_current    = 0;
            double d_st_charge_current          = 0;
            double d_st_termination_current     = 0;
            double d_st_termination_voltage     = 0;
            double d_st_maximum_charge_time     = 0;
            double d_st_rapid_time_max          = 0;
            double d_st_restore_time_max        = 0;
            double d_st_minimum_temperature     = 0;
            double d_st_maximum_temperature     = 60;
            double d_st_UVLO_rising_voltage     = 10;
            double d_st_UVLO_falling_voltage    = 8;
            double d_st_wire_resistance         = 0.100;
            double d_st_float_voltage           = 0;
            double d_st_float_current           = 0;
            double d_st_over_voltage            = 0;
            double d_st_negative_dvdt_count     = -2;
            double d_st_cc_positive_dvdt_count  = 6;
            double d_st_cv_negative_didt_count  = 4;
            double d_st_dvdt_blank_time         = 2.5;
            double d_st_dtdt_slope              = 1.5;
            double d_st_temperature_cal_ADC_vref = 5.0;
            double d_st_temperature_cal_slope    = 0.01;
            double d_st_temperature_cal_ADC_size = 10;
            double d_st_precondition_time_max    = 0;
            double d_st_pc_dvdt_count            = 10;

            #endregion

            #region Check to see if a configuration has been loaded, else load default values for configuration tab
            /* Is this a current setting? Then leave everything alone based on the (presumably) already read configuration from Flash. */
            if (chemistry == st_chemistry)
            {
                d_st_cell_voltage               = Convert.ToDouble(st_cell_voltage)           / 1000;
                d_st_number_of_cells            = Convert.ToDouble(st_number_of_cells);
                d_st_precondition_voltage       = Convert.ToDouble(st_precondition_voltage)   / 1000;
                d_st_precondition_current       = Convert.ToDouble(st_precondition_current)   / 1000;
                d_st_charge_current             = Convert.ToDouble(st_charge_current)         / 1000;
                d_st_termination_current        = Convert.ToDouble(st_termination_current)    / 1000;
                d_st_termination_voltage        = Convert.ToDouble(st_termination_voltage)    / 1000;
                d_st_maximum_charge_time        = Convert.ToDouble(st_maximum_charge_time)    / 60;
                d_st_rapid_time_max             = Convert.ToDouble(st_rapid_time_max)         / 60;
                d_st_restore_time_max           = Convert.ToDouble(st_restore_time_max)       / 60;
                d_st_minimum_temperature        = Convert.ToDouble(st_minimum_temperature);
                d_st_maximum_temperature        = Convert.ToDouble(st_maximum_temperature);
                d_st_wire_resistance            = Convert.ToDouble(st_wire_resistance);
                d_st_UVLO_falling_voltage       = Convert.ToDouble(st_UVLO_falling_voltage)   / 1000; 
                d_st_UVLO_rising_voltage        = Convert.ToDouble(st_UVLO_rising_voltage)    / 1000;
                d_st_float_voltage              = Convert.ToDouble(st_float_voltage)          / 1000;
                d_st_float_current              = Convert.ToDouble(st_float_current)          / 1000;
                d_st_over_voltage               = Convert.ToDouble(st_over_voltage)           / 1000;
                d_st_negative_dvdt_count        = Convert.ToDouble(st_negative_dvdt_count);
                d_st_cc_positive_dvdt_count     = Convert.ToDouble(st_cc_positive_dvdt_count);
                d_st_cv_negative_didt_count     = Convert.ToDouble(st_cv_negative_didt_count);
                d_st_dvdt_blank_time            = Convert.ToDouble(st_dvdt_blank_time)          / 60;
                d_st_dtdt_slope                 = Convert.ToDouble(st_dtdt_slope)               / 100;
                d_st_temperature_cal_ADC_vref   = Convert.ToDouble(st_temperature_cal_ADC_vref) / 100;
                d_st_temperature_cal_slope      = Convert.ToDouble(st_temperature_cal_slope)    / 1000;
                d_st_temperature_cal_ADC_size   = Convert.ToDouble(st_temperature_cal_ADC_size);
                d_st_precondition_time_max      = Convert.ToDouble(st_precondition_time_max)    / 60;
                d_st_pc_dvdt_count              = Convert.ToDouble(st_dvdt_pc_count);
            }   
            /* If not then put in some default values for the chemistry selected. */
            else
            {
                if (Chemistry == "Li-Ion") /* Li-Ion */
                {
                    d_st_cell_voltage = 3.7;
                    d_st_number_of_cells = 2;
                    d_st_precondition_voltage = 3.0;
                    d_st_precondition_current = 0.100;
                    d_st_charge_current = 1.00;
                    d_st_termination_current = 0.100;
                    d_st_termination_voltage = 4.2;
                    d_st_maximum_charge_time = 90; //minutes
                    d_st_float_voltage = 4.2;
                    d_st_float_current = 0.1;
                    d_st_over_voltage = 4.3;
                    d_st_precondition_time_max = 60; //minutes
                    checkBoxThermistor.CheckState = CheckState.Unchecked;
                }
                else if (Chemistry == "NiMH") /* NiMH */
                {
                    d_st_cell_voltage = 1.2;
                    d_st_number_of_cells = 7;
                    d_st_precondition_voltage = 0.8;
                    d_st_precondition_current = 0.100;
                    d_st_charge_current = 1.00;
                    d_st_termination_current = 0;
                    d_st_termination_voltage = 0;
                    d_st_maximum_charge_time = 300; //minutes
                    d_st_rapid_time_max = 90; //minutes
                    d_st_restore_time_max = 60; //minutes
                    d_st_minimum_temperature = 0;
                    d_st_maximum_temperature = 50;
                    d_st_float_voltage = 0;
                    d_st_float_current = 0;
                    d_st_over_voltage = 1.7;
                    d_st_dvdt_blank_time = 2; //minutes
                    checkBoxThermistor.CheckState = CheckState.Checked;
                    d_st_temperature_cal_ADC_size = 10;
                    d_st_temperature_cal_ADC_vref = 5.0;
                    d_st_temperature_cal_slope = 0.040;
                    d_st_precondition_time_max = 60; //minutes
                }
                else if (Chemistry == "VRLA CCCP") /* VRLA CCCP */
                {
                    d_st_cell_voltage = 2.0;
                    d_st_number_of_cells = 3;
                    d_st_precondition_voltage = 1.8;
                    d_st_precondition_current = 0.20;   
                    d_st_charge_current = 1.800;            
                    d_st_termination_current = 0.200;       
                    d_st_termination_voltage = 2.40;
                    d_st_maximum_charge_time = 480; //minutes
                    d_st_float_voltage = 2.35;
                    d_st_float_current = 0.2;
                    d_st_over_voltage = 2.5;
                    d_st_dvdt_blank_time = 2.5; //minutes
                    checkBoxThermistor.CheckState = CheckState.Unchecked;
                    d_st_precondition_time_max = 60; //minutes
                }
                else if (Chemistry == "VRLA Fast") /* VRLA Fast */ 
                {
                    d_st_cell_voltage = 2.0;
                    d_st_number_of_cells = 3;
                    d_st_precondition_voltage = 1.8;    
                    d_st_precondition_current = 0.20;   
                    d_st_charge_current = 1.800;            
                    d_st_termination_current = 0.500;       
                    d_st_termination_voltage = 2.4;        
                    d_st_maximum_charge_time = 600; //minutes
                    d_st_rapid_time_max = 120; //minutes
                    d_st_restore_time_max = 60; //minutes
                    d_st_float_voltage = 2.35;
                    d_st_float_current = 0.2;
                    d_st_over_voltage = 2.5;
                    d_st_dvdt_blank_time = 2.5; //minutes
                    checkBoxThermistor.CheckState = CheckState.Unchecked;
                    d_st_precondition_time_max = 60; //minutes
                }
                else if (Chemistry == "LiFePO4") /* LiFePO4 */
                {
                    d_st_cell_voltage = 3.7;
                    d_st_number_of_cells = 1;
                    d_st_precondition_voltage = 1.7;
                    d_st_precondition_current = 0.100;
                    d_st_charge_current = 1.00;
                    d_st_termination_current = 0.100;
                    d_st_termination_voltage = 3.80;
                    d_st_maximum_charge_time = 180; //minutes
                    d_st_float_voltage = 3.8;
                    d_st_float_current = 0.1;
                    d_st_over_voltage = 3.9;
                    d_st_precondition_time_max = 60; //minutes
                    checkBoxThermistor.CheckState = CheckState.Unchecked;
                }
                else if (Chemistry == "Super Capacitor") /* Super Capacitor */
                {
                    d_st_cell_voltage = 2.7;
                    d_st_number_of_cells = 2;
                    d_st_precondition_voltage = 0.1;
                    d_st_precondition_current = 0.1;
                    d_st_charge_current = 1.00;
                    d_st_termination_current = 0.100;
                    d_st_termination_voltage = 2.5;
                    d_st_maximum_charge_time = 180; //minutes
                    d_st_float_voltage = 2.5;
                    d_st_float_current = 0.1;
                    d_st_over_voltage = 2.7;
                    d_st_precondition_time_max = 60; //minutes
                    checkBoxThermistor.CheckState = CheckState.Unchecked;
                }

            }
            #endregion

            temperature_adc_slope = (d_st_temperature_cal_slope) / (d_st_temperature_cal_ADC_vref / ((1 << ((ushort)d_st_temperature_cal_ADC_size + 2)) - 1)); // +2 because the firmware oversamples 16x, then >> 2.
            if (chemistry == 1)
            {
                temperature_adc_slope = -1 * temperature_adc_slope;
            }

            #region Manage the active text boxes in configuration tab based on Chemistry
            panelConfigurationControl.Enabled = true;
            panelSystemSettings.Enabled = true;
            panelBasicSettings.Enabled = true;

            if (Chemistry == "Li-Ion") /* Li-Ion */
            {
                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");
                comboBoxNumberOfCells.Items.Add("6");

                panelVRLANiMH.Enabled = false;
                panelAdvancedUser.Enabled = false;
                labelRestorationTime.Enabled = false;
                textBoxRestorationChargeTime.Enabled = false;
                labelRestorationChargeTimeUnits.Enabled = false;
                labelTermination.Text = "Termination Current";
            }
            else if (Chemistry == "NiMH") /* NiMH */
            {
                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");
                comboBoxNumberOfCells.Items.Add("6");
                comboBoxNumberOfCells.Items.Add("7");
                comboBoxNumberOfCells.Items.Add("8");
                comboBoxNumberOfCells.Items.Add("9");
                comboBoxNumberOfCells.Items.Add("10");
                comboBoxNumberOfCells.Items.Add("11");
                comboBoxNumberOfCells.Items.Add("12");

                panelVRLANiMH.Enabled = true;
                panelAdvancedUser.Enabled = true;
                labelRestorationTime.Enabled = false;
                //textBoxRestorationChargeTime.Enabled = false;
                labelRestorationChargeTimeUnits.Enabled = false;
                labelTermination.Text = "Trickle Current";
                textBoxCCPositivedVdtCount.Enabled = false;
                textBoxCCPositivedVdtCount.Text = "0";
                textBoxCVNegativedIdtCount.Enabled = false;
                textBoxCVNegativedIdtCount.Text = "0";
                textBoxTempCoeff.Enabled = false;
                textBoxTempCoeff.Text = "0";
                textBoxRestorationChargeTime.Enabled = true;
                textBoxRestorationChargeTime.Text = "30";
                textBoxFloatVoltage.Enabled = false;
                textBoxFloatVoltage.Text = "0";
                textBoxTerminationCurrent.Enabled = false;
                textBoxTerminationCurrent.Text = "0";
                textBoxTerminationVoltage.Enabled = true;
                textBoxTerminationVoltage.Text = "1.35";
                textBoxFloatCurrent.Enabled = false;
                textBoxFloatCurrent.Text = "0";
                textBoxPreConditionTime.Text = "10";
            }
            else if (Chemistry == "VRLA CCCP") /* VRLA CCCP */
            {
                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");
                comboBoxNumberOfCells.Items.Add("6");

                panelVRLANiMH.Enabled = false;
                panelAdvancedUser.Enabled = false;
                labelRestorationTime.Enabled = false;
                textBoxRestorationChargeTime.Enabled = false;
                labelRestorationChargeTimeUnits.Enabled = false;
                labelTermination.Text = "Termination Current";
            }
            else if (Chemistry == "VRLA Fast") /* VRLA Fast */
            {
                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");
                comboBoxNumberOfCells.Items.Add("6");

                panelVRLANiMH.Enabled = true;
                panelAdvancedUser.Enabled = true;
                labelRestorationTime.Enabled = true;
                textBoxRestorationChargeTime.Enabled = true;
                labelRestorationChargeTimeUnits.Enabled = true;
                labelTermination.Text = "Trickle Current";
            }
            else if (Chemistry == "LiFePO4") /* LiFePO4 */
            {

                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");
                comboBoxNumberOfCells.Items.Add("6");

                panelVRLANiMH.Enabled = false;
                panelAdvancedUser.Enabled = false;
                labelRestorationTime.Enabled = false;
                textBoxRestorationChargeTime.Enabled = false;
                labelRestorationChargeTimeUnits.Enabled = false;
                labelTermination.Text = "Termination Current";
            }
            else if (Chemistry == "Super Capacitor") /* Super Capacitor */
                {
                comboBoxNumberOfCells.Items.Clear();
                comboBoxNumberOfCells.Items.Add("1");
                comboBoxNumberOfCells.Items.Add("2");
                comboBoxNumberOfCells.Items.Add("3");
                comboBoxNumberOfCells.Items.Add("4");
                comboBoxNumberOfCells.Items.Add("5");

                panelVRLANiMH.Enabled = false;
                panelAdvancedUser.Enabled = false;
                labelRestorationTime.Enabled = false;
                textBoxRestorationChargeTime.Enabled = false;
                labelRestorationChargeTimeUnits.Enabled = false;
                labelTermination.Text = "Termination Current";
            }
            #endregion

            #region Stuff the textBox's in the Configuration tab with the current data

            textBoxCellVoltage.Text             = string.Format("{0:F3}", d_st_cell_voltage);
            comboBoxNumberOfCells.Text          = string.Format("{0:F0}", d_st_number_of_cells);
            textBoxPreconditionCellVoltage.Text = string.Format("{0:F3}", d_st_precondition_voltage);
            textBoxPreconditionCurrent.Text     = string.Format("{0:F3}", d_st_precondition_current);
            textBoxChargeCurrent.Text           = string.Format("{0:F3}", d_st_charge_current);
            textBoxTerminationCurrent.Text      = string.Format("{0:F3}", d_st_termination_current);
            textBoxTerminationVoltage.Text      = string.Format("{0:F3}", d_st_termination_voltage);
            textBoxMaximumChargeTime.Text       = string.Format("{0:F0}", d_st_maximum_charge_time);
            textBoxRapidChargeTime.Text         = string.Format("{0:F0}", d_st_rapid_time_max);
            textBoxRestorationChargeTime.Text   = string.Format("{0:F0}", d_st_restore_time_max);
            textBoxMinimumTemperature.Text      = string.Format("{0}",    d_st_minimum_temperature);
            textBoxMaximumTemperature.Text      = string.Format("{0}",    d_st_maximum_temperature);
            textBoxWireRes.Text                 = string.Format("{0:F0}", d_st_wire_resistance);
            textBoxUVLOFalling.Text             = string.Format("{0:F2}", d_st_UVLO_falling_voltage);
            textBoxUVLORising.Text              = string.Format("{0:F2}", d_st_UVLO_rising_voltage);
            textBoxFloatVoltage.Text            = string.Format("{0:F3}", d_st_float_voltage);
            textBoxFloatCurrent.Text            = string.Format("{0:F3}", d_st_float_current);
            textBoxOverVoltage.Text             = string.Format("{0:F3}", d_st_over_voltage);
            textBoxNegativedVdtCount.Text       = string.Format("{0:F0}", d_st_negative_dvdt_count);
            textBoxCCPositivedVdtCount.Text     = string.Format("{0:F0}", d_st_cc_positive_dvdt_count);
            textBoxCVNegativedIdtCount.Text     = string.Format("{0:F0}", d_st_cv_negative_didt_count);
            textBoxdVdtBlankTime.Text           = string.Format("{0:F1}", d_st_dvdt_blank_time);
            textBoxdtdtSlope.Text               = string.Format("{0:F1}", d_st_dtdt_slope);
            textBoxTempSlope.Text               = string.Format("{0:F3}", d_st_temperature_cal_slope);
            textBoxADCSize.Text                 = string.Format("{0:F0}", d_st_temperature_cal_ADC_size);
            textBoxADCVref.Text                 = string.Format("{0:F3}", d_st_temperature_cal_ADC_vref);
            textBoxPreConditionTime.Text        = string.Format("{0:F0}", d_st_precondition_time_max);
            textBoxPCdVdtCount.Text             = string.Format("{0:F0}", d_st_pc_dvdt_count);
            #endregion
        }
        #endregion

        #endregion

        #region Charger On/Off Control, Reporting, Graphing
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

            #region Definition of profile_data[63] array for reference
            /* profile_data[32] definitions as loaded by charger firmware out of cd.### struct */
            // [0-1]    Measured Input voltage
            // [2-3]    Measured Output (battery) voltage
            // [4-5]    Measured Output (battery) current
            // [6-7]    **Unassigned** was Measured Vref
            // [8-9]    Measured Temperature
            // [10-11]  Charge timer (time to shut-off)
            // [12]     State of the battery charger
            // [13]     **Unassigned** was current ADC reading, whatever that was at the time
            // [14-15]  Voltage restore timer
            // [16-17]  Rapid charge timer
            // [18-19]  dV/dt detection
            // [20-21]  dT/dt detection
            // [22]     Counter for negative dV/dt
            // [23]     Counter for negative dT/dt
            // [24-25]  Live status of charger Low Byte = {NEGDVDT, BUTTONSHDN, SERIALSHDN, UNDERTEMP, OVERTEMP, VOUTOVLO, VINOVLO, VINUVLO}
            //                                   = {COMPLETE, NOBATTERY, UNUSED2, UNUSED1, CONFIGERROR, PREDONDITIONFAIL, TIMEOUT, DTDTSHDN}
            // [26]     Counter for positive dI/dt 
            // [27]     Reference design number
            // [28]     Counter for dI/dt detection
            // [29-30]     Maximum Precondition Timer
            // [31-32]  dI/dt detection
            // [33] 
            // [34]
            // [35]
            // [36] MPPT current status
            // [37] Solar charging or DC charging mode
            // [38-39] External Battery Temp
            // [40-41]  
            // [42-43]  
            // [44-45]  
            // [46-47] Current value of active DAC
            // [48] Direction to go for more power.  Provided by MPPT routine.
            //Debug Variables
            // [49-50]  
            // [51-52]  
            // [53-54]  
            // [55-56]  Solar Current 
            //MPPT Variables
            // [57-58] MPPT power,32-bit word
            // The following bytes are part of the structure, but don't get passed to the GUI  
            // [59] Analog Debug Channel BUFFCON selection
            // GUI Variables 
            // [60] Unused in current GUI:  Which LEDs are active
            // [61-62] Solar input voltage
                                               //..............................................................
            #endregion

            #region Clear the profile_data array
            for (i = 0; i < 63; i++)
            {
                profile_data[i] = 0;
            }
            #endregion

            Debug.WriteLine(script);

            #region Read the profile_data from the device
            b = Serial_Read(Profile_Access, 63, ref profile_data);
            if (b == false)
            {
                EndProfile();
                MessageBox.Show("Communications lost with battery charger.");
                SerialClose(handle);
                return;
            }
            #endregion

            #region Declarations and parsing of the profile_data into local variables
            double  input_voltage       = ((ushort)profile_data[0]  | ((ushort)profile_data[1] << 8));
            double  pack_voltage        = ((ushort)profile_data[2]  | ((ushort)profile_data[3] << 8));
            double  pack_current        = ((ushort)profile_data[4]  | ((ushort)profile_data[5] << 8));
            double  pack_temperature    = ((ushort)profile_data[8]  | ((ushort)profile_data[9] << 8));
            int     charge_time         = ((ushort)profile_data[10] | ((ushort)profile_data[11] << 8));
            byte    charger_state       = profile_data[12];
            int     restore_timer       = ((ushort)profile_data[14] | ((ushort)profile_data[15] << 8));
            int     rapid_charge_timer  = ((ushort)profile_data[16] | ((ushort)profile_data[17] << 8));
            short   idvbat_dt           = (short)((((short)profile_data[19]) << 8) | ((ushort)profile_data[18]));
            short   idtemp_dt           = (short)((((short)profile_data[21]) << 8) | ((ushort)profile_data[20]));
            int     dvbat_dt_count      = profile_data[22];
            int     dtdt_count          = profile_data[23];
            int     status              = ((ushort)profile_data[24] | ((ushort)profile_data[25] << 8));
            //byte    eoc_status          = profile_data[25];
            byte    pdvdt_count         = profile_data[26];
            byte    PCB_reference_type  = profile_data[27];
            int     didt_count          = profile_data[28];
            int     precondition_timer = ((ushort)profile_data[29] | ((ushort)profile_data[30] << 8));
            //ushort precondition_timer = (ushort)(profile_data[29] | (profile_data[30] << 8));
            short   idibat_dt           = (short)((((short)profile_data[32]) << 8) | ((ushort)profile_data[31]));

            int ipack_voltage       = (int)pack_voltage;
            int iinput_voltage      = (int)input_voltage;
            int ipack_current       = (int)pack_current;
            int ipack_temperature   = (int)pack_temperature;

            input_voltage       = (input_voltage - vinintercept[3]) / vinslope[3];
            pack_voltage        = (pack_voltage - vbatintercept[3]) / vbatslope[3];
            pack_current        = (pack_current - ibatintercept[3]) / ibatslope[3];
            pack_temperature    = temperature_cal_celsius + (pack_temperature - temperature_cal) / temperature_adc_slope;
            #endregion

            if (ticker == true)
            {                
                #region Fill in the Pack Voltage, Output Volage, Output Current, Input Voltage, and Charge Time on the Profile Tab
                labelProfilePackVoltage.Text            = string.Format("{0:F2} V", pack_voltage - (pack_current * pack_current * (st_wire_resistance)) / 1000);
                labelProfileChargerOutputVoltage.Text   = string.Format("{0:F2} V", pack_voltage);
                labelProfilePackCurrent.Text            = string.Format("{0:F3} A", pack_current);
                labelProfileInputVoltage.Text           = string.Format("{0:F2} V", input_voltage); ;
                labelProfileChargeTime.Text             = string.Format("{0} s", charge_time);
                labelPackTemperatureRead.Text           = string.Format("{0:F2}", pack_temperature);
                #endregion

                #region Fill in the label for PCB Type on the Profile tab
                if (PCB_reference_type > 7)
                {
                    labelProfilePCBtype.Text = "Undefined PCB Type";
                }
                if (PCB_reference_type == 1)
                {
                    labelProfilePCBtype.Text = "MCP19111 Charger Reference";
                }
                if (PCB_reference_type == 2)
                {
                    labelProfilePCBtype.Text = "PIC16F1716 + MCP1631 SEPIC";
                }
                if (PCB_reference_type == 3)
                {
                    labelProfilePCBtype.Text = "PIC16F866 + MCP1631 SEPIC";
                }
                if (PCB_reference_type == 4)
                {
                    labelProfilePCBtype.Text = "MCP19118 4-Switch Buck-Boost";
                }
                if (PCB_reference_type == 5)
                {
                    labelProfilePCBtype.Text = "MCP19123 Buck-Boost Reference";
                }
                if (PCB_reference_type == 6)
                {
                    labelProfilePCBtype.Text = "MCP19125 ADM00745 Charger EVK";
                }
                if (PCB_reference_type == 7)
                {
                    labelProfilePCBtype.Text = "MCP19119 4A Charger";
                }
                if (PCB_reference_type == 10)
                {
                    labelProfilePCBtype.Text = "PIC16F1779 Hybrid CIP Starter Kit";
                }
                if (PCB_reference_type == 11)
                {
                    labelProfilePCBtype.Text = "PIC16F1769 MPPT Solar";
                }

                labelProfilePackVoltageLive.Text = string.Format("{0:F2} V", pack_voltage - (pack_current * pack_current * (st_wire_resistance)) / 1000);
                labelProfilePackCurrentLive.Text = string.Format("{0:F3} A", pack_current);
                labelProfileInputVoltageLive.Text = string.Format("{0:F2} V", input_voltage);
                labelPackTemperatureReadLive.Text = string.Format("{0:F2}", pack_temperature);
                labelRapidChargeTimerLive.Text = string.Format("{0:F2}", rapid_charge_timer);
                labelChargeTimeLive.Text = string.Format("{0:F2}", charge_time);
                labelPreconditionTimerLive.Text = string.Format("{0:F2}", precondition_timer);
                labelRestoreTimerLive.Text = string.Format("{0:F2}", restore_timer);
                labeldTdtCountLive.Text = string.Format("{0:F2}", dtdt_count);
                labeldtemp_dtLive.Text = string.Format("{0:F2}", idtemp_dt);
                labeldIdtCountLive.Text = string.Format("{0:F2}", didt_count);
                labeldIdtLive.Text = string.Format("{0:F2}", idibat_dt);
                labelPosdVbat_dtCountLive.Text = string.Format("{0:F2}", pdvdt_count);
                labelNegdVbat_dtCountLive.Text = string.Format("{0:F2}", dvbat_dt_count);
                labelNegdVbat_dtLive.Text = string.Format("{0:F2}", idvbat_dt);
                #endregion
            }
            else
            {
                #region Fill in the Pack Voltage, Output Volage, Output Current, Input Voltage, Charge Time, and Other Misc on the Advanced Tab

                labelProfileChargerOutputVoltageLive.Text   = string.Format("{0:F2} V", pack_voltage);
                labelProfilePackVoltageLive.Text            = string.Format("{0:F2} V", pack_voltage - (pack_current * pack_current * (st_wire_resistance)) / 1000);
                labelOutputVoltageCounts.Text               = string.Format("{0}", ipack_voltage);
                labelProfilePackCurrentLive.Text            = string.Format("{0:F3} A", pack_current);
                labelPackCurrentCounts.Text                 = string.Format("{0}", ipack_current);
                labelProfileInputVoltageLive.Text           = string.Format("{0:F2} V", input_voltage);
                labelInputVoltageCounts.Text                = string.Format("{0}", iinput_voltage);
                labelPackTemperatureReadLive.Text           = string.Format("{0:F2}", pack_temperature);
                labelRapidChargeTimerLive.Text              = string.Format("{0:F2}", rapid_charge_timer);
                labelChargeTimeLive.Text                    = string.Format("{0:F2}", charge_time);
                labelRestoreTimerLive.Text                  = string.Format("{0:F2}", restore_timer);
                labeldTdtCountLive.Text                     = string.Format("{0:F2}", dtdt_count);
                labeldtemp_dtLive.Text                      = string.Format("{0:F2}", idtemp_dt);
                labeldIdtCountLive.Text                     = string.Format("{0:F2}", didt_count); 
                labeldIdtLive.Text                          = string.Format("{0:F2}", idibat_dt);
                labelPosdVbat_dtCountLive.Text              = string.Format("{0:F2}", pdvdt_count);
                labelNegdVbat_dtCountLive.Text              = string.Format("{0:F2}", dvbat_dt_count);
                labelNegdVbat_dtLive.Text                   = string.Format("{0:F2}", idvbat_dt);
                labelPreconditionTimerLive.Text             = string.Format("{0:F2}", precondition_timer);
                #endregion

                #region Fill in the label for PCB Type on the Advanced tab
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
                if (PCB_reference_type == 10)
                {
                    labelPCBtypeLive.Text = "PIC16F1779 Hybrid CIP Starter Kit";
                }
                if (PCB_reference_type == 11)
                {
                    labelPCBtypeLive.Text = "PIC16F1769 MPPT Solar";
                }
                #endregion
            }

            #region Debug Writeline Definition and Print of the whole Profile data and parsing
            Debug.WriteLine(string.Format("Input Voltage Counts: {0}", iinput_voltage));
            Debug.WriteLine(string.Format("Pack Voltage Counts: {0}", ipack_voltage));
            Debug.WriteLine(string.Format("Pack Voltage: {0:F3} ({1})", pack_voltage, ipack_voltage));
            Debug.WriteLine(string.Format("Pack Current Counts: {0}", ipack_current));
            Debug.WriteLine(string.Format("Pack Temperature Counts: {0}", ipack_temperature));
            Debug.WriteLine(string.Format("Pack Temperature: {0:F3} ({1})", pack_temperature, ipack_temperature));
            Debug.WriteLine(string.Format("dT/dt_count {0}", dtdt_count));
            Debug.WriteLine(string.Format("dV/dt_count {0}", dvbat_dt_count));
            Debug.WriteLine(string.Format("dI/dt_count {0}", didt_count));
            Debug.WriteLine(string.Format("Precondition_timer {0}", precondition_timer));
            Debug.WriteLine(string.Format("restore_timer {0}", restore_timer));
            Debug.WriteLine(string.Format("rapid_charge_timer {0}", rapid_charge_timer));
            Debug.WriteLine(string.Format("Charger Status: {0:x4}", status));
            //Debug.WriteLine(string.Format("EOC Status: {0:x2}", eoc_status));
            Debug.WriteLine(string.Format("PCB Type connected {0} {1}", PCB_reference_type, labelProfileInputVoltageLive.Text));
            Debug.WriteLine(string.Format(""));

            for (i = 0; i < 63; i++)
            {
                Debug.WriteLine(string.Format("Profile_Data [{0}] = {1}", i, profile_data[i]));
            }
            #endregion

            #region Tedious Temperature Management - Rewrite looking at Temp Sensor CheckBox
            //%%BRYAN%% Massage this a bit better based on temperature enabled configuration.
            if (ticker == true)
            {
                if (pack_temperature != 0)
                {
                    labelPackTemperatureRead.Text = string.Format("{0:F1} °C",pack_temperature);
                    labelPackTemperatureCountsLive.Text = string.Format("{0}", ipack_temperature);
                }
                else
                {
                    labelPackTemperatureRead.Text = "Open Circuit";
                }
            }
            else if (ticker == false)
            {
                if (pack_temperature != 0)
                {
                    labelPackTemperatureReadLive.Text = string.Format("{0:F1} °C", pack_temperature);
                    labelPackTemperatureCountsLive.Text = string.Format("{0}", ipack_temperature);
                }
                else
                {
                    labelPackTemperatureReadLive.Text = "Open Circuit";
                }
            }
            #endregion

            #region Take the Status from Byte[24-25] of Profile and Update the Text Fields in Profile and Advanced tabs
            string charger_status = "";

            if (status == 0x0000)
            {
                charger_status += "HEALTHY ";
            }
            if ((status & 0x0001) != 0)
            {
                charger_status += "VIN_UVLO ";
            }
            if ((status & 0x0002) != 0)
            {
                charger_status += "VIN_OVLO ";
            }
            if ((status & 0x0004) != 0)
            {
                charger_status += "VOUT_OVLO ";
            }
            if ((status & 0x0008) != 0)
            {
                charger_status += "OVER_TEMP ";
            }
            if ((status & 0x0010) != 0)
            {
                charger_status += "UNDER_TEMP ";
            }
            if ((status & 0x0020) != 0)
            {
                charger_status += "SERIAL_SHDN ";
            }
            if ((status & 0x0040) != 0)
            {
                charger_status += "BUTTON_SHDN ";
            }
            if ((status & 0x0080) != 0)
            {
                charger_status += "NEG_DVDT ";
            }
            if ((status & 0x0100) != 0)
            {
                charger_status += "DTDT_SHDN ";
            }
            if ((status & 0x0200) != 0)
            {
                charger_status += "TIMEOUT ";
            }
            if ((status & 0x0400) != 0)
            {
                charger_status += "PRECONDITION_FAIL ";
            }
            if ((status & 0x0800) != 0)
            {
                charger_status += "CONFIG_ERR ";
            }
            if ((status & 0x1000) != 0)
            {
                charger_status += "dI/dt_SHDN ";
            }
            if ((status & 0x2000) != 0)
            {
                charger_status += "UNUSED2 ";
            }
            if ((status & 0x4000) != 0)
            {
                charger_status += "NO_BATTERY ";
            }
            

            labelChargerStatus.Text = charger_status;
            labelChargerStatusLive.Text = charger_status;
            #endregion

            #region Take the charger_state from Byte[12] of Profile and Update the Text Fields in Profile and Advanced tabs
            switch (charger_state)
            {
                case 0x00: //Charger OFF
                    string term_status = "";
                    term_status = "OFF: ";
                    if ((status & 0x8000) != 0)
                    {
                        term_status += "CHARGE_COMPLETE ";
                    }

                    if (ticker == true)
                    {
                        labelProfileChargerState.Text = term_status;
                        labelProfileChargerStateLive.Text = term_status;
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
                case 0x02: // Lithium Ion Precondition
                    labelProfileChargerState.Text = "Li+ Precondition";
                    labelProfileChargerStateLive.Text = "Li+ Precondition";
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
            #endregion

            #region Plot the Graphs in the Profile tab
            if ((ticker == true) && (charge_time > last_charge_time))
            {
                chartProfile.Series["Pack Voltage"].Points.AddXY(charge_time, pack_voltage);
                chartProfile.Series["Pack Current"].Points.AddXY(charge_time, pack_current);
                chartProfile.Series["Input Voltage"].Points.AddXY(charge_time, input_voltage);
                chartProfile.Series["Pack Temperature"].Points.AddXY(charge_time, pack_temperature);                
                last_charge_time = charge_time;
            }
            #endregion
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
            chartProfile.Series["Pack Temperature"].Points.Clear();
            chartProfile.Series["Input Voltage"].Points.Clear();

            chartProfile.ChartAreas[0].AxisX.Minimum = 0;
            chartProfile.ChartAreas[1].AxisX.Minimum = 0;
            chartProfile.ChartAreas[2].AxisX.Minimum = 0;
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

            UpdateProfileData(true);

            Cursor.Current = Cursors.Default;

            EndProfile();
        }

        private void EndProfile()
        {
            timer1.Stop();
            buttonProfileStart.Enabled = true;
            //Button Stop is set to TRUE to always give the option to stop the charger for safety purposes. e.g. it is started manually (not with GUI).
            buttonProfileStop.Enabled = true;
            buttonSaveData.Enabled = true;
            profilerunning = false;

            labelProfilePackVoltage.Text = "";
            labelProfilePackCurrent.Text = "";
            labelProfileInputVoltage.Text = "";
            //labelProfileChargerState.Text = "Not Connected"; //%%BRYAN%% Commented out because it was overwriting the shutdown cause
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
                        System.Windows.Forms.DataVisualization.Charting.DataPoint input_voltage;
                        System.Windows.Forms.DataVisualization.Charting.DataPoint pack_voltage;
                        System.Windows.Forms.DataVisualization.Charting.DataPoint pack_current;
                        System.Windows.Forms.DataVisualization.Charting.DataPoint pack_temperature;

                        input_voltage = chartProfile.Series["Input Voltage"].Points[i];
                        pack_voltage = chartProfile.Series["Pack Voltage"].Points[i];
                        pack_current = chartProfile.Series["Pack Current"].Points[i];
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
            temperature_cal = 0;
            temperature_cal_celsius = 0;
        }

        private void buttonReadCalibration_Click(object sender, EventArgs e)  //Calls ReadCalibration() and passes a TRUE to update the text boxes with read values.
        {
            ReadCalibration(true);
        }

        private bool ReadCalibration(bool updatedialog = false) //Reads the flash values from the device, checks their validity, and if passed a true value will update the calibration value text-boxes.
        {
            int i;
            bool b;

            ClearCalibrationData();
            if (!Init_Serial())
            {
                return false;
            }

            #region Clear data array and read calibration data
            for (i = 0; i < 64; i++)
            {
                cal_data[i] = 0xff;
            }

            b = Serial_Read(Flash_Access, 64, ref cal_data);
            Debug.WriteLine(script);

            if (b == false)
            {
                MessageBox.Show("Could not read calibration data from battery charger.");
                if (serial_device == 1)
                {
                    SerialClose(handle);
                }
                return b;
            }

            //Debug.WriteLine(script);
            #endregion

            #region Load the values from the cal_data array into the individual calibration data point arrays and variables
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

            temperature_cal             = Convert.ToDouble(((ushort)cal_data[38]) | ((ushort)cal_data[39] << 8));
            temperature_cal_celsius     = Convert.ToDouble(((ushort)cal_data[36]) | ((ushort)cal_data[37] << 8)) / 10;
            
            #endregion

            #region Quick and dirty check to see if any of the values are out of range. (i.e. > 4095)
            for (i = 0; i < 3; i++)
            {
                if ((ibat[i] > 4095) || (vin[i] > 4095) || (vbat[i] > 4095) /*|| (temperature_cal > 4095)*/) //%%BRYAN%% a temp check here would be nice, but it has to be smarter since it's not always there.
                {
                    MessageBox.Show("The battery charger has not been properly calibrated.");
                    ClearCalibrationData();
                    return false;
                }
            }
            #endregion

            #region Then send the data on to a more thorough check for monotonicity and linearity
            if (CheckCalibration() == false)
            {
                ClearCalibrationData();
                return false;
            }
            #endregion

            #region Update text boxes with read values in the calibrate tab
            if (updatedialog)
            {
                textBoxLowAmp.Text          = Convert.ToString(ibat[0]);
                textBoxMidAmp.Text          = Convert.ToString(ibat[1]);
                textBoxHighAmp.Text         = Convert.ToString(ibat[2]);

                textBoxSetLowAmp.Text       = string.Format("{0:F3}", irange[0]);
                textBoxSetMidAmp.Text       = string.Format("{0:F3}", irange[1]);
                textBoxSetHighAmp.Text      = string.Format("{0:F3}", irange[2]);

                textBoxLowVbat.Text         = Convert.ToString(vbat[0]);
                textBoxMidVbat.Text         = Convert.ToString(vbat[1]);
                textBoxHighVbat.Text        = Convert.ToString(vbat[2]);

                textBoxSetLowVbat.Text      = string.Format("{0:F2}", vbatrange[0]);
                textBoxSetMidVbat.Text      = string.Format("{0:F2}", vbatrange[1]);
                textBoxSetHighVbat.Text     = string.Format("{0:F2}", vbatrange[2]);

                textBoxLowVin.Text          = Convert.ToString(vin[0]);
                textBoxMidVin.Text          = Convert.ToString(vin[1]);
                textBoxHighVin.Text         = Convert.ToString(vin[2]);

                textBoxSetLowVin.Text       = string.Format("{0:F2}", vinrange[0]);
                textBoxSetMidVin.Text       = string.Format("{0:F2}", vinrange[1]);
                textBoxSetHighVin.Text      = string.Format("{0:F2}", vinrange[2]);

                textBoxCalTempReading.Text  = Convert.ToString(temperature_cal);
                textBoxCalTemp.Text         = string.Format("{0:F2}", temperature_cal_celsius);
            }
            #endregion

            return true;
        }

        private bool CheckCalibration(bool notify = true)  //Checks calibration values for realistic values. Has a default input to display a message box error on bad results.
        {
            int i;
            bool b = true;

            #region Perform math to get the slopes and intercepts for the calibration data
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

            #endregion

            #region Checks for data validity
            b = true;
            //%%BRYAN%% Consider some checks here for the temperature calibration validity for the future

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
            #endregion

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

            /* Disconnect the Battery */
            ChargerCommand(0);

            #region Load the calibration array with values from the text boxes to accomodate manual changes
            ibat[0]      = ToDouble(textBoxLowAmp.Text);
            ibat[1]      = ToDouble(textBoxMidAmp.Text);
            ibat[2]      = ToDouble(textBoxHighAmp.Text);

            vbat[0]      = ToDouble(textBoxLowVbat.Text);
            vbat[1]      = ToDouble(textBoxMidVbat.Text);
            vbat[2]      = ToDouble(textBoxHighVbat.Text);

            vin[0]       = ToDouble(textBoxLowVin.Text);
            vin[1]       = ToDouble(textBoxMidVin.Text);
            vin[2]       = ToDouble(textBoxHighVin.Text);

            irange[0]    = ToDouble(textBoxSetLowAmp.Text)  * 1000;
            irange[1]    = ToDouble(textBoxSetMidAmp.Text)  * 1000;
            irange[2]    = ToDouble(textBoxSetHighAmp.Text) * 1000;

            vbatrange[0] = ToDouble(textBoxSetLowVbat.Text)  * 100;
            vbatrange[1] = ToDouble(textBoxSetMidVbat.Text)  * 100;
            vbatrange[2] = ToDouble(textBoxSetHighVbat.Text) * 100;

            vinrange[0]  = ToDouble(textBoxSetLowVin.Text)  * 100;
            vinrange[1]  = ToDouble(textBoxSetMidVin.Text)  * 100;
            vinrange[2]  = ToDouble(textBoxSetHighVin.Text) * 100;

            temperature_cal_celsius  = ToDouble(textBoxCalTemp.Text) * 10;
            temperature_cal          = ToDouble(textBoxCalTempReading.Text);
            
            #endregion

            #region Do a check of these new values to make sure they're valid
            if (CheckCalibration() == false)
            {
                return;
            }
            #endregion

            #region Clear the cal_data array and stuff the calibration values for writing to flash
            for (i = 0; i < 64; i++) cal_data[i] = 0xff;

            cal_data[0]  = LSB(ibat[0]);
            cal_data[1]  = MSB(ibat[0]);
            cal_data[2]  = LSB(ibat[1]);
            cal_data[3]  = MSB(ibat[1]);
            cal_data[4]  = LSB(ibat[2]);
            cal_data[5]  = MSB(ibat[2]);

            cal_data[6]  = LSB(vin[0]);
            cal_data[7]  = MSB(vin[0]);
            cal_data[8]  = LSB(vin[1]);
            cal_data[9]  = MSB(vin[1]);
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

            cal_data[36] = LSB(temperature_cal_celsius);
            cal_data[37] = MSB(temperature_cal_celsius);
            cal_data[38] = LSB(temperature_cal);
            cal_data[39] = MSB(temperature_cal);
            #endregion

            #region Write, Read, Compare the flash to confirm successful write
            //Debug.WriteLine(script);
            b = Serial_Write(Flash_Access, 64, ref cal_data); 

            if (b == false)
            {
                b = false;
                MessageBox.Show("Could not write calibration data to battery charger..");
                return;
            }

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
                buttonBeginCalibration_Click(sender, e); //Flips the Calibrating Flag back to False among other things
                buttonReadCalibration_Click(sender, e);
            }
            #endregion
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

                /* Disable the charger, turns it off, but leaves the disconnect FET engaged for sensing the battery */
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

            for (i = 0; i < 63; i++)
            {
                profile_data[i] = 0;
            }

            //Debug.WriteLine(script);
            b = Serial_Read(Profile_Access, 63, ref profile_data);

            if (b == false)
            {
                MessageBox.Show("Communications lost with battery charger.");
                SerialClose(handle);
            }

            return b;
        }

        private void ButtonDefaultCalValues_Click(object sender, EventArgs e) //These are default values for MCP19111 Battery Charger EVK "ONLY" loaded from the Advanced Tab of the GUI. 
        {
            #region Hard-Coded default values
            ibat[0] = (341);
            ibat[1] = (582);
            ibat[2] = (1180);

            vbat[0] = (1474);
            vbat[1] = (2196);
            vbat[2] = (2936);

            vin[0] = (540);
            vin[1] = (800);
            vin[2] = (1067);

            temperature_cal = (1850); // ADC default reading
            temperature_cal_celsius = (25); // 25 Celsius default reading
            #endregion

            #region Put the hard coded values in the text boxes
            textBoxLowAmp.Text = Convert.ToString(ibat[0]);
            textBoxMidAmp.Text = Convert.ToString(ibat[1]);
            textBoxHighAmp.Text = Convert.ToString(ibat[2]);
            textBoxSetLowAmp.Text = "0.200";
            textBoxSetMidAmp.Text = "1.000";
            textBoxSetHighAmp.Text = "3.000";

            textBoxLowVbat.Text = Convert.ToString(vbat[0]);
            textBoxMidVbat.Text = Convert.ToString(vbat[1]);
            textBoxHighVbat.Text = Convert.ToString(vbat[2]);
            textBoxSetLowVbat.Text = "8.4";
            textBoxSetMidVbat.Text = "12.6";
            textBoxSetHighVbat.Text = "16.8";

            textBoxLowVin.Text = Convert.ToString(vin[0]);
            textBoxMidVin.Text = Convert.ToString(vin[1]);
            textBoxHighVin.Text = Convert.ToString(vin[2]);
            textBoxSetLowVin.Text = "8.4";
            textBoxSetMidVin.Text = "12.6";
            textBoxSetHighVin.Text = "16.8";

            textBoxCalTemp.Text = Convert.ToString(temperature_cal);
            textBoxCalTempReading.Text = Convert.ToString(textBoxCalTempReading);
            #endregion
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

        private void buttonCalTemp_Click(object sender, EventArgs e)
        {
            if (ReadCalibrationPoint() == true)
            {
                int temperature = ((ushort)profile_data[8] | ((ushort)profile_data[9] << 8));
                textBoxCalTempReading.Text = Convert.ToString(temperature);
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
                    stream.WriteLine("// This file provides the hard-coded configuration file required when");
                    stream.WriteLine("// you want a fixed-function charger and don't want to use the GUI to");
                    stream.WriteLine("// configure the system in manufacturing. Which will be most cases.");
                    stream.WriteLine("// ");
                    stream.WriteLine("// To use this file, please enable the #define in MultiChemCharger_Main.h");
                    stream.WriteLine("// labeled '#define ENABLE_FIXED_CONFIG'.");
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

                    switch (profile_data[27])
                        {
                        case (10): //PIC with much larger Flash so put it up higher in the map to be easier to identify by site on a memory dump
                            stream.WriteLine("org 0x3e60        // Change this line if you change the location in memory for the config/cal data");
                            stream.WriteLine("_Cal_Data_Array:");
                            Debug.WriteLine("Calibration Data 0x3E60"); break;

                        default:
                            stream.WriteLine("org 0xe60        // Change this line if you change the location in memory for the config/cal data");
                            stream.WriteLine("_Cal_Data_Array:");
                            Debug.WriteLine("Calibration Data 0xE60"); break;
                        }


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
                    switch (profile_data[27])
                    {
                        case (10):
                            stream.WriteLine("org 0x3e80");
                            stream.WriteLine("_Config_Data_Array:");
                            Debug.WriteLine("Configuration Data: 0x3E80");
                            break;
                        default:
                            stream.WriteLine("org 0xe80");
                            stream.WriteLine("_Config_Data_Array:");
                            Debug.WriteLine("Configuration Data: 0xE80");
                            break;
                    }

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

            #region Clear the configuration_data array
            for (i = 0; i < 128; i++)
            {
                configuration_data[i] = 0;
            }
            #endregion

            #region Read the Configuration Data from flash
            b = Serial_Read((ushort)(Flash_Access | Flash_Config_Offset), 128, ref configuration_data);  
            if (b == false)
            {
                MessageBox.Show("Could not read configuration data from battery charger.");
                SerialClose(handle);
                return b;
            }
            #endregion

            #region Check that the calibration data is valid and linear
            if (ReadCalibration(false) == false)
            {
                MessageBox.Show("Could not read calibration data from battery charger.");
                SerialClose(handle);
                return b;
            }      
            #endregion

            #region Parse the configuration data bytes into 16bit st_* variables
            st_cell_voltage =             ReadConfigurationDataU16(76);
            st_number_of_cells =          ReadConfigurationDataU16(78);
            st_chemistry =                (byte)(ReadConfigurationDataU16(36));
            st_precondition_voltage =     ReadConfigurationDataU16(80);
            st_precondition_current =     ReadConfigurationDataU16(82);
            st_charge_current =           ReadConfigurationDataU16(84);
            st_termination_current =      ReadConfigurationDataU16(86);
            st_maximum_charge_time =      (ushort)((ReadConfigurationDataU16(66) & 0x00ff) | ((ReadConfigurationDataU16(68) & 0x00ff) << 8));
            st_rapid_time_max =           ReadConfigurationDataU16(28);
            st_restore_time_max =         ReadConfigurationDataU16(24);
            st_minimum_temperature =      ReadConfigurationDataI16(94);
            st_maximum_temperature =      ReadConfigurationDataI16(96);
            st_termination_voltage =      ReadConfigurationDataU16(98);
            st_wire_resistance =          ReadConfigurationDataU16(100);
            st_float_voltage =            ReadConfigurationDataU16(102);
            st_float_current =            ReadConfigurationDataU16(112);
            st_negative_dvdt_count =      ReadConfigurationDataI16(46);
            st_cc_positive_dvdt_count =   ReadConfigurationDataU16(48);
            st_cv_negative_didt_count =   ReadConfigurationDataI16(50);
            st_over_voltage =             ReadConfigurationDataU16(104);
            st_UVLO_rising_voltage =      ReadConfigurationDataU16(108);
            st_UVLO_falling_voltage =     ReadConfigurationDataU16(110);
            st_dvdt_blank_time =          ReadConfigurationDataU16(26);
            st_dtdt_slope =               ReadConfigurationDataI16(106);
            st_temperature_cal_ADC_vref = ReadConfigurationDataU16(88);
            st_temperature_cal_ADC_size = ReadConfigurationDataU16(90);
            st_temperature_cal_slope =    ReadConfigurationDataU16(92);
            st_dvdt_pc_count =            ReadConfigurationDataU16(62);
            st_precondition_time_max =    ReadConfigurationDataU16(60);

            #region Test & Populate the Chemistry Text Box based on the read st_chemistry value
            if (st_chemistry > tot_num_chems) //return false; 
            {
                MessageBox.Show(string.Format("Could not read configuration data from battery charger - Unknown Chemistry {0}.", st_chemistry));
                return false;
            }
            if (st_chemistry == 0)
            {
                comboBoxChemistry.Text = "Li-Ion";
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
            #endregion

            #region Set the 'Enable External Temp Sensor' Checkbox
            if(ReadConfigurationDataU16(56) == 1)
            {
                checkBoxThermistor.CheckState = CheckState.Checked; ;
            }
            else
            {
                checkBoxThermistor.CheckState = CheckState.Unchecked;
            }
            #endregion

            #endregion
         
            #region Clear the profile_data array and get a snap-shot from the charger to load real values. This is needed before UpdateSettingsTab() is called.
             /* Read Profile Data Once to get the PCB ID */
            for (i = 0; i < 63; i++)
            {
                profile_data[i] = 0;
            }
            b = Serial_Read(Profile_Access, 63, ref profile_data);
            if (b == false)
            {
                EndProfile();
                MessageBox.Show("Communications lost with battery charger.");
                SerialClose(handle);
                return b;
            }
            if (updatedialog)
            {
                UpdateSettingsTab();
            }
            #endregion

            return true;
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
            {
                return;
            }

            /* Check that the charger has been calibrated. If it hasn't then the data processed below is FUD. */
            if (ReadCalibration() == false)
            { 
                return;
            }

            #region Load Values from the GUI Text Boxes into local memory
            string Chemistry                = comboBoxChemistry.Text;
            bool   temp_sense_en            = checkBoxThermistor.Checked;
            double cell_voltage             = ToDouble(textBoxCellVoltage.Text);
            double precondition_voltage     = ToDouble(textBoxPreconditionCellVoltage.Text);
            double termination_voltage      = ToDouble(textBoxTerminationVoltage.Text);
            double number_of_cells          = ToDouble(comboBoxNumberOfCells.Text);
            double charge_current           = ToDouble(textBoxChargeCurrent.Text);
            double precondition_current     = ToDouble(textBoxPreconditionCurrent.Text);
            double termination_current      = ToDouble(textBoxTerminationCurrent.Text);
            double maximum_charge_time      = ToDouble(textBoxMaximumChargeTime.Text);
            double rapid_charge_time        = ToDouble(textBoxRapidChargeTime.Text);
            double restoration_time         = ToDouble(textBoxRestorationChargeTime.Text);
            double minimum_temperature      = ToDouble(textBoxMinimumTemperature.Text);
            double maximum_temperature      = ToDouble(textBoxMaximumTemperature.Text);
            double wire_resistance          = ToDouble(textBoxWireRes.Text);
            double pack_uvlo_rising         = ToDouble(textBoxUVLORising.Text);
            double pack_uvlo_falling        = ToDouble(textBoxUVLOFalling.Text);
            double float_voltage            = ToDouble(textBoxFloatVoltage.Text);
            double float_current            = ToDouble(textBoxFloatCurrent.Text);
            double negative_dvdt_count      = ToDouble(textBoxNegativedVdtCount.Text);      // -2 is recommended                        - It is dangerous to change these. Be very careful.
            double cc_positive_dvdt_count   = ToDouble(textBoxCCPositivedVdtCount.Text);    // 5 is recommended                         - It is dangerous to change these. Be very careful.
            double cv_negative_didt_count   = ToDouble(textBoxCVNegativedIdtCount.Text);    // 3 is recommended                         - It is dangerous to change these. Be very careful.
            double over_voltage             = ToDouble(textBoxOverVoltage.Text);
            double dvdt_blank_time          = ToDouble(textBoxdVdtBlankTime.Text);          // 2.5 minutes is recommended               - It is dangerous to change these. Be very careful.
            double dtdt_slope               = ToDouble(textBoxdtdtSlope.Text);              // 1.5 Celsius/minute is recommended        - It is dangerous to change these. Be very careful.
            double temperature_cal_ADC_size = ToDouble(textBoxADCSize.Text);
            double temperature_cal_ADC_vref = ToDouble(textBoxADCVref.Text);
            double temperature_cal_slope    = ToDouble(textBoxTempSlope.Text);
            double temperature_coeff        = ToDouble(textBoxTempCoeff.Text);
            double pack_ov                  = number_of_cells * over_voltage;
            double pack_conditioned         = number_of_cells * precondition_voltage;
            double pack_termvoltage         = number_of_cells * termination_voltage;
            double pack_floatvoltage        = number_of_cells * float_voltage;
            double precondition_charge_time = ToDouble(textBoxPreConditionTime.Text);
            double pc_dvdt_count            = ToDouble(textBoxPCdVdtCount.Text);
            #endregion

            temperature_adc_slope = (temperature_cal_slope) / (temperature_cal_ADC_vref / ((1 << ((ushort)temperature_cal_ADC_size + 2)) - 1)); // +2 because the firmware oversamples 16x, then >> 2.
			if (Chemistry == "NiMH")
			{
				temperature_adc_slope = -1 * temperature_adc_slope;
			}
            #region Test the User Input for valid values & Also loads the st_chemistry value

            #region UVLO Lockout Tests
            if (double.IsInfinity(pack_uvlo_rising) | double.IsNaN(pack_uvlo_rising))
            {
                pack_uvlo_rising = 5.5;    // Check if the UVLO Rising is currently at Infinity and correct
            }
            if (pack_uvlo_rising < 4.5)
            {
                MessageBox.Show("UVLO Rising is out of the range (> 4.5).");
                return;
            }

            if (double.IsInfinity(pack_uvlo_falling) | double.IsNaN(pack_uvlo_falling))
            {
                pack_uvlo_falling = 4.5;    // Check if the UVLO Falling is currently at Infinity and correct
            }
            if (pack_uvlo_falling < 4.5)
            {
                MessageBox.Show("UVLO Falling is out of the range (> 4.5).");
                return;
            }

            if (pack_uvlo_rising < pack_uvlo_falling)
            {
                MessageBox.Show("UVLO Rising must be higher than UVLO Falling.");
                return;
            }
            #endregion

            #region Charge Time Test
            if (double.IsInfinity(maximum_charge_time) | double.IsNaN(maximum_charge_time))
            {
                maximum_charge_time = 600;    // Check if the UVLO Rising is currently at Infinity and correct
            }
            if ((maximum_charge_time > 1080) || (maximum_charge_time < 0))    // 1080 * 60 = 64800 < 65535(2 bytes)
            {
                MessageBox.Show("The entered maximum charge time is out of range (1 to 1080). Or 0 for Infinite.");
                return;
            }
            if (double.IsInfinity(precondition_charge_time) | double.IsNaN(precondition_charge_time))
            {
                precondition_charge_time = 40; // 1080 * 60 = 64800 < 65535(2 bytes)
            }
            if ((precondition_charge_time > 273) || (precondition_charge_time < 1) || ((precondition_charge_time > maximum_charge_time) && (maximum_charge_time > 0)))
            {
                MessageBox.Show("The entered precondition charge time is out of range (the less of 1 to 273 minutes or Maximum Charge Time).");
                return;
            }
            if (double.IsInfinity(rapid_charge_time) | double.IsNaN(rapid_charge_time))
            {
                rapid_charge_time = 60;
            }
            if (((rapid_charge_time > maximum_charge_time) && (maximum_charge_time > 0)) || (rapid_charge_time < 0) || (rapid_charge_time > 273))
            {
                MessageBox.Show("The entered rapid charge time is out of range (the less of 1 to 273 Minutes or Maximum Charge Time, 0 for Infinity).");
                return;
            }
            if (double.IsInfinity(pc_dvdt_count) | double.IsNaN(pc_dvdt_count))
            {
                pc_dvdt_count = 20;   
            }
            if ((pc_dvdt_count > 100) || (pc_dvdt_count < 10))    
            {
                MessageBox.Show("The entered pc_dvdt_count is out of range (10 to 100).");
                return;
            }
            #endregion

            #region Temperature Tests
            if (double.IsInfinity(minimum_temperature) | double.IsNaN(minimum_temperature))
            {
                minimum_temperature = 0;    // Check if the minimum_temperature is currently at Infinity and correct
            }
            if (double.IsInfinity(maximum_temperature) | double.IsNaN(maximum_temperature))
            {
                maximum_temperature = 60;    // Check if the minimum_temperature is currently at Infinity and correct
            }
            if (temp_sense_en)
            {
                if ((minimum_temperature < -20) || (minimum_temperature >= maximum_temperature) || (minimum_temperature > 65.0))
                {
                    MessageBox.Show("The minimum temperature is out of range (-20 °C to Maximum Temperature or 65 °C).");
                    return;
                }

                if ((maximum_temperature < 0) || (maximum_temperature > 65.0))
                {
                    MessageBox.Show("The maximum temperature is out of range (Maximum Temperature to 65 °C).");
                    return;
                }
            }
            else
            {
                minimum_temperature = 0;
                maximum_temperature = 60;
            }
            #endregion

            #region System & Connection Resistance Test
            if (double.IsInfinity(wire_resistance) | double.IsNaN(wire_resistance))
            {
                wire_resistance = 0;    // Check if the minimum_temperature is currently at Infinity and correct
            }
            if ((wire_resistance < 0) || (wire_resistance > 1000))
            {
                MessageBox.Show("The maximum resistance is out of range (Resistance from 0 to 1000 milliohms).");
                return;
            }
            #endregion

            if (Chemistry == "Li-Ion")
            {
                st_chemistry = 0;

                if (double.IsInfinity(cell_voltage) | double.IsNaN(cell_voltage))
                {
                    cell_voltage = 3.6;    // Check if the cell_voltage is currently at Infinity and correct
                }
                if ((cell_voltage > 4.0) || (cell_voltage < 3.0))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (3.0 to 4.0).");
                    return;
                }

                if (double.IsInfinity(number_of_cells) | double.IsNaN(number_of_cells))
                {
                    number_of_cells = 2;    // Check if the number_of_cells is currently at Infinity and correct
                }
                if ((number_of_cells > 5.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 5).");
                    return;
                }

                if (double.IsInfinity(precondition_voltage) | double.IsNaN(precondition_voltage))
                {
                    precondition_voltage = 3.0;    // Check if the precondition_voltage is currently at Infinity and correct
                }
                if ((precondition_voltage > 4.0) || (precondition_voltage < 2.0))
                {
                    MessageBox.Show("The entered precondition voltage is out of range (2.0 to 4.0).");
                    return;
                }

                if (double.IsInfinity(charge_current) | double.IsNaN(charge_current))
                {
                    charge_current = 2.0;    // Check if the charge_current is currently at Infinity and correct
                }
                if ((charge_current > 10.0) || (charge_current < 0.200))
                {
                    MessageBox.Show("The entered charge current is out of range (0.200 to 10.0).");
                    return;
                }

                if (double.IsInfinity(precondition_current) | double.IsNaN(precondition_current))
                {
                    precondition_current = 0.1;    // Check if the precondition_current is currently at Infinity and correct
                }
                if ((precondition_current > charge_current) || (precondition_current < 0.050))
                {
                    MessageBox.Show("The entered precondition current is out of range (0.050 to Charge Current).");
                    return;
                }

                if (double.IsInfinity(termination_current) | double.IsNaN(termination_current))
                {
                    termination_current = 0.1;    // Check if the termination_current is currently at Infinity and correct
                }
                if ((termination_current > charge_current) || (termination_current < 0.050))
                {
                    MessageBox.Show("The entered termination current is out of range (0.050 to Charge Current).");
                    return;
                }

                if (double.IsInfinity(termination_voltage) | double.IsNaN(termination_voltage) || (termination_voltage < precondition_voltage))
                {
                    termination_voltage = 3.6;
                }
                if ((termination_voltage > 4.5) || (termination_voltage < 3.0))
                {
                    MessageBox.Show("The entered termination_voltage is out of range (termination_voltage frpm 3.0V to 4.5V).");
                    return;
                }
            }
            else if (Chemistry == "VRLA CCCP")
            {
                st_chemistry = 2;

                if (double.IsInfinity(cell_voltage) | double.IsNaN(cell_voltage))
                {
                    cell_voltage = 2.0;    // Check if the cell_voltage is currently at Infinity and correct
                }
                if ((cell_voltage > 2.45) || (cell_voltage < 1.5))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (1.5 to 2.45).");
                    return;
                }

                if (double.IsInfinity(number_of_cells) | double.IsNaN(number_of_cells))
                {
                    number_of_cells = 2;    // Check if the number_of_cells is currently at Infinity and correct
                }
                if ((number_of_cells > 6.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 6).");
                    return;
                }

                if (double.IsInfinity(precondition_voltage) | double.IsNaN(precondition_voltage))
                {
                    precondition_voltage = 1.5;    // Check if the precondition_voltage is currently at Infinity and correct
                }
                if ((precondition_voltage > 2.0) || (precondition_voltage < 1.1))     //1.5
                {
                    MessageBox.Show("The entered precondition voltage is out of range (1.1 to 2.0).");
                    return;
                }

                if (double.IsInfinity(charge_current) | double.IsNaN(charge_current))
                {
                    charge_current = 2.0;    // Check if the charge_current is currently at Infinity and correct
                }
                if ((charge_current > 10.0) || (charge_current < 0.200))
                {
                    MessageBox.Show("The entered charge current is out of range (0.200 to 10.0).");
                    return;
                }

                if (double.IsInfinity(precondition_current) | double.IsNaN(precondition_current))
                {
                    precondition_current = 0.1;    // Check if the precondition_current is currently at Infinity and correct
                }
                if ((precondition_current > charge_current) || (precondition_current < 0.050))
                {
                    MessageBox.Show("The entered precondition current is out of range (0.050 to Charge Current).");
                    return;
                }

                if (double.IsInfinity(termination_current) | double.IsNaN(termination_current))
                {
                    termination_current = 0.4;    // Check if the termination_current is currently at Infinity and correct
                }
                if ((termination_current > charge_current) || (termination_current < 0.050))
                {
                    MessageBox.Show("The entered termination current is out of range (0.050 to Charge Current).");
                    return;
                }

                if (double.IsInfinity(termination_voltage) | double.IsNaN(termination_voltage))
                {
                    termination_voltage = 2.4;
                }
                if ((termination_voltage > 2.5) || (termination_voltage < 2.1) || (termination_voltage < precondition_voltage))
                {
                    MessageBox.Show("The entered termination_voltage is out of range (termination_voltage frpm 2.1V to 2.5V).");
                    return;
                }
            }
            else if (Chemistry == "VRLA Fast")
            {
                st_chemistry = 3;

                if (double.IsInfinity(cell_voltage) | double.IsNaN(cell_voltage))
                {
                    cell_voltage = 2.0;    // Check if the cell_voltage is currently at Infinity and correct
                }
                if ((cell_voltage > 2.45) || (cell_voltage < 1.5))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (1.5 to 2.45).");
                    return;
                }

                if (double.IsInfinity(number_of_cells) | double.IsNaN(number_of_cells))
                {
                    number_of_cells = 2;    // Check if the number_of_cells is currently at Infinity and correct
                }
                if ((number_of_cells > 6.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 6).");
                    return;
                }

                if (double.IsInfinity(precondition_voltage) | double.IsNaN(precondition_voltage))
                {
                    precondition_voltage = 1.5;    // Check if the precondition_voltage is currently at Infinity and correct
                }
                if ((precondition_voltage > 2.0) || (precondition_voltage < 1.5))
                {
                    MessageBox.Show("The entered precondition voltage is out of range (1.5 to 2.0).");
                    return;
                }

                if (double.IsInfinity(termination_voltage) | double.IsNaN(termination_voltage))
                {
                    termination_voltage = 2.4;
                }
                if ((termination_voltage > 2.5) || (termination_voltage < 2.1) || (termination_voltage < precondition_voltage))
                {
                    MessageBox.Show("The entered termination_voltage is out of range (termination_voltage from 2.1V to 2.5V).");
                    return;
                }

                if (double.IsInfinity(float_voltage) | double.IsNaN(float_voltage))
                {
                    float_voltage = 2.35;
                }
                if ((float_voltage > 2.5) || (float_voltage < 2.1) || (float_voltage < precondition_voltage))
                {
                    MessageBox.Show("The entered float_voltage is out of range (float_voltage from 2.1V to 2.5V).");
                    return;
                }

                if (double.IsInfinity(float_current) | double.IsNaN(float_current))
                {
                    float_current = 0.100;
                }
                if ((float_current > termination_current) || (float_current < 0.05))
                {
                    MessageBox.Show("The entered float_current is out of range (float_current from 0.05A to termination current).");
                    return;
                }

                if (double.IsInfinity(charge_current) | double.IsNaN(charge_current))
                {
                    charge_current = 2.0;    // Check if the charge_current is currently at Infinity and correct
                }
                if ((charge_current > 10.0) || (charge_current < 0.200))
                {
                    MessageBox.Show("The entered charge current is out of range (0.200 to 10.0).");
                    return;
                }

                if (double.IsInfinity(precondition_current) | double.IsNaN(precondition_current))
                {
                    precondition_current = 0.1;    // Check if the precondition_current is currently at Infinity and correct
                }
                if ((precondition_current > charge_current) || (precondition_current < 0.050))
                {
                    MessageBox.Show("The entered restoration current is out of range (0.050 to Charge Current).");
                    return;
                }

                if (double.IsInfinity(termination_current) | double.IsNaN(termination_current))
                {
                    termination_current = 0.4;    // Check if the termination_current is currently at Infinity and correct
                }
                if ((termination_current > charge_current) || (termination_current < 0.050))
                {
                    MessageBox.Show("The entered trickle current is out of range (0.050 to Charge Current).");
                    return;
                }


                if (double.IsInfinity(restoration_time) | double.IsNaN(restoration_time))
                {
                    restoration_time = 60;
                }
                if (((restoration_time > maximum_charge_time) && (maximum_charge_time > 0)) || (restoration_time < 1) || (restoration_time > 273))
                {
                    MessageBox.Show("The entered restoration/trickle time is out of range (the lesser of 1 to 273 minutes or maximum charge time).");
                    return;
                }
            }
            else if (Chemistry == "LiFePO4")
            {
                st_chemistry = 4;

                if (double.IsInfinity(cell_voltage) | double.IsNaN(cell_voltage))
                {
                    cell_voltage = 3.6;    // Check if the cell_voltage is currently at Infinity and correct
                }
                if ((cell_voltage > 3.7) || (cell_voltage < 2.0))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (2.0 to 3.7).");
                    return;
                }

                if (double.IsInfinity(number_of_cells) | double.IsNaN(number_of_cells))
                {
                    number_of_cells = 2;    // Check if the number_of_cells is currently at Infinity and correct
                }
                if ((number_of_cells > 6.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 6).");
                    return;
                }

                if (double.IsInfinity(precondition_voltage) | double.IsNaN(precondition_voltage))
                {
                    precondition_voltage = 1.8;    // Check if the precondition_voltage is currently at Infinity and correct
                }
                if ((precondition_voltage > 3.2) || (precondition_voltage < 1.5))
                {
                    MessageBox.Show("The entered precondition voltage is out of range (1.5 to 3.2).");
                    return;
                }

                if (double.IsInfinity(charge_current) | double.IsNaN(charge_current))
                {
                    charge_current = 2.0;    // Check if the charge_current is currently at Infinity and correct
                }
                if ((charge_current > 10.0) || (charge_current < 0.200))
                {
                    MessageBox.Show("The entered charge current is out of range (0.200 to 10.0).");
                    return;
                }

                if (double.IsInfinity(precondition_current) | double.IsNaN(precondition_current))
                {
                    precondition_current = 0.1;    // Check if the precondition_current is currently at Infinity and correct
                }
                if ((precondition_current > charge_current) || (precondition_current < 0.050))
                {
                    MessageBox.Show("The entered precondition current is out of range (0.050 to Charge Current).");
                    return;
                }

                if (double.IsInfinity(termination_current) | double.IsNaN(termination_current))
                {
                    termination_current = 0.1;    // Check if the termination_current is currently at Infinity and correct
                }
                if ((termination_current > charge_current) || (termination_current < 0.050))
                {
                    MessageBox.Show("The entered termination current is out of range (0.050 to Charge Current).");
                    return;
                }

                if (double.IsInfinity(termination_voltage) | double.IsNaN(termination_voltage))
                {
                    termination_voltage = 3.5;
                }
                if ((termination_voltage > 4.1) || (termination_voltage < 2.9) || (termination_voltage < precondition_voltage))
                {
                    MessageBox.Show("The entered termination_voltage is out of range (termination_voltage frpm 2.9V to 4.1V).");
                    return;
                }
            }
            else if (Chemistry == "NiMH")
            {
                st_chemistry = 1;

                if (double.IsInfinity(cell_voltage) | double.IsNaN(cell_voltage))
                {
                    cell_voltage = 1.8;    // Check if the cell_voltage is currently at Infinity and correct
                }
                if ((cell_voltage > 2.0) || (cell_voltage < 1.0))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (1.0 to 2.0).");
                    return;
                }

                if (double.IsInfinity(termination_voltage) | double.IsNaN(termination_voltage))
                {
                    termination_voltage = 1.8;
                }
                if ((termination_voltage > 2.0) || (termination_voltage < 1.5) || (termination_voltage < precondition_voltage))
                {
                    MessageBox.Show("The entered termination_voltage is out of range (termination_voltage frpm 1.5V to 2.50).");
                    return;
                }

                if (double.IsInfinity(number_of_cells) | double.IsNaN(number_of_cells))
                {
                    number_of_cells = 2;    // Check if the number_of_cells is currently at Infinity and correct
                }
                if ((number_of_cells > 12.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 12).");
                    return;
                }

                if (double.IsInfinity(precondition_voltage) | double.IsNaN(precondition_voltage))
                {
                    precondition_voltage = 0.8;    // Check if the precondition_voltage is currently at Infinity and correct
                }
                if ((precondition_voltage > 1.0) || (precondition_voltage < 0.7))
                {
                    MessageBox.Show("The entered precondition voltage is out of range (0.7 to 1.0).");
                    return;
                }

                if (double.IsInfinity(charge_current) | double.IsNaN(charge_current))
                {
                    charge_current = 2.0;    // Check if the charge_current is currently at Infinity and correct
                }
                if ((charge_current > 6.0) || (charge_current < 0.400))
                {
                    MessageBox.Show("The entered charge current is out of range (0.400 to 6.0).");
                    return;
                }

                if (double.IsInfinity(precondition_current) | double.IsNaN(precondition_current))
                {
                    precondition_current = 0.1;    // Check if the precondition_current is currently at Infinity and correct
                }
                if ((precondition_current > charge_current) || (precondition_current < 0.100))
                {
                    MessageBox.Show("The entered restoration current is out of range (0.100 to Charge Current).");
                    return;
                }

                if (double.IsInfinity(termination_current) | double.IsNaN(termination_current))
                {
                    termination_current = 0.1;    // Check if the termination_current is currently at Infinity and correct
                }
                if ((termination_current > charge_current) || (termination_current < 0.0))
                {
                    MessageBox.Show("The entered trickle current is out of range (0 to Charge Current).");
                    return;
                }


                /*if (double.IsInfinity(restoration_time) | double.IsNaN(restoration_time)) //%%BRYAN%% 2-4-20 removing this because this chemistry makes no use of this timer in FW yet. If ever.
                {
                    restoration_time = 0;
                }
                if (restoration_time != 0)
                {
                    restoration_time = 0;
                }*/

                if (!temp_sense_en)
                {
                    MessageBox.Show("NiMH chemistry requires a temp sensor be enabled.");
                    return;
                }
            }
            else if (Chemistry == "Super Capacitor")
            {
                st_chemistry = 5;

                if (double.IsInfinity(cell_voltage) | double.IsNaN(cell_voltage))
                {
                    cell_voltage = 2.5;    // Check if the cell_voltage is currently at Infinity and correct
                }
                if ((cell_voltage > 2.8) || (cell_voltage < 1.0))
                {
                    MessageBox.Show("The entered cell voltage is out of the range (1.0 to 2.8).");
                    return;
                }

                if (double.IsInfinity(number_of_cells) | double.IsNaN(number_of_cells))
                {
                    number_of_cells = 2;    // Check if the number_of_cells is currently at Infinity and correct
                }
                if ((number_of_cells > 8.0) || (number_of_cells < 1.0))
                {
                    MessageBox.Show("The entered number of cells is out of range (1 to 8).");
                    return;
                }

                if (double.IsInfinity(charge_current) | double.IsNaN(charge_current))
                {
                    charge_current = 2.0;    // Check if the charge_current is currently at Infinity and correct
                }
                if ((charge_current > 6.0) || (charge_current < 0.100))
                {
                    MessageBox.Show("The entered charge current is out of range (0.100 to 6.0).");
                    return;
                }
            }
            else 
            {
                MessageBox.Show("Unknown chemistry chosen.");
                return;
            }
            #endregion

            #region Convert the local values converted from the text boxes and push them into the string values.
            /* Settings for the GUI or regenerating run constants in Flash */
            st_cell_voltage             = Convert.ToUInt16(cell_voltage         * 1000.0    );
            st_number_of_cells          = Convert.ToUInt16(number_of_cells                  );
            st_precondition_voltage     = Convert.ToUInt16(precondition_voltage * 1000      );
            st_precondition_current     = Convert.ToUInt16(precondition_current * 1000      );
            st_charge_current           = Convert.ToUInt16(charge_current       * 1000      );
            st_termination_current      = Convert.ToUInt16(termination_current  * 1000      );
            //st_maximum_charge_time      = Convert.ToUInt16(maximum_charge_time  * 60        );
            //st_rapid_time_max           = Convert.ToUInt16(rapid_charge_time    * 60        );
            //st_restore_time_max         = Convert.ToUInt16(restoration_time     * 60        );
            st_minimum_temperature      = Convert.ToInt16(minimum_temperature               );
            st_maximum_temperature      = Convert.ToInt16(maximum_temperature               );
            st_termination_voltage      = Convert.ToUInt16(termination_voltage  * 1000      );
            st_wire_resistance          = Convert.ToUInt16(wire_resistance                  );
            st_UVLO_rising_voltage      = Convert.ToUInt16(pack_uvlo_rising     * 1000      );
            st_UVLO_falling_voltage     = Convert.ToUInt16(pack_uvlo_falling    * 1000      );
            st_float_voltage            = Convert.ToUInt16(float_voltage        * 1000      );
            st_float_current            = Convert.ToUInt16(float_current        * 1000      );
            st_over_voltage             = Convert.ToUInt16(over_voltage         * 1000      );
            //st_negative_dvdt_count      = Convert.ToInt16(negative_dvdt_count               );
            //st_cc_positive_dvdt_count   = Convert.ToUInt16(cc_positive_dvdt_count           );
            //st_cv_negative_didt_count   = Convert.ToInt16(cv_negative_didt_count            );
            st_dtdt_slope               = Convert.ToInt16(dtdt_slope            * 100       );
            //st_dvdt_blank_time          = Convert.ToUInt16(dvdt_blank_time       * 60       );
            st_temperature_cal_ADC_size = Convert.ToUInt16(temperature_cal_ADC_size         );
            st_temperature_cal_ADC_vref = Convert.ToUInt16(temperature_cal_ADC_vref * 100   );
            st_temperature_cal_slope    = Convert.ToUInt16(temperature_cal_slope * 1000     );
            #endregion

            #region Convert the local values into the proper format to be stuffed into the array for sending to flash
            // Start populating the values to be loaded into the flash for configuration settings
            cf_chemistry                = Convert.ToByte(st_chemistry);
            cf_vbat_ov                  = Convert.ToUInt16(pack_ov * vbatslope[3] + vbatintercept[3]);
            cf_vbat_cv                  = Convert.ToUInt16(pack_termvoltage * vbatslope[3] + vbatintercept[3]);
            cf_ibat_cc                  = Convert.ToUInt16(charge_current * ibatslope[3] + ibatintercept[3]);
            cf_ibat_ct                  = Convert.ToUInt16(termination_current * ibatslope[3] + ibatintercept[3]);
            cf_ibat_fc                  = Convert.ToUInt16(float_current * ibatslope[3] + ibatintercept[3]);
            cf_charge_time_max          = Convert.ToUInt16(maximum_charge_time * 60.0);
            cf_adc_uvlo_threshold_off   = Convert.ToUInt16(pack_uvlo_falling * vinslope[3] + vinintercept[3]);
            cf_adc_uvlo_threshold_on    = Convert.ToUInt16(pack_uvlo_rising * vinslope[3] + vinintercept[3]);
            cf_restore_time_max         = Convert.ToUInt16(restoration_time * 60);
            cf_dvdt_blank_time          = Convert.ToUInt16(dvdt_blank_time * 60);
            cf_rapid_time_max           = Convert.ToUInt16(rapid_charge_time * 60);
            cf_vbat_fv                  = Convert.ToUInt16(pack_floatvoltage * vbatslope[3] + vbatintercept[3]);
            cf_neg_dvdt                 = Convert.ToInt16(negative_dvdt_count);
            cf_pos_dvdt_cc              = Convert.ToUInt16(cc_positive_dvdt_count);
            cf_neg_didt_cv              = Convert.ToInt16(cv_negative_didt_count);
            cf_precondition_time_max    = Convert.ToUInt16(precondition_charge_time * 60.0);
            cf_dvdt_pc                  = Convert.ToUInt16(pc_dvdt_count);
            if (temp_sense_en)  //set cf_temp_sense_en
            {
                cf_temp_sense_en = 1;
            }   
            else
            {
                cf_temp_sense_en = 0;
            }
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

#region Some hardware specific case switch calculations for setting the output voltage reference min and max
            /* %%BRYAN%% this is going to be ugly below and needs to be broken out to a hardware specific routine.  For now we're going to switch
             * this so that it will use the correct setting for calculating the OVFCON and OVCCON values and various versions of the input UVLO.  
             * For instance The MCP19118 four switch board doesn't feed a current into that amplifier, but an output voltage instead.  
             * And other chips use different formulas.*/

            double d;
            switch (profile_data[27]) //Match up to the hardware board selected
            {
                case 4: //This is the MCP19118 4 switch buck boost (really 3 switch 1 diode) EVK.  It's voltage output regulation so different than the default case.
                    //d = Convert.ToDouble(cf_vbat_ov) * 5.0 / 4095.0;
                    //d = (d * 1000.0 / 15.8) + 2.0; //The datasheet calls out a -1, instead of a +2.  This is actually a +3 value being added for margin.
                    //if (d < 0.0) d = 0.0;
                    //if (d > 255.0) d = 255.0;
                    //cf_ovcfcon_max = Convert.ToByte(d);
                    cf_ovcfcon_max = 255;

                    //d = Convert.ToDouble(cf_vbat_pc) * 5.0 / 4095.0;
                    //d = (d * 1000.0 / 15.8) - 8.0; //The datasheet calls out a -1, instead of a -8.  This is actually an extra -7 being added for margin when controlling float current.
                    //if (d < 0.0) d = 0.0;
                    //if (d > 255.0) d = 255.0;
                    //cf_ovcfcon_min = Convert.ToByte(d);
                    cf_ovcfcon_min = 1; //This is a freewheeling hardware design so duty cycle should be allowed to be set to minimum to support the lowest float and restoration currents.

                    //right now the two values below are not being used by the firmware.  I decided it would be better for the firmware to have a fast hardware cutoff around 6V.  The ADC
                    //based UVLO shutoff is adequate for now.
                    cf_uvlo_threshold_off = Convert.ToByte(26.5 * Math.Log(pack_uvlo_falling / 4.0)); //formula per MCP1911X datasheet 
                    cf_uvlo_threshold_on = Convert.ToByte(26.5 * Math.Log(pack_uvlo_rising / 4.0));  //formula per MCP1911X datasheet 

                    break;

                case 6: //This is the ADM00745 MCP19125 Flyback Charger. Setup for 3S Li+. //%%BRYAN%% Warning this can break any other battery combination on startup.
                    d = Convert.ToDouble(cf_ibat_cc) * 4.096 / 4096.0;
                    d = (d * 255) / (1.23 * 2); //N = (VREF * 255) / (1.23V_BG * 10_Gain) //%%BRYAN%% The datasheet says 1.23V, but the HW is scaling to 2.46V like it does for OVREFCON.
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_max = Convert.ToByte(d);
                    //cf_ovcfcon_max = 0xff; //for test

                    cf_ovrefcon_cv = Convert.ToUInt16((pack_termvoltage * 255 * 0.1304) / (2 * 1.23));
                    //cf_ovrefcon_cv = 0xff; //for test
                    cf_ovrefcon_ov = Convert.ToUInt16((pack_ov * 255 * 0.1304) / (2 * 1.23));
                    cf_vrefcon_max = cf_ovcfcon_max;

                    cf_uvlo_threshold_off = Convert.ToByte(35.49 * Math.Log(pack_uvlo_falling / 3.57)); //formula per MCP19124/5 datasheet
                    cf_uvlo_threshold_on = Convert.ToByte(35.49 * Math.Log(pack_uvlo_rising / 3.57));  //formula per MCP19124/5 datasheet

                    break;

                case 10: //This is the pic16f1779 hybrid starter kit
                    d = Convert.ToDouble(cf_ibat_cc) * 5.0 / 4095.0;
                    d = d / 2.048;
                    d = d * 1024;
                    if (d < 0.0) d = 0.0;
                    if (d > 1024.0) d = 1024;
                    cf_ovcfcon_max = Convert.ToUInt16(d);
                    cf_vrefcon_max = cf_ovcfcon_max;
                    break;

                case 5: //This covers the MCP19123
                    d = Convert.ToDouble(cf_ibat_cc) * 5.0 / 4095.0;
                    d = (d * 1000.0 / 15.8) + 2.0; //This doesn't agree with the datasheet.  The datasheet has a -1 isntead of a +2.  This is actually a +3 value being added for margin.
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_max = Convert.ToByte(d);

                    d = ibatintercept[3] * 5.0 / 4095.0;
                    d = (d * 1000.0 / 15.8) - 2.0; //This doesn't agree with the datasheet. The datasheet has a -1 isntead of a -2. This is actually an extra -1 being added for margin
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_min = Convert.ToByte(d);
                    cf_vrefcon_max = cf_ovcfcon_max;

                    if ((pack_uvlo_falling - 4) / 2 < 0)
                    {
                        cf_uvlo_threshold_off = 0;
                    }
                    else
                    {
                        cf_uvlo_threshold_off = Convert.ToByte((pack_uvlo_rising - 4) / 2); //Should do a decent job of matching up to the VINUVLO lookup table
                    }
                    if ((pack_uvlo_falling - 4) / 2 < 0)
                    {
                        cf_uvlo_threshold_on = 0;
                    }
                    else
                    {
                        cf_uvlo_threshold_on = Convert.ToByte((pack_uvlo_rising - 4) / 2); //Should do a decent job of matching up to the VINUVLO lookup table
                    }
                    break;

                default: //This covers the MCP19111 derivative boards that use the same forumula for current output regulation.
                    d = Convert.ToDouble(cf_ibat_cc) * 5.0 / 4095.0;
                    d = (d * 1000.0 / 15.8) + 2.0; //This doesn't agree with the datasheet.  The datasheet has a -1 isntead of a +2.  This is actually a +3 value being added for margin.
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_max = Convert.ToByte(d);

                    d = ibatintercept[3] * 5.0 / 4095.0;
                    d = (d * 1000.0 / 15.8) - 2.0; //This doesn't agree with the datasheet. The datasheet has a -1 isntead of a -2. This is actually an extra -1 being added for margin
                    if (d < 0.0) d = 0.0;
                    if (d > 255.0) d = 255.0;
                    cf_ovcfcon_min = Convert.ToByte(d);
                    cf_vrefcon_max = cf_ovcfcon_max;

                    cf_uvlo_threshold_off = Convert.ToByte(26.5 * Math.Log(pack_uvlo_falling / 4.0)); //formula per MCP1911X datasheet 
                    cf_uvlo_threshold_on = Convert.ToByte(26.5 * Math.Log(pack_uvlo_rising / 4.0));  //formula per MCP1911X datasheet 
                    break;
            }
#endregion

#region Calculations for temperature sensing compensation (if present)
            if (!temp_sense_en)
            {
                cf_dtdt_slope    = 0;
                cf_pack_temp_min = 0;
                cf_pack_temp_max = 4095;
                cf_pack_temp_25C = 0;
                cf_temp_1C = 4095;
                cf_vbat_1C_adjust = 0;
            }
            else
            {
                cf_dtdt_slope     = Convert.ToInt16(temperature_adc_slope * dtdt_slope);
                cf_pack_temp_min  = Convert.ToUInt16((minimum_temperature - temperature_cal_celsius) * temperature_adc_slope + temperature_cal);
                cf_pack_temp_max  = Convert.ToUInt16((maximum_temperature - temperature_cal_celsius) * temperature_adc_slope + temperature_cal);
                cf_pack_temp_25C  = Convert.ToUInt16((25 - temperature_cal_celsius) * temperature_adc_slope + temperature_cal);
                cf_temp_1C        = Convert.ToUInt16(Math.Abs(temperature_adc_slope));  // The slope was calculated out as the inputted slope divided by (Vref / 4095) or ADC/degree-Celsius
                cf_vbat_1C_adjust = Convert.ToUInt16(vbatslope[3] * temperature_coeff);  // The slope was calculated out empirically as ADC/V. Multiplying by the coeff gives the increment in target per degree C.
            }
#endregion
            
#endregion

            #region Debug String Prints
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
            Debug.WriteLine(string.Format("VREFCON_MAX: {0}", cf_vrefcon_max)); //MCP19125 specific - effectively max output current
            Debug.WriteLine(string.Format("Float Voltage: {0}", cf_vbat_fv));
            Debug.WriteLine(string.Format("Negative dV/dt: {0}", cf_neg_dvdt));
            Debug.WriteLine(string.Format("Positive dV/dt in CC: {0}", cf_pos_dvdt_cc));
            Debug.WriteLine(string.Format("Negative dI/dt in CV: {0}", cf_neg_didt_cv));
#endregion

            #region Clear the configuration_data and verification_data arrays and populate the configuration_data
            for (i = 0; i < 128; i++)
            {
                configuration_data[i] = 0xFF;
                configuration_data_offset[i] = 0xFF;
                verification_data[i] = 0xFF;
            }

            SetConfigurationData(0,  cf_uvlo_threshold_off);
            SetConfigurationData(1,  cf_uvlo_threshold_on);
            SetConfigurationData(2,  cf_vbat_ov);
            SetConfigurationData(3,  cf_vbat_pc);
            SetConfigurationData(4,  cf_vbat_cv);
            SetConfigurationData(5,  cf_ibat_pc);
            SetConfigurationData(6,  cf_ibat_cc);
            SetConfigurationData(7,  cf_ibat_ct);
            SetConfigurationData(8, cf_ovcfcon_min);
            SetConfigurationData(9, cf_ovcfcon_max);
            SetConfigurationData(10, cf_adc_uvlo_threshold_off);
            SetConfigurationData(11, cf_adc_uvlo_threshold_on);
            SetConfigurationData(12, cf_restore_time_max);
            SetConfigurationData(13, cf_dvdt_blank_time);
            SetConfigurationData(14, cf_rapid_time_max);
            SetConfigurationData(15, (ushort)cf_dtdt_slope);
            SetConfigurationData(16, cf_pack_temp_min);
            SetConfigurationData(17, cf_pack_temp_max);
            SetConfigurationData(18, cf_chemistry);
            SetConfigurationData(19, cf_ovrefcon_ov);
            SetConfigurationData(20, cf_ovrefcon_cv);
            SetConfigurationData(21, cf_vrefcon_max);
            SetConfigurationData(22, cf_vbat_fv);
            SetConfigurationData(23, (ushort)cf_neg_dvdt);
            SetConfigurationData(24, cf_pos_dvdt_cc);
            SetConfigurationData(25, (ushort)cf_neg_didt_cv);
            SetConfigurationData(26, cf_pack_temp_25C);
            SetConfigurationData(27, cf_temp_1C);
            SetConfigurationData(28, cf_temp_sense_en);
            SetConfigurationData(29, cf_ibat_fc);
            SetConfigurationData(30, cf_precondition_time_max);
            SetConfigurationData(31, cf_dvdt_pc);
            SetConfigurationData(32, cf_vbat_1C_adjust);
            SetConfigurationData(33,  (ushort)(cf_charge_time_max & 0x00ff));
            SetConfigurationData(34,  (ushort)((cf_charge_time_max >> 8) & 0x00ff));
            SetConfigurationData(38, st_cell_voltage);
            SetConfigurationData(39, (ushort)(st_number_of_cells));
            SetConfigurationData(40, st_precondition_voltage);
            SetConfigurationData(41, st_precondition_current);
            SetConfigurationData(42, st_charge_current);
            SetConfigurationData(43, st_termination_current);
            SetConfigurationData(44, st_temperature_cal_ADC_vref);
            SetConfigurationData(45, st_temperature_cal_ADC_size);
            SetConfigurationData(46, st_temperature_cal_slope);
            SetConfigurationData(47, (ushort)st_minimum_temperature);
            SetConfigurationData(48, (ushort)st_maximum_temperature);
            SetConfigurationData(49, st_termination_voltage);
            SetConfigurationData(50, st_wire_resistance);
            SetConfigurationData(51, st_float_voltage);
            SetConfigurationData(52, st_over_voltage);
            SetConfigurationData(53, (ushort)st_dtdt_slope);
            SetConfigurationData(54, st_UVLO_rising_voltage);
            SetConfigurationData(55, st_UVLO_falling_voltage);
            SetConfigurationData(56, st_float_current);

            #endregion

            #region Send the array over to the part, read, compare, issue a reboot
            Debug.WriteLine(script);

            b = Serial_Write((ushort)(Flash_Access | Flash_Config_Offset), 64, ref configuration_data);

            if (b == false)
            {
                b = false;   // Debugging breakpoint
                MessageBox.Show("Could not write configuration data to battery charger.");
                return;
            }

            for (i=0; i < 64; i++)
            {
                configuration_data_offset[i] = configuration_data[i + 64];
            }

            b = Serial_Write((ushort)(Flash_Access | Flash_Config_Offset + Flash_Config_Offset), 64, ref configuration_data_offset);

            if (b == false)
            {
                b = false;   // Debugging breakpoint
                MessageBox.Show("Could not write configuration data to battery charger.");
                return;
            }

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
#endregion
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
            string f;

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

                    handle = mcp2221_dll_m.MCP2221.M_Mcp2221_OpenByIndex(0x04D8, 0x00DD, nMCP2221 - 1);
                    if ((int)(handle) < 0)
                    {
                        MessageBox.Show("Could not initialize MCP2221A Device.");
                        initialized = false;
                        return initialized;
                    }
                    e = mcp2221_dll_m.MCP2221.M_Mcp2221_GetFirmwareRevision(handle);

                    f = mcp2221_dll_m.MCP2221.M_Mcp2221_GetHardwareRevision(handle);

                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_SetSpeed(handle, 400000);
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

        private bool Serial_Read(ushort memaddress, byte bytestoread, ref byte[] dataarray)
        {
            bool b;
            int c;

            if (Init_Serial() != true)
            {
                MessageBox.Show("Serial Device Not Initialized");
                return false;
            }


            switch (serial_device)
            {
                case (1):
                    b = PICkitS.I2CM.Read(smbusaddr, (byte) ((memaddress >> 8) & 0xFF), (byte) (memaddress & 0xFF), bytestoread, ref dataarray, ref script);
                    if (b == false)
                    {
                        //MessageBox.Show("Could not complete Read.");
                        return false;
                    }
                    break;
                case (2):
                    byte[] InBuff = new byte[2];
                    InBuff[0] = (byte)((memaddress >> 8) & 0xFF); 
                    InBuff[1] = (byte)(memaddress & 0xFF);
                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_I2cWrite(handle, 2, smbusaddr, 0, InBuff);
                    if (c != 0)
                    {
                        MessageBox.Show(string.Format("Could not complete Write to Start Read. {0}", c));
                        mcp2221_dll_m.MCP2221.M_Mcp2221_Close(handle);
                        return false;
                    }
                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_I2cRead(handle, bytestoread, smbusaddr, 0, dataarray);
                    if (c != 0)
                    {
                        MessageBox.Show(string.Format("Could not complete Read. {0}", c));
                        mcp2221_dll_m.MCP2221.M_Mcp2221_Close(handle);
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
                    b = PICkitS.I2CM.Write(smbusaddr, (byte)((memaddress >> 8) & 0xFF), (byte)(memaddress & 0xFF), bytestowrite, ref dataarray, ref script);
                    if (b == false)
                    {
                        //MessageBox.Show("Could not complete Write.");
                        return false;
                    }
                    break;
                case (2):
                    byte[] OutBuff = new byte[dataarray.Length + 2];
                    OutBuff[0] = (byte) ((memaddress >> 8) & 0xFF); 
                    OutBuff[1] = (byte)(memaddress & 0xFF);
                    for (int i = 2; i < OutBuff.Length; i++)
                    {
                        OutBuff[i] = dataarray[i - 2];
                    }
                    c = mcp2221_dll_m.MCP2221.M_Mcp2221_I2cWrite(handle, (byte)(bytestowrite + 2), smbusaddr, 0, OutBuff);
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
            // Note at present (2019) the firmware does nothing with commands 0x07, 0x08, and 0x09, they're available for other functions in the future.

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

            for (i = 0; i < 128; i++)
            {
                configuration_data[i] = 0xff;
            }
            b = Serial_Read((ushort)((Profile_Access | Settings_Access)+68), 4, ref configuration_data);

            //Debug.WriteLine(script);

            if (b == false)
            {
                MessageBox.Show("Could not read firmware revision from battery charger.");
                return false;
            }

            int fwrev = ((ushort)configuration_data[2] | ((ushort)configuration_data[3] << 8));

            labelFWRev.Text = string.Format("ver: {0:X3}", fwrev);

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

            return true;
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
            Serial_Read((ushort)(SFR_Access | (SFRaddr)), 1, ref SFRread);
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
            ushort[] Flashbuffer = new ushort[1];                               // is added to the calibration address offset in the serial stack. 
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
            Serial_Read((ushort)(Flash_Access | (FlashAddr & 0x60)), 64, ref Flashread);
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
            Serial_Write((ushort)(Flash_Access | (FlashAddr & 0x60)), 64, ref Flashwrite);
            Serial_Read((ushort)(Flash_Access | (FlashAddr & 0x60)), 64, ref Flashread);
            for (i=0; i<64; i++)
            {
                if (Flashwrite[i] != Flashread[i])
                {
                    i = 64;
                    MessageBox.Show("Error: Verification Read shows unexpected value");
                }
            }
        }

        private void SFR_Drop_Down_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((profile_data[27] == 1) | (profile_data[27] == 4) | (profile_data[27] == 7))
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

        #endregion

        private void buttonReadSettingsStructure_Click(object sender, EventArgs e)
        {
            bool b = true;
            int i;

            if (!Init_Serial())
            {
                return;
            }
            for (i = 0; i < 128; i++)
            {
                configuration_data[i] = 0xff;
            }
            b = Serial_Read((ushort)(Settings_Access), 2*39, ref configuration_data);  //The first 34 bytes of the struct cs in the firmware 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}