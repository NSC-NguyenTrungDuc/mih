using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms.Design;
using System.Collections;
using System.Data;

namespace IHIS.Framework
{
	/// <summary>
	/// XEditGridCellEditor에 대한 요약 설명입니다.
	/// </summary>
	internal class XEditGridCellEditor : System.Drawing.Design.UITypeEditor
	{
		//IWindowsFormsEditorService Interface 
		//Windows Forms 대화 상자나 폼 그리고 드롭다운 목록 컨트롤을 표시할 인터페이스를 제공합니다
		private IWindowsFormsEditorService edSvc = null;

		/*
		 * 사용자 지정 디자인 타임 UI 형식 편집기를 구현하려면 다음을 반드시 수행해야 합니다. 
		   1.System.Drawing.Design.UITypeEditor에서 파생되는 클래스를 정의합니다. 
		   2.EditValue 메서드를 재정의하여 사용자 인터페이스, 사용자 입력 처리 및 값 할당을 처리합니다. 
		   3.GetEditStyle 메서드를 재정의하여 해당 편집기에서 사용할 편집기 스타일 형식을 속성 창에 알립니다. 
		   4.다음 사항을 구현하여 속성 창에서 값 표현을 칠하기 위한 추가 지원을 추가할 수 있습니다. 
		   5.GetPaintValueSupported를 재정의하여 해당 편집기에서 값 표시를 표시할 수 있음을 나타냅니다. 
		   6.PaintValue를 재정의하여 값 표시의 표시 기능을 구현합니다. 
		 */

		/// <summary>
		/// GetEditStyle에 표시된 편집기 스타일을 사용하여 지정된 개체의 값을 편집합니다.
		/// </summary>
		/// <param name="context"> 추가 컨텍스트 정보를 얻는 데 사용할 수 있는 ITypeDescriptorContext </param>
		/// <param name="provider"> 이 편집기에서 서비스를 얻는 데 사용할 수 있는 IServiceProvider </param>
		/// <param name="value"> 편집할 개체입니다. </param>
		/// <returns> 개체의 새 값 </returns>
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
					//Editor는 CellGrid, CellGridCellInfoParam에서 Call
					if (context.Instance is XEditGrid)
					{
						// 속성창 ShowDialog에 표시할 Form 생성
						XEditGridCellEditorForm dlg = new  XEditGridCellEditorForm( context.Instance , (XGridCellCollection) value, provider);
						//Dialog Show
						//ComponentChanged Event가 발생하지 않으면 이 편집기를 호출한 Form에서는 변경여부를 알수가 없으므로
						//InitializeComponent()를 다시 설정하지 않는다. 따라서, 반드시 해주어야 함.
                        if (edSvc.ShowDialog(dlg) == DialogResult.OK)
                        {
                            /* .net 2003 context.OnComponentChanged() 만 Call하면 InitialzeComponent 에 변경된 Component의 속성이 반영
                             * .NET 2005 context.OnComponentChanged() Call로 반영안됨
                             * 따라서, 각 Compoent별로 Component가 변경됨을 Designer에 알려주어야 함.
                             */
                            IComponentChangeService iComp = (IComponentChangeService)provider.GetService(typeof(IComponentChangeService));
                            if (iComp != null)
                            {
                                foreach (XEditGridCell info in (XGridCellCollection)value)
                                    iComp.OnComponentChanged(info, null, null, null);
                            }

                            //변경된 CellInfos로 다른 정보 변경
                            ((XEditGrid)context.Instance).ModifyOtherColumnInfos((XGridCellCollection)value);
                            // DesignMode에서도 DataGrid 의 각 Column정보 초기화
                            ((XEditGrid)context.Instance).InitializeColumns();
                        }
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
				return UITypeEditorEditStyle.Modal;  //  Modal상자 형식으로 속성창에 표시
			}
			return base.GetEditStyle(context);
		}

	}

}
