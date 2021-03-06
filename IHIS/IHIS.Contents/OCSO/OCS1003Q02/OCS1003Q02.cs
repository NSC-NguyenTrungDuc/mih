#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.Framework;
using IHIS.OCSO.Properties;

#endregion

namespace IHIS.OCSO
{
	/// <summary>
	/// OCS1003Q02에 대한 요약 설명입니다.
	/// </summary>1
	[ToolboxItem(false)]
	public class OCS1003Q02 : IHIS.Framework.XScreen
	{
		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";
        //ログインユーザ
        private bool mDoctorLogin = false;
		//진료의사
		private string mDoctor = "";
		//진료과
		private string mGwa = "";
		//내원일자
		private string mNaewon_date = "";
		//환자번호
		private string mBunho = "";

        // Library
        IHIS.OCS.OrderBiz mOrderBiz;

		#endregion

		private System.Windows.Forms.RadioButton rbtNotTreated;
		private System.Windows.Forms.RadioButton rbtTreated;
		private System.Windows.Forms.RadioButton rbtAll;
		private IHIS.Framework.XGrid grdOUT1001;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell11;
		private IHIS.Framework.XGridCell xGridCell13;
		private IHIS.Framework.XGridCell xGridCell14;
		private IHIS.Framework.XGridCell xGridCell15;
		private IHIS.Framework.XGridCell xGridCell17;
        private IHIS.Framework.XGridCell xGridCell18;
		private IHIS.Framework.XGridCell xGridCell22;
		private IHIS.Framework.XGridCell xGridCell27;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XGridCell xGridCell28;
		private IHIS.Framework.XEditGrid grdOCS1001;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell125;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell99;
		private IHIS.Framework.XEditGridCell xEditGridCell100;
		private IHIS.Framework.XEditGridCell xEditGridCell101;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell126;
		private IHIS.Framework.XEditGridCell xEditGridCell103;
		private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell105;
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
		private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XEditGridCell xEditGridCell110;
		private IHIS.Framework.XEditGridCell xEditGridCell111;
		private IHIS.Framework.XEditGridCell xEditGridCell112;
		private IHIS.Framework.XEditGridCell xEditGridCell113;
		private IHIS.Framework.XEditGridCell xEditGridCell114;
		private IHIS.Framework.XEditGridCell xEditGridCell115;
		private IHIS.Framework.XEditGridCell xEditGridCell116;
		private IHIS.Framework.XEditGridCell xEditGridCell117;
		private IHIS.Framework.XEditGridCell xEditGridCell118;
		private IHIS.Framework.XEditGridCell xEditGridCell119;
		private IHIS.Framework.XEditGridCell xEditGridCell120;
		private IHIS.Framework.XEditGridCell xEditGridCell121;
		private IHIS.Framework.XEditGridCell xEditGridCell122;
		private IHIS.Framework.XEditGridCell xEditGridCell123;
		private IHIS.Framework.XEditGridCell xEditGridCell124;
		private IHIS.Framework.XEditGridCell xEditGridCell98;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private IHIS.Framework.XGridCell xGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
		private System.Windows.Forms.ImageList imageListMixGroup;
		private IHIS.Framework.MultiLayout layReturnValue;
        private XGridCell xGridCell6;
        private MultiLayout layQueryLayout;
        private XDataWindow dwOrderInfo;
        private MultiLayout layDisplayLayout;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem175;
        private MultiLayoutItem multiLayoutItem176;
        private MultiLayoutItem multiLayoutItem177;
        private MultiLayoutItem multiLayoutItem178;
        private MultiLayoutItem multiLayoutItem179;
        private MultiLayoutItem multiLayoutItem180;
        private MultiLayoutItem multiLayoutItem181;
        private MultiLayoutItem multiLayoutItem182;
        private MultiLayoutItem multiLayoutItem183;
        private MultiLayoutItem multiLayoutItem184;
        private MultiLayoutItem multiLayoutItem185;
        private MultiLayoutItem multiLayoutItem186;
        private MultiLayoutItem multiLayoutItem187;
        private MultiLayoutItem multiLayoutItem188;
        private MultiLayoutItem multiLayoutItem189;
        private MultiLayoutItem multiLayoutItem190;
        private MultiLayoutItem multiLayoutItem191;
        private MultiLayoutItem multiLayoutItem192;
        private MultiLayoutItem multiLayoutItem193;
        private MultiLayoutItem multiLayoutItem194;
        private MultiLayoutItem multiLayoutItem195;
        private MultiLayoutItem multiLayoutItem196;
        private MultiLayoutItem multiLayoutItem197;
        private MultiLayoutItem multiLayoutItem198;
        private MultiLayoutItem multiLayoutItem199;
        private MultiLayoutItem multiLayoutItem200;
        private MultiLayoutItem multiLayoutItem201;
        private MultiLayoutItem multiLayoutItem202;
        private MultiLayoutItem multiLayoutItem203;
        private MultiLayoutItem multiLayoutItem204;
        private MultiLayoutItem multiLayoutItem205;
        private MultiLayoutItem multiLayoutItem206;
        private MultiLayoutItem multiLayoutItem207;
        private MultiLayoutItem multiLayoutItem208;
        private MultiLayoutItem multiLayoutItem209;
        private MultiLayoutItem multiLayoutItem210;
        private MultiLayoutItem multiLayoutItem211;
        private MultiLayoutItem multiLayoutItem212;
        private MultiLayoutItem multiLayoutItem213;
        private MultiLayoutItem multiLayoutItem214;
        private MultiLayoutItem multiLayoutItem215;
        private MultiLayoutItem multiLayoutItem216;
        private MultiLayoutItem multiLayoutItem217;
        private MultiLayoutItem multiLayoutItem218;
        private MultiLayoutItem multiLayoutItem219;
        private MultiLayoutItem multiLayoutItem220;
        private MultiLayoutItem multiLayoutItem221;
        private MultiLayoutItem multiLayoutItem222;
        private MultiLayoutItem multiLayoutItem223;
        private MultiLayoutItem multiLayoutItem224;
        private MultiLayoutItem multiLayoutItem225;
        private MultiLayoutItem multiLayoutItem226;
        private MultiLayoutItem multiLayoutItem227;
        private MultiLayoutItem multiLayoutItem228;
        private MultiLayoutItem multiLayoutItem229;
        private MultiLayoutItem multiLayoutItem230;
        private MultiLayoutItem multiLayoutItem231;
        private MultiLayoutItem multiLayoutItem232;
        private MultiLayoutItem multiLayoutItem233;
        private MultiLayoutItem multiLayoutItem234;
        private MultiLayoutItem multiLayoutItem235;
        private MultiLayoutItem multiLayoutItem236;
        private MultiLayoutItem multiLayoutItem237;
        private MultiLayoutItem multiLayoutItem238;
        private MultiLayoutItem multiLayoutItem239;
        private MultiLayoutItem multiLayoutItem240;
        private MultiLayoutItem multiLayoutItem241;
        private MultiLayoutItem multiLayoutItem242;
        private MultiLayoutItem multiLayoutItem243;
        private MultiLayoutItem multiLayoutItem244;
        private MultiLayoutItem multiLayoutItem245;
        private MultiLayoutItem multiLayoutItem246;
        private MultiLayoutItem multiLayoutItem247;
        private MultiLayoutItem multiLayoutItem248;
        private MultiLayoutItem multiLayoutItem249;
        private MultiLayoutItem multiLayoutItem250;
        private MultiLayoutItem multiLayoutItem251;
        private MultiLayoutItem multiLayoutItem252;
        private MultiLayoutItem multiLayoutItem253;
        private MultiLayoutItem multiLayoutItem254;
        private MultiLayoutItem multiLayoutItem255;
        private MultiLayoutItem multiLayoutItem256;
        private MultiLayoutItem multiLayoutItem257;
        private MultiLayoutItem multiLayoutItem258;
        private MultiLayoutItem multiLayoutItem259;
        private MultiLayoutItem multiLayoutItem260;
        private MultiLayoutItem multiLayoutItem261;
        private MultiLayoutItem multiLayoutItem262;
        private MultiLayoutItem multiLayoutItem263;
        private MultiLayoutItem multiLayoutItem264;
        private MultiLayoutItem multiLayoutItem265;
        private MultiLayoutItem multiLayoutItem266;
        private MultiLayoutItem multiLayoutItem267;
        private MultiLayoutItem multiLayoutItem268;
        private MultiLayoutItem multiLayoutItem269;
        private MultiLayoutItem multiLayoutItem270;
        private MultiLayoutItem multiLayoutItem271;
        private MultiLayoutItem multiLayoutItem272;
        private MultiLayoutItem multiLayoutItem273;
        private MultiLayoutItem multiLayoutItem274;
        private MultiLayoutItem multiLayoutItem275;
        private MultiLayoutItem multiLayoutItem276;
        private MultiLayoutItem multiLayoutItem277;
        private MultiLayoutItem multiLayoutItem278;
        private MultiLayoutItem multiLayoutItem279;
        private MultiLayoutItem multiLayoutItem280;
        private MultiLayoutItem multiLayoutItem281;
        private MultiLayoutItem multiLayoutItem282;
        private MultiLayoutItem multiLayoutItem283;
        private MultiLayoutItem multiLayoutItem284;
        private MultiLayoutItem multiLayoutItem285;
        private MultiLayoutItem multiLayoutItem286;
        private MultiLayoutItem multiLayoutItem287;
        private MultiLayoutItem multiLayoutItem288;
        private MultiLayoutItem multiLayoutItem289;
        private MultiLayoutItem multiLayoutItem290;
        private MultiLayoutItem multiLayoutItem291;
        private MultiLayoutItem multiLayoutItem292;
        private MultiLayoutItem multiLayoutItem293;
        private MultiLayoutItem multiLayoutItem294;
        private MultiLayoutItem multiLayoutItem295;
        private MultiLayoutItem multiLayoutItem296;
        private MultiLayoutItem multiLayoutItem297;
        private MultiLayoutItem multiLayoutItem298;
        private MultiLayoutItem multiLayoutItem299;
        private MultiLayoutItem multiLayoutItem300;
        private MultiLayoutItem multiLayoutItem301;
        private MultiLayoutItem multiLayoutItem302;
        private MultiLayoutItem multiLayoutItem303;
        private MultiLayoutItem multiLayoutItem304;
        private MultiLayoutItem multiLayoutItem305;
        private MultiLayoutItem multiLayoutItem306;
        private MultiLayoutItem multiLayoutItem307;
        private MultiLayoutItem multiLayoutItem308;
        private MultiLayoutItem multiLayoutItem309;
        private MultiLayoutItem multiLayoutItem310;
        private MultiLayoutItem multiLayoutItem311;
        private MultiLayoutItem multiLayoutItem312;
        private MultiLayoutItem multiLayoutItem313;
        private MultiLayoutItem multiLayoutItem314;
        private MultiLayoutItem multiLayoutItem315;
        private MultiLayoutItem multiLayoutItem316;
        private MultiLayoutItem multiLayoutItem317;
        private MultiLayoutItem multiLayoutItem318;
        private MultiLayoutItem multiLayoutItem319;
        private MultiLayoutItem multiLayoutItem320;
        private MultiLayoutItem multiLayoutItem321;
        private MultiLayoutItem multiLayoutItem322;
        private MultiLayoutItem multiLayoutItem323;
        private MultiLayoutItem multiLayoutItem324;
        private MultiLayoutItem multiLayoutItem325;
        private MultiLayoutItem multiLayoutItem326;
        private MultiLayoutItem multiLayoutItem327;
        private MultiLayoutItem multiLayoutItem328;
        private MultiLayoutItem multiLayoutItem329;
        private MultiLayoutItem multiLayoutItem330;
        private MultiLayoutItem multiLayoutItem331;
        private MultiLayoutItem multiLayoutItem332;
        private MultiLayoutItem multiLayoutItem333;
		private System.ComponentModel.IContainer components;

