#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.Framework;
#endregion

namespace IHIS.SCHS
{
    /// <summary>
    /// SCH0201Q05에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class SCH0201Q05 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XDataWindow dwReserList;
        private IHIS.Framework.XPatientBox paBoxPatient;
        private IHIS.Framework.MultiLayout layReserList;
        private XLabel xLabel1;
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
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public SCH0201Q05()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.layReserList.ParamList = new List<string>(new String[] { "f_hosp_code", "f_bunho" });
            this.layReserList.ExecuteQuery = LoadDataLayReserList;
        }

        private List<object[]> LoadDataLayReserList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SCH0201Q05LayReserListArgs vSCH0201Q05LayReserListArgs = new SCH0201Q05LayReserListArgs();
            vSCH0201Q05LayReserListArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            SCH0201Q05LayReserListResult result = CloudService.Instance.Submit<SCH0201Q05LayReserListResult, SCH0201Q05LayReserListArgs>(vSCH0201Q05LayReserListArgs);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (SCH0201Q05LayReserListInfo item in result.ReserListItem)
                {
                    object[] objects = 
				{ 
					item.Pksch0201, 
					item.InOutGubun, 
					item.Fkocs, 
					item.Bunho, 
					item.Gwa, 
					item.Gumsaja, 
					item.HangmogCode, 
					item.JundalTable, 
					item.JundalPart, 
					item.ReserDate, 
					item.ReserTime, 
					item.InputDate, 
					item.InputId, 
					item.Suname, 
					item.ReserYn, 
					item.CancelYn, 
					item.ActingDate, 
					item.HopeDate, 
					item.Comments, 
					item.HangmogName, 
					item.JundalPartName, 
					item.GwaName, 
					item.HoDong1, 
					item.Sex, 
					item.Age, 
					item.Birth, 
					item.InputGwa, 
					item.DoctorName, 
					item.UpdName
				};
                    res.Add(objects);
                }
            }
            return res;
        }



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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0201Q05));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.paBoxPatient = new IHIS.Framework.XPatientBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dwReserList = new IHIS.Framework.XDataWindow();
            this.layReserList = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBoxPatient)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.paBoxPatient);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // paBoxPatient
            // 
            resources.ApplyResources(this.paBoxPatient, "paBoxPatient");
            this.paBoxPatient.Name = "paBoxPatient";
            this.paBoxPatient.PatientSelected += new System.EventHandler(this.paBoxPatient_PatientSelected);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.dwReserList);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // dwReserList
            // 
            this.dwReserList.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList.DataWindowObject = "d_reser_list_01";
            resources.ApplyResources(this.dwReserList, "dwReserList");
            this.dwReserList.LibraryList = "SCHS\\schs.sch0201q05.pbd";
            this.dwReserList.LiveScroll = false;
            this.dwReserList.Name = "dwReserList";
            this.dwReserList.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwReserList.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_RowFocusChanged);
            this.dwReserList.Click += new System.EventHandler(this.dwReserList_Click);
            // 
            // layReserList
            // 
            this.layReserList.ExecuteQuery = null;
            this.layReserList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57});
            this.layReserList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserList.ParamList")));
            this.layReserList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layReserList_QueryStarting);
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "pksch0201";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "in_out_gubun";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "fkocs";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "bunho";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "gwa";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "gumsaja";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "hangmog_code";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "jundal_table";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "jundal_part";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "reser_date";
            this.multiLayoutItem38.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "reser_time";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "input_date";
            this.multiLayoutItem40.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "input_id";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "suname";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "reser_yn";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "cancel_yn";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "acting_date";
            this.multiLayoutItem45.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "hope_date";
            this.multiLayoutItem46.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "comments";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "hangmog_name";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "jundal_part_name";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "gwa_name";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "ho_dong";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "sex";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "age";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "birth";
            this.multiLayoutItem54.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "input_gwa";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "doctor_name";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "upd_name";
            // 
            // SCH0201Q05
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "SCH0201Q05";
            resources.ApplyResources(this, "$this");
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBoxPatient)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyMultiLangDatawindow();

            if (this.OpenParam != null)
            {
                this.paBoxPatient.SetPatientID(this.OpenParam["bunho"].ToString());

                this.ReserQuery();
                return;
            }
            else
            {
                // 이전 스크린의 등록번호를 가져온다
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                {
                    this.paBoxPatient.SetPatientID(patientInfo.BunHo);
                    this.ReserQuery();
                    return;
                }
            }
        }

        private void ApplyMultiLangDatawindow()
        {
            //dwReserList
            dwReserList.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_001));
            dwReserList.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_002));
            dwReserList.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_003));
            dwReserList.Modify(string.Format("t_4.text = '{0}'", Properties.Resources.DW_TXT_004));
            dwReserList.Modify(string.Format("t_5.text = '{0}'", Properties.Resources.DW_TXT_005));
            dwReserList.Modify(string.Format("t_6.text = '{0}'", Properties.Resources.DW_TXT_006));
            dwReserList.Modify(string.Format("t_7.text = '{0}'", Properties.Resources.DW_TXT_007));
            dwReserList.Modify(string.Format("t_8.text = '{0}'", Properties.Resources.DW_TXT_008));
            dwReserList.Modify(string.Format("panm_t.text = '{0}'", Properties.Resources.DW_TXT_009));
            dwReserList.Modify(string.Format("t_13.text = '{0}'", Properties.Resources.DW_TXT_013));
        }

        #endregion


        #region Reser List Query
        private void ReserQuery()
        {
            dwReserList.Reset();
            ApplyMultiLangDatawindow();

            layReserList.Reset();

            if (this.layReserList.QueryLayout(true))
            {
                dwReserList.FillData(layReserList.LayoutTable);
                dwReserList.Refresh();
            }
        }
        #endregion

        #region dw
        private void dwReserList_Click(object sender, System.EventArgs e)
        {
            dwReserList.Refresh();
        }

        private void dwReserList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            dwReserList.Refresh();
        }
        #endregion

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    // 예약 조회
                    ReserQuery();

                    break;

                default:
                    break;
            }
        }

        private void paBoxPatient_PatientSelected(object sender, System.EventArgs e)
        {
            ReserQuery();
        }

        private void layReserList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layReserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layReserList.SetBindVarValue("f_bunho", this.paBoxPatient.BunHo);
        }

    }
}

