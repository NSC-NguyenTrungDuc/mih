using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;

using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;


namespace IHIS.BASS
{
    public partial class BunhoSelectForm : XForm
    {
        string mReturnBunho = "";
        public string ReturnBunho
        {
            get
            { return mReturnBunho; }
        }

        private List<string> _values;
        public List<string> Values
        {
            get { return _values; }
        }

        public BunhoSelectForm()
        {
            mHospCode = EnvironInfo.HospCode;
            InitializeComponent();
            this.grdPAList.ParamList = new List<String>(new String[] { "f_hosp_code"});
            //set ExecuteQuery
            grdPAList.ExecuteQuery = LoadDataDepatments;

            LoadComboBox();

            //this.FormBorderStyle = FormBorderStyle.None;
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(10, 10);
        }

        private void LoadComboBox()
        {
            Bas0260U01LoadDepartmentTypeArgs args = new Bas0260U01LoadDepartmentTypeArgs();
            args.HospCode = this.mHospCode;
            args.CodeType = "BUSEO_GUBUN";
            Bas0260U01LoadDepartmentTypeResult result = CloudService.Instance.Submit<Bas0260U01LoadDepartmentTypeResult, Bas0260U01LoadDepartmentTypeArgs>(args);

            DataTable table = new DataTable();
            table.Columns.Add("Code");
            table.Columns.Add("CodeName");

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (LoadDepartmentTypeInfo item in result.ListInfo)
                {
                    table.Rows.Add(item.Code, item.CodeName);
                }
            }
            cboBuseoGubun.SetComboItems(table, "CodeName","Code");

        }

        private string mHospCode = "";
        private void BunhoSelectForm_Load(object sender, EventArgs e)
        {
            mHospCode = EnvironInfo.HospCode;

            this.grdPAList.QueryLayout(false);
        }

        private void grdPAList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPAList.SetBindVarValue("f_hosp_code", this.mHospCode);
            //if (this.cbxQueryFlag.Checked)
            //    this.grdPAList.SetBindVarValue("f_query_flag", "ALL");
            //else
            //    this.grdPAList.SetBindVarValue("f_query_flag", "NOTALL");

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.grdPAList.CurrentRowNumber < 0)
                return;

            GetValues(this.grdPAList.CurrentRowNumber);
            this.Close();
        }

        private void grdPAList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                int rowNum = this.grdPAList.GetHitRowNumber(e.Y);

                if (rowNum < 0)
                    return;
                
                GetValues(rowNum);

                this.Close();
            }
        }

        private void GetValues(int rowNum)
        {
            _values = new List<string>();
            _values.Add(this.grdPAList.GetItemString(rowNum, "BUSEO_CODE"));
            _values.Add(this.grdPAList.GetItemString(rowNum, "BUSEO_NAME"));
            _values.Add(this.grdPAList.GetItemString(rowNum, "BUSEO_NAME2"));
            _values.Add(this.grdPAList.GetItemString(rowNum, "BUSEO_GUBUN"));
            _values.Add(this.grdPAList.GetItemString(rowNum, "PARENT_BUSEO"));
            _values.Add(this.grdPAList.GetItemString(rowNum, "GWA"));
            _values.Add(this.grdPAList.GetItemString(rowNum, "GWA_NAME"));
            _values.Add(this.grdPAList.GetItemString(rowNum, "GWA_NAME2"));
            _values.Add(this.grdPAList.GetItemString(rowNum, "GWA_GUBUN"));
            _values.Add(this.grdPAList.GetItemString(rowNum, "PARENT_GWA"));
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.grdPAList.QueryLayout(false);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<object[]> LoadDataDepatments(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            Bass0260U00DepartmentArgs args = new Bass0260U00DepartmentArgs();
            args.GwaName = xTextBoxGwaName.Text;
            args.BuseoGubun = cboBuseoGubun.GetDataValue();
            //args.BuseoGubun = "";

            Bass0260U00DepartmentResult result = CloudService.Instance.Submit<Bass0260U00DepartmentResult, Bass0260U00DepartmentArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (Bass0260U00DepartmentInfo item in result.ItemInfo)
                {
                    object[] objects =
	                {
                        item.BuseoCode,
                        item.BuseoName,
	                    item.BuseoName2,
	                    item.BuseoGubun,
                        item.ParentBuseo,
                        item.Gwa,
                        item.GwaName,
                        item.GwaName2,
                        item.GwaGubun,
                        item.ParentGwa
	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private void cboBuseoGubun_SelectedValueChanged(object sender, EventArgs e)
        {
            this.grdPAList.QueryLayout(false);
        }

    }
}