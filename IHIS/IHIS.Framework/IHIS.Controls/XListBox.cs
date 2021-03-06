using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// XListBox에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.ListBox))]
	public class XListBox : System.Windows.Forms.ListBox
	{
		#region Fields
		private XColor xBackColor				= XColor.XListBoxBackColor;
		private XColor xForeColor				= XColor.NormalForeColor;
		private XColor itemBackColor			= XColor.XListBoxItemBackColor;
		private XColor alternatingItemBackColor = XColor.XListBoxAlternatingItemBackColor;
		private XColor itemBorderColor			= XColor.XListBoxItemBorderColor;
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XListBoxBackColor"),
		Description("배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"NormalForeColor"),
		Description("텍스트색을 지정합니다.")]
		public new XColor ForeColor
		{
			get { return xForeColor;}
			set 
			{
				xForeColor = value;
				base.ForeColor = value.Color;
			}
		}
		/// <summary>
		/// ListBox의 항목 높이를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),Browsable(true),DefaultValue(12),
		Description("List Item의 높이를 지정합니다.")]
		public new int ItemHeight
		{
			get { return base.ItemHeight; }
			set { base.ItemHeight = value; }
		}
		[DefaultValue(DrawMode.OwnerDrawVariable)]
		public override DrawMode DrawMode
		{
			get { return base.DrawMode;}
			set { base.DrawMode = value;}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool MultiColumn
		{
			get { return base.MultiColumn;}
			set {}  //MultiColumn 기능은 없음(Owner Draw이므로)
		}
		#endregion

		#region Properties
		/// <summary>
		/// Item의 배경색 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XListBoxItemBackColor"),
		MergableProperty(true),
		Description("Item의 배경색을 지정합니다.")]
		public XColor ItemBackColor
		{
			get {return itemBackColor;}
			set 
			{
				itemBackColor = value;
				Invalidate(ClientRectangle);
			}
		}
		/// <summary>
		/// 교대로 반복되는 Item의 배경색 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XListBoxAlternatingItemBackColor"),
		MergableProperty(true),
		Description("Item의 배경색을 지정합니다.")]
		public XColor AlternatingItemBackColor
		{
			get {return alternatingItemBackColor;}
			set 
			{
				alternatingItemBackColor = value;
				Invalidate(ClientRectangle);
			}
		}
		/// <summary>
		/// Item의 배경색 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XListBoxItemBorderColor"),
		MergableProperty(true),
		Description("Item의 테두리색을 지정합니다.")]
		public XColor ItemBorderColor
		{
			get {return itemBorderColor;}
			set 
			{
				itemBorderColor = value;
				Invalidate(ClientRectangle);
			}
		}
		#endregion

		#region 생성자
		public XListBox()
		{
			//Default 색 지정
			this.BackColor = XColor.XListBoxBackColor;
			this.ForeColor = XColor.NormalForeColor;
			this.DrawMode = DrawMode.OwnerDrawVariable;

			// 2005/05/09 신종석 폰트 수정
			//this.Font = new Font("MS UI Gothic", 9.75f);

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = Service.COMMON_FONT;
            }
		}
		#endregion

		#region Override
		protected override void OnParentBackColorChanged(EventArgs e)
		{
			//ColorStyle 적용 (자세한 설명은 XTrackBar::OnParentBackColorChanged 참조)
			base.BackColor = this.xBackColor.Color;
			base.ForeColor = this.xForeColor.Color;
			base.OnParentBackColorChanged(e);
		}
		/// <summary>
		/// (override) ListBox의 Font와 Width에 따라 ItemHeight와 ItemWidth를 다시 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MeasureItemEventArgs </param>
		protected override void OnMeasureItem(MeasureItemEventArgs e)
		{
			//OnMeasureItem은 DrawMode가 OwnerDrawVariable일때 구동되므로 Default를 OwnerDrawVariable 설정
			if(Site!=null)
				return;
			if(e.Index > -1)
			{
				//2005.11.25 DataSource가 연결된 경우에는 Items[e.Index]가 실제 Data를 가져오지 않고,
				//DataTable과 연결된 경우는 DataRowView를 XComboItems와 연결된 경우는 XComboItem을 가져온다.(XDictListBox)
				//이 경우에 정확한 Text가 아니므로 MeasureString이 잘못된다.
				//따라서, Case를 나누어 s를 정확히 구한다.
				string s = "";
				if (this.DataSource == null)
					s = Items[e.Index].ToString();
				else 
				{
					if (this.DisplayMember == "") 
						s = "";
					else if (Items[e.Index] is DataRowView)
						s = ((DataRowView) Items[e.Index]).Row[this.DisplayMember].ToString();
					else if (Items[e.Index] is XComboItem)
						s = ((XComboItem) Items[e.Index]).DisplayItem;
					else
						s = "";
				}
				SizeF sf = e.Graphics.MeasureString(s,Font,Width);
				e.ItemHeight = (int)sf.Height + 5; //Height를 조금 넓힘
				e.ItemWidth = Width;
			}
		}
		/// <summary>
		/// (override) ListBox의 상태에 따라 Item을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 DrawItemEventArgs </param>
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if(Site!=null)
				return;
			if(e.Index > -1)
			{
				string text = string.Empty;
				//DataSource가 있으면 DisplayMember를 찾아 SET
				if (this.DataSource != null)
				{
					IList list = null;
					if ( DataSource is IList)
					{
						list = (IList)DataSource;
						Debug.Assert(list != null, "ComboBox is bound to unrecognized DataSource");
						// Now extract the actual text to be displayed
						object o = list[e.Index];
						if (DisplayMember == "")
							text = o.ToString();
						else
						{
							Type objectType = o.GetType();
							// Now invoke the method that is associate with the
							// Display name property of the ComboBox
							PropertyInfo pi = objectType.GetProperty(DisplayMember);
							text = (string)pi.GetValue(o, null);
						}
					}
					else
					{
						// Data set object
						if ( DataSource is IListSource )
						{
							IListSource ls = (IListSource)DataSource;
							list = ls.GetList();
							Debug.Assert(list != null, "ComboBox is bound to unrecognized DataSource");
							// This is a data set object, get the value under that assumption
							DataRowView dataRowView = (DataRowView)list[e.Index];
							DataRow dataRow = dataRowView.Row;
							object o = dataRow[DisplayMember];
							text = o.ToString();

						}
					}
				}
				else  //없으면 Items를 찾아 SET
					text = Items[e.Index].ToString();							
			
				//선택된 상태이면 Highlight
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight),e.Bounds);
					e.Graphics.DrawString(text,Font,new SolidBrush(SystemColors.HighlightText),
						e.Bounds.X , e.Bounds.Y + 2);
					e.Graphics.DrawRectangle(new Pen(Color.Blue),e.Bounds);
				}
				else //일반 상태
				{
					if (e.Index % 2 == 0)
						e.Graphics.FillRectangle(new SolidBrush(alternatingItemBackColor.Color),e.Bounds);
					else
						e.Graphics.FillRectangle(new SolidBrush(itemBackColor.Color),e.Bounds);

					e.Graphics.DrawString(text,Font,new SolidBrush(this.ForeColor.Color),
						e.Bounds.X , e.Bounds.Y + 2);				
					e.Graphics.DrawRectangle(new Pen(itemBorderColor.Color),e.Bounds);
				}
			}
		}
		#endregion
	}
}
