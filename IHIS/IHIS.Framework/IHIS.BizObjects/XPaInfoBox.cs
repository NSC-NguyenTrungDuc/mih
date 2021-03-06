using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.Framework.Properties;

namespace IHIS.Framework
{
	/// <summary>
	/// XPaInfoBox에 대한 요약 설명입니다. (XPatientBox와 달리 환자상세정보 부분만 전담하는 Control)
	/// XPatintBox수정시에 반드시 이 Control도 확인해야함(조회조건, IN,OUT 변경시 등등)
	/// </summary>
	[ToolboxBitmap(typeof(IHIS.Framework.XPaInfoBox), "Images.XPatientBox.bmp")]
	public class XPaInfoBox : System.Windows.Forms.UserControl ,ISupportInitialize, IHIS.Framework.IUserObject
	{
		#region Fields
		private string bunHo = "";
		private ILayoutContainer layoutContainer = null;
		private Patient paInfo = new Patient();
		private XColor xBackColor = XColor.XScreenBackColor;
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		#endregion

		#region Properties
		/// <summary>
		/// LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.")]
		public bool ApplyLayoutContainerReset
		{
			get { return applyLayoutContainerReset; }
			set { applyLayoutContainerReset = value;}
		}
		//환자번호
		[Browsable(false), DataBindable]
		public string BunHo
		{
			get { return this.bunHo;}
		}
		[Browsable(false)]
		public string SuName
		{
			get { return paInfo.SuName; }
		}
		[Browsable(false)]
		public string SuName2
		{
			get { return paInfo.SuName2; }
		}

		// 성별
		[Browsable(false)]
		public string Sex
		{
			get { return paInfo.Sex; }
		}

		// 나이(년 단위)
		[Browsable(false)]
		public int YearAge
		{
			get 
			{
				if (TypeCheck.IsInt(paInfo.YearAge))
					return Int32.Parse(paInfo.YearAge);
				else
					return 0;
			}
		}
		// 나이(월 단위)
		[Browsable(false)]
		public int MonthAge
		{
			get 
			{
				if (TypeCheck.IsInt(paInfo.MonthAge))
					return Int32.Parse(paInfo.MonthAge);
				else
					return 0;
			}
		}
		// 보험구분
		[Browsable(false)]
		public string Gubun
		{
			get { return paInfo.Gubun; }
		}

		// 보험구분명
		[Browsable(false)]
		public string GubunName
		{
			get { return paInfo.GubunName; }
		}
		// 생일
		[Browsable(false)]
		public string Birth
		{
			get { return paInfo.Birth; }
		}

		// 전화번호
		[Browsable(false)]
		public string Tel
		{
			get 
			{ 
				return (paInfo.Tel != "" ? paInfo.Tel : paInfo.Tel1);
			}
		}
		//핸드폰 번호
		[Browsable(false)]
		public string TelHP
		{
			get { return paInfo.TelHP;}
		}

		// 우편번호1
		[Browsable(false)]
		public string Zip1
		{
			get { return paInfo.Zip1; }
		}

		// 우편번호2
		[Browsable(false)]
		public string Zip2
		{
			get { return paInfo.Zip2; }
		}

		// 주소1
		[Browsable(false)]
		public string Address1
		{
			get { return paInfo.Address1; }
		}

		// 주소2
		[Browsable(false)]
		public string Address2
		{
			get { return paInfo.Address2; }
		}
		//입원중여부 (2007/01/17 추가)
		[Browsable(false)]
		public bool InHospital
		{
			get { return paInfo.InHospital; }
		}
		#endregion

