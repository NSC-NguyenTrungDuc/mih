using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using EmrDocker.Glossary;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector;
using IHIS.OCSO.Meta;
using System.IO;
using Newtonsoft.Json;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.API.Native.Implementation;
using DevExpress.XtraRichEdit;
using EmrDocker.Meta;
using EmrDocker;
using ERMUserControl;
using System.Data;
using System.Drawing;
using EmrDocker.Models;


namespace IHIS.OCSO
{
    public partial class OCS2015U40 : IHIS.Framework.XScreen
    {
        private string _record_id = string.Empty;
        private string _pkout1001 = string.Empty;
        private string _bunho = string.Empty;
        private string CACHE_HISTORY_MEDICAL_RECORD_BY_VERSION_AND_RECORD_ID = string.Empty;
        private UcGrid ucGrid;
        private UcView _ucView;
        public string Bunho
        {
            get { return _bunho; }
            set { _bunho = value; }
        }
        public OCS2015U40(UcView viewer, string pkout1001)
        {
            InitializeComponent();
            ApplyFont();
            _ucView = viewer;
            ucGrid = new UcGrid();
            ucGrid.IsEnableBtnDo = false;
            ucGrid.SetActiveGridView(false);
            ucGrid.PatientModel = _ucView.ucGrid1.PatientModel;
            if (ucGrid.PatientModel == null) return;
            this._pkout1001 = pkout1001;
            this.Bunho = _ucView.ucGrid1.PatientModel.PatientId;
            this.grdHistoryMedicalRecord.ParamList = new List<string>(new string[]
                {
                    "hosp_code",
                    "bunho",
                    "pkout1001"
                });
            grdHistoryMedicalRecord.ExecuteQuery = GetgrdHistoryMedicalRecord;
            grdHistoryMedicalRecord.QueryLayout(false);
            InitPreviewConten();
        }

        private IList<object[]> GetgrdHistoryMedicalRecord(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS2015U40EmrHistoryMedicalRecordArgs args = new OCS2015U40EmrHistoryMedicalRecordArgs();
            args.HospCode = bvc["hosp_code"].VarValue;
            args.Bunho = bvc["bunho"].VarValue;
            args.Pkout1001 = bvc["pkout1001"].VarValue;

            OCS2015U40EmrHistoryMedicalRecordResult res = CloudService.Instance.Submit<OCS2015U40EmrHistoryMedicalRecordResult, OCS2015U40EmrHistoryMedicalRecordArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.EmrHistoryMedicalRecordItem.ForEach(delegate(OCS2015U40EmrHistoryMedicalRecordInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Version,
                        (int.Parse(item.Version) == 1)? Resources.Added : Resources.Modified,
                        item.Author,
                        item.Created,
                        item.Memo,
                        item.EmrRecordId
                    });
                });
            }
            return lObj;
        }

        private void grdHistoryMedicalRecord_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdHistoryMedicalRecord.Reset();
            this.grdHistoryMedicalRecord.SetBindVarValue("hosp_code", UserInfo.HospCode);
            this.grdHistoryMedicalRecord.SetBindVarValue("bunho", this.Bunho);
            this.grdHistoryMedicalRecord.SetBindVarValue("pkout1001", this._pkout1001);
        }

        private void grdHistoryMedicalRecord_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                int rowNumber = this.grdHistoryMedicalRecord.GetHitRowNumber(e.Y);
                string version = this.grdHistoryMedicalRecord.GetItemString(rowNumber, "version").ToString();
                _record_id = this.grdHistoryMedicalRecord.GetItemString(rowNumber, "emrRecordId").ToString();
                string date = this.grdHistoryMedicalRecord.GetItemString(0, "date").ToString();
                this.LoadEmrRecordContent(_record_id, version, date);
            }
        }

        private void InitPreviewConten()
        {
            if (this.grdHistoryMedicalRecord.RowCount > 0)
            {
                string version = this.grdHistoryMedicalRecord.GetItemString(0, "version").ToString();
                string record_id = this.grdHistoryMedicalRecord.GetItemString(0, "emrRecordId").ToString();
                string date = this.grdHistoryMedicalRecord.GetItemString(0, "date").ToString();
                this.LoadEmrRecordContent(record_id, version, date);
            }
        }

        private void LoadEmrRecordContent(string record_id, string version, string date)
        {
            OCS2015U40EmrMedicalRecordContentArgs args = new OCS2015U40EmrMedicalRecordContentArgs();
            args.RecordId = record_id;
            args.Version = version;
            CACHE_HISTORY_MEDICAL_RECORD_BY_VERSION_AND_RECORD_ID = "OCS.Ocs2015u40.DataSourceByVersionAndRecordId_";
            CACHE_HISTORY_MEDICAL_RECORD_BY_VERSION_AND_RECORD_ID += record_id + "_" + version;
            OCS2015U40EmrMedicalRecordContentResult res = CacheService.Instance.Get<OCS2015U40EmrMedicalRecordContentArgs, OCS2015U40EmrMedicalRecordContentResult>(args);
            if (string.IsNullOrEmpty(res.Content))
            {
                this.ucGrid.Reset(); 
                return;
            }
            this.BindDataContent(res.Content, record_id, res.Metadata);
        }

        /// <summary>
        /// Bind data to content view
        /// </summary>
        /// <param name="emrMml"></param>
        /// <param name="emrMML"></param>
        /// <param name="recordId"></param>
        /// <param name="emrMeta"></param>
        /// <param name="emrXml"></param>
        /// <returns></returns>
        public void BindDataContent(string emrMml, string recordId, string metaData)
        {
            ucGrid.Size = new Size(this.pnlContent.Size.Width, this.pnlContent.Size.Height);
            this.pnlContent.Controls.Add(ucGrid);
            ucGrid.LoadGrid(emrMml, _ucView.ucGrid1.PatientModel, string.Empty, metaData, true, false, null, ScreenEnum.U40);
        }

        private void ApplyFont()
        {
            if (NetInfo.Language == LangMode.Vi || NetInfo.Language == LangMode.En)
            {
                ((System.ComponentModel.ISupportInitialize)(this.grdHistoryMedicalRecord)).BeginInit();

                this.grdHistoryMedicalRecord.RowHeaderFont = Service.COMMON_FONT_BOLD;

                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell1);
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell2);
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell3);
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell13);

                ((System.ComponentModel.ISupportInitialize)(this.grdHistoryMedicalRecord)).EndInit();
            }
        }
    }
}
