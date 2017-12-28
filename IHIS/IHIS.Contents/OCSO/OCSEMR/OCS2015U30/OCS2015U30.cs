using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.Framework;
using System.Threading;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Results;
using Newtonsoft.Json;
using System.Reflection;
using OCS2015U30.Models;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.OCSO.Properties;

//namespace OCS2015U30
namespace IHIS.OCSO
{
    public partial class OCS2015U30 : IHIS.Framework.XScreen
    {
        #region Contructor
        public OCS2015U30()
        {
            InitializeComponent();
            btnList.SetEnabled(FunctionType.Reset, false);
            btnList.FunctionItems.Remove(FunctionType.Reset);
            InitializeCloud();
            //grdRootTag.QueryLayout(false);
            grdNodeTags.QueryLayout(false);
            InitCboGrdTagType();
            CheckPermission();
            /*tlbRootTag.Text = Resource.EMR_U307;
            tlbNodeTag.Text = Resource.EMR_U308;*/
        }

        private void InitializeCloud()
        {
            /*#region grdRootTag
            grdRootTag.ParamList = new List<string>(new string[]
                {
                    "tag_level",
                    "sys_id"
                });
            grdRootTag.ExecuteQuery = GetgrdRootTag;
            #endregion*/

            #region grdNodeTag
            grdNodeTags.ParamList = new List<string>(new string[]
                {
                    "tag_level",
                    "sys_id"
                });
            grdNodeTags.ExecuteQuery = GetgrdNodeTag;
            #endregion

            this.mOrderBiz = new IHIS.OCS.OrderBiz(TypeCheck.NVL("OSC2015U30", this.Name).ToString());
        }

        private void InitCboGrdTagType()
        {
            _dtGrdCbo = new DataTable();
            _dtGrdCbo.Columns.Add("DisplayName", typeof(string));
            _dtGrdCbo.Columns.Add("Name", typeof(string));
            _dtGrdCbo.Rows.Add("R", "ROOT");
            _dtGrdCbo.Rows.Add("N", "NODE");

            this.grdNodeTags.SetComboItems(Tag_Level, _dtGrdCbo, "Name", "Name");
        }
        #endregion

        #region Field & Properties

        private DataTable _dtGrdCbo;
        private const string Tag_Level = "tagLevel";
        private const string LBLRoot = "ROOT";
        private const string LBLNode = "NODE";
        private const string Root = "R";
        private const string Node = "N";
        private IHIS.OCS.OrderBiz mOrderBiz = null;
        TableList<TagData> lRootTagObj = new TableList<TagData>();
        private bool _isModified = false;
        private const string USER_GROUP = "user_group";
        private const string SYS_ID = "sys_id";
        private const string TAG_ID = "tagId";
        private const string TAG_CODE = "tagCode";
        private const string TAG_NAME = "tagName";
        private const string DISPLAY_TXT = "displayTxt";
        private const string MEMO = "memo";
        private const string FILTER = "filter";
        private const string TEMPLATE_CONTENT = "templateContent";
        private const string TAG_PARENT = "tagParent";
        private const string ADMIN = "ADMIN";
        private List<OCS2015U30EmrTagSaveLayoutInfo> lstTagRoot = new List<OCS2015U30EmrTagSaveLayoutInfo>();
        private List<OCS2015U30EmrTagSaveLayoutInfo> lstTagNode = new List<OCS2015U30EmrTagSaveLayoutInfo>();
        #endregion

        #region Event
        private void OCS2015U30_Load(object sender, EventArgs e)
        {

        }

