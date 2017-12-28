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
	public class NUR9999R12 : IHIS.Framework.XScreen
	{
		#region 자동생성

        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XDataWindow dw_nur9999r12;
        private IHIS.Framework.MultiLayout layGetInfo;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
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
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
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
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
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
        private MultiLayoutItem multiLayoutItem91;
        private MultiLayoutItem multiLayoutItem92;
        private MultiLayoutItem multiLayoutItem93;
        private MultiLayoutItem multiLayoutItem97;
        private MultiLayoutItem multiLayoutItem99;
        private XButton btnZoomIn;
        private XDisplayBox dbxZoom;
        private XButton btnZoomOut;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR9999R12()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR9999R12));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnZoomIn = new IHIS.Framework.XButton();
            this.dbxZoom = new IHIS.Framework.XDisplayBox();
            this.btnZoomOut = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.dw_nur9999r12 = new IHIS.Framework.XDataWindow();
            this.layGetInfo = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem91 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem92 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem93 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem97 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem99 = new IHIS.Framework.MultiLayoutItem();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layGetInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnZoomIn);
            this.pnlBottom.Controls.Add(this.dbxZoom);
            this.pnlBottom.Controls.Add(this.btnZoomOut);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 785);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(802, 35);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.Location = new System.Drawing.Point(102, 5);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(26, 26);
            this.btnZoomIn.TabIndex = 6;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // dbxZoom
            // 
            this.dbxZoom.EditMaskType = IHIS.Framework.MaskType.Number;
            this.dbxZoom.GeneralNumberFormat = true;
            this.dbxZoom.Location = new System.Drawing.Point(33, 6);
            this.dbxZoom.Name = "dbxZoom";
            this.dbxZoom.Size = new System.Drawing.Size(68, 24);
            this.dbxZoom.TabIndex = 5;
            this.dbxZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.Location = new System.Drawing.Point(6, 5);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(26, 26);
            this.btnZoomOut.TabIndex = 4;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "EMR転送", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(552, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(250, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.dw_nur9999r12);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(802, 785);
            this.pnlFill.TabIndex = 3;
            // 
            // dw_nur9999r12
            // 
            this.dw_nur9999r12.DataWindowObject = "nur9999r12";
            this.dw_nur9999r12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_nur9999r12.LibraryList = "..\\NURI\\nuri.nur9999r12.pbd";
            this.dw_nur9999r12.Location = new System.Drawing.Point(0, 0);
            this.dw_nur9999r12.Name = "dw_nur9999r12";
            this.dw_nur9999r12.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dw_nur9999r12.Size = new System.Drawing.Size(802, 785);
            this.dw_nur9999r12.TabIndex = 0;
            this.dw_nur9999r12.Text = "xDataWindow1";
            // 
            // layGetInfo
            // 
            this.layGetInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem16,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
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
            this.multiLayoutItem91,
            this.multiLayoutItem92,
            this.multiLayoutItem93,
            this.multiLayoutItem97,
            this.multiLayoutItem99});
            this.layGetInfo.QuerySQL = resources.GetString("layGetInfo.QuerySQL");
            this.layGetInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layGetInfo_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "write_date";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "bunho";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "birth";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "age";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "gwa";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "doctor";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "reason";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "address";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "sang_name";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "past_his";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "infection";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "taboo";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "ipwon_date";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "toiwon_date";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "ho_dong";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "damdang_nurse";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "leader_nurse";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "tel";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "key1_relation";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "key1_home";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "key1_phone";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "key1_office";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "key2_relation";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "key2_home";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "key2_phone";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "key2_office";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "inpatient_course";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "nursing_pass";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "continue_nursing";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "food";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "food_adl";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "food_adl_cmt";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "excretion";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "excretion_adl";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "excretion_adl_cmt";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "move";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "move_adl";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "move_adl_cmt";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "wash";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "wash_adl";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "wash_adl_cmt";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "ware_adl";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "ware_adl_cmt";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "communication";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "sleep";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "tube";
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "comments";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "fkinp1001";
            // 
            // NUR9999R12
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "NUR9999R12";
            this.Size = new System.Drawing.Size(802, 820);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR9999R12_ScreenOpen);
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
            this.dw_nur9999r12.Reset();
            this.layGetInfo.QueryLayout(true);

            if (layGetInfo.RowCount > 0)
            {
                this.dw_nur9999r12.FillData(this.layGetInfo.LayoutTable);
            }

            if (isCalled)
            {
                dw_nur9999r12.Print();
            }
        }

		#endregion

		#region 스크린 로드
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
		}

        bool isCalled = false;
        string pknur9999 = "";

		private void PostLoad()
		{

		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
                case FunctionType.Process:

                    if (EMRHelper.EMRPrint(dw_nur9999r12, EMRIOTGubun.IN, layGetInfo.GetItemString(0, "bunho"), EnvironInfo.GetSysDate().ToShortDateString(), "", this.Name, layGetInfo.GetItemString(0, "fkinp1001")))
                    {
                        XMessageBox.Show("EMR転送成功");
                    }
                    else
                    {
                        XMessageBox.Show("EMR転送失敗");
                    }
                    break;

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
					if(this.dw_nur9999r12.RowCount > 0)
					{
						try
						{
							this.dw_nur9999r12.Print(true);
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

        private void layGetInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layGetInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layGetInfo.SetBindVarValue("f_pknur9999", pknur9999);
        }

        private void NUR9999R12_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Size.Width, rc.Height - 105);

            if (this.OpenParam != null)
            {
                if (this.OpenParam["isCalled"].ToString() == "Y")
                {
                    this.isCalled = true;
                    this.Visible = false;
                }
                else
                {
                    this.Visible = true;
                }

                if (this.OpenParam.Contains("pknur9999"))
                {
                    pknur9999 = OpenParam["pknur9999"].ToString();
                    GetQuery();
                }

                // DataWindow Preview설정
                dw_nur9999r12.Modify("DataWindow.Print.Preview=Yes");
                dw_nur9999r12.Modify("DataWindow.Print.Preview.Zoom= 100");
                dbxZoom.SetDataValue("100");
            }
            else
            {
                this.Close();
            }

        }
        #region [Zoom 처리]

        private void btnZoomIn_Click(object sender, System.EventArgs e)
        {
            int zoom = int.Parse(dbxZoom.GetDataValue());
            if (zoom < 200) zoom = zoom + 10;

            dw_nur9999r12.Modify("DataWindow.Print.Preview.Zoom= " + zoom.ToString());

            dbxZoom.SetDataValue(zoom);
        }

        private void btnZoomOut_Click(object sender, System.EventArgs e)
        {
            int zoom = int.Parse(dbxZoom.GetDataValue());
            if (zoom > 0) zoom = zoom - 10;

            dw_nur9999r12.Modify("DataWindow.Print.Preview.Zoom= " + zoom.ToString());

            dbxZoom.SetDataValue(zoom);
        }
        #endregion

    }
}

