#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Specialized;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.OCSO.Properties;
#endregion

namespace IHIS.OCSO
{
    public class DOC4003U00 : IHIS.Framework.XScreen
    {
        #region Auto-gen code

        private XLabel xLabel1;
        private XLabel xLabel2;
        private XLabel xLabel3;
        private XLabel xLabel4;
        private XLabel xLabel5;
        private XTextBox txtTo_hospital_info;
        private XTextBox txtTo_sinryouka;
        private XTextBox txtTo_doctor;
        private XTextBox txtDisease;
        private XLabel xLabel6;
        private XLabel xLabel8;
        private XTextBox txtCheckup_opinion;
        private XPanel pnlRight;
        private XEditGridCell xEditGridCell11;
        private XDataWindow dwDoc4001;
        private XPanel pnlMain;
        private XPanel pnlBottom;
        private XButtonList btnList;
        private XPanel pnlTop;
        private XLabel xLabel9;
        private XPatientBox paBox;
        private XDatePicker dtpWriteDate;
        private XEditGrid grdDOC4003;
        private XFlatLabel xFlatLabel4;
        private XFlatLabel xFlatLabel3;
        private XFlatLabel xFlatLabel2;
        private XFlatLabel xFlatLabel1;
        private XFlatLabel xFlatLabel9;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XFlatLabel lblTelFax;
        private XFlatLabel lblOf;
        private XFlatLabel lblAddress;
        private XFlatLabel lblPost;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell14;
        private XPanel pnlLeft;
        private XTextBox txtTel;
        private XTextBox txtJob;
        private XTextBox txtZip;
        private XTextBox txtBirth;
        private XFlatLabel xFlatLabel8;
        private XFlatLabel xFlatLabel10;
        private XFlatLabel xFlatLabel11;
        private XFlatLabel xFlatLabel7;
        private XFlatLabel xFlatLabel6;
        private XFlatLabel xFlatLabel5;
        private XTextBox txtSex;
        private XTextBox txtGwa;
        private XTextBox txtSuname;
        private XTextBox txtDoctor;
        private XTextBox txtHosp_tel;
        private XTextBox txtHosp_info;
        private XTextBox txtHosp_address;
        private XTextBox txtHosp_zip;
        private XTextBox txtAddress;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private MultiLayout layDataWindow;
        private XTextBox txtTo_doctor2;
        private XTextBox txtTo_sinryouka2;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XTextBox txtPrescription;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DOC4003U00));
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.txtTo_hospital_info = new IHIS.Framework.XTextBox();
            this.txtTo_sinryouka = new IHIS.Framework.XTextBox();
            this.txtTo_doctor = new IHIS.Framework.XTextBox();
            this.txtDisease = new IHIS.Framework.XTextBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.txtCheckup_opinion = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtPrescription = new IHIS.Framework.XTextBox();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.txtTo_doctor2 = new IHIS.Framework.XTextBox();
            this.txtTo_sinryouka2 = new IHIS.Framework.XTextBox();
            this.txtGwa = new IHIS.Framework.XTextBox();
            this.txtDoctor = new IHIS.Framework.XTextBox();
            this.txtHosp_tel = new IHIS.Framework.XTextBox();
            this.txtHosp_info = new IHIS.Framework.XTextBox();
            this.txtHosp_address = new IHIS.Framework.XTextBox();
            this.txtHosp_zip = new IHIS.Framework.XTextBox();
            this.txtTel = new IHIS.Framework.XTextBox();
            this.txtJob = new IHIS.Framework.XTextBox();
            this.txtAddress = new IHIS.Framework.XTextBox();
            this.txtZip = new IHIS.Framework.XTextBox();
            this.txtBirth = new IHIS.Framework.XTextBox();
            this.xFlatLabel8 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel10 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel11 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel7 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel6 = new IHIS.Framework.XFlatLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.dwDoc4001 = new IHIS.Framework.XDataWindow();
            this.dtpWriteDate = new IHIS.Framework.XDatePicker();
            this.xFlatLabel4 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel5 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel9 = new IHIS.Framework.XFlatLabel();
            this.lblTelFax = new IHIS.Framework.XFlatLabel();
            this.lblOf = new IHIS.Framework.XFlatLabel();
            this.lblAddress = new IHIS.Framework.XFlatLabel();
            this.lblPost = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.txtSex = new IHIS.Framework.XTextBox();
            this.txtSuname = new IHIS.Framework.XTextBox();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.pnlMain = new IHIS.Framework.XPanel();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdDOC4003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.layDataWindow = new IHIS.Framework.MultiLayout();
            this.pnlRight.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDOC4003)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDataWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // txtTo_hospital_info
            // 
            this.txtTo_hospital_info.AccessibleDescription = null;
            this.txtTo_hospital_info.AccessibleName = null;
            resources.ApplyResources(this.txtTo_hospital_info, "txtTo_hospital_info");
            this.txtTo_hospital_info.BackgroundImage = null;
            this.txtTo_hospital_info.Name = "txtTo_hospital_info";
            this.txtTo_hospital_info.Tag = "1";
            // 
            // txtTo_sinryouka
            // 
            this.txtTo_sinryouka.AccessibleDescription = null;
            this.txtTo_sinryouka.AccessibleName = null;
            resources.ApplyResources(this.txtTo_sinryouka, "txtTo_sinryouka");
            this.txtTo_sinryouka.BackgroundImage = null;
            this.txtTo_sinryouka.Name = "txtTo_sinryouka";
            this.txtTo_sinryouka.Tag = "1";
            // 
            // txtTo_doctor
            // 
            this.txtTo_doctor.AccessibleDescription = null;
            this.txtTo_doctor.AccessibleName = null;
            resources.ApplyResources(this.txtTo_doctor, "txtTo_doctor");
            this.txtTo_doctor.BackgroundImage = null;
            this.txtTo_doctor.Name = "txtTo_doctor";
            this.txtTo_doctor.Tag = "1";
            // 
            // txtDisease
            // 
            this.txtDisease.AccessibleDescription = null;
            this.txtDisease.AccessibleName = null;
            resources.ApplyResources(this.txtDisease, "txtDisease");
            this.txtDisease.BackgroundImage = null;
            this.txtDisease.Name = "txtDisease";
            this.txtDisease.Tag = "3";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // txtCheckup_opinion
            // 
            this.txtCheckup_opinion.AccessibleDescription = null;
            this.txtCheckup_opinion.AccessibleName = null;
            resources.ApplyResources(this.txtCheckup_opinion, "txtCheckup_opinion");
            this.txtCheckup_opinion.BackgroundImage = null;
            this.txtCheckup_opinion.Name = "txtCheckup_opinion";
            this.txtCheckup_opinion.Tag = "5";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // txtPrescription
            // 
            this.txtPrescription.AccessibleDescription = null;
            this.txtPrescription.AccessibleName = null;
            resources.ApplyResources(this.txtPrescription, "txtPrescription");
            this.txtPrescription.BackgroundImage = null;
            this.txtPrescription.Name = "txtPrescription";
            this.txtPrescription.Tag = "6";
            // 
            // pnlRight
            // 
            this.pnlRight.AccessibleDescription = null;
            this.pnlRight.AccessibleName = null;
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.BackgroundImage = null;
            this.pnlRight.Controls.Add(this.txtTo_doctor2);
            this.pnlRight.Controls.Add(this.txtTo_sinryouka2);
            this.pnlRight.Controls.Add(this.txtGwa);
            this.pnlRight.Controls.Add(this.txtDoctor);
            this.pnlRight.Controls.Add(this.txtHosp_tel);
            this.pnlRight.Controls.Add(this.txtHosp_info);
            this.pnlRight.Controls.Add(this.txtHosp_address);
            this.pnlRight.Controls.Add(this.txtHosp_zip);
            this.pnlRight.Controls.Add(this.txtTel);
            this.pnlRight.Controls.Add(this.txtJob);
            this.pnlRight.Controls.Add(this.txtAddress);
            this.pnlRight.Controls.Add(this.txtZip);
            this.pnlRight.Controls.Add(this.txtBirth);
            this.pnlRight.Controls.Add(this.xFlatLabel8);
            this.pnlRight.Controls.Add(this.xFlatLabel10);
            this.pnlRight.Controls.Add(this.xFlatLabel11);
            this.pnlRight.Controls.Add(this.xFlatLabel7);
            this.pnlRight.Controls.Add(this.xFlatLabel6);
            this.pnlRight.Controls.Add(this.xLabel9);
            this.pnlRight.Controls.Add(this.dwDoc4001);
            this.pnlRight.Controls.Add(this.dtpWriteDate);
            this.pnlRight.Controls.Add(this.xFlatLabel4);
            this.pnlRight.Controls.Add(this.xFlatLabel3);
            this.pnlRight.Controls.Add(this.xFlatLabel5);
            this.pnlRight.Controls.Add(this.xFlatLabel2);
            this.pnlRight.Controls.Add(this.xFlatLabel9);
            this.pnlRight.Controls.Add(this.lblTelFax);
            this.pnlRight.Controls.Add(this.lblOf);
            this.pnlRight.Controls.Add(this.lblAddress);
            this.pnlRight.Controls.Add(this.lblPost);
            this.pnlRight.Controls.Add(this.xFlatLabel1);
            this.pnlRight.Controls.Add(this.txtTo_hospital_info);
            this.pnlRight.Controls.Add(this.xLabel1);
            this.pnlRight.Controls.Add(this.txtPrescription);
            this.pnlRight.Controls.Add(this.xLabel8);
            this.pnlRight.Controls.Add(this.txtCheckup_opinion);
            this.pnlRight.Controls.Add(this.xLabel6);
            this.pnlRight.Controls.Add(this.txtDisease);
            this.pnlRight.Controls.Add(this.txtSex);
            this.pnlRight.Controls.Add(this.txtSuname);
            this.pnlRight.Controls.Add(this.txtTo_doctor);
            this.pnlRight.Controls.Add(this.txtTo_sinryouka);
            this.pnlRight.Controls.Add(this.xLabel5);
            this.pnlRight.Controls.Add(this.xLabel4);
            this.pnlRight.Controls.Add(this.xLabel3);
            this.pnlRight.Controls.Add(this.xLabel2);
            this.pnlRight.Font = null;
            this.pnlRight.Name = "pnlRight";
            // 
            // txtTo_doctor2
            // 
            this.txtTo_doctor2.AccessibleDescription = null;
            this.txtTo_doctor2.AccessibleName = null;
            resources.ApplyResources(this.txtTo_doctor2, "txtTo_doctor2");
            this.txtTo_doctor2.BackgroundImage = null;
            this.txtTo_doctor2.Name = "txtTo_doctor2";
            this.txtTo_doctor2.Tag = "1";
            // 
            // txtTo_sinryouka2
            // 
            this.txtTo_sinryouka2.AccessibleDescription = null;
            this.txtTo_sinryouka2.AccessibleName = null;
            resources.ApplyResources(this.txtTo_sinryouka2, "txtTo_sinryouka2");
            this.txtTo_sinryouka2.BackgroundImage = null;
            this.txtTo_sinryouka2.Name = "txtTo_sinryouka2";
            this.txtTo_sinryouka2.Tag = "1";
            // 
            // txtGwa
            // 
            this.txtGwa.AccessibleDescription = null;
            this.txtGwa.AccessibleName = null;
            resources.ApplyResources(this.txtGwa, "txtGwa");
            this.txtGwa.BackgroundImage = null;
            this.txtGwa.Name = "txtGwa";
            this.txtGwa.Tag = "1";
            // 
            // txtDoctor
            // 
            this.txtDoctor.AccessibleDescription = null;
            this.txtDoctor.AccessibleName = null;
            resources.ApplyResources(this.txtDoctor, "txtDoctor");
            this.txtDoctor.BackgroundImage = null;
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Tag = "1";
            // 
            // txtHosp_tel
            // 
            this.txtHosp_tel.AccessibleDescription = null;
            this.txtHosp_tel.AccessibleName = null;
            resources.ApplyResources(this.txtHosp_tel, "txtHosp_tel");
            this.txtHosp_tel.BackgroundImage = null;
            this.txtHosp_tel.Name = "txtHosp_tel";
            this.txtHosp_tel.Tag = "1";
            // 
            // txtHosp_info
            // 
            this.txtHosp_info.AccessibleDescription = null;
            this.txtHosp_info.AccessibleName = null;
            resources.ApplyResources(this.txtHosp_info, "txtHosp_info");
            this.txtHosp_info.BackgroundImage = null;
            this.txtHosp_info.Name = "txtHosp_info";
            this.txtHosp_info.Tag = "1";
            // 
            // txtHosp_address
            // 
            this.txtHosp_address.AccessibleDescription = null;
            this.txtHosp_address.AccessibleName = null;
            resources.ApplyResources(this.txtHosp_address, "txtHosp_address");
            this.txtHosp_address.BackgroundImage = null;
            this.txtHosp_address.Name = "txtHosp_address";
            this.txtHosp_address.Tag = "1";
            // 
            // txtHosp_zip
            // 
            this.txtHosp_zip.AccessibleDescription = null;
            this.txtHosp_zip.AccessibleName = null;
            resources.ApplyResources(this.txtHosp_zip, "txtHosp_zip");
            this.txtHosp_zip.BackgroundImage = null;
            this.txtHosp_zip.Name = "txtHosp_zip";
            this.txtHosp_zip.Tag = "1";
            // 
            // txtTel
            // 
            this.txtTel.AccessibleDescription = null;
            this.txtTel.AccessibleName = null;
            resources.ApplyResources(this.txtTel, "txtTel");
            this.txtTel.BackgroundImage = null;
            this.txtTel.Name = "txtTel";
            this.txtTel.Tag = "1";
            // 
            // txtJob
            // 
            this.txtJob.AccessibleDescription = null;
            this.txtJob.AccessibleName = null;
            resources.ApplyResources(this.txtJob, "txtJob");
            this.txtJob.BackgroundImage = null;
            this.txtJob.Name = "txtJob";
            this.txtJob.Tag = "1";
            // 
            // txtAddress
            // 
            this.txtAddress.AccessibleDescription = null;
            this.txtAddress.AccessibleName = null;
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.BackgroundImage = null;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Tag = "1";
            this.txtAddress.MouseHover += new System.EventHandler(this.txtAddress_MouseHover);
            // 
            // txtZip
            // 
            this.txtZip.AccessibleDescription = null;
            this.txtZip.AccessibleName = null;
            resources.ApplyResources(this.txtZip, "txtZip");
            this.txtZip.BackgroundImage = null;
            this.txtZip.Name = "txtZip";
            this.txtZip.Tag = "1";
            // 
            // txtBirth
            // 
            this.txtBirth.AccessibleDescription = null;
            this.txtBirth.AccessibleName = null;
            resources.ApplyResources(this.txtBirth, "txtBirth");
            this.txtBirth.BackgroundImage = null;
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Tag = "1";
            // 
            // xFlatLabel8
            // 
            this.xFlatLabel8.AccessibleDescription = null;
            this.xFlatLabel8.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel8, "xFlatLabel8");
            this.xFlatLabel8.Name = "xFlatLabel8";
            // 
            // xFlatLabel10
            // 
            this.xFlatLabel10.AccessibleDescription = null;
            this.xFlatLabel10.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel10, "xFlatLabel10");
            this.xFlatLabel10.Name = "xFlatLabel10";
            // 
            // xFlatLabel11
            // 
            this.xFlatLabel11.AccessibleDescription = null;
            this.xFlatLabel11.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel11, "xFlatLabel11");
            this.xFlatLabel11.Name = "xFlatLabel11";
            // 
            // xFlatLabel7
            // 
            this.xFlatLabel7.AccessibleDescription = null;
            this.xFlatLabel7.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel7, "xFlatLabel7");
            this.xFlatLabel7.Name = "xFlatLabel7";
            // 
            // xFlatLabel6
            // 
            this.xFlatLabel6.AccessibleDescription = null;
            this.xFlatLabel6.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel6, "xFlatLabel6");
            this.xFlatLabel6.Name = "xFlatLabel6";
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // dwDoc4001
            // 
            resources.ApplyResources(this.dwDoc4001, "dwDoc4001");
            this.dwDoc4001.DataWindowObject = "doc2001u00";
            this.dwDoc4001.LibraryList = "OCSO\\OCSO.DOC4003U00.pbd";
            this.dwDoc4001.Name = "dwDoc4001";
            // 
            // dtpWriteDate
            // 
            this.dtpWriteDate.AccessibleDescription = null;
            this.dtpWriteDate.AccessibleName = null;
            resources.ApplyResources(this.dtpWriteDate, "dtpWriteDate");
            this.dtpWriteDate.BackgroundImage = null;
            this.dtpWriteDate.IsVietnameseYearType = false;
            this.dtpWriteDate.Name = "dtpWriteDate";
            // 
            // xFlatLabel4
            // 
            this.xFlatLabel4.AccessibleDescription = null;
            this.xFlatLabel4.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel4, "xFlatLabel4");
            this.xFlatLabel4.Name = "xFlatLabel4";
            // 
            // xFlatLabel3
            // 
            this.xFlatLabel3.AccessibleDescription = null;
            this.xFlatLabel3.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.Name = "xFlatLabel3";
            // 
            // xFlatLabel5
            // 
            this.xFlatLabel5.AccessibleDescription = null;
            this.xFlatLabel5.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel5, "xFlatLabel5");
            this.xFlatLabel5.Name = "xFlatLabel5";
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.AccessibleDescription = null;
            this.xFlatLabel2.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.Name = "xFlatLabel2";
            // 
            // xFlatLabel9
            // 
            this.xFlatLabel9.AccessibleDescription = null;
            this.xFlatLabel9.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel9, "xFlatLabel9");
            this.xFlatLabel9.Name = "xFlatLabel9";
            // 
            // lblTelFax
            // 
            this.lblTelFax.AccessibleDescription = null;
            this.lblTelFax.AccessibleName = null;
            resources.ApplyResources(this.lblTelFax, "lblTelFax");
            this.lblTelFax.Name = "lblTelFax";
            // 
            // lblOf
            // 
            this.lblOf.AccessibleDescription = null;
            this.lblOf.AccessibleName = null;
            resources.ApplyResources(this.lblOf, "lblOf");
            this.lblOf.Name = "lblOf";
            // 
            // lblAddress
            // 
            this.lblAddress.AccessibleDescription = null;
            this.lblAddress.AccessibleName = null;
            resources.ApplyResources(this.lblAddress, "lblAddress");
            this.lblAddress.Name = "lblAddress";
            // 
            // lblPost
            // 
            this.lblPost.AccessibleDescription = null;
            this.lblPost.AccessibleName = null;
            resources.ApplyResources(this.lblPost, "lblPost");
            this.lblPost.Name = "lblPost";
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.AccessibleDescription = null;
            this.xFlatLabel1.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // txtSex
            // 
            this.txtSex.AccessibleDescription = null;
            this.txtSex.AccessibleName = null;
            resources.ApplyResources(this.txtSex, "txtSex");
            this.txtSex.BackgroundImage = null;
            this.txtSex.Name = "txtSex";
            this.txtSex.Tag = "1";
            // 
            // txtSuname
            // 
            this.txtSuname.AccessibleDescription = null;
            this.txtSuname.AccessibleName = null;
            resources.ApplyResources(this.txtSuname, "txtSuname");
            this.txtSuname.BackgroundImage = null;
            this.txtSuname.Name = "txtSuname";
            this.txtSuname.Tag = "1";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "code1";
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // pnlMain
            // 
            this.pnlMain.AccessibleDescription = null;
            this.pnlMain.AccessibleName = null;
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.BackgroundImage = null;
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Font = null;
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlLeft
            // 
            this.pnlLeft.AccessibleDescription = null;
            this.pnlLeft.AccessibleName = null;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.BackgroundImage = null;
            this.pnlLeft.Controls.Add(this.grdDOC4003);
            this.pnlLeft.Font = null;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // grdDOC4003
            // 
            resources.ApplyResources(this.grdDOC4003, "grdDOC4003");
            this.grdDOC4003.ApplyPaintEventToAllColumn = true;
            this.grdDOC4003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell16,
            this.xEditGridCell14,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell30,
            this.xEditGridCell20,
            this.xEditGridCell31,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell22,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell21,
            this.xEditGridCell15,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29});
            this.grdDOC4003.ColPerLine = 23;
            this.grdDOC4003.Cols = 24;
            this.grdDOC4003.ControlBinding = true;
            this.grdDOC4003.ExecuteQuery = null;
            this.grdDOC4003.FixedCols = 1;
            this.grdDOC4003.FixedRows = 1;
            this.grdDOC4003.HeaderHeights.Add(21);
            this.grdDOC4003.Name = "grdDOC4003";
            this.grdDOC4003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDOC4003.ParamList")));
            this.grdDOC4003.QuerySQL = resources.GetString("grdDOC4003.QuerySQL");
            this.grdDOC4003.RowHeaderVisible = true;
            this.grdDOC4003.Rows = 2;
            this.grdDOC4003.ToolTipActive = true;
            this.grdDOC4003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDOC4003_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "sys_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "sys_id";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "upd_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "upd_id";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "hosp_code";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 50;
            this.xEditGridCell16.CellName = "pkdoc4003";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "seq";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.BindControl = this.dtpWriteDate;
            this.xEditGridCell17.CellName = "create_date";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell17.Col = 1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.txtTo_hospital_info;
            this.xEditGridCell18.CellName = "to_hospital_info";
            this.xEditGridCell18.CellWidth = 115;
            this.xEditGridCell18.Col = 3;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.BindControl = this.txtTo_sinryouka;
            this.xEditGridCell19.CellName = "to_sinryouka";
            this.xEditGridCell19.CellWidth = 93;
            this.xEditGridCell19.Col = 4;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.BindControl = this.txtTo_sinryouka2;
            this.xEditGridCell30.CellName = "to_sinryouka2";
            this.xEditGridCell30.CellWidth = 134;
            this.xEditGridCell30.Col = 22;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.BindControl = this.txtTo_doctor;
            this.xEditGridCell20.CellName = "to_doctor";
            this.xEditGridCell20.CellWidth = 105;
            this.xEditGridCell20.Col = 5;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.BindControl = this.txtTo_doctor2;
            this.xEditGridCell31.CellName = "to_doctor2";
            this.xEditGridCell31.CellWidth = 131;
            this.xEditGridCell31.Col = 23;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.BindControl = this.txtDoctor;
            this.xEditGridCell23.CellName = "doctor";
            this.xEditGridCell23.Col = 6;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.BindControl = this.txtGwa;
            this.xEditGridCell24.CellName = "gwa";
            this.xEditGridCell24.Col = 7;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.BindControl = this.txtSuname;
            this.xEditGridCell6.CellName = "suname";
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.BindControl = this.txtSex;
            this.xEditGridCell7.CellName = "sex";
            this.xEditGridCell7.Col = 9;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.BindControl = this.txtZip;
            this.xEditGridCell22.CellName = "zip";
            this.xEditGridCell22.Col = 10;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.txtAddress;
            this.xEditGridCell8.CellLen = 1000;
            this.xEditGridCell8.CellName = "address";
            this.xEditGridCell8.Col = 11;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.BindControl = this.txtTel;
            this.xEditGridCell9.CellLen = 20;
            this.xEditGridCell9.CellName = "tel";
            this.xEditGridCell9.Col = 12;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.BindControl = this.txtBirth;
            this.xEditGridCell10.CellName = "birth";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = 13;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.txtJob;
            this.xEditGridCell12.CellLen = 200;
            this.xEditGridCell12.CellName = "job";
            this.xEditGridCell12.Col = 14;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.BindControl = this.txtDisease;
            this.xEditGridCell13.CellLen = 2000;
            this.xEditGridCell13.CellName = "disease";
            this.xEditGridCell13.Col = 15;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.BindControl = this.txtCheckup_opinion;
            this.xEditGridCell21.CellLen = 4000;
            this.xEditGridCell21.CellName = "checkup_opinion";
            this.xEditGridCell21.CellWidth = 122;
            this.xEditGridCell21.Col = 16;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.BindControl = this.txtPrescription;
            this.xEditGridCell15.CellLen = 4000;
            this.xEditGridCell15.CellName = "prescription";
            this.xEditGridCell15.CellWidth = 127;
            this.xEditGridCell15.Col = 17;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "bunho";
            this.xEditGridCell25.CellWidth = 87;
            this.xEditGridCell25.Col = 2;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.BindControl = this.txtHosp_zip;
            this.xEditGridCell26.CellName = "hosp_zip";
            this.xEditGridCell26.CellWidth = 131;
            this.xEditGridCell26.Col = 18;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.BindControl = this.txtHosp_address;
            this.xEditGridCell27.CellName = "hosp_address";
            this.xEditGridCell27.CellWidth = 151;
            this.xEditGridCell27.Col = 19;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.BindControl = this.txtHosp_tel;
            this.xEditGridCell28.CellName = "hosp_tel";
            this.xEditGridCell28.CellWidth = 124;
            this.xEditGridCell28.Col = 20;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.BindControl = this.txtHosp_info;
            this.xEditGridCell29.CellName = "hosp_info";
            this.xEditGridCell29.CellWidth = 132;
            this.xEditGridCell29.Col = 21;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, Resources.btnPrint, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, Resources.btnClose, -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.paBox.BackgroundImage = null;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // layDataWindow
            // 
            this.layDataWindow.ExecuteQuery = null;
            this.layDataWindow.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDataWindow.ParamList")));
            // 
            // DOC4003U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlMain);
            this.Name = "DOC4003U00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.DOC4003U00_ScreenOpen);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDOC4003)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDataWindow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Fields & Properties

        //환자등록번호
        string mBunho = "";

        string mDoctorID = "";
        string mDoctorName = "";
        string mDoctorGwaName = "";

        string mHospPost = "";
        string mHospAddress = "";
        string mHospOf = "";
        string mHospTel = "";
        string mHospFax = "";
        string mHospHomepage = "";

        //Hospital Code
        string mHospCode = EnvironInfo.HospCode;

        #endregion

        #region Constructor
        /// <summary>
        /// DOC4003U00
        /// </summary>
        public DOC4003U00()
        {
            try
            {
                // 이 호출은 Windows Form 디자이너에 필요합니다.
                InitializeComponent();

                //this.SaveLayoutList.Add(this.grdDOC4003);

                //this.grdDOC4003.SavePerformer = new XSavePerformer(this);
                
                //this.grdComment.SavePerformer = this.grdNurse.SavePerformer;

                // Connect to Cloud
                InitializeCloud();
            }
            catch (Exception x)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(x.StackTrace);
            }

            // 날짜 컨트롤에 오늘날짜 설정
            this.dtpWriteDate.SetDataValue(EnvironInfo.GetSysDate());
            // 그리드에 XSavePerformer 생성 및 지정
        }
        #endregion

        #region Events

        //환자 컨트롤에서 환자가 선택 되었을 때,
        private void pbxRequest_bunho_PatientSelected(object sender, EventArgs e)
        {
            mBunho = paBox.BunHo;
            //grd2004.QueryLayout(false);
        }

        //환자 선택 실패시
        private void pbxRequest_bunho_PatientSelectionFailed(object sender, EventArgs e)
        {
            mBunho = "";
        }

        private void DOC4003U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.GetPaInfo();
            this.GetHospInfo();

            this.mDoctorID = UserInfo.DoctorID;
            this.mDoctorName = UserInfo.UserName;
            //this.mDoctorGwaName = UserInfo.GwaName;
            this.mDoctorGwaName = UserInfo.BuseoName;
            this.btnList.PerformClick(FunctionType.Query);

            if (this.grdDOC4003.RowCount == 0)
                this.btnList.PerformClick(FunctionType.Insert);

        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void grdDOC4003_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            grd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grd.SetBindVarValue("f_bunho", this.paBox.BunHo);

        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    this.InserNewRow();
                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;

                    if (this.paBox.BunHo != "")
                        this.grdDOC4003.QueryLayout(false);
                    else
                        this.grdDOC4003.Reset();

                    break;
                case FunctionType.Print:

                    this.layDataWindow = this.grdDOC4003.CloneToLayout();

                    if (this.grdDOC4003.CurrentRowNumber > -1)
                    {
                        this.layDataWindow.LayoutTable.ImportRow(this.grdDOC4003.LayoutTable.Rows[this.grdDOC4003.CurrentRowNumber]);

                        dwDoc4001.Reset();
                        dwDoc4001.FillData(this.layDataWindow.LayoutTable);

                        try
                        {
                            //this.dwDoc4001.Reset();
                            ApplyMutilanguage();
                            dwDoc4001.Print();
                            this.dwDoc4001.Refresh();
                        }
                        catch
                        {
                            //https://sofiamedix.atlassian.net/browse/MED-10610
                            //XMessageBox.Show("プリンターを確認してください。");
                        }
                        XMessageBox.Show(Resources.MSG001);

                    }

                    break;

                case FunctionType.Reset:

                    e.IsBaseCall = false;

                    break;

                case FunctionType.Process:


                    break;

                case FunctionType.Update:
                    //try
                    //{
                    //    if (!this.grdDOC4003.SaveLayout())
                    //    {

                    //        return;
                    //    }
                    //}
                    //catch (Exception ee)
                    //{
                    //    XMessageBox.Show(ee.Message);
                    //}

                    // updated by Cloud
                    DOC4003U00SaveLayoutArgs args = new DOC4003U00SaveLayoutArgs();
                    args.HospCode = UserInfo.HospCode;
                    args.UserId = UserInfo.UserID;
                    args.SaveLayoutItem = GetListDataForSaveLayout();

                    // No changes
                    if (args.SaveLayoutItem.Count == 0)
                    {
                        //XMessageBox.Show(Resources.MSG_SAVE_SUCCESS, Resources.CAP_001, MessageBoxButtons.OK);
                        //grdDOC4003.ResetUpdate();
                        return;
                    }

                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, DOC4003U00SaveLayoutArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                    {
                        XMessageBox.Show(Resources.MSG_SAVE_SUCCESS, Resources.CAP_001, MessageBoxButtons.OK);
                        grdDOC4003.ResetUpdate();
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_SAVE_FAIL, Resources.CAP_001, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
            }
        }

        private void txtAddress_MouseHover(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.Show(txtAddress.Text, txtAddress);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                this.paBox.Focus();
                this.paBox.SetPatientID(info.BunHo);
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
            {
                return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
            }

            return null;
        }

        private void GetPaInfo()
        {
            if (this.OpenParam != null)
            {
                if (OpenParam.Contains("bunho"))
                {
                    this.paBox.SetPatientID(OpenParam["bunho"].ToString());
                }
            }
            else
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                {
                    this.paBox.Focus();
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
            }
        }

        private void GetHospInfo()
        {
            #region deleted by Cloud
            //            string cmd = @" SELECT SUBSTR(A.ZIP_CODE, 1, 3) || '-' || SUBSTR(A.ZIP_CODE, 4) ZIP_CODE
//                                 , A.ADDRESS
//                                 , 'TEL:' || A.TEL || ' FAX:' || A.FAX TEL
//                                 , A.YOYANG_NAME
//                              FROM BAS0001 A
//                             WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
//                               AND SYSDATE BETWEEN A.START_DATE 
//                                               AND A.END_DATE";


//            DataTable dt = Service.ExecuteDataTable(cmd);

//            if (dt.Rows.Count > 0)
//            {
//                DataRow dr = dt.Rows[0];

//                this.mHospPost = dr["zip_code"].ToString();
//                this.mHospAddress = dr["address"].ToString();
//                this.mHospOf = dr["yoyang_name"].ToString();
//                this.mHospTel = dr["tel"].ToString();
//            }

//            if (this.mHospPost != "")
//                this.txtHosp_zip.Text = this.mHospPost;
//            if (this.mHospAddress != "")
//                this.txtHosp_address.Text = this.mHospAddress;
//            if (this.mHospOf != "")
//                this.txtHosp_info.Text = this.mHospOf;
//            if (this.mHospTel != "")
            //                this.txtHosp_tel.Text = this.mHospTel;
            #endregion

            #region Updated by Cloud

            DOC4003U00GetHospArgs args = new DOC4003U00GetHospArgs();
            args.HospCode = this.mHospCode;
            DOC4003U00GetHospResult res = CloudService.Instance.Submit<DOC4003U00GetHospResult, DOC4003U00GetHospArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                this.mHospPost = res.HospInfoItem.ZipCode;
                this.mHospAddress = res.HospInfoItem.Address;
                this.mHospOf = res.HospInfoItem.YoyangName;
                this.mHospTel = res.HospInfoItem.Tel;
            }

            if (this.mHospPost != "")
                this.txtHosp_zip.Text = this.mHospPost;
            if (this.mHospAddress != "")
                this.txtHosp_address.Text = this.mHospAddress;
            if (this.mHospOf != "")
                this.txtHosp_info.Text = this.mHospOf;
            if (this.mHospTel != "")
                this.txtHosp_tel.Text = this.mHospTel;

            #endregion
        }

        private void InserNewRow()
        {
            //string cmd = "SELECT DOC4003_SEQ.NEXTVAL FROM SYS.DUAL";
            //object obj = Service.ExecuteScalar(cmd);
            //string pkdoc4003 = obj.ToString();

            // updated by Cloud
            string pkdoc4003 = string.Empty;
            DOC4003U00GetNextValResult res = CloudService.Instance.Submit<DOC4003U00GetNextValResult, DOC4003U00GetNextValArgs>(new DOC4003U00GetNextValArgs());
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                pkdoc4003 = res.NextVal;
            }

            int currenRow = this.grdDOC4003.InsertRow(-1);

            this.grdDOC4003.SetItemValue(currenRow, "pkdoc4003", pkdoc4003);
            this.grdDOC4003.SetItemValue(currenRow, "create_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.grdDOC4003.SetItemValue(currenRow, "bunho", this.paBox.BunHo);

            // 患者情報

            this.grdDOC4003.SetItemValue(currenRow, "suname", this.paBox.SuName + "(" + this.paBox.SuName2 + ")");
            this.grdDOC4003.SetItemValue(currenRow, "sex", this.paBox.Sex == "M" ? Resources.MSG_MALE : Resources.MSG_FEMALE);
            this.grdDOC4003.SetItemValue(currenRow, "birth", this.paBox.Birth);
            this.grdDOC4003.SetItemValue(currenRow, "zip", this.paBox.Zip1 + "-" + this.paBox.Zip2);
            this.grdDOC4003.SetItemValue(currenRow, "address", this.paBox.Address1 + this.paBox.Address2);
            this.grdDOC4003.SetItemValue(currenRow, "tel", this.paBox.Tel);

            // 依頼医師情報

            this.grdDOC4003.SetItemValue(currenRow, "doctor", this.mDoctorName);
            this.grdDOC4003.SetItemValue(currenRow, "gwa", this.mDoctorGwaName);

            // 病院情報

            this.grdDOC4003.SetItemValue(currenRow, "hosp_zip", this.mHospPost);
            this.grdDOC4003.SetItemValue(currenRow, "hosp_info", this.mHospOf);
            this.grdDOC4003.SetItemValue(currenRow, "hosp_tel", this.mHospTel);
            this.grdDOC4003.SetItemValue(currenRow, "hosp_address", this.mHospAddress);
        }

        #endregion

        // deleted by Cloud
        #region XSaverPerformer
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private DOC4003U00 parent = null;

