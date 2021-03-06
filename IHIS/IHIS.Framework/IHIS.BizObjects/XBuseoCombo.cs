using System;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design.Serialization;
using System.Security;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using IHIS.Framework.Properties;

namespace IHIS.Framework
{
	/// <summary>
	/// XBuseoCombo에 대한 요약 설명입니다.(진료과,병동 등 부서코드를 보여주는 Combo입니다.)
	/// </summary>
	[DefaultProperty("BuseoGubun")]
	[ToolboxBitmap(typeof(IHIS.Framework.XBuseoCombo), "Images.XBuseoCombo.bmp")]
	public class XBuseoCombo : IHIS.Framework.XComboBox, ISupportInitialize
	{
		#region Fields
		private BuseoType buseoGubun = BuseoType.Out;
		private bool   codeDisplay = false;
		private bool   isAppendAll = false;  //%.전체 추가여부
		#endregion

		#region Base Properties(Not Browse)
		//ImageList, ComboItems Not Browse
		[Browsable(false)]
		public override ImageList ImageList
		{
			get { return base.ImageList;}
			set { base.ImageList = value;}
		}
		[Browsable(false)]
		public override XComboItemCollection ComboItems
		{
			get
			{
				return base.ComboItems;
			}
		}
		#endregion

		#region Properties
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(false),
		Description("기준정보의 Code값을 Display할지 여부를 설정합니다.")]
		public bool CodeDisplay
		{
			get { return codeDisplay; }
			set { codeDisplay = value; }
		}
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(false),
		Description("전체(%)를 맨 앞에 추가할지 여부를 설정합니다.")]
		public bool IsAppendAll
		{
			get { return isAppendAll; }
			set { isAppendAll = value; }
		}
		[Browsable(true),Category("추가속성"),
		DefaultValue(BuseoType.Out),Description("부서콤보를 구성할 BuseoGubun을 지정합니다.")]
		public BuseoType BuseoGubun
		{
			get { return buseoGubun;}
			set { buseoGubun = value;}
		}
		#endregion

		#region 생성자
		public XBuseoCombo()
		{
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
			if (!this.DesignMode)
				this.InitializeCombo();
		}
		#endregion

		#region InitializeCombo
		private void InitializeCombo()
		{
			//DataSource 변경시에 SelectedIndexChanged Event Call하지 않음
			this.CallSelectedIndexChangedEvent = false;
			//변경시작전 DataSource Null
			this.DataSource = null;
			//기존 ComboItems Clear
			this.ComboItems.Clear();
			string displayItem = "";
			//전체포함이면 전체 SET */
			if (this.isAppendAll)
			{
                displayItem = (this.codeDisplay ? Resource.ComboAll1 : Resource.ComboAll);
				this.ComboItems.Add("%" , displayItem);
			}

			//기준정보 코드 조회하여 MultiLayout Return
			MultiLayout layList = BizCodeHelper.GetBuseoList(this.buseoGubun);

			//List로 ComboItems SET
			foreach (DataRow dtRow in layList.LayoutTable.Rows)
			{
				displayItem = (this.codeDisplay ? dtRow["Code"].ToString() + "." + dtRow["CodeName"].ToString()
					: dtRow["CodeName"].ToString());

				this.ComboItems.Add(dtRow["Code"].ToString(), displayItem);
			}

			//DataSource Refresh
			this.RefreshComboItems();
			//콤보가 구성되었으면 최초 SelectedIndex = 0
			if (this.ComboItems.Count > 0)
				this.SelectedIndex = 0;
			
			//Flag Clear
			this.CallSelectedIndexChangedEvent = true;
		}
		#endregion

		#region ChangeBuseoGubun(부서구분 변경)
		/// <summary>
		/// 부서구분 변경처리
		/// </summary>
		/// <param name="buseoGubun"></param>
		public void ChangeBuseoGubun(BuseoType buseoGubun)
		{
			if (this.buseoGubun != buseoGubun)
			{
				this.BuseoGubun = buseoGubun;
				this.InitializeCombo();
			}
		}
		#endregion
	}
}
