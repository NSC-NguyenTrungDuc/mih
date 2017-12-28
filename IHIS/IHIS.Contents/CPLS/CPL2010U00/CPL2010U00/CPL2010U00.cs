#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CPLS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL2010U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL2010U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.SingleLayout vsvJubsuja;
        private IHIS.Framework.SingleLayout vsvPa;
        private IHIS.Framework.SingleLayout layPa;
        private IHIS.Framework.XFindWorker fwkPa;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private IHIS.Framework.FindColumnInfo findColumnInfo5;
        private IHIS.Framework.MultiLayout layBarcode;
        private IHIS.Framework.MultiLayout layBarcode2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private IHIS.Framework.SingleLayout layPrintName;
        private IHIS.Framework.MultiLayout layBarcodeOne;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem8;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem11;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private SingleLayoutItem singleLayoutItem18;
        private SingleLayoutItem singleLayoutItem19;
        private SingleLayoutItem singleLayoutItem20;
        private SingleLayoutItem singleLayoutItem21;
        private SingleLayoutItem singleLayoutItem22;
        private SingleLayoutItem singleLayoutItem23;
        private SingleLayoutItem singleLayoutItem24;
        private SingleLayoutItem singleLayoutItem25;
        private SingleLayoutItem singleLayoutItem26;
        private SingleLayoutItem singleLayoutItem27;
        private SingleLayoutItem singleLayoutItem28;
        private MultiLayout layChkNames;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayout layBarcodeTemp;
        private MultiLayout layBarcodeTemp2;
        private SingleLayoutItem singleLayoutItem32;
        private SingleLayoutItem singleLayoutItem33;
        private SingleLayoutItem singleLayoutItem34;
        private SingleLayoutItem singleLayoutItem35;
        private MultiLayoutItem multiLayoutItem79;
        private MultiLayoutItem multiLayoutItem80;
        private MultiLayoutItem multiLayoutItem81;
        private MultiLayoutItem multiLayoutItem82;
        private MultiLayoutItem multiLayoutItem83;
        private MultiLayoutItem multiLayoutItem84;
        private MultiLayoutItem multiLayoutItem85;
        private MultiLayoutItem multiLayoutItem86;
        private MultiLayoutItem multiLayoutItem87;
        private MultiLayoutItem multiLayoutItem88;
        private MultiLayoutItem multiLayoutItem89;
        private MultiLayoutItem multiLayoutItem90;
        private MultiLayoutItem multiLayoutItem91;
        private MultiLayoutItem multiLayoutItem92;
        private MultiLayoutItem multiLayoutItem93;
        private MultiLayoutItem multiLayoutItem94;
        private MultiLayoutItem multiLayoutItem95;
        private MultiLayoutItem multiLayoutItem96;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private MultiLayoutItem multiLayoutItem70;
        private MultiLayoutItem multiLayoutItem71;
        private MultiLayoutItem multiLayoutItem72;
        private MultiLayoutItem multiLayoutItem73;
        private MultiLayoutItem multiLayoutItem74;
        private MultiLayoutItem multiLayoutItem75;
        private MultiLayoutItem multiLayoutItem76;
        private MultiLayoutItem multiLayoutItem77;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem78;
        private MultiLayoutItem multiLayoutItem98;
        private MultiLayoutItem multiLayoutItem99;
        private MultiLayoutItem multiLayoutItem100;
        private MultiLayoutItem multiLayoutItem101;
        private MultiLayoutItem multiLayoutItem102;
        private MultiLayoutItem multiLayoutItem103;
        private MultiLayoutItem multiLayoutItem104;
        private MultiLayoutItem multiLayoutItem105;
        private MultiLayoutItem multiLayoutItem106;
        private MultiLayoutItem multiLayoutItem107;
        private MultiLayoutItem multiLayoutItem108;
        private MultiLayoutItem multiLayoutItem109;
        private MultiLayoutItem multiLayoutItem110;
        private MultiLayoutItem multiLayoutItem111;
        private MultiLayoutItem multiLayoutItem112;
        private MultiLayoutItem multiLayoutItem113;
        private MultiLayoutItem multiLayoutItem114;
        private MultiLayoutItem multiLayoutItem115;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem97;
        private XPanel xPanel6;
        private XPanel panMain;
        private XPanel pnlPaInfo;
        private XPictureBox pbxJusa;
        private XButton btnJusa;
        private XDisplayBox dbxPaNote;
        private XPaInfoBox paInfoBox;
        private RadioButton rbxJubsu;
        private RadioButton rbxMijubsu;
        private XFindBox fbxBunho;
        private XDisplayBox dbxBirth;
        private XDisplayBox dbxSexAge;
        private XDisplayBox dbxTel;
        private XDisplayBox dbxAddress;
        private XLabel xLabel7;
        private XDisplayBox dbxSuname;
        private XLabel xLabel6;
        private XDatePicker dtpOrderDate;
        private XLabel xLabel4;
        private XLabel xLabel3;
        private XPanel xPanel3;
        private XPanel xPanel5;
        private XMstGrid grdSpecimen;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell47;
        private XPanel xPanel4;
        private XEditGrid grdTube;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell50;
        private XMstGrid grdOrder;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell44;
        private XMstGrid grdPaList;
        private XPanel pnlLeft;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XPanel xPanel8;
        private XButton btnPrintSetup;
        private XButton btnBarcode;
 //       private XDataWindow dwBarcode;
        private XButton btnChangeTime;
        private XButton xButton5;
        private XPanel xPanel1;
        private XPanel xPanel7;
        private XLabel xLabel1;
        private XTextBox txtJu;
        private XEditGridCell xEditGridCell58;
        private XLabel xLabel2;
        private XTextBox txtDoctor;
        private Timer timer1;
        private XDisplayBox dbxSuname2;
        private Panel pnlStatus;
        private Label lbStatus;
        private XProgressBar pgbProgress;
        private XButton btnOrderCancel;
        private XEditGridCell xEditGridCell60;
        private XFindWorker fwkActor;
        private FindColumnInfo findColumnInfo6;
        private FindColumnInfo findColumnInfo7;
        private SingleLayout layCommon;
        private XDictComboBox cboTime;
        private XLabel xLabel8;
        private XLabel lbTime;
        private XButton btnUseTimeChk;
        private XTextBox txtTimeInterval;
        private XTextBox tbxTimer;
        private XButton btnChkAllJubsu;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XComboItem xComboItem7;
        private XLabel xLabel9;
        private XEditGridCell xEditGridCell37;
        private MultiLayout mlayConstantInfo;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private XButton btnUseAlarmChk;
        private XEditGridCell xEditGridCell64;
        private XDatePicker dtpOrderToDate;
        private XPatientBox paBox;
        private XLabel lbSuname;
        private XButton btnOrderPrint;
        //private XDataWindow dwOrderPrint;
        private MultiLayout layOrderPrint;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private Label label1;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private IContainer components;

        private String CACHE_ADM3200_FWKACTOR = "CPL2010U00.ADM3200.fwkActor";
        private String CACHE_NUR0102_CBOTIME = "CPL2010U00.NUR0102.cboTime";
        private String CACHE_ADM3200_CBXACTOR = "CPL2010U00.ADM3200.cbxActor";
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell69;
        CPL2010U00SaveLayoutResult saveLayoutResult = new CPL2010U00SaveLayoutResult();
        private SplitContainer splitContainer1;
        private XLabel xLabel5;
        private XButton btnChange;
        private XDisplayBox dbxDocName;
        private XDisplayBox dbxDocCode;
        private XButtonList btnList;
        private XLabel xLabel10;
        private XTextBox txtSpecimenNo;
        private bool firstOpen = true;

        public CPL2010U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            InitDataWindow();
            //Initialize cached data
            fwkActor.ExecuteQuery = LoadDataFwkActor;
            cboTime.ExecuteQuery = LoadDataCboTime;
            dbxDocCode.Text = UserInfo.UserID;
            dbxDocName.Text = UserInfo.UserName;
            // cbxActor.ExecuteQuery = LoadDataCbxActor;

            //Initialize ParamList
            grdPaList.ParamList = new List<string>(new String[] { "f_hosp_code", "f_from_date", "f_to_date", "f_bunho" });
            grdOrder.ParamList = new List<string>(new String[] { "f_hosp_code", "f_from_date", "f_to_date", "f_bunho", "f_mijubsu", "f_reser_yn", "f_emergency_yn", "f_doctor" });
            grdTube.ParamList = new List<string>(new String[] { "f_hosp_code", "f_order_date", "f_order_time", "f_bunho" });
            grdSpecimen.ParamList = new List<string>(new String[]
            {
                "f_hosp_code", 	
                "f_order_date", 
                "f_bunho", 		
                "f_gwa", 			
                "f_order_time", 
                "f_doctor", 		
                "f_reser_date", 
                "f_jubsu_date", 
                "f_jubsu_time", 
                "f_jubsuja", 		
                "f_group_ser", 	
                "f_reser_yn", 		
                "f_emergency_yn"
                
            });
            mlayConstantInfo.ParamList = new List<string>(new String[] { "f_code_type" });
            layPrintName.ParamList = new List<string>(new String[] { "f_ip_addr" });
            layBarcodeTemp2.ParamList = new List<string>(new String[] { "f_hosp_code", "f_specimen_ser" });
            vsvPa.ParamList = new List<string>(new String[] { "f_bunho" });
            layChkNames.ParamList = new List<string>(new String[] { "f_bunho", "f_reser_date" });

            //Initialize control for Cloud service
            grdPaList.ExecuteQuery = LoadDataGrdPaList;
            grdOrder.ExecuteQuery = LoadDataGrdOrder;
            grdTube.ExecuteQuery = LoadDataGrdTube;
            grdSpecimen.ExecuteQuery = LoadDataGrdSpecimen;
            mlayConstantInfo.ExecuteQuery = LoadDataMLayConstantInfo;
            layPrintName.ExecuteQuery = LoadDataLayPrintName;
            layBarcodeTemp2.ExecuteQuery = LoadDataLayBarcodetemp2;
            layBarcodeTemp.ExecuteQuery = LoadDataLayBarcodetemp;
            vsvPa.ExecuteQuery = LoadDataVsvPa;
            layChkNames.ExecuteQuery = LoadDataLayChkNames;

            //sub-task MED-9280
            string sysDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            this.dtpOrderDate.SetDataValue(sysDate);
            this.dtpOrderToDate.SetDataValue(sysDate);
            CPL2010U00OpenScreenCompositeFirst();
            // cbxActor.SetDictDDLB();
            cboTime.SetDictDDLB();

            // https://sofiamedix.atlassian.net/browse/MED-15058
            if (NetInfo.Language == LangMode.Jr)
            {
                grdSpecimen.AutoSizeColumn(xEditGridCell8.Col, 22);
                grdSpecimen.AutoSizeColumn(xEditGridCell46.Col, 22);
                grdSpecimen.AutoSizeColumn(xEditGridCell9.Col, 153);
                grdSpecimen.AutoSizeColumn(xEditGridCell10.Col, 70);
                grdSpecimen.AutoSizeColumn(xEditGridCell11.Col, 210);
                grdSpecimen.AutoSizeColumn(xEditGridCell13.Col, 100);
                grdSpecimen.AutoSizeColumn(xEditGridCell51.Col, 100);
                grdSpecimen.AutoSizeColumn(xEditGridCell15.Col, 110);
                grdSpecimen.AutoSizeColumn(xEditGridCell47.Col, 22);
                grdSpecimen.AutoSizeColumn(xEditGridCell16.Col, 85);
                grdSpecimen.AutoSizeColumn(xEditGridCell58.Col, 30);
                grdSpecimen.AutoSizeColumn(xEditGridCell26.Col, 30);
            }
        }

        #region Load data from Cloud

        private List<object[]> LoadDataVsvPa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00VsvPaArgs args = new CPL2010U00VsvPaArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            CPL2010U00VsvPaResult result = CloudService.Instance.Submit<CPL2010U00VsvPaResult, CPL2010U00VsvPaArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.SuName
                });
            }
            return res;
        }



        private List<object[]> LoadDataLayChkNames(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00LayChkNamesArgs args = new CPL2010U00LayChkNamesArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.ReserDate = bc["f_reser_date"] != null ? bc["f_reser_date"].VarValue : "";
            CPL2010U00LayChkNamesResult result = CloudService.Instance.Submit<CPL2010U00LayChkNamesResult, CPL2010U00LayChkNamesArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00LayChkNameListItemInfo item in result.LayChkNamesList)
                {
                    object[] objects = 
				{ 
					item.Suname, 
					item.OrderDate1, 
					item.OrderDate2, 
					item.CodeName
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataLayBarcodetemp(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            List<CPL2010U00LayBarcodeTempListItemInfo> layList = saveLayoutResult.LayBarcodeTempList;
            if (layList != null && layList.Count > 0)
            {
                foreach (CPL2010U00LayBarcodeTempListItemInfo item in layList)
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

        private List<object[]> LoadDataLayBarcodetemp2(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00LayBarcodeTemp2Args args = new CPL2010U00LayBarcodeTemp2Args();
            args.SpecimentSer = bc["f_specimen_ser"] != null ? bc["f_specimen_ser"].VarValue : "";
            CPL2010U00LayBarcodeTemp2Result result = CloudService.Instance.Submit<CPL2010U00LayBarcodeTemp2Result, CPL2010U00LayBarcodeTemp2Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00LayBarcodeTempListItemInfo item in result.LayList)
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



        private List<object[]> LoadDataLayPrintName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00LayPrintNameArgs args = new CPL2010U00LayPrintNameArgs();
            args.IpAddress = bc["f_ip_addr"] != null ? bc["f_ip_addr"].VarValue : "";
            CPL2010U00LayPrintNameResult result = CloudService.Instance.Submit<CPL2010U00LayPrintNameResult, CPL2010U00LayPrintNameArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.PrintName
                });
            }
            return res;
        }



        private List<object[]> LoadDataMLayConstantInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00MlayConstantInfoArgs args = new CPL2010U00MlayConstantInfoArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            CPL2010U00MlayConstantInfoResult result = CloudService.Instance.Submit<CPL2010U00MlayConstantInfoResult, CPL2010U00MlayConstantInfoArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00MlayConstantInfoListItemInfo item in result.MLayConstantInfoList)
                {
                    object[] objects = 
				{ 
					item.Code, 
					item.CodeName, 
					item.CodeValue
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataGrdSpecimen(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00GrdSpecimenArgs args = new CPL2010U00GrdSpecimenArgs();
            args.MJubsuYn = this.mJubsu_yn;
            args.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            args.OrderTime = bc["f_order_time"] != null ? bc["f_order_time"].VarValue : "";
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.ReserDate = bc["f_reser_date"] != null ? bc["f_reser_date"].VarValue : "";
            args.JubsuDate = bc["f_jubsu_date"] != null ? bc["f_jubsu_date"].VarValue : "";
            args.JubsuTime = bc["f_jubsu_time"] != null ? bc["f_jubsu_time"].VarValue : "";
            args.Jubsuja = bc["f_jubsuja"] != null ? bc["f_jubsuja"].VarValue : "";
            args.GroupSer = bc["f_group_ser"] != null ? bc["f_group_ser"].VarValue : "";
            args.ReserYn = bc["f_reser_yn"] != null ? bc["f_reser_yn"].VarValue : "";
            args.EmergencyYn = bc["f_emergency_yn"] != null ? bc["f_emergency_yn"].VarValue : "";
            CPL2010U00GrdSpecimenResult result = CloudService.Instance.Submit<CPL2010U00GrdSpecimenResult, CPL2010U00GrdSpecimenArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00GrdSpecimenListItemInfo item in result.GrdSpecimenList)
                {
                    object[] objects = 
				{ 
					item.Pkcpl2010, 
					item.SunabYn, 
					item.JubsuFlag, 
					item.SlipName, 
					item.HangmogCode, 
					item.GumsaName, 
					item.SpecimenCode, 
					item.SpecimenName, 
					item.Emergency, 
					item.TubeCode, 
					item.TubeName, 
					item.SpecimenSer, 
					item.CommentJuCode, 
					item.Fkocs1003, 
					item.GroupGubun, 
					item.PartJubsuFlag, 
					item.GumJubsuFlag, 
					item.Dummy, 
					item.ModifyYn, 
					item.ModifyYn1, 
					item.JundalGubun, 
					item.JundalGubunName, 
					item.Jubsuja, 
					item.OrderDate, 
					item.Bunho, 
					item.JubsuDate, 
					item.JubsuTime, 
					item.OrderTime, 
					item.GroupHangmog, 
					item.SpcialName, 
					item.CanYn, 
					item.Barcode, 
					item.BarcodeName, 
					item.DocComment, 
					item.UitakCode, 
					item.MiddleResult, 
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataGrdTube(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00GrdTubeQueryStartingArgs args = new CPL2010U00GrdTubeQueryStartingArgs();
            args.RbxJubsuChecked = this.rbxJubsu.Checked;
            args.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            args.OrderTime = bc["f_order_time"] != null ? bc["f_order_time"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            CPL2010U00GrdTubeQueryStartingResult result = CloudService.Instance.Submit<CPL2010U00GrdTubeQueryStartingResult, CPL2010U00GrdTubeQueryStartingArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00GrdTubeListItemInfo item in result.GrdTubeList)
                {
                    object[] objects = 
				{ 
					item.TubeCode, 
					item.TubeName, 
					item.Cnt
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataGrdOrder(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00GrdOrderArgs args = new CPL2010U00GrdOrderArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.Mijubsu = bc["f_mijubsu"] != null ? bc["f_mijubsu"].VarValue : "";
            args.ReserYn = bc["f_reser_yn"] != null ? bc["f_reser_yn"].VarValue : "";
            args.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            args.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.EmergencyYn = bc["f_emergency_yn"] != null ? bc["f_emergency_yn"].VarValue : "";
            CPL2010U00GrdOrderResult result = CloudService.Instance.Submit<CPL2010U00GrdOrderResult, CPL2010U00GrdOrderArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00GrdOrderListItemInfo item in result.GrdOrderList)
                {
                    object[] objects = 
				{ 
					item.OrderDate, 
					item.OrderTime, 
					item.GwaName, 
					item.InOutGubun, 
					item.DoctorName, 
					item.JubsuDate, 
					item.JubsuTime, 
					item.AfterActYn, 
					item.Bunho, 
					item.Gwa, 
					item.Gubun, 
					item.Doctor, 
					item.ReserDate, 
					item.Jubsuja, 
					item.JubsujaName, 
					item.GroupSer,
                    item.IfDataSendYn
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataGrdPaList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00GrdPaListArgs args = new CPL2010U00GrdPaListArgs();
            args.RbxJubsuChecked = this.rbxJubsu.Checked;
            args.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            args.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            CPL2010U00GrdPaListResult result = CloudService.Instance.Submit<CPL2010U00GrdPaListResult, CPL2010U00GrdPaListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00GrdPaListItemInfo item in result.GrdPalistList)
                {
                    object[] objects = 
				{ 
                    item.TrialYn,
					item.Bunho, 
					item.Suname, 
					item.InOutGubun, 
					item.GwaName, 
					item.ReserYn, 
					item.Doctor, 
					item.DoctorName, 
					item.KijunDate, 
					item.EmergencyYn, 
					item.NaewonTime
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private IList<object[]> LoadDataCbxActor(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboADM3200CbxActorArgs args = new ComboADM3200CbxActorArgs();
            //ComboResult result = CacheService.Instance.Get<ComboADM3200CbxActorArgs, ComboResult>(CACHE_ADM3200_CBXACTOR,
            //    args, delegate(ComboResult cboResult)
            //    {
            //        return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
            //               cboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<ComboADM3200CbxActorArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
	                {
	                    info.Code,
	                    info.CodeName
	                });
                }
            }

            return dataList;
        }

        private IList<object[]> LoadDataCboTime(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboNUR0102CboTimeArgs args = new ComboNUR0102CboTimeArgs();
            //ComboResult result = CacheService.Instance.Get<ComboNUR0102CboTimeArgs, ComboResult>(CACHE_NUR0102_CBOTIME,
            //    args, delegate(ComboResult cboResult)
            //    {
            //        return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
            //               cboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<ComboNUR0102CboTimeArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
	                {
	                    info.Code,
	                    info.CodeName
	                });
                }
            }

            return dataList;
        }

        private IList<object[]> LoadDataFwkActor(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboADM3200FwkActorArgs args = new ComboADM3200FwkActorArgs();
            //ComboResult result = CacheService.Instance.Get<ComboADM3200FwkActorArgs, ComboResult>(CACHE_ADM3200_FWKACTOR,
            //    args, delegate(ComboResult cboResult)
            //    {
            //        return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
            //               cboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<ComboADM3200FwkActorArgs, ComboResult>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
	                {
	                    info.Code,
	                    info.CodeName
	                });
                }
            }

            return dataList;
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

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010U00));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.grdOrder = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.grdTube = new IHIS.Framework.XEditGrid();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.fwkPa = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.vsvJubsuja = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem33 = new IHIS.Framework.SingleLayoutItem();
            this.vsvPa = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem32 = new IHIS.Framework.SingleLayoutItem();
            this.layPa = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem20 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem21 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem22 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem23 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem24 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem25 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem26 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem27 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem28 = new IHIS.Framework.SingleLayoutItem();
            this.layBarcode = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem79 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem80 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem81 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem82 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem83 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem84 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem85 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem86 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem87 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem88 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem89 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem90 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem91 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem92 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem93 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem94 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcode2 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem70 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem71 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem72 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem73 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem74 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem75 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem76 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem77 = new IHIS.Framework.MultiLayoutItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.layPrintName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem34 = new IHIS.Framework.SingleLayoutItem();
            this.layBarcodeOne = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.layChkNames = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcodeTemp = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem97 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcodeTemp2 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem78 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem98 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem99 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem100 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem101 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem102 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem103 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem104 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem105 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem106 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem107 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem108 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem109 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem110 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem111 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem112 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem113 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem114 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem115 = new IHIS.Framework.MultiLayoutItem();
            this.singleLayoutItem35 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.panMain = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdSpecimen = new IHIS.Framework.XMstGrid();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.txtJu = new IHIS.Framework.XTextBox();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.txtDoctor = new IHIS.Framework.XTextBox();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.pnlPaInfo = new IHIS.Framework.XPanel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.txtSpecimenNo = new IHIS.Framework.XTextBox();
            this.btnChange = new IHIS.Framework.XButton();
            this.dbxDocName = new IHIS.Framework.XDisplayBox();
            this.dbxDocCode = new IHIS.Framework.XDisplayBox();
            this.pbxJusa = new IHIS.Framework.XPictureBox();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dbxSuname2 = new IHIS.Framework.XDisplayBox();
            this.btnJusa = new IHIS.Framework.XButton();
            this.dbxPaNote = new IHIS.Framework.XDisplayBox();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.dbxBirth = new IHIS.Framework.XDisplayBox();
            this.dbxSexAge = new IHIS.Framework.XDisplayBox();
            this.dbxTel = new IHIS.Framework.XDisplayBox();
            this.dbxAddress = new IHIS.Framework.XDisplayBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.paInfoBox = new IHIS.Framework.XPaInfoBox();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdPaList = new IHIS.Framework.XMstGrid();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dtpOrderDate = new IHIS.Framework.XDatePicker();
            this.dtpOrderToDate = new IHIS.Framework.XDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSuname = new IHIS.Framework.XLabel();
            this.rbxJubsu = new System.Windows.Forms.RadioButton();
            this.txtTimeInterval = new IHIS.Framework.XTextBox();
            this.tbxTimer = new IHIS.Framework.XTextBox();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.lbTime = new IHIS.Framework.XLabel();
            this.rbxMijubsu = new System.Windows.Forms.RadioButton();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.btnOrderPrint = new IHIS.Framework.XButton();
            this.btnUseAlarmChk = new IHIS.Framework.XButton();
            this.btnChkAllJubsu = new IHIS.Framework.XButton();
            this.btnUseTimeChk = new IHIS.Framework.XButton();
            this.btnOrderCancel = new IHIS.Framework.XButton();
            this.btnPrintSetup = new IHIS.Framework.XButton();
            this.btnBarcode = new IHIS.Framework.XButton();
            this.btnChangeTime = new IHIS.Framework.XButton();
            this.xButton5 = new IHIS.Framework.XButton();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.fwkActor = new IHIS.Framework.XFindWorker();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo7 = new IHIS.Framework.FindColumnInfo();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.mlayConstantInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.layOrderPrint = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layChkNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp2)).BeginInit();
            this.xPanel6.SuspendLayout();
            this.panMain.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecimen)).BeginInit();
            this.xPanel7.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.pnlPaInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxJusa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paInfoBox)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "검사예약.gif");
            this.ImageList.Images.SetKeyName(3, "12.gif");
            this.ImageList.Images.SetKeyName(4, "13.gif");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.pnlStatus);
            this.splitContainer1.Panel1.Controls.Add(this.grdOrder);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.grdTube);
            // 
            // pnlStatus
            // 
            resources.ApplyResources(this.pnlStatus, "pnlStatus");
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.lbStatus);
            this.pnlStatus.Controls.Add(this.pgbProgress);
            this.pnlStatus.Name = "pnlStatus";
            // 
            // lbStatus
            // 
            resources.ApplyResources(this.lbStatus, "lbStatus");
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Name = "lbStatus";
            // 
            // pgbProgress
            // 
            resources.ApplyResources(this.pgbProgress, "pgbProgress");
            this.pgbProgress.Name = "pgbProgress";
            // 
            // grdOrder
            // 
            resources.ApplyResources(this.grdOrder, "grdOrder");
            this.grdOrder.ApplyPaintEventToAllColumn = true;
            this.grdOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell20,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell61,
            this.xEditGridCell6,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell44,
            this.xEditGridCell36,
            this.xEditGridCell63,
            this.xEditGridCell67,
            this.xEditGridCell69});
            this.grdOrder.ColPerLine = 7;
            this.grdOrder.Cols = 8;
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 1;
            this.grdOrder.HeaderHeights.Add(26);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.Rows = 2;
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrder_RowFocusChanged);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);
            this.grdOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrder_QueryStarting);
            this.grdOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOrder_QueryEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "order_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 92;
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.CellName = "order_time";
            this.xEditGridCell20.CellWidth = 53;
            this.xEditGridCell20.Col = 4;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.Mask = "##:##";
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 137;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.SuppressRepeating = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "in_out_gubun";
            this.xEditGridCell3.CellWidth = 45;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.SuppressRepeating = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "doctor_name";
            this.xEditGridCell4.CellWidth = 132;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "jubsu_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 88;
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell61.CellName = "jubsu_time";
            this.xEditGridCell61.CellWidth = 65;
            this.xEditGridCell61.Col = 7;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.Mask = "##:##";
            this.xEditGridCell61.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell61.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "after_act_yn";
            this.xEditGridCell6.CellWidth = 30;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.CellName = "bunho";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.CellName = "gwa";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.CellName = "gubun";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.CellName = "doctor";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell44.CellName = "reser_date";
            this.xEditGridCell44.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell44.CellWidth = 113;
            this.xEditGridCell44.Col = 5;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.CellName = "jubsuja";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell63.CellName = "jubsuja_name";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            this.xEditGridCell63.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            this.xEditGridCell63.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell67.CellName = "group_ser";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            this.xEditGridCell67.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            this.xEditGridCell67.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell69.CellName = "if_data_send_yn";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            this.xEditGridCell69.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            this.xEditGridCell69.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // grdTube
            // 
            resources.ApplyResources(this.grdTube, "grdTube");
            this.grdTube.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell50});
            this.grdTube.ColPerLine = 4;
            this.grdTube.Cols = 5;
            this.grdTube.ExecuteQuery = null;
            this.grdTube.FixedCols = 1;
            this.grdTube.FixedRows = 1;
            this.grdTube.HeaderHeights.Add(23);
            this.grdTube.Name = "grdTube";
            this.grdTube.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdTube.ParamList")));
            this.grdTube.RowHeaderVisible = true;
            this.grdTube.Rows = 2;
            this.grdTube.ToolTipActive = true;
            this.grdTube.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdTube_GridColumnProtectModify);
            this.grdTube.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdTube_ItemValueChanging);
            this.grdTube.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdTube_QueryStarting);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.CellName = "tube_code";
            this.xEditGridCell17.CellWidth = 40;
            this.xEditGridCell17.Col = 1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.CellName = "tube_name";
            this.xEditGridCell18.CellWidth = 194;
            this.xEditGridCell18.Col = 2;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellName = "cnt";
            this.xEditGridCell19.CellWidth = 54;
            this.xEditGridCell19.Col = 3;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.CellName = "print_yn";
            this.xEditGridCell50.CellWidth = 33;
            this.xEditGridCell50.Col = 4;
            this.xEditGridCell50.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkPa
            // 
            this.fwkPa.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2,
            this.findColumnInfo3,
            this.findColumnInfo4,
            this.findColumnInfo5});
            this.fwkPa.ExecuteQuery = null;
            this.fwkPa.FormText = global::IHIS.CPLS.Properties.Resources.fwkPaText;
            this.fwkPa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkPa.ParamList")));
            this.fwkPa.ServerFilter = true;
            this.fwkPa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkPa_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "bunho";
            this.findColumnInfo1.ColWidth = 113;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "suname";
            this.findColumnInfo2.ColWidth = 135;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "in_out_gubun";
            this.findColumnInfo3.ColWidth = 40;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "gwa_name";
            this.findColumnInfo4.ColWidth = 207;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo5.ColName = "order_time";
            this.findColumnInfo5.ColWidth = 69;
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            this.findColumnInfo5.Mask = "##:##";
            // 
            // vsvJubsuja
            // 
            this.vsvJubsuja.ExecuteQuery = null;
            this.vsvJubsuja.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem33});
            this.vsvJubsuja.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvJubsuja.ParamList")));
            this.vsvJubsuja.QueryStarting += new System.ComponentModel.CancelEventHandler(this.vsvJubsuja_QueryStarting);
            // 
            // singleLayoutItem33
            // 
            this.singleLayoutItem33.DataName = "jubsuja_name";
            // 
            // vsvPa
            // 
            this.vsvPa.ExecuteQuery = null;
            this.vsvPa.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem32});
            this.vsvPa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvPa.ParamList")));
            this.vsvPa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.vsvPa_QueryStarting);
            // 
            // singleLayoutItem32
            // 
            this.singleLayoutItem32.DataName = "suname";
            // 
            // layPa
            // 
            this.layPa.ExecuteQuery = null;
            this.layPa.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem11,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17,
            this.singleLayoutItem18,
            this.singleLayoutItem19,
            this.singleLayoutItem20,
            this.singleLayoutItem21,
            this.singleLayoutItem22,
            this.singleLayoutItem23,
            this.singleLayoutItem24,
            this.singleLayoutItem25,
            this.singleLayoutItem26,
            this.singleLayoutItem27,
            this.singleLayoutItem28});
            this.layPa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPa.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "suname";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "sex";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "age";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "birth";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "address";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "ho_dong";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "ho_code";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "gwa";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "gwa_name";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "doctor";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "doctor_name";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "resident";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.DataName = "resident_name";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "in_out_gubun";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.DataName = "tel";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "jubsu_date";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "jubsu_time";
            // 
            // singleLayoutItem20
            // 
            this.singleLayoutItem20.DataName = "jubsuja";
            // 
            // singleLayoutItem21
            // 
            this.singleLayoutItem21.DataName = "part_jubsu_date";
            // 
            // singleLayoutItem22
            // 
            this.singleLayoutItem22.DataName = "part_jubsu_time";
            // 
            // singleLayoutItem23
            // 
            this.singleLayoutItem23.DataName = "part_jubsuja";
            // 
            // singleLayoutItem24
            // 
            this.singleLayoutItem24.DataName = "tat1";
            // 
            // singleLayoutItem25
            // 
            this.singleLayoutItem25.DataName = "tat2";
            // 
            // singleLayoutItem26
            // 
            this.singleLayoutItem26.DataName = "flag";
            // 
            // singleLayoutItem27
            // 
            this.singleLayoutItem27.DataName = "sex_age";
            // 
            // singleLayoutItem28
            // 
            this.singleLayoutItem28.DataName = "pa_note";
            // 
            // layBarcode
            // 
            this.layBarcode.ExecuteQuery = null;
            this.layBarcode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem79,
            this.multiLayoutItem80,
            this.multiLayoutItem81,
            this.multiLayoutItem82,
            this.multiLayoutItem83,
            this.multiLayoutItem84,
            this.multiLayoutItem85,
            this.multiLayoutItem86,
            this.multiLayoutItem87,
            this.multiLayoutItem88,
            this.multiLayoutItem89,
            this.multiLayoutItem90,
            this.multiLayoutItem91,
            this.multiLayoutItem92,
            this.multiLayoutItem93,
            this.multiLayoutItem94,
            this.multiLayoutItem95,
            this.multiLayoutItem96});
            this.layBarcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcode.ParamList")));
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "jundal_gubun";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "specimen_code";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "specimen_name";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "tube_code";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "tube_name";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "in_out_gubun";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "specimen_ser";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "bunho";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "suname";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "gwa_name";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "danger_yn";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "jangbi_code";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "jangbi_name";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "tube_max_amt";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "tube_numbering";
            // 
            // layBarcode2
            // 
            this.layBarcode2.ExecuteQuery = null;
            this.layBarcode2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem60,
            this.multiLayoutItem61,
            this.multiLayoutItem62,
            this.multiLayoutItem63,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69,
            this.multiLayoutItem70,
            this.multiLayoutItem71,
            this.multiLayoutItem72,
            this.multiLayoutItem73,
            this.multiLayoutItem74,
            this.multiLayoutItem75,
            this.multiLayoutItem76,
            this.multiLayoutItem77});
            this.layBarcode2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcode2.ParamList")));
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "jundal_gubun";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "specimen_code";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "specimen_name";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "tube_code";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "tube_name";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "in_out_gubun";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "specimen_ser";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "bunho";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "suname";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "gwa_name";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "danger_yn";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "jangbi_code";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "jangbi_name";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "tube_max_amt";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "tube_numbering";
            // 
            // layPrintName
            // 
            this.layPrintName.ExecuteQuery = null;
            this.layPrintName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem34});
            this.layPrintName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPrintName.ParamList")));
            this.layPrintName.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPrintName_QueryStarting);
            // 
            // singleLayoutItem34
            // 
            this.singleLayoutItem34.DataName = "print_name";
            // 
            // layBarcodeOne
            // 
            this.layBarcodeOne.ExecuteQuery = null;
            this.layBarcodeOne.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41});
            this.layBarcodeOne.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeOne.ParamList")));
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "jundal_gubun";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "specimen_code";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "specimen_name";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "tube_code";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "tube_name";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "in_out_gubun";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "specimen_ser";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "bunho";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "suname";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "gwa_name";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "danger_yn";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "jangbi_code";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "jangbi_name";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "tube_max_amt";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "tube_numbering";
            // 
            // layChkNames
            // 
            this.layChkNames.ExecuteQuery = null;
            this.layChkNames.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layChkNames.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layChkNames.ParamList")));
            this.layChkNames.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layChkNames_QueryStarting);
            this.layChkNames.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layChkNames_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "suname";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "order_date1";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "order_date2";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "chkname";
            // 
            // layBarcodeTemp
            // 
            this.layBarcodeTemp.ExecuteQuery = null;
            this.layBarcodeTemp.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem97});
            this.layBarcodeTemp.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeTemp.ParamList")));
            this.layBarcodeTemp.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBarcodeTemp_QueryStarting);
            this.layBarcodeTemp.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layBarcodeTemp_QueryEnd);
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "jundal_gubun";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "specimen_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "specimen_name";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "tube_code";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "tube_name";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "in_out_gubun";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "specimen_ser";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "bunho";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "suname";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "gwa_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "danger_yn";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "jangbi_code";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "jangbi_name";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "tube_count";
            this.multiLayoutItem21.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "tube_max_amt";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "tube_numbering";
            // 
            // layBarcodeTemp2
            // 
            this.layBarcodeTemp2.ExecuteQuery = null;
            this.layBarcodeTemp2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem78,
            this.multiLayoutItem98,
            this.multiLayoutItem99,
            this.multiLayoutItem100,
            this.multiLayoutItem101,
            this.multiLayoutItem102,
            this.multiLayoutItem103,
            this.multiLayoutItem104,
            this.multiLayoutItem105,
            this.multiLayoutItem106,
            this.multiLayoutItem107,
            this.multiLayoutItem108,
            this.multiLayoutItem109,
            this.multiLayoutItem110,
            this.multiLayoutItem111,
            this.multiLayoutItem112,
            this.multiLayoutItem113,
            this.multiLayoutItem114,
            this.multiLayoutItem115});
            this.layBarcodeTemp2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarcodeTemp2.ParamList")));
            this.layBarcodeTemp2.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBarcodeTemp2_QueryStarting);
            this.layBarcodeTemp2.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layBarcodeTemp2_QueryEnd);
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "jundal_gubun";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "specimen_code";
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "specimen_name";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "tube_code";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "tube_name";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "in_out_gubun";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "specimen_ser";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "bunho";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "suname";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "gwa_name";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "danger_yn";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "jangbi_code";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "jangbi_name";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "tube_count";
            this.multiLayoutItem113.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "tube_max_amt";
            this.multiLayoutItem114.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "tube_numbering";
            // 
            // singleLayoutItem35
            // 
            this.singleLayoutItem35.DataName = "print_name";
            // 
            // xPanel6
            // 
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Controls.Add(this.panMain);
            this.xPanel6.Controls.Add(this.pnlLeft);
            this.xPanel6.Controls.Add(this.xPanel8);
            this.xPanel6.Name = "xPanel6";
            // 
            // panMain
            // 
            resources.ApplyResources(this.panMain, "panMain");
            this.panMain.Controls.Add(this.xPanel3);
            this.panMain.Controls.Add(this.pnlPaInfo);
            this.panMain.Name = "panMain";
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.xPanel5);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Name = "xPanel3";
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.grdSpecimen);
            this.xPanel5.Controls.Add(this.xPanel7);
            this.xPanel5.Name = "xPanel5";
            // 
            // grdSpecimen
            // 
            resources.ApplyResources(this.grdSpecimen, "grdSpecimen");
            this.grdSpecimen.ApplyPaintEventToAllColumn = true;
            this.grdSpecimen.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell25,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell37,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell49,
            this.xEditGridCell62,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell40,
            this.xEditGridCell43,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell52,
            this.xEditGridCell51,
            this.xEditGridCell58,
            this.xEditGridCell64,
            this.xEditGridCell66,
            this.xEditGridCell47});
            this.grdSpecimen.ColPerLine = 12;
            this.grdSpecimen.ColResizable = true;
            this.grdSpecimen.Cols = 13;
            this.grdSpecimen.ControlBinding = true;
            this.grdSpecimen.ExecuteQuery = null;
            this.grdSpecimen.FixedCols = 1;
            this.grdSpecimen.FixedRows = 1;
            this.grdSpecimen.HeaderHeights.Add(39);
            this.grdSpecimen.Name = "grdSpecimen";
            this.grdSpecimen.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSpecimen.ParamList")));
            this.grdSpecimen.RowHeaderVisible = true;
            this.grdSpecimen.Rows = 2;
            this.grdSpecimen.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdSpecimen.ToolTipActive = true;
            this.grdSpecimen.UseDefaultTransaction = false;
            this.grdSpecimen.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdSpecimen_PreSaveLayout);
            this.grdSpecimen.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdSpecimen_GridColumnProtectModify);
            this.grdSpecimen.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdSpecimen_ItemValueChanging);
            this.grdSpecimen.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdSpecimen_RowFocusChanged);
            this.grdSpecimen.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSpecimen_GridCellPainting);
            this.grdSpecimen.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSpecimen_QueryStarting);
            this.grdSpecimen.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdSpecimen_QueryEnd);
            this.grdSpecimen.DoubleClick += new System.EventHandler(this.grdSpecimen_DoubleClick);
            this.grdSpecimen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdSpecimen_MouseDown);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.CellName = "pkcpl2010";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "sunab_yn";
            this.xEditGridCell7.CellWidth = 30;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "jubsu_flag";
            this.xEditGridCell8.CellWidth = 65;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.EnableSort = true;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "slip_name";
            this.xEditGridCell9.CellWidth = 153;
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.EnableSort = true;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellName = "hangmog_code";
            this.xEditGridCell10.CellWidth = 89;
            this.xEditGridCell10.Col = 4;
            this.xEditGridCell10.EnableSort = true;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "gumsa_name";
            this.xEditGridCell11.CellWidth = 177;
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.EnableSort = true;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "specimen_code";
            this.xEditGridCell12.CellWidth = 30;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.EnableSort = true;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "specimen_name";
            this.xEditGridCell13.CellWidth = 96;
            this.xEditGridCell13.Col = 6;
            this.xEditGridCell13.EnableSort = true;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellName = "emergency";
            this.xEditGridCell14.CellWidth = 22;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.EnableSort = true;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.CellName = "tube_code";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "tube_name";
            this.xEditGridCell15.CellWidth = 110;
            this.xEditGridCell15.Col = 8;
            this.xEditGridCell15.EnableSort = true;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "specimen_ser";
            this.xEditGridCell16.CellWidth = 116;
            this.xEditGridCell16.Col = 10;
            this.xEditGridCell16.EnableSort = true;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.BindControl = this.txtJu;
            this.xEditGridCell26.CellName = "comment_ju_code";
            this.xEditGridCell26.Col = 12;
            this.xEditGridCell26.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell26.EnableSort = true;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJu
            // 
            resources.ApplyResources(this.txtJu, "txtJu");
            this.txtJu.Name = "txtJu";
            this.txtJu.ReadOnly = true;
            this.txtJu.TabStop = false;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.CellName = "fkocs1003";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.CellName = "group_gubun";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.CellName = "part_jubsu_flag";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.CellName = "gum_jubsu_flag";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.CellName = "dummy";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.CellName = "modify_yn";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.CellName = "modify_yn_1";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell34.CellName = "jundal_gubun";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell49.CellName = "jundal_gubun_name";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            this.xEditGridCell49.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell62.CellName = "jubsuja";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            this.xEditGridCell62.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            this.xEditGridCell62.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.CellName = "order_date";
            this.xEditGridCell38.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.CellName = "bunho";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell41.CellName = "jubsu_date";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsUpdatable = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.CellName = "jubsu_time";
            this.xEditGridCell42.CellWidth = 40;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsUpdatable = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Mask = "##:##";
            this.xEditGridCell42.Row = -1;
            this.xEditGridCell42.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell40.CellName = "order_time";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsUpdCol = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell43.CellName = "group_hangmog";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsUpdCol = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            this.xEditGridCell43.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell45.CellName = "spcial_name";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsUpdCol = false;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            this.xEditGridCell45.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell46.CellName = "can_yn";
            this.xEditGridCell46.CellWidth = 92;
            this.xEditGridCell46.Col = 2;
            this.xEditGridCell46.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem7});
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell46.EnableSort = true;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.IsUpdCol = false;
            this.xEditGridCell46.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "Y";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "N";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "Z";
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "X";
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.CellName = "barcode";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            this.xEditGridCell52.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell51.CellName = "barcode_name";
            this.xEditGridCell51.CellWidth = 136;
            this.xEditGridCell51.Col = 7;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell58.BindControl = this.txtDoctor;
            this.xEditGridCell58.CellName = "comment";
            this.xEditGridCell58.CellWidth = 44;
            this.xEditGridCell58.Col = 11;
            this.xEditGridCell58.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsReadOnly = true;
            this.xEditGridCell58.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell58.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDoctor
            // 
            resources.ApplyResources(this.txtDoctor, "txtDoctor");
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.ReadOnly = true;
            this.txtDoctor.TabStop = false;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell64.CellName = "uitak_code";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            this.xEditGridCell64.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            this.xEditGridCell64.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell66.CellName = "middle_result";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            this.xEditGridCell66.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            this.xEditGridCell66.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.CellName = "print_yn";
            this.xEditGridCell47.CellWidth = 59;
            this.xEditGridCell47.Col = 9;
            this.xEditGridCell47.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdCol = false;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel7
            // 
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.Controls.Add(this.txtDoctor);
            this.xPanel7.Controls.Add(this.xLabel2);
            this.xPanel7.Controls.Add(this.txtJu);
            this.xPanel7.Controls.Add(this.xLabel1);
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Name = "xPanel7";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.splitContainer1);
            this.xPanel4.Name = "xPanel4";
            // 
            // pnlPaInfo
            // 
            resources.ApplyResources(this.pnlPaInfo, "pnlPaInfo");
            this.pnlPaInfo.Controls.Add(this.xLabel10);
            this.pnlPaInfo.Controls.Add(this.txtSpecimenNo);
            this.pnlPaInfo.Controls.Add(this.btnChange);
            this.pnlPaInfo.Controls.Add(this.dbxDocName);
            this.pnlPaInfo.Controls.Add(this.dbxDocCode);
            this.pnlPaInfo.Controls.Add(this.pbxJusa);
            this.pnlPaInfo.Controls.Add(this.dbxSuname);
            this.pnlPaInfo.Controls.Add(this.xLabel9);
            this.pnlPaInfo.Controls.Add(this.xLabel3);
            this.pnlPaInfo.Controls.Add(this.dbxSuname2);
            this.pnlPaInfo.Controls.Add(this.btnJusa);
            this.pnlPaInfo.Controls.Add(this.dbxPaNote);
            this.pnlPaInfo.Controls.Add(this.fbxBunho);
            this.pnlPaInfo.Controls.Add(this.dbxBirth);
            this.pnlPaInfo.Controls.Add(this.dbxSexAge);
            this.pnlPaInfo.Controls.Add(this.dbxTel);
            this.pnlPaInfo.Controls.Add(this.dbxAddress);
            this.pnlPaInfo.Controls.Add(this.xLabel7);
            this.pnlPaInfo.Controls.Add(this.xLabel6);
            this.pnlPaInfo.Controls.Add(this.xLabel4);
            this.pnlPaInfo.Controls.Add(this.paInfoBox);
            this.pnlPaInfo.DrawBorder = true;
            this.pnlPaInfo.Name = "pnlPaInfo";
            // 
            // xLabel10
            // 
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.Name = "xLabel10";
            // 
            // txtSpecimenNo
            // 
            resources.ApplyResources(this.txtSpecimenNo, "txtSpecimenNo");
            this.txtSpecimenNo.Name = "txtSpecimenNo";
            // 
            // btnChange
            // 
            resources.ApplyResources(this.btnChange, "btnChange");
            this.btnChange.ImageList = this.ImageList;
            this.btnChange.Name = "btnChange";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // dbxDocName
            // 
            resources.ApplyResources(this.dbxDocName, "dbxDocName");
            this.dbxDocName.Name = "dbxDocName";
            // 
            // dbxDocCode
            // 
            resources.ApplyResources(this.dbxDocCode, "dbxDocCode");
            this.dbxDocCode.Name = "dbxDocCode";
            // 
            // pbxJusa
            // 
            resources.ApplyResources(this.pbxJusa, "pbxJusa");
            this.pbxJusa.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.pbxJusa.Name = "pbxJusa";
            this.pbxJusa.Protect = false;
            this.pbxJusa.TabStop = false;
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Name = "xLabel3";
            // 
            // dbxSuname2
            // 
            resources.ApplyResources(this.dbxSuname2, "dbxSuname2");
            this.dbxSuname2.Name = "dbxSuname2";
            // 
            // btnJusa
            // 
            resources.ApplyResources(this.btnJusa, "btnJusa");
            this.btnJusa.Name = "btnJusa";
            this.btnJusa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJusa.TextPadding = new System.Drawing.Point(2, 0);
            this.btnJusa.Click += new System.EventHandler(this.btnJusa_Click);
            // 
            // dbxPaNote
            // 
            resources.ApplyResources(this.dbxPaNote, "dbxPaNote");
            this.dbxPaNote.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.dbxPaNote.Name = "dbxPaNote";
            // 
            // fbxBunho
            // 
            resources.ApplyResources(this.fbxBunho, "fbxBunho");
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.ReadOnly = true;
            this.fbxBunho.TabStop = false;
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunho_DataValidating);
            // 
            // dbxBirth
            // 
            resources.ApplyResources(this.dbxBirth, "dbxBirth");
            this.dbxBirth.Name = "dbxBirth";
            // 
            // dbxSexAge
            // 
            resources.ApplyResources(this.dbxSexAge, "dbxSexAge");
            this.dbxSexAge.Name = "dbxSexAge";
            // 
            // dbxTel
            // 
            resources.ApplyResources(this.dbxTel, "dbxTel");
            this.dbxTel.Name = "dbxTel";
            // 
            // dbxAddress
            // 
            resources.ApplyResources(this.dbxAddress, "dbxAddress");
            this.dbxAddress.Name = "dbxAddress";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Name = "xLabel4";
            // 
            // paInfoBox
            // 
            resources.ApplyResources(this.paInfoBox, "paInfoBox");
            this.paInfoBox.Name = "paInfoBox";
            // 
            // pnlLeft
            // 
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Controls.Add(this.grdPaList);
            this.pnlLeft.Controls.Add(this.xPanel1);
            this.pnlLeft.Name = "pnlLeft";
            // 
            // grdPaList
            // 
            resources.ApplyResources(this.grdPaList, "grdPaList");
            this.grdPaList.ApplyPaintEventToAllColumn = true;
            this.grdPaList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell68,
            this.xEditGridCell48,
            this.xEditGridCell53,
            this.xEditGridCell56,
            this.xEditGridCell54,
            this.xEditGridCell57,
            this.xEditGridCell65,
            this.xEditGridCell55,
            this.xEditGridCell60,
            this.xEditGridCell59});
            this.grdPaList.ColPerLine = 5;
            this.grdPaList.Cols = 6;
            this.grdPaList.ExecuteQuery = null;
            this.grdPaList.FixedCols = 1;
            this.grdPaList.FixedRows = 1;
            this.grdPaList.HeaderHeights.Add(34);
            this.grdPaList.Name = "grdPaList";
            this.grdPaList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaList.ParamList")));
            this.grdPaList.RowHeaderVisible = true;
            this.grdPaList.Rows = 2;
            this.grdPaList.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPaList.ToolTipActive = true;
            this.grdPaList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaList_RowFocusChanged);
            this.grdPaList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPaList_GridCellPainting);
            this.grdPaList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPaList_GridColumnChanged);
            this.grdPaList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaList_QueryStarting);
            this.grdPaList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPaList_QueryEnd);
            this.grdPaList.DoubleClick += new System.EventHandler(this.grdPaList_DoubleClick);
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell68.CellName = "trial";
            this.xEditGridCell68.CellWidth = 55;
            this.xEditGridCell68.Col = 1;
            this.xEditGridCell68.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell68.ExecuteQuery = null;
            this.xEditGridCell68.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell48.CellName = "bunho";
            this.xEditGridCell48.CellWidth = 102;
            this.xEditGridCell48.Col = 5;
            this.xEditGridCell48.EnableSort = true;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell48.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell53.CellName = "suname";
            this.xEditGridCell53.CellWidth = 99;
            this.xEditGridCell53.Col = 2;
            this.xEditGridCell53.EnableSort = true;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell56.CellName = "in_out_gubun";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell54.CellName = "gwa_name";
            this.xEditGridCell54.CellWidth = 143;
            this.xEditGridCell54.Col = 3;
            this.xEditGridCell54.EnableSort = true;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell57.CellName = "reser_yn";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            this.xEditGridCell57.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell65.CellName = "doctor";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            this.xEditGridCell65.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            this.xEditGridCell65.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell55.CellName = "doctor_name";
            this.xEditGridCell55.CellWidth = 99;
            this.xEditGridCell55.Col = 4;
            this.xEditGridCell55.EnableSort = true;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsReadOnly = true;
            this.xEditGridCell55.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell60.CellName = "reser_date";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsUpdatable = false;
            this.xEditGridCell60.IsUpdCol = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            this.xEditGridCell60.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell59.CellName = "emergency_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            this.xEditGridCell59.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dtpOrderDate);
            this.xPanel1.Controls.Add(this.dtpOrderToDate);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Controls.Add(this.lbSuname);
            this.xPanel1.Controls.Add(this.rbxJubsu);
            this.xPanel1.Controls.Add(this.txtTimeInterval);
            this.xPanel1.Controls.Add(this.tbxTimer);
            this.xPanel1.Controls.Add(this.cboTime);
            this.xPanel1.Controls.Add(this.xLabel8);
            this.xPanel1.Controls.Add(this.lbTime);
            this.xPanel1.Controls.Add(this.rbxMijubsu);
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // dtpOrderDate
            // 
            resources.ApplyResources(this.dtpOrderDate, "dtpOrderDate");
            this.dtpOrderDate.IsVietnameseYearType = false;
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpOrderDate_DataValidating);
            // 
            // dtpOrderToDate
            // 
            resources.ApplyResources(this.dtpOrderToDate, "dtpOrderToDate");
            this.dtpOrderToDate.IsVietnameseYearType = false;
            this.dtpOrderToDate.Name = "dtpOrderToDate";
            this.dtpOrderToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpOrderDate_DataValidating);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbSuname
            // 
            resources.ApplyResources(this.lbSuname, "lbSuname");
            this.lbSuname.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbSuname.Name = "lbSuname";
            // 
            // rbxJubsu
            // 
            resources.ApplyResources(this.rbxJubsu, "rbxJubsu");
            this.rbxJubsu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rbxJubsu.ImageList = this.ImageList;
            this.rbxJubsu.Name = "rbxJubsu";
            this.rbxJubsu.UseVisualStyleBackColor = false;
            // 
            // txtTimeInterval
            // 
            resources.ApplyResources(this.txtTimeInterval, "txtTimeInterval");
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.txtTimeInterval.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtTimeInterval_DataValidating);
            // 
            // tbxTimer
            // 
            resources.ApplyResources(this.tbxTimer, "tbxTimer");
            this.tbxTimer.Name = "tbxTimer";
            // 
            // cboTime
            // 
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.ExecuteQuery = null;
            this.cboTime.Name = "cboTime";
            this.cboTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTime.ParamList")));
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTime.SelectionChangeCommitted += new System.EventHandler(this.cboTime_SelectionChangeCommitted);
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel8.Name = "xLabel8";
            // 
            // lbTime
            // 
            resources.ApplyResources(this.lbTime, "lbTime");
            this.lbTime.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbTime.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lbTime.Name = "lbTime";
            // 
            // rbxMijubsu
            // 
            resources.ApplyResources(this.rbxMijubsu, "rbxMijubsu");
            this.rbxMijubsu.BackColor = System.Drawing.Color.Pink;
            this.rbxMijubsu.Checked = true;
            this.rbxMijubsu.ImageList = this.ImageList;
            this.rbxMijubsu.Name = "rbxMijubsu";
            this.rbxMijubsu.TabStop = true;
            this.rbxMijubsu.UseVisualStyleBackColor = false;
            this.rbxMijubsu.CheckedChanged += new System.EventHandler(this.rbxMijubsu_CheckedChanged);
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackColor = IHIS.Framework.XColor.XGroupBoxBackColor;
            this.paBox.Name = "paBox";
            this.paBox.Validated += new System.EventHandler(this.paBox_Validated);
            // 
            // xPanel8
            // 
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.Controls.Add(this.btnList);
            this.xPanel8.Controls.Add(this.xLabel5);
            this.xPanel8.Controls.Add(this.btnOrderPrint);
            this.xPanel8.Controls.Add(this.btnUseAlarmChk);
            this.xPanel8.Controls.Add(this.btnChkAllJubsu);
            this.xPanel8.Controls.Add(this.btnUseTimeChk);
            this.xPanel8.Controls.Add(this.btnOrderCancel);
            this.xPanel8.Controls.Add(this.btnPrintSetup);
            this.xPanel8.Controls.Add(this.btnBarcode);
            this.xPanel8.Controls.Add(this.btnChangeTime);
            this.xPanel8.Controls.Add(this.xButton5);
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Name = "xPanel8";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel5.Name = "xLabel5";
            // 
            // btnOrderPrint
            // 
            resources.ApplyResources(this.btnOrderPrint, "btnOrderPrint");
            this.btnOrderPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderPrint.Image")));
            this.btnOrderPrint.Name = "btnOrderPrint";
            this.btnOrderPrint.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnOrderPrint.Click += new System.EventHandler(this.btnOrderPrint_Click);
            // 
            // btnUseAlarmChk
            // 
            resources.ApplyResources(this.btnUseAlarmChk, "btnUseAlarmChk");
            this.btnUseAlarmChk.ImageIndex = 1;
            this.btnUseAlarmChk.ImageList = this.ImageList;
            this.btnUseAlarmChk.Name = "btnUseAlarmChk";
            this.btnUseAlarmChk.Click += new System.EventHandler(this.btnUseAlarmChk_Click);
            // 
            // btnChkAllJubsu
            // 
            resources.ApplyResources(this.btnChkAllJubsu, "btnChkAllJubsu");
            this.btnChkAllJubsu.ImageIndex = 0;
            this.btnChkAllJubsu.ImageList = this.ImageList;
            this.btnChkAllJubsu.Name = "btnChkAllJubsu";
            this.btnChkAllJubsu.Click += new System.EventHandler(this.btnChkAllJubsu_Click);
            // 
            // btnUseTimeChk
            // 
            resources.ApplyResources(this.btnUseTimeChk, "btnUseTimeChk");
            this.btnUseTimeChk.ImageIndex = 0;
            this.btnUseTimeChk.ImageList = this.ImageList;
            this.btnUseTimeChk.Name = "btnUseTimeChk";
            this.btnUseTimeChk.Click += new System.EventHandler(this.btnUseTimeChk_Click);
            // 
            // btnOrderCancel
            // 
            resources.ApplyResources(this.btnOrderCancel, "btnOrderCancel");
            this.btnOrderCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderCancel.Image")));
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // btnChangeTime
            // 
            resources.ApplyResources(this.btnChangeTime, "btnChangeTime");
            this.btnChangeTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnChangeTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChangeTime.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeTime.Image")));
            this.btnChangeTime.Name = "btnChangeTime";
            this.btnChangeTime.Click += new System.EventHandler(this.btnChangeTime_Click);
            // 
            // xButton5
            // 
            resources.ApplyResources(this.xButton5, "xButton5");
            this.xButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.xButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xButton5.Image = ((System.Drawing.Image)(resources.GetObject("xButton5.Image")));
            this.xButton5.Name = "xButton5";
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.CellName = "today_yn";
            this.xEditGridCell35.CellWidth = 25;
            this.xEditGridCell35.Col = 1;
            this.xEditGridCell35.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell35.EnableSort = true;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkActor
            // 
            this.fwkActor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo6,
            this.findColumnInfo7});
            this.fwkActor.ExecuteQuery = null;
            this.fwkActor.FormText = global::IHIS.CPLS.Properties.Resources.fwkActorText;
            this.fwkActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkActor.ParamList")));
            this.fwkActor.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkActor.ServerFilter = true;
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "user_id";
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            // 
            // findColumnInfo7
            // 
            this.findColumnInfo7.ColName = "user_name";
            this.findColumnInfo7.ColWidth = 140;
            this.findColumnInfo7.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo7, "findColumnInfo7");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // mlayConstantInfo
            // 
            this.mlayConstantInfo.ExecuteQuery = null;
            this.mlayConstantInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem23,
            this.multiLayoutItem42,
            this.multiLayoutItem43});
            this.mlayConstantInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayConstantInfo.ParamList")));
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "code";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "code_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "code_value";
            // 
            // layOrderPrint
            // 
            this.layOrderPrint.ExecuteQuery = null;
            this.layOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52});
            this.layOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderPrint.ParamList")));
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "cnt";
            this.multiLayoutItem44.IsUpdItem = true;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "order_date";
            this.multiLayoutItem45.IsUpdItem = true;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "order_time";
            this.multiLayoutItem46.IsUpdItem = true;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "bunho";
            this.multiLayoutItem47.IsUpdItem = true;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "suname";
            this.multiLayoutItem48.IsUpdItem = true;
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "suname2";
            this.multiLayoutItem49.IsUpdItem = true;
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "hangmog_code";
            this.multiLayoutItem50.IsUpdItem = true;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "hangmog_name";
            this.multiLayoutItem51.IsUpdItem = true;
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "tube_name";
            this.multiLayoutItem52.IsUpdItem = true;
            // 
            // CPL2010U00
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel6);
            this.Name = "CPL2010U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CPL2010U00_Closing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layChkNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeTemp2)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.panMain.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecimen)).EndInit();
            this.xPanel7.ResumeLayout(false);
            this.xPanel7.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            this.pnlPaInfo.ResumeLayout(false);
            this.pnlPaInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxJusa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paInfoBox)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        //private int mHeight = 110;

        #region vsvJubsuja_PreServiceCall
        private void vsvJubsuja_QueryStarting(object sender, CancelEventArgs e)
        {
            this.vsvJubsuja.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        #region Screen 변수

        private int QueryTime;
        private int TimeVal;

        // 自動照会使用可否フラグ
        private string useTimeChkYN = "Y";

        // 受付チェックボックス一括適用フラグ
        private string chkAllJubsuYN = "Y";


        // 患者有AlarmファイルPATH
        private string alarmFilePath_CPL = "";
        private string alarmFilePath_CPL_EM = "";
        private string useAlarmChkYN = "";

        #endregion

        #region OnLoad
        string mJubsu_yn = "";
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

            this.ParentForm.Size = new System.Drawing.Size(this.Width, rc.Height - 105);

            //this.grdSpecimen.SavePerformer = new XSavePerformer(this);
            //this.SaveLayoutList.Add(grdSpecimen);

            //this.dtpOrderDate.SetDataValue((EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")));
            //this.dtpOrderToDate.SetDataValue((EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")));

            mJubsu_yn = "2";  // 미채혈 query

            //dlg = new PAQRY(dtpOrderDate.GetDataValue(), rbxMijubsu.Checked ? "N" : "Y" );

            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("order_date"))
                {
                    this.dtpOrderDate.SetEditValue(this.OpenParam["order_date"].ToString());
                    this.dtpOrderDate.AcceptData();
                }
                if (this.OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }
            }
            this.grdPaList.QueryLayout(true);
            // タイマー設定
            this.setTimer();

            PostCallHelper.PostCall(new PostMethod(PostLoad));

            Form form = Parent.Parent as Form;
            if (form != null)
            {
                int width = form.Parent.Size.Width - 10;
                if (width > 1300) width = width - 20;
                Size formSize = new Size(width - 10, form.Parent.Size.Height - 5);
                form.MinimumSize = formSize;
                form.Size = formSize;

                grdOrder.Dock = DockStyle.Fill;
                grdTube.Dock = DockStyle.Fill;
            }

            // https://sofiamedix.atlassian.net/browse/MED-15740
            this.SpecimenVisibleControl();
        }

        private void PostLoad()
        {
            string btn_autoQuery_yn = null;
            string btn_autoAlarm_yn = null;

            // 注射画面コントロールデータ照会
            //            this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
            //                                                 FROM CPL0109
            //                                                WHERE HOSP_CODE = :f_hosp_code
            //                                                  AND CODE_TYPE = 'CPL_CONSTANT'
            //                                                ORDER BY CODE";

            this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            //tungtx
            this.mlayConstantInfo.SetBindVarValue("f_code_type", "CPL_CONSTANT");

            if (this.mlayConstantInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoQuery_yn")) btn_autoQuery_yn = this.mlayConstantInfo.GetItemString(i, "code_value");
                }

                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoAlarm_yn"))
                    {
                        btn_autoAlarm_yn = mlayConstantInfo.GetItemString(i, "code_value");

                        // AlarmファイルPATH取得
                        //                        this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                        //                                                 FROM CPL0109
                        //                                                WHERE HOSP_CODE = 'K01'
                        //                                                  AND CODE_TYPE = 'CPL_ALARM'
                        //                                                ORDER BY CODE";

                        this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        this.mlayConstantInfo.SetBindVarValue("f_code_type", "CPL_ALARM");

                        //query one more time
                        if (this.mlayConstantInfo.QueryLayout(true))
                        {
                            for (int k = 0; k < this.mlayConstantInfo.RowCount; k++)
                            {
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("CPL")) this.alarmFilePath_CPL = this.mlayConstantInfo.GetItemString(k, "code_value");
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("CPL_EM")) this.alarmFilePath_CPL_EM = this.mlayConstantInfo.GetItemString(k, "code_value");
                            }
                        }
                    }
                }
            }
            // Fix bug MED-13246
            if (btn_autoQuery_yn != null)
            {
                // 自動照会
                if (btn_autoQuery_yn.Equals("Y"))
                {
                    this.useTimeChkYN = "Y";
                    this.btnUseTimeChk.ImageIndex = 1;

                    this.timer1.Start();
                    this.cboTime.Enabled = true;
                }
                else
                {
                    this.useTimeChkYN = "N";
                    this.btnUseTimeChk.ImageIndex = 0;

                    this.cboTime.Enabled = false;
                    this.timer1.Stop();
                }
            }

            if (btn_autoAlarm_yn != null)
            {
                // 患者有Alarm
                if (btn_autoAlarm_yn.Equals("Y"))
                {
                    this.useAlarmChkYN = "Y";
                    this.btnUseAlarmChk.ImageIndex = 1;
                }
                else
                {
                    this.useAlarmChkYN = "N";
                    this.btnUseAlarmChk.ImageIndex = 0;
                }

            }

            // 実施者に 現在ログインしている IDを セットする｡
            this.dbxDocCode.SetDataValue(UserInfo.UserID);
            this.dbxDocName.SetDataValue(UserInfo.UserName);

        }
        #endregion

        //private void SetVisibleStatusBar(bool aIsVisible)
        //{
        //    this.pnlStatus.Visible = aIsVisible;
        //}
        //private void InitStatusBar(int aMaxValue)
        //{
        //    this.pgbProgress.Minimum = 0;
        //    this.pgbProgress.Maximum = aMaxValue;
        //    this.lbStatus.Text = "";
        //}
        //private void SetStatusBar(int aCurrentValue)
        //{
        //    this.pgbProgress.Value = aCurrentValue;
        //    this.pgbProgress.Refresh();
        //    this.lbStatus.Text = aCurrentValue.ToString() + "/" + this.pgbProgress.Maximum.ToString();
        //    this.lbStatus.Refresh();
        //}
        #region 환자선택/입력 후 벨리데이션 타기 전

        private void vsvPa_QueryStarting(object sender, CancelEventArgs e)
        {
            this.vsvPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.vsvPa.SetBindVarValue("f_date", this.dtpOrderDate.GetDataValue());
            this.vsvPa.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
        }
        #endregion


        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                if (this.rbxJubsu.Checked == true)
                {
                    this.dtpOrderDate.SetEditValue(info.SuName);
                    this.rbxMijubsu.Checked = true;
                }
                else
                {
                    this.dtpOrderDate.SetEditValue(info.SuName);
                    this.dtpOrderDate.AcceptData();
                }

                this.fbxBunho.ResetData();
                this.fbxBunho.SetEditValue(info.BunHo);
                this.fbxBunho.AcceptData();
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(paInfoBox.BunHo))
            {
                return new XPatientInfo(paInfoBox.BunHo, "", "", "", this.ScreenName);
            }
            return null;
        }
        #endregion


        #region 날짜 선택 벨리데이팅
        private void dtpOrderDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //this.grdOrder.Reset();
            //this.grdSpecimen.Reset();
            //this.grdTube.Reset();
            this.ClearInputControl();
            this.ClearXEditGrid();
            this.grdPaList.QueryLayout(true);
            //this.grdOrder.QueryLayout(false);

            //if ( dlg != null )
            //    dlg.SetBlood(this.dtpOrderDate.GetDataValue(),rbxMijubsu.Checked ? "N" : "Y");

            //// 20070312 Add Start
            //this.layChkNames.QueryLayout(true);
            //// 20070312 Add End

        }
        #endregion

        #region 검체그리드 저장 바로 전 일어나는 일

        private void grdSpecimen_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if (e.RowState == DataRowState.Modified)
                this.grdSpecimen.SetItemValue(e.RowNumber, "jubsuja", this.dbxDocCode.Text);
        }
        #endregion

        #region 처방그리드의 셀페인팅
        private void grdOrder_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (this.grdOrder.GetItemString(e.RowNumber, "jubsu_date").Length > 0)
                e.BackColor = Color.White;
            else
                e.BackColor = XColor.XLabelGradientEndColor.Color;

            if (e.ColName == "hope_date")
                if ((this.grdOrder.GetItemString(e.RowNumber, "hope_date").Trim().Length != 0)
                    && (this.grdOrder.GetItemString(e.RowNumber, "order_date").Trim() != this.grdOrder.GetItemString(e.RowNumber, "hope_date").Trim()))
                    e.ForeColor = XColor.XCalendarFullHolidayTextColor.Color;

        }
        #endregion

        #region 검체그리드의 셀페인팅
        private void grdSpecimen_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            //// 至急オーダは「Color.MistyRose」セット
            //if (this.grdSpecimen.GetItemString(e.RowNumber, "can_yn") == "X")
            //{
            //    e.BackColor = Color.MistyRose;
            //}

            //// 緊急オーダは「Color.Pink」セット
            //if (this.grdSpecimen.GetItemString(e.RowNumber, "can_yn") == "Z")
            //{
            //    e.BackColor = Color.Pink;
            //}

            // 院内検査は「Color.LightSkyBlue」セット
            if (this.grdSpecimen.GetItemString(e.RowNumber, "uitak_code") == "00" && (e.ColName == "hangmog_code"))
            {
                e.BackColor = Color.LightSkyBlue;
            }
        }
        #endregion

        #region 바코드출력 클릭
        private void btnBarcode_Click(object sender, System.EventArgs e)
        {
            Cursor preCursor = Cursor.Current;

            try
            {
                // Change cursor to waiting status to avoid double click
                // https://sofiamedix.atlassian.net/browse/MED-9443
                Cursor.Current = Cursors.WaitCursor;

                if (rbxJubsu.Checked)
                {
                    DataRow[] dtRowData = this.grdSpecimen.LayoutTable.Select("print_yn =" + "'Y'");

                    if (dtRowData.Length <= 0)
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox1_Ko
                                                            : Resources.XMessageBox1_JP);
                        string mcap = (NetInfo.Language == LangMode.Ko ? Resources.Caption1_Ko : Resources.Caption2_JP);
                        XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                        return;
                    }
                    SetPrintBacode();
                }
                else
                {
                    if (this.fbxBunho.GetDataValue() != "")
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox2_Ko
                                         : Resources.XMessageBox2_Jp);
                        string mcap = (NetInfo.Language == LangMode.Ko ? Resources.Caption1_Ko : Resources.Caption2_JP);
                        XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
            finally
            {
                Cursor.Current = preCursor;
            }
        }
        #endregion

        private void OrderQueryLayout()
        {
            if (this.fbxBunho.GetDataValue() != "")
            {
                this.grdOrder.QueryLayout(true);
                this.check_inj_cpl_order();
            }
            else
            {
                this.grdPaList.QueryLayout(true);
            }
        }

        #region 버튼리스트 작업 수행 전
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    //this.grdOrder.QueryLayout(true);
                    this.OrderQueryLayout();

                    if (grdOrder.RowCount == 0)
                    {
                        this.grdPaList.QueryLayout(true);
                    }

                    this.QueryTime = this.TimeVal;

                    break;

                case FunctionType.Update:
                    //if (dlg != null)
                    //{
                    //    dlg.TimerControl(false);
                    //}
                    this.btnList.Enabled = false;
                    if (this.grdSpecimen.RowCount == 0)
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox3_Ko
                                     : Resources.XMessageBox3_Jp);
                        string mcap = (NetInfo.Language == LangMode.Ko ? Resources.Caption1_Ko : Resources.Caption2_JP);
                        XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }
                    else
                    {
                        if (this.rbxMijubsu.Checked && this.dbxDocCode.Text.Length == 0)
                        {
                            string mMsg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox4_Ko
                                : Resources.XMessageBox4_Jp);
                            string mCap = NetInfo.Language == LangMode.Ko ? Resources.Caption1_Ko : Resources.Caption2_JP;
                            XMessageBox.Show(mMsg, mCap, MessageBoxIcon.Information);
                            //this.cbxActor.Focus();
                            e.IsBaseCall = false;
                            e.IsSuccess = false;
                            this.btnList.Enabled = true;
                            return;
                        }

                        string order_date = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date").Replace("/", "").Replace("-", "");
                        string reser_date = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "reser_date").Replace("/", "").Replace("-", "");
                        string today = DateTime.Today.ToString("yyyyMMdd");
                        reser_date = TypeCheck.NVL(reser_date, today).ToString();

                        if (this.rbxMijubsu.Checked && reser_date != today)
                        {
                            string msg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox5_ko + grdOrder.GetItemString(grdOrder.CurrentRowNumber, "reser_date").Replace("-", "/") + Resources.XMessageBox6_Ko + DateTime.Today.ToString("yyyy/MM/dd").Replace("-", "/") + Resources.XMessageBox7_Ko
                                : Resources.XMessageBox8_Jp + grdOrder.GetItemString(grdOrder.CurrentRowNumber, "reser_date").Replace("-", "/") + Resources.XMessageBox9_Jp + DateTime.Today.ToString("yyyy/MM/dd").Replace("-", "/") + Resources.XMessageBox10_Jp);

                            //"該当オーダは当日オーダでも当日予約オーダでもありません。このまま保存しますか。");
                            string cap = (NetInfo.Language == LangMode.Ko ? Resources.Caption1_Ko
                                : Resources.Caption2_JP);
                            if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo) != DialogResult.Yes)
                            {
                                e.IsBaseCall = false;
                                e.IsSuccess = false;
                                this.btnList.Enabled = true;
                                return;
                            }
                        }
                        string flg = "";
                        if (this.rbxMijubsu.Checked)
                        {
                            flg = "Y";
                        }
                        else
                        {
                            flg = "N";
                        }
                        DataRow[] dtRow = this.grdSpecimen.LayoutTable.Select("jubsu_flag =" + "'" + flg + "'");
                        if (dtRow.Length < 1)
                        {
                            string msg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox3_Ko
                                         : Resources.XMessageBox3_Jp);
                            string mcap = (NetInfo.Language == LangMode.Ko ? Resources.Caption1_Ko : Resources.Caption2_JP);
                            XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                            e.IsBaseCall = false;
                            e.IsSuccess = false;
                            this.btnList.Enabled = true;
                            return;
                        }
                    }
                    e.IsBaseCall = false;
                    jubsu_cnt = 0;
                    cancel_cnt = 0;
                    t_jubsu_gubun = "";

                    Hashtable inputList = new Hashtable();
                    Hashtable outputList = new Hashtable();

                    this.timer1.Stop();

                    //this.InitStatusBar(this.grdSpecimen.RowCount);
                    //this.SetVisibleStatusBar(true);
                    //this.SetStatusBar(0);

                    #region todo delete

                    //                    try
                    //                    {
                    //                        Service.BeginTransaction();

                    //                        if (this.grdSpecimen.SaveLayout())
                    //                        {
                    //                            e.IsSuccess = true;

                    //                            if (jubsu_cnt > 0)
                    //                            {
                    //                                inputList.Add("I_ORDER_DATE",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date"));
                    //                                inputList.Add("I_BUNHO", this.fbxBunho.GetDataValue());
                    //                                inputList.Add("I_JUBSUJA", this.cbxActor.GetDataValue());
                    //                                inputList.Add("I_JUBSU_FLAG", "Y");
                    //                                inputList.Add("I_JUBSU_GUBUN", t_jubsu_gubun); // null
                    //                                inputList.Add("I_JUBSU_DATE",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    //                                inputList.Add("I_JUBSU_TIME",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time"));

                    //                                //XMessageBox.Show("aaa");

                    //                                //채혈일은 dtpOrderDate이 아니라 sysdate가 들어감.
                    //                                if (Service.ExecuteProcedure("PR_CPL_MAKE_SPECIMEN_SER", inputList, outputList))
                    //                                {
                    //                                    if (outputList.Count > 0)
                    //                                    {
                    //                                        if (outputList["IO_FLAG"].ToString() == "N")
                    //                                        {
                    //                                            //mErrMsg = "患者情報がありません。オーダを確認してください。";
                    //                                            mErrMsg = Resources.XMessageBox11_Jp;
                    //                                            throw new Exception();
                    //                                        }
                    //                                    }
                    //                                }
                    //                                else
                    //                                {
                    //                                    throw new Exception();
                    //                                }
                    //                            }
                    //                            // 바코드 출력
                    //                            if (rbxMijubsu.Checked)
                    //                            {
                    //                                //바코드프린터명 가져오기
                    //                                this.layPrintName.QueryLayout();
                    //                                string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

                    //                                dwBarcode.Reset();
                    //                                layBarcode.Reset();
                    //                                this.layBarcodeTemp.SetBindVarValue("f_jubsu_date",
                    //                                    this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    //                                // jubsu_date 전역변수에 담아서 쿼리엔드에서도 사용해야함
                    //                                this.layBarcodeTemp.QueryLayout(true);

                    //                                if (layBarcode.RowCount > 0)
                    //                                {
                    //                                    #region

                    //                                    //채혈실의 뇨컵은 하나면된다
                    //                                    //										int nyo_cnt = 0;
                    //                                    //										string tube_code = "";
                    //                                    //										string jundal_gubun = "";
                    //                                    //										for (int i = this.layBarcode.RowCount-1; i >= 0 ; i-- )
                    //                                    //										{
                    //                                    //											jundal_gubun = this.layBarcode.GetItemString(i,"jundal_gubun");
                    //                                    //											tube_code = this.layBarcode.GetItemString(i,"tube_code");
                    //                                    //											if ( jundal_gubun != "14" ) //혈당부하 항목의 뇨는 그냥 바코드 뽑는다.
                    //                                    //											{
                    //                                    //												if ( tube_code == "18" )
                    //                                    //												{
                    //                                    //													nyo_cnt++;
                    //                                    //												}
                    //                                    //												if (nyo_cnt>1)
                    //                                    //												{
                    //                                    //													if ( tube_code == "18" )
                    //                                    //													{
                    //                                    //														this.layBarcode.DeleteRow(i);
                    //                                    //													}
                    //                                    //												}
                    //                                    //											}
                    //                                    //										}
                    //                                    //										this.layBarcode.AcceptData();
                    //                                    //
                    //                                    //										nyo_cnt = 0;
                    //                                    //										tube_code = "";
                    //                                    //										jundal_gubun = "";
                    //                                    //										for (int i = this.layBarcode.RowCount-1; i >= 0 ; i-- )
                    //                                    //										{
                    //                                    //											jundal_gubun = this.layBarcode.GetItemString(i,"jundal_gubun");
                    //                                    //											tube_code = this.layBarcode.GetItemString(i,"tube_code");
                    //                                    //											if ( jundal_gubun != "14" ) //혈당부하 항목의 뇨는 그냥 바코드 뽑는다.
                    //                                    //											{
                    //                                    //												if ( tube_code == "24" )
                    //                                    //												{
                    //                                    //													nyo_cnt++;
                    //                                    //												}
                    //                                    //												if (nyo_cnt>1)
                    //                                    //												{
                    //                                    //													if ( tube_code == "24" )
                    //                                    //													{
                    //                                    //														this.layBarcode.DeleteRow(i);
                    //                                    //													}
                    //                                    //												}
                    //                                    //											}
                    //                                    //										}
                    //                                    //this.layBarcode.AcceptData();

                    //                                    #endregion

                    //                                    //한껀씩 출력 보냄
                    //                                    //this.InitStatusBar(this.layBarcode.RowCount);
                    //                                    for (int j = 0; j < this.layBarcode.RowCount; j++)
                    //                                    {
                    //                                        //this.SetStatusBar(j);
                    //                                        dwBarcode.Reset();
                    //                                        layBarcodeOne.Reset();

                    //                                        int rowNum = layBarcodeOne.InsertRow(0);
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun",
                    //                                            this.layBarcode.GetItemString(j, "jundal_gubun"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name",
                    //                                            this.layBarcode.GetItemString(j, "jundal_gubun_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_code",
                    //                                            this.layBarcode.GetItemString(j, "specimen_code"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_name",
                    //                                            this.layBarcode.GetItemString(j, "specimen_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_code",
                    //                                            this.layBarcode.GetItemString(j, "tube_code"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_name",
                    //                                            this.layBarcode.GetItemString(j, "tube_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser",
                    //                                            this.layBarcode.GetItemString(j, "specimen_ser"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode.GetItemString(j, "bunho"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode.GetItemString(j, "suname"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "gwa_name",
                    //                                            this.layBarcode.GetItemString(j, "gwa_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "danger_yn",
                    //                                            this.layBarcode.GetItemString(j, "danger_yn"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba",
                    //                                            this.layBarcode.GetItemString(j, "specimen_ser_ba"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jangbi_code",
                    //                                            this.layBarcode.GetItemString(j, "jangbi_code"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "jangbi_name",
                    //                                            this.layBarcode.GetItemString(j, "jangbi_name"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "in_out_gubun",
                    //                                            this.layBarcode.GetItemString(j, "in_out_gubun"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re",
                    //                                            this.layBarcode.GetItemString(j, "gumsa_name_re"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_max_amt",
                    //                                            this.layBarcode.GetItemString(j, "tube_max_amt"));
                    //                                        layBarcodeOne.SetItemValue(rowNum, "tube_numbering",
                    //                                            this.layBarcode.GetItemString(j, "tube_numbering"));

                    //                                        dwBarcode.FillData(layBarcodeOne.LayoutTable);
                    //                                        dwBarcode.PrintProperties.PrinterName = printSetName;
                    //                                        dwBarcode.Print();

                    //                                        string strCMD = @"SELECT 'Y'
                    //                                                            FROM DUAL
                    //                                                           WHERE EXISTS (SELECT NULL
                    //                                                                           FROM CPL0109
                    //                                                                          WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                    //                                                                            AND CODE_TYPE = '20'
                    //                                                                            AND CODE ='" +
                    //                                                        this.layBarcodeOne.GetItemString(0, "specimen_code") + "')";

                    //                                        object retVal = Service.ExecuteScalar(strCMD);

                    //                                        if (TypeCheck.IsNull(retVal))
                    //                                        {

                    //                                            inputList.Clear();
                    //                                            outputList.Clear();

                    //                                            inputList.Add("I_SPECIMEN_SER", this.layBarcode.GetItemString(j, "specimen_ser"));
                    //                                            inputList.Add("I_JUNDAL_GUBUN", this.layBarcode.GetItemString(j, "jundal_gubun"));
                    //                                            inputList.Add("I_PART_JUBSU_DATE",
                    //                                                this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
                    //                                            inputList.Add("I_PART_JUBSU_TIME",
                    //                                                this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time"));
                    //                                            inputList.Add("I_PART_JUBSUJA", this.cbxActor.GetDataValue());
                    //                                            inputList.Add("I_USER_ID", this.cbxActor.GetDataValue());

                    //                                            if (!Service.ExecuteProcedure("PR_CPL_PART_JUBSU", inputList, outputList))
                    //                                            {
                    //                                                XMessageBox.Show(Resources.XMessageBox12 + Service.ErrFullMsg, Resources.caption4,
                    //                                                    MessageBoxIcon.Error);
                    //                                                throw new Exception();
                    //                                            }
                    //                                        }
                    //                                        //if (outputList.Count > 0)
                    //                                        //    flag = outputList[0].ToString();
                    //                                    }

                    //                                    //foreach (DataRow row in this.layBarcode.LayoutTable.Rows)
                    //                                    //{
                    //                                    //    dwBarcode.Reset();
                    //                                    //    layBarcodeOne.Reset();

                    //                                    //    layBarcodeOne.LayoutTable.ImportRow(row);

                    //                                    //    dwBarcode.FillData(layBarcodeOne.LayoutTable);
                    //                                    //    dwBarcode.PrintProperties.PrinterName = printSetName;
                    //                                    //    dwBarcode.Print();
                    //                                    //}
                    //                                }

                    //                            }

                    //                        }
                    //                        else
                    //                        {
                    //                            throw new Exception();
                    //                        }
                    //                        Service.CommitTransaction();
                    //                    }
                    //                    catch
                    //                    {
                    //                        Service.RollbackTransaction();
                    //                        e.IsSuccess = false;
                    //                        XMessageBox.Show(Resources.XMessageBox13 + mErrMsg, Resources.caption5, MessageBoxIcon.Error);
                    //                    }
                    //                    finally
                    //                    {
                    //                        if (this.useTimeChkYN.Equals("Y"))
                    //                        {
                    //                            this.timer1.Start();
                    //                        }
                    //                        //this.SetVisibleStatusBar(false);
                    //                        this.btnList.Enabled = true;

                    //                    }

                    #endregion


                    if (this.rbxJubsu.Checked == true)
                    {
                        foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                        {
                            // 会計未処理のみ
                            if (dtRow["if_data_send_yn"].ToString() == "Y")
                            {
                                XMessageBox.Show(Resources.XMessageBox2, "", MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    //save layout
                    try
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-15740
                        if (UserInfo.CplSpecimenAuto == "N" && !this.SpecimenChecks())
                        {
                            return;
                        }

                        e.IsSuccess = SaveGrdSpecimen();
                        if (e.IsSuccess == false)
                        {
                            // Save failed.
                            XMessageBox.Show(Resources.XMessageBox13 + mErrMsg, Resources.caption5, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Save succeeded.
                            // https://sofiamedix.atlassian.net/browse/MED-15204
                            this.SetDefaultSpecimenSer();
                            this.grdPaList.QueryLayout(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        //2015.10.07: modified due to MED-4594
                        if (ex.GetType().IsAssignableFrom(typeof(Sybase.DataWindow.MethodFailureException)))
                        {
                            // Print did not complete, but save successfully.
                            this.grdPaList.QueryLayout(true);
                        }
                        else
                        {
                            e.IsSuccess = false;
                            XMessageBox.Show(Resources.XMessageBox13 + mErrMsg, Resources.caption5, MessageBoxIcon.Error);
                        }
                    }
                    finally
                    {
                        if (this.useTimeChkYN.Equals("Y"))
                        {
                            this.timer1.Start();
                        }
                        //this.SetVisibleStatusBar(false);
                        this.btnList.Enabled = true;

                    }

                    //if (dlg != null)
                    //{
                    //    dlg.TimerControl(true);
                    //}
                    break;
                default:
                    break;
            }
        }



        #endregion

        #region Cloud-service SaveLayout implementation

        private bool SaveGrdSpecimen()
        {

            //String msg = Resources.TEXT88;
            //String cap = Resources.TEXT99;

            //if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            //{
            //    return false;
            //}

            List<CPL2010U00GrdSpecimenListItemInfo> inputList = GetListFromGrdSpecimen();
            if (inputList.Count == 0)
            {
                return false;
            }

            CPL2010U00SaveLayoutArgs args = new CPL2010U00SaveLayoutArgs();
            args.InputList = inputList;
            args.Bunho = this.fbxBunho.GetDataValue();
            args.BunhoPr1 = this.fbxBunho.GetDataValue();
            args.JubsuDate = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date");
            args.JubsuDatePr1 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date");
            args.JubsuFlagPr1 = "Y";
            //args.JubsuGubunPr1 = "";
            args.JubsuTimePr1 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time");
            args.JubsujaPr1 = this.dbxDocCode.GetDataValue();
            //args.JundalGubunPr2 = "";
            args.OrderDatePr1 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date");
            args.PartJubsuDatePr2 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date");
            args.PartJubsuTimePr2 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time");
            args.PartJubsujaPr2 = this.dbxDocCode.GetDataValue();
            args.RbxMijubsuChecked = rbxMijubsu.Checked;
            //args.SpecimenSerPr2 = "";
            args.UserId = UserInfo.UserID;
            args.UserIdPr2 = this.dbxDocCode.GetDataValue();
            args.IpAddr = Service.ClientIP.ToString();
            saveLayoutResult = CloudService.Instance.Submit<CPL2010U00SaveLayoutResult, CPL2010U00SaveLayoutArgs>(args);
            if (saveLayoutResult.ExecutionStatus == ExecutionStatus.Success)
            {
                if (saveLayoutResult.WholeResult)
                {
                    //after save
                    if (rbxMijubsu.Checked)
                    {
    //                    dwBarcode.Reset();
                        layBarcode.Reset();

                        layBarcodeTemp.QueryLayout(true);
                        if (layBarcode.RowCount > 0)
                        {
                            for (int j = 0; j < this.layBarcode.RowCount; j++)
                            {
                                //this.SetStatusBar(j);
      //                          dwBarcode.Reset();
                                layBarcodeOne.Reset();

                                int rowNum = layBarcodeOne.InsertRow(0);
                                layBarcodeOne.SetItemValue(rowNum, "jundal_gubun", this.layBarcode.GetItemString(j, "jundal_gubun"));
                                layBarcodeOne.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcode.GetItemString(j, "jundal_gubun_name"));
                                layBarcodeOne.SetItemValue(rowNum, "specimen_code", this.layBarcode.GetItemString(j, "specimen_code"));
                                layBarcodeOne.SetItemValue(rowNum, "specimen_name", this.layBarcode.GetItemString(j, "specimen_name"));
                                layBarcodeOne.SetItemValue(rowNum, "tube_code", this.layBarcode.GetItemString(j, "tube_code"));
                                layBarcodeOne.SetItemValue(rowNum, "tube_name", this.layBarcode.GetItemString(j, "tube_name"));
                                layBarcodeOne.SetItemValue(rowNum, "specimen_ser", this.layBarcode.GetItemString(j, "specimen_ser"));
                                layBarcodeOne.SetItemValue(rowNum, "bunho", this.layBarcode.GetItemString(j, "bunho"));
                                layBarcodeOne.SetItemValue(rowNum, "suname", this.layBarcode.GetItemString(j, "suname"));
                                layBarcodeOne.SetItemValue(rowNum, "gwa_name", this.layBarcode.GetItemString(j, "gwa_name"));
                                layBarcodeOne.SetItemValue(rowNum, "danger_yn", this.layBarcode.GetItemString(j, "danger_yn"));
                                layBarcodeOne.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcode.GetItemString(j, "specimen_ser_ba"));
                                layBarcodeOne.SetItemValue(rowNum, "jangbi_code", this.layBarcode.GetItemString(j, "jangbi_code"));
                                layBarcodeOne.SetItemValue(rowNum, "jangbi_name", this.layBarcode.GetItemString(j, "jangbi_name"));
                                layBarcodeOne.SetItemValue(rowNum, "in_out_gubun", this.layBarcode.GetItemString(j, "in_out_gubun"));
                                layBarcodeOne.SetItemValue(rowNum, "gumsa_name_re", this.layBarcode.GetItemString(j, "gumsa_name_re"));
                                layBarcodeOne.SetItemValue(rowNum, "tube_max_amt", this.layBarcode.GetItemString(j, "tube_max_amt"));
                                layBarcodeOne.SetItemValue(rowNum, "tube_numbering", this.layBarcode.GetItemString(j, "tube_numbering"));

   //                             dwBarcode.FillData(layBarcodeOne.LayoutTable);
   //                             dwBarcode.PrintProperties.PrinterName = saveLayoutResult.PrintName;
  //                              dwBarcode.Print();
                            }
                        }
                    }
                }

                return saveLayoutResult.WholeResult;
            }
            return false;
        }

        private List<CPL2010U00GrdSpecimenListItemInfo> GetListFromGrdSpecimen()
        {
            List<CPL2010U00GrdSpecimenListItemInfo> dataList = new List<CPL2010U00GrdSpecimenListItemInfo>();
            for (int i = 0; i < grdSpecimen.RowCount; i++)
            {
                if (grdSpecimen.GetRowState(i) == DataRowState.Modified)
                {
                    //pre-save
                    this.grdSpecimen.SetItemValue(i, "jubsuja", this.dbxDocCode.GetDataValue());

                    CPL2010U00GrdSpecimenListItemInfo info = new CPL2010U00GrdSpecimenListItemInfo();
                    info.Pkcpl2010 = grdSpecimen.GetItemString(i, "pkcpl2010");
                    info.SunabYn = grdSpecimen.GetItemString(i, "sunab_yn");
                    info.JubsuFlag = grdSpecimen.GetItemString(i, "jubsu_flag");
                    info.SlipName = grdSpecimen.GetItemString(i, "slip_name");
                    info.HangmogCode = grdSpecimen.GetItemString(i, "hangmog_code");
                    info.GumsaName = grdSpecimen.GetItemString(i, "gumsa_name");
                    info.SpecimenCode = grdSpecimen.GetItemString(i, "specimen_code");
                    info.SpecimenName = grdSpecimen.GetItemString(i, "specimen_name");
                    info.Emergency = grdSpecimen.GetItemString(i, "emergency");
                    info.TubeCode = grdSpecimen.GetItemString(i, "tube_code");
                    info.TubeName = grdSpecimen.GetItemString(i, "tube_name");

                    // https://sofiamedix.atlassian.net/browse/MED-15740
                    //info.SpecimenSer = grdSpecimen.GetItemString(i, "specimen_ser");
                    info.SpecimenSer = UserInfo.CplSpecimenAuto == "Y" ? grdSpecimen.GetItemString(i, "specimen_ser") : txtSpecimenNo.GetDataValue();

                    info.CommentJuCode = grdSpecimen.GetItemString(i, "comment_ju_code");
                    info.Fkocs1003 = grdSpecimen.GetItemString(i, "fkocs1003");
                    info.GroupGubun = grdSpecimen.GetItemString(i, "group_gubun");
                    info.PartJubsuFlag = grdSpecimen.GetItemString(i, "part_jubsu_flag");
                    info.GumJubsuFlag = grdSpecimen.GetItemString(i, "gum_jubsu_flag");
                    info.Dummy = grdSpecimen.GetItemString(i, "dummy");
                    info.ModifyYn = grdSpecimen.GetItemString(i, "modify_yn");
                    info.ModifyYn1 = grdSpecimen.GetItemString(i, "modify_yn_1");
                    info.JundalGubun = grdSpecimen.GetItemString(i, "jundal_gubun");
                    info.JundalGubunName = grdSpecimen.GetItemString(i, "jundal_gubun_name");
                    info.Jubsuja = grdSpecimen.GetItemString(i, "jubsuja");
                    info.OrderDate = grdSpecimen.GetItemString(i, "order_date");
                    info.Bunho = grdSpecimen.GetItemString(i, "bunho");
                    info.JubsuDate = grdSpecimen.GetItemString(i, "jubsu_date");
                    info.JubsuTime = grdSpecimen.GetItemString(i, "jubsu_time");
                    info.OrderTime = grdSpecimen.GetItemString(i, "order_time");
                    info.GroupHangmog = grdSpecimen.GetItemString(i, "group_hangmog");
                    info.SpcialName = grdSpecimen.GetItemString(i, "spcial_name");
                    info.CanYn = grdSpecimen.GetItemString(i, "can_yn");
                    info.Barcode = grdSpecimen.GetItemString(i, "barcode");
                    info.BarcodeName = grdSpecimen.GetItemString(i, "barcode_name");
                    info.DocComment = grdSpecimen.GetItemString(i, "comment");
                    info.UitakCode = grdSpecimen.GetItemString(i, "uitak_code");
                    info.MiddleResult = grdSpecimen.GetItemString(i, "middle_result");
                    info.RowState = DataRowState.Modified.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
        }

        #endregion


        #region Command

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "bunho":

                    if (commandParam.Contains("bunho"))
                    {
                        fbxBunho.SetEditValue(commandParam["bunho"].ToString());
                        fbxBunho.AcceptData();
                    }

                    break;
                case "ADM104Q":                    
                    if (commandParam.Contains("user_id") && !String.IsNullOrEmpty(commandParam["user_id"].ToString()))
                    {
                        dbxDocCode.SetDataValue(commandParam["user_id"]);
                    }
                    if (commandParam.Contains("user_name") && !String.IsNullOrEmpty(commandParam["user_name"].ToString()))
                    {
                        dbxDocName.SetDataValue(commandParam["user_name"]);
                    }                    
                    break;
            }

            return base.Command(command, commandParam);
        }


        #endregion

        #region 버튼리스트 작업 수행 후
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    if (e.IsSuccess == true)
                    {
                        //바코드 출력 후 오더 재조회(바코드 올 출력시 오더조회그리드의 current_row 를 참조하는 것이 이유)
                        //this.grdOrder.QueryLayout(false);
                        this.ClearInputControl();
                        this.ClearXEditGrid();
                        this.grdPaList.QueryLayout(true);
                    }


                    //if (dlg != null)
                    //{
                    //    string blood = "N";

                    //    if (rbxJubsu.Checked == true)
                    //    {
                    //        blood = "Y";
                    //    }
                    //    dlg.SetBlood(this.dtpOrderDate.GetDataValue(), blood);
                    //}

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 시간변경클릭
        private void btnChangeTime_Click(object sender, System.EventArgs e)
        {
            if (this.fbxBunho.GetDataValue() != "")
            {
                /*********************
			    /  폼으로 보여줄 때 
			    /********************/
                if (this.grdSpecimen.RowCount > 0)
                {
                    CHANGETIME dlg = new CHANGETIME(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gwa"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gubun"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "doctor"),
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun"));
                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        this.grdSpecimen.QueryLayout(true);
                    }
                }
                else
                {
                    string msg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox15_Ko
                        : Resources.XMessageBox15_Jp);
                    string mcap = (NetInfo.Language == LangMode.Ko ? Resources.Caption1_Ko : Resources.Caption2_JP);
                    XMessageBox.Show(msg, mcap, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region 미채혈 라디오 체크
        private void rbxMijubsu_CheckedChanged(object sender, System.EventArgs e)
        {

            if (this.rbxMijubsu.Checked == true)
            {
                this.rbxMijubsu.ImageIndex = 1;
                this.rbxJubsu.ImageIndex = 0;

                this.mJubsu_yn = "2";
                this.ClearInputControl();
                this.ClearXEditGrid();
                this.btnOrderCancel.Visible = false;
                this.btnBarcode.Visible = false;

                this.btnChange.Enabled = true;
                //this.dbxDocCode.SelectedIndex = 0;

                // 実施者に 現在ログインしている IDを セットする｡
                this.dbxDocCode.SetDataValue(UserInfo.UserID);
                this.dbxDocName.SetDataValue(UserInfo.UserName);
                this.xEditGridCell5.IsReadOnly = false;
                this.xEditGridCell61.IsReadOnly = false;

                this.rbxMijubsu.BackColor = Color.Pink;
                this.rbxJubsu.BackColor = Color.WhiteSmoke;

                // https://sofiamedix.atlassian.net/browse/MED-15948
                this.txtSpecimenNo.Enabled = true;
                this.SetDefaultSpecimenSer();
            }
            else
            {
                this.rbxMijubsu.ImageIndex = 0;
                this.rbxJubsu.ImageIndex = 1;

                this.mJubsu_yn = "3";
                this.ClearInputControl();
                this.ClearXEditGrid();
                //this.btnOrderCancel.Visible = true;
                this.btnBarcode.Visible = true;

                this.btnChange.Enabled = false;

                this.xEditGridCell5.IsReadOnly = true;
                this.xEditGridCell61.IsReadOnly = true;

                this.rbxMijubsu.BackColor = Color.WhiteSmoke;
                this.rbxJubsu.BackColor = Color.Pink;

                // https://sofiamedix.atlassian.net/browse/MED-15948
                this.txtSpecimenNo.Enabled = false;
            }

            // 一括受付ボタン初期化
            this.reset_BtnChkAllJubsu();

            this.grdPaList.QueryLayout(true);
        }
        #endregion

        #region 채혈 라디오 체크
        private void rbxJubsu_CheckedChanged(object sender, System.EventArgs e)
        {

            //if ( this.rbxJubsu.Checked == true )
            //{
            //    this.rbxMijubsu.ImageIndex = 1;
            //    this.rbxJubsu.ImageIndex = 0;

            //    this.mJubsu_yn = "3";
            //    this.ClearInputControl();
            //    this.ClearXEditGrid();
            //    this.grdOrder.QueryLayout(false);
            //    this.grdSpecimen.QueryLayout(false);
            //    this.lbTitle.Text = "採血患者照会";
            //    this.lbTitle.ForeColor = new XColor(Color.Crimson);
            //    this.grdPaList.QueryLayout(true);
            //    this.btnOrderCancel.Visible = true;
            //}
        }
        #endregion

        #region	grdSpecimen QueryStart/End
        private void grdSpecimen_QueryStarting(object sender, CancelEventArgs e)
        {
            grdSpecimen.Reset();

            //            if (this.mJubsu_yn == "1")// 채혈, 미채혈. 실제로 사용되지 않음... 왜있는거지....?
            //            {
            ////                this.grdSpecimen.QuerySQL = @"/* grd Specimen 1 */
            ////                                                SELECT A.PKCPL2010 
            ////                                                     , DECODE(A.SUNAB_DATE, NULL, 'N', 'Y')         SUNAB_YN
            ////                                                     , DECODE(A.JUBSU_DATE, NULL, 'N', 'Y')          JUBSU_FLAG
            ////                                                     , F.SLIP_NAME                                   
            ////                                                     , A.HANGMOG_CODE
            ////                                                     , C.GUMSA_NAME      
            ////                                                     , A.SPECIMEN_CODE   
            ////                                                     , B.CODE_NAME                       SPECIMEN_NAME
            ////                                                     , A.EMERGENCY
            ////                                                     , A.TUBE_CODE
            ////                                                     , NVL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME  
            ////                                                     , A.SPECIMEN_SER 
            ////                                                     , FN_CPL_SUB_COMMENT(A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)                 COMMENT_JU_CODE
            ////                                                     , A.FKOCS1003
            ////                                                     , NVL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN
            ////                                                     , DECODE(A.PART_JUBSU_DATE, NULL, 'N', 'Y')     PART_JUBSU_FLAG
            ////                                                     , DECODE(A.GUM_JUBSU_DATE, NULL, 'N', 'Y')      GUM_JUBSU_FLAG
            ////                                                     , A.DUMMY       
            ////                                                     , DECODE(C.GROUP_GUBUN,'03','Y','N')            MODIFY_YN
            ////                                                     , DECODE(A.HANGMOG_CODE,A.GROUP_HANGMOG,DECODE(C.GROUP_GUBUN,'02','N','Y'),'N')    MODIFY_YN_1
            ////                                                     , A.JUNDAL_GUBUN
            ////                                                     , A.JUBSUJA 
            ////                                                     , A.ORDER_DATE
            ////                                                     , A.BUNHO     
            ////                                                     , A.JUBSU_DATE
            ////                                                     , A.JUBSU_TIME
            ////                                                     , A.ORDER_TIME
            ////                                                     , A.GROUP_HANGMOG
            ////                                                     , C.SPCIAL_NAME
            ////                                                     --, DECODE(A.JUBSU_DATE, NULL, FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003), NULL) CAN_YN
            ////                                                     , FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) CAN_YN
            ////                                                     , C.BARCODE BARCODE
            ////                                                     , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE) BARCODE_NAME
            ////                                                     , FN_XRT_LOAD_COMMENT(A.FKOCS1003, A.FKOCS2003) DOC_COMMENT
            ////                                                     , C.UITAK_CODE
            ////                                                  FROM CPL0001 F, 
            ////                                                       CPL0109 D, 
            ////                                                       CPL0101 C, 
            ////                                                       CPL0109 B, 
            ////                                                       CPL2010 A
            ////                                                 WHERE A.HOSP_CODE                = :f_hosp_code
            ////                                                   AND B.HOSP_CODE(+)             = A.HOSP_CODE
            ////                                                   AND C.HOSP_CODE                = A.HOSP_CODE
            ////                                                   AND D.HOSP_CODE(+)             = A.HOSP_CODE
            ////                                                   AND F.HOSP_CODE(+)             = C.HOSP_CODE
            ////                                                   AND A.ORDER_DATE               = to_date(:f_order_date,'YYYY/MM/DD')
            ////                                                   AND A.BUNHO                    = :f_bunho
            ////                                                   AND A.GWA                      = :f_gwa
            ////                                                   AND NVL(A.ORDER_TIME,'0000')   = NVL(:f_order_time,'0000')
            ////                                                   AND NVL(A.GUBUN,'%')           LIKE :f_gubun||'%'
            ////                                                   AND A.DOCTOR                   = :f_doctor
            ////                                                   AND A.IN_OUT_GUBUN             = :f_in_out_gubun  
            ////                                                   AND (  ( :f_reser_date IS NOT NULL AND A.RESER_DATE = :f_reser_date )
            ////                                                       OR ( :f_reser_date IS NULL AND A.RESER_DATE IS NULL ) )         
            ////                                                   AND NVL(A.DC_YN,'N')           = 'N'
            ////                                                   --AND A.JUNDAL_GUBUN            <> '08' --BLOOD
            ////                                                   AND ( (A.AFTER_ACT_YN IS NULL) OR 
            ////                                                       (A.AFTER_ACT_YN =  'N' ) )
            ////                                                   AND B.CODE(+)                  = A.SPECIMEN_CODE
            ////                                                   AND B.CODE_TYPE(+)             = '04'
            ////                                                   AND C.HANGMOG_CODE             = A.HANGMOG_CODE
            ////                                                   AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE
            ////                                                   AND C.EMERGENCY                = A.EMERGENCY
            ////                                                   AND D.CODE(+)                  = A.TUBE_CODE
            ////                                                   AND D.CODE_TYPE(+)             = '02'
            ////                                                   AND F.SLIP_CODE(+)             = C.SLIP_CODE
            ////                                              ORDER BY C.UITAK_CODE,
            ////                                                       LPAD(A.GROUP_HANGMOG,10,'0'),
            ////                                                       DECODE(A.GROUP_HANGMOG, A.HANGMOG_CODE, 1, 2 ),
            ////                                                       LPAD(A.HANGMOG_CODE,10,'0'),
            ////                                                       A.TUBE_CODE,
            ////                                                       A.ORDER_TIME,
            ////                                                       A.JUNDAL_GUBUN,
            ////                                                       A.SPECIMEN_CODE,
            ////                                                       NVL(C.SERIAL,'9999999999')";
            //            }
            //            else if (this.mJubsu_yn == "2") //미채혈
            //            {
            //                this.grdSpecimen.QuerySQL = @"/* grd Specimen Before Jubsu */
            //                                                SELECT A.PKCPL2010 
            //                                                     , DECODE(A.SUNAB_DATE, NULL, 'N', 'Y')          SUNAB_YN
            //                                                     , DECODE(A.JUBSU_DATE, NULL, 'N', 'Y')        JUBSU_FLAG
            //                                                     --, 'Y'                                           JUBSU_FLAG
            //                                                     , F.SLIP_NAME                                   
            //                                                     , A.HANGMOG_CODE
            //                                                     , C.GUMSA_NAME      
            //                                                     , A.SPECIMEN_CODE   
            //                                                     , B.CODE_NAME                       SPECIMEN_NAME
            //                                                     , A.EMERGENCY
            //                                                     , A.TUBE_CODE
            //                                                     , NVL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME  
            //                                                     , A.SPECIMEN_SER 
            //                                                     , FN_CPL_SUB_COMMENT(A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)                 COMMENT_JU_CODE
            //                                                     , A.FKOCS1003
            //                                                     , NVL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN
            //                                                     , DECODE(A.PART_JUBSU_DATE, NULL, 'N', 'Y')     PART_JUBSU_FLAG
            //                                                     , DECODE(A.GUM_JUBSU_DATE, NULL, 'N', 'Y')      GUM_JUBSU_FLAG
            //                                                     , A.DUMMY       
            //                                                     , DECODE(C.GROUP_GUBUN,'03','Y','N')            MODIFY_YN
            //                                                     , DECODE(A.HANGMOG_CODE,A.GROUP_HANGMOG,DECODE(C.GROUP_GUBUN,'02','N','Y'),'N')    MODIFY_YN_1
            //                                                     , A.JUNDAL_GUBUN
            //                                                     , FN_CPL_LOAD_CODE_NAME('01',A.JUNDAL_GUBUN)    JUNDAL_GUBUN_NAME
            //                                                     , A.JUBSUJA
            //                                                     , A.ORDER_DATE
            //                                                     , A.BUNHO     
            //                                                     , A.JUBSU_DATE
            //                                                     , A.JUBSU_TIME
            //                                                     , A.ORDER_TIME
            //                                                     , A.GROUP_HANGMOG
            //                                                     , C.SPCIAL_NAME
            //                                                     --, DECODE(A.JUBSU_DATE, NULL, FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003), NULL) CAN_YN
            //                                                     , FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) CAN_YN
            //                                                     , C.BARCODE BARCODE
            //                                                     , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE) BARCODE_NAME
            //                                                     , FN_XRT_LOAD_COMMENT(A.FKOCS1003, A.FKOCS2003) DOC_COMMENT
            //                                                     , C.UITAK_CODE
            //                                                     , NVL(C.MIDDLE_RESULT, 'N')                              MIDDLE_RESULT
            //                                                  FROM CPL0001 F
            //                                                     , CPL0109 D
            //                                                     , CPL0101 C
            //                                                     , CPL0109 B
            //                                                     , OCS1003 O
            //                                                     , CPL2010 A
            //                                                 WHERE A.HOSP_CODE                = :f_hosp_code
            //                                                   AND B.HOSP_CODE(+)             = A.HOSP_CODE
            //                                                   AND C.HOSP_CODE                = A.HOSP_CODE
            //                                                   AND D.HOSP_CODE(+)             = A.HOSP_CODE
            //                                                   AND F.HOSP_CODE(+)             = C.HOSP_CODE
            //                                                   AND A.ORDER_DATE               = :f_order_date
            //                                                   --
            //                                                   AND A.GROUP_SER                = :f_group_ser
            //
            //                                                   AND A.BUNHO                    = :f_bunho
            //                                                   AND A.GWA                      = :f_gwa
            //                                                   AND NVL(A.ORDER_TIME,'0000')   = NVL(:f_order_time,'0000')
            //                                                   --AND NVL(A.GUBUN,'%')           LIKE :f_gubun||'%'
            //                                                   AND A.DOCTOR                   = :f_doctor
            //                                                   AND A.IN_OUT_GUBUN             = 'O'
            //                                                   AND A.JUBSU_DATE               IS NULL
            //                                                   AND (  ( :f_reser_yn = 'Y' AND A.RESER_DATE = :f_reser_date )
            //                                                       OR ( :f_reser_yn = 'N' AND A.RESER_DATE IS NULL ) )         
            //                                                   AND NVL(A.DC_YN,'N')           = 'N'
            //                                                   --AND A.JUNDAL_GUBUN            <> '08' --BLOOD
            //                                                   AND ( (A.AFTER_ACT_YN IS NULL) OR 
            //                                                       (A.AFTER_ACT_YN =  'N' ) )
            //                                                   AND B.CODE(+)                  = A.SPECIMEN_CODE
            //                                                   AND B.CODE_TYPE(+)             = '04'
            //                                                   AND C.HANGMOG_CODE             = A.HANGMOG_CODE
            //                                                   AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE
            //                                                   AND C.EMERGENCY                = A.EMERGENCY
            //                                                   AND D.CODE(+)                  = A.TUBE_CODE
            //                                                   AND D.CODE_TYPE(+)             = '02'
            //                                                   AND F.SLIP_CODE(+)             = C.SLIP_CODE
            //
            //                                                   AND O.HOSP_CODE                = A.HOSP_CODE
            //                                                   AND O.PKOCS1003                = A.FKOCS1003
            //                                                   AND (:f_emergency_yn = 'N' AND NVL(O.EMERGENCY, 'N') = 'N'
            //                                                     OR :f_emergency_yn = 'Y' AND NVL(O.EMERGENCY, 'N') = 'Y')
            //                                              ORDER BY C.UITAK_CODE,
            //                                                       LPAD(A.GROUP_HANGMOG,10,'0'),
            //                                                       DECODE(A.GROUP_HANGMOG, A.HANGMOG_CODE, 1, 2 ),
            //                                                       LPAD(A.HANGMOG_CODE,10,'0'),
            //                                                       A.TUBE_CODE,
            //                                                       A.ORDER_TIME,
            //                                                       A.JUNDAL_GUBUN,
            //                                                       A.SPECIMEN_CODE,
            //                                                       NVL(C.SERIAL,'9999999999')";
            //            }
            //            else //채혈
            //            {
            //                this.grdSpecimen.QuerySQL = @"/* grd Specimen After Jubsu */
            //                                                SELECT A.PKCPL2010 
            //                                                     , DECODE(A.SUNAB_DATE, NULL, 'N', 'Y')	         SUNAB_YN
            //                                                     , DECODE(A.JUBSU_DATE, NULL, 'N', 'Y')          JUBSU_FLAG
            //                                                     , F.SLIP_NAME                                   
            //                                                     , A.HANGMOG_CODE
            //                                                     , C.GUMSA_NAME	  
            //                                                     , A.SPECIMEN_CODE   
            //                                                     , B.CODE_NAME                       SPECIMEN_NAME
            //                                                     , A.EMERGENCY
            //                                                     , A.TUBE_CODE
            //                                                     , NVL(D.CODE_NAME, D.CODE_NAME_RE)  TUBE_NAME  
            //                                                     , A.SPECIMEN_SER 
            //                                                     , FN_CPL_SUB_COMMENT(A.HANGMOG_CODE, A.SPECIMEN_CODE, A.EMERGENCY)                 COMMENT_JU_CODE
            //                                                     , A.FKOCS1003
            //                                                     , NVL(C.GROUP_GUBUN, 'N')           GROUP_GUBUN
            //                                                     , DECODE(A.PART_JUBSU_DATE, NULL, 'N', 'Y')     PART_JUBSU_FLAG
            //                                                     , DECODE(A.GUM_JUBSU_DATE, NULL, 'N', 'Y')      GUM_JUBSU_FLAG
            //                                                     , A.DUMMY       
            //                                                     , DECODE(C.GROUP_GUBUN,'03','Y','N')            MODIFY_YN
            //                                                     , DECODE(A.HANGMOG_CODE,A.GROUP_HANGMOG,DECODE(C.GROUP_GUBUN,'02','N','Y'),'N')    MODIFY_YN_1
            //                                                     , A.JUNDAL_GUBUN
            //                                                     , FN_CPL_LOAD_CODE_NAME('01',A.JUNDAL_GUBUN)    JUNDAL_GUBUN_NAME
            //                                                     , A.JUBSUJA   
            //                                                     , A.ORDER_DATE
            //                                                     , A.BUNHO     
            //                                                     , A.JUBSU_DATE
            //                                                     , A.JUBSU_TIME
            //                                                     , A.ORDER_TIME
            //                                                     , A.GROUP_HANGMOG
            //                                                     , C.SPCIAL_NAME
            //                                                     --, DECODE(A.JUBSU_DATE, NULL, FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003), NULL) CAN_YN
            //                                                     , FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003) CAN_YN
            //                                                     , C.BARCODE BARCODE
            //                                                     , FN_CPL_LOAD_CODE_NAME('11', C.BARCODE) BARCODE_NAME
            //                                                     , FN_XRT_LOAD_COMMENT(A.FKOCS1003, A.FKOCS2003) DOC_COMMENT
            //                                                     , C.UITAK_CODE
            //                                                     , NVL(C.MIDDLE_RESULT, 'N')                              MIDDLE_RESULT
            //                                                  FROM CPL0001 F
            //                                                     , CPL0109 D
            //                                                     , CPL0101 C
            //                                                     , CPL0109 B
            //                                                     , OCS1003 O
            //                                                     , CPL2010 A
            //                                                 WHERE A.HOSP_CODE                = :f_hosp_code
            //                                                   AND B.HOSP_CODE(+)             = A.HOSP_CODE
            //                                                   AND C.HOSP_CODE                = A.HOSP_CODE
            //                                                   AND D.HOSP_CODE(+)             = A.HOSP_CODE
            //                                                   AND F.HOSP_CODE(+)             = C.HOSP_CODE
            //                                                   AND A.ORDER_DATE               = :f_order_date
            //                                                   --
            //                                                   AND A.GROUP_SER                = :f_group_ser
            //
            //                                                   AND A.BUNHO                    = :f_bunho
            //                                                   AND A.GWA                      = :f_gwa
            //                                                   AND NVL(A.ORDER_TIME,'0000')   = NVL(:f_order_time,'0000')
            //                                                   --AND NVL(A.GUBUN,'%')           LIKE :f_gubun||'%'
            //                                                   AND A.DOCTOR                   = :f_doctor
            //                                                   AND A.IN_OUT_GUBUN             = 'O'
            //                                                   AND A.JUBSU_DATE               = :f_jubsu_date
            //                                                   AND A.JUBSU_TIME               = :f_jubsu_time
            //                                                   AND A.JUBSUJA                  = :f_jubsuja
            //                                                   AND (  ( :f_reser_yn = 'Y' AND A.RESER_DATE = :f_reser_date )
            //                                                       OR ( :f_reser_yn = 'N' AND A.RESER_DATE IS NULL ) )   
            //                                                   AND NVL(A.DC_YN,'N')           = 'N'
            //                                                   AND ( (A.AFTER_ACT_YN IS NULL) OR 
            //                                                       (A.AFTER_ACT_YN =  'N' ) )
            //                                                   AND B.CODE(+)                  = A.SPECIMEN_CODE
            //                                                   AND B.CODE_TYPE(+)             = '04'
            //                                                   AND C.HANGMOG_CODE             = A.HANGMOG_CODE
            //                                                   AND C.SPECIMEN_CODE            = A.SPECIMEN_CODE
            //                                                   AND C.EMERGENCY                = A.EMERGENCY
            //                                                   AND D.CODE(+)                  = A.TUBE_CODE
            //                                                   AND D.CODE_TYPE(+)             = '02'
            //                                                   AND F.SLIP_CODE(+)             = C.SLIP_CODE
            //
            //                                                   AND O.HOSP_CODE                = A.HOSP_CODE
            //                                                   AND O.PKOCS1003                = A.FKOCS1003
            //                                                   AND (:f_emergency_yn = 'N' AND NVL(O.EMERGENCY, 'N') = 'N'
            //                                                     OR :f_emergency_yn = 'Y' AND NVL(O.EMERGENCY, 'N') = 'Y')
            //                                              ORDER BY C.UITAK_CODE,
            //                                                       LPAD(A.GROUP_HANGMOG,10,'0'),
            //                                                       DECODE(A.GROUP_HANGMOG, A.HANGMOG_CODE, 1, 2 ),
            //                                                       LPAD(A.HANGMOG_CODE,10,'0'),
            //                                                       A.TUBE_CODE,
            //                                                       A.ORDER_TIME,
            //                                                       A.JUNDAL_GUBUN,
            //                                                       A.SPECIMEN_CODE,
            //                                                       NVL(C.SERIAL,'9999999999')";
            //            }
            this.grdSpecimen.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSpecimen.SetBindVarValue("f_order_date", this.grdOrder.GetItemValue(this.grdOrder.CurrentRowNumber, "order_date").ToString());
            this.grdSpecimen.SetBindVarValue("f_bunho", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"));
            this.grdSpecimen.SetBindVarValue("f_gwa", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gwa"));
            this.grdSpecimen.SetBindVarValue("f_order_time", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_time"));
            //this.grdSpecimen.SetBindVarValue("f_gubun", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "gubun"));
            this.grdSpecimen.SetBindVarValue("f_doctor", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "doctor"));
            //this.grdSpecimen.SetBindVarValue("f_in_out_gubun", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun"));
            this.grdSpecimen.SetBindVarValue("f_reser_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "reser_date"));

            this.grdSpecimen.SetBindVarValue("f_jubsu_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));
            this.grdSpecimen.SetBindVarValue("f_jubsu_time", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_time"));
            this.grdSpecimen.SetBindVarValue("f_jubsuja", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsuja"));

            this.grdSpecimen.SetBindVarValue("f_group_ser", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "group_ser"));

            this.grdSpecimen.SetBindVarValue("f_reser_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "reser_yn"));
            this.grdSpecimen.SetBindVarValue("f_emergency_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "emergency_yn"));
        }

        private void grdSpecimen_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.rbxMijubsu.Checked == true) this.MakeJubsu();

            this.setGrdHeaderImage(this.grdSpecimen);
        }

        #region 접수체크 메소드
        private void MakeJubsu()
        {
            for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            {
                this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
            }
        }
        #endregion

        private void ShowNyo()
        {
            try
            {
                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                {
                    if (this.grdSpecimen.GetItemString(i, "spcial_name") == "01")
                    {
                        string bunho = this.grdSpecimen.GetItemString(i, "bunho");
                        string order_date = this.grdSpecimen.GetItemString(i, "order_date");
                        string pkocskey = this.grdSpecimen.GetItemString(i, "fkocs1003");
                        string in_out_gubun = this.grdOrder.GetItemString(i, "in_out_gubun"); ;
                        string hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");

                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", bunho);
                        openParams.Add("order_date", order_date);
                        openParams.Add("pkocskey", pkocskey);
                        openParams.Add("in_out_gubun", in_out_gubun);
                        openParams.Add("hangmog_code", hangmog_code);

                        if (pkocskey.Trim().Length > 0)
                        {
                            XScreen.OpenScreenWithParam(this, "CPLS", "CPL1000U03", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                    }
                    else if (this.grdSpecimen.GetItemString(i, "spcial_name") == "03")
                    {
                        string bunho = this.grdSpecimen.GetItemString(i, "bunho");
                        string order_date = this.grdSpecimen.GetItemString(i, "order_date");
                        string pkocskey = this.grdSpecimen.GetItemString(i, "fkocs1003");
                        string in_out_gubun = this.grdOrder.GetItemString(i, "in_out_gubun"); ;
                        string hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");

                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", bunho);
                        openParams.Add("order_date", order_date);
                        openParams.Add("pkocskey", pkocskey);
                        openParams.Add("in_out_gubun", in_out_gubun);
                        openParams.Add("hangmog_code", hangmog_code);

                        if (pkocskey.Trim().Length > 0)
                        {
                            XScreen.OpenScreenWithParam(this, "CPLS", "CPL1000U00", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                    }
                    else if (this.grdSpecimen.GetItemString(i, "spcial_name") == "04")
                    {
                        string bunho = this.grdSpecimen.GetItemString(i, "bunho");
                        string order_date = this.grdSpecimen.GetItemString(i, "order_date");
                        string pkocskey = this.grdSpecimen.GetItemString(i, "fkocs1003");
                        string in_out_gubun = this.grdOrder.GetItemString(i, "in_out_gubun"); ;
                        string hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");

                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", bunho);
                        openParams.Add("order_date", order_date);
                        openParams.Add("pkocskey", pkocskey);
                        openParams.Add("in_out_gubun", in_out_gubun);
                        openParams.Add("hangmog_code", hangmog_code);

                        if (pkocskey.Trim().Length > 0)
                        {
                            XScreen.OpenScreenWithParam(this, "CPLS", "CPL1000U01", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                    }
                    else if (this.grdSpecimen.GetItemString(i, "spcial_name") == "05")
                    {
                        string bunho = this.grdSpecimen.GetItemString(i, "bunho");
                        string order_date = this.grdSpecimen.GetItemString(i, "order_date");
                        string pkocskey = this.grdSpecimen.GetItemString(i, "fkocs1003");
                        string in_out_gubun = this.grdOrder.GetItemString(i, "in_out_gubun"); ;
                        string hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");

                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", bunho);
                        openParams.Add("order_date", order_date);
                        openParams.Add("pkocskey", pkocskey);
                        openParams.Add("in_out_gubun", in_out_gubun);
                        openParams.Add("hangmog_code", hangmog_code);

                        if (pkocskey.Trim().Length > 0)
                        {
                            XScreen.OpenScreenWithParam(this, "CPLS", "CPL1000U02", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("Message[" + ex.Message + "]");
                //XMessageBox.Show("Source[" + ex.Source + "]");
                //XMessageBox.Show("StackTrace[" + ex.StackTrace + "]");
            }
        }
        #endregion

        #region fwkPa_QueryStarting
        private void fwkPa_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            if (this.rbxJubsu.Checked == true)
                this.fwkPa.SetBindVarValue("jubsu_yn", "Y");
            else
                this.fwkPa.SetBindVarValue("jubsu_yn", "N");

        }
        #endregion

        #region grdSpecimen_GridColumnProtectModify
        private void grdSpecimen_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "jubsu_flag")
            {
                string hangmog_code = this.grdSpecimen.GetItemString(e.RowNumber, "hangmog_code");
                string group_hangmog = this.grdSpecimen.GetItemString(e.RowNumber, "group_hangmog");
                string part_yn = this.grdSpecimen.GetItemString(e.RowNumber, "part_jubsu_flag");
                if (hangmog_code == group_hangmog)
                {
                    e.Protect = false;
                }
                else
                {
                    e.Protect = true;
                }

                //if ( part_yn == "Y" )
                //e.Protect = true;
            }
            else if (e.ColName == "print_yn")
            {
                if (this.rbxJubsu.Checked)
                    e.Protect = false;
                else if (this.rbxMijubsu.Checked)
                    e.Protect = true;
            }
        }
        #endregion

        #region 검체그리드 아이템체인지
        private void grdSpecimen_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            string middle_result = this.grdSpecimen.GetItemString(e.RowNumber, "middle_result");

            if (this.rbxJubsu.Checked == true)
            {
                // 検査時間の間をおいて検査する項目なので一緒にチェックされない様に
                if (middle_result != "Y")
                {
                    if (e.ColName == "jubsu_flag")
                    {
                        //string hangmog_code = this.grdSpecimen.GetItemString(e.RowNumber, "hangmog_code");
                        //string group_hangmog = this.grdSpecimen.GetItemString(e.RowNumber,"group_hangmog");
                        string specimen_ser = this.grdSpecimen.GetItemString(e.RowNumber, "specimen_ser");

                        for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                        {
                            //if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "fkocs1003") == fkocs1003))
                            if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "specimen_ser") == specimen_ser))
                            {
                                if (e.ChangeValue.ToString() == "Y")
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
                                }
                                else
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
                                }
                            }
                        }
                    }
                }

                if (e.ColName == "print_yn")
                {

                    for (int i = 0; i < grdTube.RowCount; i++)
                    {
                        if (grdSpecimen.GetItemString(grdSpecimen.CurrentRowNumber, "tube_name") == grdTube.GetItemString(i, "tube_name"))
                        {
                            grdTube.SetItemValue(i, "print_yn", e.ChangeValue);
                        }
                    }

                    //string specimen_ser = this.grdSpecimen.GetItemString(e.RowNumber, "specimen_ser");
                    //string tube_name = this.grdSpecimen.GetItemString(e.RowNumber, "tube_name");

                    //if (tube_name != "")
                    //{
                    //    for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                    //    {
                    //        if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "specimen_ser") == specimen_ser))
                    //        {
                    //            this.grdSpecimen.SetItemValue(i, "print_yn", e.ChangeValue.ToString());
                    //        }
                    //    }

                    //    for (int i = 0; i < this.grdTube.RowCount; i++)
                    //    {
                    //        if (grdTube.GetItemString(i, "tube_name") == tube_name)
                    //            grdTube.SetItemValue(i, "print_yn", e.ChangeValue.ToString());
                    //    }
                    //}
                }
            }

            if (this.rbxMijubsu.Checked == true)
            {
                if (e.ColName == "jubsu_flag")
                {
                    //string hangmog_code = this.grdSpecimen.GetItemString(e.RowNumber, "hangmog_code");
                    //string group_hangmog = this.grdSpecimen.GetItemString(e.RowNumber,"group_hangmog");
                    string uitak_code = this.grdSpecimen.GetItemString(e.RowNumber, "uitak_code");
                    string tube_code = this.grdSpecimen.GetItemString(e.RowNumber, "tube_code");

                    // 検査時間の間をおいて検査する項目なので一緒にチェックされない様に
                    if (middle_result != "Y")
                    {
                        for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                        {
                            //if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "fkocs1003") == fkocs1003))
                            if ((i != e.RowNumber) && (this.grdSpecimen.GetItemString(i, "uitak_code") == uitak_code) && (this.grdSpecimen.GetItemString(i, "tube_code") == tube_code))
                            {
                                if (e.ChangeValue.ToString() == "Y")
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
                                }
                                else
                                {
                                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        private void fbxBunho_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ////환자번호 9자리로 변경
                //if (this.laySujinNo.QueryLayout())
                //{
                //    fbxBunho.SetDataValue(laySujinNo.GetItemValue("bunho"));
                //}
                if (fbxBunho.GetDataValue().ToString() != "")
                {
                    fbxBunho.SetEditValue(IHIS.Framework.BizCodeHelper.GetStandardBunHo(fbxBunho.GetDataValue().ToString()));
                    fbxBunho.AcceptData();
                }
            }
        }

        #region 바코드 프린터 설정
        private void SetPrint()
        {
            this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

            if (printSetName == "")
            {
                this.printDialog1.Document = this.printDocument1;
            }
            else
            {
                this.printDialog1.PrinterSettings.PrinterName = printSetName;
            }

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
                string PrinterName = this.printDialog1.PrinterSettings.PrinterName; //this.printDocument1.PrinterSettings.PrinterName;

                //                string cmdText1 = @" UPDATE ADM3300
                //                                       SET USER_ID         = :q_user_id
                //                                         , UP_TIME         = SYSDATE
                //                                         , B_PRINT_NAME    = :f_b_print_name
                //                                     WHERE HOSP_CODE       = :f_hosp_code 
                //                                       AND IP_ADDR         = :f_ip_addr";

                //                string cmdText2 = @"INSERT INTO ADM3300
                //                                          ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
                //                                            USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
                //                                        VALUES 
                //                                          ( :t_trm_id, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
                //                                            NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name)
                //                                        ";

                //                BindVarCollection bc = new BindVarCollection();
                //                bc.Add("q_user_id", UserInfo.UserID);
                //                bc.Add("f_b_print_name", PrinterName);
                //                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                //                bc.Add("f_ip_addr", Service.ClientIP.ToString());

                //                if (!Service.ExecuteNonQuery(cmdText1, bc))
                //                {
                //                    if (Service.ErrFullMsg == "Execute Error(Data does not changed)")
                //                    {
                //                        cmdText1 = @"SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
                //                                       FROM ADM3300
                //                                      WHERE HOSP_CODE = :f_hosp_code  ";

                //                        object t_trm_id = Service.ExecuteScalar(cmdText1, bc);

                //                        if (!TypeCheck.IsNull(t_trm_id))
                //                        {
                //                            bc.Add("t_trm_id", t_trm_id.ToString());
                //                        }

                //                        if (!Service.ExecuteNonQuery(cmdText2, bc))
                //                        {
                //                            XMessageBox.Show(Service.ErrFullMsg);
                //                        }
                //                    }
                //                    else
                //                    {
                //                        XMessageBox.Show(Service.ErrFullMsg);
                //                    }
                //                }

                //                string cmdText = @" DECLARE 
                //    
                //                                        T_TRM_ID VARCHAR2(8) := ''; 
                //
                //                                    BEGIN
                //                                        UPDATE ADM3300
                //                                           SET USER_ID         = :q_user_id
                //                                             , UP_TIME         = SYSDATE
                //                                             , B_PRINT_NAME    = :f_b_print_name
                //                                         WHERE HOSP_CODE       = :f_hosp_code 
                //                                           AND IP_ADDR         = :f_ip_addr;
                //                                           
                //                                              
                //                                           IF SQL%NOTFOUND THEN       
                //                                             
                //                                             SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
                //                                               INTO T_TRM_ID
                //                                               FROM ADM3300
                //                                              WHERE HOSP_CODE = :f_hosp_code;
                //                                              
                //                                             INSERT INTO ADM3300
                //                                                  ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
                //                                                    USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
                //                                                VALUES 
                //                                                  ( T_TRM_ID, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
                //                                                    NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name);       
                //                                                    
                //                                           END IF; 
                //
                //                                    END;";

                //                BindVarCollection bc = new BindVarCollection();
                //                bc.Add("q_user_id", UserInfo.UserID);
                //                bc.Add("f_b_print_name", PrinterName);
                //                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                //                bc.Add("f_ip_addr", Service.ClientIP.ToString());

                //tungtx
                CPL2010U00SetPrintArgs args = new CPL2010U00SetPrintArgs(UserInfo.UserID, PrinterName, Service.ClientIP.ToString());
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, CPL2010U00SetPrintArgs>(args);

                //if (!Service.ExecuteNonQuery(cmdText, bc))
                if (result.ExecutionStatus != ExecutionStatus.Success)
                {
                    XMessageBox.Show(Resources.XMessageBox16 + Service.ErrFullMsg, Resources.Caption6, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnPrintSetup_Click(object sender, System.EventArgs e)
        {
            SetPrint();
        }
        #endregion

        #region 프린터 설정 과 바코드 출력
        private void SetPrintBacode()
        {
            //바코드프린터명 가져오기
            this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

            if (this.grdSpecimen.RowCount < 1) return;

   //         dwBarcode.Reset();
            layBarcode.Reset();

            ArrayList SpecimenSerArr = new ArrayList();
            //string pre_specimen_ser = "";

            for (int i = 0; i < grdSpecimen.RowCount; i++)
            {
                if (grdSpecimen.GetItemString(i, "print_yn") == "Y")
                {
                    //if ( pre_specimen_ser != grdSpecimen.GetItemString(i,"specimen_ser") )
                    //{
                    //    SpecimenSerArr.Add(grdSpecimen.GetItemString(i,"specimen_ser"));
                    //}
                    //pre_specimen_ser = grdSpecimen.GetItemString(i,"specimen_ser");
                    if (!SpecimenSerArr.Contains(grdSpecimen.GetItemString(i, "specimen_ser")))
                    {
                        SpecimenSerArr.Add(grdSpecimen.GetItemString(i, "specimen_ser"));
                    }
                }
            }

            if (SpecimenSerArr.Count > 0)
            {
                SpecimenSerArr.Sort();

                for (int i = 0; i < SpecimenSerArr.Count; i++)
                {
                    string specimen_ser = SpecimenSerArr[i].ToString();
                    this.layBarcodeTemp2.SetBindVarValue("f_specimen_ser", specimen_ser);
                    this.layBarcodeTemp2.QueryLayout(true);

                    if (layBarcode2.RowCount > 0)
                    {
                        //한껀씩 출력 보냄
                        foreach (DataRow row in this.layBarcode2.LayoutTable.Rows)
                        {
   //                         dwBarcode.Reset();
                            layBarcodeOne.Reset();
                            this.layBarcodeOne.LayoutTable.ImportRow(row);

    //                        dwBarcode.FillData(layBarcodeOne.LayoutTable);
    //                        dwBarcode.PrintProperties.PrinterName = printSetName;
                            try
                            {
    //                            dwBarcode.Print();

                            }
                            catch { }

                        }
                    }
                }
            }
            else
            {
                string specimen_ser = grdSpecimen.GetItemString(grdSpecimen.CurrentRowNumber, "specimen_ser");
                this.layBarcodeTemp2.SetBindVarValue("f_specimen_ser", specimen_ser);
                this.layBarcodeTemp2.QueryLayout(true);

                if (layBarcode2.RowCount > 0)
                {
                    //한껀씩 출력 보냄
                    foreach (DataRow row in this.layBarcode2.LayoutTable.Rows)
                    {
   //                     dwBarcode.Reset();
                        layBarcodeOne.Reset();
                        this.layBarcodeOne.LayoutTable.ImportRow(row);

   //                     dwBarcode.FillData(layBarcodeOne.LayoutTable);
  //                      dwBarcode.PrintProperties.PrinterName = printSetName;
                        try
                        {
    //                        dwBarcode.Print();
                        }
                        catch { }
                    }
                }
            }
        }
        #endregion

        private void grdSpecimen_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (this.grdSpecimen.RowCount > 0)
            {
                this.grdTube.QueryLayout(true);

                for (int i = 0; i < grdTube.RowCount; i++)
                {
                    for (int j = 0; j < grdSpecimen.RowCount; j++)
                    {
                        if (grdSpecimen.GetItemString(j, "tube_name") == grdTube.GetItemString(i, "tube_name"))
                        {
                            grdTube.SetItemValue(i, "print_yn", grdSpecimen.GetItemString(j, "print_yn"));
                        }
                    }

                }
            }

            // https://sofiamedix.atlassian.net/browse/MED-15949
            if (rbxJubsu.Checked && !TypeCheck.IsNull(grdSpecimen.GetItemString(e.CurrentRow, "specimen_ser")))
            {
                txtSpecimenNo.Text = grdSpecimen.GetItemString(e.CurrentRow, "specimen_ser");
            }
        }

        private void grdOrder_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            string jubsuja = this.grdOrder.GetItemString(e.CurrentRow, "jubsuja_name");
            if (jubsuja.Equals(""))
            {  // 実施者に 現在ログインしている IDを セットする｡
                this.dbxDocCode.SetDataValue(UserInfo.UserID);
                this.dbxDocName.SetDataValue(UserInfo.UserName);
            }
            else
            {   // 採血者をセットする。
                this.dbxDocCode.Text = this.grdOrder.GetItemString(e.CurrentRow, "jubsuja");
                this.dbxDocName.Text = this.grdOrder.GetItemString(e.CurrentRow, "jubsuja_name");
            }
            this.grdSpecimen.QueryLayout(true);
            //this.ShowNyo(); 파트접수에서 함
            //this.grdChamgo.QueryLayout(false);
        }

        #region 환자 파인드 창
        private void fbxBunho_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if(dlg == null)
            //{
            //    dlg = new PAQRY(dtpOrderDate.GetDataValue(), rbxMijubsu.Checked ? "N" : "Y" );
            //    dlg.Owner = this.ParentForm;
            //    Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            //    int X = screen.Right - dlg.Size.Width;
            //    int Y = screen.Bottom - dlg.Size.Height - mHeight;
            //    dlg.Location = new Point(X, Y);
            //    dlg.Show();
            //}
            //else
            //{
            //    dlg.Dispose();
            //    dlg = new PAQRY(dtpOrderDate.GetDataValue(), rbxMijubsu.Checked ? "N" : "Y" );
            //    dlg.Owner = this.ParentForm;
            //    Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            //    int X = screen.Right - dlg.Size.Width;
            //    int Y = screen.Bottom - dlg.Size.Height - mHeight;
            //    dlg.Location = new Point(X, Y);
            //    dlg.Show();
            //}

        }
        #endregion

        #region 바코드 프린트 관련 셋팅

        private void layPrintName_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPrintName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layPrintName.SetBindVarValue("f_ip_addr", Service.ClientIP.ToString());
        }

        #endregion

        #region [一括受付ボタン関連]
        private void btnChkAllJubsu_Click(object sender, EventArgs e)
        {
            if (this.chkAllJubsuYN.Equals("Y"))
            {
                this.btnChkAllJubsu.ImageIndex = 1;
                this.chkAllJubsuYN = "N";

                string hangmog_code = string.Empty;
                string group_hangmog = string.Empty;
                string part_yn = string.Empty;

                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                {
                    hangmog_code = this.grdSpecimen.GetItemString(i, "hangmog_code");
                    group_hangmog = this.grdSpecimen.GetItemString(i, "group_hangmog");
                    part_yn = this.grdSpecimen.GetItemString(i, "part_jubsu_flag");

                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "N");
                }
                this.grdSpecimen.Refresh();
            }
            else
            {
                this.btnChkAllJubsu.ImageIndex = 0;
                this.chkAllJubsuYN = "Y";

                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                    this.grdSpecimen.SetItemValue(i, "jubsu_flag", "Y");
                this.grdSpecimen.Refresh();
            }
        }

        private void reset_BtnChkAllJubsu()
        {
            this.btnChkAllJubsu.ImageIndex = 3;
            this.chkAllJubsuYN = "Y";
        }
        #endregion

        private bool groupPartYn(string aGroup_hangmog)
        {
            string group_hangmog = string.Empty;
            string part_yn = string.Empty;

            for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            {
                group_hangmog = this.grdSpecimen.GetItemString(i, "group_hangmog");
                part_yn = this.grdSpecimen.GetItemString(i, "part_jubsu_flag");
                if (group_hangmog == aGroup_hangmog)
                {
                    //그룹 항목중 하나라도 파트접수가 되면 취소 안됨
                    if (part_yn == "Y") return false;
                }
            }

            return true;
        }

        private void fbxBunho_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {

            if (e.DataValue == "")
            {
                // https://sofiamedix.atlassian.net/browse/MED-12243
                //this.paInfoBox.SetPatientID("");
                this.paInfoBox.Reset();

                this.ClearInputControl();
                this.ClearXEditGrid();
                return;
            }

            string bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
            this.fbxBunho.SetDataValue(bunho);

            if (firstOpen)
            {
                CPL2010U00OpenScreenCompositeSecond();
                firstOpen = false;
            }
            this.vsvPa.QueryLayout();

            //if ((this.vsvPa.GetItemValue("suname").ToString() == "")&&(e.DataValue!=""))
            //{
            //    e.Cancel = true;
            //    return;
            //}



            //this.LoadPationtInfoByBunho();

            this.paInfoBox.SetPatientID(this.fbxBunho.GetDataValue());
            this.dbxAddress.SetDataValue(this.paInfoBox.Address2);
            this.dbxBirth.SetDataValue(this.paInfoBox.Birth);
            this.dbxSexAge.SetDataValue(this.paInfoBox.Sex + "/" + this.paInfoBox.YearAge);
            this.dbxSuname.SetDataValue(this.paInfoBox.SuName);
            this.dbxSuname2.SetDataValue(this.paInfoBox.SuName2);
            this.dbxTel.SetDataValue(this.paInfoBox.Tel);
            // 20070312 Add Start
            this.layChkNames.QueryLayout(true);
            // 20070312 Add End


            //#region 주사 유무 확인 2011.11.07 이흥도

            //BindVarCollection bindVar = new BindVarCollection();

            //string strCmd = @"SELECT FN_INJ_CPL_CHK_YN(:f_io_gubun, :f_bunho, :f_order_date, 'INJ') FROM DUAL";

            //bindVar.Add("f_io_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
            //bindVar.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
            ////bindVar.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
            //bindVar.Add("f_order_date", this.dtpOrderDate.GetDataValue());
            //object retVal = Service.ExecuteScalar(strCmd, bindVar);

            //if (retVal != null)
            //{
            //    if (retVal.ToString() == "Y")
            //    {
            //        this.btnJusa.Visible = true;
            //        this.pbxJusa.Visible = true;
            //        btnJusa.Text = "注射有り";
            //    }
            //    else
            //    {
            //        this.btnJusa.Visible = false;
            //        this.pbxJusa.Visible = false;
            //        btnJusa.Text = "注射無し";
            //    }
            //}
            //#endregion

            // 患者リストから選択されている　患者のオーダ情報取得
            this.grdOrder.QueryLayout(true);
            this.check_inj_cpl_order();
        }

        #region 환자선택/입력 후 벨리데이션이 성공이면,
        private void LoadPationtInfoByBunho()
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(this.fbxBunho.GetDataValue());

            if (Service.ExecuteProcedure("PR_CPL_BUNHO_LOAD_MIN", inputList, outputList))
            {
                if (outputList.Count > 0)
                {
                    this.layPa.SetItemValue("suname", outputList[0].ToString());
                    //this.layPa.SetItemValue("sujumin1", outputList[1].ToString());
                    //this.layPa.SetItemValue("sujumin2", outputList[2].ToString());
                    this.layPa.SetItemValue("sex", outputList[3].ToString());
                    this.layPa.SetItemValue("age", outputList[4].ToString());
                    this.layPa.SetItemValue("birth", outputList[5].ToString() == "" ? "" : DateTime.Parse(outputList[5].ToString()).ToShortDateString());
                    this.layPa.SetItemValue("address", outputList[6].ToString());
                    this.layPa.SetItemValue("ho_dong", outputList[7].ToString());
                    this.layPa.SetItemValue("ho_code", outputList[8].ToString());
                    this.layPa.SetItemValue("gwa", outputList[9].ToString());
                    this.layPa.SetItemValue("gwa_name", outputList[10].ToString());
                    this.layPa.SetItemValue("doctor", outputList[11].ToString());
                    this.layPa.SetItemValue("doctor_name", outputList[12].ToString());
                    this.layPa.SetItemValue("resident", outputList[13].ToString());
                    this.layPa.SetItemValue("resident_name", outputList[14].ToString());
                    this.layPa.SetItemValue("in_out_gubun", outputList[15].ToString());
                    this.layPa.SetItemValue("tel", outputList[16].ToString());
                    this.layPa.SetItemValue("jubsu_date", outputList[17].ToString() == "" ? "" : DateTime.Parse(outputList[17].ToString()).ToShortDateString());
                    this.layPa.SetItemValue("jubsu_time", outputList[18].ToString());
                    this.layPa.SetItemValue("jubsuja", outputList[19].ToString());
                    this.layPa.SetItemValue("part_jubsu_date", outputList[20].ToString() == "" ? "" : DateTime.Parse(outputList[20].ToString()).ToShortDateString());
                    this.layPa.SetItemValue("part_jubsu_time", outputList[21].ToString());
                    this.layPa.SetItemValue("part_jubsuja", outputList[22].ToString());
                    this.layPa.SetItemValue("tat1", outputList[23].ToString());
                    this.layPa.SetItemValue("tat2", outputList[24].ToString());
                    this.layPa.SetItemValue("pa_note", outputList[25].ToString());
                    this.layPa.SetItemValue("flag", outputList[26].ToString());
                    this.layPa.SetItemValue("sex_age", outputList[3].ToString() + " / " + outputList[4].ToString());
                }
            }
            /*
             *  PR_CPL_BUNHO_LOAD_MIN(:f_bunho          ,:o_suname         ,:o_sujumin1      , 
                                      :o_sujumin2       ,:o_sex            ,:o_age           ,
                                      :o_birth          ,:o_address        ,:o_ho_dong       ,
                                      :o_ho_code        ,:o_gwa            ,:o_gwa_name      ,
                                      :o_doctor         ,:o_doctor_name    ,:o_resident      ,
                                      :o_resident_name  ,:o_in_out_gubun   ,:o_tel           ,
                                      :o_jubsu_date     ,:o_jubsu_time     ,:o_jubsuja       ,
                                      :o_part_jubsu_date,:o_part_jubsu_time,:o_part_jubsuja  ,
                                      :o_tat1           ,:o_tat2           ,:o_pa_note       ,
                                      :o_flag           );
            */


        }
        #endregion


        private void check_inj_cpl_order()
        {
            #region 주사 유무 확인 2011.11.07 이흥도

            if (this.grdOrder.CurrentRowNumber < 0)
            {
                return;

            }
            //BindVarCollection bindVar = new BindVarCollection();
            //string strCmd = @"SELECT FN_INJ_CPL_CHK_YN(:f_io_gubun, :f_bunho, :f_order_date, 'INJ') FROM DUAL";

            //bindVar.Add("f_io_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
            //bindVar.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
            //bindVar.Add("f_order_date", this.dtpOrderDate.GetDataValue());
            //object retVal = Service.ExecuteScalar(strCmd, bindVar);

            CPL2010U00CheckInjCplOrderArgs args = new CPL2010U00CheckInjCplOrderArgs();
            args.Bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho");
            args.IoGubun = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun");
            args.OrderDate = this.dtpOrderDate.GetDataValue();
            CPL2010U00CheckInjCplOrderResult result =
                CloudService.Instance.Submit<CPL2010U00CheckInjCplOrderResult, CPL2010U00CheckInjCplOrderArgs>(args);

            //if (retVal != null)
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                //if (retVal.ToString() == "Y")
                if (result.FnInjCplChkYn == "Y")
                {
                    this.btnJusa.Visible = true;
                    this.pbxJusa.Visible = true;
                    btnJusa.Text = Resources.btnJusaText1;
                }
                else
                {
                    this.btnJusa.Visible = false;
                    this.pbxJusa.Visible = false;
                    btnJusa.Text = Resources.btnJusaText2;
                }
            }
            #endregion
        }

        #region 그리드 더블 클릭(인쇄 자동체크,언체크)
        private void grdSpecimen_DoubleClick(object sender, System.EventArgs e)
        {
            bool is_checked = false;

            if (this.grdSpecimen.CurrentColName != "print_yn")
                return;

            for (int i = 0; i < grdSpecimen.RowCount; i++)
            {
                if (grdSpecimen.GetItemString(i, "print_yn") == "Y")
                {
                    is_checked = true;
                    break;
                }
            }

            if (is_checked)
            {
                for (int i = 0; i < grdSpecimen.RowCount; i++)
                {
                    grdSpecimen.SetItemValue(i, "print_yn", "N");
                }
            }
            else
            {
                for (int i = 0; i < grdSpecimen.RowCount; i++)
                {
                    grdSpecimen.SetItemValue(i, "print_yn", "Y");
                }
            }
        }
        #endregion


        private void grdOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdChamgo.Reset();
            this.grdSpecimen.Reset();
            this.grdTube.Reset();
            this.grdOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOrder.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
            this.grdOrder.SetBindVarValue("f_mijubsu", this.mJubsu_yn);
            this.grdOrder.SetBindVarValue("f_from_date", this.dtpOrderDate.GetDataValue());
            this.grdOrder.SetBindVarValue("f_to_date", this.dtpOrderToDate.GetDataValue());
            this.grdOrder.SetBindVarValue("f_reser_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "reser_yn"));
            this.grdOrder.SetBindVarValue("f_emergency_yn", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "emergency_yn"));
            this.grdOrder.SetBindVarValue("f_doctor", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "doctor"));
        }

        private void grdOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.rbxMijubsu.Checked)
            {
                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    this.grdOrder.SetItemValue(i, "jubsu_date", EnvironInfo.GetSysDate());
                    this.grdOrder.SetItemValue(i, "jubsu_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                }
            }

            //this.grdOrder.ResetUpdate();
        }

        private void layChkNames_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layChkNames.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layChkNames.SetBindVarValue("f_bunho", this.paInfoBox.BunHo);
            this.layChkNames.SetBindVarValue("f_reser_date", this.dtpOrderDate.GetDataValue());
        }

        private void layChkNames_QueryEnd(object sender, QueryEndEventArgs e)
        {
            string chkNames = "";

            for (int i = 0; i < layChkNames.RowCount; i++)
            {
                chkNames += "," + layChkNames.GetItemString(i, "chkname");
            }

            if (chkNames != "")
                chkNames = chkNames.Substring(1, chkNames.Length - 1);

            if (layChkNames.RowCount > 0)
            {
                if (layChkNames.GetItemString(0, "suname").Length > 0)
                {
                    string msg = (
                        Resources.XMessageBox17 + layChkNames.GetItemString(0, "suname") + Resources.layChkNames1 +
                        layChkNames.GetItemString(0, "order_date1") + ", " +
                        layChkNames.GetItemString(0, "order_date2") + Resources.layChkNames2 +
                        layChkNames.GetItemString(0, "chknames") + ")");
                    XMessageBox.Show(msg);
                }
            }

        }

        private void layBarcodeTemp_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBarcodeTemp.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layBarcodeTemp.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
        }

        private void layBarcodeTemp_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //tungtx
            //if (e.IsSuccess)
            //{
            this.layBarcode.Reset();
            int t_tube_count = 0;
            int rowNum = 0;

            for (int i = 0; i < layBarcodeTemp.RowCount; i++)
            {
                t_tube_count = layBarcodeTemp.GetItemInt(i, "tube_count");

                for (int j = 0; j < t_tube_count; j++)
                {
                    rowNum = this.layBarcode.InsertRow(j - 1);
                    //rowNum = this.layBarcode.InsertRow(0);

                    this.layBarcode.SetItemValue(rowNum, "jundal_gubun", this.layBarcodeTemp.GetItemString(i, "jundal_gubun"));
                    this.layBarcode.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcodeTemp.GetItemString(i, "jundal_gubun_name"));
                    this.layBarcode.SetItemValue(rowNum, "specimen_code", this.layBarcodeTemp.GetItemString(i, "specimen_code"));
                    this.layBarcode.SetItemValue(rowNum, "specimen_name", this.layBarcodeTemp.GetItemString(i, "specimen_name"));
                    this.layBarcode.SetItemValue(rowNum, "tube_code", this.layBarcodeTemp.GetItemString(i, "tube_code"));
                    this.layBarcode.SetItemValue(rowNum, "tube_name", this.layBarcodeTemp.GetItemString(i, "tube_name"));
                    this.layBarcode.SetItemValue(rowNum, "in_out_gubun", this.layBarcodeTemp.GetItemString(i, "in_out_gubun"));
                    this.layBarcode.SetItemValue(rowNum, "specimen_ser", this.layBarcodeTemp.GetItemString(i, "specimen_ser"));
                    this.layBarcode.SetItemValue(rowNum, "bunho", this.layBarcodeTemp.GetItemString(i, "bunho"));
                    this.layBarcode.SetItemValue(rowNum, "suname", this.layBarcodeTemp.GetItemString(i, "suname"));
                    this.layBarcode.SetItemValue(rowNum, "gwa_name", this.layBarcodeTemp.GetItemString(i, "gwa_name"));
                    this.layBarcode.SetItemValue(rowNum, "danger_yn", this.layBarcodeTemp.GetItemString(i, "danger_yn"));
                    this.layBarcode.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcodeTemp.GetItemString(i, "specimen_ser_ba"));
                    this.layBarcode.SetItemValue(rowNum, "jangbi_code", this.layBarcodeTemp.GetItemString(i, "jangbi_code"));
                    this.layBarcode.SetItemValue(rowNum, "jangbi_name", this.layBarcodeTemp.GetItemString(i, "jangbi_name"));
                    this.layBarcode.SetItemValue(rowNum, "gumsa_name_re", this.layBarcodeTemp.GetItemString(i, "gumsa_name_re"));
                    this.layBarcode.SetItemValue(rowNum, "tube_max_amt", this.layBarcodeTemp.GetItemString(i, "tube_max_amt"));
                    this.layBarcode.SetItemValue(rowNum, "tube_numbering", this.layBarcodeTemp.GetItemString(i, "tube_numbering"));
                }

            }

            //                string cmdText = @" UPDATE CPL2010
            //                                   SET DUMMY = NULL
            //                                 WHERE HOSP_CODE     = :f_hosp_code 
            //                                   AND JUBSU_DATE    = to_date(:f_jubsu_date,'YYYY/MM/DD')
            //                                   AND BUNHO         = :f_bunho
            //                                   AND DUMMY         = 'Y'";

            //                BindVarCollection bc = new BindVarCollection();
            //                bc.Add("f_hosp_code", EnvironInfo.HospCode);
            //                bc.Add("f_bunho", this.fbxBunho.GetDataValue());
            //                bc.Add("f_jubsu_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date"));

            //                Service.ExecuteNonQuery(cmdText, bc);
            //}
        }

        private void layBarcodeTemp2_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                this.layBarcode2.Reset();
                int t_tube_count = 0;
                int rowNum = 0;


                for (int i = 0; i < layBarcodeTemp2.RowCount; i++)
                {
                    t_tube_count = layBarcodeTemp2.GetItemInt(i, "tube_count");

                    for (int j = 0; j < t_tube_count; j++)
                    {
                        rowNum = this.layBarcode2.InsertRow(j - 1);
                        //rowNum = this.layBarcode2.InsertRow(0);

                        this.layBarcode2.SetItemValue(rowNum, "jundal_gubun", this.layBarcodeTemp2.GetItemString(i, "jundal_gubun"));
                        this.layBarcode2.SetItemValue(rowNum, "jundal_gubun_name", this.layBarcodeTemp2.GetItemString(i, "jundal_gubun_name"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_code", this.layBarcodeTemp2.GetItemString(i, "specimen_code"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_name", this.layBarcodeTemp2.GetItemString(i, "specimen_name"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_code", this.layBarcodeTemp2.GetItemString(i, "tube_code"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_name", this.layBarcodeTemp2.GetItemString(i, "tube_name"));
                        this.layBarcode2.SetItemValue(rowNum, "in_out_gubun", this.layBarcodeTemp2.GetItemString(i, "in_out_gubun"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_ser", this.layBarcodeTemp2.GetItemString(i, "specimen_ser"));
                        this.layBarcode2.SetItemValue(rowNum, "bunho", this.layBarcodeTemp2.GetItemString(i, "bunho"));
                        this.layBarcode2.SetItemValue(rowNum, "suname", this.layBarcodeTemp2.GetItemString(i, "suname"));
                        this.layBarcode2.SetItemValue(rowNum, "gwa_name", this.layBarcodeTemp2.GetItemString(i, "gwa_name"));
                        this.layBarcode2.SetItemValue(rowNum, "danger_yn", this.layBarcodeTemp2.GetItemString(i, "danger_yn"));
                        this.layBarcode2.SetItemValue(rowNum, "specimen_ser_ba", this.layBarcodeTemp2.GetItemString(i, "specimen_ser_ba"));
                        this.layBarcode2.SetItemValue(rowNum, "jangbi_code", this.layBarcodeTemp2.GetItemString(i, "jangbi_code"));
                        this.layBarcode2.SetItemValue(rowNum, "jangbi_name", this.layBarcodeTemp2.GetItemString(i, "jangbi_name"));
                        this.layBarcode2.SetItemValue(rowNum, "gumsa_name_re", this.layBarcodeTemp2.GetItemString(i, "gumsa_name_re"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_max_amt", this.layBarcodeTemp2.GetItemString(i, "tube_max_amt"));
                        this.layBarcode2.SetItemValue(rowNum, "tube_numbering", this.layBarcodeTemp2.GetItemString(i, "tube_numbering"));
                    }
                }
            }
        }

        private void layBarcodeTemp2_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBarcodeTemp2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdTube_QueryStarting(object sender, CancelEventArgs e)
        {

            //            if (rbxJubsu.Checked == true)
            //            {
            //                grdTube.QuerySQL = @"SELECT X.TUBE_CODE,
            //                                           X.TUBE_NAME,
            //                                           SUM(X.TUBE_COUNT)   CNT
            //                                      FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,
            //                                                        MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE))            TUBE_NAME,
            //                                                        FN_CPL_TUBE_COUNT(A.SPECIMEN_SER)               TUBE_COUNT,
            //                                                        A.HOSP_CODE 
            //                                                   FROM CPL0101 B,
            //                                                        CPL2010 A
            //                                                  WHERE A.HOSP_CODE     = :f_hosp_code
            //                                                    AND B.HOSP_CODE     = A.HOSP_CODE 
            //                                                    --AND A.JUBSU_DATE    = to_date(:f_jubsu_date,'YYYY/MM/DD')
            //                                                    --AND A.JUBSU_TIME    = :f_jubsu_time
            //                                                    AND A.ORDER_DATE    = to_date(:f_order_date,'YYYY/MM/DD')
            //                                                    AND A.ORDER_TIME    = :f_order_time
            //                                                    AND A.BUNHO         = :f_bunho
            //                                                    AND A.JUBSU_DATE    IS NOT NULL
            //                                                    AND B.HANGMOG_CODE  = A.HANGMOG_CODE
            //                                                    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
            //                                                    AND B.EMERGENCY     = A.EMERGENCY
            //                                                  GROUP BY A.HOSP_CODE,
            //                                                        --A.JUNDAL_GUBUN,
            //                                                        --A.SPECIMEN_CODE,
            //                                                        A.TUBE_CODE,
            //                                                        A.IN_OUT_GUBUN,
            //                                                        A.SPECIMEN_SER,
            //                                                        A.GWA,
            //                                                        A.BUNHO      ) X
            //                                     WHERE X.HOSP_CODE = :f_hosp_code
            //                                     GROUP BY X.TUBE_CODE, X.TUBE_NAME
            //                                     ORDER BY 1";

            //                //this.grdTube.SetBindVarValue("f_jubsu_date", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "jubsu_date"));
            //                //this.grdTube.SetBindVarValue("f_jubsu_time", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "jubsu_time"));
            //            }
            //            else if (rbxMijubsu.Checked == true)
            //            {
            //                grdTube.QuerySQL = @"SELECT X.TUBE_CODE,
            //                                           X.TUBE_NAME,
            //                                           SUM(X.TUBE_COUNT)   CNT
            //                                      FROM (     SELECT MIN(A.TUBE_CODE)                TUBE_CODE,
            //                                                        MIN(FN_CPL_CODE_NAME('02',A.TUBE_CODE))            TUBE_NAME,
            //                                                        1                                                  TUBE_COUNT,
            //                                                        A.HOSP_CODE 
            //                                                   FROM CPL0101 B,
            //                                                        CPL2010 A
            //                                                  WHERE A.HOSP_CODE     = :f_hosp_code
            //                                                    AND B.HOSP_CODE     = A.HOSP_CODE 
            //                                                    AND A.ORDER_DATE    = to_date(:f_order_date,'YYYY/MM/DD')
            //                                                    AND A.ORDER_TIME    = :f_order_time
            //                                                    AND A.BUNHO         = :f_bunho
            //                                                    AND A.JUBSU_DATE    IS NULL
            //                                                    AND B.HANGMOG_CODE  = A.HANGMOG_CODE
            //                                                    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
            //                                                    AND B.EMERGENCY     = A.EMERGENCY
            //                                                  GROUP BY A.HOSP_CODE,
            //                                                        --A.JUNDAL_GUBUN,
            //                                                        --A.SPECIMEN_CODE,
            //                                                        A.TUBE_CODE,
            //                                                        A.IN_OUT_GUBUN,
            //                                                        --A.SPECIMEN_SER,
            //                                                        A.GWA,
            //                                                        A.BUNHO      ) X
            //                                     WHERE X.HOSP_CODE = :f_hosp_code
            //                                     GROUP BY X.TUBE_CODE, X.TUBE_NAME
            //                                     ORDER BY 1";
            //            }
            this.grdTube.SetBindVarValue("f_order_date", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "order_date"));
            this.grdTube.SetBindVarValue("f_order_time", this.grdSpecimen.GetItemString(this.grdSpecimen.CurrentRowNumber, "order_time"));
            this.grdTube.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdTube.SetBindVarValue("f_bunho", fbxBunho.GetDataValue());
        }

        //private void grdChamgo_QueryStarting(object sender, CancelEventArgs e)
        //{
        //    this.grdChamgo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        //    this.grdChamgo.SetBindVarValue("f_order_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date"));
        //    this.grdChamgo.SetBindVarValue("f_order_time", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_time"));
        //    this.grdChamgo.SetBindVarValue("f_bunho",        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho"));
        //    this.grdChamgo.SetBindVarValue("f_in_out_gubun", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun"));
        //    this.grdChamgo.SetBindVarValue("f_reser_date", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "reser_date"));
        //}


        #region XSavePerformer

        private int jubsu_cnt = 0;
        private int cancel_cnt = 0;
        private string t_jubsu_gubun = "";
        private string mErrMsg = "";
        //        private class XSavePerformer : IHIS.Framework.ISavePerformer
        //        {

        //            private CPL2010U00 parent = null;
        //            public XSavePerformer(CPL2010U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                string t_in_out_gubun = "";
        //                string t_fkocs = "";
        //                parent.mErrMsg = "";

        //                Hashtable inputList = new Hashtable();
        //                Hashtable outputList = new Hashtable();

        //                item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        //                switch (item.RowState)
        //                { 
        //                    case DataRowState.Modified:

        //                        cmdText = @"SELECT IN_OUT_GUBUN
        //                                         , DECODE(IN_OUT_GUBUN,'O',FKOCS1003,FKOCS2003) FKOCS
        //                                      FROM CPL2010
        //                                     WHERE HOSP_CODE = :f_hosp_code
        //                                       AND PKCPL2010 = :f_pkcpl2010";

        //                        DataTable dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

        //                        if (!TypeCheck.IsNull(dt))
        //                        {
        //                            t_in_out_gubun = dt.Rows[0]["in_out_gubun"].ToString();
        //                            t_fkocs = dt.Rows[0]["fkocs"].ToString();
        //                        }
        //                        else
        //                        {
        //                            parent.mErrMsg = Resources.mErrMsg + Service.ErrFullMsg;
        //                            return false;
        //                        }

        //                        // 受付チェックの場合、「DUMMY　= 'Y'」
        //                        if (item.BindVarList["f_jubsu_flag"].VarValue == "Y")
        //                        {
        //                            parent.jubsu_cnt++;

        //                            cmdText = @"UPDATE CPL2010
        //                                           SET UPD_ID    = :q_user_id
        //                                             , UPD_DATE  = SYSDATE
        //                                             , DUMMY     = 'Y'
        //                                         WHERE HOSP_CODE = :f_hosp_code
        //                                           AND PKCPL2010 = :f_pkcpl2010";

        //                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
        //                            {
        //                                if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
        //                                {
        //                                    parent.mErrMsg = Resources.mErrMsg + Service.ErrFullMsg;
        //                                    return false;
        //                                }
        //                            }
        //                        }
        //                        // 受付チェック取消の場合、「DUMMY　= 'N'」
        //                        else if (item.BindVarList["f_jubsu_flag"].VarValue == "N")
        //                        {
        //                            cmdText = @"  SELECT 'Y'
        //                                            FROM DUAL
        //                                           WHERE EXISTS ( SELECT 'X'
        //                                                            FROM CPL2010
        //                                                           WHERE HOSP_CODE = :f_hosp_code 
        //                                                             AND PKCPL2010 = :f_pkcpl2010
        //                                                             AND SPECIMEN_SER IS NOT NULL)";

        //                            object o_flag2 = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                            if (!TypeCheck.IsNull(o_flag2))
        //                            {
        //                                if (o_flag2.ToString() == "Y")
        //                                {
        //                                    parent.cancel_cnt++;

        //                                    cmdText = @"UPDATE CPL2010
        //                                                   SET UPD_ID    = :q_user_id
        //                                                     , UPD_DATE  = SYSDATE
        //                                                     , DUMMY     = 'N'
        //                                                 WHERE HOSP_CODE = :f_hosp_code 
        //                                                   AND PKCPL2010 = :f_pkcpl2010";

        //                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
        //                                    {
        //                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
        //                                        {
        //                                            parent.mErrMsg = Resources.mErrMsg + Service.ErrFullMsg;
        //                                            return false;
        //                                        }
        //                                    }

        //                                    inputList.Clear();

        //                                    inputList.Add("I_ORDER_DATE", item.BindVarList["f_order_date"].VarValue);
        //                                    inputList.Add("I_BUNHO", item.BindVarList["f_bunho"].VarValue);
        //                                    inputList.Add("I_JUBSUJA", UserInfo.UserID);
        //                                    inputList.Add("I_JUBSU_FLAG", "N");
        //                                    inputList.Add("I_JUBSU_GUBUN", parent.t_jubsu_gubun);// null
        //                                    inputList.Add("I_JUBSU_DATE", item.BindVarList["f_jubsu_date"].VarValue);
        //                                    inputList.Add("I_JUBSU_TIME", item.BindVarList["f_jubsu_time"].VarValue);

        //                                    if (!Service.ExecuteProcedure("PR_CPL_MAKE_SPECIMEN_SER", inputList, outputList))
        //                                    {
        //                                        parent.mErrMsg = Resources.mErrMsg4 + Service.ErrFullMsg;
        //                                        return false;
        //                                    }

        //                                    if (outputList.Count > 0)
        //                                    {
        //                                        if (outputList["IO_FLAG"].ToString() == "N")
        //                                        {
        //                                            parent.mErrMsg = Resources.mErrMsg2;
        //                                            return false;                                        
        //                                        }
        //                                    }

        //                                    cmdText = @"UPDATE CPL2010
        //                                                   SET UPD_ID    = :q_user_id
        //                                                     , UPD_DATE  = SYSDATE
        //                                                     , DUMMY     = NULL
        //                                                 WHERE HOSP_CODE = :f_hosp_code 
        //                                                   AND PKCPL2010 = :f_pkcpl2010";

        //                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
        //                                    {
        //                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
        //                                        {
        //                                            parent.mErrMsg = Resources.mErrMsg + Service.ErrFullMsg;
        //                                            return false;
        //                                        }
        //                                    }

        //                                    if (outputList["IO_FLAG"].ToString() == "N")
        //                                    {
        //                                        return true;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        break;
        //                }
        //                return true;
        //            }
        //        }
        #endregion

        private void grdSpecimen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (e.Button == MouseButtons.Left)
                {

                }
            }
        }

        private void grdTube_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            grdTube.ResetUpdate();
            if (e.ColName == "print_yn")
            {
                for (int i = 0; i < grdSpecimen.RowCount; i++)
                {
                    if (grdTube.GetItemString(grdTube.CurrentRowNumber, "tube_name") == grdSpecimen.GetItemString(i, "tube_name"))
                    {
                        grdSpecimen.SetItemValue(i, "print_yn", e.ChangeValue);
                    }
                }
            }
        }

        private void btnJusa_Click(object sender, EventArgs e)
        {
            if (this.fbxBunho.GetDataValue() == "")
            {
                return;
            }
            IXScreen old_screen = FindScreen("INJS", "INJ1001U01");

            if (old_screen == null)
            {
                CommonItemCollection param = new CommonItemCollection();

                //param.Add("order_date", grdOrder.GetItemValue(grdOrder.CurrentRowNumber, "order_date"));
                param.Add("bunho", this.fbxBunho.GetDataValue());
                param.Add("order_date", this.dtpOrderDate.GetDataValue());
                param.Add("jubsuja_id", this.dbxDocCode.GetDataValue());

                //param.Add("gwa", grdPaList.GetItemValue(grdPaList.CurrentRowNumber, "gwa"));
                //param.Add("doctor", grdPaList.GetItemValue(grdPaList.CurrentRowNumber, "doctor"));
                //param.Add("naewon_key", grdPaList.GetItemValue(grdPaList.CurrentRowNumber, "naewon_key"));

                XScreen.OpenScreenWithParam(this, "INJS", "INJ1001U01", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopLeft, param);

            }
            else
            {
                string bunho = this.fbxBunho.GetDataValue();
                string order_date = this.dtpOrderDate.GetDataValue();
                old_screen.Activate();
                XPatientInfo paInfo = new XPatientInfo(bunho, order_date, "", "", "", PatientPKGubun.Out, this.ScreenName);
                XScreen.SendPatientInfo(paInfo);

            }

        }


        private void grdPaList_QueryStarting(object sender, CancelEventArgs e)
        {
            //            if (this.rbxJubsu.Checked == true)
            //            {
            //                this.grdPaList.QuerySQL = @"/* grd PaList After Jubsu */
            //                                            SELECT A.BUNHO
            //                                                 , MAX(B.SUNAME)
            //                                                 , MAX(A.IN_OUT_GUBUN)
            //                                                 , MAX(FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE)) GWA_NAME
            //                                                 --, MAX(FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003))   TODAY_YN
            //                                                 , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)   RESER_YN
            //                                                 , MAX(A.DOCTOR)
            //                                                 , A.DOCTOR_NAME
            //                                                 --, FN_REQUEST_GWA_NAME('O',A.BUNHO, A.GWA, A.ORDER_DATE)            REQUEST_NAME
            //                                                 , NVL(A.RESER_DATE, A.ORDER_DATE)                                   KIJUN_DATE
            //                                                 , NVL(C.EMERGENCY, 'N')                                             EMERGENCY_YN
            //                                              FROM OCS1003 C
            //                                                 , OUT0101 B
            //                                                 , CPL2010 A
            //                                             WHERE A.HOSP_CODE    = :f_hosp_code
            //                                               AND B.HOSP_CODE    = A.HOSP_CODE 
            //                                               --AND ((A.ORDER_DATE     = TO_DATE(:f_order_date) AND A.RESER_DATE IS NULL )
            //                                               -- OR  (A.RESER_DATE     = TO_DATE(:f_order_date) ))
            //                                               AND ((:f_bunho IS NULL AND NVL(A.RESER_DATE, A.ORDER_DATE) between TO_DATE(:f_from_date) and TO_DATE(:f_to_date))
            //                                                OR  (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))
            //                                               AND A.JUBSU_DATE IS NOT NULL
            //                                               AND A.IN_OUT_GUBUN   = 'O'
            //                                               AND B.BUNHO          = A.BUNHO
            //                                               AND C.HOSP_CODE      = A.HOSP_CODE
            //                                               AND C.PKOCS1003      = A.FKOCS1003
            //                                               AND EXISTS (SELECT 'X' 
            //                                                             FROM OUT1001 X 
            //                                                            WHERE X.HOSP_CODE   = A.HOSP_CODE
            //                                                              --AND X.NAEWON_DATE between TO_DATE(:f_from_date) and TO_DATE(:f_to_date)
            //                                                              AND X.NAEWON_DATE = NVL(A.RESER_DATE, A.ORDER_DATE)
            //                                                              AND X.BUNHO       = A.BUNHO
            //                                                              AND X.GWA         != '03')  -- 来院患者チェック
            //                                                GROUP BY A.BUNHO
            //                                                       , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)
            //                                                       , A.DOCTOR_NAME
            //                                                       , FN_REQUEST_GWA_NAME('O',A.BUNHO, A.GWA, A.ORDER_DATE)
            //                                                       , NVL(A.RESER_DATE, A.ORDER_DATE)
            //                                                       , NVL(C.EMERGENCY, 'N')
            //                                             ORDER BY MAX(A.JUBSU_DATE) DESC, MAX(A.JUBSU_TIME) DESC";
            //            }
            //            else
            //            {
            //                this.grdPaList.QuerySQL = @"/* grd PaList Before Jubsu */
            //                                            SELECT A.BUNHO
            //                                                 , MAX(B.SUNAME)
            //                                                 , MAX(A.IN_OUT_GUBUN)
            //                                                 , MAX(FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE)) GWA_NAME
            //                                                -- , MAX(FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003))   TODAY_YN
            //                                                 , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)   RESER_YN
            //                                                 , MAX(A.DOCTOR)
            //                                                 , A.DOCTOR_NAME
            //                                                -- , FN_REQUEST_GWA_NAME('O',A.BUNHO, A.GWA, A.ORDER_DATE)            REQUEST_NAME 
            //                                                 , NVL(A.RESER_DATE, A.ORDER_DATE)                                   KIJUN_DATE
            //                                                 , NVL(C.EMERGENCY, 'N')                                             EMERGENCY_YN
            //                                                -- , DECODE(FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE), 'Y'
            //                                                --           , MAX((SELECT X.JUBSU_TIME
            //                                                --                FROM OUT1001 X 
            //                                                --              WHERE X.HOSP_CODE = A.HOSP_CODE 
            //                                                --                AND X.BUNHO = A.BUNHO
            //                                                --                AND X.NAEWON_DATE = TRUNC(SYSDATE)
            //                                                --                AND X.NAEWON_YN = 'Y'))
            //                                                --           , MAX(A.ORDER_TIME))                                       NAEWON_TIME
            //                                                 , MAX(A.ORDER_TIME)                                       NAEWON_TIME
            //                                              FROM OCS1003 C
            //                                                 , OUT0101 B
            //                                                 , CPL2010 A
            //                                             WHERE A.HOSP_CODE    = :f_hosp_code
            //                                               AND B.HOSP_CODE    = A.HOSP_CODE 
            //                                               --AND ((A.ORDER_DATE     = TO_DATE(:f_order_date) AND A.RESER_DATE IS NULL )
            //                                               -- OR  (A.RESER_DATE     = TO_DATE(:f_order_date) ))
            //                                               AND ((:f_bunho IS NULL AND NVL(A.RESER_DATE, A.ORDER_DATE) between TO_DATE(:f_from_date) and TO_DATE(:f_to_date))
            //                                                OR  (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))
            //                                               AND A.JUBSU_DATE IS NULL
            //                                               AND A.IN_OUT_GUBUN   = 'O'
            //                                               AND B.BUNHO          = A.BUNHO
            //                                               AND C.HOSP_CODE      = A.HOSP_CODE
            //                                               AND C.PKOCS1003      = A.FKOCS1003
            //                                               AND EXISTS (SELECT 'X' 
            //                                                             FROM OUT1001 X 
            //                                                            WHERE X.HOSP_CODE = A.HOSP_CODE
            //                                                              --AND X.NAEWON_DATE between TO_DATE(:f_from_date) and TO_DATE(:f_to_date)
            //                                                              AND X.NAEWON_DATE = NVL(A.RESER_DATE, A.ORDER_DATE)
            //                                                              AND X.BUNHO = A.BUNHO
            //                                                              AND NVL(X.NAEWON_YN, 'N') != 'N'  
            //                                                              AND X.GWA   != '03')  -- 来院患者チェック
            //                                                GROUP BY A.BUNHO
            //                                                       , FN_SCH_RESER_YN1(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003,A.RESER_DATE)
            //                                                       , A.DOCTOR_NAME
            //                                                       , FN_REQUEST_GWA_NAME('O',A.BUNHO, A.GWA, A.ORDER_DATE)
            //                                                       , NVL(A.RESER_DATE, A.ORDER_DATE)
            //                                                       , NVL(C.EMERGENCY, 'N')
            //                                              ORDER BY NVL(A.RESER_DATE, A.ORDER_DATE) , NAEWON_TIME";
            //            }

            this.grdPaList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPaList.SetBindVarValue("f_from_date", this.dtpOrderDate.GetDataValue());
            this.grdPaList.SetBindVarValue("f_to_date", this.dtpOrderToDate.GetDataValue());
            this.grdPaList.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void grdPaList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            this.setGrdBackColor(sender, e);
            //trial patient
            if (e.DataRow["trial"].ToString() == "Y")
            {
                grdPaList[e.RowNumber + 1, 1].ToolTipText = Resources.SMS_TRIAL;
            }
            if (e.DataRow["trial"].ToString() == "N")
            {
                grdPaList[e.RowNumber + 1, 1].ToolTipText = " ";
            }

        }

        #region grid backColor setting
        private void setGrdBackColor(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.Name == "grdPaList")
            {
                if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
                    e.BackColor = (XColor.XMatrixColHeaderBackColor).Color;

                if (grid.GetItemString(e.RowNumber, "emergency_yn") == "Y")
                    e.BackColor = Color.Pink;
            }
        }
        #endregion

        private void grdPaList_DoubleClick(object sender, EventArgs e)
        {
            //if (this.grdPaList.CurrentRowNumber < 0)
            //    return;

            //this.fbxBunho.SetEditValue(this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "bunho"));
            //this.fbxBunho.AcceptData();

        }

        private void grdPaList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.setGrdHeaderImage(this.grdPaList);

            this.QueryTime = TimeVal;

            if (this.grdPaList.RowCount > 0)
            {
                // 画面のALARMが活性の場合
                if (this.rbxMijubsu.Checked && this.useAlarmChkYN.Equals("Y"))
                {
                    for (int i = 0; i < grdPaList.RowCount; i++)
                    {
                        // 予約患者の場合は音無
                        if (this.grdPaList.GetItemString(i, "reser_yn").Equals("N")
                            || this.grdPaList.GetItemString(i, "in_out_gubun").Equals("O"))
                        {
                            // 一般、緊急の音をセットする。
                            if (this.grdPaList.GetItemString(i, "emergency_yn").Equals("Y")) this.playAlarm("CPL_EM");
                            else this.playAlarm("CPL");
                        }
                    }
                }
            }
            else
            {
                this.fbxBunho.SetEditValue("");
                this.fbxBunho.AcceptData();
            }
        }

        #region 환자 그리드 이미지 셋팅
        private void setGrdHeaderImage(XEditGrid grid)
        {
            if (grid.Name == "grdPaList")
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    // 입원 예약환자.
                    if (grid.GetItemString(i, "reser_yn") == "Y")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + Resources.ToolTipText1;
                    }

                    // 緊急オーダ
                    if (grid.GetItemString(i, "emergency_yn") == "Y")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[4];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + Resources.ToolTipText2;
                    }
                }
            }

            if (grid.Name == "grdSpecimen")
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    ///*
                    // GRIDのHEADを2行にした場合、ROWのイメージは　「＊２」にセットする。　                 
                    // */

                    // 至急オーダ
                    if (grid.GetItemString(i, "can_yn") == "X")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + Resources.ToolTipText3;
                    }

                    // 緊急オーダ
                    if (grid.GetItemString(i, "can_yn") == "Z")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[4];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + Resources.ToolTipText2;
                    }
                }
            }
        }
        #endregion

        #region [playAlarm] 撮影区分別にAlarmを設定
        private void playAlarm(string part)
        {
            try
            {
                if (part.Equals("CPL"))
                    Kernel32.PlaySound(this.alarmFilePath_CPL, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else if (part.Equals("CPL_EM"))
                    Kernel32.PlaySound(this.alarmFilePath_CPL_EM, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else
                    IHIS.Framework.Kernel32.Nofify();
            }
            catch { }
        }
        #endregion

        private void ClearInputControl()
        {
            foreach (object obj in this.pnlPaInfo.Controls)
            {
                if (obj is XDisplayBox)
                {
                    if (((XDisplayBox)obj).Name != "cbxActor")
                    {
                        ((XDisplayBox)obj).ResetData();
                    }
                }
            }
            this.fbxBunho.ResetData();
            this.btnJusa.Visible = false;
            this.pbxJusa.Visible = false;
        }
        private void ClearXEditGrid()
        {
            this.grdOrder.Reset();
            this.grdSpecimen.Reset();
            this.grdTube.Reset();
        }

        private void CPL2010U00_Closing(object sender, CancelEventArgs e)
        {
            this.timer1.Stop();
        }

        private void grdTube_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "print_yn")
            {
                if (this.rbxJubsu.Checked)
                    e.Protect = false;
                else if (this.rbxMijubsu.Checked)
                    e.Protect = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ORDERCANCEL dlg = new ORDERCANCEL(paInfoBox.BunHo, dtpOrderDate.GetDataValue());

            dlg.ShowDialog();
            grdSpecimen.QueryLayout(true);
        }

        #region [timer1_Tick] 自動照会関連
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = (this.QueryTime / 1000).ToString();
            this.QueryTime = this.QueryTime - 1000;

            if (QueryTime == 0)
            {
                // 受付TABの場合、再照会
                if (this.rbxMijubsu.Checked) this.grdPaList.QueryLayout(true);
                else
                    // 受付TABが選択される。
                    this.rbxMijubsu.Checked = true;

                this.timer1.Stop();

                this.timer1.Start();

                this.QueryTime = TimeVal;
            }
        }

        private void btnUseTimeChk_Click(object sender, EventArgs e)
        {
            // 自動照会使用可否 useTimeChkYN 

            if (this.useTimeChkYN.Equals("N"))
            {
                this.btnUseTimeChk.ImageIndex = 1;
                this.useTimeChkYN = "Y";

                this.timer1.Start();
                this.cboTime.Enabled = true;
                this.tbxTimer.SetDataValue("Y");
                this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
                this.txtTimeInterval.AcceptData();
            }
            else
            {
                this.btnUseTimeChk.ImageIndex = 0;
                this.useTimeChkYN = "N";

                this.cboTime.Enabled = false;
                this.timer1.Stop();
            }
        }

        #region [btnUseAlarmChk_Click]
        private void btnUseAlarmChk_Click(object sender, EventArgs e)
        {
            // 自動照会使用可否 useTimeChkYN 

            if (this.useAlarmChkYN.Equals("N"))
            {
                this.btnUseAlarmChk.ImageIndex = 1;
                this.useAlarmChkYN = "Y";
            }
            else
            {
                this.btnUseAlarmChk.ImageIndex = 0;
                this.useAlarmChkYN = "N";
            }
        }
        #endregion

        private void setTimer()
        {
            if (TypeCheck.IsInt(txtTimeInterval.Text))
            {
                this.QueryTime = int.Parse(txtTimeInterval.GetDataValue());
                this.TimeVal = int.Parse(txtTimeInterval.GetDataValue());
            }

            this.QueryTime = this.TimeVal;

            this.cboTime.SelectedIndex = 0;
            this.timer1.Start();
            this.cboTime.Enabled = true;
            this.tbxTimer.SetDataValue("Y");
            this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            this.txtTimeInterval.AcceptData();
        }

        private void txtTimeInterval_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsInt(e.DataValue))
            {
                this.QueryTime = int.Parse(e.DataValue);
                this.TimeVal = int.Parse(e.DataValue);


                this.lbTime.Text = (this.QueryTime / 1000).ToString();

                if (this.tbxTimer.GetDataValue() == "Y")
                {
                    this.timer1.Stop();
                    this.timer1.Start();
                }
            }
            else
            {
                PostCallHelper.PostCall(new PostMethod(PostTimerValidating));
            }
        }

        private void PostTimerValidating()
        {
            this.txtTimeInterval.SetDataValue(this.TimeVal.ToString());
        }

        private void cboTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.timer1.Stop();

            this.tbxTimer.SetDataValue("Y");
            this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            this.txtTimeInterval.AcceptData();

            this.timer1.Start();
        }
        #endregion


        private void grdPaList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.fbxBunho.SetEditValue(this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "bunho"));
            this.fbxBunho.AcceptData();
        }

        private void paBox_Validated(object sender, EventArgs e)
        {
            //btnList.PerformClick(FunctionType.Query);
            lbSuname.Text = paBox.SuName;

            this.grdPaList.QueryLayout(true);
        }


        // Sub-task MED-9280
        private void CPL2010U00OpenScreenCompositeFirst()
        {

            CPL2010U00OpenScreenCompositeArgs compositeArgs = new CPL2010U00OpenScreenCompositeArgs();
            //5
            ComboADM3200CbxActorArgs comboAdm3200CbxActorArgs = new ComboADM3200CbxActorArgs();
            compositeArgs.CbxActor = comboAdm3200CbxActorArgs;
            //6
            FormEnvironInfoSysDateArgs formEnvironInfoSysDateArgs = new FormEnvironInfoSysDateArgs();
            compositeArgs.InfoSysDate.Add(formEnvironInfoSysDateArgs);
            //7
            CPL2010U00GrdPaListArgs cpl2010U00GrdPaListArgs = new CPL2010U00GrdPaListArgs();
            cpl2010U00GrdPaListArgs.RbxJubsuChecked = this.rbxJubsu.Checked;
            cpl2010U00GrdPaListArgs.FromDate = dtpOrderDate.GetDataValue();
            cpl2010U00GrdPaListArgs.ToDate = dtpOrderToDate.GetDataValue();
            cpl2010U00GrdPaListArgs.Bunho = paBox.BunHo;
            compositeArgs.PaList = cpl2010U00GrdPaListArgs;

            FormEnvironInfoSysDateTimeArgs formEnvironInfoSysDateTimeArgs = new FormEnvironInfoSysDateTimeArgs();
            compositeArgs.InfoSysDateTime.Add(formEnvironInfoSysDateTimeArgs);
            //15
            CPL2010U00MlayConstantInfoArgs cpl2010U00MlayConstantInfoArgs1 = new CPL2010U00MlayConstantInfoArgs();
            cpl2010U00MlayConstantInfoArgs1.CodeType = "CPL_CONSTANT";
            compositeArgs.ConstantInfo.Add(cpl2010U00MlayConstantInfoArgs1);
            CPL2010U00MlayConstantInfoArgs cpl2010U00MlayConstantInfoArgs2 = new CPL2010U00MlayConstantInfoArgs();
            cpl2010U00MlayConstantInfoArgs2.CodeType = "CPL_ALARM";
            compositeArgs.ConstantInfo.Add(cpl2010U00MlayConstantInfoArgs2);

            CPL2010U00OpenScreenCompositeResult res = CloudService.Instance.Submit<CPL2010U00OpenScreenCompositeResult, CPL2010U00OpenScreenCompositeArgs>(compositeArgs, false, CallbackCompositeFirst);
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackCompositeFirst(CPL2010U00OpenScreenCompositeArgs args, CPL2010U00OpenScreenCompositeResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();
            cacheOne.Add(args.CbxActor, new KeyValuePair<int, object>(1, result.CbxActor));
            cacheOne.Add(args.InfoSysDate[0], new KeyValuePair<int, object>(3, result.InfoSysDate[0]));
            cacheOne.Add(args.PaList, new KeyValuePair<int, object>(1, result.PaList));
            cacheOne.Add(args.InfoSysDateTime[0], new KeyValuePair<int, object>(1, result.InfoSysDateTime[0]));
            for (int i = 0; i < result.ConstantInfo.Count; i++)
            {
                cacheOne.Add(args.ConstantInfo[i], new KeyValuePair<int, object>(1, result.ConstantInfo[i]));
            }
            cacheData.Add(CachePolicy.ONCE, cacheOne);

            return cacheData;
        }

        private void CPL2010U00OpenScreenCompositeSecond()
        {

            CPL2010U00OpenScreenCompositeArgs compositeArgs = new CPL2010U00OpenScreenCompositeArgs();

            CPL2010U00VsvPaArgs cpl2010U00VsvPaArgs = new CPL2010U00VsvPaArgs();
            cpl2010U00VsvPaArgs.Bunho = fbxBunho.GetDataValue();
            compositeArgs.VsvPa = cpl2010U00VsvPaArgs;

            XPaInfoBoxArgs paInfoBoxArgs = new XPaInfoBoxArgs(fbxBunho.GetDataValue());
            compositeArgs.InfoBox = paInfoBoxArgs;

            CPL2010U00LayChkNamesArgs cpl2010U00LayChkNamesArgs = new CPL2010U00LayChkNamesArgs();
            cpl2010U00LayChkNamesArgs.Bunho = fbxBunho.GetDataValue();
            cpl2010U00LayChkNamesArgs.ReserDate = dtpOrderDate.GetDataValue();
            compositeArgs.LayChkName = cpl2010U00LayChkNamesArgs;

            CPL2010U00GrdOrderArgs cpl2010U00GrdOrderArgs = new CPL2010U00GrdOrderArgs();
            cpl2010U00GrdOrderArgs.Bunho = fbxBunho.GetDataValue();
            cpl2010U00GrdOrderArgs.Mijubsu = this.mJubsu_yn;
            cpl2010U00GrdOrderArgs.ReserYn = grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "reser_yn");
            cpl2010U00GrdOrderArgs.FromDate = dtpOrderDate.GetDataValue();
            cpl2010U00GrdOrderArgs.ToDate = dtpOrderToDate.GetDataValue();
            cpl2010U00GrdOrderArgs.Doctor = grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "doctor");
            cpl2010U00GrdOrderArgs.EmergencyYn = grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "emergency_yn");
            compositeArgs.GrdOrder = cpl2010U00GrdOrderArgs;

            CPL2010U00GrdPaListArgs cpl2010U00GrdPaListArgs = new CPL2010U00GrdPaListArgs();
            cpl2010U00GrdPaListArgs.RbxJubsuChecked = this.rbxJubsu.Checked;
            cpl2010U00GrdPaListArgs.FromDate = dtpOrderDate.GetDataValue();
            cpl2010U00GrdPaListArgs.ToDate = dtpOrderToDate.GetDataValue();
            cpl2010U00GrdPaListArgs.Bunho = paBox.BunHo;
            compositeArgs.PaList = cpl2010U00GrdPaListArgs;


            CPL2010U00OpenScreenCompositeResult res = CloudService.Instance.Submit<CPL2010U00OpenScreenCompositeResult, CPL2010U00OpenScreenCompositeArgs>(compositeArgs, false, CallbackCompositeSecond);
        }

        private Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackCompositeSecond(CPL2010U00OpenScreenCompositeArgs args, CPL2010U00OpenScreenCompositeResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();

            cacheOne.Add(args.VsvPa, new KeyValuePair<int, object>(1, result.VsvPa));
            cacheOne.Add(args.InfoBox, new KeyValuePair<int, object>(1, result.InfoBox));
            cacheOne.Add(args.LayChkName, new KeyValuePair<int, object>(1, result.LayChkName));
            cacheOne.Add(args.GrdOrder, new KeyValuePair<int, object>(1, result.GrdOrder));

            if (result.GrdOrder.GrdOrderList.Count > 0)
            {
                CPL2010U00GrdSpecimenArgs specimenArgs = new CPL2010U00GrdSpecimenArgs();
                specimenArgs.MJubsuYn = this.mJubsu_yn;
                specimenArgs.OrderDate = result.GrdOrder.GrdOrderList[0].OrderDate;
                specimenArgs.Bunho = result.GrdOrder.GrdOrderList[0].Bunho;
                specimenArgs.Gwa = result.GrdOrder.GrdOrderList[0].Gwa;
                specimenArgs.OrderTime = result.GrdOrder.GrdOrderList[0].OrderTime;
                specimenArgs.Doctor = result.GrdOrder.GrdOrderList[0].Doctor;
                specimenArgs.ReserDate = result.GrdOrder.GrdOrderList[0].ReserDate;
                specimenArgs.JubsuDate = result.GrdOrder.GrdOrderList[0].JubsuDate;
                specimenArgs.JubsuTime = result.GrdOrder.GrdOrderList[0].JubsuTime;
                specimenArgs.Jubsuja = result.GrdOrder.GrdOrderList[0].Jubsuja;
                specimenArgs.GroupSer = result.GrdOrder.GrdOrderList[0].GroupSer;
                specimenArgs.ReserYn = grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "reser_yn");
                specimenArgs.EmergencyYn = grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "emergency_yn");

                cacheOne.Add(specimenArgs, new KeyValuePair<int, object>(1, result.GrdSpecimen));

                CPL2010U00GrdTubeQueryStartingArgs queryStartingArgs = new CPL2010U00GrdTubeQueryStartingArgs();
                queryStartingArgs.OrderDate = specimenArgs.OrderDate;
                queryStartingArgs.OrderTime = specimenArgs.OrderTime;
                queryStartingArgs.Bunho = fbxBunho.GetDataValue();

                cacheOne.Add(queryStartingArgs, new KeyValuePair<int, object>(1, result.GrdTube));

                CPL2010U00CheckInjCplOrderArgs injCplOrderArgs = new CPL2010U00CheckInjCplOrderArgs();
                injCplOrderArgs.Bunho = result.GrdOrder.GrdOrderList[0].Bunho;
                injCplOrderArgs.IoGubun = result.GrdOrder.GrdOrderList[0].InOutGubun;
                injCplOrderArgs.OrderDate = this.dtpOrderDate.GetDataValue();

                cacheOne.Add(injCplOrderArgs, new KeyValuePair<int, object>(1, result.InjCplOrder));
            }
            cacheData.Add(CachePolicy.ONCE, cacheOne);

            return cacheData;
        }

        #region [btnOrderPrint_Click 患者のオーダ内訳を印刷]
        private void btnOrderPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdSpecimen.RowCount < 1) return;

                //if (this.rbxMijubsu.Checked)
                //{
                this.layOrderPrint.Reset();
                //this.dwOrderPrint.Reset();

                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                {
                    this.layOrderPrint.InsertRow(i);
                    this.layOrderPrint.SetItemValue(i, "cnt", (i + 1).ToString());
                    this.layOrderPrint.SetItemValue(i, "order_date", this.grdSpecimen.GetItemString(i, "order_date"));
                    this.layOrderPrint.SetItemValue(i, "order_time", this.grdSpecimen.GetItemString(i, "order_time"));
                    this.layOrderPrint.SetItemValue(i, "bunho", this.fbxBunho.GetDataValue());
                    this.layOrderPrint.SetItemValue(i, "suname", this.dbxSuname.Text);
                    this.layOrderPrint.SetItemValue(i, "suname2", this.dbxSuname2.Text);
                    this.layOrderPrint.SetItemValue(i, "hangmog_code", this.grdSpecimen.GetItemString(i, "hangmog_code"));
                    this.layOrderPrint.SetItemValue(i, "hangmog_name", this.grdSpecimen.GetItemString(i, "gumsa_name"));
                    this.layOrderPrint.SetItemValue(i, "tube_name", this.grdSpecimen.GetItemString(i, "tube_name"));
                }

                //this.dwOrderPrint.Reset();
                //ApplyMultilanguagePrintDW();
                //this.dwOrderPrint.FillData(this.layOrderPrint.LayoutTable);
                //this.dwOrderPrint.Refresh();
                //this.dwOrderPrint.Print();

            }
            catch (Exception)
            {
                //XMessageBox.Show("Print was called when no DataWindow object was attached.", string.Empty, MessageBoxIcon.Error);
            }

            //}
        }
        #endregion
        private void InitDataWindow()
        {
            ////===https://sofiamedix.atlassian.net/browse/MED-9362
            //this.dwBarcode.DataWindowObject = "";
            //this.dwBarcode.DataWindowObject = global::IHIS.CPLS.Properties.Resources.dwBarcodeDataWindowObject;
            //this.dwBarcode.LibraryList = global::IHIS.CPLS.Properties.Resources.dwBarcodeLibraryList;
            //this.dwBarcode.Name = global::IHIS.CPLS.Properties.Resources.dwBarcodeName;
            ////===https://sofiamedix.atlassian.net/browse/MED-9360
            //this.dwOrderPrint.DataWindowObject = "";
            //this.dwOrderPrint.DataWindowObject = Resources.dwOrderPrintDataWindowObject;
            //this.dwOrderPrint.LibraryList = Resources.dwOrderPrintLibraryList;
            //this.dwOrderPrint.Name = Resources.dwOrderPrintName;
        }
        public void ApplyMultilanguagePrintDW()
        {
            try
            {
                //dw_comment
                //dwOrderPrint.Refresh();
                //dwOrderPrint.Modify(string.Format("pkapl1000_t.text = '{0}'", Resources.DW_TXT_1));
                //dwOrderPrint.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_2));
                //dwOrderPrint.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_3));
                //dwOrderPrint.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_4));
                //dwOrderPrint.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_5));
                //dwOrderPrint.Modify(string.Format("t_9.text = '{0}'", Resources.DW_TXT_6));
                //dwOrderPrint.Modify(string.Format("t_10.text = '{0}'", Resources.DW_TXT_7));
                //dwOrderPrint.Modify(string.Format("t_11.text = '{0}'", Resources.DW_TXT_8));
                //dwOrderPrint.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_9));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void grdPaList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("user_id", dbxDocCode.GetDataValue());
            param.Add("user_name", dbxDocName.GetDataValue());
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM104Q", ScreenOpenStyle.PopupSingleFixed, param);
        }

        #region https://sofiamedix.atlassian.net/browse/MED-15204

        private void SpecimenVisibleControl()
        {
            if (UserInfo.CplSpecimenAuto == "Y")
            {
                xLabel10.Visible = false;
                txtSpecimenNo.Visible = false;
            }
            else
            {
                xLabel10.Visible = true;
                txtSpecimenNo.Visible = true;
                txtSpecimenNo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                this.SetDefaultSpecimenSer();
            }
        }

        private bool SpecimenChecks()
        {
            // Do not check for tab executed
            if (rbxJubsu.Checked) return true;

            // Required check
            if (TypeCheck.IsNull(txtSpecimenNo.GetDataValue()))
            {
                XMessageBox.Show(Resources.MSG_REQUIRED_SPECIMEN, Resources.caption5, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Duplicate check
            CPL2010U00CheckSpecimenDupArgs args = new CPL2010U00CheckSpecimenDupArgs();
            args.JundalGubunText = txtSpecimenNo.GetDataValue();
            StringResult res = CloudService.Instance.Submit<StringResult, CPL2010U00CheckSpecimenDupArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == "Y")
            {
                XMessageBox.Show(Resources.MSG_DUP_SPECIMEN, Resources.caption5, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SetDefaultSpecimenSer()
        {
            txtSpecimenNo.SetDataValue(DateTime.Now.ToString("ddMMyy") + "-");
        }

        #endregion
    }
}