//            public XSavePerformer(DOC4003U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {

//                string cmd = "";

//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("f_user_id", UserInfo.UserID);

//                Service.BeginTransaction();


//                switch (callerID)
//                {
//                    case '1':

//                        // DELETE
//                        if (parent.grdDOC4003.DeletedRowCount > 0)
//                        {
//                            for (int i = 0; i < parent.grdDOC4003.DeletedRowCount; i++)
//                            {
//                                cmd = @"DELETE DOC4003 A
//                                         WHERE A.HOSP_CODE = '" + parent.grdDOC4003.DeletedRowTable.Rows[i]["hosp_code"].ToString() + @"'
//                                           AND A.PKDOC4003 = '" + parent.grdDOC4003.DeletedRowTable.Rows[i]["pkdoc4003"].ToString() + "' ";
//                                try
//                                {
//                                    Service.ExecuteScalar(cmd);
//                                }
//                                catch (Exception ee)
//                                {
//                                    XMessageBox.Show(ee.Message);
//                                    Service.RollbackTransaction();
//                                }
//                            }
//                        }


//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                string cmd_seq = "";

//                                cmd_seq = @"SELECT NVL(MAX(A.SEQ) + 1, 1) SEQ
//                                              FROM DOC4003 A
//                                             WHERE A.HOSP_CODE = :f_hosp_code
//                                               AND A.BUNHO     = :f_bunho
//                                            ";
//                                object obj = Service.ExecuteScalar(cmd_seq, item.BindVarList);

