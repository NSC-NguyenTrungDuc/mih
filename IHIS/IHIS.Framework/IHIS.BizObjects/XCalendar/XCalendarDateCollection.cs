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
	/// <summary>
	/// XCalendarDateCollection에 대한 요약 설명입니다.
	/// </summary>
	public class XCalendarDateCollection : CollectionBase
	{
		private XCalendar owner;

		#region Indexer
		public XCalendarDate this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (XCalendarDate)List[index];
			}
		}
		public XCalendarDate this[DateTime date]
		{
			get 
			{ 
				foreach (XCalendarDate info in this.List)
				{
					if (info.Date.ToShortDateString() == date.ToShortDateString())
						return info;
				}
				return null;
			}
		}
		#endregion

		#region 생성자
		public XCalendarDateCollection(XCalendar owner) : base()
		{
			if (owner == null)
				throw new ArgumentNullException("XCalendarDateCollection::Constructor XCalendar is null");
							
			this.owner = owner;
		}
		#endregion

		public void Add(XCalendarDate dateItem)
		{
			if (dateItem.Calendar == null)
				dateItem.Calendar = this.owner;
			
			int index = IndexOf(dateItem);
			if (index == -1)
				this.List.Add(dateItem);
			else
				this.List[index] = dateItem;
		}
		public void Add(DateTime date)
		{
			if (!Contains(date))
			{
				XCalendarDate dateItem = new XCalendarDate(date);
				this.List.Add(dateItem);
			}
		}
		public void AddRange(XCalendarDate[] dateItems)
		{
			//Owner 지정
			foreach (XCalendarDate dateItem in dateItems)
			{
				dateItem.Calendar = owner;
				Add(dateItem);
			}
		}
		public int IndexOf(DateTime date)
		{
			int index = 0;
			foreach (XCalendarDate info in this.List)
			{
				if (info.Date.ToShortDateString() == date.ToShortDateString())
					return index;
				index++;

			}
			return -1;
		}
		public int IndexOf(XCalendarDate dateItem)
		{
			for (int i=0; i<this.Count; i++)
			{
				if (this[i] == dateItem)
					return i;
			}
			return -1;
		}
		public bool Contains(DateTime date)
		{
			return (IndexOf(date) == -1 ? false : true);
		}
		public void Remove(DateTime date)
		{
			int index = IndexOf(date);
			if (index >= 0)
				List.RemoveAt(index);
		}
		public void Remove(int index)
		{
			if ((index >= 0) && (index < this.Count))
				List.RemoveAt(index);
		}
	}

	#region XCalendarDateCollectionEditor
	/// <summary>
	/// A custom CollectionEditor for editing DateItemCollection
	/// </summary>
	internal class XCalendarDateCollectionEditor : CollectionEditor
	{
		#region Fields
		private XCalendar calendar;
		#endregion
		
		#region Constructor

		public XCalendarDateCollectionEditor(Type type) : base(type)
		{
			
		}

		#endregion
		
		#region overrides

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider isp, object value)
		{
			XCalendar originalControl = (XCalendar) context.Instance;
			calendar = originalControl;

			object returnObject = base.EditValue(context, isp, value);
						
			return returnObject;
		}
		
		protected override object CreateInstance(Type itemType)
		{
			object dateItem = base.CreateInstance(itemType);
				
			((XCalendarDate) dateItem).Date = DateTime.Today;
			((XCalendarDate) dateItem).Calendar = calendar;
			return dateItem;
		}

		#endregion
	}
	#endregion
}
