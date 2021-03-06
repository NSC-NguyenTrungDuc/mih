using System;
using System.Text;
using System.IO;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Diagnostics;
using System.Reflection;

namespace IHIS.Framework
{
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(IHIS.Framework.XDWWorker), "Images.XDWWorker.bmp")]
	public class XDWWorker : Component, IHIS.Framework.IPrintWorker
	{
		#region Fields
		private DataTable	sourceTable = null;
		private string libraryList = "";
		private string dataWindowObject = "";
		private XDWWorkerTextCollection textArgs = new XDWWorkerTextCollection();  //DW의 Control에 Text설정할 데이타 관리
		private XDWWorkerTextCollection imageArgs = new XDWWorkerTextCollection(); //DW의 Computed Field Control의 Image 설정 관리
		private XDWWorkerChildSourceCollection childSources = new XDWWorkerChildSourceCollection();
		private int		copies = 1;  //출력장수
		private bool	isLandScape = true;  //가로, 세로 출력
		private int		magnification = 100;  //출력배율 100%
		private	bool	isNestedReport  = false;  //NestedReport 인지 여부
		private DataWindowPaperSize paperSize = DataWindowPaperSize.DefaultSize;
		private PrintProcessType   processType   = PrintProcessType.Popup;
		private XDataWindow dwViewer = null;  //Viewer로 출력시 지정한 DataWindow
		private bool collate = false;  //한부씩 인쇄여부
		private bool isPreviewStatusPopup = false; //Popup으로 띄울때 미리보기상태로 띄울지 여부
		private string printerName = "";
		#endregion
		
		#region Properties
		[Category("출력정보"),
		DefaultValue(false),
		Browsable(true),
		Description("출력시 한부씩 인쇄할지 여부를 지정합니다.")]
		public bool Collate
		{
			get { return collate;}
			set { collate = value;}
		}
		[Category("출력정보"),
		DefaultValue(PrintProcessType.Popup),
		Browsable(true),
		Description("출력시 프린트 경로설정입니다.(Popup은 출력창으로, Viewer는 지정한 DWViewer를 출력)")]
		public PrintProcessType ProcessType
		{
			get { return processType;}
			set { processType = value;}
		}
		[Category("출력정보"),
		DefaultValue(null),
		Browsable(true),
		Description("Viewer로 출력시에 출력할 DataWindow를 지정합니다.")]
		public XDataWindow DWViewer
		{
			get { return dwViewer;}
			set { dwViewer = value;}
		}
		[Category("출력정보"),
		DefaultValue(null),
		Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(UITypeEditor)),
		Description("출력할 DataWindow의 LibraryList를 지정합니다.(PopUp으로 출력시 실행시 참조할 pbd 파일의 위치로 지정, Viewer로 출력시는 Viewer에 지정된 속성사용)")]
		public string LibraryList
		{
			get { return libraryList;}
			set { libraryList = value;}
		}
		[Category("출력정보"),
		DefaultValue(""),
		Description("PopUp으로 출력시 DataWindowObject를 지정합니다.(Viewer로 출력시는 Viewer에 지정된 속성사용)")]
		public string DataWindowObject
		{
			get { return dataWindowObject;}
			set { dataWindowObject = value;}
		}
		[Category("출력정보"),
		DefaultValue(DataWindowPaperSize.DefaultSize),
		Description("출력용지를 지정합니다.")]
		public DataWindowPaperSize PaperSize
		{
			get { return paperSize;}
			set { paperSize = value;}
		}
		[Category("출력정보"),
		DefaultValue(1),
		Description("출력할 장수(매수)를 지정합니다.")]
		public int Copies
		{
			get { return copies;}
			set { copies = Math.Max(1, value);}
		}
		[Category("출력정보"),
		DefaultValue(true),
		Description("가로방향으로 출력할지 여부를 지정합니다.")]
		public bool IsLandScape
		{
			get { return isLandScape;}
			set { isLandScape = value;}
		}
		[Category("출력정보"),
		DefaultValue(false),
		Description("지정한 Report가 Nested Report인지 여부를 지정합니다.")]
		public bool IsNestedReport
		{
			get { return isNestedReport;}
			set { isNestedReport = value;}
		}
		[Category("출력정보"),
		DefaultValue(100),
		Description("출력 배율을 지정합니다.")]
		public int Magnification
		{
			get { return magnification;}
			set { magnification = Math.Max(50, Math.Min(200,value));}  //최소 50 - 최대200
		}
		[Category("출력정보"),
		DefaultValue(false),
		Description("Popup으로 출력시 미리보기상태로 출력창을 띄울지 여부를 지정합니다.")]
		public bool IsPreviewStatusPopup
		{
			get { return isPreviewStatusPopup;}
			set { isPreviewStatusPopup = value;}
		}
		[Browsable(false)]
		[Category("출력정보"),
		DefaultValue(null),
		Description("DataWindow의 데이타를 채울 DataTable을 지정합니다.")]
		public DataTable SourceTable
		{
			get { return sourceTable;}
			set { sourceTable = value;}
		}
		[Browsable(false)]
		[Category("출력정보"),
		DefaultValue(""),
		Description("출력 Printer를 지정하여 출력시에 Printer명을 지정합니다.")]
		public string PrinterName
		{
			get { return printerName;}
			set { printerName = value;}
		}
		/// <summary>
		/// DW의 Text를 동적으로 할당할때 데이타를 담을 Collection (PrintStart에서 주로 설정)
		/// </summary>
		[Browsable(false)]
		public XDWWorkerTextCollection TextArgs
		{
			get { return this.textArgs;}
		}
		/// <summary>
		/// DW의 Computed Field의 Image를 동적으로 할당할때 데이타를 담을 Collection (PrintStart에서 주로 설정)
		/// </summary>
		[Browsable(false)]
		public XDWWorkerTextCollection ImageArgs
		{
			get { return this.imageArgs;}
		}
		/// <summary>
		/// NestedReport일때 Child의 DataSource를 관리하는 XDWWorkerChildSource를 관리하는 Collection
		/// </summary>
		[Browsable(false)]
		public XDWWorkerChildSourceCollection ChildSources
		{
			get { return this.childSources;}
		}
		#endregion

		#region Events
		// Events
		[Description("Print 시작할때 발생합니다.")]
		public event CancelEventHandler PrintStart;
		[Description("Print 완료후에 발생합니다.")]
		public event PrintEndEventHandler PrintEnd;
		#endregion

		#region 생성자
		public XDWWorker()
		{
		}
		#endregion

		#region Preview (XPrintScreen에서 미리보기 버튼을 누를때 사용 , Print와 동일한 Logic이며 Print만 하지 않음
		internal bool Preview()
		{
			return PrintSub(false);
		}
		#endregion

		#region Print
		public bool Print()
		{
			return PrintSub(true);
		}
		private bool PrintSub(bool callPrint)
		{
			DateTime dt = DateTime.Now;
			string title = (NetInfo.Language == LangMode.Ko ? "리포트 출력" : "レポート印刷");
			string msg = "";
			//Viewer로 출력시 DataWindow지정여부 확인
			if ((this.processType == PrintProcessType.Viewer) && (this.dwViewer == null))
			{
				msg = (NetInfo.Language == LangMode.Ko ? "XDWWorker::Print DWViewer가 지정되지 않았습니다."
					:"XDWWorker::Print DWViewerが指定されていません。");
				XMessageBox.Show(msg, title);
				return false;
			}
			//Viewer로 출력시는 Viewer에 지정된 LibraryList, DataWindowObject 속성확인
			if (this.processType == PrintProcessType.Viewer)
			{
				//libraryList, dataWindowObject, sourceLayout, sourceTable 지정여부 확인
				if (this.dwViewer.LibraryList.Trim() == "")
				{
					msg = (NetInfo.Language == LangMode.Ko ? "XDWWorker::Print LibraryList가 지정되지 않았습니다."
						:"XDWWorker::Print LibraryListが指定されていません。");
					XMessageBox.Show(msg, title);
					return false;
				}
				if (this.dwViewer.DataWindowObject.Trim() == "")
				{
					msg = (NetInfo.Language == LangMode.Ko ? "XDWWorker::Print DataWindowObject가 지정되지 않았습니다."
						:"XDWWorker::Print DataWindowObjectが指定されていません。");
					XMessageBox.Show(msg, title);
					return false;
				}
			}
			else
			{
				//libraryList, dataWindowObject, sourceLayout, sourceTable 지정여부 확인
				if (this.libraryList.Trim() == "")
				{
					msg = (NetInfo.Language == LangMode.Ko ? "XDWWorker::Print LibraryList가 지정되지 않았습니다."
						:"XDWWorker::Print LibraryListが指定されていません。");
					XMessageBox.Show(msg, title);
					return false;
				}
				if (this.dataWindowObject.Trim() == "")
				{
					msg = (NetInfo.Language == LangMode.Ko ? "XDWWorker::Print DataWindowObject가 지정되지 않았습니다."
						:"XDWWorker::Print DataWindowObjectが指定されていません。");
					XMessageBox.Show(msg, title);
					return false;
				}
			}

			//PrintStart Event Call
			CancelEventArgs xe = new CancelEventArgs(false);
			OnPrintStart(xe);
			if (xe.Cancel) return false;  //출력하지 않음


			//NestedReport이면 ChildDWSources를 지정해야 하고, 아니면 sourceLayout, sourceTable 지정
			if (!this.isNestedReport)
			{
				//DataSource가 둘다 설정되지 않았으면 에러(설정순서는 Layout-> DataTable)
				if (this.sourceTable == null)
				{
					msg = (NetInfo.Language == LangMode.Ko ? "XDWWorker::Print SourceTable이 지정되지 않았습니다."
						:"XDWWorker::Print SourceTableが指定されていません。");
					XMessageBox.Show(msg, title);
					return false;
				}
			}
			else   //ChildSources 지정여부 확인
			{
				if (this.childSources.Count < 1)
				{
					msg = (NetInfo.Language == LangMode.Ko ? "XDWWorker::Print ChildSources가 지정되지 않았습니다."
						:"XDWWorker::Print ChildSourcesが指定されていません。");
					XMessageBox.Show(msg, title);
					return false;
				}
			}
			try
			{
				//2006.04.21 프린터명 지정시 프린터명 확인후 DataWindow의 PrinterName SET
				if (this.printerName.Trim() != "")
				{
					bool isFound = false;
					foreach (string pName in PrinterSettings.InstalledPrinters)
					{
						if (pName == this.printerName.Trim())
						{
							isFound = true;
							break;
						}
					}
					if (!isFound)
					{
						msg = (NetInfo.Language == LangMode.Ko ? "XDWWorker::Print PrinterName[" + this.printerName + "]을 잘못지정하셨습니다."
							:"XDWWorker::Print プリンター名[" + this.printerName + "]の指定が間違いました。");
						XMessageBox.Show(msg, title);
						return false;
					}
				}

				//ProcessType에 따라 분기, Viewer Popup
				if ((this.processType == PrintProcessType.Popup) || (this.processType == PrintProcessType.Direct))
				{
					if (callPrint)
					{
						DataWindowForm dlg = new DataWindowForm(this);
						//Show Dialog
						dlg.ShowDialog(EnvironInfo.MdiForm);
						//PrintEnd Event Call
						OnPrintEnd(new PrintEndEventArgs(dlg.Result));
					}
				}
				else //Viewer
				{
					if (this.printerName.Trim() != "")
					{
						//Printer Name 설정
						dwViewer.PrintProperties.PrinterName = this.printerName.Trim();
					}

					//DataWindow 속성을 Worker의 속성으로 SET
					dwViewer.PrintProperties.PaperSize = (int) this.PaperSize;
					dwViewer.PrintProperties.Copies = this.Copies;
					dwViewer.PrintProperties.Scale = this.Magnification;
					if (this.IsLandScape)
						this.dwViewer.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Landscape;
					else
						this.dwViewer.PrintProperties.Orientation = Sybase.DataWindow.PrintProperties.PrintOrientation.Portrait;
					dwViewer.PrintProperties.Collate = this.Collate;

					//DataSource Fill 
					//1.NestedReport가 아니면 SourceLayout Fill -> DataSourceFill
					//2.NestedReport이면 ChildSources를 돌며 DataFill
					if (!this.IsNestedReport)
					{
						this.dwViewer.FillData(this.SourceTable);
					}
					else  //Nested
					{
						foreach (XDWWorkerChildSource item in this.ChildSources)
						{
							if (item.IsGroupedChild)  //Grouped Child
							{
								if (item.SourceTable != null)
									dwViewer.FillGroupedChildData(item.ChildName, item.SourceTable);
							}
							else
							{
								if (item.SourceTable != null)
									dwViewer.FillChildData(item.ChildName, item.SourceTable);
							}
						}
					}

					//TextArgs Set (DW의 Text 동적할당)
					//TextArgs 설정 (Text Object 잘못 지정시에는 에러로 처리하지 않고 Text만 안설정되게 Try,catch함
					//DataWindow에 있는 Object 목록 Get
					string setting = dwViewer.Describe("DataWindow.Objects");
					string modStr = "";
					foreach (XDWWorkerText item in this.TextArgs)
					{
						try
						{
							//"text_1.Text='Employee'"
							//Object 목록에 item.Name이 있으면 SET
							if (setting.IndexOf(item.Name) >= 0)
							{
								modStr = item.Name + ".Text='" + item.Data + "'";
								dwViewer.Modify(modStr);
							}
						}
						catch{}
					}

					//2006.03.15 기본 Footer Image 설정
					dwViewer.SetFooterImage();

					//2006.03.14 ImageArgs 설정(Computed Field Control의 이미지를 동적으로 할당)
					//설정시 에러발생시 에러를 발생시키지 않고 try-catch만 함
					foreach (XDWWorkerText item in this.ImageArgs)
					{
						try
						{
							//"computed_1.Expression='Bitmap("C:\IFC\AAA.gif"'"
							//파일이 존재하고 Object 목록에 item.Name이 있으면 SET
							if (File.Exists(item.Data) && (setting.IndexOf(item.Name) >= 0))
							{
								modStr = item.Name + ".Expression='Bitmap(\"" + item.Data + "\")'";
								dwViewer.Modify(modStr);
							}
						}
						catch{}
					}

					//Print (에러시 PrintError)
					if (callPrint)  // Print할 경우에만
					{
						try
						{
							dwViewer.Print();
							OnPrintEnd(new PrintEndEventArgs(PrintResult.PrintOK));
						}
						catch
						{
							OnPrintEnd(new PrintEndEventArgs(PrintResult.PrintError));
						}
					}

				}

			}
			catch(Exception e)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "출력 에러[" + e.Message + "]"
					: "印刷エラー[" + e.Message + "]");
				XMessageBox.Show(msg, title);
				return false;
			}

			return true;

			
		}
		#endregion

		#region Event Invoker
		protected virtual void OnPrintStart(CancelEventArgs e)
		{
			if (this.PrintStart != null)
				PrintStart(this, e);
		}
		protected virtual void OnPrintEnd(PrintEndEventArgs e)
		{
			if (this.PrintEnd != null)
				PrintEnd(this, e);
		}
		#endregion
	}

	#region XDWWorkerTextArgsCollection (DW의 Text를 설정할 데이타를 관리하는 Collection
	public class XDWWorkerText
	{
		private string name = "";
		private string data = "";

		public string Name
		{
			get { return name;}
		}
		public string Data
		{
			get { return data;}
			set { name = value;}
		}
		
		internal XDWWorkerText(string name, string data)
		{
			this.name = name;
			this.data = data;
		}
	}
	/// <summary>
	/// XDWWorkerTextCollection
	/// </summary>
	public class XDWWorkerTextCollection : CollectionBase
	{
		/// <summary>
		/// XDWWorkerTextCollection 생성자
		/// </summary>
		public XDWWorkerTextCollection()
		{
		}
		
		/// <summary>
		/// 지정한 Index에 있는 CommonItemCollection을 가져옵니다.
		/// </summary>
		public XDWWorkerText this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (XDWWorkerText)List[index];
			}
			
		}
		/// <summary>
		/// 지정한 Key에 있는 CommonItemCollection을 가져옵니다.
		/// </summary>
		public XDWWorkerText this[string key]
		{
			get
			{
				if (key == "") return null;
				foreach (XDWWorkerText item in this)
					if (item.Name == key) 
						return item;
				return null;
			}
		}

		/// <summary>
		/// XDWWorkerText 을 Collection의 끝에 추가합니다.
		/// </summary>
		/// <param name="item"> PreDataItem class</param>
		public void Add(string name, string data)
		{
			//이미 등록되어 있으면 data만 다시 설정
			foreach (XDWWorkerText pItem in List)
			{
				if (pItem.Name == name)
				{
					pItem.Data = data;
					return;
				}
					
			}
			XDWWorkerText item = new XDWWorkerText(name,data);
			List.Add(item);
		}
		/// <summary>
		/// 해당 Index의 XDWWorkerText을 제거합니다.
		/// </summary>
		/// <param name="index"></param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0)
			{
				throw (new IndexOutOfRangeException());
			}
			else
			{
				List.RemoveAt(index); 
			}
		}
		/// <summary>
		/// 해당 이름의 XDWWorkerText을 제거합니다.
		/// </summary>
		/// <param name="sqlID"> XDWWorkerText 이름 </param>
		public void Remove(string name)
		{
			for (int i = 0 ; i < List.Count ; i++)
			{
				XDWWorkerText pItem = (XDWWorkerText) List[i];
				if (pItem.Name == name)
					List.RemoveAt(i);
			}
		}

		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="item">컬렉션에서 찾을 XDWWorkerText입니다.</param>
		/// <returns>XDWWorkerText가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XDWWorkerText item)
		{
			return List.Contains(item);
		}
		/// <summary>
		/// 해당이름의 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="argName"></param>
		/// <returns> XDWWorkerText가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다. </returns>
		public bool Contains(string name)
		{
			foreach (XDWWorkerText item in List)
				if (item.Name == name)
					return true;
			return false;
		}
	}
	#endregion

	#region XDWWorkerChildSourceCollection (Nested DW의 Source를 설정할 데이타를 관리하는 Collection
	public class XDWWorkerChildSource
	{
		private string	childName = "";
		private bool	isGroupedChild = false; //Grouping된 Child인지여부(데이타 설정방법이 다름)
		private DataTable	sourceTable = null;

		public string ChildName
		{
			get { return childName;}
		}
		public bool IsGroupedChild
		{
			get { return isGroupedChild;}
			set { isGroupedChild = value;}
		}
		public DataTable SourceTable
		{
			get { return sourceTable;}
			set { sourceTable = value;}
		}
		
		public XDWWorkerChildSource(string childName)
		{
			this.childName = childName;
		}
		public XDWWorkerChildSource(string childName, bool isGroupedChild, DataTable sourceTable)
		{
			this.childName = childName;
			this.isGroupedChild = isGroupedChild;
			this.sourceTable = sourceTable;
		}
	}
	/// <summary>
	/// XDWWorkerChildSourceCollection
	/// </summary>
	public class XDWWorkerChildSourceCollection : CollectionBase
	{
		/// <summary>
		/// XDWWorkerChildSourceCollection 생성자
		/// </summary>
		public XDWWorkerChildSourceCollection()
		{
		}
		
		/// <summary>
		/// 지정한 Index에 있는 XDWWorkerChildSource을 가져옵니다.
		/// </summary>
		public XDWWorkerChildSource this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (XDWWorkerChildSource)List[index];
			}
			
		}
		/// <summary>
		/// 지정한 Key에 있는 CommonItemCollection을 가져옵니다.
		/// </summary>
		public XDWWorkerChildSource this[string key]
		{
			get
			{
				if (key == "") return null;
				foreach (XDWWorkerChildSource item in this)
					if (item.ChildName == key) 
						return item;
				return null;
			}
		}

		/// <summary>
		/// XDWWorkerChildSource 을 Collection의 끝에 추가합니다.
		/// </summary>
		public void Add(string childName, bool isGroupedChild, DataTable sourceTable)
		{
			//이미 등록되어 있으면 isGroupedChild, sourceLayout 변경만 다시 설정
			foreach (XDWWorkerChildSource pItem in List)
			{
				if (pItem.ChildName == childName)
				{
					pItem.IsGroupedChild = isGroupedChild;
					pItem.SourceTable = sourceTable;
					return;
				}
					
			}
			XDWWorkerChildSource item = new XDWWorkerChildSource(childName,isGroupedChild,sourceTable);
			List.Add(item);
		}
		/// <summary>
		/// 해당 Index의 XDWWorkerChildSource을 제거합니다.
		/// </summary>
		/// <param name="index"></param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0)
			{
				throw (new IndexOutOfRangeException());
			}
			else
			{
				List.RemoveAt(index); 
			}
		}
		/// <summary>
		/// 해당 이름의 XDWWorkerChildSource을 제거합니다.
		/// </summary>
		/// <param name="sqlID"> XDWWorkerChildSource 이름 </param>
		public void Remove(string childName)
		{
			for (int i = 0 ; i < List.Count ; i++)
			{
				XDWWorkerChildSource pItem = (XDWWorkerChildSource) List[i];
				if (pItem.ChildName == childName)
					List.RemoveAt(i);
			}
		}

		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="item">컬렉션에서 찾을 XDWWorkerChildSource입니다.</param>
		/// <returns>XDWWorkerChildSource가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XDWWorkerChildSource item)
		{
			return List.Contains(item);
		}
		/// <summary>
		/// 해당이름의 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="argName"></param>
		/// <returns> XDWWorkerChildSource가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다. </returns>
		public bool Contains(string childName)
		{
			foreach (XDWWorkerChildSource item in List)
				if (item.ChildName == childName)
					return true;
			return false;
		}
	}
	#endregion

	#region DataWindowPaperSize enum (DataWindow 출력시 출력용지 지정 Enum)
	public enum DataWindowPaperSize
	{
		DefaultSize = 0,	//0. Default paper size for printer
		Letter8 = 1,		//1. Letter 8 1/2 x 11 in
		LetterSmall8 = 2,	//2. LetterSmall 8 1/2 x 11 in
		Tabloid = 3,		//3. Tabloid 17 x 11 inches
		Ledger = 4,			//4. Ledger 17 x 11 in
		Legal8 = 5,			//5. Legal 8 1/2 x 14 in
		Statement5 = 6,		//6. Statement 5 1/2 x 8 1/2 in
		Executive7 = 7,		//7. Executive 7 1/4 x 10 1/2 in
		A3 = 8,				//8. A3 297 x 420 mm
		A4 = 9,				//9. A4 210 x 297 mm
		A4Small = 10,		//10. A4 small 210 x 297 mm
		A5 = 11,			//11. A5 148 x 210 mm
		B4 = 12				//12. B4 250 x 354 mm

	}
	#endregion

	#region enum
	/// <summary>
	/// PrintProcessType enum (Print 경로설정)
	/// </summary>
	[Serializable]
	public enum PrintProcessType
	{
		/// <summary>
		/// Dialog를 띄워 출력함
		/// </summary>
		Popup = 0,  // PrintDialog를 띄움
		/// <summary>
		/// Viewer를 통해 출력함
		/// </summary>
		Viewer,      // Dialog를 띄우지 않고 Viewer를 구동시킴
		/// <summary>
		/// Popup, Viewer가 없이 Direct로 출력처리(Direct는 Popup창을 띄운후에 바로 출력하고 Popup창을 닫음)
		/// </summary>
		Direct
	}
	/// <summary>
	/// PrintResult enum
	/// </summary>
	[Serializable]
	public enum PrintResult
	{
		/// <summary>
		/// Print 정상완료
		/// </summary>
		PrintOK = 0,  // 정상 Print
		/// <summary>
		/// Print 취소
		/// </summary>
		PrintCancel,  // Print 취소
		/// <summary>
		/// Print 에러발생
		/// </summary>
		PrintError    // Print Error
	}
	#endregion

	#region PrintEndEventHandler
	[Serializable]
	public delegate void PrintEndEventHandler(object sender, PrintEndEventArgs e);

	public class PrintEndEventArgs : EventArgs
	{
		PrintResult result;

		public PrintResult Result
		{
			get { return result; }
		}

		public PrintEndEventArgs(PrintResult result)
		{
			this.result = result;
		}
	}
	#endregion

}