//                                item.BindVarList["f_seq"].VarValue = obj.ToString();

//                                cmd = @"INSERT INTO DOC4003 (  SYS_DATE     , SYS_ID            , HOSP_CODE       
//                                                             , PKDOC4003    , SEQ               , CREATE_DATE    , TO_HOSPITAL_INFO    , TO_SINRYOUKA    , TO_SINRYOUKA2    
//                                                             , TO_DOCTOR    , TO_DOCTOR2        , DOCTOR         , GWA                 , SUNAME          , SEX             
//                                                             , ZIP          , ADDRESS           , TEL            , BIRTH               , JOB             
//                                                             , DISEASE      , CHECKUP_OPINION   , PRESCRIPTION   , BUNHO )
//                                                      VALUES(  SYSDATE      , :f_user_id        , :f_hosp_code       
//                                                             , :f_pkdoc4003 , :f_seq            , :f_create_date , :f_to_hospital_info , :f_to_sinryouka , :f_to_sinryouka2 
//                                                             , :f_to_doctor , :f_to_doctor2     , :f_doctor         , :f_gwa           , :f_suname       , :f_sex             
//                                                             , :f_zip       , :f_address        , :f_tel         , :f_birth            , :f_job             
//                                                             , :f_disease   , :f_checkup_opinion, :f_prescription, :f_bunho )";

