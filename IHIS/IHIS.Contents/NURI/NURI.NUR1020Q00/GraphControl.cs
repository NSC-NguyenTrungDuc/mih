#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// GraphControl에 대한 요약 설명입니다.
	/// </summary>
	internal class GraphControl : System.Windows.Forms.Panel, System.ComponentModel.ISupportInitialize
	{
		#region Constant Fields
        const string IMAGE_PATH = "IHIS.NURI.Images.";
        //const int PIXEL_WIDTH = 120;
        const int PIXEL_WIDTH =138;
		const int BOX_HEIGHT = 18;
        const int BASE_HEIGHT_MARGIN = 8;
        const int TEXT_HEIGHT = 11;
		const int GRAPH_ITEM_HEIGHT = 25;
		
		/*
		const int GRAPH_HEADER_DEVIDE_UNIT = 5; //Graph 영역의 Header의 나누기 갯수
		const int GRAPH_ITEM_DEVIDE_UNIT = 5;  //Graph 영역의 ITem의 나누기 갯수
		*/
            
		// 20110412 - Add Start			
		const int GRAPH_HEADER_DEVIDE_UNIT = 4; //Graph 영역의 Header의 나누기 갯수
		const int GRAPH_ITEM_DEVIDE_UNIT = 6;  //Graph 영역의 ITem의 나누기 갯수
        // 20110412 - Add End
		
		const int DISPLAY_DAY_COUNT = 7;       //Dispay할 총날짜수
        //const int AREA_DIVIDE_THREE = 3;       //7002 영역 분할 Count ETC1
		//const int AREA_DIVIDE_THREE = 3;       //식사 영역 분할 Count
        const int AREA_DIVIDE_THREE = 3;      //관찰항목 영역 분할 Count
		const int AREA_DIVIDE_TWO = 2;      //IN,OUT 영역 분할 Count
		//private int INOUT_KIND_COUNT = 5;        //IN,OUT 의 종류 (IN, OUT header 포함 5개), 2006.02.16 IN,OUT종류는 고정되지 않고 설정됨

        //2012.01.23 woo 
        private int mHangmog_count = 1;  //일단 1개로할당.

		#endregion

		#region Fields
		private bool reDraw = true; //그리기 여부

        //領域管理
		private Rectangle graphColHeaderRect = Rectangle.Empty;  //Graph의 ColHeader 영역
		private Rectangle graphRowHeaderRect = Rectangle.Empty;  //Graph의 RowHeader 영역
		private Rectangle graphRect = Rectangle.Empty;  //Graph의 Item 영역
        private Rectangle etc1Rect = Rectangle.Empty;  //酸素、SPO2、BS、処置領域 ETC1
        private Rectangle etc2Rect = Rectangle.Empty;  //便、尿、身長、体重領域 ETC2
        private Rectangle etc3Rect = Rectangle.Empty;  //ケア領域 ETC3
		private Rectangle foodRect = Rectangle.Empty;  //식사 영역
		private Rectangle inOutRect = Rectangle.Empty;  //In Out 영역
		private Rectangle inOutTotalRect = Rectangle.Empty;  //In Out Total 영역
        //2012.01.20 woo
        private Rectangle nur1122Rect = Rectangle.Empty;    //NUR1122의 아이템 값 영역
        private Rectangle nur1122ItemRect = Rectangle.Empty; //NUR1122의 아이템 영역

        private int graphEnd = 0;                            //그래프의 끝 영역
        private int currYPos = 0;                            //현재의 Y최대치 

		//ItemInfo 관리 리스트		
        private ArrayList etc1HeaderItemList = new ArrayList();     //NUR7002 헤더 리스트(酸素、SPO2、処置) ETC1
        private Hashtable etc1ItemList = new Hashtable();     //NUR7002 데이타 리스트(酸素、SPO2、処置) ETC1
        private ArrayList etc2HeaderItemList = new ArrayList();     //NUR7002 헤더 리스트(便、尿、身長) ETC2
        private Hashtable etc2ItemList = new Hashtable();     //NUR7002 데이타 리스트(便、尿、身長) ETC2
        private ArrayList etc3HeaderItemList = new ArrayList();     //NUR7002 헤더 리스트(케어) ETC3
        private Hashtable etc3ItemList = new Hashtable();     //NUR7002 데이타 리스트(케어) ETC3
        private ArrayList foodHeaderItemList = new ArrayList();  //Food rowHelader 항목
        private Hashtable foodItemList = new Hashtable();   //Food 영역 데이타 식 List
		private Hashtable inoutItemList = new Hashtable();     //InOut 영역 데이타 리스트
		private ArrayList rowHeaderItemList = new ArrayList();  //RowHeader의 Item 영역 List
		private ArrayList inoutHeaderItemList = new ArrayList();  //InOut의 Header의 Item 영역 관리 LIST
		private Hashtable inoutTotalItemList = new Hashtable();  //InOut의 Total의 Item 영역 관리 LIST
		private Hashtable colHeaderItemList = new Hashtable();  //ColHeader 영역의 Item List (key로 Level(0,1,2,), value는 ItemInfo를 가지는 ArrayList
		//2012.01.20 woo
        private ArrayList nur1122HeaderList = new ArrayList();      //NUR1122의 Column Header
        private Hashtable nur1122ItemList = new Hashtable();        // 환자별 nur1122의 항목별 데이터 리스트
        private ArrayList nur1122HeaderItemList = new ArrayList();  //환자별 nur1122의 항목
		//식사구분 일본어 이름 관리
		private Hashtable siksaNameList = new Hashtable();

		//P(맥박),(BPH,BPL) 혈압,T(체온), SPO2(산소 포화도), R(호흡수), BS(혈당) 좌표관리 리스트
		private ArrayList PPointList = new ArrayList();
		private ArrayList BPHPointList = new ArrayList();
		private ArrayList BPLPointList = new ArrayList();
		private ArrayList TPointList = new ArrayList();
		//private ArrayList Spo2PointList = new ArrayList();
		private ArrayList RPointList = new ArrayList();			// 20070412 Add Line
        //private ArrayList BSPointList = new ArrayList();		// 20110412 Add Line
		//Image
		private Image pImage = null;  //P Image
		private Image bphImage = null;  //BPH Image
		private Image bplImage = null;  //BPL Image
		private Image tImage   = null;  // T Image
		private Image bpImage  = null;  //BPH + BPL Image
        private Image susulImage = null; //수술이미지
		//private Image spo2Image = null; //Spo2이미지
        private Image rImage = null;	// r Image
        //private Image bsImage = null;	// 혈당 Image

		//Pen관리
		
        //internal Pen BPHPen = new Pen(Color.Orange, 1.5f);

        //internal Pen BPLPen = new Pen(Color.Violet, 1.8f); 
        //internal Pen BPHPen = new Pen(Color.Violet, 1.8f);
        //internal Pen RPen = new Pen(Color.DarkGreen, 1.8f);

        internal Pen PPen = new Pen(Color.Red, 1.8f);
        internal Pen BPLPen = new Pen(Color.Black, 1.8f);  //색상 변경 Violet -> Black 20130314
        internal Pen BPHPen = new Pen(Color.Black, 1.8f);  //색상 변경 Violet -> Black 20130314
        internal Pen TPen = new Pen(Color.Blue, 1.8f);
        internal Pen Spo2Pen = new Pen(Color.Black, 1.8f);
        internal Pen RPen = new Pen(Color.Black, 1.8f);	        // 20070412 Add Line -> 색상 변경 DarkGreen -> Black 20130314
        internal Pen BSPen = new Pen(Color.Black, 1.8f);    // 20110412 Add Line -> 삭제 20130314

		//2006.02.16 IO Type의 List를 관리 List(IN, OUT이 기준정보에 의해 관리됨)
		private ArrayList inTypeItemList = new ArrayList();
		private ArrayList outTypeItemList = new ArrayList();
		private MultiLayout layMIO = new MultiLayout();  //IN,OUT 기준정보 조회 서비스, layout

		//Print 관련
		private PrintDocument printDoc = new PrintDocument();
		private string headerText = "";
		private Font headerTextFont = new Font("MS UI Gothic", 12.0f);
		private StringFormat textFormat = new StringFormat();

        //2012.01.17 woo
        private ArrayList pValueList = new ArrayList();
        private ArrayList bplValueList = new ArrayList();
        private ArrayList bphValueList = new ArrayList();
        private ArrayList tValueList = new ArrayList();
        //private ArrayList spo2ValueList = new ArrayList();
        private ArrayList rValueList = new ArrayList();
        //private ArrayList bsValueList = new ArrayList();

		#endregion

		#region 속성
		public bool ReDraw
		{
			get { return reDraw;}
			set 
			{ 
				if (reDraw != value)
				{
					reDraw = value;
					if (value)
						Invalidate(true);
				}
			}
		}
		#endregion

		#region 생성자
		public GraphControl()
		{
			//Resource에서 Image Get
			//이미지 가져오기
			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			
			Bitmap bmp = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "TImage.png"));
			//bmp.MakeTransparent();
			this.tImage = bmp;
            bmp = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "PRImage.png"));
			//bmp.MakeTransparent();
			this.pImage = bmp;
            bmp = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "BPLImage.png"));
			//bmp.MakeTransparent();
			this.bplImage = bmp;
            bmp = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "BPHImage.png"));
			//bmp.MakeTransparent();
			this.bphImage = bmp;
            bmp = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "BPImage.png"));
			//bmp.MakeTransparent();
			this.bpImage = bmp;
			bmp = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "susu.ico"));
			bmp.MakeTransparent();
			this.susulImage = bmp;
            //bmp = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Spo2Image.png"));
			//bmp.MakeTransparent();
			//this.spo2Image = bmp;
			// 20070412 - Add Start
            bmp = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "RImage.png"));
			//bmp.MakeTransparent();
			this.rImage = bmp;
			// 20070412 - Add End

            //// 20110412 - Add Start
            //bmp = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "BSImage.png"));
            ////bmp.MakeTransparent();
            //this.bsImage = bmp;
            //// 20110412 - Add End

			//BP이미지는 나중에 추가후 설정, 일단은 bpH Image로
			//this.bpImage = this.bphImage;


			//식사구분명(0.禁食, 1.特式, 2.一般式, 3.小児式, 4.治療式, 5.その他(治療式), 6.官給式, 7.検事式)
            //siksaNameList.Add("0", "禁食");
            //siksaNameList.Add("1", "特食");
            //siksaNameList.Add("2", "一般食");
            //siksaNameList.Add("3", "小児食");
            //siksaNameList.Add("4", "治療食");
            //siksaNameList.Add("5", "その他");
            //siksaNameList.Add("6", "官給食");
            //siksaNameList.Add("7", "検事食");

			//IN,OUT 기준정보 조회 Service 속성 Set
//            layMIO.LayoutItems.Add("io_gubun", DataType.String);
//            layMIO.LayoutItems.Add("io_type", DataType.String);
//            layMIO.LayoutItems.Add("io_type_name", DataType.String);
//            layMIO.InitializeLayoutTable();

