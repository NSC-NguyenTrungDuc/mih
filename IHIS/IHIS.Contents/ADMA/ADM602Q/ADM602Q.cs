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

namespace IHIS.ADMA
{
	/// <summary>
	/// ADM602Q에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class ADM602Q : IHIS.Framework.XScreen
	{
		private DataTable objectListTable = new DataTable(); //Lock Object List 데이타 조회 Table

		private IHIS.Framework.XGrid grdList;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XGridCell xGridCell9;
		private IHIS.Framework.XGridCell xGridCell10;
		private IHIS.Framework.XGridCell xGridCell11;
		private IHIS.Framework.XGridCell xGridCell12;
		private IHIS.Framework.XGridCell xGridCell13;
		private IHIS.Framework.XGridCell xGridCell14;
		private IHIS.Framework.XGridCell xGridCell15;
		private IHIS.Framework.XGridCell xGridCell16;
		private IHIS.Framework.XGridCell xGridCell17;
		private System.Windows.Forms.Panel pnlBottom;
		private IHIS.Framework.XButton btnKill;
		private IHIS.Framework.XButtonList btnList;
		private System.Windows.Forms.Panel pnlBottom1;
		private IHIS.Framework.XGridCell xGridCell18;
		private IHIS.Framework.XGridCell xGridCell19;
		private IHIS.Framework.XTextBox txtSqlText;
		private IHIS.Framework.XGrid grdObjList;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ADM602Q()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			//objectListTable 컬럼 설정 (컬럼명은 grdObjList 컬럼명과 동일하게)
			//grdObjList에 ImportRowRange할 소스 DataTable
			objectListTable.Columns.Add("type", typeof(string));
			objectListTable.Columns.Add("name", typeof(string));
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

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			//Lock Session List 조회
			this.CurrMQLayout = this.grdList;

			//LOCK LIST 조회
			this.grdList.QueryLayout(true);
		}


		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ADM602Q));
			this.grdList = new IHIS.Framework.XGrid();
			this.xGridCell1 = new IHIS.Framework.XGridCell();
			this.xGridCell2 = new IHIS.Framework.XGridCell();
			this.xGridCell3 = new IHIS.Framework.XGridCell();
			this.xGridCell4 = new IHIS.Framework.XGridCell();
			this.xGridCell5 = new IHIS.Framework.XGridCell();
			this.xGridCell6 = new IHIS.Framework.XGridCell();
			this.xGridCell7 = new IHIS.Framework.XGridCell();
			this.xGridCell8 = new IHIS.Framework.XGridCell();
			this.xGridCell9 = new IHIS.Framework.XGridCell();
			this.xGridCell10 = new IHIS.Framework.XGridCell();
			this.xGridCell11 = new IHIS.Framework.XGridCell();
			this.xGridCell12 = new IHIS.Framework.XGridCell();
			this.xGridCell13 = new IHIS.Framework.XGridCell();
			this.xGridCell14 = new IHIS.Framework.XGridCell();
			this.xGridCell15 = new IHIS.Framework.XGridCell();
			this.xGridCell16 = new IHIS.Framework.XGridCell();
			this.xGridCell17 = new IHIS.Framework.XGridCell();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.btnKill = new IHIS.Framework.XButton();
			this.btnList = new IHIS.Framework.XButtonList();
			this.pnlBottom1 = new System.Windows.Forms.Panel();
			this.txtSqlText = new IHIS.Framework.XTextBox();
			this.grdObjList = new IHIS.Framework.XGrid();
			this.xGridCell18 = new IHIS.Framework.XGridCell();
			this.xGridCell19 = new IHIS.Framework.XGridCell();
			((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
			this.pnlBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
			this.pnlBottom1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdObjList)).BeginInit();
			this.SuspendLayout();
			// 
			// grdList
			// 
			this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
																			   this.xGridCell1,
																			   this.xGridCell2,
																			   this.xGridCell3,
																			   this.xGridCell4,
																			   this.xGridCell5,
																			   this.xGridCell6,
																			   this.xGridCell7,
																			   this.xGridCell8,
																			   this.xGridCell9,
																			   this.xGridCell10,
																			   this.xGridCell11,
																			   this.xGridCell12,
																			   this.xGridCell13,
																			   this.xGridCell14,
																			   this.xGridCell15,
																			   this.xGridCell16,
																			   this.xGridCell17});
			this.grdList.ColPerLine = 17;
			this.grdList.ColResizable = true;
			this.grdList.Cols = 17;
			this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdList.FixedRows = 1;
			this.grdList.HeaderHeights.Add(21);
			this.grdList.Location = new System.Drawing.Point(2, 2);
			this.grdList.Name = "grdList";
			this.grdList.QuerySQL = @"SELECT VS.SID, VS.SERIAL#, VS.MACHINE, VS.PROCESS, VP.SPID, VP.USERNAME, VS.USERNAME, 
       VS.PROGRAM, VS.MODULE, VS.TERMINAL, VS.CLIENT_INFO,
       DECODE(VS.COMMAND, 0, 'SLEEP', 2, 'INSERT', 3, 'SELECT', 6, 'UPDATE',7, 'DELETE', 'Etc'||TO_CHAR(VS.COMMAND)),
       VS.ACTION, VS.STATUS, VS.LOCKWAIT, TO_CHAR(VS.LOGON_TIME, 'HH24:MI:SS'), VS.SQL_HASH_VALUE
  FROM SYS.V_$SESSION VS, SYS.V_$PROCESS VP
 WHERE VP.ADDR = VS.PADDR
   AND VS.TYPE = 'USER'
   AND VS.SID IN (SELECT VL.SID FROM SYS.V_$LOCK VL WHERE VL.TYPE = 'TM')
 ORDER BY 1, 2";
			this.grdList.Rows = 2;
			this.grdList.Size = new System.Drawing.Size(956, 410);
			this.grdList.TabIndex = 3;
			this.grdList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
			// 
			// xGridCell1
			// 
			this.xGridCell1.CellName = "sid";
			this.xGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
			this.xGridCell1.CellWidth = 58;
			this.xGridCell1.GeneralNumberFormat = true;
			this.xGridCell1.HeaderText = "Sid";
			this.xGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xGridCell2
			// 
			this.xGridCell2.CellName = "serial";
			this.xGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
			this.xGridCell2.CellWidth = 70;
			this.xGridCell2.Col = 1;
			this.xGridCell2.GeneralNumberFormat = true;
			this.xGridCell2.HeaderText = "Serial";
			this.xGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xGridCell3
			// 
			this.xGridCell3.CellName = "machine";
			this.xGridCell3.CellWidth = 70;
			this.xGridCell3.Col = 2;
			this.xGridCell3.HeaderText = "Machine";
			// 
			// xGridCell4
			// 
			this.xGridCell4.CellName = "process";
			this.xGridCell4.CellWidth = 70;
			this.xGridCell4.Col = 3;
			this.xGridCell4.HeaderText = "Process";
			// 
			// xGridCell5
			// 
			this.xGridCell5.CellName = "pid";
			this.xGridCell5.CellWidth = 70;
			this.xGridCell5.Col = 4;
			this.xGridCell5.HeaderText = "DB Prs.";
			// 
			// xGridCell6
			// 
			this.xGridCell6.CellName = "processUser";
			this.xGridCell6.CellWidth = 70;
			this.xGridCell6.Col = 5;
			this.xGridCell6.HeaderText = "OS User";
			// 
			// xGridCell7
			// 
			this.xGridCell7.CellName = "sessionUser";
			this.xGridCell7.CellWidth = 70;
			this.xGridCell7.Col = 6;
			this.xGridCell7.HeaderText = "Sess. User";
			// 
			// xGridCell8
			// 
			this.xGridCell8.CellName = "program";
			this.xGridCell8.CellWidth = 202;
			this.xGridCell8.Col = 7;
			this.xGridCell8.HeaderText = "Program";
			// 
			// xGridCell9
			// 
			this.xGridCell9.CellName = "module";
			this.xGridCell9.CellWidth = 172;
			this.xGridCell9.Col = 8;
			this.xGridCell9.HeaderText = "Module";
			// 
			// xGridCell10
			// 
			this.xGridCell10.CellName = "terminal";
			this.xGridCell10.Col = 16;
			this.xGridCell10.HeaderText = "Terminal";
			// 
			// xGridCell11
			// 
			this.xGridCell11.CellName = "clientInfo";
			this.xGridCell11.Col = 10;
			this.xGridCell11.HeaderText = "Client";
			// 
			// xGridCell12
			// 
			this.xGridCell12.CellName = "command";
			this.xGridCell12.Col = 11;
			this.xGridCell12.HeaderText = "Command";
			// 
			// xGridCell13
			// 
			this.xGridCell13.CellName = "action";
			this.xGridCell13.Col = 12;
			this.xGridCell13.HeaderText = "Action";
			// 
			// xGridCell14
			// 
			this.xGridCell14.CellName = "status";
			this.xGridCell14.Col = 13;
			this.xGridCell14.HeaderText = "Status";
			// 
			// xGridCell15
			// 
			this.xGridCell15.CellName = "lockwait";
			this.xGridCell15.Col = 14;
			this.xGridCell15.HeaderText = "LockWait";
			// 
			// xGridCell16
			// 
			this.xGridCell16.CellName = "loginTime";
			this.xGridCell16.Col = 15;
			this.xGridCell16.HeaderText = "LoginTime";
			// 
			// xGridCell17
			// 
			this.xGridCell17.CellName = "sqlHashValue";
			this.xGridCell17.Col = 9;
			this.xGridCell17.HeaderText = "SqlHashValue";
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.btnKill);
			this.pnlBottom.Controls.Add(this.btnList);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(2, 550);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(956, 38);
			this.pnlBottom.TabIndex = 2;
			// 
			// btnKill
			// 
			this.btnKill.Enabled = false;
			this.btnKill.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnKill.Image = ((System.Drawing.Image)(resources.GetObject("btnKill.Image")));
			this.btnKill.Location = new System.Drawing.Point(662, 4);
			this.btnKill.Name = "btnKill";
			this.btnKill.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
			this.btnKill.Size = new System.Drawing.Size(116, 30);
			this.btnKill.TabIndex = 1;
			this.btnKill.Text = "Kill Session";
			this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
			// 
			// btnList
			// 
			this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnList.IsVisibleReset = false;
			this.btnList.Location = new System.Drawing.Point(790, 2);
			this.btnList.Name = "btnList";
			this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
			this.btnList.Size = new System.Drawing.Size(163, 34);
			this.btnList.TabIndex = 0;
			// 
			// pnlBottom1
			// 
			this.pnlBottom1.Controls.Add(this.txtSqlText);
			this.pnlBottom1.Controls.Add(this.grdObjList);
			this.pnlBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom1.Location = new System.Drawing.Point(2, 412);
			this.pnlBottom1.Name = "pnlBottom1";
			this.pnlBottom1.Size = new System.Drawing.Size(956, 138);
			this.pnlBottom1.TabIndex = 4;
			// 
			// txtSqlText
			// 
			this.txtSqlText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSqlText.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
			this.txtSqlText.Location = new System.Drawing.Point(304, 0);
			this.txtSqlText.Multiline = true;
			this.txtSqlText.Name = "txtSqlText";
			this.txtSqlText.ReadOnly = true;
			this.txtSqlText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSqlText.Size = new System.Drawing.Size(652, 138);
			this.txtSqlText.TabIndex = 1;
			this.txtSqlText.TabStop = false;
			// 
			// grdObjList
			// 
			this.grdObjList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
																				  this.xGridCell18,
																				  this.xGridCell19});
			this.grdObjList.ColPerLine = 2;
			this.grdObjList.Cols = 2;
			this.grdObjList.Dock = System.Windows.Forms.DockStyle.Left;
			this.grdObjList.FixedRows = 1;
			this.grdObjList.HeaderHeights.Add(21);
			this.grdObjList.Location = new System.Drawing.Point(0, 0);
			this.grdObjList.Name = "grdObjList";
			this.grdObjList.Rows = 2;
			this.grdObjList.Size = new System.Drawing.Size(304, 138);
			this.grdObjList.TabIndex = 0;
			// 
			// xGridCell18
			// 
			this.xGridCell18.CellName = "type";
			this.xGridCell18.CellWidth = 98;
			this.xGridCell18.HeaderText = "Type";
			// 
			// xGridCell19
			// 
			this.xGridCell19.CellName = "name";
			this.xGridCell19.CellWidth = 178;
			this.xGridCell19.Col = 1;
			this.xGridCell19.HeaderText = "Name";
			// 
			// ADM602Q
			// 
			this.Controls.Add(this.grdList);
			this.Controls.Add(this.pnlBottom1);
			this.Controls.Add(this.pnlBottom);
			this.DockPadding.All = 2;
			this.Name = "ADM602Q";
			((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
			this.pnlBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
			this.pnlBottom1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdObjList)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnKill_Click(object sender, System.EventArgs e)
		{
			int rowNum = grdList.CurrentRowNumber;
			if (rowNum < 0) return;
			string sid = grdList.GetItemString(rowNum, "sid");
			string serial = grdList.GetItemString(rowNum, "serial");

			//Session Kill여부 확인후 Session Kill
			if (XMessageBox.Show("Do you want to kill this session?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				//KILL SESSION SQL SET , Execute DDL Call
				string cmdText = "ALTER SYSTEM KILL SESSION '" + sid + "," + serial + "'";
				if (Service.ExecuteDDL(cmdText))
				{
					//성공시 Session List 다시 조회
					this.grdList.QueryLayout(true);
				}
			}
		}

		private void grdList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			// Row변경시에 LockObject, SqlText 조회
			if (e.CurrentRow >= 0)
			{
				//LOCK OBJECT 조회
				/* V_$LOCK 에서 해당 SID의 ID1 리스트 조회
				 * LOOP를 돌며 SO.OBJ# Table에서 해당 LOCK_ID의 Object Type과 Object Name GET
				 * 소스 Data List에서 데이타를 담아서 Grid에 ImportRowRange 처리
				 */ 
				string cmdText = "";
				BindVarCollection bindVars = new BindVarCollection();
				this.objectListTable.Clear(); //소스 Data List clear
				this.grdObjList.Reset(); //Grid Reset

				cmdText = "SELECT VL.ID1 FROM SYS.V_$LOCK VL WHERE VL.SID = :f_sid ORDER BY 1";
				bindVars.Add("f_sid", grdList.GetItemString(e.CurrentRow, "sid"));
				DataTable table = Service.ExecuteDataTable(cmdText, bindVars);
				//해당 ID1 LIST가 있으면 
				if ((table != null) && (table.Rows.Count > 0))
				{
					for (int i = 0 ; i < table.Rows.Count ; i++)
					{
						cmdText 
							= "SELECT DECODE(SO.TYPE#, 1,'INDEX',2,'TABLE', "
							+ "               3, 'CLUSTER', 4, 'VIEW', 5, 'SYSNONYM', 6, 'SEQUENCE', 7, 'PROCEDURE',"
							+ "               8, 'FUNCTION', 9, 'PACKAGE', 12, 'TRIGGER', 19, 'PARTITION', TO_CHAR(SO.TYPE#)) OBJ_TYPE,"
							+ " SO.NAME   NAME FROM SYS.OBJ$ SO WHERE SO.OBJ# = :f_lock_id ";
						bindVars.Clear();
						//f_lock_id에 ID1 SET
						bindVars.Add("f_lock_id", table.Rows[i][0].ToString());
						DataTable dTable = Service.ExecuteDataTable(cmdText, bindVars);
						if ((dTable != null) && (dTable.Rows.Count > 0))
						{
							//objectListTable에 데이타 SET
							DataRow dtRow = this.objectListTable.NewRow();
							dtRow[0] = dTable.Rows[0][0];  //Type
							dtRow[1] = dTable.Rows[0][1]; //Name
							this.objectListTable.Rows.Add(dtRow);
						}
					}
				}
				//Grid에 Import (맨 처음부터 Import)
				this.grdObjList.ImportRowRange(this.objectListTable, 0);


				//sqlHashTable의 SQLTEXT 조회
				cmdText
					= "SELECT REPLACE(SQL_TEXT, CHR(10), CHR(13)||CHR(10))"
					+ "  FROM SYS.V_$SQLTEXT_WITH_NEWLINES"
					+ " WHERE HASH_VALUE = :f_sql_hash_value"
					+ " ORDER BY PIECE";
				bindVars.Clear();
				bindVars.Add("f_sql_hash_value", grdList.GetItemString(e.CurrentRow, "sqlHashValue"));
				//SQL 조회 데이타가 있으면 Form SHOW
				object retVal = Service.ExecuteScalar(cmdText, bindVars);
				if (retVal != null)
				{
					this.txtSqlText.Text = retVal.ToString();
				}
			}
		}
	}
}

