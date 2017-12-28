using System;
using System.Net;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;

namespace IHIS.NURI
{
	#region HoSilBox (병실을 Display하는 PictureBox
	/// <summary>
	/// HoSilBox에 대한 요약 설명입니다.
	/// </summary>
	internal class HoSilBox : System.Windows.Forms.PictureBox
	{
		#region 그리기 관련 Fields
		const int BORDER_MARGIN = 3;
		const int TITLE_HEIGHT = 24;
		private Font titleFont = new Font("MS UI Gothic", 12.0f, FontStyle.Bold);
		private SolidBrush borderStatus1Brush = new SolidBrush(Color.FromArgb(160,197,216));
		private SolidBrush borderStatus2Brush = new SolidBrush(Color.FromArgb(196,217,161));
		private SolidBrush backStatus1Brush = new SolidBrush(Color.FromArgb(50,127,207));
		private SolidBrush backStatus2Brush = new SolidBrush(Color.FromArgb(53,156,39));
		private Pen        borderPen   = new Pen(Color.FromArgb(157,174,130));
		private Pen        whitePen   = new Pen(Color.White);
		private Brush	   textBrush  = new SolidBrush(Color.Black);
		private SolidBrush borderHcuBrush   = new SolidBrush(Color.Tomato);                     //HCU  빨강
		private SolidBrush borderEastBrush  = new SolidBrush(Color.LightBlue);                  //동   파랑
		private SolidBrush borderWestBrush  = new SolidBrush(Color.LightGreen);                 //서   녹색
		private SolidBrush borderSouthBrush = new SolidBrush(Color.LightPink);                  //남   핑크
		private SolidBrush borderNorthBrush = new SolidBrush(Color.LightGoldenrodYellow);       //북   노랑
		private SolidBrush borderOldBrush  = new SolidBrush(Color.LightCoral);                  //신관, 구관
		private SolidBrush borderGitaBrush  = new SolidBrush(Color.Silver);                     //기타 실버

        private SolidBrush borderManBrush = new SolidBrush(Color.LightBlue);                  //남자병실
        private SolidBrush borderWomanBrush = new SolidBrush(Color.LightPink);                  //여자병실
        private SolidBrush borderTotalBrush = new SolidBrush(Color.LightGreen);                 //공용병실
		#endregion

		#region Fields having Property
		private string title = "";
		private HoSilStatus hStatus = HoSilStatus.General;
		private WingGubun wingGubun = WingGubun.State1;
        private string hSex = "";
		#endregion

		#region base Property
		[Browsable(false),
		DefaultValue(typeof(Color),"Transparent")]
		public new Color BackColor
		{
			get { return base.BackColor;}
			set { base.BackColor = value;}
		}
		#endregion

		#region Properties
		[DefaultValue(""),Category("추가속성"),
		Description("호실의 Title을 설정합니다.")]
		public string Title
		{
			get { return title;}
			set 
			{
				if (title != value)
				{
					title = value;
					Invalidate(true);
				}
			}
		}
		[DefaultValue(HoSilStatus.General),Category("추가속성"),
		Description("호실의 상태를 설정합니다.")]
		public HoSilStatus HStatus
		{
			get { return hStatus;}
			set 
			{
				if (hStatus != value)
				{
					hStatus = value;
					Invalidate(true);
				}
			}
		}

		[DefaultValue(""),Category("추가속성"),
		Description("윙구분의 상태를 설정합니다.")]
		public string HSex
		{
			get { return hSex;}
			set 
			{
				if (hSex != value)
				{
					hSex = value;
					Invalidate(true);
				}
			}
		}

        [DefaultValue(WingGubun.State1), Category("추가속성"),
        Description("윙구분의 상태를 설정합니다.")]
        public WingGubun WingGubun
        {
            get { return wingGubun; }
            set
            {
                if (wingGubun != value)
                {
                    wingGubun = value;
                    Invalidate(true);
                }
            }
        }
		#endregion

		//병실을 보여주는 Picture Box
		public HoSilBox()
		{
			this.BorderStyle = BorderStyle.None;
			this.BackColor = Color.Transparent;
		}

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			int width = this.Size.Width;
			int height = this.Size.Height;
			Rectangle rect = Rectangle.Empty;

			if ((width < BORDER_MARGIN) || (height < TITLE_HEIGHT)) return;