//            layMIO.QuerySQL = @"SELECT 'I'       IO_GUBUN
//                                      ,CODE      IO_TYPE
//                                      ,CODE_NAME IO_TYPE_NAME
//                                      ,SORT_KEY  SORT_KEY
//                                  FROM NUR0102
//                                 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
//                                   AND CODE_TYPE = 'VSPATN_IN'
//
//                                 UNION ALL
//
//                                SELECT 'O'       IO_GUBUN
//                                      ,CODE      IO_TYPE
//                                      ,CODE_NAME IO_TYPE_NAME
//                                      ,SORT_KEY  SORT_KEY
//                                  FROM NUR0102
//                                 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
//                                   AND CODE_TYPE = 'VSPATN_OUT'
//                                 ORDER BY 1, 4, 2 ";


            
			//Print 관련
			printDoc.DefaultPageSettings.Landscape = true; //가로로 인쇄
			printDoc.PrintPage += new PrintPageEventHandler(OnPrintDocPrintPage);
			this.textFormat.LineAlignment = StringAlignment.Center;
			this.textFormat.Alignment = StringAlignment.Far;

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
		/// 초기화 종료시 컬럼을 초기화(InitializeColumns)합니다.
		/// </summary>
		void ISupportInitialize.EndInit()
		{
			//RunTime시 조회하여 DataSet (DesignMode에서는 조회하지 않음)
            //if (!this.DesignMode)
            //    layMIO.QueryLayout(true);

			//Layout Setup
			DoLayout(DateTime.Today, layMIO.LayoutTable);
		}
		#endregion

        #region 그래프 초기화
        public void InitGraph()
        {
            Control cnt = null;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                cnt = this.Controls[i];

                if (cnt.GetType().Name.ToString().IndexOf("PictureBox") >= 0)
                {
                    cnt.Dispose();
                    i--;
                }
            }

            currYPos = graphEnd;

            //rowHeaderItemList.Clear();

        }

        #endregion 

        #region DoLayout (좌표영역 정의)
        public void DoLayout(DateTime date, DataTable ioTypeTable)
		{
			//List Clear
			foodItemList.Clear();
			inoutItemList.Clear();
			rowHeaderItemList.Clear();
			inoutHeaderItemList.Clear();
			inoutTotalItemList.Clear();
			colHeaderItemList.Clear();
			inTypeItemList.Clear();
			outTypeItemList.Clear();

		
			int xPos = 0, yPos = 0;
			//RowHeader 영역 ItemInfo 정의
			ItemInfo childInfo = null;
			//첫번째줄
			ItemInfo info = new ItemInfo("");
			info.Rect = new Rectangle(xPos, yPos, PIXEL_WIDTH, BOX_HEIGHT);
			rowHeaderItemList.Add(info);
			yPos += BOX_HEIGHT;

			//두번째줄
			info = new ItemInfo("");
			info.Rect = new Rectangle(xPos, yPos, PIXEL_WIDTH, BOX_HEIGHT);
			rowHeaderItemList.Add(info);
			yPos += BOX_HEIGHT;

			//세번째줄 그래프 항목 정의 (Child가 5개 (P, BP, T, R, SPO2)) 
			info = new ItemInfo("");
			//BS
            //childInfo = new ItemInfo("BS", ContentAlignment.TopCenter, bsImage, ContentAlignment.BottomCenter,
            //    new Rectangle(xPos, yPos, PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
            //childInfo.TextColor = Color.LimeGreen;
            //info.Childs.Add(childInfo);
            //xPos += PIXEL_WIDTH/GRAPH_HEADER_DEVIDE_UNIT;

			//BP
			childInfo = new ItemInfo("BP", ContentAlignment.TopCenter, bpImage, ContentAlignment.BottomCenter, 
				new Rectangle(xPos, yPos, PIXEL_WIDTH/GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
			//childInfo.TextColor = Color.Violet;  //Color Violet
            childInfo.TextColor = Color.Black;  //--> 색상 변경 20130314
			info.Childs.Add(childInfo);
			xPos += PIXEL_WIDTH/GRAPH_HEADER_DEVIDE_UNIT;
			
			//Spo2
            //childInfo = new ItemInfo("SPO2", ContentAlignment.TopCenter, spo2Image, ContentAlignment.BottomCenter, 
            //    new Rectangle(xPos, yPos, PIXEL_WIDTH/GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
            //childInfo.TextColor = Color.Black;  //Color Black
            //info.Childs.Add(childInfo);
            //xPos += PIXEL_WIDTH/GRAPH_HEADER_DEVIDE_UNIT;
			
			//R 20070412 - Add Start, 2012.01.24 W->R
			childInfo = new ItemInfo("R", ContentAlignment.TopCenter, rImage, ContentAlignment.BottomCenter,
				new Rectangle(xPos, yPos, PIXEL_WIDTH/GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
			//childInfo.TextColor = Color.DarkGreen; 
            childInfo.TextColor = Color.Black;  //--> 색상 변경 20130314
			info.Childs.Add(childInfo);
			xPos += PIXEL_WIDTH/GRAPH_HEADER_DEVIDE_UNIT;
			// 20070412 - Add End

            //P
            childInfo = new ItemInfo("P", ContentAlignment.TopCenter, pImage, ContentAlignment.BottomCenter,
                new Rectangle(xPos, yPos, PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
            childInfo.TextColor = Color.Red;
            info.Childs.Add(childInfo);
            xPos += PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT;

            //T
            childInfo = new ItemInfo("T", ContentAlignment.TopCenter, tImage, ContentAlignment.BottomCenter,
                new Rectangle(xPos, yPos, PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
            childInfo.TextColor = Color.Blue;  //Color Blue
            info.Childs.Add(childInfo);
            //xPos += PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT;
            
			
			rowHeaderItemList.Add(info);
			//xPos Reset, yPos 증가
			xPos = 0;
			yPos += GRAPH_ITEM_HEIGHT;

            int startT = (int)MAX_T;
            int startP = MAX_P;
            int startR = MAX_R;	// 20070412 - Add Line  2012.01.24 startW -> startR
            //int startSpo2 = MAX_SPO2;
            int startBP = MAX_BP;
            
            //int startBS = MAX_BS;	// 20110412 - Add Line
            //int startP = 240, startT = 41, startSpo2 = 110;    //2012.01.18 startP 200 을 220으로 woo
            //int startR = 900;	// 20070412 - Add Line  2012.01.24 startW -> startR
            //int startBS = 310;	// 20110412 - Add Line


            // 각 항목들의 Y축 생성
			for (int i = 0; i < STEPS ; i++)
			{
				//P,BP는 180-> 20단위로 줄어듬, T : 40-> 1단위로 줄어듬
                //startP -= 20;
                //startT  -= 1;
                //startSpo2 -= 10;
                //startR -= 100; // 20070412 - Add Line 
                //startBS -= 30; // 20110412 - Add Line

                startT -= intervalT;
                startP -= intervalP;
                startR -= intervalR;
                //startSpo2 -= intervalSpo2;
                startBP -= intervalBP;
                //startBS -= intervalBS;

				info = new ItemInfo("");

                //BS 280
                //childInfo = new ItemInfo(startBS.ToString(), ContentAlignment.BottomCenter, null, ContentAlignment.BottomCenter,
                //    new Rectangle(xPos, yPos, PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
                //childInfo.TextColor = Color.LimeGreen;
                //info.Childs.Add(childInfo);
                //xPos += PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT;
                
                //BP 220
				childInfo = new ItemInfo(startBP.ToString(), ContentAlignment.BottomCenter, null, ContentAlignment.BottomCenter, 
					new Rectangle(xPos, yPos, PIXEL_WIDTH/GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
				//childInfo.TextColor = Color.Violet;  //Color Violet
                childInfo.TextColor = Color.Black;  //--> 색상 변경 20130314
				info.Childs.Add(childInfo);
				xPos += PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT;
								
                //Spo2 100
                //childInfo = new ItemInfo(startSpo2.ToString(), ContentAlignment.BottomCenter, null, ContentAlignment.BottomCenter, 
                //    new Rectangle(xPos, yPos, PIXEL_WIDTH/GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
                //childInfo.TextColor = Color.Black;  //Color Black
                //info.Childs.Add(childInfo);
                //xPos += PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT;

                //R 70
                childInfo = new ItemInfo(startR.ToString(), ContentAlignment.BottomCenter, null, ContentAlignment.BottomCenter,
                    new Rectangle(xPos, yPos, PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
                //childInfo.TextColor = Color.DarkGreen;
                childInfo.TextColor = Color.Black;  //--> 색상 변경 20130314
				info.Childs.Add(childInfo);
				xPos += PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT;
				
                //P 200
                childInfo = new ItemInfo(startP.ToString(), ContentAlignment.BottomCenter, null, ContentAlignment.BottomCenter,
                    new Rectangle(xPos, yPos, PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
                childInfo.TextColor = Color.Red;  //Color Red
				info.Childs.Add(childInfo);
				xPos += PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT; 
                
                //T 41
                childInfo = new ItemInfo(startT.ToString(), ContentAlignment.BottomCenter, null, ContentAlignment.BottomCenter,
                    new Rectangle(xPos, yPos, PIXEL_WIDTH / GRAPH_HEADER_DEVIDE_UNIT, GRAPH_ITEM_HEIGHT));
                childInfo.TextColor = Color.Blue;  //Color Blue
                info.Childs.Add(childInfo);

				rowHeaderItemList.Add(info);
				//xPos Reset, yPos 증가
				xPos = 0;
				yPos += GRAPH_ITEM_HEIGHT;
			}

            //네번째줄 그래프 끝나고 공백 한줄
            info = new ItemInfo("");
            info.Rect = new Rectangle(xPos, yPos, PIXEL_WIDTH, BOX_HEIGHT);
            rowHeaderItemList.Add(info);
            yPos += BOX_HEIGHT;


            graphEnd = yPos;
            /////////////////////////////////////////그래프 끝 ////////////////////////////////////////////////////////

            /*
             * 
            //2012.01.23 woo
            info = new ItemInfo("観察項目", ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH, BOX_HEIGHT));
            rowHeaderItemList.Add(info);
            //여기, 관리항목 헤더를 그린시점의 Y값을 totalHeight에 넣어주고 있다가 관리항목목록을 그려줄때 쓰인다.
            this.totalHeight = yPos;
            yPos += BOX_HEIGHT;  //yPos 증가

            */
            /*
            //IN, OUT Header
			info = new ItemInfo("");
			//IN
			childInfo = new ItemInfo("IN", ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos,PIXEL_WIDTH/2, BOX_HEIGHT)); 
			info.Childs.Add(childInfo);
			xPos += PIXEL_WIDTH/2;
			//OUT
			childInfo = new ItemInfo("OUT", ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos,PIXEL_WIDTH/2, BOX_HEIGHT)); 
			info.Childs.Add(childInfo);
			rowHeaderItemList.Add(info);
			//XPos Reset, YPos 증가
			xPos = 0;
			yPos += BOX_HEIGHT;

			//2006.02.16 IN,OUT은 고정되지 않고 기준정보에 의해 관리됨, 따라서, ioTypeTable에서 추출하여 관리함.(몇건이 될지는 알수 없음)
			//ioTypeTable에서 데이타 추출하여 IOTypeItem을 생성하여 List에 Add, ioTypeTable은 io_gubun(I.O), io_type, io_type_name으로 관리됨
			string ioGubun = "";
			foreach (DataRow dtRow in ioTypeTable.Rows)
			{
				ioGubun = dtRow["io_gubun"].ToString();
				if (ioGubun == "I")  //IN
					this.inTypeItemList.Add(new IOTypeItem(dtRow["io_type"].ToString(), dtRow["io_type_name"].ToString()));
				else  //OUT
					this.outTypeItemList.Add(new IOTypeItem(dtRow["io_type"].ToString(), dtRow["io_type_name"].ToString()));
			}

			int index = 0;
			//IN, OUT 구성
			//IN의 Type이 많은지, OUT의 Type이 많은지 확인
			if (inTypeItemList.Count >= outTypeItemList.Count) //IN이 더 많은 경우
			{
				foreach (IOTypeItem item in inTypeItemList)
				{
					info = new ItemInfo("");
					xPos = 0;  //xPos Reset
					//IN 구성
					childInfo = new ItemInfo(item.TypeName, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos,PIXEL_WIDTH/2, BOX_HEIGHT)); 
					info.Childs.Add(childInfo);
					//MessageBox.Show(outTypeItemList.Count.ToString());
					//OUT 구성
					if (index < outTypeItemList.Count)
					{
						xPos += PIXEL_WIDTH/2;  //xPos OUT 위치로 이동
						IOTypeItem oItem = outTypeItemList[index] as IOTypeItem;
						childInfo = new ItemInfo(oItem.TypeName, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos,PIXEL_WIDTH/2, BOX_HEIGHT)); 
						info.Childs.Add(childInfo);
					}
					rowHeaderItemList.Add(info);  //RowHeaderItemList에 Add
					yPos += BOX_HEIGHT;  //yPos 증가
					index++;
				}
			}
			else //OUT이 더 많은 경우
			{
				foreach (IOTypeItem item in outTypeItemList)
				{
					info = new ItemInfo("");
					xPos = 0;  //xPos Reset
					//IN 구성
					if (index < inTypeItemList.Count)
					{
						IOTypeItem iItem = inTypeItemList[index] as IOTypeItem;
						childInfo = new ItemInfo(iItem.TypeName, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos,PIXEL_WIDTH/2, BOX_HEIGHT)); 
						info.Childs.Add(childInfo);
					}
					//OUT구성
					xPos += PIXEL_WIDTH/2;  //xPos OUT 위치로 이동
					childInfo = new ItemInfo(item.TypeName, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos,PIXEL_WIDTH/2, BOX_HEIGHT)); 
					info.Childs.Add(childInfo);
					rowHeaderItemList.Add(info);  //RowHeaderItemList에 Add
					yPos += BOX_HEIGHT;  //yPos 증가
					index++;
				}
			}

			//in out total
			xPos = 0;
			info = new ItemInfo("Total", ContentAlignment.MiddleCenter,
				new Rectangle(xPos, yPos, PIXEL_WIDTH, BOX_HEIGHT));
			rowHeaderItemList.Add(info);
			yPos += BOX_HEIGHT;  //yPos 증가


            //식사 Header
            info = new ItemInfo("食事", ContentAlignment.MiddleCenter, new Font("MS UI Gothic", 12.0f, FontStyle.Bold),
                new Rectangle(xPos, yPos, PIXEL_WIDTH, BOX_HEIGHT * 3));
            rowHeaderItemList.Add(info);
            yPos += BOX_HEIGHT * 3;

             * 
             */
            /////////////////////////////////////////////////로우 헤더 끝////////////////////////////////////////////////
            

            /////////////////////////////////////////////////컬럼 헤더 설정 ////////////////////////////////////////////
			//rowHeaderRect 설정
			this.graphRowHeaderRect = new Rectangle(0,0, PIXEL_WIDTH, yPos);

			//ColHeader 영역 설정
			xPos = PIXEL_WIDTH;
			yPos = 0;
			//날짜 영역(보여질 날짜의 갯수만큼)
			for (int i = 0 ; i < DISPLAY_DAY_COUNT ; i++)
			{
				info = new ItemInfo(date.AddDays(i-6).ToString("MM/dd").Replace("-","/"), ContentAlignment.MiddleCenter, 
					new Rectangle(xPos, yPos, PIXEL_WIDTH, BOX_HEIGHT));
				xPos += PIXEL_WIDTH;
				//Key는 i로 설정
				colHeaderItemList.Add(i.ToString(), info);
			}

			//시간 영역
			xPos = PIXEL_WIDTH;
			yPos = BOX_HEIGHT;
			string key = "";
			for (int i = 0 ; i < DISPLAY_DAY_COUNT ; i++)
			{
				key = i.ToString() + "1";
				info = new ItemInfo("");
				for (int j = 0 ; j < 6 ; j++)
				{
					//childInfo = new ItemInfo((j*6).ToString(), ContentAlignment.MiddleLeft, new Rectangle(xPos,yPos,PIXEL_WIDTH/4, BOX_HEIGHT));
                    //2012.01.24 24시간을 6시간 단위로 잘랐던 것을 4시간 단위로 수정
                    childInfo = new ItemInfo((j * 4).ToString(), ContentAlignment.MiddleLeft, new Rectangle(xPos - 4, yPos, PIXEL_WIDTH / 6, BOX_HEIGHT));
					info.Childs.Add(childInfo);
					xPos += PIXEL_WIDTH/6;
				}
				colHeaderItemList.Add(key, info);
			}
			
			xPos = PIXEL_WIDTH; //Reset

			//graphColHeaderRect 영역 설정 (너비는 한 Cell의 너비*날짜수, 높이는 3줄)
			this.graphColHeaderRect = new Rectangle(xPos, 0, DISPLAY_DAY_COUNT*PIXEL_WIDTH, BOX_HEIGHT*3);
            
            //그래프 Item Rect 정의
            this.graphRect = new Rectangle(xPos, BOX_HEIGHT * 3, DISPLAY_DAY_COUNT * PIXEL_WIDTH, GRAPH_ITEM_HEIGHT * 10);
            
            ////////////////////////////////////////// 그래프 디자인 끝 ///////////////////////////////////////////////////////
            
            //데이터 영역
            xPos = PIXEL_WIDTH;
            yPos = BOX_HEIGHT * 3 + GRAPH_ITEM_HEIGHT * 10;

            //IN,OUT
            xPos = PIXEL_WIDTH;
            yPos = BOX_HEIGHT * 6  + GRAPH_ITEM_HEIGHT * 10;  //2줄 늘어남


            /*
            //2006.02.16 INOUT_KIND_COUNT 설정 (HEADER 포함)
            INOUT_KIND_COUNT = Math.Max(this.inTypeItemList.Count, this.outTypeItemList.Count) + 1;

            //INOUT영역 Rect 설정
            this.inOutRect = new Rectangle(xPos, yPos, DISPLAY_DAY_COUNT * PIXEL_WIDTH, BOX_HEIGHT * INOUT_KIND_COUNT);

            string text = "";
            //보여지는 (행) 날짜수 * IN,OUT분할(2) +  INOUT 종류(5, Header포함)
            //데이타는  Date + IN/OUT구분(I.In, O.Out) + IOType(In에서는 A1.경구, A2.윤액, A3.혈액, A4.기타, Out에서는 A1.누량, A2.편량, A3.출혈, A4.기타) + 수량
            //따라서, Key = i(시작일자와의 일수차이) + IN/OUT구분(I,0) + IOType(A1,A2.A3,A4)
            //2006.02.16 INOUT의 종류는 고정되지 않고 기준정보에 의해 처리됨
            //따라서, inTypeItemList와 outTypeItemList의 갯수로 INOUT의 종류를 설정함

            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                for (int j = 0; j < AREA_DIVIDE_TWO; j++)
                {
                    for (int k = 0; k < INOUT_KIND_COUNT; k++)
                    {
                        text = "";
                        //Header IN,OUT Text 설정
                        if (k == 0)
                        {
                            if (j % 2 == 0)
                                text = "IN";
                            else
                                text = "OUT";
                        }

                        //Key 구성
                        key = i.ToString();
                        if (j % 2 == 0)
                            key += "I";
                        else
                            key += "O";

                        //2006.02.16 IN,OUT의 Key는 IN은 inTypeItemList에서 가져오고, OUT은 outTypeItemList에서 가져온다.
                        if (k == 0)  //IN, OUT Header
                        {
                            info = new ItemInfo(text, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_TWO, BOX_HEIGHT));
                            this.inoutHeaderItemList.Add(info); //Header List에 Add
                        }
                        else // k > 0 일때 실제 Item
                        {
                            if (j % 2 == 0) //IN
                            {
                                if (k - 1 < inTypeItemList.Count)  //Item Valid Check
                                {
                                    IOTypeItem ioItem = this.inTypeItemList[k - 1] as IOTypeItem;
                                    key += ioItem.IOType;  //Key 설정
                                    info = new ItemInfo(text, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_TWO, BOX_HEIGHT));
                                    this.inoutItemList.Add(key, info);  //IN,OUT Item List에 Add
                                }

                            }
                            else  //OUT
                            {
                                if (k - 1 < outTypeItemList.Count)  //Item Valid Check
                                {
                                    IOTypeItem ioItem = this.outTypeItemList[k - 1] as IOTypeItem;
                                    key += ioItem.IOType;  //Key 설정
                                    info = new ItemInfo(text, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_TWO, BOX_HEIGHT));
                                    this.inoutItemList.Add(key, info);  //IN,OUT Item List에 Add
                                }
                            }
                        }

                        yPos += BOX_HEIGHT;
                    }
                    xPos += PIXEL_WIDTH / AREA_DIVIDE_TWO;
                    yPos = BOX_HEIGHT * 6 + GRAPH_ITEM_HEIGHT * 10;
                }
            }

            //in out total영역
            xPos = PIXEL_WIDTH;
            yPos = BOX_HEIGHT * (6 + INOUT_KIND_COUNT) + GRAPH_ITEM_HEIGHT * 10;
            //in out total영역 Rect 설정
            this.inOutTotalRect = new Rectangle(xPos, yPos, DISPLAY_DAY_COUNT * PIXEL_WIDTH, BOX_HEIGHT);

            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                for (int j = 0; j < AREA_DIVIDE_THREE; j++)
                {

                    info = new ItemInfo("", ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_THREE, BOX_HEIGHT));
                    info.Name = "total";
                    this.inoutTotalItemList.Add(i.ToString() + (j + 1).ToString(), info);
                    yPos += BOX_HEIGHT;

                    xPos += PIXEL_WIDTH / AREA_DIVIDE_THREE;
                    yPos = BOX_HEIGHT * (6 + INOUT_KIND_COUNT) + GRAPH_ITEM_HEIGHT * 10;
                }
            }

            //식사영역
            //식사영역 Rect 설정
            this.foodRect = new Rectangle(xPos, yPos, DISPLAY_DAY_COUNT * PIXEL_WIDTH, BOX_HEIGHT * 3);

            //보여지는 (행) 날짜수 * 식사분할수 + 3줄
            //Key값은 i(시작날짜와의 날수 차이) + (j + 1)(키구분: 1.조식,2.중식,3.석식,4.야식) + k.(0.식사구분, 1.주식섭취량, 2.부식섭취량)
            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                for (int j = 0; j < AREA_DIVIDE_THREE; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        info = new ItemInfo("", ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_THREE, BOX_HEIGHT));
                        foodItemList.Add(i.ToString() + "T" + (j + 1).ToString() + k.ToString(), info);
                        yPos += BOX_HEIGHT;
                    }
                    xPos += PIXEL_WIDTH / AREA_DIVIDE_THREE;
                    yPos = BOX_HEIGHT * 3 + GRAPH_ITEM_HEIGHT * 10;
                }
            }

            */
            // Control의 Size Set
           // this.Size = new Size(PIXEL_WIDTH * (DISPLAY_DAY_COUNT + 1), this.totalHeight);

		}
		#endregion

		#region Draw 관련
		private Pen pen1 = new Pen(Color.FromArgb(8,146,180));
		private Pen pen2 = new Pen(Color.FromArgb(208,228,233));
		private Pen pen3 = new Pen(Color.FromArgb(255,0,0));
		private void DrawLine(Graphics g)
		{
			//RowHeader 영역 Line Draw (수평라인 -> 수직라인)
            int xPos = graphRowHeaderRect.X;
            int yPos = graphRowHeaderRect.Y + BOX_HEIGHT*3;

            g.DrawLine(pen1, this.graphRect.X, yPos, graphRowHeaderRect.Right, yPos); //ColHeader 부분
			yPos += GRAPH_ITEM_HEIGHT*10;
			g.DrawLine(pen1, xPos, yPos, graphRowHeaderRect.Right, yPos);  //Graph Bottom
			
			//수직라인
			g.DrawLine(pen1, graphRowHeaderRect.X + PIXEL_WIDTH, graphRowHeaderRect.Y, graphRowHeaderRect.X + PIXEL_WIDTH, graphRowHeaderRect.Bottom);

			//Graph Item 영역 Draw
			xPos = this.graphRect.X;
			yPos = this.graphRect.Y;
			
			//Right 영역에 Verical Line Draw
			for (int i = 1 ; i <= DISPLAY_DAY_COUNT ; i++)
			{
				for (int j = 1 ; j <= GRAPH_ITEM_DEVIDE_UNIT ; j++)
				{
					xPos += PIXEL_WIDTH/GRAPH_ITEM_DEVIDE_UNIT;
					if (j == GRAPH_ITEM_DEVIDE_UNIT)  //굵은 Line
						g.DrawLine(pen1, xPos, graphRect.Top, xPos, graphRect.Bottom);
					else  //가는 Line
						g.DrawLine(pen2, xPos, graphRect.Top, xPos, graphRect.Bottom);
				}
			}
			//Horizontal Line Draw
			for (int i = 1 ; i <= 50 ; i++)
			{
				yPos += GRAPH_ITEM_HEIGHT/5;  //yPos 증가
				if (i%5 == 0) //굵은 Line
					if (i == 30)
						g.DrawLine(pen3, graphRect.X, yPos, graphRect.Right, yPos);
					else
						g.DrawLine(pen1, graphRect.X, yPos, graphRect.Right, yPos);
				else
					g.DrawLine(pen2, graphRect.X, yPos, graphRect.Right, yPos);
			}

            //////////////////////////////////////////그래프 괘선 끝////////////////////////////////////

            DrawNUR1122Line(g);
            DrawFoodLine(g);
            DrawEtc1Line(g);
            DrawEtc2Line(g);
            DrawEtc3Line(g);

            //DrawInOutLine(g);            
		}
        
        public void DrawNUR1122Line(Graphics g)
        {
            int xPos, yPos;

            xPos = nur1122Rect.X;
            yPos = nur1122Rect.Y;

            //2013.07.06 관찰항목 수평라인
            for (int i = 0; i < mHangmog_count; i++)
            {
                yPos += BOX_HEIGHT;
                g.DrawLine(pen1, xPos, yPos, nur1122Rect.Right, yPos);
            }

            //헤더 구분선 추가
            g.DrawLine(pen1, 0, nur1122Rect.Y + BOX_HEIGHT, xPos, nur1122Rect.Y + BOX_HEIGHT);

            //2013.07.06 관찰항목 수직라인
            xPos = this.nur1122Rect.X;
            yPos = this.nur1122Rect.Y;
            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                for (int j = 0; j < AREA_DIVIDE_THREE; j++)
                {
                    if (j == 0)  //굵은 Line
                        g.DrawLine(pen1, xPos, nur1122Rect.Top, xPos, nur1122Rect.Bottom);
                    else  //가는 Line
                        g.DrawLine(pen2, xPos, nur1122Rect.Top, xPos, nur1122Rect.Bottom);
                    xPos += PIXEL_WIDTH / AREA_DIVIDE_THREE;
                }

            }

            //관찰항목 전체 사각형의 B, R Line
            g.DrawLine(pen1, 0, nur1122Rect.Bottom, nur1122Rect.Right, nur1122Rect.Bottom);
            g.DrawLine(pen1, nur1122Rect.Right, nur1122Rect.Top, nur1122Rect.Right, nur1122Rect.Bottom);

        }

        public void DrawInOutLine(Graphics g)
        {

            //IN,OUT 경계 시작 위치
            //int inoutYPos = yPos;
            /*
            //IN,OUT Header
            yPos += BOX_HEIGHT;
            g.DrawLine(pen1, xPos, yPos, graphRowHeaderRect.Right, yPos);
            //IN,OUT Bottom
            yPos += BOX_HEIGHT*(INOUT_KIND_COUNT - 1);
            g.DrawLine(pen1, xPos, yPos, graphRowHeaderRect.Right, yPos);
            //Total Bottom
            yPos += BOX_HEIGHT;
            g.DrawLine(pen1, xPos, yPos, graphRowHeaderRect.Right, yPos);
            //항목 코드 header
            yPos += BOX_HEIGHT;
            g.DrawLine(pen1, xPos, yPos, graphRowHeaderRect.Right, yPos);
            */

            //IN,OUT 경계 수직라인
            //g.DrawLine(pen2, graphRowHeaderRect.X + PIXEL_WIDTH/2, inoutYPos, graphRowHeaderRect.X + PIXEL_WIDTH/2,  inOutRect.Bottom); //graphRowHeaderRect.Bottom
            //ColHeader LIne (Bottom에 하나)
            //			g.DrawLine(pen1, graphColHeaderRect.X, graphColHeaderRect.Bottom, graphColHeaderRect.Right, graphColHeaderRect.Bottom);



            /*

            //IN,OUT Vertical Line
            xPos = this.inOutRect.X;
            yPos = this.inOutRect.Y;
            for (int i = 1 ; i <= DISPLAY_DAY_COUNT ; i++)
            {
                for (int j = 1 ; j <= AREA_DIVIDE_TWO ; j++)
                {
                    xPos += PIXEL_WIDTH/AREA_DIVIDE_TWO;
                    if (j == AREA_DIVIDE_TWO)  //굵은 Line
                        g.DrawLine(pen1, xPos, inOutRect.Top, xPos, inOutRect.Bottom);
                    else  //가는 Line
                        g.DrawLine(pen2, xPos, inOutRect.Top, xPos, inOutRect.Bottom);

                }
            }
            //In,OUT 수평라인
            for (int i = 1 ; i <= INOUT_KIND_COUNT+1 ; i++)
            {
                yPos += BOX_HEIGHT;
                g   .DrawLine(pen1, inOutRect.X, yPos, inOutRect.Right, yPos);
            }

            //in out total (Vertical Line)
            xPos = this.inOutTotalRect.X;
            yPos = this.inOutTotalRect.Y;
            for (int i = 1 ; i <= DISPLAY_DAY_COUNT ; i++)
            {
                for (int j = 1 ; j <= AREA_DIVIDE_THREE ; j++)
                {
                    xPos += PIXEL_WIDTH/AREA_DIVIDE_THREE;
                    if (j == AREA_DIVIDE_THREE)  //굵은 Line
                        g.DrawLine(pen1, xPos, inOutTotalRect.Top, xPos, inOutTotalRect.Bottom);
                    else  //가는 Line
                        g.DrawLine(pen2, xPos, inOutTotalRect.Top, xPos, inOutTotalRect.Bottom);

                }
            }
            */
        }

        public void DrawFoodLine(Graphics g)
        {
            int xPos, yPos;

            xPos = this.foodRect.X;
            yPos = this.foodRect.Y;

            //식사영역 수평Line
            for (int i = 0; i < 5; i++)
            {
                yPos += BOX_HEIGHT;
                g.DrawLine(pen1, xPos, yPos, foodRect.Right, yPos);
            }

            g.DrawLine(pen1, xPos - PIXEL_WIDTH / 2, foodRect.Top, xPos - PIXEL_WIDTH / 2, foodRect.Bottom); //중간 구분 라인

            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                for (int j = 0; j < AREA_DIVIDE_THREE; j++)
                {
                    if (j == 0)  //굵은 Line
                        g.DrawLine(pen1, xPos, foodRect.Top, xPos, foodRect.Bottom);
                    else  //가는 Line
                        g.DrawLine(pen2, xPos, foodRect.Top, xPos, foodRect.Bottom);
                    xPos += PIXEL_WIDTH / AREA_DIVIDE_THREE;
                }
            }


            //식사영역 전체 사각형의 B, R Line
            g.DrawLine(pen1, 0, foodRect.Bottom, foodRect.Right, foodRect.Bottom);
            g.DrawLine(pen1, foodRect.Right, foodRect.Top, foodRect.Right, foodRect.Bottom);
        }

        public void DrawEtc1Line(Graphics g)
        {
            int xPos, yPos, endyPos;

            xPos = etc1Rect.X;
            yPos = etc1Rect.Y;

            //SPO2, O2, CHUCHI
            for (int i = 0; i < 3; i++)
            {
                yPos += BOX_HEIGHT;
                g.DrawLine(pen1, xPos, yPos, etc1Rect.Right, yPos);
            }

            endyPos = yPos;

            //SPO2, O2, CHUCHI 수직라인
            xPos = this.etc1Rect.X;
            yPos = this.etc1Rect.Y;

            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                for (int j = 0; j < AREA_DIVIDE_THREE; j++)
                {
                    if (j == 0)  //굵은 Line
                        g.DrawLine(pen1, xPos, etc1Rect.Top, xPos, etc1Rect.Bottom);
                    else  //가는 Line
                        g.DrawLine(pen2, xPos, etc1Rect.Top, xPos, endyPos);
                    xPos += PIXEL_WIDTH / AREA_DIVIDE_THREE;
                }

            }

            //SPO2, O2, CHUCHI 전체 사각형의 B, R Line
            g.DrawLine(pen1, 0, etc1Rect.Bottom, etc1Rect.Right, etc1Rect.Bottom);
            g.DrawLine(pen1, etc1Rect.Right, etc1Rect.Top, etc1Rect.Right, etc1Rect.Bottom);
        }

        public void DrawEtc2Line(Graphics g)
        {
            int xPos, yPos;

            xPos = etc2Rect.X;
            yPos = etc2Rect.Y;

            //변 처치, 뇨 처치, 신장, 체중 수평라인
            for (int i = 0; i < 3; i++)
            {
                yPos += BOX_HEIGHT;
                g.DrawLine(pen1, xPos, yPos, nur1122Rect.Right, yPos);
            }

            //변 처치, 뇨 처치, 신장, 체중 수직라인
            xPos = this.etc2Rect.X;
            yPos = this.etc2Rect.Y;
            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                for (int j = 0; j < AREA_DIVIDE_TWO; j++)
                {
                    if (j == 0)  //굵은 Line
                        g.DrawLine(pen1, xPos, etc2Rect.Top, xPos, etc2Rect.Bottom);
                    else  //가는 Line
                        g.DrawLine(pen2, xPos, etc2Rect.Top, xPos, etc2Rect.Bottom);
                    xPos += PIXEL_WIDTH / AREA_DIVIDE_TWO;
                }

            }

            //변 처치, 뇨 처치, 신장, 체중 전체 사각형의 B, R Line
            g.DrawLine(pen1, 0, etc2Rect.Bottom, etc2Rect.Right, etc2Rect.Bottom);
            g.DrawLine(pen1, etc2Rect.Right, etc2Rect.Top, etc2Rect.Right, etc2Rect.Bottom);
        }

        public void DrawEtc3Line(Graphics g)
        {
            int xPos, yPos;

            xPos = etc3Rect.X;
            yPos = etc3Rect.Y;

            //CARE 항목 수직라인
            xPos = this.etc3Rect.X;
            yPos = this.etc3Rect.Y;
            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                g.DrawLine(pen1, xPos, etc3Rect.Top, xPos, etc3Rect.Bottom);
                xPos += PIXEL_WIDTH;
            }

            //CARE 항목 전체 사각형의 B, R Line
            g.DrawLine(pen1, 0, etc3Rect.Bottom, etc3Rect.Right, etc3Rect.Bottom);
            g.DrawLine(pen1, etc3Rect.Right, etc3Rect.Top, etc3Rect.Right, etc3Rect.Bottom);
        }

        #endregion

        #region SetGraphData (데이타로 그래프의 좌표 계산)
        
        
        const int STEPS = 9; // 그래프 숫자 표현 단계

        /* MAX - MIN 의 값이 STEPS의 배수가 되게 한다.
         * 　　　　
         */
        const int MAX_BP = 220;
		const int MIN_BP = 40;  //2012.01.18 MIN_BP 20 을 40으로 수정 woo
		const double MAX_T = 43;
		const double MIN_T = 34;
		//const int MAX_SPO2 = 105;
        //const int MIN_SPO2 = 60;
        const int MAX_P = 210;
        const int MIN_P = 30;
        
        int intervalT = (int)((MAX_T - MIN_T) / (STEPS));
        int intervalP = (MAX_P - MIN_P) / (STEPS);
        int intervalR = (MAX_R - MIN_R) / (STEPS);
        //int intervalSpo2 = (MAX_SPO2 - MIN_SPO2) / (STEPS);
        int intervalBP = (MAX_BP - MIN_BP) / (STEPS);
        //int intervalBS = (MAX_BS - MIN_BS) / (STEPS);

		// 20070412 - Add Start
		const int MAX_R = 90; //MAX_W -> MAX_R
		const int MIN_R = 0;    //MIN_W -> MIN_R
		// 20070412 - Add End

        // 20110412 - Add Start
        //const int MAX_BS = 300;
        //const int MIN_BS = 30;
        // 20110412 - Add End


		public void SetGraphData(DataTable dTable, DateTime endDate)
		{
			//LIST Clear
			this.BPHPointList.Clear();
			this.BPLPointList.Clear();
			this.PPointList.Clear();
			this.TPointList.Clear();
			//this.Spo2PointList.Clear();
			this.RPointList.Clear();		// 20070412 - Add Line
            //this.BSPointList.Clear();       // 20110412 - Add Line

            //Point Values Clear
            this.bphValueList.Clear();
            this.bplValueList.Clear();
            this.pValueList.Clear();
            this.tValueList.Clear();
            //this.spo2ValueList.Clear();
            this.rValueList.Clear();
            //this.bsValueList.Clear();

			if (dTable.Rows.Count < 1) return;
			
            try
            {
				DateTime dTime;
				DateTime startTime = DateTime.Now;
				string dataType = "", timeGubun = "";
				double timeData = 0;
				int dateDiff = 0;
				double data = 0;
				int dataInt = 0;
				double dataDouble = 0;
				int remnInt = 0;
				double remnDouble = 0;
				int yPos = 0;
				int xPos = 0;
				
				//시작일자는 조회기준일 - (DISPLAY_DAY_COUNT -1)일
				startTime = endDate.AddDays(-DISPLAY_DAY_COUNT + 1);
				//Table 컬럼은 Date + Time + DataType + Data
                foreach (DataRow dtRow in dTable.Rows)
                {
                    if (dtRow["pr_value"].ToString() != "0")
                    {

                        //Reset
                        xPos = this.graphRect.Left;
                        yPos = this.graphRect.Top;

                        dTime = DateTime.Parse(dtRow["ymd_date"].ToString());
                        //0630형식으로 데이타가 관리됨(2006.01.03 수정)
                        timeGubun = dtRow["time_gubun"].ToString();
                        if (timeGubun.Length == 4)  //0512형식
                        {
                            timeData = double.Parse(timeGubun.Substring(0, 2)) + double.Parse(timeGubun.Substring(2, 2)) / 24.0;
                            timeData = Math.Round(timeData, 2); //소수 2자리까지만 반영함
                        }
                        else  //유효한 값이 아니므로 Skip
                            continue;
                        dataType = dtRow["pr_gubun"].ToString();
                        if (dtRow["pr_value"].ToString() == "")
                            continue;
                        else
                            data = double.Parse(dtRow["pr_value"].ToString());
                        //일수 차이 계산
                        dateDiff = ((TimeSpan)dTime.Subtract(startTime)).Days;
                        //일수 차이에 따른 xPos(시작위치)
                        xPos += dateDiff * PIXEL_WIDTH;

                        //Time에 따라 XPos 위치 계산
                        //총 24시간중에서 Time의 위치
                        xPos += (int)(((double)PIXEL_WIDTH) * ((double)timeData / 24.0));

                        //DataType에 따라 YPos 위치계산
                        switch (dataType)
                        {
                            case "BPH":
                            case "BPL":
                                dataInt = Math.Min(MAX_BP, Math.Max(MIN_BP, (int)data));
                                //Top에서 부터 위치를 계산(Interval단위로 그래프를 그리므로 Interval로 나눈다)
                                yPos += (MAX_BP - dataInt) / intervalBP * GRAPH_ITEM_HEIGHT;
                                remnInt = (MAX_BP - dataInt) % intervalBP;
                                remnInt = (int)((double)remnInt / (double)intervalBP * (double)GRAPH_ITEM_HEIGHT);
                                yPos += remnInt;
                                break;
                            
                            case "P":
                                dataInt = Math.Min(MAX_P, Math.Max(MIN_P, (int)data));
                                yPos += (MAX_P - dataInt) / intervalP * GRAPH_ITEM_HEIGHT;
                                remnInt = (MAX_P - dataInt) % intervalBP;
                                remnInt = (int)((double)remnInt / (double)intervalP * (double)GRAPH_ITEM_HEIGHT);
                                yPos += remnInt;
                                break;

                            case "T":
                                dataDouble = Math.Min(MAX_T, Math.Max(MIN_T, data));
                                dataInt = (int)(MAX_T - dataDouble) / intervalT;
                                yPos += dataInt * GRAPH_ITEM_HEIGHT;
                                remnDouble = MAX_T - dataDouble - (double)dataInt;
                                remnInt = (int)(remnDouble * (double)GRAPH_ITEM_HEIGHT);
                                yPos += remnInt;
                                break;
                            //case "SPO2":
                            //    dataInt = Math.Min(MAX_SPO2, Math.Max(MIN_SPO2, (int)data));
                            //    //Top에서 부터 위치를 계산(Interval단위로 그래프를 그리므로 Interval로 나눈다)
                            //    yPos += (MAX_SPO2 - dataInt) / intervalSpo2 * GRAPH_ITEM_HEIGHT;
                            //    remnInt = (MAX_SPO2 - dataInt) % intervalSpo2;
                            //    remnInt = (int)((double)remnInt / (double)intervalSpo2 * (double)GRAPH_ITEM_HEIGHT);
                            //    yPos += remnInt;
                            //    break;
                            // 20070412 - Add Start
                            case "R":   //212.01.24 W -> R
                                dataInt = Math.Min(MAX_R, Math.Max(MIN_R, (int)data));
                                //Top에서 부터 위치를 계산(Interval단위로 그래프를 그리므로 Interval로 나눈다)
                                yPos += (MAX_R - dataInt) / intervalR * GRAPH_ITEM_HEIGHT;
                                remnInt = (MAX_R - dataInt) % intervalR;
                                remnInt = (int)((double)remnInt / intervalR * (double)GRAPH_ITEM_HEIGHT);
                                yPos += remnInt;
                                break;
                            // 20070412 - Add End

                            // 20070412 - Add Start
                            //case "BS":
                            //    dataInt = Math.Min(MAX_BS, Math.Max(MIN_BS, (int)data));
                            //    //Top에서 부터 위치를 계산(Interval단위로 그래프를 그리므로 Interval로 나눈다)
                            //    yPos += (MAX_BS - dataInt) / intervalBS * GRAPH_ITEM_HEIGHT;
                            //    remnInt = (MAX_BS - dataInt) % intervalBS;
                            //    remnInt = (int)((double)remnInt / (double)intervalBS * (double)GRAPH_ITEM_HEIGHT);
                            //    yPos += remnInt;
                            //    break;
                            // 20070412 - Add End
                        }
                        //DataType에 따라 LIST에 저장
                        switch (dataType)
                        {
                            case "BPH":
                                this.BPHPointList.Add(new Point(xPos, yPos));
                                this.bphValueList.Add(dtRow["pr_value"].ToString());
                                break;
                            case "BPL":
                                this.BPLPointList.Add(new Point(xPos, yPos));
                                this.bplValueList.Add(data);
                                break;
                            case "P":
                                this.PPointList.Add(new Point(xPos, yPos));
                                this.pValueList.Add(dtRow["pr_value"].ToString());
                                break;
                            case "T":
                                this.TPointList.Add(new Point(xPos, yPos));
                                this.tValueList.Add(dtRow["pr_value"].ToString());
                                break;
                            //case "SPO2":
                            //    this.Spo2PointList.Add(new Point(xPos, yPos));
                            //    this.spo2ValueList.Add(dtRow["pr_value"].ToString());
                            //    break;
                            case "R":
                                this.RPointList.Add(new Point(xPos, yPos));
                                this.rValueList.Add(dtRow["pr_value"].ToString());
                                break;
                            //case "BS":
                            //    this.BSPointList.Add(new Point(xPos, yPos));
                            //    this.bsValueList.Add(dtRow["pr_value"].ToString());
                            //    break;
                        }
                    }
                }
            }
            catch (Exception xe)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("SetGraphData Error=" + xe.Message);
            }
		}
		#endregion

		#region SetDateHeader, SetFoodData, SetInOutData
		public void SetDateHeader(DateTime endDate,IHIS.Framework.MultiLayout layOut)
		{
			bool isSusul = false;
			int  susulilsu = 0;
			DateTime startDt = endDate.AddDays(-DISPLAY_DAY_COUNT + 1);
			int k = 0;
			//날짜는 colHeaderItemList에 0 ~ DISPLAY_DAY_COUNT -1 Key로 ItemInfo 설정함
			for (int i = 0 ; i < DISPLAY_DAY_COUNT ; i++)
			{
				((ItemInfo) this.colHeaderItemList[i.ToString()]).Image = null;
				if (isSusul)
				{
					((ItemInfo) this.colHeaderItemList[i.ToString()]).Image = this.susulImage;
					((ItemInfo) this.colHeaderItemList[i.ToString()]).ImageAlign = ContentAlignment.MiddleLeft;
					((ItemInfo) this.colHeaderItemList[i.ToString()]).Text = startDt.ToString("MM/dd").Replace("-","/")+"["+susulilsu.ToString()+"]"; 
				}
				else
				{
					((ItemInfo) this.colHeaderItemList[i.ToString()]).Image = null;
					((ItemInfo) this.colHeaderItemList[i.ToString()]).Text = startDt.ToString("MM/dd").Replace("-","/");
				}
				//수술이미지 clear
				//((ItemInfo) this.colHeaderItemList[i.ToString()]).Image = null;
				for ( int j = 0; j < layOut.RowCount; j++)
				{
					int op_reser = int.Parse((Convert.ToDateTime(layOut.GetItemString(j,"op_reser_date")).ToString("yyyyMMdd").Replace("-", "").Replace("/", "").ToString()));
					int Start = int.Parse(startDt.ToString("yyyyMMdd").Replace("-", "").Replace("/", "").ToString());
			
					if (Convert.ToDateTime(layOut.GetItemString(j,"op_reser_date")).CompareTo(startDt) <= 0)
					{	
						isSusul = true;
						if (k == 0 && Convert.ToDateTime(layOut.GetItemString(j,"op_reser_date")).CompareTo(startDt) < 0)
						{
							susulilsu = Start - op_reser;
							k++;
						}
						//해당일자에 수술이미지 세팅
						((ItemInfo) this.colHeaderItemList[i.ToString()]).Image = this.susulImage;
						((ItemInfo) this.colHeaderItemList[i.ToString()]).ImageAlign = ContentAlignment.MiddleLeft;
						((ItemInfo) this.colHeaderItemList[i.ToString()]).Text = startDt.ToString("MM/dd").Replace("-","/")+"["+susulilsu.ToString()+"]"; 
						break;
					}
				}
		
				//startDt = startDt.AddDays(1);
		
				if (isSusul)
				{
					susulilsu++;
				}
				
				if (susulilsu > DISPLAY_DAY_COUNT) 
				{
					((ItemInfo) this.colHeaderItemList[i.ToString()]).Image = null;
					((ItemInfo) this.colHeaderItemList[i.ToString()]).Text = startDt.ToString("MM/dd").Replace("-","/");
				}
		
				startDt = startDt.AddDays(1);
			}
		}

        public void SetFoodLayout()
        {
            //식사 Header
            ItemInfo info, childinfo;
            int yPos = currYPos;
            int xPos = graphRowHeaderRect.X;
            int temp = yPos;
            string key = "";

            foodHeaderItemList.Clear();
            foodItemList.Clear();

            info = new ItemInfo("食事", ContentAlignment.MiddleCenter, new Font("MS UI Gothic", 12.0f, FontStyle.Bold),
                new Rectangle(this.graphRowHeaderRect.X, yPos, PIXEL_WIDTH/2, BOX_HEIGHT * 5));

            childinfo = new ItemInfo("食種", ContentAlignment.MiddleCenter, new Rectangle(xPos + PIXEL_WIDTH / 2, yPos, PIXEL_WIDTH / 2, BOX_HEIGHT));
            info.Childs.Add(childinfo);
            yPos += BOX_HEIGHT;

            childinfo = new ItemInfo("主食", ContentAlignment.TopCenter, new Rectangle(xPos + PIXEL_WIDTH / 2, yPos, PIXEL_WIDTH / 2, BOX_HEIGHT * 2));
            info.Childs.Add(childinfo);
            yPos += BOX_HEIGHT * 2;

            childinfo = new ItemInfo("副食", ContentAlignment.TopCenter, new Rectangle(xPos + PIXEL_WIDTH / 2, yPos, PIXEL_WIDTH / 2, BOX_HEIGHT));
            info.Childs.Add(childinfo);
            yPos += BOX_HEIGHT * 2;

            temp = yPos;

            //rowHeaderItemList.Add(info);
            foodHeaderItemList.Add(info);

            xPos = graphColHeaderRect.X;
            yPos = currYPos;

            //식사영역
            //식사영역 Rect 설정
            this.foodRect = new Rectangle(xPos, yPos, DISPLAY_DAY_COUNT * PIXEL_WIDTH, BOX_HEIGHT * 5);

            //보여지는 (행) 날짜수 * 식사분할수 + 3줄
            //Key값은 i(시작날짜와의 날수 차이) + (j + 1)(키구분: 1.조식,2.중식,3.석식,4.야식) + k.(0.식사구분, 1.주식종, 2.주식섭취량, 3.부식종, 4.부식섭취량)
            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                for (int j = 0; j < AREA_DIVIDE_THREE; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        key = i.ToString() + "T" + (j + 1).ToString() + k.ToString();

                        if (!foodItemList.Contains(key))
                        {                            
                            info = new ItemInfo("", ContentAlignment.MiddleRight, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_THREE, BOX_HEIGHT));
                            foodItemList.Add(key, info);
                        }
                        yPos += BOX_HEIGHT;
                    }
                    xPos += PIXEL_WIDTH / AREA_DIVIDE_THREE;
                    yPos = currYPos;
                }
            }

            currYPos = temp;
        }
        public void SetFoodData(DataTable dTable, DateTime endDate)
		{
			//dTable은 Date + 끼니구분(T1.조식,T2.중식,T3.석식,T4.야식) + 
			//식사구분(0.禁食, 1.特式, 2.一般式, 3.小児式, 4.治療式, 5.その他(治療式), 6.官給式, 7.検事式) + 섭취량 로 구성됨

			//기존에 있던 Text는 Clear
			foreach (ItemInfo info in foodItemList.Values)
				info.Text = "";

			DateTime startDt = endDate.AddDays(-DISPLAY_DAY_COUNT + 1);
			DateTime date;
            string kiGubun = "", key = "", qty = "", qty2 = "", sik_jong = "", sik_jusik = "", sik_busik = "";  //siksaGubun = "",
			int dateDiff;
			foreach (DataRow dtRow in dTable.Rows)
			{
                try
                {
					date = DateTime.Parse(dtRow["ymd"].ToString());
					kiGubun = dtRow["nut_gubun"].ToString();
					//siksaGubun = dtRow["siksa_gubun"].ToString();

                    sik_jong = dtRow["sik_jong"].ToString();
                    sik_jusik = dtRow["sik_jusik"].ToString();
                    sik_busik = dtRow["sik_busik"].ToString();
					qty = dtRow["nut_value"].ToString();
                    qty2 = dtRow["nut_value2"].ToString();
					//일수 차이 계산
					dateDiff = ((TimeSpan) date.Subtract(startDt)).Days;
					//foodItemList에 담긴 ItemInfo를 Key를 구성하여 찾아서 SET
					//Key구성 = 시작일과의 일수차이 + 끼니구분 + (0.식사구분, 1.섭취량)
					key = dateDiff.ToString() + kiGubun + "0";
					//끼니구분 ItemInfo 의 Text는 식사구분명을 설정
                    //if ( dtRow["siksa_gubun_name"].ToString().Length > 2)
                    //    ((ItemInfo) this.foodItemList[key]).Text = dtRow["siksa_gubun_name"].ToString().Substring(0,2);
                    //else

                    ((ItemInfo)this.foodItemList[key]).Text = sik_jong;
                    //if (((ItemInfo)this.foodItemList[key]).Text.Trim().Length > 1)
                    //{
                    //    ((ItemInfo)this.foodItemList[key]).TextAlign = ContentAlignment.MiddleLeft;
                    //}
                    //else
                    //{
                    //    ((ItemInfo)this.foodItemList[key]).TextAlign = ContentAlignment.MiddleRight;
                    //}

					//((ItemInfo) this.foodItemList[key]).Text = siksaNameList[siksaGubun].ToString();
					//섭취량 ItemInfo란에는 섭취량을 설정
                    key = dateDiff.ToString() + kiGubun + "1";
                    ((ItemInfo)this.foodItemList[key]).Text = sik_jusik;
					key = dateDiff.ToString() + kiGubun + "2";
					((ItemInfo) this.foodItemList[key]).Text = qty;
                    key = dateDiff.ToString() + kiGubun + "3";
                    ((ItemInfo)this.foodItemList[key]).Text = sik_busik;
                    key = dateDiff.ToString() + kiGubun + "4";
                    ((ItemInfo)this.foodItemList[key]).Text = qty2;
                }
                catch (Exception xe)
                {
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show("SetGraphData Error=" + xe.Message);
                }
			}
			
		}
		
        public void SetInOutData(DataTable dTable, DateTime endDate)
		{
			//dTable은 Date + IN/OUT구분(I.In, O.Out) + IOType(In에서는 A1.경구, A2.윤액, A3.혈액, A4.기타, Out에서는 A1.누량, A2.편량, A3.출혈, A4.기타) + 수량

			//기존에 있던 Text Clear (IN/OUT Header는 제외)
			//Key는 시작일과의 일수차이 + I/O + IOType
			foreach (ItemInfo info in this.inoutItemList.Values)
				info.Text = "";
			DateTime startDt = endDate.AddDays(-DISPLAY_DAY_COUNT + 1);
			string inOutGubun, ioType, key, qty;
			DateTime date;
			int dateDiff;

			foreach (DataRow dtRow in dTable.Rows)
			{
				date = DateTime.Parse(dtRow["ymd"].ToString());
				inOutGubun = dtRow["io_gubun"].ToString();
				ioType = dtRow["io_type"].ToString();
				qty = dtRow["io_value"].ToString();
				//일수 차이 계산
				dateDiff = ((TimeSpan) date.Subtract(startDt)).Days;
				//inoutItemList에 담긴 ItemInfo를 Key를 구성하여 찾아서 SET
				//Key구성 = 시작일과의 일수차이 + I/O + IOType
				key = dateDiff.ToString() + inOutGubun + ioType;
				((ItemInfo) this.inoutItemList[key]).Text = qty;
			}
		}
        public void SetInOutTotalData(DataTable dTable, DateTime endDate)
		{
			//dTable은 Date + IN/OUT구분(I.In, O.Out) + IOType(In에서는 A1.경구, A2.윤액, A3.혈액, A4.기타, Out에서는 A1.누량, A2.편량, A3.출혈, A4.기타) + 수량

			//기존에 있던 Text Clear (IN/OUT Header는 제외)
			//Key는 시작일과의 일수차이 + I/O + IOType
			foreach (ItemInfo info in this.inoutTotalItemList.Values)
				info.Text = "";
			DateTime startDt = endDate.AddDays(-DISPLAY_DAY_COUNT +1);
			string inTotal, outTotal, inoutMinus, key;
			DateTime date;
			int dateDiff;

			foreach (DataRow dtRow in dTable.Rows)
			{
				date = DateTime.Parse(dtRow["ymd"].ToString());
				
				inTotal    = dtRow["in_total"].ToString();
				outTotal   = dtRow["out_total"].ToString();
				inoutMinus = dtRow["inout_minus"].ToString();
				//일수 차이 계산
				dateDiff = ((TimeSpan) date.Subtract(startDt)).Days;
				//inoutItemList에 담긴 ItemInfo를 Key를 구성하여 찾아서 SET
				//Key구성 = 시작일과의 일수차이 + I/O + IOType
				key = dateDiff.ToString() + "1";
				//MessageBox.Show(key);
				((ItemInfo) this.inoutTotalItemList[key]).Text = inTotal;
				key = dateDiff.ToString() + "2";
				((ItemInfo) this.inoutTotalItemList[key]).Text = outTotal;
				key = dateDiff.ToString() + "3";
				((ItemInfo) this.inoutTotalItemList[key]).Text = inoutMinus;
			}
		}
        
        public void SetNUR1122Layout(DataTable dTable)
        {
            this.nur1122HeaderList.Clear();
            this.nur1122ItemList.Clear();
            this.nur1122HeaderItemList.Clear();

            mHangmog_count = dTable.Rows.Count;

            //foreach (ItemInfo infoF in this.nur1122HeaderItemList)
            //    infoF.Text = "";
            //for (int i = 0; i < dTable.Rows.Count; i++)
            //{
            //    hangmogName = dTable.Rows[i]["hangmog_name"].ToString();
            //    ((ItemInfo)this.nur1122HeaderItemList[i]).Text = hangmogName;
            //}
            ItemInfo info = new ItemInfo("");
            string text, key, hangmogCode, hangmogName;
            int xPos, yPos, hangmogCount, temp;
            Color infoColor = new Color(); //글자 색 지정

            hangmogCount = mHangmog_count;
            hangmogName = "";
            xPos = 0;
            //yPos = this.totalHeight;
            temp = currYPos;
            yPos = currYPos; //각 단위별 시작지점

            for (int i = 0; i < hangmogCount; i++)
            {
                hangmogName = dTable.Rows[i]["hangmog_name"].ToString();
                info = new ItemInfo(hangmogName, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH, BOX_HEIGHT));
                this.nur1122HeaderItemList.Add(info);
                yPos += BOX_HEIGHT;
            }

            xPos = PIXEL_WIDTH;

            yPos = currYPos;//BOX_HEIGHT * (7 + INOUT_KIND_COUNT) + GRAPH_ITEM_HEIGHT * 10;
            this.nur1122Rect = new Rectangle(xPos, yPos, DISPLAY_DAY_COUNT * PIXEL_WIDTH, BOX_HEIGHT * (hangmogCount));

            for (int i = 0; i < DISPLAY_DAY_COUNT; i++) //날짜
            {
                for (int j = 0; j < hangmogCount; j++)
                {
                    text = "";  //header 測定値 설정
                    xPos = PIXEL_WIDTH * (i + 1);

                    for (int k = 1; k <= AREA_DIVIDE_THREE; k++)
                    {
                        //타이틀 명 및 데이터 글씨 색 지정
                        switch (k)
                        {
                            case 1:
                                //text = "深夜";
                                infoColor = Color.Red;
                                break;

                            case 2:
                                //text = "昼間";
                                infoColor = Color.FromArgb(3, 57, 70);
                                break;

                            case 3:
                                //text = "夜間";
                                infoColor = Color.Red;
                                break;
                        }

                        if (j == 0) //타이틀일 경우
                        {
                            info = new ItemInfo(text, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_THREE, BOX_HEIGHT));
                            info.TextColor = infoColor;
                            this.nur1122HeaderList.Add(info);
                        }
                        else //관찰항목 값 부분일 경우
                        {
                            hangmogCode = dTable.Rows[j]["hangmog_code"].ToString();
                            key = i.ToString() + hangmogCode + k.ToString();
                            info = new ItemInfo(text, ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_THREE, BOX_HEIGHT));
                            info.TextColor = infoColor;
                            this.nur1122ItemList.Add(key, info);
                        }
                        xPos += PIXEL_WIDTH / AREA_DIVIDE_THREE;
                    }
                    yPos += BOX_HEIGHT;
                }
                temp = yPos;
                yPos = currYPos; // BOX_HEIGHT * (7 + INOUT_KIND_COUNT) + GRAPH_ITEM_HEIGHT * 10;
            }
            currYPos = temp;
        }

        public void SetNUR1122Data(DataTable dTable, DateTime endDate)
        {
            //기본데이터 클리어
            foreach (ItemInfo info in this.nur1122ItemList.Values)
                info.Text = "";
            DateTime startDt = endDate.AddDays(-DISPLAY_DAY_COUNT + 1);
            string hangmogCode, hangmogValue, key;
            DateTime date;
            int dateDiff;
            DateTime dateTemp = DateTime.Parse("1888.12.31");
            int hangmogCount = 0;
            foreach (DataRow dtRow in dTable.Rows)
            {
                date = DateTime.Parse(dtRow["ymd"].ToString());
                hangmogCode = dtRow["hangmog_code"].ToString();                
                //일수 차이 계산
                dateDiff = ((TimeSpan)date.Subtract(startDt)).Days;
                //nur1122ItemList 에 담긴 iteminfo를 key를 구성하여 찾아서 set
                //key 구성 = 시작일과 일수차이 + 항목순서
                if (dateTemp != date)
                {
                    hangmogCount = 0;
                    dateTemp = date;
                }

                for (int i = 1; i <= AREA_DIVIDE_THREE; i++)
                {
                    hangmogValue = dtRow["hangmog_value" + i.ToString()].ToString();
                    key = dateDiff.ToString() + hangmogCode + i.ToString();
                    ((ItemInfo)this.nur1122ItemList[key]).Text = hangmogValue;
                }
                //key = dateDiff.ToString() + hangmogCount.ToString()+hangmogCode;
                
                hangmogCount++;
            }
        }

        public void SetNURName(DataRow[] dTable)
        {
            int key = 0;

            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                for (int j = 1; j <= AREA_DIVIDE_THREE; j++)
                {
                    //foreach (DataRow dtRow in dTable.Select("diff = " + i.ToString() + ", hangmog_seq = " + j.ToString()))
                    //{
                    //    ((ItemInfo)this.nur1122HeaderItemList[key]).Text = dtRow["hangmog_value"].ToString();
                    //}     

                    for (int k = 0; k < dTable.Length; k++)
                    {
                        if (dTable[k]["diff"].ToString() == i.ToString() && dTable[k]["hangmog_seq"].ToString() == j.ToString())
                        {
                            ((ItemInfo)this.nur1122HeaderList[key]).Text = dTable[k]["hangmog_value"].ToString();
                        }
                    }                       
                    key++;
                }
            }
            
        }

        public void SetEtc1Layout(int rowNum)
        {
            //Etc1 Header
            ItemInfo info;
            int yPos = currYPos;
            int xPos = graphRowHeaderRect.X;
            int temp = yPos;
            string key = "";

            etc1HeaderItemList.Clear();
            etc1ItemList.Clear();

            //HEADER SETTING
            etc1HeaderItemList.Add(new ItemInfo("酸素", ContentAlignment.MiddleCenter, new Rectangle(this.graphRowHeaderRect.X, yPos, PIXEL_WIDTH, BOX_HEIGHT)));
            yPos += BOX_HEIGHT;
            etc1HeaderItemList.Add(new ItemInfo("SPO2", ContentAlignment.MiddleCenter, new Rectangle(this.graphRowHeaderRect.X, yPos, PIXEL_WIDTH, BOX_HEIGHT)));
            yPos += BOX_HEIGHT;
            etc1HeaderItemList.Add(new ItemInfo("BS", ContentAlignment.MiddleCenter, new Rectangle(this.graphRowHeaderRect.X, yPos, PIXEL_WIDTH, BOX_HEIGHT)));
            yPos += BOX_HEIGHT;
            etc1HeaderItemList.Add(new ItemInfo("処置", ContentAlignment.MiddleCenter, new Rectangle(this.graphRowHeaderRect.X, yPos, PIXEL_WIDTH, BASE_HEIGHT_MARGIN + ( TEXT_HEIGHT * rowNum))));
            yPos += BASE_HEIGHT_MARGIN + (TEXT_HEIGHT * rowNum);

            temp = yPos;
            
            //データ領域
            xPos = graphColHeaderRect.X;
            yPos = currYPos;

            int currXPos = xPos;

            this.etc1Rect = new Rectangle(xPos, yPos, DISPLAY_DAY_COUNT * PIXEL_WIDTH, (BOX_HEIGHT * 3) + BASE_HEIGHT_MARGIN + (TEXT_HEIGHT * rowNum));

            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                int j = 0;
                for (j = 0; j < 3; j++)
                {
                    xPos = currXPos;
                    for (int k = 1; k <= AREA_DIVIDE_THREE; k++)
                    {
                        //산소 , SPO2, BS 레이아웃 생성
                        key = i.ToString() + j.ToString() + k.ToString();

                        if (!etc1ItemList.Contains(key))
                        {
                            info = new ItemInfo("", ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_THREE, BOX_HEIGHT));
                            etc1ItemList.Add(key, info);
                        }
                        xPos += PIXEL_WIDTH / AREA_DIVIDE_THREE;
                    }
                    yPos += BOX_HEIGHT;
                }                
                //처치 레이아웃 생성
                key = i.ToString() + j.ToString() + "1";
                if (!etc1ItemList.Contains(key))
                {
                    info = new ItemInfo("", ContentAlignment.MiddleCenter, new Rectangle(currXPos, yPos, PIXEL_WIDTH, BASE_HEIGHT_MARGIN + (TEXT_HEIGHT * rowNum)));
                    etc1ItemList.Add(key, info);
                }

                currXPos += PIXEL_WIDTH;
                yPos = currYPos;
            }
            currYPos = temp;
        }

        public void SetEtc2Layout()
        {
            //Etc1 Header
            ItemInfo info;
            int yPos = currYPos;
            int xPos = graphRowHeaderRect.X;
            int temp = yPos;
            string key = "";

            etc2HeaderItemList.Clear();
            etc2ItemList.Clear();

            //HEADER SETTING
            etc2HeaderItemList.Add(new ItemInfo("便処置・便回数", ContentAlignment.MiddleCenter, new Rectangle(this.graphRowHeaderRect.X, yPos, PIXEL_WIDTH, BOX_HEIGHT)));
            yPos += BOX_HEIGHT;
            etc2HeaderItemList.Add(new ItemInfo("　尿量・尿回数", ContentAlignment.MiddleCenter, new Rectangle(this.graphRowHeaderRect.X, yPos, PIXEL_WIDTH, BOX_HEIGHT)));
            yPos += BOX_HEIGHT;
            etc2HeaderItemList.Add(new ItemInfo("　身長・体重　", ContentAlignment.MiddleCenter, new Rectangle(this.graphRowHeaderRect.X, yPos, PIXEL_WIDTH, BOX_HEIGHT)));
            yPos += BOX_HEIGHT;

            temp = yPos;

            //データ領域
            xPos = graphColHeaderRect.X;
            yPos = currYPos;

            int currXPos = xPos;

            this.etc2Rect = new Rectangle(xPos, yPos, DISPLAY_DAY_COUNT * PIXEL_WIDTH, BOX_HEIGHT * 3);

            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                int j = 0;
                for (j = 0; j < 3; j++)
                {
                    xPos = currXPos;
                    for (int k = 1; k <= AREA_DIVIDE_TWO; k++)
                    {
                        //변, 뇨, 신장, 체중
                        key = i.ToString() + j.ToString() + k.ToString();

                        if (!etc2ItemList.Contains(key))
                        {
                            info = new ItemInfo("", ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH / AREA_DIVIDE_TWO, BOX_HEIGHT));
                            etc2ItemList.Add(key, info);
                        }
                        xPos += PIXEL_WIDTH / AREA_DIVIDE_TWO;
                    }
                    yPos += BOX_HEIGHT;
                }

                currXPos += PIXEL_WIDTH;
                yPos = currYPos;
            }
            currYPos = temp;
        }

        public void SetEtc3Layout(int rowNum)
        {
            //Etc1 Header
            ItemInfo info;
            int yPos = currYPos;
            int xPos = graphRowHeaderRect.X;
            int temp = yPos;    
            string key = "";

            etc3HeaderItemList.Clear();
            etc3ItemList.Clear();

            //HEADER SETTING
            etc3HeaderItemList.Add(new ItemInfo("ケア", ContentAlignment.MiddleCenter, new Rectangle(this.graphRowHeaderRect.X, yPos, PIXEL_WIDTH, BASE_HEIGHT_MARGIN + (TEXT_HEIGHT * rowNum))));
            yPos += BASE_HEIGHT_MARGIN + (TEXT_HEIGHT * rowNum);
            
            temp = yPos;

            //データ領域
            xPos = graphColHeaderRect.X;
            yPos = currYPos;

            this.etc3Rect = new Rectangle(xPos, yPos, DISPLAY_DAY_COUNT * PIXEL_WIDTH, BASE_HEIGHT_MARGIN + (TEXT_HEIGHT * rowNum));

            for (int i = 0; i < DISPLAY_DAY_COUNT; i++)
            {
                key = i.ToString();

                if (!etc3ItemList.Contains(key))
                {
                    info = new ItemInfo("", ContentAlignment.MiddleCenter, new Rectangle(xPos, yPos, PIXEL_WIDTH, BASE_HEIGHT_MARGIN + (TEXT_HEIGHT * rowNum)));
                    etc3ItemList.Add(key, info);
                }
                xPos += PIXEL_WIDTH;
            }
            currYPos = temp;
        }

        public void SetEtc1Data(DataRow[] dTable)
        {

            string key = "";

            foreach (ItemInfo info in etc1ItemList.Values)
                info.Text = "";

            foreach (DataRow dtRow in dTable)
            {
                key = dtRow["diff"].ToString();

                try
                {
                    switch (dtRow["hangmog_gubun"].ToString())
                    {
                        case "O2":
                            key += "0" + dtRow["hangmog_seq"].ToString();
                            break;
                        case "SPO2":
                            key += "1" + dtRow["hangmog_seq"].ToString();
                            break;
                        case "BS":
                            key += "2" + dtRow["hangmog_seq"].ToString();
                            break;
                        case "SYO":
                            key += "3" + dtRow["hangmog_seq"].ToString();
                            break;
                    }
                    ((ItemInfo)this.etc1ItemList[key]).Text = dtRow["hangmog_value"].ToString();
                }
                catch (Exception xe)
                {
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show("Set SPO2 Data Error=" + xe.Message);
                }
            }

        }

        public void SetEtc2Data(DataRow[] dTable)
        {

            string key = "";

            foreach (ItemInfo info in etc2ItemList.Values)
                info.Text = "";

            foreach (DataRow dtRow in dTable)
            {
                key = dtRow["diff"].ToString();

                try
                {
                    switch (dtRow["hangmog_gubun"].ToString())
                    {
                        case "AS":
                            key += "01";
                            break;

                        case "AX":
                            key += "02";
                            break;

                        case "UT":
                            key += "11";
                            break;
                        case "UX":
                            key += "12";
                            break;
                        case "HEIGHT":
                            key += "21";
                            break;

                        case "WEIGHT":
                            key += "22";
                            break;
                    }   

                    ((ItemInfo)this.etc2ItemList[key]).Text = dtRow["hangmog_value"].ToString();
                }
                catch (Exception xe)
                {
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show("Set Urine Data Error=" + xe.Message);
                }
            }

        }

        public void SetEtc3Data(DataRow[] dTable)
        {

            string key = "";

            foreach (ItemInfo info in etc3ItemList.Values)
                info.Text = "";

            foreach (DataRow dtRow in dTable)
            {
                key = dtRow["diff"].ToString();

                try
                {
                    ((ItemInfo)this.etc3ItemList[key]).Text = dtRow["hangmog_value"].ToString();
                }
                catch (Exception xe)
                {
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show("Set Care Data Error=" + xe.Message);
                }
            }

        }


        #endregion

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
		{
			if (this.reDraw)
                Draw(e.Graphics);
            base.OnPaint(e);
		}
		//전체 그리기
		private void Draw(Graphics g)
		{  
			//Line Draw
			this.DrawLine(g);

			//각 영역별로 그리기
			//RowHeader 그리기
			if (g.IsVisible(this.graphRowHeaderRect))
			{
				foreach (ItemInfo info in this.rowHeaderItemList)
				{
					info.Draw(g);
					if (info.Childs.Count > 0)
					{
						foreach (ItemInfo childInfo in info.Childs)
							childInfo.Draw(g);
					}
				}
			}

			//ColHeader 그리기
			if (g.IsVisible(this.graphColHeaderRect))
			{
				foreach (ItemInfo info in this.colHeaderItemList.Values)
				{
					info.Draw(g);
					if (info.Childs.Count > 0)
					{
						foreach (ItemInfo childInfo in info.Childs)
							childInfo.Draw(g);
					}
				}
			}

			//Graph Item 그리기 (그래프 그리기)
			if (g.IsVisible(this.graphRect))
			{
				DrawLineGraph(g);
			}

            //2012.01.21 woo
            if (g.IsVisible(this.nur1122Rect))
            {
                foreach (ItemInfo info in this.nur1122HeaderList)
                    info.Draw(g);
                foreach (ItemInfo info in this.nur1122ItemList.Values)
                    info.Draw(g);
                foreach (ItemInfo info in this.nur1122HeaderItemList)
                    info.Draw(g);
            }
            if (g.IsVisible(this.nur1122ItemRect))
            {
                foreach (ItemInfo info in this.nur1122HeaderItemList)
                    info.Draw(g);
            }


            //산소, spo2, 처치
            if (g.IsVisible(this.etc1Rect))
            {
                foreach (ItemInfo info in this.etc1HeaderItemList)
                {
                    info.Draw(g);
                }
                foreach (ItemInfo info in this.etc1ItemList.Values)
                {
                    info.Draw(g);
                }
            }

            // 식사영역
            if (g.IsVisible(this.foodRect))
			{
                foreach (ItemInfo info in this.foodHeaderItemList)
                {
                    info.Draw(g);
                    if (info.Childs.Count > 0)
                    {
                        foreach (ItemInfo childInfo in info.Childs)
                            childInfo.Draw(g);
                    }
                }

				foreach (ItemInfo info in this.foodItemList.Values)
				{
					info.Draw(g);
					if (info.Childs.Count > 0)
					{
						foreach (ItemInfo childInfo in info.Childs)
							childInfo.Draw(g);
					}
				}
			}

            //변, 뇨, 신장, 체중
            if (g.IsVisible(this.etc2Rect))
            {
                foreach (ItemInfo info in this.etc2HeaderItemList)
                {
                    info.Draw(g);
                }
                foreach (ItemInfo info in this.etc2ItemList.Values)
                {
                    info.Draw(g);
                }
            }

            //케어
            if (g.IsVisible(this.etc3Rect))
            {
                foreach (ItemInfo info in this.etc3HeaderItemList)
                {
                    info.Draw(g);
                }
                foreach (ItemInfo info in this.etc3ItemList.Values)
                {
                    info.Draw(g);
                }
            }

			//IN,OUT 영역
            if (g.IsVisible(this.inOutRect))
            {
                //IN, OUT Header
                foreach (ItemInfo info in this.inoutHeaderItemList)
                    info.Draw(g);
                //IN,OUT Item
                foreach (ItemInfo info in this.inoutItemList.Values)
                    info.Draw(g);

            }



            //IN,OUT total 영역
            if (g.IsVisible(this.inOutTotalRect))
            {
                //IN,OUT total
                foreach (ItemInfo info in this.inoutTotalItemList.Values)
                {
                    info.Draw(g);
                }
            }

			//Border Draw
			Rectangle borderRect = new Rectangle(graphRowHeaderRect.X, graphRowHeaderRect.Y, ClientRectangle.Width, ClientRectangle.Height);
			ControlPaint.DrawBorder(g, borderRect, pen1.Color, ButtonBorderStyle.Solid);



		}

		//그래프 선, 이미지 그리기
		private void DrawLineGraph(Graphics g)
		{
            Point stPt = Point.Empty;
            Rectangle rect = Rectangle.Empty;
            int imgWidth = 8, imgHeight = 8; //, stringWidth = 35, stringHeight = 16;
            int index = 0;
            string s = string.Empty;
            SolidBrush drawBrush = new SolidBrush(Color.Black);


			//if ((this.BPHPointList.Count < 1) && (this.BPLPointList.Count < 1) && (this.PPointList.Count < 1) && (this.TPointList.Count < 1) && (this.Spo2PointList.Count < 1)) return;
            
            // && (this.BSPointList.Count <1)
			// 20070421 - Modify Line
			if ((this.BPHPointList.Count < 1) && (this.BPLPointList.Count < 1) && (this.PPointList.Count < 1) && 
                (this.TPointList.Count < 1)  && (this.RPointList.Count < 1)) 
                return;




             
            //BP High Draw
			foreach (Point pt in this.BPHPointList)
			{
				if (index == 0)
				{
					stPt = pt;
				}
				else
				{
					// g.DrawLine(BPHPen, stPt, pt);  -> 20130314
					stPt = pt;
				}
				//해당 Point에 Image Draw
				rect = new Rectangle(pt.X - 4, pt.Y - 9, imgWidth, imgHeight);
                //drawBrush = new SolidBrush(Color.Violet);
                drawBrush = new SolidBrush(Color.Black);
                DrawImage(g, this.bphImage, rect, ContentAlignment.BottomCenter, this.bphValueList[index].ToString());
                //if (index == 0)
                //{
                //    s = "BPH";
                //    rect = new Rectangle(pt.X - 35, pt.Y - 8, stringWidth, stringHeight);
                //    DrawString(g, s, rect, drawBrush);
                //}
				index++;
			}
            //if (index != 0)
            //{
            //     s = "BPH";
            //     rect = new Rectangle(stPt.X + 4, stPt.Y - 8, stringWidth, stringHeight);
            //        DrawString(g, s, rect, drawBrush);
            //}
			index = 0;
			foreach (Point pt in this.BPLPointList)
			{
				if (index == 0)
				{
					stPt = pt;
				}
				else
				{
                    //g.DrawLine(BPLPen, stPt, pt); -> 20130314
					stPt = pt;
				}
				//해당 Point에 Image Draw(Violet)
                rect = new Rectangle(pt.X - 4, pt.Y+1, imgWidth, imgHeight);
                drawBrush = new SolidBrush(Color.Orange);
                DrawImage(g, this.bplImage, rect, ContentAlignment.TopCenter, this.bplValueList[index].ToString());
                //if (index == 0)
                //{
                //    s = "BPL";
                //    rect = new Rectangle(pt.X - 35, pt.Y - 8, stringWidth, stringHeight);
                //    DrawString(g, s, rect, drawBrush);
                //}

				index++;
			}
            //if (index != 0)
            //{
            //    s = "BPL";
            //    rect = new Rectangle(stPt.X + 4, stPt.Y - 8, stringWidth, stringHeight);
            //    DrawString(g, s, rect, drawBrush);
            //}

			index = 0;


            //고혈압과 저혈압 라인 연결 부분 2012.02.16 woo 
            //필요 없어짐 -> 20130314
            /*
            for (int i = 0; i < this.BPLPointList.Count; i++)
            {
                Point ptH = (Point)this.BPHPointList[i];
                Point ptL = (Point)this.BPLPointList[i];
                g.DrawLine(BPLPen, ptH, ptL);

            }
            */


            foreach (Point pt in this.PPointList)
			{
				if (index == 0)
				{
					stPt = pt;
				}
				else
				{
					g.DrawLine(PPen, stPt, pt);
					stPt = pt;
				}
				//해당 Point에 Image Draw(Green)
                rect = new Rectangle(pt.X - 4, pt.Y - 4, imgWidth, imgHeight);
                drawBrush = new SolidBrush(Color.Red);
                DrawImage(g, this.pImage, rect, ContentAlignment.BottomCenter, this.pValueList[index].ToString());
                //if (index == 0)
                //{
                //    s = "PR";
                //    rect = new Rectangle(pt.X - 30, pt.Y - 8, stringWidth, stringHeight);
                //    DrawString(g, s, rect, drawBrush);
                //}

				index++;
			}
            //if (index != 0)
            //{
            //    s = "PR";
            //    rect = new Rectangle(stPt.X + 4, stPt.Y - 8, stringWidth, stringHeight);
            //    DrawString(g, s, rect, drawBrush);
            //}

			index = 0;
			foreach (Point pt in this.TPointList)
			{
				if (index == 0)
				{
					stPt = pt;
				}
				else
				{
					g.DrawLine(TPen, stPt, pt);
					stPt = pt;
				}
				//해당 Point에 Image Draw(Blue)
                rect = new Rectangle(pt.X -4, pt.Y - 4, imgWidth, imgHeight);
                drawBrush = new SolidBrush(Color.Blue);
                DrawImage(g, this.tImage, rect, ContentAlignment.TopCenter, this.tValueList[index].ToString());
                //if (index == 0)
                //{
                //    s = "T";
                //    rect = new Rectangle(pt.X - 25, pt.Y - 8, stringWidth, stringHeight);
                //    DrawString(g, s, rect, drawBrush);
                //}

				index++;
			}
            //if (index != 0)
            //{
            //    s = "T";
            //    rect = new Rectangle(stPt.X + 4, stPt.Y - 8, stringWidth, stringHeight);
            //    DrawString(g, s, rect, drawBrush);
            //}

			//index = 0;
            //foreach (Point pt in this.Spo2PointList)
            //{
            //    if (index == 0)
            //    {
            //        stPt = pt;
            //    }
            //    else
            //    {
            //        g.DrawLine(Spo2Pen, stPt, pt);
            //        stPt = pt;
            //    }
            //    //해당 Point에 Image Draw(Blue)
            //    rect = new Rectangle(pt.X - 4, pt.Y - 4, imgWidth, imgHeight);
            //    drawBrush = new SolidBrush(Color.Black);
            //    DrawImage(g, this.spo2Image, rect, ContentAlignment.TopCenter, this.spo2ValueList[index].ToString());
            //    //if (index == 0)
            //    //{
            //    //    s = "spo2";
            //    //    rect = new Rectangle(pt.X - 40, pt.Y - 8, stringWidth, stringHeight);
            //    //    DrawString(g, s, rect, drawBrush);
            //    //}

            //    index++;
            //}
            //if (index != 0)
            //{
            //    s = "spo2";
            //    rect = new Rectangle(stPt.X + 4, stPt.Y - 8, stringWidth, stringHeight);
            //    DrawString(g, s, rect, drawBrush);
            //}

			// 20070412 - Add Start
			index = 0;
			foreach (Point pt in this.RPointList)
			{
				if (index == 0)
				{
					stPt = pt;
				}
				else
				{
					g.DrawLine(RPen, stPt, pt);
					stPt = pt;
				}
				//해당 Point에 Image Draw(Blue)
                rect = new Rectangle(pt.X -4, pt.Y - 4, imgWidth, imgHeight);
                drawBrush = new SolidBrush(Color.Green);
                DrawImage(g, this.rImage, rect, ContentAlignment.TopCenter, this.rValueList[index].ToString());
                //if (index == 0)
                //{
                //    s = "U";
                //    rect = new Rectangle(pt.X -25, pt.Y - 8, stringWidth, stringHeight);
                //    DrawString(g, s, rect, drawBrush);
                //}

				index++;
			}
            //if (index != 0)
            //{
            //    s = "U";
            //    rect = new Rectangle(stPt.X + 4, stPt.Y - 8, stringWidth, stringHeight);
            //    DrawString(g, s, rect, drawBrush);
            //}

			// 20070412 - Add End

            // 20110412 - Add Start
            index = 0;
            //foreach (Point pt in this.BSPointList)
            //{
            //    if (index == 0)
            //    {
            //        stPt = pt;
            //    }
            //    else
            //    {
            //        g.DrawLine(BSPen, stPt, pt);
            //        stPt = pt;
            //    }
            //    //해당 Point에 Image Draw(Blue)
            //    rect = new Rectangle(pt.X - 4, pt.Y - 4, imgWidth, imgHeight);
            //    drawBrush = new SolidBrush(Color.Olive);
            //    DrawImage(g, this.bsImage, rect, ContentAlignment.TopCenter, this.bsValueList[index].ToString());
            //    //if (index == 0)
            //    //{
            //    //    s = "BS";
            //    //    rect = new Rectangle(pt.X - 40, pt.Y - 8, stringWidth, stringHeight);
            //    //    DrawString(g, s, rect, drawBrush);
            //    //}

            //    index++;
            //}
            //if (index != 0)
            //{
            //    s = "BS";
            //    rect = new Rectangle(stPt.X + 4, stPt.Y - 8, stringWidth, stringHeight);
            //    DrawString(g, s, rect, drawBrush);
            //}

            // 20110412 - Add End
		}

        private void DrawString(Graphics g, string s, Rectangle rect, SolidBrush drawBrush)
        {
            Font font = new Font("Arial",10);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            g.DrawString(s, font, drawBrush, rect, drawFormat);
        }

        /// <summary>
        /// 그래프의 각 포인터에 마우스커서를 가져가면 툴팁으로 그 수치값을 볼 수 있다. 2012.01.23 woo
        /// </summary>
        ToolTip toolTip = new ToolTip();
		private void DrawImage(Graphics g, Image image, Rectangle rect, ContentAlignment align, string value)
		{
			PointF ptImage = DrawHelper.GetObjAlignment(align,rect.Left, rect.Top, rect.Width, rect.Height, image.Width, image.Height);
            
			RectangleF imageRect = rect;
			imageRect.Intersect(new RectangleF(ptImage, image.PhysicalDimension));
            g.DrawImage(image, Rectangle.Truncate(imageRect));  //프린트할 때 이미지 나오게 하기위해 먼저 그림을 하나 그리고
            //ToolTop을 보여주기 위해 PictureBox 에 넣어서 추가 해 주고~
            PictureBox pb = new PictureBox();
            pb.BackgroundImage = image;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            pb.Size = new Size(rect.Width, rect.Height);
            pb.Location = new Point(rect.X, rect.Y);
            pb.BringToFront();
            toolTip.SetToolTip(pb, value);
            this.Controls.Add(pb);

		}

		#endregion

		#region Graph Print 관련
		public void SetHeaderText(string text)
		{
			this.headerText = text;
		}
		private void OnPrintDocPrintPage(object sender, PrintPageEventArgs e)
		{
			//Header Draw
			try
			{
				this.SuspendLayout();
				//Margin을 설정하여 여백을 줌
				//가로로 출력하고 A4용지이면 80,80을 주고 Header Text를 설정하면 중앙에 위치함
				//SetMargin(5,40);
				//SetMargin(80,40);


				//Header Text Draw
                if (this.headerText != "")
                {
                    //Rectangle rect = new Rectangle(80, 40, this.Width, 40);
                    Rectangle rect = new Rectangle(this.Width - 600, this.Height -40, 600, 40);
                    e.Graphics.DrawString(headerText, headerTextFont, Brushes.Black, rect, this.textFormat);
                }
                Draw(e.Graphics);
			}
			finally
			{
				//Margin을 복구
				//SetMargin(-5,-40);
				this.ResumeLayout(true);
			}
            
		}
		public void Print()
		{
            try
            {
                this.printDoc.Print();
            }
            catch (Exception xe)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("印刷エラー[" + xe.Message + "]");
            }

		}
		#endregion

		#region SetMargin(int x, int y)
		private void SetMargin(int x, int y)
		{
			//각 영역 Rect 고려하여 다시 설정
			graphColHeaderRect = new Rectangle(graphColHeaderRect.Left + x, graphColHeaderRect.Top + y, graphColHeaderRect.Width, graphColHeaderRect.Height);
			graphRect = new Rectangle(graphRect.Left + x, graphRect.Top + y, graphRect.Width, graphRect.Height);
			graphRowHeaderRect = new Rectangle(graphRowHeaderRect.Left + x, graphRowHeaderRect.Top + y, graphRowHeaderRect.Width, graphRowHeaderRect.Height);
            //2012.01.20 woo
            nur1122Rect = new Rectangle(nur1122Rect.Left + x, nur1122Rect.Top + y, nur1122Rect.Width, nur1122Rect.Height);

            //inOutRect = new Rectangle(inOutRect.Left + x, inOutRect.Top + y, inOutRect.Width, inOutRect.Height);
			//inOutTotalRect = new Rectangle(inOutTotalRect.Left + x, inOutTotalRect.Top + y, inOutTotalRect.Width, inOutTotalRect.Height);
            foodRect = new Rectangle(foodRect.Left + x, foodRect.Top + y, foodRect.Width, foodRect.Height);			

			//Graph 좌표 Point 수정
			ArrayList ptList = new ArrayList();
			foreach (Point pt in this.BPHPointList)
				ptList.Add(pt);
			this.BPHPointList.Clear();
			foreach (Point pt in ptList)
				this.BPHPointList.Add(new Point(pt.X + x, pt.Y + y));

			ptList.Clear();
			foreach (Point pt in this.BPLPointList)
				ptList.Add(pt);
			this.BPLPointList.Clear();
			foreach (Point pt in ptList)
				this.BPLPointList.Add(new Point(pt.X + x, pt.Y + y));

			ptList.Clear();
			foreach (Point pt in this.PPointList)
				ptList.Add(pt);
			this.PPointList.Clear();
			foreach (Point pt in ptList)
				this.PPointList.Add(new Point(pt.X + x, pt.Y + y));

			ptList.Clear();
			foreach (Point pt in this.TPointList)
				ptList.Add(pt);
			this.TPointList.Clear();
			foreach (Point pt in ptList)
				this.TPointList.Add(new Point(pt.X + x, pt.Y + y));

            //ptList.Clear();
            //foreach (Point pt in this.Spo2PointList)
            //    ptList.Add(pt);
            //this.Spo2PointList.Clear();
            //foreach (Point pt in ptList)
            //    this.Spo2PointList.Add(new Point(pt.X + x, pt.Y + y));

			// 20070412 - Add Start
			ptList.Clear();
			foreach (Point pt in this.RPointList)
				ptList.Add(pt);
			this.RPointList.Clear();
			foreach (Point pt in ptList)
				this.RPointList.Add(new Point(pt.X + x, pt.Y + y));
			// 20070412 - Add End
            
            // 20110412 - Add Start
            //ptList.Clear();
            //foreach (Point pt in this.BSPointList)
            //    ptList.Add(pt);
            //this.BSPointList.Clear();
            //foreach (Point pt in ptList)
            //    this.BSPointList.Add(new Point(pt.X + x, pt.Y + y));
            // 20110412 - Add End

			//각 ItemList의 좌표 수정
			//rowHeaderItemList, colHeaderItemList, foodItemList, inoutHeaderItemList
			foreach (ItemInfo info in this.rowHeaderItemList)
			{
				info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
				if (info.Childs.Count > 0)
				{
					foreach (ItemInfo cInfo in info.Childs)
						cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
				}
			}
			foreach (ItemInfo info in this.colHeaderItemList.Values)
			{
				info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
				if (info.Childs.Count > 0)
				{
					foreach (ItemInfo cInfo in info.Childs)
						cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
				}
			}
			foreach (ItemInfo info in this.foodItemList.Values)
			{
				info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
				if (info.Childs.Count > 0)
				{
					foreach (ItemInfo cInfo in info.Childs)
						cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
				}
			}
			foreach (ItemInfo info in this.inoutHeaderItemList)
			{
				info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
				if (info.Childs.Count > 0)
				{
					foreach (ItemInfo cInfo in info.Childs)
						cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
				}
			}
			foreach (ItemInfo info in this.inoutItemList.Values)
			{
				info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
				if (info.Childs.Count > 0)
				{
					foreach (ItemInfo cInfo in info.Childs)
						cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
				}
			}
			foreach (ItemInfo info in this.inoutTotalItemList.Values)
			{
				info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
				if (info.Childs.Count > 0)
				{
					foreach (ItemInfo cInfo in info.Childs)
						cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
				}
			}

            //2012.01.25
            foreach (ItemInfo info in this.nur1122HeaderList)
            {
                info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
                if (info.Childs.Count > 0)
                {
                    foreach (ItemInfo cInfo in info.Childs)
                        cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
                }
            }
            //

            foreach (ItemInfo info in this.nur1122HeaderItemList)
            {
                info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
                if (info.Childs.Count > 0)
                {
                    foreach (ItemInfo cInfo in info.Childs)
                        cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
                }
            }
            foreach (ItemInfo info in this.nur1122ItemList.Values)
            {
                info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
                if (info.Childs.Count > 0)
                {
                    foreach (ItemInfo cInfo in info.Childs)
                        cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
                }

            }

            foreach (ItemInfo info in this.etc1HeaderItemList)
            {
                info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
                if (info.Childs.Count > 0)
                {
                    foreach (ItemInfo cInfo in info.Childs)
                        cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
                }

            }

            foreach (ItemInfo info in this.etc1ItemList.Values)
            {
                info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
                if (info.Childs.Count > 0)
                {
                    foreach (ItemInfo cInfo in info.Childs)
                        cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
                }

            }

            foreach (ItemInfo info in this.etc2HeaderItemList)
            {
                info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
                if (info.Childs.Count > 0)
                {
                    foreach (ItemInfo cInfo in info.Childs)
                        cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
                }

            }

            foreach (ItemInfo info in this.etc2ItemList.Values)
            {
                info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
                if (info.Childs.Count > 0)
                {
                    foreach (ItemInfo cInfo in info.Childs)
                        cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
                }

            }

            foreach (ItemInfo info in this.etc3HeaderItemList)
            {
                info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
                if (info.Childs.Count > 0)
                {
                    foreach (ItemInfo cInfo in info.Childs)
                        cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
                }

            }

            foreach (ItemInfo info in this.etc3ItemList.Values)
            {
                info.Rect = new Rectangle(info.Rect.X + x, info.Rect.Y + y, info.Rect.Width, info.Rect.Height);
                if (info.Childs.Count > 0)
                {
                    foreach (ItemInfo cInfo in info.Childs)
                        cInfo.Rect = new Rectangle(cInfo.Rect.X + x, cInfo.Rect.Y + y, cInfo.Rect.Width, cInfo.Rect.Height);
                }

            }


		}
		#endregion
	}

	#region IOTypeItem
	internal class IOTypeItem
	{
		public string IOType  = "";  //A0,A1...
		public string TypeName = "";  //Type의 Name
		public IOTypeItem(string ioType, string typeName)
		{
			this.IOType = ioType;
			this.TypeName = typeName;
		}
	}
	#endregion

	#region ItemInfo
	internal class ItemInfo
	{
		public string Name = "";
		public string Text = "";
		public ContentAlignment TextAlign = ContentAlignment.MiddleCenter;
		public Color TextColor = Color.FromArgb(3,57,70);
		public Image Image = null;
		public ContentAlignment ImageAlign = ContentAlignment.MiddleCenter;
		public Rectangle Rect = Rectangle.Empty;
		public Font TextFont = new Font("MS UI Gothic", 9f);
		public ArrayList Childs = new ArrayList();  //Child Item List
        
		public ItemInfo(string text)
		{
			this.Text = text;
		}
		public ItemInfo(string text, ContentAlignment textAlign, Rectangle rect)
		{
			this.Text = text;
			this.TextAlign = textAlign;
			this.Rect = rect;
		}
		public ItemInfo(string text, ContentAlignment textAlign, Font textFont, Rectangle rect)
		{
			this.Text = text;
			this.TextAlign = textAlign;
			this.TextFont = textFont;
			this.Rect = rect;
		}
		public ItemInfo(string text, ContentAlignment textAlign, Image image, ContentAlignment imageAlign, Rectangle rect)
		{
			this.Text = text;
			this.TextAlign = textAlign;
			this.Image = image;
			this.ImageAlign = imageAlign;
			this.Rect = rect;
		}


		public void Draw(Graphics g)
		{
			if (this.Text == "") return;

			//Image Draw
			if (this.Image != null)
			{
				PointF ptImage = DrawHelper.GetObjAlignment(ImageAlign ,Rect.Left, Rect.Top, Rect.Width, Rect.Height, Image.Width, Image.Height);
				RectangleF imageRect = Rect;
				imageRect.Intersect(new RectangleF(ptImage, Image.PhysicalDimension));
				//Truncate the Rectangle for appreximation problem
				g.DrawImage(Image ,Rectangle.Truncate(imageRect));
			}
			
            //Text Draw

			using (Brush br = new SolidBrush(TextColor))
			{	
				SizeF fontSize = g.MeasureString(Text, TextFont);
				g.DrawString(Text, TextFont, br, 
					DrawHelper.GetObjAlignment(TextAlign, Rect.X, Rect.Y, Rect.Width, Rect.Height, fontSize.Width, fontSize.Height));
			}
		}
	}
	#endregion
}