		#region Base Property
		[DefaultValue(typeof(XColor),"XScreenBackColor"),
		Description("배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		#endregion

		private System.Windows.Forms.PictureBox pbxBallMove;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components;
		private IHIS.Framework.SingleLayout layPaInfo;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem1;
        private IHIS.Framework.SingleLayoutItem singleLayoutItem2;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem5;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem6;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem7;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem8;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem9;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem10;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem11;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem12;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem13;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem14;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem15;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem16;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem17;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem18;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem19;
		private System.Windows.Forms.PictureBox pbxBallStop;

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XPaInfoBox));
            this.pbxBallStop = new System.Windows.Forms.PictureBox();
            this.pbxBallMove = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.layPaInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxBallStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBallMove)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxBallStop
            // 
            this.pbxBallStop.Image = ((System.Drawing.Image)(resources.GetObject("pbxBallStop.Image")));
            this.pbxBallStop.Location = new System.Drawing.Point(0, 0);
            this.pbxBallStop.Name = "pbxBallStop";
            this.pbxBallStop.Size = new System.Drawing.Size(20, 20);
            this.pbxBallStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxBallStop.TabIndex = 98;
            this.pbxBallStop.TabStop = false;
            // 
            // pbxBallMove
            // 
            this.pbxBallMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxBallMove.Image = ((System.Drawing.Image)(resources.GetObject("pbxBallMove.Image")));
            this.pbxBallMove.Location = new System.Drawing.Point(0, 0);
            this.pbxBallMove.Name = "pbxBallMove";
            this.pbxBallMove.Size = new System.Drawing.Size(20, 20);
            this.pbxBallMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxBallMove.TabIndex = 99;
            this.pbxBallMove.TabStop = false;
            this.toolTip.SetToolTip(this.pbxBallMove, "클릭시에 상세정보를 보여줍니다.");
            this.pbxBallMove.Visible = false;
            this.pbxBallMove.Click += new System.EventHandler(this.pbxBallMove_Click);
            // 
            // layPaInfo
            // 
            this.layPaInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
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
            this.singleLayoutItem19});
            this.layPaInfo.QuerySQL = resources.GetString("layPaInfo.QuerySQL");
            this.layPaInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPaInfo_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "SuName";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "SuName2";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "Sex";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "YearAge";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "MonthAge";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "Gubun";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "GubunName";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "Birth";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "Tel";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "Tel1";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "TelHP";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "Email";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.DataName = "Zip1";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "Zip2";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.DataName = "Address1";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "Address2";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "InHospital";
            // 
            // XPaInfoBox
            // 
            this.Controls.Add(this.pbxBallStop);
            this.Controls.Add(this.pbxBallMove);
            this.Name = "XPaInfoBox";
            this.Size = new System.Drawing.Size(20, 20);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBallStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBallMove)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	
		#region 생성자
		public XPaInfoBox()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

            // Connect Cloud
		    this.layPaInfo.ExecuteQuery = layPaInfo_GetPatientInfo;

		    this.Size = new Size(20,20);
			this.BackColor = XColor.XScreenBackColor;
			//ToolTip Text Set
			this.toolTip.SetToolTip(this.pbxBallMove, (NetInfo.Language == LangMode.Ko ? "클릭시에 환자상세정보를 보여줍니다."
				: Resource.pbxBallMove_ToolTip2));
		}
		#endregion

		#region IUserObject Implementation
		//UserObject의 Control은 Binding 허용하지 않음
		bool IUserObject.AllowBindControls
		{
			get { return false;}
		}
		//지정한 Property는 Binding 허용함
		bool IUserObject.AllowBindVariables
		{
			get { return true;}
		}
		#endregion

		#region ISupportInitialize Implemetation
		/// <summary>
		/// 초기화가 시작됨을 개체에 알립니다.
		/// </summary>
		void ISupportInitialize.BeginInit()
		{
		}
		/// <summary>
		/// 초기화 종료시 환자번호 BOX 초기화(InitialzePatientBox)합니다.
		/// </summary>
		void ISupportInitialize.EndInit()
		{
			if (!this.DesignMode)  //RunTime시에 ILayoutContainer SET
			{
				//ILayoutContainer SET
				SetLayoutContainer();
			}
		}
		#endregion

		#region ParentIsILayoutContainer, SetLayoutContainer, SetMsg
		/// <summary>
		/// Parent Control이 ILayoutContainer인지 여부를 반환합니다.
		/// </summary>
		/// <param name="parent"> Parent Control </param>
		/// <param name="parentControl"> (out) Parent Control 개체 </param>
		/// <returns> ILayoutContainer이면 true, 아니면 false </returns>
		protected bool ParentIsILayoutContainer(Control parent, out Control parentControl)
		{
			parentControl = null;
			if(parent is ILayoutContainer)
			{
				parentControl = parent;
				return true;
			}
			else
			{
				if(parent.Parent != null)
					return ParentIsILayoutContainer(parent.Parent, out parentControl);
				else
					return false;
			}
		}
		/// <summary>
		/// 환자번호 Box가 있는 화면,Form이 ILayoutContainer인지 SET 
		/// InitializeComponent에서 모든 Control이 설정되고 난후 반영되도록 EndInit에 추가함.
		/// </summary>
		private void SetLayoutContainer()
		{
			if (this.layoutContainer == null)
			{
				Control parentControl = null;
				if (this.Parent != null)
				{
					// DataLayout Container의 Current DataLayout 초기화
					if(ParentIsILayoutContainer(this.Parent, out parentControl))
					{
						this.layoutContainer = (ILayoutContainer) parentControl;
					}
				}
			}	
		}
		private void SetMsg(string msg, MsgType msgType)
		{
			//Screen위에 있으면 Screen으로 Msg를 보내고 ,없으면 MsgBox
			if (this.layoutContainer != null)
				this.layoutContainer.SetMsg(msg, msgType);
			else
				XMessageBox.Show(msg, "PatientBox");
		}
		#endregion

		#region QueryPatientInfo (환자정보 조회)
		private void QueryPatientInfo()  //환자번호로 환자정보 조회
		{
			this.Reset();
			SetMsg("", MsgType.Normal);

			string msg = "";
			//환자번호 입력여부 확인
			if (this.bunHo.Trim() == "")
			{
                // https://sofiamedix.atlassian.net/browse/MED-12243
                //msg = (NetInfo.Language == LangMode.Ko ? "환자번호를 입력하십시오"
                //    : "患者番号を入力してください。");
                msg = XMsg.GetMsg("M041");

				SetMsg(msg, MsgType.Error);
				return;
			}

            if (!this.layPaInfo.QueryLayout()) //환자정보 조회 실패시 Msg Set
            {
                msg = (NetInfo.Language == LangMode.Ko ? "환자번호를 잘못 입력하셨습니다."
                    : Resource.Msg_00001);
                SetMsg(msg, MsgType.Error);
                return;
            }
            //성공시에 환자정보 설정
            //<미확정> 조회문에 InHospital 조회가 없음. pc파일 확인하여 수정필요
            paInfo.BunHo		= this.bunHo;
            paInfo.SuName		= layPaInfo.GetItemValue("SuName").ToString();
            paInfo.SuName2		= layPaInfo.GetItemValue("SuName2").ToString();
            paInfo.Sex			= layPaInfo.GetItemValue("Sex").ToString();
            paInfo.YearAge		= layPaInfo.GetItemValue("YearAge").ToString();
            paInfo.MonthAge		= layPaInfo.GetItemValue("MonthAge").ToString();
            paInfo.Gubun		= layPaInfo.GetItemValue("Gubun").ToString();
            paInfo.GubunName	= layPaInfo.GetItemValue("GubunName").ToString();
            paInfo.Birth		= layPaInfo.GetItemValue("Birth").ToString();
            paInfo.Tel			= layPaInfo.GetItemValue("Tel").ToString();
            paInfo.Tel1			= layPaInfo.GetItemValue("Tel1").ToString();
            paInfo.TelHP		= layPaInfo.GetItemValue("TelHP").ToString();
            paInfo.Email		= layPaInfo.GetItemValue("Email").ToString();
            paInfo.Zip1			= layPaInfo.GetItemValue("Zip1").ToString();
            paInfo.Zip2			= layPaInfo.GetItemValue("Zip2").ToString();
            paInfo.Address1		= layPaInfo.GetItemValue("Address1").ToString();
            paInfo.Address2		= layPaInfo.GetItemValue("Address2").ToString();
            paInfo.InHospital   = ( layPaInfo.GetItemValue("InHospital").ToString() == "Y" ? true : false); //입원중여부

            //환자번호 입력됨 이미지 SET
			this.pbxBallStop.Visible = false;
			this.pbxBallMove.Visible = true;
	
		}
		#endregion

		#region Public Method (Reset, SetPatientID)
		public void Reset()
		{
			//환자정보 Clear
			this.pbxBallStop.Visible = true;
			this.pbxBallMove.Visible = false;
			this.paInfo.Reset();
		}
		public void SetPatientID(string bunHo)
		{
			//환자번호 설정후 환자정보 조회 Service call
			this.bunHo = bunHo;
			//환자정보 조회
			QueryPatientInfo();
		}
		#endregion

		#region 환자번호 MoveBall Click시에 환자상세정보 조회)
		private void pbxBallMove_Click(object sender, System.EventArgs e)
		{
			//상세정보 완료전까지 일단 Comment 처리
			DetailPaInfoForm dlg = new DetailPaInfoForm(this.paInfo, this.pbxBallMove);
			dlg.ShowDialog(EnvironInfo.MdiForm);
			dlg.Dispose();
		}
		#endregion

		private void layPaInfo_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//f_bunho BIND 변수 SET
			layPaInfo.SetBindVarValue("f_bunho", this.bunHo);
		}

	    private List<string> layPaInfo_CreateParamList()
	    {
	        List<string> listParam = new List<string>();
            listParam.Add("f_bunho");
	        return listParam;
	    }

        private IList<object[]> layPaInfo_GetPatientInfo(BindVarCollection bindVarCollection)
	    {
            IList<object[]> lstResult = new List<object[]>();

            XPaInfoBoxResult res = CloudService.Instance.Submit<XPaInfoBoxResult, XPaInfoBoxArgs>(new XPaInfoBoxArgs(bindVarCollection["f_bunho"].VarValue));
            if (res.ExecutionStatus == ExecutionStatus.Success && res.PatientInfoItem.Count > 0)
            {
                XPaInfoBoxInfo paInfoItem = res.PatientInfoItem[0];

                lstResult.Add(new object[]
                {
                    paInfoItem.PatientName,
                    paInfoItem.PatientName2,
                    paInfoItem.Sex,
                    paInfoItem.YearAge,
                    paInfoItem.MonthAge,
                    paInfoItem.DepartmentCode,
                    paInfoItem.DepartmentName,
                    paInfoItem.Birth,
                    paInfoItem.Tel,
                    paInfoItem.Tel1,
                    paInfoItem.TelHp,
                    paInfoItem.Email,
                    paInfoItem.ZipCode1,
                    paInfoItem.ZipCode2,
                    paInfoItem.Address1,
                    paInfoItem.Address2,
                    "" // InHospital
                });
            }

            return lstResult;
	    }
	}
}