        private void grdNodeTags_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string prevFilterValue = grdNodeTags.GetItemString(e.RowNumber, FILTER, DataBufferType.PreviousBuffer).ToString();
            string prevTagCodeValue = grdNodeTags.GetItemValue(e.RowNumber, TAG_CODE, DataBufferType.PreviousBuffer).ToString();
            string prevTagNameValue = grdNodeTags.GetItemValue(e.RowNumber, TAG_NAME, DataBufferType.PreviousBuffer).ToString();
            string prevDisplayTxtValue = grdNodeTags.GetItemValue(e.RowNumber, DISPLAY_TXT, DataBufferType.PreviousBuffer).ToString();
            string prevTagLevel = grdNodeTags.GetItemString(e.RowNumber, Tag_Level, DataBufferType.PreviousBuffer).ToString();
            string prevMemoValue = grdNodeTags.GetItemValue(e.RowNumber, MEMO, DataBufferType.PreviousBuffer).ToString();
            string prevTagParentValue = grdNodeTags.GetItemValue(e.RowNumber, TAG_PARENT, DataBufferType.PreviousBuffer).ToString();
            //Check permission
            if (UserInfo.UserGroup.ToString() != ADMIN && UserInfo.UserID != grdNodeTags.GetItemString(e.RowNumber, SYS_ID))
            {
                grdNodeTags.SetItemValue(e.RowNumber, FILTER, prevFilterValue);
                grdNodeTags.SetItemValue(e.RowNumber, TAG_CODE, prevTagCodeValue);
                grdNodeTags.SetItemValue(e.RowNumber, TAG_NAME, prevTagNameValue);
                grdNodeTags.SetItemValue(e.RowNumber, DISPLAY_TXT, prevDisplayTxtValue);
                grdNodeTags.SetItemValue(e.RowNumber, Tag_Level, prevTagLevel);
                grdNodeTags.SetItemValue(e.RowNumber, TAG_PARENT, prevTagParentValue);
                grdNodeTags.SetItemValue(e.RowNumber, MEMO, prevMemoValue);
                XMessageBox.Show(Resource.EMR_M002, Resource.EMR_M004, MessageBoxIcon.Warning);
                return;
            }

            //Validate input data when add tag
            if (this.grdNodeTags.GetRowState(int.Parse(e.RowNumber.ToString())) == DataRowState.Added && !ValidateNodeTagData())
            {
                grdNodeTags.SetItemValue(e.RowNumber, FILTER, prevFilterValue);
                grdNodeTags.SetItemValue(e.RowNumber, TAG_CODE, prevTagCodeValue);
                grdNodeTags.SetItemValue(e.RowNumber, TAG_NAME, prevTagNameValue);
                grdNodeTags.SetItemValue(e.RowNumber, DISPLAY_TXT, prevDisplayTxtValue);
                grdNodeTags.SetItemValue(e.RowNumber, Tag_Level, prevTagLevel);
                grdNodeTags.SetItemValue(e.RowNumber, TAG_PARENT, prevTagParentValue);
                grdNodeTags.SetItemValue(e.RowNumber, MEMO, prevMemoValue);

                grdNodeTags.SetFocusToItem(e.RowNumber, TAG_CODE);
                return;
            }

            if (e.ColName.ToString() == TAG_NAME)
            {
                string displayTxt = this.grdNodeTags.GetItemString(e.RowNumber, TAG_NAME).ToString();
                if (displayTxt.Length > 16)
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M14, " " + 16 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    this.grdNodeTags.SetFocusToItem(e.RowNumber, TAG_NAME);
                }
            }

