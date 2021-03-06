using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Drawing.Imaging;

namespace IHIS.Framework
{
	/// <summary>
	/// AListBox에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.PictureBox))]
	public class XPictureBox : System.Windows.Forms.PictureBox, IDataControl
	{
		#region Fields
		private bool	dataChanged = false;
		private XColor xBackColor	= XColor.XPictureBoxBackColor;
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"AMonthCalendarBackColor"),
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
		#endregion

		#region Events
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("데이타 유효성검사가 진행될 때 발생합니다.")]
		public event DataValidatingEventHandler DataValidating;
		#endregion
		
		#region Properties
		object IDataControl.DataValue
		{
			get	{ return this.DataValue; }
			set	
			{ 
				if (value is byte[])
					this.DataValue = (byte[]) value; 
				else
					this.DataValue = null;
			}
		}
		ControlDataType IDataControl.ContType
		{
			get{ return ControlDataType.Binary; }
		}
		/// <summary>
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// </summary>
		protected byte[] DataValue
		{
			get
			{
				try
				{
					if (this.Image == null) return new byte[0];
					MemoryStream ms = new MemoryStream();
					/* MemoryStream에 Image.Save로 Image.RawFormat으로 가져오면 Client에서 읽은 Image파일은 관계가 없으나
					 * 서버에서 가져와 SET으로 Image를 설정한 경우 Image.RawFormat 으로 다시 전송시에 에러가 발생. 명확한 원인은
					 * 아직 파악을 못했으며 일단 에러를 피하는 방법으로  Image해상도에 손상이 없고, Size가 작은 Jpeg형식으로 
					 * Binary를 만드는 것으로 처리한다. Gif는 Size는 작으나 해상도가 떨어짐
					 * Jpeg로 저장시에 gif등이 최초 byte가 커질수 있으나 이후 수렴함
					 * Image의 RawFormat이 MemoryBmp일때는 Save시에 Encoder가 없어서 에러가 발생함. 
					 * 그러므로 MemoryBmp이면 Png형식으로 저장함 */
					if (this.Image.RawFormat.Equals(ImageFormat.MemoryBmp))
						this.Image.Save(ms, ImageFormat.Png);
					else
						this.Image.Save(ms, this.Image.RawFormat);
					byte[] binaryBuffer = ms.ToArray();
					ms.Close();
					return binaryBuffer;
				}
				catch
				{
					try
					{
						MemoryStream ms = new MemoryStream();
						this.Image.Save(ms, ImageFormat.Jpeg);
						byte[] binaryBuffer = ms.ToArray();
						ms.Close();
						return binaryBuffer;
					}
					catch(Exception xxe)
					{
						XMessageBox.Show(xxe.StackTrace);
						return new byte[0];
					}
				}
			}
			set
			{
				try
				{
					if (value != null)
					{
						byte[] binaryBuffer = value;
						if (binaryBuffer.Length > 0)
						{
							using (MemoryStream ms = new MemoryStream(binaryBuffer, false))
								this.Image = System.Drawing.Image.FromStream(ms);
							//ms.Close();
						}
						else
							this.Image = null;
					}
					else
						this.Image = null;
				}
				catch(Exception xe)
				{
					MessageBox.Show(xe.Message);
					MessageBox.Show(xe.StackTrace);
					this.Image = null;
				}
			}
		}
		/// <summary>
		/// 컨트롤이 편집가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public bool Protect
		{ 
			get { return !Enabled;}
			set { Enabled  = !value;}
		}
		/// <summary>
		/// 컨트롤의 값이 변경되었는지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		DefaultValue(false)]
		public bool DataChanged
		{
			get { return dataChanged; }
			set { dataChanged = value;}
		}
		/// <summary>
		/// LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.")]
		public bool ApplyLayoutContainerReset
		{
			get { return applyLayoutContainerReset; }
			set { applyLayoutContainerReset = value;}
		}
		#endregion

		#region 생성자
		public XPictureBox()
		{
			//Default 색 지정
			this.BackColor = XColor.XMonthCalendarBackColor;
		}
		#endregion

		#region Implement IDataControl
		/// <summary>
		/// 편집중인 데이타를 컨트롤의 값으로 설정합니다.
		/// </summary>
		/// <returns> 설정 성공시 true, 실패시 false </returns>
		public virtual bool AcceptData()
		{
			return true;
		}
		/// <summary>
		/// 컨트롤의 값을 Clear합니다.
		/// </summary>
		public void ResetData()
		{
			this.Image = null;
			dataChanged = false;
		}
		/// <summary>
		/// DataValidating Event를 발생시킵니다. (에러방지용)
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 ValidateEventArgs </param>
		protected virtual void OnDataValidating(DataValidatingEventArgs e)
		{
			if (DataValidating != null)
				DataValidating(this, e);
		}
		#endregion

		#region Data 가져오기, 설정 Method
		/// <summary>
		/// 해당 컨트롤의 DataValue를 가져옵니다.
		/// </summary>
		/// <returns></returns>
		public byte[] GetDataValue()
		{
			return this.DataValue;
		}
		/// <summary>
		/// 해당 컨트롤의 DataValue를 지정합니다.(이떄 DataChanged는 false로 설정합니다. Validation Check하지 않음)
		/// </summary>
		/// <param name="dataValue"></param>
		public void SetDataValue(object dataValue)
		{
			((IDataControl) this).DataValue = dataValue;
		}
		/// <summary>
		/// 해당 컨트롤의 DataValue를 지정합니다.(이떄 DataChanged는 true로 설정합니다. Validation Check함)
		/// </summary>
		public void SetEditValue(object dataValue)
		{
			((IDataControl) this).DataValue = dataValue;
			this.DataChanged = true;
		}
		#endregion

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.BackColor != xBackColor.Color)
				base.BackColor = xBackColor.Color;
			base.OnPaint(e);
		}
		#endregion
	}
}
