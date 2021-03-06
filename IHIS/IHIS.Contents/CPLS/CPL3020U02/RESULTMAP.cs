using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using System.Collections;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;

namespace IHIS.CPLS
{
    public partial class RESULTMAP : XForm
    {
        public RESULTMAP()
        {
            InitializeComponent();
        }

        #region ƒVƒXƒeƒ€•Ï”

        private string equip_code = "";

        private string suname = "";
        private string specimen_ser = "";

        public string procYN = "N";

        #endregion

        public RESULTMAP(string equip_code, string equip_name, string from_date, string to_date, string suname, string specimen_ser)
        {
            InitializeComponent();

            this.equip_code = equip_code;
            this.dbxEquip.Text = equip_name;

            this.dtpFromDate.SetDataValue(from_date);
            this.dtpToDate.SetDataValue(to_date);

            this.suname = suname;
            this.specimen_ser = specimen_ser;

            this.dbxSuname.Text = suname;
            this.dbxSpecimen_ser.Text = specimen_ser;

            //added by Cloud Version 
            this.grdIDList.ParamList = new List<string>(new String[] { "f_hosp_code", "f_jangbi_code", "f_from_date", "f_to_date", "f_specimen_ser", "f_all_yn" });
            this.grdIDList.ExecuteQuery = LoadDataGrdIDList;

            this.grdResultList.ParamList = new List<string>(new String[] { "f_hosp_code", "f_jangbi_code", "f_result_date", "f_sample_id" });
            this.grdResultList.ExecuteQuery = LoadDataGrdResultList;
        }

        #region RESULTMAP_Load
        private void RESULTMAP_Load(object sender, EventArgs e)
        {
            this.grdIDList.QueryLayout(true);
        }
        #endregion

        #region GRID EVENT
        private void grdIDList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdIDList.Reset();

            this.grdIDList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdIDList.SetBindVarValue("f_jangbi_code", this.equip_code);
            this.grdIDList.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdIDList.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.grdIDList.SetBindVarValue("f_specimen_ser", this.specimen_ser);

            if(this.cbxAll.Checked)
                this.grdIDList.SetBindVarValue("f_all_yn", "Y");
            else
                this.grdIDList.SetBindVarValue("f_all_yn", "N");
        }

