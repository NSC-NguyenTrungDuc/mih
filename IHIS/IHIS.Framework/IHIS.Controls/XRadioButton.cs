using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// XRadioButton에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.RadioButton))]
	public class XRadioButton : System.Windows.Forms.RadioButton
	{
		#region Class Variables
		private string checkedValue = "Y";
		private string checkedText = "",   unCheckedText = "";
		private XColor xBackColor = XColor.XRadioButtonBackColor;
		private XColor xForeColor = XColor.NormalForeColor;
		#endregion
		
		#region Base Properties
		[DefaultValue(typeof(XColor),"XRadioButtonBackColor"),
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
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region Properties
		/// <summary>
		/// 체크된 상태의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue("Y"),
		Description("체크된 상태의 값을 지정합니다.")]
		public string CheckedValue
		{
			get	{return checkedValue;}
			set	{checkedValue = value;}
		}
		/// <summary>
		/// 체크된 상태에서 보여줄 문자를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue(""),
		Description("체크된 상태에서 보여줄 문자를 지정합니다.")]
		public string CheckedText
		{
			get	{return checkedText;}
			set { checkedText = value;}
		}
		/// <summary>
		/// 체크되지 않은 상태에서 보여줄 문자를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue(""),
		Description("체크되지 않은 상태에서 보여줄 문자를 지정합니다.")]
		public string UnCheckedText
		{
			get	{return unCheckedText;}
			set { unCheckedText = value;}
		}
		#endregion

		#region 생성자
		public XRadioButton()
		{
			//Default 색 지정
			this.BackColor = XColor.XRadioButtonBackColor;
			this.ForeColor = XColor.NormalForeColor;

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
		/// <summary>
		/// CheckedChanged Event를 발생시킵니다.
		/// (override) 체크상태에 따라 Text를 변경합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnClick(EventArgs e)
		{
			// Checked에 따라 Text 변경
			if(this.Checked)
			{
				if(!this.checkedText.Trim().Equals(string.Empty))
					this.Text = this.checkedText;
			}
			else
			{
				if(!this.unCheckedText.Trim().Equals(string.Empty))
					this.Text = this.unCheckedText;
			}
			base.OnClick (e);

			//XGroupBox의 DataChanged 변경
			if (!this.DesignMode)
			{
				if ((this.Parent != null) && (this.Parent is XGroupBox))
				{
					((XGroupBox) Parent).SetDataChanged(true);
				}
			}
		}
		#endregion

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.BackColor != xBackColor.Color)
				base.BackColor = xBackColor.Color;
			if (base.ForeColor != xForeColor.Color)
				base.ForeColor = xForeColor.Color;

			base.OnPaint(e);
		}
		#endregion

	}
}
