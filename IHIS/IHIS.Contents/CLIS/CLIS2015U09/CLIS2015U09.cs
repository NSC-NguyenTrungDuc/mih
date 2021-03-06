using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IHIS.CLIS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Clis;
using IHIS.CloudConnector.Contracts.Models.Clis;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Clis;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;

namespace IHIS.CLIS
{
    public partial class CLIS2015U09 : IHIS.Framework.XScreen
    {
        #region Fields & Properties
        
        private string _clisSmoId;
        private DataRowState _rowState;
        string mCallControl = "";
        private string mbxMsg = "";
        bool boolSave = true;

        #endregion

        #region Constructor
        /// <summary>
        /// CLIS2015U09
        /// </summary>
        public CLIS2015U09()
        {
            InitializeComponent();
            grdMaster.ParamList = new List<string>(new String[] {});
            grdMaster.ExecuteQuery = ExecuteQueryGrdListItem;
            grdMaster.QueryLayout(true);
            this.fwkCommon.ParamList = new List<string>(new String[] { "f_find1", "f_code_type" });
            Control_Protect();
            this.txtCode.Protect = true;
        }
        #endregion

        #region Events

        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            this.boolSave = true;
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.grdMaster.QueryLayout(true);
                    this.txtCode.Protect = true;
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    //TODO Check have protocol
                    if (SaveLayout())
                    {
                        grdMaster.ResetUpdate();
                        mbxMsg = Resources.MSG_008;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    break;
                case FunctionType.Delete:
                    
                    string clisSmoId = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "clis_smo_id");
                    if(!CheckSmoForDelete(clisSmoId))
                    {
                        e.IsBaseCall = false;
                        mbxMsg = Resources.MSG_016;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                default:
                    break;
            }
            Control_Protect();
        }

        /// <summary>
        /// 동이름 일부 입력후 파인드 클릭 하는 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fbxAddress_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.mCallControl = ((XFindBox)sender).Name;

            string zipCode1 = "";
            string zipCode2 = "";
            string address1 = "";

            switch (this.mCallControl)
            {
                case "fbxAddress1":

                    zipCode1 = this.fbxZip_Code1.GetDataValue();
                    zipCode2 = this.txtZip_Code2.GetDataValue();
                    address1 = this.fbxAddress.GetDataValue();

                    break;
            }

