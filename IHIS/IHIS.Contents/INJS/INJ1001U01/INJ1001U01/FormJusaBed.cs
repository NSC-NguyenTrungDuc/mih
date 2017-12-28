using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;

namespace IHIS.INJS
{
	/// <summary>
	/// FormJusaBed에 대한 요약 설명입니다.
	/// </summary>
	public class FormJusaBed : System.Windows.Forms.Form
	{
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XPanel pnlLeft;
		private IHIS.Framework.MultiLayout layPatientList;
		private IHIS.Framework.MultiLayout layHosilList;
		private IHIS.Framework.XLabel xLabel1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;


		#region 배치 관련 변수
		const int HOCNT_PER_LINE = 6;			//한 라인의 호실수
		const int BEDCNT_PER_HOSIL = 20;    	//한 호실의 병상수
		const int LEFT_MARGIN = 5;				//병실배치 시작 left Margin
		const int TOP_MARGIN = 5;				//병실배치 시작 Top Margin
		const int HOSILBOX_GAP = 10;			//호실 사이의 간격	
		const int HOSILBOX_TOP_MARGIN = 10;		//병상배치시 호실에서 시작 Top Margin
		const int HOSILBOX_BOTTOM_MARGIN = 4;	//호실Box의 아래 Margin
		const int HOSILBOX_LEFT_MARGIN = 6;		//병상배치시에 호실Box시작위치에서 병상 시작위치 Margin
		const int BEDBOX_FULL_WIDTH = 102;		//병상의 전체기본너비
		const int BEDBOX_SMALL_WIDTH = 90;		//공병상의 기본너비
		const int BEDBOX_HEIGHT = 36;			//병상의 기본높이
		const int BEDBOX_VERT_GAP = 1;			//한 호실내에서 병상간 수직간격 
		#endregion

		#region Fields
		private string mBunho = string.Empty;
		private string mName = string.Empty;
		private Hashtable hoSilBoxList = new Hashtable();	//HoSilBox Control List 관리
        private Hashtable bedBoxList = new Hashtable();
        private SingleLayout layPatient;
        private SingleLayoutItem singleLayoutItem1;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;		//BedBox Control List관리
		private BedBox selectedBedBox = null;				//현재 선택된 BedBox
		#endregion


