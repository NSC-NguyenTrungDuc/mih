using System.Collections.Generic;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.API.Native.Implementation;
using EmrDocker.AdditionalBusiness;
using EmrDocker.Glossary;
using EmrDocker.Models;
using ERMUserControl;
using GhostscriptSharp;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.Framework;
using IHIS.OCSO;
using IHIS.OCSO.Meta;
using Newtonsoft.Json;
using Utilities = IHIS.OCSO.Utilities;



namespace EmrDocker
{
    public partial class UcEditor : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field & Properties
        
        private IHIS.OCS.PatientInfo mSelectedPatientInfo;
        private string _bunho = "";
        private bool _isInitCtrl = true;
        private int _templateIndex = -1;
        private bool _isShowMessageTemp = false;
        System.Windows.Forms.ToolTip tooltip1 = new System.Windows.Forms.ToolTip();
        private IHIS.X.Magic.Menus.PopupMenu mPanelBtn = new IHIS.X.Magic.Menus.PopupMenu();

        public string Bunho
        {
            get { return _mainScreen == null ? _bunho : _mainScreen.MSelectedPatientInfo.Parameter.Bunho; }
            set { _bunho = value; }
        }

        public bool IsInitCtrl
        {
            get { return _isInitCtrl; }
            set { _isInitCtrl = value; }
        }

        private Dictionary<string, string> hashFileNameDict = new Dictionary<string, string>();
        public IMainScreen _mainScreen;
        private Dictionary<string, string> _TemplateMap = new Dictionary<string, string>();
        private static Dictionary<string, string> _tagDictionary = new Dictionary<string, string>();
        private static List<TemplateMeta> _templateList = new List<TemplateMeta>();
        private static Dictionary<string, string> _templateDictionary = new Dictionary<string, string>();
        private Dictionary<string, List<OCS2015U31EmrTagGetTemplateTagsInfo>> _dicTempLstTags = new Dictionary<string, List<OCS2015U31EmrTagGetTemplateTagsInfo>>();