        #region param for load data form cloud service
	    private OCS1003GrdOUT1001RowFocusChangedResult rowFocusChangedResult;
        #endregion

        public OCS1003Q02()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            
            // Create param list for grdOCS1001
            grdOCS1001.ParamList = new List<string>(new String[] { "f_naewon_date", "f_bunho", "f_gwa", "f_doctor", "f_naewon_yn" });
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1003Q02));
            this.rbtNotTreated = new System.Windows.Forms.RadioButton();
            this.rbtTreated = new System.Windows.Forms.RadioButton();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.grdOUT1001 = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell28 = new IHIS.Framework.XGridCell();
            this.xGridCell11 = new IHIS.Framework.XGridCell();
            this.xGridCell13 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell14 = new IHIS.Framework.XGridCell();
            this.xGridCell18 = new IHIS.Framework.XGridCell();
            this.xGridCell15 = new IHIS.Framework.XGridCell();
            this.xGridCell17 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell22 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell27 = new IHIS.Framework.XGridCell();
            this.btnClose = new IHIS.Framework.XButton();
            this.grdOCS1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.layReturnValue = new IHIS.Framework.MultiLayout();
            this.layQueryLayout = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem175 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem176 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem177 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem178 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem179 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem180 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem181 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem182 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem183 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem184 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem185 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem186 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem187 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem188 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem189 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem190 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem191 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem192 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem193 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem194 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem195 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem196 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem197 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem198 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem199 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem200 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem201 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem202 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem203 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem204 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem205 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem206 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem207 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem208 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem209 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem210 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem211 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem212 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem213 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem214 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem215 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem216 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem217 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem218 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem219 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem220 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem221 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem222 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem223 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem224 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem225 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem226 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem227 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem228 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem229 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem230 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem231 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem232 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem233 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem234 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem235 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem236 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem237 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem238 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem239 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem240 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem241 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem242 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem243 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem244 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem245 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem246 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem247 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem248 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem249 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem250 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem251 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem252 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem253 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem254 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem255 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem256 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem257 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem258 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem259 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem260 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem261 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem262 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem263 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem264 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem265 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem266 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem267 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem268 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem269 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem270 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem271 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem272 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem273 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem274 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem275 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem276 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem277 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem278 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem279 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem280 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem281 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem282 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem283 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem284 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem285 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem286 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem287 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem288 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem289 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem290 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem291 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem292 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem293 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem294 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem295 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem296 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem297 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem298 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem299 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem300 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem301 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem302 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem303 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem304 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem305 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem306 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem307 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem308 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem309 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem310 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem311 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem312 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem313 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem314 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem315 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem316 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem317 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem318 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem319 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem320 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem321 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem322 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem323 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem324 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem325 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem326 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem327 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem328 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem329 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem330 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem331 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem332 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem333 = new IHIS.Framework.MultiLayoutItem();
            this.dwOrderInfo = new IHIS.Framework.XDataWindow();
            this.layDisplayLayout = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1001)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layReturnValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQueryLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDisplayLayout)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            // 
            // rbtNotTreated
            // 
            this.rbtNotTreated.AccessibleDescription = null;
            this.rbtNotTreated.AccessibleName = null;
            resources.ApplyResources(this.rbtNotTreated, "rbtNotTreated");
            this.rbtNotTreated.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtNotTreated.BackgroundImage = null;
            this.rbtNotTreated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtNotTreated.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtNotTreated.ImageList = this.ImageList;
            this.rbtNotTreated.Name = "rbtNotTreated";
            this.rbtNotTreated.UseVisualStyleBackColor = false;
            this.rbtNotTreated.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbtTreated
            // 
            this.rbtTreated.AccessibleDescription = null;
            this.rbtTreated.AccessibleName = null;
            resources.ApplyResources(this.rbtTreated, "rbtTreated");
            this.rbtTreated.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtTreated.BackgroundImage = null;
            this.rbtTreated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtTreated.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtTreated.ImageList = this.ImageList;
            this.rbtTreated.Name = "rbtTreated";
            this.rbtTreated.UseVisualStyleBackColor = false;
            this.rbtTreated.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbtAll
            // 
            this.rbtAll.AccessibleDescription = null;
            this.rbtAll.AccessibleName = null;
            resources.ApplyResources(this.rbtAll, "rbtAll");
            this.rbtAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtAll.BackgroundImage = null;
            this.rbtAll.Checked = true;
            this.rbtAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbtAll.ImageList = this.ImageList;
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.TabStop = true;
            this.rbtAll.UseVisualStyleBackColor = false;
            this.rbtAll.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // grdOUT1001
            // 
            resources.ApplyResources(this.grdOUT1001, "grdOUT1001");
            this.grdOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell28,
            this.xGridCell11,
            this.xGridCell13,
            this.xGridCell4,
            this.xGridCell14,
            this.xGridCell18,
            this.xGridCell15,
            this.xGridCell17,
            this.xGridCell5,
            this.xGridCell22,
            this.xGridCell6,
            this.xGridCell27});
            this.grdOUT1001.ColPerLine = 5;
            this.grdOUT1001.Cols = 5;
            this.grdOUT1001.ExecuteQuery = null;
            this.grdOUT1001.FixedRows = 1;
            this.grdOUT1001.HeaderHeights.Add(24);
            this.grdOUT1001.Name = "grdOUT1001";
            this.grdOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT1001.ParamList")));
            this.grdOUT1001.QuerySQL = resources.GetString("grdOUT1001.QuerySQL");
            this.grdOUT1001.Rows = 2;
            this.grdOUT1001.ToolTipActive = true;
            this.grdOUT1001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOUT1001_QueryEnd);
            this.grdOUT1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOUT1001_RowFocusChanged);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "jubsu";
            this.xGridCell1.Col = -1;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "reser_yn";
            this.xGridCell2.Col = -1;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.IsVisible = false;
            this.xGridCell2.Row = -1;
            // 
            // xGridCell3
            // 
            this.xGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell3.CellName = "jinryo_time";
            this.xGridCell3.CellWidth = 120;
            this.xGridCell3.Col = 1;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            this.xGridCell3.Mask = "##:##";
            this.xGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell28
            // 
            this.xGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell28.CellName = "gwa_name";
            this.xGridCell28.CellWidth = 102;
            this.xGridCell28.Col = 2;
            resources.ApplyResources(this.xGridCell28, "xGridCell28");
            this.xGridCell28.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell28.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell11
            // 
            this.xGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell11.CellName = "doctor_name";
            this.xGridCell11.CellWidth = 90;
            this.xGridCell11.Col = 3;
            resources.ApplyResources(this.xGridCell11, "xGridCell11");
            this.xGridCell11.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell11.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell13
            // 
            this.xGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell13.CellName = "order_end_yn";
            this.xGridCell13.CellWidth = 100;
            this.xGridCell13.Col = 4;
            resources.ApplyResources(this.xGridCell13, "xGridCell13");
            this.xGridCell13.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell13.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell4
            // 
            this.xGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell4.CellName = "bunho";
            this.xGridCell4.CellWidth = 82;
            this.xGridCell4.Col = -1;
            this.xGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.IsVisible = false;
            this.xGridCell4.Row = -1;
            this.xGridCell4.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell4.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell14
            // 
            this.xGridCell14.CellName = "naewon_date";
            this.xGridCell14.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell14.Col = -1;
            resources.ApplyResources(this.xGridCell14, "xGridCell14");
            this.xGridCell14.IsVisible = false;
            this.xGridCell14.Row = -1;
            // 
            // xGridCell18
            // 
            this.xGridCell18.CellName = "gwa";
            this.xGridCell18.Col = -1;
            resources.ApplyResources(this.xGridCell18, "xGridCell18");
            this.xGridCell18.IsVisible = false;
            this.xGridCell18.Row = -1;
            // 
            // xGridCell15
            // 
            this.xGridCell15.CellName = "doctor";
            this.xGridCell15.Col = -1;
            resources.ApplyResources(this.xGridCell15, "xGridCell15");
            this.xGridCell15.IsVisible = false;
            this.xGridCell15.Row = -1;
            // 
            // xGridCell17
            // 
            this.xGridCell17.CellName = "naewon_type";
            this.xGridCell17.Col = -1;
            resources.ApplyResources(this.xGridCell17, "xGridCell17");
            this.xGridCell17.IsVisible = false;
            this.xGridCell17.Row = -1;
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "jubsu_no";
            this.xGridCell5.Col = -1;
            resources.ApplyResources(this.xGridCell5, "xGridCell5");
            this.xGridCell5.IsVisible = false;
            this.xGridCell5.Row = -1;
            // 
            // xGridCell22
            // 
            this.xGridCell22.CellName = "pk_naewon";
            this.xGridCell22.CellType = IHIS.Framework.XCellDataType.Number;
            this.xGridCell22.Col = -1;
            resources.ApplyResources(this.xGridCell22, "xGridCell22");
            this.xGridCell22.IsVisible = false;
            this.xGridCell22.Row = -1;
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "naewon_yn";
            this.xGridCell6.Col = -1;
            resources.ApplyResources(this.xGridCell6, "xGridCell6");
            this.xGridCell6.IsVisible = false;
            this.xGridCell6.Row = -1;
            // 
            // xGridCell27
            // 
            this.xGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell27.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell27.CellName = "order_image";
            this.xGridCell27.CellWidth = 45;
            resources.ApplyResources(this.xGridCell27, "xGridCell27");
            this.xGridCell27.ImageList = this.ImageList;
            this.xGridCell27.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell27.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell27.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackgroundImage = null;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdOCS1001
            // 
            resources.ApplyResources(this.grdOCS1001, "grdOCS1001");
            this.grdOCS1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell125,
            this.xEditGridCell12,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell1,
            this.xEditGridCell18,
            this.xEditGridCell126,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell117,
            this.xEditGridCell118,
            this.xEditGridCell119,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell123,
            this.xEditGridCell124,
            this.xEditGridCell98});
            this.grdOCS1001.ColPerLine = 6;
            this.grdOCS1001.Cols = 6;
            this.grdOCS1001.EnableMultiSelection = true;
            this.grdOCS1001.ExecuteQuery = null;
            this.grdOCS1001.FixedRows = 1;
            this.grdOCS1001.HeaderHeights.Add(21);
            this.grdOCS1001.Name = "grdOCS1001";
            this.grdOCS1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS1001.ParamList")));
            this.grdOCS1001.QuerySQL = resources.GetString("grdOCS1001.QuerySQL");
            this.grdOCS1001.Rows = 2;
            this.grdOCS1001.RowStateCheckOnPaint = false;
            this.grdOCS1001.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.CellName = "ju_sang_yn";
            this.xEditGridCell10.CellWidth = 43;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.ImageList = this.ImageList;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.CellName = "sang_code";
            this.xEditGridCell11.CellWidth = 83;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.ImageList = this.ImageList;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "ser";
            this.xEditGridCell125.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsUpdatable = false;
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.CellName = "dis_sang_name";
            this.xEditGridCell12.CellWidth = 323;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.ImageList = this.ImageList;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell99.CellName = "sang_start_date";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell99.Col = 3;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell99.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.CellName = "sang_end_date";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell100.Col = 4;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell101.CellName = "sang_end_sayu";
            this.xEditGridCell101.CellWidth = 180;
            this.xEditGridCell101.Col = 5;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.HeaderImageStretch = true;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsUpdatable = false;
            this.xEditGridCell101.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell101.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "bunho";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "naewon_date";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "gwa";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "doctor";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "naewon_type";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "jubsu_no";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "pk_order";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "sang_name";
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsUpdatable = false;
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "pre_modifier1";
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsUpdatable = false;
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "pre_modifier2";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsUpdatable = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "pre_modifier3";
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsUpdatable = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "pre_modifier4";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsUpdatable = false;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "pre_modifier5";
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "pre_modifier6";
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "pre_modifier7";
            this.xEditGridCell109.Col = -1;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "pre_modifier8";
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "pre_modifier9";
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsUpdatable = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "pre_modifier10";
            this.xEditGridCell112.Col = -1;
            this.xEditGridCell112.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "pre_modifier_name";
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "post_modifier1";
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsUpdatable = false;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "post_modifier2";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "post_modifier3";
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsUpdatable = false;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "post_modifier4";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "post_modifier5";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsUpdatable = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "post_modifier6";
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsUpdatable = false;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "post_modifier7";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "post_modifier8";
            this.xEditGridCell121.Col = -1;
            this.xEditGridCell121.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsUpdatable = false;
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "post_modifier9";
            this.xEditGridCell122.Col = -1;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.IsVisible = false;
            this.xEditGridCell122.Row = -1;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "post_modifier10";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsUpdatable = false;
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "post_modifier_name";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "bulyong_check";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsUpdatable = false;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.grdOUT1001);
            this.panel1.Controls.Add(this.rbtNotTreated);
            this.panel1.Controls.Add(this.rbtAll);
            this.panel1.Controls.Add(this.rbtTreated);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AccessibleDescription = null;
            this.panel2.AccessibleName = null;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackgroundImage = null;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Font = null;
            this.panel2.Name = "panel2";
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "");
            this.imageListMixGroup.Images.SetKeyName(1, "");
            this.imageListMixGroup.Images.SetKeyName(2, "");
            this.imageListMixGroup.Images.SetKeyName(3, "");
            this.imageListMixGroup.Images.SetKeyName(4, "");
            this.imageListMixGroup.Images.SetKeyName(5, "");
            this.imageListMixGroup.Images.SetKeyName(6, "");
            this.imageListMixGroup.Images.SetKeyName(7, "");
            this.imageListMixGroup.Images.SetKeyName(8, "");
            this.imageListMixGroup.Images.SetKeyName(9, "");
            this.imageListMixGroup.Images.SetKeyName(10, "");
            this.imageListMixGroup.Images.SetKeyName(11, "");
            this.imageListMixGroup.Images.SetKeyName(12, "");
            this.imageListMixGroup.Images.SetKeyName(13, "");
            this.imageListMixGroup.Images.SetKeyName(14, "");
            this.imageListMixGroup.Images.SetKeyName(15, "");
            this.imageListMixGroup.Images.SetKeyName(16, "");
            this.imageListMixGroup.Images.SetKeyName(17, "");
            this.imageListMixGroup.Images.SetKeyName(18, "");
            this.imageListMixGroup.Images.SetKeyName(19, "");
            // 
            // layReturnValue
            // 
            this.layReturnValue.ExecuteQuery = null;
            this.layReturnValue.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReturnValue.ParamList")));
            // 
            // layQueryLayout
            // 
            this.layQueryLayout.ExecuteQuery = null;
            this.layQueryLayout.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem175,
            this.multiLayoutItem176,
            this.multiLayoutItem177,
            this.multiLayoutItem178,
            this.multiLayoutItem179,
            this.multiLayoutItem180,
            this.multiLayoutItem181,
            this.multiLayoutItem182,
            this.multiLayoutItem183,
            this.multiLayoutItem184,
            this.multiLayoutItem185,
            this.multiLayoutItem186,
            this.multiLayoutItem187,
            this.multiLayoutItem188,
            this.multiLayoutItem189,
            this.multiLayoutItem190,
            this.multiLayoutItem191,
            this.multiLayoutItem192,
            this.multiLayoutItem193,
            this.multiLayoutItem194,
            this.multiLayoutItem195,
            this.multiLayoutItem196,
            this.multiLayoutItem197,
            this.multiLayoutItem198,
            this.multiLayoutItem199,
            this.multiLayoutItem200,
            this.multiLayoutItem201,
            this.multiLayoutItem202,
            this.multiLayoutItem203,
            this.multiLayoutItem204,
            this.multiLayoutItem205,
            this.multiLayoutItem206,
            this.multiLayoutItem207,
            this.multiLayoutItem208,
            this.multiLayoutItem209,
            this.multiLayoutItem210,
            this.multiLayoutItem211,
            this.multiLayoutItem212,
            this.multiLayoutItem213,
            this.multiLayoutItem214,
            this.multiLayoutItem215,
            this.multiLayoutItem216,
            this.multiLayoutItem217,
            this.multiLayoutItem218,
            this.multiLayoutItem219,
            this.multiLayoutItem220,
            this.multiLayoutItem221,
            this.multiLayoutItem222,
            this.multiLayoutItem223,
            this.multiLayoutItem224,
            this.multiLayoutItem225,
            this.multiLayoutItem226,
            this.multiLayoutItem227,
            this.multiLayoutItem228,
            this.multiLayoutItem229,
            this.multiLayoutItem230,
            this.multiLayoutItem231,
            this.multiLayoutItem232,
            this.multiLayoutItem233,
            this.multiLayoutItem234,
            this.multiLayoutItem235,
            this.multiLayoutItem236,
            this.multiLayoutItem237,
            this.multiLayoutItem238,
            this.multiLayoutItem239,
            this.multiLayoutItem240,
            this.multiLayoutItem241,
            this.multiLayoutItem242,
            this.multiLayoutItem243,
            this.multiLayoutItem244,
            this.multiLayoutItem245,
            this.multiLayoutItem246,
            this.multiLayoutItem247,
            this.multiLayoutItem248,
            this.multiLayoutItem249,
            this.multiLayoutItem250,
            this.multiLayoutItem251,
            this.multiLayoutItem252,
            this.multiLayoutItem253,
            this.multiLayoutItem254,
            this.multiLayoutItem255,
            this.multiLayoutItem256,
            this.multiLayoutItem257,
            this.multiLayoutItem258,
            this.multiLayoutItem259,
            this.multiLayoutItem260,
            this.multiLayoutItem261,
            this.multiLayoutItem262,
            this.multiLayoutItem263,
            this.multiLayoutItem264,
            this.multiLayoutItem265,
            this.multiLayoutItem266,
            this.multiLayoutItem267,
            this.multiLayoutItem268,
            this.multiLayoutItem269,
            this.multiLayoutItem270,
            this.multiLayoutItem271,
            this.multiLayoutItem272,
            this.multiLayoutItem273,
            this.multiLayoutItem274,
            this.multiLayoutItem275,
            this.multiLayoutItem276,
            this.multiLayoutItem277,
            this.multiLayoutItem278,
            this.multiLayoutItem279,
            this.multiLayoutItem280,
            this.multiLayoutItem281,
            this.multiLayoutItem282,
            this.multiLayoutItem283,
            this.multiLayoutItem284,
            this.multiLayoutItem285,
            this.multiLayoutItem286,
            this.multiLayoutItem287,
            this.multiLayoutItem288,
            this.multiLayoutItem289,
            this.multiLayoutItem290,
            this.multiLayoutItem291,
            this.multiLayoutItem292,
            this.multiLayoutItem293,
            this.multiLayoutItem294,
            this.multiLayoutItem295,
            this.multiLayoutItem296,
            this.multiLayoutItem297,
            this.multiLayoutItem298,
            this.multiLayoutItem299,
            this.multiLayoutItem300,
            this.multiLayoutItem301,
            this.multiLayoutItem302,
            this.multiLayoutItem303,
            this.multiLayoutItem304,
            this.multiLayoutItem305,
            this.multiLayoutItem306,
            this.multiLayoutItem307,
            this.multiLayoutItem308,
            this.multiLayoutItem309,
            this.multiLayoutItem310,
            this.multiLayoutItem311,
            this.multiLayoutItem312,
            this.multiLayoutItem313,
            this.multiLayoutItem314,
            this.multiLayoutItem315,
            this.multiLayoutItem316,
            this.multiLayoutItem317,
            this.multiLayoutItem318,
            this.multiLayoutItem319,
            this.multiLayoutItem320,
            this.multiLayoutItem321,
            this.multiLayoutItem322,
            this.multiLayoutItem323,
            this.multiLayoutItem324,
            this.multiLayoutItem325,
            this.multiLayoutItem326,
            this.multiLayoutItem327,
            this.multiLayoutItem328,
            this.multiLayoutItem329,
            this.multiLayoutItem330,
            this.multiLayoutItem331,
            this.multiLayoutItem332,
            this.multiLayoutItem333});
            this.layQueryLayout.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layQueryLayout.ParamList")));
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "in_out_key";
            this.multiLayoutItem175.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem175.IsUpdItem = true;
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "pkocskey";
            this.multiLayoutItem176.IsUpdItem = true;
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "bunho";
            this.multiLayoutItem177.IsUpdItem = true;
            // 
            // multiLayoutItem178
            // 
            this.multiLayoutItem178.DataName = "order_date";
            this.multiLayoutItem178.IsUpdItem = true;
            // 
            // multiLayoutItem179
            // 
            this.multiLayoutItem179.DataName = "gwa";
            this.multiLayoutItem179.IsUpdItem = true;
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "doctor";
            this.multiLayoutItem180.IsUpdItem = true;
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "resident";
            this.multiLayoutItem181.IsUpdItem = true;
            // 
            // multiLayoutItem182
            // 
            this.multiLayoutItem182.DataName = "naewon_type";
            this.multiLayoutItem182.IsUpdItem = true;
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "jubsu_no";
            this.multiLayoutItem183.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem183.IsUpdItem = true;
            // 
            // multiLayoutItem184
            // 
            this.multiLayoutItem184.DataName = "input_id";
            this.multiLayoutItem184.IsUpdItem = true;
            // 
            // multiLayoutItem185
            // 
            this.multiLayoutItem185.DataName = "input_part";
            this.multiLayoutItem185.IsUpdItem = true;
            // 
            // multiLayoutItem186
            // 
            this.multiLayoutItem186.DataName = "input_gwa";
            this.multiLayoutItem186.IsUpdItem = true;
            // 
            // multiLayoutItem187
            // 
            this.multiLayoutItem187.DataName = "input_doctor";
            this.multiLayoutItem187.IsUpdItem = true;
            // 
            // multiLayoutItem188
            // 
            this.multiLayoutItem188.DataName = "input_gubun";
            this.multiLayoutItem188.IsUpdItem = true;
            // 
            // multiLayoutItem189
            // 
            this.multiLayoutItem189.DataName = "input_gubun_name";
            // 
            // multiLayoutItem190
            // 
            this.multiLayoutItem190.DataName = "group_ser";
            this.multiLayoutItem190.IsUpdItem = true;
            // 
            // multiLayoutItem191
            // 
            this.multiLayoutItem191.DataName = "input_tab";
            this.multiLayoutItem191.IsUpdItem = true;
            // 
            // multiLayoutItem192
            // 
            this.multiLayoutItem192.DataName = "input_tab_name";
            // 
            // multiLayoutItem193
            // 
            this.multiLayoutItem193.DataName = "order_gubun";
            this.multiLayoutItem193.IsUpdItem = true;
            // 
            // multiLayoutItem194
            // 
            this.multiLayoutItem194.DataName = "order_gubun_name";
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "group_yn";
            this.multiLayoutItem195.IsUpdItem = true;
            // 
            // multiLayoutItem196
            // 
            this.multiLayoutItem196.DataName = "seq";
            this.multiLayoutItem196.IsUpdItem = true;
            // 
            // multiLayoutItem197
            // 
            this.multiLayoutItem197.DataName = "slip_code";
            this.multiLayoutItem197.IsUpdItem = true;
            // 
            // multiLayoutItem198
            // 
            this.multiLayoutItem198.DataName = "hangmog_code";
            this.multiLayoutItem198.IsUpdItem = true;
            // 
            // multiLayoutItem199
            // 
            this.multiLayoutItem199.DataName = "hangmog_name";
            // 
            // multiLayoutItem200
            // 
            this.multiLayoutItem200.DataName = "specimen_code";
            this.multiLayoutItem200.IsUpdItem = true;
            // 
            // multiLayoutItem201
            // 
            this.multiLayoutItem201.DataName = "specimen_name";
            // 
            // multiLayoutItem202
            // 
            this.multiLayoutItem202.DataName = "suryang";
            this.multiLayoutItem202.IsUpdItem = true;
            // 
            // multiLayoutItem203
            // 
            this.multiLayoutItem203.DataName = "sunab_suryang";
            this.multiLayoutItem203.IsUpdItem = true;
            // 
            // multiLayoutItem204
            // 
            this.multiLayoutItem204.DataName = "subul_suryang";
            this.multiLayoutItem204.IsUpdItem = true;
            // 
            // multiLayoutItem205
            // 
            this.multiLayoutItem205.DataName = "ord_danui";
            this.multiLayoutItem205.IsUpdItem = true;
            // 
            // multiLayoutItem206
            // 
            this.multiLayoutItem206.DataName = "ord_danui_name";
            // 
            // multiLayoutItem207
            // 
            this.multiLayoutItem207.DataName = "dv_time";
            this.multiLayoutItem207.IsUpdItem = true;
            // 
            // multiLayoutItem208
            // 
            this.multiLayoutItem208.DataName = "dv";
            this.multiLayoutItem208.IsUpdItem = true;
            // 
            // multiLayoutItem209
            // 
            this.multiLayoutItem209.DataName = "dv_1";
            this.multiLayoutItem209.IsUpdItem = true;
            // 
            // multiLayoutItem210
            // 
            this.multiLayoutItem210.DataName = "dv_2";
            this.multiLayoutItem210.IsUpdItem = true;
            // 
            // multiLayoutItem211
            // 
            this.multiLayoutItem211.DataName = "dv_3";
            this.multiLayoutItem211.IsUpdItem = true;
            // 
            // multiLayoutItem212
            // 
            this.multiLayoutItem212.DataName = "dv_4";
            this.multiLayoutItem212.IsUpdItem = true;
            // 
            // multiLayoutItem213
            // 
            this.multiLayoutItem213.DataName = "nalsu";
            this.multiLayoutItem213.IsUpdItem = true;
            // 
            // multiLayoutItem214
            // 
            this.multiLayoutItem214.DataName = "sunab_nalsu";
            this.multiLayoutItem214.IsUpdItem = true;
            // 
            // multiLayoutItem215
            // 
            this.multiLayoutItem215.DataName = "jusa";
            this.multiLayoutItem215.IsUpdItem = true;
            // 
            // multiLayoutItem216
            // 
            this.multiLayoutItem216.DataName = "jusa_name";
            this.multiLayoutItem216.IsUpdItem = true;
            // 
            // multiLayoutItem217
            // 
            this.multiLayoutItem217.DataName = "jusa_spd_gubun";
            this.multiLayoutItem217.IsUpdItem = true;
            // 
            // multiLayoutItem218
            // 
            this.multiLayoutItem218.DataName = "bogyong_code";
            this.multiLayoutItem218.IsUpdItem = true;
            // 
            // multiLayoutItem219
            // 
            this.multiLayoutItem219.DataName = "bogyong_name";
            this.multiLayoutItem219.IsUpdItem = true;
            // 
            // multiLayoutItem220
            // 
            this.multiLayoutItem220.DataName = "emergency";
            this.multiLayoutItem220.IsUpdItem = true;
            // 
            // multiLayoutItem221
            // 
            this.multiLayoutItem221.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem221.IsUpdItem = true;
            // 
            // multiLayoutItem222
            // 
            this.multiLayoutItem222.DataName = "jundal_table";
            this.multiLayoutItem222.IsUpdItem = true;
            // 
            // multiLayoutItem223
            // 
            this.multiLayoutItem223.DataName = "jundal_part";
            this.multiLayoutItem223.IsUpdItem = true;
            // 
            // multiLayoutItem224
            // 
            this.multiLayoutItem224.DataName = "move_part";
            this.multiLayoutItem224.IsUpdItem = true;
            // 
            // multiLayoutItem225
            // 
            this.multiLayoutItem225.DataName = "portable_yn";
            this.multiLayoutItem225.IsUpdItem = true;
            // 
            // multiLayoutItem226
            // 
            this.multiLayoutItem226.DataName = "powder_yn";
            this.multiLayoutItem226.IsUpdItem = true;
            // 
            // multiLayoutItem227
            // 
            this.multiLayoutItem227.DataName = "hubal_change_yn";
            this.multiLayoutItem227.IsUpdItem = true;
            // 
            // multiLayoutItem228
            // 
            this.multiLayoutItem228.DataName = "pharmacy";
            this.multiLayoutItem228.IsUpdItem = true;
            // 
            // multiLayoutItem229
            // 
            this.multiLayoutItem229.DataName = "drg_pack_yn";
            this.multiLayoutItem229.IsUpdItem = true;
            // 
            // multiLayoutItem230
            // 
            this.multiLayoutItem230.DataName = "muhyo";
            this.multiLayoutItem230.IsUpdItem = true;
            // 
            // multiLayoutItem231
            // 
            this.multiLayoutItem231.DataName = "prn_yn";
            this.multiLayoutItem231.IsUpdItem = true;
            // 
            // multiLayoutItem232
            // 
            this.multiLayoutItem232.DataName = "toiwon_drg_yn";
            this.multiLayoutItem232.IsUpdItem = true;
            // 
            // multiLayoutItem233
            // 
            this.multiLayoutItem233.DataName = "prn_nurse";
            this.multiLayoutItem233.IsUpdItem = true;
            // 
            // multiLayoutItem234
            // 
            this.multiLayoutItem234.DataName = "append_yn";
            this.multiLayoutItem234.IsUpdItem = true;
            // 
            // multiLayoutItem235
            // 
            this.multiLayoutItem235.DataName = "order_remark";
            this.multiLayoutItem235.IsUpdItem = true;
            // 
            // multiLayoutItem236
            // 
            this.multiLayoutItem236.DataName = "nurse_remark";
            this.multiLayoutItem236.IsUpdItem = true;
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "comment";
            this.multiLayoutItem237.IsUpdItem = true;
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "mix_group";
            this.multiLayoutItem238.IsUpdItem = true;
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "amt";
            this.multiLayoutItem239.IsUpdItem = true;
            // 
            // multiLayoutItem240
            // 
            this.multiLayoutItem240.DataName = "pay";
            this.multiLayoutItem240.IsUpdItem = true;
            // 
            // multiLayoutItem241
            // 
            this.multiLayoutItem241.DataName = "wonyoi_order_yn";
            this.multiLayoutItem241.IsUpdItem = true;
            // 
            // multiLayoutItem242
            // 
            this.multiLayoutItem242.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem242.IsUpdItem = true;
            // 
            // multiLayoutItem243
            // 
            this.multiLayoutItem243.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem243.IsUpdItem = true;
            // 
            // multiLayoutItem244
            // 
            this.multiLayoutItem244.DataName = "bom_occur_yn";
            this.multiLayoutItem244.IsUpdItem = true;
            // 
            // multiLayoutItem245
            // 
            this.multiLayoutItem245.DataName = "bom_source_key";
            this.multiLayoutItem245.IsUpdItem = true;
            // 
            // multiLayoutItem246
            // 
            this.multiLayoutItem246.DataName = "display_yn";
            this.multiLayoutItem246.IsUpdItem = true;
            // 
            // multiLayoutItem247
            // 
            this.multiLayoutItem247.DataName = "sunab_yn";
            this.multiLayoutItem247.IsUpdItem = true;
            // 
            // multiLayoutItem248
            // 
            this.multiLayoutItem248.DataName = "sunab_date";
            this.multiLayoutItem248.IsUpdItem = true;
            // 
            // multiLayoutItem249
            // 
            this.multiLayoutItem249.DataName = "sunab_time";
            this.multiLayoutItem249.IsUpdItem = true;
            // 
            // multiLayoutItem250
            // 
            this.multiLayoutItem250.DataName = "hope_date";
            this.multiLayoutItem250.IsUpdItem = true;
            // 
            // multiLayoutItem251
            // 
            this.multiLayoutItem251.DataName = "hope_time";
            this.multiLayoutItem251.IsUpdItem = true;
            // 
            // multiLayoutItem252
            // 
            this.multiLayoutItem252.DataName = "nurse_confirm_user";
            this.multiLayoutItem252.IsUpdItem = true;
            // 
            // multiLayoutItem253
            // 
            this.multiLayoutItem253.DataName = "nurse_confirm_date";
            this.multiLayoutItem253.IsUpdItem = true;
            // 
            // multiLayoutItem254
            // 
            this.multiLayoutItem254.DataName = "nurse_confirm_time";
            this.multiLayoutItem254.IsUpdItem = true;
            // 
            // multiLayoutItem255
            // 
            this.multiLayoutItem255.DataName = "nurse_pickup_user";
            this.multiLayoutItem255.IsUpdItem = true;
            // 
            // multiLayoutItem256
            // 
            this.multiLayoutItem256.DataName = "nurse_pickup_date";
            this.multiLayoutItem256.IsUpdItem = true;
            // 
            // multiLayoutItem257
            // 
            this.multiLayoutItem257.DataName = "nurse_pickup_time";
            this.multiLayoutItem257.IsUpdItem = true;
            // 
            // multiLayoutItem258
            // 
            this.multiLayoutItem258.DataName = "nurse_hold_user";
            this.multiLayoutItem258.IsUpdItem = true;
            // 
            // multiLayoutItem259
            // 
            this.multiLayoutItem259.DataName = "nurse_hold_date";
            this.multiLayoutItem259.IsUpdItem = true;
            // 
            // multiLayoutItem260
            // 
            this.multiLayoutItem260.DataName = "nurse_hold_time";
            this.multiLayoutItem260.IsUpdItem = true;
            // 
            // multiLayoutItem261
            // 
            this.multiLayoutItem261.DataName = "reser_date";
            this.multiLayoutItem261.IsUpdItem = true;
            // 
            // multiLayoutItem262
            // 
            this.multiLayoutItem262.DataName = "reser_time";
            this.multiLayoutItem262.IsUpdItem = true;
            // 
            // multiLayoutItem263
            // 
            this.multiLayoutItem263.DataName = "jubsu_date";
            this.multiLayoutItem263.IsUpdItem = true;
            // 
            // multiLayoutItem264
            // 
            this.multiLayoutItem264.DataName = "jubsu_time";
            this.multiLayoutItem264.IsUpdItem = true;
            // 
            // multiLayoutItem265
            // 
            this.multiLayoutItem265.DataName = "acting_date";
            this.multiLayoutItem265.IsUpdItem = true;
            // 
            // multiLayoutItem266
            // 
            this.multiLayoutItem266.DataName = "acting_time";
            this.multiLayoutItem266.IsUpdItem = true;
            // 
            // multiLayoutItem267
            // 
            this.multiLayoutItem267.DataName = "acting_day";
            this.multiLayoutItem267.IsUpdItem = true;
            // 
            // multiLayoutItem268
            // 
            this.multiLayoutItem268.DataName = "result_date";
            this.multiLayoutItem268.IsUpdItem = true;
            // 
            // multiLayoutItem269
            // 
            this.multiLayoutItem269.DataName = "dc_gubun";
            this.multiLayoutItem269.IsUpdItem = true;
            // 
            // multiLayoutItem270
            // 
            this.multiLayoutItem270.DataName = "dc_yn";
            this.multiLayoutItem270.IsUpdItem = true;
            // 
            // multiLayoutItem271
            // 
            this.multiLayoutItem271.DataName = "bannab_yn";
            this.multiLayoutItem271.IsUpdItem = true;
            // 
            // multiLayoutItem272
            // 
            this.multiLayoutItem272.DataName = "bannab_confirm";
            this.multiLayoutItem272.IsUpdItem = true;
            // 
            // multiLayoutItem273
            // 
            this.multiLayoutItem273.DataName = "source_ord_key";
            this.multiLayoutItem273.IsUpdItem = true;
            // 
            // multiLayoutItem274
            // 
            this.multiLayoutItem274.DataName = "ocs_flag";
            this.multiLayoutItem274.IsUpdItem = true;
            // 
            // multiLayoutItem275
            // 
            this.multiLayoutItem275.DataName = "sg_code";
            this.multiLayoutItem275.IsUpdItem = true;
            // 
            // multiLayoutItem276
            // 
            this.multiLayoutItem276.DataName = "sg_ymd";
            this.multiLayoutItem276.IsUpdItem = true;
            // 
            // multiLayoutItem277
            // 
            this.multiLayoutItem277.DataName = "io_gubun";
            this.multiLayoutItem277.IsUpdItem = true;
            // 
            // multiLayoutItem278
            // 
            this.multiLayoutItem278.DataName = "after_act_yn";
            this.multiLayoutItem278.IsUpdItem = true;
            // 
            // multiLayoutItem279
            // 
            this.multiLayoutItem279.DataName = "bichi_yn";
            this.multiLayoutItem279.IsUpdItem = true;
            // 
            // multiLayoutItem280
            // 
            this.multiLayoutItem280.DataName = "drg_bunho";
            this.multiLayoutItem280.IsUpdItem = true;
            // 
            // multiLayoutItem281
            // 
            this.multiLayoutItem281.DataName = "sub_susul";
            this.multiLayoutItem281.IsUpdItem = true;
            // 
            // multiLayoutItem282
            // 
            this.multiLayoutItem282.DataName = "print_yn";
            this.multiLayoutItem282.IsUpdItem = true;
            // 
            // multiLayoutItem283
            // 
            this.multiLayoutItem283.DataName = "chisik";
            this.multiLayoutItem283.IsUpdItem = true;
            // 
            // multiLayoutItem284
            // 
            this.multiLayoutItem284.DataName = "tel_yn";
            this.multiLayoutItem284.IsUpdItem = true;
            // 
            // multiLayoutItem285
            // 
            this.multiLayoutItem285.DataName = "order_gubun_bas";
            this.multiLayoutItem285.IsUpdItem = true;
            // 
            // multiLayoutItem286
            // 
            this.multiLayoutItem286.DataName = "input_control";
            this.multiLayoutItem286.IsUpdItem = true;
            // 
            // multiLayoutItem287
            // 
            this.multiLayoutItem287.DataName = "suga_yn";
            this.multiLayoutItem287.IsUpdItem = true;
            // 
            // multiLayoutItem288
            // 
            this.multiLayoutItem288.DataName = "jaeryo_yn";
            this.multiLayoutItem288.IsUpdItem = true;
            // 
            // multiLayoutItem289
            // 
            this.multiLayoutItem289.DataName = "wonyoi_check";
            this.multiLayoutItem289.IsUpdItem = true;
            // 
            // multiLayoutItem290
            // 
            this.multiLayoutItem290.DataName = "emergency_check";
            this.multiLayoutItem290.IsUpdItem = true;
            // 
            // multiLayoutItem291
            // 
            this.multiLayoutItem291.DataName = "specimen_check";
            // 
            // multiLayoutItem292
            // 
            this.multiLayoutItem292.DataName = "portable_check";
            this.multiLayoutItem292.IsUpdItem = true;
            // 
            // multiLayoutItem293
            // 
            this.multiLayoutItem293.DataName = "bulyong_check";
            this.multiLayoutItem293.IsUpdItem = true;
            // 
            // multiLayoutItem294
            // 
            this.multiLayoutItem294.DataName = "sunab_check";
            // 
            // multiLayoutItem295
            // 
            this.multiLayoutItem295.DataName = "dc_check";
            // 
            // multiLayoutItem296
            // 
            this.multiLayoutItem296.DataName = "dc_gubun_check";
            this.multiLayoutItem296.IsUpdItem = true;
            // 
            // multiLayoutItem297
            // 
            this.multiLayoutItem297.DataName = "confirm_check";
            this.multiLayoutItem297.IsUpdItem = true;
            // 
            // multiLayoutItem298
            // 
            this.multiLayoutItem298.DataName = "reser_yn_check";
            this.multiLayoutItem298.IsUpdItem = true;
            // 
            // multiLayoutItem299
            // 
            this.multiLayoutItem299.DataName = "chisik_check";
            this.multiLayoutItem299.IsUpdItem = true;
            // 
            // multiLayoutItem300
            // 
            this.multiLayoutItem300.DataName = "nday_yn";
            this.multiLayoutItem300.IsUpdItem = true;
            // 
            // multiLayoutItem301
            // 
            this.multiLayoutItem301.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem301.IsUpdItem = true;
            // 
            // multiLayoutItem302
            // 
            this.multiLayoutItem302.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem302.IsUpdItem = true;
            // 
            // multiLayoutItem303
            // 
            this.multiLayoutItem303.DataName = "specific_comment";
            this.multiLayoutItem303.IsUpdItem = true;
            // 
            // multiLayoutItem304
            // 
            this.multiLayoutItem304.DataName = "specific_comment_name";
            this.multiLayoutItem304.IsUpdItem = true;
            // 
            // multiLayoutItem305
            // 
            this.multiLayoutItem305.DataName = "specific_comment_sys_id";
            this.multiLayoutItem305.IsUpdItem = true;
            // 
            // multiLayoutItem306
            // 
            this.multiLayoutItem306.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem306.IsUpdItem = true;
            // 
            // multiLayoutItem307
            // 
            this.multiLayoutItem307.DataName = "specific_comment_not_null";
            this.multiLayoutItem307.IsUpdItem = true;
            // 
            // multiLayoutItem308
            // 
            this.multiLayoutItem308.DataName = "specific_comment_table_id";
            this.multiLayoutItem308.IsUpdItem = true;
            // 
            // multiLayoutItem309
            // 
            this.multiLayoutItem309.DataName = "specific_comment_col_id";
            this.multiLayoutItem309.IsUpdItem = true;
            // 
            // multiLayoutItem310
            // 
            this.multiLayoutItem310.DataName = "donbog_yn";
            this.multiLayoutItem310.IsUpdItem = true;
            // 
            // multiLayoutItem311
            // 
            this.multiLayoutItem311.DataName = "order_gubun_bas_name";
            this.multiLayoutItem311.IsUpdItem = true;
            // 
            // multiLayoutItem312
            // 
            this.multiLayoutItem312.DataName = "act_doctor";
            this.multiLayoutItem312.IsUpdItem = true;
            // 
            // multiLayoutItem313
            // 
            this.multiLayoutItem313.DataName = "act_buseo";
            this.multiLayoutItem313.IsUpdItem = true;
            // 
            // multiLayoutItem314
            // 
            this.multiLayoutItem314.DataName = "act_gwa";
            this.multiLayoutItem314.IsUpdItem = true;
            // 
            // multiLayoutItem315
            // 
            this.multiLayoutItem315.DataName = "home_care_yn";
            this.multiLayoutItem315.IsUpdItem = true;
            // 
            // multiLayoutItem316
            // 
            this.multiLayoutItem316.DataName = "regular_yn";
            this.multiLayoutItem316.IsUpdItem = true;
            // 
            // multiLayoutItem317
            // 
            this.multiLayoutItem317.DataName = "sort_fkocskey";
            this.multiLayoutItem317.IsUpdItem = true;
            // 
            // multiLayoutItem318
            // 
            this.multiLayoutItem318.DataName = "child_yn";
            this.multiLayoutItem318.IsUpdItem = true;
            // 
            // multiLayoutItem319
            // 
            this.multiLayoutItem319.DataName = "if_input_control";
            // 
            // multiLayoutItem320
            // 
            this.multiLayoutItem320.DataName = "slip_name";
            // 
            // multiLayoutItem321
            // 
            this.multiLayoutItem321.DataName = "org_key";
            // 
            // multiLayoutItem322
            // 
            this.multiLayoutItem322.DataName = "parent_key";
            // 
            // multiLayoutItem323
            // 
            this.multiLayoutItem323.DataName = "bun_code";
            // 
            // multiLayoutItem324
            // 
            this.multiLayoutItem324.DataName = "dv_5";
            // 
            // multiLayoutItem325
            // 
            this.multiLayoutItem325.DataName = "dv_6";
            // 
            // multiLayoutItem326
            // 
            this.multiLayoutItem326.DataName = "dv_7";
            // 
            // multiLayoutItem327
            // 
            this.multiLayoutItem327.DataName = "dv_8";
            // 
            // multiLayoutItem328
            // 
            this.multiLayoutItem328.DataName = "wonnae_drg_yn";
            // 
            // multiLayoutItem329
            // 
            this.multiLayoutItem329.DataName = "hubal_change_check";
            // 
            // multiLayoutItem330
            // 
            this.multiLayoutItem330.DataName = "drg_pack_check";
            // 
            // multiLayoutItem331
            // 
            this.multiLayoutItem331.DataName = "pharmacy_check";
            // 
            // multiLayoutItem332
            // 
            this.multiLayoutItem332.DataName = "powder_check";
            // 
            // multiLayoutItem333
            // 
            this.multiLayoutItem333.DataName = "imsi_drug_yn";
            // 
            // dwOrderInfo
            // 
            resources.ApplyResources(this.dwOrderInfo, "dwOrderInfo");
            this.dwOrderInfo.DataWindowObject = "dw_order_info";
            this.dwOrderInfo.LibraryList = "OCSO\\ocso.ocs1003p01.pbd";
            this.dwOrderInfo.Name = "dwOrderInfo";
            this.dwOrderInfo.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            // 
            // layDisplayLayout
            // 
            this.layDisplayLayout.ExecuteQuery = null;
            this.layDisplayLayout.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21});
            this.layDisplayLayout.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDisplayLayout.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "group_ser";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "order_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "order_mark";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "hangmog_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "order_info";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "order_detail";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "nalsu";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "dv_name";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "acting_date";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "child_yn";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "child_exist_yn";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "input_gubun";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "dc_yn";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "num_nalsu";
            this.multiLayoutItem14.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "ocs_flag";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "sunab_yn";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "bogyong_code_yn";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "input_tab";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "group_ser_num";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "hangmog_code";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "hope_date";
            // 
            // OCS1003Q02
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.dwOrderInfo);
            this.Controls.Add(this.grdOCS1001);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "OCS1003Q02";
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1001)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layReturnValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQueryLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDisplayLayout)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);

            this.mOrderBiz = new IHIS.OCS.OrderBiz(this.Name);

			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
					if(OpenParam.Contains("naewon_date"))
					{
						if(TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
							mNaewon_date = OpenParam["naewon_date"].ToString();
					}	

					if(OpenParam.Contains("doctor"))
					{
						if(OpenParam.Contains("doctor").ToString().Trim() == "")
						{
							mbxMsg = Resources.MSG001_MSG;
							mbxCap = "";
							XMessageBox.Show(mbxMsg, mbxCap);
						}
						else
							mDoctor = OpenParam["doctor"].ToString();
					}
					else
					{
						mbxMsg = Resources.MSG001_MSG;
						mbxCap = "";
						XMessageBox.Show(mbxMsg, mbxCap);	
					}

					if(OpenParam.Contains("gwa"))
					{
						if(OpenParam.Contains("gwa").ToString().Trim() == "")
						{
							mbxMsg = Resources.MSG002_MSG;
							mbxCap = "";
							XMessageBox.Show(mbxMsg, mbxCap);
						}
						else
							mGwa = OpenParam["gwa"].ToString();
					}
					else
					{
						mbxMsg = Resources.MSG002_MSG;
						mbxCap = "";
						XMessageBox.Show(mbxMsg, mbxCap);	
					}

					if(OpenParam.Contains("bunho"))
					{
						if(OpenParam.Contains("bunho").ToString().Trim() == "")
						{
							mbxMsg = Resources.MSG003_MSG;
							mbxCap = "";
							XMessageBox.Show(mbxMsg, mbxCap);
						}
						else
							mBunho = OpenParam["bunho"].ToString();
					}
					else
					{
						mbxMsg = Resources.MSG003_MSG;
						mbxCap = "";
						XMessageBox.Show(mbxMsg, mbxCap);	
					}
									

				}
				catch (Exception ex)
				{
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");	
				}
			}
			else
			{
				mBunho = "000400040";
				mDoctor = "01006";
				mGwa = "01";
				mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");			
			}
            // 사용자권한체크
            IsOrderInputUserCheck(true);

            this.LoadOUT1001(this.mNaewon_date, this.mBunho, this.mGwa, this.mDoctor);
		}
        
		#endregion

        #region [ Data Load }

        private void LoadOUT1001(string aNaewonDate, string aBunho, string aGwa, string aDoctor)
        {
            this.grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);
            this.grdOUT1001.SetBindVarValue("f_bunho", mBunho);
            this.grdOUT1001.SetBindVarValue("f_gwa", mGwa);
            this.grdOUT1001.SetBindVarValue("f_doctor", mDoctor);
            this.grdOUT1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (this.rbtAll.Checked)
            {
                this.grdOUT1001.SetBindVarValue("f_naewon_yn", "%");
            }
            else if (this.rbtTreated.Checked)
            {
                this.grdOUT1001.SetBindVarValue("f_naewon_yn", "Y");
            }
            else
            {
                this.grdOUT1001.SetBindVarValue("f_naewon_yn", "N");
            }

            // Create ExecuteQuery
            grdOUT1001.ExecuteQuery = grdOUT1001_ExecuteQuery;
            grdOUT1001.QueryLayout(false);
        }

        private void LoadOUTSANG(string aBunho, string aNaewonDate, string aGwa)
        {
            this.grdOCS1001.SetBindVarValue("f_bunho", aBunho);
            this.grdOCS1001.SetBindVarValue("f_naewon_date", aNaewonDate);
            this.grdOCS1001.SetBindVarValue("f_gwa", aGwa);
            this.grdOCS1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.grdOCS1001.ExecuteQuery = grdOCS1001_ExecuteQuery;
            this.grdOCS1001.QueryLayout(true);
        }
        
        private void LoadOUT10003(string aBunho, string aPkout1001)
        {
            this.layQueryLayout.SetBindVarValue("f_bunho", aBunho);
            this.layQueryLayout.SetBindVarValue("f_fkout1001", aPkout1001);
            this.layQueryLayout.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layQueryLayout.SetBindVarValue("f_input_gubun", "D%");
            this.layQueryLayout.SetBindVarValue("f_query_gubun", (this.mDoctorLogin == true ? "D" : "N"));

            this.layQueryLayout.ExecuteQuery = layQueryLayout_ExecuteQuery;
            this.layQueryLayout.QueryLayout(true);

            this.DislplayOrderDataWindow();
        }

        private void DislplayOrderDataWindow()
        {
            this.mOrderBiz.SetDisplayOrderData(this.layQueryLayout, this.layDisplayLayout);

            this.dwOrderInfo.Reset();

            this.dwOrderInfo.FillData(this.layDisplayLayout.LayoutTable);
        }

        #endregion

        #region [Service Event]
        private void grdOUT1001_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			Imagechange(grdOUT1001);
		}
		#endregion

		#region [Control Event]
		/// <summary>
		/// radiobutton 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RadioButton_Click(object sender, System.EventArgs e)
		{
			if(rbtNotTreated.Checked)
			{
				rbtNotTreated.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtNotTreated.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtNotTreated.ImageIndex = 0;

				rbtTreated.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtTreated.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtTreated.ImageIndex = 1;

				rbtAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtAll.ImageIndex = 1;

			}
			else if(rbtTreated.Checked)
			{
				rbtTreated.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtTreated.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtTreated.ImageIndex = 0;

				rbtNotTreated.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtNotTreated.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtNotTreated.ImageIndex = 1;

				rbtAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtAll.ImageIndex = 1;		
		
			}
			else
			{
				rbtAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtAll.ImageIndex = 0;

				rbtNotTreated.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtNotTreated.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtNotTreated.ImageIndex = 1;

				rbtTreated.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtTreated.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtTreated.ImageIndex = 1;	

			}

			Imagechange(grdOUT1001);

			if(grdOUT1001.RowCount > 0)
				grdOUT1001.SetFocusToItem(0, 0);

            if (((RadioButton)sender).Checked)
                this.LoadOUT1001(this.mNaewon_date, this.mBunho, this.mGwa, this.mDoctor);
		
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#endregion

		#region [Image 표시]
		private void Imagechange(object grid)
		{
			XGrid grdObject = (XGrid)grid;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{	
				if(grdObject.GetItemString(rowIndex, "order_end_yn").ToString() == "Y")
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];	
				}
				else
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
				}
			}
		}
		#endregion

		#region [grdOUT1001 Event]

		private void grdOUT1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            XGrid grd = sender as XGrid;

            if (e.CurrentRow >= 0)
            {
                rowFocusChangedResult = LoadOutSangAndOut1003(grd.GetItemString(e.CurrentRow, "bunho"), grd.GetItemString(e.CurrentRow, "naewon_date"), grd.GetItemString(e.CurrentRow, "gwa"), grd.GetItemString(e.CurrentRow, "pk_naewon"));
                
                if (rowFocusChangedResult != null)
                {
                    this.LoadOUTSANG(grd.GetItemString(e.CurrentRow, "bunho"), grd.GetItemString(e.CurrentRow, "naewon_date"), grd.GetItemString(e.CurrentRow, "gwa"));
                    this.LoadOUT10003(grd.GetItemString(e.CurrentRow, "bunho"), grd.GetItemString(e.CurrentRow, "pk_naewon"));       
                }
                
            }
		}

		#endregion

		#region Mix Group 데이타 Image Display (DiaplayMixGroup)
		/// <summary>
		/// Mix Group 데이타 Image Display
		/// </summary>
		/// <param name="aGrd"> XEditGrid </param>
		/// <returns> void  </returns>
		private void DiaplayMixGroup(XEditGrid aGrd)
		{
			if (aGrd == null) return;

			try
			{
				//aGrd.Redraw = false; // Grid Display 멈춤

				int imageCnt = 0;

				// 기존 image 클리어
				for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

				for (int i = 0; i < aGrd.RowCount; i++)
				{
					// 이미 이미지 세팅이 안된건에 한해서 작업수행
					if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
					{
						//이미수행한건 빼는로직이 있어야함..
						int count = 0;
						for (int j = i; j < aGrd.RowCount; j++)
						{
							// 동일 group_ser, 동일 mix_group
							if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
								aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
								aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim())
							{
								count++;
								if (count > 1)
								{
									//      헤더를 빼야 실제 Row
									aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
									aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
								}
							}
						}
						// 현재는 image 갯수만큼 처리
						imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
					}
				}
			}
			finally
			{
				//aGrd.Redraw = true; // Grid Display 
			}

		}
		#endregion


        private bool IsOrderInputUserCheck(bool aIsCloseYN)
        {
            if (UserInfo.UserGubun == UserType.Doctor)
            {                
                this.mDoctorLogin = true;
                
            }
            else
            {                
                this.mDoctorLogin = false;
                
            }
                       
            return true;
        }

        #region gridOCS1001 Execute Query

        /// <summary>
        /// grdOCS1001 ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> grdOUT1001_ExecuteQuery(BindVarCollection varCollection)
	    {
	        IList<object[]> lstObject = new List<object[]>();
            OCS1003Q02GridOUT1001Args args = new OCS1003Q02GridOUT1001Args();
	        args.NaewonDate = varCollection["f_naewon_date"].VarValue;
	        args.Bunho = varCollection["f_bunho"].VarValue;
	        args.Gwa = varCollection["f_gwa"].VarValue;
	        args.Doctor = varCollection["f_doctor"].VarValue;
	        args.NaewonYn = varCollection["f_naewon_yn"].VarValue;
	        OCS1003Q02GridOUT1001Result result =
	            CloudService.Instance.Submit<OCS1003Q02GridOUT1001Result, OCS1003Q02GridOUT1001Args>(args);
	        if (result != null)
	        {
	            List<OCS1003Q02GridOUT1001Info> lstGridOut1001Info = result.GridOut1001Info;
	            if (lstGridOut1001Info != null && lstGridOut1001Info.Count > 0)
	            {
	                foreach (OCS1003Q02GridOUT1001Info out1001Info in lstGridOut1001Info)
	                {
	                    lstObject.Add(new object[]
	                    {
	                        out1001Info.Jubsu,
	                        out1001Info.ReserYn,
	                        out1001Info.JinryoTime,
	                        out1001Info.GwaName,
	                        out1001Info.DoctorName,
	                        out1001Info.NaewonYnName,
	                        out1001Info.Bunho,
	                        out1001Info.NaewonDate,
	                        out1001Info.Gwa,
	                        out1001Info.Doctor,
	                        out1001Info.NaewonType,
	                        out1001Info.JubsuNo,
	                        out1001Info.PkNaewon,
	                        out1001Info.OrderEndYn
	                    });
	                }
	            }
	        }
	        return lstObject;
	    }
        #endregion 

        #region LoadOUTSANG, LoadOUT10003

        /// <summary>
        /// Load data for gridOutSang And gridOut1003
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aNaewonDate"></param>
        /// <param name="aGwa"></param>
        /// <param name="aPkout1001"></param>
        /// <returns></returns>
        private OCS1003GrdOUT1001RowFocusChangedResult LoadOutSangAndOut1003(string aBunho, string aNaewonDate, string aGwa, string aPkout1001)
	    {
	        OCS1003GrdOUT1001RowFocusChangedArgs args = new OCS1003GrdOUT1001RowFocusChangedArgs();
            args.Bunho = aBunho;
            args.NaewonDate = aNaewonDate;
            args.Gwa = aGwa;
            args.Fkout1001 = aPkout1001;
            args.InputGubun = "D%";
            args.QueryGubun = (this.mDoctorLogin == true ? "D" : "N");

            return CloudService.Instance.Submit<OCS1003GrdOUT1001RowFocusChangedResult, OCS1003GrdOUT1001RowFocusChangedArgs>(args);
	    }

        /// <summary>
        /// grdOCS1001 ExcuteQuery
        /// </summary>
        /// <param name="bindVarCollection"></param>
        /// <returns></returns>
	    private IList<object[]> grdOCS1001_ExecuteQuery(BindVarCollection bindVarCollection)
	    {
            IList<object[]> lstObject = new List<object[]>();
	        List<OCS1003Q02grdOCS1001Info> lstGrdOcs1001Info = rowFocusChangedResult.GrdOcs1001Info;
	        if (lstGrdOcs1001Info != null && lstGrdOcs1001Info.Count > 0)
	        {
	            lstObject = grdOCS1001_ConvertToLstObj(lstGrdOcs1001Info);
	        }
	        return lstObject;
	    }

        /// <summary>
        /// layQueryLayout ExcuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
	    private IList<object[]> layQueryLayout_ExecuteQuery(BindVarCollection varCollection)
	    {
            IList<object[]> lstObject = new List<object[]>();
            List<OCS1003Q02LayQueryLayoutInfo> lstLayQueryLayoutInfo = rowFocusChangedResult.LayQueryLayoutInfo;
            if (lstLayQueryLayoutInfo != null && lstLayQueryLayoutInfo.Count > 0)
            {
                lstObject = layQueryLayout_ConvertToLstObj(lstLayQueryLayoutInfo);
            }
            return lstObject;

	    }
        /// <summary>
        /// Convert from List<OCS1003Q02grdOCS1001Info> to List<object[]>
        /// </summary>
        /// <param name="lstGrdOcs1001Info"></param>
        /// <returns></returns>
	    private IList<object[]> grdOCS1001_ConvertToLstObj(List<OCS1003Q02grdOCS1001Info> lstGrdOcs1001Info)
	    {
	        IList<object[]> lstObject = new List<object[]>();
	        if (lstGrdOcs1001Info != null && lstGrdOcs1001Info.Count > 0)
	        {
	            foreach (OCS1003Q02grdOCS1001Info ocs1001Info in lstGrdOcs1001Info)
	            {
	                lstObject.Add(new object[]
	                {
	                    ocs1001Info.JuSangYn,
	                    ocs1001Info.SangCode,
	                    ocs1001Info.Ser,
	                    ocs1001Info.DisSangName,
	                    ocs1001Info.SangStartDate,
	                    ocs1001Info.SangEndDate,
	                    ocs1001Info.SangEndSayu,
	                    ocs1001Info.Bunho,
	                    ocs1001Info.NaewonDate,
	                    ocs1001Info.Gwa,
	                    ocs1001Info.Doctor,
	                    ocs1001Info.NaewonType,
	                    ocs1001Info.JubsuNo,
	                    ocs1001Info.PkOrder,
	                    ocs1001Info.SangName,
	                    ocs1001Info.PreModifier1,
	                    ocs1001Info.PreModifier2,
	                    ocs1001Info.PreModifier3,
	                    ocs1001Info.PreModifier4,
	                    ocs1001Info.PreModifier5,
	                    ocs1001Info.PreModifier6,
	                    ocs1001Info.PreModifier7,
	                    ocs1001Info.PreModifier8,
	                    ocs1001Info.PreModifier9,
	                    ocs1001Info.PreModifier10,
	                    ocs1001Info.PreModifierName,
	                    ocs1001Info.PostModifier1,
	                    ocs1001Info.PostModifier2,
	                    ocs1001Info.PostModifier3,
	                    ocs1001Info.PostModifier4,
	                    ocs1001Info.PostModifier5,
	                    ocs1001Info.PostModifier6,
	                    ocs1001Info.PostModifier7,
	                    ocs1001Info.PostModifier8,
	                    ocs1001Info.PostModifier9,
	                    ocs1001Info.PostModifier10,
	                    ocs1001Info.PostModifierName,
	                    ocs1001Info.EndYn
	                });
	            }
	        }
	        return lstObject;
	    }

        /// <summary>
        /// Convert from List<OCS1003Q02LayQueryLayoutInfo> to List<object[]>
        /// </summary>
        /// <param name="lstLayQueryLayoutInfo"></param>
        /// <returns></returns>
	    private IList<object[]> layQueryLayout_ConvertToLstObj(List<OCS1003Q02LayQueryLayoutInfo> lstLayQueryLayoutInfo)
	    {
            IList<object[]> lstObject = new List<object[]>();
	        if (lstLayQueryLayoutInfo != null && lstLayQueryLayoutInfo.Count > 0)
	        {
                foreach (OCS1003Q02LayQueryLayoutInfo layQueryLayoutInfo in lstLayQueryLayoutInfo)
	            {
	                lstObject.Add(new object[]
	                {
	                    layQueryLayoutInfo.InOutKey,
	                    layQueryLayoutInfo.Pkocskey,
	                    layQueryLayoutInfo.Bunho,
	                    layQueryLayoutInfo.OrderDate,
	                    layQueryLayoutInfo.Gwa,
	                    layQueryLayoutInfo.Doctor,
	                    layQueryLayoutInfo.Resident,
	                    layQueryLayoutInfo.NaewonType,
	                    layQueryLayoutInfo.JubsuNo,
	                    layQueryLayoutInfo.InputId,
	                    layQueryLayoutInfo.InputPart,
	                    layQueryLayoutInfo.InputGwa,
	                    layQueryLayoutInfo.InputDoctor,
	                    layQueryLayoutInfo.InputGubun,
	                    layQueryLayoutInfo.InputGubunName,
	                    layQueryLayoutInfo.GroupSer,
	                    layQueryLayoutInfo.InputTab,
	                    layQueryLayoutInfo.InputTabName,
	                    layQueryLayoutInfo.OrderGubun,
	                    layQueryLayoutInfo.OrderGubunName,
	                    layQueryLayoutInfo.GroupYn,
	                    layQueryLayoutInfo.Seq,
	                    layQueryLayoutInfo.SlipCode,
	                    layQueryLayoutInfo.HangmogCode,
	                    layQueryLayoutInfo.HangmogName,
	                    layQueryLayoutInfo.SpecimenCode,
	                    layQueryLayoutInfo.SpecimenName,
	                    layQueryLayoutInfo.Suryang,
	                    layQueryLayoutInfo.SunabSuryang,
	                    layQueryLayoutInfo.SubulSuryang,
	                    layQueryLayoutInfo.OrdDanui,
	                    layQueryLayoutInfo.OrdDanuiName,
	                    layQueryLayoutInfo.DvTime,
	                    layQueryLayoutInfo.Dv,
	                    layQueryLayoutInfo.Dv1,
	                    layQueryLayoutInfo.Dv2,
	                    layQueryLayoutInfo.Dv3,
	                    layQueryLayoutInfo.Dv4,
	                    layQueryLayoutInfo.Nalsu,
	                    layQueryLayoutInfo.SunabNalsu,
	                    layQueryLayoutInfo.Jusa,
	                    layQueryLayoutInfo.JusaName,
	                    layQueryLayoutInfo.JusaSpdGubun,
	                    layQueryLayoutInfo.BogyongCode,
	                    layQueryLayoutInfo.BogyongName,
	                    layQueryLayoutInfo.Emergency,
	                    layQueryLayoutInfo.JaeryoJundalYn,
	                    layQueryLayoutInfo.JundalTable,
	                    layQueryLayoutInfo.JundalPart,
	                    layQueryLayoutInfo.MovePart,
	                    layQueryLayoutInfo.PortableYn,
	                    layQueryLayoutInfo.PowderYn,
	                    layQueryLayoutInfo.HubalChangeYn,
	                    layQueryLayoutInfo.Pharmacy,
	                    layQueryLayoutInfo.DrgPackYn,
	                    layQueryLayoutInfo.Muhyo,
	                    layQueryLayoutInfo.PrnYn,
	                    layQueryLayoutInfo.ToiwonDrgYn,
	                    layQueryLayoutInfo.PrnNurse,
	                    layQueryLayoutInfo.AppendYn,
	                    layQueryLayoutInfo.OrderRemark,
	                    layQueryLayoutInfo.NurseRemark,
	                    layQueryLayoutInfo.Comments,
	                    layQueryLayoutInfo.MixGroup,
	                    layQueryLayoutInfo.Amt,
	                    layQueryLayoutInfo.Pay,
	                    layQueryLayoutInfo.WonyoiOrderYn,
	                    layQueryLayoutInfo.DangilGumsaOrderYn,
	                    layQueryLayoutInfo.DangilGumsaResultYn,
	                    layQueryLayoutInfo.BomOccurYn,
	                    layQueryLayoutInfo.BomSourceKey,
	                    layQueryLayoutInfo.DisplayYn,
	                    layQueryLayoutInfo.SunabYn,
	                    layQueryLayoutInfo.SunabDate,
	                    layQueryLayoutInfo.SunabTime,
	                    layQueryLayoutInfo.HopeDate,
	                    layQueryLayoutInfo.HopeTime,
	                    layQueryLayoutInfo.NurseConfirmUser,
	                    layQueryLayoutInfo.NurseConfirmDate,
	                    layQueryLayoutInfo.NurseConfirmTime,
	                    layQueryLayoutInfo.NursePickupUser,
	                    layQueryLayoutInfo.NursePickupDate,
	                    layQueryLayoutInfo.NursePickupTime,
	                    layQueryLayoutInfo.NurseHoldUser,
	                    layQueryLayoutInfo.NurseHoldDate,
	                    layQueryLayoutInfo.NurseHoldTime,
	                    layQueryLayoutInfo.ReserDate,
	                    layQueryLayoutInfo.ReserTime,
	                    layQueryLayoutInfo.JubsuDate,
	                    layQueryLayoutInfo.JubsuTime,
	                    layQueryLayoutInfo.ActingDate,
	                    layQueryLayoutInfo.ActingTime,
	                    layQueryLayoutInfo.ActingDay,
	                    layQueryLayoutInfo.ResultDate,
	                    layQueryLayoutInfo.DcGubun,
	                    layQueryLayoutInfo.DcYn,
	                    layQueryLayoutInfo.BannabYn,
	                    layQueryLayoutInfo.BannabConfirm,
	                    layQueryLayoutInfo.SourceOrdKey,
	                    layQueryLayoutInfo.OcsFlag,
	                    layQueryLayoutInfo.SgCode,
	                    layQueryLayoutInfo.SgYmd,
	                    layQueryLayoutInfo.IoGubun,
	                    layQueryLayoutInfo.AfterActYn,
	                    layQueryLayoutInfo.BichiYn,
	                    layQueryLayoutInfo.DrgBunho,
	                    layQueryLayoutInfo.SubSusul,
	                    layQueryLayoutInfo.PrintYn,
	                    layQueryLayoutInfo.Chisik,
	                    layQueryLayoutInfo.TelYn,
	                    layQueryLayoutInfo.OrderGubunBas,
	                    layQueryLayoutInfo.InputControl,
	                    layQueryLayoutInfo.SugaYn,
	                    layQueryLayoutInfo.JaeryoYn,
	                    layQueryLayoutInfo.WonyoiCheck,
	                    layQueryLayoutInfo.EmergencyCheck,
	                    layQueryLayoutInfo.SpecimenCheck,
	                    layQueryLayoutInfo.PortableYn2,
	                    layQueryLayoutInfo.BulyongCheck,
	                    layQueryLayoutInfo.SunabCheck,
	                    layQueryLayoutInfo.DcCheck,
	                    layQueryLayoutInfo.DcGubunCheck,
	                    layQueryLayoutInfo.ConfirmCheck,
	                    layQueryLayoutInfo.ReserYnCheck,
	                    layQueryLayoutInfo.ChisikYn,
	                    layQueryLayoutInfo.NdayYn,
	                    layQueryLayoutInfo.DefaultJaeryoJundalYn,
	                    layQueryLayoutInfo.DefaultWonyoiYn,
	                    layQueryLayoutInfo.SpecificComment,
	                    layQueryLayoutInfo.SpecificCommentName,
	                    layQueryLayoutInfo.SpecificCommentSysId,
	                    layQueryLayoutInfo.SpecificCommentPgmId,
	                    layQueryLayoutInfo.SpecificCommentNotNull,
	                    layQueryLayoutInfo.SpecificCommentTableId,
	                    layQueryLayoutInfo.SpecificCommentColId,
	                    layQueryLayoutInfo.DonbogYn,
	                    layQueryLayoutInfo.OrderGubunBasName,
	                    layQueryLayoutInfo.ActDoctor,
	                    layQueryLayoutInfo.ActBuseo,
	                    layQueryLayoutInfo.ActGwa,
	                    layQueryLayoutInfo.HomeCareYn,
	                    layQueryLayoutInfo.RegularYn,
	                    layQueryLayoutInfo.SortFkocskey,
	                    layQueryLayoutInfo.ChildYn,
	                    layQueryLayoutInfo.IfInputControl,
	                    layQueryLayoutInfo.SlipName,
	                    layQueryLayoutInfo.OrgKey,
	                    layQueryLayoutInfo.ParentKey,
	                    layQueryLayoutInfo.BunCode,
	                    layQueryLayoutInfo.Dv5,
	                    layQueryLayoutInfo.Dv6,
	                    layQueryLayoutInfo.Dv7,
	                    layQueryLayoutInfo.Dv8,
	                    layQueryLayoutInfo.WonnaeDrgYn,
	                    layQueryLayoutInfo.HubalChangeCheck,
	                    layQueryLayoutInfo.DrgPackCheck,
	                    layQueryLayoutInfo.PharmacyCheck,
	                    layQueryLayoutInfo.PowerCheck,
	                    layQueryLayoutInfo.ImsiDrugYn,
	                    layQueryLayoutInfo.OrderByKey
	                });
	            }
	        }
	        return lstObject;
	    }

        #endregion
    }
}

