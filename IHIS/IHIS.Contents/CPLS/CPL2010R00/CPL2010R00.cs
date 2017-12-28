/*
** CPL2010R00 バーコード再出力
** Date		: 2007. 11. 30
** Modified	: 2007. 11. 30
**			  Park Seung Hwan
*/

#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL2010R00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL2010R00 : IHIS.Framework.XScreen
    {
        #region IHIS Controls
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XColumnHeader xColumnHeader1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XTextBox txtBarcode;
        private IHIS.Framework.XButton btnPrintSetup;
        private IHIS.Framework.XButton btnBarcode;
    //    private IHIS.Framework.XDataWindow dwBarcode;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label lbSpecimenSer;
        private IHIS.Framework.XButton btnClose;
        private IHIS.Framework.MultiLayout layBarcodeOne;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem8;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem9;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem10;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem11;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem12;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem13;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem14;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem15;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem16;
        private IHIS.Framework.MultiLayout layBarcode;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem17;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem18;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem19;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem20;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem21;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem22;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem23;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem24;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem25;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem26;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem27;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem28;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem29;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem30;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem31;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem32;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region Main Destructor
        public CPL2010R00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            layBarcode.ParamList = new List<string>(new String[] { "f_specimen_ser" });
            layBarcode.ExecuteQuery = LoadDataLayBarcode;
        }

        #region CloudService load data for controls

        private List<object[]> LoadDataLayBarcode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010R00GetBarCodeArgs args = new CPL2010R00GetBarCodeArgs();
            args.SpecimenSer = bc["f_specimen_ser"] != null ? bc["f_specimen_ser"].VarValue : "";
            CPL2010R00GetBarCodeResult result =
                CloudService.Instance.Submit<CPL2010R00GetBarCodeResult, CPL2010R00GetBarCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010R00GetBarCodeInfo item in result.ListItem)
                {
                    object[] objects =
                    {
                        item.JundalGubun,
                        item.JundalGubunName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.TubeCode,
                        item.TubeName,
                        item.InOutGubun,
                        item.SpecimenSer,
                        item.Bunho,
                        item.Suname,
                        item.GwaName,
                        item.DangerYn,
                        item.SpecimenSerBa,
                        item.JangbiCode,
                        item.JangbiName,
                        item.GumsaNameRe,
                        item.TubeCount,
                        item.TubeMaxAmt,
                        item.TubeNumbering
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion



        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010R00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.lbSpecimenSer = new System.Windows.Forms.Label();
            this.txtBarcode = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xColumnHeader1 = new IHIS.Framework.XColumnHeader();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnPrintSetup = new IHIS.Framework.XButton();
            this.btnBarcode = new IHIS.Framework.XButton();
    //        this.dwBarcode = new IHIS.Framework.XDataWindow();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.layBarcodeOne = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcode = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.lbSpecimenSer);
            this.xPanel1.Controls.Add(this.txtBarcode);
            this.xPanel1.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // lbSpecimenSer
            // 
            resources.ApplyResources(this.lbSpecimenSer, "lbSpecimenSer");
            this.lbSpecimenSer.Name = "lbSpecimenSer";
            // 
            // txtBarcode
            // 
            resources.ApplyResources(this.txtBarcode, "txtBarcode");
            this.txtBarcode.AutoTabAtMaxLength = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtBarcode_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xColumnHeader1
            // 
            resources.ApplyResources(this.xColumnHeader1, "xColumnHeader1");
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnClose);
            this.xPanel3.Controls.Add(this.btnPrintSetup);
            this.xPanel3.Controls.Add(this.btnBarcode);
  //          this.xPanel3.Controls.Add(this.dwBarcode);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrintSetup
            // 
            resources.ApplyResources(this.btnPrintSetup, "btnPrintSetup");
            this.btnPrintSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSetup.Image")));
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // btnBarcode
            // 
            resources.ApplyResources(this.btnBarcode, "btnBarcode");
            this.btnBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcode.Image")));
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // dwBarcode
            // 
            //this.dwBarcode.DataWindowObject = "d_specimen_ser";
            //this.dwBarcode.LibraryList = "CPLS\\cpls.cpl2010r00.pbd";
            //resources.ApplyResources(this.dwBarcode, "dwBarcode");
            //this.dwBarcode.Name = "dwBarcode";
            // 
            // layBarcodeOne
            // 
            this.layBarcodeOne.ExecuteQuery = null;
            this.layBarcodeOne.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16});
            this.layBarcodeOne.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeOne.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "jundal_gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "specimen_code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "specimen_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "tube_code";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "tube_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "in_out_gubun";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "specimen_ser";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "bunho";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "suname";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "gwa_name";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "danger_yn";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "jangbi_code";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jangbi_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "gumsa_name_re";
            // 
            // layBarcode
            // 
            this.layBarcode.ExecuteQuery = null;
            this.layBarcode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32});
            this.layBarcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcode.ParamList")));
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "jundal_gubun";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "specimen_code";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "specimen_name";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "tube_code";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "tube_name";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "in_out_gubun";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "specimen_ser";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "bunho";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "suname";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "gwa_name";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "danger_yn";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "jangbi_code";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "jangbi_name";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "gumsa_name_re";
            // 
            // CPL2010R00
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel3);
            this.Name = "CPL2010R00";
            resources.ApplyResources(this, "$this");
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Onload
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion

        #region 닫기
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        /********************************************************************************************/

        #region [ #01 검체번호 벨리데이션 ]
        private void txtBarcode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //바코드 재출력
           // this.btnBarcode.PerformClick();
        }
        #endregion

        #region [ #02 바코드 프린터 설정 버튼 클릭 ]
        private void btnPrintSetup_Click(object sender, System.EventArgs e)
        {
            SetPrint();
        }
        #endregion

        #region [ #03 재인쇄 버튼 클릭 ]
        private void btnBarcode_Click(object sender, System.EventArgs e)
        {
            SetPrintBarcode();
        }
        #endregion

        /************** Custom Method **************/

        #region [ #01 SetPrint() 바코드 프린터 설정 ]
        private void SetPrint()
        {
            try
            {
                //Open the PrintDialog
                this.printDialog1.Document = this.printDocument1;
                DialogResult dr = this.printDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //Get the Copy times
                    int nCopy = this.printDocument1.PrinterSettings.Copies;
                    //Get the number of Start Page
                    int sPage = this.printDocument1.PrinterSettings.FromPage;
                    //Get the number of End Page
                    int ePage = this.printDocument1.PrinterSettings.ToPage;
                    //Get the printer name
                    string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                    this.PrintNameSave(PrinterName);
                }
            }
            catch (Exception err)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("C #01\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }
        #endregion

        #region [ #02 PrintNameSave() 프린터 이름 저장 ]
        private void PrintNameSave(string printerName)
        {
//            try
//            {
//                BindVarCollection bindVar = new BindVarCollection();
//                string tmpQuery = string.Empty;
//                tmpQuery = @"
//						DECLARE
//
//							t_trim_id VARCHAR2(8);
//
//						BEGIN
//
//							UPDATE ADM3300
//							   SET USER_ID         = :q_user_id
//								 , UP_TIME         = SYSDATE
//								 , B_PRINT_NAME    = :f_b_print_name
//							 WHERE IP_ADDR         = :f_ip_addr;
//
//							IF SQL%ROWCOUNT = 0 THEN
//							
//								SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
//								INTO t_trim_id
//								FROM ADM3300;
//
//								INSERT INTO ADM3300
//											( TRM_ID,    IP_ADDR,    USER_ID,    DEPT_CODE, 
//											  USE_YN,    SERVER_IP,  CR_MEMB,    CR_TIME,    CR_TRM, B_PRINT_NAME)
//											VALUES 
//											( t_trim_id,  :f_ip_addr,   :q_user_id, NULL, 
//											  NULL,      NULL,         :q_user_id, SYSDATE,  NULL,  :f_b_print_name);
//
//							END IF;
//
//						END;";

//                tmpQuery = tmpQuery.Replace("\r", " ");

//                bindVar.Add("q_user_id", UserInfo.UserID);
//                bindVar.Add("f_b_print_name", printerName);
//                bindVar.Add("f_ip_addr", Service.ClientIP.ToString());

//                Service.BeginTransaction();
//                if (!Service.ExecuteNonQuery(tmpQuery, bindVar))
//                {
//                    throw new Exception();
//                }
//                else
//                {
//                    Service.CommitTransaction();
//                }
//            }
//            catch (Exception err)
//            {
//                Service.RollbackTransaction();
//                XMessageBox.Show("C #02\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
//            }

            try
            {
                InjsINJ1001U01SettingPrintArgs args = new InjsINJ1001U01SettingPrintArgs();
                args.BPrintName = printerName;
                args.IpAddr = Service.ClientIP.ToString();
                args.UserId = UserInfo.UserID;

                InjsINJ1001U01SettingPrintResult result =
                    CloudService.Instance.Submit<InjsINJ1001U01SettingPrintResult, InjsINJ1001U01SettingPrintArgs>(args);
                if (result.ExecutionStatus != ExecutionStatus.Success || result.Result == false)
                {
                    XMessageBox.Show("C #02\n\nService : " + Service.ErrFullMsg + "\n\nException : ");
                }
            }
            catch (Exception err)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("C #02\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }
        #endregion

        #region [ #03 SetPrintBarcode() 프린터 설정 과 바코드 출력 ]
        private void SetPrintBarcode()
        {
            try
            {
                if (TypeCheck.IsNull(txtBarcode.GetDataValue()) && TypeCheck.IsNull(lbSpecimenSer.Text))
                {
                    txtBarcode.Focus();
                    return;
                }

                //바코드프린터명 가져오기
                string printSetName = this.GetPrintName();

    //            dwBarcode.Reset();
                layBarcode.Reset();

                string specimen_ser = txtBarcode.GetDataValue();
                if (TypeCheck.IsNull(specimen_ser))
                    specimen_ser = lbSpecimenSer.Text;

                layBarcode.SetBindVarValue("f_specimen_ser", specimen_ser);

                if (!layBarcode.QueryLayout(true))
                {
                    throw new Exception();
                }

                if (layBarcode.RowCount > 0)
                {
                    //채혈실의 뇨컵은 하나면된다
                    int nyo_cnt = 0;
                    string tube_code = "";
                    string jundal_gubun = "";
                    for (int i = this.layBarcode.RowCount - 1; i >= 0; i--)
                    {
                        jundal_gubun = this.layBarcode.GetItemString(i, "jundal_gubun");
                        tube_code = this.layBarcode.GetItemString(i, "tube_code");
                        if (jundal_gubun != "14") //혈당부하 항목의 뇨는 그냥 바코드 뽑는다.
                        {
                            if (tube_code == "18")
                            {
                                nyo_cnt++;
                            }
                            if (nyo_cnt > 1)
                            {
                                if (tube_code == "18")
                                {
                                    this.layBarcode.DeleteRow(i);
                                }
                            }
                        }
                    }
                    this.layBarcode.AcceptData();

                    nyo_cnt = 0;
                    tube_code = "";
                    jundal_gubun = "";
                    for (int i = this.layBarcode.RowCount - 1; i >= 0; i--)
                    {
                        jundal_gubun = this.layBarcode.GetItemString(i, "jundal_gubun");
                        tube_code = this.layBarcode.GetItemString(i, "tube_code");
                        if (jundal_gubun != "14") //혈당부하 항목의 뇨는 그냥 바코드 뽑는다.
                        {
                            if (tube_code == "24")
                            {
                                nyo_cnt++;
                            }
                            if (nyo_cnt > 1)
                            {
                                if (tube_code == "24")
                                {
                                    this.layBarcode.DeleteRow(i);
                                }
                            }
                        }
                    }
                    this.layBarcode.AcceptData();

                    //한껀씩 출력 보냄
                    for (int j = 0; j < this.layBarcode.RowCount; j++)
                    {
     //                   dwBarcode.Reset();
                        layBarcodeOne.Reset();

                        layBarcodeOne.InsertRow(0);
                        layBarcodeOne.SetItemValue(0, "jundal_gubun", this.layBarcode.GetItemString(j, "jundal_gubun"));
                        layBarcodeOne.SetItemValue(0, "jundal_gubun_name", this.layBarcode.GetItemString(j, "jundal_gubun_name"));
                        layBarcodeOne.SetItemValue(0, "specimen_code", this.layBarcode.GetItemString(j, "specimen_code"));
                        layBarcodeOne.SetItemValue(0, "specimen_name", this.layBarcode.GetItemString(j, "specimen_name"));
                        layBarcodeOne.SetItemValue(0, "tube_code", this.layBarcode.GetItemString(j, "tube_code"));
                        layBarcodeOne.SetItemValue(0, "tube_name", this.layBarcode.GetItemString(j, "tube_name"));
                        layBarcodeOne.SetItemValue(0, "specimen_ser", this.layBarcode.GetItemString(j, "specimen_ser"));
                        layBarcodeOne.SetItemValue(0, "bunho", this.layBarcode.GetItemString(j, "bunho"));
                        layBarcodeOne.SetItemValue(0, "suname", this.layBarcode.GetItemString(j, "suname"));
                        layBarcodeOne.SetItemValue(0, "gwa_name", this.layBarcode.GetItemString(j, "gwa_name"));
                        layBarcodeOne.SetItemValue(0, "danger_yn", this.layBarcode.GetItemString(j, "danger_yn"));
                        layBarcodeOne.SetItemValue(0, "specimen_ser_ba", this.layBarcode.GetItemString(j, "specimen_ser_ba"));
                        layBarcodeOne.SetItemValue(0, "jangbi_code", this.layBarcode.GetItemString(j, "jangbi_code"));
                        layBarcodeOne.SetItemValue(0, "jangbi_name", this.layBarcode.GetItemString(j, "jangbi_name"));
                        layBarcodeOne.SetItemValue(0, "in_out_gubun", this.layBarcode.GetItemString(j, "in_out_gubun"));
                        layBarcodeOne.SetItemValue(0, "gumsa_name_re", this.layBarcode.GetItemString(j, "gumsa_name_re"));

           //             dwBarcode.FillData(layBarcodeOne.LayoutTable);
           //             dwBarcode.PrintProperties.PrinterName = printSetName;
                        try
                        {
            //                dwBarcode.Print();
                            if (!TypeCheck.IsNull(txtBarcode.GetDataValue()))
                            {
                                this.lbSpecimenSer.Text = txtBarcode.GetDataValue();
                                txtBarcode.SetDataValue("");
                                txtBarcode.Focus();
                            }
                        }
                        catch { }
                    }
                }
            }
            catch (Exception err)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("C #03\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }
        #endregion

        #region [ #04 GetPrintName() 프린터 이름 가져오기 ]
        private string GetPrintName()
        {
            string returnValue = string.Empty;

            try
            {
//                object objResult = null;
//                BindVarCollection bindVar = new BindVarCollection();
//                string tmpQuery = @"
//								 SELECT B_PRINT_NAME
//								   FROM ADM3300
//								  WHERE IP_ADDR          = :f_ip_addr";

//                bindVar.Add("f_ip_addr", Service.ClientIP.ToString());

//                try
//                {
//                    objResult = Service.ExecuteScalar(tmpQuery, bindVar);
//                }
//                catch
//                {
//                    XMessageBox.Show("C #04-1\n\n" + Service.ErrFullMsg);
//                }

//                if (objResult != null) returnValue = objResult.ToString();

                CPL2010U00LayPrintNameArgs args = new CPL2010U00LayPrintNameArgs(Service.ClientIP.ToString());
                CPL2010U00LayPrintNameResult result =
                    CloudService.Instance.Submit<CPL2010U00LayPrintNameResult, CPL2010U00LayPrintNameArgs>(
                        args);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    returnValue = result.PrintName;
                }
                else
                {
                    XMessageBox.Show("C #04-1\n\n" + Service.ErrFullMsg);
                }
            }
            catch (Exception err)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("C #04\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }

            return returnValue;
        }
        #endregion
    }
}

