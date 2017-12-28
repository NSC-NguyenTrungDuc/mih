/*********************************************************************************
 * 프로그램명: OCS0311Q00
 *  내    용 : 내시경 세트 재료,처치 항목 트리
 *             선택한 재료,처치를 리턴해주는 프로그램
 *  작 성 자 : 김민수
 *  날    짜 : 2008.1.13
 * *******************************************************************************/

#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0311Q00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0311Q00 : IHIS.Framework.XScreen
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private IHIS.Framework.MultiLayout layRootList;
        private IHIS.Framework.MultiLayout layDownList;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XLabel xLabel31;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XLabel lbXrayRoom;
        private IHIS.Framework.XPictureBox xPictureBox3;
        private IHIS.Framework.XLabel xLabel32;
        private IHIS.Framework.XLabel xLabel34;
        private IHIS.Framework.XPanel xPanel7;
        private IHIS.Framework.XLabel xLabel33;
        private IHIS.Framework.XButton btnChoice;
        private System.Windows.Forms.Label label1;
        private IHIS.Framework.XTreeView JaeryoTreeView;
        private IHIS.Framework.XDictComboBox cboSetPart;
        private IHIS.Framework.MultiLayout laySet;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private IHIS.Framework.MultiLayout layJaeryo;

        public OCS0311Q00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // Updated by Cloud
            InitItemControls();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0311Q00));
            this.JaeryoTreeView = new IHIS.Framework.XTreeView();
            this.layRootList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.cboSetPart = new IHIS.Framework.XDictComboBox();
            this.layDownList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.lbXrayRoom = new IHIS.Framework.XLabel();
            this.xPictureBox3 = new IHIS.Framework.XPictureBox();
            this.xLabel32 = new IHIS.Framework.XLabel();
            this.xLabel34 = new IHIS.Framework.XLabel();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChoice = new IHIS.Framework.XButton();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.laySet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.layJaeryo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.layRootList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox3)).BeginInit();
            this.xPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJaeryo)).BeginInit();
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
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            // 
            // JaeryoTreeView
            // 
            this.JaeryoTreeView.AccessibleDescription = null;
            this.JaeryoTreeView.AccessibleName = null;
            resources.ApplyResources(this.JaeryoTreeView, "JaeryoTreeView");
            this.JaeryoTreeView.BackgroundImage = null;
            this.JaeryoTreeView.ImageList = this.ImageList;
            this.JaeryoTreeView.Name = "JaeryoTreeView";
            this.JaeryoTreeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.JaeryoTreeView_AfterCollapse);
            this.JaeryoTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.JaeryoTreeView_AfterSelect);
            this.JaeryoTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JaeryoTreeView_MouseDown);
            this.JaeryoTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.JaeryoTreeView_AfterExpand);
            // 
            // layRootList
            // 
            this.layRootList.ExecuteQuery = null;
            this.layRootList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layRootList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layRootList.ParamList")));
            this.layRootList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layRootList_QueryStarting);
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "set_part";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "hangmog_code";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "hangmog_name";
            // 
            // cboSetPart
            // 
            this.cboSetPart.AccessibleDescription = null;
            this.cboSetPart.AccessibleName = null;
            resources.ApplyResources(this.cboSetPart, "cboSetPart");
            this.cboSetPart.BackgroundImage = null;
            this.cboSetPart.ExecuteQuery = null;
            this.cboSetPart.Name = "cboSetPart";
            this.cboSetPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSetPart.ParamList")));
            this.cboSetPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSetPart.SelectedIndexChanged += new System.EventHandler(this.cboSetPart_SelectedIndexChanged);
            // 
            // layDownList
            // 
            this.layDownList.CallerID = '2';
            this.layDownList.ExecuteQuery = null;
            this.layDownList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57});
            this.layDownList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDownList.ParamList")));
            this.layDownList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layDownList_QueryEnd);
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "set_part";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "hangmog_code";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "set_code";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "set_hangmog_code";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "set_hangmog_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "suryang";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "danui";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "danui_name";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "bulyong_yn";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "slip_name";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "input_control";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "bun_code";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "conv_hangmog_code";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "conv_hangmog_name";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "conv_ord_danui";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "conv_ord_danui_name";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "conv_slip_name";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "conv_bulyong_yn";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "conv_yn";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xLabel31
            // 
            this.xLabel31.AccessibleDescription = null;
            this.xLabel31.AccessibleName = null;
            resources.ApplyResources(this.xLabel31, "xLabel31");
            this.xLabel31.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel31.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel31.EdgeRounding = false;
            this.xLabel31.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel31.Image = null;
            this.xLabel31.Name = "xLabel31";
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.lbXrayRoom);
            this.xPanel4.Controls.Add(this.xPictureBox3);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // lbXrayRoom
            // 
            this.lbXrayRoom.AccessibleDescription = null;
            this.lbXrayRoom.AccessibleName = null;
            resources.ApplyResources(this.lbXrayRoom, "lbXrayRoom");
            this.lbXrayRoom.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.lbXrayRoom.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbXrayRoom.GradientEndColor = IHIS.Framework.XColor.XGridColHeaderGradientEndColor;
            this.lbXrayRoom.Image = null;
            this.lbXrayRoom.Name = "lbXrayRoom";
            // 
            // xPictureBox3
            // 
            this.xPictureBox3.AccessibleDescription = null;
            this.xPictureBox3.AccessibleName = null;
            resources.ApplyResources(this.xPictureBox3, "xPictureBox3");
            this.xPictureBox3.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox3.BackgroundImage = null;
            this.xPictureBox3.Font = null;
            this.xPictureBox3.ImageLocation = null;
            this.xPictureBox3.Name = "xPictureBox3";
            this.xPictureBox3.Protect = false;
            this.xPictureBox3.TabStop = false;
            // 
            // xLabel32
            // 
            this.xLabel32.AccessibleDescription = null;
            this.xLabel32.AccessibleName = null;
            resources.ApplyResources(this.xLabel32, "xLabel32");
            this.xLabel32.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel32.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel32.EdgeRounding = false;
            this.xLabel32.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel32.Image = null;
            this.xLabel32.Name = "xLabel32";
            // 
            // xLabel34
            // 
            this.xLabel34.AccessibleDescription = null;
            this.xLabel34.AccessibleName = null;
            resources.ApplyResources(this.xLabel34, "xLabel34");
            this.xLabel34.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel34.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel34.EdgeRounding = false;
            this.xLabel34.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel34.Image = null;
            this.xLabel34.Name = "xLabel34";
            // 
            // xPanel7
            // 
            this.xPanel7.AccessibleDescription = null;
            this.xPanel7.AccessibleName = null;
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPanel7.BackgroundImage = null;
            this.xPanel7.Controls.Add(this.label1);
            this.xPanel7.Controls.Add(this.btnChoice);
            this.xPanel7.Controls.Add(this.btnList);
            this.xPanel7.Controls.Add(this.cboSetPart);
            this.xPanel7.Font = null;
            this.xPanel7.Name = "xPanel7";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // btnChoice
            // 
            this.btnChoice.AccessibleDescription = null;
            this.btnChoice.AccessibleName = null;
            resources.ApplyResources(this.btnChoice, "btnChoice");
            this.btnChoice.BackgroundImage = null;
            this.btnChoice.Image = ((System.Drawing.Image)(resources.GetObject("btnChoice.Image")));
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnChoice.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // xLabel33
            // 
            this.xLabel33.AccessibleDescription = null;
            this.xLabel33.AccessibleName = null;
            resources.ApplyResources(this.xLabel33, "xLabel33");
            this.xLabel33.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel33.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel33.EdgeRounding = false;
            this.xLabel33.GradientEndColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xLabel33.Image = null;
            this.xLabel33.Name = "xLabel33";
            // 
            // laySet
            // 
            this.laySet.ExecuteQuery = null;
            this.laySet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem11});
            this.laySet.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySet.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "set_part";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "hangmog_code";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "set_code";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "set_name";
            // 
            // layJaeryo
            // 
            this.layJaeryo.CallerID = '2';
            this.layJaeryo.ExecuteQuery = null;
            this.layJaeryo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem20,
            this.multiLayoutItem21});
            this.layJaeryo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJaeryo.ParamList")));
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "hangmog_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "hangmog_name";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "suryang";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "danui";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "danui_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "slip_name";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "input_control";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "bun_code";
            // 
            // OCS0311Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackGroundColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.BackgroundImage = null;
            this.Controls.Add(this.JaeryoTreeView);
            this.Controls.Add(this.xLabel34);
            this.Controls.Add(this.xPanel7);
            this.Controls.Add(this.xLabel33);
            this.Controls.Add(this.xLabel32);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xLabel31);
            this.Name = "OCS0311Q00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0311Q00_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.layRootList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox3)).EndInit();
            this.xPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.laySet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJaeryo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region RootNodeMaker()
        /// <summary>
        /// 파인드박스에서 셀렉트되었을 때, 시스템노드만 완성
        /// </summary>
        /// <returns></returns>
        private bool RootNodeMaker()
        {
            if ( !this.layRootList.QueryLayout(true) )
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
            
            //노드를 클리어합니다.
            this.JaeryoTreeView.Nodes.Clear();
            
            if (this.layRootList.RowCount < 1)
                return false;

            //root 노드 생성
            for (int i = 0 ; i < layRootList.RowCount ; i++)
            {                            
                string sSetPart     = this.layRootList.GetItemValue(i, "set_part").ToString();
                string sHangmogCode = this.layRootList.GetItemValue(i, "hangmog_code").ToString();
                string sHangmogName = this.layRootList.GetItemValue(i, "hangmog_name").ToString();
                                
                TreeNode rootNode = new TreeNode(sHangmogName);
                                
                rootNode.Tag = new object[]{"root", sSetPart, sHangmogCode, sHangmogName};
                rootNode.ImageIndex = 4;
                rootNode.SelectedImageIndex = 4;
                
                //전체 트리에 시스템 노드를 추가한다.
                this.JaeryoTreeView.Nodes.Add(rootNode);
            }
            return true;
        }
        #endregion

        #region MiddleDownNodeMaker()
        // ----------------------------------------------------------------
        // 항목노드를 제외한 하위 노드들이 생성된다
        // 항목 노드를 체크 혹은 클릭했을때는 항목과 세트노드를 생성
        // 세트 노드를 체크 혹은 클릭했을때는 세트 노드를 생성
        // ----------------------------------------------------------------
        private void MiddleDownNodeMaker(TreeNode ChooseNode, int LoopCount)
        {
            //Middle 노드 생성
            for (int i = 0 ; i < LoopCount ; i++)
            {                            
                string sSetPart     = this.laySet.GetItemValue(i, "set_part").ToString();
                string sHangmogCode = this.laySet.GetItemValue(i, "hangmog_code").ToString();
                string sSetCode     = this.laySet.GetItemValue(i, "set_code").ToString();
                string sSetName     = this.laySet.GetItemValue(i, "set_name").ToString();
                                
                TreeNode middleNode = new TreeNode(sSetName);
                                
                middleNode.Tag = new object[]{"set", sSetPart, sHangmogCode, sSetCode, sSetName};
                middleNode.ImageIndex = 2;
                middleNode.SelectedImageIndex = 3;
                
                //재료 세분류 노드를 추가한다.
                ChooseNode.Nodes.Add(middleNode);
            }
        }
        #endregion

        #region DownNodeMaker()
        // ----------------------------------------------------------------
        // 세트노드를 제외한 하위 노드들이 생성된다
        // 세트 노드를 체크 혹은 클릭했을때는 세트와 재료노드를 생성
        // 재료 노드를 체크 혹은 클릭했을때는 재료 노드를 생성
        // ----------------------------------------------------------------
        private void DownNodeMaker(TreeNode ChooseNode, int LoopCount)
        {
            for (int j = 0 ; j < LoopCount ; j++)
            {
                // 서비스에서 받아온 데이터들( 선택된 노드의 하위 노드에 대한 데이터들)
                string sSetPart          = this.layDownList.GetItemValue(j, "set_part").ToString();//표기편의를 위한 변수선언
                string sHangmogCode      = this.layDownList.GetItemValue(j, "hangmog_code").ToString();
                string sSetCode          = this.layDownList.GetItemValue(j, "set_code").ToString();
                string sSetHangmogCode   = this.layDownList.GetItemValue(j, "set_hangmog_code").ToString();
                string sSetHangmogName   = this.layDownList.GetItemValue(j, "set_hangmog_name").ToString();
                string sSuryang          = this.layDownList.GetItemValue(j, "suryang").ToString();
                string sDanui            = this.layDownList.GetItemValue(j, "danui").ToString();
                string sDanuiName        = this.layDownList.GetItemValue(j, "danui_name").ToString();
                string sBulyongYn        = this.layDownList.GetItemValue(j, "bulyong_yn").ToString();
                string sSlipName         = this.layDownList.GetItemValue(j, "slip_name").ToString();
                string sConvHangmogCode  = this.layDownList.GetItemValue(j, "conv_hangmog_code").ToString();
                string sConvHangmogName  = this.layDownList.GetItemValue(j, "conv_hangmog_name").ToString();
                string sConvOrdDanui     = this.layDownList.GetItemValue(j, "conv_ord_danui"   ).ToString();
                string sConvOrdDanuiName = this.layDownList.GetItemValue(j, "conv_ord_danui_name").ToString();
                string sConvSlipName     = this.layDownList.GetItemValue(j, "conv_slip_name").ToString();
                string sConvBulyongYn    = this.layDownList.GetItemValue(j, "conv_bulyong_yn").ToString();
                string sConvYn           = this.layDownList.GetItemValue(j, "conv_yn").ToString();
                string sInputControl     = this.layDownList.GetItemValue(j, "input_control").ToString();
                string sBunCode          = this.layDownList.GetItemValue(j, "bun_code").ToString();
                
                // 재료 노드를 생성한다.
                TreeNode downNode = new TreeNode(sSetHangmogName + " [ " + sSuryang + sDanuiName + " ] [" + sSetHangmogCode + "]");
                downNode.ImageIndex = 0;
                //downNode.SelectedImageIndex = 1;
                
                downNode.Tag = new object[]{"JAERYO", sSetPart        , sHangmogCode    , sSetCode     , sSetHangmogCode  , sSetHangmogName
                                                    , sSuryang        , sDanui          , sDanuiName   , sBulyongYn       , sSlipName     
                                                    , sConvHangmogCode, sConvHangmogName, sConvOrdDanui, sConvOrdDanuiName, sConvSlipName
                                                    , sConvBulyongYn  , sConvYn         , sInputControl, sBunCode};
                if ( sBulyongYn == "Y" )
                {
                    downNode.ForeColor = Color.Red;
                }
                
                // 하위 노드를 추가
                ChooseNode.Nodes.Add(downNode);
            }
        }
        #endregion

        #region After_Select(,)
        /// 셀렉트시 정보(node.tag)를 비교하여 하위노드를 생성하게 합니다.
        private void JaeryoTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if ( this.JaeryoTreeView.SelectedNode.Nodes.Count == 0 )
            {
                updateTree(this.JaeryoTreeView.SelectedNode);
                this.JaeryoTreeView.SelectedNode.Expand();
            }

            this.JaeryoTreeView.Refresh();
        }
        #endregion

        #region updateTree
        // ----------------------------------------------------------------
        // 트리에 정보가 변경되었을때 혹은 클릭되었을때,
        // 선택된 노드의 하위노드를 셋팅, 그리고 해쉬테이블도 셋팅
        // 이 메소드는 선택된 노드의 하위 노드만을 셋팅해 주면 되기 때문에
        // 프로그램 노드가 선택되었을 때는 아무런 일도 일어나지 안는다.
        // ----------------------------------------------------------------
        private void updateTree(TreeNode node)
        {
            if (node == null)
                return;

            object[] nodeInfo = (object[])node.Tag;//현재 체크한 노드의 태그를 가져온다.

            // 노드가 항목이라면
            if(nodeInfo[0].ToString() == "root")
            {
                try
                {
                    // 선택된 노드를 클리어 한다.
                    node.Nodes.Clear();
                    
                    // 데이터베이스의 재료 테이블에서 정보를 뽑아오기위한
                    // 인밸류 값들을 셋팅
                    this.laySet.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.laySet.SetBindVarValue("f_set_part", nodeInfo[1].ToString());
                    this.laySet.SetBindVarValue("f_hangmog_code", nodeInfo[2].ToString());
                    
                    // 서비스 호출
                    this.laySet.QueryLayout(true);
                    
                    // 서비스에서 받아온 정보를 가지고 하위 노드를 구성
                    MiddleDownNodeMaker(node, this.laySet.RowCount);
                }
                catch
                {}
            }
            // 노드가 세트라면,
            else if(nodeInfo[0].ToString() == "set")
            {
                try
                {
                    // 선택된 노드를 클리어 한다.
                    node.Nodes.Clear();
                    
                    // 데이터베이스의 메뉴/프로그램 테이블에서 정보를 뽑아오기위한
                    // 인밸류 값들을 셋팅
                    this.layDownList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layDownList.SetBindVarValue("f_set_part", nodeInfo[1].ToString());
                    this.layDownList.SetBindVarValue("f_hangmog_code", nodeInfo[2].ToString());
                    this.layDownList.SetBindVarValue("f_set_code", nodeInfo[3].ToString());
                    
                    // 서비스 호출
                    this.layDownList.QueryLayout(true);
                    
                    // 서비스에서 받아온 정보를 가지고 하위 노드를 구성
                    DownNodeMaker(node, this.layDownList.RowCount);
                }
                catch
                {}
            }
            
        }
        #endregion

        private void cboSetPart_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                //항목노드를 생성합니다.
                if(    RootNodeMaker() )
                {
                    this.JaeryoTreeView.SelectedNode = this.JaeryoTreeView.Nodes[0];
                }
            }
            catch(Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.StackTrace);
                //XMessageBox.Show(ex.Source);
            }
        }

        private void OCS0311Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            string set_part = "";
            string set_table = "";
            string hangmog_code = "";

            if (this.OpenParam != null)
            {
                set_table = this.OpenParam["set_table"].ToString();
                set_part = this.OpenParam["set_part"].ToString();
                hangmog_code = this.OpenParam["hangmog_code"].ToString();
                this.layRootList.SetBindVarValue("f_hangmog_code",hangmog_code);

                // 検査PARTセット
                //this.setCboPartBySetTable(set_table);
            }

            // Cloud updated code START
            cboSetPart.SetBindVarValue("f_set_table", set_table);
            cboSetPart.SetDictDDLB();

            this.cboSetPart.SetEditValue(set_part);
            this.cboSetPart.AcceptData();
            this.JaeryoTreeView.Refresh();
            // Cloud updated code END
        }

        #region [setCboPartBySetTable クライアントＩＰによる検査PARTセット]
