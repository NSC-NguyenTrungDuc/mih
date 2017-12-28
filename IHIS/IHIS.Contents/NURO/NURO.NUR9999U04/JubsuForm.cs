
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Phys;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.NURO;
using IHIS.NURO.Properties;

namespace IHIS.NURO
{
    public partial class JubsuForm : XForm
    {
        string pkout1001 = "";
        public JubsuForm(string pkout1001)
        {
            this.pkout1001 = pkout1001;

            InitializeComponent();

            cboGwa.ExecuteQuery = LoadCboGwa;
            cboGwa.SetDictDDLB();
            cboDoctor.ParamList = CreateCboDoctorParamList();
            cboDoctor.ExecuteQuery = LoadCboDoctor;
            cboDoctor.SetDictDDLB();
            cboJubsuGubun.ExecuteQuery = LoadCboJubsuGubun;
            cboJubsuGubun.SetDictDDLB();
        }

        private void cboDoctor_DDLBSetting(object sender, EventArgs e)
        {
            this.cboDoctor.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
        }

        private void cboGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cboDoctor.SetDictDDLB();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJubsu_Click(object sender, EventArgs e)
        {
            if (this.cboGwa.GetDataValue() == "")
            {
                XMessageBox.Show(Resources.MSG031_MSG, Resources.MSG031_CAP, MessageBoxIcon.Information);
                return;
            }

            if (this.cboDoctor.GetDataValue() == "")
            {
                XMessageBox.Show(Resources.MSG032_MSG, Resources.MSG031_CAP, MessageBoxIcon.Information);
                return;
            }

            if (this.cboJubsuGubun.GetDataValue() == "")
            {
                XMessageBox.Show(Resources.MSG033_MSG, Resources.MSG031_CAP, MessageBoxIcon.Information);
                return;
            }

            /*ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(this.pkout1001);
            inputList.Add(this.cboGwa.GetDataValue());
            inputList.Add(this.cboDoctor.GetDataValue());
            inputList.Add(this.cboJubsuGubun.GetDataValue());
            inputList.Add(UserInfo.UserID);*/

            PHY2001U04PrOutMakeAutoJubsuArgs args = new PHY2001U04PrOutMakeAutoJubsuArgs();
            args.Pkout1001 = this.pkout1001;
            args.Gwa = this.cboGwa.GetDataValue();
            args.Doctor = this.cboDoctor.GetDataValue();
            args.JubsuGubun = this.cboJubsuGubun.GetDataValue();
            args.UserId = UserInfo.UserID;
            args.Bunho = "";
            args.NaewonDate = "";
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, PHY2001U04PrOutMakeAutoJubsuArgs>(args);

            //if (!Service.ExecuteProcedure("PR_OUT_MAKE_AUTO_JUBSU", inputList, outputList))
            if (result.ExecutionStatus != ExecutionStatus.Success || !result.Result)
            {
                XMessageBox.Show(Resources.MSG034_MSG + Service.ErrFullMsg, Resources.MSG034_CAP, MessageBoxIcon.Warning);
                return;
            }
            

            /*if (outputList != null)
            {
                if (outputList[1] != null)
                {
                    if (outputList[1].ToString() != "0")
                    {
                        XMessageBox.Show(Resources.MSG034_MSG + Service.ErrFullMsg, Resources.MSG034_CAP, MessageBoxIcon.Warning);
                        return;                    
                    }
                }
            }*/

            this.Close();
        }

        private void JubsuForm_Load(object sender, EventArgs e)
        {
            if(this.cboJubsuGubun.ComboItems.Count > 0)
                this.cboJubsuGubun.SelectedIndex = 0;
        }

        #region cloud services

        private List<object[]> LoadCboGwa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            NUR2001U04CboGwaArgs args = new NUR2001U04CboGwaArgs();
            ComboResult result =
                CacheService.Instance.Get<NUR2001U04CboGwaArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    object[] objects = 
				    { 
					    item.Code,
                        item.CodeName
				    };
                    res.Add(objects);
                }
            }
            return res;
        } 

        private List<string> CreateCboDoctorParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_gwa");
            return paramList;
        }

        private List<object[]> LoadCboDoctor(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            NUR2001U04CboDoctorArgs args = new NUR2001U04CboDoctorArgs();
            args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : ""; 
            ComboResult result = CloudService.Instance.Submit<ComboResult, NUR2001U04CboDoctorArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    object[] objects = 
				    { 
					    item.Code,
                        item.CodeName
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadCboJubsuGubun(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY2001U04GrdCboJubsuGubunArgs args = new PHY2001U04GrdCboJubsuGubunArgs();
            ComboResult result =
                CacheService.Instance.Get<PHY2001U04GrdCboJubsuGubunArgs, ComboResult>(args, delegate(ComboResult comboResult)
                    {
                        return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
                               comboResult.ComboItem.Count > 0;
                    });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    object[] objects = 
				    { 
					    item.Code,
                        item.CodeName
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion
    }
}