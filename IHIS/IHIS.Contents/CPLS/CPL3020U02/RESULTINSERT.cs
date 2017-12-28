using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.CPLS
{
	/// <summary>
	/// CHANGETIME에 대한 요약 설명입니다.
	/// </summary>
	public class RESULTINSERT : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XFindWorker fwkDummy;
		private IHIS.Framework.MultiLayout laySayu;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XButton btnUpdate;
		private IHIS.Framework.XPanel xPanel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XLabel xLabel10;
		private IHIS.Framework.XLabel xLabel11;
		private IHIS.Framework.XLabel xLabel12;
		private IHIS.Framework.XLabel xLabel13;
		private IHIS.Framework.XLabel xLabel14;
		private IHIS.Framework.XLabel xLabel15;
		private IHIS.Framework.XLabel xLabel16;
		private IHIS.Framework.XLabel xLabel17;
		private IHIS.Framework.XLabel xLabel18;
		private IHIS.Framework.XLabel xLabel19;
		private IHIS.Framework.XLabel xLabel20;
		private IHIS.Framework.XLabel xLabel21;
		private IHIS.Framework.XLabel xLabel22;
		private IHIS.Framework.XLabel xLabel23;
		private IHIS.Framework.XLabel xLabel24;
		private IHIS.Framework.XLabel xLabel25;
		private IHIS.Framework.XLabel xLabel26;
		private IHIS.Framework.XLabel xLabel27;
		private IHIS.Framework.XLabel xLabel28;
		private IHIS.Framework.XLabel xLabel29;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private IHIS.Framework.XNumericUpDown nudSum;
		private IHIS.Framework.XNumericUpDown nudMinus;
		private IHIS.Framework.XNumericUpDown nudPoint;
		private IHIS.Framework.XNumericUpDown nud3;
		private IHIS.Framework.XNumericUpDown nud6;
		private IHIS.Framework.XNumericUpDown nud9;
		private IHIS.Framework.XNumericUpDown nudStar;
		private IHIS.Framework.XNumericUpDown nud2;
		private IHIS.Framework.XNumericUpDown nud5;
		private IHIS.Framework.XNumericUpDown nud8;
		private IHIS.Framework.XNumericUpDown nudSlacy;
		private IHIS.Framework.XNumericUpDown nud0;
		private IHIS.Framework.XNumericUpDown nud1;
		private IHIS.Framework.XNumericUpDown nud4;
		private IHIS.Framework.XNumericUpDown nud7;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RESULTINSERT()
		{
			InitializeComponent();
		}

		public RESULTINSERT(string aLabNo, string aHangmogCode, string aSpecimenCode, string aEmergency, string aBeforeResult, string aBeforeGumsaja, string aPkcpl3020)
		{
			InitializeComponent();
            this.laySayu.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.laySayu.SetBindVarValue("f_lab_no",aLabNo);
            this.laySayu.SetBindVarValue("f_hangmog_code", aHangmogCode);
            this.laySayu.SetBindVarValue("f_specimen_code", aSpecimenCode);
            this.laySayu.SetBindVarValue("f_emergency", aEmergency);
			
			this.mLabNo = aLabNo;
			this.mHangmogCode = aHangmogCode;
			this.mSpecimenCode = aSpecimenCode;
			this.mEmergency = aEmergency;
			this.mBeforeResult = aBeforeResult;
			this.mBeforeGumsaja = aBeforeGumsaja;
			this.mPkcpl3020 = aPkcpl3020;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RESULTINSERT));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnUpdate = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.laySayu = new IHIS.Framework.MultiLayout();
            this.fwkDummy = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMinus = new IHIS.Framework.XNumericUpDown();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.nudPoint = new IHIS.Framework.XNumericUpDown();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.nud3 = new IHIS.Framework.XNumericUpDown();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.nud6 = new IHIS.Framework.XNumericUpDown();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.nud9 = new IHIS.Framework.XNumericUpDown();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.nudStar = new IHIS.Framework.XNumericUpDown();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.nud2 = new IHIS.Framework.XNumericUpDown();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.nud5 = new IHIS.Framework.XNumericUpDown();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.nud8 = new IHIS.Framework.XNumericUpDown();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.nudSlacy = new IHIS.Framework.XNumericUpDown();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.nud0 = new IHIS.Framework.XNumericUpDown();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.nud1 = new IHIS.Framework.XNumericUpDown();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.nud4 = new IHIS.Framework.XNumericUpDown();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.nud7 = new IHIS.Framework.XNumericUpDown();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.nudSum = new IHIS.Framework.XNumericUpDown();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySayu)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlacy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSum)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnUpdate);
            this.xPanel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            // 
            // laySayu
            // 
            this.laySayu.QuerySQL = resources.GetString("laySayu.QuerySQL");
            // 
            // fwkDummy
            // 
            this.fwkDummy.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkDummy.FormText = "取消事由照会";
            this.fwkDummy.InputSQL = resources.GetString("fwkDummy.InputSQL");
            this.fwkDummy.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkDummy.ServerFilter = true;
            this.fwkDummy.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkDummy_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 467;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.label8);
            this.xPanel2.Controls.Add(this.label9);
            this.xPanel2.Controls.Add(this.label10);
            this.xPanel2.Controls.Add(this.label6);
            this.xPanel2.Controls.Add(this.label7);
            this.xPanel2.Controls.Add(this.label5);
            this.xPanel2.Controls.Add(this.label4);
            this.xPanel2.Controls.Add(this.nudMinus);
            this.xPanel2.Controls.Add(this.xLabel28);
            this.xPanel2.Controls.Add(this.xLabel29);
            this.xPanel2.Controls.Add(this.nudPoint);
            this.xPanel2.Controls.Add(this.xLabel26);
            this.xPanel2.Controls.Add(this.xLabel27);
            this.xPanel2.Controls.Add(this.nud3);
            this.xPanel2.Controls.Add(this.xLabel18);
            this.xPanel2.Controls.Add(this.xLabel19);
            this.xPanel2.Controls.Add(this.nud6);
            this.xPanel2.Controls.Add(this.xLabel20);
            this.xPanel2.Controls.Add(this.xLabel21);
            this.xPanel2.Controls.Add(this.nud9);
            this.xPanel2.Controls.Add(this.xLabel22);
            this.xPanel2.Controls.Add(this.xLabel23);
            this.xPanel2.Controls.Add(this.nudStar);
            this.xPanel2.Controls.Add(this.xLabel24);
            this.xPanel2.Controls.Add(this.xLabel25);
            this.xPanel2.Controls.Add(this.nud2);
            this.xPanel2.Controls.Add(this.xLabel10);
            this.xPanel2.Controls.Add(this.xLabel11);
            this.xPanel2.Controls.Add(this.nud5);
            this.xPanel2.Controls.Add(this.xLabel12);
            this.xPanel2.Controls.Add(this.xLabel13);
            this.xPanel2.Controls.Add(this.nud8);
            this.xPanel2.Controls.Add(this.xLabel14);
            this.xPanel2.Controls.Add(this.xLabel15);
            this.xPanel2.Controls.Add(this.nudSlacy);
            this.xPanel2.Controls.Add(this.xLabel16);
            this.xPanel2.Controls.Add(this.xLabel17);
            this.xPanel2.Controls.Add(this.nud0);
            this.xPanel2.Controls.Add(this.xLabel8);
            this.xPanel2.Controls.Add(this.xLabel9);
            this.xPanel2.Controls.Add(this.nud1);
            this.xPanel2.Controls.Add(this.xLabel6);
            this.xPanel2.Controls.Add(this.xLabel7);
            this.xPanel2.Controls.Add(this.nud4);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.nud7);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.nudSum);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.label3);
            this.xPanel2.Controls.Add(this.label2);
            this.xPanel2.Controls.Add(this.label1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // nudMinus
            // 
            resources.ApplyResources(this.nudMinus, "nudMinus");
            this.nudMinus.Name = "nudMinus";
            // 
            // xLabel28
            // 
            resources.ApplyResources(this.xLabel28, "xLabel28");
            this.xLabel28.Name = "xLabel28";
            // 
            // xLabel29
            // 
            resources.ApplyResources(this.xLabel29, "xLabel29");
            this.xLabel29.Name = "xLabel29";
            // 
            // nudPoint
            // 
            resources.ApplyResources(this.nudPoint, "nudPoint");
            this.nudPoint.Name = "nudPoint";
            // 
            // xLabel26
            // 
            resources.ApplyResources(this.xLabel26, "xLabel26");
            this.xLabel26.Name = "xLabel26";
            // 
            // xLabel27
            // 
            resources.ApplyResources(this.xLabel27, "xLabel27");
            this.xLabel27.Name = "xLabel27";
            // 
            // nud3
            // 
            resources.ApplyResources(this.nud3, "nud3");
            this.nud3.Name = "nud3";
            // 
            // xLabel18
            // 
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.Name = "xLabel18";
            // 
            // xLabel19
            // 
            resources.ApplyResources(this.xLabel19, "xLabel19");
            this.xLabel19.Name = "xLabel19";
            // 
            // nud6
            // 
            resources.ApplyResources(this.nud6, "nud6");
            this.nud6.Name = "nud6";
            // 
            // xLabel20
            // 
            resources.ApplyResources(this.xLabel20, "xLabel20");
            this.xLabel20.Name = "xLabel20";
            // 
            // xLabel21
            // 
            resources.ApplyResources(this.xLabel21, "xLabel21");
            this.xLabel21.Name = "xLabel21";
            // 
            // nud9
            // 
            resources.ApplyResources(this.nud9, "nud9");
            this.nud9.Name = "nud9";
            // 
            // xLabel22
            // 
            resources.ApplyResources(this.xLabel22, "xLabel22");
            this.xLabel22.Name = "xLabel22";
            // 
            // xLabel23
            // 
            resources.ApplyResources(this.xLabel23, "xLabel23");
            this.xLabel23.Name = "xLabel23";
            // 
            // nudStar
            // 
            resources.ApplyResources(this.nudStar, "nudStar");
            this.nudStar.Name = "nudStar";
            // 
            // xLabel24
            // 
            resources.ApplyResources(this.xLabel24, "xLabel24");
            this.xLabel24.Name = "xLabel24";
            // 
            // xLabel25
            // 
            resources.ApplyResources(this.xLabel25, "xLabel25");
            this.xLabel25.Name = "xLabel25";
            // 
            // nud2
            // 
            resources.ApplyResources(this.nud2, "nud2");
            this.nud2.Name = "nud2";
            // 
            // xLabel10
            // 
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel11
            // 
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Name = "xLabel11";
            // 
            // nud5
            // 
            resources.ApplyResources(this.nud5, "nud5");
            this.nud5.Name = "nud5";
            // 
            // xLabel12
            // 
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel13
            // 
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.Name = "xLabel13";
            // 
            // nud8
            // 
            resources.ApplyResources(this.nud8, "nud8");
            this.nud8.Name = "nud8";
            // 
            // xLabel14
            // 
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.Name = "xLabel14";
            // 
            // xLabel15
            // 
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.Name = "xLabel15";
            // 
            // nudSlacy
            // 
            resources.ApplyResources(this.nudSlacy, "nudSlacy");
            this.nudSlacy.Name = "nudSlacy";
            // 
            // xLabel16
            // 
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.Name = "xLabel16";
            // 
            // xLabel17
            // 
            resources.ApplyResources(this.xLabel17, "xLabel17");
            this.xLabel17.Name = "xLabel17";
            // 
            // nud0
            // 
            resources.ApplyResources(this.nud0, "nud0");
            this.nud0.Name = "nud0";
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Name = "xLabel9";
            // 
            // nud1
            // 
            resources.ApplyResources(this.nud1, "nud1");
            this.nud1.Name = "nud1";
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // nud4
            // 
            resources.ApplyResources(this.nud4, "nud4");
            this.nud4.Name = "nud4";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // nud7
            // 
            resources.ApplyResources(this.nud7, "nud7");
            this.nud7.Name = "nud7";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // nudSum
            // 
            resources.ApplyResources(this.nudSum, "nudSum");
            this.nudSum.Name = "nudSum";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // RESULTINSERT
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RESULTINSERT";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySayu)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlacy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSum)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region fields
		private string mLabNo = "";
		private string mSpecimenCode = "";
		private string mEmergency = "";
		private string mHangmogCode = "";
		private string mBeforeResult = "";
		private string mBeforeGumsaja = "";
		private string mPkcpl3020 = "";
		#endregion
	
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
		}

		#region 단축키 설정
		protected override bool ProcessDialogKey(Keys keyData)
		{

			Keys keyCode = (Keys)(((int)keyData << 16) >> 16);
			Keys keyModifier = (Keys)(((int)keyData >> 16) << 16);

			switch (keyCode)
			{
				case Keys.OemSemicolon:
					// 별표클릭
					if( keyModifier  == Keys.Control)
					{
						this.nudStar.SetDataValue(int.Parse(this.nudStar.GetDataValue()) + 1);
						this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					}
					break;
				//조건조회/검색실행버튼에 단축키 F1을 맵핑
				case Keys.OemQuestion:
					this.nudSlacy.SetDataValue(int.Parse(this.nudSlacy.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.OemMinus:
					this.nudMinus.SetDataValue(int.Parse(this.nudMinus.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad0:
					this.nud0.SetDataValue(int.Parse(this.nud0.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad1:
					this.nud1.SetDataValue(int.Parse(this.nud1.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad2:
					this.nud2.SetDataValue(int.Parse(this.nud2.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad3:
					this.nud3.SetDataValue(int.Parse(this.nud3.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad4:
					this.nud4.SetDataValue(int.Parse(this.nud4.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad5:
					this.nud5.SetDataValue(int.Parse(this.nud5.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad6:
					this.nud6.SetDataValue(int.Parse(this.nud6.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad7:
					this.nud7.SetDataValue(int.Parse(this.nud7.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad8:
					this.nud8.SetDataValue(int.Parse(this.nud8.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.NumPad9:
					this.nud9.SetDataValue(int.Parse(this.nud9.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.Multiply:
					this.nudStar.SetDataValue(int.Parse(this.nudStar.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.Divide:
					this.nudSlacy.SetDataValue(int.Parse(this.nudSlacy.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.Subtract:
					this.nudMinus.SetDataValue(int.Parse(this.nudMinus.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D0:
					this.nud0.SetDataValue(int.Parse(this.nud0.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D1:
					this.nud1.SetDataValue(int.Parse(this.nud1.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D2:
					this.nud2.SetDataValue(int.Parse(this.nud2.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D3:
					this.nud3.SetDataValue(int.Parse(this.nud3.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D4:
					this.nud4.SetDataValue(int.Parse(this.nud4.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D5:
					this.nud5.SetDataValue(int.Parse(this.nud5.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D6:
					this.nud6.SetDataValue(int.Parse(this.nud6.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D7:
					this.nud7.SetDataValue(int.Parse(this.nud7.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D8:
					this.nud8.SetDataValue(int.Parse(this.nud8.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				case Keys.D9:
					this.nud9.SetDataValue(int.Parse(this.nud9.GetDataValue()) + 1);
					this.nudSum.SetDataValue(int.Parse(this.nudSum.GetDataValue()) + 1);
					break;
				default:
					break;
			}

			return base.ProcessDialogKey(keyData);
		}
		#endregion

        private void fwkDummy_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkDummy.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
	}
}
