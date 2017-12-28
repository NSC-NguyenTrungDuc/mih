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
using IHIS.Framework;
#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// NUR1014R00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1014R00 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XLabel lblWrdt;
		private IHIS.Framework.XDatePicker dtpWrdt;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XDataWindow dwNur1014R00;
        private IHIS.Framework.MultiLayout layGetInfo;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR1014R00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}
		#endregion

		#region 소멸자
		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1014R00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.dtpWrdt = new IHIS.Framework.XDatePicker();
            this.lblWrdt = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.dwNur1014R00 = new IHIS.Framework.XDataWindow();
            this.layGetInfo = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layGetInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.dtpWrdt);
            this.pnlTop.Controls.Add(this.lblWrdt);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(761, 30);
            this.pnlTop.TabIndex = 0;
            // 
            // dtpWrdt
            // 
            this.dtpWrdt.IsJapanYearType = true;
            this.dtpWrdt.Location = new System.Drawing.Point(78, 5);
            this.dtpWrdt.Name = "dtpWrdt";
            this.dtpWrdt.Size = new System.Drawing.Size(110, 20);
            this.dtpWrdt.TabIndex = 112;
            // 
            // lblWrdt
            // 
            this.lblWrdt.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblWrdt.EdgeRounding = false;
            this.lblWrdt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrdt.Location = new System.Drawing.Point(5, 5);
            this.lblWrdt.Name = "lblWrdt";
            this.lblWrdt.Size = new System.Drawing.Size(71, 20);
            this.lblWrdt.TabIndex = 111;
            this.lblWrdt.Text = "照会日付";
            this.lblWrdt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(201, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(560, 30);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 785);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(761, 35);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(517, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(244, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.dwNur1014R00);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 30);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(761, 755);
            this.pnlFill.TabIndex = 3;
            // 
            // dwNur1014R00
            // 
            this.dwNur1014R00.DataWindowObject = "dw_nur1014r00";
            this.dwNur1014R00.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwNur1014R00.LibraryList = "..\\NURI\\nuri.nur1014r00.pbd";
            this.dwNur1014R00.Location = new System.Drawing.Point(0, 0);
            this.dwNur1014R00.Name = "dwNur1014R00";
            this.dwNur1014R00.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwNur1014R00.Size = new System.Drawing.Size(761, 755);
            this.dwNur1014R00.TabIndex = 0;
            this.dwNur1014R00.Text = "xDataWindow1";
            // 
            // layGetInfo
            // 
            this.layGetInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem32,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47});
            this.layGetInfo.QuerySQL = resources.GetString("layGetInfo.QuerySQL");
            this.layGetInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layGetInfo_QueryStarting);
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "wrdt";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "bunho";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "suname";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "out_date";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "out_time";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "in_hope_date";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "in_hope_time";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "out_object_text";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "doctor";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "doctor_name";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "ho_dong";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "ho_dong_name";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "out_date1";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "in_hope_date1";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "addr_tel";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "yoyang_name";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "nut_start_date";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "nut_start_kini";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "nut_end_date";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "nut_end_kini";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "woi_gubun";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "nut_end_yn";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "dest_ishome";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "dest_addr";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "dest_tel";
            // 
            // NUR1014R00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1014R00";
            this.Size = new System.Drawing.Size(761, 820);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layGetInfo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 조회

        private void GetQuery()
        {
            if (this.dtpWrdt.GetDataValue().ToString() != "" && this.paBox.BunHo.ToString() != "")
            {
                this.dwNur1014R00.Reset();
                if (this.layGetInfo.QueryLayout(true))
                {
                    string cmdText = @"SELECT A.ADDRESS||' '||A.ADDRESS1||' (TEL) '|| A.TEL ADDR_TEL
                                             , A.YOYANG_NAME                                    YOYANG_NAME
                                          FROM BAS0001 A
                                         WHERE A.HOSP_CODE  = :f_hosp_code
                                           AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE";

                    BindVarCollection bc = new BindVarCollection();

                    bc.Add("f_hosp_code", EnvironInfo.HospCode);

                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);

                    if (!TypeCheck.IsNull(dt))
                    {
                        if (this.layGetInfo.RowCount > 0)
                        {
                            this.layGetInfo.SetItemValue(0, "addr_tel", dt.Rows[0]["addr_tel"].ToString());
                            this.layGetInfo.SetItemValue(0, "yoyang_name", dt.Rows[0]["yoyang_name"].ToString());

                            this.dwNur1014R00.FillData(this.layGetInfo.LayoutTable);

                            if (isCalled)
                            {
                                this.ParentForm.WindowState = FormWindowState.Minimized;
                                dwNur1014R00.Print();
                                this.Close();
                            }

                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg.ToString());
                        return;
                    }
                }
            }
        }

		#endregion

		#region 스크린 로드
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

        bool isCalled = false;
        string flag = "";
        string out_time = "";
        string in_hope_date = "";
        string in_hope_time = "";

		private void PostLoad()
		{
            this.dtpWrdt.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpWrdt.AcceptData();
            isCalled = false;

            flag = "";
            out_time = "";
            in_hope_date = "";
            in_hope_time = "";

			if (this.OpenParam != null)
            {
                if (this.OpenParam["isCalled"].ToString() == "Y")
                {
                    isCalled = true;
                    this.Visible = false;
                }
                flag = this.OpenParam["flag"].ToString();
                out_time = this.OpenParam["out_time"].ToString();
                in_hope_date = this.OpenParam["in_hope_date"].ToString();
                in_hope_time = this.OpenParam["in_hope_time"].ToString();

                this.dtpWrdt.SetDataValue(this.OpenParam["order_date"].ToString());
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());

			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.paBox.SetPatientID(patientInfo.BunHo);
				}
			}
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
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					//조회
					GetQuery();
					break;
				case FunctionType.Print:
					e.IsBaseCall = false;
					if(this.dwNur1014R00.RowCount > 0)
					{
						try
						{
							this.dwNur1014R00.Print(true);
						}
						catch(Exception Xe)
						{
							//https://sofiamedix.atlassian.net/browse/MED-10610
							//XMessageBox.Show(Xe.Message.ToString());
							return;
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 환자번호를 입력을 했을 때

		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			//조회
			GetQuery();
		}

		#endregion

        private void layGetInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layGetInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layGetInfo.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layGetInfo.SetBindVarValue("f_wrdt", this.dtpWrdt.GetDataValue());
            this.layGetInfo.SetBindVarValue("f_out_time", this.out_time);
            this.layGetInfo.SetBindVarValue("f_gubun", this.flag);
            this.layGetInfo.SetBindVarValue("f_in_hope_date", this.in_hope_date);
            this.layGetInfo.SetBindVarValue("f_in_hope_time", this.in_hope_time);
        }
	}
}