//        private void setCboPartBySetTable(string srt)
//        {
//            this.cboSetPart.ResetData();

//            // 基準情報（PFE0102）から取得、システムによる検査パート設定
//            this.cboSetPart.UserSQL = @"SELECT CODE, CODE_NAME
//                                          FROM OCS0132
//                                         WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
//                                           AND CODE_TYPE = 'SET_PART'
//                                           AND GROUP_KEY = '" + srt + @"'";

//            this.cboSetPart.SetDictDDLB();

//            this.JaeryoTreeView.Refresh();
//        }
        #endregion

        private void btnChoice_Click(object sender, System.EventArgs e)
        {
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;    

            CommonItemCollection commandParams  = new CommonItemCollection();
            commandParams.Add( "jaeryo_list"   , layJaeryo);
            scrOpener.Command(this.ScreenID, commandParams);

            this.Close();
        }

        #region 버튼리스트 조회
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            if ( e.Func == FunctionType.Query )
            {
                e.IsBaseCall = false;
                try
                {
                    //항목노드를 생성합니다.
                    if(    RootNodeMaker() )
                    {
                        this.JaeryoTreeView.SelectedNode = this.JaeryoTreeView.Nodes[0];
                    }
                }
                catch(Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.StackTrace);
                    //XMessageBox.Show(ex.Source);
                }
            }
        }
        #endregion

        #region 트리 확대,축소
        private void JaeryoTreeView_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            object[] nodeInfo = (object[])this.JaeryoTreeView.SelectedNode.Tag;
            if ( nodeInfo[0].ToString() == "root" )
            {
                e.Node.ImageIndex = 5;
                e.Node.SelectedImageIndex = 5;
            }
            else if ( nodeInfo[0].ToString() == "set" )
            {
                e.Node.ImageIndex = 3;
                e.Node.SelectedImageIndex = 3;
            }
        }

        private void JaeryoTreeView_AfterCollapse(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            object[] nodeInfo = (object[])this.JaeryoTreeView.SelectedNode.Tag;
            if ( nodeInfo[0].ToString() == "root" )
            {
                e.Node.ImageIndex = 4;
                e.Node.SelectedImageIndex = 4;
            }
            else if ( nodeInfo[0].ToString() == "set" )
            {
                e.Node.ImageIndex = 2;
                e.Node.SelectedImageIndex = 2;
            }
        }
        #endregion

        #region 선택된 트리 체크 언체크 작업
        
        private void JaeryoTreeView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ( JaeryoTreeView.GetNodeAt(new Point(e.X, e.Y) ) == null || 
                 JaeryoTreeView.GetNodeAt(new Point(e.X, e.Y)).Nodes.Count > 0 ) return;

            if ( e.Button == MouseButtons.Left ) //&& e.Clicks == 1 )
            {
                TreeNode selectNode = JaeryoTreeView.GetNodeAt(new Point(e.X, e.Y) );
                JaeryoTreeView.SelectedNode = selectNode;

                object[] nodeInfo = (object[])selectNode.Tag;

                if ( nodeInfo[0].ToString() != "JAERYO" ) return;

                string hangmog_code           = nodeInfo[4].ToString();
                string hangmog_name           = nodeInfo[5].ToString();
                string suryang               = nodeInfo[6].ToString();
                string danui               = nodeInfo[7].ToString();
                string danui_name           = nodeInfo[8].ToString();
                string bulyong_yn           = nodeInfo[9].ToString();
                string slip_name           = nodeInfo[10].ToString();

                string conv_hangmog_code   = nodeInfo[11].ToString();
                string conv_hangmog_name   = nodeInfo[12].ToString();
                string conv_ord_danui      = nodeInfo[13].ToString();
                string conv_ord_danui_name = nodeInfo[14].ToString();
                string conv_slip_name      = nodeInfo[15].ToString();
                string conv_bulyong_yn     = nodeInfo[16].ToString();
                string conv_yn             = nodeInfo[17].ToString();

                string input_control = nodeInfo[18].ToString();
                string bun_code = nodeInfo[19].ToString();

                // 선택한 항목이 불용이 아닐 경우
                if ( bulyong_yn != "Y" )
                {
                    if ( selectNode.ImageIndex == 1 && selectNode.SelectedImageIndex == 1)
                    {
                        selectNode.ImageIndex = 0;
                        selectNode.SelectedImageIndex = 0;
                        for ( int i=0; i<layJaeryo.RowCount; i++ )
                        {
                            if ( layJaeryo.GetItemString(i,"hangmog_code") == hangmog_code )
                            {
                                layJaeryo.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    else
                    {
                        selectNode.ImageIndex = 1;
                        selectNode.SelectedImageIndex = 1;
                        int row = layJaeryo.InsertRow(0);
                        layJaeryo.SetItemValue(row, "hangmog_code", hangmog_code);
                        layJaeryo.SetItemValue(row, "hangmog_name", hangmog_name);
                        layJaeryo.SetItemValue(row, "suryang", suryang);
                        layJaeryo.SetItemValue(row, "danui", danui);
                        layJaeryo.SetItemValue(row, "danui_name", danui_name);
                        layJaeryo.SetItemValue(row, "slip_name", slip_name);
                        layJaeryo.SetItemValue(row, "input_control", input_control);
                        layJaeryo.SetItemValue(row, "bun_code", bun_code);
                    }
                }
                // 선택한 항목이 불용일 경우
                else
                {
                    // 대체항목이 불용이 아니고 대체항목이 있으면 대체항목의 정보를 가지고 온다.
                    // 이때, 수량은 null로 설정한다.(단위등이 문제가 될 수 있으므로)
                    if (conv_bulyong_yn != "Y" && conv_yn == "Y")
                    {
                        if ( selectNode.ImageIndex == 1 && selectNode.SelectedImageIndex == 1)
                        {
                            selectNode.ImageIndex = 0;
                            selectNode.SelectedImageIndex = 0;
                            for ( int i=0; i<layJaeryo.RowCount; i++ )
                            {
                                if ( layJaeryo.GetItemString(i,"hangmog_code") == conv_hangmog_code )
                                {
                                    layJaeryo.DeleteRow(i);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            selectNode.ImageIndex = 1;
                            selectNode.SelectedImageIndex = 1;
                            int row = layJaeryo.InsertRow(0);
                            layJaeryo.SetItemValue(row,"hangmog_code",conv_hangmog_code);
                            layJaeryo.SetItemValue(row,"hangmog_name",conv_hangmog_name);
                            layJaeryo.SetItemValue(row,"suryang",0);
                            layJaeryo.SetItemValue(row,"danui",conv_ord_danui);
                            layJaeryo.SetItemValue(row,"danui_name",conv_ord_danui_name);
                            layJaeryo.SetItemValue(row,"slip_name",conv_slip_name);
                            layJaeryo.SetItemValue(row, "input_control", input_control);
                            layJaeryo.SetItemValue(row, "bun_code", bun_code);
                        }
                    }
                }
            }
        }
        #endregion

        private void layRootList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layRootList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layRootList.SetBindVarValue("f_set_part", this.cboSetPart.GetDataValue());
        }

        private void layDownList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            #region deleted by Cloud
//            ArrayList inputList = new ArrayList();
//            ArrayList outputList = new ArrayList();
//            string cmdText = "";
//            BindVarCollection bc = new BindVarCollection();
//            string t_convert_hangmog_code = "";

//            for (int i = 0; i < this.layDownList.RowCount; i++)
//            {
//                inputList.Clear();
//                outputList.Clear();
//                /* 불용 오더 이면 대체오더로 등록이 된 것이 있는 지 확인한다. */
//                if (this.layDownList.GetItemString(i, "bulyong_yn") == "Y")
//                {
//                    inputList.Add("2");
//                    inputList.Add("1");
//                    inputList.Add(this.layDownList.GetItemString(i, "set_hangmog_code"));
//                    inputList.Add("");
//                    inputList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
//                    inputList.Add("2");

//                    Service.ExecuteProcedure("PR_OCS_CONVERT_HANGMOG_CODE", inputList, outputList);
//                    t_convert_hangmog_code = "";
//                    if (!TypeCheck.IsNull(outputList[0]))
//                        t_convert_hangmog_code = outputList[0].ToString();

//                    if (TypeCheck.NVL(layDownList.GetItemString(i, "set_hangmog_code"), "X") != TypeCheck.NVL(t_convert_hangmog_code, "X"))
//                    {
//                        /* 대체약품 정보 LOAD */
//                        cmdText = @"SELECT A.HANGMOG_NAME    HANGMOG_NAME
//                                          , A.ORD_DANUI       ORD_DANUI
//                                          , B.CODE_NAME       ORD_DANUI_NAME
//                                          , FN_OCS_BULYONG_CHECK(:t_convert_hangmog_code,SYSDATE) BULYONG_YN
//                                          , C.SLIP_NAME       SLIP_NAME
//                                       FROM OCS0102 C
//                                          , OCS0132 B
//                                          , OCS0103 A
//                                      WHERE A.HOSP_CODE    = :f_hosp_code
//                                        AND B.HOSP_CODE(+) = A.HOSP_CODE
//                                        AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                        AND A.HANGMOG_CODE = TRIM(:t_convert_hangmog_code)
//                                        AND B.CODE_TYPE(+) = 'ORD_DANUI'
//                                        AND A.ORD_DANUI    = B.CODE(+)
//                                        AND A.SLIP_CODE    = C.SLIP_CODE(+)";
//                        bc.Clear();
//                        bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bc.Add("t_convert_hangmog_code", t_convert_hangmog_code);

//                        DataTable dt = Service.ExecuteDataTable(cmdText, bc);

//                        if (!TypeCheck.IsNull(dt))
//                        {
//                            this.layDownList.SetItemValue(i, "convert_hangmog_name", dt.Rows[0]["hangmog_name"]);
//                            this.layDownList.SetItemValue(i, "convert_ord_danui", dt.Rows[0]["ord_danui"]);
//                            this.layDownList.SetItemValue(i, "convert_ord_danui_name", dt.Rows[0]["ord_danui_name"]);
//                            this.layDownList.SetItemValue(i, "convert_slip_name", dt.Rows[0]["slip_name"]);
//                            this.layDownList.SetItemValue(i, "convert_bulyong_yn", dt.Rows[0]["bulyong_yn"]);
//                            this.layDownList.SetItemValue(i, "convert_yn", "Y");
//                        }
//                    }

//                }
//            }
            #endregion

            #region updated by Cloud

            List<OCS0311Q00LayDownListQueryEndReqInfo> lstData = new List<OCS0311Q00LayDownListQueryEndReqInfo>();

            for (int i = 0; i < this.layDownList.RowCount; i++)
            {
                if (layDownList.GetItemString(i, "bulyong_yn") == "Y") continue;

                OCS0311Q00LayDownListQueryEndReqInfo item = new OCS0311Q00LayDownListQueryEndReqInfo();

                item.BulyongYn = layDownList.GetItemString(i, "bulyong_yn");
                item.SetHangmogCode = layDownList.GetItemString(i, "set_hangmog_code");

                lstData.Add(item);
            }

            if (lstData.Count > 0)
            {
                OCS0311Q00LayDownListQueryEndArgs args = new OCS0311Q00LayDownListQueryEndArgs();
                args.LayDownReqItem = lstData;
                OCS0311Q00LayDownListQueryEndResult res = CloudService.Instance.Submit<OCS0311Q00LayDownListQueryEndResult,
                    OCS0311Q00LayDownListQueryEndArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success && res.LayDownResItem.Count > 0)
                {
                    for (int i = 0; i < res.LayDownResItem.Count; i++)
                    {
                        int rowIdx = Int32.Parse(res.LayDownResItem[i].RowIdx);

                        this.layDownList.SetItemValue(rowIdx, "convert_hangmog_name", res.LayDownResItem[i].HangmogName);
                        this.layDownList.SetItemValue(rowIdx, "convert_ord_danui", res.LayDownResItem[i].OrdDanui);
                        this.layDownList.SetItemValue(rowIdx, "convert_ord_danui_name", res.LayDownResItem[i].OrdDanuiName);
                        this.layDownList.SetItemValue(rowIdx, "convert_slip_name", res.LayDownResItem[i].SlipName);
                        this.layDownList.SetItemValue(rowIdx, "convert_bulyong_yn", res.LayDownResItem[i].BulyongYn);
                        this.layDownList.SetItemValue(rowIdx, "convert_yn", "Y");
                    }
                }
            }

            #endregion

            this.layDownList.ResetUpdate();
        }

        #region Cloud updated code

        #region InitItemControls
        /// <summary>
        /// InitItemControls
        /// </summary>
        private void InitItemControls()
        {
            // layDownList
            layDownList.ParamList = new List<string>(new string[] { "f_hangmog_code", "f_set_code", "f_set_part" });
            layDownList.ExecuteQuery = GetLayDownList;

            // layRootList
            layRootList.ParamList = new List<string>(new string[] { "f_hangmog_code", "f_set_part" });
            layRootList.ExecuteQuery = GetLayRootList;

            // laySet
            laySet.ParamList = new List<string>(new string[] { "f_hangmog_code", "f_set_part" });
            laySet.ExecuteQuery = GetLaySet;

            // cboSetPart
            cboSetPart.ParamList = new List<string>(new string[] { "f_set_table" });
            cboSetPart.ExecuteQuery = GetCboSetPart;
        }
        #endregion

        #region GetLayDownList
        /// <summary>
        /// GetLayDownList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayDownList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0311Q00LayDownListArgs args = new OCS0311Q00LayDownListArgs();
            args.HangmogCode = bvc["f_hangmog_code"].VarValue;
            args.SetCode = bvc["f_set_code"].VarValue;
            args.SetPart = bvc["f_set_part"].VarValue;
            OCS0311Q00LayDownListResult res = CloudService.Instance.Submit<OCS0311Q00LayDownListResult, OCS0311Q00LayDownListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayDownListItem.ForEach(delegate(OCS0311Q00LayDownListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.SetPart,
                        item.HangmogCode,
                        item.SetCode,
                        item.HangmogCodeSet,
                        item.HangmogName,
                        item.Suryang,
                        item.Danui,
                        item.DanuiName,
                        item.BulyongYn,
                        item.SlipName,
                        item.InputControl,
                        item.BunCode,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayRootList
        /// <summary>
        /// GetLayRootList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayRootList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0311Q00LayRootListArgs args = new OCS0311Q00LayRootListArgs();
            args.HangmogCode = bvc["f_hangmog_code"].VarValue;
            args.SetPart = bvc["f_set_part"].VarValue;
            OCS0311Q00LayRootListResult res = CloudService.Instance.Submit<OCS0311Q00LayRootListResult, OCS0311Q00LayRootListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayRootListItem.ForEach(delegate(OCS0311Q00LayRootListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.SetPart,
                        item.HangmogCode,
                        item.HangmogName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLaySet
        /// <summary>
        /// GetLaySet
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLaySet(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0311Q00LaySetArgs args = new OCS0311Q00LaySetArgs();
            args.HangmogCode = bvc["f_hangmog_code"].VarValue;
            args.SetPart = bvc["f_set_part"].VarValue;
            OCS0311Q00LaySetResult res = CloudService.Instance.Submit<OCS0311Q00LaySetResult, OCS0311Q00LaySetArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LaySetItem.ForEach(delegate(OCS0311Q00LaySetInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.SetPart,
                        item.HangmogCode,
                        item.SetCode,
                        item.SetCodeName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetCboSetPart
        /// <summary>
        /// GetCboSetPart
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboSetPart(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0311Q00CboSetPartArgs args = new OCS0311Q00CboSetPartArgs();
            args.SetTable = bvc["f_set_table"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0311Q00CboSetPartArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}