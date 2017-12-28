using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Threading;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using EmrDocker.Glossary;
using EmrDocker.Models;
using EmrDocker.Types;
using EmrDockerS;
using ERMUserControl;
using DevExpress.Utils;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.Framework;
using IHIS.OCSO;
using MedicalInterfaceTest;
using Newtonsoft.Json;
using PaintDotNet;
using Utilities = IHIS.OCSO.Utilities;
using DevExpress.XtraRichEdit.Utils;
using IHIS.CloudConnector.Caching;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using MedicalInterface;
using System.Text;
using GhostscriptSharp;
using System.Text.RegularExpressions;

namespace EmrDocker
{
    //[ComplexBindingProperties("DataSource", "DataMember")]
    public partial class UcGrid : XtraUserControl
    {
        #region Contructor

        public UcGrid()
        {
            InitializeComponent();
            //LoadGrid(DataCreator.CreateDataGrid(20, "", false));
            gridView1.MasterRowExpanded += gridView1_MasterRowExpanded;
            grdContent.ForceInitialize();

            //MED-8221config devexpress multi-threading
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
        }

        #endregion

        #region Field & Properties
        //int selectedRowIndex;

        private PatientModelInfo _patientModel;
        private string _pkout;
        private DataTable currentDataSource;
        private DataTable currentDataOrder;
        public string strMml = "";
        private const string B1 = "B1";
        private const string B2 = "B2";
        public string _strMsgCheckTagCodeAndContent;
        private string _naewonKey = "";
        private bool _isEnableBtnDo = true;
        private ScreenEnum _screen;

        private string CACHE_FIRST_DATE_TIME = "CACHE_FIRST_DATE_TIME_{0}";
        private DateTime _dtFromServer;
        private string _dateCacheFromServer;
        /*private const string STRFDTEMP = "1000123888";*/
        private const string STRFDTEMP = "emr_template";
        private List<string> fileUploaded = new List<string>();
        private bool isConfirmSave = false;
        private string _currentTemplateId = "";

        private string _gwa = string.Empty;
        private Dictionary<string, CommentInfo> dicCommentInfos = new Dictionary<string, CommentInfo>();

        public delegate void UpdateCommentsHandler(object sender, UpdateCommentsAgr e);
        public event UpdateCommentsHandler UpdateComments;

        private string oldMmlContent;
        private ContextMenu emptyMenu;

        private List<OcsoOCS1003P01GridOutSangInfo> _lstOcsoOCS1003P01GridOutSangInfo = new List<OcsoOCS1003P01GridOutSangInfo>();

        public List<OcsoOCS1003P01GridOutSangInfo> LstOcsoOCS1003P01GridOutSangInfo
        {
            get { return _lstOcsoOCS1003P01GridOutSangInfo; }
            set { _lstOcsoOCS1003P01GridOutSangInfo = value; }
        }

        int masterId = 0, detailId = 0;

        List<int> orderList = new List<int>();
        private TextEdit _textEdit = null;
        private string _currentSelectedText = "";
        private bool isReCalRowHeight = false;
        private int _currentRowHeight = 0;
        private const int DefaultRowHeight = 24;
        private const string LBLY = "Y";
        private const string LBLN = "N";
        private const string LBLSub = "-";

        public bool IsConfirmSave
        {
            get { return isConfirmSave; }
            set { isConfirmSave = value; }
        }

        private List<CommentInfo> currentComments = new List<CommentInfo>();
        public List<CommentInfo> CurrentComments
        {
            get { return currentComments; }
            set { currentComments = value; }
        }

        public string CurrentTemplateId
        {
            get { return _currentTemplateId; }
            set { _currentTemplateId = value; }
        }

        public Dictionary<string, CommentInfo> DicCommentInfos
        {
            get
            {
                return dicCommentInfos;
            }
        }

        public PatientModelInfo PatientModel
        {
            get { return this._patientModel; }
            set { this._patientModel = value; }
        }
        public string Gwa
        {
            set { _gwa = value; }
        }

        public bool IsEnableBtnDo
        {
            get { return _isEnableBtnDo; }
            set { _isEnableBtnDo = value; }
        }

        public string StrMsgCheckTagCodeAndContent
        {
            get { return this._strMsgCheckTagCodeAndContent; }
            set { this._strMsgCheckTagCodeAndContent = value; }
        }

        public string NaewonKey
        {
            get { return _naewonKey; }
            set { _naewonKey = value; }
        }

        public string Pkout
        {
            get { return _pkout; }
        }
        public DataTable CurrentDataOrder
        {
            get { return currentDataOrder; }
        }

        #region Check media files to upload
        private Dictionary<string, string> mediaDictionary = new Dictionary<string, string>();
        public Dictionary<string, string> MediaDictionary
        {
            get { return mediaDictionary; }
            set { mediaDictionary = value; }
        }
        private bool ExistMediaFile(string hashCode)
        {
            try
            {
                return this.MediaDictionary.ContainsKey(hashCode) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            return false;
        }
        private void MediaDictionaryAdd(string hashCode, string filePath)
        {
            try
            {
                if (!this.MediaDictionary.ContainsKey(hashCode))
                    this.MediaDictionary.Add(hashCode, filePath);
                else
                {
                    MediaDictionary[hashCode] = filePath;
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }
        private void MediaDictonaryClear()
        {
            this.mediaDictionary.Clear();
        }
        #endregion

        #endregion

        #region Event

        #region Event handle
        public event KeyEventHandler KeyDown;
        #endregion

        private void grdContent_Load(object sender, EventArgs e)
        {
            RepositoryItemMemoEdit myGridMemoEdit = new RepositoryItemMemoEdit();
            myGridMemoEdit.WordWrap = true;
            gridView1.OptionsView.RowAutoHeight = true;
            repositoryItemButtonEdit1.TextEditStyle = TextEditStyles.HideTextEditor;

            repositoryItemButtonEdit1.LookAndFeel.UseDefaultLookAndFeel = false;
            repositoryItemButtonEdit1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            repositoryItemButtonEdit1.Appearance.Options.UseBackColor = true;

            gridView2.Columns["OrderDisplayOrder"].OptionsColumn.FixedWidth = true;
            gridView2.Columns["OrderDisplayOrder"].Width = 75;

            gridView2.Columns["BtnDo"].OptionsColumn.FixedWidth = true;
            gridView2.Columns["BtnDo"].Width = 75;
            //gridView2.Columns["BtnDo"].Caption = "Do";

            SetItemComboCheckBoxEdit();

            grdContent.ForceInitialize();
            InitAppearance();
        }

        private void SetItemComboCheckBoxEdit()
        {
            repositoryItemCheckedComboBoxEdit1.Items.Clear();
            repositoryItemCheckedComboBoxEdit2.Items.Clear();

            repositoryItemCheckedComboBoxEdit1.SelectAllItemCaption = Resources.UcGrid_RpItChBox_SelectAll;
            repositoryItemCheckedComboBoxEdit1.Items.Add("D", Resources.UcGrid_RpItChBox_Doctor);
            repositoryItemCheckedComboBoxEdit1.Items.Add("O", Resources.UcGrid_RpItChBox_OtherClinic);
            repositoryItemCheckedComboBoxEdit1.Items.Add("R", Resources.UcGrid_RpItChBox_Relected);
            repositoryItemCheckedComboBoxEdit1.Items.Add("P", Resources.UcGrid_RpItChBox_Patient);

            repositoryItemCheckedComboBoxEdit2.SelectAllItemCaption = Resources.UcGrid_RpItChBox_SelectAll;
            repositoryItemCheckedComboBoxEdit2.Items.Add("D", Resources.UcGrid_RpItChBox_Doctor);
            repositoryItemCheckedComboBoxEdit2.Items.Add("O", Resources.UcGrid_RpItChBox_OtherClinic);
            repositoryItemCheckedComboBoxEdit2.Items.Add("R", Resources.UcGrid_RpItChBox_Relected);
            repositoryItemCheckedComboBoxEdit2.Items.Add("P", Resources.UcGrid_RpItChBox_Patient);
        }

        private void grdContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control | e.KeyCode == Keys.N)
            {
                int selectedRowIndex = gridView1.FocusedRowHandle > 0 ? gridView1.FocusedRowHandle : 0;
                DataTable dt = grdContent.DataSource as DataTable;
                DataRow newRow = dt != null ? dt.NewRow() : null;
                DataRow currentRow = dt != null && dt.Rows.Count > 0 ? dt.Rows[selectedRowIndex] : null;
                if (newRow == null) return;
                newRow["OrderMaster"] = ++masterId;
                newRow["Id"] = Guid.NewGuid();
                newRow["TagCode"] = "";
                newRow["TagName"] = "";
                newRow["Content"] = "";
                newRow["PkOut"] = currentRow == null ? _pkout : currentRow["PkOut"];
                newRow["CreateDate"] = _dateCacheFromServer;

                dt.Rows.InsertAt(newRow, selectedRowIndex + 1);
                //gridView1.AddNewRow();
                gridView1.FocusedRowHandle = gridView1.GetRowHandle(selectedRowIndex + 1);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                //move to grdContent_ProcessGridKey() func
                //int selectedRowIndex = gridView1.FocusedRowHandle > 0 ? gridView1.FocusedRowHandle : 0;
                //DataTable dt = grdContent.DataSource as DataTable;
                //if (dt != null)
                //{
                //    DataRow currentRow = dt.Rows[selectedRowIndex];
                //    if (!currentRow["Type"].ToString().Equals("3") && !currentRow["Type"].ToString().Equals("4") || gridView1.FocusedColumn.FieldName == "TagCode")
                //        gridView1.DeleteSelectedRows();
                //}
            }
            else if (e.KeyCode == Keys.Enter)
            {

            }
            else if (e.KeyCode == Keys.Tab)
            {
                //DevExpress support for issue
                /*//GridColumn column = gridView1.Columns["TagCode"];
                GridColumn columnFocus = gridView1.FocusedColumn;
                if (columnFocus == colTagCode)
                {
                    int selectedRowIndex = gridView1.FocusedRowHandle > 0 ? gridView1.FocusedRowHandle : 0;
                    gridView1.FocusedColumn = colContent;
                    gridView1.FocusedRowHandle = gridView1.GetRowHandle(selectedRowIndex - 1);
                    /*ColumnView columnView = sender as ColumnView;
                    if (columnView != null) columnView.MoveNext();#1#

                    /*ColumnView columnView = grdContent.FocusedView as ColumnView;
                    if (columnView != null)
                        columnView.FocusedRowHandle++;#1#

                    gridView1.FocusedColumn = gridView1.GetNearestCanFocusedColumn(gridView1.FocusedColumn);
                    gridView1.CloseEditor();
                    gridView1.MoveNext();
                    e.Handled = true;
                }*/
            }
        }


        private int rowToBeUpdated = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        private List<EmrRecordInfo> _existingRecords;

        public List<EmrRecordInfo> ExistingRecords
        {
            get { return _existingRecords; }
        }


        private void gridView1_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            if (isReCalRowHeight)
            {
                /*e.RowHeight += 50;*/
                _currentRowHeight = e.RowHeight;
                MemoEdit memo = sender as MemoEdit;
                if (memo != null)
                {
                    Graphics gr = memo.CreateGraphics();
                    int lenght = memo.Lines.Length;
                    if (memo.Height < 68) memo.Height = (lenght * DefaultRowHeight);
                }

                e.RowHeight = 100;
                repositoryItemMemoEdit1_EditValueChanging(new object(), new ChangingEventArgs(null, new object()));
                isReCalRowHeight = false;
            }

            /*//AnhLT - Customize
            GridView view = sender as GridView;
            if (view != null)
            {
                GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
                int width = colContent.VisibleWidth;
                GraphicsInfo info = new GraphicsInfo();
                info.AddGraphics(null);
                string text = view.GetRowCellDisplayText(e.RowHandle, colContent);
                if (viewInfo != null)
                {
                    viewInfo.PaintAppearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    e.RowHeight = DevExpress.Utils.Text.TextUtils.GetStringHeight(info.Graphics, text, viewInfo.PaintAppearance.Row.Font, width, viewInfo.PaintAppearance.Row.TextOptions.GetStringFormat());
                }
                info.ReleaseGraphics();
            }*/
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            gridView1.CustomRowCellEdit -= gridView1_CustomRowCellEdit;
            /*if (e.Column.FieldName == "TagCode")
            {
                string strType = gridView1.GetRowCellValue(e.RowHandle, "TagCode").ToString();
                repositoryItemGridLookUpEdit1.Appearance.TextOptions.HAlignment = HorzAlignment.Default;
                if (DataProvider.Instance.TagDetailCodeName.ContainsKey(strType))
                {
                    repositoryItemGridLookUpEdit1.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                }
            }*/

            if (e.Column.FieldName == "Content")
            {
                if (gridView1.GetRowCellValue(e.RowHandle, "Type") != null && !string.IsNullOrEmpty(gridView1.GetRowCellValue(e.RowHandle, "Type").ToString()))
                {
                    int a;
                    if (Int32.TryParse(gridView1.GetRowCellValue(e.RowHandle, "Type").ToString(), out a))
                    {
                        string strType = Enum.GetName(typeof(TypeEnum), a);
                        TypeEnum typeItem = KeyEnum(strType);
                        if (typeItem == TypeEnum.Image || typeItem == TypeEnum.Pdf)
                        {
                            e.RepositoryItem = repositoryItemPictureEdit1;
                            /*repositoryItemPictureEdit1.SizeMode = PictureSizeMode.Squeeze;*/
                            repositoryItemPictureEdit1.SizeMode = PictureSizeMode.Zoom;
                            repositoryItemPictureEdit1.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                        }
                        else
                        {
                            e.RepositoryItem = repositoryItemMemoEdit1;
                        }
                    }
                    else
                    {
                        //int a = gridView1.GetRowCellValue(e.RowHandle, "Type");
                        string strType = gridView1.GetRowCellValue(e.RowHandle, "Type").ToString();
                        TypeEnum typeItem = KeyEnum(strType);
                        if (typeItem == TypeEnum.Image || typeItem == TypeEnum.Pdf)
                        {
                            e.RepositoryItem = repositoryItemPictureEdit1;
                            repositoryItemPictureEdit1.SizeMode = PictureSizeMode.Zoom;
                            repositoryItemPictureEdit1.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                        }
                        else
                        {
                            e.RepositoryItem = repositoryItemMemoEdit1;
                        }
                    }
                    /*//int a = gridView1.GetRowCellValue(e.RowHandle, "Type");
                    string strType = Enum.GetName(typeof(TypeEnum), a);
                    TypeEnum typeItem = KeyEnum(strType);
                    if (typeItem == TypeEnum.Image || typeItem == TypeEnum.Pdf)
                    {
                        e.RepositoryItem = repositoryItemPictureEdit1;
                        repositoryItemPictureEdit1.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                    }
                    else
                    {
                        e.RepositoryItem = repositoryItemMemoEdit1;
                    }*/
                }
            }

            gridView1.CustomRowCellEdit += new CustomRowCellEditEventHandler(gridView1_CustomRowCellEdit);
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //gridView1.CellValueChanged -= gridView1_CellValueChanged;

            //try
            //{
            //    LoadTagName(e);
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    gridView1.CellValueChanged += gridView1_CellValueChanged;
            //}
        }

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.Name != colTagCode.Name) return;
                LoadTagName(e.Value.ToString().Trim());
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null && e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Transparent;

