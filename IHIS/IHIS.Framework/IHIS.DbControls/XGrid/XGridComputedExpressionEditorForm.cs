using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;

namespace IHIS.Framework
{
	/// <summary>
	/// XGridComputedExpressionEditorForm에 대한 요약 설명입니다.
	/// </summary>
	public class XGridComputedExpressionEditorForm : System.Windows.Forms.Form
	{
		private XGridCellCollection cellInfos = null;
		private XGridComputedKind computedKind = XGridComputedKind.Text;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnVerify;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox funcList;
		private System.Windows.Forms.ListBox colList;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtExp;
		private System.Windows.Forms.Label label4;
		private IHIS.Framework.XComboBox cboGroup;
		private System.Windows.Forms.Label label5;

		/// <summary>
		/// 지정한 Expression을 가져옵니다.
		/// </summary>
		public string Expression
		{
			get { return txtExp.Text;}
		}
		/// <summary>
		/// 지정한 GroupName을 가져옵니다.
		/// </summary>
		public string GroupName
		{
			get { return cboGroup.GetDataValue();}
		}
		/// <summary>
		/// 지정한 Expression의 XGridComputedKind를 가져옵니다.
		/// </summary>
		public XGridComputedKind ComputedKind
		{
			get { return this.computedKind;}
		}

		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		/// <summary>
		/// XGridComputedExpressionEditorForm 생성자
		/// </summary>
		/// <param name="changableGroup"></param>
		/// <param name="cellInfos"></param>
		/// <param name="groupInfos"></param>
		/// <param name="groupName"></param>
		/// <param name="expression"></param>
		public XGridComputedExpressionEditorForm(bool changableGroup, XGridCellCollection cellInfos, XGridGroupInfoCollection groupInfos, string groupName, string expression)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			this.cellInfos = cellInfos;
			
			//funcList Set
			funcList.Items.AddRange(XGridUtility.ExpressionFunctions);
			//colList Set
			foreach (XGridCell info in cellInfos)
				colList.Items.Add(info.CellName);

			// Group변경가능하면 Group SET
			if (changableGroup)
			{
				cboGroup.DataSource = null;
				cboGroup.ComboItems.Add(XGridUtility.FooterGroupName,XGridUtility.FooterGroupName);
				foreach (XGridGroupInfo info in groupInfos)
					cboGroup.ComboItems.Add(info.GroupName, info.GroupName);
				//ComboItem설정후 DataSource다시 연결
				cboGroup.DataSource = cboGroup.ComboItems;
				cboGroup.DisplayMember = "DisplayItem";
				cboGroup.ValueMember = "ValueItem";
				//groupName SET
				cboGroup.SetDataValue(groupName);
			}
			else
			{
				cboGroup.DataSource = null;
				//groupName만 SET
				cboGroup.ComboItems.Add(groupName,groupName);
				//ComboItem설정후 DataSource다시 연결
				cboGroup.DataSource = cboGroup.ComboItems;
				cboGroup.DisplayMember = "DisplayItem";
				cboGroup.ValueMember = "ValueItem";
				//groupName SET
				cboGroup.SetDataValue(groupName);
				cboGroup.Protect = true;  // Group 변경불가
			}

