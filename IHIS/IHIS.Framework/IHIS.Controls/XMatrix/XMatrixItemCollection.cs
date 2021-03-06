using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XMatrixItem Collection
	/// <summary>
	/// XMatrixItem 을 관리하는 컬렉션입니다.
	/// </summary>
	public class XMatrixItemCollection : System.Collections.CollectionBase
	{
		#region 생성자
		private XMatrixControl matrix = null;
		public XMatrixItemCollection(object owner) : base()
		{
			if (!(owner is XMatrixControl))
				throw new Exception("XMatrixItemCollection::Creator owner is not XMatrixControl");
			this.matrix = (XMatrixControl) owner;
				
		}
		#endregion
		/// <summary>
		/// 지정한 인덱스에 있는 ComboItem 가져옵니다.
		/// </summary>
		public XMatrixItem this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (XMatrixItem)List[index];
			}
		}
		public XMatrixItem Add(int row, string colKey, string text)
		{
			return Add(row, colKey, text, -1);
		}
		public XMatrixItem Add(int row,  string colKey, string text, int imageIndex)
		{
			XMatrixItem item = new XMatrixItem(row, colKey, text, imageIndex);
			//Item의 Matrix Set
			item.Matrix = this.matrix;
			List.Add(item);
			return item;
		}
		/// <summary>
		/// XMatrixItem을 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="matrixItem"> XMatrixItem 개체 </param>
		/// <returns> 추가한 XMatrixItem 개체 </returns>
		public void Add(XMatrixItem item)
		{
			//Item의 Matrix Set
			item.Matrix = this.matrix;
			List.Add(item);
		}
		/// <summary>
		/// 지정한 Index의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="index"> 지정 Index </param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0) 
				return;
			else
				List.RemoveAt(index); 
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XMatrixItem객체를 제거합니다.
		/// </summary>
		/// <param name="item">제거할 XMatrixItem객체</param>
		public void Remove(XMatrixItem item)
		{
			List.Remove(item);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="targetItem"> Insert 위치를 지정 Target Item </param>
		/// <param name="insertItem"> Insert 되는 Item </param>
		/// <param name="toFront"> target Item 앞으로 넣으면 true, 뒤로 넣으면 false </param>
		public void Insert(XMatrixItem targetItem, XMatrixItem insertItem, bool toFront)
		{
			//TagetItem 포함여부 확인
			if (!Contains(targetItem)) return;

			//insertItem이 이미 리스트에 있으면 Remove
			if (Contains(insertItem))
				Remove(insertItem);
			//TargetItem의 Index Get
			int index = 0;
			foreach (XMatrixItem item in List)
			{
				if (item.Equals(targetItem))
					break;
				index++;
			}
			if (toFront)
				List.Insert(index, insertItem);
			else
				List.Insert(index + 1, insertItem);
		}
		public bool Contains(XMatrixItem item)
		{
			return List.Contains(item);
		}
	}
	#endregion

	#region XColMatrixItem Collection
	/// <summary>
	/// XColMatrixItem 을 관리하는 컬렉션입니다.
	/// </summary>
	public class XColMatrixItemCollection : System.Collections.CollectionBase
	{
		#region 생성자
		private XMatrixControl matrix = null;
		public XColMatrixItemCollection(object owner) : base()
		{
			if (!(owner is XMatrixControl))
				throw new Exception("XColMatrixItemCollection::Creator owner is not XMatrixControl");
			this.matrix = (XMatrixControl) owner;
				
		}
		#endregion

		/// <summary>
		/// 지정한 인덱스에 있는 XColMatrixItem 가져옵니다.
		/// </summary>
		public XColMatrixItem this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (XColMatrixItem)List[index];
			}
		}

		/// <summary>
		/// 지정한 Key를 가지는 XColMatrixItem 가져옵니다.
		/// </summary>
		public XColMatrixItem this[string key]
		{
			get
			{
				foreach (XColMatrixItem item in this)
				{
					if (item.Key == key)
						return item;
				}
				return null;
			}
		}
		public XColMatrixItem Add(string key, string text)
		{
			return Add (key, text, XMatrixUtils.DefaultItemWidth, -1);
		}
		public XColMatrixItem Add(string key, string text, int width)
		{
			return Add (key, text, width, -1);
		}
		public XColMatrixItem Add(string key, string text, int width, int imageIndex)
		{
			XColMatrixItem item = new XColMatrixItem(key, text, width, imageIndex);
			//Item의 Maxtrix Set
			item.Matrix = this.matrix;
			//Childs Set
			item.Childs = new XColMatrixItemCollection(this.matrix);
			List.Add(item);
			return item;
		}
		/// <summary>
		/// XMatrixItem을 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="matrixItem"> XMatrixItem 개체 </param>
		/// <returns> 추가한 XMatrixItem 개체 </returns>
		public void Add(XColMatrixItem item)
		{
			//Item의 Maxtrix Set
			item.Matrix = this.matrix;
			//Childs Set
			item.Childs = new XColMatrixItemCollection(this.matrix);
			List.Add(item);
		}
		/// <summary>
		/// 지정한 Index의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="index"> 지정 Index </param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0) 
				return;
			else
				List.RemoveAt(index); 
		}
		/// <summary>
		/// 지정한 실제값의 XMatrixItem을 삭제합니다.
		/// </summary>
		/// <param name="valueMember"> XMatrixItem.ValueItem </param>
		public void Remove(string key)
		{
			for (int i = 0 ; i < this.Count ; i++)
			{
				if (this[i].Key == key)
				{
					this.Remove(i);
					break;
				}

			}
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XMatrixItem객체를 제거합니다.
		/// </summary>
		/// <param name="item">제거할 XMatrixItem객체</param>
		public void Remove(XColMatrixItem item)
		{
			List.Remove(item);
		}
		/// <summary>
		/// 해당이름의 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="dataName"></param>
		/// <returns> PreDataItem가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다. </returns>
		public bool Contains(string key)
		{
			foreach (XColMatrixItem item in List)
				if (item.Key == key)
					return true;
			return false;
		}
		public bool Contains(XColMatrixItem item)
		{
			return List.Contains(item);
		}
	}
	#endregion

	#region XRowMatrixItem Collection
	/// <summary>
	/// XRowMatrixItem 을 관리하는 컬렉션입니다.
	/// </summary>
	public class XRowMatrixItemCollection : System.Collections.CollectionBase
	{
		#region 생성자
		private XMatrixControl matrix = null;
		public XRowMatrixItemCollection(object owner) : base()
		{
			if (!(owner is XMatrixControl))
				throw new Exception("XRowMatrixItemCollection::Creator owner is not XMatrixControl");
			this.matrix = (XMatrixControl) owner;
				
		}
		#endregion

		/// <summary>
		/// 지정한 인덱스에 있는 XColMatrixItem 가져옵니다.
		/// </summary>
		public XRowMatrixItem this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (XRowMatrixItem)List[index];
			}
		}
		public XRowMatrixItem Add(string text, int colLevel)
		{
			return Add(text, colLevel, XMatrixUtils.DefaultItemHeight);
		}
		public XRowMatrixItem Add(string text, int colLevel, int height)
		{
			XRowMatrixItem item = new XRowMatrixItem(text, colLevel, height);
			//Item의 Maxtrix Set
			item.Matrix = this.matrix;
			List.Add(item);
			return item;
		}
		/// <summary>
		/// XMatrixItem을 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="matrixItem"> XMatrixItem 개체 </param>
		/// <returns> 추가한 XMatrixItem 개체 </returns>
		public void Add(XRowMatrixItem item)
		{
			//Item의 Maxtrix Set
			item.Matrix = this.matrix;
			List.Add(item);
		}
		/// <summary>
		/// 지정한 Index의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="index"> 지정 Index </param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0) 
				return;
			else
				List.RemoveAt(index); 
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XMatrixItem객체를 제거합니다.
		/// </summary>
		/// <param name="item">제거할 XMatrixItem객체</param>
		public void Remove(XRowMatrixItem item)
		{
			List.Remove(item);
		}
		public bool Contains(XRowMatrixItem item)
		{
			return List.Contains(item);
		}
	}
	#endregion

	#region ItemInfo Collection
	internal class ItemInfo
	{
		public int Row = 0;
		public string ColKey = "";
		public ArrayList ItemList = new ArrayList(); //XMatrixItem 객체 보관 리스트
		public ItemInfo(int row, string colKey)
		{
			this.Row = row;
			this.ColKey = colKey;
		}
	}
	/// <summary>
	/// ItemInfo 을 관리하는 컬렉션입니다.
	/// </summary>
	internal class ItemInfoCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 지정한 인덱스에 있는 ItemInfo 가져옵니다.
		/// </summary>
		public ItemInfo this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (ItemInfo)List[index];
			}
		}

		/// <summary>
		/// 지정한 Key를 가지는 ItemInfo 가져옵니다.
		/// </summary>
		public ItemInfo this[int row, string colKey]
		{
			get
			{
				foreach (ItemInfo item in this)
				{
					if ((item.Row == row) && (item.ColKey == colKey))
						return item;
				}
				return null;
			}
		}
		public ItemInfo Add(int row, string colKey)
		{
			ItemInfo info = new ItemInfo(row, colKey);
			List.Add(info);
			return info;
		}
		/// <summary>
		/// 해당이름의 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="dataName"></param>
		/// <returns> PreDataItem가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다. </returns>
		public bool Contains(int row, string colKey)
		{
			foreach (ItemInfo item in List)
				if ((item.Row == row) && (item.ColKey == colKey))
					return true;
			return false;
		}
	}
	#endregion
}
