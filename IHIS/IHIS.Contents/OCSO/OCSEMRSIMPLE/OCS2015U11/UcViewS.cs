using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraRichEdit.API.Native;
using System;
using EmrDocker.Glossary;
using EmrDocker.Models;
using EmrDockerS;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSO;
using ERMUserControl;
using IHIS.OCSO.Meta;
using EmrDocker.Types;
using MedicalInterfaceTest;
using Utilities = IHIS.Framework.Utilities;
using System.Drawing;
using MedicalInterface;

namespace EmrDocker
{
    public partial class UcViewS : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field & Properties
        System.Windows.Forms.ToolTip tooltip1 = new System.Windows.Forms.ToolTip();

        private Dictionary<string, string> displayedTags = new Dictionary<string, string>();

        private Dictionary<string, UserData> metaDictionary = new Dictionary<string, UserData>();

        private List<CustomMarkSchema> currentEmrMeta = new List<CustomMarkSchema>();

        private string currentEmrWordMl;
        private List<EmrDocker.Types.Tuple<int, UserData>> currentCustomMarks = new List<EmrDocker.Types.Tuple<int, UserData>>();

        public Dictionary<string, UserData> MetaDictionary
        {
            get { return metaDictionary; }
        }

        private List<OcsoOCS1003P01GridOutSangInfo> _lstOcsoOCS1003P01GridOutSangInfo = new List<OcsoOCS1003P01GridOutSangInfo>();

        public List<OcsoOCS1003P01GridOutSangInfo> LstOcsoOCS1003P01GridOutSangInfo
        {
            get { return _lstOcsoOCS1003P01GridOutSangInfo; }
            set { _lstOcsoOCS1003P01GridOutSangInfo = value; }
        }

        private Dictionary<string, int> recordPosition = new Dictionary<string, int>();
        public IMainScreen _mainScreen;
        private string _naewonDate = string.Empty;
        public string NaewonDate
        {
            get { return _naewonDate; }
            set { _naewonDate = value; }
        }
        private string _naewonKey = string.Empty;
        public string NaewonKey
        {
            get { return _naewonKey; }
            set { _naewonKey = value; }
        }
        private string pkout1001 = "";
        private string _bunho = "";
        private string _recordId = string.Empty;
        private bool _isEnableBtnEdit = true;
        private string _currentPkout;

        private List<DateTime> _lstHisExamination = new List<DateTime>();

        public List<DateTime> LstHisExamination
        {
            get { return _lstHisExamination; }
            set { _lstHisExamination = value; }
        }

        public bool IsEnableBtnEdit
        {
            get { return _isEnableBtnEdit; }
            set { _isEnableBtnEdit = value; }
        }

        public string Pkout1001
        {
            get { return pkout1001; }
            set { pkout1001 = value; }
        }

        public string Bunho
        {
            get { return _bunho; }
            set { _bunho = value; }
        }
        public string Record_id
        {
            get { return _recordId; }
            set { _recordId = value; }
        }

        public string CurrentPkout
        {
            get { return _currentPkout; }
            set { _currentPkout = value; }
        }

        public delegate void UpdateEmrDataHandler(object sender, UpdateDataEmrAgrs e);

