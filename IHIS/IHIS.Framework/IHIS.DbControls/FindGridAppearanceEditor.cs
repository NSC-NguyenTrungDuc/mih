using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
	/// <summary>
	/// FindGridAppearanceEditor에 대한 요약 설명입니다.
	/// </summary>

	// UITypeEditor 상속 Editor
	[Serializable]
	internal class FindGridAppearanceEditor : System.Drawing.Design.UITypeEditor 
	{
		//IWindowsFormsEditorService Interface 
		//Windows Forms 대화 상자나 폼 그리고 드롭다운 목록 컨트롤을 표시할 인터페이스를 제공합니다
		private IWindowsFormsEditorService edSvc = null;


		//GetEditStyle에 표시된 편집기 스타일을 사용하여 지정된 개체의 값을 편집
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			if (context != null
				&& context.Instance != null
				&& provider != null) 
			{
				
				//서비스 개체 즉, 다른 개체에 대한 사용자 지정 지원을 제공하는 개체를 검색하는 메커니즘을 정의합니다.
				//[ComVisible(false)] object GetService(Type serviceType); 지정된 형식의 서비스 개체를 가져옵니다
				edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

				if (edSvc != null) 
				{
					// ColInfos에 자료가 없으면 ColInfo입력 먼저 처리
					if (((FindColumnInfoCollection) value).Count <= 0)
					{
						MessageBox.Show("컬럼 정보를 먼저 입력하십시오.");
						return value;
					}

					// 속성창 ShowDialog에 표시할 Form 생성
					FindGridAppearanceEditorForm dlg = new FindGridAppearanceEditorForm((FindColumnInfoCollection) value);
					//Dialog Show
					if( edSvc.ShowDialog(dlg) == DialogResult.OK)
					{
						context.OnComponentChanged();  // ComponentChanged 이벤트를 발생시켜 InitialzeComponent에 반영되록함
					}
					
				}
			}

			return value;
		}
		
		//EditValue 메서드에서 사용하는 편집기 스타일을 가져옵니다
		//public virtual UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context);
		// GetEditStyle 재정의
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if (context != null && context.Instance != null) 
			{
				//UITypeEditorStyle Enum : UITypeEditor의 값 편집 스타일을 나타내는 식별자를 지정
				//DropDown 드롭다운 대화 상자에 호스팅될 사용자 인터페이스 및 아래쪽 화살표 단추를 표시합니다. 
				//Modal 모달 대화 상자를 시작하는 ... 단추를 표시합니다. 
				//None 대화형 UI(사용자 인터페이스) 구성 요소를 제공하지 않습니다. 
				return UITypeEditorEditStyle.Modal;  //  Modal상자 형식으로 속성창에 표시
			}
			return base.GetEditStyle(context);
		}
	}
}
