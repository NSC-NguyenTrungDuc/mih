using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design; 
using System.Drawing.Drawing2D;
using System.Drawing.Printing; 
using System.Windows.Forms;
using System.Windows.Forms.Design; 
using System.Runtime.Serialization;
using System.Globalization;
using System.Threading;

namespace IHIS.Framework
{
	#region Enums
	/// <summary>
	/// MatrixItem의 Type
	/// </summary>
	public enum XMatrixItemType
	{
		Base,     //XMatrixItem의 Base Type
		Content,  //내용을 가지는 실제 Item
		ColHeader,  //RowHeader Item
		RowHeader   //ColHeader Item
	}
	/// <summary>
	/// Item의 상태관리 Enum
	/// </summary>
	internal enum XMatrixItemState
	{
		Normal,
		Focus,
		Selected
	}
	#endregion

	#region Event Delegator
	public delegate void XMatrixItemClickEventHandler(object sender, XMatrixItemClickEventArgs e);
	public delegate void XMatrixItemDragDropEventHandler(object sender, XMatrixItemDragDropEventArgs e);
	#endregion

	#region XMatrixUtils
	internal class XMatrixUtils
	{
		public static StringFormat GetStringAlignment(ContentAlignment align)
		{
			StringFormat sf = new StringFormat();
			sf.Trimming = StringTrimming.EllipsisCharacter;  //문자가 길면 ... 표시
	 
			//StringFormat으로 Draw
			if (DrawHelper.IsTop(align))
				sf.LineAlignment = StringAlignment.Near;
			else if (DrawHelper.IsVCenter(align))
				sf.LineAlignment = StringAlignment.Center;
			else
				sf.LineAlignment = StringAlignment.Far;

			if (DrawHelper.IsLeft(align))
				sf.Alignment = StringAlignment.Near;
			else if (DrawHelper.IsHCenter(align))
				sf.Alignment = StringAlignment.Center;
			else
				sf.Alignment = StringAlignment.Far;
				
			return sf;
		}
		public static int DefaultItemHeight = 24;
		public static int DefaultItemWidth = 100;
		public static Pen LinePen = new Pen(XColor.XMatrixLineColor.Color);
	}
	#endregion

	#region XMatrixItemDragDropEventArgs
	public class XMatrixItemDragDropEventArgs : EventArgs
	{

		#region Fields and Properties
		private XMatrixItem dropItem;
		private int keyState;
		private IDataObject data;
		private int dropRow;
		private string dropColKey;
		private XRowMatrixItem dropRowItem;
		private XColMatrixItem dropColItem;
		public XMatrixItem DropItem
		{
			get { return dropItem;}
		}

		public int KeyState
		{
			get { return keyState;}
		}
		public IDataObject Data
		{
			get { return data;}
		}
		public int DropRow
		{
			get { return dropRow;}
		}
		public string DropColKey
		{
			get { return dropColKey;}
		}
		public XRowMatrixItem DropRowItem
		{
			get { return dropRowItem;}
		}
		public XColMatrixItem DropColItem
		{
			get { return dropColItem;}
		}
		#endregion

		#region Constructor
		public XMatrixItemDragDropEventArgs(IDataObject data, int keystate , int dropRow, string dropColKey, XRowMatrixItem dropRowItem , XColMatrixItem dropColItem , XMatrixItem dropItem)
		{
			this.data = data;
			this.keyState = keystate;
			this.dropRow = dropRow;
			this.dropColKey = dropColKey;
			this.dropItem = dropItem;
			this.dropRowItem = dropRowItem;
			this.dropColItem = dropColItem;
		}
		#endregion
	}
	#endregion

	#region XMatrixItemClickEventArgs
	public class XMatrixItemClickEventArgs : EventArgs
	{
		#region Fields and Properties
		private XMatrixItem item;
		private MouseButtons button;
		public XMatrixItem Item
		{
			get { return item;}
		}
		public MouseButtons Button
		{
			get { return button;}
		}
		#endregion

		#region Constructor
		public XMatrixItemClickEventArgs(XMatrixItem item, MouseButtons button)
		{
			this.item = item;
			this.button = button;
		}
		#endregion
	}
	#endregion
}
