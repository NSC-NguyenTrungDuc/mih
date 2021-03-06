using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.OCSA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.OCSA
{
    public partial class OCS0103U00 : XScreen
    {
        #region Fields
        private string common_order_state = "";
        private string mMsg = "";
        private string mCap = "";
        private string hosp_code = "";
        private string JundalTableOut = "";
        private OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz();
        private string mHospCode = UserInfo.HospCode;
        private OCS0103U00LoadAllComboResult _comboResult;        
        #endregion

        #region Constructor
        /// <summary>
        /// OCS0103U00
        /// </summary>
        public OCS0103U00()
        {
            		

            this.InitializeComponent();
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                mHospCode = this.xHospBox1.HospCode;
                btnUpdateMst.Visible = false;                   
            }
            else
            {
                xHospBox1.Visible = false;
                mHospCode = UserInfo.HospCode;
                btnUpdateMst.Visible = true;
                btnUpdateMst.Location = new Point(1082, 0);
                btnOpenHOTCODEMst.Location = new Point(959, 30);
            }

            // updated by Cloud
            InitializeCloud();
        }
        #endregion

        #region Events

        private void OCS0103U10_Load(object sender, EventArgs e)
        {

            // 저장용 세이브 퍼포머 지정
            //this.grdOCS0108.SavePerformer = new XSavePeformer(this);
            //this.grdOCS0113.SavePerformer = new XSavePeformer(this);
            //this.grdOCS0115.SavePerformer = new XSavePeformer(this);
            //this.grdOCS0103.SavePerformer = new XSavePeformer(this);

            this.LoadAllCombos();

            layDanui.QueryLayout(true);
            grdOCS0108.SetComboItems("ord_danui", layDanui.LayoutTable, "code_name", "code");

            this.InitScreen();
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {

            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    //オーダ検索の文字が入っていたら大文字に変更して検索条件にする。

                    this.DataLoadOCS0103(this.cboQrySlipGubun.GetDataValue(), this.fbxQrySlipCode.GetDataValue(), this.txtQryHangmogINX.GetDataValue());
                    //this.DataLoadOCS0103(this.cboQrySlipGubun.GetDataValue(), this.fbxQrySlipCode.GetDataValue(), this.txtQryHangmogINX.GetDataValue());

                    this.grdOCS0103.Focus();                    
                    //cbxCommonOrder.Enabled = false;
                    //＊　画面を開いてすぐに入力・行削除ボタンを押したときにgrdOCS0103に対して操作をするためにフォーカスを当てる。

                    break;

                case FunctionType.Insert:
                    
                    e.IsBaseCall = false;

                    //SetCommonOrder();
                    //オーダマスタなしで換算基準・伝達部署・検体コードに入力行を表示しない
                    if (this.CurrMQLayout != this.grdOCS0103 & this.grdOCS0103.RowCount == 0)
                    {
                        return;
                    }

                    if (this.CurrMQLayout == this.grdOCS0103) // 항목 마스터
                    {
                        this.Insert_OCS0103(this.grdOCS0103.CurrentRowNumber);
                    }
                    else if (this.CurrMQLayout == this.grdOCS0108)  // 환산수량
                    {
                        this.Insert_OCS0108(this.grdOCS0108.CurrentRowNumber);
                    }
                    else if (this.CurrMQLayout == this.grdOCS0115)  // 진료과별 전달파트 
                    {
                        this.Insert_OCS0115(this.grdOCS0115.CurrentRowNumber);
                    }
                    else if (this.CurrMQLayout == this.grdOCS0113)  // 항목별 검체코드 관리
                    {
                        this.Insert_OCS0113(this.grdOCS0113.CurrentRowNumber);
                    }

                    break;

                case FunctionType.Update:

                    if (this.UpdateCheck() == false)
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        return;
                    }

                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                        #region deleted by Cloud
                        //Service.BeginTransaction();

                        //// 오더별 전달 테이블 관리
                        //if (this.IsExistModifiedData(this.grdOCS0115))
                        //{

                        //    if (this.grdOCS0115.SaveLayout() == false)
                        //    {
                        //        this.mMsg = Resources.MSG018_MSG + Service.ErrFullMsg;
                        //        this.mCap = Resources.MSG018_CAP;

                        //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //        throw new Exception();
                        //    }
                        //    this.DataLoadOCS0115(this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"), this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));
                        //    //this.DataLoadOCS0115(this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code")); UPD SHIMO
                        //}
                        //// 오더별 사용 검체 관리
                        //if (this.IsExistModifiedData(this.grdOCS0113))
                        //{
                        //    if (this.grdOCS0113.SaveLayout() == false)
                        //    {
                        //        this.mMsg = Resources.MSG019_MSG + Service.ErrFullMsg;
                        //        this.mCap = Resources.MSG018_CAP;

                        //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //        throw new Exception();
                        //    }
                        //    this.DataLoadOCS0113(this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"), this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));
                        //    //this.DataLoadOCS0113(this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"));UPD SHIMO
                        //}
                        //// 오더별 환산수량
                        //if (this.IsExistModifiedData(this.grdOCS0108))
                        //{
                        //    if (this.grdOCS0108.SaveLayout() == false)
                        //    {
                        //        this.mMsg = Resources.MSG020_MSG + Service.ErrFullMsg;
                        //        this.mCap = Resources.MSG018_CAP;

                        //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //        throw new Exception();
                        //    }

                        //    this.DataLoadOCS0108(this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"), this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));
                        //    //this.DataLoadOCS0108(this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"));UPD SHIMO
                        //}

                        //// 오더마스터
                        //if (this.grdOCS0103.SaveLayout() == false)
                        //{
                        //    this.mMsg = Resources.MSG021_MSG + Service.ErrFullMsg;
                        //    this.mCap = Resources.MSG018_CAP;

                        //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    throw new Exception();
                        //}

                        //Service.CommitTransaction();
                        //XMessageBox.Show(Resources.MSG022_MSG, Resources.MSG022_CAP, MessageBoxIcon.Information);
                        //btnList.PerformClick(FunctionType.Query);
                        #endregion

                        // Updated by Cloud
                        e.IsBaseCall = false;

                        OCS0103U00SaveLayoutArgs args = new OCS0103U00SaveLayoutArgs();
                        args.GrdOcs0103Item = GetGrdOCS0103ForSaveLayout();
                        args.GrdOcs0108Item = GetGrdOCS0108ForSaveLayout();
                        args.GrdOcs0113Item = GetGrdOCS0113ForSaveLayout();
                        args.GrdOcs0115Item = GetGrdOCS0115ForSaveLayout();
                        args.HospCode = mHospCode;

                        // No change?
                        if (args.GrdOcs0103Item.Count == 0
                            && args.GrdOcs0108Item.Count == 0
                            && args.GrdOcs0113Item.Count == 0
                            && args.GrdOcs0115Item.Count == 0)
                        {
                            //Modified due to MED-3972
                            XMessageBox.Show(Resources.MSG022_MSG, Resources.MSG022_CAP, MessageBoxIcon.Information);                            
                            return;
                        }

                        //MED-10625 and MED-11079
                        if (!CheckValidCommonYn(args.GrdOcs0103Item))
                        {
                            XMessageBox.Show(Resources.MSG054_MSG, Resources.MSG054_CAP, MessageBoxIcon.Error);
                            return;
                        }

                        if (args.GrdOcs0103Item.Count > 0)
                        {
                            foreach (OCS0103U00GrdOCS0103Info item in args.GrdOcs0103Item)
                            {
                                if ((item.RowState==DataRowState.Added.ToString() || item.RowState == DataRowState.Modified.ToString()) 
                                    && item.Trial == "Y" && (item.Protocol == "" || item.Protocol == null))
                                {
                                    XMessageBox.Show(Resources.MSG050_MSG, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                        args.UserId = UserInfo.UserID;
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS0103U00SaveLayoutArgs>(args);

                       
                        string msg = string.Empty;
                        string cap = string.Empty;
                        switch (res.Msg)
                        {
                            case "1":
                                msg = Resources.MSG035_MSG;
                                cap = Resources.MSG035_CAP;
                                XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            case "2":
                                msg = Resources.MSG036_MSG;
                                cap = Resources.MSG035_CAP;
                                XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            case "3":
                                msg = Resources.MSG037_MSG;
                                cap = Resources.MSG035_CAP;
                                XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            case "4":
                                msg = Resources.MSG038_MSG;
                                cap = Resources.MSG035_CAP;
                                XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            case "unmap":
                                msg = Resources.MSG053_MSG;
                                cap = Resources.Cap053_CAP;
                                XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            //case "ERR_1": // Error when update grdOCS0103
                            //    this.mMsg = Resources.MSG021_MSG + Service.ErrFullMsg;
                            //    this.mCap = Resources.MSG018_CAP;
                            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    throw new Exception();
                            //case "ERR_2": // Error when update grdOCS0108
                            //    this.mMsg = Resources.MSG020_MSG + Service.ErrFullMsg;
                            //    this.mCap = Resources.MSG018_CAP;
                            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    throw new Exception();
                            //case "ERR_3": // Error when update grdOCS0115
                            //    this.mMsg = Resources.MSG018_MSG + Service.ErrFullMsg;
                            //    this.mCap = Resources.MSG018_CAP;
                            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    throw new Exception();
                            //case "ERR_4": // Error when update grdOCS0113
                            //    this.mMsg = Resources.MSG019_MSG + Service.ErrFullMsg;
                            //    this.mCap = Resources.MSG018_CAP;
                            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    throw new Exception();
                            default:
                                break;
                        }

                        if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                        {
                            // Reload data
                            this.DataLoadOCS0115(this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"), this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));
                            this.DataLoadOCS0113(this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"), this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));
                            this.DataLoadOCS0108(this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"), this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));

                            XMessageBox.Show(Resources.MSG022_MSG, Resources.MSG022_CAP, MessageBoxIcon.Information);
                            btnList.PerformClick(FunctionType.Query);
                        }
                        else
                        {
                            this.mMsg = Resources.MSG049_MSG;
                            this.mCap = Resources.MSG018_CAP;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }

                    break;

                case FunctionType.Delete:

                    #region 関連マスタがグリッドに残っている場合はオーダマスタは削除できない。

                    if (this.CurrMQLayout == this.grdOCS0103)
                    {
                        e.IsBaseCall = false;

                        //換算基準が登録されてないかチェック
                        if (this.grdOCS0108.RowCount > 0)
                        {
                            XMessageBox.Show(Resources.MSG023_MSG, Resources.MSG023_CAP, MessageBoxIcon.Warning);
                            return;
                        }

                        //オーダ伝達部署が登録されていないかチェック
                        if (this.grdOCS0115.RowCount > 0)
                        {
                            XMessageBox.Show(Resources.MSG024_MSG, Resources.MSG023_CAP, MessageBoxIcon.Warning);

                            return;
                        }

                        // オーダ別検体情報が登録されていないかチェック
                        if (this.grdOCS0113.RowCount > 0)
                        {
                            XMessageBox.Show(Resources.MSG025_MSG, Resources.MSG023_CAP, MessageBoxIcon.Warning);

                            return;
                        }

                        e.IsBaseCall = true;
                    }
                    #endregion

                    break;
            }
        }

        //MED-10625 and MED-11079
        /**
         * Does not allow departments change Common order settings except CPL, XRT, OP, PFE 
         * */
        private bool CheckValidCommonYn(List<OCS0103U00GrdOCS0103Info> inputList)
        {
            try
            {
                List<DataStringListItemInfo> hangmogList = new List<DataStringListItemInfo>();
                foreach (OCS0103U00GrdOCS0103Info info in inputList)
                {
                    DataStringListItemInfo hangmogCode = new DataStringListItemInfo();
                    hangmogCode.DataValue = info.HangmogCode;
                    hangmogList.Add(hangmogCode);
                }
                OCS0103U00GetCommonYnArgs args = new OCS0103U00GetCommonYnArgs();
                args.HangmogList = hangmogList;
                OCS0103U00GetCommonYnResult result = CloudService.Instance.Submit<OCS0103U00GetCommonYnResult, OCS0103U00GetCommonYnArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (inputList.Count == result.CommonYnList.Count)
                    {
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            string jundalTable = inputList[i].JundalTableOut;
                            if (!(jundalTable == "CPL" || jundalTable == "XRT" || jundalTable == "OP" || jundalTable == "PFE"))
                            {
                                //if (inputList[i].CommonOrder != result.CommonYnList[i].DataValue)
                                //{
                                //    return false;
                                //}
                                switch (result.CommonYnList[i].DataValue)
                                {
                                    case "Y":
                                        if (inputList[i].CommonOrder != result.CommonYnList[i].DataValue)
                                        {
                                            return false;
                                        }
                                        break;
                                    case "N":
                                    case "":
                                        if (inputList[i].CommonOrder == "Y")
                                        {
                                            return false;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Service.WriteLog("CheckValidCommonYn get exception: " + ex.Message);
                Service.WriteLog("CheckValidCommonYn stack trace: " + ex.StackTrace);
                return true;
            }
        }

        private void grdOCS0103_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            
            if (e.CurrentRow < 0)
            {
                this.ClearInputControl();
            }
            else
            {
                // 환산수량 로드
                this.DataLoadOCS0108(this.grdOCS0103.GetItemString(e.CurrentRow, "hangmog_code"), this.grdOCS0103.GetItemString(e.CurrentRow, "start_date"));
                //this.DataLoadOCS0108(this.grdOCS0103.GetItemString(e.CurrentRow, "hangmog_code"), UPD SHIMO

                // 전달파트
                this.DataLoadOCS0115(this.grdOCS0103.GetItemString(e.CurrentRow, "hangmog_code"), this.grdOCS0103.GetItemString(e.CurrentRow, "start_date"));
                //this.DataLoadOCS0115(this.grdOCS0103.GetItemString(e.CurrentRow, "hangmog_code") UPD SHIMO

                // 항목코드별 검체코드
                this.DataLoadOCS0113(this.grdOCS0103.GetItemString(e.CurrentRow, "hangmog_code"), this.grdOCS0103.GetItemString(e.CurrentRow, "start_date"));
                JundalTableOut = this.grdOCS0103.GetItemString(e.CurrentRow, "jundal_table_out");
                //this.DataLoadOCS0113(this.grdOCS0103.GetItemString(e.CurrentRow, "hangmog_code") UPD SHIMO
            }
            this.ProtectInputControl(e.CurrentRow);
            //cbxCommonOrder.Enabled = false;
           // SetCommonOrder();
            common_order_state = grdOCS0103.GetItemString(e.CurrentRow, "common_order");            
        }

        private void grdOCS0108_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {

        }

        private void XEditGrid_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.SetFindWorker(true, grid.Name, e.ColName);
        }

        private void XEditGrid_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            //string cmd = "";
            string name = "";
            string nameColumn = "";
            bool isQueryCloud = false;

            switch (grid.Name)
            {
                #region grdOCS0115
                case "grdOCS0115": // 진료과별 전달테이블 

                    if (e.ColName == "input_part")
                    {
                        #region INPUT PART ( 진료과 )

                        if (e.ChangeValue.ToString() == "*")
                        {
                            grid.SetItemValue(e.RowNumber, "gwa_name", Resources.MSG026_MSG);
                            this.SetMsg("");

                            return;
                        }

                        if (e.ChangeValue.ToString() == "")
                        {
                            grid.SetItemValue(e.RowNumber, "gwa_name", "");
                            this.SetMsg("");

                            return;
                        }

                        // updated by Cloud
                        //cmd = " SELECT A.GWA_NAME " +
                        //      "   FROM BAS0260 A" +
                        //      "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                        //      "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //      "    AND A.GWA = '" + e.ChangeValue.ToString() + "' " +
                        //      "    AND NVL(A.OUT_JUBSU_YN, 'N') = 'Y'   " +
                        //      "  ORDER BY A.GWA ";
                        isQueryCloud = true;

                        nameColumn = "gwa_name";

                        #endregion
                    }
                    else if (e.ColName == "jundal_part_out")
                    {
                        #region 전달파트 외래

                        if (e.ChangeValue.ToString() == "")
                        {
                            grid.SetItemValue(e.RowNumber, "gwa_name_out", "");
                            this.SetMsg("");

                            return;
                        }

                        //cmd = " SELECT A.GWA_NAME " +
                        //    "   FROM BAS0260 A," +
                        //    "　　　  OCS0128 B " +
                        //    "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                        //    "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //    "    AND A.GWA = '" + e.ChangeValue.ToString() + "' " +
                        //    "    AND A.OUT_JUNDAL_PART_YN = 'Y'   " +
                        //    "    AND B.HOSP_CODE = A.HOSP_CODE " +
                        //    "    AND B.IO_GUBUN = 'O' " +
                        //    "    AND B.JUNDAL_PART = A.GWA " +
                        //    "  ORDER BY A.GWA ";

                        //cmd = " SELECT A.GWA_NAME " +
                        //      "   FROM BAS0260 A " +
                        //      "  WHERE A.GWA = '" + e.ChangeValue.ToString() + "' " +
                        //      "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //      "    AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "' ";

                        isQueryCloud = true;
                        nameColumn = "gwa_name_out";

                        #endregion
                    }
                    else if (e.ColName == "jundal_part_inp")
                    {
                        #region 전달파트 입원

                        if (e.ChangeValue.ToString() == "")
                        {
                            grid.SetItemValue(e.RowNumber, "gwa_name_inp", "");
                            this.SetMsg("");

                            return;
                        }

                        //cmd = " SELECT A.GWA_NAME " +
                        //      "   FROM BAS0260 A " +
                        //      "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                        //      "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //      "    AND A.GWA = '" + e.ChangeValue.ToString() + "' ";

                        isQueryCloud = true;
                        nameColumn = "gwa_name_inp";

                        #endregion
                    }
                    else if (e.ColName == "move_part")
                    {
                        #region 이동부서

                        if (e.ChangeValue.ToString() == "")
                        {
                            grid.SetItemValue(e.RowNumber, "move_part_name", "");
                            this.SetMsg("");

                            return;
                        }

                        //cmd = " SELECT A.GWA_NAME " +
                        //      "   FROM BAS0260 A " +
                        //      "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                        //      "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //      "    AND A.GWA = '" + e.ChangeValue.ToString() + "' ";

                        isQueryCloud = true;
                        nameColumn = "move_part_name";

                        #endregion
                    }

                    break;
                #endregion

                #region grdOCS0113
                case "grdOCS0113": // 오더코드별 검체코드 관리

                    if (e.ColName == "specimen_code")
                    {
                        if (e.ChangeValue.ToString() == "")
                        {
                            grid.SetItemValue(e.RowNumber, "specimen_name", "");
                            this.SetMsg("");

                            return;
                        }

                        //cmd = " SELECT A.SPECIMEN_NAME " +
                        //      "   FROM OCS0116 A " +
                        //      "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                        //      "    AND A.SPECIMEN_CODE = '" + e.ChangeValue.ToString() + "' ";

                        isQueryCloud = true;
                        nameColumn = "specimen_name";
                    }

                    break;
                #endregion

                #region grdOCS0108
                case "grdOCS0108":

                    if (e.ColName == "ord_danui")
                    {

                        DataRow[] dr = layDanui.LayoutTable.Select("code = '" + e.ChangeValue + "'");
                        if (this.dbxSunabDanuiName.Text != null)
                        {
                            grdOCS0108.SetItemValue(e.RowNumber, "change_danui1", dr[0]["code_name"].ToString() + "/" + this.dbxSunabDanuiName.Text);
                        }
                        if (this.dbxSubulDanuiName.Text != null)
                        {
                            grdOCS0108.SetItemValue(e.RowNumber, "change_danui2", dr[0]["code_name"].ToString() + "/" + this.dbxSubulDanuiName.Text);
                        }
                    }
                    if (e.ColName == "change_qty1" && grdOCS0108.GetItemString(e.RowNumber, "change_qty2") == "")
                    {
                        grdOCS0108.SetItemValue(e.RowNumber, "change_qty2", e.ChangeValue);
                    }

                    break;
                #endregion
            }

            //if (cmd != "")
            if (isQueryCloud)
            {
                //object returnVal = Service.ExecuteScalar(cmd);

                //if (TypeCheck.IsNull(returnVal))
                //{
                //    name = "";
                //}
                //else
                //{
                //    name = returnVal.ToString();
                //}

                // updated by Cloud
                OCS0103U00GridColumnChangedArgs args = new OCS0103U00GridColumnChangedArgs();
                args.ChangeValue = e.ChangeValue.ToString();
                args.ColName = e.ColName;
                args.GridName = grid.Name;
                args.HospCode = mHospCode;
                OCS0103U00StringResult res = CloudService.Instance.Submit<OCS0103U00StringResult, OCS0103U00GridColumnChangedArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    name = res.ResStr;
                }

                if (name == "")
                {
                    this.mMsg = Resources.MSG027_MSG;
                    this.mCap = Resources.MSG027_CAP;

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true;

                    this.SetMsg(this.mMsg, MsgType.Error);

                    return;
                }

                grid.SetItemValue(e.RowNumber, nameColumn, name);
                this.SetMsg("");
            }

            if (grid.Name == "grdOCS0115")
            {
                string jundalTable = "";

                if (e.ColName == "jundal_part_out")
                {
                    jundalTable = this.GetJundalTable("O", e.ChangeValue.ToString(), this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));

                    if (jundalTable == "")
                    {
                        this.mMsg = Resources.MSG028_MSG;
                        this.mCap = Resources.MSG027_CAP;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.SetMsg(this.mMsg, MsgType.Error);
                    }
                    else
                    {
                        grid.SetItemValue(e.RowNumber, "jundal_table_out", jundalTable);
                    }
                }
                else if (e.ColName == "jundal_part_inp")
                {
                    jundalTable = this.GetJundalTable("I", e.ChangeValue.ToString(), this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));

                    if (jundalTable == "")
                    {
                        this.mMsg = Resources.MSG029_MSG;
                        this.mCap = Resources.MSG027_CAP;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.SetMsg(this.mMsg, MsgType.Error);
                    }
                    else
                    {
                        grid.SetItemValue(e.RowNumber, "jundal_table_inp", jundalTable);
                    }
                }

            }
        }

        private void FindBox_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox control = sender as XFindBox;

            switch (control.Name)
            {
                case "fbxBogyongCode":

                    #region 복용 코드인경우

                    // 내복약, 외용약인경우는 다른 창을 염
                    if (this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "C")      // 내복약
                    {

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.BOGYONG_CODE, A.BOGYONG_NAME "
                        //                        + "   FROM DRG0120 A "
                        //                        + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   "
                        //                        + "    AND BUNRYU1 <> '6'"
                        //                        + "  ORDER BY A.BOGYONG_CODE ";
                        this.fwkCommon.ExecuteQuery = GetFindBoxC;

                        //e.Cancel = true;
                        //XScreen.OpenScreen(this, "DRG0120Q01", ScreenOpenStyle.ResponseFixed);
                    }
                    else if (this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "D")  // 외용약
                    {

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.BOGYONG_CODE, A.BOGYONG_NAME "
                        //                        + "   FROM DRG0120 A "
                        //                        + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   "
                        //                        + "    AND BUNRYU1=  '6'"
                        //                        + "  ORDER BY A.BOGYONG_CODE ";

                        this.fwkCommon.ExecuteQuery = GetFindBoxD;

                        //e.Cancel = true;
                        //XScreen.OpenScreen(this, "DRG0120Q02", ScreenOpenStyle.ResponseFixed);
                    }
                    else if (this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "B") // 주사
                    {
                        this.SetFindWorker(false, "", control.Name);
                    }
                    else
                    {
                        e.Cancel = true;
                    }

                    break;

                    #endregion

                case "fbxSgCode":

                    #region 점수 코드인경우
                    e.Cancel = true;

                    CommonItemCollection param = new CommonItemCollection();

                    param.Add("sg_ymd", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                    XScreen.OpenScreenWithParam(this, "BASS", "BAS0311Q01", ScreenOpenStyle.ResponseFixed, param);

                    #endregion
                    break;


                default:

                    // 파인드워커 셋팅
                    this.SetFindWorker(false, "", control.Name);

                    break;
            }
        }

        private void FindBox_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //string cmd = "";
            object nameControl = null;
            string validatingObjectName = "";
            string jundalTable = "";
            // updated by Cloud
            bool isQueryCloud = true;

            XFindBox control = sender as XFindBox;

            switch (control.Name)
            {
                case "fbxQrySlipCode":

                    #region 조회용 슬립코드

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");
                        this.dbxQrySlipCodeName.SetDataValue("");
                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                        return;
                    }

                    // deleted by Cloud
                    //cmd = " SELECT A.SLIP_NAME "
                    //    + "   FROM OCS0102 A "
                    //    + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                    //    + "    AND A.SLIP_CODE = '" + e.DataValue + "' ";

                    isQueryCloud = true;
                    nameControl = this.dbxQrySlipCodeName;
                    validatingObjectName = Resources.VALIDATING_OBJECT_NAME_1_TEXT;

                    #endregion

                    break;

                case "fbxSlipCode":

                    #region 슬립코드

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");
                        this.dbxQrySlipCodeName.SetDataValue("");
                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                        return;
                    }

                    //cmd = " SELECT A.SLIP_NAME "
                    //    + "   FROM OCS0102 A "
                    //    + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                    //    + "    AND A.SLIP_CODE = '" + e.DataValue + "' ";

                    isQueryCloud = true;
                    nameControl = this.dbxSlipName;
                    validatingObjectName = Resources.VALIDATING_OBJECT_NAME_1_TEXT;

                    #endregion

                    break;

                case "fbxJundalPartOut":

                    #region 외래 전달 파트

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");
                        this.dbxJundalPartOutName.SetDataValue("");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jundal_part_out_name", "");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jundal_table_out", "");
                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                        return;
                    }

                    //cmd = " SELECT  A.GWA_NAME " +
                    //       "   FROM BAS0260 A, " +
                    //       "        OCS0128 B " +
                    //       "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                    //       "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                    //       "    AND A.GWA = '" + e.DataValue + "'" +
                    //       "    AND A.INP_JUNDAL_PART_YN = 'Y' " +
                    //       "    AND B.HOSP_CODE   = A.HOSP_CODE " +
                    //       "    AND B.IO_GUBUN    = 'O'" +
                    //       "    AND B.JUNDAL_PART = A.GWA " +
                    //       "  ORDER BY A.GWA ";

                    //cmd = " SELECT FN_BAS_LOAD_GWA_NAME ( '" + e.DataValue + "', TO_DATE('" + this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date") + "', 'YYYY/MM/DD') )" +
                    //      "   FROM DUAL ";

                    isQueryCloud = true;
                    nameControl = this.dbxJundalPartOutName;
                    validatingObjectName = Resources.VALIDATING_OBJECT_NAME_2_TEXT;

                    #endregion

                    break;

                case "fbxJundalPartInp":

                    #region 입원 전달 파트

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");
                        this.dbxJundalPartInpName.SetDataValue("");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jundal_part_inp_name", "");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jundal_table_inp", "");
                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                        return;
                    }

                    //cmd = " SELECT A.GWA_NAME " +
                    //        "   FROM BAS0260 A, " +
                    //        "        OCS0128 B " +
                    //        "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                    //        "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                    //        "    AND A.GWA = '" + e.DataValue + "'" +
                    //        "    AND A.INP_JUNDAL_PART_YN = 'Y' " +
                    //        "    AND B.HOSP_CODE   = A.HOSP_CODE " +
                    //        "    AND B.IO_GUBUN    = 'I'" +
                    //        "    AND B.JUNDAL_PART = A.GWA " +
                    //        "  ORDER BY A.GWA ";

                    //cmd = " SELECT FN_BAS_LOAD_GWA_NAME ( '" + e.DataValue + "', TO_DATE('" + this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date") + "', 'YYYY/MM/DD') )" +
                    //      "   FROM DUAL ";

                    isQueryCloud = true;
                    nameControl = this.dbxJundalPartInpName;
                    validatingObjectName = Resources.VALIDATING_OBJECT_NAME_3_TEXT;

                    #endregion

                    break;

                case "fbxMovePart":

                    #region 이동부서

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");
                        this.dbxJundalPartInpName.SetDataValue("");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "move_part_name", "");
                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                        return;
                    }

                    //cmd = " SELECT FN_BAS_LOAD_GWA_NAME ( '" + e.DataValue + "', TO_DATE('" + this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date") + "', 'YYYY/MM/DD') )" +
                    //      "   FROM SYS.DUAL ";

                    isQueryCloud = true;
                    nameControl = this.dbxMovePartName;
                    validatingObjectName = Resources.VALIDATING_OBJECT_NAME_4_TEXT;

                    #endregion

                    break;

                case "fbxSgCode":

                    #region 점수 코드

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");

                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "sg_name", "");
                        this.dbxSgName.SetDataValue("");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "bulyong_ymd", "");
                        this.dbxSgEndDate.SetDataValue("");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "hubal_drg_yn", "");
                        //this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "toijang_yn", "");
                        this.cbxToijangYN.SetDataValue("");

                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));

                        return;
                    }

                    this.layCommon.LayoutItems.Clear();
                    this.layCommon.LayoutItems.Add("sg_name", DataType.String);
                    this.layCommon.LayoutItems.Add("bulyong_ymd", DataType.Date);
                    this.layCommon.LayoutItems.Add("hubal_drg_yn", DataType.String);
                    //this.layCommon.LayoutItems.Add("toijang_yn", DataType.String);

                    this.layCommon.InitializeLayoutTable();

                    //this.layCommon.QuerySQL = " SELECT A.SG_NAME, A.BULYONG_YMD, A.HUBAL_DRG_YN " +
                    //                          "   FROM BAS0310 A " +
                    //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                    //                          "    AND A.SG_CODE = '" + e.DataValue + "' " +
                    //                          "    AND A.SG_YMD = ( SELECT MAX(Z.SG_YMD) " +
                    //                          "                       FROM BAS0310 Z " +
                    //                          "                      WHERE Z.HOSP_CODE = A.HOSP_CODE " +
                    //    //"                        AND Z.SG_YMD <= TO_DATE('" + this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date") + "', 'YYYY/MM/DD') " +
                    //                          "                        AND Z.SG_YMD <= TRUNC(SYSDATE) " +
                    //                          "                        AND NVL(Z.BULYONG_YMD, TO_DATE('99981231', 'YYYYMMDD')) > TO_DATE('" + this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date") + "', 'YYYY/MM/DD') " +
                    //                          "                        AND Z.SG_CODE = A.SG_CODE ) ";

                    // updated by Cloud
                    this.layCommon.ParamList = new List<string>(new string[] { "f_sg_code", "f_start_date" });
                    this.layCommon.SetBindVarValue("f_sg_code", e.DataValue);
                    this.layCommon.SetBindVarValue("f_start_date", this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));
                    this.layCommon.ExecuteQuery = GetLayCommonSgCode;

                    this.layCommon.QueryLayout(true);

                    if (this.layCommon.RowCount <= 0)
                    {
                        this.mMsg = Resources.MSG030_MSG;
                        this.mCap = Resources.MSG030_CAP;

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.SetMsg(this.mMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }
                    else
                    {
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "sg_name", this.layCommon.GetItemString(0, "sg_name"));
                        this.dbxSgName.SetDataValue(this.layCommon.GetItemString(0, "sg_name"));
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "bulyong_ymd", this.layCommon.GetItemString(0, "bulyong_ymd"));
                        this.dbxSgEndDate.SetDataValue(this.layCommon.GetItemString(0, "bulyong_ymd"));
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "hubal_drg_yn", this.layCommon.GetItemString(0, "hubal_drg_yn"));
                        this.cbxToijangYN.SetDataValue(this.layCommon.GetItemString(0, "hubal_drg_yn"));
                        //this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "toijang_yn", this.layCommon.GetItemString(0, "toijang_yn"));
                        //this.cbxToijangYN.SetDataValue(this.layCommon.GetItemString(0, "toijang_yn"));

                        this.SetMsg("");
                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                        return;
                    }

                    #endregion

                //break;

                case "fbxJaeryoCode":

                    #region 재료코드

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");

                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jaeryo_name", "");
                        this.dbxJaeryoName.SetDataValue("");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jaeryo_bulyong_date", "");
                        this.dbxJaeryoEndDate.SetDataValue("");

                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));

                        return;
                    }

                    this.layCommon.LayoutItems.Clear();
                    this.layCommon.LayoutItems.Add("jaeryo_name", DataType.String);
                    this.layCommon.LayoutItems.Add("bulyong_date", DataType.Date);
                    this.layCommon.InitializeLayoutTable();

                    //this.layCommon.QuerySQL = " SELECT A.JAERYO_NAME, A.BULYONG_DATE " +
                    //                          "   FROM INV0110 A " +
                    //                          "  WHERE A.HOSP_CODE   = '" + EnvironInfo.HospCode + "' " +
                    //                          "    AND A.JAERYO_CODE = '" + e.DataValue + "' ";

                    // updated by Cloud
                    this.layCommon.ParamList = new List<string>(new string[] { "f_jearyo_code" });
                    this.layCommon.SetBindVarValue("f_jearyo_code", e.DataValue);
                    this.layCommon.ExecuteQuery = GetLayCommonJearyoCode;

                    this.layCommon.QueryLayout(true);

                    if (this.layCommon.RowCount <= 0)
                    {
                        this.mMsg = Resources.MSG031_MSG;
                        this.mCap = Resources.MSG031_CAP;

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.SetMsg(this.mMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }
                    else
                    {
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jaeryo_name", this.layCommon.GetItemString(0, "jaeryo_name"));
                        this.dbxJaeryoName.SetDataValue(this.layCommon.GetItemString(0, "jaeryo_name"));
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jaeryo_bulyong_date", this.layCommon.GetItemString(0, "bulyong_date"));
                        this.dbxJaeryoEndDate.SetDataValue(this.layCommon.GetItemString(0, "bulyong_date"));

                        this.SetMsg("");

                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));

                        return;
                    }

                    #endregion

                case "fbxYJ_CODE":

                    #region unused codes
                    //                    this.layCommon.LayoutItems.Clear();
                    //                    this.layCommon.LayoutItems.Add("yj_code", DataType.String);
                    //                    this.layCommon.LayoutItems.Add("sg_code", DataType.String);
                    //                    this.layCommon.LayoutItems.Add("yak_kijun_code", DataType.String);
                    //                    this.layCommon.LayoutItems.Add("sale_name", DataType.String);
                    //                    this.layCommon.LayoutItems.Add("created_company_name", DataType.String);
                    //                    this.layCommon.LayoutItems.Add("saled_company_name", DataType.String);
                    //                    this.layCommon.InitializeLayoutTable();

                    //                    this.layCommon.QuerySQL = @"   SELECT A.A8  YJ_CODE
                    //                                                        , A.A7  YAK_KIJUN_CODE
                    //                                                        , A.A9  SG_CODE
                    //                                                        , A.A12 SALE_NAME
                    //                                                        , A.A21 CREATED_COMPANY_NAME
                    //                                                        , A.A22 SALED_COMPANY_NAME
                    //                                                     FROM ADM9983 A
                    //                                                    WHERE A.A9 = '" + this.fbxSgCode.GetDataValue() + @"'
                    //                                                      AND A.A7 = '" + this.txtYAK_KIJUN_CODE.Text + @"'
                    //                                                    GROUP BY A.A9, A.A7, A.A8, A.A12, A.A21, A.A22
                    //                                                    ORDER BY A.A8";

                    //                    this.layCommon.QueryLayout(true);
                    #endregion

                    return;

                    //break;

                //break;
                case "fbxBogyongCode":

                    #region 복용코드, 주사방법

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");

                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "default_bogyong_name", "");
                        this.dbxBogyongCodeName.SetDataValue("");

                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                        return;
                    }



                  // 내복
                    else if (this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "C")
                    {
                        //cmd = " SELECT A.BOGYONG_NAME "
                        //    + "   FROM DRG0120 A "
                        //    + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   "
                        //    + "    AND BUNRYU1<> '6'"
                        //    + "    AND BOGYONG_CODE= '" + e.DataValue + "'"
                        //    + "  ORDER BY A.BOGYONG_CODE ";

                        validatingObjectName = Resources.VALIDATING_OBJECT_NAME_5_TEXT;

                        isQueryCloud = true;
                    }


               // 외용약
                    else if (this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "D")
                    {
                        //cmd = " SELECT A.BOGYONG_NAME "
                        //    + "   FROM DRG0120 A "
                        //    + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                        //    + "    AND BUNRYU1       = '6'"
                        //    + "    AND BOGYONG_CODE  = '" + e.DataValue + "' "
                        //    + "ORDER BY A.BOGYONG_CODE ";

                        nameControl = this.dbxBogyongCodeName;
                        validatingObjectName = Resources.VALIDATING_OBJECT_NAME_5_TEXT;
                        isQueryCloud = true;
                    }

                    // 주사인경우

                    if (this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "B")
                    {
                        //cmd = " SELECT A.CODE_NAME "
                        // + "   FROM OCS0132 A "
                        // + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   "
                        // + "    AND A.CODE_TYPE = 'JUSA' "
                        // + "    AND A.CODE= '" + e.DataValue + "'"
                        // + "  ORDER BY A.CODE_NAME ";

                        nameControl = this.dbxBogyongCodeName;
                        validatingObjectName = Resources.LBBOGYONGCODE_1_TEXT;
                        isQueryCloud = true;
                    }

                    //}                    // 주사인경우
                    //if (this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "B")
                    //{
                    //    cmd = " SELECT FN_OCS_LOAD_CODE_NAME ('JUSA', '" + e.DataValue + "' ) " +
                    //          "   FROM DUAL ";

                    //    validatingObjectName = "注射方法";
                    //}

                    //외용약인경

                    // 내복, 외용약인경
                    //else if (this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "C" ||
                    //         this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "D")
                    //{
                    //    cmd = " SELECT FN_DRG_LOAD_BOGYONG_NAME ( '" + e.DataValue + "' ) " +
                    //          "   FROM DUAL ";

                    //    validatingObjectName = "服用";
                    //}

                    nameControl = this.dbxBogyongCodeName;

                    #endregion

                    break;

                case "fbxSpecimenDefault":

                    #region 기본검체

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "specimen_default", "");

                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                        return;
                    }

                    //cmd = " SELECT A.SPECIMEN_NAME " +
                    //      "   FROM OCS0116 A " +
                    //      "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                    //      "    AND A.SPECIMEN_CODE = '" + e.DataValue + "' ";

                    validatingObjectName = Resources.VALIDATING_OBJECT_NAME_6_TEXT;
                    isQueryCloud = true;

                    #endregion

                    break;

                case "fbxPatStatusGr":

                    #region 환자상태

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "pat_status_gr", "");

                        PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                        return;
                    }

                    //cmd = " SELECT A.PAT_STATUS_GR_NAME " +
                    //      "   FROM OCS0803 A " +
                    //      "  WHERE A.HOSP_CODE     = '" + EnvironInfo.HospCode + "' " +
                    //      "    AND A.PAT_STATUS_GR = '" + e.DataValue + "' ";

                    isQueryCloud = true;
                    validatingObjectName = Resources.VALIDATING_OBJECT_NAME_7_TEXT;

                    #endregion

                    break;

                case "fbxSpecificComment":

                    #region 의뢰서

                    if (e.DataValue == "")
                    {
                        this.SetMsg("");
                        this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "SpecificComment", "");
                        isQueryCloud = false;
                        break;
                    }

                    //cmd = " SELECT A.SPECIFIC_COMMENT " +
                    //      "   FROM OCS0170 A " +
                    //      "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                    //      "    AND A.SPECIFIC_COMMENT = '" + e.DataValue + "' ";
                    isQueryCloud = true;

                    #endregion

                    break;

            }

            #region 벨리데이팅

            string name = "";

            //if (Service.ExecuteScalar(cmd) == null)
            //{
            //    name = "";
            //}
            //else
            //{
            //    name = Service.ExecuteScalar(cmd).ToString();
            //}

            //name = Service.ExecuteScalar(cmd).ToString();

            if (isQueryCloud)
            {
                OCS0103U00FindBoxDataValidatingArgs args = new OCS0103U00FindBoxDataValidatingArgs();
                args.DataValue = e.DataValue;
                args.FbName = control.Name;
                args.OrderGubun = grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun");
                args.StartDate = grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date");
                args.HospCode = mHospCode;
                OCS0103U00StringResult res = CloudService.Instance.Submit<OCS0103U00StringResult, OCS0103U00FindBoxDataValidatingArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    name = res.ResStr;
                }


                if (name == "")
                {
                    this.mMsg = validatingObjectName + Resources.MSG032_MSG;
                    this.mCap = validatingObjectName + Resources.MSG027_CAP;

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.SetMsg(this.mMsg, MsgType.Error);

                    e.Cancel = true;
                }
                else
                {
                    if (nameControl != null && nameControl is XDisplayBox)
                    {
                        ((XDisplayBox)nameControl).SetEditValue(name);
                        ((XDisplayBox)nameControl).AcceptData();

                        foreach (XEditGridCell cell in this.grdOCS0103.CellInfos)
                        {
                            if (cell.BindControl is XDisplayBox &&
                                ((Control)cell.BindControl).Name == ((Control)nameControl).Name)
                            {
                                this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, cell.CellName, name);
                            }
                        }
                    }

                    // 입력컨트롤 Protect를 위한 포스트 메소드
                    PostCallHelper.PostCall(new PostMethod(this.PostValidating_Protect));
                }
            }

            #endregion

            #region 전달 파트 변경시 전달 테이블 셋팅

            if (control.Name == "fbxJundalPartOut")
            {

                jundalTable = this.GetJundalTable("O", e.DataValue, this.dtpStartDate.GetDataValue());

                if (jundalTable == "")
                {
                    this.mMsg = Resources.MSG033_MSG;
                    this.mCap = Resources.MSG033_CAP;

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true;
                }
                else
                {
                    this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jundal_table_out", jundalTable);
                    this.SetMsg("");
                }
            }
            else if (control.Name == "fbxJundalPartInp")
            {
                jundalTable = this.GetJundalTable("I", e.DataValue, this.dtpStartDate.GetDataValue());

                if (jundalTable == "")
                {
                    this.mMsg = Resources.MSG034_MSG;
                    this.mCap = Resources.MSG034_CAP;

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true;
                }
                else
                {
                    this.grdOCS0103.SetItemValue(this.grdOCS0103.CurrentRowNumber, "jundal_table_inp", jundalTable);
                    this.SetMsg("");
                }
            }

            #endregion
        }

        private void InputControl_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //cboDvTime.SelectedIndex = 0;
            //cboDvTime.AcceptData();
            PostCallHelper.PostCall(new PostMethod(PostValidating_Protect));
        }

        private void cboUsedYn_SelectedValueChanged(object sender, EventArgs e)
        {
            PostCallHelper.PostCall(new PostMethod(PostComboControl));
        }

        private void cboWonnaeYn_SelectedValueChanged(object sender, EventArgs e)
        {
            PostCallHelper.PostCall(new PostMethod(PostComboControl));
        }

        private void btnOrderCopy_Click(object sender, EventArgs e)
        {            
            int currentRowNumber = this.grdOCS0103.CurrentRowNumber;

            if (currentRowNumber < 0) return;

            int newRow = this.grdOCS0103.InsertRow(currentRowNumber);

            //SetCommonOrder();

            foreach (DataColumn cl in this.grdOCS0103.LayoutTable.Columns)
            {
                if (cl.ColumnName != "hangmog_code" &&
                    cl.ColumnName != "hangmog_name")
                    this.grdOCS0103.SetItemValue(newRow, cl.ColumnName, this.grdOCS0103.GetItemString(currentRowNumber, cl.ColumnName));
            }

        }

        private void btnDrugMaster_Click(object sender, EventArgs e)
        {
            if (this.grdOCS0103.CurrentRowNumber < 0)
            {
                return;
            }

            if (this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "B" ||
                this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "C" ||
                this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "order_gubun") == "D")
            {
                CommonItemCollection param = new CommonItemCollection();

                param.Add("hangmog_code", this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"));
                param.Add("hangmog_name", this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_name"));

                XScreen.OpenScreenWithParam(this, "DRGS", "DRGOCSCHK", ScreenOpenStyle.ResponseFixed, param);
            }
            else
            {
                this.mMsg = Resources.MSG039_MSG;
                this.mCap = Resources.MSG039_CAP;
                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMSLayout != null) this.mOrderBiz.GridDisplayValue((XGrid)this.CurrMSLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }

        private void grdOCS0103_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            //換算基準・すべて削除したとき
            if (this.grdOCS0108.RowCount == 0)
            {
                if (this.grdOCS0108.DeletedRowTable != null &&
                    this.grdOCS0108.DeletedRowTable.Rows.Count > 0)
                {
                    if (XMessageBox.Show(Resources.MSG040_MSG, Resources.MSG023_CAP,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                    else
                    {
                        return;
                    }

                    return;
                }
            }

            //換算基準を1行以上残して削除及び追加・修正したとき
            for (int i = 0; i < this.grdOCS0108.RowCount; i++)
            {
                //削除
                if (this.grdOCS0108.DeletedRowTable != null &&
                    this.grdOCS0108.DeletedRowTable.Rows.Count > 0)
                {
                    if (XMessageBox.Show(Resources.MSG040_MSG, Resources.MSG023_CAP,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                    else
                    {
                        return;
                    }

                    return;
                }
                //追加・修正
                if (this.grdOCS0108.LayoutTable.Rows[i].RowState == DataRowState.Added ||
                    this.grdOCS0108.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                {
                    if (XMessageBox.Show(Resources.MSG041_MSG, Resources.MSG023_CAP,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            //オーダ伝達・すべて削除したとき
            if (this.grdOCS0115.RowCount == 0)
            {
                if (this.grdOCS0115.DeletedRowTable != null &&
                    this.grdOCS0115.DeletedRowTable.Rows.Count > 0)
                {
                    if (XMessageBox.Show(Resources.MSG042_MSG, Resources.MSG023_CAP,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                    else
                    {
                        return;
                    }

                    return;
                }
            }

            //オーダ別伝達部署を1行以上残して削除及び追加・修正したとき
            for (int i = 0; i < this.grdOCS0115.RowCount; i++)
            {
                //削除
                if (this.grdOCS0115.DeletedRowTable != null &&
                    this.grdOCS0115.DeletedRowTable.Rows.Count > 0)
                {
                    if (XMessageBox.Show(Resources.MSG042_MSG, Resources.MSG023_CAP,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                    else
                    {
                        return;
                    }

                    return;
                }
                //追加・修正
                if (this.grdOCS0115.LayoutTable.Rows[i].RowState == DataRowState.Added ||
                    this.grdOCS0115.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                {
                    if (XMessageBox.Show(Resources.MSG043_MSG, Resources.MSG023_CAP,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            //検体コード・すべて削除したとき
            if (this.grdOCS0113.RowCount == 0)
            {
                if (this.grdOCS0113.DeletedRowTable != null &&
                    this.grdOCS0113.DeletedRowTable.Rows.Count > 0)
                {
                    if (XMessageBox.Show(Resources.MSG044_MSG, Resources.MSG023_CAP,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                    else
                    {
                        return;
                    }

                    return;
                }
            }

            //検体コードを1行以上残して削除及び追加・修正したとき
            for (int i = 0; i < this.grdOCS0113.RowCount; i++)
            {
                //削除
                if (this.grdOCS0113.DeletedRowTable != null &&
                    this.grdOCS0113.DeletedRowTable.Rows.Count > 0)
                {
                    if (XMessageBox.Show(Resources.MSG044_MSG, Resources.MSG023_CAP,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                    else
                    {
                        return;
                    }

                    return;
                }
                //追加・修正
                if (this.grdOCS0113.LayoutTable.Rows[i].RowState == DataRowState.Added ||
                    this.grdOCS0113.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                {
                    if (XMessageBox.Show(Resources.MSG045_MSG, Resources.MSG023_CAP,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void txtQryHangmogINX_DataValidating(object sender, DataValidatingEventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);
        }

        private void cboOrderGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrderGubun.GetDataValue() == "B")
                lbBogyongCode.Text = Resources.LBBOGYONGCODE_3_TEXT;
            else
                lbBogyongCode.Text = Resources.LBBOGYONGCODE_2_TEXT;

        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "BAS0311Q01":
                    if (commandParam != null && commandParam.Contains("BAS0311"))
                    {
                        this.fbxSgCode.SetEditValue(((MultiLayout)commandParam["BAS0311"]).GetItemString(0, "sg_code"));
                        this.fbxSgCode.AcceptData();
                    }
                    break;
            }
            return base.Command(command, commandParam);
        }

        private void layDanui_QueryStarting(object sender, CancelEventArgs e)
        {
            layDanui.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void xHospBox1_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox1.HospCode;
            this.btnList.PerformClick(FunctionType.Query);

            //set comboBox
            this.LoadAllCombos();
        }

        private void xHospBox1_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = xHospBox1.HospCode;
                this.btnList.PerformClick(FunctionType.Query);

                //set comboBox
                this.LoadAllCombos();
            }
        }

        #endregion

        #region Methods(private)

        private void InitScreen()
        {
            // 조회조건 클리어.
            this.cboQrySlipGubun.SelectedIndex = 0;

            this.fbxQrySlipCode.SetDataValue("");
            this.dbxQrySlipCodeName.SetDataValue("");

            this.txtQryHangmogINX.SetDataValue("");

            this.cboWonnaeYn.SelectedValueChanged -= new EventHandler(cboWonnaeYn_SelectedValueChanged);
            this.cboWonnaeYn.SetDataValue("%");
            this.cboWonnaeYn.SelectedValueChanged += new EventHandler(cboWonnaeYn_SelectedValueChanged);

            this.cboUsedYn.SelectedValueChanged -= new EventHandler(cboUsedYn_SelectedValueChanged);
            this.cboUsedYn.SetDataValue("%");
            this.cboUsedYn.SelectedValueChanged += new EventHandler(cboUsedYn_SelectedValueChanged);

            // 입력 컨트롤 프로텍트 -- 전부 protect true
            this.ProtectInputControl();
        }

        private void ClearInputControl()
        {
            foreach (Control control in this.pnlControls.Controls)
            {
                if (control is IDataControl)
                {
                    ((IDataControl)control).ResetData();
                }
            }
        }

        private void ProtectInputControl()
        {
            foreach (Control control in this.pnlControls.Controls)
            {
                if (control is IDataControl)
                {
                    ((IDataControl)control).Protect = true;
                }
            }
        }

        private void ProtectInputControl(int aRowNumber)
        {
            // MessageBox.Show("시작");
            if (aRowNumber < 0)
            {
                return;
            }

            foreach (XEditGridCell cell in this.grdOCS0103.CellInfos)
            {
                if (cell.BindControl == null) continue;

                bool isProtect = false;

                if (cell.IsReadOnly == true)
                {
                    isProtect = true;
                }
                else if (this.grdOCS0103.GetRowState(aRowNumber) != DataRowState.Added && cell.IsUpdatable == false)
                {
                    isProtect = true;
                }
                else
                {

                    switch (cell.CellName)
                    {
                        case "wonyoi_order_yn":
                        case "default_bogyong_code":
                        //                        case "bogyong_code":
                        case "dv_time":

                            #region ( 내복약, 외용약, 주사인경우만의 로직 )

                            // 주사, 내복약, 외용약인경우만 dv_time 입력, bogyong_code 입력
                            if (this.grdOCS0103.GetItemString(aRowNumber, "order_gubun") == "B" ||
                                this.grdOCS0103.GetItemString(aRowNumber, "order_gubun") == "C" ||
                                this.grdOCS0103.GetItemString(aRowNumber, "order_gubun") == "D")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            if (this.grdOCS0103.GetItemString(aRowNumber, "order_gubun") == "B")
                            {
                                this.lbBogyongCode.Text = Resources.LBBOGYONGCODE_1_TEXT;
                            }
                            else if (this.grdOCS0103.GetItemString(aRowNumber, "order_gubun") == "C" ||
                                     this.grdOCS0103.GetItemString(aRowNumber, "order_gubun") == "D")
                            {
                                this.lbBogyongCode.Text = Resources.LBBOGYONGCODE_2_TEXT;
                            }

                            #endregion

                            break;


                        case "specimen_default":

                            #region ( 기본검체 입력 컬럼 프로텍트 )

                            // specimen_yn 이 Y 인경우만 입력가능

                            if (this.grdOCS0103.GetItemString(aRowNumber, "specimen_yn") == "Y")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;

                        case "sg_code":

                            #region ( 점수 코드 입력 컬럼 프로텍트 )

                            // 점수사용이 Y인경우만 sg_code 입력

                            if (this.grdOCS0103.GetItemString(aRowNumber, "suga_yn") == "Y")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;

                        case "jaeryo_code":

                            #region ( 재료코드 입력 컬럼 프로텍트 )

                            if (this.grdOCS0103.GetItemString(aRowNumber, "jaeryo_yn") == "Y")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;

                        case "reser_yn_out":

                            #region ( 외래 예약 여부 컬럼 프로텍트 )

                            if (this.grdOCS0103.GetItemString(aRowNumber, "jaeryo_yn") != "Y" &&
                                this.grdOCS0103.GetItemString(aRowNumber, "jundal_table_out") != "HOM")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;

                        case "reser_yn_inp":

                            #region ( 입원 예약 여부 컬럼 프로텍트 )

                            if (this.grdOCS0103.GetItemString(aRowNumber, "jaeryo_yn") != "Y" &&
                                this.grdOCS0103.GetItemString(aRowNumber, "jundal_table_inp") != "HOM")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;

                        case "specimen_yn":

                            #region ( 검체 사용여부 입력 컨트롤 프로텍트 )

                            if (this.grdOCS0103.GetItemString(aRowNumber, "jaeryo_yn") != "Y")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;

                        case "portable_check":

                            #region ( 이동촬영 여부 입력 컨트롤 프로텍트 )

                            // 방사선인 경우만
                            if (this.grdOCS0103.GetItemString(aRowNumber, "order_gubun") == "E")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;

                        case "bom_yn":

                            #region ( BOM 재료사용 여부 입력 컨트롤 프로텍트 )

                            if (this.grdOCS0103.GetItemString(aRowNumber, "jaeryo_yn") != "Y" && this.grdOCS0103.GetItemString(aRowNumber, "return_yn") != "Y")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;

                        case "return_yn":
                        case "default_suryang":
                        case "subul_convert_gubun":

                            #region ( 재료인경우의 입력컨트롤 프로텍트 )

                            if (this.grdOCS0103.GetItemString(aRowNumber, "jaeryo_yn") == "Y")
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;

                        case "anti_cancer_yn":

                            #region ( 주사인경우의 입력컨트롤 프로텍트 )

                            if (this.grdOCS0103.GetItemString(aRowNumber, "order_gubun") == "B") // 주사인경우
                            {
                                isProtect = false;
                            }
                            else
                            {
                                isProtect = true;
                            }

                            #endregion

                            break;
                        case "yj_code":
                            if (this.grdOCS0103.GetItemString(aRowNumber, "yak_kijun_code") != "")
                                isProtect = false;
                            else
                                isProtect = true;
                            break;
                        case "trial":
                            if (this.grdOCS0103.GetItemString(aRowNumber, "trial") != "Y")
                            {
                                this.fbxProtocol.Protect = true;
                                this.fbxProtocol.ResetData();
                            }
                            else
                            {
                                this.fbxProtocol.Protect = false;
                            }
                            break;


                    }
                }
                if(cell.CellName!="protocol")
                    ((IDataControl)cell.BindControl).Protect = isProtect;
                // MessageBox.Show(cell.CellName + " " + ((Control)cell.BindControl).Name + " " + isProtect.ToString());
            }
            //If User is admingroup and f_jundal_table_out not in ('CPL', 'XRT', 'OP', 'PFE')
            if (CheckAdminUser() == true)
            {
                cbxCommonOrder.Enabled = true;
            }
            else
            {
                cbxCommonOrder.Enabled = false;
            }            

        }
        private bool CheckAdminUser()
        {
            OCS0103U00CheckAdminUserArgs args = new OCS0103U00CheckAdminUserArgs();
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                args.HospCode = xHospBox1.HospCode.ToString();
                hosp_code = xHospBox1.HospCode.ToString();
            }
            else 
            {
                args.HospCode = UserInfo.HospCode;
                hosp_code = UserInfo.HospCode;
            }
            
            OCS0103U00CheckAdminUserResult res = CloudService.Instance.Submit<OCS0103U00CheckAdminUserResult, OCS0103U00CheckAdminUserArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.MasterGroupHosp == hosp_code)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Sub-task MED-10693
        private void SetCommonOrder()
        {
            OCS0103U00CheckAdminUserArgs args = new OCS0103U00CheckAdminUserArgs();
            args.HospCode = UserInfo.HospCode;
            OCS0103U00CheckAdminUserResult res = CloudService.Instance.Submit<OCS0103U00CheckAdminUserResult, OCS0103U00CheckAdminUserArgs>(args);
            if (UserInfo.AdminType == AdminType.Admin)
            {
                if(res.ExecutionStatus == ExecutionStatus.Success && res.MasterGroupHosp == UserInfo.HospCode)
                {
                    cbxCommonOrder.Enabled = true;
                }                
            }
            else
                cbxCommonOrder.Enabled = false;
        }

        private void DataLoadOCS0103(string aSlipGubun, string aSlipCode, string aHangmogINX)
        {
            #region unused codes
            //this.grdOCS0103.QuerySQL = " SELECT A.SYS_DATE                   " + "\r\n"
            //             + "      , A.SYS_ID                     " + "\r\n"
            //             + "      , A.UPD_DATE                   " + "\r\n"
            //             + "      , A.HANGMOG_CODE               " + "\r\n"
            //             + "      , A.HANGMOG_NAME               " + "\r\n"
            //             + "      , A.SLIP_CODE                  " + "\r\n"
            //             + "      , A.GROUP_YN                   " + "\r\n"
            //             + "      , A.POSITION                   " + "\r\n"
            //             + "      , A.SEQ                        " + "\r\n"
            //             + "      , A.ORDER_GUBUN                " + "\r\n"
            //             + "      , A.INPUT_CONTROL              " + "\r\n"
            //             + "      , A.JUNDAL_TABLE_OUT           " + "\r\n"
            //             + "      , A.JUNDAL_TABLE_INP           " + "\r\n"
            //             + "      , A.JUNDAL_PART_OUT            " + "\r\n"
            //             + "      , A.JUNDAL_PART_INP            " + "\r\n"
            //             + "      , A.MOVE_PART                  " + "\r\n"
            //             + "      , A.DV_TIME                    " + "\r\n"
            //             + "      , A.ORD_DANUI                  " + "\r\n"
            //             + "      , A.DEFAULT_BOGYONG_CODE       " + "\r\n"
            //             + "      , A.SUGA_YN                    " + "\r\n"
            //             + "      , A.SG_CODE                    " + "\r\n"
            //             + "      , A.JAERYO_YN                  " + "\r\n"
            //             + "      , A.JAERYO_CODE                " + "\r\n"
            //             + "      , A.HANGMOG_NAME_INX           " + "\r\n"
            //             + "      , A.DISPLAY_YN                 " + "\r\n"
            //             + "      , A.START_DATE                 " + "\r\n"
            //             + "      , A.END_DATE                   " + "\r\n"
            //             + "      , A.SPECIMEN_YN                " + "\r\n"
            //             + "      , A.SPECIMEN_DEFAULT           " + "\r\n"
            //             + "      , A.DEFAULT_PORTABLE_YN        " + "\r\n"
            //             + "      , A.SPECIFIC_COMMENT           " + "\r\n"
            //             + "      , A.RESER_YN_OUT               " + "\r\n"
            //             + "      , A.RESER_YN_INP               " + "\r\n"
            //             + "      , A.EMERGENCY                  " + "\r\n"
            //             + "      , A.LIMIT_SURYANG              " + "\r\n"
            //             + "      , A.BOM_YN                     " + "\r\n"
            //             + "      , A.RETURN_YN                  " + "\r\n"
            //             + "      , A.SUBUL_CONVERT_GUBUN        " + "\r\n"
            //             + "      , A.WONYOI_ORDER_YN            " + "\r\n"
            //             + "      , A.DEFAULT_WONNAE_SAYU        " + "\r\n"
            //             + "      , A.ANTI_CANCER_YN             " + "\r\n"
            //             + "      , A.CHISIK_YN                  " + "\r\n"
            //             + "      , A.NDAY_YN                    " + "\r\n"
            //             + "      , A.MUHYO_YN                   " + "\r\n"
            //             + "      , A.INV_JUNDAL_YN              " + "\r\n"
            //             + "      , A.POWDER_YN                  " + "\r\n"
            //             + "      , A.REMARK                     " + "\r\n"
            //             + "      , A.DEFAULT_DV                 " + "\r\n"
            //             + "      , A.DEFAULT_SURYANG            " + "\r\n"
            //             //+ "      , D.SG_UNION                   "
            //             //+ "      , D.SG_NAME                    "
            //             + "      , A.NURSE_INPUT_YN             " + "\r\n"
            //             + "      , A.SUPPLY_INPUT_YN            " + "\r\n"
            //             + "      , A.LIMIT_NALSU                " + "\r\n"
            //             + "      , A.DEFAULT_WONYOI_YN          " + "\r\n"
            //             + "      , A.PORTABLE_CHECK             " + "\r\n"
            //             + "      , A.PAT_STATUS_GR              " + "\r\n"
            //             + "      , A.UPD_ID                     " + "\r\n"
            //             + "      , A.HOSP_CODE                  " + "\r\n"
            //             + "      , A.DEFAULT_JUSA               " + "\r\n"
            //             + "      , B.SLIP_NAME                  " + "\r\n"
            //             + "      , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_OUT, SYSDATE)   JUNDAL_PART_OUT_NAME " + "\r\n"
            //             + "      , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART_INP, SYSDATE)   JUNDAL_PART_INP_NAME " + "\r\n"
            //             + "      , FN_BAS_LOAD_GWA_NAME(A.MOVE_PART, SYSDATE)         MOVE_PART_NAME " + "\r\n"
            //             //+ "      , TO_CHAR(D.BULYONG_YMD, 'YYYY/MM/DD')                "
            //             //+ "      , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', D.DANUI)      SG_DANUI_NAME "
            //             //+ "      , D.TOIJANG_YN                 " 
            //             + "      , E.JAERYO_NAME                " + "\r\n"
            //             + "      , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', E.SUBUL_DANUI) SUBUL_DANUI_NAME " + "\r\n"
            //             + "      , TO_CHAR(E.BULYONG_DATE, 'YYYY/MM/DD')  JEARYO_BULYONG_DATE " + "\r\n"
            //             + "      , CASE WHEN A.ORDER_GUBUN IN ('C', 'D') THEN FN_DRG_LOAD_BOGYONG_NAME ( A.DEFAULT_BOGYONG_CODE ) " + "\r\n"
            //             + "             WHEN A.ORDER_GUBUN IN ('B')      THEN FN_OCS_LOAD_CODE_NAME ('JUSA', A.DEFAULT_BOGYONG_CODE ) " + "\r\n"
            //             + "             ELSE NULL               " + "\r\n"
            //             + "        END DEFAULT_BOGYONG_NAME     " + "\r\n"
            //             + "      , A.IF_INPUT_CONTROL           " // ADD 
            //             + "      , D.HUBAL_DRG_YN              "  + "\r\n" 
            //             + "      , D.SG_NAME                    " + "\r\n"
            //             + "      , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', D.DANUI)      SG_DANUI_NAME "   + "\r\n"
            //             + "      , TO_CHAR(D.BULYONG_YMD, 'YYYY/MM/DD')" + "\r\n"
            //             + "      , A.RESULT_GUBUN  " + "\r\n"
            //             + "      , A.WONNAE_DRG_YN " + "\r\n"
            //             + "   FROM CNV0006 F                    " + "\r\n" 
            //             + "      , INV0110 E                    " + "\r\n"
            //             //+ "      , BAS0310 D                    " DELL 
            //             + "        ,(SELECT X.SG_CODE           "
            //             + "               , X.SG_UNION          "
            //             + "               , X.SG_NAME           "
            //             + "               , X.BULYONG_YMD       "
            //             + "               , X.DANUI             "
            //             + "               , X.HUBAL_DRG_YN "
            //             + "            FROM BAS0310 X           "
            //             + "           WHERE X.SG_YMD = ( SELECT MAX(Z.SG_YMD) "
            //             + "                                FROM BAS0310 Z "
            //             + "                               WHERE Z.SG_CODE = X.SG_CODE "
            //             + "                                 AND Z.SG_YMD <= TRUNC(SYSDATE) ) "
            //             + "        ) D                          " + "\r\n"
            //             + "      , OCS0101 C                    " + "\r\n"
            //             + "      , OCS0102 B                    " + "\r\n"
            //             + "      , OCS0103 A                    " + "\r\n"
            //             + "  WHERE A.SLIP_CODE        LIKE '" + TypeCheck.NVL(aSlipCode, "%").ToString() + "'        " + "\r\n"
            //             + "    AND A.HANGMOG_NAME_INX LIKE '%" + TypeCheck.NVL(this.LoadKatakanaFull(aHangmogINX) + "%", "%").ToString() + "'  " + "\r\n"
            //            // + "    AND A.HANGMOG_NAME_INX LIKE '" + TypeCheck.NVL(aHangmogINX, "%").ToString() + "'  " + "\r\n" 
            //             + "    AND A.HOSP_CODE        = B.HOSP_CODE " + "\r\n"
            //             + "    AND A.SLIP_CODE        = B.SLIP_CODE " + "\r\n"
            //             + "    AND B.HOSP_CODE        = C.HOSP_CODE " + "\r\n"
            //             + "    AND B.SLIP_GUBUN       = C.SLIP_GUBUN " + "\r\n"
            //             + "    AND C.SLIP_GUBUN       LIKE '" + aSlipGubun + "'   " + "\r\n"
            //             //+ "    AND A.HOSP_CODE        = D.HOSP_CODE (+) "
            //             + "    AND A.SG_CODE          = D.SG_CODE (+) "
            //             + "    AND A.HOSP_CODE        = E.HOSP_CODE (+) "
            //             + "    AND A.JAERYO_CODE      = E.JAERYO_CODE (+) " + "\r\n"
            //             + "    AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " + "\r\n"
            //             + "    AND D.SG_CODE   = F.SG_CODE (+) "
            //             + "    AND ( "
            //             + "           ( :f_used_yn = '%' ) "
            //             + "           OR "
            //             + "           ( :f_used_yn = '1' "
            //             + "             AND F.SG_CODE IS NOT NULL ) "
            //             + "           OR "
            //             + "           ( :f_used_yn = '2' "
            //             + "             AND F.SG_CODE IS NULL ) "
            //             + "        ) "
            //             + "    AND ( "
            //             + "           ( :f_wonnae_yn = '%' ) "
            //             + "           OR "
            //             + "           ( :f_wonnae_yn = '1' "
            //             + "             AND NVL(A.WONNAE_DRG_YN, 'N') = 'Y' ) "
            //             + "           OR "
            //             + "           ( :f_wonnae_yn = '2' "
            //             + "             AND NVL(A.WONNAE_DRG_YN, 'N') != 'Y' ) "
            //             + "        ) "
            //             + "  ORDER BY A.HANGMOG_CODE            ";
            #endregion

            this.grdOCS0103.SetBindVarValue("f_slip_code", TypeCheck.NVL(aSlipCode, "%").ToString());
            //this.grdOCS0103.SetBindVarValue("f_hangmog_inx", "%" + TypeCheck.NVL(this.LoadKatakanaFull(aHangmogINX) + "%", "%").ToString());
            this.grdOCS0103.SetBindVarValue("f_hangmog_inx", TypeCheck.NVL(aHangmogINX , "").ToString());
            this.grdOCS0103.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS0103.SetBindVarValue("f_slip_gubun", aSlipGubun);

            this.grdOCS0103.SetBindVarValue("f_used_yn", this.cboUsedYn.GetDataValue());
            this.grdOCS0103.SetBindVarValue("f_wonnae_yn", this.cboWonnaeYn.GetDataValue());

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                this.grdOCS0103.QueryLayout(false);                
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void DataLoadOCS0108(string aHangmogCode, string aHangmogStartDate)
        //private void DataLoadOCS0108(string aHangmogCode) UPD SHIMO
        {
            //this.grdOCS0108.QuerySQL = " SELECT A.HANGMOG_CODE                       "
            //            + "      , A.ORD_DANUI                                       "
            //            + "      , A.SEQ                                             "
            //            + "      , A.CHANGE_QTY1                 SUNAB_GIJUN         "
            //            + "      , A.CHANGE_QTY2                 SUBUL_GIJUN         "
            //            + "      , A.HOSP_CODE                                       "
            //            + "      , A.HANGMOG_START_DATE                              "
            //            + "      , B.CODE_NAME || '/' || FN_OCS_LOAD_SUNAB_DANUI_NAME(A.HANGMOG_CODE, A.HANGMOG_START_DATE) "
            //            + "      , B.CODE_NAME || '/' || FN_OCS_LOAD_SUBUL_DANUI_NAME(A.HANGMOG_CODE, A.HANGMOG_START_DATE) "
            //            + "   FROM OCS0108 A                                         "
            //            + "      , OCS0132 B                                         "
            //            + "  WHERE A.HANGMOG_CODE = '" + aHangmogCode + "'           "
            //            + "    AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "'      "
            //            + "    AND A.HANGMOG_START_DATE = TO_DATE('" + aHangmogStartdate + "','YYYY/MM/DD')"
            //            + "    AND A.ORD_DANUI = B.CODE (+)                          "
            //            + "    AND B.CODE_TYPE = 'ORD_DANUI'                         "
            //            + "  ORDER BY A.HANGMOG_CODE, A.SEQ                          ";
            this.grdOCS0108.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS0108.SetBindVarValue("f_hangmog_code", aHangmogCode);
            this.grdOCS0108.SetBindVarValue("f_hangmog_start_date", aHangmogStartDate);
            this.grdOCS0108.QueryLayout(true);

            //if (grdOCS0108.RowCount > 0)
            //{
            //    for (int i = 0; i < grdOCS0108.RowCount; i++)
            //    {
            //        if (this.dbxSunabDanuiName.Text != null)
            //        {
            //            grdOCS0108.SetItemValue(i, "change_danui1", grdOCS0108[i, "ord_danui"].CellDisplayText + "/" + this.dbxSunabDanuiName.Text);
            //        }
            //        if (this.dbxSubulDanuiName.Text != null)
            //        {
            //            grdOCS0108.SetItemValue(i, "change_danui2", grdOCS0108[i, "ord_danui"].CellDisplayText + "/" + this.dbxSubulDanuiName.Text);
            //        }                    
            //    }
            //    grdOCS0108.ResetUpdate();
            //}
        }

        private void DataLoadOCS0115(string aHangmogCode, string aHangmogStartDate)
        //private void DataLoadOCS0115(string aHangmogCode) UPD SHIMO
        {
            //this.grdOCS0115.QuerySQL = " SELECT A.HANGMOG_CODE                                                         "
            //            + "      , A.INPUT_GWA                                                            "
            //            + "      , A.INPUT_PART                                                           "
            //            + "      , DECODE(A.INPUT_PART, '*', '全体', FN_BAS_LOAD_GWA_NAME ( A.INPUT_PART, SYSDATE ))       GWA_NAME          "
            //            + "      , A.JUNDAL_TABLE_OUT                                                     "
            //            + "      , A.JUNDAL_PART_OUT                                                      "
            //            + "      , A.MOVE_PART                                                            "
            //            + "      , A.JUNDAL_TABLE_INP                                                     "
            //            + "      , A.JUNDAL_PART_INP                                                      "
            //            + "      , FN_BAS_LOAD_GWA_NAME ( A.JUNDAL_PART_OUT, SYSDATE)   GWA_NAME_OUT      "
            //            + "      , FN_BAS_LOAD_GWA_NAME ( A.JUNDAL_PART_INP, SYSDATE)   GWA_NAME_INP      "
            //            + "      , FN_BAS_LOAD_GWA_NAME ( A.MOVE_PART, SYSDATE)         MOVE_PART_NAME    "
            //            + "      , A.START_DATE                                                           "
            //            + "      , A.END_DATE                                                             "
            //            + "      , A.HOSP_CODE "
            //            + "      , A.HANGMOG_START_DATE                                                   "// ADD SHIMO
            //            + "   FROM OCS0115 A                                                              "
            //            + "  WHERE A.HANGMOG_CODE = '" + aHangmogCode + "'                                "
            //            + "    AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "'                           "
            //            + "    AND A.HANGMOG_START_DATE = TO_DATE('" + aHangmogStartDate + "','YYYY/MM/DD')"// ADD SHIMO
            //            + "  ORDER BY A.HANGMOG_CODE    ";

            this.grdOCS0115.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS0115.SetBindVarValue("f_hangmog_code", aHangmogCode);
            this.grdOCS0115.SetBindVarValue("f_hangmog_start_date", aHangmogStartDate);
            this.grdOCS0115.QueryLayout(true);
        }

        private void DataLoadOCS0113(string aHangmogCode, string aHangmogStartDate)
        //private void DataLoadOCS0113(string aHangmogCode) UPD SHIMO
        {
            //this.grdOCS0113.QuerySQL = " SELECT A.HANGMOG_CODE           "
            //             + "      , A.SEQ                    "
            //             + "      , A.DEFAULT_YN             "
            //             + "      , A.SPECIMEN_CODE          "
            //             + "      , B.SPECIMEN_NAME          "
            //             + "      , A.HOSP_CODE              "
            //             + "      , A.HANGMOG_START_DATE     "// ADD SHIMO
            //             + "   FROM OCS0116 B                "
            //             + "      , OCS0113 A                "
            //             + "  WHERE A.HANGMOG_CODE  = '" + aHangmogCode + "' "
            //             + "    AND A.HOSP_CODE     = '" + EnvironInfo.HospCode + "' "
            //             + "    AND A.SPECIMEN_CODE = B.SPECIMEN_CODE "
            //             + "    AND A.HANGMOG_START_DATE =TO_DATE('" + aHangmogStartDate + "','YYYY/MM/DD') " // ADD SHIMO
            //             + "  ORDER BY A.SEQ                 ";

            this.grdOCS0113.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS0113.SetBindVarValue("f_hangmog_code", aHangmogCode);
            this.grdOCS0113.SetBindVarValue("f_hangmog_start_date", aHangmogStartDate);
            this.grdOCS0113.QueryLayout(true);
        }

        private string LoadKatakanaFull(string aText)
        {
            //string cmd = " SELECT FN_ADM_CONVERT_KATAKANA_FULL ('" + aText + "' )" +
            //             "   FROM SYS.DUAL ";

            //object retValue = Service.ExecuteScalar(cmd);

            //if (retValue == null || TypeCheck.IsNull(retValue))
            //    return "";

            //return retValue.ToString();

            // updated by Cloud
            string result = string.Empty;

            OCS0103U00LoadKanaFullArgs args = new OCS0103U00LoadKanaFullArgs();
            args.Text = aText;
            args.HospCode = mHospCode;
            OCS0103U00StringResult res = CloudService.Instance.Submit<OCS0103U00StringResult, OCS0103U00LoadKanaFullArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                result = res.ResStr;
            }

            return result;
        }

        private void Insert_OCS0103(int aCurrentRow)
        {

            int insertRow = this.grdOCS0103.InsertRow(aCurrentRow);

            //Slip_code가 지정되어 있는 경우에는 해당 Slip_code값을 Default로 가져간다.
            string slip_code = "";
            if (fbxQrySlipCode.GetDataValue() != "")
                slip_code = fbxQrySlipCode.GetDataValue().Trim();

            // 시작일자 종료일자
            this.dtpStartDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            this.dtpStartDate.AcceptData();

            // 종료일자
            this.dtpEndDate.SetEditValue("9998/12/31");
            this.dtpEndDate.AcceptData();

            if (slip_code != "")
            {
                this.fbxSlipCode.SetEditValue(slip_code);
                this.fbxSlipCode.AcceptData();
            }

            //Dafault Value
            grdOCS0103.SetItemValue(insertRow, "group_yn", "N"); ;

            // Position 
            this.cboPosition.SetEditValue("1");
            this.cboPosition.AcceptData();
            

            //원외여부는 Z으로 가져간다. default
            this.cboWonyoiOrderYN.SetEditValue("Z");
            this.cboWonyoiOrderYN.AcceptData();

            //진료지원처방, 간호처방
            this.cbxSupplyInputYN.SetEditValue("Y");
            this.cbxSupplyInputYN.AcceptData();

            this.cbxNurseInputYN.SetEditValue("Y");
            this.cbxNurseInputYN.AcceptData();

            //응급
            this.cboEmergency.SetEditValue("Z");
            this.cboEmergency.AcceptData();

            //default 수량
            this.emkDefaultSuryang.SetEditValue("1");
            this.emkDefaultSuryang.AcceptData();

            // DISPLAY YN
            this.grdOCS0103.SetItemValue(insertRow, "display_yn", "Y");

            this.txtHangmogCode.Focus();
            txtHangmogCode.SelectAll();

            // Hosp Code
            this.grdOCS0103.SetItemValue(insertRow, "hosp_code", EnvironInfo.HospCode);
        }

        private void Insert_OCS0108(int aCurrentRow)
        {
            int newRow = this.grdOCS0108.InsertRow(aCurrentRow);

            this.grdOCS0108.SetItemValue(newRow, "hangmog_code", this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"));

            this.grdOCS0108.SetItemValue(newRow, "hosp_code", EnvironInfo.HospCode);


            this.grdOCS0108.SetItemValue(newRow, "hangmog_start_date", this.dtpStartDate.GetDataValue());
        }

        private void Insert_OCS0115(int aCurrentRow)
        {
            int newRow = this.grdOCS0115.InsertRow(aCurrentRow);

            this.grdOCS0115.SetItemValue(newRow, "hangmog_code", this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"));
            this.grdOCS0115.SetItemValue(newRow, "input_gwa", "*");
            this.grdOCS0115.SetItemValue(newRow, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));// 今日を入力する
            //this.grdOCS0115.SetItemValue(newRow, "start_date", this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "start_date"));

            this.grdOCS0115.SetItemValue(newRow, "hosp_code", EnvironInfo.HospCode);

            this.grdOCS0115.SetItemValue(newRow, "hangmog_start_date", this.dtpStartDate.GetDataValue());
        }

        private void Insert_OCS0113(int aCurrentRow)
        {
            int newRow = this.grdOCS0113.InsertRow(aCurrentRow);

            this.grdOCS0113.SetItemValue(newRow, "hangmog_code", this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"));

            this.grdOCS0113.SetItemValue(newRow, "hosp_code", EnvironInfo.HospCode);

            this.grdOCS0113.SetItemValue(newRow, "hangmog_start_date", this.dtpStartDate.GetDataValue());

        }

        private bool UpdateCheck()
        {
            this.mMsg = "";
            this.mCap = Resources.MSG001_CAP;
            int rowIndex = -1;

            // OCS0103 Check

            #region OCS0103

            for (rowIndex = 0; rowIndex < this.grdOCS0103.RowCount; rowIndex++)
            {
                if (this.grdOCS0103.GetRowState(rowIndex) != DataRowState.Unchanged)
                {
                    // 항목코드 체크
                    if (this.grdOCS0103.GetItemString(rowIndex, "hangmog_code") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG002_MSG;
                    }

                    // 항목명칭 체크
                    if (this.grdOCS0103.GetItemString(rowIndex, "hangmog_name") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG003_MSG;
                    }

                    // 기본검체 체크 
                    if (this.grdOCS0103.GetItemString(rowIndex, "specimen_yn") == "Y" && this.grdOCS0103.GetItemString(rowIndex, "specimen_default") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG004_MSG;
                    }

                    // 재료코드
                    if (this.grdOCS0103.GetItemString(rowIndex, "jaeryo_yn") == "Y" && this.grdOCS0103.GetItemString(rowIndex, "jaeryo_code") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG005_MSG;
                    }

                    // 점수코드
                    if (this.grdOCS0103.GetItemString(rowIndex, "suga_yn") == "Y" && this.grdOCS0103.GetItemString(rowIndex, "sg_code") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG006_MSG;
                    }

                    //2015/08/11: added by Cloud due to MED-2617
                    if (this.grdOCS0103.GetItemString(rowIndex, "jundal_part_out_name") == "" || this.grdOCS0103.GetItemString(rowIndex, "jundal_table_out") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG046_MSG;
                    }

                    if (this.grdOCS0103.GetItemString(rowIndex, "jundal_part_inp_name") == "" || this.grdOCS0103.GetItemString(rowIndex, "jundal_table_inp") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG047_MSG;
                    }

                    if (String.IsNullOrEmpty(this.grdOCS0103.GetItemString(rowIndex, "slip_code")))
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG048_MSG;
                    }
                }
            }

            if (this.mMsg != "")
            {
                this.mMsg = Resources.MSG007_MSG +
                            this.mMsg;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            #endregion

            // OCS0108 Check

            #region OCS0108

            for (rowIndex = 0; rowIndex < this.grdOCS0108.RowCount; rowIndex++)
            {
                if (this.grdOCS0108.GetRowState(rowIndex) != DataRowState.Unchanged)
                {
                    if (this.grdOCS0108.GetItemString(rowIndex, "hangmog_code") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG002_MSG;
                    }

                    if (this.grdOCS0108.GetItemString(rowIndex, "ord_danui") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG008_MSG;
                    }

                    if (this.grdOCS0108.GetItemString(rowIndex, "change_qty1") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG009_MSG;
                    }

                    if (this.grdOCS0108.GetItemString(rowIndex, "change_qty2") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG010_MSG;
                    }
                }
            }

            if (this.mMsg != "")
            {
                this.mMsg = Resources.MSG011_MSG +
                            this.mMsg;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            #endregion

            // OCS0115 Check

            #region OCS0115

            for (rowIndex = 0; rowIndex < this.grdOCS0115.RowCount; rowIndex++)
            {
                if (this.grdOCS0115.GetRowState(rowIndex) != DataRowState.Unchanged)
                {
                    if (this.grdOCS0115.GetItemString(rowIndex, "hangmog_code") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG002_MSG;
                    }

                    if (this.grdOCS0115.GetItemString(rowIndex, "jundal_part_out") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG012_MSG;
                    }

                    if (this.grdOCS0115.GetItemString(rowIndex, "jundal_part_inp") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG013_MSG;
                    }

                    if (this.grdOCS0115.GetItemString(rowIndex, "move_part") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG014_MSG;
                    }
                }
            }

            if (this.mMsg != "")
            {
                this.mMsg = Resources.MSG015_MSG +
                            this.mMsg;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            #endregion

            // OCS0113 Check

            #region OCS0113

            for (rowIndex = 0; rowIndex < this.grdOCS0113.RowCount; rowIndex++)
            {
                if (this.grdOCS0113.GetRowState(rowIndex) != DataRowState.Unchanged)
                {
                    if (this.grdOCS0113.GetItemString(rowIndex, "hangmog_code") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG002_MSG;
                    }

                    if (this.grdOCS0113.GetItemString(rowIndex, "specimen_code") == "")
                    {
                        this.mMsg += (rowIndex + 1).ToString() + Resources.MSG016_MSG;
                    }
                }
            }

            if (this.mMsg != "")
            {
                this.mMsg = Resources.MSG017_MSG +
                            this.mMsg;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            #endregion

            return true;
        }

        private bool IsExistModifiedData(XEditGrid aGrid)
        {

            // 삭제 데이터 체크 
            if (aGrid.DeletedRowTable != null &&
                aGrid.DeletedRowCount > 0)
            {
                return true;
            }

            // 변경건 체크 
            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (aGrid.GetRowState(i) != DataRowState.Unchanged)
                {
                    return true;
                }
            }

            return false;
        }

        private void SetFindWorker(bool aIsGridControl, string aGridName, string aControlName)
        {
            bool isQueryCloud = false;

            if (aIsGridControl)
            {
                #region 그리드 컨트롤 일때의 파인드 워커 셋팅

                switch (aGridName)
                {
                    case "grdOCS0108": // 환산수량 그리드

                        #region 환산수량 그리드

                        // 단위
                        if (aControlName == "ord_danui")
                        {
                            this.fwkCommon.ColInfos.Clear();

                            this.fwkCommon.ServerFilter = false;
                            this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                            this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                            this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                            //this.fwkCommon.InputSQL = " SELECT A.CODE " +
                            //                          "      , A.CODE_NAME " +
                            //                          "   FROM OCS0132 A " +
                            //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                            //                          "    AND A.CODE_TYPE = 'ORD_DANUI' " +
                            //                          "  ORDER BY A.SLIP_CODE ";

                            isQueryCloud = true;
                        }

                        #endregion

                        break;

                    case "grdOCS0115":  // 진료과별 전달파트 그리드 

                        #region 진료과별 전달파트 그리드

                        if (aControlName == "input_part")
                        {
                            #region 입력부서

                            this.fwkCommon.ColInfos.Clear();

                            this.fwkCommon.ServerFilter = false;
                            this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                            this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                            this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                            //this.fwkCommon.InputSQL = " SELECT '*', FN_ADM_MSG(221) " +
                            //                          "   FROM DUAL " +
                            //                          "  UNION ALL " +
                            //                          " SELECT A.GWA " +
                            //                          "      , A.GWA_NAME " +
                            //                          "   FROM BAS0260 A " +
                            //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                            //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                            //                          "    AND A.GWA IS NOT NULL " +
                            //                          "    AND A.BUSEO_GUBUN = '1' " +
                            //                          "  ORDER BY 1 ";

                            isQueryCloud = true;

                            #endregion
                        }
                        else if (aControlName == "jundal_part_out")
                        {
                            #region 외래 전달 파트

                            this.fwkCommon.ColInfos.Clear();

                            this.fwkCommon.ServerFilter = false;

                            this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                            this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                            this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;


                            //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                            //                          "      , A.GWA_NAME " +
                            //                          "   FROM BAS0260 A," +
                            //                          "　　　  OCS0128 B " +
                            //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                            //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                            //                          "    AND A.GWA IS NOT NULL " +
                            //                          "    AND A.OUT_JUNDAL_PART_YN = 'Y' " +
                            //                          "    AND B.HOSP_CODE = A.HOSP_CODE " +
                            //                          "    AND B.IO_GUBUN = 'O' " +
                            //                          "    AND B.JUNDAL_PART = A.GWA " +
                            //                          "  ORDER BY A.GWA "; // FwkCommonJundalPartOutRequest

                            //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                            //                          "      , A.GWA_NAME " +
                            //                          "   FROM BAS0260 A " +
                            //                          "  WHERE A.OUT_JUNDAL_PART_YN = 'Y' " +
                            //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                            //                          "    AND A.GWA IS NOT NULL " +
                            //                          "    AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   " +
                            //                          "  ORDER BY A.GWA ";

                            isQueryCloud = true;

                            #endregion
                        }
                        else if (aControlName == "jundal_part_inp")
                        {

                            #region 입원 전달 파트

                            this.fwkCommon.ColInfos.Clear();

                            this.fwkCommon.ServerFilter = false;

                            this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                            this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                            this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                            //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                            //                          "      , A.GWA_NAME " +
                            //                          "   FROM BAS0260 A," +
                            //                          "　　　  OCS0128 B " +
                            //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                            //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                            //                          "    AND A.GWA IS NOT NULL " +
                            //                          "    AND A.OUT_JUNDAL_PART_YN = 'Y' " +
                            //                          "    AND B.HOSP_CODE = A.HOSP_CODE " +
                            //                          "    AND B.IO_GUBUN = 'I' " +
                            //                          "    AND B.JUNDAL_PART = A.GWA " +
                            //                          "  ORDER BY A.GWA ";


                            //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                            //                          "      , A.GWA_NAME " +
                            //                          "   FROM BAS0260 A " +
                            //                          "  WHERE A.INP_JUNDAL_PART_YN = 'Y' " +
                            //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                            //                          "    AND A.GWA IS NOT NULL " +
                            //                          "    AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   " +
                            //                          "  ORDER BY A.GWA ";

                            isQueryCloud = true;

                            #endregion
                        }
                        else if (aControlName == "move_part")
                        {
                            #region 이동부서

                            this.fwkCommon.ColInfos.Clear();

                            this.fwkCommon.ServerFilter = false;

                            this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                            this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                            this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                            //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                            //                          "      , A.GWA_NAME " +
                            //                          "   FROM BAS0260 A " +
                            //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                            //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                            //                          "    AND A.GWA IS NOT NULL " +
                            //                          "    AND A.OUT_MOVE_YN = 'Y' " +
                            //                          "  ORDER BY A.GWA ";

                            isQueryCloud = true;

                            #endregion
                        }

                        #endregion

                        break;

                    case "grdOCS0113": // 항목별 검체 그리드

                        #region 항목별 검체 그리드

                        if (aControlName == "specimen_code")
                        {
                            this.fwkCommon.ColInfos.Clear();

                            this.fwkCommon.ServerFilter = false;

                            this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                            this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                            this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                            //this.fwkCommon.InputSQL = " SELECT A.SPECIMEN_CODE "
                            //                        + "      , A.SPECIMEN_NAME "
                            //                        + "   FROM OCS0116 A       "
                            //                        + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                            //                        + "  ORDER BY A.SPECIMEN_CODE  ";

                            isQueryCloud = true;
                        }

                        #endregion

                        break;
                }

                #endregion
            }
            else
            {
                #region 일반 컨트롤 일때의 파인드 워커 셋팅

                switch (aControlName)
                {

                    case "fbxQrySlipCode":
                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;
                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.SLIP_CODE " +
                        //                          "      , A.SLIP_NAME " +
                        //                          "   FROM OCS0102 A " +
                        //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   " +
                        //                          "    AND A.SLIP_GUBUN LIKE '" + TypeCheck.NVL(this.cboQrySlipGubun.GetDataValue(), "%") + "' " +
                        //                          "  ORDER BY A.SLIP_CODE ";

                        isQueryCloud = true;

                        break;

                    case "fbxSlipCode":

                        #region 서식지 조회

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;
                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.SLIP_CODE " +
                        //                          "      , A.SLIP_NAME " +
                        //                          "   FROM OCS0102 A " +
                        //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   " +
                        //                          "  ORDER BY A.SLIP_CODE ";

                        isQueryCloud = true;

                        #endregion

                        break;

                    case "fbxSpecificComment":

                        #region 의뢰서

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.SPECIFIC_COMMENT " +
                        //                          "      , A.SPECIFIC_COMMENT_NAME " +
                        //                          "   FROM OCS0170 A " +
                        //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   " +
                        //                          "  ORDER BY A.SPECIFIC_COMMENT ";

                        isQueryCloud = true;

                        #endregion

                        break;

                    case "fbxJundalPartOut":

                        #region 외래 전달파트

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                        //                          "      , A.GWA_NAME " +
                        //                          "   FROM BAS0260 A," +
                        //                          "　　　  OCS0128 B " +
                        //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                        //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //                          "    AND A.GWA IS NOT NULL " +
                        //                          "    AND A.OUT_JUNDAL_PART_YN = 'Y' " +
                        //                          "    AND B.HOSP_CODE = A.HOSP_CODE " +
                        //                          "    AND B.IO_GUBUN = 'O' " +
                        //                          "    AND B.JUNDAL_PART = A.GWA " +
                        //                          "  ORDER BY A.GWA ";


                        //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                        //                          "      , A.GWA_NAME " +
                        //                          "   FROM BAS0260 A " +
                        //                          "  WHERE A.OUT_JUNDAL_PART_YN = 'Y' " +
                        //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //                          "    AND A.GWA IS NOT NULL " +
                        //                          "    AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   " +
                        //                          "  ORDER BY A.GWA ";

                        isQueryCloud = true;

                        #endregion

                        break;

                    case "fbxJundalPartInp":

                        #region 입원 전달파트

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                        //                          "      , A.GWA_NAME " +
                        //                          "   FROM BAS0260 A, " +
                        //                          "        OCS0128 B " +
                        //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                        //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //                          "    AND A.GWA IS NOT NULL " +
                        //                          "    AND A.INP_JUNDAL_PART_YN = 'Y' " +
                        //                          "    AND B.HOSP_CODE   = A.HOSP_CODE " +
                        //                          "    AND B.IO_GUBUN    = 'I' " +
                        //                          "    AND B.JUNDAL_PART = A.GWA " +
                        //                          "  ORDER BY A.GWA ";

                        //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                        //                          "      , A.GWA_NAME " +
                        //                          "   FROM BAS0260 A " +
                        //                          "  WHERE A.INP_JUNDAL_PART_YN = 'Y' " +
                        //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //                          "    AND A.GWA IS NOT NULL " +
                        //                          "    AND A.HOSP_CODE = '" + EnvironInfo.HospCode + "'   " +
                        //                          "  ORDER BY A.GWA ";

                        isQueryCloud = true;

                        #endregion

                        break;

                    case "fbxMovePart":

                        #region 이동부서

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.GWA " +
                        //                          "      , A.GWA_NAME " +
                        //                          "   FROM BAS0260 A " +
                        //                          "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
                        //                          "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE " +
                        //                          "    AND A.GWA IS NOT NULL " +
                        //                          "    AND A.OUT_MOVE_YN = 'Y'   " +
                        //                          "  ORDER BY A.GWA ";

                        isQueryCloud = true;

                        #endregion

                        break;

                    case "fbxBogyongCode": // 오더 구분이 주사인 경우만 여기를 콜함 약인경우는 복용코드 쿼리용 화면을 콜함.

                        #region 주사방법

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.CODE, A.CODE_NAME "
                        //                        + "   FROM OCS0132 A "
                        //                        + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                        //                        + "    AND A.CODE_TYPE = 'JUSA' "
                        //                        + "  ORDER BY A.CODE ";

                        isQueryCloud = true;

                        #endregion

                        break;

                    case "fbxSpecimenDefault":

                        #region 오더별 기본검체

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.SPECIMEN_CODE "
                        //                        + "      , B.SPECIMEN_NAME "
                        //                        + "   FROM OCS0116 B "
                        //                        + "      , OCS0113 A "
                        //                        + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                        //                        + "    AND A.HANGMOG_CODE = '" + this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code") + "' "
                        //                        + "    AND B.HOSP_CODE     = A.HOSP_CODE "
                        //                        + "    AND B.SPECIMEN_CODE = A.SPECIMEN_CODE "
                        //                        + "  ORDER BY A.SPECIMEN_CODE  ";

                        isQueryCloud = true;

                        #endregion

                        break;

                    case "fbxPatStatusGr":

                        #region 환자 상태 구분

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.PAT_STATUS_GR, A.PAT_STATUS_GR_NAME "
                        //                        + "   FROM OCS0803 A "
                        //                        + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                        //                        + "  ORDER BY A.PAT_STATUS_GR ";

                        isQueryCloud = true;

                        #endregion

                        break;

                    case "fbxJaeryoCode":

                        #region 재료코드

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;

                        this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                        //this.fwkCommon.InputSQL = " SELECT A.JAERYO_CODE, A.JAERYO_NAME "
                        //                        + "   FROM INV0110 A "
                        //                        + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                        //                        + "    AND A.JAERYO_NAME_INX LIKE '%'||:f_find1 ||'%' "
                        //                        + "  ORDER BY A.JAERYO_CODE ";

                        isQueryCloud = true;

                        #endregion

                        break;

                    case "fbxYJ_CODE":

                        #region YJ_CODE

                        this.fwkCommon.ColInfos.Clear();

                        this.fwkCommon.ServerFilter = false;
                        this.fwkCommon.ColInfos.Add("yj_code", Resources.FWKCOMMON_YJ_CODE_TEXT, FindColType.String, 100, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("hot_code", Resources.FWKCOMMON_HOT_CODE_TEXT, FindColType.String, 100, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("yak_kijun_code", Resources.FWKCOMMON_YAK_KIJUN_CODE_TEXT, FindColType.String, 100, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("sg_code", Resources.FWKCOMMON_SG_CODE_TEXT, FindColType.String, 100, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("sale_name", Resources.FWKCOMMON_SALE_NAME_TEXT, FindColType.String, 100, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("created_company_name", Resources.FWKCOMMON_CREATED_COMPANY_NAME_TEXT, FindColType.String, 100, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("saled_company_name", Resources.FWKCOMMON_SALED_COMPANY_NAME_TEXT, FindColType.String, 100, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos.Add("pack_danui_suryang", Resources.FWKCOMMON_PACK_DANUI_SURYANG_TEXT, FindColType.String, 100, 0, true, FilterType.InitYes);
                        this.fwkCommon.ColInfos.Add("pack_total_suryang", Resources.FWKCOMMON_PACK_TOTAL_SURYANG_TEXT, FindColType.String, 100, 0, true, FilterType.InitYes);

                        this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

//                        this.fwkCommon.InputSQL = @"   SELECT A.A8  YJ_CODE
//                                                            , A.A1  HOT_CODE
//                                                            , A.A7  YAK_KIJUN_CODE                                                            
//                                                            , A.A9  SG_CODE                                                            
//                                                            , A.A12 SALE_NAME
//                                                            , A.A21 CREATED_COMPANY_NAME
//                                                            , A.A22 SALED_COMPANY_NAME
//                                                            , A.A16 
//                                                            , A.A18 
//                                                         FROM ADM9983 A
//                                                        WHERE A.A9 = '" + this.fbxSgCode.GetDataValue() + @"'
//                                                          AND A.A7 = '" + this.txtYAK_KIJUN_CODE.Text + @"'
//                                                        
//                                                        ORDER BY A.A8, A.A1";

                        isQueryCloud = true;

                        #endregion

                        break;

                }

                #endregion
            }

            // updated by Cloud
            if (isQueryCloud)
            {
                this.fwkCommon.ParamList = new List<string>(new string[]
                    {
                        "f_is_grid_control",
                        "f_grid_name",
                        "f_control_name",
                        "f_slip_gubun",
                        "f_sg_code",
                        "f_kijun_code",
                        "f_hangmog_code",
                    });
                this.fwkCommon.SetBindVarValue("f_is_grid_control"  , aIsGridControl.ToString());
                this.fwkCommon.SetBindVarValue("f_grid_name"        , aGridName);
                this.fwkCommon.SetBindVarValue("f_control_name"     , aControlName);
                this.fwkCommon.SetBindVarValue("f_slip_gubun"       , TypeCheck.NVL(this.cboQrySlipGubun.GetDataValue(), "%").ToString());
                this.fwkCommon.SetBindVarValue("f_sg_code"          , this.fbxSgCode.GetDataValue());
                this.fwkCommon.SetBindVarValue("f_kijun_code"       , this.txtYAK_KIJUN_CODE.Text);
                this.fwkCommon.SetBindVarValue("f_hangmog_code"     , this.grdOCS0103.GetItemString(this.grdOCS0103.CurrentRowNumber, "hangmog_code"));
                this.fwkCommon.ExecuteQuery = GetFindWorker;
            }
        }

        private string GetJundalTable(string aIOGubun, string aJundalPart, string aStartDate)
        {
            //string cmd = "";
            //string jundalTable = "";

            //cmd = "SELECT A.JUNDAL_TABLE " +
            //     "   FROM OCS0128 A " +
            //     "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' " +
            //     "    AND A.JUNDAL_PART = '" + aJundalPart + "' " +
            //     "    AND TO_DATE('" + aStartDate + "', 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE " +
            //     "    AND A.IO_GUBUN = '" + aIOGubun + "' ";

            //if (Service.ExecuteScalar(cmd) == null)
            //{
            //    jundalTable = "";
            //}
            //else
            //{
            //    jundalTable = Service.ExecuteScalar(cmd).ToString();
            //}

            //return jundalTable;

            // Updated by Cloud
            OCS0103U00GetJundalTableArgs args = new OCS0103U00GetJundalTableArgs();
            args.IoGubun = aIOGubun;
            args.JundalPart = aJundalPart;
            args.StartDate = aStartDate;
            args.HospCode = mHospCode;
            OCS0103U00StringResult res = CloudService.Instance.Submit<OCS0103U00StringResult, OCS0103U00GetJundalTableArgs>(args);

            return res.ExecutionStatus == ExecutionStatus.Success ? res.ResStr : string.Empty;
        }

        // 컨트롤 데이터 벨리데이팅 후 입력컨트롤 프로텍트를 위한 Post Method
        private void PostValidating_Protect()
        {
            this.ProtectInputControl(this.grdOCS0103.CurrentRowNumber);
        }

        private void PostComboControl()
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            // grdOCS0103
            grdOCS0103.ParamList = new List<string>(new string[]
                {
                    "f_slip_code",
                    "f_hangmog_inx",
                    "f_slip_gubun",
                    "f_used_yn",
                    "f_wonnae_yn",
                    "f_page_number"
                });
            grdOCS0103.ExecuteQuery = GetGrdOCS0103;

            // grdOCS0108
            grdOCS0108.ParamList = new List<string>(new string[]
                {
                    "f_hangmog_code",
                    "f_hangmog_start_date",
                });
            grdOCS0108.ExecuteQuery = GetGrdOCS0108;

            // grdOCS0113
            grdOCS0113.ParamList = new List<string>(new string[]
                {
                    "f_hangmog_code",
                    "f_hangmog_start_date",
                });
            grdOCS0113.ExecuteQuery = GetGrdOCS0113;

            // grdOCS0115
            grdOCS0115.ParamList = new List<string>(new string[]
                {
                    "f_hangmog_code",
                    "f_hangmog_start_date",
                });
            grdOCS0115.ExecuteQuery = GetGrdOCS0115;

            // Combobox          
            layDanui.ExecuteQuery               = GetLayDanui;
            cboQrySlipGubun.ExecuteQuery        = GetCboQrySlipGubun;
            cboResultGubun.ExecuteQuery         = GetCboResultGubun;
            cboIfInputControl.ExecuteQuery      = GetCboIfInputControl;
            cboEmergency.ExecuteQuery           = GetCboEmergency;
            cboSubulConvertGubun.ExecuteQuery   = GetCboSubulConvertGubun;
            cboWonyoiOrderYN.ExecuteQuery       = GetCboWonyoiOrderYN;
            cboDvTime.ExecuteQuery              = GetCboDvTime;
            cboOrdDanui.ExecuteQuery            = GetCboOrdDanui;
            cboInputControl.ExecuteQuery        = GetCboInputControl;
            cboOrderGubun.ExecuteQuery          = GetCboOrderGubun;
            //cboDvTime.SelectedIndex = 0;
            
            //set comboBox
            //cboQrySlipGubun.SetDictDDLB();
            //cboResultGubun.SetDictDDLB();
            //cboIfInputControl.SetDictDDLB();
            //cboEmergency.SetDictDDLB();
            //cboSubulConvertGubun.SetDictDDLB();
            //cboWonyoiOrderYN.SetDictDDLB();
            //cboDvTime.SetDictDDLB();
            //cboOrdDanui.SetDictDDLB();
            //cboInputControl.SetDictDDLB();
            //cboOrderGubun.SetDictDDLB();
        }
        #endregion

        #region GetGrdOCS0103
        /// <summary>
        /// GetGrdOCS0103
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOCS0103(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U00GrdOCS0103Args args   = new OCS0103U00GrdOCS0103Args();
            args.HangmogInx                 = bvc["f_hangmog_inx"].VarValue;
            args.SlipCode                   = bvc["f_slip_code"].VarValue;
            args.SlipGubun                  = bvc["f_slip_gubun"].VarValue;
            args.UsedYn                     = bvc["f_used_yn"].VarValue;
            args.WonnaeYn                   = bvc["f_wonnae_yn"].VarValue;
            args.HospCode = mHospCode;
            args.PageNumber = bvc["f_page_number"].VarValue;
            args.Offset = "200";
            OCS0103U00GrdOCS0103Result res = CloudService.Instance.Submit<OCS0103U00GrdOCS0103Result, OCS0103U00GrdOCS0103Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdOcs0103Item.ForEach(delegate(OCS0103U00GrdOCS0103Info item)
                {
                    lObj.Add(new object[]
                    {
                        
                        
                        item.SysDate,
                        item.SysId,
                        item.UpdDate,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SlipCode,
                        item.GroupYn,
                        item.Position,
                        item.Seq,
                        item.OrderGubun,
                        item.InputControl,
                        item.JundalTableOut,
                        item.JundalTableInp,
                        item.JundalPartOut,
                        item.JundalPartInp,
                        item.MovePart,
                        item.DvTime,
                        item.OrdDanui,
                        item.DefaultBogyongCode,
                        item.SugaYn,
                        item.SgCode,
                        item.JaeryoYn,
                        item.JaeryoCode,
                        item.HangmogNameInx,
                        item.DisplayYn,
                        item.StartDate,
                        item.EndDate,
                        item.SpecimenYn,
                        item.SpecimenDefault,
                        item.DefaultPortableYn1,
                        item.SpecificComment,
                        item.ReserYnOut,
                        item.ReserYnInp,
                        item.Emergency,
                        item.LimitSuryang,
                        item.BomYn,
                        item.ReturnYn,
                        item.SubulConvertGubun,
                        item.WonyoiOrderYn,
                        item.DefaultWonnaeSayu,
                        item.AntiCancerYn,
                        item.ChisikYn,
                        item.NdayYn,
                        item.MuhyoYn,
                        item.InvJundalYn,
                        item.PowderYn,
                        item.Remark,
                        item.DefaultDv,
                        item.DefaultSuryang,
                        item.NurseInputYn,
                        item.SupplyInputYn,
                        item.LimitNalsu,
                        item.DefaultWonyoiYn,
                        item.PortableCheck,
                        item.PatStatusGr,
                        item.UpdId,
                        item.HospCode,
                        item.DefaultJusa,
                        item.SlipName,
                        item.JundalPartOutName,
                        item.JundalPartInpName,
                        item.MovePartName,
                        item.JaeryoName,
                        item.SubulDanuiName,
                        item.JearyoBulyongDate,
                        item.DefaultBogyongName,
                        item.IfInputControl,
                        item.HubalDrgYn,
                        item.SgName,
                        item.SgDanuiName,
                        item.BulyongYmd,
                        item.ResultGubun,
                        item.WonnaeDrgYn,
                        //item.OutHospBookYn,
                        item.YakKijunCode,
                        item.YjCode,
                        item.IfCode,
                        item.Trial,
                        item.Protocol,
                        string.IsNullOrEmpty(item.CommonOrder) ? "N" :  item.CommonOrder,
                        item.DefaultPortableYn2
                        
                        
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdOCS0108
        /// <summary>
        /// GetGrdOCS0108
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOCS0108(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U00GrdOCS0108Args args = new OCS0103U00GrdOCS0108Args();
            args.HangmogCode = bvc["f_hangmog_code"].VarValue;
            args.HangmogStartDate = bvc["f_hangmog_start_date"].VarValue;
            args.HospCode = mHospCode;
            OCS0103U00GrdOCS0108Result res = CloudService.Instance.Submit<OCS0103U00GrdOCS0108Result, OCS0103U00GrdOCS0108Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdOcs0108Item.ForEach(delegate(OCS0103U00GrdOCS0108Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.HangmogCode,
                        item.OrdDanui,
                        item.Seq,
                        item.SunabGijun,
                        item.SubulGijun,
                        item.HospCode,
                        item.HangmogStartDate,
                        item.CodeName1,
                        item.CodeName2,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdOCS0113
        /// <summary>
        /// GetGrdOCS0113
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOCS0113(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U00GrdOCS0113Args args = new OCS0103U00GrdOCS0113Args();
            args.HangmogCode = bvc["f_hangmog_code"].VarValue;
            args.HangmogStartDate = bvc["f_hangmog_start_date"].VarValue;
            args.HospCode = mHospCode;
            OCS0103U00GrdOCS0113Result res = CloudService.Instance.Submit<OCS0103U00GrdOCS0113Result, OCS0103U00GrdOCS0113Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdOcs0113Item.ForEach(delegate(OCS0103U00GrdOCS0113Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.HangmogCode,
                        item.Seq,
                        item.DefaultYn,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.HospCode,
                        item.HangmogStartDate,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdOCS0115
        /// <summary>
        /// GetGrdOCS0115
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOCS0115(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U00GrdOCS0115Args args = new OCS0103U00GrdOCS0115Args();
            args.HangmogCode = bvc["f_hangmog_code"].VarValue;
            args.HangmogStartDate = bvc["f_hangmog_start_date"].VarValue;
            args.HospCode = mHospCode;
            OCS0103U00GrdOCS0115Result res = CloudService.Instance.Submit<OCS0103U00GrdOCS0115Result, OCS0103U00GrdOCS0115Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdOcs115Item.ForEach(delegate(OCS0103U00GrdOCS0115Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.HangmogCode,
                        item.InputGwa,
                        item.InputPart,
                        item.GwaName,
                        item.JundalTableOut,
                        item.JundalPartOut,
                        item.MovePart,
                        item.JundalTableInp,
                        item.JundalPartInp,
                        item.GwaNameOut,
                        item.GwaNameInp,
                        item.MovePartName,
                        item.StartDate,
                        item.EndDate,
                        item.HospCode,
                        item.HangmogStartDate,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayDanui
        /// <summary>
        /// GetLayDanui
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayDanui(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //ComboOrdDanuiArgs args = new ComboOrdDanuiArgs();
            //args.IsAll = false;
            //args.HospCode = mHospCode;
            ////ComboResult res = CacheService.Instance.Get<ComboOrdDanuiArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS_COMBO_ORD_DANUI_KEYS,
            ////    new ComboOrdDanuiArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, ComboOrdDanuiArgs>(args);

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.OrderDanuiItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboQrySlipGubun
        /// <summary>
        /// GetCboQrySlipGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboQrySlipGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //OCS0103U00CboSlipGubunArgs args = new OCS0103U00CboSlipGubunArgs(mHospCode);
            ////ComboResult res = CacheService.Instance.Get<OCS0103U00CboSlipGubunArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS0103U00_CBO_SLIP_GUBUN,
            ////    new OCS0103U00CboSlipGubunArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboSlipGubunArgs>(args);
            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.SlipGubunItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboResultGubun
        /// <summary>
        /// GetCboResultGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboResultGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //OCS0103U00CboResultGubunArgs args = new OCS0103U00CboResultGubunArgs(mHospCode);
            ////ComboResult res = CacheService.Instance.Get<OCS0103U00CboResultGubunArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS0103U00_CBO_RESULT_GUBUN,
            ////    new OCS0103U00CboResultGubunArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboResultGubunArgs>(args);
            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.ResultGubunItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboIfInputControl
        /// <summary>
        /// GetCboIfInputControl
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboIfInputControl(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //OCS0103U00CboIfInputControlArgs args = new OCS0103U00CboIfInputControlArgs(mHospCode);
            ////ComboResult res = CacheService.Instance.Get<OCS0103U00CboIfInputControlArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS0103U00_CBO_IF_INPUT_CONTROL,
            ////    new OCS0103U00CboIfInputControlArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboIfInputControlArgs>(args);

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.IfInputControlItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboEmergency
        /// <summary>
        /// GetCboEmergency
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboEmergency(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //OCS0103U00CboEmergencyArgs args = new OCS0103U00CboEmergencyArgs(mHospCode);
            ////ComboResult res = CacheService.Instance.Get<OCS0103U00CboEmergencyArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS0103U00_CBO_EMERGENCY,
            ////    new OCS0103U00CboEmergencyArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboEmergencyArgs>(args);
            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.EmergencyItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboSubulConvertGubun
        /// <summary>
        /// GetCboSubulConvertGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboSubulConvertGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //OCS0103U00CboSubulConvertGubunArgs args = new OCS0103U00CboSubulConvertGubunArgs(mHospCode);
            ////ComboResult res = CacheService.Instance.Get<OCS0103U00CboSubulConvertGubunArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS0103U00_CBO_SUBUL_CONVERT_GUBUN,
            ////    new OCS0103U00CboSubulConvertGubunArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboSubulConvertGubunArgs>(args);

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.SubunConvertGubunItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboWonyoiOrderYN
        /// <summary>
        /// GetCboWonyoiOrderYN
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboWonyoiOrderYN(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //OCS0103U00CboWonyoiOrderYnArgs args = new OCS0103U00CboWonyoiOrderYnArgs(mHospCode);
            ////ComboResult res = CacheService.Instance.Get<OCS0103U00CboWonyoiOrderYnArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS0103U00_CBO_WONYOI_ORDER_YN,
            ////    new OCS0103U00CboWonyoiOrderYnArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboWonyoiOrderYnArgs>(args);

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.WonyoiOrderYnItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboDvTime
        /// <summary>
        /// GetCboDvTime
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboDvTime(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //OCS0103U00CboDvTimeArgs args = new OCS0103U00CboDvTimeArgs(mHospCode);
            ////ComboResult res = CacheService.Instance.Get<OCS0103U00CboDvTimeArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS0103U00_CBO_DV_TIME,
            ////    new OCS0103U00CboDvTimeArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboDvTimeArgs>(args);

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.DvTimeItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboOrdDanui
        /// <summary>
        /// GetCboOrdDanui
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboOrdDanui(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            //ComboOrdDanuiArgs args = new ComboOrdDanuiArgs();
            //args.IsAll = false;
            //args.HospCode = mHospCode;
            ////ComboResult res = CacheService.Instance.Get<ComboOrdDanuiArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS_COMBO_ORD_DANUI_KEYS,
            ////    new ComboOrdDanuiArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, ComboOrdDanuiArgs>(args);

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.OrderDanuiItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboInputControl
        /// <summary>
        /// GetCboInputControl
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboInputControl(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //OCS0103U00CboInputControlArgs args = new OCS0103U00CboInputControlArgs(mHospCode);
            ////ComboResult res = CacheService.Instance.Get<OCS0103U00CboInputControlArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS0103U00_CBO_INPUT_CONTROL,
            ////    new OCS0103U00CboInputControlArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboInputControlArgs>(args);

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.InputControlItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetCboOrderGubun
        /// <summary>
        /// GetCboOrderGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboOrderGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            //OCS0103U00CboOrderGubunArgs args = new OCS0103U00CboOrderGubunArgs(mHospCode);
            ////ComboResult res = CacheService.Instance.Get<OCS0103U00CboOrderGubunArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS0103U00_CBO_ORDER_GUBUN,
            ////    new OCS0103U00CboOrderGubunArgs(), delegate(ComboResult r)
            ////    {
            ////        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            ////    });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboOrderGubunArgs>(args);

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            _comboResult.OrderGubunItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });

            return lObj;
        }
        #endregion

        #region GetFindBoxC
        /// <summary>
        /// GetFindBoxC
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFindBoxC(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS0103U00FindBoxCArgs args = new OCS0103U00FindBoxCArgs(mHospCode);
            ComboResult res = CacheService.Instance.Get<OCS0103U00FindBoxCArgs, ComboResult>(args, delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
                });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00FindBoxCArgs>(args);

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

        #region GetFindBoxD
        /// <summary>
        /// GetFindBoxD
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFindBoxD(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS0103U00FindBoxDArgs args = new OCS0103U00FindBoxDArgs(mHospCode);
            ComboResult res = CacheService.Instance.Get<OCS0103U00FindBoxDArgs, ComboResult>(args, delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
                });
            //ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00FindBoxDArgs>(args);

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

        #region GetLayCommonSgCode
        /// <summary>
        /// GetLayCommonSgCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayCommonSgCode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U00LayCommonSgCodeArgs args = new OCS0103U00LayCommonSgCodeArgs();
            args.SgCode = bvc["f_sg_code"].VarValue;
            args.StartDate = bvc["f_start_date"].VarValue;
            args.HospCode = mHospCode;
            OCS0103U00LayCommonSgCodeResult res = CloudService.Instance.Submit<OCS0103U00LayCommonSgCodeResult, OCS0103U00LayCommonSgCodeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayCommonSgItem.ForEach(delegate(OCS0103U00LayCommonInfo item)
                {
                    lObj.Add(new object[] { item.Name, item.Bulyong, item.DrgYn });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayCommonJearyoCode
        /// <summary>
        /// GetLayCommonJearyoCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayCommonJearyoCode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U00LayCommonJaeryoCodeArgs args = new OCS0103U00LayCommonJaeryoCodeArgs();
            args.JaeryoCode = bvc["f_jearyo_code"].VarValue;
            args.HospCode = mHospCode;
            ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00LayCommonJaeryoCodeArgs>(args);

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

        #region GetFindWorker
        /// <summary>
        /// GetFindWorker
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFindWorker(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U00FwkCommonArgs args    = new OCS0103U00FwkCommonArgs();
            args.IsGridControl              = Boolean.Parse(bvc["f_is_grid_control"].VarValue);
            args.ControlName                = bvc["f_control_name"].VarValue;
            args.GridName                   = bvc["f_grid_name"].VarValue;
            args.KijunCode                  = bvc["f_kijun_code"].VarValue;
            args.SgCode                     = bvc["f_sg_code"].VarValue;
            args.SlipGubun                  = bvc["f_slip_gubun"].VarValue;
            args.HangmogCode                = bvc["f_hangmog_code"].VarValue;
            args.HospCode = mHospCode;

            OCS0103U00FwkCommonResult res = CloudService.Instance.Submit<OCS0103U00FwkCommonResult, OCS0103U00FwkCommonArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.ComboItem.Count > 0)
                {
                    res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                    {
                        lObj.Add(new object[] { item.Code, item.CodeName });
                    });
                }
                else if (res.FwkItem.Count > 0)
                {
                    res.FwkItem.ForEach(delegate(OCS0103U00FwkCommonInfo item)
                    {
                        lObj.Add(new object[]
                        {
                            item.YjCode,
                            item.HotCode,
                            item.YakKijunCode,
                            item.SgCode,
                            item.SaleName,
                            item.CreatedCompanyName,
                            item.SaledCompanyName,
                            item.A16,
                            item.A18,
                        });
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdOCS0103ForSaveLayout
        /// <summary>
        /// GetGrdOCS0103ForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0103U00GrdOCS0103Info> GetGrdOCS0103ForSaveLayout()
        {
            List<OCS0103U00GrdOCS0103Info> lstData = new List<OCS0103U00GrdOCS0103Info>();

            // for insert/update
            for (int i = 0; i < grdOCS0103.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdOCS0103.GetRowState(i) == DataRowState.Unchanged) continue;

                OCS0103U00GrdOCS0103Info item = new OCS0103U00GrdOCS0103Info();

                item.SysDate                    = grdOCS0103.GetItemString(i, "sys_date");
                item.SysId                      = grdOCS0103.GetItemString(i, "sys_id");
                item.UpdDate                    = grdOCS0103.GetItemString(i, "upd_date");
                item.HangmogCode                = grdOCS0103.GetItemString(i, "hangmog_code");
                item.HangmogName                = grdOCS0103.GetItemString(i, "hangmog_name");
                item.SlipCode                   = grdOCS0103.GetItemString(i, "slip_code");
                item.GroupYn                    = grdOCS0103.GetItemString(i, "group_yn");
                item.Position                   = grdOCS0103.GetItemString(i, "position");
                item.Seq                        = grdOCS0103.GetItemString(i, "seq");
                item.OrderGubun                 = grdOCS0103.GetItemString(i, "order_gubun");
                item.InputControl               = grdOCS0103.GetItemString(i, "input_control");
                item.JundalTableOut             = grdOCS0103.GetItemString(i, "jundal_table_out");
                item.JundalTableInp             = grdOCS0103.GetItemString(i, "jundal_table_inp");
                item.JundalPartOut              = grdOCS0103.GetItemString(i, "jundal_part_out");
                item.JundalPartInp              = grdOCS0103.GetItemString(i, "jundal_part_inp");
                item.MovePart                   = grdOCS0103.GetItemString(i, "move_part");
                if (grdOCS0103.GetItemString(i, "dv_time") == null || grdOCS0103.GetItemString(i, "dv_time") == "")
                {
                    cboDvTime.SelectedIndex = 0;
                    this.AcceptData();
                    item.DvTime = cboDvTime.GetDataValue();
                    
                }
                else
                {
                    item.DvTime = grdOCS0103.GetItemString(i, "dv_time");
                }

                item.OrdDanui                   = grdOCS0103.GetItemString(i, "ord_danui");
                item.DefaultBogyongCode         = grdOCS0103.GetItemString(i, "default_bogyong_code");
                item.SugaYn                     = grdOCS0103.GetItemString(i, "suga_yn");
                item.SgCode                     = grdOCS0103.GetItemString(i, "sg_code");
                item.JaeryoYn                   = grdOCS0103.GetItemString(i, "jaeryo_yn");
                item.JaeryoCode                 = grdOCS0103.GetItemString(i, "jaeryo_code");
                item.HangmogNameInx             = grdOCS0103.GetItemString(i, "hangmog_name_inx");
                item.DisplayYn                  = grdOCS0103.GetItemString(i, "display_yn");
                item.StartDate                  = grdOCS0103.GetItemString(i, "start_date");
                item.EndDate                    = grdOCS0103.GetItemString(i, "end_date");
                item.SpecimenYn                 = grdOCS0103.GetItemString(i, "specimen_yn");
                item.SpecimenDefault            = grdOCS0103.GetItemString(i, "specimen_default");
                item.DefaultPortableYn1         = grdOCS0103.GetItemString(i, "default_portable_yn");
                item.SpecificComment            = grdOCS0103.GetItemString(i, "specific_comment");
                item.ReserYnOut                 = grdOCS0103.GetItemString(i, "reser_yn_out");
                item.ReserYnInp                 = grdOCS0103.GetItemString(i, "reser_yn_inp");
                item.Emergency                  = grdOCS0103.GetItemString(i, "emergency");
                item.LimitSuryang               = grdOCS0103.GetItemString(i, "limit_suryang");
                item.BomYn                      = grdOCS0103.GetItemString(i, "bom_yn");
                item.ReturnYn                   = grdOCS0103.GetItemString(i, "return_yn");
                item.SubulConvertGubun          = grdOCS0103.GetItemString(i, "subul_convert_gubun");
                item.WonyoiOrderYn              = grdOCS0103.GetItemString(i, "wonyoi_order_yn");
                item.DefaultWonnaeSayu          = grdOCS0103.GetItemString(i, "default_wonnae_sayu");
                item.AntiCancerYn               = grdOCS0103.GetItemString(i, "anti_cancer_yn");
                item.ChisikYn                   = grdOCS0103.GetItemString(i, "chisik_yn");
                item.NdayYn                     = grdOCS0103.GetItemString(i, "nday_yn");
                item.MuhyoYn                    = grdOCS0103.GetItemString(i, "muhyo_yn");
                item.InvJundalYn                = grdOCS0103.GetItemString(i, "inv_jundal_yn");
                item.PowderYn                   = grdOCS0103.GetItemString(i, "powder_yn");
                item.Remark                     = grdOCS0103.GetItemString(i, "remark");
                item.DefaultDv                  = grdOCS0103.GetItemString(i, "default_dv");
                item.DefaultSuryang             = grdOCS0103.GetItemString(i, "default_suryang");
                item.NurseInputYn               = grdOCS0103.GetItemString(i, "nurse_input_yn");
                item.SupplyInputYn              = grdOCS0103.GetItemString(i, "supply_input_yn");
                item.LimitNalsu                 = grdOCS0103.GetItemString(i, "limit_nalsu");
                item.DefaultWonyoiYn            = grdOCS0103.GetItemString(i, "default_wonyoi_yn");
                item.PortableCheck              = grdOCS0103.GetItemString(i, "portable_check");
                item.PatStatusGr                = grdOCS0103.GetItemString(i, "pat_status_gr");
                item.UpdId                      = grdOCS0103.GetItemString(i, "upd_id");
                //item.HospCode                   = grdOCS0103.GetItemString(i, "hosp_code");
                item.DefaultJusa                = grdOCS0103.GetItemString(i, "default_jusa");
                item.SlipName                   = grdOCS0103.GetItemString(i, "slip_name");
                item.JundalPartOutName          = grdOCS0103.GetItemString(i, "jundal_part_out_name");
                item.JundalPartInpName          = grdOCS0103.GetItemString(i, "jundal_part_inp_name");
                item.MovePartName               = grdOCS0103.GetItemString(i, "move_part_name");
                //item.JaeryoName                 = grdOCS0103.GetItemString(i, "jaeryo_name");
                // https://sofiamedix.atlassian.net/browse/MED-14580
                item.JaeryoName = grdOCS0103.GetItemString(i, "hangmog_name");
                //======
                item.SubulDanuiName             = grdOCS0103.GetItemString(i, "subul_danui_name");
                item.JearyoBulyongDate          = grdOCS0103.GetItemString(i, "jaeryo_bulyong_date");
                item.DefaultBogyongName         = grdOCS0103.GetItemString(i, "default_bogyong_name");
                item.IfInputControl             = grdOCS0103.GetItemString(i, "if_input_control");
                item.HubalDrgYn                 = grdOCS0103.GetItemString(i, "hubal_drg_yn");
                item.SgName                     = grdOCS0103.GetItemString(i, "sg_name");
                item.SgDanuiName                = grdOCS0103.GetItemString(i, "sg_danui_name");
                item.BulyongYmd                 = grdOCS0103.GetItemString(i, "bulyong_ymd");
                item.ResultGubun                = grdOCS0103.GetItemString(i, "result_gubun");
                item.WonnaeDrgYn                = grdOCS0103.GetItemString(i, "wonnae_drg_yn");
                //item.OutHospBookYn              = grdOCS0103.GetItemString(i, "out_hosp_book_yn");
                item.YakKijunCode               = grdOCS0103.GetItemString(i, "yak_kijun_code");
                item.YjCode                     = grdOCS0103.GetItemString(i, "yj_code");
                item.IfCode                     = grdOCS0103.GetItemString(i, "if_code");
                item.Trial                      = grdOCS0103.GetItemString(i, "trial");
                item.Protocol                   = grdOCS0103.GetItemString(i, "protocol");
                item.DefaultPortableYn2         = grdOCS0103.GetItemString(i, "default_portable_yn");
                item.RowState                   = grdOCS0103.GetRowState(i).ToString();
                item.CommonOrder                = grdOCS0103.GetItemString(i, "common_order");

                //if (cbxCommonOrder.Checked)
                //{
                //    item.CommonOrder = common_order_state;//old
                //    item.Protocol = "Y";//new
                //}
                //else
                //{
                //    item.CommonOrder = common_order_state;
                //    item.Protocol = "N";                   
                //}
                //item.RowState                   = grdOCS0103.GetRowState(i).ToString();


                //Sub-task MED-10693
                    //if ((common_order_state == "N" || common_order_state == "") && cbxCommonOrder.Checked == true)
                    //{
                    //    item.RowState = "Added";
                    //    item.CommonOrder = "Y";

                    //}
                    //else if (common_order_state == "Y" && cbxCommonOrder.Checked == false)
                    //{
                    //    item.RowState = grdOCS0103.GetRowState(i).ToString();
                    //    item.CommonOrder = "N";
                    //}
                    //else
                    //{
                    //    item.RowState = grdOCS0103.GetRowState(i).ToString();
                    //    item.CommonOrder = "";
                    //}                                                                                          
                lstData.Add(item);
            }

            // for delete
            if (null != grdOCS0103.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0103.DeletedRowTable.Rows)
                {
                    OCS0103U00GrdOCS0103Info item = new OCS0103U00GrdOCS0103Info();

                    item.HangmogCode = Convert.ToString(dr["hangmog_code"]);
                    item.StartDate = Convert.ToString(dr["start_date"]);
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region GetGrdOCS0108ForSaveLayout
        /// <summary>
        /// GetGrdOCS0108ForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0103U00GrdOCS0108Info> GetGrdOCS0108ForSaveLayout()
        {
            List<OCS0103U00GrdOCS0108Info> lstData = new List<OCS0103U00GrdOCS0108Info>();

            // for insert/update
            for (int i = 0; i < grdOCS0108.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdOCS0108.GetRowState(i) == DataRowState.Unchanged) continue;

                OCS0103U00GrdOCS0108Info item = new OCS0103U00GrdOCS0108Info();

                item.HangmogCode         = grdOCS0108.GetItemString(i, "hangmog_code");
                item.OrdDanui            = grdOCS0108.GetItemString(i, "ord_danui");
                item.Seq                 = grdOCS0108.GetItemString(i, "seq");
                item.SunabGijun          = grdOCS0108.GetItemString(i, "change_qty1");
                item.SubulGijun          = grdOCS0108.GetItemString(i, "change_qty2");
                //item.HospCode            = grdOCS0108.GetItemString(i, "hosp_code");
                item.HangmogStartDate    = grdOCS0108.GetItemString(i, "hangmog_start_date");
                item.CodeName1           = grdOCS0108.GetItemString(i, "change_danui1");
                item.CodeName2           = grdOCS0108.GetItemString(i, "change_danui2");
                item.RowState            = grdOCS0108.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // for delete
            if (grdOCS0108.DeletedRowTable != null)
            {
                foreach (DataRow dr in grdOCS0108.DeletedRowTable.Rows)
                {
                    OCS0103U00GrdOCS0108Info item = new OCS0103U00GrdOCS0108Info();

                    item.HangmogCode = Convert.ToString(dr["hangmog_code"]);
                    item.HangmogStartDate = Convert.ToString(dr["hangmog_start_date"]);
                    item.OrdDanui = Convert.ToString(dr["ord_danui"]);
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region GetGrdOCS0113ForSaveLayout
        /// <summary>
        /// GetGrdOCS0113ForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0103U00GrdOCS0113Info> GetGrdOCS0113ForSaveLayout()
        {
            List<OCS0103U00GrdOCS0113Info> lstData = new List<OCS0103U00GrdOCS0113Info>();

            // for insert/update
            for (int i = 0; i < grdOCS0113.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdOCS0113.GetRowState(i) == DataRowState.Unchanged) continue;

                OCS0103U00GrdOCS0113Info item = new OCS0103U00GrdOCS0113Info();

                item.HangmogCode          = grdOCS0113.GetItemString(i, "hangmog_code");
                item.Seq                  = grdOCS0113.GetItemString(i, "seq");
                item.DefaultYn            = grdOCS0113.GetItemString(i, "default_yn");
                item.SpecimenCode         = grdOCS0113.GetItemString(i, "specimen_code");
                item.SpecimenName         = grdOCS0113.GetItemString(i, "specimen_name");
                //item.HospCode             = grdOCS0113.GetItemString(i, "hosp_code");
                item.HangmogStartDate     = grdOCS0113.GetItemString(i, "hangmog_start_date");
                item.RowState             = grdOCS0113.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // for delete
            if (null != grdOCS0113.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0113.DeletedRowTable.Rows)
                {
                    OCS0103U00GrdOCS0113Info item = new OCS0103U00GrdOCS0113Info();

                    item.HangmogCode          = Convert.ToString(dr["hangmog_code"]);
                    item.Seq                  = Convert.ToString(dr["seq"]);
                    item.DefaultYn            = Convert.ToString(dr["default_yn"]);
                    item.SpecimenCode         = Convert.ToString(dr["specimen_code"]);
                    item.SpecimenName         = Convert.ToString(dr["specimen_name"]);
                    //item.HospCode             = Convert.ToString(dr["hosp_code"]);
                    item.HangmogStartDate     = Convert.ToString(dr["hangmog_start_date"]);
                    item.RowState             = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region GetGrdOCS0115ForSaveLayout
        /// <summary>
        /// GetGrdOCS0115ForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0103U00GrdOCS0115Info> GetGrdOCS0115ForSaveLayout()
        {
            List<OCS0103U00GrdOCS0115Info> lstData = new List<OCS0103U00GrdOCS0115Info>();

            // for insert/update
            for (int i = 0; i < grdOCS0115.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdOCS0115.GetRowState(i) == DataRowState.Unchanged) continue;

                OCS0103U00GrdOCS0115Info item = new OCS0103U00GrdOCS0115Info();

                item.HangmogCode              = grdOCS0115.GetItemString(i, "hangmog_code");
                item.InputGwa                 = grdOCS0115.GetItemString(i, "input_gwa");
                item.InputPart                = grdOCS0115.GetItemString(i, "input_part");
                item.GwaName                  = grdOCS0115.GetItemString(i, "gwa_name");
                item.JundalTableOut           = grdOCS0115.GetItemString(i, "jundal_table_out");
                item.JundalPartOut            = grdOCS0115.GetItemString(i, "jundal_part_out");
                item.MovePart                 = grdOCS0115.GetItemString(i, "move_part");
                item.JundalTableInp           = grdOCS0115.GetItemString(i, "jundal_table_inp");
                item.JundalPartInp            = grdOCS0115.GetItemString(i, "jundal_part_inp");
                item.GwaNameOut               = grdOCS0115.GetItemString(i, "gwa_name_out");
                item.GwaNameInp               = grdOCS0115.GetItemString(i, "gwa_name_inp");
                item.MovePartName             = grdOCS0115.GetItemString(i, "move_part_name");
                item.StartDate                = grdOCS0115.GetItemString(i, "start_date");
                item.EndDate                  = grdOCS0115.GetItemString(i, "end_date");
                //item.HospCode                 = grdOCS0115.GetItemString(i, "hosp_code");
                item.HangmogStartDate         = grdOCS0115.GetItemString(i, "hangmog_start_date");
                item.RowState                 = grdOCS0115.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // for delete
            if (null != grdOCS0115.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0115.DeletedRowTable.Rows)
                {
                    OCS0103U00GrdOCS0115Info item = new OCS0103U00GrdOCS0115Info();

                    item.HangmogCode        = Convert.ToString(dr["hangmog_code"]);
                    item.HangmogStartDate   = Convert.ToString(dr["hangmog_start_date"]);
                    item.InputPart          = Convert.ToString(dr["input_part"]);
                    item.InputGwa           = Convert.ToString(dr["input_gwa"]);
                    item.StartDate          = Convert.ToString(dr["start_date"]);
                    item.RowState           = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region LoadAllCombos
        /// <summary>
        /// LoadAllCombos
        /// </summary>
        private void LoadAllCombos()
        {
            OCS0103U00LoadAllComboArgs args = new OCS0103U00LoadAllComboArgs();
            args.IsAll = false;
            args.HospCode = this.mHospCode;
            OCS0103U00LoadAllComboResult res = CloudService.Instance.Submit<OCS0103U00LoadAllComboResult, OCS0103U00LoadAllComboArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                _comboResult = res;
            }
            else
            {
                throw new Exception("OCS0103U00 Load all combo failed!");
            }

            //set comboBox
            cboQrySlipGubun.SetDictDDLB();
            cboResultGubun.SetDictDDLB();
            cboIfInputControl.SetDictDDLB();
            cboEmergency.SetDictDDLB();
            cboSubulConvertGubun.SetDictDDLB();
            cboWonyoiOrderYN.SetDictDDLB();
            cboDvTime.SetDictDDLB();
            cboOrdDanui.SetDictDDLB();
            cboInputControl.SetDictDDLB();
            cboOrderGubun.SetDictDDLB();
        }
        #endregion

        #endregion

        private void cbxTrialInputYN_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTrialInputYN.GetDataValue() == "Y")
            {
                this.fbxProtocol.Protect = false;
                
            }
            else
            {
                this.fbxProtocol.Protect = true;
                this.fbxProtocol.ResetData();
                this.fbxProtocol.AcceptData();
            }
            cbxTrialInputYN.AcceptData();
        }

        private void fbxProtocol_FindClick(object sender, CancelEventArgs e)
        {
            this.fwkCommon.ColInfos.Clear();

            this.fwkCommon.ServerFilter = false;

            this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_TEXT, FindColType.String, 80, 0, true, FilterType.InitYes);
            this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);

            this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

            //this.fwkCommon.AutoQuery = true;
            //this.fwkCommon.ServerFilter = true;
            ////fwkCommon.FormText = Resources.TEXT_001;
            //this.fwkCommon.ParamList = new List<string>(new String[] { "f_find1" });
            ////this.fwkCommon.BindVarList.Add("f_code_type", this.fbxPrefectureCode.Text);

            this.fwkCommon.ExecuteQuery = GetProtocolCode;
        }

        private IList<object[]> GetProtocolCode(BindVarCollection bindVar)
        {
            IList<object[]> res = new List<object[]>();
            OCS0103U00GetProtocolArgs args = new OCS0103U00GetProtocolArgs();
            if (xHospBox1.Visible)
            {
                args.HospCode = xHospBox1.HospCode;
            }
            else
            {
                args.HospCode = UserInfo.HospCode;
            }
            args.Find1 = "";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, OCS0103U00GetProtocolArgs>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo itemInfo in comboResult.ComboItem)
                {
                    res.Add(new object[] { itemInfo.Code, itemInfo.CodeName });
                }
            }
            return res;

        }

        private void fbxProtocol_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
            {
                //txtPrefecture.SetDataValue("");
                return;
            }

            OCS0103U00GetNameProtocolArgs args = new OCS0103U00GetNameProtocolArgs();
            args.ProtocolCode = e.DataValue;
            if (xHospBox1.Visible)
            {
                args.HospCode = xHospBox1.HospCode;
            }
            else
            {
                args.HospCode = UserInfo.HospCode;
            }

            OCS0103U00GetNameProtocolResult result = CloudService.Instance
                .Submit<OCS0103U00GetNameProtocolResult, OCS0103U00GetNameProtocolArgs>(args);

            string retVal = result.ProtocolName;
            if (TypeCheck.IsNull(retVal))
            {
                XMessageBox.Show(Resources.MSG051_MSG, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                e.Cancel = true;

                return;
            }
            else
            {
                //this.txtPrefecture.SetEditValue(retVal);
                //this.grdMaster.SetItemValue(this.grdMaster.CurrentRowNumber, "code_name", retVal);
                //txtPrefecture.AcceptData();
                //this.grdBoheom.SetItemValue(this.grdBoheom.CurrentRowNumber, "gubun_name1", name);

                //this.Control_Protect(e.DataValue);
            }
        }
       
        private void btnUpdateMst_Click(object sender, EventArgs e)
        {
            if (XMessageBox.Show(Resources.MSG052_MSG, Resources.MSG023_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                UpdateMasterDataArgs args = new UpdateMasterDataArgs();
                args.ScreenName = this.ScreenID;
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, UpdateMasterDataArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success && result.Result == true)
                {
                    XMessageBox.Show(Resources.MSG022_MSG, Resources.MSG022_CAP, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    XMessageBox.Show(Resources.MSG049_MSG, Resources.MSG022_CAP, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnOpenHOTCODEMst_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM2016U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void xLabel62_Click(object sender, EventArgs e)
        {

        }

        //MED-10625 and MED-11079
        private void cbxCommonOrder_CheckedChanged(object sender, EventArgs e)
        {
            //JundalTableOut = this.grdOCS0103.GetItemString(grdOCS0103.CurrentRowNumber, "jundal_table_out");
            //if (String.IsNullOrEmpty(JundalTableOut)) return;
            //MED-11704
            //if (this.grdOCS0103.GetRowState(grdOCS0103.CurrentRowNumber) == DataRowState.Unchanged) return;

            //if (!(JundalTableOut == "CPL" || JundalTableOut == "XRT" || JundalTableOut == "OP" || JundalTableOut == "PFE"))
            //{
            //    XMessageBox.Show(Resources.MSG054_MSG, Resources.MSG054_CAP, MessageBoxIcon.Error); 
            //    this.cbxCommonOrder.CheckedChanged -= new System.EventHandler(this.cbxCommonOrder_CheckedChanged);
            //    if (cbxCommonOrder.Checked)
            //    {
            //        cbxCommonOrder.Checked = false;
            //    }
            //    else
            //    {
            //        cbxCommonOrder.Checked = true;
            //    }
            //    this.cbxCommonOrder.CheckedChanged += new System.EventHandler(this.cbxCommonOrder_CheckedChanged); 
            //}
        }


        // deleted by Cloud
        #region XSavePeformer
//        private class XSavePeformer : ISavePerformer
//        {
//            private OCS0103U00 parent = null;

//            public XSavePeformer(OCS0103U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerId, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_chk = "";
//                object seq = "";
//                string msg = "";
//                string cap = "";

//                switch (callerId)
//                {
//                    case '1':   // 오더 마스터 
//                        #region
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                // 중복체크
//                                cmdText = "SELECT 'Y' " +
//                                          "  FROM OCS0103 " +
//                                          " WHERE HOSP_CODE = :f_hosp_code " +
//                                          "   AND HANGMOG_CODE = :f_hangmog_code " +
//                                          "   AND START_DATE   = :f_start_date ";

//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (TypeCheck.NVL(t_chk, "N").ToString() == "Y")
//                                {
//                                    msg = Resources.MSG035_MSG;
//                                    cap = Resources.MSG035_CAP;

//                                    XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
//                                    return false;

//                                }

//                                // 동일한 코드로 기간에 있다면 이전코드꺼는 중지 시킨다.
//                                cmdText = @" UPDATE OCS0103 " +
//                                           "    SET UPD_DATE = SYSDATE " +
//                                           "      , UPD_ID   = '" + UserInfo.UserID + "' " +
//                                           "      , END_DATE = TO_DATE(:f_start_date) - 1 " +
//                                           "  WHERE HOSP_CODE = :f_hosp_code " +
//                                           "    AND HANGMOG_CODE = :f_hangmog_code " +
//                                           "    AND START_DATE  <= :f_start_date " +
//                                           "    AND END_DATE     = TO_DATE('99981231', 'YYYYMMDD') ";

//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                                // 시퀀스 가져오기
//                                cmdText = "SELECT MAX(SEQ) + 1 " +
//                                          "  FROM OCS0103 " +
//                                          " WHERE HOSP_CODE = :f_hosp_code " +
//                                          "   AND SLIP_CODE = :f_slip_code ";

//                                seq = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (TypeCheck.IsNull(seq))
//                                {
//                                    seq = "1";
//                                }

//                                cmdText = @" INSERT INTO OCS0103
//                                                  ( SYS_DATE           , SYS_ID          , UPD_DATE            , HANGMOG_CODE
//                                                  , HANGMOG_NAME       , SLIP_CODE       , GROUP_YN            , POSITION
//                                                  , SEQ                , ORDER_GUBUN     , INPUT_CONTROL       , JUNDAL_TABLE_OUT
//                                                  , JUNDAL_TABLE_INP   , JUNDAL_PART_OUT , JUNDAL_PART_INP     , MOVE_PART
//                                                  , DV_TIME            , ORD_DANUI       , DEFAULT_BOGYONG_CODE, SUGA_YN
//                                                  , SG_CODE            , JAERYO_YN       , JAERYO_CODE         , HANGMOG_NAME_INX
//                                                  , DISPLAY_YN         , END_DATE        , SPECIMEN_YN         , SPECIMEN_DEFAULT
//                                                  , DEFAULT_PORTABLE_YN, SPECIFIC_COMMENT, RESER_YN_OUT        , RESER_YN_INP
//                                                  , EMERGENCY          , LIMIT_SURYANG   , BOM_YN              , RETURN_YN
//                                                  , SUBUL_CONVERT_GUBUN, WONYOI_ORDER_YN , DEFAULT_WONNAE_SAYU , ANTI_CANCER_YN
//                                                  , CHISIK_YN          , NDAY_YN         , MUHYO_YN            , INV_JUNDAL_YN
//                                                  , POWDER_YN          , REMARK          , DEFAULT_DV          , DEFAULT_SURYANG
//                                                  , SG_NAME            , NURSE_INPUT_YN  , SUPPLY_INPUT_YN     , LIMIT_NALSU
//                                                  , DEFAULT_WONYOI_YN  , PORTABLE_CHECK  , PAT_STATUS_GR       , UPD_ID
//                                                  , HOSP_CODE          , START_DATE      , DEFAULT_JUSA        , IF_INPUT_CONTROL
//                                                  , RESULT_GUBUN       , WONNAE_DRG_YN   , YJ_CODE)
//                                             VALUES 
//                                                  ( SYSDATE               , '" + UserInfo.UserID + @"', SYSDATE         , :f_hangmog_code
//                                                  , :f_hangmog_name       , :f_slip_code       , :f_group_yn            , :f_position
//                                                  , " + seq + @"          , :f_order_gubun     , :f_input_control       , :f_jundal_table_out
//                                                  , :f_jundal_table_inp   , :f_jundal_part_out , :f_jundal_part_inp     , :f_move_part
//                                                  , :f_dv_time            , :f_ord_danui       , :f_default_bogyong_code, :f_suga_yn
//                                                  , :f_sg_code            , :f_jaeryo_yn       , :f_jaeryo_code         , :f_hangmog_name_inx
//                                                  , 'Y'                   , nvl(:f_end_date, TO_DATE('99981231', 'YYYYMMDD'))        , :f_specimen_yn         , :f_specimen_default
//                                                  , :f_default_portable_yn, :f_specific_comment, :f_reser_yn_out        , :f_reser_yn_inp
//                                                  , :f_emergency          , :f_limit_suryang   , :f_bom_yn              , :f_return_yn
//                                                  , :f_subul_convert_gubun, :f_wonyoi_order_yn , :f_default_wonnae_sayu , :f_anti_cancer_yn
//                                                  , :f_chisik_yn          , :f_nday_yn         , :f_muhyo_yn            , :f_inv_jundal_yn
//                                                  , :f_powder_yn          , :f_remark          , :f_default_dv          , :f_default_suryang
//                                                  , :f_sg_name            , :f_nurse_input_yn  , :f_supply_input_yn     , :f_limit_nalsu
//                                                  , :f_default_wonyoi_yn  , :f_portable_check  , :f_pat_status_gr       ,  '" + UserInfo.UserID + @"' 
//                                                  , :f_hosp_code          , :f_start_date      , :f_default_jusa        , :f_if_input_control
//                                                  , :f_result_gubun       , :f_wonnae_drg_yn   , :f_yj_code) ";

//                                break;

//                            case DataRowState.Modified:



//                                cmdText = @" UPDATE OCS0103 
//                                                SET HANGMOG_NAME         = :f_hangmog_name        
//                                                  , SLIP_CODE            = :f_slip_code           
//                                                  , GROUP_YN             = :f_group_yn            
//                                                  , POSITION             = :f_position            
//                                                  , ORDER_GUBUN          = :f_order_gubun         
//                                                  , INPUT_CONTROL        = :f_input_control       
//                                                  , JUNDAL_TABLE_OUT     = :f_jundal_table_out    
//                                                  , JUNDAL_TABLE_INP     = :f_jundal_table_inp    
//                                                  , JUNDAL_PART_OUT      = :f_jundal_part_out     
//                                                  , JUNDAL_PART_INP      = :f_jundal_part_inp     
//                                                  , MOVE_PART            = :f_move_part           
//                                                  , DV_TIME              = :f_dv_time             
//                                                  , ORD_DANUI            = :f_ord_danui           
//                                                  , DEFAULT_BOGYONG_CODE = :f_default_bogyong_code
//                                                  , SUGA_YN              = :f_suga_yn             
//                                                  , SG_CODE              = :f_sg_code             
//                                                  , JAERYO_YN            = :f_jaeryo_yn           
//                                                  , JAERYO_CODE          = :f_jaeryo_code         
//                                                  , HANGMOG_NAME_INX     = :f_hangmog_name_inx    
//                                                  , DISPLAY_YN           = :f_display_yn          
//                                                  , END_DATE             = :f_end_date            
//                                                  , SPECIMEN_YN          = :f_specimen_yn         
//                                                  , SPECIMEN_DEFAULT     = :f_specimen_default    
//                                                  , DEFAULT_PORTABLE_YN  = :f_default_portable_yn 
//                                                  , SPECIFIC_COMMENT     = :f_specific_comment    
//                                                  , RESER_YN_OUT         = :f_reser_yn_out        
//                                                  , RESER_YN_INP         = :f_reser_yn_inp        
//                                                  , EMERGENCY            = :f_emergency           
//                                                  , LIMIT_SURYANG        = :f_limit_suryang       
//                                                  , BOM_YN               = :f_bom_yn              
//                                                  , RETURN_YN            = :f_return_yn           
//                                                  , SUBUL_CONVERT_GUBUN  = :f_subul_convert_gubun 
//                                                  , WONYOI_ORDER_YN      = :f_wonyoi_order_yn     
//                                                  , DEFAULT_WONNAE_SAYU  = :f_default_wonnae_sayu 
//                                                  , ANTI_CANCER_YN       = :f_anti_cancer_yn      
//                                                  , CHISIK_YN            = :f_chisik_yn           
//                                                  , NDAY_YN              = :f_nday_yn             
//                                                  , MUHYO_YN             = :f_muhyo_yn            
//                                                  , INV_JUNDAL_YN        = :f_inv_jundal_yn       
//                                                  , POWDER_YN            = :f_powder_yn           
//                                                  , REMARK               = :f_remark              
//                                                  , DEFAULT_DV           = :f_default_dv          
//                                                  , DEFAULT_SURYANG      = :f_default_suryang     
//                                                  , SG_NAME              = :f_sg_name             
//                                                  , NURSE_INPUT_YN       = :f_nurse_input_yn      
//                                                  , SUPPLY_INPUT_YN      = :f_supply_input_yn     
//                                                  , LIMIT_NALSU          = :f_limit_nalsu         
//                                                  , DEFAULT_WONYOI_YN    = :f_default_wonyoi_yn   
//                                                  , PORTABLE_CHECK       = :f_portable_check      
//                                                  , PAT_STATUS_GR        = :f_pat_status_gr 
//                                                  , UPD_DATE             = SYSDATE      
//                                                  , UPD_ID               = '" + UserInfo.UserID + @"'
//                                                  , DEFAULT_JUSA         = :f_default_jusa 
//                                                  , IF_INPUT_CONTROL     = :f_if_input_control   
//                                                  , RESULT_GUBUN         = :f_result_gubun
//                                                  , WONNAE_DRG_YN        = :f_wonnae_drg_yn  
//                                                  , YJ_CODE              = :f_yj_code 
//                                              WHERE HOSP_CODE    = :f_hosp_code
//                                                AND HANGMOG_CODE = :f_hangmog_code 
//                                                AND START_DATE   = :f_start_date   ";


//                                break;

//                            case DataRowState.Deleted:


//                                // 삭제 하려면 삭제건 보다 바로 적은 놈의 end_date 를 풀어줘야죠
//                                cmdText = " UPDATE OCS0103 " +
//                                          "    SET UPD_ID           = '" + UserInfo.UserID + "' " +
//                                          "      , UPD_DATE         = SYSDATE " +
//                                          "      , END_DATE         = TO_DATE('9998/12/31', 'YYYY/MM/DD') " +
//                                          "  WHERE HOSP_CODE        = :f_hosp_code " +
//                                          "    AND HANGMOG_CODE     = :f_hangmog_code " +
//                                          "    AND START_DATE       = :f_start_date" +
//                                          "    AND END_DATE         = TO_DATE(:f_start_date) - 1";


//                                cmdText = @" DELETE FROM OCS0103 " +
//                                           "  WHERE HOSP_CODE    = :f_hosp_code " +
//                                           "    AND HANGMOG_CODE = :f_hangmog_code " +
//                                           "    AND START_DATE   = :f_start_date ";

//                                break;
//                        }
//                        #endregion
//                        break;

//                    case '2': // 환산수량
//                        #region
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @" SELECT 'Y'
//                                               FROM SYS.DUAL
//                                              WHERE EXISTS ( SELECT 'X'
//                                                               FROM OCS0108" +
//                                           "                  WHERE HANGMOG_CODE       = :f_hangmog_code " +
//                                           "                    AND HOSP_CODE          = :f_hosp_code" +
//                                           "                    AND HANGMOG_START_DATE = :f_hangmog_start_date" + //ADD SHIMO
//                                           "                    AND ORD_DANUI          = :f_ord_danui ) ";


//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (TypeCheck.NVL(t_chk, "N").ToString() == "Y")
//                                {
//                                    msg = Resources.MSG036_MSG;
//                                    cap = Resources.MSG035_CAP;

//                                    XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

//                                    return false;
//                                }

//                                // sequence 구하기
//                                cmdText = " SELECT MAX(SEQ) + 1 " +
//                                          "   FROM OCS0108 " +
//                                          "  WHERE HOSP_CODE          = :f_hosp_code " +
//                                          "    AND HANGMOG_START_DATE = :f_hangmog_start_date" +
//                                          "    AND HANGMOG_CODE       = :f_hangmog_code ";


//                                seq = Service.ExecuteScalar(cmdText, item.BindVarList);



//                                // string aa = parent.grdOCS0103.GetItemString(

//                                // XMessageBox.Show(aa, MessageBoxButtons.OK, MessageBoxIcon.Error);

//                                if (TypeCheck.IsNull(seq))
//                                {
//                                    seq = "1";
//                                }

//                                cmdText = @" INSERT INTO OCS0108 
//                                                       ( SYS_DATE    ,    SYS_ID      ,    UPD_DATE ,    UPD_ID,
//                                                         HOSP_CODE   ,    HANGMOG_CODE,    ORD_DANUI,    SEQ   ,
//                                                         CHANGE_QTY1 ,    CHANGE_QTY2 ,    HANGMOG_START_DATE)
//                                                  VALUES
//                                                       ( SYSDATE     ,    '" + UserInfo.UserID + "', SYSDATE,     '" + UserInfo.UserID + "'," +
//                                                       " :f_hosp_code  , :f_hangmog_code, :f_ord_danui, " + seq.ToString() + ", " +
//                                                       " :f_change_qty1, :f_change_qty2,:f_hangmog_start_date) ";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @" UPDATE OCS0108
//                                                SET CHANGE_QTY1  = :f_change_qty1
//                                                  , CHANGE_QTY2  = :f_change_qty2
//                                                  , UPD_DATE     = SYSDATE
//                                                  , UPD_ID       = '" + UserInfo.UserID + @"' 
//                                              WHERE HOSP_CODE    = :f_hosp_code
//                                                AND HANGMOG_CODE = :f_hangmog_code 
//                                                AND HANGMOG_START_DATE = :f_hangmog_start_date 
//                                                AND ORD_DANUI    = :f_ord_danui    ";

//                                break;

//                            case DataRowState.Deleted:



//                                cmdText = @" DELETE FROM OCS0108 
//                                              WHERE HOSP_CODE           = :f_hosp_code" +
//                                              "  AND HANGMOG_CODE       = :f_hangmog_code " +
//                                              "  AND HANGMOG_START_DATE =  :f_hangmog_start_date " +
//                                              "  AND ORD_DANUI          = :f_ord_danui";
//                                // ADD HANGMOG_START_DATE SHIMO //

//                                break;
//                        }
//                        #endregion
//                        break;

//                    case '3': // 전달부서
//                        #region
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                // 일단 중복 체크
//                                cmdText = " SELECT 'Y' " +
//                                          "   FROM SYS.DUAL " +
//                                          "  WHERE EXISTS ( SELECT 'X' " +
//                                          "                   FROM OCS0115 " +
//                                          "                  WHERE HOSP_CODE    = :f_hosp_code " +
//                                          "                    AND HANGMOG_CODE = :f_hangmog_code " +
//                                          "                    AND INPUT_PART   = :f_input_part " +
//                                          "                    AND INPUT_GWA    = :f_input_gwa " +
//                                          "                    AND HANGMOG_START_DATE = :f_hangmog_start_date " + // ADD 
//                                          "                    AND START_DATE   = :f_start_date ) ";

//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (TypeCheck.NVL(t_chk, "N").ToString() == "Y")
//                                {
//                                    msg = Resources.MSG037_MSG;
//                                    cap = Resources.MSG035_CAP;

//                                    XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

//                                    return false;
//                                }

//                                // 이전에 등록된거 있음 그거 END_DATE 박아야죠

//                                cmdText = " UPDATE OCS0115 " +
//                                          "    SET END_DATE = TO_DATE(:f_start_date) - 1 " +
//                                          "        ,UPD_ID= '" + UserInfo.UserID + @"'" +
//                                          "        ,UPD_DATE = SYSDATE " +
//                                          "  WHERE HOSP_CODE            = :f_hosp_code " +
//                                          "        AND HANGMOG_CODE     = :f_hangmog_code " +
//                                          "        AND START_DATE       <=:f_start_date" +
//                                          "        AND INPUT_PART       = :f_input_part " +
//                                          "        AND INPUT_GWA        = :f_input_gwa " +
//                                          "        AND HANGMOG_START_DATE = :f_hangmog_start_date " + // ADD 
//                                          "        AND END_DATE         = TO_DATE('9998/12/31', 'YYYY/MM/DD') ";


//                                //cmdText = " UPDATE OCS0115 " +
//                                //          "    SET END_DATE = TO_DATE('" + item.BindVarList["f_start_date"].ToString() + "', 'YYYY/MM/DD') -1 " +
//                                //          "  WHERE HOSP_CODE = :f_hosp_code " +
//                                //          "            START_DATE <= TO_DATE('" + item.BindVarList["f_start_date"].ToString() + "', 'YYYY/MM/DD') " +
//                                //          "    AND END_DATE = TO_DATE('9998/12/31', 'YYYY/MM/DD') ";




//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                                // 업데이트 시작 합시다...

//                                cmdText = " INSERT INTO OCS0115 " +
//                                          "        ( SYS_DATE  ,   SYS_ID          ,   UPD_DATE           ,   HANGMOG_CODE   , " +
//                                          "          INPUT_PART,   INPUT_GWA       ,   JUNDAL_TABLE_OUT   ,   JUNDAL_PART_OUT, " +
//                                          "          MOVE_PART ,   JUNDAL_TABLE_INP,   JUNDAL_PART_INP    ,   UPD_ID          , " +
//                                          "          HOSP_CODE ,   START_DATE      ,   END_DATE           ,   HANGMOG_START_DATE ) " +
//                                          " VALUES " +
//                                          "        ( SYSDATE   ,   '" + UserInfo.UserID + "',SYSDATE      ,     :f_hangmog_code, " +
//                                          "          :f_input_part, :f_input_gwa   , :f_jundal_table_out ,   :f_jundal_part_out, " +
//                                          "          :f_move_part , :f_jundal_table_inp, :f_jundal_part_inp, '" + UserInfo.UserID + @"'," +
//                                          "        '" + EnvironInfo.HospCode + "', :f_start_date,  TO_DATE('9998/12/31', 'YYYY/MM/DD'),:f_hangmog_start_date ) ";

//                                break;

//                            case DataRowState.Modified:

//                                // 업데이트 시작 합니다.
//                                cmdText = " UPDATE OCS0115 " +
//                                          "    SET UPD_ID           = '" + UserInfo.UserID + "' " +
//                                          "      , UPD_DATE         = SYSDATE " +
//                                          "      , JUNDAL_TABLE_OUT = :f_jundal_table_out " +
//                                          "      , JUNDAL_PART_OUT  = :f_jundal_part_out " +
//                                          "      , JUNDAL_TABLE_INP = :f_jundal_table_inp " +
//                                          "      , JUNDAL_PART_INP  = :f_jundal_part_inp " +
//                                          "      , MOVE_PART        = :f_move_part       " +
//                                          "      , END_DATE         = :f_end_date        " +
//                                          "      , HANGMOG_START_DATE = :f_hangmog_start_date " +
//                                          "  WHERE HOSP_CODE        = :f_hosp_code " +
//                                          "    AND HANGMOG_CODE     = :f_hangmog_code " +
//                                          "    AND INPUT_PART       = :f_input_part " +
//                                          "    AND INPUT_GWA        = :f_input_gwa " +
//                                          "    AND HANGMOG_START_DATE = :f_hangmog_start_date" +  //ADD SHIMO
//                                          "    AND START_DATE       = :f_start_date ";


//                                break;

//                            case DataRowState.Deleted:

//                                // 삭제 하려면 삭제건 보다 바로 적은 놈의 end_date 를 풀어줘야 하지 않을까요???????
//                                cmdText = " UPDATE OCS0115 " +
//                                          "    SET UPD_ID = '" + UserInfo.UserID + "' " +
//                                          "      , UPD_DATE = SYSDATE " +
//                                          "      , END_DATE = TO_DATE('9998/12/31', 'YYYY/MM/DD') " +
//                                          "  WHERE HOSP_CODE        = :f_hosp_code " +
//                                          "    AND HANGMOG_CODE     = :f_hangmog_code " +
//                                          "    AND INPUT_PART       = :f_input_part " +
//                                          "    AND INPUT_GWA        = :f_input_gwa " +
//                                          "    AND HANGMOG_START_DATE = :f_hangmog_start_date" +  //ADD SHIMO
//                                          "    AND END_DATE       = TO_DATE(:f_start_date) - 1";


//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                                cmdText = " DELETE FROM OCS0115 " +
//                                          "  WHERE HOSP_CODE        = :f_hosp_code " +
//                                          "    AND HANGMOG_CODE     = :f_hangmog_code " +
//                                          "    AND INPUT_PART       = :f_input_part " +
//                                          "    AND INPUT_GWA        = :f_input_gwa " +
//                                          "    AND HANGMOG_START_DATE = :f_hangmog_start_date " + //ADD SHIMO
//                                          "    AND START_DATE        = :f_start_date ";

//                                break;
//                        }
//                        #endregion
//                        break;

//                    case '4': // 검체코드
//                        #region

//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                // 중복체크

//                                cmdText = " SELECT 'Y' " +
//                                          "   FROM SYS.DUAL " +
//                                          "  WHERE EXISTS ( SELECT 'X' " +
//                                          "                   FROM OCS0113 A " +
//                                          "                  WHERE A.HOSP_CODE           = '" + EnvironInfo.HospCode + "' " +
//                                          "                    AND A.HANGMOG_CODE        = :f_hangmog_code " +
//                                          "                    AND A.HANGMOG_START_DATE  = :f_hangmog_start_date " +  // ADD SHIMO
//                                          "                    AND A.SPECIMEN_CODE       = :f_specimen_code ) ";


//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (TypeCheck.NVL(t_chk, "N").ToString() == "Y")
//                                {
//                                    msg = Resources.MSG038_MSG;
//                                    cap = Resources.MSG035_CAP;

//                                    XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

//                                    return false;
//                                }

//                                // Seq 가져오기
//                                cmdText = " SELECT MAX(A.SEQ) + 1" +
//                                          "   FROM OCS0113 A" +
//                                          "  WHERE A.HOSP_CODE           = '" + EnvironInfo.HospCode + "' " +
//                                          "    AND A.HANGMOG_START_DATE  = :f_hangmog_start_date " + //ADD SHIMO
//                                          "    AND A.HANGMOG_CODE        = :f_hangmog_code ";

//                                seq = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                //MessageBox.Show(seq.ToString());

//                                if (TypeCheck.IsNull(seq))
//                                {
//                                    seq = "1";
//                                }
//                                cmdText = " INSERT INTO OCS0113 " +
//                                      "      ( SYS_DATE    , SYS_ID       , UPD_DATE, " +
//                                      "        HANGMOG_CODE, SPECIMEN_CODE, SEQ     , DEFAULT_YN  , " +
//                                      "        UPD_ID      , HOSP_CODE              ,HANGMOG_START_DATE) " +
//                                      " VALUES " +
//                                      "      ( SYSDATE        , '" + UserInfo.UserID + "', SYSDATE, " +
//                                      "        :f_hangmog_code, :f_specimen_code, " + seq.ToString() + ", :f_default_yn, " +
//                                      "        '" + UserInfo.UserID + "', '" + EnvironInfo.HospCode + "',:f_hangmog_start_date ) ";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = " UPDATE OCS0113 " +
//                                          "    SET DEFAULT_YN         = :f_default_yn " +
//                                          "      , UPD_DATE           = SYSDATE " +
//                                          "      , UPD_ID             = '" + UserInfo.UserID + "'" +
//                                          "  WHERE HOSP_CODE          = :f_hosp_code " +
//                                          "    AND HANGMOG_CODE       = :f_hangmog_code " +
//                                          "    AND HANGMOG_START_DATE = :f_hangmog_start_date " + //ADD SHIMO 
//                                          "    AND SPECIMEN_CODE      = :f_specimen_code ";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = " DELETE FROM OCS0113 " +
//                                          "  WHERE HOSP_CODE          = :f_hosp_code " +
//                                          "    AND HANGMOG_CODE       = :f_hangmog_code " +
//                                          "    AND HANGMOG_START_DATE = :f_hangmog_start_date " + // ADD SHIMO
//                                          "    AND SPECIMEN_CODE      = :f_specimen_code ";

//                                break;
//                        }

//                        #endregion

//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion
    }
}
