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

using IHIS.Framework;


namespace IHIS.Framework
{
	/// <summary>
	/// XPersonCombo에 대한 요약 설명입니다.
	/// 해당진료과의 의사, 해당 병동의 간호사등 사용자리스트 보여주는 Combo
	/// </summary>
	[DefaultProperty("PersonType")]
	[ToolboxBitmap(typeof(IHIS.Framework.XPersonCombo), "Images.XPersonCombo.bmp")]
	public class XPersonCombo : IHIS.Framework.XComboBox, ISupportInitialize
	{
		#region Fields
		private string   buseoCode = "";  //사용자의 부서코드
		private DateTime baseDate = DateTime.Today;  //조회기준일
		
		private XPersonComboType personType = XPersonComboType.Doctor;
		private bool   codeDisplay = false;  //의사 ID Display여부
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
		DefaultValue(XPersonComboType.Doctor),Description("사용자콤보를 구성할 콤보종류를 지정합니다.")]
		public XPersonComboType PersonType
		{
			get { return personType;}
			set { personType = value;}
		}
		#endregion

		#region 생성자
		public XPersonCombo()
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
			//추후 필요시 기능추가
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
				displayItem = (this.codeDisplay ? (NetInfo.Language == LangMode.Ko ? "%.전체" : "%.全体")
					: (NetInfo.Language == LangMode.Ko ? "전체" : "全体"));
				this.ComboItems.Add("%" , displayItem);
			}

			//기준정보 코드 조회하여 MultiLayout Return
			MultiLayout layList = BizCodeHelper.GetPersonList(this.personType, this.buseoCode, this.baseDate);

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

		#region ChangePerson
		/// <summary>
		/// 현재일 기준으로 해당부서코드의 사용자리스트 변경
		/// </summary>
		/// <param name="buseoCode"></param>
		public void ChangePerson(string buseoCode)
		{
			ChangePerson(this.personType, buseoCode, EnvironInfo.GetSysDate());
		}
		/// <summary>
		/// 사용자콤보 변경
		/// </summary>
		/// <param name="buseoGubun"></param>
		public void ChangePerson(string buseoCode, DateTime baseDate)
		{
			ChangePerson(this.personType, buseoCode, baseDate);
		}
		public void ChangePerson(string buseoCode, string baseDate)
		{
			ChangePerson(this.personType, buseoCode, baseDate);
		}
		public void ChangePerson(XPersonComboType personType, string buseoCode, string baseDate)
		{
			string msg = "";
			//string baseDate는 YYYYMMDD OR YYYY/MM/DD형도 가능함
			DateTime baseDt = DateTime.Today;
			if (TypeCheck.IsDateTime(baseDate))
			{
				baseDt = DateTime.Parse(baseDate);
			}
			else if (baseDate.Length == 8)
			{
				string dateStr = baseDate.Substring(0,4) + "/" + baseDate.Substring(4,2) + "/" + baseDate.Substring(6);
				if (!TypeCheck.IsDateTime(dateStr))
				{
					msg = (NetInfo.Language == LangMode.Ko ? "[ChangePerson]기준일을 잘못 지정하셨습니다.[" + baseDate + "]"
						: "[ChangePerson] 基準日の指定が間違いました。[" + baseDate + "]");
					XMessageBox.Show(msg);
					return;
				}
				baseDt = DateTime.Parse(dateStr);
			}
			else
			{
				msg = (NetInfo.Language == LangMode.Ko ? "[ChangePerson]기준일을 잘못 지정하셨습니다.[" + baseDate + "]"
					: "[ChangePerson] 基準日の指定が間違いました。[" + baseDate + "]");
				XMessageBox.Show(msg);
				return;
			}
			ChangePerson(personType, buseoCode, baseDt);
		}
		public void ChangePerson(XPersonComboType personType, string buseoCode, DateTime baseDate)
		{
			//Property설정
			this.personType = personType;
			this.buseoCode  = buseoCode;
			this.baseDate   = baseDate;
			InitializeCombo();
		}
		#endregion
	}

}
