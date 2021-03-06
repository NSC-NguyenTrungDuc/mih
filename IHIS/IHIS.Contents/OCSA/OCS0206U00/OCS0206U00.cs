#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0206U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0206U00 : IHIS.Framework.XScreen
	{
		#region [DynService Control]
		#endregion

		#region [Instance Variable]
		//Doctor
		string mDoctor = "";
		//Message처리
        string mbxMsg = "", mbxCap = "";

        string mHospCode = EnvironInfo.HospCode;
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XFlatLabel lblHangmog_name;
		private IHIS.Framework.XFindBox fbxHangmog_code;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XMstGrid grdOCS0206;
		private IHIS.Framework.XEditGrid grdOCS0207;
		private IHIS.Framework.XFindWorker fdwHangmog_code;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.PictureBox pictureBox1;
		
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0206U00()
		{
            /* SavePerformer 생성 */
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdOCS0206.SavePerformer = new XSavePerformer(this);
            this.grdOCS0207.SavePerformer = this.grdOCS0206.SavePerformer;
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdOCS0206);
            this.SaveLayoutList.Add(this.grdOCS0207);
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

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0206U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.lblHangmog_name = new IHIS.Framework.XFlatLabel();
            this.fbxHangmog_code = new IHIS.Framework.XFindBox();
            this.fdwHangmog_code = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOCS0206 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdOCS0207 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0206)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0207)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.lblHangmog_name);
            this.xPanel1.Controls.Add(this.fbxHangmog_code);
            this.xPanel1.Controls.Add(this.pictureBox1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(898, 34);
            this.xPanel1.TabIndex = 0;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Location = new System.Drawing.Point(12, 6);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(88, 20);
            this.xLabel3.TabIndex = 15;
            this.xLabel3.Text = "オ―ダコード";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHangmog_name
            // 
            this.lblHangmog_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHangmog_name.Location = new System.Drawing.Point(208, 6);
            this.lblHangmog_name.Name = "lblHangmog_name";
            this.lblHangmog_name.Size = new System.Drawing.Size(310, 20);
            this.lblHangmog_name.TabIndex = 14;
            // 
            // fbxHangmog_code
            // 
            this.fbxHangmog_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHangmog_code.FindWorker = this.fdwHangmog_code;
            this.fbxHangmog_code.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fbxHangmog_code.Location = new System.Drawing.Point(102, 6);
            this.fbxHangmog_code.Name = "fbxHangmog_code";
            this.fbxHangmog_code.Size = new System.Drawing.Size(104, 20);
            this.fbxHangmog_code.TabIndex = 13;
            this.fbxHangmog_code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHangmog_code_DataValidating);
            this.fbxHangmog_code.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxHangmog_code_FindClick);
            // 
            // fdwHangmog_code
            // 
            this.fdwHangmog_code.AutoQuery = false;
            this.fdwHangmog_code.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fdwHangmog_code.FormText = "オ―ダコード";
            this.fdwHangmog_code.InputSQL = resources.GetString("fdwHangmog_code.InputSQL");
            this.fdwHangmog_code.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fdwHangmog_code.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "hangmog_code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.Yes;
            this.findColumnInfo1.HeaderText = "オ―ダコード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "hangmog_name";
            this.findColumnInfo2.ColWidth = 449;
            this.findColumnInfo2.HeaderText = "オ―ダコード名";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(896, 32);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xButtonList1);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Location = new System.Drawing.Point(0, 544);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(898, 42);
            this.xPanel4.TabIndex = 3;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(466, 4);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.Size = new System.Drawing.Size(406, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdOCS0206);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 34);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(544, 510);
            this.xPanel2.TabIndex = 1;
            // 
            // grdOCS0206
            // 
            this.grdOCS0206.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdOCS0206.ColPerLine = 2;
            this.grdOCS0206.Cols = 2;
            this.grdOCS0206.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS0206.FixedRows = 1;
            this.grdOCS0206.FocusColumnName = "hangmog_code";
            this.grdOCS0206.HeaderHeights.Add(21);
            this.grdOCS0206.Location = new System.Drawing.Point(0, 0);
            this.grdOCS0206.Name = "grdOCS0206";
            this.grdOCS0206.QuerySQL = resources.GetString("grdOCS0206.QuerySQL");
            this.grdOCS0206.Rows = 2;
            this.grdOCS0206.Size = new System.Drawing.Size(542, 508);
            this.grdOCS0206.TabIndex = 0;
            this.grdOCS0206.UseDefaultTransaction = false;
            this.grdOCS0206.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdOCS0206_GridFindSelected);
            this.grdOCS0206.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0206_PreSaveLayout);
            this.grdOCS0206.CheckDetailLayout += new System.ComponentModel.CancelEventHandler(this.grdOCS0206_CheckDetailLayout);
            this.grdOCS0206.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0206_GridColumnChanged);
            this.grdOCS0206.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS0206_GridFindClick);
            this.grdOCS0206.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0206_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "doctor";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "doctor";
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "seq";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "seq";
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AutoInsertAtEnterKey = true;
            this.xEditGridCell3.CellName = "hangmog_code";
            this.xEditGridCell3.CellWidth = 121;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.FindWorker = this.fdwHangmog_code;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "オ―ダコード";
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "hangmog_name";
            this.xEditGridCell4.CellWidth = 380;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "オ―ダコード名";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ord_danui";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "ord_danui";
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdOCS0207);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(544, 34);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(354, 510);
            this.xPanel3.TabIndex = 2;
            // 
            // grdOCS0207
            // 
            this.grdOCS0207.CallerID = '2';
            this.grdOCS0207.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10});
            this.grdOCS0207.ColPerLine = 3;
            this.grdOCS0207.Cols = 3;
            this.grdOCS0207.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS0207.FixedRows = 1;
            this.grdOCS0207.FocusColumnName = "weight";
            this.grdOCS0207.HeaderHeights.Add(21);
            this.grdOCS0207.Location = new System.Drawing.Point(0, 0);
            this.grdOCS0207.MasterLayout = this.grdOCS0206;
            this.grdOCS0207.Name = "grdOCS0207";
            this.grdOCS0207.QuerySQL = resources.GetString("grdOCS0207.QuerySQL");
            this.grdOCS0207.Rows = 2;
            this.grdOCS0207.Size = new System.Drawing.Size(352, 508);
            this.grdOCS0207.TabIndex = 1;
            this.grdOCS0207.UseDefaultTransaction = false;
            this.grdOCS0207.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0207_QueryStarting);
            this.grdOCS0207.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0207_PreSaveLayout);
            this.grdOCS0207.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0207_GridColumnChanged);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "doctor";
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "hangmog_code";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "hangmog_code";
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "weight";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 86;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "体重";
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "suryang";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell9.CellWidth = 97;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "数量";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AutoInsertAtEnterKey = true;
            this.xEditGridCell10.CellName = "ord_danui";
            this.xEditGridCell10.CellWidth = 127;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell10.HeaderText = "処方単位";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(544, 34);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 510);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // OCS0206U00
            // 
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0206U00";
            this.Size = new System.Drawing.Size(898, 586);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0206)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0207)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			//Set M/D Relation
			grdOCS0207.SetRelationKey("doctor", "doctor");
			grdOCS0207.SetRelationKey("hangmog_code", "hangmog_code");

			//Set Current Grid
			this.CurrMSLayout = this.grdOCS0206;
			this.CurrMQLayout = this.grdOCS0206;

			//Create Combo
			CreateCombo();

			//의사코드를 가져온다.
			if(!LoadDoctor())
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "使用権限がありません。ご確認ください." : "사용권한이 없습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
				this.Close();		
			}

            if (!grdOCS0206.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
		}

		private bool LoadDoctor()
		{
			mDoctor = UserInfo.UserID;
			//의사코드를 가져온다. Load BAS0280
			return true;
		}

		#endregion

		#region [Combo 생성]

		private void CreateCombo()
		{
            IHIS.Framework.MultiLayout layoutCombo;
            layoutCombo = new MultiLayout();

            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("seq",  DataType.String);
            layoutCombo.InitializeLayoutTable();

            layoutCombo.QuerySQL = @"SELECT '', '00'
                                       FROM DUAL
                                      UNION ALL
                                     SELECT CODE||': '||CODE_NAME CODE_NAME, CODE SEQ
                                       FROM OCS0132
                                      WHERE CODE_TYPE = 'ORD_DANUI'
                                        AND HOSP_CODE = '" + mHospCode + @"'
                                      ORDER BY 2";

            if (layoutCombo.QueryLayout(true))
                grdOCS0207.SetComboItems("ord_danui", layoutCombo.LayoutTable, "code", "seq");
            else XMessageBox.Show(Service.ErrFullMsg);
		}

		#endregion

		#region [Load Code Name]
        
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
			string codeName = "";
            string cmdText  = "";
            object retVal   = null;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hangmog_code", code);
            bindVars.Add("f_hosp_code",    mHospCode);
            bindVars.Add("f_doctor",       mDoctor);

			if(code.Trim() == "" ) return codeName;

			switch (codeMode)
			{
				case "hangmog_code":

                    cmdText = @"SELECT A.HANGMOG_NAME
                                  FROM OCS0103 A
                                 WHERE A.HANGMOG_CODE = :f_hangmog_code
                                   AND A.HOSP_CODE    = :f_hosp_code";

                    retVal = Service.ExecuteScalar(cmdText, bindVars);

                    if (!TypeCheck.IsNull(retVal))
                    {
                        codeName = retVal.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }

					break;

				case "hangmog_code_check":

					cmdText = @"SELECT B.HANGMOG_NAME
                                  FROM OCS0206 A,
                                       OCS0103 B
                                 WHERE A.DOCTOR          = :f_doctor
                                   AND A.HANGMOG_CODE    = :f_hangmog_code
                                   AND A.HOSP_CODE       = :f_hosp_code
                                   AND B.HANGMOG_CODE(+) = A.HANGMOG_CODE
                                   AND B.HOSP_CODE   (+) = A.HOSP_CODE";

                    retVal = Service.ExecuteScalar(cmdText, bindVars);

                    if (!TypeCheck.IsNull(retVal))
                    {
                        codeName = retVal.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }

                    break;

				default:
					break;
			}

			return codeName;
		}

		#endregion

		private void fbxHangmog_code_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			lblHangmog_name.Text = "";
			lblHangmog_name.Text = this.GetCodeName("hangmog_code", e.DataValue.ToString());
            if (!grdOCS0206.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
		}

		#region [grdOCS0206 Event]

		private void grdOCS0206_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			e.Cancel= false;	

			switch (e.ColName)
			{
				case "hangmog_code":

					if(e.ChangeValue.ToString().Trim() == "" ) 
					{
						grdOCS0206.SetItemValue(e.RowNumber, "hangmog_name", "");
                        grdOCS0206.SetItemValue(e.RowNumber, "ord_danui", "");
						break;
					}
                    
					// 중복 Check
					// 현재 화면
					for(int i = 0; i < grdOCS0206.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdOCS0206.GetItemString(i, "hangmog_code").Trim() == e.ChangeValue.ToString().Trim() )
							{
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダコードに重複値があります。 ご確認ください。" : "항목코드가 중복됩니다. 확인바랍니다.";
								mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
								XMessageBox.Show(mbxMsg, mbxCap);
								e.Cancel= true;								
							}
						}
					}
 
					if(e.Cancel) break;

					// Delete Table Check
					// 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
					bool deleted = false;
					if(grdOCS0206.DeletedRowTable != null)
					{
						foreach(DataRow row in grdOCS0206.DeletedRowTable.Rows)
						{
							if(row[e.ColName].ToString() == e.ChangeValue.ToString())
							{
								deleted = true;
								break;
							}
						}
					}

					if(deleted) break;
                    
					//Check Origin Data
					string hangmog_name = this.GetCodeName("hangmog_code_check", e.ChangeValue.ToString());

					if(hangmog_name != "")
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダコードに重複値があります。 ご確認ください。" : "항목코드가 중복됩니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
						e.Cancel= true;	
						break;	
					}

                    string cmdText = "";
                    cmdText = @"SELECT A.HANGMOG_NAME
                                     , A.ORD_DANUI
                                  FROM OCS0103 A
                                 WHERE A.HANGMOG_CODE = :f_hangmog_code
                                   AND A.HOSP_CODE    = :f_hosp_code";
                    DataTable dtResult = new DataTable();
                    BindVarCollection bindVars = new BindVarCollection();
                    bindVars.Add("f_hangmog_code", e.ChangeValue.ToString().Trim());
                    bindVars.Add("f_hosp_code",    mHospCode);
                    dtResult = Service.ExecuteDataTable(cmdText, bindVars);

                    if (dtResult.Rows.Count > 0)
                    {
                        grdOCS0206.SetItemValue(e.RowNumber, "hangmog_name", dtResult.Rows[0]["hangmog_name"].ToString());
                        grdOCS0206.SetItemValue(e.RowNumber, "ord_danui",    dtResult.Rows[0]["ord_danui"].ToString());
                    }

					break;

				default:
					break;
			}

		
		}
        
		/// <summary>
		/// 일단 Data 처리를 위해 disable
		/// </summary>		
		private void grdOCS0206_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			switch (e.ColName)
			{
				case "hangmog_code":

					if(((XFindBox)((XEditGridCell)grdOCS0206.CellInfos[e.ColName]).CellEditor.Editor).GetDataValue().Trim() == "")
						fdwHangmog_code.AutoQuery = false;
					else
						fdwHangmog_code.AutoQuery = true;

					break;
				default:
					break;
			}
		}

		private void grdOCS0206_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
		{
			grdOCS0206.SetItemValue(e.RowNumber, "hangmog_name", e.ReturnValues.GetValue(1).ToString());
		}

		private void grdOCS0206_CheckDetailLayout(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(CheckDetailData(sender))
				e.Cancel = true;
			else
				e.Cancel = false;
		
		}
        
		/// <summary>
		/// Detail Data 존재여부를 check합니다.
		/// </summary>
		private bool CheckDetailData(object aGrd)
		{
			bool returnValue = false;

			if (aGrd == null) return returnValue;

			XMstGrid mstGrid = null;
            
			try
			{
				mstGrid = (XMstGrid)aGrd;
			}
			catch
			{
				return returnValue;
			}

			int chk = 0;

			try
			{
				foreach( object obj in this.Controls )
				{
					if( obj.GetType().Name.ToString().IndexOf("Panel") >= 0 )
					{
						foreach( object panObj in ((Panel)obj).Controls )
						{
							if( panObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)panObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)panObj).RowCount;						
							}
							else if( panObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)panObj).DeletedRowCount;

							}
							else if( panObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)panObj).DeletedRowCount;
							}
						}
					}
					else if( obj.GetType().Name.ToString().IndexOf("GroupBox") >= 0 )
					{
						foreach( object gbxObj in ((GroupBox)obj).Controls )
						{						
							if( gbxObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)gbxObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)gbxObj).RowCount;						
							}
							else if( gbxObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)gbxObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)gbxObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)gbxObj).DeletedRowCount;

							}
							else if( gbxObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)gbxObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)gbxObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)gbxObj).DeletedRowCount;
							}
						}
					}
					else if( obj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)obj).MasterLayout == mstGrid)
					{	
						chk = chk + ((XGrid)obj).RowCount;						
					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XEditGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XEditGrid)obj).DeletedRowCount;

					}
					else if( obj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XMstGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XMstGrid)obj).DeletedRowCount;
					}
				}
			}
			catch {}

			if(chk > 0)							
				returnValue = true;

			return returnValue;
		}

		#endregion

		#region [grdOCS0207 Event]

		private void grdOCS0207_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			switch (e.ColName)
			{
				case "weight":

					if(e.ChangeValue.ToString().Trim() == "" ) 
					{
						grdOCS0206.SetItemValue(e.RowNumber, "hangmog_name", "");
						grdOCS0206.SetItemValue(e.RowNumber, "ord_danui", "");
						break;
					}
                    
					// 중복 Check
					// 현재 화면
					for(int i = 0; i < grdOCS0207.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdOCS0207.GetItemString(i, "weight").Trim() == e.ChangeValue.ToString().Trim() )
							{
								mbxMsg = NetInfo.Language == LangMode.Jr ? "体重が重複されます. 確認してください." : " 체중이 중복됩니다. 확인바랍니다.";
								mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
								XMessageBox.Show(mbxMsg, mbxCap);
								e.Cancel= true;		
								break;
							}
						}
					} 
					break;

				default:
					break;
			}

		
		}

		#endregion

		#region [Control Event]

		private void fbxHangmog_code_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(fbxHangmog_code.GetDataValue().Trim() == "")
				fdwHangmog_code.AutoQuery = false;
			else
				fdwHangmog_code.AutoQuery = true;
		}

		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:

					e.IsBaseCall = false;
					
					DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

					if(chkCell.RowNumber < 0)
					{
						int currentRow = -1;
						if(this.CurrMSLayout == grdOCS0206)
						{
							currentRow = grdOCS0206.InsertRow();
							grdOCS0206.SetItemValue(currentRow, "doctor", mDoctor);
						}
						else
						{
							currentRow = grdOCS0207.InsertRow();
							grdOCS0207.SetItemValue(currentRow, "doctor", mDoctor);
							grdOCS0207.SetItemValue(currentRow, "hangmog_code", grdOCS0206.GetItemString(grdOCS0206.CurrentRowNumber, "hangmog_code"));
							grdOCS0207.SetItemValue(currentRow, "ord_danui", grdOCS0206.GetItemString(grdOCS0206.CurrentRowNumber, "ord_danui"));
						}
					}
					else
					{
						e.IsBaseCall = false;
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
					}
					
					break;

				case FunctionType.Update:

                    if (SaveMethod())
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
						SetMsg(mbxMsg);
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : "저장이 실패하였습니다.";
						mbxMsg = mbxMsg + "\n\r" + Service.ErrMsg;
						mbxCap = NetInfo.Language == LangMode.Jr ? "保存エラー" : "Save Error";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
					}

					break;

				case FunctionType.Delete:
                    
					break;

				default:

					break;
			}	
		}

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:
					
					break;

				default:

					break;
			}	
		
		}
		#endregion

		#region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
		/// <summary>
		/// Insert한 Row 중에 Not Null필드 미입력 Row Search
		/// </summary>
		/// <remarks>
		/// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
		/// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
		private DataGridCell GetEmptyNewRow(object aGrd)
		{
			DataGridCell celReturn = new DataGridCell(-1, -1);

			if (aGrd == null) return celReturn;

			XEditGrid grdChk = null;
            
			try
			{
				grdChk = (XEditGrid)aGrd;
			}
			catch
			{
				return celReturn;
			}

			foreach (XEditGridCell cell in grdChk.CellInfos)
			{
				// NotNull Check
				if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly) 
				{
					for( int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
					{
						if(grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
						{
							celReturn.ColumnNumber = cell.Col;
							celReturn.RowNumber   = rowIndex;
							break;
						}
					}

					if(celReturn.RowNumber < 0) 
						continue;
					else
						break;
				}

			}

			return celReturn;
		}

		#endregion

		#region [Service Control Event]

		/// <summary>
		/// 저장전 Validation Check
		/// </summary>
		private void dsvSave_ServiceStart(object sender, GridRecordEventArgs e)
		{
			AcceptData();

			//grdOCS0206
			for(int rowIndex = 0; rowIndex < grdOCS0206.RowCount; rowIndex++)
			{
				if(grdOCS0206.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
				{
					//Key값이 없으면 삭제처리
					if(grdOCS0206.GetItemString(rowIndex, "hangmog_code").Trim() == "" )
					{
						grdOCS0206.DeleteRow(rowIndex);
						rowIndex = rowIndex - 1;
						continue;
					}
				}

				if(grdOCS0206.GetItemString(rowIndex, "seq") != rowIndex.ToString()) grdOCS0206.SetItemValue(rowIndex, "seq", rowIndex + 1);
				
			}

			//grdOCS0207
			for(int rowIndex = 0; rowIndex < grdOCS0207.RowCount; rowIndex++)
			{
				if(grdOCS0207.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
				{					
					//Key값이 없으면 삭제처리
					if(grdOCS0207.GetItemString(rowIndex, "weight").Trim() == "" )
					{
						grdOCS0207.DeleteRow(rowIndex);
						rowIndex = rowIndex - 1;						
						continue;
					}
				}
			}

        }

        private void grdOCS0206_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            //AcceptData();

            
        }

        private void grdOCS0207_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            //AcceptData();

            
        }

        private bool SaveMethod()
        {
            for (int rowIndex = 0; rowIndex < grdOCS0206.RowCount; rowIndex++)
            {
                if (grdOCS0206.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0206.GetItemString(rowIndex, "hangmog_code").Trim() == "")
                    {
                        grdOCS0206.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (grdOCS0206.GetItemString(rowIndex, "seq") != rowIndex.ToString()) grdOCS0206.SetItemValue(rowIndex, "seq", rowIndex + 1);

            }

            for (int rowIndex = 0; rowIndex < grdOCS0207.RowCount; rowIndex++)
            {
                if (grdOCS0207.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0207.GetItemString(rowIndex, "weight").Trim() == "")
                    {
                        grdOCS0207.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }
            }

            try
            {
                Service.BeginTransaction();
                if (!grdOCS0206.SaveLayout()) throw new Exception();
                if (!grdOCS0207.SaveLayout()) throw new Exception();
            }
            catch
            {
                Service.RollbackTransaction();
                return false;
            }
            Service.CommitTransaction();
            return true;
        }
		#endregion

        #region 각 그리드에 바인드 변수 설정
        private void grdOCS0206_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0206.SetBindVarValue("f_doctor",       mDoctor);
            grdOCS0206.SetBindVarValue("f_hangmog_code", fbxHangmog_code.GetDataValue());
            grdOCS0206.SetBindVarValue("f_hosp_code",    mHospCode);
        }

        private void grdOCS0207_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0207.SetBindVarValue("f_doctor", mDoctor);
            grdOCS0207.SetBindVarValue("f_hangmog_code", grdOCS0206.GetItemString(grdOCS0206.CurrentRowNumber, "hangmog_code"));
            grdOCS0207.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS0206U00 parent = null;
            public XSavePerformer(OCS0206U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                string cmdDupChk = "";
                object retVal = null;
                //Grid에서 넘어온 Bind 변수에 q_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdDupChk = @"SELECT 'Y'
                                                FROM OCS0206
                                               WHERE DOCTOR       = :f_doctor
                                                 AND HANGMOG_CODE = :f_hangmog_code
                                                 AND HOSP_CODE    = :f_hosp_code
                                                 AND ROWNUM       = 1";
                                retVal = Service.ExecuteScalar(cmdDupChk, item.BindVarList);
                                if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show("既に同一データがあります。 ご確認ください。", "同一データ", MessageBoxIcon.Error);
                                    return false;
                                }

                                cmdText = @"INSERT INTO OCS0206
                                                  ( SYS_DATE    ,
                                                    SYS_ID      ,
                                                    DOCTOR      ,
                                                    SEQ         ,
                                                    HANGMOG_CODE,
                                                    HOSP_CODE
                                                  )
                                             VALUES
                                                  ( SYSDATE     ,
                                                    :q_user_id  ,
                                                    :f_doctor   ,
                                                    :f_seq      ,
                                                    :f_hangmog_code,
                                                    :f_hosp_code
                                                  )";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE OCS0206
                                               SET SEQ          = :f_seq
                                             WHERE DOCTOR       = :f_doctor
                                               AND HANGMOG_CODE = :f_hangmog_code
                                               AND HOSP_CODE    = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdDupChk = @"SELECT 'Y'
                                                FROM OCS0207 
                                               WHERE DOCTOR       = :f_doctor
                                                 AND HANGMOG_CODE = :f_hangmog_code
                                                 AND HOSP_CODE    = :f_hosp_code
                                                 AND ROWNUM       = 1";
                                retVal = Service.ExecuteScalar(cmdDupChk, item.BindVarList);
                                if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show("Detailにデータがあります。 ご確認ください。", "削除エラー", MessageBoxIcon.Error);
                                    return false;
                                }

                                cmdText = @"DELETE OCS0206 
                                             WHERE DOCTOR       = :f_doctor
                                               AND HANGMOG_CODE = :f_hangmog_code
                                               AND HOSP_CODE    = :f_hosp_code";
                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdDupChk = @"SELECT 'Y'
                                                FROM OCS0207 
                                               WHERE DOCTOR       = :f_doctor
                                                 AND HANGMOG_CODE = :f_hangmog_code
                                                 AND WEIGHT       = :f_weight
                                                 AND HOSP_CODE    = :f_hosp_code
                                                 AND ROWNUM       = 1";
                                retVal = Service.ExecuteScalar(cmdDupChk, item.BindVarList);
                                if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show("既に同一データがあります。 ご確認ください。", "同一データ", MessageBoxIcon.Error);
                                    return false;
                                }

                                cmdText = @"INSERT INTO OCS0207
                                                   ( SYS_DATE , SYS_ID     , DOCTOR      , HANGMOG_CODE,
                                                     WEIGHT   , SURYANG    , ORD_DANUI   , HOSP_CODE )
                                             VALUES  
                                                   ( SYSDATE  , :q_user_id , :f_doctor   , :f_hangmog_code, 
                                                     :f_weight, :f_suryang , :f_ord_danui, :f_hosp_code)";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE OCS0207             
                                               SET UPD_ID       = :q_user_id    ,
                                                   UPD_DATE     = SYSDATE       ,
                                                   SURYANG      = :f_suryang    ,
                                                   ORD_DANUI    = :f_ord_danui
                                             WHERE DOCTOR       = :f_doctor
                                               AND HANGMOG_CODE = :f_hangmog_code
                                               AND WEIGHT       = :f_weight
                                               AND HOSP_CODE    = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE OCS0207 
                                             WHERE DOCTOR       = :f_doctor
                                               AND HANGMOG_CODE = :f_hangmog_code
                                               AND WEIGHT       = :f_weight
                                               AND HOSP_CODE    = :f_hosp_code";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

    }
}