        private void grdIDList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdResultList.QueryLayout(true);
        }

        private void grdIDList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdIDList.RowCount < 1) this.grdResultList.QueryLayout(true); 
        }

        private void grdResultList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdResultList.Reset();

            this.grdResultList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdResultList.SetBindVarValue("f_jangbi_code", this.equip_code);
            this.grdResultList.SetBindVarValue("f_result_date", this.grdIDList.GetItemString(this.grdIDList.CurrentRowNumber, "result_date"));
            this.grdResultList.SetBindVarValue("f_sample_id", this.grdIDList.GetItemString(this.grdIDList.CurrentRowNumber, "sample_id"));
        }
        #endregion

        #region Date_DataValidating
        private void dtpFromDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void dtpToDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region cbxAll_CheckedChanged
        private void cbxAll_CheckedChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region btnList_ButtonClick
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;
                    this.grdIDList.QueryLayout(true);

                    break;

                case FunctionType.Process:
                    e.IsBaseCall = false;

                    if (XMessageBox.Show("[" + suname + "]" + "患者さんの" + "[" + specimen_ser + "]の検体に結果マッチングを行いますか？", "検体確認", MessageBoxButtons.YesNo) == DialogResult.Yes) this.matchProcess("Y");
                    else return;

                    break;

                case FunctionType.Cancel:
                    e.IsBaseCall = false;

                    if (this.grdIDList.GetItemString(this.grdIDList.CurrentRowNumber, "specimen_ser") == "") return;

                    if (XMessageBox.Show("選択した検体結果取消を行いますか？", "結果取消", MessageBoxButtons.YesNo) == DialogResult.Yes) this.matchProcess("N");
                    else return;

                    break;

                case FunctionType.Close:
                    break;
            }
        }
        #endregion

        #region speciment match proc
        //modified by Cloud version
        private void matchProcess(string proc_gubun)
        {
            //Hashtable inputList = new Hashtable();
            //Hashtable outputList = new Hashtable();
            List<CPL3020U02PrCplResultMatchProcInfo> inputList = new List<CPL3020U02PrCplResultMatchProcInfo>();

            for (int i = 0; i < grdResultList.RowCount; i++)
            {
                //inputList.Clear();
                //outputList.Clear();

                //inputList.Add("I_PROC_GUBUN", proc_gubun); 

                //// cpl3020
                //inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode); 
                //if(proc_gubun == "Y") inputList.Add("I_SPECIMEN_SER", specimen_ser);
                //else inputList.Add("I_SPECIMEN_SER", this.grdIDList.GetItemString(this.grdIDList.CurrentRowNumber, "specimen_ser"));
                //inputList.Add("I_HANGMOG_CODE", this.grdResultList.GetItemString(i, "hangmog_code"));
                //inputList.Add("I_RESULT_VAL", this.grdResultList.GetItemString(i, "result_val"));

                //// cpl0891
                //inputList.Add("I_JANGBI_CODE", this.equip_code);
                //inputList.Add("I_RESULT_DATE", this.grdIDList.GetItemString(this.grdIDList.CurrentRowNumber, "result_date"));
                //inputList.Add("I_SAMPLE_ID", this.grdIDList.GetItemString(this.grdIDList.CurrentRowNumber, "sample_id"));
                //inputList.Add("I_RESULT_CODE", this.grdResultList.GetItemString(i, "result_code"));

                //if (!Service.ExecuteProcedure("PR_CPL_RESULT_MATCH_PROC", inputList, outputList))
                //{
                //    XMessageBox.Show("PR_CPL_RESULT_MATCH_PROC\r\n" + Service.ErrFullMsg, "", MessageBoxIcon.Error);
                //    return;
                //}
                CPL3020U02PrCplResultMatchProcInfo info = new CPL3020U02PrCplResultMatchProcInfo();
                info.ProcGubun = proc_gubun;
                // cpl3020
                if (proc_gubun == "Y") info.SpecimenSer = specimen_ser;
                else info.SpecimenSer = this.grdIDList.GetItemString(this.grdIDList.CurrentRowNumber, "specimen_ser");
                info.HangmogCode = this.grdResultList.GetItemString(i, "hangmog_code");
                info.ResultVal = this.grdResultList.GetItemString(i, "result_val");
                // cpl0891
                info.JangbiCode = this.equip_code;
                info.ResultDate = this.grdIDList.GetItemString(this.grdIDList.CurrentRowNumber, "result_date");
                info.SampleId = this.grdIDList.GetItemString(this.grdIDList.CurrentRowNumber, "sample_id");
                info.ResultCode = this.grdResultList.GetItemString(i, "result_code");

                inputList.Add(info);
            }
            CPL3020U02PrCplResultMatchProcArgs args = new CPL3020U02PrCplResultMatchProcArgs(inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, CPL3020U02PrCplResultMatchProcArgs>(args);
            if (result.ExecutionStatus != ExecutionStatus.Success || !result.Result)
            {
                XMessageBox.Show("PR_CPL_RESULT_MATCH_PROC\r\n" + Service.ErrFullMsg, "", MessageBoxIcon.Error);
                return;                
            }

            this.procYN = "Y";

            this.btnList.PerformClick(FunctionType.Close);
        }
        #endregion

        #region Cloud Service
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdIDList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3020U02ResultMapGrdIDArgs args = new CPL3020U02ResultMapGrdIDArgs();
            args.AllYn = bc["f_all_yn"] != null ? bc["f_all_yn"].VarValue : "";
            args.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            args.JangbiCode = bc["f_jangbi_code"] != null ? bc["f_jangbi_code"].VarValue : "";
            args.SpecimenSer = bc["f_specimen_ser"] != null ? bc["f_specimen_ser"].VarValue : "";
            args.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            CPL3020U02ResultMapGrdIDResult result = CloudService.Instance.Submit<CPL3020U02ResultMapGrdIDResult, CPL3020U02ResultMapGrdIDArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3020U02ResultMapGrdIDInfo item in result.GrdIDList)
                {
                    object[] objects = 
                    { 
                        item.ResultDate, 
                        item.ProcTime, 
                        item.SampleId, 
                        item.SpecimenSer, 
                        item.PatientId
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdResultList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3020U02ResultMapGrdRsltArgs args = new CPL3020U02ResultMapGrdRsltArgs();
            args.JangbiCode = bc["f_jangbi_code"] != null ? bc["f_jangbi_code"].VarValue : "";
            args.ResultDate = bc["f_result_date"] != null ? bc["f_result_date"].VarValue : "";
            args.SampleId = bc["f_sample_id"] != null ? bc["f_sample_id"].VarValue : "";
            CPL3020U02ResultMapGrdRsltResult result = CloudService.Instance.Submit<CPL3020U02ResultMapGrdRsltResult, CPL3020U02ResultMapGrdRsltArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3020U02ResultMapGrdRsltInfo item in result.GrdResultList)
                {
                    object[] objects = 
                    { 
                        item.ResultCode, 
                        item.HangmogCode, 
                        item.GumsaName,
                        item.ResultVal
                    };
                    res.Add(objects);
                }
            }
            return res;
        } 
        #endregion
    }
}