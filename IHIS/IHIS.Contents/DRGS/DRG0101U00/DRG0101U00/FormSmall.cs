using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using IHIS.Framework;

namespace IHIS.DRGS
{
	/// <summary>
	/// FormSmall에 대한 요약 설명입니다.
	/// </summary>
	public class FormSmall : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel plnTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XTreeView tv;
		private IHIS.Framework.MultiLayout layCode;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnOk;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private string code = string.Empty;
		private string mSmallCode = string.Empty;

		private IHIS.Framework.XButton btnCanCel;
		private string name = string.Empty;
		internal string GetCode
		{
			get{return code;}
		}
		internal string GetName
		{
			get{return name;}
		}

		public FormSmall(Control cont, string smallCode)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			mSmallCode = smallCode;

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//

			// 위치조정(Find창을 Call한 Control의 하단에
			if (cont != null)
			{
				/*Screen이 2개이상일 경우에는 rc의 Width는 두 모니터의 Width를 더한값, Height는
				 *Second화면의 해상도가 같으면 관계없으나, 해상도가 다르면 Second화면의 WorkingArea의 Y는
				 *0부터시작하지않고, Primary의 기준에서 얼만큼 높이에 있는냐로 처리됨.
				 *ex> Primary : 1280*1024 Second 1024*768이면 Primary.WorkingArea(0,0,1280,994) Second.WorkingArea(1280,256,1024,768)
				 *따라서, 높이는 Second의 WorkingArea의 Y + Height로 설정해야함
				 */
				Rectangle rc = Screen.PrimaryScreen.WorkingArea;
				// 위치 조정(Dual Monitor일때 Second화면에 있으면 X값은 Primary화면의Width + Second에서의 위치로 표시됨
				Point pos = cont.PointToScreen(new Point(0, cont.Height));
				if (SystemInformation.MonitorCount > 1)
				{
					//pos.X가 Second Monitor에 있으면 rc 변경
					if (pos.X > rc.Width)
					{
						Rectangle sRect = Screen.AllScreens[1].WorkingArea;
						rc = new Rectangle(rc.X, rc.Y, rc.Width + sRect.Width, sRect.Y + sRect.Height);
					}
				}

				if (this.Width > rc.Width - pos.X)
				{
					pos.X = Math.Max(rc.Width - this.Width, 0);
				}
				if (this.Height > rc.Height - pos.Y)
				{
					if (this.Height > pos.Y - cont.Height)
						pos.Y = Math.Max(rc.Height - this.Height, 0);
					else
						pos.Y -= (this.Height + cont.Height);
				}
				this.Location = pos;
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
            this.plnTop = new IHIS.Framework.XPanel();
            this.tv = new IHIS.Framework.XTreeView();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnCanCel = new IHIS.Framework.XButton();
            this.btnOk = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.layCode = new IHIS.Framework.MultiLayout();
            this.plnTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layCode)).BeginInit();
            this.SuspendLayout();
            // 
            // plnTop
            // 
            this.plnTop.Controls.Add(this.tv);
            this.plnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnTop.Location = new System.Drawing.Point(0, 0);
            this.plnTop.Name = "plnTop";
            this.plnTop.Size = new System.Drawing.Size(312, 455);
            this.plnTop.TabIndex = 0;
            // 
            // tv
            // 
            this.tv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(312, 455);
            this.tv.TabIndex = 1;
            this.tv.DoubleClick += new System.EventHandler(this.tv_DoubleClick);
            this.tv.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_BeforeSelect);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCanCel);
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 455);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(312, 32);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCanCel
            // 
            this.btnCanCel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanCel.Location = new System.Drawing.Point(8, 4);
            this.btnCanCel.Name = "btnCanCel";
            this.btnCanCel.Size = new System.Drawing.Size(56, 24);
            this.btnCanCel.TabIndex = 2;
            this.btnCanCel.Text = "取消";
            this.btnCanCel.Click += new System.EventHandler(this.btnCanCel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(200, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 24);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "選択";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnClose.Location = new System.Drawing.Point(256, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "閉じる";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // layCode
            // 
            this.layCode.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layCode_QueryEnd);
            // 
            // FormSmall
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(312, 509);
            this.Controls.Add(this.plnTop);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FormSmall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "効能別分類";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.plnTop, 0);
            this.plnTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layCode)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			ServiceCall();
		}

		private void ServiceCall()
		{
            if (!DsvMaster("1", "%", "%"))
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
		}

        private bool DsvMaster(string gubun, string code, string code1)
        {
            switch (gubun)
            {
                case "1":
                    layCode.QuerySQL = @"SELECT '1', CODE, CODE_NAME FROM DRG0140 WHERE HOSP_CODE = :f_hosp_code ORDER BY CODE";
                    break;

                case "2":
                    layCode.QuerySQL = @"SELECT '2', CODE1, CODE_NAME1 FROM DRG0141 WHERE CODE = :f_code AND HOSP_CODE = :f_hosp_code ORDER BY CODE1";
                    break;

                case "3":
                    layCode.QuerySQL = @"SELECT '3', CODE2, CODE_NAME2 FROM DRG0142 WHERE CODE = :f_code AND CODE1 = :f_code1 AND HOSP_CODE = :f_hosp_code ORDER BY CODE2";
                    break;
            }

            layCode.SetBindVarValue("f_code", code);
            layCode.SetBindVarValue("f_code1", code1);
            layCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (!layCode.QueryLayout(false))
            {
                return false;
            }
            return true;
        }

		#region 리스트를 조회한다.



		private void setCodeList(TreeNode agrTode)
		{

//			if(this.layCode.RowCount > 0)
//			{
//				string opreserdate = string.Empty;
//				foreach(DataRow dr in layCode.LayoutTable.Rows)
//				{
//					TreeNode tn = new TreeNode(dr["code_name"].ToString());
//					tn.Tag = new string[]{dr["kind"].ToString(), dr["code"].ToString(), dr["code_name"].ToString()};
//					agrTode.Nodes.Add(tn);
//				}
//				agrTode.ExpandAll();
//			}
		}
		#endregion 

		private void tv_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			
			if (e.Node.Tag == null) 
			{
				return;
			}
			if (e.Node.GetNodeCount(false) > 0) return;

			string[] kind = (string[])e.Node.Tag;
			switch(kind[0])
			{
				case "1":
                    if (DsvMaster("2", kind[1], "%")) XMessageBox.Show(Service.ErrFullMsg);
					setCodeList(e.Node);
					break;
				case "2":
                    if (DsvMaster("3", ((string[])e.Node.Parent.Tag)[1], kind[1])) XMessageBox.Show(Service.ErrFullMsg);
					setCodeList(e.Node);
					break;
				default:
					break;
			}
			
		}

		private void tv_DoubleClick(object sender, System.EventArgs e)
		{
			TreeNode tr = tv.SelectedNode;
			if (tr.Tag == null) return;
			if (!tr.IsSelected) return;
			if( ((string[])tr.Tag)[0].ToString() == "3" )
			{
				code = ((string[])tr.Tag)[1].ToString();		

			    name = tr.Text;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			TreeNode tr = tv.SelectedNode;
			if (tr.Tag == null) return;
			if (!tr.IsSelected) return;
			if( ((string[])tr.Tag)[0].ToString() == "3" )
			{
				code = 	((string[])tr.Tag)[1].ToString().Trim();	
				name = tr.Text;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		private void btnCanCel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			code="";
			name="";
			this.Close();
		}

        private void layCode_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess == true)
            {
                TreeNode rootNode = new TreeNode("効能別分類");
                tv.Nodes.Add(rootNode);
                setCodeList(rootNode);
            }
        }
	
	}
}
