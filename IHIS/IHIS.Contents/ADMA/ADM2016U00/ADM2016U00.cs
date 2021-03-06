using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Caching;
using IHIS.Framework;
using IHIS.ADMA.Properties;


namespace IHIS.ADMA
{
    public partial class ADM2016U00 : IHIS.Framework.XScreen
    {
        public ADM2016U00()
        {
            InitializeComponent();
 
            grdLoadAccount.ParamList = new List<string>(new string[] { "f_page_number", "f_offset"});
            grdLoadAccount.ExecuteQuery = LoadGrdDrg;
            cbxType.ExecuteQuery = LoadComboData;
            cbxType.SetDictDDLB();
            cbxType.SetEditValue("");
            cbxAccount.SetEditValue("All");
            
        }

        #region ================== Event===========================     
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    grdLoadAccount.QueryLayout(false);
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    SaveData();
                    grdLoadAccount.QueryLayout(false);
                    break;
                case FunctionType.Close:
                    break;
            }
        }
        private void ADM2016U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            grdLoadAccount.QueryLayout(false);
        }

        private void grdLoadAccount_GridCellFocusChanged(object sender, XGridCellFocusChangedEventArgs e)
        {
            if (grdLoadAccount.GetItemString(grdLoadAccount.CurrentRowNumber, "use_yn") == "Y" && grdLoadAccount.GetRowState(grdLoadAccount.CurrentRowNumber) == DataRowState.Unchanged)
            {
                grdLoadAccount.ReadOnly = true;
            }
            else
            {
                grdLoadAccount.ReadOnly = false;
            }
        }

        #endregion=================================================
       
        #region ================== Method===========================
        
        private void SaveData()
        {
            HOTCODEMASTERSaveArgs args = new HOTCODEMASTERSaveArgs();
            args.HotCodeInfo = GetHotCodeInfo();
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, HOTCODEMASTERSaveArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
            {
                XMessageBox.Show(Resources.MSG2, Resources.CAP2, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (res != null && res.Result == false)
                {                   
                    XMessageBox.Show(Resources.MSG1, Resources.CAP1, MessageBoxIcon.Warning);
                }

            }
        }

        //Cannot untick if tick and save successfully
        private List<ADM2016U00GrdLoadDrgInfo> GetHotCodeInfo()
        {
            List<ADM2016U00GrdLoadDrgInfo> lstData = new List<ADM2016U00GrdLoadDrgInfo>();
            for (int i = 0; i < grdLoadAccount.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdLoadAccount.GetRowState(i) == DataRowState.Unchanged) continue;
                if (grdLoadAccount.GetItemString(i, "use_yn") == "Y")
                {
                    ADM2016U00GrdLoadDrgInfo item = new ADM2016U00GrdLoadDrgInfo();
                    item.A1 = grdLoadAccount.GetItemString(i, "A1");
                    lstData.Add(item);
                }

            }
            return lstData;
        }
       
        #endregion=================================================

        #region ================== Cloud===========================
        private List<object[]> LoadGrdDrg(BindVarCollection bc)
        { 
            List<object[]> res = new List<object[]>();
            ADM2016U00GrdLoadDrgArgs args = new ADM2016U00GrdLoadDrgArgs();
            args.SearchName = txtName.Text;
            args.SearchType = cbxType.GetDataValue().ToString();
            args.SearchAccount = cbxAccount.GetDataValue();
            args.Offset = "200";
            args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            ADM2016U00GrdLoadDrgResult result = CloudService.Instance.Submit<ADM2016U00GrdLoadDrgResult, ADM2016U00GrdLoadDrgArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM2016U00GrdLoadDrgInfo item in result.ItemInfo)
                {
                    object[] objects = 
				{ 
					 item.A1,
                    item.A2,
                    item.A3,
                    item.A4,
                    item.A5,
                    item.A6,
                    item.A7,
                    item.A8,
                    item.A9,
                    item.A10,
                    item.A11,
                    item.A12,
                    item.A13,
                    item.A14,
                    item.A15,
                    item.A16,
                    item.A17,
                    item.A18,
                    item.A19,
                    item.A20,
                    item.A21,
                    item.A22,
                    item.A23,
                    item.A24,
                    item.UseYn
				};
                    res.Add(objects);
                }
            }
            return res;
        }
        //Load HotCode Drg by tick checkbox
        private List<object[]> LoadCheckDrg(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            return res;
        }

        private List<object[]> LoadComboData(BindVarCollection bc)
        {
            List<object[]> lstResult = new List<object[]>();

            ADM2016U00NameTypeArgs argsCbo = new ADM2016U00NameTypeArgs();
            ComboResult result = CacheService.Instance.Get<ADM2016U00NameTypeArgs, ComboResult>(argsCbo, delegate(ComboResult r)
            {
                return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            });
            if (result != null)
            {
                List<ComboListItemInfo> listItem = result.ComboItem;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }

         #endregion=================================================
       
    }
}
