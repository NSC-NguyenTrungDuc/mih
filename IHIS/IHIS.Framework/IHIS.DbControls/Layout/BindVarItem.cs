using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel.Design.Serialization;

namespace IHIS.Framework
{
	#region BindVar Item
	/// <summary>
	/// BindVar Item
	/// </summary>
	[Serializable,
	ToolboxItem(false),
	DesignTimeVisible(false)]
	public class BindVarItem : System.ComponentModel.Component
	{
		#region Fields
		private string varName = "";
		private Control bindControl = null; //Binding된 IDataControl, IBizComponent, Grid
		private string bindVariable = "";  //Binding된 Property Name
		private string gridColName = "";   //Binding된 Grid의 컬럼명
		#endregion

		#region Properties
		[Browsable(true),
		Category("Data"),
		DefaultValue("")]
		public string VarName
		{
			get { return varName; }
			set { varName = value; }
		}
		[Browsable(true),
		Category("Data"),
		DefaultValue(null)]
		public Control BindControl
		{
			get { return bindControl; }
			set { bindControl = value; }
		}

		[Browsable(true),
		Category("Data"),
		DefaultValue(""),
		NotifyParentProperty(true)]
		public string BindVariable
		{
			get { return bindVariable; }
			set { bindVariable = value; }
		}
		[Browsable(true),
		Category("Data"),
		DefaultValue(""),
		NotifyParentProperty(true)]
		public string GridColName
		{
			get { return gridColName; }
			set { gridColName = value; }
		}
		#endregion

		#region 생성자
		public BindVarItem()
		{
		}
		#endregion
	}
	#endregion

	#region BindVar Item Collection
	/// <summary>
	/// DataLayout Item Collection
	/// </summary>
	[Serializable]
	[Editor(typeof(BindVarItemsEditor), typeof(UITypeEditor))]
	public class BindVarItemCollection : System.Collections.CollectionBase
	{
		public BindVarItemCollection()
		{
		}

		public BindVarItem this[int index]
		{
			get
			{
				if ((index < 0) || (index >= List.Count)) return null;

				return (BindVarItem)List[index];
			}
		}

		public BindVarItem this[string key]
		{
			get
			{
				if (key == "") return null;

				foreach (BindVarItem item in this)
				{
					if (item.VarName == key) return item;
				}
				return null;
			}
		}

		public void Add(BindVarItem item)
		{
			//InitializeComponents에서 Serialize되는 순서가 AddRange -> Add가 먼저 발생하고,
			//다음에 XComboItem의 ValueItem과 DisplayItem이 설정되므로 ValueItem이 ""인 상태에서
			//Add가 발생하여 Exception이 발생함. 따라서, 동일한 값 확인여부를 Check하지 않음
			//foreach (BindVarItem si in List)
			//{
			//    if (si.VarName == item.VarName)
			//        throw (new Exception("이미 등록된 항목명[" + si.VarName + "]과 동일합니다.[BindVarItemCollection::Add]"));
			//}
			List.Add(item);
		}

		public void AddRange(BindVarItem[] items)
		{
			List.Clear();
			foreach (BindVarItem Item in items)
			{
				Add(Item);
			}
		}
		public void Remove(string varName)
		{
			int index = -1;
			foreach (BindVarItem si in List)
			{
				index++;
				if (si.VarName == varName)
					break;
			}
			if (index >= 0)
				List.RemoveAt(index);
		}
		public void Remove(BindVarItem item)
		{
			List.Remove(item);
		}
		public bool Contains(string varName)
		{
			foreach (BindVarItem si in List)
				if (si.VarName == varName)
					return true;
			return false;
		}
		public bool Contains(BindVarItem item)
		{
			return List.Contains(item);
		}
		/// <summary>
		/// 컬렉션에 속하는 BindVarItem을 BindVarItem[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> BindVarItem[] </returns>
		public BindVarItem[] ToArray()
		{
			BindVarItem[] itemArray = new BindVarItem[List.Count];
			for (int i = 0; i < List.Count; i++)
				itemArray[i] = (BindVarItem)List[i];
			return itemArray;
		}

	}
	#endregion
}
