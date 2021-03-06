using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// BackContainer (Grid의 container) class에 대한 요약설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	[Serializable]
	internal class BackContainer : System.Windows.Forms.UserControl
	{
		#region System Generated
		private System.ComponentModel.IContainer components = null;
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			// 
			// BackContainer
			// 
			this.Name = "BackContainer";
			this.Size = new System.Drawing.Size(296, 288);

		}
		#endregion

		#region 생성자
		/// <summary>
		/// BackContainer 생성자
		/// </summary>
		public BackContainer()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			//to remove flicker
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);

			//ToolTip InActive
			this.toolTip.Active = false;
		}
		#endregion

		private System.Windows.Forms.ToolTip toolTip;


		#region Private Field Having Property
		private XGrid grid = null;
		#endregion

		#region Properties
		/// <summary>
		/// 개체를 포함하는 Grid를 가져옵니다.
		/// </summary>
		internal XGrid Grid
		{
			get{return grid;}
			set{grid = value;}
		}
		internal string ToolTipText
		{
			get{return toolTip.GetToolTip(this);}
			set{toolTip.SetToolTip(this,value);}
		}
		internal bool ToolTipActive
		{
			get{return toolTip.Active;}
			set{toolTip.Active = value;}
		}
		#endregion
		
		#region Protected Override Method
		/// <summary>
		/// 지정된 키가 일반 입력 키인지 또는 전처리를 필요로 하는 특수 키인지 여부를 확인합니다.
		/// (override) ArrowKey, TAB 키는 일반 입력 Key로 판단함.
		/// </summary>
		/// <param name="keyData"> Keys Enum </param>
		/// <returns> 지정된 키가 일반 입력 키이면 true이고, 그렇지 않으면 false </returns>
		protected override bool IsInputKey(Keys keyData)
		{
			//ArrowKey, Tab Key는 일반입력키임
			switch (keyData)
			{
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
				case Keys.Tab:
					return true;
				default:
					return base.IsInputKey(keyData);
			}
		}
		#endregion
	}
}
