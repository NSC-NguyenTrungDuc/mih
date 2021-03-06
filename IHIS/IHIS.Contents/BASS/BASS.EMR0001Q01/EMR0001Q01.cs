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

namespace IHIS.BASS
{
	/// <summary>
	/// OCS1023U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class EMR0001Q01 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		//private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		//private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		//private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		//private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
		#endregion

        private MultiLayout mLayOutputHangmogInfo = new MultiLayout();    // 항목정보 서비스 OutPutData LayoutTable
        
		#region [Instance Variable]

        //등록번호
        //private string mBunho = "";

        //PRINT NAME
        private string printName = "";

        // Parameter　　*주가
        private string mAutoClose = "N";
		#endregion

		#region 자동생성

        //private IHIS.Framework.XGridHeader xGridHeader1;
        //private XEditGridCell xEditGridCell72;
        private XDWWorker dwPrint;
        private XPanel xPanel3;
        private XPanel xPanel4;
        private XLabel lbSheetId;
        private XLabel lbBunho;
        private XButton btnPrintSetup;
        private XButton btnBarcode;
        private SingleLayout layPrintName;
        private SingleLayoutItem singleLayoutItem2;
        private XEditGrid gridBarcode;
        private XEditGridCell xEditGridCell1;
        private PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private XEditGridCell xEditGridCell2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public EMR0001Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EMR0001Q01));
            this.dwPrint = new IHIS.Framework.XDWWorker();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.lbSheetId = new IHIS.Framework.XLabel();
            this.lbBunho = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.gridBarcode = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.btnPrintSetup = new IHIS.Framework.XButton();
            this.btnBarcode = new IHIS.Framework.XButton();
            this.layPrintName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "약국정보관리16.ico");
            this.ImageList.Images.SetKeyName(3, "주사실수행관리16.ico");
            // 
            // dwPrint
            // 
            this.dwPrint.DataWindowObject = "emr_barcode";
            this.dwPrint.IsLandScape = false;
            this.dwPrint.LibraryList = "..\\BASS\\bass.emr0001q01.pbd";
            this.dwPrint.ProcessType = IHIS.Framework.PrintProcessType.Direct;
            this.dwPrint.PrintStart += new System.ComponentModel.CancelEventHandler(this.dwPrint_PrintStart);
            // 
            // xPanel3
            // 
            this.xPanel3.BackgroundImage = global::IHIS.BASS.Properties.Resources.TopBackground;
            this.xPanel3.Controls.Add(this.lbSheetId);
            this.xPanel3.Controls.Add(this.lbBunho);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(920, 49);
            this.xPanel3.TabIndex = 28;
            // 
            // lbSheetId
            // 
            this.lbSheetId.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbSheetId.EdgeRounding = false;
            this.lbSheetId.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbSheetId.Location = new System.Drawing.Point(342, 13);
            this.lbSheetId.Name = "lbSheetId";
            this.lbSheetId.Size = new System.Drawing.Size(234, 21);
            this.lbSheetId.TabIndex = 310;
            this.lbSheetId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbBunho
            // 
            this.lbBunho.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbBunho.EdgeRounding = false;
            this.lbBunho.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbBunho.Location = new System.Drawing.Point(38, 13);
            this.lbBunho.Name = "lbBunho";
            this.lbBunho.Size = new System.Drawing.Size(234, 21);
            this.lbBunho.TabIndex = 309;
            this.lbBunho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.gridBarcode);
            this.xPanel4.Controls.Add(this.btnPrintSetup);
            this.xPanel4.Controls.Add(this.btnBarcode);
            this.xPanel4.Controls.Add(this.xPanel3);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Location = new System.Drawing.Point(0, 0);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(922, 240);
            this.xPanel4.TabIndex = 309;
            // 
            // gridBarcode
            // 
            this.gridBarcode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.gridBarcode.ColPerLine = 2;
            this.gridBarcode.Cols = 2;
            this.gridBarcode.FixedRows = 1;
            this.gridBarcode.HeaderHeights.Add(21);
            this.gridBarcode.Location = new System.Drawing.Point(23, 55);
            this.gridBarcode.Name = "gridBarcode";
            this.gridBarcode.Rows = 2;
            this.gridBarcode.Size = new System.Drawing.Size(283, 75);
            this.gridBarcode.TabIndex = 276;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 14;
            this.xEditGridCell1.CellName = "barcode";
            this.xEditGridCell1.CellWidth = 151;
            this.xEditGridCell1.HeaderText = "barcode";
            // 
            // btnPrintSetup
            // 
            this.btnPrintSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSetup.Image")));
            this.btnPrintSetup.Location = new System.Drawing.Point(616, 199);
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Size = new System.Drawing.Size(158, 27);
            this.btnPrintSetup.TabIndex = 275;
            this.btnPrintSetup.Text = "PRINT設定";
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcode.Image")));
            this.btnBarcode.Location = new System.Drawing.Point(774, 199);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(134, 27);
            this.btnBarcode.TabIndex = 274;
            this.btnBarcode.Text = "PRINT";
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // layPrintName
            // 
            this.layPrintName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layPrintName.QuerySQL = "SELECT B_PRINT_NAME\r\n  FROM ADM3300\r\n WHERE HOSP_CODE  = :f_hosp_code\r\n   AND IP_" +
                "ADDR    = :f_ip_addr\r\n";
            this.layPrintName.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPrintName_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "print_name";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "seq";
            this.xEditGridCell2.CellWidth = 128;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "seq";
            // 
            // EMR0001Q01
            // 
            this.Controls.Add(this.xPanel4);
            this.Name = "EMR0001Q01";
            this.Size = new System.Drawing.Size(922, 240);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.EMR0001Q01_ScreenOpen);
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBarcode)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region [Screen Event]
        private void EMR0001Q01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{

			// Call된 경우
			if ( e.OpenParam != null ) 
			{
				try
				{
                    if(OpenParam.Contains("bunho"))
                        this.lbBunho.Text = OpenParam["bunho"].ToString().Trim();
                    else
                        return;

                    //Parameter 추가
                    if (OpenParam.Contains("sheet_id"))
                        this.lbSheetId.Text = OpenParam["sheet_id"].ToString().Trim();

                    //Parameter 추가
                    if (OpenParam.Contains("print_name"))
                        this.printName = OpenParam["print_name"].ToString().Trim();

                    //Prameter  추가
                    if (OpenParam.Contains("auto_close_yn"))
                        mAutoClose = OpenParam["auto_close_yn"].ToString().Trim();                        
               
                    if ( this.mAutoClose == "Y")
                        this.ParentForm.WindowState = FormWindowState.Minimized;

                }
				catch (Exception ex)
				{
					//https://sofiamedix.atlassian.net/browse/MED-10610
					//XMessageBox.Show(ex.Message, "");	
					this.Close();
				}
				
			}

            this.initScreen();
		}
		
        private void initScreen()
        {
            string asterisk = "*";
            string gubun = "O$";
            string seq = "0000000001";

            string barcode = asterisk + gubun + seq + asterisk;

            int row = this.gridBarcode.InsertRow(-1);

            this.gridBarcode.SetItemValue(row, "barcode", barcode);
            this.gridBarcode.SetItemValue(row, "seq", seq);

            // PRINT
            this.btnBarcode.PerformClick();
        }
		#endregion



        #region [印刷関連]
        private void dwPrint_PrintStart(object sender, CancelEventArgs e)
        {
            //바코드프린터명 가져오기
            this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

            if (this.printName.Equals("")) this.dwPrint.PrinterName = printSetName;
            else this.dwPrint.PrinterName = this.printName;

            this.dwPrint.SourceTable = this.gridBarcode.LayoutTable;
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            dwPrint.Print();

            this.Close();
        }
        #endregion

        #region 바코드 프린터 설정
        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            this.SetPrint();
        }

        private void SetPrint()
        {
            //Open the PrintDialog
            this.layPrintName.QueryLayout();
            string printSetName = this.layPrintName.GetItemValue("print_name").ToString();

            if (printSetName == "")
            {
                this.printDialog1.Document = this.printDocument1;
            }
            else
            {
                this.printDialog1.PrinterSettings.PrinterName = printSetName;
            }
            DialogResult dr = this.printDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //Get the Copy times
                int nCopy = this.printDocument1.PrinterSettings.Copies;
                //Get the number of Start Page
                int sPage = this.printDocument1.PrinterSettings.FromPage;
                //Get the number of End Page
                int ePage = this.printDocument1.PrinterSettings.ToPage;
                //Get the printer name
                string PrinterName = this.printDialog1.PrinterSettings.PrinterName;

                string cmdText = @" DECLARE 
    
                                        T_TRM_ID VARCHAR2(8) := ''; 

                                    BEGIN
                                        UPDATE ADM3300
                                           SET USER_ID         = :q_user_id
                                             , UP_TIME         = SYSDATE
                                             , B_PRINT_NAME    = :f_b_print_name
                                         WHERE HOSP_CODE       = :f_hosp_code 
                                           AND IP_ADDR         = :f_ip_addr;
                                           
                                              
                                           IF SQL%NOTFOUND THEN       
                                             
                                             SELECT TRIM('TRM'||LPAD(TO_NUMBER(SUBSTR(NVL(MAX(TRM_ID),'TRM000'),4,3))+1,3,'0'))
                                               INTO T_TRM_ID
                                               FROM ADM3300
                                              WHERE HOSP_CODE = :f_hosp_code;
                                              
                                             INSERT INTO ADM3300
                                                  ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,
                                                    USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)
                                                VALUES 
                                                  ( T_TRM_ID, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,
                                                    NULL,      NULL,         :q_user_id, SYSDATE,     NULL,      :f_b_print_name);       
                                                    
                                           END IF; 

                                    END;";

                BindVarCollection bc = new BindVarCollection();
                bc.Add("q_user_id", UserInfo.UserID);
                bc.Add("f_b_print_name", PrinterName);
                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_ip_addr", Service.ClientIP.ToString());

                if (!Service.ExecuteNonQuery(cmdText, bc))
                {
                    XMessageBox.Show("プリンタ設定中にエラーが発生しました。\r\n" + Service.ErrFullMsg, "注意", MessageBoxIcon.Warning);
                }
            }
        }

        private void layPrintName_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layPrintName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layPrintName.SetBindVarValue("f_ip_addr", Service.ClientIP.ToString());
        }
        #endregion


    }
}