        public event UpdateEmrDataHandler EditButtonClick;
        protected virtual void OnEditButtonClick(UpdateDataEmrAgrs e)
        {
            UpdateEmrDataHandler handler = EditButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public List<CommentMeta> GetComments()
        {
            List<CommentMeta> comments = new List<CommentMeta>();
            //foreach (CustomMark mark in richEditControl.Document.CustomMarks)
            //{
            //    if (mark.UserData.GetType().ToString().Equals("CommentMeta"))
            //    {
            //        CommentMeta meta = JsonConvert.DeserializeObject<CommentMeta>(mark.UserData.ToString());
            //        if (meta != null) comments.Add(meta);
            //    }
            //}

            return comments;
        }

        #endregion

        #region Contructor
        public UcViewS()
        {
            InitializeComponent();
            ReSetLocation();
            SetTooltipForButtonControl();

            this.bar3.Visible = false;

            barDockControlTop.BackColor = ColorTranslator.FromHtml("#E7EEF8");
        }

        #endregion

        #region Events

        private void UcView_Load(object sender, EventArgs e)
        {
            this.ucGrid1.SetActiveGridView(false);
            SetDisableDrawDragCommonBar();
            SetTooltipForButtonControl();
        }

        public void ViewLoadFunc()
        {
            try
            {
                SetDateToDatePicker("");
                BindCombo();
                InitOtherControls();
                //todo: hash code
                /*ReloadLatesTags();*/
                ucGrid1.InitAppearance();
                LoadCboDisplayTag();
                ucGrid1.GetCurrentComments(CurrentPkout);
                SetDisableDrawDragCommonBar();
            }
            catch (Exception e)
            {

            }
        }

        private void SetDisableDrawDragCommonBar()
        {
            /*commonBar1.OptionsBar.DrawDragBorder = false;
            commonBar1.OptionsBar.DisableCustomization = true;
            commonBar1.OptionsBar.MultiLine = false;
            commonBar1.OptionsBar.DrawSizeGrip = false;
            commonBar1.OptionsBar.Hidden = false;
            commonBar1.OptionsBar.MultiLine = false;*/
        }

        #region LoadCboDisplayTag
        private void LoadCboDisplayTag()
        {
            DataTable dtDisplayTagData = DataCreator.CreateDisplayTagData();
            ComboBoxItemCollection itemsCollection = comboBoxEdit1.Properties.Items;
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

            comboBoxEdit1.SelectedIndex = 2;
        }

        #endregion

        public void SetActiveEditEmrBtn()
        {
            if (string.IsNullOrEmpty(this.Record_id) || !IsEnableBtnEdit)
            {
                this.barButtonItem01.Enabled = false;
                xButton1.Enabled = false;
            }
            else
            {
                this.barButtonItem01.Enabled = true;
                xButton1.Enabled = true;
            }
        }
        private void barTag_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barTag = (BarEditItem)sender;
            string tag = barTag.EditValue.ToString();
            this.PutToDisplayedTags(barTag, tag);
            bool putSubTag = DataProvider.Instance.Tags.ContainsKey(tag);

            string barSubTagName = barTag.Name.Replace("barTag", "barSubTag");
            foreach (BarItemLink item in tagBar1.ItemLinks)
            {
                if (item.Item.Name.Equals(barSubTagName))
                {
                    ((BarEditItem)item.Item).EditValue = "";
                    RepositoryItemComboBox cboSubTag = (RepositoryItemComboBox)((BarEditItemLink)item).Edit;
                    cboSubTag.Items.Clear();
                    if (putSubTag)
                    {
                        foreach (string subTag in DataProvider.Instance.Tags[tag])
                        {
                            cboSubTag.Items.Add(String.Format("{0}-{1}", tag, subTag));
                            //cboSubTag.Items.Add(String.Format("{0}", subTag));
                        }
                    }
                }
            }

            ShowHideTag();
        }