            this.OpenScreen_BAS0123Q00("address", zipCode1, zipCode2, address1);
        }

        private void fbxZip_Code1_FindClick(object sender, CancelEventArgs e)
        {
            this.mCallControl = ((XFindBox)sender).Name;

            string zipCode1 = "";
            string zipCode2 = "";
            string address1 = "";

            switch (this.mCallControl)
            {
                case "fbxZip_Code1":

                    zipCode1 = this.fbxZip_Code1.GetDataValue();
                    zipCode2 = this.txtZip_Code2.GetDataValue();
                    address1 = this.fbxAddress.GetDataValue();

                    break;
            }

            this.OpenScreen_BAS0123Q00("zipCode", zipCode1, zipCode2, address1);
        }

        private void fbxPrefectureCode_FindClick(object sender, CancelEventArgs e)
        {
            this.fwkCommon.AutoQuery = true;
            this.fwkCommon.ServerFilter = true;
            fwkCommon.FormText = Resources.TEXT_001;
            this.fwkCommon.ParamList = new List<string>(new String[] { "f_code_type", "f_find1" });
            this.fwkCommon.BindVarList.Add("f_code_type", this.fbxPrefectureCode.Text);

            this.fwkCommon.ExecuteQuery = GetPrefectureCode;

        }

        private void fbxPrefectureCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
            {
                txtPrefecture.SetDataValue("");
                return;
            }

            CLIS2015U09GetCodeNameArgs args = new CLIS2015U09GetCodeNameArgs();
            args.Code = e.DataValue;

            CLIS2015U09GetCodeNameResult result = CloudService.Instance
                .Submit<CLIS2015U09GetCodeNameResult, CLIS2015U09GetCodeNameArgs>(args);

            string retVal = result.CodeName;
            if (TypeCheck.IsNull(retVal))
            {
                this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "보험종류를 확인하세요." : Resources.MSG_022);

                this.SetMsg(this.mbxMsg, MsgType.Error);

                e.Cancel = true;

                return;
            }
            else
            {
                this.txtPrefecture.SetEditValue(retVal);
                this.grdMaster.SetItemValue(this.grdMaster.CurrentRowNumber, "code_name", retVal);
                txtPrefecture.AcceptData();
                //this.grdBoheom.SetItemValue(this.grdBoheom.CurrentRowNumber, "gubun_name1", name);

                //this.Control_Protect(e.DataValue);
            }

        }

        private void xButtonList1_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            if (e.Func == FunctionType.Reset)
            {
                Control_Protect();
                txtCode.Focus();
                //this.dtpSg_Ymd.Protect = false;
            }
            else if (e.Func == FunctionType.Insert)
            {
                if (e.IsSuccess == true)
                {
                    Control_Protect();
                }
            }
            else if (e.Func == FunctionType.Query)
            {
                if (e.IsSuccess == true)
                {
                    txtCode.Protect = true;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("clis_protocol_id", "12");
            try
            {
                XScreen.OpenScreenWithParam(this, "CLIS", "CLIS2015U13", ScreenOpenStyle.ResponseFixed, param);
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Methods

        private List<CLIS2015U09ItemInfo> PrepareInsert()
        {
            List<CLIS2015U09ItemInfo> lst= new List<CLIS2015U09ItemInfo>();

            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetRowState(i) == DataRowState.Added || grdMaster.GetRowState(i) == DataRowState.Modified)
                {
                    CLIS2015U09ItemInfo info = new CLIS2015U09ItemInfo();
                    info.ClisSmoId = grdMaster.GetItemString(i, "clis_smo_id");
                    info.SmoCode = grdMaster.GetItemString(i, "smo_code");
                    info.StartDate = grdMaster.GetItemString(i, "start_date");
                    info.EndDate = grdMaster.GetItemString(i, "end_date");
                    info.SmoName = grdMaster.GetItemString(i, "smo_name");
                    info.SmoName1 = grdMaster.GetItemString(i, "smo_name1");
                    info.ZipCode1 = grdMaster.GetItemString(i, "zip_code1");
                    info.ZipCode2 = grdMaster.GetItemString(i, "zip_code2");
                    info.Address = grdMaster.GetItemString(i, "address");
                    info.Address1 = grdMaster.GetItemString(i, "address1");
                    info.Tel = grdMaster.GetItemString(i, "tel");
                    info.Tel1 = grdMaster.GetItemString(i, "tel1");
                    info.Fax = grdMaster.GetItemString(i, "fax");
                    info.DodobuhyeunNo = grdMaster.GetItemString(i, "dodobuhyeun_no");
                    info.CodeName = grdMaster.GetItemString(i, "code_name");
                    info.Homepage = grdMaster.GetItemString(i, "homepage");
                    info.Email = grdMaster.GetItemString(i, "email");
                    info.RowState = grdMaster.GetRowState(i).ToString();

                    lst.Add(info);
                }
            }
            if (grdMaster.DeletedRowTable != null && grdMaster.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdMaster.DeletedRowTable.Rows)
                {
                    CLIS2015U09ItemInfo info = new CLIS2015U09ItemInfo();
                    info.ClisSmoId = row["clis_smo_id"].ToString();
                    info.SmoCode = row["smo_code"].ToString();
                    info.StartDate = row["start_date"].ToString();
                    info.EndDate = row["end_date"].ToString();
                    info.SmoName = row["smo_name"].ToString();
                    info.SmoName1 = row["smo_name1"].ToString();
                    info.ZipCode1 = row["zip_code1"].ToString();
                    info.ZipCode2 = row["zip_code2"].ToString();
                    info.Address = row["address"].ToString();
                    info.Address1 = row["address1"].ToString();
                    info.Tel = row["tel"].ToString();
                    info.Tel1 = row["tel1"].ToString();
                    info.Fax = row["fax"].ToString();
                    info.DodobuhyeunNo = row["dodobuhyeun_no"].ToString();
                    info.CodeName = row["code_name"].ToString();
                    info.Homepage = row["homepage"].ToString();
                    info.Email = row["email"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    lst.Add(info);
                }
            }
            return lst;


            return lst;
        }

        private bool CheckSmoCode(string smoCode)
        {
            CLIS2015U09CheckSmoCodeArgs args = new CLIS2015U09CheckSmoCodeArgs();
            args.SmoCode = smoCode;
            CLIS2015U09CheckSmoCodeResult result = CloudService.Instance.Submit<CLIS2015U09CheckSmoCodeResult, CLIS2015U09CheckSmoCodeArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (int.Parse(result.Cnt) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool SaveLayout()
        {
            CLIS2015U09SaveArgs args = new CLIS2015U09SaveArgs();
            args.Dt = PrepareInsert();
            if (!Validate(args.Dt))
            {
                return false;
            }
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, CLIS2015U09SaveArgs>(args);
            if (result == null || result.ExecutionStatus != ExecutionStatus.Success ||
                result.Result == false)
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// 우편번호 조회 창 Open
        /// </summary>
        /// <param name="aSearchGubun"></param>
        /// <param name="aZipCode1"></param>
        /// <param name="aZipCode2"></param>
        /// <param name="aAddress"></param>
        private void OpenScreen_BAS0123Q00(string aSearchGubun, string aZipCode1, string aZipCode2, string aAddress)
        {
            CommonItemCollection param = new CommonItemCollection();

            if (aSearchGubun == "zipCode")
            {
                param.Add("SearchGubun", aSearchGubun);
                param.Add("zip_code1", aZipCode1);
                param.Add("zip_code2", aZipCode2);
            }
            else
            {
                param.Add("SearchGubun", aSearchGubun);
                param.Add("address", aAddress);
            }

            XScreen.OpenScreenWithParam(this, "BASS", "BAS0123Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// Command 호출후 포커스 이동등..
        /// </summary>
        /// <param name="aScreenName"></param>
        private void PostCallCommand(string aScreenName)
        {
            switch (aScreenName)
            {
                case "BAS0110Q00":

                    this.fbxZip_Code1.Focus();

                    break;
            }
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            PostCallHelper.PostCall(new PostMethodStr(PostCallCommand), command);

            switch (command)
            {
                case "BAS0123Q00":

                    this.fbxZip_Code1.SetEditValue(commandParam["zip_code1"]);
                    this.fbxZip_Code1.AcceptData();
                    this.txtZip_Code2.SetEditValue(commandParam["zip_code2"]);
                    this.txtZip_Code2.AcceptData();
                    this.txtAddress1.SetEditValue(commandParam["address"]);
                    this.txtAddress1.AcceptData();
                    this.txtAddress2.SetEditValue(commandParam["address"]);
                    this.txtAddress2.AcceptData();
                    this.txtAddress2.Focus();
                    this.mCallControl = "";

                    break;

            }

            return base.Command(command, commandParam);
        }

        private void Control_Protect()
        {
            if (grdMaster.RowCount <= 0)
            {
                foreach (object obj in xPanel5.Controls)
                {

                    if (obj.GetType().Name == "XTextBox")
                    {
                        ((XTextBox)obj).Protect = true;
                    }
                }
                
            }
            else
            {
                foreach (object obj in xPanel5.Controls)
                {

                    if (obj.GetType().Name == "XTextBox")
                    {
                        ((XTextBox)obj).Protect = false;
                    }
                }
            }
            
        }
        
        private bool Validate(List<CLIS2015U09ItemInfo> lst)
        {
            foreach (CLIS2015U09ItemInfo item in lst)
            {
                if (item.RowState == "Added" || item.RowState == "Updated" || item.RowState == "Modified")
                {
                    if (item.SmoCode.Trim().Length == 0)
                    {
                        mbxMsg = Resources.MSG_010;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (item.StartDate == "" || item.EndDate == "")
                    {
                        mbxMsg = Resources.MSG_009;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (item.SmoName.Trim().Length == 0)
                    {
                        mbxMsg = Resources.MSG_017;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (item.SmoName1.Trim().Length == 0)
                    {
                        mbxMsg = Resources.MSG_018;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (item.ZipCode1.Trim().Length == 0 || item.ZipCode2.Trim().Length == 0)
                    {
                        mbxMsg = Resources.MSG_012;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (item.Address.Trim().Length == 0)
                    {
                        mbxMsg = Resources.MSG_013;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (item.Tel.Trim().Length == 0)
                    {
                        mbxMsg = Resources.MSG_014;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (item.DodobuhyeunNo == "")
                    {
                        mbxMsg = Resources.MSG_015;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (item.RowState == "Added")
                    {
                        if (CheckSmoCode(item.SmoCode))
                        {
                            mbxMsg = Resources.MSG_001;
                            XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (item.StartDate == "" || item.EndDate == "")
                    {
                        mbxMsg = Resources.MSG_002;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    DateTime startDate = DateTime.ParseExact(item.StartDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    DateTime endDate = DateTime.ParseExact(item.EndDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    if (startDate > endDate)
                    {
                        mbxMsg = Resources.MSG_021;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    int n;
                    bool isNumeric1 = int.TryParse(item.ZipCode1, out n);
                    bool isNumeric2 = int.TryParse(item.ZipCode1, out n);
                    if (!isNumeric1 || !isNumeric2)
                    {
                        mbxMsg = Resources.MSG_003;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    isNumeric1 = int.TryParse(item.Tel, out n);
                    isNumeric2 = true;
                    if (item.Tel1 != "" && item.Tel1 != null)
                    {
                        isNumeric2 = int.TryParse(item.Tel1, out n);
                    }
                    if (!isNumeric1 || !isNumeric2)
                    {
                        mbxMsg = Resources.MSG_019;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (item.Fax != "" && item.Fax != null)
                    {
                        isNumeric1 = int.TryParse(item.Fax, out n);
                        if (!isNumeric1)
                        {
                            mbxMsg = Resources.MSG_020;
                            XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    isNumeric1 = int.TryParse(item.DodobuhyeunNo, out n);
                    if (!isNumeric1)
                    {
                        mbxMsg = Resources.MSG_006;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (item.Email != "" && item.Email !=null && !EmailIsValid(item.Email))
                    {
                        mbxMsg = Resources.MSG_007;
                        XMessageBox.Show(mbxMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool EmailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        

        #endregion

        #region CloudConnector

        private IList<object[]> GetPrefectureCode(BindVarCollection bindVar)
        {
            IList<object[]> res = new List<object[]>();
            CLIS2015U09PrefectureCodeArgs args = new CLIS2015U09PrefectureCodeArgs();
            args.CodeType = bindVar["f_code_type"] != null ? bindVar["f_code_type"].VarValue : "";
            args.Find1 = "";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, CLIS2015U09PrefectureCodeArgs>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo itemInfo in comboResult.ComboItem)
                {
                    res.Add(new object[] { itemInfo.Code, itemInfo.CodeName });
                }
            }
            return res;

        }

        private IList<object[]> ExecuteQueryGrdListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            CLIS2015U09GrdArgs args = new CLIS2015U09GrdArgs();
            CLIS2015U09GrdResult result = CloudService.Instance.Submit<CLIS2015U09GrdResult, CLIS2015U09GrdArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CLIS2015U09ItemInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.ClisSmoId,
                        item.SmoCode,
                        item.StartDate,
                        item.EndDate,
                        item.SmoName,
                        item.SmoName1,
                        item.ZipCode1,
                        item.ZipCode2,
                        item.Address,
                        item.Address1,
                        item.Tel,
                        item.Tel1,
                        item.Fax,
                        item.DodobuhyeunNo,
                        item.CodeName,
                        item.Homepage,
                        item.Email
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private bool CheckSmoForDelete(string clisSmoId)
        {
            CLIS2015U09CheckSmoCodeOnDeleteArgs args = new CLIS2015U09CheckSmoCodeOnDeleteArgs();
            args.ClisSmoId=clisSmoId;
            CLIS2015U09CheckSmoCodeOnDeleteResult result = CloudService.Instance.Submit<CLIS2015U09CheckSmoCodeOnDeleteResult, CLIS2015U09CheckSmoCodeOnDeleteArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                if(Convert.ToInt32(result.Cnt)==0)
                    return true;
            }
            return false;
        }

        #endregion

        private void CLIS2015U09_Closing(object sender, CancelEventArgs e)
        {
            if (this.boolSave == false)
            {
                e.Cancel = true;
            }
        }

        private void CLIS2015U09_Load(object sender, EventArgs e)
        {
            if (NetInfo.Language == LangMode.Vi)
            {
                fbxZip_Code1.Enabled = false;
                fbxAddress.Enabled = false;
            }
        }
    }
}