			//expression Set
			txtExp.Text = expression;
			//SelectAll
			txtExp.SelectAll();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOK = new IHIS.Framework.XButton();
			this.btnCancel = new IHIS.Framework.XButton();
			this.btnVerify = new IHIS.Framework.XButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.funcList = new System.Windows.Forms.ListBox();
			this.colList = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtExp = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cboGroup = new IHIS.Framework.XComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(308, 112);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(68, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(308, 204);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(68, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			// 
			// btnVerify
			// 
			this.btnVerify.Location = new System.Drawing.Point(308, 160);
			this.btnVerify.Name = "btnVerify";
			this.btnVerify.Scheme = IHIS.Framework.XButtonSchemes.Silver;
			this.btnVerify.Size = new System.Drawing.Size(68, 23);
			this.btnVerify.TabIndex = 5;
			this.btnVerify.Text = "Verify";
			this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "※ Function List";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label2.Location = new System.Drawing.Point(148, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "※ Columns";
			// 
			// funcList
			// 
			this.funcList.ItemHeight = 12;
			this.funcList.Location = new System.Drawing.Point(8, 96);
			this.funcList.Name = "funcList";
			this.funcList.Size = new System.Drawing.Size(136, 136);
			this.funcList.Sorted = true;
			this.funcList.TabIndex = 2;
			this.funcList.DoubleClick += new System.EventHandler(this.funcList_DoubleClick);
			// 
			// colList
			// 
			this.colList.ItemHeight = 12;
			this.colList.Location = new System.Drawing.Point(148, 96);
			this.colList.Name = "colList";
			this.colList.Size = new System.Drawing.Size(136, 136);
			this.colList.Sorted = true;
			this.colList.TabIndex = 3;
			this.colList.DoubleClick += new System.EventHandler(this.colList_DoubleClick);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label3.Location = new System.Drawing.Point(8, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "※ Expression";
			// 
			// txtExp
			// 
			this.txtExp.Location = new System.Drawing.Point(104, 32);
			this.txtExp.Name = "txtExp";
			this.txtExp.Size = new System.Drawing.Size(280, 21);
			this.txtExp.TabIndex = 1;
			this.txtExp.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "※ Group 선택";
			// 
			// cboGroup
			// 
			this.cboGroup.DisplayMember = "DisplayItem";
			this.cboGroup.Location = new System.Drawing.Point(104, 4);
			this.cboGroup.Name = "cboGroup";
			this.cboGroup.Size = new System.Drawing.Size(280, 20);
			this.cboGroup.TabIndex = 0;
			this.cboGroup.ValueMember = "ValueItem";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(192, 60);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(192, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "< Text는 \"\"로 묶어야 합니다. >";
			// 
			// XGridComputedExpressionEditorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(390, 240);
			this.ControlBox = false;
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtExp);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.colList);
			this.Controls.Add(this.funcList);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnVerify);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cboGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "XGridComputedExpressionEditorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Computed 컬럼 편집기";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(this.txtExp.Text == "")
			{
				XMessageBox.Show("Expression을 입력하십시오.");
				return;
			}
			string errMsg = "";
			//Expression이 제대로 되지 않음
			if (!XGridUtility.VerifyExpression(this.cellInfos, txtExp.Text, out errMsg))
			{
				XMessageBox.Show(errMsg, "Verify Expression");
				return;
			}
			
			this.computedKind = XGridUtility.GetXGridComputedKindByExpression(txtExp.Text);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnVerify_Click(object sender, System.EventArgs e)
		{
			if(this.txtExp.Text == "")
			{
				XMessageBox.Show("Expression을 입력하십시오.");
				return;
			}
			string errMsg = "";
			if (!XGridUtility.VerifyExpression(this.cellInfos, txtExp.Text, out errMsg))
				XMessageBox.Show(errMsg, "Verify Expression");
			else
				XMessageBox.Show("Expression is OK", "Verify Expression");

		}

		private void funcList_DoubleClick(object sender, System.EventArgs e)
		{
			string func = funcList.SelectedItem.ToString();
			SetExpressionText(func);
			
		}
		private void SetExpressionText(string exp)
		{
			int strPos = txtExp.SelectionStart;
			int pos1 = exp.IndexOf("(");
			int pos2 = exp.IndexOf(")");
			txtExp.SelectedText = exp;
			if(pos1 >= 0)
			{
				txtExp.SelectionStart = strPos + pos1 + 1;
				txtExp.SelectionLength = pos2 - pos1 -1;
			}
			txtExp.Focus();
		}

		private void colList_DoubleClick(object sender, System.EventArgs e)
		{
			string col = colList.SelectedItem.ToString();
			SetExpressionText(col);
		}
	}
}
