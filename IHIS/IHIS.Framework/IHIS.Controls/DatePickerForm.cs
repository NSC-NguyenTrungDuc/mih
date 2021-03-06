using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// DatePickerForm에 대한 요약 설명입니다.
	/// </summary>
	internal class DatePickerForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.MonthCalendar calendar;
		internal IHIS.Framework.XButton btnCancel;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DatePickerForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			//this.btnCancel.Text = "Cancel"; //취소

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

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatePickerForm));
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.btnCancel = new IHIS.Framework.XButton();
            this.SuspendLayout();
            // 
            // calendar
            // 
            resources.ApplyResources(this.calendar, "calendar");
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            // 
            // DatePickerForm
            // 
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.calendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DatePickerForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

		}
		#endregion
	}
}
