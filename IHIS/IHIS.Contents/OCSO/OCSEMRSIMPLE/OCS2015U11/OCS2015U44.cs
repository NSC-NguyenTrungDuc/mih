using DevExpress.XtraEditors.Controls;
using EmrDockerS;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.OCSO
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    using DevExpress.XtraBars;
    using DevExpress.XtraRichEdit;
    using DevExpress.XtraRichEdit.API.Native;
    using DevExpress.XtraRichEdit.API.Native.Implementation;
    using DevExpress.XtraRichEdit.UI;

    using global::EmrDocker;
    using global::EmrDocker.Meta;

    using GhostscriptSharp;

    using IHIS.CloudConnector;
    using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
    using IHIS.CloudConnector.Contracts.Results;
    using IHIS.CloudConnector.Contracts.Results.System;
    using IHIS.Framework;
    using IHIS.OCSO.Meta;

    using Newtonsoft.Json;
    using DevExpress.Utils.Menu;
    using DevExpress.XtraRichEdit.Commands;

    using global::EmrDocker.Glossary;
    using global::EmrDocker.Types;
    using System.Data;
    using ERMUserControl;
    using global::EmrDocker.Models;

    public partial class OCS2015U44 : Form
    {
        private Dictionary<string, UserData> metaDictionary = new Dictionary<string, UserData>();
        private string emrRecordId;
        private string bunho;
        private string _pkout;
        private List<OcsoOCS1003P01GridOutSangInfo> _lstOcsoOcs1003P01GridOutSangInfos = new List<OcsoOCS1003P01GridOutSangInfo>();
        //public event EventHandler UpdateEmrViewer;

        public delegate void UpdateEmrDataHandler(object sender, UpdateDataEmrAgrs e);
        public event UpdateEmrDataHandler UpdateEmrViewer;

        private UcGrid ucGrid;

        public string Pkout
        {
            get { return _pkout; }
            set { _pkout = value; }
        }
        public OCS2015U44()
        {
            InitializeComponent();
        }

        public OCS2015U44(string mml, string record_id, PatientModelInfo patientModelInfo, string dicCommentInfo)
            : this()
        {
            /*this.emrRecordId = record_id;
            this.bunho = patientModelInfo.PatientId;
            InitGrdViewer(mml, patientModelInfo, dicCommentInfo);
            //DataProvider.Instance.TagDisplayModeSetup(barTagOptions);
            LoadCboDisplayTag();
            //cboDisplay1.Location = new Point(264, 7);*/

            LoadFormOCS2015U44(mml, record_id, patientModelInfo, dicCommentInfo);
        }

        public OCS2015U44(string mml, string record_id, PatientModelInfo patientModelInfo, string dicCommentInfo, List<OcsoOCS1003P01GridOutSangInfo> pListOcsoOCS1003P01GridOutSangInfo)
            : this()
        {
            if (_lstOcsoOcs1003P01GridOutSangInfos.Count > 0) _lstOcsoOcs1003P01GridOutSangInfos.Clear();
            _lstOcsoOcs1003P01GridOutSangInfos = pListOcsoOCS1003P01GridOutSangInfo;

            LoadFormOCS2015U44(mml, record_id, patientModelInfo, dicCommentInfo);
        }

        private void LoadFormOCS2015U44(string mml, string record_id, PatientModelInfo patientModelInfo, string dicCommentInfo)
        {
            this.emrRecordId = record_id;
            this.bunho = patientModelInfo.PatientId;
            InitGrdViewer(mml, patientModelInfo, dicCommentInfo);
            //DataProvider.Instance.TagDisplayModeSetup(barTagOptions);
            LoadCboDisplayTag();
            //cboDisplay1.Location = new Point(264, 7);
        }

        private void InitGrdViewer(string mmlData, PatientModelInfo patientModelInfo, string dicCommentInfo)
        {
            ucGrid = new UcGrid();
            ucGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Controls.Add(ucGrid);
            ucGrid.LstOcsoOCS1003P01GridOutSangInfo = _lstOcsoOcs1003P01GridOutSangInfos;
            ucGrid.LoadGrid(mmlData, patientModelInfo, string.Empty, dicCommentInfo, true, false, null, ScreenEnum.U44);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
        }

        private void insertImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CLIP";
            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
                EditImage(dialog.FileName);
        }

        private void insertPdfItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pdf Files|*.pdf";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(dialog.FileName);
                if (ext.ToLower() == ".pdf")
                {
                    string max_size = string.Empty;
                    if (!Utilities.CheckPdfUploadFile(dialog.FileName, out max_size))
                    {
                        XMessageBox.Show(string.Format(Resources.EMR_PDF_MAX_SIZE, max_size), Resources.WARN);
                        return;
                    }
                    string originalFilePath = dialog.FileName;
                    string pdfLink = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(bunho, Path.GetFileName(originalFilePath), "pdf"), bunho);
                    File.Copy(originalFilePath, pdfLink);

                    string pdfHash = Utilities.CalculateFileChecksum(pdfLink);
                    string thumbnailFilePath;

                    FileDocumentImageSource image = Utilities.GetPdfThumbnail(pdfLink, out thumbnailFilePath);
                    string thumbnailHash = Utilities.CalculateImageChecksum(image.Stream);
                    if (!metaDictionary.ContainsKey(thumbnailHash))
                        metaDictionary.Add(thumbnailHash, new PdfMeta(pdfHash, pdfLink, new ImageMeta(thumbnailHash, thumbnailFilePath, 0.25f, 0.25f)));
                    ucGrid.InsertImage(thumbnailFilePath, TypeEnum.Pdf, pdfLink, ActionType.Insert, true);
                }
            }
        }

        public static void CancelSaving(string emrRecordId, string updId)
        {
            if (CloudService.Instance.Connect())
            {
                OCS2015U00EmrRecordUnlockArgs args = new OCS2015U00EmrRecordUnlockArgs();
                args.RecordId = emrRecordId;
                args.UpdId = updId;
                args.ScreenId = "OCS2015U06";
                CloudService.Instance.Submit<UpdateResult, OCS2015U00EmrRecordUnlockArgs>(args);
            }
        }

        private void EditImage(string imagePath)
        {
            this.ucGrid.InsertImage(imagePath, TypeEnum.Image, imagePath, ActionType.Insert, true);
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barTag = (BarEditItem)sender;
            string tag = barTag.EditValue.ToString();
            TagOption code = StringEnum.Parse<TagOption>(tag);

            int indexEnum = (int)(code);
            //if (!tag.Trim().Equals(""))
            if (indexEnum > 0)
            {
                this.ucGrid.ModeByTag(indexEnum - 1);
            }
        }

        private void btnSaveEmrRecordn_Click(object sender, EventArgs e)
        {
            OCS2015U42 frmOCS2015U42 = new OCS2015U42(this);
            frmOCS2015U42.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmOCS2015U42.MaximizeBox = false;
            frmOCS2015U42.MinimizeBox = false;
            frmOCS2015U42.StartPosition = FormStartPosition.CenterScreen;
            //Show OCS2015U42 popup to add comment
            DialogResult dialogResult = frmOCS2015U42.ShowDialog();
            string emailFlg = frmOCS2015U42.EmailCheckBox.Checked ? "1" : "0";

            if (dialogResult == DialogResult.Cancel)
            {
                frmOCS2015U42.Close();
                CancelSaving(this.emrRecordId, UserInfo.UserID);
                return;
            }

            if (CloudService.Instance.Connect())
            {
                //Todo save Editing emr record
                string recordLog = frmOCS2015U42.TxtRecordLog.Text.Trim();
                OCS2015U44EmrHistoricRecordUpdateArgs args = new OCS2015U44EmrHistoricRecordUpdateArgs();
                args.Content = this.ucGrid.Save(null, true, ScreenEnum.U44);
                args.Metadata = this.ucGrid.GetDicCommentInfo(false);
                args.RecordId = this.emrRecordId;
                args.RecordLog = recordLog.Length > 128 ? recordLog.Trim().Substring(0, 128) : recordLog.Trim(); // limit 128 characters
                args.UpdId = UserInfo.UserID;
                args.EmailFlg = emailFlg;
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS2015U44EmrHistoricRecordUpdateArgs>(args);
                if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                {
                    if (UpdateEmrViewer != null)
                    {
                        UpdateDataEmrAgrs retData = new UpdateDataEmrAgrs(this.ucGrid.GetTagIdsByPkout(Pkout), this.ucGrid.GetNewCommentList());
                        UpdateEmrViewer(this, retData);//Reload data of the Emr viewer
                    }
                    XMessageBox.Show(Resources.CMO_M005, string.Empty, MessageBoxIcon.Information);
                    frmOCS2015U42.Close();
                    this.Close();
                }
                else
                {
                    XMessageBox.Show(Resources.CMO_M006, string.Empty, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CancelSaving(emrRecordId, UserInfo.UserID);
            this.Dispose(true);
        }

        private void insertCommentItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ucGrid.AddComment();
        }

        #region LoadCboDisplayTag
        private void LoadCboDisplayTag()
        {
            DataTable dtDisplayTagData = DataCreator.CreateDisplayTagData();

            ComboBoxItemCollection itemsCollection = cboDisplay1.Properties.Items;
            itemsCollection.Clear();
            itemsCollection.BeginUpdate();
            try
            {
                foreach (DataRow row in dtDisplayTagData.Rows)
                    itemsCollection.Add(row["DisplayId"]);
            }
            finally
            {
                itemsCollection.EndUpdate();
            }

            cboDisplay1.SelectedIndex = 2;
        }

        #endregion

        private void cboDisplay1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int objSelected;
            /*Int32.TryParse(Convert.ToString(cboDisplay1.SelectedValue), out objSelected);*/
            Int32.TryParse(Convert.ToString(cboDisplay1.SelectedIndex), out objSelected);
            ucGrid.ModeByTag(objSelected);
        }
    }
}
