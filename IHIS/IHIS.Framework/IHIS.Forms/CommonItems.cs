using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.Framework
{
	#region CommonItem
	public class CommonItem
	{
		string	name = "";
		object	data = null;
		
		/// <summary>
		/// CommonItem의 이름을 가져옵니다.
		/// </summary>
		public string Name
		{
			get {return name;}
		}
		
		/// <summary>
		/// CommonItem의 값을 가져옵니다.
		/// </summary>
		public object Data
		{
			get {return data;}
		}
		/// <summary>
		/// CommonItem 생성자
		/// </summary>
		/// <param name="name"> CommonItem 이름 </param>
		/// <param name="data"> CommonItem 값 </param>
		public CommonItem(string name, object data)
		{
			this.name = name;
			this.data = data;
		}
	}
	#endregion

	#region CommonItemCollection
	/// <summary>
	/// CommonItemCollection에 대한 요약 설명입니다.
	/// </summary>
	public class CommonItemCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 지정한 index에 들어있는 CommonItem의 값을 가져옵니다.
		/// </summary>
		public object this[int index]
		{
			get
			{
				if ((index < 0) || (index >= List.Count))
					return string.Empty;
				else
					return ((CommonItem)List[index]).Data;
			}
				
		}
		/// <summary>
		/// 지정한 Key에 있는 CommonItem의 값을 가져옵니다.
		/// </summary>
		public object this[string key]
		{
			get
			{
				if (key == "") return string.Empty;
				foreach (CommonItem item in List)
				{
					if (item.Name == key) return item.Data;
				}
				return string.Empty;
			}
		}
		/// <summary>
		/// 해당이름, 값을 가진 ScreenParam를 생성하여 List에 추가합니다.
		/// </summary>
		/// <param name="name"> CommonItem 명</param>
		/// <param name="data"> CommonItem 값 </param>
		public void Add(string name, object data)
		{
			foreach (CommonItem item in List)
			{
				if (item.Name == name)
					throw(new Exception("[CommonItem]이미 등록된 이름과 동일합니다."));
			}
			CommonItem	cItem = new CommonItem(name, data);
			List.Add(cItem);
		}

		/// <summary>
		/// 지정한 Key의 CommonItem을 Remove합니다.
		/// </summary>
		/// <param name="name"></param>
		public void Remove(string name)
		{
			int index = 0;
			bool isFound = false;
			foreach (CommonItem item in List)
			{
				if (item.Name == name)
				{
					isFound = true;
					break;
				}
				index++;
			}
			if (isFound)
				this.RemoveAt(index);
		}
		/// <summary>
		/// 해당이름의 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="name"></param>
		/// <returns> SystemItem가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다. </returns>
		public bool Contains(string name)
		{
			foreach (CommonItem item in List)
				if (item.Name == name)
					return true;
			return false;
		}
	}
	#endregion
}