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
	/// NUR8050R00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR8050R00 : IHIS.Framework.XScreen
	{
		#region 화면변수
		private string sysid  = string.Empty;
		private string screen = string.Empty;
        private string mSort = string.Empty;
        private string mFkinp1001 = string.Empty;

		#endregion

		#region 자동생성
        private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XLabel lblRecord_date;
        private IHIS.Framework.XDatePicker dtpDate;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XDataWindow dwNur8050R00;
        //private IHIS.Framework.DataServiceSIMO dsvNur8050r_Query;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayout layNUR8050his;
        private XRadioButton rbxGubun;
        private XRadioButton rbxDate;
        private XGroupBox gbxSort;
        private XLabel xLabel2;
        private XDictComboBox cboGubun;
        private XNumericUpDown nudCnt;
        private XLabel xLabel1;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR8050R00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR8050R00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.nudCnt = new IHIS.Framework.XNumericUpDown();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cboGubun = new IHIS.Framework.XDictComboBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.dtpDate = new IHIS.Framework.XDatePicker();
            this.lblRecord_date = new IHIS.Framework.XLabel();
            this.gbxSort = new IHIS.Framework.XGroupBox();
            this.rbxGubun = new IHIS.Framework.XRadioButton();
            this.rbxDate = new IHIS.Framework.XRadioButton();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dwNur8050R00 = new IHIS.Framework.XDataWindow();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.layNUR8050his = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.gbxSort.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR8050his)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.nudCnt);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.cboGubun);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.dtpDate);
            this.pnlTop.Controls.Add(this.lblRecord_date);
            this.pnlTop.Controls.Add(this.gbxSort);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlTop.Size = new System.Drawing.Size(761, 70);
            this.pnlTop.TabIndex = 0;
            // 
            // nudCnt
            // 
            this.nudCnt.Location = new System.Drawing.Point(469, 9);
            this.nudCnt.Name = "nudCnt";
            this.nudCnt.Size = new System.Drawing.Size(64, 20);
            this.nudCnt.TabIndex = 17;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.Location = new System.Drawing.Point(393, 8);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(70, 20);
            this.xLabel1.TabIndex = 16;
            this.xLabel1.Text = "項目数";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel2.Location = new System.Drawing.Point(4, 8);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(70, 20);
            this.xLabel2.TabIndex = 11;
            this.xLabel2.Text = "区分";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboGubun
            // 
            this.cboGubun.Location = new System.Drawing.Point(80, 8);
            this.cboGubun.Name = "cboGubun";
            this.cboGubun.Size = new System.Drawing.Size(121, 21);
            this.cboGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGubun.TabIndex = 10;
            this.cboGubun.UserSQL = resources.GetString("cboGubun.UserSQL");
            this.cboGubun.SelectedIndexChanged += new System.EventHandler(this.cboGubun_SelectedIndexChanged);
            // 
            // paBox
            // 
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(6, 36);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(749, 31);
            this.paBox.TabIndex = 1;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // dtpDate
            // 
            this.dtpDate.IsJapanYearType = true;
            this.dtpDate.Location = new System.Drawing.Point(641, 9);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(109, 20);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.Visible = false;
            // 
            // lblRecord_date
            // 
            this.lblRecord_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblRecord_date.EdgeRounding = false;
            this.lblRecord_date.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord_date.Location = new System.Drawing.Point(565, 9);
            this.lblRecord_date.Name = "lblRecord_date";
            this.lblRecord_date.Size = new System.Drawing.Size(70, 20);
            this.lblRecord_date.TabIndex = 1;
            this.lblRecord_date.Text = "照会日";
            this.lblRecord_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecord_date.Visible = false;
            // 
            // gbxSort
            // 
            this.gbxSort.Controls.Add(this.rbxGubun);
            this.gbxSort.Controls.Add(this.rbxDate);
            this.gbxSort.Location = new System.Drawing.Point(209, 0);
            this.gbxSort.Name = "gbxSort";
            this.gbxSort.Size = new System.Drawing.Size(178, 31);
            this.gbxSort.TabIndex = 8;
            this.gbxSort.TabStop = false;
            // 
            // rbxGubun
            // 
            this.rbxGubun.AutoSize = true;
            this.rbxGubun.CheckedValue = "N";
            this.rbxGubun.Location = new System.Drawing.Point(97, 10);
            this.rbxGubun.Name = "rbxGubun";
            this.rbxGubun.Size = new System.Drawing.Size(64, 17);
            this.rbxGubun.TabIndex = 7;
            this.rbxGubun.Text = "区分順";
            this.rbxGubun.UseVisualStyleBackColor = true;
            // 
            // rbxDate
            // 
            this.rbxDate.AutoSize = true;
            this.rbxDate.Checked = true;
            this.rbxDate.Location = new System.Drawing.Point(15, 10);
            this.rbxDate.Name = "rbxDate";
            this.rbxDate.Size = new System.Drawing.Size(77, 17);
            this.rbxDate.TabIndex = 6;
            this.rbxDate.TabStop = true;
            this.rbxDate.Text = "作成日順";
            this.rbxDate.UseVisualStyleBackColor = true;
            this.rbxDate.CheckedChanged += new System.EventHandler(this.rbxDate_CheckedChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 665);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(761, 35);
            this.pnlBottom.TabIndex = 1;
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
            // dwNur8050R00
            // 
            this.dwNur8050R00.DataWindowObject = "nur8050his";
            this.dwNur8050R00.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwNur8050R00.LibraryList = "..\\NURI\\nuri.nur8050r00.pbd";
            this.dwNur8050R00.Location = new System.Drawing.Point(0, 70);
            this.dwNur8050R00.Name = "dwNur8050R00";
            this.dwNur8050R00.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwNur8050R00.Size = new System.Drawing.Size(761, 595);
            this.dwNur8050R00.TabIndex = 2;
            this.dwNur8050R00.Text = "xDataWindow1";
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
            // layNUR8050his
            // 
            this.layNUR8050his.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7});
            this.layNUR8050his.QuerySQL = resources.GetString("layNUR8050his.QuerySQL");
            this.layNUR8050his.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNur8050his_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "suname";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "gubun";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "detail";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "write_date";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "write_user";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "confirm_user";
            // 
            // NUR8050R00
            // 
            this.Controls.Add(this.dwNur8050R00);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR8050R00";
            this.Size = new System.Drawing.Size(761, 700);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR8050R00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.gbxSort.ResumeLayout(false);
            this.gbxSort.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR8050his)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen Load

        private void NUR8050R00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Width, rc.Height - 105);

            // 매개변수 세팅
			if (this.OpenParam != null)
			{
				this.sysid      = OpenParam["sysid"].ToString();
				this.screen     = OpenParam["screen"].ToString();

                this.paBox.PatientSelected -= new EventHandler(paBox_PatientSelected);
                this.paBox.SetPatientID(e.OpenParam["bunho"].ToString());
                this.paBox.PatientSelected += new EventHandler(paBox_PatientSelected);

                GetFkinp1001();

                this.dtpDate.SetDataValue(e.OpenParam["date"].ToString());
                this.cboGubun.SetDataValue(e.OpenParam["gubun"].ToString());
                
                if (e.OpenParam["sort"].ToString() == "Y")
                {
                    rbxDate.Checked = true;
                    nudCnt.SetDataValue(20);
                }
                else
                {
                    rbxGubun.Checked = true;
                    nudCnt.SetDataValue(3);
                }
                
                
                this.AcceptData();

                this.btnList.PerformClick(FunctionType.Query);
			}
			else
			{
                /* 조회기간 설정 */
                this.dtpDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                this.dtpDate.AcceptData();

				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.paBox.SetPatientID(patientInfo.BunHo);

					if( this.dtpDate.GetDataValue().ToString() != "" &&
						this.paBox.BunHo.ToString() != "")
					{
						if(this.layNUR8050his.QueryLayout(true))
						{
							if(this.layNUR8050his.RowCount > 0)
							{
								this.dwNur8050R00.Reset();
                                this.dwNur8050R00.FillData(this.layNUR8050his.LayoutTable);

                                //this.dwNur8050R00.Modify("from_time1.TEXT='" + this.from_time1 + "'");
                                //this.dwNur8050R00.Modify("to_time1.TEXT='" + this.to_time1 + "'");
                                //this.dwNur8050R00.Modify("from_time2.TEXT='" + this.from_time2 + "'");
                                //this.dwNur8050R00.Modify("to_time2.TEXT='" + this.to_time2 + "'");
                                //this.dwNur8050R00.Modify("from_time3.TEXT='" + this.from_time3 + "'");
                                //this.dwNur8050R00.Modify("to_time3.TEXT='" + this.to_time3 + "'");
                                /*
                                 * if( mayak_use_yn = 'Y', rgb(255,0,0), if(  record_time < '0830',rgb(255,0,0),if(record_time >= '1700',rgb(0,0,255),rgb(0,0,0)) ))
                                 */

                                //this.dwNur8050R00.Refresh();
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

					if( this.dtpDate.GetDataValue().ToString() != "" &&
						this.paBox.BunHo.ToString() != "")
					{
						if(this.layNUR8050his.QueryLayout(true))
						{
							if(this.layNUR8050his.RowCount > 0)
							{
								this.dwNur8050R00.Reset();
								this.dwNur8050R00.FillData(this.layNUR8050his.LayoutTable);
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
						if(this.dwNur8050R00.RowCount > 0)
						{
							this.dwNur8050R00.Print(true);
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

        private void layNur8050his_QueryStarting(object sender, CancelEventArgs e)
        {
            string strCmd = string.Empty;

            if (rbxGubun.Checked)
            {
                strCmd = @"SELECT A.BUNHO
                                 , A.SUNAME
                                 , A.GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , A.WRITE_USER
                                 , A.CONFIRM_USER
                                 , A.ROW_NUMBER  
                              FROM
                             (SELECT A.BUNHO
                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)  AS SUNAME
                                 , B.CODE_NAME                  AS GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , FN_ADM_LOAD_USER_NM(A.WRITE_USER, SYSDATE)       AS WRITE_USER
                                 , FN_ADM_LOAD_USER_NM(A.CONFIRM_USER, SYSDATE)     AS CONFIRM_USER
                                 , ROW_NUMBER() OVER (ORDER BY A.WRITE_DATE DESC) AS ROW_NUMBER
                                 --, A.GUBUN
                              FROM NUR8050 A
                                 , NUR0102 B
                             WHERE A.HOSP_CODE  = :f_hosp_code
                               AND A.BUNHO      = :f_bunho
                               AND A.FKINP1001  = :f_fkinp1001
                               AND ( (:f_gubun = '%' AND A.GUBUN = '01')
                                     OR (:f_gubun = '01' AND A.GUBUN = '01'))
                               AND B.HOSP_CODE  = A.HOSP_CODE
                               AND B.CODE_TYPE  = 'ADL_WORK_GUBUN'
                               AND B.CODE       = A.GUBUN  
                             ORDER BY A.WRITE_DATE DESC) A
                             WHERE (:f_gubun = '%' AND A.ROW_NUMBER <= TO_NUMBER(:f_cnt)
                                OR :f_gubun != '%' AND 1=1) 

                            UNION ALL

                            SELECT A.BUNHO
                                 , A.SUNAME
                                 , A.GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , A.WRITE_USER
                                 , A.CONFIRM_USER
                                 , A.ROW_NUMBER  
                              FROM
                             (SELECT A.BUNHO
                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)  AS SUNAME
                                 , B.CODE_NAME                  AS GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , FN_ADM_LOAD_USER_NM(A.WRITE_USER, SYSDATE)       AS WRITE_USER
                                 , FN_ADM_LOAD_USER_NM(A.CONFIRM_USER, SYSDATE)     AS CONFIRM_USER
                                 , ROW_NUMBER() OVER (ORDER BY A.WRITE_DATE DESC) AS ROW_NUMBER
                                 --, A.GUBUN
                              FROM NUR8050 A
                                 , NUR0102 B
                             WHERE A.HOSP_CODE  = :f_hosp_code
                               AND A.BUNHO      = :f_bunho
                               AND A.FKINP1001  = :f_fkinp1001
                               AND ( (:f_gubun = '%' AND A.GUBUN = '02')
                                     OR (:f_gubun = '02' AND A.GUBUN = '02'))
                               AND B.HOSP_CODE  = A.HOSP_CODE
                               AND B.CODE_TYPE  = 'ADL_WORK_GUBUN'
                               AND B.CODE       = A.GUBUN  
                             ORDER BY A.WRITE_DATE DESC) A
                             WHERE (:f_gubun = '%' AND A.ROW_NUMBER <= TO_NUMBER(:f_cnt)
                                OR :f_gubun != '%' AND 1=1)
                             
                             UNION ALL

                            SELECT A.BUNHO
                                 , A.SUNAME
                                 , A.GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , A.WRITE_USER
                                 , A.CONFIRM_USER
                                 , A.ROW_NUMBER  
                              FROM
                             (SELECT A.BUNHO
                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)  AS SUNAME
                                 , B.CODE_NAME                  AS GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , FN_ADM_LOAD_USER_NM(A.WRITE_USER, SYSDATE)       AS WRITE_USER
                                 , FN_ADM_LOAD_USER_NM(A.CONFIRM_USER, SYSDATE)     AS CONFIRM_USER
                                 , ROW_NUMBER() OVER (ORDER BY A.WRITE_DATE DESC) AS ROW_NUMBER
                                 --, A.GUBUN
                              FROM NUR8050 A
                                 , NUR0102 B
                             WHERE A.HOSP_CODE  = :f_hosp_code
                               AND A.BUNHO      = :f_bunho
                               AND A.FKINP1001  = :f_fkinp1001
                               AND ( (:f_gubun = '%' AND A.GUBUN = '03')
                                     OR (:f_gubun = '03' AND A.GUBUN = '03'))
                               AND B.HOSP_CODE  = A.HOSP_CODE
                               AND B.CODE_TYPE  = 'ADL_WORK_GUBUN'
                               AND B.CODE       = A.GUBUN  
                             ORDER BY A.WRITE_DATE DESC) A
                             WHERE (:f_gubun = '%' AND A.ROW_NUMBER <= TO_NUMBER(:f_cnt)
                                OR :f_gubun != '%' AND 1=1)
                                
                             UNION ALL

                            SELECT A.BUNHO
                                 , A.SUNAME
                                 , A.GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , A.WRITE_USER
                                 , A.CONFIRM_USER
                                 , A.ROW_NUMBER  
                              FROM
                             (SELECT A.BUNHO
                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)  AS SUNAME
                                 , B.CODE_NAME                  AS GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , FN_ADM_LOAD_USER_NM(A.WRITE_USER, SYSDATE)       AS WRITE_USER
                                 , FN_ADM_LOAD_USER_NM(A.CONFIRM_USER, SYSDATE)     AS CONFIRM_USER
                                 , ROW_NUMBER() OVER (ORDER BY A.WRITE_DATE DESC) AS ROW_NUMBER
                                 --, A.GUBUN
                              FROM NUR8050 A
                                 , NUR0102 B
                             WHERE A.HOSP_CODE  = :f_hosp_code
                               AND A.BUNHO      = :f_bunho
                               AND A.FKINP1001  = :f_fkinp1001
                               AND ( (:f_gubun = '%' AND A.GUBUN = '04')
                                     OR (:f_gubun = '04' AND A.GUBUN = '04'))
                               AND B.HOSP_CODE  = A.HOSP_CODE
                               AND B.CODE_TYPE  = 'ADL_WORK_GUBUN'
                               AND B.CODE       = A.GUBUN  
                             ORDER BY A.WRITE_DATE DESC) A
                             WHERE (:f_gubun = '%' AND A.ROW_NUMBER <= TO_NUMBER(:f_cnt)
                                OR :f_gubun != '%' AND 1=1) 
                                
                             UNION ALL

                            SELECT A.BUNHO
                                 , A.SUNAME
                                 , A.GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , A.WRITE_USER
                                 , A.CONFIRM_USER
                                 , A.ROW_NUMBER  
                              FROM
                             (SELECT A.BUNHO
                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)  AS SUNAME
                                 , B.CODE_NAME                  AS GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , FN_ADM_LOAD_USER_NM(A.WRITE_USER, SYSDATE)       AS WRITE_USER
                                 , FN_ADM_LOAD_USER_NM(A.CONFIRM_USER, SYSDATE)     AS CONFIRM_USER
                                 , ROW_NUMBER() OVER (ORDER BY A.WRITE_DATE DESC) AS ROW_NUMBER
                                 --, A.GUBUN
                              FROM NUR8050 A
                                 , NUR0102 B
                             WHERE A.HOSP_CODE  = :f_hosp_code
                               AND A.BUNHO      = :f_bunho
                               AND A.FKINP1001  = :f_fkinp1001
                               AND ( (:f_gubun = '%' AND A.GUBUN = '05')
                                     OR (:f_gubun = '05' AND A.GUBUN = '05'))
                               AND B.HOSP_CODE  = A.HOSP_CODE
                               AND B.CODE_TYPE  = 'ADL_WORK_GUBUN'
                               AND B.CODE       = A.GUBUN  
                             ORDER BY A.WRITE_DATE DESC) A
                             WHERE (:f_gubun = '%' AND A.ROW_NUMBER <= TO_NUMBER(:f_cnt)
                                OR :f_gubun != '%' AND 1=1)
                             
                             UNION ALL

                            SELECT A.BUNHO
                                 , A.SUNAME
                                 , A.GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , A.WRITE_USER
                                 , A.CONFIRM_USER
                                 , A.ROW_NUMBER  
                              FROM
                             (SELECT A.BUNHO
                                 , FN_OUT_LOAD_SUNAME(A.BUNHO)  AS SUNAME
                                 , B.CODE_NAME                  AS GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , FN_ADM_LOAD_USER_NM(A.WRITE_USER, SYSDATE)       AS WRITE_USER
                                 , FN_ADM_LOAD_USER_NM(A.CONFIRM_USER, SYSDATE)     AS CONFIRM_USER
                                 , ROW_NUMBER() OVER (ORDER BY A.WRITE_DATE DESC) AS ROW_NUMBER
                                 --, A.GUBUN
                              FROM NUR8050 A
                                 , NUR0102 B
                             WHERE A.HOSP_CODE  = :f_hosp_code
                               AND A.BUNHO      = :f_bunho
                               AND A.FKINP1001  = :f_fkinp1001
                               AND ( (:f_gubun = '%' AND A.GUBUN = '06')
                                     OR (:f_gubun = '06' AND A.GUBUN = '06'))
                               AND B.HOSP_CODE  = A.HOSP_CODE
                               AND B.CODE_TYPE  = 'ADL_WORK_GUBUN'
                               AND B.CODE       = A.GUBUN  
                             ORDER BY A.WRITE_DATE DESC) A
                             WHERE (:f_gubun = '%' AND A.ROW_NUMBER <= TO_NUMBER(:f_cnt)
                                OR :f_gubun != '%' AND 1=1)
                                ";
            }
            else
            {
                strCmd = @" SELECT A.BUNHO
                                 , A.SUNAME
                                 , A.GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , A.WRITE_USER
                                 , A.CONFIRM_USER
                            FROM     
                            (SELECT A.BUNHO
                                 , FN_OUT_LOAD_SUNAME(A.BUNHO) AS SUNAME
                                 , A.FKINP1001
                                 , B.CODE_NAME   AS GUBUN_NAME
                                 , A.DETAIL
                                 , A.WRITE_DATE
                                 , FN_ADM_LOAD_USER_NM(A.WRITE_USER, SYSDATE)    AS WRITE_USER
                                 , FN_ADM_LOAD_USER_NM(A.CONFIRM_USER, SYSDATE)    AS CONFIRM_USER
                                 , ROW_NUMBER() OVER(ORDER BY A.WRITE_DATE DESC, A.GUBUN) AS ROW_NUM
                              FROM NUR8050 A
                                 , NUR0102 B
                             WHERE A.HOSP_CODE  = :f_hosp_code
                               AND A.BUNHO      = :f_bunho
                               AND A.FKINP1001  = :f_fkinp1001
                               AND A.GUBUN      LIKE :f_gubun
                               AND B.HOSP_CODE  = A.HOSP_CODE
                               AND B.CODE_TYPE  = 'ADL_WORK_GUBUN'
                               AND B.CODE       = A.GUBUN  
                             ORDER BY A.WRITE_DATE DESC, A.GUBUN) A
                             WHERE A.ROW_NUM <= TO_NUMBER(:f_cnt)
                                ";
            }

            layNUR8050his.QuerySQL = strCmd;

            this.layNUR8050his.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNUR8050his.SetBindVarValue("f_bunho", paBox.BunHo);
            this.layNUR8050his.SetBindVarValue("f_fkinp1001", this.mFkinp1001);
            this.layNUR8050his.SetBindVarValue("f_gubun", cboGubun.GetDataValue());
            this.layNUR8050his.SetBindVarValue("f_cnt", nudCnt.GetDataValue());
        }

        #endregion

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
            {
                if (this.GetFkinp1001())
                {
                    if (!layNUR8050his.QueryLayout(false))
                    {
                        XMessageBox.Show(Service.ErrFullMsg + "\n\r" + Service.ErrCode);
                    }
                }
            }
        }

        /// <summary>
        /// 환자번호로 입원키를 찾는다.
        /// </summary>
        #region 환자의 입원키를 찾는다.
        private bool GetFkinp1001()
        {
            try
            {
                string cmdText = @"SELECT PKINP1001
                                     FROM VW_OCS_INP1001_01
                                    WHERE HOSP_CODE            = :f_hosp_code 
                                      AND NVL(CANCEL_YN,'N')   = 'N'
                                      AND NVL(JAEWON_FLAG,'N') = 'Y'
                                      AND BUNHO                = :f_bunho";

                BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVars.Add("f_bunho", paBox.BunHo.Trim());

                object retVal = Service.ExecuteScalar(cmdText, bindVars);

                if (TypeCheck.IsNull(retVal))
                {
                    paBox.Focus();
                    return false;
                }
                else
                {
                    mFkinp1001 =  retVal.ToString();
                    return true;
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
                return false;
            }
        }
        #endregion

        private void paBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            layNUR8050his.Reset();
            dwNur8050R00.Reset();
        }

        private void rbxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbxDate.Checked)
            {
                this.nudCnt.SetDataValue(20);
            }
            else
            {
                this.nudCnt.SetDataValue(3);
            }

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cboGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

    }
}

