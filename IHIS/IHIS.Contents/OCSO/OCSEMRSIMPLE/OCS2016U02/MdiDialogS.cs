﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSO
{
    public partial class MdiDialogS : Form
    {
        private readonly OCS2016U02 mainScreen;

        private readonly OCS2015U21S patientBox;

        public MdiDialogS(OCS2016U02 mainScreen)
        {
            this.mainScreen = mainScreen;
            InitializeComponent();
            patientBox = new OCS2015U21S(mainScreen);
            Size screenSize = patientBox.Size;
            Size regionSize = this.pnlMain.Size;
            int dWidth = screenSize.Width - regionSize.Width;
            int dHeight = screenSize.Height - regionSize.Height;
            Size += new Size(dWidth, dHeight);

            //Dock Fill, Panel에 Add
            patientBox.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(patientBox);

            //Raise close form event
            this.patientBox.OnCloseParentForm += patientBox_OnCloseParentForm;
            this.ShowIcon = false;
            //this.Text = "患者リスト";
        }

        protected override void OnShown(EventArgs e)
        {
            patientBox.CboGwa.SetDataValue(UserInfo.Gwa);
            patientBox.FbxDoctor.SetEditValue(UserInfo.DoctorID);
            patientBox.DbxDoctor_name.SetDataValue(UserInfo.UserName);
            patientBox.PaBox.Reset();
            patientBox.PatientListQuery(mainScreen.DtpNaewonDate.GetDataValue(),
                            patientBox.CboGwa.GetDataValue(),
                            patientBox.FbxDoctor.GetDataValue(),
                            patientBox.PaBox.BunHo);

            //patientBox.PatientListQuery(mainScreen.DtpNaewonDate.GetDataValue(),
            //                patientBox.CboQryGwa.GetDataValue(),
            //                patientBox.CboQryDoctor.GetDataValue());
        }

        void patientBox_OnCloseParentForm(object sender, EventArgs e)
        {
            this.Close();
            //this.Hide();
        }

        public OCS2015U21S PatientBox
        {
            get
            {
                return patientBox;
            }
        }
    }
}