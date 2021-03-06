using System;
using System.Collections.Generic;
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

namespace IHIS.Framework
{
	/// <summary>
	/// XInfoCombo에 대한 요약 설명입니다.(기준정보를 Display하는 ComboBox입니다)
	/// </summary>
	[DefaultProperty("CodeType")]
	[ToolboxBitmap(typeof(IHIS.Framework.XInfoCombo), "Images.XInfoCombo.bmp")]
	public class XInfoCombo : IHIS.Framework.XComboBox, ISupportInitialize
	{
		#region Fields
		private string codeType = "";
		private bool   codeDisplay = false;
        private IList<object[]> dataList;
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
		[Browsable(true),Category("추가속성"),
		DefaultValue(""),Description("기준정보를 조회할 CodeType을 지정합니다.")]
		public string CodeType
		{
			get { return codeType;}
			set { codeType = value;}
		}

        public IList<object[]> DataList
	    {
            get { return dataList; }
            set
            {
                dataList = value;
                this.InitializeCombo();
            }
	    }
		#endregion

		#region 생성자
		public XInfoCombo()
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

		#region InitialzeCombo
		private void InitializeCombo()
		{
			//DataSource 변경시에 SelectedIndexChanged Event Call하지 않음
			this.CallSelectedIndexChangedEvent = false;
			//변경시작전 DataSource Null
			this.DataSource = null;
			//기존 ComboItems Clear
			this.ComboItems.Clear();
			if (this.codeType == "") return;
			
			//기준정보 코드 조회하여 MultiLayout Return
            
            // Cloud edition
             MultiLayout layList = BizCodeHelper.GetBaseInfoList(this.codeType);

			string displayItem = "";
			//List로 ComboItems SET
            foreach (DataRow dtRow in layList.LayoutTable.Rows)
            {
                displayItem = (this.codeDisplay ? dtRow["Code"].ToString() + "." + dtRow["CodeName"].ToString()
                    : dtRow["CodeName"].ToString());

                this.ComboItems.Add(dtRow["Code"].ToString(), displayItem);
            }
            //if (dataList != null)
            //{
            //    foreach (object[] dtRow in dataList)
            //    {
            //        displayItem = (this.codeDisplay ? dtRow[0].ToString() + "." + dtRow[1].ToString()
            //            : dtRow[1].ToString());

            //        this.ComboItems.Add(dtRow[0].ToString(), displayItem);
            //    }    
            //}

			//DataSource Refresh
			this.RefreshComboItems();
			//콤보가 구성되었으면 최초 SelectedIndex = 0
			if (this.ComboItems.Count > 0)
				this.SelectedIndex = 0;
			
			//Flag Clear
			this.CallSelectedIndexChangedEvent = true;
		}
		#endregion

		#region 코드타입 변경
		/// <summary>
		/// 코드 타입 변경처리
		/// </summary>
		/// <param name="buseoGubun"></param>
		public void ChangeCodeType(string codeType)
		{
			if (this.codeType != codeType)
			{
				this.codeType = codeType;
				this.InitializeCombo();
			}
		}
		#endregion
	}
}