        private string GetCbxTemContent(string temId)
        {
            try
            {
                if (_TemplateMap.ContainsKey(temId))
                    return _TemplateMap[temId];
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        private List<OCS2015U31EmrTagGetTemplateTagsInfo> GetLstTagByTempId(string temId)
        {
            try
            {
                if (_dicTempLstTags.ContainsKey(temId))
                    return _dicTempLstTags[temId];
                else
                    return new List<OCS2015U31EmrTagGetTemplateTagsInfo>();
            }
            catch (Exception ex)
            {
                return new List<OCS2015U31EmrTagGetTemplateTagsInfo>();
            }
        }
        List<string> _newlyAddedImages = new List<string>();
        private Dictionary<string, UserData> metaDictionary = new Dictionary<string, UserData>();

        private List<TemplateTagItem> _backupTagList = new List<TemplateTagItem>();
        private List<TemplateTagItem> _historyTagContentLst = new List<TemplateTagItem>();

        //private EmrViewer _viewer;// = new EmrViewer();

        private bool _isSetTemDefault = true;
        public bool IsSetTemDefault
        {
            get { return _isSetTemDefault; }
            set { _isSetTemDefault = value; }
        }

        private bool _isFirstSelectedChanged = true;
        #endregion

        #region Contructor
        public UcEditor()
        {
            InitializeComponent();
            SetTooltipForButtonControl();
        }
        #endregion

        #region Event

        public void EditorLoadFunc(bool isQueryTemp)
        {
            //Load lstTag gridCbo
            if (isQueryTemp) ReloadLatesTags();
            _isFirstSelectedChanged = true;
            //Get all Template
            GetContentTemplates(isQueryTemp);
            //Load cboDiplay
            LoadCboDisplayTag();
            //LoadGrid();
            //Todo: hash code
            /*DataTable dtCboGrd = DataCreator.CboTagData();
            LoadGridCbo(dtCboGrd);*/
            cboTempl2.SelectedItem = 0;
            cboDisplay1.SelectedIndex = 2;
            GetCurrentComments();
        }

        private void GetCurrentComments()
        {
            //ucGrid1.GetCurrentComments(_mainScreen.MSelectedPatientInfo.Parameter.NaewonKey);
            ucGrid1.GetCurrentComments(_mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
        }
        
        #region insertPdfItem_ItemClick
        private void insertPdfItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pdf Files|*.pdf";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(dialog.FileName);
                if (ext != null && ext.ToLower() == ".pdf")
                {
                    //InsertPdfFile(dialog.FileName, pos, true);
                    InsertPdfFile(dialog.FileName, 0, true, ActionType.Insert);
                }
            }
        }
        #endregion

        #region insertImage1_ItemClick
        private void insertImage1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CLIP";
            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                /*string originalFilePath = dialog.FileName;
                string fileName = Utilities.GetFileName(originalFilePath);
                string filePath = Utilities.GetAbsoluteDataPath(fileName, Bunho);
                FileInfo fileInfo = new FileInfo(filePath);
                if (!fileInfo.Exists)
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                File.Copy(originalFilePath, filePath);
                ucGrid1.InsertImage(filePath, TypeEnum.Image, filePath);*/
                ucGrid1.InsertImage(dialog.FileName, TypeEnum.Image, dialog.FileName, ActionType.Insert, true);
            }
        }

        #endregion

        private void dateEdit_EditValueChanged(object sender, EventArgs e)
        {
            //ucGrid1.ScrollToDate(dateEdit.Text);
        }
        //static DataTable InforDoctorPatient()
        //{
        //    DataTable dt = new DataTable();

        //    dt.Columns.Add("doctor_name");
        //    dt.Columns.Add("gwa_name");
        //    dt.Columns.Add("yotang_name");
        //    dt.Columns.Add("adress_doc");
        //    dt.Columns.Add("tel_doc");
        //    dt.Columns.Add("seqvalue");
        //    dt.Columns.Add("suname");
        //    dt.Columns.Add("birth");
        //    dt.Columns.Add("sex");
        //    dt.Columns.Add("adress_pa");
        //    dt.Columns.Add("tel_pa");
        //    foreach (var item in list)
        //    {
        //        var row = dt.NewRow();
        //        row["doctor_name"] = item.Name;
        //        row["doctor_name"] = item.Name;
        //        row["doctor_name"] = item.Name;
        //        row["doctor_name"] = item.Name;
        //        row["doctor_name"] = item.Name;
        //        row["doctor_name"] = item.Name;
        //        row["doctor_name"] = item.Name;
        //        row["doctor_name"] = item.Name;
        //        row["doctor_name"] = item.Name;
        //        row["doctor_name"] = item.Name;



        //        dt.Rows.Add(row);
        //    }

        //    return dt;
        //}
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (NetInfo.Language == IHIS.Framework.LangMode.Vi)
            {
                #region MED-12962
                //DataTable dtListDoctorPaTable = new DataTable();
                //DataTable dtListDiseaseTable = new DataTable();
                //DataTable dtListOrderTable = new DataTable();
                //DataTable dtListContentTable = new DataTable();


                //dtListDoctorPaTable.Columns.Add("doctor_name");
                //dtListDoctorPaTable.Columns.Add("gwa_name");
                //dtListDoctorPaTable.Columns.Add("yotang_name");
                //dtListDoctorPaTable.Columns.Add("adress_doc");
                //dtListDoctorPaTable.Columns.Add("tel_doc");
                //dtListDoctorPaTable.Columns.Add("seqvalue");
                //dtListDoctorPaTable.Columns.Add("suname");
                //dtListDoctorPaTable.Columns.Add("birth");
                //dtListDoctorPaTable.Columns.Add("sex");
                //dtListDoctorPaTable.Columns.Add("adress_pa");
                //dtListDoctorPaTable.Columns.Add("tel_pa");
                //dtListDoctorPaTable.Columns.Add("bunho");
                //dtListDoctorPaTable.Columns.Add("naewon_date");

                //dtListDiseaseTable.Columns.Add("sang_code");
                //dtListDiseaseTable.Columns.Add("sang_name");

                //dtListOrderTable.Columns.Add("hangmog_code");
                //dtListOrderTable.Columns.Add("hangmog_name");
                //dtListOrderTable.Columns.Add("suryang");
                //dtListOrderTable.Columns.Add("dv");
                //dtListOrderTable.Columns.Add("nalsu");
                //dtListOrderTable.Columns.Add("multil");
                //dtListOrderTable.Columns.Add("bogyong_name");
                //dtListOrderTable.Columns.Add("code_name");

                //dtListContentTable.Columns.Add("reason");
                //dtListContentTable.Columns.Add("patient_symptom");
                //dtListContentTable.Columns.Add("medical_history");
                //dtListContentTable.Columns.Add("health_index");
                //dtListContentTable.Columns.Add("doctor_comment");
                //dtListContentTable.Columns.Add("doctor_comment_detail");
                //dtListContentTable.Columns.Add("examination_comment");
                //dtListContentTable.Columns.Add("xray_comment");
                //dtListContentTable.Columns.Add("function_comment");
                //dtListContentTable.Columns.Add("method");
                //dtListContentTable.Columns.Add("doctor_remind");
                #endregion
                try
                {
                    DataSetReport ds = new DataSetReport();
                    ds.Clear();
                    OCS2015U00GetDoctorPatientReportArgs args = new OCS2015U00GetDoctorPatientReportArgs();
                    args.Doctor = UserInfo.DoctorID;
                    args.Bunho = Bunho;
                    args.Pkout1001 = _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                    args.NaewonDate = _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
                    args.Gwa = UserInfo.Gwa;
                    OCS2015U00GetDoctorPatientReportResult result = CloudService.Instance
                        .Submit<OCS2015U00GetDoctorPatientReportResult, OCS2015U00GetDoctorPatientReportArgs>(args);
                    if (result != null)
                    {
                        List<OCS2015U00GetDoctorPatientReportInfo> ListItemItem = new List<OCS2015U00GetDoctorPatientReportInfo>();
                        ListItemItem.Add(result.ListItem);
                        if (ListItemItem.Count > 0)
                        {
                            foreach (OCS2015U00GetDoctorPatientReportInfo info in ListItemItem)
                            {
                                DataRow row = ds.DataTable1.NewRow();
                                row["doctor_name"] = info.DoctorName.ToUpper();
                                row["gwa_name"] = info.GwaName;
                                row["yotang_name"] = UserInfo.HospName;
                                row["adress_doc"] = info.AdressDoc;
                                row["tel_doc"] = info.TelDoc;
                                row["seqvalue"] = info.Seqvalue.ToUpper();
                                row["suname"] = info.Suname.ToUpper();

                                if (!string.IsNullOrEmpty(info.Birth))
                                {
                                    DateTime dt = DateTime.ParseExact(info.Birth, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                                    row["birth"] = dt.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    row["birth"] = "";
                                }
                                if (info.Sex == "F")
                                {
                                    row["sex"] = "NỮ";
                                }
                                else
                                {
                                    row["sex"] = "NAM";
                                }
                                row["adress_pa"] = info.AdressPa;
                                row["tel_pa"] = info.TelPa;
                                row["bunho"] = Bunho;
                                if (!String.IsNullOrEmpty(_mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()))
                                {
                                    DateTime dt1 = DateTime.ParseExact(_mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                                    row["naewon_date"] = dt1.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    row["naewon_date"] = "";
                                }
                                row["fax_doc"] = info.FaxDoc;
                                row["website"] = info.Website;
                                ds.DataTable1.Rows.Add(row);

                            }
                        }
                        if (result.ListDisease.Count > 0)
                        {
                            foreach (OCS2015U00GetDiseaseReportInfo info in result.ListDisease)
                            {
                                DataRow row = ds.DataTable2.NewRow();
                                row["sang_code"] = info.SangCode;
                                row["sang_name"] = info.SangName;
                                ds.DataTable2.Rows.Add(row);
                            }
                        }
                        if (result.ListOrder.Count > 0)
                        {
                            foreach (OCS2015U00GetOrderReportInfo info in result.ListOrder)
                            {
                                DataRow row = ds.DataTable3.NewRow();
                                row["hangmog_code"] = info.HangmogCode;
                                row["hangmog_name"] = info.HangmogName;
                                row["suryang"] = info.Suryang;
                                row["dv"] = info.Dv;
                                row["nalsu"] = info.Nalsu;
                                decimal mutil = (Convert.ToDecimal(info.Suryang) * Convert.ToDecimal(info.Dv) * Convert.ToDecimal(info.Nalsu));
                                if (mutil != 0) row["multil"] = Convert.ToInt32(mutil).ToString();
                                row["bogyong_name"] = info.BogyongName;
                                row["code_name"] = info.CodeName;
                                ds.DataTable3.Rows.Add(row);

                            }
                        }
                    }
                    List<TagInfo> lstTagB2 = ucGrid1.GetListChildrenTagA("B2");
                    if (lstTagB2.Count > 0)
                    {
                        foreach (TagInfo itemTagInfo in lstTagB2)
                        {
                            DataRow row1 = ds.DataTable4.NewRow();
                            //if (!String.IsNullOrEmpty(itemTagInfo.Content.ToString()))
                            //{
                            if (itemTagInfo.Type == Glossary.TypeEnum.Image) continue;
                            row1["TagName"] = itemTagInfo.TagName;
                            row1["Content"] = itemTagInfo.Content;
                            ds.DataTable4.Rows.Add(row1);
                            //}                           
                        }



                    }
                    #region Table5

                    //foreach (TagInfo itemTagInfo in lstTagB2)
                    //{

                    //    switch (itemTagInfo.TagCode)
                    //    {

                    //        case "C6":
                    if (lstTagB2.Count > 0)
                    {
                        for (int j = 0; j < lstTagB2.Count; j++)
                        {
                            if (!String.IsNullOrEmpty(lstTagB2[j].DirLocation))
                            {
                                DataRow row2 = ds.DataTable5.NewRow();
                                row2["link_picture"] = lstTagB2[j].DirLocation.Trim();
                                ds.DataTable5.Rows.Add(row2);
                            }

                        }
                    }
                    //            break;

                    //    }

                    //}

                    #endregion
                    //DataSet ds = new DataSet();
                    //ds.Tables.Add(dtListDoctorPaTable);
                    //ds.Tables.Add(dtListDiseaseTable);
                    //ds.Tables.Add(dtListOrderTable);
                    //ds.Tables.Add(dtListContentTable);
                    ReportMedicalRecord xReport = new ReportMedicalRecord();
                    xReport.DataSource = ds;
                    //xReport.DataMember = "Table1";
                    xReport.Print();
                }
                catch
                {
                    XMessageBox.Show("Error");
                }
            }
            else
            {
                ucGrid1.PrintPreview();
            }
        }

        private void ucGrid1_Load(object sender, EventArgs e)
        {

        }

        private void AddComment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucGrid1.AddComment();
        }

        private void cboTempl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTempl2.SelectedIndexChanged -= new System.EventHandler(cboTempl2_SelectedIndexChanged);

            if (!IsInitCtrl /*&& !IsSetTemDefault*/)
            {
                if (this.ucGrid1.IsEdited() && _isShowMessageTemp)
                {
                    DialogResult dr = XMessageBox.Show(Resources.EMR_U315, "", MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button2, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Cancel)
                    {
                        cboTempl2.SelectedIndex = _templateIndex;
                        cboTempl2.SelectedIndexChanged += new System.EventHandler(cboTempl2_SelectedIndexChanged);
                        return;
                    }
                }
            }

            IsInitCtrl = false;
            _templateIndex = this.cboTempl2.SelectedIndex;
            string emrTemplateId = _templateDictionary.ContainsKey(_templateIndex.ToString(CultureInfo.InvariantCulture)) ? _templateDictionary[_templateIndex.ToString(CultureInfo.InvariantCulture)] : "";
            /*TemplateMeta tem = this.cboTempl2.SelectedItem as TemplateMeta;*/

            /*ucGrid1.CurrentTemplateId = this.GetCbxTemContent(emrTemplateId);*/

            //Template default
            if (_isShowMessageTemp)
            {
                /*ucGrid1.CurrentTemplateId = emrTemplateId;*/
                ucGrid1.CurrentTemplateId = this.GetCbxTemContent(emrTemplateId);
            }



            if (!string.IsNullOrEmpty(emrTemplateId))
            {
                CreateApplyTemplateToGrid(emrTemplateId);
                _isFirstSelectedChanged = false;
            }


            /*int objSelected;
            Int32.TryParse(Convert.ToString(cboTempl2.SelectedValue), out objSelected);
            //ucGrid1.GetTemplate(objSelected);*/

            cboTempl2.SelectedIndexChanged += new System.EventHandler(cboTempl2_SelectedIndexChanged);
        }

        private void cboDisplay1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int objSelected;
            /*Int32.TryParse(Convert.ToString(cboDisplay1.SelectedValue), out objSelected);*/
            Int32.TryParse(Convert.ToString(cboDisplay1.SelectedIndex), out objSelected);
            ucGrid1.ModeByTag(objSelected);
        }

        private void btnInsertPdfItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pdf Files|*.pdf";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ext = Path.GetExtension(dialog.FileName);
                    if (ext != null && ext.ToLower() == ".pdf")
                    {
                        //InsertPdfFile(dialog.FileName, pos, true);
                        InsertPdfFile(dialog.FileName, 0, true, ActionType.Insert);
                    }
                }
                catch (Exception ex)
                {
                   
                }
                
            }
        }

        private void btnInsertImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CLIP";
            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                /*string originalFilePath = dialog.FileName;
                string fileName = Utilities.GetFileName(originalFilePath);
                string filePath = Utilities.GetAbsoluteDataPath(fileName, Bunho);
                FileInfo fileInfo = new FileInfo(filePath);
                if (!fileInfo.Exists)
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                File.Copy(originalFilePath, filePath);
                ucGrid1.InsertImage(filePath, TypeEnum.Image, filePath);*/
                ucGrid1.InsertImage(dialog.FileName, TypeEnum.Image, dialog.FileName, ActionType.Insert, true);
            }
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            ucGrid1.AddComment();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string pkOut = _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
            List<EmrRecordInfo> emrRecordInfo = ucGrid1.ExistingRecords;

            if (NetInfo.Language == IHIS.Framework.LangMode.Vi)
            {
                try
                {
                    #region Old
                    /*DataSetReport ds = new DataSetReport();
                    ds.Clear();
                    OCS2015U00GetDoctorPatientReportArgs args = new OCS2015U00GetDoctorPatientReportArgs();
                    args.Doctor = UserInfo.DoctorID;
                    args.Bunho = Bunho;
                    args.Pkout1001 = _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                    args.NaewonDate = _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
                    args.Gwa = UserInfo.Gwa;
                    OCS2015U00GetDoctorPatientReportResult result = CloudService.Instance
                        .Submit<OCS2015U00GetDoctorPatientReportResult, OCS2015U00GetDoctorPatientReportArgs>(args);
                    if (result != null)
                    {
                        List<OCS2015U00GetDoctorPatientReportInfo> ListItemItem = new List<OCS2015U00GetDoctorPatientReportInfo>();
                        ListItemItem.Add(result.ListItem);
                        if (ListItemItem.Count > 0)
                        {
                            foreach (OCS2015U00GetDoctorPatientReportInfo info in ListItemItem)
                            {
                                DataRow row = ds.DataTable1.NewRow();
                                row["doctor_name"] = info.DoctorName.ToUpper();
                                row["gwa_name"] = info.GwaName;
                                row["yotang_name"] = UserInfo.HospName;
                                row["adress_doc"] = info.AdressDoc;
                                row["tel_doc"] = info.TelDoc;
                                row["seqvalue"] = info.Seqvalue.ToUpper();
                                row["suname"] = info.Suname.ToUpper();
                                if (!string.IsNullOrEmpty(info.Birth))
                                {
                                    DateTime dt = DateTime.ParseExact(info.Birth, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                                    row["birth"] = dt.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    row["birth"] = "";
                                }
                                if (info.Sex == "F")
                                {
                                    row["sex"] = "NỮ";
                                }
                                else
                                {
                                    row["sex"] = "NAM";
                                }
                                row["adress_pa"] = info.AdressPa;
                                row["tel_pa"] = info.TelPa;
                                row["bunho"] = Bunho;
                                if (!String.IsNullOrEmpty(_mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()))
                                {
                                    DateTime dt1 = DateTime.ParseExact(_mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                                    row["naewon_date"] = dt1.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    row["naewon_date"] = "";
                                }
                                row["fax_doc"] = info.FaxDoc;
                                row["website"] = info.Website;
                                ds.DataTable1.Rows.Add(row);

                            }
                        }
                        if (result.ListDisease.Count > 0)
                        {
                            foreach (OCS2015U00GetDiseaseReportInfo info in result.ListDisease)
                            {
                                DataRow row = ds.DataTable2.NewRow();
                                row["sang_code"] = info.SangCode;
                                row["sang_name"] = info.SangName;
                                ds.DataTable2.Rows.Add(row);
                            }
                        }
                        if (result.ListOrder.Count > 0)
                        {
                            foreach (OCS2015U00GetOrderReportInfo info in result.ListOrder)
                            {
                                DataRow row = ds.DataTable3.NewRow();
                                row["hangmog_code"] = info.HangmogCode;
                                row["hangmog_name"] = info.HangmogName;
                                row["suryang"] = info.Suryang;
                                row["dv"] = info.Dv;
                                row["nalsu"] = info.Nalsu;
                                decimal mutil = (Convert.ToDecimal(info.Suryang) * Convert.ToDecimal(info.Dv) * Convert.ToDecimal(info.Nalsu));
                                if (mutil != 0) row["multil"] = Convert.ToInt32(mutil).ToString();
                                row["bogyong_name"] = info.BogyongName;
                                row["code_name"] = info.CodeName;
                                ds.DataTable3.Rows.Add(row);

                            }
                        }
                    }

                    List<EmrRecordInfo> emrRecordInfo = ucGrid1.ExistingRecords;
                    //https://sofiamedix.atlassian.net/browse/MED-14530
                    string pkOut = _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();

                    foreach (EmrRecordInfo recordInfo in emrRecordInfo)
                    {
                        if (recordInfo.PkOut != pkOut) continue;
                        foreach (TagInfo tagInfo in recordInfo.TagInfos)
                        {
                            if (tagInfo == null || (tagInfo.Type != TypeEnum.Tag && tagInfo.Type != TypeEnum.Image)) continue;
                            DataRow row1 = ds.DataTable4.NewRow();
                            row1["TagName"] = tagInfo.TagName;
                            if (tagInfo.Type == TypeEnum.Tag)
                            {
                                row1["Content"] = tagInfo.Content;
                            }
                            else if (tagInfo.Type == TypeEnum.Image)
                            {
                                row1["ImagePath"] = Utilities.ConvertToLocalPath(tagInfo.DirLocation.Trim(), UserInfo.HospCode, Bunho);
                            }
                            ds.DataTable4.Rows.Add(row1);
                        }
                    }

                    #region don't use
                    /*List<TagInfo> lstTagB2 = ucGrid1.GetListChildrenTagA("B2");
                    if (lstTagB2.Count > 0)
                    {

                        foreach (TagInfo itemTagInfo in lstTagB2)
                        {
                            DataRow row1 = ds.DataTable4.NewRow();
                            //if (!String.IsNullOrEmpty(itemTagInfo.Content.ToString()))
                            //{
                            if (itemTagInfo.Type == Glossary.TypeEnum.Image) continue;
                            row1["TagName"] = itemTagInfo.TagName;
                            row1["Content"] = itemTagInfo.Content;
                            ds.DataTable4.Rows.Add(row1);
                            //}                           
                        }

                    }

                    #region Table5
                    if (lstTagB2.Count > 0)
                    {
                        for (int j = 0; j < lstTagB2.Count; j++)
                        {
                            if (!String.IsNullOrEmpty(lstTagB2[j].DirLocation))
                            {
                                DataRow row2 = ds.DataTable5.NewRow();
                                //row2["link_picture"] = lstTagB2[j].DirLocation.Trim();
                                row2["link_picture"] = Utilities.ConvertToLocalPath(lstTagB2[j].DirLocation.Trim(), UserInfo.HospCode, Bunho);
                                ds.DataTable5.Rows.Add(row2);
                            }

                        }
                    }

                    #endregion              #1#
                    #endregion

                    ReportMedicalRecord xReport = new ReportMedicalRecord();
                    xReport.DataSource = ds;
                    xReport.Print();*/
                    #endregion

                    PopupPrintEmr popupPrintEmr = new PopupPrintEmr(true, emrRecordInfo, Bunho, ScreenEnum.UcEditor, ucGrid1.LstOcsoOCS1003P01GridOutSangInfo, pkOut);
                    popupPrintEmr.ShowDialog();
                }
                catch
                {
                    XMessageBox.Show("Error");
                }
            }
            else
            {
                /*List<TagPrintInfo> lstTagPrintInfos = ucGrid1.GetListTagPrintInfo();*/
                PopupPrintEmr popupPrintEmr = new PopupPrintEmr(emrRecordInfo, Bunho, ScreenEnum.UcEditor, ucGrid1.LstOcsoOCS1003P01GridOutSangInfo, pkOut);
                popupPrintEmr.ShowDialog();
                /*ucGrid1.PrintPreview();*/
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            InitPopupMenuForBtnPanel();

            XButton button = sender as XButton;

            if (button != null)
                this.mPanelBtn.TrackPopup(this.PointToScreen(new Point(button.Location.X, button.Location.Y + 20)));
        }
        #endregion

        #region Method

        public UcEditor(IMainScreen main_screen)
            : this()
        {
            this._mainScreen = main_screen;
        }

        #region ReloadLatesTags
        public void ReloadLatesTags()
        {
            //Load all tagDetail
            DataProvider.Instance.ReloadLatestTags();
        }

        #endregion

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

            /*_templateIndex = this.cboTempl1.SelectedIndex;*/
            _templateIndex = this.cboTempl2.SelectedIndex;
        }

        #endregion

        #region LoadGrid
        //Load Grid

        #endregion

        #region LoadGrid
        //Load Grid
        private void LoadGridCbo(DataTable lstGrdCbo)
        {
            //ucGrid1.LoadGridCombobox(lstGrdCbo);
        }
        #endregion

        #region GetContentTemplates
        private void GetContentTemplates(bool isQueryTemp)
        {
            string a = "";
            //repositoryEmrTemplate.Items.Clear() ;
            _TemplateMap.Clear();
            int count = 0;
            /*cboTempl1.SelectedIndex = -1;*/

            //Query cbo Template
            if (isQueryTemp) QueryTemplate();
            //List<TemplateMeta> templateList = OCS2015U09Businesses.GetTemplateList();      
            this.cboTempl2.Reset();
            cboTempl2.Properties.Items.Clear();
            foreach (TemplateMeta meta in _templateList)
            {
                this.cboTempl2.Properties.Items.Add(meta.TemplateName);
                /*_TemplateMap.Add(meta.EmrTemplateId, meta.TemplateContent);*/
                _TemplateMap.Add(meta.EmrTemplateId, meta.TemplateCode);
                if (!TypeCheck.IsNull(meta.DefaultYn) && meta.DefaultYn.ToUpper() == "Y")
                {
                    _isShowMessageTemp = false;
                    this.cboTempl2.SelectedIndex = count;
                    _isShowMessageTemp = true;
                }
                count++;
            }

            if (_templateList != null && _templateList.Count > 0)
            {
                //_isSetTemDefault = true;
                SetTemplateDefault();
            }
        }

        #endregion

        #region SetTemplateDefault
        private void SetTemplateDefault()
        {
            if (_isSetTemDefault)
            {
                /*this.cboTempl1.SelectedIndex = 0;*/
                string selectedIndex = this.cboTempl2.SelectedIndex.ToString(CultureInfo.InvariantCulture);
                string emrTemplateId = _templateDictionary.ContainsKey(selectedIndex) ? _templateDictionary[selectedIndex.ToString(CultureInfo.InvariantCulture)] : "";
                if (!string.IsNullOrEmpty(emrTemplateId))
                {
                    /*ucGrid1.CurrentTemplateId = emrTemplateId;*/
                    ucGrid1.CurrentTemplateId = this.GetCbxTemContent(emrTemplateId);
                    CreateApplyTemplateToGrid(emrTemplateId);
                }
            }
        }

        private void CreateApplyTemplateToGrid(string emrTemplateId)
        {
            /*string temContent = this.GetCbxTemContent(emrTemplateId);*/
            List<OCS2015U31EmrTagGetTemplateTagsInfo> lstTagsByTempId = GetLstTagByTempId(emrTemplateId);
            /*ucGrid1.CurrentTemplateId = emrTemplateId;*/
            if (IsEmrRecordFromGrid() && _isFirstSelectedChanged)
            {
                cboTempl2.SelectedIndex = -1;
                ucGrid1.SetForcusedRowHandle(0);
            }
            else
            {
                /*ApplyTemplate(temContent, true);*/
                ApplyTemplate(lstTagsByTempId, true);
            }
        }

        #endregion

        #region QueryTemplate
        /// <summary>
        /// Get Template list from DB
        /// </summary>
        private void QueryTemplate()
        {
            _templateList.Clear();
            _templateDictionary.Clear();
            int count = 0;
            List<TemplateMeta> tmp = new List<TemplateMeta>(); // result will be stored in this List<>
            //TODO: query DB
            OCS2015U09GetTemplateComboBoxArgs args = new OCS2015U09GetTemplateComboBoxArgs();
            args.UserId = UserInfo.UserID;
            OCS2015U09GetTemplateComboBoxResult res =
                CloudService.Instance.Submit<OCS2015U09GetTemplateComboBoxResult, OCS2015U09GetTemplateComboBoxArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                _tagDictionary.Clear();
                try
                {
                    foreach (OCS2015U09GetTemplateComboBoxInfo comboBoxInfo in res.TemplateList)
                    {
                        TemplateMeta template = new TemplateMeta();
                        template.Description = comboBoxInfo.Description;
                        template.EmrTemplateId = comboBoxInfo.EmrTemplateId;
                        template.EmrTemplateTypeId = comboBoxInfo.EmrTemplateTypeId;
                        template.PermissionType = comboBoxInfo.PermissionType;
                        template.SysId = comboBoxInfo.SysId;
                        template.TemplateContent = comboBoxInfo.TemplateContent;
                        template.TemplateCode = comboBoxInfo.TemplateCode;
                        template.TemplateName = comboBoxInfo.TemplateName;
                        template.UpdId = comboBoxInfo.UpdId;
                        template.DefaultYn = comboBoxInfo.DefaultYn;

                        //add new
                        if (!_dicTempLstTags.ContainsKey(comboBoxInfo.EmrTemplateId))
                            _dicTempLstTags.Add(comboBoxInfo.EmrTemplateId, comboBoxInfo.Tags);
                        else
                        {
                            _dicTempLstTags[comboBoxInfo.EmrTemplateId] = comboBoxInfo.Tags;
                        }

                        foreach (OCS2015U31EmrTagGetTemplateTagsInfo tagInfo in comboBoxInfo.Tags)
                        {
                            template.TagList[tagInfo.TagCode] = tagInfo.TagDisplayText;

                            if (!_tagDictionary.ContainsKey(tagInfo.TagCode))
                            {
                                _tagDictionary.Add(tagInfo.TagCode, tagInfo.TagDisplayText);
                            }
                            else
                            {
                                _tagDictionary[tagInfo.TagCode] = tagInfo.TagDisplayText;
                            }
                        }


                        tmp.Add(template);
                        _templateDictionary.Add(count.ToString(CultureInfo.InvariantCulture), template.EmrTemplateId);
                        count++;
                    }

                    if (tmp.Count > 0)
                    {
                        _templateList.AddRange(tmp);
                    }
                    //GetTagsInEachTemplate();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        #endregion

        #region InsertPdfFile
        //private void InsertPdfFile(string originalFilePath, DocumentPosition pos, bool beginEndBlock)        
        private void InsertPdfFile(string originalFilePath, int pos, bool beginEndBlock, ActionType actionType)
        {
            string max_size = string.Empty;
            if (!Utilities.CheckPdfUploadFile(originalFilePath, out max_size))
            {
                XMessageBox.Show(string.Format(Resources.EMR_PDF_MAX_SIZE, max_size), Resources.WARN);
                return;
            }
            string pdfLink = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(Bunho, Path.GetFileName(originalFilePath), "pdf"), Bunho);
            File.Copy(originalFilePath, pdfLink);
            _newlyAddedImages.Add(pdfLink);
            //MED-8221
            this.ucGrid1.Upload(pdfLink);

            string pdfHash = Utilities.CalculateFileChecksum(pdfLink);
            string thumbnailFilePath;

            //thumbnailFilePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(Bunho, Path.GetFileNameWithoutExtension(pdfLink), "jpeg"), Bunho);
            thumbnailFilePath = pdfLink.Replace(".pdf", ".jpeg");
            try
            {
                GhostscriptWrapper.GeneratePageThumb(pdfLink, thumbnailFilePath, 1, 24, 24);
                this.ucGrid1.Upload(thumbnailFilePath);
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
            FileDocumentImageSource image = new FileDocumentImageSource(thumbnailFilePath);

            //FileDocumentImageSource image = GetPdfThumbnail(pdfLink, out thumbnailFilePath);
            //FileDocumentImageSource image = GetPdfThumbnail(originalFilePath, out thumbnailFilePath);

            _newlyAddedImages.Add(pdfLink);
            _newlyAddedImages.Add(thumbnailFilePath);
            string thumbnailHash = Utilities.CalculateImageChecksum(image.Stream);
            if (!metaDictionary.ContainsKey(thumbnailHash))
            {
                metaDictionary.Add(
                    thumbnailHash,
                    new PdfMeta(pdfHash, pdfLink, new ImageMeta(thumbnailHash, thumbnailFilePath, 0.25f, 0.25f)));
            }
            ucGrid1.InsertImage(thumbnailFilePath, TypeEnum.Pdf, pdfLink, actionType, true);
        }
        #endregion

        public void ApplyTemplate(string tagContent, bool reset)
        {
            this.ucGrid1.GetTemplate(tagContent);
            //if (reset) Reset(true);
        }

        public void ApplyTemplate(List<OCS2015U31EmrTagGetTemplateTagsInfo> lstTagInfo, bool reset)
        {
            this.ucGrid1.GetTemplate(lstTagInfo, _bunho);
            //if (reset) Reset(true);
        }

        /*public void GetCurrentTagContent(string tagContent)
        {
            string[] tagContentArr = tagContent.Split(new char[] { ',' });
            string currentRoot = null;
            List<string> conversionTags = new List<string>();
            Dictionary<String, List<String>> allTag = DataProvider.Instance.Tags;

            foreach (string tg in tagContentArr)
            {
                if (allTag.ContainsKey(tg.Trim()))
                {
                    currentRoot = tg.Trim();
                    conversionTags.Add(tg.Trim());
                }
                else if (currentRoot != null && allTag[currentRoot].Contains(tg.Trim()))
                {
                    conversionTags.Add(string.Format("{0}-{1}", currentRoot, tg.Trim()));
                }
            }

            //this.GetPrevTagContent();
            _backupTagList.Clear();

            TemplateTagItem mTagItem;
            //Get all tag content in Editor
            List<TemplateTagItem> mTagContentEditingLst = new List<TemplateTagItem>();

            if (tagContentArr.Length > 0)
            {
                //Todo: hash code
                DataTable dtCboGrd = DataCreator.CboTagData();
                dtCboGrd.Rows.Clear();

                List<EmrRecordInfo> lstRecord = DataCreator.GetData(3, 5, false);
                DataTable dtGrd = Utilities.ConvertListObjToDataTable(lstRecord[0].TagInfos);

                //DataTable dtGrd = DataCreator.CreateDataGridEditor(20, "", true);
                dtGrd.Rows.Clear();

                if (string.IsNullOrEmpty(tagContent))
                {
                    _backupTagList.Clear();
                    dtGrd.Rows.Clear();
                    //Todo: Load grid this!
                    //LoadGrid(dtGrd);

                    return;
                }

                for (int i = 0; i < conversionTags.Count; i++)
                {
                    OCS2015U06Businesses.TagInfo info = DataProvider.Instance.TagDetail.ContainsKey(conversionTags[i].ToString(CultureInfo.InvariantCulture)) ? DataProvider.Instance.TagDetail[conversionTags[i].ToString(CultureInfo.InvariantCulture)] : null;
                    if (info != null)
                    {
                        //add tag to Grid follow Template
                        dtCboGrd.Rows.Add(info.TagCode, info.TagDisplay);
                        dtGrd.Rows.Add(i, info.TagCode, info.TagDisplay, "");
                    }
                    //Get tag content in Editor
                    mTagItem = GetTagEditingByTagCode(mTagContentEditingLst, conversionTags[i]);
                    //string tagName = _tagDictionary[conversionTags[i].ToString(CultureInfo.InvariantCulture)];
                    //Dictionary<string, string> dicTagCodeName = DataProvider.Instance.TagDetailCodeName();
                    //string tagName = dicTagCodeName[conversionTags[i].ToString(CultureInfo.InvariantCulture)];
                    ////string tagName = DataProvider.Instance.TagDetailCodeName.ContainsKey(conversionTags[i].ToString(CultureInfo.InvariantCulture));
                    //dtCboGrd.Rows.Add(conversionTags[i], tagName);
                    if (mTagItem == null)
                    {
                        //get tag content in history
                        mTagItem = GetTagContentByTagCode(conversionTags[i].Trim());
                        if (mTagItem == null)
                        {
                            mTagItem = new TemplateTagItem(conversionTags[i].Trim(), "", "", true);
                        }
                    }
                    _backupTagList.Add(mTagItem);
                }

                LoadGridCbo(dtCboGrd);
                //LoadGrid(dtGrd);
            }
        }*/

        /// <summary>
        /// Get tag item in tag List by tag name
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public TemplateTagItem GetTagContentByTagCode(string tagCode)
        {
            if (_historyTagContentLst.Count <= 0) return null;
            TemplateTagItem templateTagItem = null;
            foreach (TemplateTagItem item in _historyTagContentLst)
            {
                if (tagCode.Trim() == item.TagCode)
                {
                    string tagName = "";
                    templateTagItem = new TemplateTagItem(tagCode, tagName, item.TagContent, false);
                }
            }
            return templateTagItem;
        }
        /// <summary>
        /// Get Tag'content in Edittor by tagcode
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="tagCode"></param>
        /// <returns></returns>
        public TemplateTagItem GetTagEditingByTagCode(List<TemplateTagItem> lst, string tagCode)
        {
            if (lst.Count <= 0) return null;
            foreach (TemplateTagItem item in lst)
            {
                if (tagCode.Trim() == item.TagCode)
                {
                    return item;
                }
            }
            return null;
        }

        public void Reset(bool isApplyTem)
        {
            BindGridComment();
            //if (isApplyTem) BindStyles();
            metaDictionary.Clear();
            hashFileNameDict.Clear();
            _newlyAddedImages.Clear();
        }

        public void VisiableAllCtrl(bool value)
        {
            ucGrid1.Enabled = value;
            insertPdfItem.Enabled = value;
            insertImage1.Enabled = value;
            AddComment.Enabled = value;
            barButtonItem3.Enabled = value;
            labelControl1.Enabled = value;
            insertBookmark.Enabled = value;
            cboTempl2.Enabled = value;
            cboDisplay1.Enabled = value;
            if (btnMore != null) btnMore.Enabled = value;
            if (btnInsertPdfItem != null) btnInsertPdfItem.Enabled = value;
            if (btnInsertImage != null) btnInsertImage.Enabled = value;
            if (btnAddComment != null) btnAddComment.Enabled = value;
            if (btnPrint != null) btnPrint.Enabled = value;

        }

        private void BindGridComment()
        {
            /*List<CommentMeta> comments = new List<CommentMeta>();
            foreach (CustomMark mark in richEditControl.Document.CustomMarks)
            {
                CommentMeta meta = JsonConvert.DeserializeObject<CommentMeta>(mark.UserData.ToString());
                if (meta != null) comments.Add(meta);
            }*/

        }

        public bool IsEmrRecordFromGrid()
        {
            EmrRecordInfo editorEmrRecordInfo = this.ucGrid1.GetEmrRecordFromGrid(false, UserInfo.UserID);
            return (editorEmrRecordInfo.TagInfos.Count > 0);
        }

        public bool IsExistOrderInfo()
        {
            EmrRecordInfo editorEmrRecordInfo = this.ucGrid1.GetEmrRecordFromGrid(true, UserInfo.UserID);
            return (editorEmrRecordInfo.OrderInfos.Count > 0);
        }

        private void SetTooltipForButtonControl()
        {
            tooltip1.SetToolTip(btnInsertPdfItem, Resources.UcEditorS_SetTooltipForButtonControl_BtnInsertPdfItem);
            tooltip1.SetToolTip(btnInsertImage, Resources.UcEditorS_SetTooltipForButtonControl_BtnInsertImage2);
            tooltip1.SetToolTip(btnAddComment, Resources.UcEditorS_SetTooltipForButtonControl_BtnAddComment2);
            tooltip1.SetToolTip(btnPrint, Resources.UcEditorS_SetTooltipForButtonControl_BtnPrint2);
        }

        private void InitPopupMenuForBtnPanel()
        {
            mPanelBtn.MenuCommands.Clear();

            IHIS.X.Magic.Menus.MenuCommand popUpMenu;
            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.UcEditorS_SetTooltipForButtonControl_BtnInsertPdfItem,
                (Image)this.imageList1.Images[6], new EventHandler(btnInsertPdfItem_Click));
            popUpMenu.Tag = "1";
            mPanelBtn.MenuCommands.Add(popUpMenu);

            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.UcEditorS_SetTooltipForButtonControl_BtnInsertImage2,
                (Image)this.imageList1.Images[4], new EventHandler(btnInsertImage_Click));
            popUpMenu.Tag = "2";
            mPanelBtn.MenuCommands.Add(popUpMenu);

            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.UcEditorS_SetTooltipForButtonControl_BtnAddComment2,
                (Image)this.imageList1.Images[2], new EventHandler(btnAddComment_Click));
            popUpMenu.Tag = "3";
            mPanelBtn.MenuCommands.Add(popUpMenu);

            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.UcEditorS_SetTooltipForButtonControl_BtnPrint2,
                (Image)this.imageList1.Images[11], new EventHandler(btnPrint_Click));
            popUpMenu.Tag = "4";
            mPanelBtn.MenuCommands.Add(popUpMenu);
        }

        public void EnableMenuPopup(bool value)
        {
            this.bar3.Visible = !value;
            this.btnInsertImage.Visible = !value;
            this.btnInsertPdfItem.Visible = !value;
            this.btnAddComment.Visible = !value;
            this.btnPrint.Visible = !value;
            this.btnMore.Visible = value;
        }
        #endregion
    }
}
