using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using EnvDTE;

namespace IHIS.Framework
{
    /// <summary>
    /// BindVarItemsEditor
    /// </summary>
    // UITypeEditor 상속 Editor
    internal class BindVarItemsEditor : System.Drawing.Design.UITypeEditor
    {
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
                    IDesignerHost host = (IDesignerHost)provider.GetService(typeof(IDesignerHost));
                    // 속성창 ShowDialog에 표시할 Form 생성
                    BindVarItemsEditorForm dlg = new BindVarItemsEditorForm((BindVarItemCollection)value, host, provider);
                    if (edSvc.ShowDialog(dlg) == DialogResult.OK)
                    {
                        //context.OnComponentChanged();  // ComponentChanged 이벤트를 발생시켜 InitialzeComponent에 반영되록함
                        /* .net 2003 context.OnComponentChanged() 만 Call하면 InitialzeComponent 에 변경된 Component의 속성이 반영
                             * .NET 2005 context.OnComponentChanged() Call로 반영안됨
                             *  따라서, 각 Compoent별로 Component가 변경됨을 Designer에 알려주어야 함.
                             */
                        IComponentChangeService iComp = (IComponentChangeService)provider.GetService(typeof(IComponentChangeService));
                        if (iComp != null)
                        {
                            foreach (BindVarItem info in (BindVarItemCollection)value)
                                iComp.OnComponentChanged(info, null, null, null);
                        }
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