		public FormJusaBed(string bunho, string name)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			mBunho = bunho;
			mName  = name;
			ExecuteQuery();
		}

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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJusaBed));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnClose = new IHIS.Framework.XButton();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.layPatientList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.layHosilList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layPatient = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layPatientList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHosilList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(4, 430);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(368, 22);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(303, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 20);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.DrawBorder = true;
            this.pnlLeft.Location = new System.Drawing.Point(4, 24);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(368, 406);
            this.pnlLeft.TabIndex = 2;
            // 
            // layPatientList
            // 
            this.layPatientList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15});
            this.layPatientList.QuerySQL = resources.GetString("layPatientList.QuerySQL");
            this.layPatientList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPatientList_QueryStarting);
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "ho_code";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "ho_bed";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "bunho";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "suname";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "sex";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "br_code";
            // 
            // layHosilList
            // 
            this.layHosilList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12});
            this.layHosilList.QuerySQL = resources.GetString("layHosilList.QuerySQL");
            this.layHosilList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layHosilList_QueryStarting);
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "ho_code";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "ho_status";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "ho_total_bed";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Number;
            // 
            // xLabel1
            // 
            this.xLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xLabel1.Location = new System.Drawing.Point(4, 4);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(368, 20);
            this.xLabel1.TabIndex = 3;
            this.xLabel1.Tag = IHIS.Framework.XColor.InsertedForeColor;
            this.xLabel1.Text = "Location";
            // 
            // layPatient
            // 
            this.layPatient.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layPatient.QuerySQL = "SELECT CODE_NAME  \r\n  FROM INJ0102 \r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE" +
                "_TYPE LIKE \'BED%\' \r\n   AND CODE_NAME = :f_code_name";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "code_name";
            // 
            // FormJusaBed
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(376, 456);
            this.ControlBox = false;
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormJusaBed";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layPatientList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHosilList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		#region ExecuteQuery(병동정보 조회 처리)
		private void ExecuteQuery()
		{
			/* 선택환자 Clear
			 * Right 병동기본정보 조회
			 * 해당 병동의 병실정보 조회 -> HoSilBox, 공배드 배치 구성
			 * 해당 병동의 환자정보 조회 -> BedBox의 속성 설정
			 */

			//선택된 BedBox Clear
			this.selectedBedBox = null;

			ArrangeHoSilBox();
			SetBedBoxProperties();
		}


		/// <summary>
		/// 병동 병실정보로 HoSilBox, 기본 BedBox(공병상) 배치
		/// </summary>
		private void ArrangeHoSilBox()
		{
			// 기존 HoSilBox Clear
			foreach (Control cont in this.hoSilBoxList.Values)
				this.pnlLeft.Controls.Remove(cont);

			// 기존 BedBox Clear
			foreach (Control cont in this.bedBoxList.Values)
				this.pnlLeft.Controls.Remove(cont);
			
			//기존 Data Clear
			this.hoSilBoxList.Clear();
			this.bedBoxList.Clear();

			layHosilList.Reset();
			if (!this.layHosilList.QueryLayout(true))
			{
				XMessageBox.Show(Service.ErrFullMsg);
				this.Close() ;
			}

			//병동환자정보 조회하여 병상 Control에 값 설정
			if (!this.layPatientList.QueryLayout(true))
			{
                XMessageBox.Show(Service.ErrFullMsg);
				this.Close() ;
			}

			//해당병동의 호실수, 호실별 병상수에 따라 배치
			//한 라인에 총 6개 호실 배치, 한호실에 6개까지 병상 배치가능,
			//ICU처럼 호실 하나에 병상이 많으면 같은 호실을 두개 이상으로 나눔
			if (this.layHosilList.RowCount < 1) return ;
			
			ArrayList hosilLocationList = new ArrayList();
			HoSilLocation hLocation = null;
			string hoCode, hoStatus;
			int    hoTotalBed = 0, modifier = 0, remain = 0;
			int    startX = LEFT_MARGIN, startY = TOP_MARGIN, totalHoCount = 0;
			bool   isExceedHoCount = false;
			

			foreach (DataRow dtRow in this.layHosilList.LayoutTable.Rows)
			{

				hoCode		= dtRow["ho_code"].ToString();
				hoStatus	= dtRow["ho_status"].ToString();
				hoTotalBed = Int32.Parse(dtRow["ho_total_bed"].ToString());

				//한 병실을 몇개로 나누어 보여줄지 여부 
				modifier = (hoTotalBed == 0 ? 0 : ((hoTotalBed - 1)/BEDCNT_PER_HOSIL) + 1);
				remain   = (hoTotalBed == 0 ? 0 : (hoTotalBed%BEDCNT_PER_HOSIL == 0 ? BEDCNT_PER_HOSIL :hoTotalBed%BEDCNT_PER_HOSIL ));

				for (int i = 0 ; i < modifier ; i++)
				{
					//전체호실수는 12개이상일수 없음
					if (totalHoCount > 11)
					{
						isExceedHoCount = true; //호실 갯수 초과
						break;
					}

					hLocation = new HoSilLocation();
					hLocation.HoCode = hoCode;
					hLocation.Seq = i;
					hLocation.HoStatus = GetHoSilStatus(hoStatus);
					hLocation.X = startX;
					hLocation.Y  = startY;
					hLocation.Width = BEDBOX_FULL_WIDTH;

					if (modifier == 1)  //한개일때
					{
						hLocation.Height = HOSILBOX_TOP_MARGIN + remain*(BEDBOX_HEIGHT + BEDBOX_VERT_GAP) + HOSILBOX_BOTTOM_MARGIN;
						hLocation.BedCount = remain;  //호실의 병상수 SET
					}
					else if ( i == modifier -1)  //2개이상으로 나뉠때 마지막
					{
						hLocation.Height = HOSILBOX_TOP_MARGIN + remain*(BEDBOX_HEIGHT + BEDBOX_VERT_GAP) + HOSILBOX_BOTTOM_MARGIN;
						hLocation.BedCount = remain;  //호실의 병상수 SET
					}
					else //2개이상일때 꽉차는 호실
					{
						hLocation.Height = HOSILBOX_TOP_MARGIN + BEDCNT_PER_HOSIL*(BEDBOX_HEIGHT + BEDBOX_VERT_GAP) + HOSILBOX_BOTTOM_MARGIN;
						hLocation.BedCount = BEDCNT_PER_HOSIL;  //호실의 병상수 SET
					}
					
					//다음 시작위치는 BedBox의 너비 + HosilBox 간격
					startX += BEDBOX_FULL_WIDTH + HOSILBOX_GAP;
					//한라인을 넘었으면 startX위치 처음으로 //Y좌표의 시작위치는 한라인을 넘어선 경우에만 다시 설정
					if (totalHoCount == HOCNT_PER_LINE - 1)
					{
						startX = LEFT_MARGIN;
						//기존위치 + 6개가 꽉찬 병실의 높이 + 호실사이의 간격
						startY += HOSILBOX_TOP_MARGIN + BEDCNT_PER_HOSIL*(BEDBOX_HEIGHT + BEDBOX_VERT_GAP) + HOSILBOX_BOTTOM_MARGIN + HOSILBOX_GAP;
					}
					totalHoCount++;  //전체 호실의 갯수 증가
					
					//List에 Add
					hosilLocationList.Add(hLocation);
				}

				//호실 갯수 초과시 Break
				if (isExceedHoCount) break;
			}

			//생성된 호실정보로 호실 Control 생성
			HoSilBox hoBox = null;
			BedBox   bBox = null;
			foreach (HoSilLocation hs in hosilLocationList)
			{
				hoBox = new HoSilBox();
				hoBox.Title = hs.HoCode;
				hoBox.HStatus = hs.HoStatus;
				hoBox.Size = new Size(hs.Width, hs.Height);
				hoBox.Location = new Point(hs.X, hs.Y);
				this.pnlLeft.Controls.Add(hoBox);

				//호실Box 관리 List(Hashtable에 Add Key는 HoCode + 순번)
				this.hoSilBoxList.Add(hs.HoCode + hs.Seq.ToString(), hoBox);

				//각 호실별 병상수에 따라 기본 병상 Box SET
				for (int i = 0 ; i < hs.BedCount ; i++)
				{
					bBox = new BedBox();
					bBox.Size = new Size(BEDBOX_SMALL_WIDTH, BEDBOX_HEIGHT);  //최초 너비는 공병상너비 기준으로 설정

					//위치는 해당 병실의 HoSilBox 에 위치 (BedBox사이는 2Pixel을 띄움
					bBox.Location = new Point(hs.X + HOSILBOX_LEFT_MARGIN, hs.Y + HOSILBOX_TOP_MARGIN + (BEDBOX_HEIGHT + BEDBOX_VERT_GAP)*i);
					bBox.HoCode = hs.HoCode;  //이 병상의 병실번호 SET
					bBox.BedNumber = hs.Seq*BEDCNT_PER_HOSIL + i + 1; //병상번호 SET (같은 호실에서의 순번*한병실의 BED수 + i + 1(1번부터 시작)

					//환자명DoubleClick, Click Event Set
					bBox.SuNameDoubleClick += new EventHandler(OnBedBoxSuNameDoubleClick);
					//BedBox MouseDown,MouseMove Event Set
					bBox.MouseDown += new MouseEventHandler(OnBedBoxMouseDown);
					bBox.MouseMove += new MouseEventHandler(OnBedBoxMouseMove);

					//추가오더발생영역 DoubleClick Event Set
					//bBox.BottomLeftDoubleClick += new EventHandler(OnBedBoxBottomLeftDoubleClick);
					//MouseEnter, MouseLeave Event Handling (toolTip)
					bBox.MouseEnter += new EventHandler(OnBedBoxMouseEnter);
					bBox.MouseLeave += new EventHandler(OnBedBoxMouseLeave);

					//DragDrop 관련
					bBox.AllowDrop = true;
					bBox.DragEnter += new DragEventHandler(OnBedBoxDragEnter);
					bBox.DragDrop  += new DragEventHandler(OnBedBoxDragDrop);
					bBox.GiveFeedback += new GiveFeedbackEventHandler(OnBedBoxGiveFeedback);

					//병상리스트에 Add, Key는 hoCode + BedNumber(1부터 시작)
					this.bedBoxList.Add(hs.HoCode +  bBox.BedNumber.ToString(), bBox);
					//pnlLeft에 Controls에 Add
					pnlLeft.Controls.Add(bBox);
					bBox.BringToFront();
				}
			}
		}


		//환자정보를 조회하여 병상Box의 Property 설정
		private void SetBedBoxProperties()
		{
			//환자정보에 따라 병상 배치
			//환자정보는 호실순, 병상번호순으로 조회하여 처리함
			
			if (this.layPatientList.RowCount < 1) return;

			//조회된 환자정보를 가지고 해당 BedBox의 속성 설정
			string hoCode = "", bedNumber; 
			BedBox bBox = null;
			PatientItem pItem = null;

			// 환자가 등록되어 있는지 확인한다
			DataRow[] bunhoRows = null;
			bunhoRows = layPatientList.LayoutTable.Select("bunho = '" + mBunho +"' ");

			// 신규이면 첫번째로 set한다
			if (bunhoRows.Length <= 0)
            {
                layPatient.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                layPatient.SetBindVarValue("f_code_name", mBunho);
                this.layPatient.QueryLayout();

				if (this.layPatient.GetItemValue("code_name").ToString() == "")
				{
					if (this.bedBoxList.ContainsKey("BED0" + "1"))
					{
						bBox = (BedBox) bedBoxList["BED0" + "1"];
						bBox.Redraw = false; //그리기 중지

						//BedBox에 보여줄 이름을 한자어로 할지, 가나어로 할지는 미정(일단 한자어로 SET)
						bBox.Bunho  = mBunho;
						bBox.BedNumber = 1;
						bBox.HoCode = "BED1";
						bBox.BedStatus = BedStatus.State3;
						bBox.SuName    = mName;

				
						//Tag에 PatientItem(환자정보 Item SET)
						pItem = new PatientItem();
						pItem.Bunho  = mBunho;
						pItem.Suname = mName;
						bBox.Tag = pItem;
						bBox.Redraw = true; //다시 그림
					}
				}
			}

			if (this.bedBoxList.ContainsKey("BED0" + "2"))
			{
				bBox = (BedBox) bedBoxList["BED0" + "2"];
				bBox.Redraw = false; //그리기 중지

				//휴지통을 만든다
				bBox.Bunho  = "CLEAR";
				bBox.BedNumber = 2;
				bBox.HoCode = "BED0";
				bBox.BedStatus = BedStatus.State4;
				bBox.SuName    = "CLEAR";

				
				//Tag에 PatientItem(환자정보 Item SET)
				pItem = new PatientItem();
				pItem.Bunho  = "CLEAR";
				pItem.Suname = "CLEAR";
				bBox.Tag = pItem;
				bBox.Redraw = true; //다시 그림
			}


			foreach (DataRow dtRow in this.layPatientList.LayoutTable.Rows)
			{
				hoCode	  = dtRow["ho_code"].ToString();
				bedNumber = dtRow["ho_bed"].ToString();
			
				if (hoCode == "BED0") continue;

				//bedBoxList의 Key는 병실 + Bed번호
				if (this.bedBoxList.ContainsKey(hoCode + bedNumber))
				{
					bBox = (BedBox) bedBoxList[hoCode + bedNumber];
					bBox.Redraw = false; //그리기 중지

					//BedBox에 보여줄 이름을 한자어로 할지, 가나어로 할지는 미정(일단 한자어로 SET)
					bBox.Bunho  = dtRow["bunho"].ToString();
					bBox.BedNumber = int.Parse(dtRow["ho_bed"].ToString());
					bBox.HoCode = hoCode;
				
					if (TypeCheck.IsNull(dtRow["suname"]))
					{
						bBox.BedStatus = BedStatus.State1;
					}
					else
					{
						bBox.BedStatus = BedStatus.State3;
						bBox.SuName = dtRow["suname"].ToString();		
					}
					
					//Tag에 PatientItem(환자정보 Item SET)
					pItem = new PatientItem();
					pItem.Bunho  = dtRow["bunho"].ToString();
					pItem.Suname = dtRow["bunho"].ToString();
					bBox.Tag = pItem;
					bBox.Redraw = true; //다시 그림
				}
			}
		}
	
		#endregion

		#region Data -> Enum으로 변경
		//호실의 성격(현재는 1.일반실, 2.특실로만 처리함)
		private HoSilStatus GetHoSilStatus(string hoStatus)
		{
			HoSilStatus hStatus = HoSilStatus.State1;
			switch (hoStatus)
			{
				case "2":
					hStatus = HoSilStatus.State2;
					break;
				case "3":
					hStatus = HoSilStatus.State3;
					break;
			}
			return hStatus;
		}


		//병상의 성격 (환자성격에 따라 구분)
		//private BedStatus GetBedStatus(string brCode)
		private BedStatus GetBedStatus(string life_self_grade)
		{
			//02.거동불가 State4, 03.호송환자 State3, 그외는 State2
			//J 거동불가, A 준거동, B,C 거동가능
			BedStatus status = BedStatus.State2;  //거동가능환자
			switch (life_self_grade)
			{
				case "A":
					status = BedStatus.State3;
					break;
				case "J":
					status = BedStatus.State4;
					break;
			}
			return status;
		}
		#endregion

		#region BedBox EventHandler
		private bool canDrag = false;
		private int  dragPointX = 0;
		private int  dragPointY = 0;
		private Font dragFont = new Font("MS UI Gothic", 10.0f);
		private void OnBedBoxMouseDown(object sender, MouseEventArgs e)
		{
			//Left Click이고 BedBox의 병상상태가 환자가 있으면(Status1이 아니면)
			BedBox bBox = (BedBox) sender;
			//if ((e.Button == MouseButtons.Left) && (bBox.BedStatus != BedStatus.State1))			
			if (bBox.BedStatus != BedStatus.State1)
			{
				//기존 선택된 Box 선택상태 변경
				if (this.selectedBedBox != null)
					this.selectedBedBox.Selected = false;
				//선택된 BedBox를 SET
				this.selectedBedBox = (BedBox) sender;
				this.selectedBedBox.Selected = true; //선택상태 변경

				//Drag관련 변수 SET
				canDrag = true;
				dragPointX = e.X;
				dragPointY = e.Y;
			}
		}
		private void OnBedBoxMouseMove(object sender, MouseEventArgs e)
		{
			BedBox bBox = (BedBox) sender;
			//Left인 상태에서 Move시
			if ((e.Button == MouseButtons.Left) && (bBox.BedStatus != BedStatus.State1) && canDrag && (Math.Abs(e.X - dragPointX) > 3 || Math.Abs(e.Y - dragPointY) > 3))
			{
				canDrag = false;
				//코드로 DragCursor Create
				DragHelper.CreateDragCursor(bBox, bBox.SuName, dragFont);
				bBox.DoDragDrop(bBox , DragDropEffects.Move);
			}
		}
		private void OnBedBoxDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			//BedBox Drag시 Drag상태 유지
			if (e.Data.GetDataPresent(typeof(IHIS.INJS.BedBox)))
			{
				e.Effect = DragDropEffects.Move;
			}
		}

		private void OnBedBoxGiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}
		}
		private void OnBedBoxDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			try
			{
				//DragDrop시에 
				BedBox dragBed = null;
				if (e.Data.GetDataPresent(typeof(IHIS.INJS.BedBox)))
					dragBed = e.Data.GetData(typeof(IHIS.INJS.BedBox)) as BedBox;

				if (dragBed == null) return;

				BedBox dropBed = (BedBox) sender;

				//동일한 병실,병상이면 Return
				if ((dragBed.HoCode == dropBed.HoCode) && (dragBed.BedNumber == dropBed.BedNumber)) return;

				string title = (NetInfo.Language == LangMode.Ko ? "이동확인" : "移動確認");
				//string msg = "";

				//DropBed가 공상이 아니면 불가
//				if (dropBed.BedStatus != BedStatus.State1)
//				{
//					msg = (NetInfo.Language == LangMode.Ko ? "공병상으로만 이동가능합니다." 
//						: "空ベットではありません。");
//					XMessageBox.Show(msg, title);
//					return;
//				}
//
//				//성별이 다른 호실로는 이동불가(이동할 호실에 있는 Bed의 성별확인)
//				//DropBed의 호실과 동일한 호실의 첫번째 환자 Find
//				BedBox preBedBox = null;
//				foreach (BedBox bBox in this.bedBoxList.Values)
//				{
//					//같은 호실에 공상이 아닌 첫번째 Bed FInd
//					if ((bBox.HoCode == dropBed.HoCode) && (bBox.BedStatus != BedStatus.State1))
//					{
//						preBedBox = bBox;
//						break;
//					}
//				}
//				if (preBedBox != null)
//				{
//					if (preBedBox.SexKind != dragBed.SexKind)
//					{
//						msg = (NetInfo.Language == LangMode.Ko ? (dragBed.SexKind == HumanSex.Man ? "남성환자를 여성병실로 이동할 수 없습니다." : "여성환자를 남성병실로 이동할 수 없습니다.")
//							: (dragBed.SexKind == HumanSex.Man ? "男性患者さんは女性病室に移動できません。" : "女性患者さんは男性病室に移動できません。"));
//						XMessageBox.Show(msg, title);
//						return;
//					}
//				}

                /*
				this.dsvMoveHosil.SetInValue("bunho"  , dragBed.Bunho);
				this.dsvMoveHosil.SetInValue("ho_code", dropBed.HoCode); //(dropBed.Bunho == "CLEAR" ? dropBed.HoCode:dragBed.HoCode));		
				this.dsvMoveHosil.SetInValue("bed_no" , dropBed.BedNumber);

				//전과,전실 성공시 다시 Refresh (전과전실 업무 확정후 반영하기, 일단 TEST로 변경해봄)
				if (dsvMoveHosil.Call())
				{

				}
                 * */

				//DragBed와 DrapBed 위치 변경
				dragBed.Redraw = false;
				dropBed.Redraw = false;

				dropBed.SuName		= dragBed.SuName;
				dropBed.SexKind		= dragBed.SexKind;
				dropBed.BedStatus	= dragBed.BedStatus;
				dropBed.RTStatus	= dragBed.RTStatus;
				dropBed.RBStatus	= dragBed.RBStatus;
				dropBed.BLStatus	= dragBed.BLStatus;
				dropBed.BRStatus	= dragBed.BRStatus;
				dropBed.Tag			= dragBed.Tag;

				//DragBed Clear
				dragBed.SuName = "";
				dragBed.BedStatus	= BedStatus.State1;
				dragBed.RTStatus	= RightTopStatus.State1;
				dragBed.RBStatus	= RightBottomStatus.State1;
				dragBed.BLStatus	= BottomLeftStatus.State1;
				dragBed.BRStatus	= BottomRightStatus.State1;
				dragBed.Tag = null;

				//Select Clear
				dragBed.Selected = false;
				dropBed.Selected = true;
				dragBed.Redraw = true;
				dropBed.Redraw = true;

				//선택된 Bed 설정
				this.selectedBedBox = dropBed;
				//				}
			}
			catch (Exception xe)
			{
				Debug.WriteLine("OnBedBoxDragDrop Error=" + xe.Message);
			}
		}

		private void OnBedBoxSuNameDoubleClick(object sender, EventArgs e)
		{
			//이름 Double Click시에 환자상세 정보내역 조회(확정필요)
			BedBox bBox = (BedBox) sender;
		}
		private void OnBedBoxBottomLeftDoubleClick(object sender, EventArgs e)
		{
			//추가Order발생 역역 Click시에 간호확인 화면 Open(확정필요)
			BedBox bBox = (BedBox) sender;
		}
		private void OnBedBoxMouseEnter(object sender, EventArgs e)
		{
			//MouseEnter시에 환자정보 ToolTop Display(세부내역은 확정필요)
			BedBox bBox = (BedBox) sender;
			//공상이 아니면 ToolTip Set
			if (bBox.BedStatus == BedStatus.State1) //공상
			{
				//this.toolTip1.SetToolTip(bBox, "");
				//this.toolTip1.Active = false;
			}
			else
			{
				string text = "";
				//Tag에 저장된 PatientItem에서 정보 Get
				PatientItem pItem = (PatientItem) bBox.Tag;
				if (pItem.Bunho != "")
					text += "患者番号 : " + pItem.Bunho + "\n";

				/*
				if (pItem.BirthDate != "")
					text += "生年月日 : " + pItem.BirthDate + " (" + pItem.SexAge + ")" + "\n";
				if (pItem.IpwonDate != "")
					text += "入院日 : " + pItem.IpwonDate + " (" + pItem.JaewonNalsu + "日)" + "\n";
				if (pItem.GwaName != "")
					text += "診療科 : " + pItem.GwaName + "\n";
				if (pItem.DoctorName != "")
					text += "主治医 : " + pItem.DoctorName + "\n";
				if (pItem.ResidentName != "")
					text += "担当医 : " + pItem.ResidentName + "\n";
				if (pItem.NurseName != "")
					text += "担当看護婦 :" + pItem.NurseName + "\n";
				if (pItem.SangName != "")
					text += "疾病名 : " + pItem.SangName + "\n";
				*/

				if (text != "")
					text = text.Substring(0, text.Length - 1); //마지막 NL 제거

				//				this.toolTip1.Active = true;
				//				this.toolTip1.SetToolTip(bBox, text);
			}
		}
		private void OnBedBoxMouseLeave(object sender, EventArgs e)
		{
			BedBox bBox = (BedBox) sender;
			//ToolTip Clear
			//this.toolTip1.SetToolTip(bBox, "");
			//this.toolTip1.Active = false;
		}

		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
		
		}

		#region HoSilLocation(호실박스의 위치관리 class)
		private class HoSilLocation
		{
			public string HoCode;
			public int    Seq = 0 ;       //같은 호실을 가지는 호실Box의 순번
			public HoSilStatus HoStatus = HoSilStatus.State1;
			public int    BedCount = 0;  //호실의 병상수
			public int	  X = 0;         //X
			public int    Y  = 0;        //Y
			public int    Width = 0;     //W
			public int    Height = 0;

		}
		#endregion

		#region PatientItem 환자정보 관리 Class
		private class PatientItem
		{
			public string Bunho = "";
			public string Suname = "";    //한자명
		}
		#endregion

        private void layHosilList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layHosilList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPatientList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }


	}

}