        private void barSubTag_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barTag = (BarEditItem)sender;
            string tag = barTag.EditValue.ToString();
            this.PutToDisplayedTags(barTag, tag);
            ShowHideTag();
        }

        private void cbOrderType_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barTag = (BarEditItem)sender;
            string tag = barTag.EditValue.ToString();

            string[] orderArr = tag.Split(new char[] { '[' });
            string orderRightSp = orderArr[1].Trim();
            string[] orderArr1 = orderRightSp.Split(new char[] { ']' });
            string orderGubun = orderArr1[0];

        }

        private void cbDisplay_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barTag = (BarEditItem)sender;
            string tag = barTag.EditValue.ToString();
            TagOption code = StringEnum.Parse<TagOption>(tag);

            int indexEnum = (int)(code);

            if (!tag.Trim().Equals(""))
            {
                /*OCS2015U06Businesses.DisplayTagBeforeParagraph(this.richEditControl,
                    this.richEditControl.Document.GetParagraphs(this.richEditControl.Document.Range),
                    tag);*/
            }
            if (indexEnum > 0)
            {
                ucGrid1.ModeByTag(indexEnum - 1);
            }

        }

        public void ResetControlFilter()
        {
            RepositoryItemComboBox cboTags = (RepositoryItemComboBox)barTag1.Edit;
            if (cboTags.Items.Count > 0)
            {
                barTag1.EditValue = cboTags.Items[0];
            }
            RepositoryItemComboBox cboSubTags = (RepositoryItemComboBox)barSubTag1.Edit;
            if (cboSubTags.Items.Count > 0)
            {
                barSubTag1.EditValue = cboSubTags.Items[0];
            }
            RepositoryItemComboBox cboOrderType = (RepositoryItemComboBox)cbOrderType.Edit;
            if (cboOrderType.Items.Count > 0)
            {
                cbOrderType.EditValue = cboOrderType.Items[0];
            }
            /*RepositoryItemComboBox cboDisplay = (RepositoryItemComboBox)cbDisplay.Edit;
            if (cboDisplay.Items.Count > 0)
            {
                cbDisplay.EditValue = cboDisplay.Items[0];
            }*/
        }

        private void barTag1_EditValueChanged(object sender, EventArgs e)
        {
            string orderGubun = "", childrentTagAlone = "";
            //string childrentTagAlone = "";

            string parrentTag = barTag1.EditValue != null ? barTag1.EditValue.ToString() : "";
            string childrentTag = barSubTag1.EditValue != null ? barSubTag1.EditValue.ToString() : "";

            /*if (!string.IsNullOrEmpty(childrentTag))
            {
                string[] childrentTagArr = childrentTag.Split(new char[] { '-' });
                childrentTagAlone = childrentTagArr[1].Trim();
            }*/

            string orderType = cbOrderType.EditValue != null ? cbOrderType.EditValue.ToString() : "";
            if (!string.IsNullOrEmpty(orderType))
            {
                string[] orderArr = orderType.Split(new char[] { '[' });
                string orderRightSp = orderArr[1].Trim();
                string[] orderArr1 = orderRightSp.Split(new char[] { ']' });
                orderGubun = orderArr1[0];
            }

            ucGrid1.FillterByTagAndOrder(parrentTag, childrentTag, orderGubun);
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int objSelected;
            Int32.TryParse(Convert.ToString(comboBoxEdit1.SelectedIndex), out objSelected);
            ucGrid1.ModeByTag(objSelected);
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Record_id))
                return;
            if (!string.IsNullOrEmpty(this.Bunho))
            {
                OCS2015U00EmrRecordLockArgs lockArgs = new OCS2015U00EmrRecordLockArgs();
                lockArgs.RecordId = this.Record_id;
                lockArgs.UpdId = UserInfo.UserID;
                lockArgs.ScreenId = "OCS2015U06";
                UpdateResult lockRes = CloudService.Instance.Submit<UpdateResult, OCS2015U00EmrRecordLockArgs>(lockArgs);
                if (lockRes.ExecutionStatus == ExecutionStatus.Success && lockRes.Result)
                {
                    /*OCS2015U44 historicEditor = new OCS2015U44(this.ucGrid1.strMml, this.Record_id, this.ucGrid1.PatientModel, this.ucGrid1.GetDicCommentInfo(true));*/
                    OCS2015U44 historicEditor = new OCS2015U44(this.ucGrid1.strMml, this.Record_id, this.ucGrid1.PatientModel, this.ucGrid1.GetDicCommentInfo(true), _lstOcsoOCS1003P01GridOutSangInfo);
                    historicEditor.Pkout = CurrentPkout;
                    historicEditor.FormBorderStyle = FormBorderStyle.FixedDialog;
                    historicEditor.MaximizeBox = false;
                    historicEditor.MinimizeBox = false;
                    historicEditor.StartPosition = FormStartPosition.CenterScreen;
                    historicEditor.UpdateEmrViewer += historicEditor_UpdateEmrViewer;
                    historicEditor.ShowDialog();
                }
                else
                {
                    XMessageBox.Show(Resources.LockAlert);
                }
            }
        }

        private void xButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Bunho)) return;
            frOCS2015U40 frU40 = new frOCS2015U40(this, pkout1001);
            frU40.FormBorderStyle = FormBorderStyle.FixedDialog;
            frU40.MaximizeBox = false;
            frU40.MinimizeBox = false;
            frU40.StartPosition = FormStartPosition.CenterScreen;
            frU40.ShowDialog();
        }

        private void xButton3_Click(object sender, EventArgs e)
        {
            /*            // Invoke the Print Preview dialog for the workbook.
                using (PrintingSystem printingSystem = new PrintingSystem())
                {
                    using (PrintableComponentLink link = new PrintableComponentLink(printingSystem))
                    {
                        //link.Component = richEditControl;
                        //link.Component = new ;
                        link.CreateDocument();
                        link.ShowPreviewDialog();
                    }
                }*/
            List<EmrRecordInfo> emrRecordInfo = new List<EmrRecordInfo>();
            emrRecordInfo = ucGrid1.ExistingRecords;
            string naewonDate = _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
            string pkOut = _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();

            if (NetInfo.Language == IHIS.Framework.LangMode.Vi)
            {
                PopupPrintEmr popupPrintEmr = new PopupPrintEmr(true, emrRecordInfo, Bunho, ScreenEnum.UcView, ucGrid1.LstOcsoOCS1003P01GridOutSangInfo, pkOut);
                popupPrintEmr.ShowDialog();

                /*PopupEmrHistory openEmrHistory = new PopupEmrHistory(emrRecordInfo, Bunho, naewonDate);
                openEmrHistory.ShowDialog();*/
            }
            else
            {
                PopupPrintEmr popupPrintEmr = new PopupPrintEmr(emrRecordInfo, Bunho, ScreenEnum.UcView, ucGrid1.LstOcsoOCS1003P01GridOutSangInfo, pkOut);
                popupPrintEmr.ShowDialog();
                /*ucGrid1.PrintPreview();*/
            }
        }

        private void xButton4_Click(object sender, EventArgs e)
        {
            //RepositoryItemComboBox cboTags = (RepositoryItemComboBox)barTag1.Edit;
            //if (cboTags.Items.Count > 0)
            //{
            //    barTag1.EditValue = cboTags.Items[0];
            //}
            //RepositoryItemComboBox cboSubTags = (RepositoryItemComboBox)barSubTag1.Edit;
            //if (cboSubTags.Items.Count > 0)
            //{
            //    barSubTag1.EditValue = cboSubTags.Items[0];
            //}
            //RepositoryItemComboBox cboOrderType = (RepositoryItemComboBox)cbOrderType.Edit;
            //if (cboOrderType.Items.Count > 0)
            //{
            //    cbOrderType.EditValue = cboOrderType.Items[0];
            //}
            //RepositoryItemComboBox cboDisplay = (RepositoryItemComboBox)cbDisplay.Edit;
            //if (cboDisplay.Items.Count > 0)
            //{
            //    cbDisplay.EditValue = cboDisplay.Items[0];
            //}
            this.ResetControlFilter();
        }
        #endregion

        #region Method

        public UcViewS(IMainScreen main_screen)
            : this()
        {
            this._mainScreen = main_screen;
        }

        private void BindCombo()
        {
            BindMenu(barTag1, barSubTag1);
        }

        private void BindMenu(BarEditItem barTag, BarEditItem barSubTag)
        {
            RepositoryItemComboBox cboTag = (RepositoryItemComboBox)barTag.Edit;
            RepositoryItemComboBox cboSubTag = (RepositoryItemComboBox)barSubTag.Edit;
            cboSubTag.Items.Clear();
            cboTag.Items.Clear();
            cboTag.Items.Add("");
            cboSubTag.Items.Add("");
            DataProvider.Instance.ReloadLatestTags();
            foreach (string tag in DataProvider.Instance.DicParentTagInfos.Keys)
            {
                cboTag.Items.Add(tag);
            }

            foreach (string tag in DataProvider.Instance.TagParentDetail.Keys)
            {
                cboSubTag.Items.Add(tag);
            }
            /*barTag.EditValueChanged += new EventHandler(barTag_EditValueChanged);*/
            barSubTag.EditValueChanged += new EventHandler(barSubTag_EditValueChanged);
        }

        private void PutToDisplayedTags(BarEditItem barTag, string tag)
        {
            if (tag != null && tag.Trim().Length > 0)
            {
                if (!this.displayedTags.ContainsKey(barTag.Name))
                {
                    this.displayedTags.Add(barTag.Name, tag.Trim());
                }
                else
                {
                    this.displayedTags[barTag.Name] = tag.Trim();
                }
            }
            else
            {
                displayedTags.Remove(barTag.Name);
            }
        }

        private void ShowHideTag()
        {
            List<string> supportedTags = new List<string>();
            supportedTags.AddRange(displayedTags.Values);
            List<string> allTags = DataProvider.Instance.AllTags;

            ShowHideByOrderType(cbOrderType.EditValue == null ? string.Empty : cbOrderType.EditValue.ToString());
        }

        public void ShowHideByOrderType(string tag)
        {
            ShowTableLine(string.IsNullOrEmpty(tag));
            if (!string.IsNullOrEmpty(tag))
            {
                int leftSquareBracket = tag.IndexOf('[') > -1 ? tag.IndexOf('[') : 0;
                int rightSquareBracket = tag.IndexOf(']') > (leftSquareBracket + 1) ? tag.IndexOf(']') : 0;
                //ERMControl.DoButtonBusiness.FilterOrderByGubun(
                //    richEditControl,
                //    tag.Substring(
                //        leftSquareBracket + 1,
                //        (rightSquareBracket - leftSquareBracket - 1) >= (leftSquareBracket + 1)
                //            ? (rightSquareBracket - leftSquareBracket - 1)
                //            : (leftSquareBracket + 1)));
            }
            else
            {
                //TableCollection tables = richEditControl.Document.Tables;
                //DocumentImageCollection images = richEditControl.Document.GetImages(richEditControl.Document.Range);
                //foreach (Table table in tables)
                //{
                //    if (EmrDocker.DoButtonBusiness.CheckDoTable(table, images))
                //    {
                //        DocumentRange range = table.Range;
                //        CharacterProperties cp = richEditControl.Document.BeginUpdateCharacters(range);
                //        cp.Hidden = false;
                //        //richEditControl.Document.EndUpdateCharacters(cp);
                //    }
                //}
            }
        }

        public void ShowTableLine(bool show)
        {
            TableBorderLineStyle lineStyle = show ? TableBorderLineStyle.Single : TableBorderLineStyle.None;
        }

        /// <summary>
        /// Init value for combo Order types, Display
        /// </summary>
        private void InitOtherControls()
        {
            this.dateEdit1.Enabled = true;
            RepositoryItemComboBox cboOrder = (RepositoryItemComboBox)cbOrderType.Edit;
            cboOrder.Items.Add(""); // default all order types
            if (CloudService.Instance.Connect())
            {
                OCS2015U06OrderTypeComboArgs args = new OCS2015U06OrderTypeComboArgs();
                OCS2015U06OrderTypeComboResult result =
                    CloudService.Instance.Submit<OCS2015U06OrderTypeComboResult, OCS2015U06OrderTypeComboArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    foreach (OCS2015U06OrderTypeComboInfo item in result.OrderTypes)
                    {
                        if (!item.CodeName.Trim().Equals(""))
                        {
                            cboOrder.Items.Add(item.CodeName);
                        }
                    }
                }
            }

            /*DataProvider.Instance.TagDisplayModeSetup(cbDisplay);*/
        }

        void historicEditor_UpdateEmrViewer(object sender, UpdateDataEmrAgrs e)
        {
            //Todo: reload data for EMR after finish edit emr medical record
            OnEditButtonClick(e);
        }

        #region ReloadLatesTags
        public void ReloadLatesTags()
        {
            DataTable dtCboGrd = DataCreator.CboTagData();
            LoadGridCbo(dtCboGrd);
        }

        private void LoadGridCbo(DataTable lstGrdCbo)
        {
            //Load lstTag gridCbo
            //DataProvider.ReloadLatestTags();
            //DataTable lstGrdCbo = DataCreator.CboTagData();
            //ucGrid1.LoadGridCombobox(lstGrdCbo);
        }
        #endregion

        public void ResetEmrViewer()
        {
            this.Record_id = string.Empty;
            this.CurrentPkout = string.Empty;
            this.ucGrid1.Reset();
        }

        public void VisiableAllCtrl(bool value)
        {
            if (string.IsNullOrEmpty(this.Record_id) || !IsEnableBtnEdit)
            {
                this.barButtonItem01.Enabled = false;
                xButton1.Enabled = false;
            }
            else
            {
                barButtonItem01.Enabled = value;
                xButton1.Enabled = value;
            }
        }

        public void SetDateToDatePicker(string dateTime)
        {
            if (!string.IsNullOrEmpty(dateTime))
            {
                dateEdit1.Text = dateTime;
            }
            else
            {
                dateEdit1.Text = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
            }
        }

        private void SetTooltipForButtonControl()
        {
            tooltip1.SetToolTip(xButton1, Resources.UcViewS_SetTooltipForButtonControl_BtnEdit);
            tooltip1.SetToolTip(xButton2, Resources.UcViewS_SetTooltipForButtonControl_BtnShowLog);
            tooltip1.SetToolTip(xButton3, Resources.UcViewS_SetTooltipForButtonControl_BtnPrint);
            tooltip1.SetToolTip(xButton4, Resources.UcViewS_SetTooltipForButtonControl_BtnRefresh);
        }

        private void ReSetLocation()
        {
            //comboBoxEdit1.Location = new Point(197, 1);
            //comboBoxEdit1.Size = new Size(100, 20);
            comboBoxEdit1.Location = new Point(188, 1);
            comboBoxEdit1.Size = new Size(90, 20);

            //dateEdit1.Location = new Point(308, 1);
            //dateEdit1.Size = new Size(100, 20);
            dateEdit1.Size = new Size(78, 20);
            dateEdit1.Location = new Point(285, 1);

            //xButton1.Location = new Point(420, 1);
            xButton1.Location = new Point(363, 1);
            xButton1.Size = new Size(27, 21);

            //xButton2.Location = new Point(454, 1);
            xButton2.Location = new Point(390, 1);
            xButton2.Size = new Size(27, 21);

            //xButton3.Location = new Point(488, 1);
            xButton3.Location = new Point(417, 1);
            xButton3.Size = new Size(27, 21);

            //xButton4.Location = new Point(522, 1);
            xButton4.Location = new Point(444, 1);
            xButton4.Size = new Size(27, 21);
        }

        #endregion

        private void dateEdit1_DrawItem(object sender, DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e)
        {
            if (_lstHisExamination.Count <= 0) return;
            foreach (DateTime itemDate in _lstHisExamination)
            {
                if (e.Date == itemDate.Date)
                {
                    /*e.Style.ForeColor = Color.Khaki;
                    e.Style.BackColor = Color.Blue;*/

                    e.Graphics.FillRectangle(Brushes.Khaki, e.Bounds);
                    e.Style.ForeColor = Color.Red;
                    e.Style.Font = new Font(e.Style.Font, FontStyle.Bold);
                }
            }

            if (e.Selected || e.Date == DateTime.Today)
            {
                Brush brush = (e.Highlighted ? Brushes.Red : Brushes.Red);

                e.Graphics.FillRectangle(Brushes.Khaki, e.Bounds);

                e.Style.BorderColor = Color.Red;
                e.Style.DrawBackground(e.Graphics, e.Cache, e.Bounds);
                e.Style.DrawString(e.Cache, e.Date.Day.ToString(), e.Bounds);
                e.Style.Options.UseBorderColor = true;
                e.Graphics.FillRectangle(Brushes.Khaki, e.Bounds);

                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;
                strFormat.LineAlignment = StringAlignment.Center;
                //draw the day number
                e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, brush, e.Bounds, strFormat);
                e.Handled = true;
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string strDtp = dateEdit1.DateTime.ToShortDateString();
            ucGrid1.ScrollToDate(strDtp, "");
        }
    }
}