			try
			{
				Brush borderBrush, backBrush;
				//호실상태에 따라 Brush 선택
				borderBrush = borderStatus1Brush;
				backBrush   = backStatus1Brush;
				switch (hStatus)
				{
					case HoSilStatus.Special:
						borderBrush = borderStatus2Brush;
						backBrush   = backStatus2Brush;
						break;
					case HoSilStatus.Other:
						borderBrush = borderStatus2Brush;
						backBrush   = backStatus2Brush;
						break;
				}

				//윙구분에 따라 색깔을 변경
				switch(wingGubun)
				{
                    //case WingGubun.General: //HCU
                    //    borderBrush = borderHcuBrush;
                    //    backBrush = borderHcuBrush;
                    //    break;
                    //case WingGubun.Special: //동
                    //    borderBrush = borderEastBrush;
                    //    backBrush = borderEastBrush;
                    //    break;
                    //case WingGubun.Other: //서
                    //    borderBrush = borderWestBrush;
                    //    backBrush = borderWestBrush;
                    //    break;
                    //case WingGubun.State4: //남
                    //    borderBrush = borderSouthBrush;
                    //    backBrush = borderSouthBrush;
                    //    break;
                    //case WingGubun.State5: //북
                    //    borderBrush = borderNorthBrush;
                    //    backBrush = borderNorthBrush;
                    //    break;
                    //case WingGubun.State6: //기타
                    //    borderBrush = borderGitaBrush;
                    //    backBrush = borderGitaBrush;
                    //    break;
                    //case WingGubun.State7: //신관, 구관
                    //    borderBrush = borderOldBrush;
                    //    backBrush = borderOldBrush;
                    //    break;
                    default:
                        //borderBrush = borderEastBrush; //LightBlue
                        //backBrush = borderEastBrush;

                        //borderBrush = borderWestBrush;   //LightGreen
                        //backBrush = borderWestBrush;

                        /*
                        borderBrush = borderSouthBrush;  //LightPink
                        backBrush = borderSouthBrush;
                         * */

                        if (hSex == "M")
                        {
                            borderBrush = borderManBrush;  //LightBlue
                            backBrush = borderManBrush;
                        }
                        else if (hSex == "F")
                        {
                            borderBrush = borderWomanBrush;  //LightPink
                            backBrush = borderWomanBrush;
                        }
                        else
                        {
                            borderBrush = borderTotalBrush;  //LightGreen
                            backBrush = borderTotalBrush;                        
                        }


                        //borderBrush = borderNorthBrush; //LightGoldenrodYellow
                        //backBrush = borderNorthBrush;

                        //borderBrush = borderGitaBrush; //LightCoral
                        //backBrush = borderGitaBrush;

                        //borderBrush = borderOldBrush; //Silver
                        //backBrush = borderOldBrush;

                        break;
				}
				//Border Draw
				rect = new Rectangle(0,0, width, height);
				e.Graphics.FillRectangle(borderBrush, rect);

				//안쪽 Line Draw, Gray
				rect = new Rectangle(BORDER_MARGIN, BORDER_MARGIN, width - BORDER_MARGIN*2 -1 , height - BORDER_MARGIN*2);
				e.Graphics.DrawRectangle(borderPen, rect);
				//안쪽 Line Whiete Draw
				rect = new Rectangle(BORDER_MARGIN + 1, BORDER_MARGIN + 1, width - (BORDER_MARGIN + 1)*2 -1 , height - (BORDER_MARGIN + 1)*2);
				e.Graphics.DrawRectangle(whitePen, rect);
				//Back Draw
				rect = new Rectangle(BORDER_MARGIN + 2, BORDER_MARGIN + 2, width - (BORDER_MARGIN + 2)*2 -1 , height - (BORDER_MARGIN + 2)*2);
				e.Graphics.FillRectangle(backBrush, rect);

				//Title Draw
				if (title != "")
				{
					rect = new Rectangle( BORDER_MARGIN + 2 , BORDER_MARGIN + 2, width - (BORDER_MARGIN + 2)*2 , TITLE_HEIGHT);
					SizeF fontSize = e.Graphics.MeasureString(title, titleFont);
					e.Graphics.DrawString(title, titleFont, textBrush, 
						DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.X, rect.Y, rect.Width, rect.Height, fontSize.Width, fontSize.Height));
				}
			}
			catch(Exception xe)
			{
				Debug.WriteLine("HosilBox::OnPaint error=" + xe.Message);
			}
		}
		#endregion
	}
	#endregion

	#region enum
	/// <summary>
	/// 호실의 성격을 나타내는 Enum(현재는 일반실, 특실밖에 없음)
	/// </summary>
	internal enum HoSilStatus
	{
		General,  //일반실
		Special,  //특실
		Other   //기타
	}
	#endregion

	#region enum
	/// <summary>
	/// 윙구분을 나타내는 Enum(HCU, 동, 서, 남, 북)
	/// </summary>
	internal enum WingGubun
	{
        State1,  //HCU
        State2,  //동
        State3,  //서
        State4,  //남
        State5,  //북
        State6,  //기타
        State7   //신관, 구관

        //General,  //5층
        //Special,  //6층
        //Other,  //7층
	}
	#endregion
}
