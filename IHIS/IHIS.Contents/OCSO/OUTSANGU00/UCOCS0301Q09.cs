#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSO.Properties;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;

#endregion

namespace IHIS.OCSO
{
    /// <summary>
    /// OCS0301Q00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCOCS0301Q09 : IHIS.Framework.XScreen
    {
        #region [OCS Library]
        private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리        
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
        private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
        private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 오더별 컬럼 컨트롤 라이브러리
        private IHIS.OCS.PatientInfo mPatientInfo = null;
        #endregion

        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";

        //사용자
        private string mMemb = "";
        //진료과
        private string mGwa    = "";
        //진료의사
        //private string mDoctor = "";
        //입력구분 
        private string mInput_tab = "%";
        //Call한 시스템 외래,입원,응급 구분
        private string mIOgubun = "";
        private string mInput_gubun = "";
        private string mDirect_path = "";
        //약속코드
        //private string mYaksok_code = "";    
        //내원일자
        //private string mNaewon_date = "";
        //신규그룹번호발생여부
        //private bool   mIsNewGroupSer = true;

        //환자등록번호
        //private string mBunho = "";

        //ntt 자식여부
        //private string mChildYN = "";

        private IHIS.X.Magic.Menus.PopupMenu popupSetOrderCopy = new IHIS.X.Magic.Menus.PopupMenu(); // Set Gubun        
        private IHIS.X.Magic.Menus.PopupMenu popupMenu         = new IHIS.X.Magic.Menus.PopupMenu();

        private OCS.OrderBiz ob = new OrderBiz();

        // Hospital Code
        private string mHospCode = EnvironInfo.HospCode;

        private const int INPUT_GUBUN_WIDTH = 160;
        private const int INPUT_GUBUN_HEIGHT = 26;//    140, 34    
        private string protocolID;
        private bool isMouseDown = false;
        private string sangCode = "";
        #endregion

        #region Constructor
        /// <summary>
        /// OCS0301Q09
        /// </summary>
        public UCOCS0301Q09()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.mOrderBiz      = new IHIS.OCS.OrderBiz();                   // OCS 그룹 Business 라이브러리
            this.mOrderFunc     = new IHIS.OCS.OrderFunc();                  // OCS 그룹 Function 라이브러리            
            this.mHangmogInfo   = new IHIS.OCS.HangmogInfo(this.ScreenID);   // OCS 항목정보 그룹 라이브러리
            this.mInputControl  = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리     
            this.mColumnControl = new IHIS.OCS.ColumnControl(this.ScreenID); // OCS 컬럼 컨트롤 그룹 라이브러리 
            this.mPatientInfo   = new IHIS.OCS.PatientInfo(this.ScreenID);   // OCS 患者情報
            //this.protocolID = OpenParam["protocol_id"].ToString();

            //comboBox생성
            CreateCombo();

            //DataLayout 생성
            CreateLayout();
            // Cloud update
            InitControlsToConnectCloud(sangCode);
            
        }
        #endregion

        #region Events

        private void OnLoad()
        {
            mMemb = UserInfo.Gwa + UserInfo.UserID;
            // 회수 Header 한칸으로 처리하기
            if (this.grdOCS0303[0, 10] != null)
                this.grdOCS0303[0, 10].RowSpan = 2;
            if (this.grdOCS0303[1, 10] != null)
                this.grdOCS0303[1, 10] = null;
            if (this.grdOCS0303[1, 11] != null)
                this.grdOCS0303[1, 11] = null;

            //base.OnLoad(e);

            try
            {
                popupMenu.MenuCommands.Clear();
                popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG001_MSG, (Image)this.ImageList.Images[4],
                    new EventHandler(this.PopUpMenuGumsaInfo_Click)));