            if (e.ColName.ToString() == MEMO)
            {
                string displayTxt = this.grdNodeTags.GetItemString(e.RowNumber, MEMO).ToString();
                if (displayTxt.Length > 128)
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M14, " " + 128 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    this.grdNodeTags.SetFocusToItem(e.RowNumber, MEMO);
                }
            }

            if (this.grdNodeTags.GetItemString(e.RowNumber, DISPLAY_TXT).ToString() == "")
                this.grdNodeTags.SetItemValue(e.RowNumber, DISPLAY_TXT, this.grdNodeTags.GetItemString(e.RowNumber, TAG_NAME).ToString());
        }

        /*private void grdRootTag_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string prevFilterValue = grdRootTag.GetItemString(e.RowNumber, FILTER, DataBufferType.PreviousBuffer).ToString();
            string prevTagCodeValue = grdRootTag.GetItemValue(e.RowNumber, TAG_CODE, DataBufferType.PreviousBuffer).ToString();
            string prevTagNameValue = grdRootTag.GetItemValue(e.RowNumber, TAG_NAME, DataBufferType.PreviousBuffer).ToString();
            string prevDisplayTxtValue = grdRootTag.GetItemValue(e.RowNumber, DISPLAY_TXT, DataBufferType.PreviousBuffer).ToString();
            string prevMemoValue = grdRootTag.GetItemValue(e.RowNumber, MEMO, DataBufferType.PreviousBuffer).ToString();

            //Validate input data when add tag
            if (this.grdRootTag.GetRowState(int.Parse(e.RowNumber.ToString())) == DataRowState.Added && !ValidateRootTagData())
            {
                RollBackData(sender, e);
                return;
            }

            if (this.grdRootTag.GetItemString(e.RowNumber, TAG_CODE).ToString().Trim().Length > 1)
            {
                XMessageBox.Show(string.Format(Resource.CMO_M14, " " + 1 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                RollBackData(sender, e);
                return;
            }

            if (e.ColName.ToString() == TAG_NAME)
            {
                string displayTxt = this.grdRootTag.GetItemString(e.RowNumber, TAG_NAME).ToString();
                if (displayTxt.Length > 16)
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M14, " " + 16 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                }
            }

            if (e.ColName.ToString() == MEMO)
            {
                string displayTxt = this.grdRootTag.GetItemString(e.RowNumber, MEMO).ToString();
                if (displayTxt.Length > 128)
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M14, " " + 128 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                }
            }

            if (this.grdRootTag.GetItemString(e.RowNumber, DISPLAY_TXT).ToString() == "")
                this.grdRootTag.SetItemValue(e.RowNumber, DISPLAY_TXT, this.grdRootTag.GetItemString(e.RowNumber, TAG_NAME).ToString());
        }*/
        #endregion

        #region Method
        #region Action Handler
        private void Add(object sender, ButtonClickEventArgs e)
        {
            e.IsBaseCall = false;
            this.grdNodeTags.GridColumnChanged -= grdNodeTags_GridColumnChanged;
            int rowNum = 0;
            if (this.CurrMQLayout == this.grdNodeTags)
            {
                rowNum = this.grdNodeTags.InsertRow(-1);
                int a = this.grdNodeTags.CurrentRowNumber - 1;
                string tagLevelNameCr = this.grdNodeTags.GetItemString(a, Tag_Level);
                this.grdNodeTags.SetItemValue(rowNum, SYS_ID, UserInfo.UserID);
                this.grdNodeTags.SetFocusToItem(rowNum, TAG_CODE);
                this.grdNodeTags.SetItemValue(rowNum, DISPLAY_TXT, string.Empty);
                //todo: fix Level Type
                this.grdNodeTags.SetItemValue(rowNum, Tag_Level, LBLRoot);
            }
            else
            {
                if (UserInfo.UserGroup.ToString() != ADMIN)
                {
                    this.grdNodeTags.GridColumnChanged += grdNodeTags_GridColumnChanged;
                    return;
                }
                /*rowNum = this.grdRootTag.InsertRow(-1);
                this.grdRootTag.SetItemValue(rowNum, DISPLAY_TXT, string.Empty);
                this.grdRootTag.SetFocusToItem(rowNum, TAG_CODE);*/
            }
            this.grdNodeTags.GridColumnChanged += grdNodeTags_GridColumnChanged;
        }

        private void Delete(object sender, ButtonClickEventArgs e)
        {
            if (this.CurrMQLayout == this.grdNodeTags)
            {
                if (UserInfo.UserGroup.ToString() != ADMIN && UserInfo.UserID != grdNodeTags.GetItemString((this.grdNodeTags.FocusCell.Grid).CurrentRowNumber, SYS_ID))
                {
                    e.IsBaseCall = false;
                    XMessageBox.Show(Resource.EMR_M002, Resource.EMR_M004, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (UserInfo.UserGroup.ToString() != ADMIN)
                {
                    e.IsBaseCall = false;
                    XMessageBox.Show(Resource.EMR_M003, Resource.EMR_M004, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        private void SaveData()
        {
            _isModified = false;
            OCS2015U30EmrTagSaveLayoutArgs args = new OCS2015U30EmrTagSaveLayoutArgs();
            args.UserId = UserInfo.UserID;
            args.UserGroup = UserInfo.UserGroup.ToString();
            args.SaveLayoutRootItem = GetListDataForSaveLayout(true);
            args.SaveLayoutNodeItem = GetListDataForSaveLayout(false);

            if (ValidateData())
            {
                if (!_isModified) return;
                //DialogResult dr = XMessageBox.Show(Resource.CMO_M004, Resource.EMR_M004, MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button2, MessageBoxIcon.Asterisk);
                //if (dr == DialogResult.Cancel) return;
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS2015U30EmrTagSaveLayoutArgs>(args);
                if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                {
                    XMessageBox.Show(Resource.CMO_M005, string.Empty, MessageBoxIcon.Information);
                    /*this.grdRootTag.ResetUpdate();*/
                    this.grdNodeTags.ResetUpdate();
                    this.btnList.PerformClick(FunctionType.Query);
                }
                else
                    XMessageBox.Show(Resource.CMO_M006, string.Empty, MessageBoxIcon.Asterisk);
            }
        }
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = true;
                    SaveData();
                    break;
                case FunctionType.Insert:
                    Add(sender, e);
                    break;
                case FunctionType.Delete:
                    Delete(sender, e);
                    break;
                case FunctionType.Close:
                    break;
                default:
                    break;
            }
        }
        private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                //초기화가 된 후 포커스 마스터 그리드로..
                case FunctionType.Reset:
                    //this.CurrMQLayout = this.grdMcode;
                    break;
                default:
                    break;
            }
        }
        private void grdNodeTags_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            //((XFindBox)((XEditGridCell)grdNodeTags.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grdNodeTags.GetItemString(e.RowNumber, "tagParent"));
            ChoseTagParent frChoseParent = new ChoseTagParent(this, grdNodeTags.CurrentRowNumber, e.ColName, ((XEditGridCell)grdNodeTags.CellInfos[e.ColName]).CellEditor.Editor.DataValue.ToString(), lRootTagObj.GetDataTable());
            frChoseParent.FormBorderStyle = FormBorderStyle.FixedDialog;
            frChoseParent.MaximizeBox = false;
            frChoseParent.MinimizeBox = false;
            frChoseParent.StartPosition = FormStartPosition.CenterParent;
            frChoseParent.ShowDialog();
        }
        internal void GrdSetItemValue(int currentRowNumber, string colName, string value)
        {
            this.grdNodeTags.SetItemValue(currentRowNumber, colName, value);
        }
        private void grdTag_MouseClick(object sender, MouseEventArgs e)
        {
            sender = (XEditGrid)sender;
        }

        #endregion

        #region Validate Data
        private bool ValidateData()
        {
            if (UserInfo.UserGroup.ToString() == ADMIN)
            {
                /*int rowCount1 = 0;
                for (int i = 0; i < this.grdRootTag.RowCount; i++)
                {
                    if (!string.IsNullOrEmpty(this.grdRootTag.GetItemString(i, TAG_CODE).ToString()))
                        rowCount1++;
                }
                //Validate Root tags
                for (int i = 0; i < this.grdRootTag.RowCount; i++)
                {
                    if (string.IsNullOrEmpty(this.grdRootTag.GetItemString(i, TAG_CODE).ToString()))
                    {
                        XMessageBox.Show(string.Format(Resource.CMO_M001, " " + Resource.EMR_U302 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (this.grdRootTag.GetItemString(i, TAG_CODE).ToString().Trim().Length > 1)
                    {
                        XMessageBox.Show(Resource.EMR_M001, Resource.EMR_M004, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (string.IsNullOrEmpty(this.grdRootTag.GetItemString(i, TAG_NAME).ToString()))
                    {
                        XMessageBox.Show(string.Format(Resource.CMO_M001, " " + Resource.EMR_U303 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);

                        return false;
                    }

                    if (this.grdRootTag.GetItemString(i, TAG_NAME).ToString().Length > 16)
                    {
                        XMessageBox.Show(string.Format(Resource.CMO_M14, " " + 16 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                        this.grdRootTag.SetFocusToItem(i, TAG_NAME);
                        return false;
                    }
                    if (this.grdRootTag.GetItemString(i, MEMO).ToString().Length > 128)
                    {
                        XMessageBox.Show(string.Format(Resource.CMO_M14, " " + 128 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                        this.grdRootTag.SetFocusToItem(i, MEMO);
                        return false;
                    }
                }*/
            }
            int rowCount2 = 0;
            for (int i = 0; i < this.grdNodeTags.RowCount; i++)
            {
                if (!string.IsNullOrEmpty(this.grdNodeTags.GetItemString(i, TAG_CODE).ToString()))
                    rowCount2++;
            }
            //Validate node tags
            for (int j = 0; j < this.grdNodeTags.RowCount; j++)
            {
                //if (this.grdNodeTags.GetRowState(j) == DataRowState.Unchanged) continue;
                if (string.IsNullOrEmpty(this.grdNodeTags.GetItemString(j, TAG_CODE).ToString()))
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M001, " " + Resource.EMR_U302 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    grdNodeTags.SetFocusToItem(j, TAG_CODE);
                    return false;
                }

                // 2016.03.03 AnhNV fixed https://sofiamedix.atlassian.net/browse/MED-7775
                // AnhLT: https://sofiamedix.atlassian.net/browse/MED-7769
                //if (this.grdNodeTags.GetItemString(j, Tag_Level) == LBLRoot && this.grdNodeTags.GetItemString(j, TAG_CODE).ToString().Trim().Length > 1)
                //{
                //    XMessageBox.Show(string.Format(Resource.CMO_M14, 1), Resource.EMR_M004, MessageBoxIcon.Warning);
                //    grdNodeTags.SetFocusToItem(j, TAG_CODE);
                //    return false;
                //}

                if (string.IsNullOrEmpty(this.grdNodeTags.GetItemString(j, TAG_NAME).ToString()))
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M001, " " + Resource.EMR_U303 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    grdNodeTags.SetFocusToItem(j, TAG_NAME);
                    return false;
                }

                if (string.IsNullOrEmpty(this.grdNodeTags.GetItemString(j, Tag_Level).ToString()))
                {
                    XMessageBox.Show(Resource.EMR_M0009, Resource.EMR_M004, MessageBoxIcon.Warning);
                    grdNodeTags.SetFocusToItem(j, Tag_Level);
                    return false;
                }

                /*//bug https://sofiamedix.atlassian.net/browse/MED-7769
                if (grdNodeTags.GetItemString(j, Tag_Level).ToString(CultureInfo.InvariantCulture) == Root && grdNodeTags.GetItemString(j, TAG_CODE).ToString(CultureInfo.InvariantCulture).Length > 1)
                {
                    XMessageBox.Show(Resource.EMR_M0008, Resource.EMR_M004, MessageBoxIcon.Warning);
                    this.grdNodeTags.SetFocusToItem(j, Tag_Level);
                    return false;
                }*/

                if (this.grdNodeTags.GetItemString(j, TAG_NAME).ToString().Length > 16)
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M14, " " + 16 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    this.grdNodeTags.SetFocusToItem(j, TAG_NAME);
                    return false;
                }

                if (this.grdNodeTags.GetItemString(j, MEMO).ToString().Length > 128)
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M14, " " + 128 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    this.grdNodeTags.SetFocusToItem(j, MEMO);
                    return false;
                }
            }
            return true;
        }

        /*private bool ValidateRootTagData()
        {
            int rowCount = 0;
            for (int i = 0; i < this.grdRootTag.RowCount; i++)
            {
                if (!string.IsNullOrEmpty(this.grdRootTag.GetItemString(i, TAG_CODE).ToString()))
                    rowCount++;
            }
            //Validate Root tags
            for (int i = 0; i < this.grdRootTag.RowCount; i++)
            {
                //Check existed
                if (this.IsExisted(this.grdRootTag.GetItemString(i, TAG_CODE).ToString(), i, rowCount, true))
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M002, " " + Resource.EMR_U302 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }*/

        private bool ValidateNodeTagData()
        {
            int rowCount = 0;
            for (int i = 0; i < this.grdNodeTags.RowCount; i++)
            {
                if (!string.IsNullOrEmpty(this.grdNodeTags.GetItemString(i, TAG_CODE).ToString()))
                    rowCount++;
            }
            //Validate node tags
            for (int j = 0; j < this.grdNodeTags.RowCount; j++)
            {
                //Check existed
                if (this.IsExisted(this.grdNodeTags.GetItemString(j, TAG_CODE).ToString(), j, rowCount, false))
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M002, " " + Resource.EMR_U302 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    this.grdNodeTags.SetFocusToItem(j, TAG_CODE);
                    return false;
                }
            }
            return true;
        }

        private bool IsExisted(string tagCode, int index, int length, bool isRootTag)
        {
            for (int i = index; i < length; i++)
            {
                if (isRootTag) //Check exist for root tags
                {
                    /*for (int j = i + 1; j < this.grdRootTag.RowCount; j++)
                    {
                        if (this.grdRootTag.GetItemString(j, TAG_CODE).ToString().Trim() == tagCode.Trim()) return true;
                    }*/
                }
                else //Check exist for node tags
                {
                    for (int k = i + 1; k < this.grdNodeTags.RowCount; k++)
                    {
                        if (this.grdNodeTags.GetItemString(k, TAG_CODE).ToString().Trim() == tagCode.Trim()) return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region RootTag
        private IList<object[]> GetgrdRootTag(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS2015U30EmrTagGetTagArgs args = new OCS2015U30EmrTagGetTagArgs();
            args.TagLevel = bvc["tag_level"].VarValue;
            args.SysId = bvc["sys_id"].VarValue;
            OCS2015U30EmrTagGetTagResult res = CloudService.Instance.Submit<OCS2015U30EmrTagGetTagResult, OCS2015U30EmrTagGetTagArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                lRootTagObj.Clear();
                res.GridTagItemInfo.ForEach(delegate(OCS2015U30EmrTagGetTagInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.TagId,
                        (item.FilterFlg.ToString() == "1") ? "Y" : "N",
                        item.TagCode,
                        item.TagName,
                        item.TagDisplayText,
                        item.Description
                    });

                    lRootTagObj.Add(new TagData(item.TagId, item.TagCode, item.TagName));
                });
            }
            return lObj;
        }

        /*private void grdRootTag_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdRootTag.Reset();
            this.grdRootTag.SetBindVarValue("tag_level", Root);
            this.grdRootTag.SetBindVarValue("sys_id", UserInfo.UserID);
        }*/
        #endregion

        #region NodeTags
        private IList<object[]> GetgrdNodeTag(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            IList<object[]> lObjRoot = new List<object[]>();
            IList<object[]> lObjNode = new List<object[]>();
            OCS2015U30EmrTagGetTagArgs args = new OCS2015U30EmrTagGetTagArgs();
            args.TagLevel = bvc["tag_level"].VarValue;
            args.SysId = bvc["sys_id"].VarValue;
            OCS2015U30EmrTagGetTagResult res = CloudService.Instance.Submit<OCS2015U30EmrTagGetTagResult, OCS2015U30EmrTagGetTagArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS2015U30EmrTagGetTagInfo itemTagGetTagInfo in res.GridTagItemInfo)
                {
                    if (itemTagGetTagInfo.TagLevel == Root)
                    {
                        lObjRoot.Add(new object[]
                        {
                            itemTagGetTagInfo.TagId,
                            itemTagGetTagInfo.TagCode,
                            itemTagGetTagInfo.TagName,
                            itemTagGetTagInfo.TagDisplayText,
                            //itemTagGetTagInfo.TagLevel,
                            LBLRoot,
                            (itemTagGetTagInfo.FilterFlg.ToString() == "1") ? "Y" : "N",
                            itemTagGetTagInfo.Description,
                            itemTagGetTagInfo.TagParent,
                            itemTagGetTagInfo.SysId
                        });
                    }
                    else
                    {
                        lObjNode.Add(new object[]
                        {
                            itemTagGetTagInfo.TagId,
                            itemTagGetTagInfo.TagCode,
                            itemTagGetTagInfo.TagName,
                            itemTagGetTagInfo.TagDisplayText,
                            /*itemTagGetTagInfo.TagLevel,*/
                            LBLNode,
                            (itemTagGetTagInfo.FilterFlg.ToString() == "1") ? "Y" : "N",
                            itemTagGetTagInfo.Description,
                            itemTagGetTagInfo.TagParent,
                            itemTagGetTagInfo.SysId
                        });
                    }
                }

                ((List<object[]>)lObj).AddRange(lObjRoot);
                ((List<object[]>)lObj).AddRange(lObjNode);

                /*res.GridTagItemInfo.ForEach(delegate(OCS2015U30EmrTagGetTagInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.TagId,
                        item.TagCode,
                        item.TagName,
                        item.TagDisplayText,
                        item.TagLevel,
                        (item.FilterFlg.ToString() == "1") ? "Y" : "N",
                        item.Description,
                        item.TagParent,
                        item.SysId
                    });
                });*/
            }
            
            return lObj;
        }

        private void grdNodeTags_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNodeTags.Reset();
            this.grdNodeTags.SetBindVarValue("tag_level", Node);
            this.grdNodeTags.SetBindVarValue("sys_id", UserInfo.UserID);
        }
        #endregion

        #region GetListDataForSaveLayout
        private List<OCS2015U30EmrTagSaveLayoutInfo> GetListDataForSaveLayout(bool isRootTag)
        {
            List<OCS2015U30EmrTagSaveLayoutInfo> lstData = new List<OCS2015U30EmrTagSaveLayoutInfo>();
            lstTagNode = new List<OCS2015U30EmrTagSaveLayoutInfo>();
            lstTagRoot = new List<OCS2015U30EmrTagSaveLayoutInfo>();
            if (isRootTag)
            {

                /*string codeType = grdRootTag.GetItemString(grdRootTag.CurrentRowNumber, TAG_ID);

                for (int i = 0; i < this.grdRootTag.RowCount; i++)
                {
                    // Skip unchanged rows
                    if (grdRootTag.GetRowState(i) == DataRowState.Unchanged) continue;
                    OCS2015U30EmrTagSaveLayoutInfo item = new OCS2015U30EmrTagSaveLayoutInfo();
                    item.TagId = grdRootTag.GetItemString(i, TAG_ID);
                    item.TagCode = grdRootTag.GetItemString(i, TAG_CODE);
                    item.TagName = grdRootTag.GetItemString(i, TAG_NAME);
                    item.FilterFlg = grdRootTag.GetItemString(i, FILTER);
                    item.TagDisplayText = grdRootTag.GetItemString(i, DISPLAY_TXT);
                    item.Description = grdRootTag.GetItemString(i, MEMO);
                    item.RowState = grdRootTag.GetRowState(i).ToString();
                    lstData.Add(item);
                    if (item.RowState != DataRowState.Unchanged.ToString() && !_isModified)
                        _isModified = true;
                }

                if (null != grdRootTag.DeletedRowTable)
                {
                    for (int i = 0; i < grdRootTag.DeletedRowTable.Rows.Count; i++)
                    {
                        OCS2015U30EmrTagSaveLayoutInfo item = new OCS2015U30EmrTagSaveLayoutInfo();
                        item.TagId = Convert.ToString(grdRootTag.DeletedRowTable.Rows[i][TAG_ID]);
                        item.RowState = DataRowState.Deleted.ToString();
                        lstData.Add(item);
                    }
                    if (grdRootTag.DeletedRowTable.Rows.Count > 0 && !_isModified)
                        _isModified = true;
                }*/
            }
            else
            {
                string codeType = grdNodeTags.GetItemString(grdNodeTags.CurrentRowNumber, TAG_ID);

                for (int i = 0; i < this.grdNodeTags.RowCount; i++)
                {
                    // Skip unchanged rows
                    if (grdNodeTags.GetRowState(i) == DataRowState.Unchanged) continue;
                    OCS2015U30EmrTagSaveLayoutInfo item = new OCS2015U30EmrTagSaveLayoutInfo();
                    item.TagId = grdNodeTags.GetItemString(i, TAG_ID);
                    item.TagCode = grdNodeTags.GetItemString(i, TAG_CODE);
                    item.TagName = grdNodeTags.GetItemString(i, TAG_NAME);
                    item.FilterFlg = string.IsNullOrEmpty(grdNodeTags.GetItemString(i, FILTER)) ? "N" : grdNodeTags.GetItemString(i, FILTER);
                    string tagLevel = grdNodeTags.GetItemString(i, Tag_Level);
                    if (tagLevel == LBLRoot)
                    {
                        item.TagLevel = Root;
                    }
                    else
                    {
                        item.TagLevel = Node;
                    }
                    item.TagParent = grdNodeTags.GetItemString(i, TAG_PARENT);
                    item.TagDisplayText = grdNodeTags.GetItemString(i, DISPLAY_TXT);
                    item.Description = grdNodeTags.GetItemString(i, MEMO);
                    item.SysId = grdNodeTags.GetItemString(i, SYS_ID);
                    //Check permission
                    if (UserInfo.UserGroup.ToString() != ADMIN && UserInfo.UserID != grdNodeTags.GetItemString(i, SYS_ID))
                        item.RowState = DataRowState.Unchanged.ToString();
                    else
                    {
                        item.RowState = grdNodeTags.GetRowState(i).ToString();
                        lstData.Add(item);
                    }

                    if (item.TagLevel == Root)
                    {
                        lstTagRoot.Add(item);
                    }
                    else if (item.TagLevel == Node)
                    {
                        lstTagNode.Add(item);
                    }

                    if (item.RowState != DataRowState.Unchanged.ToString() && !_isModified)
                        _isModified = true;
                }

                if (null != grdNodeTags.DeletedRowTable)
                {
                    for (int i = 0; i < grdNodeTags.DeletedRowTable.Rows.Count; i++)
                    {
                        OCS2015U30EmrTagSaveLayoutInfo item = new OCS2015U30EmrTagSaveLayoutInfo();
                        item.TagId = Convert.ToString(grdNodeTags.DeletedRowTable.Rows[i][TAG_ID]);
                        item.RowState = DataRowState.Deleted.ToString();
                        item.SysId = Convert.ToString(grdNodeTags.DeletedRowTable.Rows[i][SYS_ID]);
                        lstData.Add(item);
                    }
                    if (grdNodeTags.DeletedRowTable.Rows.Count > 0 && !_isModified)
                        _isModified = true;
                }
            }
            return lstData;
        }
        #endregion

        private void CheckPermission()
        {
            //this.grdRootTag.ReadOnly = (UserInfo.UserGroup.ToString() == ADMIN) ? false : true;
        }

        /*private void RollBackData(object sender, GridColumnChangedEventArgs e)
        {
            string prevFilterValue = grdRootTag.GetItemString(e.RowNumber, FILTER, DataBufferType.PreviousBuffer).ToString();
            string prevTagCodeValue = grdRootTag.GetItemValue(e.RowNumber, TAG_CODE, DataBufferType.PreviousBuffer).ToString();
            string prevTagNameValue = grdRootTag.GetItemValue(e.RowNumber, TAG_NAME, DataBufferType.PreviousBuffer).ToString();
            string prevDisplayTxtValue = grdRootTag.GetItemValue(e.RowNumber, DISPLAY_TXT, DataBufferType.PreviousBuffer).ToString();
            string prevMemoValue = grdRootTag.GetItemValue(e.RowNumber, MEMO, DataBufferType.PreviousBuffer).ToString();
            grdRootTag.SetItemValue(e.RowNumber, FILTER, prevFilterValue);
            grdRootTag.SetItemValue(e.RowNumber, TAG_CODE, prevTagCodeValue);
            grdRootTag.SetItemValue(e.RowNumber, TAG_NAME, prevTagNameValue);
            grdRootTag.SetItemValue(e.RowNumber, DISPLAY_TXT, prevDisplayTxtValue);
            grdRootTag.SetItemValue(e.RowNumber, MEMO, prevMemoValue);
        }*/
        #endregion
    }
}
