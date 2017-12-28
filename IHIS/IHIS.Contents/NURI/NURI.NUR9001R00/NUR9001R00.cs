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
	/// NUR9001R00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR9001R00 : IHIS.Framework.XScreen
	{
		#region 화면변수
		private string sysid  = string.Empty;
		private string screen = string.Empty;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlTopLeft;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XLabel lblRecord_date;
		private IHIS.Framework.XDatePicker dtpFrom_date;
		private IHIS.Framework.XDatePicker dtpTo_date;
		private System.Windows.Forms.Label lblDash;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XDataWindow dwNur9001R00;
        //private IHIS.Framework.DataServiceSIMO dsvNur9001r_Query;
        private IHIS.Framework.MultiLayout layNur9001R00;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayout layWorkTime;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
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
        private MultiLayoutItem multiLayoutItem33;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR9001R00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR9001R00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlTopLeft = new IHIS.Framework.XPanel();
            this.lblDash = new System.Windows.Forms.Label();
            this.dtpTo_date = new IHIS.Framework.XDatePicker();
            this.dtpFrom_date = new IHIS.Framework.XDatePicker();
            this.lblRecord_date = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dwNur9001R00 = new IHIS.Framework.XDataWindow();
            this.layNur9001R00 = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.layWorkTime = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlTopLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNur9001R00)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWorkTime)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.pnlTopLeft);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlTop.Size = new System.Drawing.Size(760, 36);
            this.pnlTop.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBox.Location = new System.Drawing.Point(328, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(432, 31);
            this.paBox.TabIndex = 1;
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.Controls.Add(this.lblDash);
            this.pnlTopLeft.Controls.Add(this.dtpTo_date);
            this.pnlTopLeft.Controls.Add(this.dtpFrom_date);
            this.pnlTopLeft.Controls.Add(this.lblRecord_date);
            this.pnlTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTopLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Size = new System.Drawing.Size(328, 31);
            this.pnlTopLeft.TabIndex = 0;
            // 
            // lblDash
            // 
            this.lblDash.BackColor = System.Drawing.Color.Transparent;
            this.lblDash.Location = new System.Drawing.Point(192, 9);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(9, 13);
            this.lblDash.TabIndex = 4;
            this.lblDash.Text = "-";
            // 
            // dtpTo_date
            // 
            this.dtpTo_date.IsJapanYearType = true;
            this.dtpTo_date.Location = new System.Drawing.Point(204, 5);
            this.dtpTo_date.Name = "dtpTo_date";
            this.dtpTo_date.Size = new System.Drawing.Size(109, 20);
            this.dtpTo_date.TabIndex = 3;
            // 
            // dtpFrom_date
            // 
            this.dtpFrom_date.IsJapanYearType = true;
            this.dtpFrom_date.Location = new System.Drawing.Point(80, 5);
            this.dtpFrom_date.Name = "dtpFrom_date";
            this.dtpFrom_date.Size = new System.Drawing.Size(109, 20);
            this.dtpFrom_date.TabIndex = 2;
            // 
            // lblRecord_date
            // 
            this.lblRecord_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblRecord_date.EdgeRounding = false;
            this.lblRecord_date.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord_date.Location = new System.Drawing.Point(7, 5);
            this.lblRecord_date.Name = "lblRecord_date";
            this.lblRecord_date.Size = new System.Drawing.Size(70, 20);
            this.lblRecord_date.TabIndex = 1;
            this.lblRecord_date.Text = "照会日";
            this.lblRecord_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 665);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(760, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(516, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(244, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dwNur9001R00
            // 
            this.dwNur9001R00.DataWindowObject = "dw_nur9001r00";
            this.dwNur9001R00.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwNur9001R00.LibraryList = "..\\NURI\\nuri.nur9001r00.pbd";
            this.dwNur9001R00.Location = new System.Drawing.Point(0, 36);
            this.dwNur9001R00.Name = "dwNur9001R00";
            this.dwNur9001R00.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwNur9001R00.Size = new System.Drawing.Size(760, 629);
            this.dwNur9001R00.TabIndex = 2;
            this.dwNur9001R00.Text = "xDataWindow1";
            // 
            // layNur9001R00
            // 
            this.layNur9001R00.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem33});
            this.layNur9001R00.QuerySQL = resources.GetString("layNur9001R00.QuerySQL");
            this.layNur9001R00.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNur9001R00_QueryStarting);
            this.layNur9001R00.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layNur9001R00_QueryEnd);
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "record_date";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "record_time";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "soap_gubun";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "record_contents";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "record_user";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "record_user_name";
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
            this.multiLayoutItem27.DataName = "dc_yn";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "mayak_use_yn";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "color";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "record_date";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "record_time";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "soap_gubun";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "record_contents";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "record_user";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "record_user_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "bunho";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "suname";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "dc_yn";
            // 
            // layWorkTime
            // 
            this.layWorkTime.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layWorkTime.QuerySQL = "SELECT CODE         WORK_TIME_GUUBUN\r\n     , CODE_NAME    WORK_TIME\r\n  FROM NUR01" +
                "02 \r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = \'WORK_TIME\'";
            this.layWorkTime.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layWorkTime_QueryStarting);
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "time_gubun";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "time";
            // 
            // NUR9001R00
            // 
            this.Controls.Add(this.dwNur9001R00);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR9001R00";
            this.Size = new System.Drawing.Size(760, 700);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR9001R00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlTopLeft.ResumeLayout(false);
            this.pnlTopLeft.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNur9001R00)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWorkTime)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen Load

        string from_time1 = ""; // 일근            
        string to_time1 = ""; // 일근
        string from_time2 = ""; // 준야          
        string to_time2 = ""; // 준야
        string from_time3 = ""; // 심야          
        string to_time3 = ""; // 심야
		private void NUR9001R00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			/* 조회기간 설정 */
            this.dtpFrom_date.SetEditValue(EnvironInfo.GetSysDate().AddDays(-6).ToString("yyyy/MM/dd"));
			this.dtpFrom_date.AcceptData();
            this.dtpTo_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpTo_date.AcceptData();

            string t_time = "";
            string[] temp_time = null;

            this.layWorkTime.QueryLayout(false);
            if (this.layWorkTime.RowCount == 3)
            {
                t_time = this.layWorkTime.GetItemString(0, "time"); // 일근
                //일근
                temp_time = t_time.Split('-');
                if (temp_time.Length == 2)
                {
                    from_time1 = temp_time[0];
                    to_time1 = temp_time[1];
                }

                //준야
                t_time = this.layWorkTime.GetItemString(1, "time"); // 준야
                temp_time = t_time.Split('-');
                if (temp_time.Length == 2)
                {
                    from_time2 = temp_time[0];
                    to_time2 = temp_time[1];
                }

                //심야
                t_time = this.layWorkTime.GetItemString(2, "time"); // 심야
                temp_time = t_time.Split('-');
                if (temp_time.Length == 2)
                {
                    from_time3 = temp_time[0];
                    to_time3 = temp_time[1];
                }
            }

			if (this.OpenParam != null)
			{
				this.sysid      = OpenParam["sysid"].ToString();
				this.screen     = OpenParam["screen"].ToString();
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
                this.dtpFrom_date.SetDataValue(OpenParam["from_date"].ToString());
                this.dtpFrom_date.SetDataValue(OpenParam["from_date"].ToString());

				if(this.dtpFrom_date.GetDataValue().ToString() != ""&& this.dtpTo_date.GetDataValue().ToString() != "" &&
					this.paBox.BunHo.ToString() != "")
				{
					if(this.layNur9001R00.QueryLayout(true))
					{
						if(this.layNur9001R00.RowCount > 0)
						{
							this.dwNur9001R00.Reset();
							this.dwNur9001R00.FillData(this.layNur9001R00.LayoutTable);

                            //this.dwNur9001R00.Modify("from_time1.TEXT='" + this.from_time1 + "'");
                            //this.dwNur9001R00.Modify("to_time1.TEXT='" + this.to_time1 + "'");
                            //this.dwNur9001R00.Modify("from_time2.TEXT='" + this.from_time2 + "'");
                            //this.dwNur9001R00.Modify("to_time2.TEXT='" + this.to_time2 + "'");
                            //this.dwNur9001R00.Modify("from_time3.TEXT='" + this.from_time3 + "'");
                            //this.dwNur9001R00.Modify("to_time3.TEXT='" + this.to_time3 + "'");

                            //this.dwNur9001R00.Refresh();

							return;
						}
					}
					else
					{
						XMessageBox.Show(Service.ErrFullMsg.ToString());
						return;
					}
				}
			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.paBox.SetPatientID(patientInfo.BunHo);

					if(this.dtpFrom_date.GetDataValue().ToString() != ""&& this.dtpTo_date.GetDataValue().ToString() != "" &&
						this.paBox.BunHo.ToString() != "")
					{
						if(this.layNur9001R00.QueryLayout(true))
						{
							if(this.layNur9001R00.RowCount > 0)
							{
								this.dwNur9001R00.Reset();
                                this.dwNur9001R00.FillData(this.layNur9001R00.LayoutTable);

                                //this.dwNur9001R00.Modify("from_time1.TEXT='" + this.from_time1 + "'");
                                //this.dwNur9001R00.Modify("to_time1.TEXT='" + this.to_time1 + "'");
                                //this.dwNur9001R00.Modify("from_time2.TEXT='" + this.from_time2 + "'");
                                //this.dwNur9001R00.Modify("to_time2.TEXT='" + this.to_time2 + "'");
                                //this.dwNur9001R00.Modify("from_time3.TEXT='" + this.from_time3 + "'");
                                //this.dwNur9001R00.Modify("to_time3.TEXT='" + this.to_time3 + "'");
                                /*
                                 * if( mayak_use_yn = 'Y', rgb(255,0,0), if(  record_time < '0830',rgb(255,0,0),if(record_time >= '1700',rgb(0,0,255),rgb(0,0,0)) ))
                                 */

                                //this.dwNur9001R00.Refresh();
								return;
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

					if(this.dtpFrom_date.GetDataValue().ToString() != ""&& this.dtpTo_date.GetDataValue().ToString() != "" &&
						this.paBox.BunHo.ToString() != "")
					{
						if(this.layNur9001R00.QueryLayout(true))
						{
							if(this.layNur9001R00.RowCount > 0)
							{
								this.dwNur9001R00.Reset();
								this.dwNur9001R00.FillData(this.layNur9001R00.LayoutTable);
								return;
							}
						}
						else
						{
							XMessageBox.Show(Service.ErrFullMsg.ToString());
							return;
						}
					}
					break;
				case FunctionType.Print:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					try
					{
						if(this.dwNur9001R00.RowCount > 0)
						{
							this.dwNur9001R00.Print(true);
							return;
						}
					}
					catch(Exception Xe)
					{
						//https://sofiamedix.atlassian.net/browse/MED-10610
						//XMessageBox.Show(Xe.Message.ToString());
						return;
					}
					break;
				default:
					break;
			}
		}
		#endregion

        #region Query Event
        private void layNur9001R00_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNur9001R00.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNur9001R00.SetBindVarValue("f_from_date", this.dtpFrom_date.GetDataValue());
            this.layNur9001R00.SetBindVarValue("f_to_date", this.dtpTo_date.GetDataValue());
            this.layNur9001R00.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void layWorkTime_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layWorkTime.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layNur9001R00_QueryEnd(object sender, QueryEndEventArgs e)
        {
            for (int i = 0; i < this.layNur9001R00.RowCount; i++)
            {
                string record_time = this.layNur9001R00.GetItemString(i, "record_time");
                //일근
                if (this.from_time1 != "" && this.to_time1 != "")
                {
                    if (int.Parse(record_time) >= Convert.ToInt32(from_time1)
                        && int.Parse(record_time) < Convert.ToInt32(to_time1))
                    {
                        this.layNur9001R00.SetItemValue(i, "color", "BLACK");
                    }
                }

                //준야
                if (this.from_time2 != "" && this.to_time2 != "")
                {
                    if (int.Parse(record_time) >= Convert.ToInt32(from_time2)
                        && int.Parse(record_time) < Convert.ToInt32(to_time2))
                    {
                        this.layNur9001R00.SetItemValue(i, "color", "BLUE");
                    }
                }

                //심야
                if (this.from_time3 != "" && this.to_time3 != "")
                {
                    if ((int.Parse(record_time) >= Convert.ToInt32(from_time3) && int.Parse(record_time) <= 2400)
                      || (int.Parse(record_time) <= Convert.ToInt32(to_time3) && int.Parse(record_time) >= 0))
                    {
                        this.layNur9001R00.SetItemValue(i, "color", "RED");
                    }
                }
            }
        }
        #endregion
    }
}

