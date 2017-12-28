using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.PHYS;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Phys;
using IHIS.CloudConnector.Contracts.Models.Phys;
using IHIS.CloudConnector.Contracts.Results.Phys;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Utility;
using IHIS.PHYS.Properties;

namespace IHIS.PHYS
{
    public partial class JubsuForm : XForm
    {
        string pkout1001 = "";

        public JubsuForm(string pkout1001)
        {
            this.pkout1001 = pkout1001;

            InitializeComponent();

            // updated by Cloud
            InitializeCloud();
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
                XMessageBox.Show(Resources.XMessageBox1, Resources.XMessageBox_Caption1, MessageBoxIcon.Information);
                return;
            }

            if (this.cboDoctor.GetDataValue() == "")
            {
                XMessageBox.Show(Resources.XMessageBox1, Resources.XMessageBox_Caption1, MessageBoxIcon.Information);
                return;
            }

            if (this.cboJubsuGubun.GetDataValue() == "")
            {
                XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_Caption1, MessageBoxIcon.Information);
                return;
            }

            #region deleted by Cloud
            //ArrayList inputList = new ArrayList();
            //ArrayList outputList = new ArrayList();

            //inputList.Add(this.pkout1001);
            //inputList.Add(this.cboGwa.GetDataValue());
            //inputList.Add(this.cboDoctor.GetDataValue());
            //inputList.Add(this.cboJubsuGubun.GetDataValue());
            //inputList.Add(UserInfo.UserID);

            //if (!Service.ExecuteProcedure("PR_OUT_MAKE_AUTO_JUBSU", inputList, outputList))
            //{
            //    XMessageBox.Show("受付データの生成に失敗しました。\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
            //    return;
            //}

            //if (outputList != null)
            //{
            //    if (outputList[1] != null)
            //    {
            //        if (outputList[1].ToString() != "0")
            //        {
            //            XMessageBox.Show("受付データの生成に失敗しました。\r\n" + Service.ErrFullMsg, "受付失敗", MessageBoxIcon.Warning);
            //            return;
            //        }
            //    }
            //}
            #endregion

            // updated by Cloud
            PHY2001U04PrOutMakeAutoJubsuArgs args = new PHY2001U04PrOutMakeAutoJubsuArgs();
            args.Pkout1001 = pkout1001;
            args.Gwa = cboGwa.GetDataValue();
            args.Doctor = cboDoctor.GetDataValue();
            args.JubsuGubun = cboJubsuGubun.GetDataValue();
            args.UserId = UserInfo.UserID;
            args.Bunho = ""; // unused
            args.NaewonDate = ""; // unused
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, PHY2001U04PrOutMakeAutoJubsuArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.Msg != "0")
                {
                    XMessageBox.Show(Resources.XMessageBox3 + Service.ErrFullMsg, Resources.XMessageBox_Caption3, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                XMessageBox.Show(Resources.XMessageBox3 + Service.ErrFullMsg, Resources.XMessageBox_Caption3, MessageBoxIcon.Warning);
                return;
            }

            this.Close();
        }

        private void JubsuForm_Load(object sender, EventArgs e)
        {
            if(this.cboJubsuGubun.ComboItems.Count > 0)
                this.cboJubsuGubun.SelectedIndex = 0;
        }

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            // cboGwa
            cboGwa.ExecuteQuery = GetCboGwa;
            cboGwa.SetDictDDLB();

            // cboDoctor
            cboDoctor.ParamList = new List<string>(new string[] { "f_gwa" });
            cboDoctor.ExecuteQuery = GetCboDoctor;

            // cboJubsuGubun
            cboJubsuGubun.ExecuteQuery = GetCboJubsuGubun;
            cboJubsuGubun.SetDictDDLB();
        }
        #endregion

        #region GetCboGwa
        /// <summary>
        /// GetCboGwa
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboGwa(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ComboResult res = CloudService.Instance.Submit<ComboResult, PHY2001U04JubsuFormCboGwaArgs>(new PHY2001U04JubsuFormCboGwaArgs());
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

        #region GetCboDoctor
        /// <summary>
        /// GetCboDoctor
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboDoctor(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PHY2001U04CboDoctorArgs args = new PHY2001U04CboDoctorArgs();
            args.Gwa = bvc["f_gwa"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, PHY2001U04CboDoctorArgs>(args);

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

        #region GetCboJubsuGubun
        /// <summary>
        /// GetCboJubsuGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboJubsuGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ComboResult res = CacheService.Instance.Get<PHY2001U04GrdCboJubsuGubunArgs, ComboResult>(new PHY2001U04GrdCboJubsuGubunArgs(), delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
                });

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