//                                break;

//                            case DataRowState.Modified:
//                                cmd = @"UPDATE DOC4003 A
//                                           SET A.UPD_DATE            = SYSDATE
//                                             , A.UPD_ID              = :f_user_id          
//                                             , A.TO_HOSPITAL_INFO    = :f_to_hospital_info
//                                             , A.TO_SINRYOUKA        = :f_to_sinryouka    
//                                             , A.TO_SINRYOUKA2       = :f_to_sinryouka2    
//                                             , A.TO_DOCTOR           = :f_to_doctor       
//                                             , A.TO_DOCTOR2          = :f_to_doctor2       
//                                             , A.DOCTOR              = :f_doctor          
//                                             , A.GWA                 = :f_gwa             
//                                             , A.SUNAME              = :f_suname          
//                                             , A.SEX                 = :f_sex             
//                                             , A.ZIP                 = :f_zip             
//                                             , A.ADDRESS             = :f_address         
//                                             , A.TEL                 = :f_tel             
//                                             , A.BIRTH               = :f_birth           
//                                             , A.JOB                 = :f_job             
//                                             , A.DISEASE             = :f_disease         
//                                             , A.CHECKUP_OPINION     = :f_checkup_opinion 
//                                             , A.PRESCRIPTION        = :f_prescription    
//                                         WHERE A.HOSP_CODE = :f_hosp_code
//                                           AND A.BUNHO     = :f_bunho
//                                           AND A.PKDOC4003 = :f_pkdoc4003";

