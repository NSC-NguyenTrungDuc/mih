using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
	/// <summary>
	/// FocusColumnNameEditor에 대한 요약설명입니다.
	/// 행삽입,행삭제후 Focus를 줄 컬럼명 속셩의 편집기입니다.
	/// </summary>
	internal class FocusColumnNameEditor : System.Drawing.Design.UITypeEditor
	{
		//IWindowsFormsEditorService Interface 
		//Windows Forms 대화 상자나 폼 그리고 드롭다운 목록 컨트롤을 표시할 인터페이스를 제공합니다
		private IWindowsFormsEditorService edSvc = null;
		
		/// <summary>
		/// GetEditStyle에 표시된 편집기 스타일을 사용하여 지정된 개체의 값을 편집합니다.
		/// </summary>
		/// <param name="context"> 추가 컨텍스트 정보를 얻는 데 사용할 수 있는 ITypeDescriptorContext </param>
		/// <param name="provider"> 이 편집기에서 서비스를 얻는 데 사용할 수 있는 IServiceProvider </param>
		/// <param name="value"> 편집할 개체입니다. </param>
		/// <returns> 개체의 새 값 </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			XGridCellCollection cellInfos;

			if (context != null
				&& context.Instance != null
				&& provider != null) 
			{
				
				//서비스 개체 즉, 다른 개체에 대한 사용자 지정 지원을 제공하는 개체를 검색하는 메커니즘을 정의합니다.
				//[ComVisible(false)] object GetService(Type serviceType); 지정된 형식의 서비스 개체를 가져옵니다
				edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

				if (edSvc != null)
				{
					if (context.Instance is XEditGrid)
					{
						cellInfos = ((XEditGrid) context.Instance).CellInfos;

						if (cellInfos.Count < 1)
						{
							MessageBox.Show("CellInfos 정보(컬럼정보)를 먼저 입력하십시오.");
							return value;
						}
						string colName = "";
						if (value.ToString() == "")
							colName = "(없음)";
						else
							colName = value.ToString();

						FocusColumnNameEditorControl editorControl = new FocusColumnNameEditorControl(colName, cellInfos);
						editorControl.Click += new EventHandler(this.ValueChanged);
						// DropDown형식으로 Editor표시
						edSvc.DropDownControl(editorControl);

						// Value는 SelectedItem Set
						colName = editorControl.SelectedItem.ToString();
						if (colName == "(없음)")
							value = string.Empty;
						else
							value = colName;

						context.OnComponentChanged();
					}
				}
			}
			return value;
		}
		
		/// <summary>
		/// EditValue 메서드에서 사용하는 편집기 스타일을 가져옵니다.
		/// </summary>
		/// <param name="context"> 추가 컨텍스트 정보를 얻는 데 사용할 수 있는 ITypeDescriptorContext </param>
		/// <returns> EditValue에서 사용하는 편집기 스타일을 나타내는 UITypeEditorEditStyle 값 </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if (context != null && context.Instance != null) 
			{
				//UITypeEditorStyle Enum : UITypeEditor의 값 편집 스타일을 나타내는 식별자를 지정
				//DropDown 드롭다운 대화 상자에 호스팅될 사용자 인터페이스 및 아래쪽 화살표 단추를 표시합니다. 
				//Modal 모달 대화 상자를 시작하는 ... 단추를 표시합니다. 
				//None 대화형 UI(사용자 인터페이스) 구성 요소를 제공하지 않습니다. 
				return UITypeEditorEditStyle.DropDown;  //  Modal상자 형식으로 속성창에 표시
			}
			return base.GetEditStyle(context);
		}

		private void ValueChanged(object sender, EventArgs e) 
		{
			if (edSvc != null) 
			{
				// DropDonw한 Editor Close
				edSvc.CloseDropDown();
			}
		}
	}

	internal class FocusColumnNameEditorControl : ListBox
	{
		public FocusColumnNameEditorControl(string columnName, XGridCellCollection cellInfos)
		{
			this.Items.Add("(없음)");
			// ListBox의 Item SET
			foreach(XGridCell info in cellInfos)
			{
				this.Items.Add(info.CellName);
			}
			//Select
			this.SelectedItem = (object) columnName;
		}
	}
}