                string type = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Type"]);
                if (type == "4")
                {
                    /*e.Appearance.BackColor = Color.Khaki;
                    e.Appearance.BackColor2 = Color.Khaki;*/

                    e.Appearance.BackColor = ColorTranslator.FromHtml("#ffffcc");
                }
            }
            //if (gridView1.IsCellSelected(e.RowHandle, e.Column))
            //{
            //    e.Appearance.BackColor = Color.LightSkyBlue;
            //    e.Appearance.BackColor2 = Color.LightSkyBlue;
            //}
            /*for (int i = 0; i < view.RowCount; i++)
            {
                if (((TypeEnum)(view.GetDataRow(i)["Type"])).Equals(TypeEnum.Header))
                {
                    e.Appearance.BackColor = Color.LightSkyBlue;
                }
            }*/
        }

        public void PrintPreview()
        {
            using (PrintingSystem printingSystem = new PrintingSystem())
            {
                using (PrintableComponentLink link = new PrintableComponentLink(printingSystem))
                {
                    //link.Component = richEditControl;
                    link.Component = grdContent;
                    link.CreateDocument();
                    link.ShowPreviewDialog();
                    //MED-13556
                    //gridView1.OptionsPrint.PrintHorzLines = false;
                    //gridView1.OptionsPrint.PrintVertLines = false;
                    //gridView1.OptionsPrint.ExpandAllDetails = true;
                    //gridView1.AppearancePrint.HeaderPanel.Options.UseTextOptions = false;
                    //gridView1.OptionsPrint.PrintDetails = true;
                }
            }
        }

        public void gridView1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView gridViewWelds = sender as GridView;
            if (gridViewWelds != null)
            {
                GridView grdViewMd = gridViewWelds.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                //grdViewMd.Bo
                if (grdViewMd != null)
                {
                    grdViewMd.CellMerge -= grdViewMd_CellMerge;
                    grdViewMd.ShowingEditor -= gridViewMd_ShowingEditor;
                    grdViewMd.CustomRowCellEdit += grdViewMd_CustomRowCellEdit;
                    grdViewMd.BeginUpdate();
                    grdViewMd.Columns["OrderDisplayOrder"].OptionsColumn.FixedWidth = true;
                    grdViewMd.Columns["BtnDo"].OptionsColumn.FixedWidth = true;
                    grdViewMd.Columns["InputGubunName"].OptionsColumn.AllowSize = true;
                    grdViewMd.Columns["OrderGubunName"].OptionsColumn.AllowSize = true;
                    grdViewMd.Columns["HangmogName"].OptionsColumn.AllowSize = true;
                    grdViewMd.Columns["Content"].OptionsColumn.AllowSize = true;

                    grdViewMd.Columns["OrderDisplayOrder"].VisibleIndex = 6;

                    grdViewMd.Columns["OrderDisplayOrder"].Width = 50;
                    grdViewMd.Columns["BtnDo"].Width = 40;
                    grdViewMd.Columns["InputGubunName"].Width = 50;
                    grdViewMd.Columns["OrderGubunName"].Width = 60;
                    grdViewMd.Columns["HangmogName"].Width = 220;
                    grdViewMd.Columns["Content"].Width = 50;


                    //grdViewMd.Columns["BtnDo"].ColumnEdit = repositoryItemButtonEdit1;
                    grdViewMd.Columns["OrderCurrent"].Visible = false;
                    grdViewMd.Columns["ParrentTagCurrent"].Visible = false;
                    grdViewMd.Columns["GubunBass"].Visible = false;
                    grdViewMd.Columns["HangmogCode"].Visible = false;
                    grdViewMd.Columns["ActionDoYn"].Visible = false;
                    grdViewMd.Columns["Bunho"].Visible = false;
                    grdViewMd.Columns["Doctor"].Visible = false;
                    grdViewMd.Columns["Gwa"].Visible = false;
                    grdViewMd.Columns["NaewonDate"].Visible = false;
                    grdViewMd.Columns["NaewonKey"].Visible = false;
                    grdViewMd.Columns["InputTab"].Visible = false;
                    grdViewMd.Columns["InputTabAndGroupSer"].Visible = false;
                    //grdViewMd.Columns["BtnDo"].Caption = "Do";

                    grdViewMd.BorderStyle = BorderStyles.Default;
                    grdViewMd.OptionsView.ShowHorzLines = true;
                    grdViewMd.OptionsView.ShowVertLines = true;
                    grdViewMd.OptionsView.AllowCellMerge = true;
                    grdViewMd.CellMerge += grdViewMd_CellMerge;
                    grdViewMd.ShowingEditor += gridViewMd_ShowingEditor;
                    grdViewMd.EndUpdate();
                }
            }
        }

        /// <summary>
        /// Simulates a repositoryItemButtonEdit1_Click event
        /// 2015.09.25 AnhNV Added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdViewMd_Click(object sender, EventArgs e)
        {
            GridView grdViewOder = sender as GridView;

            if (grdViewOder.FocusedColumn.FieldName == colBtnDo.FieldName)
            {
                string bunho = "";
                string doctor = "";
                string gwa = "";
                string naewonDate = "";
                string naewonKey = "";
                string inputTab = "";
                string actionDoYn = "";
                string groupSerAndInputab = "";

                string focusVal = grdViewOder.FocusedValue.ToString();
                if (focusVal.Length < 2) return;
                string selectedInputTab = focusVal.Substring(focusVal.Length - 2);

                // Get row which is clicked on Do button
                DataRow selectedRow = grdViewOder.GetFocusedDataRow();

                if (selectedRow != null && IsEnableBtnDo)
                {
                    if (selectedRow["ActionDoYn"].ToString() == LBLN)
                    {
                        XMessageBox.Show(Resources.UcGrid_grdViewMd_Click_Can_t_Do_Order);
                        return;
                    }
                    bunho = selectedRow["Bunho"].ToString();
                    doctor = selectedRow["Doctor"].ToString();
                    gwa = selectedRow["Gwa"].ToString();
                    naewonDate = selectedRow["NaewonDate"].ToString();
                    naewonKey = selectedRow["NaewonKey"].ToString();
                    inputTab = selectedInputTab;
                    groupSerAndInputab = selectedRow["InputTabAndGroupSer"].ToString();
                    //inputTab = selectedRow["InputTabAndGroupSer"].ToString();
                    DoButtonBusiness.DoOrder(bunho, doctor, gwa, naewonDate, naewonKey, inputTab, groupSerAndInputab);
                }
            }
            //gridView1.ExpandAllGroups();
        }

        private void grdViewMd_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView grdViewOder = sender as GridView;
            grdViewOder.Click -= grdViewMd_Click;

            // Sort by input tab
            /*grdViewOder.Columns["InputTab"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;*/
            grdViewOder.Columns["InputTabAndGroupSer"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            // Merges button Do only
            if (e.Column.Name != "colBtnDo")
            {
                e.Column.OptionsColumn.AllowMerge = DefaultBoolean.False;
            }
            else
            {
                string text1 = grdViewOder.GetRowCellDisplayText(e.RowHandle1, colInputTabAndGroupSer);
                string text2 = grdViewOder.GetRowCellDisplayText(e.RowHandle2, colInputTabAndGroupSer);
                e.Merge = (text1 == text2);
                e.Handled = true;
                grdViewOder.Click += grdViewMd_Click;
            }
        }

        void grdViewMd_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            /*GridView grdViewOder1 = sender as GridView;
            if (grdViewOder1 != null) grdViewOder1.Click += grdViewMd_Click;*/

            if (e.Column.Name.Equals("colBtnDo"))
            {
                if (IsEnableBtnDo)
                {
                    /*repositoryItemButtonEdit1.Buttons[0].Appearance.BackColor2 = Color.FromArgb(192, 255, 255);*/
                    repositoryItemButtonEdit1.Buttons[0].Appearance.BackColor2 = ColorTranslator.FromHtml("#CAFECE");
                    repositoryItemButtonEdit1.Buttons[0].Enabled = true;
                }
                else
                {
                    repositoryItemButtonEdit1.Buttons[0].Appearance.BackColor2 = Color.White;
                    repositoryItemButtonEdit1.Buttons[0].Enabled = false;
                }
                e.RepositoryItem = string.IsNullOrEmpty(e.CellValue.ToString()) ? (RepositoryItem)repositoryItemMemoEdit1 : repositoryItemButtonEdit1;

                if (IsEnableBtnDo)
                {
                    e.RepositoryItem.ReadOnly = false;
                    e.RepositoryItem.Enabled = true;
                    e.RepositoryItem.UnLockEvents();
                    /*this.repositoryItemButtonEdit1.ButtonClick += repositoryItemButtonEdit1_ButtonClick;
                    GridView grdViewOder1 = sender as GridView;
                    if (grdViewOder1 != null) grdViewOder1.Click += grdViewMd_Click;*/

                    GridView grdViewOder1 = sender as GridView;
                    if (grdViewOder1 != null)
                    {
                        string rowValue = grdViewOder1.GetRowCellValue(e.RowHandle, colActionDoYn).ToString();
                        /*repositoryItemButtonEdit1.Buttons[0].Caption = rowValue == "N" ? "Not DO" : "Do";*/
                    }
                }
                else
                {
                    e.RepositoryItem.ReadOnly = true;
                    e.RepositoryItem.Enabled = false;
                    e.RepositoryItem.LockEvents();
                    /*this.repositoryItemButtonEdit1.ButtonClick -= repositoryItemButtonEdit1_ButtonClick;
                    GridView grdViewOder = sender as GridView;
                    if (grdViewOder != null) grdViewOder.Click -= grdViewMd_Click;*/
                }
            }
            else
            {
                GridView grdOrder = (GridView)sender;
                if (grdOrder != null)
                {
                    if (e.Column.Name.Equals(colOrderDisplayOrder.Name))
                    {
                        e.RepositoryItem = /*string.IsNullOrEmpty(e.CellValue.ToString()) ? (RepositoryItem)repositoryItemMemoEdit1 : */repositoryItemCheckedComboBoxEdit2;
                    }
                    else
                    {
                        string rowValue = grdOrder.GetRowCellValue(e.RowHandle, colActionDoYn).ToString();
                        if (rowValue == LBLN)
                            e.RepositoryItem = TestMethod();
                    }
                }
            }
        }

        #region btnDo Action

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!IsEnableBtnDo) return;
            string bunho = "";
            string doctor = "";
            string gwa = "";
            string naewonDate = "";
            string naewonKey = "";
            string inputTab = "";
            string groupSerAndInputab = "";

            GridView view = grdContent.FocusedView as GridView;
            if (view == null) return;
            DataRowView selRow = (DataRowView)(grdContent.MainView.GetRow(view.FocusedRowHandle));
            int indexRow = view.FocusedRowHandle;
            //string a = selRow["Bunho"].ToString();
            bunho = view.GetRowCellValue(indexRow, view.Columns["Bunho"]).ToString();
            doctor = view.GetRowCellValue(indexRow, view.Columns["Doctor"]).ToString();
            gwa = view.GetRowCellValue(indexRow, view.Columns["Gwa"]).ToString();
            naewonDate = view.GetRowCellValue(indexRow, view.Columns["NaewonDate"]).ToString();
            naewonKey = view.GetRowCellValue(indexRow, view.Columns["NaewonKey"]).ToString();
            inputTab = view.GetRowCellValue(indexRow, view.Columns["InputTab"]).ToString();
            groupSerAndInputab = view.GetRowCellValue(indexRow, view.Columns["InputTabAndGroupSer"]).ToString();
            DoButtonBusiness.DoOrder(bunho, doctor, gwa, naewonDate, naewonKey, inputTab, groupSerAndInputab);
        }

        #endregion

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view != null && !view.IsNewItemRow(e.RowHandle)) return;
            //if (view != null)
            //{
            //    view.SetMasterRowExpanded(view.FocusedRowHandle, true);
            //    GridView detailView = view.GetDetailView(view.FocusedRowHandle, 0) as GridView;
            //    if (detailView != null)
            //    {
            //        detailView.AddNewRow();
            //        BeginInvoke(new MethodInvoker(delegate
            //                                        {
            //                                            grdContent.FocusedView = detailView;
            //                                            detailView.ShowEditor();
            //                                        }
            //                    ));
            //    }
            //}
        }

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null && (e.Column.VisibleIndex == 0 && view.IsMasterRowEmpty(e.RowHandle)))
            {
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetDataRow(i)["TagCode"].Equals("Orders"))
                    {
                        //gridView1.SetMasterRowExpanded(i, true);
                    }

                    /*if (((TypeEnum)(view.GetDataRow(i)["Type"])).Equals(TypeEnum.Header))
                    {
                        e.Appearance.BackColor = Color.LightSkyBlue;
                    }*/
                }
                GridCellInfo gridCellInfo = e.Cell as GridCellInfo;
                if (gridCellInfo != null) gridCellInfo.CellButtonRect = Rectangle.Empty;
            }

            //GridView grdViewOder = view.GetDetailView(e.RowHandle, e.RowHandle,);
            //if (e.Column.Name.ToString() != grdViewOder.Columns["BtnDo"].Name.ToString().Trim()) return;

            //e.DisplayText = "Negative";
            //switch (Math.Sign(Convert.ToInt32(e.CellValue)))
            //{
            //    case -1:
            //        e.DisplayText = "Negative";
            //        break;
            //    case 0:
            //        e.DisplayText = "Zero";
            //        break;
            //    case 1:
            //        e.DisplayText = "Positive";
            //        break;
            //    default:
            //        break;
            //}

            int rowHandle = gridView1.GetDataSourceRowIndex(e.RowHandle);
            DataRow rowDt = gridView1.GetDataRow(rowHandle);
            if (rowDt == null) return;
            string tagId = rowDt["Id"].ToString();
            if (CommentDataDic.ContainsKey(tagId) && e.Column == colContent)
            {
                Point[] triangle = new Point[]{
                    new Point(e.Bounds.Right, e.Bounds.Top),
                    new Point(e.Bounds.Right, e.Bounds.Top + 7),
                    new Point(e.Bounds.Right - 7, e.Bounds.Top),
                };
                e.Graphics.DrawPolygon(new Pen(Color.Green), triangle);
                e.Graphics.FillPolygon(new SolidBrush(Color.Green), triangle);
            }
        }

        #region Drall with cell
        GridViewInfo GetViewInfo(GridView view)
        {
            PropertyInfo pi = view.GetType().GetProperty("ViewInfo", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            return pi.GetValue(view, null) as GridViewInfo;
        }

        int GetRowHeight(GridView view, int rowHandle)
        {
            GridViewInfo viewInfo = GetViewInfo(view);
            return viewInfo.CalcRowHeight(CreateGraphics(), rowHandle, 0);
        }

        int GetInvisibleRowsHeight(GridView view)
        {
            int height = 0;
            for (int i = 0; i < view.RowCount; i++)
            {
                int rowHandle = view.GetVisibleRowHandle(i);
                if (view.IsRowVisible(rowHandle) != RowVisibleState.Visible)
                    height += GetRowHeight(view, rowHandle);
            }
            return height;
        }

        int GetEmptyHeight(GridView view)
        {
            GridViewInfo viewInfo = GetViewInfo(view);
            return viewInfo.ViewRects.EmptyRows.Height;
        }

        void AdjustGridMinHeight(GridControl grid)
        {
            //if((gridControl1.MainView as GridView).RowCount < 5) 
            {
                grid.Height += GetInvisibleRowsHeight(grid.MainView as GridView);
                grid.Height -= GetEmptyHeight(grid.MainView as GridView);
            }
        }

        void AdjustGridSize(GridControl grid)
        {
            AdjustGridMinHeight(grid);
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            GridView view = (sender as GridView);
            if (view != null) AdjustGridSize(view.GridControl);
        }

        #endregion

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            /*GridControl grid = (GridControl)sender;
            Point pt = grid.PointToClient(Control.MousePosition);
            DoRowDoubleClick((GridView)grid.MainView, pt);*/
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            /*GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);*/
        }

        private static void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                //if rightclick on image & pdf don't show context menu editor
                emptyMenu = new ContextMenu();
                if (components != null) this.components.Add(emptyMenu);
                gridView1.ActiveEditor.ContextMenu = emptyMenu;
                if (gridView1.FocusedColumn.FieldName == "Content")
                {
                    //AnhLT - MED-10138
                    HoldCurrentTextEdit();

                    int selectedRowIndex = gridView1.FocusedRowHandle > 0 ? gridView1.FocusedRowHandle : 0;
                    if (gridView1.GetRowCellValue(selectedRowIndex, "Type") != null && !string.IsNullOrEmpty(gridView1.GetRowCellValue(selectedRowIndex, "Type").ToString()))
                    {
                        int a;
                        if (Int32.TryParse(gridView1.GetRowCellValue(selectedRowIndex, "Type").ToString(), out a))
                        {
                            string strType = Enum.GetName(typeof(TypeEnum), a);
                            TypeEnum typeItem = KeyEnum(strType);
                            if (typeItem == TypeEnum.Image || typeItem == TypeEnum.Pdf)
                            {
                                InitializeContextMenu();
                                gridView1.ActiveEditor.ContextMenu = emptyMenu;
                            }
                        }
                    }

                    /*repositoryItemButtonEdit1.LookAndFeel.UseDefaultLookAndFeel = false;
                    repositoryItemButtonEdit1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
                    repositoryItemButtonEdit1.Appearance.Options.UseBackColor = true;
                    repositoryItemButtonEdit1.Appearance.BackColor = Color.LightSkyBlue;
                    repositoryItemButtonEdit1.Appearance.BackColor2 = Color.White;
                    repositoryItemButtonEdit1.Appearance.ForeColor = Color.Khaki;*/

                    //    Point[] triangle = new Point[]{
                    //    new Point(e.Bounds.Right, e.Bounds.Top),
                    //    new Point(e.Bounds.Right, e.Bounds.Top + 7),
                    //    new Point(e.Bounds.Right - 7, e.Bounds.Top),
                    //};
                    //    e.Graphics.DrawPolygon(new Pen(Color.Green), triangle);
                    //    e.Graphics.FillPolygon(new SolidBrush(Color.Green), triangle);
                }

                //GridView view = (GridView)sender;
                //Point pt = view.GridControl.PointToClient(Control.MousePosition);
                //DoRowDoubleClick(view, pt);

                //GridView view = sender as GridView;
                //if (view == null) return;
                //if (view.FocusedColumn.FieldName == "Content")
                //{
                //    //Todo
                //}
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception of gridView1_ShownEditor() method: " + ex.StackTrace);
            }
        }

        private void HoldCurrentTextEdit()
        {
            _textEdit = null;
            _currentSelectedText = "";
            _textEdit = gridView1.ActiveEditor as TextEdit;
            if (_textEdit != null) _currentSelectedText = _textEdit.SelectedText;
        }

        private void repositoryItemPictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = grdContent.FocusedView as GridView;
                if (view == null) return;
                DataRowView selRow = (DataRowView)(grdContent.MainView.GetRow(view.FocusedRowHandle));
                Bitmap contentBm = (Bitmap)selRow["Content"];
                TypeEnum typeEnum = (TypeEnum)selRow["Type"];

                using (Bitmap bitmap = new Bitmap(contentBm))
                {
                    ImageFormat imageFormat = bitmap.RawFormat;
                    if (typeEnum == TypeEnum.Pdf)
                    {
                        string linkLocation = selRow["DirLocation"].ToString().Trim();
                        string filePathLocal = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(linkLocation) ? linkLocation.Trim() : "", UserInfo.HospCode, _patientModel.PatientId);
                        if (!File.Exists(filePathLocal)) Utilities.DownloadFile(filePathLocal, UserInfo.HospCode, _patientModel.PatientId);

                        Process.Start(filePathLocal);
                    }
                    else
                    {
                        string filePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(this._patientModel.PatientId, "tem", "jpg"), this._patientModel.PatientId).Trim();
                        FileInfo fileInfo = new FileInfo(filePath);
                        contentBm.Save(filePath, ImageFormat.Jpeg);
                        if (!gridView1.OptionsBehavior.ReadOnly)
                            EditImage(filePath, TypeEnum.Image, filePath, ActionType.Update, true);
                        else
                            Process.Start(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error on event: repositoryItemPictureEdit1_DoubleClick" + ex.StackTrace);
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != grdContent) return;

            ToolTipControlInfo info = null;
            //Get the view at the current mouse position
            GridView view = grdContent.GetViewAt(e.ControlMousePosition) as GridView;
            if (view == null) return;
            //Get the view's element information that resides at the current position
            GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
            int rowHandle = hi.RowHandle;
            DataRow rowDt = gridView1.GetDataRow(rowHandle);
            if (rowDt == null) return;
            string tagId = rowDt["Id"].ToString();
            if (CommentDataDic.ContainsKey(tagId) && hi.Column == colContent)
            {
                CommentData commentDataObj = CommentDataDic[tagId];
                if (commentDataObj == null) return;
                //info = new ToolTipControlInfo(hi.RowHandle, commentInfoObj.Comment, commentInfoObj.Title);
                info = new ToolTipControlInfo(hi.RowHandle, GetBookMarkTooltip(tagId), string.Empty);

            }

            /*//Display a hint for row indicator cells
            if (hi.HitTest == GridHitTest.RowCell)
            {
                //An object that uniquely identifies a row indicator cell
                object o = hi.HitTest.ToString() + hi.RowHandle.ToString();
                string text = "Row " + hi.RowHandle.ToString();
                info = new ToolTipControlInfo(o, text);
            }*/

            //Supply tooltip information
            if (info != null)
                e.Info = info;
        }

        private string GetBookMarkTooltip(string tagId)
        {
            string contentRet = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(tagId))
                    return string.Empty;
                if (CommentDataDic.ContainsKey(tagId))
                {
                    if (CommentDataDic[tagId].CommentList.Count > 0)
                        foreach (CommentInfo item in CommentDataDic[tagId].CommentList)
                        {
                            contentRet += Resources.EMR_BOOKMARK_TITLE + ": " + item.Title + "\n" + Resources.EMR_BOOKMARK_CONTENT + ": " + item.Comment + "\n";
                        }
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
                MessageBox.Show(ex.StackTrace);
            }
            return contentRet;
        }

        private void gridView1_RowCellDefaultAlignment(object sender, RowCellAlignmentEventArgs e)
        {
            /*if (e.Column.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
            {
                string strType = gridView1.GetRowCellValue(e.RowHandle, "TagCode").ToString();
                if (DataProvider.Instance.TagDetailCodeName.ContainsKey(strType))
                {
                    e.HorzAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
                else
                {
                    e.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
            }*/
        }
        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null && e.RowHandle >= 0)
            {
                string type = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Type"]);
                if (type == "4")
                {
                    /*e.Appearance.BackColor = Color.SkyBlue;
                    e.Appearance.BackColor2 = Color.White;*/
                    //e.Appearance.BackColor = Color.Transparent;

                    e.Appearance.BackColor = ColorTranslator.FromHtml("#D2E4FC");
                }
            }
        }

        private void grdContent_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //Func Delete only use on UcEditor and U44
                if (_screen != ScreenEnum.UcEditor && _screen != ScreenEnum.U44) return;
                //Update commentDataDic
                DataTable dt = grdContent.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0) return;
                int selectedRowIndex = gridView1.FocusedRowHandle > 0 ? gridView1.FocusedRowHandle : 0;
                string tagId = gridView1.GetRowCellValue(selectedRowIndex, "Id").ToString();
                DeleteCommentListByTagId(tagId);

                DataRow currentRow = dt.Rows[selectedRowIndex];

                if (gridView1.FocusedColumn.FieldName == colContent.FieldName && currentRow["Type"].ToString().Equals("0")) return; //can't delete row with focusing colmn content
                if (!currentRow["Type"].ToString().Equals("3") && !currentRow["Type"].ToString().Equals("4") || gridView1.FocusedColumn.FieldName == "TagCode")
                {
                    gridView1.DeleteSelectedRows();
                    return;
                }
                //if (gridView1.FocusedColumn.FieldName == "TagCode")
                //{
                //    gridView1.DeleteSelectedRows();
                //    return;
                //}

                if (gridView1.FocusedColumn.FieldName == "Content")
                {
                    //int selectedRowIndex = gridView1.FocusedRowHandle > 0 ? gridView1.FocusedRowHandle : 0;
                    if (gridView1.GetRowCellValue(selectedRowIndex, "Type") != null && !string.IsNullOrEmpty(gridView1.GetRowCellValue(selectedRowIndex, "Type").ToString()))
                    {
                        int a;
                        if (Int32.TryParse(gridView1.GetRowCellValue(selectedRowIndex, "Type").ToString(), out a))
                        {
                            string strType = Enum.GetName(typeof(TypeEnum), a);
                            TypeEnum typeItem = KeyEnum(strType);
                            if (typeItem == TypeEnum.Image || typeItem == TypeEnum.Pdf)
                            {
                                gridView1.DeleteSelectedRows();
                                return;
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (gridView1.FocusedColumn.FieldName == colContent.FieldName)
                {
                    //Re-Draw current row handle
                    /*int height = 0;

                    GridViewInfo vi = gridView1.GetViewInfo() as GridViewInfo;
                    if (vi != null)
                    {
                        GridRowInfo ri = vi.RowsInfo.FindRow(gridView1.FocusedRowHandle);
                        if (ri != null)
                            height = ri.Bounds.Height;
                    }

                    int rowHandle = gridView1.FocusedRowHandle;
                    isReCalRowHeight = true;
                    gridView1_CalcRowHeight(new object(), new RowHeightEventArgs(rowHandle, height));*/

                    gridView1.ShowEditor();
                    e.Handled = true;
                    TextEdit editor = gridView1.ActiveEditor as TextEdit;
                    if (editor != null)
                    {
                        /*editor.SelectionStart = editor.Text.Length;*/
                        editor.SelectionStart += 0;
                        editor.SelectionLength = 0;
                        /*editor.SelectedText = Environment.NewLine;*/
                        int lenght = 24;
                        if (editor.Height < 68) editor.Height = (lenght * DefaultRowHeight);
                    }

                    /*emoEdit memo = sender as MemoEdit;
                    if (memo != null)
                    {
                        Graphics gr = memo.CreateGraphics();
                        int lenght = memo.Lines.Length;
                        if (memo.Height < 68) memo.Height = (lenght*DefaultRowHeight);
                    }*/

                }
            }
        }

        private void repositoryItemMemoEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            MemoEdit memo = sender as MemoEdit;
            if (memo != null)
            {
                Graphics gr = memo.CreateGraphics();
                string strNewValue = e.NewValue.ToString();
                int lenght = memo.Lines.Length;
                if (lenght < 1) lenght = 1;
                if (memo.Height < 68) memo.Height = (lenght * DefaultRowHeight);

                /*int selectionStart = memo.SelectionStart;
                int selectionLength = memo.SelectionLength;

                gridView1.PostEditor();
                gridView1.ShowEditor();
                /*gridView1.UpdateCurrentRow();#1#

                memo.SelectionStart = selectionStart;
                memo.SelectionLength = selectionLength;*/

            }

            /*MemoEdit memo = sender as MemoEdit;
            Graphics gr = memo.CreateGraphics();
            MemoEditViewInfo info = memo.GetViewInfo() as MemoEditViewInfo;
            // change height
            gridView1.Rows
            gridView1.RowHeight = 50;
            memo.Height = Convert.ToInt32(string_height) + 2;
            //
            gr.Dispose();*/

        }

        private void gridView2_ShowingEditor(object sender, CancelEventArgs e)
        {
            /*GridView view = (GridView)sender;

            if (view.FocusedColumn.FieldName == colBtnDo.FieldName)
            {
                string rowValue = view.GetRowCellValue(e., colActionDoYn).ToString();
                /*repositoryItemButtonEdit1.Buttons[0].Caption = rowValue == "N" ? "Not DO" : "Do";#1#

                ButtonEdit ed = (ButtonEdit)view.ActiveEditor;

                ed.Properties.Buttons[0].Caption = "Do21212";

            }*/

            GridView view = (GridView)sender;

            if (view.FocusedColumn.FieldName == colBtnDo.FieldName)
            {

                ButtonEdit ed = (ButtonEdit)view.ActiveEditor;

                int selectedRowIndex = gridView2.FocusedRowHandle > 0 ? gridView1.FocusedRowHandle : 0;
                string a = gridView2.GetRowCellValue(selectedRowIndex, colActionDoYn.FieldName).ToString();
                if (a == LBLN)
                {
                    ed.Properties.Buttons[0].Caption = "Not Do";
                }
                else
                {
                    ed.Properties.Buttons[0].Caption = "Do";
                }

                BaseView baseView = sender as DevExpress.XtraGrid.Views.Base.BaseView;
                if (baseView != null)
                {
                    DevExpress.XtraEditors.BaseEdit edit = baseView.ActiveEditor;
                    if (edit is DevExpress.XtraEditors.ButtonEdit && a == LBLN)
                    {
                        ButtonEdit buttonEdit = edit as DevExpress.XtraEditors.ButtonEdit;
                        buttonEdit.Properties.Buttons[0].Enabled = false;
                    }
                }
            }
        }

        private void gridView2_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colBtnDo)
            {
                GridView grdOrder = (GridView)sender;
                if (grdOrder != null)
                {
                    string rowValue = grdOrder.GetRowCellValue(e.RowHandle, colActionDoYn).ToString();
                    e.DisplayText = rowValue == "N" ? "Not DO" : "Do";
                }
            }
        }

        public class MyRepositoryItemButtonEdit : RepositoryItemButtonEdit
        {
            public override DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo CreateViewInfo()
            {
                return new MyRepositoryItemButtonEditViewInfo(this);
            }
        }
        public class MyRepositoryItemButtonEditViewInfo : ButtonEditViewInfo
        {
            public MyRepositoryItemButtonEditViewInfo(RepositoryItem item) : base(item) { }

            protected override DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs CreateButtonInfo(EditorButton button, int index)
            {
                return base.CreateButtonInfo(new MyEditorButton(), index);
            }
        }

        public class MyEditorButton : EditorButton
        {
            public MyEditorButton() : this(string.Empty) { }
            public MyEditorButton(string myCaption)
            {
                this.myCaption = myCaption;
                Kind = ButtonPredefines.Glyph;
            }
            string myCaption = "";
            public override string Caption
            {
                get
                {
                    return myCaption;
                }
                set
                {
                    myCaption = value;
                }
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (_screen == ScreenEnum.U44)
            {
                GridView view = sender as GridView;
                if (view != null && (/*view.FocusedColumn.FieldName == "Region" && */!IsEditRowCellHandle(view, view.FocusedRowHandle)))
                    e.Cancel = true;
            }
        }

        private void gridViewMd_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (_screen == ScreenEnum.U44)
            {
                GridView view = sender as GridView;
                if (view != null && (view.FocusedColumn.FieldName != colBtnDo.FieldName) && (view.FocusedColumn.FieldName != colOrderDisplayOrder.FieldName))
                    e.Cancel = true;
            }
        }


        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OnBrower(sender, e);
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                DataRowView selRow = (DataRowView)(grdContent.MainView.GetRow(gridView1.FocusedRowHandle));
                TypeEnum typeEnum = (TypeEnum)selRow["Type"];
                if ((typeEnum == TypeEnum.Image || typeEnum == TypeEnum.Pdf) && gridView1.FocusedColumn.FieldName == colContent.FieldName)
                {
                    contextMenuStrip.Show(MousePosition);
                }
            }
            catch (Exception)
            {

            }
        }

        private void repositoryItemMemoEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value != null)
                e.Value = Regex.Replace(e.Value.ToString(), "(?<!\r)\n", "\r\n");
        }
        

        #endregion

        #region Method
        #region Get DateTime From Server

        //MED-10925
        public void SetCacheDateTimeFromServer()
        {
            try
            {
                string cacheKeys = string.Format(CACHE_FIRST_DATE_TIME, NetInfo.Language);
                _dateCacheFromServer = CacheService.Instance.Get<string>(cacheKeys);
                if (string.IsNullOrEmpty(_dateCacheFromServer))
                {
                    _dtFromServer = EnvironInfo.GetSysDateTime();
                    DateTime timeServer = _dtFromServer;
                    DateTime maxDateTimeFromSv = timeServer.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                    TimeSpan duration = maxDateTimeFromSv - timeServer;

                    CacheService.Instance.Set(cacheKeys, _dtFromServer.ToShortDateString(), duration);
                    _dateCacheFromServer = CacheService.Instance.Get<string>(cacheKeys);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception on SetCacheDateTimeFromServer() " + ex.StackTrace);
            }
        }

        #endregion

        #region IsEdited
        public bool IsEdited()
        {
            try
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    DataRow row1 = gridView1.GetDataRow(i);
                    if (!String.IsNullOrEmpty(row1["Content"].ToString()))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.StackTrace);
                return false;
            }
        }
        #endregion

        #region Load LoadGridCombobox
        public void LoadGridCombobox()
        {
            RepositoryItemLookUpEdit popEdit = new RepositoryItemLookUpEdit();
            //popEdit.DataSource = DataCreator.CboTagData();
            DataTable dt = new DataTable("GridEditorData");
            dt.Columns.Add("TagCode", typeof(string));
            dt.Columns.Add("TagName", typeof(string));
            foreach (string tag in DataProvider.Instance.DicTemplateTagItems.Keys)
            {
                string byTagCode = tag.Trim();
                if (DataProvider.Instance.TagDetailCodeName.ContainsKey(tag))
                {
                    byTagCode = "  " + tag;
                    //byTagCode = tag;
                }
                dt.Rows.Add(byTagCode, DataProvider.Instance.DicTemplateTagItems[tag]);
                //dt.Rows.Add(tag.ToString(CultureInfo.InvariantCulture), DataProvider.Instance.DicTemplateTagItems[tag]);
            }


            popEdit.DataSource = dt;
            popEdit.DisplayMember = "TagCode";
            //popEdit.ValueMember = "TagName";            
            popEdit.ValueMember = "TagCode";
            //popEdit.SearchMode = SearchMode.AutoComplete;
            popEdit.AutoSearchColumnIndex = 2;
            gridView1.Columns["TagCode"].ColumnEdit = popEdit;
        }
        public void LoadGridCombobox(string hospCode)
        {
            RepositoryItemLookUpEdit popEdit = new RepositoryItemLookUpEdit();
            //popEdit.DataSource = DataCreator.CboTagData();
            DataTable dt = new DataTable("GridEditorData");
            dt.Columns.Add("TagCode", typeof(string));
            dt.Columns.Add("TagName", typeof(string));
            foreach (string tag in DataProvider.Instance.DicTemplateTagClinicReferItems.Keys)
            {
                string byTagCode = tag.Trim();
                if (DataProvider.Instance.TagDetailCodeNameClinicRefer.ContainsKey(tag))
                {
                    byTagCode = "  " + tag;
                    //byTagCode = tag;
                }
                dt.Rows.Add(byTagCode, DataProvider.Instance.DicTemplateTagClinicReferItems[tag]);
                //dt.Rows.Add(tag.ToString(CultureInfo.InvariantCulture), DataProvider.Instance.DicTemplateTagItems[tag]);
            }


            popEdit.DataSource = dt;
            popEdit.DisplayMember = "TagCode";
            //popEdit.ValueMember = "TagName";            
            popEdit.ValueMember = "TagCode";
            //popEdit.SearchMode = SearchMode.AutoComplete;
            popEdit.AutoSearchColumnIndex = 2;
            gridView1.Columns["TagCode"].ColumnEdit = popEdit;
        }

        #endregion

        private void LoadListCheckBoxEdit()
        {
            string[] itemValues = new string[] { 
                        //"Circle", "Rectangle", "Ellipse", 
                        "Doctor", "Other clinic doctors", "Related companies", 
                        "Patient" };
            repositoryItemCheckedComboBoxEdit1.Items.Clear();
            repositoryItemCheckedComboBoxEdit2.Items.Clear();
            foreach (string value in itemValues)
            {
                repositoryItemCheckedComboBoxEdit1.Items.Add(value, CheckState.Unchecked, true);
                repositoryItemCheckedComboBoxEdit2.Items.Add(value, CheckState.Unchecked, true);
            }
        }

        #region LoadGrid
        /*public void LoadGrid(string strMmlParam, PatientModelInfo pModel, string pkout, string strLstCommentInfos, bool isShowHeader, bool isUcEditor, string hospCodeRefer, ScreenEnum screeEnum)
        {
            _screen = screeEnum;
            this.oldMmlContent = strMmlParam;
            if (string.IsNullOrEmpty(hospCodeRefer))
            {
                LoadGridCombobox();
            }
            else
            {
                LoadGridCombobox(hospCodeRefer);
            }
            InitCommentDataDic(strLstCommentInfos);
            _pkout = pkout;
            _patientModel = pModel;
            _existingRecords = new List<EmrRecordInfo>();
            _gwa = _patientModel.Gwa;
            //parse from strMML  to list
            if (!string.IsNullOrEmpty(strMmlParam) && _patientModel != null)
            {
                Tuple<List<EmrRecordInfo>, PatientModelInfo> lstInfo = MmlParser.Instance.ToModel(strMmlParam);
                _existingRecords = lstInfo.V1;
            }

            DataTable dtTag = new DataTable();

            DataColumn dcmpk = dtTag.Columns.Add("OrderMaster", typeof(int));
            dtTag.Columns.Add("Id", typeof(string));
            dtTag.Columns.Add("TagCode", typeof(string));
            dtTag.Columns.Add("TagName", typeof(string));
            dtTag.Columns.Add("Content", typeof(object));
            dtTag.Columns.Add("Type", typeof(TypeEnum)); //(TypeEnum: string, Image, pdf)
            dtTag.Columns.Add("CreateDate", typeof(string));
            dtTag.Columns.Add("DirLocation", typeof(string));
            dtTag.Columns.Add("PkOut", typeof(string));
            dtTag.Columns.Add("HospCode", typeof(string));
            dtTag.Columns.Add("Gwa", typeof(string));
            dtTag.Columns.Add("DateTime", typeof(string));
            dtTag.Columns.Add("Doctor", typeof(string));
            dtTag.PrimaryKey = new DataColumn[] { dcmpk };

            DataTable dtOrder = new DataTable();
            dtOrder.Columns.Add("BtnDo", typeof(object));
            dtOrder.Columns.Add("InputGubunName", typeof(string));
            dtOrder.Columns.Add("OrderGubunName", typeof(string));
            dtOrder.Columns.Add("HangmogName", typeof(string));
            dtOrder.Columns.Add("Content", typeof(string));
            dtOrder.Columns.Add("OrderCurrent", typeof(int));
            DataColumn dcdfk = dtOrder.Columns.Add("ParrentTagCurrent", typeof(int));
            dtOrder.Columns.Add("GubunBass", typeof(string));
            dtOrder.Columns.Add("HangmogCode", typeof(string));
            dtOrder.Columns.Add("ActionDoYn", typeof(string));
            dtOrder.Columns.Add("Bunho", typeof(string));
            dtOrder.Columns.Add("Doctor", typeof(string));
            dtOrder.Columns.Add("Gwa", typeof(string));
            dtOrder.Columns.Add("NaewonDate", typeof(string));
            dtOrder.Columns.Add("NaewonKey", typeof(string));
            dtOrder.Columns.Add("InputTab", typeof(string));
            dtOrder.Columns.Add("InputTabAndGroupSer", typeof(string));

            foreach (EmrRecordInfo emrRecordInfo in _existingRecords)
            {
                //Add header
                if (isShowHeader)
                    dtTag.Rows.Add(++masterId, Guid.NewGuid(), "", emrRecordInfo.Doctor, emrRecordInfo.DateTime, TypeEnum.Header, emrRecordInfo.DateTime, "", emrRecordInfo.PkOut, emrRecordInfo.HospCode, emrRecordInfo.Facility, emrRecordInfo.DateTime, emrRecordInfo.Doctor);

                if (isUcEditor && emrRecordInfo.PkOut != pkout) continue;

                foreach (TagInfo tagInfo in emrRecordInfo.TagInfos)
                {
                    //todo: download file imge
                    if (tagInfo == null) continue;

                    if (string.IsNullOrEmpty(tagInfo.Id))
                    {
                        tagInfo.Id = Guid.NewGuid().ToString();
                    }

                    if (!string.IsNullOrEmpty(tagInfo.TagCode))
                    {
                        //get TagName from TagCode
                        OCS2015U06Businesses.TagInfo dicA;
                        if (string.IsNullOrEmpty(hospCodeRefer))
                        {
                            dicA = DataProvider.Instance.TagDetail.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetail[tagInfo.TagCode.Trim()] : null;
                        }
                        else
                        {
                            dicA = DataProvider.Instance.TagDetailClinicRefer.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetailClinicRefer[tagInfo.TagCode.Trim()] : null;
                        }
                        if (dicA != null)
                        {
                            tagInfo.TagName = dicA.TagDisplay;
                        }
                        else
                        {
                            string strCodeName;
                            if (string.IsNullOrEmpty(hospCodeRefer))
                            {
                                strCodeName = DataProvider.Instance.TagDetailCodeName.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetailCodeName[tagInfo.TagCode.Trim()] : "";
                            }
                            else
                            {
                                strCodeName = DataProvider.Instance.TagDetailCodeNameClinicRefer.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetailCodeNameClinicRefer[tagInfo.TagCode.Trim()] : "";
                            }
                            //tagInfo.TagCode = tagInfo.TagCode;
                            tagInfo.TagCode = "  " + tagInfo.TagCode.Trim();
                            tagInfo.TagName = !string.IsNullOrEmpty(strCodeName) ? strCodeName : "";
                        }
                    }

                    if (tagInfo.Content == null)
                    {
                        string hospCode = UserInfo.HospCode;
                        if (!string.IsNullOrEmpty(hospCodeRefer))
                        {
                            hospCode = hospCodeRefer;
                        }

                        if (tagInfo.Type == TypeEnum.Image)
                        {
                            //get content
                            string filePathLocal = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Trim() : "", UserInfo.HospCode, pModel.PatientId);
                            if (!File.Exists(filePathLocal))
                            {
                                Utilities.DownloadFile(filePathLocal, hospCode, pModel.PatientId);
                            }
                            tagInfo.Content = Image.FromFile(!string.IsNullOrEmpty(filePathLocal) ? filePathLocal : "");

                            if (!string.IsNullOrEmpty(filePathLocal))
                            {
                                MediaDictionaryAdd(Utilities.CalculateFileChecksum(filePathLocal), filePathLocal);
                            }
                        }
                        else
                        {
                            string filePathLocalPdf = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Trim() : "", UserInfo.HospCode, pModel.PatientId);
                            if (!File.Exists(filePathLocalPdf)) Utilities.DownloadFile(filePathLocalPdf, hospCode, pModel.PatientId);

                            string thumbnailFilePath = !string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Replace(".pdf", ".jpeg") : "";
                            string filePathLocal = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(thumbnailFilePath) ? thumbnailFilePath.Trim() : "", UserInfo.HospCode, pModel.PatientId);
                            if (!File.Exists(filePathLocal)) Utilities.DownloadFile(filePathLocal, hospCode, pModel.PatientId);

                            tagInfo.Content = Image.FromFile(filePathLocal);

                            if (!string.IsNullOrEmpty(filePathLocalPdf))
                            {
                                MediaDictionaryAdd(Utilities.CalculateFileChecksum(filePathLocalPdf), filePathLocalPdf);
                            }
                            if (!string.IsNullOrEmpty(filePathLocal))
                            {
                                MediaDictionaryAdd(Utilities.CalculateFileChecksum(filePathLocal), filePathLocal);
                            }
                        }
                    }

                    //bind to row
                    dtTag.Rows.Add(++masterId, tagInfo.Id, tagInfo.Type == TypeEnum.Tag ? tagInfo.TagCode : string.Empty, tagInfo.TagName, tagInfo.Content, tagInfo.Type, tagInfo.CreateDate, tagInfo.DirLocation, emrRecordInfo.PkOut, emrRecordInfo.HospCode, emrRecordInfo.Facility, emrRecordInfo.DateTime, emrRecordInfo.Doctor);
                }

                if (_screen != ScreenEnum.UcEditor)
                {
                    dtTag.Rows.Add(++masterId, Guid.NewGuid().ToString(), "Orders", "", "", TypeEnum.Order, _dateCacheFromServer, "", emrRecordInfo.PkOut, emrRecordInfo.HospCode, emrRecordInfo.Facility, emrRecordInfo.DateTime, emrRecordInfo.Doctor);

                    if (emrRecordInfo.OrderInfos != null && emrRecordInfo.OrderInfos.Count > 0 && !isUcEditor)
                    {
                        foreach (OrderInfo orderInfo in emrRecordInfo.OrderInfos)
                        {
                            //dtOrder.Rows.Add(orderInfo.ActionDoYn.Equals("Y") ? "Do..." : null, orderInfo.ActionDoYn.Equals("Y") ? orderInfo.InputGubunName : null, orderInfo.ActionDoYn.Equals("Y") ? orderInfo.OrderGubunName : null, orderInfo.HangmogName, orderInfo.Content, ++detailId, masterId, orderInfo.GubunBass, orderInfo.HangmogCode, orderInfo.ActionDoYn, orderInfo.Bunho, orderInfo.Doctor, orderInfo.Gwa, orderInfo.NaewonDate, orderInfo.NaewonKey, orderInfo.InputTab);

                            // 2015.09.25 AnhNV modified
                            dtOrder.Rows.Add(
                                orderInfo.ActionDoYn == LBLN ? "" : "Do..." + orderInfo.InputTab,
                                orderInfo.InputGubunName,
                                orderInfo.OrderGubunName,
                                orderInfo.HangmogName,
                                orderInfo.Content,
                                ++detailId,
                                masterId,
                                orderInfo.GubunBass,
                                orderInfo.HangmogCode,
                                orderInfo.ActionDoYn,
                                orderInfo.Bunho,
                                orderInfo.Doctor,
                                orderInfo.Gwa,
                                orderInfo.NaewonDate,
                                orderInfo.NaewonKey,
                                orderInfo.InputTab,
                                orderInfo.InputTabAndGroupSer);
                        }
                    }
                    else
                    {
                        //dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00001", "Contrent test 001", orderType);
                    }
                }
                //DataSet ds = new DataSet();
                //ds.Tables.AddRange(new DataTable[] { dtTag, dtOrder });
                //ds.Relations.Add("CustomerOrders", dcmpk, dcdfk);
            }
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { dtTag, dtOrder });
            ds.Relations.Add("CustomerOrders", dcmpk, dcdfk);

            strMml = strMmlParam;
            grdContent.DataSource = dtTag;
            currentDataSource = dtTag;
            currentDataOrder = dtOrder;
            gridView1.BorderStyle = BorderStyles.NoBorder;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsView.ShowHorzLines = false;
            gridView1.OptionsView.ShowVertLines = false;
            gridView1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gridView1.OptionsView.ShowFooter = false;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.FocusedRowHandle = 1;
            grdContent.RefreshDataSource();
            InitAppearance();

            //store column index
            orderList.Clear();
            for (int i = 0; i < gridView1.Columns.Count; i++)
                orderList.Add(gridView1.Columns[i].VisibleIndex);

        }*/
        //MED-13135
        public void LoadGrid(string strMmlParam, PatientModelInfo pModel, string pkout, string strLstCommentInfos, bool isShowHeader, bool isUcEditor, string hospCodeRefer, ScreenEnum screeEnum)
        {
            lock (this.grdContent)
            {
                _screen = screeEnum;
                this.oldMmlContent = strMmlParam;
                if (string.IsNullOrEmpty(hospCodeRefer))
                {
                    LoadGridCombobox();
                }
                else
                {
                    LoadGridCombobox(hospCodeRefer);
                }
                InitCommentDataDic(strLstCommentInfos);
                _pkout = pkout;
                _patientModel = pModel;
                _existingRecords = new List<EmrRecordInfo>();
                _gwa = _patientModel.Gwa;
                //parse from strMML  to list
                if (!string.IsNullOrEmpty(strMmlParam) && _patientModel != null)
                {
                    EmrDocker.Types.Tuple<List<EmrRecordInfo>, PatientModelInfo> lstInfo = MmlParser.Instance.ToModel(strMmlParam);
                    _existingRecords = lstInfo.V1;
                }

                DataTable dtTag = new DataTable();

                DataColumn dcmpk = dtTag.Columns.Add("OrderMaster", typeof(int));
                dtTag.Columns.Add("Id", typeof(string));
                dtTag.Columns.Add("TagCode", typeof(string));
                dtTag.Columns.Add("TagName", typeof(string));
                dtTag.Columns.Add("Content", typeof(object));
                dtTag.Columns.Add("Type", typeof(TypeEnum)); //(TypeEnum: string, Image, pdf)
                dtTag.Columns.Add("CreateDate", typeof(string));
                dtTag.Columns.Add("DirLocation", typeof(string));
                dtTag.Columns.Add("PkOut", typeof(string));
                dtTag.Columns.Add("HospCode", typeof(string));
                dtTag.Columns.Add("Gwa", typeof(string));
                dtTag.Columns.Add("DateTime", typeof(string));
                dtTag.Columns.Add("Doctor", typeof(string));
                dtTag.Columns.Add("DisplayOrther", typeof(string));
                dtTag.PrimaryKey = new DataColumn[] { dcmpk };

                DataTable dtOrder = new DataTable();
                dtOrder.Columns.Add("BtnDo", typeof(object));
                dtOrder.Columns.Add("InputGubunName", typeof(string));
                dtOrder.Columns.Add("OrderGubunName", typeof(string));
                dtOrder.Columns.Add("HangmogName", typeof(string));
                dtOrder.Columns.Add("Content", typeof(string));
                dtOrder.Columns.Add("OrderCurrent", typeof(int));
                DataColumn dcdfk = dtOrder.Columns.Add("ParrentTagCurrent", typeof(int));
                dtOrder.Columns.Add("GubunBass", typeof(string));
                dtOrder.Columns.Add("HangmogCode", typeof(string));
                dtOrder.Columns.Add("ActionDoYn", typeof(string));
                dtOrder.Columns.Add("Bunho", typeof(string));
                dtOrder.Columns.Add("Doctor", typeof(string));
                dtOrder.Columns.Add("Gwa", typeof(string));
                dtOrder.Columns.Add("NaewonDate", typeof(string));
                dtOrder.Columns.Add("NaewonKey", typeof(string));
                dtOrder.Columns.Add("InputTab", typeof(string));
                dtOrder.Columns.Add("InputTabAndGroupSer", typeof(string));
                dtOrder.Columns.Add("OrderDisplayOrder", typeof(string));
                if (_existingRecords.Count > 0)
                {
                    _existingRecords.Sort(
                        delegate(EmrRecordInfo p1, EmrRecordInfo p2)
                        {
                            return DateTime.Parse(p2.DateTime).CompareTo(DateTime.Parse(p1.DateTime));
                        }
                    );
                }
                foreach (EmrRecordInfo emrRecordInfo in _existingRecords)
                {
                    //Add header
                    if (isShowHeader)
                        dtTag.Rows.Add(++masterId, Guid.NewGuid(), "", emrRecordInfo.Doctor, emrRecordInfo.DateTime, TypeEnum.Header, emrRecordInfo.DateTime, "", emrRecordInfo.PkOut, emrRecordInfo.HospCode, emrRecordInfo.Facility, emrRecordInfo.DateTime, emrRecordInfo.Doctor, "");

                    if (isUcEditor && emrRecordInfo.PkOut != pkout) continue;

                    int rowNumber = isShowHeader ? 1 : 0;
                    foreach (TagInfo tagInfo in emrRecordInfo.TagInfos)
                    {
                        //todo: download file imge
                        if (tagInfo == null)
                        {
                            rowNumber++;
                            continue;
                        }

                        if (IsHideTagOrderInHospRefer(hospCodeRefer, tagInfo.Permission)) continue;

                        if (string.IsNullOrEmpty(tagInfo.Id))
                        {
                            tagInfo.Id = Guid.NewGuid().ToString();
                        }

                        if (!string.IsNullOrEmpty(tagInfo.TagCode))
                        {
                            //get TagName from TagCode
                            //OCS2015U06Businesses.TagInfo dicA;
                            //if (string.IsNullOrEmpty(hospCodeRefer))
                            //{
                            //    dicA = DataProvider.Instance.TagDetail.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetail[tagInfo.TagCode.Trim()] : null;
                            //}
                            //else
                            //{
                            //    dicA = DataProvider.Instance.TagDetailClinicRefer.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetailClinicRefer[tagInfo.TagCode.Trim()] : null;
                            //}
                            //if (dicA != null)
                            //{
                            //    tagInfo.TagName = dicA.TagDisplay;
                            //}
                            //else
                            //{
                            //    string strCodeName;
                            //    if (string.IsNullOrEmpty(hospCodeRefer))
                            //    {
                            //        strCodeName = DataProvider.Instance.TagDetailCodeName.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetailCodeName[tagInfo.TagCode.Trim()] : "";
                            //    }
                            //    else
                            //    {
                            //        strCodeName = DataProvider.Instance.TagDetailCodeNameClinicRefer.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetailCodeNameClinicRefer[tagInfo.TagCode.Trim()] : "";
                            //    }
                            //    //tagInfo.TagCode = tagInfo.TagCode;
                            //    tagInfo.TagCode = "  " + tagInfo.TagCode.Trim();
                            //    tagInfo.TagName = !string.IsNullOrEmpty(strCodeName) ? strCodeName : "";
                            //}

                            string strCodeName;
                            if (string.IsNullOrEmpty(hospCodeRefer))
                            {
                                strCodeName = DataProvider.Instance.TagDetailCodeName.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetailCodeName[tagInfo.TagCode.Trim()] : "";
                            }
                            else
                            {
                                strCodeName = DataProvider.Instance.TagDetailCodeNameClinicRefer.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetailCodeNameClinicRefer[tagInfo.TagCode.Trim()] : "";
                            }
                            //tagInfo.TagCode = tagInfo.TagCode;
                            tagInfo.TagCode = "  " + tagInfo.TagCode.Trim();
                            tagInfo.TagName = !string.IsNullOrEmpty(strCodeName) ? strCodeName : "";

                            if (string.IsNullOrEmpty(strCodeName))
                            {
                                OCS2015U06Businesses.TagInfo dicA;
                                if (string.IsNullOrEmpty(hospCodeRefer))
                                {
                                    dicA = DataProvider.Instance.TagDetail.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetail[tagInfo.TagCode.Trim()] : null;
                                }
                                else
                                {
                                    dicA = DataProvider.Instance.TagDetailClinicRefer.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetailClinicRefer[tagInfo.TagCode.Trim()] : null;
                                }
                                if (dicA != null)
                                {
                                    tagInfo.TagCode = dicA.TagCode;
                                    tagInfo.TagName = dicA.TagDisplay;
                                }
                            }
                        }

                        if (tagInfo.Content == null)
                        {
                            string hospCode = UserInfo.HospCode;
                            if (!string.IsNullOrEmpty(hospCodeRefer))
                            {
                                hospCode = hospCodeRefer;
                            }

                            if (tagInfo.Type == TypeEnum.Image)
                            {
                                //get content
                                //get content
                                string filePathLocal = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Trim() : "", UserInfo.HospCode, pModel.PatientId);
                                if (!File.Exists(filePathLocal))
                                {
                                    /*BackgroundWorkerDownload(filePathLocal, hospCode, pModel.PatientId, rowNumber.ToString());*/
                                    Utilities.DownloadFile(filePathLocal, hospCode, pModel.PatientId);
                                    tagInfo.Content = File.Exists(filePathLocal) ? Image.FromFile(filePathLocal) : null;
                                }
                                else
                                {
                                    if (File.Exists(filePathLocal) && File.ReadAllBytes(filePathLocal).Length > 0)
                                    {
                                        tagInfo.Content = Image.FromFile(!string.IsNullOrEmpty(filePathLocal) ? filePathLocal : "");
                                    }
                                }

                                if (!string.IsNullOrEmpty(filePathLocal) && File.Exists(filePathLocal))
                                {
                                    MediaDictionaryAdd(Utilities.CalculateFileChecksum(filePathLocal), filePathLocal);
                                }
                            }
                            else
                            {
                                string filePathLocalPdf = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Trim() : "", UserInfo.HospCode, pModel.PatientId);
                                if (!File.Exists(filePathLocalPdf))
                                {
                                    /*BackgroundWorkerDownload(filePathLocalPdf, hospCode, pModel.PatientId, rowNumber.ToString());*/
                                    Utilities.DownloadFile(filePathLocalPdf, hospCode, pModel.PatientId);
                                }
                                //MED-10635
                                else
                                {
                                    if (!string.IsNullOrEmpty(filePathLocalPdf) && File.Exists(filePathLocalPdf))
                                    {
                                        MediaDictionaryAdd(Utilities.CalculateFileChecksum(filePathLocalPdf), filePathLocalPdf);
                                    }
                                }

                                string thumbnailFilePath = filePathLocalPdf.Trim().Replace(".pdf", ".jpeg");
                                if (!File.Exists(thumbnailFilePath))
                                {
                                    try
                                    {
                                        GhostscriptWrapper.GeneratePageThumb(filePathLocalPdf.Trim(), thumbnailFilePath, 1, 24, 24);
                                    }
                                    catch (Exception ex)
                                    {
                                        //https://sofiamedix.atlassian.net/browse/MED-10610
                                        //MessageBox.Show(ex.StackTrace);
                                    }
                                }

                                if (File.Exists(thumbnailFilePath) && File.ReadAllBytes(thumbnailFilePath).Length > 0)
                                {
                                    tagInfo.Content = File.Exists(thumbnailFilePath) ? Image.FromFile(thumbnailFilePath) : null;
                                }

                                if (!string.IsNullOrEmpty(filePathLocalPdf) && File.Exists(filePathLocalPdf))
                                {
                                    MediaDictionaryAdd(Utilities.CalculateFileChecksum(filePathLocalPdf), filePathLocalPdf);
                                }

                                if (!string.IsNullOrEmpty(thumbnailFilePath) && File.Exists(thumbnailFilePath))
                                {
                                    MediaDictionaryAdd(Utilities.CalculateFileChecksum(thumbnailFilePath), thumbnailFilePath);
                                }
                            }
                        }

                        string tagCodeBinding = "";
                        if (!string.IsNullOrEmpty(tagInfo.TagCode) && (tagInfo.Type == TypeEnum.Tag || tagInfo.Type == TypeEnum.Image || tagInfo.Type == TypeEnum.Pdf))
                            tagCodeBinding = tagInfo.TagCode;
                        //bind to row
                        dtTag.Rows.Add(++masterId, tagInfo.Id, tagCodeBinding, tagInfo.TagName, tagInfo.Content, tagInfo.Type, tagInfo.CreateDate, tagInfo.DirLocation, emrRecordInfo.PkOut, emrRecordInfo.HospCode, emrRecordInfo.Facility, emrRecordInfo.DateTime, emrRecordInfo.Doctor, /*"Doctor"*/ ConvertBinaryToStrPermission(tagInfo.Permission));
                        rowNumber++;
                    }

                    if (_screen != ScreenEnum.UcEditor)
                    {
                        dtTag.Rows.Add(++masterId, Guid.NewGuid().ToString(), "Orders", "", "", TypeEnum.Order, _dateCacheFromServer, "", emrRecordInfo.PkOut, emrRecordInfo.HospCode, emrRecordInfo.Facility, emrRecordInfo.DateTime, emrRecordInfo.Doctor, "");

                        if (emrRecordInfo.OrderInfos != null && emrRecordInfo.OrderInfos.Count > 0 && !isUcEditor)
                        {
                            foreach (OrderInfo orderInfo in emrRecordInfo.OrderInfos)
                            {
                                int aValue = 0;
                                if (!string.IsNullOrEmpty(orderInfo.OrderDisplayOther))
                                {
                                    bool isOk = Int32.TryParse(orderInfo.OrderDisplayOther, out aValue);
                                    if (isOk)
                                        if (IsHideTagOrderInHospRefer(hospCodeRefer, aValue)) continue;
                                }
                                
                                //dtOrder.Rows.Add(orderInfo.ActionDoYn.Equals("Y") ? "Do..." : null, orderInfo.ActionDoYn.Equals("Y") ? orderInfo.InputGubunName : null, orderInfo.ActionDoYn.Equals("Y") ? orderInfo.OrderGubunName : null, orderInfo.HangmogName, orderInfo.Content, ++detailId, masterId, orderInfo.GubunBass, orderInfo.HangmogCode, orderInfo.ActionDoYn, orderInfo.Bunho, orderInfo.Doctor, orderInfo.Gwa, orderInfo.NaewonDate, orderInfo.NaewonKey, orderInfo.InputTab);

                                // 2015.09.25 AnhNV modified
                                dtOrder.Rows.Add(
                                    orderInfo.ActionDoYn == LBLN ? "" : "Do..." + orderInfo.InputTab,
                                    orderInfo.InputGubunName,
                                    orderInfo.OrderGubunName,
                                    orderInfo.HangmogName,
                                    orderInfo.Content,
                                    ++detailId,
                                    masterId,
                                    orderInfo.GubunBass,
                                    orderInfo.HangmogCode,
                                    orderInfo.ActionDoYn,
                                    orderInfo.Bunho,
                                    orderInfo.Doctor,
                                    orderInfo.Gwa,
                                    orderInfo.NaewonDate,
                                    orderInfo.NaewonKey,
                                    orderInfo.InputTab,
                                    orderInfo.InputTabAndGroupSer,
                                    /*"Doctor"*/ ConvertBinaryToStrPermission(orderInfo.OrderDisplayOther));
                            }
                        }
                        else
                        {
                            //dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00001", "Contrent test 001", orderType);
                        }
                    }
                    //DataSet ds = new DataSet();
                    //ds.Tables.AddRange(new DataTable[] { dtTag, dtOrder });
                    //ds.Relations.Add("CustomerOrders", dcmpk, dcdfk);
                }
                DataSet ds = new DataSet();
                ds.Tables.AddRange(new DataTable[] { dtTag, dtOrder });
                ds.Relations.Add("CustomerOrders", dcmpk, dcdfk);

                strMml = strMmlParam;
                grdContent.DataSource = dtTag;
                currentDataSource = dtTag;
                currentDataOrder = dtOrder;
                gridView1.BorderStyle = BorderStyles.NoBorder;
                gridView1.OptionsView.ShowGroupPanel = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridView1.OptionsView.ShowHorzLines = false;
                gridView1.OptionsView.ShowVertLines = false;
                gridView1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                gridView1.OptionsView.ShowFooter = false;
                gridView1.OptionsView.ColumnAutoWidth = true;
                gridView1.FocusedRowHandle = 1;
                grdContent.RefreshDataSource();
                InitAppearance();

                //store column index
                orderList.Clear();
                for (int i = 0; i < gridView1.Columns.Count; i++)
                    orderList.Add(gridView1.Columns[i].VisibleIndex);

                Monitor.Pulse(this.grdContent);
            }
        }
        #endregion

        private bool IsHideTagOrderInHospRefer(string _hospCodeRefer, int _permission)
        {
            return !string.IsNullOrEmpty(_hospCodeRefer) && BitFlag(_permission, 3);
        }

        
        #region InsertImage
        public void InsertImage(string imagePath, TypeEnum typeEnum, string linkLocation, ActionType actionType, bool showControl)
        {
            string filePath = "";

            string bunho = _patientModel.PatientId;
            if (typeEnum == TypeEnum.Pdf)
            {
                filePath = imagePath;
            }
            else
            {
                filePath = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(bunho, Utilities.GetFileName(imagePath), Path.GetExtension(imagePath)), bunho).Trim();
            }
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
                if (fileInfo.Directory != null) Directory.CreateDirectory(fileInfo.Directory.FullName);

            if (typeEnum == TypeEnum.Image)
            {
                SaveStreamToFile(filePath, File.ReadAllBytes(imagePath));
            }

            EditImage(filePath, typeEnum, linkLocation, actionType, showControl);
        }
        #endregion

        #region LoadTagName
        private void LoadTagName(string strValue)
        {
            XmlTextReader reader = new XmlTextReader("c:\\IntroToVCS.xml");

            //Check Dic parent
            OCS2015U06Businesses.TagInfo info = DataProvider.Instance.TagDetail.ContainsKey(strValue) ? DataProvider.Instance.TagDetail[strValue] : null;
            if (info != null)
            {
                //dtCboGrd.Rows.Add(info.TagCode, info.TagDisplay);
                #region forLookupEdit
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TagCode", info.TagCode);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TagName", info.TagDisplay);
                #endregion
            }
            else
            {
                //check Dic Children
                OCS2015U06Businesses.TagInfo infoParentDetail = DataProvider.Instance.TagParentDetail.ContainsKey(strValue) ? DataProvider.Instance.TagParentDetail[strValue] : null;
                if (infoParentDetail != null)
                {
                    //dtCboGrd.Rows.Add(info.TagCode, info.TagDisplay);
                    #region forLookupEdit
                    //string tagCode = infoParentDetail.TagCode;
                    string tagCode = "  " + infoParentDetail.TagCode.Trim();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TagCode", tagCode);
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TagCode", infoParentDetail.TagCode);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TagName", infoParentDetail.TagDisplay);
                    #endregion
                }
            }
        }

        #endregion

        #region Mode by Tag

        public void ModeByTag(int objSelected)
        {
            if (orderList.Count > 0)
                RestoreOrder();
            if (objSelected == 0)
            {
                gridView1.Columns["TagCode"].Visible = true;
                gridView1.Columns["TagName"].Visible = false;
            }
            else if (objSelected == 1)
            {
                gridView1.Columns["TagCode"].Visible = false;
                gridView1.Columns["TagName"].Visible = true;
            }
            else if (objSelected == 2)
            {
                gridView1.Columns["TagCode"].Visible = true;
                gridView1.Columns["TagName"].Visible = true;
            }

            gridView1.RefreshData();

        }

        void RestoreOrder()
        {
            if (orderList.Count > 0)
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].VisibleIndex = orderList[i];
                }
        }

        #endregion

        #region Scroll to Date
        public void ScrollToDate(string strDateTime, string naewonKey)
        {
            if (string.IsNullOrEmpty(strDateTime))
            {
                grdContent.DataSource = null;
                grdContent.DataSource = currentDataSource;
                grdContent.Refresh();
            }
            else
            {
                DateTime dt = Convert.ToDateTime(strDateTime);
                string dtConvert = dt.ToString("yyyy/MM/dd");
                //for (int i = 0; i < gridView1.DataRowCount; i++)
                //{
                //    DataRow row = gridView1.GetDataRow(i);
                //    if (row["CreateDate"].ToString() == dtConvert)
                //    {

                //    }
                //}

                /*                //Binding DataSource  filter by date
                DataTable dt1 = DataCreator.CreateDataGrid(20, "", false, "");

                DataTable dataSortBy = dt1.Clone();

                foreach (DataRow itemData in dt1.Rows)
                {
                    if (itemData["CreateDate"].ToString() == dtConvert)
                    {
                        dataSortBy.ImportRow(itemData);
                        int handle = (int)itemData[0];
                        //GridColumn column = gridView1.Columns["TagCode"];
                        int rowHandle = gridView1.LocateByValue(0, gridView1.Columns["TagCode"], handle);
                    }
                }
                grdContent.DataSource = dataSortBy;*/


                //Croll to Date
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!string.IsNullOrEmpty(naewonKey))
                    {
                        if (gridView1.GetDataRow(i)["CreateDate"].Equals(dtConvert) && naewonKey == _pkout)
                        {
                            // gridView1.MakeRowVisible(16, false);
                            //int rowHandle = gridView1.LocateByValue(0, gridView1.Columns["CreateDate"], 16);
                            gridView1.FocusedRowHandle = i;
                            MoveUpToTheTop(i);
                            break;
                        }
                        else
                        {
                            gridView1.FocusedRowHandle = 1;
                        }
                    }
                    else
                    {
                        if (gridView1.GetDataRow(i)["CreateDate"].Equals(dtConvert) && gridView1.GetDataRow(i)["Type"].Equals(4))
                        {
                            // gridView1.MakeRowVisible(16, false);
                            //int rowHandle = gridView1.LocateByValue(0, gridView1.Columns["CreateDate"], 16);
                            gridView1.FocusedRowHandle = i;
                            MoveUpToTheTop(i);
                            break;
                        }
                        else
                        {
                            //gridView1.FocusedRowHandle = 1;
                        }
                    }
                }

                grdContent.Refresh();
            }
        }

        #endregion

        private void MoveUpToTheTop(int focusedRowHandle)
        {
            gridView1.LeftCoord = focusedRowHandle;
            gridView1.TopRowIndex = focusedRowHandle;
        }

        #region Scroll to TagId
        public void ScrollToTagId(string tagId)
        {
            if (string.IsNullOrEmpty(tagId))
            {
                grdContent.DataSource = null;
                grdContent.DataSource = currentDataSource;
                grdContent.Refresh();
            }
            else
            {
                //Croll to Date
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetDataRow(i)["Id"].Equals(tagId))
                    {
                        // gridView1.MakeRowVisible(16, false);
                        //int rowHandle = gridView1.LocateByValue(0, gridView1.Columns["CreateDate"], 16);
                        gridView1.FocusedRowHandle = i;
                        MoveUpToTheTop(i);
                        break;
                    }
                    else
                    {
                        //gridView1.FocusedRowHandle = 1;
                    }
                }

                grdContent.Refresh();
            }
        }

        #endregion

        #region Scroll to PkOut
        public void ScrollToPkOut(string pkOut)
        {
            if (TypeCheck.IsNull(pkOut))
            {
                grdContent.DataSource = null;
                grdContent.DataSource = currentDataSource;
                grdContent.Refresh();
            }
            else
            {
                //Croll to Date
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    try
                    {
                        if (gridView1.GetDataRow(i)["PkOut"].Equals(pkOut))
                        {
                            // gridView1.MakeRowVisible(16, false);
                            //int rowHandle = gridView1.LocateByValue(0, gridView1.Columns["CreateDate"], 16);
                            gridView1.FocusedRowHandle = i;
                            MoveUpToTheTop(i);
                            break;
                        }
                        else
                        {
                            gridView1.FocusedRowHandle = 1;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                grdContent.Refresh();
            }
        }

        #endregion

        #region Fillter by Tag

        public void FillterByTagAndOrder(string tag, string tagChildren, string order)
        {
            try
            {
                int cout = 0, j = 0;
                if (currentDataSource == null) return;
                DataTable dtTag = new DataTable();
                DataColumn dcmpk = dtTag.Columns.Add("OrderMaster", typeof(int));
                dtTag.Columns.Add("Id", typeof(string));
                dtTag.Columns.Add("TagCode", typeof(string));
                dtTag.Columns.Add("TagName", typeof(string));
                dtTag.Columns.Add("Content", typeof(object));
                dtTag.Columns.Add("Type", typeof(TypeEnum)); //(TypeEnum: string, Image, pdf)
                dtTag.Columns.Add("CreateDate", typeof(string));
                dtTag.Columns.Add("DirLocation", typeof(string));
                dtTag.Columns.Add("PkOut", typeof(string));
                dtTag.Columns.Add("HospCode", typeof(string));
                dtTag.Columns.Add("Gwa", typeof(string));
                dtTag.Columns.Add("DateTime", typeof(string));
                dtTag.Columns.Add("Doctor", typeof(string));
                dtTag.Columns.Add("DisplayOrther", typeof(string));
                dtTag.PrimaryKey = new DataColumn[] { dcmpk };


                DataTable dtOrder = new DataTable();
                dtOrder.Columns.Add("BtnDo", typeof(object));
                dtOrder.Columns.Add("InputGubunName", typeof(string));
                dtOrder.Columns.Add("OrderGubunName", typeof(string));
                dtOrder.Columns.Add("HangmogName", typeof(string));
                dtOrder.Columns.Add("Content", typeof(string));
                dtOrder.Columns.Add("OrderCurrent", typeof(int));
                DataColumn dcdfk = dtOrder.Columns.Add("ParrentTagCurrent", typeof(int));
                dtOrder.Columns.Add("GubunBass", typeof(string));
                dtOrder.Columns.Add("HangmogCode", typeof(string));
                dtOrder.Columns.Add("ActionDoYn", typeof(string));
                dtOrder.Columns.Add("Bunho", typeof(string));
                dtOrder.Columns.Add("Doctor", typeof(string));
                dtOrder.Columns.Add("Gwa", typeof(string));
                dtOrder.Columns.Add("NaewonDate", typeof(string));
                dtOrder.Columns.Add("NaewonKey", typeof(string));
                dtOrder.Columns.Add("InputTab", typeof(string));
                dtOrder.Columns.Add("InputTabAndGroupSer", typeof(string));
                dtOrder.Columns.Add("OrderDisplayOrder", typeof(object));

                foreach (DataRow itemData in currentDataSource.Rows)
                {
                    bool isExistParentTag = DataProvider.Instance.DicParentTagInfos.ContainsKey(itemData["TagCode"].ToString().Trim()); //parent tag
                    bool isExistChildTag = DataProvider.Instance.TagParentDetail.ContainsKey(itemData["TagCode"].ToString().Trim());   //Child tag
                    bool isPassOrder = false;

                    if (string.IsNullOrEmpty(tag))
                    {
                        if (string.IsNullOrEmpty(tagChildren))
                        {
                            isPassOrder = true;
                        }
                        else
                        {
                            if (isExistParentTag || (isExistChildTag && itemData["TagCode"].ToString().Trim() == tagChildren.Trim())) isPassOrder = true;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(tagChildren))
                        {
                            if (isExistChildTag || (isExistParentTag && itemData["TagCode"].ToString().Trim() == tag.Trim())) isPassOrder = true;
                        }
                        else
                        {
                            if ((isExistParentTag && itemData["TagCode"].ToString().Trim() == tag.Trim())
                                || (isExistChildTag && itemData["TagCode"].ToString().Trim() == tagChildren.Trim()))
                                isPassOrder = true;
                        }
                    }

                    if (isPassOrder
                        || itemData["TagCode"].ToString() == "Orders"
                        || itemData["Type"].ToString() == "4" /*Header*/)
                    {
                        dtTag.ImportRow(itemData);
                        foreach (DataRow itemOrder in currentDataOrder.Rows)
                        {
                            if (!string.IsNullOrEmpty(order))
                            {
                                if (itemOrder["ParrentTagCurrent"].ToString() == itemData[0].ToString() &&
                                    itemOrder["GubunBass"].ToString() == order)
                                {
                                    dtOrder.ImportRow(itemOrder);
                                }
                            }
                            else
                            {
                                if (itemOrder["ParrentTagCurrent"].ToString() == itemData[0].ToString())
                                {
                                    dtOrder.ImportRow(itemOrder);
                                }
                            }
                        }
                    }
                }

                DataSet ds = new DataSet();
                ds.Tables.AddRange(new DataTable[] { dtTag, dtOrder });
                ds.Relations.Add("CustomerOrders", dcmpk, dcdfk);
                grdContent.DataSource = dtTag;
                grdContent.Refresh();
                for (int i = 0; i < gridView1.DataRowCount; i++)
                    gridView1.SetMasterRowExpanded(i, true);
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of FillterByTagAndOrder() method: " + ex.StackTrace);
            }
        }

        #endregion

        #region AddNewRow
        private void AddNewRow(string tagCode, string tagName, string content, string imagePath)
        {
            int selectedRowIndex = gridView1.FocusedRowHandle;
            DataTable dt = grdContent.DataSource as DataTable;

            DataRow newRow = dt != null ? dt.NewRow() : null;
            if (newRow == null) return;
            newRow["TagCode"] = tagCode;
            newRow["TagName"] = tagName;
            newRow["Type"] = 1;
            newRow["Content"] = Image.FromFile(imagePath);
            newRow["CreateDate"] = _dateCacheFromServer;
            dt.Rows.InsertAt(newRow, selectedRowIndex + 1);
            gridView1.SelectRow(selectedRowIndex + 1);
        }
        #endregion

        #region EditImage
        private void EditImage(string filePath, TypeEnum typeEnum, string linkLocation, ActionType actionType, bool showControl)
        {
            // Get original image which is being edited
            DataProvider.ImageEditorInstance.Edit(filePath, linkLocation, typeEnum, 50, 50,
                delegate(byte[] data, float scaleX, float scaleY)
                {
                    Image img = Image.FromStream(new MemoryStream(data));
                    int selectedRowIndex = gridView1.FocusedRowHandle > 0 ? gridView1.FocusedRowHandle : 0;

                    DataTable dt = grdContent.DataSource as DataTable;
                    if (dt == null) return;
                    if (actionType == ActionType.Update || actionType == ActionType.Replace)
                    {
                        //foreach (DataRow row in dt.Rows)
                        //{
                        //    if (row["Name"].ToString() == "SomeName")
                        //        row.SetField("Name", "AnotherName");
                        //}
                        dt.Rows[selectedRowIndex]["Content"] = img;
                        dt.Rows[selectedRowIndex]["DirLocation"] = filePath;
                        gridView1.RefreshData();
                        gridView1.RefreshEditor(true);
                        gridView1.RefreshRow(selectedRowIndex);
                    }
                    else
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["OrderMaster"] = ++masterId;
                        newRow["TagCode"] = "";
                        newRow["TagName"] = "";
                        newRow["Type"] = typeEnum;
                        newRow["Content"] = img;
                        newRow["Id"] = Guid.NewGuid();
                        if (dt.Rows.Count > 0)
                        {
                            DataRow currentRow = dt.Rows[selectedRowIndex];
                            newRow["PkOut"] = currentRow == null ? _pkout : currentRow["PkOut"];
                        }
                        newRow["CreateDate"] = _dateCacheFromServer;
                        if (typeEnum == TypeEnum.Pdf)
                        {
                            newRow["DirLocation"] = linkLocation;
                        }
                        else
                        {
                            newRow["DirLocation"] = filePath;
                        }
                        dt.Rows.InsertAt(newRow, selectedRowIndex + 1);
                        gridView1.SelectRow(selectedRowIndex + 1);
                    }

                }, this, showControl);

            //MED-8221 - MED-13135
            if (typeEnum == TypeEnum.Pdf) //upload pdf file
            {
                Upload(linkLocation);
                MediaDictionaryAdd(Utilities.CalculateFileChecksum(linkLocation), linkLocation);

                string thumbnailFilePath = linkLocation.Trim().Replace(".pdf", ".jpeg");
                if (File.Exists(thumbnailFilePath))
                {
                    MediaDictionaryAdd(Utilities.CalculateFileChecksum(thumbnailFilePath), thumbnailFilePath);
                }
            }

            Upload(filePath); //Upload Image file if pdf file then upload file thumnail
            MediaDictionaryAdd(Utilities.CalculateFileChecksum(filePath), filePath);
        }

        #endregion

        public void GetTemplate(List<OCS2015U31EmrTagGetTemplateTagsInfo> lstTagsInfo, string bunho)
        {
            if (currentDataSource == null) return;

            DataTable dataSortBy = currentDataSource.Clone();
            Dictionary<String, List<String>> allTag = DataProvider.Instance.Tags;

            foreach (OCS2015U31EmrTagGetTemplateTagsInfo tagInfo in lstTagsInfo)
            {
                string tagCode = tagInfo.TagCode.Trim();
                string tagName = tagInfo.TagName;
                string permissionEmr = "D";
                object defaultContent = null;

                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    // Create new EMR record base on pkOutTemp
                    DataRow row = gridView1.GetDataRow(i);
                    if (tagCode == row["TagCode"].ToString())
                    {
                        string displayOrther = row["DisplayOrther"].ToString();
                        permissionEmr = displayOrther;
                    }
                }

                TypeEnum tagType = TypeEnum.Tag;
                string dirLocation = "";
                OCS2015U06Businesses.TagInfo infoParentDetail = DataProvider.Instance.TagParentDetail.ContainsKey(tagCode) ? DataProvider.Instance.TagParentDetail[tagCode] : null;
                if (infoParentDetail != null)
                {
                    tagCode = "  " + infoParentDetail.TagCode.Trim();
                }

                if (tagInfo.Type == "1")
                {
                    tagType = TypeEnum.Image;
                    //Image type
                    if (!string.IsNullOrEmpty(tagInfo.DefaultContent))
                    {
                        string filePathLocal = Utilities.ConvertToLocalPath(
                            !string.IsNullOrEmpty(tagInfo.DefaultContent) ? tagInfo.DefaultContent.Trim() : "",
                            UserInfo.HospCode, bunho);
                        if (!File.Exists(filePathLocal))
                        {
                            Utilities.DownloadFile(filePathLocal, UserInfo.HospCode, STRFDTEMP);
                        }
                        defaultContent = !string.IsNullOrEmpty(filePathLocal) && File.Exists(filePathLocal) ? Image.FromFile(filePathLocal) : null;
                        if (!string.IsNullOrEmpty(filePathLocal) && File.Exists(filePathLocal))
                        {
                            Upload(filePathLocal);
                            MediaDictionaryAdd(Utilities.CalculateFileChecksum(filePathLocal), filePathLocal);
                        }

                        dirLocation = filePathLocal;
                    }
                }
                else
                {
                    //Text type
                    defaultContent = tagInfo.DefaultContent;
                }

                dataSortBy.Rows.Add(++masterId, Guid.NewGuid().ToString(), tagCode, tagName, defaultContent, tagType, !string.IsNullOrEmpty(_dateCacheFromServer) ? _dateCacheFromServer : DateTime.Now.ToString("yyyy/MM/dd"), dirLocation, permissionEmr);
            }

            LoadGridCombobox();
            grdContent.DataSource = dataSortBy;
            grdContent.Refresh();
        }

        public void GetTemplate(string arrTag)
        {
            string[] tagContentArr = arrTag.Split(new char[] { ',' });
            if (currentDataSource == null) return;

            DataTable dataSortBy = currentDataSource.Clone();
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

            for (int i = 0; i < conversionTags.Count; i++)
            {
                OCS2015U06Businesses.TagInfo info =
                    DataProvider.Instance.TagDetail.ContainsKey(conversionTags[i].ToString(CultureInfo.InvariantCulture))
                        ? DataProvider.Instance.TagDetail[conversionTags[i].ToString(CultureInfo.InvariantCulture)]
                        : null;
                if (info != null)
                {
                    string tagCodeConvert = info.TagCode.Trim();
                    OCS2015U06Businesses.TagInfo infoParentDetail = DataProvider.Instance.TagParentDetail.ContainsKey(tagCodeConvert) ? DataProvider.Instance.TagParentDetail[tagCodeConvert] : null;
                    if (infoParentDetail != null)
                    {
                        //tagCodeConvert = infoParentDetail.TagCode;
                        tagCodeConvert = "  " + infoParentDetail.TagCode.Trim();
                    }
                    /*//add tag to Grid follow Template
                    dtCboGrd.Rows.Add(info.TagCode, info.TagDisplay);
                    dtGrd.Rows.Add(i, info.TagCode, info.TagDisplay, "");*/
                    dataSortBy.Rows.Add(++masterId, Guid.NewGuid().ToString(), tagCodeConvert, info.TagDisplay, "");

                    /*foreach (DataRow itemData in currentDataSource.Rows)
                    {
                        if (itemData["TagCode"].ToString() == info.TagCode
                            || itemData["TagCode"].ToString() == "Order")
                        {
                            dataSortBy.ImportRow(itemData);
                        }
                    }*/
                }
            }

            LoadGridCombobox();
            grdContent.DataSource = dataSortBy;
            grdContent.Refresh();
        }

        #region SetMasterRowExpanded
        public void InitAppearance()
        {
            //int rowCount = gridView1.RowCount;

            //gridView1.SetMasterRowExpanded(rowCount - 1, true);

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                if ((TypeEnum)row["Type"] == TypeEnum.Order)
                {
                    gridView1.SetMasterRowExpanded(i, true);
                }
            }
        }
        #endregion

        public void SetDisableContent()
        {
            /*GridView view = grdContent.FocusedView as GridView;
            if (view == null) return;
            DataRowView selRow = (DataRowView)(grdContent.MainView.GetRow(view.FocusedRowHandle));
            Bitmap contentBm = (Bitmap)selRow["Content"];
            TypeEnum typeEnum = (TypeEnum)selRow["Type"];*/

            /*for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                if (row["Type"].ToString().Equals("4"))
                {
                    
                }
            }*/
        }

        public string Save(EmrRecordInfo include, bool useTagFromGrid, ScreenEnum screenEnum)
        {
            //MED-10925
            SetCacheDateTimeFromServer();

            if (_patientModel != null)
            {
                List<EmrRecordInfo> oldRecords = useTagFromGrid ? new List<EmrRecordInfo>() : _existingRecords;

                if (useTagFromGrid)
                {
                    Dictionary<string, EmrRecordInfo> dicRecords = new Dictionary<string, EmrRecordInfo>();
                    string neawonDate = string.Empty;
                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        // Create new EMR record base on pkOutTemp
                        DataRow row = gridView1.GetDataRow(i);
                        string pkout = row["PkOut"] == null ? null : row["PkOut"].ToString();
                        neawonDate = row["DateTime"] == null ? "" : row["CreateDate"].ToString();
                        if (string.IsNullOrEmpty(pkout)) continue;

                        if (!dicRecords.ContainsKey(pkout))
                        {
                            EmrRecordInfo rc = new EmrRecordInfo();
                            rc.PkOut = pkout;
                            rc.HospCode = UserInfo.HospCode;
                            rc.Facility = row["Gwa"].ToString();
                            rc.DateTime = string.IsNullOrEmpty(neawonDate) ? _dateCacheFromServer : neawonDate;
                            rc.Doctor = row["Doctor"].ToString();
                            dicRecords.Add(pkout, rc);
                            oldRecords.Add(rc);

                            //because user can't update ORDERS from UcGrid so we should use ORDER from _existingRecords
                            foreach (EmrRecordInfo recordInfo in _existingRecords)
                            {
                                if (screenEnum == ScreenEnum.U44)
                                {
                                    foreach (OrderInfo orderInfo in recordInfo.OrderInfos)
                                    {
                                        #region Get datasource of Details view(Order List) - 2
                                        GridViewInfo viewInfo = gridView1.GetViewInfo() as GridViewInfo;
                                        if (viewInfo != null)
                                        {
                                            foreach (GridRowInfo rowInfo in viewInfo.RowsInfo)
                                            {
                                                int rowHandle = rowInfo.RowHandle;
                                                BaseView detailView = gridView1.GetDetailView(rowHandle, 0);

                                                if (detailView != null)
                                                {
                                                    DataView dataView = detailView.DataSource as DataView;
                                                    if (dataView != null)
                                                    {
                                                        DataTable table = dataView.Table;
                                                        if (table != null)
                                                        {
                                                            foreach (DataRow rowGrd in table.Rows)
                                                            {
                                                                if (orderInfo.HangmogCode == rowGrd["HangmogCode"].ToString() && orderInfo.NaewonKey == rowGrd["NaewonKey"].ToString())
                                                                {
                                                                    if (table.Columns.Contains("OrderDisplayOrder"))
                                                                    {
                                                                        string permission = rowGrd["OrderDisplayOrder"].ToString();
                                                                        orderInfo.OrderDisplayOther = ConvertStringToInt(permission).ToString();
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                }

                                if (recordInfo.PkOut.Equals(pkout))
                                {
                                    if (!string.IsNullOrEmpty(recordInfo.TemplateId))
                                        rc.TemplateId = recordInfo.TemplateId;
                                    rc.OrderInfos.AddRange(recordInfo.OrderInfos);
                                }
                            }
                        }

                        EmrRecordInfo emrRecord = dicRecords[pkout];

                        TagInfo tagItem = GetTagByDataRow(row, i, true);
                        if (tagItem != null) emrRecord.TagInfos.Add(tagItem);
                    }
                }

                if (include != null)
                {
                    bool existed = false;
                    for (int i = 0; i < oldRecords.Count; i++)
                    {
                        if (oldRecords[i].PkOut.Equals(include.PkOut))
                        {
                            if (!string.IsNullOrEmpty(include.TemplateId))
                                oldRecords[i].TemplateId = include.TemplateId;

                            if (include.TagInfos != null && include.TagInfos.Count > 0)
                            {
                                oldRecords[i].TagInfos.Clear();
                                oldRecords[i].TagInfos.AddRange(include.TagInfos);
                            }

                            oldRecords[i].OrderInfos = include.OrderInfos;
                            existed = true;
                            break;
                        }
                        else
                        {

                        }
                    }

                    //Clear comment by pkout
                    //foreach (CommentData commentDataItem in commentDataDic.Values)
                    //    commentDataItem.ClearCommentItemByPkOut(include.PkOut);

                    if (!existed)
                    {
                        oldRecords.Add(include);
                    }
                }

                /*string mml = MmlParser.Instance.ToMmL(oldRecords, _patientModel, oldMmlContent);*/
                string mml = MmlParser.Instance.ToMmL(oldRecords, _patientModel, oldMmlContent, LstOcsoOCS1003P01GridOutSangInfo);

                strMml = mml;
                return mml;
            }
            return string.Empty;
        }

        private bool CheckInfoTag(TagInfo objTagInfo, EmrRecordInfo emrRecordInfo)
        {
            foreach (TagInfo tagInfo in emrRecordInfo.TagInfos)
            {
                if (objTagInfo.Id.Equals(tagInfo.Id) && objTagInfo.TagCode.Equals(tagInfo.TagCode))
                {
                    return true;
                }
            }

            return false;
        }

        /*public string GetMmlFromGrid(bool includeOrders, string user_id)
        {
            EmrRecordInfo record = GetEmrRecordFromGrid(includeOrders, user_id);
            List<EmrRecordInfo> items = new List<EmrRecordInfo>();
            items.Add(record);
            string mml = MmlParser.Instance.ToMmL(items, _patientModel, oldMmlContent);
            return mml;
        }*/

        public EmrRecordInfo GetEmrRecordFromGrid(bool includeOrders, string user_id)
        {
            return ProcessGetEmrRecordFromGrid(includeOrders, user_id, false);
        }

        public EmrRecordInfo GetEmrRecordFromGrid(bool includeOrders, string user_id, bool isUserUpload)
        {
            return ProcessGetEmrRecordFromGrid(includeOrders, user_id, isUserUpload);
        }

        private EmrRecordInfo ProcessGetEmrRecordFromGrid(bool includeOrders, string user_id, bool isUserUpload)
        {
            //MED-10925
            SetCacheDateTimeFromServer();
            List<TagInfo> lstTag = new List<TagInfo>();

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row1 = gridView1.GetDataRow(i);
                TagInfo tag = GetTagByDataRow(row1, i, isUserUpload);
                if (tag != null) lstTag.Add(tag);
            }

            EmrRecordInfo emrRecord = new EmrRecordInfo();
            emrRecord.HospCode = UserInfo.HospCode;
            emrRecord.Facility = UserInfo.Gwa;
            emrRecord.DateTime = _dateCacheFromServer;
            emrRecord.Doctor = user_id;
            emrRecord.PkOut = !string.IsNullOrEmpty(_pkout) ? _pkout : _naewonKey;
            emrRecord.TemplateId = !string.IsNullOrEmpty(CurrentTemplateId) ? CurrentTemplateId.Trim() : "";
            emrRecord.TagInfos.AddRange(lstTag);
            if (includeOrders) emrRecord.OrderInfos = GetCurrentOrders();
            return emrRecord;
        }

        private List<OrderInfo> GetCurrentOrders()
        {
            List<OrderInfo> listOrderInfos = new List<OrderInfo>();
            DataTable lstOrder = DoButtonBusiness.OrderData;
            if (lstOrder != null)
            {
                List<string> distinctInputTab = new List<string>();
                DataRow[] dRows = lstOrder.Select("", "input_tab");
                int count = 0;
                foreach (DataRow row1 in dRows)
                {
                    string ip = row1["input_tab"].ToString();

                    OrderInfo orderItem = new OrderInfo();

                    orderItem.HangmogName = row1["hangmog_name"].ToString();
                    orderItem.GubunBass = row1["order_gubun"].ToString();
                    orderItem.HangmogCode = row1["hangmog_code"].ToString();
                    orderItem.InputGubunName = row1["input_gubun_name"].ToString();
                    orderItem.OrderGubunName = row1["order_gubun_name"].ToString();
                    if (row1["ord_danui_name"].ToString() == "無")
                    {
                        orderItem.OrdDanuiName = "";
                    }
                    else orderItem.OrdDanuiName = row1["ord_danui_name"].ToString();

                    orderItem.Content = row1["suryang"] + orderItem.OrdDanuiName + row1["dv_time"] + row1["nalsu"];
 
                    if (!distinctInputTab.Contains(row1["input_tab"].ToString()))
                    {
                        /*orderItem.ActionDoYn = "Y";*/
                        distinctInputTab.Add(row1["input_tab"].ToString());
                    }
                    else
                    {
                        /*orderItem.ActionDoYn = "N";*/
                    }

                    /*orderItem.ActionDoYn = count % 2 != 0 ? "Y" : "N";*/
                    orderItem.ActionDoYn = row1["action_do_yn"].ToString();
                    orderItem.Bunho = row1["bunho"].ToString();
                    orderItem.Doctor = row1["doctor"].ToString();
                    orderItem.Gwa = row1["gwa"].ToString();
                    orderItem.NaewonDate = _dateCacheFromServer;
                    orderItem.NaewonKey = _pkout;
                    orderItem.InputTab = row1["input_tab"].ToString();
                    //MED-10208 add field group_ser to InputTab for merge cell follow inputtab + group_ser
                    orderItem.InputTabAndGroupSer = row1["input_tab"].ToString() + LBLSub + row1["group_ser"].ToString();

                    foreach (EmrRecordInfo recordInfo in _existingRecords)
                    {
                        foreach (OrderInfo orderInfo in recordInfo.OrderInfos)
                        {
                            if (recordInfo.PkOut.Equals(_pkout) && orderInfo.HangmogCode == row1["hangmog_code"].ToString())
                            {
                                orderItem.OrderDisplayOther = orderInfo.OrderDisplayOther;
                            }
                        }
                    }

                    orderItem.Nalsu = row1["nalsu"].ToString();
                    orderItem.Dv = row1["dv"].ToString();
                    orderItem.OrdDanuiName = row1["ord_danui_name"].ToString();
                    orderItem.Suryang = row1["suryang"].ToString();
                    orderItem.BogyongName = row1["bogyong_name"].ToString();
                    //MED-15743
                    orderItem.DvTime = row1["dv_time"].ToString();
                    orderItem.MixSet = row1["mix_group"].ToString();
                    orderItem.JusaName = row1["jusa_name"].ToString();
                    for (int i = 1; i < 9; i++)
                    {
                        if (row1["dv_" + i] != null)
                        {
                            orderItem.UnequalDosage += (row1["dv_" + i] + "-").ToString();
                        }
                    }
                    orderItem.UnequalDosage = orderItem.UnequalDosage.Trim(new char[] { '-' });
                    orderItem.HopeDate = row1["hope_date"].ToString();
                    orderItem.Comment = row1["order_remark"].ToString();
                    orderItem.GroupSer = row1["group_ser"].ToString();

                    listOrderInfos.Add(orderItem);
                    ++count;
                }
            }
            return listOrderInfos;
        }

        private TagInfo GetTagByDataRow(DataRow row1, int i)
        {
            return ProcessGetTagByDataRow(row1, i, false);
        }

        private TagInfo GetTagByDataRow(DataRow row1, int i, bool isUseUpload)
        {
            return ProcessGetTagByDataRow(row1, i, isUseUpload);
        }

        private TagInfo ProcessGetTagByDataRow(DataRow row1, int i, bool isUseUpload)
        {
            TagInfo tagItem = new TagInfo();
            tagItem.Order = i;
            tagItem.TagCode = row1["TagCode"].ToString().Trim();
            tagItem.TagName = row1["TagName"].ToString();
            tagItem.Content = row1["Content"];
            string tagId = row1["Id"].ToString();
            tagItem.Id = string.IsNullOrEmpty(tagId) ? Guid.NewGuid().ToString() : tagId;
            //tagItem.Id = Guid.NewGuid().ToString();
            tagItem.Type = !string.IsNullOrEmpty(row1["Type"].ToString()) ? (TypeEnum)row1["Type"] : TypeEnum.Tag;
            tagItem.CreateDate = _dateCacheFromServer;
            tagItem.DirLocation = row1["DirLocation"].ToString();
            string perM = row1["DisplayOrther"].ToString();
            tagItem.Permission = ConvertStringToInt(perM);

            if (tagItem.Type == TypeEnum.Image && !string.IsNullOrEmpty(tagItem.DirLocation))
            {
                if (File.Exists(tagItem.DirLocation))
                {
                    Upload(tagItem.DirLocation.Trim(), isUseUpload);
                }
            }
            else if (tagItem.Type == TypeEnum.Pdf && !string.IsNullOrEmpty(tagItem.DirLocation))
            {
                //upload pdf
                if (File.Exists(tagItem.DirLocation))
                    Upload(tagItem.DirLocation.Trim(), isUseUpload);
                /*//upload thumnail
                string thumbnailFilePath = tagItem.DirLocation.Trim().Replace(".pdf", ".jpeg");
                if (File.Exists(thumbnailFilePath))
                    Upload(thumbnailFilePath.Trim(), isUseUpload);*/
            }

            if ((tagItem.Type == TypeEnum.Tag || tagItem.Type == TypeEnum.Order) &&
                !string.IsNullOrEmpty(tagItem.Content.ToString()) && string.IsNullOrEmpty(tagItem.TagCode))
            {
                _strMsgCheckTagCodeAndContent = Resources.Emr_Msg_000001;
                return null;
            }

            if (((tagItem.Type == TypeEnum.Tag) && !string.IsNullOrEmpty(tagItem.Content.ToString())
                && !string.IsNullOrEmpty(tagItem.TagCode)) || ((tagItem.Type == TypeEnum.Order)
                && !string.IsNullOrEmpty(tagItem.Content.ToString())) || ((tagItem.Type == TypeEnum.Image || tagItem.Type == TypeEnum.Pdf)
                && !string.IsNullOrEmpty(tagItem.DirLocation)))
            {
                return tagItem;
            }
            return null;
        }

        /*public void Upload(string filePath)
        {
            if (this.ExistMediaFile(Utilities.CalculateFileChecksum(filePath)) || string.IsNullOrEmpty(filePath))
                return;
            //TODO need override this test code
            string localPath = Utilities.ConvertToLocalPath(filePath, UserInfo.HospCode, _patientModel.PatientId);

            // MED-10181
            //string uploadAddress = ConfigurationManager.AppSettings["UploadBaseUri"]; //http://10.1.20.2:8010/upload
            string uploadAddress = IHIS.CloudConnector.Utility.Utility.GetConfig("UploadBaseUri", UserInfo.VpnYn);

            string uploadToken = ConfigurationManager.AppSettings["UploadToken"]; //"1234"
            Uri address = new Uri(uploadAddress);
            Utilities.UploadFile(address, localPath, uploadToken, UserInfo.HospCode, _patientModel.PatientId);
        }*/


        public void Upload(string path)
        {
            // MED-8221
            //using backgroundworker to improve performance
            try
            {

                if (this.ExistMediaFile(Utilities.CalculateFileChecksum(path)) || string.IsNullOrEmpty(path))
                    return;

                BackgroundWorker bwUpload = new BackgroundWorker();
                bwUpload.WorkerReportsProgress = true;
                bwUpload.WorkerSupportsCancellation = true;
                bwUpload.DoWork += new DoWorkEventHandler(bwUpload_DoWork);

                if (bwUpload.IsBusy != true)
                {
                    bwUpload.RunWorkerAsync(path);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("UPLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        //MED-8221
        private void bwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                String uploadPath = e.Argument as String;

                //TODO need override this test code
                string localPath = Utilities.ConvertToLocalPath(uploadPath, UserInfo.HospCode,
                    _patientModel.PatientId);

                // MED-10181
                //string uploadAddress = ConfigurationManager.AppSettings["UploadBaseUri"];
                string uploadAddress = IHIS.CloudConnector.Utility.Utility.GetConfig("UploadBaseUri", UserInfo.VpnYn);

                //http://10.1.20.2:8010/upload
                string uploadToken = ConfigurationManager.AppSettings["UploadToken"]; //"1234"
                Uri address = new Uri(uploadAddress);

                if (!this.IsConfirmSave)
                {
                    Utilities.UploadTempFile(address, localPath, uploadToken, UserInfo.HospCode, _patientModel.PatientId);
                }
                else
                {
                    // MED-10181
                    //string moveAddress = ConfigurationManager.AppSettings["MoveBaseUri"];
                    string moveAddress = IHIS.CloudConnector.Utility.Utility.GetConfig("MoveBaseUri", UserInfo.VpnYn);

                    address = new Uri(moveAddress);
                    Utilities.MoveTempFile(address, localPath, uploadToken, UserInfo.HospCode, _patientModel.PatientId);

                    /*if (localPath.EndsWith(".pdf"))
                    {
                        string thumbnailFilePath = localPath.Replace(".pdf", ".jpeg");
                        if (File.Exists(thumbnailFilePath))
                        {
                            Utilities.MoveTempFile(address, thumbnailFilePath, uploadToken, UserInfo.HospCode, _patientModel.PatientId);
                        }
                    }*/
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("UPLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        #region Convert String to Int

        private int ConvertStringToInt(string strValue)
        {
            int iValue = 0;
            if (!string.IsNullOrEmpty(strValue))
            {
                string[] arrString = strValue.Split(new char[] { ',' });
                foreach (string sVlue in arrString)
                {
                    if (sVlue.Trim() == "D")
                        iValue += 8;
                    else if (sVlue.Trim() == "O")
                        iValue += 4;
                    else if (sVlue.Trim() == "R")
                        iValue += 2;
                    else if (sVlue.Trim() == "P")
                        iValue += 1;
                }
            }

            return iValue;
        }
        #endregion

        #region Convert Int to String Permission
        private string ConvertBinaryToStrPermission(string value)
        {
            string strPermission = "";
            int aValue = 0;
            if (!string.IsNullOrEmpty(value))
            {
                bool isOk = Int32.TryParse(value, out aValue);
                if (isOk)
                    strPermission = ConvertBinaryToStrPermission(aValue);
            }

            return strPermission;
        }

        private string ConvertBinaryToStrPermission(int value)
        {
            string strPermission = "";
            if (BitFlag(value, 4))
            {
                strPermission = "D";
            }

            if (BitFlag(value, 3))
            {
                if (string.IsNullOrEmpty(strPermission))
                {
                    strPermission = "O";
                }
                else
                {
                    strPermission = strPermission + ", " + "O";
                }
            }

            if (BitFlag(value, 2))
            {
                if (string.IsNullOrEmpty(strPermission))
                {
                    strPermission = "R";
                }
                else
                {
                    strPermission = strPermission + ", " + "R";
                }
            }

            if (BitFlag(value, 1))
            {
                if (string.IsNullOrEmpty(strPermission))
                {
                    strPermission = "P";
                }
                else
                {
                    strPermission = strPermission + ", " + "P";
                }
            }
            return strPermission.Trim();
        }

        private bool BitFlag(int value, int bitNo)
        {
            return (value >> (bitNo - 1)) % 2 == 1;
        }
        #endregion

        public string ToBinary(int dec)
        {
            string str = "";
            str = Convert.ToString(dec, 2);
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length == 1)
                {
                    str = "000" + str;
                }
                else if (str.Length == 2)
                {
                    str = "00" + str;
                }
                else if (str.Length == 3)
                {
                    str = "0" + str;
                }
            }
            return str;
        }

        private string ConvertBinaryToStrPermission1(string strBinary)
        {
            string strPermission = "";
            StringBuilder sb = new StringBuilder(strBinary);

            for (int i = 0; i < sb.Length; i++)
            {
                string swStr = SwitchIntToChar(i, sb[i].ToString());

                if (string.IsNullOrEmpty(strPermission))
                {
                    if (VScroll)
                    {

                    }
                }
                else
                {

                }
            }

            return strPermission.Trim();
        }

        private string SwitchIntToChar(int posi, string vlue)
        {
            string strChar = "";
            switch (posi)
            {
                case 0:
                    strChar = vlue == "1" ? "D" : "";
                    break;
                case 1:
                    strChar = vlue == "1" ? "O" : "";
                    break;
                case 2:
                    strChar = vlue == "1" ? "R" : "";
                    break;
                case 3:
                    strChar = vlue == "1" ? "P" : "";
                    break;
                default:
                    break;
            }
            return strChar;
        }

        private void BackgroundWorkerDownload(string path, string hospCode, string patientId, string rowNum)
        {
            try
            {
                BackgroundWorker bwDownload = new BackgroundWorker();
                bwDownload.WorkerReportsProgress = true;
                bwDownload.WorkerSupportsCancellation = true;
                bwDownload.DoWork += new DoWorkEventHandler(bwDownload_DoWork);

                if (bwDownload.IsBusy != true)
                {
                    string[] stringParam = { path, hospCode, patientId, rowNum };
                    bwDownload.RunWorkerAsync(stringParam);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("DOWNLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        //MED-8221
        private void bwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string[] param = e.Argument as string[];
                if (param.Length > 3)
                {
                    string filePath = param[0];
                    Utilities.DownloadFile(filePath, param[1], param[2]);

                    lock (this.grdContent)
                    {
                        int rowNum = Int32.Parse(param[3]);
                        string fileType = filePath.Remove(0, filePath.Trim().Length - 3);
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            MediaDictionaryAdd(Utilities.CalculateFileChecksum(filePath), filePath);
                        }

                        if (fileType.ToLower() != "pdf")
                        {
                            DataTable tbl = grdContent.DataSource as DataTable;
                            if (tbl != null && tbl.Rows.Count > rowNum)
                            {
                                tbl.Rows[rowNum]["Content"] = Image.FromFile(filePath);
                                grdContent.DataSource = tbl;
                                grdContent.RefreshDataSource();
                            }
                        }
                        Monitor.Pulse(this.grdContent);
                    }
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("DOWNLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        public void Upload(string path, bool importantUpload)
        {
            // MED-8221
            //using backgroundworker to improve performance
            try
            {
                if (!importantUpload)
                {
                    if (this.ExistMediaFile(Utilities.CalculateFileChecksum(path)) || string.IsNullOrEmpty(path))
                        return;
                }
                else
                {
                    string localPathWithPatient = Utilities.ConvertToLocalPath(path, UserInfo.HospCode,
                    _patientModel.PatientId);

                    if (!File.Exists(localPathWithPatient))
                        File.Copy(path, localPathWithPatient);
                }

                BackgroundWorker bwUpload = new BackgroundWorker();
                bwUpload.WorkerReportsProgress = true;
                bwUpload.WorkerSupportsCancellation = true;
                bwUpload.DoWork += new DoWorkEventHandler(bwUpload_DoWork);

                if (bwUpload.IsBusy != true)
                {
                    bwUpload.RunWorkerAsync(path);
                }

            }
            catch (Exception ex)
            {
                Service.WriteLog("UPLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        public void Reset()
        {
            strMml = string.Empty;
            _existingRecords = new List<EmrRecordInfo>();
            _patientModel = null;
            _pkout = string.Empty;
            currentDataSource = null;
            currentDataOrder = null;
            grdContent.DataSource = null;
            orderList.Clear();
            gridView1.RefreshData();
            MediaDictonaryClear();
            CommentDataDic.Clear();
            _gwa = string.Empty;
            CurrentComments.Clear();
        }

        public TypeEnum KeyEnum(string value)
        {
            const TypeEnum typeEnum = TypeEnum.Tag;
            switch (value)
            {
                case "Tag":
                    return TypeEnum.Tag;
                    break;
                case "Image":
                    return TypeEnum.Image;
                    break;
                case "Pdf":
                    return TypeEnum.Pdf;
                    break;
                case "Order":
                    return TypeEnum.Order;
                    break;
                case "Header":
                    return TypeEnum.Header;
                    break;
            }
            return typeEnum;
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        private void SaveStreamToFile(string fileFullPath, byte[] data)
        {
            if (data.Length == 0) return;
            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = File.Create(fileFullPath, data.Length))
            {
                // Use FileStream object to write to the specified file
                fileStream.Write(data, 0, data.Length);
            }
        }

        public void SetActiveGridView(bool isActive)
        {
            gridView1.OptionsBehavior.ReadOnly = !isActive;
            //gridView1.OptionsBehavior.Editable = isActive;
        }

        public List<TagInfo> GetListChildrenTagA(string rpName)
        {
            List<EmrRecordInfo> lstRecord = new List<EmrRecordInfo>();
            List<TagInfo> lstTagInfos = new List<TagInfo>();
            if (string.IsNullOrEmpty(strMml)) return lstTagInfos;
            if (!string.IsNullOrEmpty(strMml) && _patientModel != null)
            {
                EmrDocker.Types.Tuple<List<EmrRecordInfo>, PatientModelInfo> lstInfo = MmlParser.Instance.ToModel(strMml);
                lstRecord = lstInfo.V1;
                DataProvider.Instance.ReloadLatestTags();
            }
            foreach (EmrRecordInfo emrRecordInfo in lstRecord)
            {
                int i = 0;
                foreach (TagInfo tagInfo in emrRecordInfo.TagInfos)
                {
                    if (!String.IsNullOrEmpty(emrRecordInfo.TagInfos[i].DirLocation) && emrRecordInfo.DateTime == DateTime.Now.ToString("yyyy/MM/dd"))
                    {
                        tagInfo.DirLocation = emrRecordInfo.TagInfos[i].DirLocation;
                        lstTagInfos.Add(tagInfo);
                    }
                    i += 1;
                    if (tagInfo.Type != TypeEnum.Tag) continue;

                    if (string.IsNullOrEmpty(rpName))
                    {
                        if (tagInfo.TagCode.Trim().ToUpper() == "MA" || tagInfo.TagCode.Trim().ToUpper() == "MS" || tagInfo.TagCode.Trim().ToUpper() == "MI")
                        {
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                    }
                    else if (rpName.Trim().ToUpper() == B1)
                    {
                        if (tagInfo.TagCode.Trim().ToUpper() == "B1")
                        {
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                    }
                    else if (rpName.Trim().ToUpper() == B2)
                    {
                        #region Update Report VN
                        if (tagInfo.TagCode.Trim().ToUpper() == "A")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["A"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "B1")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["B1"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "B2")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["B2"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "C1")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["C1"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "C2")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["C2"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "C3")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["C3"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "C4")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["C4"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "C5")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["C5"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "C6")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["C6"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "C7")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["C7"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "C8")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["C8"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        if (tagInfo.TagCode.Trim().ToUpper() == "C9")
                        {
                            tagInfo.TagName = DataProvider.Instance.DicTemplateTagItems["C9"].ToString();
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                        #endregion
                    }
                }
            }
            return lstTagInfos;
        }

        public void AddComment()
        {
            try
            {
                int rHandle1 = gridView1.FocusedRowHandle;
                DataRow rowDt = gridView1.GetDataRow(rHandle1);
                if (rowDt != null)
                {
                    string tagId = rowDt["Id"].ToString();
                    /*TextEdit edit = gridView1.ActiveEditor as TextEdit;*/
                    //if (edit == null || edit.EditValue == null) return;
                    //AnhLT - MED-10138
                    if (rHandle1 < 0 || (_textEdit == null || _textEdit.EditValue == null /*|| string.IsNullOrEmpty(_textEdit.SelectedText)*/ || string.IsNullOrEmpty(_currentSelectedText)))
                    {
                        XMessageBox.Show(Resources.EMPTY_COMMENT_SELECTION_WARN, Resources.WARN);
                        return;
                    }
                    frmComment frm = new frmComment(tagId, string.Empty, string.Empty, true);
                    frm.CommentUpdated += new frmComment.CommentUpdateHandler(frm_CommentUpdated);
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.StackTrace);
            }
        }
        private void frm_CommentUpdated(object sender, CommentEventArgs e)
        {
            string tagId = GetSelectedRowValue(colId.ToString());
            if (e.Comment.Trim().Length > 0)
            {
                string gwa = !string.IsNullOrEmpty(UserInfo.Gwa) ? UserInfo.Gwa : _gwa;
                string gwaName = !string.IsNullOrEmpty(UserInfo.GwaName) ? UserInfo.GwaName : "";
                CommentInfo comment = new CommentInfo(tagId, UserInfo.UserID, e.Title, e.Comment, UserInfo.UserID, gwa, gwaName, _dateCacheFromServer, UserInfo.UserGubun == UserType.Doctor, _pkout);
                //HungNV start
                comment.CommentId = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
                if (this.CommentDicGetCommentData(tagId) != null)
                {
                    this.CommentDicGetCommentData(tagId).InsertComment(comment);
                }
                else
                {
                    CommentData cmmtData = new CommentData(comment);
                    this.CommentDicInsertCommentData(cmmtData);
                }
                //HungNV End
            }
        }

        private Dictionary<string, CommentData> commentDataDic = new Dictionary<string, CommentData>();
        private Dictionary<string, CommentData> commentDataTempDic = new Dictionary<string, CommentData>();
        public Dictionary<string, CommentData> CommentDataDic
        {
            get { return commentDataDic; }
        }

        /// <summary>
        /// Get Comment data from Comment data diction
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        private CommentData CommentDicGetCommentData(string tagId)
        {
            try
            {
                if (commentDataDic.ContainsKey(tagId))
                    return commentDataDic[tagId];
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        ///Add commentData to dictionary 
        /// </summary>
        /// <param name="comment"></param>
        private void CommentDicInsertCommentData(CommentData comment)
        {
            try
            {
                if (commentDataDic.ContainsKey(comment.TagId))
                {
                    commentDataDic[comment.TagId].InsertComment(comment.CommentList[0]);
                }
                else
                {
                    commentDataDic.Add(comment.TagId, comment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void DeleteCommentListByTagId(string tagId)
        {
            if (string.IsNullOrEmpty(tagId))
                return;
            CommentData cmmData = this.CommentDicGetCommentData(tagId);
            if (cmmData != null)
                cmmData.DeleteCommentsByTagId(tagId);
        }

        public string GetSelectedRowValue(string column)
        {
            string value = "";
            int rHandle1 = gridView1.FocusedRowHandle;
            DataRow rowDt = gridView1.GetDataRow(rHandle1);
            value = rowDt[column].ToString();

            return value;
        }
        /// <summary>
        /// Init data for CommentDataDic
        /// </summary>
        /// <param name="strLstCommentInfos"></param>
        private void InitCommentDataDic(string strLstCommentInfos)
        {
            //HungNV added
            commentDataDic.Clear();
            if (string.IsNullOrEmpty(strLstCommentInfos)) return;
            List<CommentInfo> commentsList = JsonConvert.DeserializeObject<List<CommentInfo>>(strLstCommentInfos);

            foreach (CommentInfo commentInfo in commentsList)
            {
                if (commentDataDic.ContainsKey(commentInfo.TagId))
                {
                    this.CommentDicGetCommentData(commentInfo.TagId).InsertComment(commentInfo);
                }
                else
                {
                    CommentData cmmtData = new CommentData(commentInfo);
                    this.CommentDicInsertCommentData(cmmtData);
                }
            }

        }
        public void DeleteOrUpdateDic(CommentInfo objCommentInfo, bool remove)
        {
            if (objCommentInfo == null) return;
            //HungNV added
            if (commentDataDic.ContainsKey(objCommentInfo.TagId))
            {
                if (remove)
                {
                    int countLst = CommentDicGetCommentData(objCommentInfo.TagId).DeleteComment(objCommentInfo.CommentId);
                    if (countLst <= 0)
                        CommentDataDic.Remove(objCommentInfo.TagId);
                }
                else
                {
                    CommentDataDic[objCommentInfo.TagId].UpdateComment(objCommentInfo);
                }
            }
            else
            {
                CommentData cmmtData = new CommentData(objCommentInfo);
                this.CommentDicInsertCommentData(cmmtData);
            }
        }

        public string GetDicCommentInfo(bool isViewer)
        {
            return GetCommentJsonData(null, isViewer);
        }

        public string GetDicCommentInfo(Dictionary<string, CommentInfo> includes)
        {
            string strLstcommentInfo = "";

            List<CommentInfo> lstCommentInfosReturn = new List<CommentInfo>();
            foreach (string tag in dicCommentInfos.Keys)
            {
                lstCommentInfosReturn.Add(dicCommentInfos[tag]);
            }

            if (includes != null)
            {
                foreach (CommentInfo info in includes.Values)
                {
                    lstCommentInfosReturn.Add(info);
                }
            }

            if (lstCommentInfosReturn.Count > 0)
            {
                JsonSerializerSettings setting = new JsonSerializerSettings();
                setting.TypeNameHandling = TypeNameHandling.Objects;
                strLstcommentInfo = JsonConvert.SerializeObject(lstCommentInfosReturn, setting);
            }
            return strLstcommentInfo;
        }

        public string GetCommentJsonData(Dictionary<string, CommentData> includes, bool isViewer)
        {
            string commentsStr = "";
            EmrRecordInfo emr = GetEmrRecordFromGrid(isViewer, UserInfo.UserID);
            if (emr.TagInfos.Count <= 0)
                return commentsStr;
            List<CommentInfo> commentLst = new List<CommentInfo>();
            foreach (CommentData commentData in commentDataDic.Values)
            {
                foreach (CommentInfo item in commentData.CommentList)
                    commentLst.Add(item);
            }

            if (includes != null)
            {
                foreach (CommentData cmmtData in includes.Values)
                {
                    foreach (CommentInfo item in cmmtData.CommentList)
                        commentLst.Add(item);
                }
            }

            if (commentLst.Count > 0)
            {
                JsonSerializerSettings setting = new JsonSerializerSettings();
                setting.TypeNameHandling = TypeNameHandling.Objects;
                commentsStr = JsonConvert.SerializeObject(commentLst, setting);
            }
            return commentsStr;
        }

        public List<CommentInfo> GetCurrentComments(string pkout)
        {
            List<CommentInfo> comments = new List<CommentInfo>();
            foreach (CommentData commentDataItem in commentDataDic.Values)
                comments.AddRange(commentDataItem.GetCommentsByPkout(pkout));

            CurrentComments = comments;
            return comments;
        }
        public List<CommentInfo> UpdateComment(string pkout, List<string> tagIds, List<CommentInfo> newCmmtList)
        {
            List<CommentInfo> newCommentList = (!string.IsNullOrEmpty(pkout) && newCmmtList != null) ? newCmmtList : GetNewCommentList();
            //List<CommentInfo> newCommentList = GetNewCommentList();
            List<CommentInfo> commentListCached = GetCommentsCached();

            if (!ListsEqual(newCommentList, commentListCached))
            {
                List<string> TagIds = (!string.IsNullOrEmpty(pkout) && tagIds != null) ? tagIds : GetCurrentTagIds();// all of tagIds on editor or U44
                //List<string> TagIds = GetCurrentTagIds();
                if (TagIds.Count <= 0)
                    return CurrentComments;
                foreach (CommentInfo item in CurrentComments)
                {
                    if (!isExistTag(item.TagId, TagIds))// if not exist tag on Editor => clear
                    {
                        foreach (CommentData commentDataItem in commentDataDic.Values)
                            commentDataItem.ClearCommentItemByID(item.CommentId);
                    }
                }
            }
            return CurrentComments;
        }

        public void UpdateComment(List<CommentInfo> currentComments)
        {
            if (currentComments.Count <= 0)
            {
                foreach (CommentData commentDataItem in commentDataDic.Values)
                    commentDataItem.ClearCommentItemByPkOut(_pkout);
                return;
            }

            if (!ListsEqual(CurrentComments, currentComments))
            {
                foreach (CommentInfo item in currentComments)
                {
                    foreach (CommentData commentDataItem in commentDataDic.Values)
                        commentDataItem.ClearCommentItemByID(item.CommentId);
                }
            }
        }

        public List<CommentInfo> GetNewCommentList()
        {
            List<CommentInfo> newCommentList = new List<CommentInfo>();
            if (string.IsNullOrEmpty(_pkout))
                return newCommentList;
            foreach (CommentData commentDataItem in commentDataDic.Values)
                newCommentList.AddRange(commentDataItem.GetCommentsByPkout(_pkout));
            return newCommentList;
        }
        public List<CommentInfo> GetCommentsCached()
        {
            string commentKey = string.Format("CACHE_EMR_RECORD_SCHEMA_{0}_{1}_{2}", UserInfo.UserID, _pkout, PatientModel.NaewonDate.Replace("/", ""));
            string commentStr = CacheService.Instance.Get<string>(commentKey);
            if (string.IsNullOrEmpty(commentStr)) return null;
            List<CommentInfo> commentsList = JsonConvert.DeserializeObject<List<CommentInfo>>(commentStr);
            return commentsList;
        }

        public void UpdateCommentsCached(string pkout)
        {
            string commentKey = string.Format("CACHE_EMR_RECORD_SCHEMA_{0}_{1}_{2}", UserInfo.UserID, pkout, PatientModel.NaewonDate.Replace("/", ""));
            string commentsDataStr = GetDicCommentInfo(false);
            CacheService.Instance.Set(commentKey, commentsDataStr, TimeSpan.MaxValue);
        }
        public bool ListsEqual(List<CommentInfo> list1, List<CommentInfo> list2)
        {
            if (list1 == null || list2 == null || list1.Count != list2.Count) return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].CommentId != list2[i].CommentId || list1[i].Pkout != list2[i].Pkout || list1[i].Comment != list2[i].Comment) return false;
            }
            return true;
        }

        private List<string> GetCurrentTagIds()
        {
            List<string> TagIds = new List<string>();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row1 = gridView1.GetDataRow(i);
                if (!string.IsNullOrEmpty(row1["PkOut"].ToString()) || !string.IsNullOrEmpty(row1["Content"].ToString()))
                    TagIds.Add(row1["Id"].ToString());
            }
            return TagIds;
        }

        public List<string> GetTagIdsByPkout(string pkOut)
        {
            List<string> TagIds = new List<string>();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row1 = gridView1.GetDataRow(i);
                if (row1["PkOut"].ToString().Equals(pkOut))
                    TagIds.Add(row1["Id"].ToString());
            }
            return TagIds;
        }

        private bool isExistTag(string tagId, List<string> tagids)
        {
            if (tagids == null || tagids.Count <= 0)
                return false;
            return tagids.Contains(tagId);
        }

        public void SetForcusedRowHandle(int rowNumber)
        {
            gridView1.FocusedRowHandle = rowNumber;
        }

        private RepositoryItemTextEdit TestMethod()
        {
            RepositoryItemTextEdit repositoryItemTextEditReadOnly = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            repositoryItemTextEditReadOnly.Name = "repositoryItemTextEditReadOnly";
            repositoryItemTextEditReadOnly.ReadOnly = true;

            return repositoryItemTextEditReadOnly;
        }

        private bool IsEditRowCellHandle(GridView view, int row)
        {
            GridColumn col = view.Columns["Type"];
            string val = Convert.ToString(view.GetRowCellValue(row, col));
            return (val == string.Empty || val == "0" || val == "1" || val == "2");
            /*TypeEnum typeItem = KeyEnum(val);
            return (typeItem == TypeEnum.Tag || typeItem == TypeEnum.Image || typeItem == TypeEnum.Pdf);*/
        }
        public void CreateCurrentDataSource()
        {
            DataTable dtTag = new DataTable();

            DataColumn dcmpk = dtTag.Columns.Add("OrderMaster", typeof(int));
            dtTag.Columns.Add("Id", typeof(string));
            dtTag.Columns.Add("TagCode", typeof(string));
            dtTag.Columns.Add("TagName", typeof(string));
            dtTag.Columns.Add("Content", typeof(object));
            dtTag.Columns.Add("Type", typeof(TypeEnum)); //(TypeEnum: string, Image, pdf)
            dtTag.Columns.Add("CreateDate", typeof(string));
            dtTag.Columns.Add("DirLocation", typeof(string));
            dtTag.Columns.Add("PkOut", typeof(string));
            dtTag.Columns.Add("HospCode", typeof(string));
            dtTag.Columns.Add("Gwa", typeof(string));
            dtTag.Columns.Add("DateTime", typeof(string));
            dtTag.Columns.Add("Doctor", typeof(string));
            dtTag.Columns.Add("DisplayOrther", typeof(string));
            dtTag.PrimaryKey = new DataColumn[] { dcmpk };

            DataTable dtOrder = new DataTable();
            dtOrder.Columns.Add("BtnDo", typeof(object));
            dtOrder.Columns.Add("InputGubunName", typeof(string));
            dtOrder.Columns.Add("OrderGubunName", typeof(string));
            dtOrder.Columns.Add("HangmogName", typeof(string));
            dtOrder.Columns.Add("Content", typeof(string));
            dtOrder.Columns.Add("OrderCurrent", typeof(int));
            DataColumn dcdfk = dtOrder.Columns.Add("ParrentTagCurrent", typeof(int));
            dtOrder.Columns.Add("GubunBass", typeof(string));
            dtOrder.Columns.Add("HangmogCode", typeof(string));
            dtOrder.Columns.Add("ActionDoYn", typeof(string));
            dtOrder.Columns.Add("Bunho", typeof(string));
            dtOrder.Columns.Add("Doctor", typeof(string));
            dtOrder.Columns.Add("Gwa", typeof(string));
            dtOrder.Columns.Add("NaewonDate", typeof(string));
            dtOrder.Columns.Add("NaewonKey", typeof(string));
            dtOrder.Columns.Add("InputTab", typeof(string));
            dtOrder.Columns.Add("InputTabAndGroupSer", typeof(string));
            dtOrder.Columns.Add("OrderDisplayOrder", typeof(object));

            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { dtTag, dtOrder });
            ds.Relations.Add("CustomerOrders", dcmpk, dcdfk);

            grdContent.DataSource = dtTag;
            currentDataSource = dtTag;
            currentDataOrder = dtOrder;
        }

        private void InitializeContextMenu()
        {
            emptyMenu.MenuItems.Add(new MenuItem(Resources.UcGrid_Lbl_Brower, new EventHandler(OnBrower)));
        }

        private void OnBrower(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CLIP";
            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                InsertImage(dialog.FileName, TypeEnum.Image, dialog.FileName, ActionType.Replace, true);
            }
        }

        /*public List<TagPrintInfo> GetListTagPrintInfo()
        {
            List<TagPrintInfo> listTagPrintInfo = new List<TagPrintInfo>();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                TagPrintInfo tagPrintInfo = new TagPrintInfo();

                DataRow row = gridView1.GetDataRow(i);

                TagInfo tagItem = GetTagByDataRow(row, i);
                if(tagItem == null) continue;
                tagPrintInfo.TagCode = tagItem.TagCode;
                tagPrintInfo.TagName = tagItem.TagName;
                tagPrintInfo.TagContent = tagItem.Type != TypeEnum.Image ? tagItem.Content.ToString() : "";
                tagPrintInfo.IsImage = tagItem.Type == TypeEnum.Image;

                tagPrintInfo.ImageLink = "file:///" + tagItem.DirLocation;

                listTagPrintInfo.Add(tagPrintInfo);
            }

            return listTagPrintInfo;
        }*/
        #endregion
    }
    
    public class UpdateCommentsAgr : EventArgs
    {
        private string _pkout;
        public UpdateCommentsAgr(string pkout)
        {
            _pkout = pkout;
        }
    }
}