                popupSetOrderCopy.MenuCommands.Clear();
                popupSetOrderCopy.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG002_MSG, (Image)this.ImageList.Images[5],
                    new EventHandler(this.PopUpMenuSetOrderCopy_Click)));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.Message);
            }

            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    // 호출한 화면의 사용자 memb
                    if (OpenParam.Contains("memb"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["memb"].ToString()))
                            mMemb = OpenParam["memb"].ToString();
                    }

                    //호출한 화면의 사용자의 과
                    if (OpenParam.Contains("gwa"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["gwa"].ToString()))
                            mGwa = OpenParam["gwa"].ToString();
                    }

                    if (OpenParam.Contains("input_tab"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["input_tab"].ToString()))
                            mInput_tab = OpenParam["input_tab"].ToString();
                    }
                    if (OpenParam.Contains("io_gubun"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["io_gubun"].ToString()))
                            mIOgubun = OpenParam["io_gubun"].ToString();
                    }
                    if (OpenParam.Contains("direct_path"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["direct_path"].ToString()))
                            mDirect_path = OpenParam["direct_path"].ToString();
                    }

                    if (OpenParam.Contains("input_gubun"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["input_gubun"].ToString()))
                            mInput_gubun = OpenParam["input_gubun"].ToString().Trim();
                        else
                            mInput_gubun = "D0";
                    }
                    if (OpenParam.Contains("patient_info"))
                    {
                        this.mPatientInfo = ((PatientInfo)this.OpenParam["patient_info"]);
                    }
                    //mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                    //if (OpenParam.Contains("naewon_date"))
                    //{
                    //    if (TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                    //        mNaewon_date = OpenParam["naewon_date"].ToString();
                    //}
                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }
            else
            {
                //mYaksok_code = "";
            }

            this.initScreen();

            //Set M/D Relation
            grdOCS0303.SetRelationKey("memb", "memb");
            grdOCS0303.SetRelationKey("yaksok_code", "yaksok_code");
            grdOCS0303.SetRelationKey("input_tab", "input_tab");

            grdOCS0303.SetBindVarValue("f_input_tab", mInput_tab);
            grdOCS0303.SetBindVarValue("f_input_tab", mInput_tab);


            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0301;
            this.CurrMQLayout = this.grdOCS0301;

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void OCS0301Q00_UserChanged(object sender, System.EventArgs e)
        {
            this.panMemb.Visible = true;
            SetUserCheckBox();
        }

        private void rbtMemb_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rbt = sender as XRadioButton;

            if (rbt.Checked)
            {
                rbt.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbt.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbt.ImageIndex = 1;

                grdOCS0301.ClearFilter();

                //현재선택된 row trans            
                for (int i = 0; i < grdOCS0301.RowCount; i++)
                {
                    if (grdOCS0301.GetItemString(i, "select") == "Y")
                        dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
                }

                //현재선택된 row trans            
                for (int i = 0; i < grdOCS0303.RowCount; i++)
                {
                    if (grdOCS0303.GetItemString(i, "select") == "Y")
                        InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
                }

                string isGrantNur = "%";

                if (rbt.Tag.ToString() == "GWA")
                {
                    //this.pnlMemb_1.Visible = true;
                    //this.lblGwaDoctor.Text = "診療科";
                    //this.fbxDoctor.Visible = false;
                    //this.dbxDoctor_name.Visible = false;
                    //this.cboGwa.Visible = true;

                    //if (cboGwa.SelectedIndex >= 0)
                    //    mMemb = cboGwa.GetDataValue();
                    //else
                    //    mMemb = "";

                    isGrantNur = "Y";

                }
                else if (rbt.Tag.ToString() == "DOCTOR")
                {
                    //this.pnlMemb_1.Visible = true;
                    //lblGwaDoctor.Text = "医師";
                    //this.fbxDoctor.Visible = true;

                    //주치의 자동세팅
                    //this.fbxDoctor.SetEditValue(mDoctor);
                    //this.fbxDoctor.AcceptData();

                    //this.dbxDoctor_name.Visible = true;
                    //this.cboGwa.Visible = false;

                    //mMemb = fbxDoctor.GetDataValue();

                    isGrantNur = "Y";
                }
                else if (rbt.Tag.ToString() == "ADMIN")
                {
                    //병원공통세트의 경우 의사가 아닌 경우는 간호오더가 가능한 세트만 보여 주도록 한다.
                    if (!IsDoctor(mMemb))
                        isGrantNur = "Y";
                    else
                        isGrantNur = "%";

                    mMemb = rbt.Tag.ToString();
                }
                else
                {
                    //this.pnlMemb_1.Visible = false;
                    mMemb = rbt.Tag.ToString();
                }
                grdOCS0301.SetBindVarValue("memb", mMemb);
                grdOCS0301.SetBindVarValue("yaksok_code", "");
                //grdOCS0301.SetBindVarValue("grant_nur", isGrantNur);
                grdOCS0301.QueryLayout(true);
            }
            else
            {
                rbt.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbt.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbt.ImageIndex = 0;
            }

            #region comments
            //modify by yoonB [Query2回実行回避] 2012/03/23
            //foreach (object obj in panMemb.Controls)
            //{
            //    //if (((XRadioButton)obj).Name == rbt.Name)

            //    if (((XRadioButton)obj).Checked == true)
            //    {
            //        ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
            //        ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
            //        ((XRadioButton)obj).ImageIndex = 1;

            //        if (!((XRadioButton)obj).Checked)
            //            ((XRadioButton)obj).Checked = true;

            //        grdOCS0301.ClearFilter();

            //        //현재선택된 row trans            
            //        for (int i = 0; i < grdOCS0301.RowCount; i++)
            //        {
            //            if (grdOCS0301.GetItemString(i, "select") == "Y")
            //                dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
            //        }

            //        //현재선택된 row trans            
            //        for (int i = 0; i < grdOCS0303.RowCount; i++)
            //        {
            //            if (grdOCS0303.GetItemString(i, "select") == "Y")
            //                InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            //        }

            //        string isGrantNur = "%";

            //        if (((XRadioButton)obj).Tag.ToString() == "GWA")
            //        {
            //            //this.pnlMemb_1.Visible = true;
            //            //this.lblGwaDoctor.Text = "診療科";
            //            //this.fbxDoctor.Visible = false;
            //            //this.dbxDoctor_name.Visible = false;
            //            //this.cboGwa.Visible = true;

            //            //if (cboGwa.SelectedIndex >= 0)
            //            //    mMemb = cboGwa.GetDataValue();
            //            //else
            //            //    mMemb = "";

            //            isGrantNur = "Y";

            //        }
            //        else if (((XRadioButton)obj).Tag.ToString() == "DOCTOR")
            //        {
            //            //this.pnlMemb_1.Visible = true;
            //            //lblGwaDoctor.Text = "医師";
            //            //this.fbxDoctor.Visible = true;

            //            //주치의 자동세팅
            //            //this.fbxDoctor.SetEditValue(mDoctor);
            //            //this.fbxDoctor.AcceptData();

            //            //this.dbxDoctor_name.Visible = true;
            //            //this.cboGwa.Visible = false;

            //            //mMemb = fbxDoctor.GetDataValue();

            //            isGrantNur = "Y";
            //        }
            //        else if ((((XRadioButton)obj).Tag.ToString() == "ADMIN"))
            //        {
            //            //병원공통세트의 경우 의사가 아닌 경우는 간호오더가 가능한 세트만 보여 주도록 한다.
            //            if (!IsDoctor(mMemb))
            //                isGrantNur = "Y";
            //            else
            //                isGrantNur = "%";

            //            mMemb = ((XRadioButton)obj).Tag.ToString();
            //        }
            //        else
            //        {
            //            //this.pnlMemb_1.Visible = false;
            //            mMemb = ((XRadioButton)obj).Tag.ToString();
            //        }


            //        grdOCS0301.SetBindVarValue("memb", mMemb);
            //        grdOCS0301.SetBindVarValue("yaksok_code", "");
            //        //grdOCS0301.SetBindVarValue("grant_nur", isGrantNur);
            //        grdOCS0301.QueryLayout(true);

            //    }
            //    else
            //    {
            //        ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
            //        ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //        ((XRadioButton)obj).ImageIndex = 0;

            //        if (((XRadioButton)obj).Checked)
            //            ((XRadioButton)obj).Checked = false;
            //    }
            //}
            #endregion

            if (this.mDirect_path != "")
            {
                string[] path = this.mDirect_path.Split('/');
                string input_tab = path[0].ToString();
                string id = path[1].ToString();
                string m0300 = path[2].ToString();
                string m0303 = path[3].ToString();

                // Cloud updated code START
                OCS0301Q09RbtMembCheckedChangedArgs args = new OCS0301Q09RbtMembCheckedChangedArgs();
                args.Code = input_tab;
                args.DirectPath = this.mDirect_path;
                args.Id = id;
                args.M0300 = m0300;
                args.M0301 = mDirect_path;
                args.RbtName = rbt.Name;
                OCS0301Q09RbtMembCheckedChangedResult res = CloudService.Instance.Submit<OCS0301Q09RbtMembCheckedChangedResult,
                    OCS0301Q09RbtMembCheckedChangedArgs>(args);
                // Cloud updated code END

                if (rbt.Name == "rbt" + id)
                {
                    int node1 = 0;
                    int node2 = 0;
                    int node3 = 0;

                    #region Cloud deleted code
//                    string cmd1 = @"SELECT A.CODE_NAME
//                                 FROM OCS0132 A
//                                WHERE A.HOSP_CODE = :f_hosp_code
//                                  AND A.CODE_TYPE = 'INPUT_TAB'
//                                  AND A.CODE      = :f_code
//                ";
//                    BindVarCollection bind1 = new BindVarCollection();
//                    bind1.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bind1.Add("f_code", input_tab);

//                    object obj1 = Service.ExecuteScalar(cmd1, bind1);


//                    string cmd2 = @"SELECT A.YAKSOK_GUBUN_NAME
//                                         FROM OCS0300 A
//                                        WHERE A.HOSP_CODE = :f_hosp_code
//                                          AND A.MEMB      = :f_id
//                                          AND A.PK_SEQ    = :f_m0300";

//                    BindVarCollection bind2 = new BindVarCollection();
//                    bind2.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bind2.Add("f_id", id);
//                    bind2.Add("f_m0300", m0300);

//                    object obj2 = Service.ExecuteScalar(cmd2, bind2);

//                    string cmd3 = @"SELECT B.YAKSOK_NAME
//                                      FROM OCS0300 A
//                                          ,OCS0301 B
//                                     WHERE A.HOSP_CODE = :f_hosp_code
//                                       AND A.MEMB      = :f_id
//                                       AND A.PK_SEQ    = :f_m0300
//                                       --
//                                       AND B.HOSP_CODE     = A.HOSP_CODE
//                                       AND B.FKOCS0300_SEQ = A.PK_SEQ
//                                       AND B.YAKSOK_CODE = :f_m0301";

//                    BindVarCollection bind3 = new BindVarCollection();
//                    bind3.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bind3.Add("f_id", id);
//                    bind3.Add("f_m0300", m0300);
//                    bind3.Add("f_m0301", this.mDirect_path);

//                    object obj3 = Service.ExecuteScalar(cmd3, bind3);
                    #endregion

                    string result1 = string.Empty;
                    string result2 = string.Empty;
                    string result3 = string.Empty;
                    if (null != res)
                    {
                        result1 = res.Result1;
                        result2 = res.Result2;
                        result3 = res.Result3;
                    }

                    //if ((obj1 != null && obj1.ToString() != "")
                    //    && (obj2 != null && obj2.ToString() != "")
                    //    && (obj3 != null && obj3.ToString() != ""))
                    //{
                    if (result1 != ""
                        && result2 != ""
                        && result3 != "")
                    {
                        // 1 node find
                        for (int i1 = 0; i1 < this.tvwOCS0300.Nodes.Count; i1++)
                        {
                            if (this.tvwOCS0300.Nodes[i1].Text == /*obj1.ToString()*/result1)
                            {
                                node1 = i1;
                                // 2 node find
                                for (int i2 = 0; i2 < this.tvwOCS0300.Nodes[node1].Nodes.Count; i2++)
                                {
                                    if (this.tvwOCS0300.Nodes[node1].Nodes[i2].Text == /*obj2.ToString()*/ result2)
                                    {
                                        node2 = i2;
                                        // 3 node find
                                        for (int i3 = 0; i3 < this.tvwOCS0300.Nodes[node1].Nodes[node2].Nodes.Count; i3++)
                                        {
                                            if (this.tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[i3].Text == /*obj3.ToString()*/ result3)
                                            {
                                                node3 = i3;
                                                this.tvwOCS0300.SelectedNode = tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3];
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        //// input_tab \ id \ ocs0300 \ ocs0303
                        ////mDirect_path

                        //if (tvwOCS0300.Nodes.Count >= node1 + 1)
                        //{
                        //    if (tvwOCS0300.Nodes[node1].Nodes.Count >= node2 + 1)
                        //    {
                        //        if (tvwOCS0300.Nodes[node1].Nodes[node2].Nodes.Count >= node3 + 1)
                        //        {
                        //            if (tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3] != null)
                        //                this.tvwOCS0300.SelectedNode = tvwOCS0300.Nodes[1].Nodes[0].Nodes[1];
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }

        private void rbtMemb_Click(object sender, System.EventArgs e)
        {
            if (!isMouseDown) //탭클링어하는데 이게 자꾸 왜타지냐
                return;

            XRadioButton rbt = sender as XRadioButton;

            foreach (object obj in panMemb.Controls)
            {
                //if (((XRadioButton)obj).Name == rbt.Name)
                if (((XRadioButton)obj).Checked == true)
                {
                    ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                    ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                    ((XRadioButton)obj).ImageIndex = 1;

                    if (!((XRadioButton)obj).Checked)
                        ((XRadioButton)obj).Checked = true;

                    grdOCS0301.ClearFilter();

                    //현재선택된 row trans            
                    for (int i = 0; i < grdOCS0301.RowCount; i++)
                    {
                        if (grdOCS0301.GetItemString(i, "select") == "Y")
                            dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
                    }

                    //현재선택된 row trans            
                    for (int i = 0; i < grdOCS0303.RowCount; i++)
                    {
                        if (grdOCS0303.GetItemString(i, "select") == "Y")
                            InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
                    }

                    string isGrantNur = "%";

                    if (((XRadioButton)obj).Tag.ToString() == "GWA")
                    {
                        //this.pnlMemb_1.Visible = true;
                        //this.lblGwaDoctor.Text = "診療科";
                        //this.fbxDoctor.Visible = false;
                        //this.dbxDoctor_name.Visible = false;
                        //this.cboGwa.Visible = true;

                        //if (cboGwa.SelectedIndex >= 0)
                        //    mMemb = cboGwa.GetDataValue();
                        //else
                        //    mMemb = "";

                        isGrantNur = "Y";

                    }
                    else if (((XRadioButton)obj).Tag.ToString() == "DOCTOR")
                    {
                        //this.pnlMemb_1.Visible = true;
                        //lblGwaDoctor.Text = "医師";
                        //this.fbxDoctor.Visible = true;

                        //주치의 자동세팅
                        //this.fbxDoctor.SetEditValue(mDoctor);
                        //this.fbxDoctor.AcceptData();

                        //this.dbxDoctor_name.Visible = true;
                        //this.cboGwa.Visible = false;

                        //mMemb = fbxDoctor.GetDataValue();

                        isGrantNur = "Y";
                    }
                    else if ((((XRadioButton)obj).Tag.ToString() == "ADMIN"))
                    {
                        //병원공통세트의 경우 의사가 아닌 경우는 간호오더가 가능한 세트만 보여 주도록 한다.
                        if (!IsDoctor(mMemb))
                            isGrantNur = "Y";
                        else
                            isGrantNur = "%";

                        mMemb = ((XRadioButton)obj).Tag.ToString();
                    }
                    else
                    {
                        //this.pnlMemb_1.Visible = false;
                        mMemb = ((XRadioButton)obj).Tag.ToString();
                    }


                    grdOCS0301.SetBindVarValue("memb", mMemb);
                    grdOCS0301.SetBindVarValue("yaksok_code", "");
                    //grdOCS0301.SetBindVarValue("grant_nur", isGrantNur);
                    grdOCS0301.QueryLayout(true);

                }
                else
                {
                    ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                    ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                    ((XRadioButton)obj).ImageIndex = 0;

                    if (((XRadioButton)obj).Checked)
                        ((XRadioButton)obj).Checked = false;
                }
            }
        }

        private void tvwOCS0300_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //modify by jc [NodeLevel3でイベントが起きるように修正]
            //if (tvwOCS0300.SelectedNode.Parent == null) return;
            if (tvwOCS0300.SelectedNode.Parent == null || tvwOCS0300.SelectedNode.Level < 2)
            {

            }
            else
            {
                try
                {
                    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                    grdOCS0301.SetFocusToItem(int.Parse(tvwOCS0300.SelectedNode.Tag.ToString()), 1);

                }
                finally
                {
                    Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            }
            //tvwOCS0300.ExpandAll();
        }

        private void tvwOCS0300_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                isMouseDown = true;
                if (tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)) == null || tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)).Parent == null) return;

                if (mMemb == UserInfo.YaksokOpenID || TypeCheck.IsNull(UserInfo.YaksokOpenID)) return;
                //PopUp Menu Show
                tvwOCS0300.SelectedNode = tvwOCS0300.GetNodeAt(new Point(e.X, e.Y));
                popupSetOrderCopy.TrackPopup(tvwOCS0300.PointToScreen(new Point(e.X, e.Y)));

                isMouseDown = false;
            }
            //delete by yoonB [ダブルクリックでチェックされるロジック削除] 2012/03/23
            //else if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    if (tvwOCS0300.SelectedNode.Level > 1)
            //    {
            //        if (tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)) == null || tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)).Parent == null) return;
            //        tvwOCS0300.SelectedNode = tvwOCS0300.GetNodeAt(new Point(e.X, e.Y));

            //        if ((tvwOCS0300.SelectedNode == null) || (tvwOCS0300.SelectedNode.Parent == null)) return;

            //        TreeNode node = tvwOCS0300.GetNodeAt(new Point(e.X, e.Y));

            //        if (node.ImageIndex == 1)
            //        {
            //            //DeleteRow
            //            node.ImageIndex = 0;
            //            node.SelectedImageIndex = 0;
            //            DeleteRow("%");
            //        }
            //        else
            //        {
            //            node.ImageIndex = 1;
            //            node.SelectedImageIndex = 1;
            //            SelectRow("%");
            //        }
            //    }
            //}
        }

        private void txtSearchSetName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //            //현재선택된 row trans            
            //            for(int i = 0; i < grdOCS0301.RowCount; i++)
            //            {
            //                if(grdOCS0301.GetItemString(i, "select") == " ")
            //                    dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
            //            }
            //
            //            //현재선택된 row trans            
            //            for(int i = 0; i < grdOCS0303.RowCount; i++)
            //            {
            //                if(grdOCS0303.GetItemString(i, "select") == " ")
            //                    dloSelectOCS0303.LayoutTable.ImportRow(grdOCS0303.LayoutTable.Rows[i]);
            //            }    
            //
            //            dsvLDOCS0301.ExhaustiveCall(true);

            grdOCS0301.ClearFilter();

            if (!TypeCheck.IsNull(txtSearchSetName.GetDataValue().Trim()))
            {
                if (grdOCS0301.RowCount > 0)
                    grdOCS0301.SetFilter(" yaksok_name like '%" + txtSearchSetName.GetDataValue().Trim() + "%'");
            }

            //if (grdOCS0301.CurrentRowNumber >= 0 && grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "select_sang") == "Y")
            //    lblSelectSang.ImageIndex = 1;
            //else
            //    lblSelectSang.ImageIndex = 0;

            ShowOCS0300();

        }

        public void btnProcess_Click()
        {
            //XButton btn = sender as XButton;
            // ?? ??? ????.
            //????? row trans            
            for (int i = 0; i < grdOCS0303.RowCount; i++)
            {
                if (grdOCS0303.GetItemString(i, "select") == "Y")
                    InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            }

            CreateReturnLayout("D0");
        }

        

        private void grdOCS0301_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            ///이전에 선택한 약속코드가 있으면 선택상태로
            foreach (DataRow row in dloSelectOCS0301.LayoutTable.Select(" memb = '" + mMemb + "' ", ""))
            {
                for (int i = 0; i < grdOCS0301.RowCount; i++)
                {
                    if (grdOCS0301.GetItemString(i, "pk_seq") == row["pk_seq"].ToString() &&
                        grdOCS0301.GetItemString(i, "yaksok_code") == row["yaksok_code"].ToString())
                    {
                        grdOCS0301.SetItemValue(i, "select", "Y");
                        //grdOCS0301.SetItemValue(i, "select_sang", row["select_sang"].ToString());
                    }
                }
            }

            ////이전 선택정보를 삭제한다.
            //for (int i = 0; i < dloSelectOCS0301.RowCount; i++)
            //{
            //    if (dloSelectOCS0301.GetItemString(i, "memb") == mMemb)
            //    {
            //        dloSelectOCS0301.LayoutTable.Rows.Remove(dloSelectOCS0301.LayoutTable.Rows[i]);
            //        i = i - 1;
            //    }
            //}

            if (!TypeCheck.IsNull(txtSearchSetName.GetDataValue().Trim()))
                grdOCS0301.SetFilter(" yaksok_name like '%" + txtSearchSetName.GetDataValue().Trim() + "%'");

            ShowOCS0300();

            if (this.grdOCS0301.RowCount == 0)
                this.grdOCS0303.Reset();
        }

        private void grdOCS0303_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            string pk_yaksok = grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "pk_yaksok");

            ///이전에 선택한 약속처방이 있으면 선택상태로
            foreach (DataRow row in dloSelectOCS0303.LayoutTable.Select(" pk_yaksok = '" + pk_yaksok + "' ", ""))
            {
                for (int i = 0; i < grdOCS0303.RowCount; i++)
                {
                    if (grdOCS0303.GetItemString(i, "pkocs0303") == row["pkocs0303"].ToString())
                    {
                        //一般名の最新情報で更新
                        //if (grdOCS0303.GetItemString(i, "general_disp_yn") == "Y")
                        //    this.dloSelectOCS0303.SetItemValue(i, "hangmog_name", this.grdOCS0303.GetItemString(i, "generic_name"));
                        //else
                        //    this.dloSelectOCS0303.SetItemValue(i, "hangmog_name", this.grdOCS0303.GetItemString(i, "hangmog_name"));

                        //값 setting
                        foreach (XEditGridCell cell in grdOCS0303.CellInfos)
                        {
                            //if(cell.CellName == "select")
                            //checkplz

                            if (cell.CellName == "hangmog_name" && this.cbxGeneric_YN.GetDataValue() == "Y" && grdOCS0303.GetItemString(i, "general_disp_yn") == "Y")
                            {
                                string generic_name = mHangmogInfo.GetGenericName(grdOCS0303.GetItemString(i, "hangmog_code"));

                                if (generic_name != "")
                                {
                                    grdOCS0303.SetItemValue(i, "hangmog_name", generic_name);
                                }
                            }
                            else if (cell.CellName == "hangmog_name" && this.cbxGeneric_YN.GetDataValue() == "N" && grdOCS0303.GetItemString(i, "general_disp_yn") == "N")
                            {
                                string hangmog_name = mHangmogInfo.GetHangmogName(grdOCS0303.GetItemString(i, "hangmog_code"));

                                if (hangmog_name != "")
                                {
                                    grdOCS0303.SetItemValue(i, "hangmog_name", hangmog_name);
                                }
                            }
                            else
                                grdOCS0303.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            //if(cell.CellName == "hangmog_name")
                            //    mOrderBiz.
                            //    grdOCS0303.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            //else
                            //    grdOCS0303.SetItemValue(i, cell.CellName, row[cell.CellName]);
                        }
                    }
                }
            }

            //이전 선택정보를 삭제한다.
            //for (int i = 0; i < dloSelectOCS0303.RowCount; i++)
            //{
            //    if (dloSelectOCS0303.GetItemString(i, "pk_yaksok") == pk_yaksok)
            //    {
            //        dloSelectOCS0303.LayoutTable.Rows.Remove(dloSelectOCS0303.LayoutTable.Rows[i]);
            //        i = i - 1;
            //    }
            //}

            SelectionBackColorChange(grdOCS0303);

            //MakeGroupTab(this.grdOCS0303);

        }

        private void grdOCS0301_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //현재선택된 row trans            
            for (int i = 0; i < grdOCS0303.RowCount; i++)
            {
                if (grdOCS0303.GetItemString(i, "select") == "Y")
                    InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            }


            this.grdOCS0303.QueryLayout(true);
        }

        private void grdOCS0303_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            //insert by jc [院内採用薬の場合ROWの色を塗る。]
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(mIOgubun, grid, e);

            if (e.DataRow["bulyong_check"].ToString() == "Y" || e.DataRow["bulyong_check"].ToString() == "Z")
            {
                e.BackColor = ((XEditGridCell)grdOCS0303.CellInfos[e.ColName]).RowBackColor.Color;
                if (e.ColName != "child_gubun" && e.ColName != "select")
                    e.ForeColor = Color.Red;

            }

            switch (e.ColName)
            {
                case "general_disp_yn":
                    if (this.grdOCS0303.GetItemString(e.RowNumber, e.ColName) == "Y")
                        e.BackColor = Color.Green;
                    else
                        e.BackColor = Color.Transparent;
                    break;
            }

            #region 코드만 화면 Display하는 필드를 명칭으로 ToolTip 처리
            switch (e.ColName)
            {

                case "pay": // 급여
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "pay_name");
                    break;

                case "bogyong_name": // 급여
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "bogyong_name") + grdOCS0303.GetItemString(e.RowNumber, "dv_name");
                    break;

                case "jundal_part_out": // 전달부서 외래
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "jundal_part_out_name");
                    break;

                case "jundal_part_inp": // 전달부서 입원
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "jundal_part_inp_name");
                    break;

            }
            #endregion

        }

        private void grdOCS0303_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int rowIndex;
            rowIndex = grdOCS0303.GetHitRowNumber(e.Y);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //return; //무효처리

                if (rowIndex < 0) return;

                if (grdOCS0303.CurrentColNumber == 0)
                {
                    //불용처리된 것은 선택을 막는다
                    if (grdOCS0303.GetItemString(rowIndex, "bulyong_check") == "Y")
                    {
                        //불용인 경우에는 해당 항목의 심사기준을 보여준다.
                        mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS0303.GetItemString(rowIndex, "hangmog_code"));
                        mbxCap = Resources.MSG004_MSG;
                        if (!TypeCheck.IsNull(mbxMsg)) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

                        return;
                    }

                    if (this.grdOCS0303.GetItemString(rowIndex, "select") == "Y")
                    {
                        this.grdOCS0303.SetItemValue(rowIndex, "select", "N");
                        SelectionBackColorChange(sender, rowIndex, "N");
                        this.RemoveBackTable(this.grdOCS0303.LayoutTable.Rows[rowIndex]);
                    }
                    else
                    {
                        this.grdOCS0303.SetItemValue(rowIndex, "select", "Y");
                        SelectionBackColorChange(sender, rowIndex, "Y");
                        this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[rowIndex]);
                    }

                    /*
                    //의사인 경우 order 권한 Check한다.
                    if (UserInfo.UserGubun == UserType.Doctor)
                    {
                        if (!this.mOrderBiz.CheckOrderAuthority(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), UserInfo.Gwa, UserInfo.UserID))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】の入力権限がありません。確認してください。" : "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】오더에 대해서 입력권한이 없습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "入力権限" : "입력권한";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            return;
                        }
                    }

                    //환자별 특수약제
                    if (!TypeCheck.IsNull(mBunho) && this.mOrderBiz.CheckSpecialDrugForPatient(mBunho, grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name")))
                        return;

                    if (grdOCS0303.GetItemString(rowIndex, "select") == "")
                    {
                        //2009.12.14 ntt 자식입력에서 호출일 경우 재료만 선택가능하게
                        if (this.mChildYN == "Y")
                        {
                            if (!this.mHangmogInfo.IsChildInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")))
                                return;

                            //자식선택일 경우만 반드시 "3"으로 입력
                            grdOCS0303.SetItemValue(rowIndex, "child_gubun", "3");
                        }
                        else
                        {
                            //체크된 오다가 자식인 경우 부모가 선택되어 있는지 체크하여 메시지 처리
                            if (grdOCS0303.GetItemString(rowIndex, "child_gubun") == "3")
                            {
                                string child_key = grdOCS0303.GetItemString(rowIndex, "child_key");
                                bool isInsertYN = false;
                                for (int i = 0; i < grdOCS0303.RowCount; i++)
                                {
                                    if (grdOCS0303.GetItemString(i, "parents_key") == child_key && grdOCS0303.GetItemString(i, "select") == " ")
                                    {
                                        isInsertYN = true;
                                        break;
                                    }
                                    else
                                        isInsertYN = false;

                                }
                                if (!isInsertYN)
                                {
                                    mbxMsg = NetInfo.Language == LangMode.Jr ? "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】 選択されたオーダは材料オーダですので先に手技オーダを選択して下さい！確認してください。" : "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "　선택된 오다는 재료오더입니다 먼저 수기오다를 선택하십시오!. 확인바랍니다.";
                                    mbxCap = NetInfo.Language == LangMode.Jr ? "入力権限" : "입력권한";
                                    XMessageBox.Show(mbxMsg, mbxCap);
                                    return;
                                }
                            }
                            else
                            {
                                //단독으로 입력할 수 있는지 체크
                                if (!this.mHangmogInfo.IsDandokInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "%", grdOCS0303.GetItemString(rowIndex, "order_gubun").Substring(1, 1)))
                                    return;
                            }
                        }

                        grdOCS0303.SetItemValue(rowIndex, "select", " ");
                        SelectionBackColorChange(sender, rowIndex, "Y");
                    }
                    else
                    {
                        grdOCS0303.SetItemValue(rowIndex, "select", "");
                        SelectionBackColorChange(sender, rowIndex, "N");
                    }
                     * */

                    SetSelectYaksok();
                    SetTabImage();
                }
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowIndex < 0) return;

                /*
                //2009.12.14 ntt 자식입력에서 호출일 경우 재료만 선택가능하게
                if (this.mChildYN == "Y")
                {
                    if (!this.mHangmogInfo.IsChildInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")))
                        return;

                    //자식선택일 경우만 반드시 "3"으로 입력
                    grdOCS0303.SetItemValue(rowIndex, "child_gubun", "3");
                }
                else
                {
                    //단독입력가능여부 체크
                    if (grdOCS0303.GetItemString(rowIndex, "child_gubun") != "3")
                    {
                        if (!this.mHangmogInfo.IsDandokInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "%", grdOCS0303.GetItemString(rowIndex, "order_gubun").Substring(1, 1)))
                            return;
                    }
                }
                * */

                //CreateReturnLayout();
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                rowIndex = grdOCS0303.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOCS0303.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

                popupMenu.TrackPopup(((IHIS.Framework.XEditGrid)sender).PointToScreen(new Point(e.X, e.Y)));
            }

        }

        private void grdOCS0303_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            if (e.CurrentRow >= 0)
            {
                // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
                this.mHangmogInfo.DisplaySpecialColHeader("O", grd, e.CurrentRow, grd.GetItemString(e.CurrentRow, "hangmog_code"));
            }
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                default:

                    break;
            }
        }

        // 검사정보조회
        private void PopUpMenuGumsaInfo_Click(object sender, System.EventArgs e)
        {
            if (this.CurrMSLayout == null || CurrMSLayout.CurrentRowNumber < 0) return;

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("hangmog_code", CurrMSLayout.GetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_code"));
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        // Set Order Copy
        private void PopUpMenuSetOrderCopy_Click(object sender, System.EventArgs e)
        {
            if (tvwOCS0300.SelectedNode.Tag == null) return;

            int currentRow = int.Parse(tvwOCS0300.SelectedNode.Tag.ToString());

            string yaksok_memb = grdOCS0301.GetItemString(currentRow, "memb");
            string yaksok_code = grdOCS0301.GetItemString(currentRow, "yaksok_code");
            string newYaksok_code = "";
            string newYaksok_name = grdOCS0301.GetItemString(currentRow, "yaksok_name");
            string insert_tab = grdOCS0301.GetItemString(currentRow, "tab_gubun");


            if (CheckExistsYasokCode(yaksok_code))
            {
                //약속코드를 입력받는다.
                frmYaksok_code frm = new frmYaksok_code();
                frm.Yaksok_name = newYaksok_name;
                frm.ShowDialog();

                //선택시 처리
                if (frm.DialogResult == DialogResult.OK)
                {
                    newYaksok_code = frm.Yaksok_code;
                    newYaksok_name = frm.Yaksok_name;
                }
                else
                    return;
            }
            else
            {
                newYaksok_code = yaksok_code;
            }

            this.dloSetOrderCopy.Reset();
            int insertRow = this.dloSetOrderCopy.InsertRow(-1);
            this.dloSetOrderCopy.SetItemValue(insertRow, "source_memb", yaksok_memb);
            this.dloSetOrderCopy.SetItemValue(insertRow, "source_yaksok_code", yaksok_code);
            this.dloSetOrderCopy.SetItemValue(insertRow, "target_memb", UserInfo.YaksokOpenID);
            this.dloSetOrderCopy.SetItemValue(insertRow, "yaksok_code", newYaksok_code);
            this.dloSetOrderCopy.SetItemValue(insertRow, "yaksok_name", newYaksok_name);
            this.dloSetOrderCopy.SetItemValue(insertRow, "insert_tab", insert_tab);

            if (this.SetOrderCopy())
            {
                mbxMsg = Resources.MSG006_MSG;
                mbxCap = Resources.MSG002_MSG;
                XMessageBox.Show(mbxMsg, mbxCap);
            }
            else
            {
                mbxMsg = Resources.MSG007_MSG;
                mbxMsg = mbxMsg + Service.ErrMsg;
                mbxCap = Resources.MSG002_MSG;
                XMessageBox.Show(mbxMsg, mbxCap);
            }

        }

        private void btnCPLInfo_Click(object sender, System.EventArgs e)
        {
            int rowIndex = grdOCS0303.CurrentRowNumber;
            if (rowIndex < 0) return;

            if (grdOCS0303.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

            popupMenu.MenuCommands[0].OnClick(null);

        }

        private void grdOCS0301_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0301.SetBindVarValue("f_hosp_code", mHospCode);

            //hard coding
            grdOCS0301.SetBindVarValue("f_memb", mMemb);
            grdOCS0301.SetBindVarValue("f_input_tab", mInput_tab);
        }

        private void grdOCS0303_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0303.SetBindVarValue("f_hosp_code", mHospCode);
            //grdOCS0303.SetBindVarValue("f_group_ser", tabGroupSerial.SelectedTab.Title);

            //hard coding
            grdOCS0303.SetBindVarValue("f_memb", mMemb);
            grdOCS0303.SetBindVarValue("f_fkocs0300_seq", grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "pk_seq"));
            grdOCS0303.SetBindVarValue("f_yaksok_code", grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            grdOCS0303.SetBindVarValue("f_input_tab", grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "input_tab"));
            grdOCS0303.SetBindVarValue("f_generic_yn", cbxGeneric_YN.GetDataValue());
            grdOCS0303.SetBindVarValue("f_protocol_id", protocolID);

        }

        private void tabGroupSerial_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdOCS0303.RowCount; i++)
            {
                if (this.grdOCS0303.GetItemString(i, "group_ser") == this.tabGroupSerial.SelectedTab.Tag.ToString())
                {
                    this.grdOCS0303.SetRowVisible(i, true);
                }
                else
                {
                    this.grdOCS0303.SetRowVisible(i, false);
                }
            }
        }

        private void btnDeleteAllTab_Click(object sender, EventArgs e)
        {
            //if (this.tabGroupSerial.SelectedTab != null)
            //    SelectRow(this.tabGroupSerial.SelectedTab.Tag.ToString());
            //if (this.tabGroupSerial.SelectedTab != null)
            DeleteRow("%");
        }

        private void btnSelectAllTab_Click(object sender, EventArgs e)
        {
            //if (this.tabGroupSerial.SelectedTab != null)
            SelectRow("%");
        }

        private void grdOCS0303_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void cbxGeneric_YN_CheckedChanged(object sender, EventArgs e)
        {
            this.grdOCS0303.QueryLayout(true);
        }

        #endregion

        #region Methods (private)

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command.Trim())
            {
                case "OCS0270Q00": // 의사조회

                    //if (!TypeCheck.IsNull(commandParam["doctor"].ToString()))
                    //{
                    //    this.fbxDoctor.SetEditValue(commandParam["doctor"].ToString());
                    //}

                    //fbxDoctor.AcceptData();
                    //fbxDoctor.Focus();
                    //fbxDoctor.SelectAll();

                    break;

            }
            return base.Command(command, commandParam);
        }

        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>
        private void initScreen()
        {
            grdOCS0303.FixedCols = 7;
            //panel 경계부분 splitter가 있는 경우 경계부분 panel bordColor처리
            splitter1.BackColor = XColor.XDisplayBoxGradientEndColor.Color;

            //column invible처리
            foreach (XGridCell cell in grdOCS0303.CellInfos)
            {
                if (cell.IsVisible)
                {
                    if (mInput_tab == "%" || this.mInputControl.IsVisibleColumn(mInput_tab, cell.CellName))
                    {
                        grdOCS0303.AutoSizeColumn(cell.Col, cell.CellWidth);
                    }
                    else
                        grdOCS0303.AutoSizeColumn(cell.Col, 0);

                }
            }

            if (this.mInput_gubun == "CK" && !this.mOrderBiz.getEnablePostApprove(this.mIOgubun, this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString()))
            {
                //this.btnProcessD0.Visible = true;
                //this.btnProcessD0.Text = Resources.BTN_PROCESS_D0_1_TEXT;
                //this.btnProcessD4.Visible = false;
                //this.btnProcessD7.Visible = false;
            }
            //else if (this.mIOgubun == "O" || ((XScreen)Opener).ScreenID != "OCS2003P01")
            //{
            //    //this.btnProcessD0.Visible = true;
            //    //this.btnProcessD0.Text = Resources.BTN_PROCESS_D0_2_TEXT;
            //    //this.btnProcessD4.Visible = false;
            //    //this.btnProcessD7.Visible = false;
            //}
        }

        private void PostLoad()
        {
            

            /// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            this.OCS0301Q00_UserChanged(this, new System.EventArgs());
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (mDirect_path != "")
                PostCallHelper.PostCall(new PostMethod(SetDirect));
        }

        private void SetDirect()
        {
            ((XRadioButton)panMemb.Controls[0]).Checked = true;
        }

        private bool IsDoctor(string aMemb)
        {
//            string cmdText = @"SELECT 'Y'
//                                  FROM DUAL
//                                 WHERE EXISTS ( SELECT DOCTOR
//                                                  FROM BAS0270
//                                                 WHERE HOSP_CODE = :f_hosp_code
//                                                   AND DOCTOR    = :f_doctor
//                                                   AND SYSDATE   BETWEEN START_DATE AND END_DATE )";

//            BindVarCollection bc = new BindVarCollection();
//            bc.Add("f_hosp_code", mHospCode);
//            bc.Add("f_doctor", aMemb);

            // Cloud updated code START
            OCS0301Q09IsDoctorArgs args = new OCS0301Q09IsDoctorArgs();
            args.Doctor = aMemb;
            OCS0301Q09IsDoctorResult res = CloudService.Instance.Submit<OCS0301Q09IsDoctorResult, OCS0301Q09IsDoctorArgs>(args);

            return (null != res && res.Result == "Y");
            // Cloud updated code START

            //object retVal = Service.ExecuteScalar(cmdText, bc);
            //if (!TypeCheck.IsNull(retVal))
            //{
            //    if (retVal.ToString() == "Y")
            //        return true;
            //}

            //return false;
        }

        //사용자 checkBox 생성
        private void SetUserCheckBox()
        {
            //memb reset
            dloMemb.Reset();
            int insertRow;

            //병원공통약속order            
            insertRow = dloMemb.InsertRow(-1);
            dloMemb.SetItemValue(insertRow, "memb", "ADMIN");
            dloMemb.SetItemValue(insertRow, "memb_name", Resources.dloMembItemValue);

            // Cloud updated code START
            OCS0301Q09SetUserCheckBoxArgs args = new OCS0301Q09SetUserCheckBoxArgs();
            args.Gwa = this.mGwa;
            args.GwaAllName = new LoadColumnCodeNameInfo("gwa_all", this.mGwa, null, null, null);
            args.GwaDoctorName = new LoadColumnCodeNameInfo("gwa_doctor", "%", mMemb, null, null);
            args.UserIdName = new LoadColumnCodeNameInfo("user_id", this.mMemb, null, null, null);
            args.Memb = this.mMemb;
            OCS0301Q09SetUserCheckBoxResult res = CloudService.Instance.Submit<OCS0301Q09SetUserCheckBoxResult,
                OCS0301Q09SetUserCheckBoxArgs>(args);
            // Cloud updated code END

            //해당과
            string gwa_name = "";
            if (mGwa != "")
            {
                if (null != res)
                {
                    gwa_name = res.GwaAllName;
                    if (!string.IsNullOrEmpty(gwa_name))
                    {
                        insertRow = dloMemb.InsertRow(-1);
                        dloMemb.SetItemValue(insertRow, "memb", mGwa);
                        dloMemb.SetItemValue(insertRow, "memb_name", gwa_name);
                    }
                }

                //if (ob.LoadColumnCodeName("gwa_all", mGwa, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref gwa_name))
                //{
                //    insertRow = dloMemb.InsertRow(-1);
                //    dloMemb.SetItemValue(insertRow, "memb", mGwa);
                //    dloMemb.SetItemValue(insertRow, "memb_name", gwa_name);
                //}
            }

            string user_name = "";
            if (this.mMemb != "")
            {
                if (null != res)
                {
                    if (!string.IsNullOrEmpty(res.GwaDoctorName))
                    {
                        user_name = res.GwaDoctorName;

                        // 의사인경우는... 의사공통을 가져가야한다.
                        //해당 사용자 User
                        insertRow = dloMemb.InsertRow(-1);
                        //dloMemb.SetItemValue(insertRow, "memb", mMemb.Replace(mGwa, ""));
                        dloMemb.SetItemValue(insertRow, "memb", mMemb.Substring(2));
                        dloMemb.SetItemValue(insertRow, "memb_name", user_name + Resources.memb_name);
                    }
                    else
                    {
                        user_name = res.UserIdName;
                    }
                }

                #region Cloud deleted code
                //if (ob.LoadColumnCodeName("gwa_doctor", "%", mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref user_name))
                //{
                //    // 의사인경우는... 의사공통을 가져가야한다.
                //    //해당 사용자 User
                //    insertRow = dloMemb.InsertRow(-1);
                //    //dloMemb.SetItemValue(insertRow, "memb", mMemb.Replace(mGwa, ""));
                //    dloMemb.SetItemValue(insertRow, "memb", mMemb.Substring(2));
                //    dloMemb.SetItemValue(insertRow, "memb_name", user_name + Resources.memb_name);
                //}
                //else if (ob.LoadColumnCodeName("user_id", mMemb, ref user_name))
                //{
                //}
                #endregion

                //과별개인셋트오더취득
//                SingleLayout layCommon = new SingleLayout();
//                layCommon.QuerySQL = @" SELECT 'Y'
//                                           FROM DUAL 
//                                          WHERE EXISTS ( SELECT 'X'
//                                                           FROM  OCS0301 Z 
//                                                          WHERE  Z.HOSP_CODE = :f_hosp_code
//                                                            AND  Z.MEMB      = :f_memb)";
//                layCommon.LayoutItems.Add("check_yn");
//                layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                layCommon.SetBindVarValue("f_memb", mMemb);

                // Cloud updated code START
                if (null != res && res.Result == "Y")
                {
                    //해당 사용자 User
                    insertRow = dloMemb.InsertRow(-1);
                    dloMemb.SetItemValue(insertRow, "memb", mMemb);
                    dloMemb.SetItemValue(insertRow, "memb_name", user_name + "【" + gwa_name + "】");
                }
                // Cloud updated code END

                //if (layCommon.QueryLayout() && (layCommon.GetItemValue("check_yn").ToString() == "Y"))
                //{
                //    //해당 사용자 User
                //    insertRow = dloMemb.InsertRow(-1);
                //    dloMemb.SetItemValue(insertRow, "memb", mMemb);
                //    dloMemb.SetItemValue(insertRow, "memb_name", user_name + "【" + gwa_name + "】");
                //}
            }

            //검색어 문제로 해당부분을 막는다.
            //            if(UserInfo.UserGubun == UserType.Nurse && EnvironInfo.CurrSystemID == "NURI")
            //                this.LoadHoDongComUSer(ref dloMemb);

            //사용자 약속코드 정보 Load
            if (dloMemb.RowCount > 0)
            {
                if (dloMemb.RowCount <= 5)
                    panMemb.SetBounds(panMemb.Location.X, panMemb.Location.Y, panMemb.Size.Width, rbt.Location.Y + rbt.Size.Height + 2);

                ShowMemb();
            }
            else
            {
                mbxMsg = Resources.MSG003_MSG;
                mbxCap = Resources.MSG003_CAP;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
                this.Close();
            }

        }

        //사용자 ComboBox생성
        //private void SetUserCombo()
        //{
        //    //CreateGwaCombo();
        //}

        /// <summary>
        /// DataLayout LayoutItems생성
        /// </summary>
        private void CreateLayout()
        {
            //OCS0301
            foreach (XGridCell cell in this.grdOCS0301.CellInfos)
            {
                dloSelectOCS0301.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS0301.InitializeLayoutTable();

            //OCS0303
            foreach (XGridCell cell in this.grdOCS0303.CellInfos)
            {
                dloSelectOCS0303.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS0303.InitializeLayoutTable();
        }

        #region comments
        /// <summary>
        /// 기준정보 DataLayout생성
        /// </summary>
//        private void LoadBaseData()
//        {
//            //Order 단위
//            dloOrder_danui.QuerySQL = @"SELECT CODE
//                                          FROM OCS0132
//                                         WHERE CODE_TYPE = 'ORD_DANUI'
//                                           AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
//                                         ORDER BY CODE";
//            dloOrder_danui.QueryLayout(false);

//            //InputControl
//            dloInputControl.QuerySQL = @"SELECT INPUT_CONTROL     , 
//                                                INPUT_CONTROL_NAME, 
//                                                SPECIMEN_CR_YN    , 
//                                                SURYANG_CR_YN     , 
//                                                ORD_DANUI_CR_YN   , 
//                                         --       DV_TIME_CR_YN     , 
//                                                DV_CR_YN          , 
//                                                NALSU_CR_YN       , 
//                                                JUSA_CR_YN        , 
//                                                BOGYONG_CODE_CR_YN, 
//                                                TOIWON_DRG_CR_YN  , 
//                                         --       TPN_CR_YN         , 
//                                         --       ANTI_CANCER_CR_YN , 
//                                         --       FLUID_CR_YN       , 
//                                                PORTABLE_CR_YN    , 
//                                         --       DONER_CR_YN       , 
//                                                AMT_CR_YN           
//                                           FROM OCS0133
//                                          WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()";
//            dloInputControl.QueryLayout(false);
        //        }
        #endregion

        #region comments

        #region [병동간호 공통유져]

        //        private void LoadHoDongComUSer(ref MultiLayout dloMemb)
        //        {
        //            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();

        //            //SLIP_GUBUN DataLayout;
        //            layoutCombo.Reset();
        //            layoutCombo.LayoutItems.Clear();
        //            layoutCombo.LayoutItems.Add("memb", DataType.String);
        //            layoutCombo.LayoutItems.Add("memb_name", DataType.String);
        //            layoutCombo.InitializeLayoutTable();

        //            layoutCombo.QuerySQL = @"SELECT A.MEMB, A.MEMB_NAME FROM OCS0130 A         
        //                                      WHERE A.MEMB_GUBUN = 'B'
        //                                        AND A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
        //                                      ORDER BY MEMB ";

        //            layoutCombo.QueryLayout(false);

        //            if (Service.ErrCode.ToString() == "0" && layoutCombo.LayoutTable != null)
        //            {
        //                int insertRow = -1;
        //                foreach (DataRow row in layoutCombo.LayoutTable.Rows)
        //                {
        //                    if (dloMemb.LayoutTable.Select(" memb = '" + row["memb"].ToString() + "' ", "").Length == 0)
        //                    {
        //                        insertRow = dloMemb.InsertRow(-1);
        //                        dloMemb.SetItemValue(insertRow, "memb", row["memb"]);
        //                        dloMemb.SetItemValue(insertRow, "memb_name", row["memb_name"]);
        //                    }
        //                }
        //            }

        //        }

        #endregion

        #region [사용자공통 USER를 가져옵니다.]


        /// <summary>
        /// 해당 사용자의 공통 USER ID를 가져옵니다.
        /// </summary>
        /// <param name="aUser_gubun">공통사용자구분</param>
        /// <param name="aUser_id">사용자ID</param>
        /// <returns></returns>
        //private string GetOCSCOM_USER_ID(string aUser_gubun, string aUser_id)
        //{
        //    string comUser_id = "";
        //    string cmdText = "";
        //    BindVarCollection bindVars = new BindVarCollection();
        //    object retVal = null;

        //    cmdText = "SELECT FN_OCS_LOAD_MEMB_COMID(:f_gubun, :f_user_id) FROM DUAL";
        //    bindVars.Add("f_gubun", aUser_gubun);
        //    bindVars.Add("f_user_id", aUser_id);

        //    retVal = Service.ExecuteScalar(cmdText, bindVars);

        //    if (!TypeCheck.IsNull(retVal))
        //    {
        //        comUser_id = retVal.ToString();
        //    }

        //    return comUser_id;
        //}


        #endregion

        #endregion

        private void ShowMemb()
        {
            panMemb.Controls.Clear();

            XRadioButton rbtMemb;

            int startX = 4;
            bool isVisible = true;

            foreach (DataRow row in dloMemb.LayoutTable.Rows)
            {
                rbtMemb = new XRadioButton();
                rbtMemb.Appearance = System.Windows.Forms.Appearance.Button;
                rbtMemb.Cursor = System.Windows.Forms.Cursors.Hand;
                rbtMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtMemb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtMemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                rbtMemb.ImageList = this.ImageList;
                rbtMemb.ImageIndex = 0;
                rbtMemb.Location = new System.Drawing.Point(startX, 4);
                rbtMemb.Name = "rbt" + row["memb"];
                rbtMemb.Size = new System.Drawing.Size(INPUT_GUBUN_WIDTH, INPUT_GUBUN_HEIGHT);
                rbtMemb.Text = "     " + row["memb_name"].ToString();
                rbtMemb.Tag = row["memb"].ToString();
                rbtMemb.Visible = isVisible;
                //rbtMemb.Click += new System.EventHandler(this.rbtMemb_Click);
                rbtMemb.CheckedChanged += new EventHandler(rbtMemb_CheckedChanged);
                panMemb.Controls.Add(rbtMemb);

                startX = startX + INPUT_GUBUN_WIDTH;
            }

            // 간호
            //if (UserInfo.UserGubun == UserType.Nurse)
            //{
            //    rbtMemb = new XRadioButton();
            //    rbtMemb.Appearance = System.Windows.Forms.Appearance.Button;
            //    rbtMemb.Cursor = System.Windows.Forms.Cursors.Hand;
            //    rbtMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            //    rbtMemb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //    rbtMemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    rbtMemb.ImageList = this.ImageList;
            //    rbtMemb.ImageIndex = 0;
            //    rbtMemb.Location = new System.Drawing.Point(startX, 4);
            //    rbtMemb.Name = "rbtGwa";
            //    rbtMemb.Size = new System.Drawing.Size(78, INPUT_GUBUN_HEIGHT);
            //    rbtMemb.Text = "      診療科";
            //    rbtMemb.Tag = "GWA";
            //    rbtMemb.Click += new System.EventHandler(this.rbtMemb_Click);
            //    panMemb.Controls.Add(rbtMemb);
            //    startX = startX + 78;

            //    rbtMemb = new XRadioButton();
            //    rbtMemb.Appearance = System.Windows.Forms.Appearance.Button;
            //    rbtMemb.Cursor = System.Windows.Forms.Cursors.Hand;
            //    rbtMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            //    rbtMemb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //    rbtMemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    rbtMemb.ImageList = this.ImageList;
            //    rbtMemb.ImageIndex = 0;
            //    rbtMemb.Location = new System.Drawing.Point(startX, 4);
            //    rbtMemb.Name = "rbtDoctor";
            //    rbtMemb.Size = new System.Drawing.Size(78, INPUT_GUBUN_HEIGHT);
            //    rbtMemb.Text = "      医師";
            //    rbtMemb.Tag = "DOCTOR";
            //    rbtMemb.Click += new System.EventHandler(this.rbtMemb_Click);
            //    panMemb.Controls.Add(rbtMemb);
            //}

            if (dloMemb.RowCount > 0)
            {
                if (dloMemb.RowCount >= 3)
                {
                    //정형외과는 정형외과가 선택되도록 변경
                    //if (UserInfo.UserGubun == UserType.Doctor && UserInfo.Gwa == "06")
                    //    rbtMemb_Click(panMemb.Controls[dloMemb.RowCount - 1], null);
                    //else
                    //    rbtMemb_Click(panMemb.Controls[1], null);
                    //rbtMemb_Click(panMemb.Controls[dloMemb.RowCount - 1], null);

                    //this.rbtMemb_CheckedChanged(panMemb.Controls[dloMemb.RowCount - 1], new EventArgs());
                    //공통으로변경
                    ((XRadioButton)panMemb.Controls[2]).Checked = true;
                }
                else
                {
                    //this.rbtMemb_CheckedChanged(panMemb.Controls[dloMemb.RowCount - 1], new EventArgs());
                    ((XRadioButton)panMemb.Controls[0]).Checked = true;
                }
            }
        }

        private void ShowOCS0300()
        {
            tvwOCS0300.Nodes.Clear();
            if (grdOCS0301.RowCount < 1) return;

            string pk_seq = "";
            string pk_input_gubun = "";
            int rowNum = 0;
            int node1 = -1, node2 = -1, node3 = -1;
            TreeNode node;

            foreach (DataRow row in grdOCS0301.LayoutTable.Rows)
            {
                if (pk_input_gubun != row["input_tab_name"].ToString())
                {
                    node = new TreeNode(row["input_tab_name"].ToString());
                    //node.Tag = row["pk_seq"].ToString();
                    tvwOCS0300.Nodes.Add(node);
                    pk_input_gubun = row["input_tab_name"].ToString();
                    row["node1"] = -1;
                    row["node2"] = -1;
                    row["node3"] = -1;
                    node1 = node1 + 1;
                    node2 = -1;
                    node3 = -1;
                }


                if (pk_seq != row["pk_seq"].ToString())
                {
                    node = new TreeNode(row["yaksok_gubun_name"].ToString());
                    node.Tag = row["pk_seq"].ToString();
                    //tvwOCS0300.Nodes.Add(node);
                    tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes.Add(node);
                    pk_seq = row["pk_seq"].ToString();

                    node2 = node2 + 1;
                    node3 = -1;


                }

                node = new TreeNode(row["yaksok_name"].ToString());
                node.Tag = rowNum;

                if (row["select"].ToString() == "Y")
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                }
                else
                {
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                }

                tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes[tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes.Count - 1].Nodes.Add(node);
                node3 = node3 + 1;
                row["node1"] = node1;
                row["node2"] = node2;
                row["node3"] = node3;

                rowNum++;
            }

            //tvwOCS0300.Nodes.Clear();
            //if (grdOCS0301.RowCount < 1) return;

            //string pk_seq = "";
            //int rowNum = 0;
            //int node1 = -1, node2 = -1;
            //TreeNode node;

            //foreach (DataRow row in grdOCS0301.LayoutTable.Rows)
            //{
            //    if (pk_seq != row["pk_seq"].ToString())
            //    {
            //        node = new TreeNode(row["yaksok_gubun_name"].ToString());
            //        node.Tag = row["pk_seq"].ToString();
            //        tvwOCS0300.Nodes.Add(node);
            //        pk_seq = row["pk_seq"].ToString();

            //        row["node1"] = -1;
            //        row["node1"] = -1;
            //        node1 = node1 + 1;
            //        node2 = -1;
            //    }

            //    node = new TreeNode(row["yaksok_name"].ToString());
            //    node.Tag = rowNum;

            //    if (row["select"].ToString() == "Y")
            //    {
            //        node.ImageIndex = 1;
            //        node.SelectedImageIndex = 1;
            //    }
            //    else
            //    {
            //        node.ImageIndex = 0;
            //        node.SelectedImageIndex = 0;
            //    }

            //    tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes.Add(node);
            //    node2 = node2 + 1;
            //    row["node1"] = node1;
            //    row["node2"] = node2;

            //    rowNum++;
            //}

            foreach (TreeNode parentNode in this.tvwOCS0300.Nodes)
            {
                foreach (TreeNode childNode in parentNode.Nodes)
                {
                    if (childNode.ImageIndex == 1)
                    {
                        parentNode.Expand();
                        break;
                    }

                }
            }

        }

        private void CreateCombo()
        {
            DataTable dtTemp;

            //// DV_TIME
            //dtTemp = this.mOrderBiz.LoadComboDataSource("dv_time").LayoutTable;
            //this.grdOCS0303.SetComboItems("dv_time", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            //// 이동촬영여부
            //dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
            //this.grdOCS0303.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            ////급여여부
            //dtTemp = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
            //this.grdOCS0303.SetComboItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            // 주사스피드구분
            dtTemp = this.mOrderBiz.LoadComboDataSource("jusa_spd_gubun").LayoutTable;
            this.grdOCS0303.SetComboItems("jusa_spd_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);

            //CreateGwaCombo();

            // Cloud updated code START
            ComboResult dvTimeRes = CacheService.Instance.Get<ComboDvTimeArgs, ComboResult>(new ComboDvTimeArgs());
            if (null != dvTimeRes)
            {
                this.grdOCS0303.SetComboItems("dv_time", Utility.ConvertToDataTable(dvTimeRes.ComboItem), "code_name", "code", XComboSetType.NoAppend);
            }

            ComboResult portableYnRes = CacheService.Instance.Get<ComboPortableYnArgs, ComboResult>(new ComboPortableYnArgs());
            if (null != portableYnRes)
            {
                this.grdOCS0303.SetComboItems("portable_yn", Utility.ConvertToDataTable(portableYnRes.ComboItem), "code_name", "code", XComboSetType.NoAppend);
            }

            ComboResult payRes = CacheService.Instance.Get<ComboPayArgs, ComboResult>(new ComboPayArgs());
            if (null != payRes)
            {
                this.grdOCS0303.SetComboItems("pay", Utility.ConvertToDataTable(payRes.ComboItem), "code_name", "code", XComboSetType.NoAppend);
            }
            // Cloud updated code END
        }

        //private void lblSelectOrder_Click(object sender, System.EventArgs e)
        //{
        //    if (lblSelectOrder.ImageIndex == 0)
        //    {
        //        if (grdSelectAll(grdOCS0303, true))
        //        {
        //            lblSelectOrder.ImageIndex = 1;
        //            lblSelectOrder.Text = " 全体選択取消";
        //        }
        //    }
        //    else
        //    {
        //        if (grdSelectAll(grdOCS0303, false))
        //        {
        //            lblSelectOrder.ImageIndex = 0;
        //            lblSelectOrder.Text = " 全体選択";
        //        }
        //    }
        //}

        //private void lblSelectSang_Click(object sender, System.EventArgs e)
        //{
        //    if (lblSelectSang.ImageIndex == 0)
        //    {
        //        lblSelectSang.ImageIndex = 1;
        //        if (grdOCS0301.CurrentRowNumber >= 0)
        //            grdOCS0301.SetItemValue(grdOCS0301.CurrentRowNumber, "select_sang", "Y");

        //    }
        //    else
        //    {
        //        lblSelectSang.ImageIndex = 0;
        //        if (grdOCS0301.CurrentRowNumber >= 0)
        //            grdOCS0301.SetItemValue(grdOCS0301.CurrentRowNumber, "select_sang", "N");
        //    }

        //    //선택된 row 표시
        //    SetSelectYaksok();
        //}

        /// <summary>
        /// 해당 Grid 전체선택 해제
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="select"></param>
        //private bool grdSelectAll(XGrid grdObject, bool select)
        //{
        //    int rowIndex = -1;

        //    if (select)
        //    {
        //        for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
        //        {
        //            /*
        //            //의사인 경우 order 권한 Check한다.
        //            if (UserInfo.UserGubun == UserType.Doctor)
        //            {
        //                if (!this.mOrderBiz.CheckOrderAuthority(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), UserInfo.Gwa, UserInfo.UserID))
        //                {
        //                    mbxMsg = NetInfo.Language == LangMode.Jr ? "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】の入力権限がありません。確認してください。" : "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】오더에 대해서 입력권한이 없습니다. 확인바랍니다.";
        //                    mbxCap = NetInfo.Language == LangMode.Jr ? "入力権限" : "입력권한";
        //                    XMessageBox.Show(mbxMsg, mbxCap);
        //                    continue;
        //                }
        //            }

        //            //환자별 특수약제
        //            if (!TypeCheck.IsNull(mBunho) && this.mOrderBiz.CheckSpecialDrugForPatient(mBunho, grdObject.GetItemString(rowIndex, "hangmog_code"), grdObject.GetItemString(rowIndex, "hangmog_name")))
        //                continue;

        //            //자식일 경우
        //            string insertYN = string.Empty;
        //            if (this.mChildYN == "Y")
        //            {
        //                //자식입력여부로드
        //                if (this.mHangmogInfo.LoadChildInsertYN(grdObject.GetItemString(rowIndex, "hangmog_code"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref insertYN))
        //                {
        //                    if (insertYN != "Y") continue;
        //                }
        //            }
        //            else
        //            {
        //                //자식일 경우는 스킵
        //                if (grdObject.GetItemString(rowIndex, "child_gubun") != "3")
        //                {
        //                    //단독입력여부로드
        //                    if (this.mHangmogInfo.LoadDandokInsertYN(grdObject.GetItemString(rowIndex, "hangmog_code"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "%", grdObject.GetItemString(rowIndex, "order_gubun").Substring(1, 1), ref insertYN))
        //                    {
        //                        if (insertYN != "Y") continue;
        //                    }
        //                }
        //            }
        //             //*/

        //            if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y") grdObject.SetItemValue(rowIndex, "select", " ");
        //        }
        //    }
        //    else
        //    {
        //        for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
        //        {
        //            if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y") grdObject.SetItemValue(rowIndex, "select", "");
        //        }
        //    }

        //    SelectionBackColorChange(grdObject);

        //    //선택된 row 표시
        //    SetSelectYaksok();
        //    return true;

        //}

        private void MakeGroupTab(XEditGrid aGrid)
        {
            string currentGroupSer = "";
            string title = "";
            IHIS.X.Magic.Controls.TabPage tpgGroup;

            this.tabGroupSerial.SelectionChanged -= new EventHandler(tabGroupSerial_SelectionChanged);

            // 탭페이지 클리어
            try
            {
                this.tabGroupSerial.TabPages.Clear();
            }
            catch
            {
                this.tabGroupSerial.Refresh();
            }

            bool isSelected = false;
            for (int i = 0; i < aGrid.RowCount; i++)
            {
                isSelected = false;
                if (currentGroupSer != aGrid.GetItemString(i, "group_ser"))
                {
                    if (aGrid.GetItemString(i, "input_tab") == "01") // 약인경우는 그룹탭에 복용법을 같이 보여준다.
                    {
                        title = aGrid.GetItemString(i, "group_ser") + " グループ : " + aGrid.GetItemString(i, "bogyong_name");
                    }
                    else
                    {
                        title = aGrid.GetItemString(i, "group_ser") + " グループ";
                    }
                    if (aGrid.GetItemString(i, "select") == "Y")
                        isSelected = true;

                    tpgGroup = new IHIS.X.Magic.Controls.TabPage(title);
                    tpgGroup.ImageList = this.ImageList;
                    if (isSelected)
                        tpgGroup.ImageIndex = 1;
                    else
                        tpgGroup.ImageIndex = 0;

                    tpgGroup.Tag = aGrid.GetItemString(i, "group_ser");

                    this.tabGroupSerial.TabPages.Add(tpgGroup);

                    currentGroupSer = aGrid.GetItemString(i, "group_ser");
                }
            }

            this.tabGroupSerial.SelectionChanged += new EventHandler(tabGroupSerial_SelectionChanged);

            SetTabImage();

            this.tabGroupSerial_SelectionChanged(this.tabGroupSerial, new EventArgs());
        }

        //private void SetTabImage()
        //{
        //    string group_ser = "";

        //    for (int j = 0; j < this.tabGroupSerial.TabPages.Count; j++)
        //    {
        //        tabGroupSerial.TabPages[j].ImageIndex = 0;
        //    }
        //    for (int i = 0; i < this.grdOCS0303.RowCount; i++)
        //    {
        //        if (this.grdOCS0303.GetItemString(i, "select") == "Y")
        //        {
        //            group_ser = this.grdOCS0303.GetItemString(i, "group_ser");

        //            for (int j = 0; j < this.tabGroupSerial.TabPages.Count; j++)
        //            {
        //                if (group_ser == this.tabGroupSerial.TabPages[j].Tag.ToString())
        //                {
        //                    tabGroupSerial.TabPages[j].ImageIndex = 1;
        //                }
        //            }
        //        }
        //    }
        //}

        private void SetTabImage()
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroupSerial.TabPages)
            {
                if (this.IsExistSelectedOrder(tpg.Tag.ToString()) == true)
                {
                    tpg.ImageIndex = 1;
                }
                else
                {
                    tpg.ImageIndex = 0;
                }
            }
        }

        private bool IsExistSelectedOrder(string aGroupSer)
        {
            DataRow[] dr = this.dloSelectOCS0303.LayoutTable.Select("group_ser =" + aGroupSer);

            if (dr.Length > 0) return true;

            return false;
        }

        private void InsertBackTable(DataRow dr)
        {
            DataRow[] rows = this.dloSelectOCS0303.LayoutTable.Select("pkocs0303=" + dr["pkocs0303"].ToString());
            if (rows.Length < 1)
                this.dloSelectOCS0303.LayoutTable.ImportRow(dr);
        }

        private void RemoveBackTable(DataRow dr)
        {
            DataRow[] rows = this.dloSelectOCS0303.LayoutTable.Select("pkocs0303=" + dr["pkocs0303"].ToString());
            foreach (DataRow row in rows)
                this.dloSelectOCS0303.LayoutTable.Rows.Remove(row);
        }

        //private void DetailSelect(bool select)
        //{
        //    if (select)
        //    {
        //        // Detail 전체 Select
        //        // OCS0303
        //        for (int i = 0; i < grdOCS0303.RowCount; i++)
        //        {
        //            grdOCS0303.SetItemValue(i, "select", " ");
        //        }

        //        SelectionBackColorChange(grdOCS0303);
        //    }
        //    else
        //    {
        //        // Detail 전체 Select
        //        // OCS0303
        //        for (int i = 0; i < grdOCS0303.RowCount; i++)
        //        {
        //            grdOCS0303.SetItemValue(i, "select", "");
        //        }

        //        SelectionBackColorChange(grdOCS0303);
        //    }
        //}

        private void SetSelectYaksok()
        {
            int currentRow = grdOCS0301.CurrentRowNumber;
            bool select = false;

            //modify by jc
            //int node1 = -1, node2 = -1;
            int node1 = -1, node2 = -1, node3 = -1;

            if (grdOCS0301.CurrentRowNumber < 0) return;

            //if (grdOCS0301.CurrentRowNumber >= 0)
            //{
            //    //if (grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "select_sang") == "Y")
            //        select = true;
            //}

            // OCS1003
            if (!select)
            {
                for (int i = 0; i < grdOCS0303.RowCount; i++)
                {
                    if (grdOCS0303.GetItemString(i, "select") != "Y") continue;
                    select = true;
                    break;
                }
            }

            if (select)
            {
                grdOCS0301.SetItemValue(currentRow, "select", "Y");
                //SelectionBackColorChange(grdOCS0301, currentRow, "Y");

                //modify by jc
                //node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                //node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                //tvwOCS0300.Nodes[node1].Nodes[node2].ImageIndex = 1;
                //tvwOCS0300.Nodes[node1].Nodes[node2].SelectedImageIndex = 1;
                node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                node3 = int.Parse(grdOCS0301.GetItemString(currentRow, "node3"));
                tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3].ImageIndex = 1;
                tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3].SelectedImageIndex = 1;
            }
            else
            {
                grdOCS0301.SetItemValue(currentRow, "select", "N");
                //SelectionBackColorChange(grdOCS0301, currentRow, "N");

                //modify by jc
                //node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                //node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                //tvwOCS0300.Nodes[node1].Nodes[node2].ImageIndex = 0;
                //tvwOCS0300.Nodes[node1].Nodes[node2].SelectedImageIndex = 0;
                node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                node3 = int.Parse(grdOCS0301.GetItemString(currentRow, "node3"));
                tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3].ImageIndex = 0;
                tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3].SelectedImageIndex = 0;
            }
        }

        private void CreateReturnLayout(string aInputGubun)
        {
            if ((this.mInput_gubun == "CK" && !this.mOrderBiz.getEnablePostApprove(this.mIOgubun, this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString()))
                || this.mIOgubun == "O"
                || ((XScreen)Opener).ScreenID != "OCS2003P01")
                aInputGubun = this.mInput_gubun;

            grdOCS0301.ClearFilter();

            this.AcceptData();
            //if (dloSelectOCS0303.LayoutTable.Rows.Count < 1)
            //{
            //    mbxMsg = Resources.MSG005_MSG;
            //    mbxCap = Resources.MSG004_MSG;
            //    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
            //    return;
            //}

            // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
            DataRow row;

            for (int i = 0; i < dloSelectOCS0303.RowCount; i++)
            {
                row = dloSelectOCS0303.LayoutTable.Rows[i];

                if (row["general_disp_yn"].ToString().Trim() == "Y")
                {
                    row["hangmog_name"] = row["generic_name"].ToString().Trim();
                }
            }
            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("OCS0303", dloSelectOCS0303);
            commandParams.Add("input_gubun", aInputGubun);
            scrOpener.Command("OCS0301Q09", commandParams);

            this.Close();
        }

        //날수 및 기타 기본정보변경
        private void CreateReturnLayout()
        {
            grdOCS0301.ClearFilter();

            this.AcceptData();

            //현재선택된 row trans
            //OCS0301
            //for (int i = 0; i < grdOCS0301.RowCount; i++)
            //{
            //    if (grdOCS0301.GetItemString(i, "select_sang") == "Y" && !TypeCheck.IsNull(grdOCS0301.GetItemString(i, "sang_code")))
            //        dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
            //}

            // 상병이 선택된 경우만 넘긴다
            //for (int i = 0; i < dloSelectOCS0301.RowCount; i++)
            //{
            //    if (dloSelectOCS0301.GetItemString(i, "select_sang") != "Y")
            //    {
            //        dloSelectOCS0301.DeleteRow(i);
            //        i--;
            //    }
            //}

            //OCS0303
            //for (int i = 0; i < grdOCS0303.RowCount; i++)
            //{
            //    if (grdOCS0303.GetItemString(i, "select") == "Y")
            //        dloSelectOCS0303.LayoutTable.ImportRow(grdOCS0303.LayoutTable.Rows[i]);
            //}

            //string pk_yaksok = "";
            //int base_Nalsu = 0;
            //DataRow[] tempRow = null;

            //foreach (DataRow row in dloSelectOCS0303.LayoutTable.Rows)
            //{
            //    //order 단위가 현재 존재하지 않는 경우
            //    //                if(dloOrder_danui.LayoutTable.Select(" code = '" + row["ord_danui"].ToString() + "' ", "").Length < 1)
            //    //                    row["ord_danui"] = row["ord_danui_check"];

            //    pk_yaksok = row["pk_yaksok"].ToString();

            //    tempRow = dloSelectOCS0301.LayoutTable.Select(" pk_yaksok = '" + pk_yaksok + "' ", "");
            //    if (tempRow.Length < 1 || !TypeCheck.IsInt(tempRow[0]["nalsu"].ToString()) || tempRow[0]["nalsu"].ToString() == "0")
            //        base_Nalsu = int.Parse(row["nalsu"].ToString() == "" ? "0" : row["nalsu"].ToString());
            //    else
            //        base_Nalsu = int.Parse(tempRow[0]["nalsu"].ToString());

            //    if (base_Nalsu <= 0) continue;

            //    //내복약,외용약
            //    if (row["order_gubun_bas"].ToString() == "C" || row["order_gubun_bas"].ToString() == "D")
            //    {
            //        row["nalsu"] = base_Nalsu;
            //    }

            //}

            //if (dloSelectOCS0301.LayoutTable.Rows.Count < 1 && dloSelectOCS0303.LayoutTable.Rows.Count < 1)
            if (dloSelectOCS0303.LayoutTable.Rows.Count < 1)
            {
                mbxMsg = Resources.MSG005_MSG;
                mbxCap = Resources.MSG004_MSG;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
            DataRow row;

            for (int i = 0; i < dloSelectOCS0303.RowCount; i++)
            {
                row = dloSelectOCS0303.LayoutTable.Rows[i];

                if (row["general_disp_yn"].ToString().Trim() == "Y")
                {
                    row["hangmog_name"] = row["generic_name"].ToString().Trim();
                }
            }
            //if (chkIsNewGroup.Checked)
            //    mIsNewGroupSer = true;
            //else
            //    mIsNewGroupSer = false;

            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            //commandParams.Add("OCS0301", dloSelectOCS0301);
            //commandParams.Add("isnewgroup", mIsNewGroupSer);
            commandParams.Add("OCS0303", dloSelectOCS0303);
            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }

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
                            if (aGrd.GetItemValue(i, "order_gubun").ToString().Trim() == aGrd.GetItemValue(j, "order_gubun").ToString().Trim() &&
                                aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim())
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
                        if (count > 1) imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }

        private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            if (currentRowIndex < 0) return;

            //선택된 Row에대해서 색을 변경한다
            //data   Y :색을 변경, N :색을 변경 해제
            //image 설정
            if (data == "Y")
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
            }
            else
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
            }

            for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            {
                if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                {
                    // 돈복여부
                    if (grdObject.GetItemString(currentRowIndex, "donbog_yn") == "Y")
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                        continue;
                    }

                    // 불균등분할
                    if (!TypeCheck.IsNull(grdObject.GetItemString(currentRowIndex, "dv_name")))
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                        continue;
                    }
                }

                if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "select")
                {
                    if (data == "Y")
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                    }
                    else
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                    }
                }
                else
                {

                }
            }

            //child 이미지 세팅
            ChildSetImage();
        }

        private void SelectionBackColorChange(object grid)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            //기존의 색으로 변경을 시킨다
            for (int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "select").ToString() == "Y")
                {
                    //image 변경
                    if (grdObject.RowHeaderVisible)
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                    else
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];

                    //ColorYn Y :색을 변경, N :색을 변경 해제
                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                        {
                            // 돈복여부
                            if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                continue;
                            }

                            // 불균등분할
                            if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                continue;
                            }
                        }
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "select")
                        {
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                        }
                    }
                }
                else
                {
                    //image 변경
                    if (grdObject.RowHeaderVisible)
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                    else
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                        {
                            // 돈복여부
                            if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                continue;
                            }

                            // 불균등분할
                            if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                continue;
                            }
                        }

                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "select")
                        {
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                        }
                    }
                }
            }

            if (grdObject.Name == "grdOCS0303") DiaplayMixGroup(grdObject);


            //child 이미지 세팅
            ChildSetImage();
        }

        private bool SetOrderCopy()
        {
            ArrayList inputList = new ArrayList();
            inputList.Add(dloSetOrderCopy.GetItemString(0, "source_memb"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "source_yaksok_code"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "target_memb"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "yaksok_code"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "yaksok_name"));
            ArrayList outputList = new ArrayList();

            if (!Service.ExecuteProcedure("PR_OCS_COPY_SET_ORDER", inputList, outputList))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return false;
            }
            return true;
        }

        private bool CheckExistsYasokCode(string aYasok_code)
        {
            ////중복check
            //string cmdText = "";
            //object retVal = null;
            //cmdText = " SELECT YAKSOK_NAME "
            //        + "   FROM OCS0301 "
            //        + "  WHERE MEMB = '" + UserInfo.YaksokOpenID + "' "
            //        + "    AND YAKSOK_CODE = '" + aYasok_code + "' "
            //        + "    AND HOSP_CODE   = '" + mHospCode + "' ";

            //retVal = Service.ExecuteScalar(cmdText);

            //if (!TypeCheck.IsNull(retVal))
            //    return false;
            //else
            //    return true;

            // Cloud updated code START
            OCS0301Q09CheckExistsYasokCodeArgs args = new OCS0301Q09CheckExistsYasokCodeArgs();
            args.YaksokOpenId = UserInfo.YaksokOpenID;
            args.YasokCode = aYasok_code;
            OCS0301Q09CheckExistsYasokCodeResult res = CloudService.Instance.Submit<OCS0301Q09CheckExistsYasokCodeResult,
                OCS0301Q09CheckExistsYasokCodeArgs>(args);

            return !(null != res && !string.IsNullOrEmpty(res.Result));
            // Cloud updated code END
        }

        private void ChildSetImage()
        {
            for (int i = 0; i < this.grdOCS0303.RowCount; i++)
            {
                this.grdOCS0303[i, "child_gubun"].ForeColor = new XColor(System.Drawing.Color.Transparent);
                switch (this.grdOCS0303.GetItemString(i, "child_gubun"))
                {
                    case "1": //자식있음
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[6];
                        break;
                    case "2": //자식없음
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[7];
                        break;
                    case "3": //자식
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[8];
                        break;
                    default:
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[7];
                        break;
                }
                this.grdOCS0303[i, "child_gubun"].ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            }
        }

        private void SelectRow(string groupSerial)
        {
            if (groupSerial == "%")
            {
                for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                {
                    if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                        continue;

                    this.grdOCS0303.SetItemValue(i, "select", "Y");
                    SelectionBackColorChange(grdOCS0303, i, "Y");
                    this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                }
            }
            else
            {
                for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                {
                    if (this.grdOCS0303.GetItemString(i, "group_ser") == groupSerial)
                    {
                        if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                            continue;

                        this.grdOCS0303.SetItemValue(i, "select", "Y");
                        SelectionBackColorChange(grdOCS0303, i, "Y");
                        this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                    }
                }
            }

            SetSelectYaksok();
            SetTabImage();
        }

        private void DeleteRow(string groupSerial)
        {
            if (groupSerial == "%")
            {
                for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                {
                    if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                        continue;

                    this.grdOCS0303.SetItemValue(i, "select", "N");
                    SelectionBackColorChange(grdOCS0303, i, "N");
                    this.RemoveBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                }
            }
            else
            {
                //for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                //{
                //    if (this.grdOCS0303.GetItemString(i, "group_ser") == groupSerial)
                //    {
                //        if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                //            continue;

                //        this.grdOCS0303.SetItemValue(i, "select", "Y");
                //        SelectionBackColorChange(grdOCS0303, i, "Y");
                //        this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                //    }
                //}
            }

            SetSelectYaksok();
            SetTabImage();
        }

        #endregion

        #region Cloud updated code (2015.04.08)

        #region InitControlsToConnectCloud
        /// <summary>
        /// InitControlsToConnectCloud
        /// </summary>
        public void InitControlsToConnectCloud(string _sangcode)
        {
            sangCode = _sangcode;
            // grdOCS0301
            grdOCS0301.ParamList = new List<string>(new string[] { "f_memb", "f_yaksok_code", "f_input_tab", });
            grdOCS0301.ExecuteQuery = GetGrdOCS0301;

            // grdOCS0303
            grdOCS0303.ParamList = new List<string>(new string[]
                {
                    "f_generic_yn",
                    "f_memb",
                    "f_fkocs0300_seq",
                    "f_yaksok_code",
                    "f_protocol_id"
                });
            grdOCS0303.ExecuteQuery = GetGrdOCS0303;
            OnLoad();
        }
        #endregion

        #region GetGrdOCS0301
        /// <summary>
        /// GetGrdOCS0301
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOCS0301(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OUTSANGU00GrdOCS0301Args args = new OUTSANGU00GrdOCS0301Args();

            args.Memb = bvc["f_memb"].VarValue;
            args.SangCode = sangCode;
            args.YaksokCode = bvc["f_yaksok_code"].VarValue;
            args.InputTab = bvc["f_input_tab"].VarValue;
            OUTSANGU00GrdOCS0301Result res = CloudService.Instance.Submit<OUTSANGU00GrdOCS0301Result,
                OUTSANGU00GrdOCS0301Args>(args);

            if (null != res)
            {
                foreach (OUTSANGU00GrdOCS0301Info item in res.ListInfo)
                {
                    lObj.Add(new object[]
                    {
                        item.Memb,
                        item.PkSeq,
                        item.YaksokGubun,
                        item.YaksokGubunName,
                        item.YaksokCode,
                        item.YaksokName,
                        item.InputTab,
                        item.PkYaksok,
                        item.InputTabName,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdOCS0303
        /// <summary>
        /// GetGrdOCS0303
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOCS0303(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0301Q09GrdOCS0303Args args = new OCS0301Q09GrdOCS0303Args();
            args.Fkocs0300Seq = bvc["f_fkocs0300_seq"].VarValue;
            args.GenericYn = bvc["f_generic_yn"].VarValue;
            args.Memb = bvc["f_memb"].VarValue;
            args.YaksokCode = bvc["f_yaksok_code"].VarValue;
            args.ProtocolId = protocolID;
            OCS0301Q09GrdOCS0303Result res = CloudService.Instance.Submit<OCS0301Q09GrdOCS0303Result,
                OCS0301Q09GrdOCS0303Args>(args);

            if (null != res)
            {
                foreach (OCS0301Q09GrdOCS0303Info item in res.GrdOcs0303Item)
                {
                    lObj.Add(new object[]
                    {
                        item.TrialFlag,
                        item.Memb,
                        item.YaksokCode,
                        item.PkYaksok,
                        item.Pkocs0303,
                        item.GroupSer,
                        item.MixGroup,
                        item.Seq,
                        item.OrderGubun,
                        item.OrderGubunName,
                        item.InputTab,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.Suryang,
                        item.OrdDanui,
                        item.OrdDanuiName,
                        item.DvTime,
                        item.Dv,
                        item.Dv1,
                        item.Dv2,
                        item.Dv3,
                        item.Dv4,
                        item.Nalsu,
                        item.Jusa,
                        item.JusaName,
                        item.BogyongCode,
                        item.BogyongName,
                        item.JusaSpdGubun,
                        item.HubalChangeYn,
                        item.Pharmacy,
                        item.DrgPackYn,
                        item.Emergency,
                        item.Pay,
                        item.PortableYn,
                        item.PowderYn,
                        item.Muhyo,
                        item.PrnYn,
                        item.OrderRemark,
                        item.NurseRemark,
                        item.BulyongCheck,
                        item.SlipCode,
                        item.GroupYn,
                        item.OrderGubunBas,
                        item.InputControl,
                        item.SgCode,
                        item.SugaYn,
                        item.EmergencyCheck,
                        item.LimitSuryang,
                        item.SpecimenYn,
                        item.JaeryoYn,
                        item.OrdDanuiCheck,
                        item.WonyoiOrderYn,
                        item.DangilGumsaOrderYn,
                        item.DangilGumsaResultYn,
                        item.WonyoiOrderCrYn,
                        item.NdayYn,
                        item.MuhyoYn,
                        item.PayName,
                        item.BunCode,
                        item.DataControl,
                        item.DonbokYn,
                        item.DvName,
                        item.DrgInfo,
                        item.DrgBunryu,
                        item.ChildGubun,
                        item.BomSourceKey,
                        item.HaengweeYn,
                        item.OrgKey,
                        item.ParentKey,
                        item.Fkocs0300Seq,
                        item.ChildYn,
                        item.JundalTableOut,
                        item.JundalPartOut,
                        item.JundalTableInp,
                        item.JundalPartInp,
                        item.MovePartOut,
                        item.MovePartInp,
                        item.JundalPartOutName,
                        item.JundalPartInpName,
                        item.WonnaeDrgYn,
                        item.Dv5,
                        item.Dv6,
                        item.Dv7,
                        item.Dv8,
                        item.GeneralDispYn,
                        item.GenericName,
                        item.N,
                        item.YjCode
                    });
                }
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}

