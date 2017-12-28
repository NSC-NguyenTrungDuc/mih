using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.NURO
{
    /// <summary>
    /// Form select examination. Implements https://sofiamedix.atlassian.net/browse/MED-11937
    /// </summary>
    public partial class FormSelectExam : Form
    {
        #region Fields && Properties

        private string _hospCode = "";
        private string _bunho = "";
        private ExamInfo _examInfo = new ExamInfo();

        public ExamInfo ExamInfoValue
        {
            get { return _examInfo; }
            set { _examInfo = value; }
        }

        #endregion

        #region Constructors

        public FormSelectExam()
        {
            InitializeComponent();
        }

        public FormSelectExam(string hospCode, string bunho)
        {
            InitializeComponent();

            this._bunho = bunho;
            this._hospCode = hospCode;
        }

        #endregion

        #region Events

        private void grdExamList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdExamList.SetBindVarValue("f_hosp_code", this._hospCode);
            grdExamList.SetBindVarValue("f_bunho", this._bunho);
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    grdExamList.QueryLayout(true);
                    break;
                case FunctionType.Process:
                    e.IsBaseCall = false;
                    this.SetExamInfo();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case FunctionType.Close:
                    e.IsBaseCall = false;
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void FormSelectExam_Load(object sender, EventArgs e)
        {
            InitCloud();
            btnList.PerformClick(FunctionType.Query);
        }

        private void grdExamList_MouseDown(object sender, MouseEventArgs e)
        {
            // Skips header row
            if (grdExamList.GetHitRowNumber(e.Y) < 0)
            {
                return;
            }

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                btnList.PerformClick(FunctionType.Process);
            }
        }

        #endregion

        #region Methods

        private void InitCloud()
        {
            this.grdExamList.ParamList = new List<string>(new string[] { "f_hosp_code", "f_bunho" });
            this.grdExamList.ExecuteQuery = this.GetGrdExamList;
        }

        private List<object[]> GetGrdExamList(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            NUR2015U01GrdOrderArgs args = new NUR2015U01GrdOrderArgs();
            args.Bunho = bc["f_bunho"].VarValue;
            args.HospCode = bc["f_hosp_code"].VarValue;

            NUR2015U01GrdOrderResult result =
                CloudService.Instance.Submit<NUR2015U01GrdOrderResult, NUR2015U01GrdOrderArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (NUR2015U01GrdOrderInfo info in result.GrdOrderList)
                {
                    lObj.Add(new object[]
                    {
                        info.ExamDate,
                        info.Gwa,
                        info.GwaName,
                        info.NaewonKey,
                    });
                }
            }

            return lObj;
        }

        private void SetExamInfo()
        {
            this._examInfo.Gwa = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "gwa");
            this._examInfo.GwaName = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "gwa_name");
            this._examInfo.NaewonDate = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "naewon_date");
            this._examInfo.NaewonKey = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "naewon_key");
            //this._examInfo.Suname = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "suname");
            //this._examInfo.Address1 = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "address1");
            //this._examInfo.Birth = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "birth");
            //this._examInfo.Sex = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "sex");
            //this._examInfo.Tel = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "tel");
            //this._examInfo.Email = this.grdExamList.GetItemString(grdExamList.CurrentRowNumber, "email");
        }

        #endregion

        #region ExamInfo

        /// <summary>
        /// Stored each of examination information record
        /// </summary>
        public class ExamInfo
        {
            private string _naewonDate = "";
            private string _gwa = "";
            private string _gwaName = "";
            private string _naewonKey = "";
            private string _suname = "";
            private string _address1 = "";
            private string _birth = "";
            private string _sex = "";
            private string _tel = "";
            private string _email = "";

            public string NaewonDate
            {
                get { return _naewonDate; }
                set { _naewonDate = value; }
            }

            public string Gwa
            {
                get { return _gwa; }
                set { _gwa = value; }
            }

            public string GwaName
            {
                get { return _gwaName; }
                set { _gwaName = value; }
            }

            public string NaewonKey
            {
                get { return _naewonKey; }
                set { _naewonKey = value; }
            }

            public string Suname
            {
                get { return _suname; }
                set { _suname = value; }
            }

            public string Address1
            {
                get { return _address1; }
                set { _address1 = value; }
            }

            public string Birth
            {
                get { return _birth; }
                set { _birth = value; }
            }

            public string Sex
            {
                get { return _sex; }
                set { _sex = value; }
            }

            public string Tel
            {
                get { return _tel; }
                set { _tel = value; }
            }

            public string Email
            {
                get { return _email; }
                set { _email = value; }
            }

            public ExamInfo()
            {
            }
        }

        #endregion
    }
}