//                                break;
//                        }
//                        break;
//                }
//                try
//                {
//                    Service.ExecuteNonQuery(cmd, item.BindVarList);
//                }
//                catch (Exception ee)
//                {
//                    XMessageBox.Show(ee.Message);
//                    Service.RollbackTransaction();
//                }

//                Service.CommitTransaction();

//                return true;

                
//            }
//        }
        #endregion

        #region Connect to Cloud

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            grdDOC4003.ParamList = new List<string>(new string[]
                {
                    "f_hosp_code",
                    "f_bunho",
                });
            grdDOC4003.ExecuteQuery = GetGrdDOC4003;
        }
        #endregion

        #region GetGrdDOC4003
        /// <summary>
        /// GetGrdDOC4003
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdDOC4003(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DOC4003U00GrdDOC4003Args args = new DOC4003U00GrdDOC4003Args();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.HospCode = bvc["f_hosp_code"].VarValue;
            DOC4003U00GrdDOC4003Result res = CloudService.Instance.Submit<DOC4003U00GrdDOC4003Result, DOC4003U00GrdDOC4003Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Doc4003Item.ForEach(delegate(DOC4003U00GrdDOC4003Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.SysDate,
                        item.SysId,
                        item.UpdDate,
                        item.UpdId,
                        item.HospCode,
                        item.Pkdoc4003,
                        item.Seq,
                        item.CreateDate,
                        item.ToHospitalInfo,
                        item.ToSinryouka,
                        item.ToSinryouka2,
                        item.ToDoctor,
                        item.ToDoctor2,
                        item.Doctor,
                        item.Gwa,
                        item.Suname,
                        item.Sex,
                        item.Zip,
                        item.AAddress,
                        item.Tel,
                        item.Birth,
                        item.Job,
                        item.Disease,
                        item.CheckupOpinion,
                        item.Prescription,
                        item.Bunho,
                        item.ZipCode,
                        item.BAddress,
                        item.Fax,
                        item.YoyangName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<DOC4003U00GrdDOC4003Info> GetListDataForSaveLayout()
        {
            List<DOC4003U00GrdDOC4003Info> lstData = new List<DOC4003U00GrdDOC4003Info>();

            // For insert/update
            for (int i = 0; i < grdDOC4003.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdDOC4003.GetRowState(i) == DataRowState.Unchanged) continue;

                DOC4003U00GrdDOC4003Info item = new DOC4003U00GrdDOC4003Info();

                item.SysDate                = grdDOC4003.GetItemString(i, "sys_date");
                item.SysId                  = grdDOC4003.GetItemString(i, "sys_id");
                item.UpdDate                = grdDOC4003.GetItemString(i, "upd_date");
                item.UpdId                  = grdDOC4003.GetItemString(i, "upd_id");
                item.HospCode               = grdDOC4003.GetItemString(i, "hosp_code");
                item.Pkdoc4003              = grdDOC4003.GetItemString(i, "pkdoc4003");
                item.Seq                    = grdDOC4003.GetItemString(i, "seq");
                item.CreateDate             = grdDOC4003.GetItemString(i, "create_date");
                item.ToHospitalInfo         = grdDOC4003.GetItemString(i, "to_hospital_info");
                item.ToSinryouka            = grdDOC4003.GetItemString(i, "to_sinryouka");
                item.ToSinryouka2           = grdDOC4003.GetItemString(i, "to_sinryouka2");
                item.ToDoctor               = grdDOC4003.GetItemString(i, "to_doctor");
                item.ToDoctor2              = grdDOC4003.GetItemString(i, "to_doctor2");
                item.Doctor                 = grdDOC4003.GetItemString(i, "doctor");
                item.Gwa                    = grdDOC4003.GetItemString(i, "gwa");
                item.Suname                 = grdDOC4003.GetItemString(i, "suname");
                item.Sex                    = grdDOC4003.GetItemString(i, "sex");
                item.Zip                    = grdDOC4003.GetItemString(i, "zip");
                item.AAddress               = grdDOC4003.GetItemString(i, "address");
                item.Tel                    = grdDOC4003.GetItemString(i, "tel");
                item.Birth                  = grdDOC4003.GetItemString(i, "birth");
                item.Job                    = grdDOC4003.GetItemString(i, "job");
                item.Disease                = grdDOC4003.GetItemString(i, "disease");
                item.CheckupOpinion         = grdDOC4003.GetItemString(i, "checkup_opinion");
                item.Prescription           = grdDOC4003.GetItemString(i, "prescription");
                item.Bunho                  = grdDOC4003.GetItemString(i, "bunho");
                item.ZipCode                = grdDOC4003.GetItemString(i, "hosp_zip");
                item.BAddress               = grdDOC4003.GetItemString(i, "hosp_address");
                item.Fax                    = grdDOC4003.GetItemString(i, "hosp_tel");
                item.YoyangName             = grdDOC4003.GetItemString(i, "hosp_info");
                item.RowState               = grdDOC4003.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // For delete
            if (null != grdDOC4003.DeletedRowTable)
            {
                foreach (DataRow dr in grdDOC4003.DeletedRowTable.Rows)
                {
                    DOC4003U00GrdDOC4003Info item = new DOC4003U00GrdDOC4003Info();
                    item.Pkdoc4003 = dr["pkdoc4003"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #endregion

        private void ApplyMutilanguage()
        {
            try
            {
                dwDoc4001.Modify(string.Format("t_1.text =  '{0}'", Resources.DW_TXT_1));
                dwDoc4001.Modify(string.Format("t_2.text =  '{0}'", Resources.DW_TXT_2));
                dwDoc4001.Modify(string.Format("t_3.text =  '{0}'", Resources.DW_TXT_3));
                dwDoc4001.Modify(string.Format("t_5.text =  '{0}'", Resources.DW_TXT_4));
                dwDoc4001.Modify(string.Format("t_6.text =  '{0}'", Resources.DW_TXT_5));
                dwDoc4001.Modify(string.Format("t_8.text =  '{0}'", Resources.DW_TXT_6));
                dwDoc4001.Modify(string.Format("t_9.text =  '{0}'", Resources.DW_TXT_7));
                dwDoc4001.Modify(string.Format("t_19.text =  '{0}'", Resources.DW_TXT_8));
                dwDoc4001.Modify(string.Format("t_10.text =  '{0}'", Resources.DW_TXT_9));
                dwDoc4001.Modify(string.Format("t_22.text =  '{0}'", Resources.DW_TXT_10));
                dwDoc4001.Modify(string.Format("t_20.text =  '{0}'", Resources.DW_TXT_11));
                dwDoc4001.Modify(string.Format("t_24.text =  '{0}'", Resources.DW_TXT_12));
                dwDoc4001.Modify(string.Format("t_21.text =  '{0}'", Resources.DW_TXT_13));
                dwDoc4001.Modify(string.Format("t_23.text =  '{0}'", Resources.DW_TXT_14));
                dwDoc4001.Modify(string.Format("t_11.text =  '{0}'", Resources.DW_TXT_15));
                dwDoc4001.Modify(string.Format("t_13.text =  '{0}'", Resources.DW_TXT_16));
                dwDoc4001.Modify(string.Format("t_14.text =  '{0}'", Resources.DW_TXT_17));

            }
            catch (Exception ex)
            {
                Service.WriteLog("[ERROR][DOC4003U00] :" + ex.Message);
            }
        }
       
    }
}
