using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel.Design.Serialization;

namespace IHIS.Framework
{
	#region XGridGroupInfo
	/// <summary>
	/// CellInfo(Cell컬럼 정보관리) class에 대한 요약 설명입니다.
	/// </summary>
	[Serializable,
	TypeConverter(typeof(XGridGroupInfoTypeConverter)),
	DesignTimeVisible(false)]
	public class XGridGroupInfo
	{
		private string groupName = string.Empty;   // GroupName
		private ArrayList columnList = new ArrayList();
		/// <summary>
		/// XGridGroupInfo 생성자
		/// </summary>
		/// <param name="groupName"> Group 명 </param>
		/// <param name="columns"> Column Name List </param>
		public XGridGroupInfo(string groupName, object[] columns)
		{
			this.groupName = groupName;
			this.columnList.AddRange(columns);
		}
		/// <summary>
		/// 컬럼의 Visible여부를 가져오거나 설정합니다.
		/// </summary>
		public string GroupName
		{
			get { return groupName; }
			set { groupName = value ;}
		}
		/// <summary>
		/// Grouping된 컬럼의 컬럼정보를 가져오거나 설정합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ArrayList ColumnList
		{
			get { return columnList; }
			set { columnList = value ;}
		}
		/// <summary>
		/// 이 개체의 String표현을 가져옵니다.(컬럼명)
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return groupName;
		}
	}
	#endregion

	#region XGridGroupInfo Type Converter
	/// <summary>
	/// XGridGroupInfo TypeConverter
	/// </summary>
	public class XGridGroupInfoTypeConverter : TypeConverter
	{
		/// <summary>
		/// 이 변환기가 개체를 지정된 형식으로 변환할 수 있는지 여부를 반환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="destinationType"> 변환할 대상 형식을 나타내는 Type </param>
		/// <returns> 이 변환기가 변환을 수행할 수 있으면 true이고, 그렇지 않으면 false </returns>
		public override bool CanConvertTo (ITypeDescriptorContext context, System.Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
				return true;

			return base.CanConvertTo(context, destinationType);
		}
		/// <summary>
		/// 지정된 값 개체를 지정된 형식으로 변환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="culture"> CultureInfo 개체 </param>
		/// <param name="value"> 변환할 Object </param>
		/// <param name="destinationType"> value 매개 변수를 변환할 Type </param>
		/// <returns> 변환된 값을 나타내는 Object </returns>
		public override object ConvertTo
			(ITypeDescriptorContext context, CultureInfo culture,
			object value, System.Type destinationType )
		{
			XGridGroupInfo groupInfo;
			object[] args;
			
			System.Type[] Types = new Type[]{typeof(string),typeof(XGridCell[])};

			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is XGridGroupInfo)
				{
					groupInfo = (XGridGroupInfo)value;
					args = new Object[]{groupInfo.GroupName, groupInfo.ColumnList.ToArray()};
					InstanceDescriptor id = new InstanceDescriptor(groupInfo.GetType().GetConstructor(Types), args);
					return id;
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	#endregion

	#region XGridGroupInfoCollection 
	/// <summary>
	/// XGridGroupInfo 객체를 관리하는 컬렉션입니다.
	/// </summary>
	[Serializable]
	public class XGridGroupInfoCollection : CollectionBase
	{
		/// <summary>
		/// 해당 Index에 있는 XGridGroupInfo 객체를 반환합니다.
		/// </summary>
		public XGridGroupInfo this[int index]
		{
			get { return (XGridGroupInfo)List[index]; }
		}
		/// <summary>
		/// 해당 Key(groupName)를 가지는 XGridGroupInfo를 반환합니다.
		/// </summary>
		public XGridGroupInfo this[string groupName]
		{
			get
			{
				if (groupName == "") return null;
				foreach (XGridGroupInfo item in this)
				{
					if (item.GroupName == groupName) return item;
				}
				return null;
			}
		}
		/// <summary>
		/// XGridGroupInfo 객체를 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="groupInfo"> XGridGroupInfo 객체 </param>
		public void Add(XGridGroupInfo groupInfo)
		{
			foreach (XGridGroupInfo info in List)
			{
				if (info.GroupName == groupInfo.GroupName)
					throw(new Exception("이미 등록된 그룹명과 동일합니다."));
			}
			List.Add(groupInfo);
		}
		/// <summary>
		/// XGridGroupInfo[] 를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="groupInfos"> XGridGroupInfo[] </param>
		public void AddRange(XGridGroupInfo[] groupInfos)
		{
			List.Clear();
			foreach (XGridGroupInfo info in groupInfos)
				Add(info);
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridGroupInfo객체를 제거합니다.
		/// </summary>
		/// <param name="groupInfo">제거할 XGridGroupInfo객체</param>
		public void Remove(XGridGroupInfo groupInfo)
		{
			List.Remove(groupInfo);
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridGroupInfo객체를 제거합니다.
		/// </summary>
		/// <param name="key">제거할 XGridGroupInfo의 GroupName</param>
		public void Remove(string key)
		{
			XGridGroupInfo groupInfo = null;
			foreach (XGridGroupInfo info in List)
			{
				if (info.GroupName == key)
				{
					groupInfo = info;
					break;
				}
			}
			if (groupInfo != null)
				List.Remove(groupInfo);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="groupInfo">컬렉션에서 찾을 XGridGroupInfo입니다.</param>
		/// <returns>groupInfo가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XGridGroupInfo groupInfo)
		{
			return List.Contains(groupInfo);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="groupName">컬렉션에서 찾을 GroupName </param>
		/// <returns>groupInfo가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(string groupName)
		{
			foreach (XGridGroupInfo info in List)
				if (info.GroupName == groupName)
					return true;

			return false;
		}
	}
	#endregion

}
