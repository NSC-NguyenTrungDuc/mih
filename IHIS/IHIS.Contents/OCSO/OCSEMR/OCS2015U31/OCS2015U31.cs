using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EmrDocker.Glossary;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Messaging;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using System.Reflection;
using System.Text.RegularExpressions;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.OCSO.Properties;
using Microsoft.SqlServer.Server;
using OCS2015U31EmrTagGetTagInfo = IHIS.CloudConnector.Contracts.Models.OcsEmr.OCS2015U31EmrTagGetTagInfo;
using OCS2015U31GetADM3200UserInfo = IHIS.CloudConnector.Contracts.Models.OcsEmr.OCS2015U31GetADM3200UserInfo;
using OCS2015U31GetEmrTemplateInfo = IHIS.CloudConnector.Contracts.Models.OcsEmr.OCS2015U31GetEmrTemplateInfo;
using OCS2015U31GetTemplateTagsInfo = IHIS.CloudConnector.Contracts.Models.OcsEmr.OCS2015U31GetTemplateTagsInfo;

namespace IHIS.OCSO
{
    public partial class OCS2015U31 : IHIS.Framework.XScreen
    {
        #region Field & properties
        private IList<object[]> lTagObj = new List<object[]>();
        IList<object[]> lGrdCboObj = new List<object[]>();
        private List<OCS2015U31EmrTagGetTagInfo> originalTagLst = new List<OCS2015U31EmrTagGetTagInfo>();
        private Dictionary<string, List<string>> currentTagCollection = new Dictionary<string, List<string>>();
        private string _templateName = string.Empty;
        private string _userId = string.Empty;
        private string _userGroup = string.Empty;
        private static Dictionary<int, string> _tagCollection = new Dictionary<int, string>();
        private DataTable _dtTemplateCbo = new DataTable();
        private string _currentTemplateId = string.Empty;
        private string _currentSysId = string.Empty;
        private string _currentTemRowNum = "0";
        private int _temIndex = -1;
        private bool _isModified = false;
        private bool _isProcess = false;
        private bool _isAddParentRecord = false;
        private const string TEMPLATE_ID = "templateId";
        private const string TEMPLATE_TYPE = "templateType";
        private const string TYPE_NAME = "typeName";
        private const string USER_ID = "user_id";
        private const string USER_GROUP = "user_group";
        private const string TEMPLATE_CODE = "templateCode";
        private const string TEMPLATE_NAME = "templateName";
        private const string DESCRIPTION = "description";
        private const string SYS_ID = "sys_id";
        private const string DEFAULT_FLG = "default_Flg";
        private const string TAG_CODE = "tagCode";
        private const string TAG_NAME = "tagName";
        private const string TAG_LEVEL = "tagLevel";
        private const string TYPE = "type";
        private const string TEXT = "Text";
        private const string IMAGE = "Image";
        private const string COL_DEFAULT_CONTENT = "defaultContent";
        private const string COL_URLLOCATION = "urlLocation";
        private const string BINARY = "binary";
        /*private const string BUNHO = "1000123888";*/
        private const string BUNHO = "emr_template";
        /*private const string ROOT = "ROOT";
        private const string NODE = "NODE";*/
        private const string ROOT = "R";
        private const string NODE = "N";
        private const string DISPLAY_TXT = "displayTxt";
        private const string MEMO = "memo";
        private const string STR_TAG_CODE = "str_tag_code";
        private const string TEMPLATE_CONTENT = "templateContent";
        private const string TEM_ID = "temId";
        private const string ADMIN = "ADMIN";
        private const string TAG_PARENT = "tagParent";
        private string departCode = "";
        private string doctorCode = "";
        private bool isCheckLoad = false;
        private int _countGrdDocAndDepart ;
        private bool isCheckInsert = false;
        private bool isCheckInsertDocAndDep = true;
        private bool isCheckDeleComTemplate = false;
        private DataTable _dtGrdCbo;
        private static readonly MD5 md5 = MD5.Create();
        private Dictionary<string, string> mediaDictionary = new Dictionary<string, string>();

        #endregion

        #region Contractor
        public OCS2015U31()
        {
            InitializeComponent();
            ApplyFont();
            btnList.SetEnabled(FunctionType.Reset, false);
            btnList.FunctionItems.Remove(FunctionType.Reset);
            //this.GetTemplateTypeCbo();
            this.InitializeCloud();
            InitCboGrdTagType();
            CheckUserAdminLogin();
            this.grdUser.QueryLayout(false);
            this.grdTemplate.QueryLayout(false);
            this.InitTemplateTypeCbo();
            this.InitAllTags();
            _tagCollection.Clear();
            this.InitTagCollection();
            this.InitTemplateTags();
            this.grdUser.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdUser_RowFocusChanged);
            this.grdTemplate.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdTemplate_RowFocusChanged);
            QueryGrdTag();           
            QueryComboboxData();
            //this.grdTags.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdTags_RowFocusChanged);

            //this.InitCboItemType();
            //tlbtemplate.Text = Resource.EMR_U313;
            //tlbTags.Text = Resource.EMR_U314;

        }
        #endregion

        private void ApplyFont()
        {
            if (NetInfo.Language == LangMode.Vi || NetInfo.Language == LangMode.En)
            {
                ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdTemplate)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdTags)).BeginInit();

                this.grdUser.RowHeaderFont = Service.COMMON_FONT_BOLD;
                this.grdTemplate.RowHeaderFont = Service.COMMON_FONT_BOLD;
                this.grdTags.RowHeaderFont = Service.COMMON_FONT_BOLD;

                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell17);

                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell1);
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell2);
                xEditGridCell26.CellWidth = 80;

                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell7);
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell8);

                ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdTemplate)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdTags)).EndInit();
            }
        }

        #region Method
        private IList<object[]> GetGrdUser(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS2015U31GetADM3200UserArgs args = new OCS2015U31GetADM3200UserArgs();
            args.UserId = bvc["user_id"].VarValue;
            args.UserGroup = bvc["user_group"].VarValue;
            OCS2015U31GetADM3200UserResult res = CloudService.Instance.Submit<OCS2015U31GetADM3200UserResult, OCS2015U31GetADM3200UserArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Adm3200UserInfo.ForEach(delegate(OCS2015U31GetADM3200UserInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.UserId,
                        item.UserGroup,
                        item.UserNm
                    });
                });
            }
            return lObj;
        }

        private IList<object[]> LoadGridDepartAndDoctor(BindVarCollection bvc)
        {
            IList<object[]> lstDepartAndDoc = new List<object[]>();
            OCS2015U31LoadGridDepartAndDoctorArgs args = new OCS2015U31LoadGridDepartAndDoctorArgs();
            OCS2015U31LoadGridDepartAndDoctorResult result =
                CloudService.Instance
                    .Submit<OCS2015U31LoadGridDepartAndDoctorResult, OCS2015U31LoadGridDepartAndDoctorArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (IHIS.CloudConnector.Contracts.Models.OcsEmr.OCS2015U31LoadGridDepartAndDoctorInfo itemInfo in result.DepartAndDoctor)
                {
                    object[] objects =
                    {                        
                        itemInfo.DepartInfo.CodeName,
                        itemInfo.DoctorInfo.CodeName,
                        itemInfo.DepartInfo.Code,
                        itemInfo.DoctorInfo.Code,                        
                    };
                    lstDepartAndDoc.Add(objects);
                }
            }
            return lstDepartAndDoc;
        }
        private IList<object[]> GetGrdTemplate(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS2015U31GetEmrTemplateArgs args = new OCS2015U31GetEmrTemplateArgs();
            //args.UserId = _userId;
            args.UserId = UserInfo.UserID;                                   
            if (isCheckLoad)
            {
                departCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_code");
                doctorCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_code");
                args.DepartCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_code");
                args.DoctorCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_code");
            }
            else
            {
                args.DepartCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_name");
                args.DoctorCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_name");
            }
            if (UserInfo.UserGroup.ToString() != ADMIN)
            {
                if (rbtCommonTemplate.Checked)
                {
                    args.CommonYn = "Y";
                }
                else args.CommonYn = "N";
            }
            else args.CommonYn = "";
            
            if (departCode.ToLower() == "adm")
            {
                args.Type = "1";
            }
            else if (departCode.ToLower() != "adm" && doctorCode.ToLower() == "adm")
            {
                args.Type = "2";
            }
            else
            {
                args.Type = "3";
            }
            OCS2015U31GetEmrTemplateResult res = CloudService.Instance.Submit<OCS2015U31GetEmrTemplateResult, OCS2015U31GetEmrTemplateArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GridTemplateItemInfo.ForEach(delegate(OCS2015U31GetEmrTemplateInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.TypeId,
                        item.TemplateId,
                        item.TemplateCode,
                        item.TemplateName,
                        item.DefaultFlg,
                        item.Description,
                        item.SysId,
                        item.TemplateTypeId,
                        item.RowState
                    });
                });
            }
            return lObj;
        }

        private IList<object[]> GetGrdTag(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS2015U31GetTemplateTagsArgs args = new OCS2015U31GetTemplateTagsArgs();
            args.EmrTemplateId = grdTemplate.GetItemString(grdTemplate.CurrentRowNumber, "templateId");
            OCS2015U31GetTemplateTagsResult res = CloudService.Instance.Submit<OCS2015U31GetTemplateTagsResult, OCS2015U31GetTemplateTagsArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS2015U31GetTemplateTagsInfo temTagRoot in res.TemTagRootItemInfo)
                {
                    object binaryRoot = null;
                    string strDefaultContentRoot = "";
                    if (temTagRoot.Type == "1")
                    {
                        //Image
                        string localPathUrl;
                        binaryRoot = GetBinary(temTagRoot, out localPathUrl);
                        strDefaultContentRoot = localPathUrl;
                    }
                    lObj.Add(new object[]
                    {
                        temTagRoot.TagId,
                        temTagRoot.TagCode,
                        temTagRoot.TagName,
                        temTagRoot.Type == "1" ? IMAGE : TEXT, //Type
                        !string.IsNullOrEmpty(strDefaultContentRoot) ? strDefaultContentRoot : temTagRoot.DefaultContent, //DefaulContent
                        !string.IsNullOrEmpty(strDefaultContentRoot) ? strDefaultContentRoot : temTagRoot.DefaultContent, //urlLocation - Backup
                        "", //btnAddImage
                        binaryRoot, //Binary
                        temTagRoot.TagParent,
                        temTagRoot.TagLevel,
                        //"Add child",
                        temTagRoot.TemplateId,
                        temTagRoot.RowState
                    });

                    foreach (OCS2015U31GetTemplateTagsInfo temTagNode in res.TemTagNodeItemInfo)
                    {
                        if (temTagNode.TagParent.Trim() == temTagRoot.TagParent.Trim())
                        {
                            object binaryNode = null;
                            string strDefaultContentNode = "";
                            if (temTagNode.Type == "1")
                            {
                                //Image
                                string localPathUrl;
                                binaryNode = GetBinary(temTagNode, out localPathUrl);
                                strDefaultContentNode = localPathUrl;
                            }
                            lObj.Add(new object[]
                            {
                                temTagNode.TagId,
                                temTagNode.TagCode,
                                temTagNode.TagName,
                                temTagNode.Type == "1" ? IMAGE : TEXT, //Type
                                !string.IsNullOrEmpty(strDefaultContentNode) ? strDefaultContentNode : temTagNode.DefaultContent, //DefaulContent
                                !string.IsNullOrEmpty(strDefaultContentNode) ? strDefaultContentNode : temTagNode.DefaultContent, //urlLocation - Backup
                                "", //btnAddImage
                                binaryNode, //Binary
                                temTagNode.TagParent,
                                temTagNode.TagLevel,
                                temTagNode.TemplateId,
                                temTagNode.RowState
                            });
                        }
                    }
                }
                /*res.TemTagItemInfo.ForEach(delegate(OCS2015U31GetTemplateTagsInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.TagId,
                        item.TagCode,
                        item.TagName,
                        item.TagDisplayText,
                        item.Description,
                        item.TagParent,
                        item.SysId
                    });
                });*/
            }
            return lObj;
        }

        private object GetBinary(OCS2015U31GetTemplateTagsInfo temTag, out string localPathUrl)
        {
            object binary = null;
            localPathUrl = "";
            try
            {
                if (!string.IsNullOrEmpty(temTag.DefaultContent))
                {
                    string filePathLocal = ConvertToLocalPath(temTag.DefaultContent.Trim(), UserInfo.HospCode, BUNHO);
                    localPathUrl = filePathLocal;
                    if (!File.Exists(filePathLocal))
                    {
                        DownloadFile(filePathLocal, UserInfo.HospCode, BUNHO);
                    }
                    binary = Image.FromFile(!string.IsNullOrEmpty(filePathLocal) ? filePathLocal : "");

                    if (!string.IsNullOrEmpty(filePathLocal))
                    {
                        MediaDictionaryAdd(CalculateFileChecksum(filePathLocal), filePathLocal);
                    }
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Err Of GetBinary() " + ex.StackTrace);
            }
            
            return binary;
        }

        private XFindWorker GetFindWorker(string findMode)
        {
            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();

            switch (findMode)
            {
                case TAG_CODE:
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;
                    fdwCommon.ExecuteQuery = InitSearchBoxTags;
                    fdwCommon.FormText = Resource.fdwCommon_FormText;
                    fdwCommon.ColInfos.Add(TAG_CODE, " " + Resource.EMR_U302 + " ", FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add(TAG_NAME, " " + Resource.EMR_U303 + " ", FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("TagDisplayText", " " + Resource.EMR_U304 + " ", FindColType.String, 100, 0, true, FilterType.Yes);
                    break;
                default:
                    break;
            }
            return fdwCommon;
        }

        private IList<object[]> InitSearchBoxTags(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS2015U31EmrTagGetTagArgs args = new OCS2015U31EmrTagGetTagArgs();
            int currentRowFocusTagGrid = grdTags.CurrentRowNumber;
            string currentTagLevel = grdTags.GetItemString(currentRowFocusTagGrid, TAG_LEVEL);
            args.TagLevel = currentRowFocusTagGrid.Equals(0) ? ROOT : currentTagLevel;
            OCS2015U31EmrTagGetTagResult res = CloudService.Instance.Submit<OCS2015U31EmrTagGetTagResult, OCS2015U31EmrTagGetTagArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GridTagItemInfo.ForEach(delegate(OCS2015U31EmrTagGetTagInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.TagCode,
                        item.TagName,
                        item.TagDisplayText
                    });
                });
            }
            return lObj;
        }

        private List<OCS2015U31GetEmrTemplateInfo> GetListTemplateDataForSaveLayout()
        {
            List<OCS2015U31GetEmrTemplateInfo> lstData = new List<OCS2015U31GetEmrTemplateInfo>();
            for (int i = 0; i < this.grdTemplate.RowCount; i++)
            {
                if (grdTemplate.GetRowState(i) == DataRowState.Unchanged) continue;
                OCS2015U31GetEmrTemplateInfo item = new OCS2015U31GetEmrTemplateInfo();
                item.TemplateId = grdTemplate.GetItemString(i, TEMPLATE_ID);
                item.TemplateCode = grdTemplate.GetItemString(i, TEMPLATE_CODE);
                item.TemplateName = grdTemplate.GetItemString(i, TEMPLATE_NAME);
                item.Description = grdTemplate.GetItemString(i, DESCRIPTION);
                item.TypeId = grdTemplate.GetItemString(i, TYPE_NAME);
                item.SysId = grdTemplate.GetItemString(i, SYS_ID);
                item.DefaultFlg = string.IsNullOrEmpty(grdTemplate.GetItemString(i, DEFAULT_FLG))
                    ? "N"
                    : grdTemplate.GetItemString(i, DEFAULT_FLG);
                string typeName = grdTemplate.GetComboDisplayValue(i, TYPE_NAME);
                item.TemplateTypeId = GetTemplateTypeId(typeName);
                /*this.grdTemplate.SetComboItems(TYPE_NAME, _dtTemplateCbo, "type_name", "template_type_id");*/
                if (UserInfo.UserGroup.ToString() != ADMIN && rbtCommonTemplate.Checked)
                {
                    item.UseYn = string.IsNullOrEmpty(grdTemplate.GetItemString(i, "user"))
                        ? "N"
                        : grdTemplate.GetItemString(i, "user");
                }
                else item.UseYn = "";
                if (!string.IsNullOrEmpty(item.TemplateId) &&
                    this.GetTagCollection(item.TemplateId).Trim() != grdTemplate.GetItemString(i, TEMPLATE_NAME))
                    item.RowState = DataRowState.Modified.ToString();
                else
                    item.RowState = grdTemplate.GetRowState(i).ToString();

                if (item.RowState != DataRowState.Unchanged.ToString())
                {
                    lstData.Add(item);
                    _isAddParentRecord = true;
                }

                if (item.RowState != DataRowState.Unchanged.ToString() && !_isModified)
                    _isModified = true;
            }
            /*if (null != grdTemplate.DeletedRowTable)*/
            if (grdTemplate.DeletedRowTable != null && grdTemplate.DeletedRowTable.Rows.Count > 0)
            {
                for (int i = 0; i < grdTemplate.DeletedRowTable.Rows.Count; i++)
                {
                    OCS2015U31GetEmrTemplateInfo item = new OCS2015U31GetEmrTemplateInfo();
                    item.TemplateId = Convert.ToString(grdTemplate.DeletedRowTable.Rows[i][TEMPLATE_ID]);
                    item.SysId = Convert.ToString(grdTemplate.DeletedRowTable.Rows[i][SYS_ID]);
                    item.RowState = DataRowState.Deleted.ToString();
                    lstData.Add(item);
                }
                if (grdTemplate.DeletedRowTable.Rows.Count > 0 && !_isModified)
                    _isModified = true;
                isCheckDeleComTemplate = true;
            }
            return lstData;
        }

        private List<OCS2015U31GetTemplateTagsInfo> GetListTemplateTagDataForSaveLayout()
        {
            List<OCS2015U31GetTemplateTagsInfo> lstData = new List<OCS2015U31GetTemplateTagsInfo>();

            for (int i = 0; i < this.grdTags.RowCount; i++)
            {
                OCS2015U31GetTemplateTagsInfo item = new OCS2015U31GetTemplateTagsInfo();
                int currentTempFocus = grdTemplate.CurrentRowNumber;
                item.TemplateId = grdTemplate.GetItemString(currentTempFocus, TEMPLATE_ID);
                item.TagId = grdTags.GetItemString(i, "tagId");
                item.TagCode = grdTags.GetItemString(i, TAG_CODE);
                item.Type = grdTags.GetComboDisplayValue(i, TYPE) == IMAGE ? "1" : "0";
                item.DefaultContent = grdTags.GetItemString(i, COL_DEFAULT_CONTENT);
                if (grdTags.GetComboDisplayValue(i, TYPE) == IMAGE && !string.IsNullOrEmpty(item.DefaultContent))
                {
                    item.DefaultContent = grdTags.GetItemString(i, COL_URLLOCATION);
                    if (File.Exists(item.DefaultContent))
                        Upload(item.DefaultContent.Trim());
                }

                string currentTagLevel = grdTags.GetItemString(i, TAG_LEVEL);
                item.TagLevel = currentTagLevel;
                if (currentTagLevel.Equals(ROOT))
                {
                    item.TagParent = item.TagCode;
                }
                else
                {
                    item.TagParent = grdTags.GetItemString(i, "tagParent");
                    item.TagChild = item.TagCode;
                }
                item.TagName = grdTags.GetItemString(i, TAG_NAME);

                /*if (!string.IsNullOrEmpty(item.TemplateId) && this.GetTagCollection(item.TemplateId).Trim() != grdTags.GetItemString(i, TAG_NAME))
                    item.RowState = DataRowState.Modified.ToString();
                else*/
                item.RowState = grdTags.GetRowState(i).ToString();
                if (item.RowState != DataRowState.Unchanged.ToString())
                    lstData.Add(item);
                if (item.RowState != DataRowState.Unchanged.ToString() && !_isModified)
                    _isModified = true;
            }

            if (grdTags.DeletedRowTable != null)
            {
                for (int i = 0; i < grdTags.DeletedRowTable.Rows.Count; i++)
                {
                    OCS2015U31GetTemplateTagsInfo item = new OCS2015U31GetTemplateTagsInfo();
                    item.TemplateId = Convert.ToString(grdTags.DeletedRowTable.Rows[i][TEMPLATE_ID]);
                    item.TagId = Convert.ToString(grdTags.DeletedRowTable.Rows[i]["tagId"]);
                    item.TagCode = Convert.ToString(grdTags.DeletedRowTable.Rows[i][TAG_CODE]);
                    item.TagName = Convert.ToString(grdTags.DeletedRowTable.Rows[i][TAG_NAME]);
                    string type = Convert.ToString(grdTags.DeletedRowTable.Rows[i][TYPE]);
                    item.Type = type == IMAGE ? "1" : "0";
                    item.DefaultContent = Convert.ToString(grdTags.DeletedRowTable.Rows[i][COL_DEFAULT_CONTENT]);
                    string currentTagLevel = Convert.ToString(grdTags.DeletedRowTable.Rows[i][TAG_LEVEL]);
                    item.TagLevel = currentTagLevel;
                    if (currentTagLevel.Equals(ROOT))
                    {
                        item.TagParent = item.TagCode;
                    }
                    else
                    {
                        item.TagParent = grdTags.GetItemString(i, "tagParent");
                        item.TagChild = item.TagCode;
                    }

                    item.RowState = DataRowState.Deleted.ToString();
                    lstData.Add(item);
                }
                if (grdTags.DeletedRowTable.Rows.Count > 0 && !_isModified)
                    _isModified = true;
            }
            return lstData;
        }

        #region BtnList handler

        private void SaveData()
        {
            string departCodeCobobox = "";
            string doctorCodeCobobox = "";
            departCodeCobobox = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_name");
            doctorCodeCobobox = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_name");
            if (UserInfo.UserGroup.ToString() == ADMIN)
            {
                if (!CheckComboDocAndDepar()) return;
            }            
            /*OCS2015U31EmrTemplateSaveLayoutArgs args = new OCS2015U31EmrTemplateSaveLayoutArgs();*/
            OCS2015U31SaveLayoutArgs args = new OCS2015U31SaveLayoutArgs();
            int currentTempGrid = grdUser.CurrentRowNumber;
            string userId = grdUser.GetItemString(currentTempGrid, "userId");
            args.UserId = userId;
            args.ListTemplate = GetListTemplateDataForSaveLayout();
            args.ListTemplateTag = GetListTemplateTagDataForSaveLayout();

            if (args.ListTemplate.Count == 0 && args.ListTemplateTag.Count == 0)
            {
                XMessageBox.Show(Resource.CMO_M013, string.Empty, MessageBoxIcon.Warning);
                return;
            }
            if (isCheckLoad)
            {
                departCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_code");
                doctorCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_code"); 
                args.DeptCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_code");
                args.DoctorCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_code");
            }
            else
            {
                args.DeptCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_name");
                args.DoctorCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_name");
            }       
            //args.DeptCode = departCodeCobobox;
            //args.DoctorCode = doctorCodeCobobox;
            //args.UseYn = string.IsNullOrEmpty(grdTemplate.GetItemString(grdTemplate.CurrentRowNumber, "user"))
            //    ? "N"
            //    : grdTemplate.GetItemString(grdTemplate.CurrentRowNumber, "user");
            if (departCodeCobobox.ToLower() == "adm")
            {
                args.Type = "1";
            }
            else if (departCodeCobobox.ToLower() != "adm" && doctorCodeCobobox.ToLower() == "adm")
            {
                args.Type = "2";
            }
            else
            {
                args.Type = "3";
            }
            if (UserInfo.UserGroup.ToString() != ADMIN && rbtCommonTemplate.Checked)
            {
                if (isCheckDeleComTemplate)
                {
                    args.CloneYn = "N";
                    isCheckDeleComTemplate = false;
                }
                else args.CloneYn = "Y";                             
            }
            else args.CloneYn = "N";

            if (TemplateValidateData())
            {
                if (!_isModified) return;
                if (!TemplateTagValidateData()) return;

                //DialogResult dr = XMessageBox.Show(Resource.CMO_M004, Resource.EMR_M004, MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button2, MessageBoxIcon.Asterisk);
                //if (dr == DialogResult.Cancel) return;
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS2015U31SaveLayoutArgs>(args);
                if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                {
                    _isModified = false;
                    _isAddParentRecord = false;
                    isCheckInsertDocAndDep = true;
                    this.grdTemplate.ResetUpdate();
                    XMessageBox.Show(Resource.CMO_M005, string.Empty, MessageBoxIcon.Information);
                    this.btnList.PerformClick(FunctionType.Query);                    
                }
                else if (res.ExecutionStatus == ExecutionStatus.Success && res.Msg.Equals("01"))
                {
                    XMessageBox.Show(Resource.CMO_M014, string.Empty, MessageBoxIcon.Information);
                }
                else
                    XMessageBox.Show(Resource.CMO_M006, string.Empty, MessageBoxIcon.Asterisk);
            }
            CheckReadOnlyAfterSave(true);
        }
        private void Add(object sender, ButtonClickEventArgs e)
        {
            CheckReadOnlyAfterSave(false);
            e.IsBaseCall = false;            
            int rowNum = 0;
            if (UserInfo.UserGroup.ToString() == ADMIN)
            {
                if (this.CurrMQLayout == this.grdLoadDocAndDepart)
                {
                    isCheckInsert = true;
                    if (isCheckInsertDocAndDep)
                    {
                        rowNum = this.grdLoadDocAndDepart.InsertRow(-1);
                        this.grdTemplate.Reset();
                        this.grdTags.Reset();
                        isCheckLoad = false;
                        isCheckInsertDocAndDep = false;
                    }
                    //_countGrdDocAndDepart = _countGrdDocAndDepart + 1;                                      
                    //if (_isAddParentRecord) return;
                    //if(!CheckInsetDataUserAdmin()) return;
                }
                else
                {
                    if (this.CurrMQLayout == this.grdTemplate)
                    {
                        rowNum = this.grdTemplate.InsertRow(-1);
                        if (_isAddParentRecord) return;
                        if (!CheckInsetDataTemplateGrd()) return;
                    }
                    else
                    {
                        if (this.CurrMQLayout == this.grdTags)
                        {
                            if (this.grdTemplate.RowCount < 0) return;
                            rowNum = this.grdTags.InsertRow(-1);
                            this.grdTags.SetItemValue(rowNum, "tagLevel", ROOT);
                            this.grdTags.SetItemValue(rowNum, TYPE, TEXT);
                        }
                    }
                }
            }
            else
            {
                if (this.CurrMQLayout == this.grdTemplate)
                {
                    _temIndex--;
                    if (_isAddParentRecord) return;
                    if (!CheckInsetDataTemplateGrd()) return;

                    //rowNum = this.grdTemplate.InsertRow(-1);
                    this.grdTemplate.SetFocusToItem(rowNum, TEMPLATE_ID);
                    //this.grdTemplate.SetItemValue(rowNum, "temId", _temIndex);
                    this.grdTemplate.SetItemValue(rowNum, SYS_ID, UserInfo.UserID);
                    _currentTemplateId = _temIndex.ToString();

                }
                else
                {
                    /*if (int.Parse(this._currentTemplateId) > 0 && UserInfo.UserGroup.ToString() != ADMIN && UserInfo.UserID.ToString() != _currentSysId)
                    {
                        XMessageBox.Show(Resource.EMR_M003, Resource.EMR_M004, MessageBoxIcon.Warning);
                        return;
                    }*/
                    if (this.grdTemplate.RowCount <= 0) return;
                    rowNum = this.grdTags.InsertRow(-1);
                    //this.grdTags.SetItemValue(rowNum, DISPLAY_TXT, string.Empty);
                    this.grdTags.SetItemValue(rowNum, "tagLevel", ROOT);
                    this.grdTags.SetItemValue(rowNum, TYPE, TEXT);
                }
            }
        }
        private void Delete(object sender, ButtonClickEventArgs e)
        {
            try
            {
                if (UserInfo.UserGroup.ToString() == ADMIN)
                {
                    int rowNum = 0;
                    if (this.CurrMQLayout == this.grdLoadDocAndDepart)
                    {
                        isCheckInsertDocAndDep = true;                        
                    }
                    if (this.CurrMQLayout == this.grdLoadDocAndDepart)
                    {
                        e.IsBaseCall = false;
                        if (grdTemplate.RowCount > 0)
                        {
                            XMessageBox.Show(Resource.MSG_Del_Depart_Doctor, Resource.WARN, MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                        e.IsBaseCall = true;
                    }
                }
                /*string mTemSysId = this.grdTemplate.GetItemString((this.grdTemplate.FocusCell.Grid).CurrentRowNumber, SYS_ID);*/
                if (this.CurrMQLayout == this.grdTemplate)
                {
                    /*if (UserInfo.UserGroup.ToString() != ADMIN && mTemSysId != UserInfo.UserID)
                    {
                        XMessageBox.Show(Resource.EMR_M003, Resource.EMR_M004, MessageBoxIcon.Warning);
                        e.IsBaseCall = false;
                        return;
                    }*/

                    _templateName = this.grdTemplate.GetItemString(int.Parse(this.grdTemplate.FocusCell.Row.ToString()), "templateName");
                    //_templateName = "";
                    if (!string.IsNullOrEmpty(_templateName))
                        this.grdTags.QueryLayout(false);
                    else
                        this.grdTags.Reset();
                }
                else
                {
                    /*if (UserInfo.UserGroup.ToString() != ADMIN && mTemSysId != UserInfo.UserID)
                    {
                        XMessageBox.Show(Resource.EMR_M002, Resource.EMR_M004, MessageBoxIcon.Warning);
                        e.IsBaseCall = false;
                    }*/

                    List<string> childrentIndexLst = new List<string>();
                    bool ret = this.UpdateTag((int)actionType.Delete,
                                                this.grdTags.GetItemString(this.grdTags.CurrentRowNumber, TAG_CODE),
                                                this.grdTags.GetItemString(this.grdTags.CurrentRowNumber, TAG_PARENT),
                                                this.grdTags.CurrentRowNumber, out childrentIndexLst
                                                );
                    if (!ret)
                    {
                        e.IsBaseCall = false;
                    }
                    else
                    {
                        if (childrentIndexLst.Count > 0)
                        {
                            foreach (string index in childrentIndexLst)
                            {
                                this.grdTags.DeleteRow(int.Parse(index));
                            }
                        }
                    }
                    if (this.grdTags.RowCount == 1)
                    {
                        this.UpdateTagCollection(_currentTemplateId, string.Empty);
                        //this.grdTemplate.SetItemValue(int.Parse(_currentTemRowNum), TEMPLATE_CONTENT, string.Empty);
                        return;
                    }
                    this.grdTags.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdTags_GridCellFocusChanged);
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        private bool CheckInsetDataTemplateGrd()
        {
            for (int i = 0; i < grdTemplate.RowCount; i++)
            {
                string rowState = grdTemplate.GetRowState(i).ToString();
                if (rowState == DataRowState.Added.ToString())
                {
                    return false;
                }

              
            }
            return true;
        }

        #region Validate Data
        /// <summary>
        /// Validate input data for template
        /// </summary>
        /// <returns></returns>
        private bool TemplateValidateData()
        {
            for (int i = 0; i < this.grdTemplate.RowCount; i++)
            {
                if (string.IsNullOrEmpty(this.grdTemplate.GetItemString(i, TYPE_NAME).ToString()))
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M001, " " + Resource.EMR_U311 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    return false;
                }
                if (string.IsNullOrEmpty(this.grdTemplate.GetItemString(i, TEMPLATE_NAME).ToString()))
                {
                    XMessageBox.Show(string.Format(Resource.CMO_M001, " " + Resource.EMR_U312 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
                    return false;
                }
                if (string.IsNullOrEmpty(this.grdTemplate.GetItemString(i, "templateCode").ToString()))
                {
                    XMessageBox.Show(Resource.EMR_U31_TemplateCode, Resource.EMR_M004, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool TemplateTagValidateData()
        {
            for (int i = 0; i < this.grdTags.RowCount; i++)
            {
                if (grdTags.GetComboDisplayValue(i, TYPE) == IMAGE && string.IsNullOrEmpty(grdTags.GetItemString(i, COL_DEFAULT_CONTENT)))
                {
                    XMessageBox.Show(Resource.OCS2015U31_TemplateTagImage_DfContent, Resource.EMR_M004, MessageBoxIcon.Warning);
                    grdTags.SetFocusToItem(i, COL_DEFAULT_CONTENT);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Validate input data for tags
        /// </summary>
        /// <returns></returns>
        //private bool TagValidateData()
        //{
        //    int rowCount = 0;
        //    for (int i = 0; i < this.grdTags.RowCount; i++)
        //    {
        //        if (!string.IsNullOrEmpty(this.grdTags.GetItemString(i, TAG_CODE).ToString()))
        //            rowCount++;
        //    }
        //    if (rowCount == 1) return true;
        //    for (int i = 0; i < rowCount; i++)
        //    {
        //        //Check existed
        //        if (this.IsExisted(this.grdTags.GetItemString(i, TAG_CODE).ToString(), i, rowCount))
        //        {
        //            XMessageBox.Show(string.Format(Resource.CMO_M002, " " + Resource.EMR_U302 + " "), Resource.EMR_M004, MessageBoxIcon.Warning);
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        /// <summary>
        /// Check exist for tag code
        /// </summary>
        /// <param name="tagCode"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private bool IsExisted(string tagCode, int index, int length)
        {
            if (length == 1 || string.IsNullOrEmpty(tagCode)) return false;
            for (int i = index; i < length; i++)
            {
                for (int k = i + 1; k < this.grdTags.RowCount; k++)
                {
                    if (this.grdTags.GetItemString(k, TAG_CODE).ToString() == tagCode) return true;
                }
            }
            return false;
        }
        #endregion

        #region InitData
        private void InitializeCloud()
        {
            #region grdUser
            grdUser.ParamList = new List<string>(new string[]
                {
                    "user_id",
                    "user_group"
                });
            grdUser.ExecuteQuery = GetGrdUser;
            #endregion

            #region grdTemplate
            grdTemplate.ParamList = new List<string>(new string[]
                {
                    "sys_id",
                    "user_group"
                });
            grdTemplate.ExecuteQuery = GetGrdTemplate;
            #endregion

            #region grdTag
            grdTags.ParamList = new List<string>(new string[]
                {
                    "str_tag_code"
                });
            grdTags.ExecuteQuery = GetGrdTag;

            #endregion

            #region grdLoadDoctor And Depart

            grdLoadDocAndDepart.ExecuteQuery = LoadGridDepartAndDoctor;

            #endregion
        }
        private void InitTemplateTags()
        {
            if (this.grdTemplate.RowCount > 0)
            {
                //todo
                /*_templateName = this.grdTemplate.GetItemString(0, TEMPLATE_CONTENT);*/
                _templateName = "";
                if (!string.IsNullOrEmpty(_templateName))
                    this.grdTags.QueryLayout(false);
            }
        }
        /// <summary>
        /// Get all tags
        /// </summary>
        private void InitAllTags()
        {
            OCS2015U31EmrTagGetTagArgs args = new OCS2015U31EmrTagGetTagArgs();
            /*int currentRowFocusTagGrid = grdTags.CurrentRowNumber;
            string currentTagLevel = grdTags.GetItemString(currentRowFocusTagGrid, TAG_LEVEL);*/
            args.TagLevel = ""; //get all Tag (ROOT & NODE)
            OCS2015U31EmrTagGetTagResult res = CloudService.Instance.Submit<OCS2015U31EmrTagGetTagResult, OCS2015U31EmrTagGetTagArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GridTagItemInfo.ForEach(delegate(OCS2015U31EmrTagGetTagInfo item)
                {
                    lTagObj.Add(new object[]
                    {
                        item.TagCode,
                        item.TagName,
                        item.TagDisplayText
                    });
                });
            }
        }

        private void InitTemplateTypeCbo()
        {
            //this.grdTemplate.SetComboItems(TYPE_NAME, _dtTemplateCbo, "type_name", "template_type_id");
        }

        private void InitCboItemType()
        {
            if (this.grdTemplate.RowCount <= 0) return;
            for (int i = this.grdTemplate.RowCount; i >= 0; i--)
                this.grdTemplate.SetFocusToItem(i, TYPE_NAME);
            this.grdTemplate.SetFocusToItem(0, TYPE_NAME);
        }
        /// <summary>
        /// Get template type combo
        /// </summary>
        private void GetTemplateTypeCbo()
        {
            lGrdCboObj = new List<object[]>();
            OCS2015U31EmrTemplateTypeArgs args = new OCS2015U31EmrTemplateTypeArgs();
            OCS2015U31EmrTemplateTypeResult res = CloudService.Instance.Submit<OCS2015U31EmrTemplateTypeResult, OCS2015U31EmrTemplateTypeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.EmrTemplateTypeInfo != null)
                {
                    _dtTemplateCbo = ConvertToDataTable(res.EmrTemplateTypeInfo);
                    foreach (DataRow dtRow in _dtTemplateCbo.Rows)
                    {
                        lGrdCboObj.Add(new object[]
                        {
                            dtRow["template_type_id"],
                            dtRow["type_name"]
                        });
                    }
                }
            }
        }
        #endregion

        #region Common
        private DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(Regex.Replace(prop.Name, "(?<=.)([A-Z])", "_$0", RegexOptions.Compiled).ToLower());
            }
            foreach (T item in items)
            {
                object[] values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private object[] GetDataSelected(IList<object[]> lst, string tagCode)
        {
            if (lst.Count <= 0) return null;
            int i, j;
            List<object> retData = new List<object>();
            for (i = 0; i < lst.Count; i++)
            {
                if (lst[i][0].ToString().Trim() == tagCode.Trim()) return lst[i];
            }
            return null;
        }

        #endregion

        #region validate for new rule
        private bool IsRootTag(string tagParent)
        {
            if (string.IsNullOrEmpty(tagParent))
                return true;
            else
                return false;
        }

        private bool UpdateTag(int action, string tagCode, string parentTagCode, int currentRow, out List<string> childrentIndexLst)
        {
            bool result = false;
            childrentIndexLst = new List<string>();
            switch (action)
            {
                case (int)actionType.Add:
                    result = IsAddTag(tagCode, parentTagCode, currentRow);
                    break;
                case (int)actionType.Edit:
                    result = IsEditTag(tagCode, parentTagCode, currentRow);
                    break;
                case (int)actionType.Delete:
                    result = IsDeleteTag(tagCode, parentTagCode, currentRow, out childrentIndexLst);
                    break;
                default:
                    break;
            }
            return result;
        }

        private bool IsAddTag(string tagCode, string parentTagCode, int CurrentRowNumber)
        {
            if (string.IsNullOrEmpty(parentTagCode.Trim()))
            {
                //Todo Add root tag
                return true;
            }
            else// if it's node tag
            {
                //Get rootTag latest
                bool getDublecateTagLatest = GetDublecateTagLatest(CurrentRowNumber, tagCode, parentTagCode);
                if (!getDublecateTagLatest)
                {
                    XMessageBox.Show(Resource.EMR_U31_ADD1, Resource.EMR_M004, MessageBoxIcon.Warning);
                    return false;
                }

                /*string[] parentTagArr = parentTagCode.Split(new char[] { ',' });
                if (Array.IndexOf(parentTagArr, rootTagLatest) > -1)
                {
                    //Add node tag
                    return true;
                }
                else
                {
                    //Not allow add node tag
                    XMessageBox.Show(Resource.EMR_U31_ADD2, Resource.EMR_M004, MessageBoxIcon.Warning);
                    return false;
                }*/
            }

            return true;
        }

        private bool IsEditTag(string tagCode, string parentTagCode, int CurrentRowNumbe)
        {
            if (string.IsNullOrEmpty(parentTagCode))//root tag
            {
                DialogResult dr;
                if (this.grdTags.RowCount == CurrentRowNumbe)
                    return true;
                List<string> childrenIndexLst = GetTagChildrenIndex(parentTagCode, CurrentRowNumbe);
                if (childrenIndexLst.Count > 0)
                {
                    XMessageBox.Show(Resource.EMR_U31_UPD1, Resource.EMR_M004, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else//node tag
            {
                bool getDublecateTagLatest = GetDublecateTagLatest(CurrentRowNumbe, tagCode, parentTagCode);
                if (!getDublecateTagLatest)
                {
                    XMessageBox.Show(Resource.EMR_U31_ADD1, Resource.EMR_M004, MessageBoxIcon.Warning);
                    return false;
                }

                /*//Get latest root tag
                string rootTagLatest = GetDublecateTagLatest(CurrentRowNumbe);
                string parentTag = this.grdTags.GetItemString(this.grdTags.CurrentRowNumber, TAG_PARENT).ToString();
                if (Array.IndexOf(parentTag.Split(new char[] { ',' }), rootTagLatest) > -1)// node tag is child of latest root tag.
                    return true;
                else
                {
                    XMessageBox.Show(Resource.EMR_U31_ADD2, Resource.EMR_M004, MessageBoxIcon.Warning);
                    return false;
                }*/

                return true;
            }
            return false;
        }

        private bool IsDeleteTag(string tagCode, string parentTagCode, int CurrentRowNumbe, out List<string> childrenIndexLst)
        {
            childrenIndexLst = new List<string>();
            if (!string.IsNullOrEmpty(parentTagCode))
            {
                // Delete node tag
                return true;
            }
            else// if it's root tag
            {
                //Get childrent of root tag
                childrenIndexLst = GetTagChildrenIndex(parentTagCode, CurrentRowNumbe);

                if (childrenIndexLst.Count <= 0)
                    return true;
                else
                {
                    DialogResult dr = XMessageBox.Show(Resource.EMR_U31_UPD2, Resource.EMR_M004, MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button2, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Cancel)
                        return false;
                    else
                        return true;
                }
            }
            return false;
        }

        private bool GetDublecateTagLatest(int CurrentRowNumber, string tagCode, string parentTagCode)
        {
            //TODO
            for (int i = 0; i < grdTags.RowCount; i++)
            {
                if (i == CurrentRowNumber) continue;

                string tagCodeItem = this.grdTags.GetItemString(i, TAG_CODE);
                string tagLevel = this.grdTags.GetItemString(i, TAG_LEVEL);
                string tagParent = this.grdTags.GetItemString(i, "tagParent");
                if (tagCode == parentTagCode)
                {
                    if (tagLevel != ROOT) continue;
                    if (!string.IsNullOrEmpty(tagCodeItem))
                    {
                        if (tagCodeItem == tagCode)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (tagLevel != NODE || parentTagCode != tagParent) continue;

                    if (!string.IsNullOrEmpty(tagCodeItem))
                    {
                        if (tagCodeItem == tagCode)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private List<string> GetTagChildrenIndex(string rootTagCode, int currentRowNumber)
        {
            List<string> indexLst = new List<string>();
            if (currentRowNumber == this.grdTags.RowCount)
                return indexLst;
            for (int i = currentRowNumber + 1; i <= this.grdTags.RowCount; i++)
            {
                if (string.IsNullOrEmpty(this.grdTags.GetItemString(i, TAG_PARENT)))// next tag is root tag
                    break;
                else
                    indexLst.Add(i.ToString());
            }
            return indexLst;
        }

        enum actionType
        {
            Add,
            Edit,
            Delete
        };

        #endregion

        private void RollBackData(object sender, GridColumnChangedEventArgs e)
        {
            string prevTagCodeValue = grdTags.GetItemValue(e.RowNumber, TAG_CODE, DataBufferType.PreviousBuffer).ToString();
            string prevTagNamValue = grdTags.GetItemValue(e.RowNumber, TAG_NAME, DataBufferType.PreviousBuffer).ToString();

            grdTags.SetItemValue(e.RowNumber, TAG_CODE, prevTagCodeValue);
            grdTags.SetItemValue(e.RowNumber, TAG_NAME, prevTagNamValue);
        }

        #region TagsDict
        /// <summary>
        /// Get string of tag code  in grd tag
        /// </summary>
        /// <returns></returns>
        private string GetTagsCode()
        {
            string strTags = string.Empty;
            for (int i = 0; i < this.grdTags.RowCount; i++)
            {
                if (string.IsNullOrEmpty(grdTags.GetItemString(i, TAG_CODE).ToString())) continue;
                strTags += grdTags.GetItemString(i, TAG_CODE) + ",";
            }
            return string.IsNullOrEmpty(strTags) ? string.Empty : strTags.Substring(0, strTags.Length - 1);
        }
        /// <summary>
        /// Update tag into tag collection
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void UpdateTagCollection(string key, string value)
        {
            if (string.IsNullOrEmpty(key)) return;
            int mKey = int.Parse(key);
            if (_tagCollection.ContainsKey(mKey))
            {
                _tagCollection[mKey] = value;
            }
            else
            {
                _tagCollection.Add(mKey, value);
            }
        }
        private void InitTagCollection()
        {
            for (int i = 0; i < this.grdTemplate.RowCount; i++)
            {
                this.UpdateTagCollection(grdTemplate.GetItemString(i, TEMPLATE_ID), grdTemplate.GetItemString(i, TEMPLATE_NAME));
            }
        }

        private string GetTagCollection(string key)
        {
            try
            {
                int mKey = int.Parse(key);
                if (_tagCollection.ContainsKey(mKey))
                {
                    return _tagCollection[mKey].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        private void DeleteTagCollection(string key)
        {
            if (string.IsNullOrEmpty(key)) return;
            int mKey = int.Parse(key);
            if (_tagCollection.ContainsKey(mKey))
            {
                _tagCollection.Remove(mKey);
            }
        }
        #endregion

        private void QueryGrdTag()
        {
            int rowNum = grdTemplate.CurrentRowNumber;
            _currentTemplateId = this.grdTemplate.GetItemString(rowNum, TEMPLATE_ID);

            if (!string.IsNullOrEmpty(_currentTemplateId))
                this.grdTags.QueryLayout(false);
            else
                this.grdTags.Reset();
        }

        private string GetTemplateTypeId(string typeName)
        {
            string templateTypeId = "";
            foreach (DataRow rowItem in _dtTemplateCbo.Rows)
            {
                if (rowItem["type_name"].ToString() == typeName)
                {
                    templateTypeId = rowItem["template_type_id"].ToString();
                    break;
                }
            }

            return templateTypeId;
        }

        #region For upload file
        private string GetAbsoluteDataPath(string name, string bunho)
        {
            return GetRelativePath(name, false, bunho);
        }
        private string GetRelativePath(string name, bool checkExists, string bunho)
        {
            name = "Data\\" + UserInfo.HospCode + "\\" + bunho + "\\" + name;
            string path = Application.StartupPath;
            string s = "\\";
            if (!Directory.Exists(path + "\\Data\\" + UserInfo.HospCode + "\\" + bunho + "\\"))
            {
                Directory.CreateDirectory(path + "\\Data\\" + UserInfo.HospCode + "\\" + bunho + "\\");
            }
            if (checkExists)
            {
                for (int i = 0; i <= 10; i++)
                {
                    if (File.Exists(path + s + name)) return (path + s + name);
                    else s += "..\\";
                }
                return "";
            }
            else
            {
                return (path + s + name);
            }
        }

        public string GetFileName(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                int index = filePath.LastIndexOf("/") == -1 ? filePath.LastIndexOf("\\") : filePath.LastIndexOf("/");
                string fileName = filePath.Substring(index == -1 ? 0 : index + 1);
                return fileName;
            }

            return "";
        }

        public static string NextSequence(string bunho, string filename, string fileExtension)
        {
            string path = GetBunhoDataPath(bunho);
            int maxFileNameLength = 248 - path.Length - String.Format("{0}__{1}.{2}", bunho, DateTime.Now.ToString("yyyyMMddHHmmssffffff"), fileExtension.Replace(".", "")).Length;
            //return String.Format("{0}-{1}-{2}-{3}", hospitalCode, Guid.NewGuid(), Process.GetCurrentProcess().Id, DateTime.Now.Millisecond);
            string modifiedName = string.IsNullOrEmpty(filename) ? string.Empty : Path.GetFileNameWithoutExtension(filename);
            modifiedName = modifiedName.Length <= maxFileNameLength ? modifiedName : modifiedName.Substring(0, maxFileNameLength);

            modifiedName = string.Empty; //TODO Fix filename to empty to avoid upload error
            string tmpFilename = String.Format("{0}_{1}_{2}.{3}", bunho, modifiedName, DateTime.Now.ToString("yyyyMMddHHmmssffffff"), fileExtension.Replace(".", ""));
            //CacheService.Instance.Get(tmpFilename);
            return tmpFilename;
        }

        public static string GetBunhoDataPath(string bunho)
        {
            string relativePath = "Data\\" + UserInfo.HospCode + "\\" + bunho + "\\";
            string path = Application.StartupPath;
            string s = "\\";
            if (!Directory.Exists(path + s + relativePath))
            {
                Directory.CreateDirectory(path + s + relativePath);
            }
            return path + s + relativePath;
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

        private void Upload(string path)
        {
            // MED-8221
            //using backgroundworker to improve performance
            try
            {

                if (this.ExistMediaFile(CalculateFileChecksum(path)) || string.IsNullOrEmpty(path))
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

        public static string CalculateFileChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                byte[] checksum = md5.ComputeHash(stream);
                return BitConverter.ToString(checksum);
            }
        }

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
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
            return false;
        }

        //MED-8221
        private void bwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                String uploadPath = e.Argument as String;

                //TODO need override this test code
                string localPath = ConvertToLocalPath(uploadPath, UserInfo.HospCode,
                    BUNHO);

                // MED-10181
                //string uploadAddress = ConfigurationManager.AppSettings["UploadBaseUri"];
                string uploadAddress = IHIS.CloudConnector.Utility.Utility.GetConfig("UploadBaseUri", UserInfo.VpnYn);

                //http://10.1.20.2:8010/upload
                string uploadToken = ConfigurationManager.AppSettings["UploadToken"]; //"1234"
                Uri address = new Uri(uploadAddress);

                /*if (!this.IsConfirmSave)
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
                }*/

                UploadTempFile(address, localPath, uploadToken, UserInfo.HospCode, BUNHO);
            }
            catch (Exception ex)
            {
                Service.WriteLog("UPLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        private string ConvertToLocalPath(string filePath, string hosp_code, string bunho)
        {
            string path = Application.StartupPath;
            if (!Directory.Exists(path + "\\Data\\" + hosp_code + "\\" + bunho))
            {
                Directory.CreateDirectory(path + "\\Data\\" + hosp_code + "\\" + bunho);
            }

            string localPath = string.IsNullOrEmpty(filePath) ? null : Application.StartupPath + "\\Data\\" + hosp_code + "\\" + bunho + "\\" + GetFileName(filePath);
            return localPath;
        }

        private void UploadTempFile(Uri address, string filePath, string token, string hosp_code, string bunho)
        {
            try
            {
                if (address == null)
                {
                    throw new ArgumentNullException("address");
                }
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("token", token);
                    client.Headers.Add("filename", GetFileName(filePath));
                    client.Headers.Add("HOSP_CODE", hosp_code);
                    client.Headers.Add("PATIENT_CODE", bunho);
                    /*client.Headers.Add("TEMP", "Y");*/
                    Service.WriteLog("[BEGIN UPLOAD] - " + filePath + ", token: " + token);
                    //client.UploadFile(address, filePath);
                    client.UploadData(address, File.ReadAllBytes(filePath));
                    Service.WriteLog("[END UPLOAD] - " + filePath + ", token: " + token);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("UPLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        private void DownloadFile(string filePath, string hosp_code, string bunho)
        {
            try
            {
                // MED-10181
                //string mediaHost = ConfigurationManager.AppSettings["MediaBaseUri"];// "http://media.nextop.asia/k01/";
                string mediaHost = Utility.GetConfig("MediaBaseUri", UserInfo.VpnYn);
                Uri assetUrl = new Uri(mediaHost);
                DownloadAssetDataFromUrl(assetUrl, filePath, hosp_code, bunho);
            }
            catch (Exception)
            {

            }
        }

        private void DownloadAssetDataFromUrl(Uri assetUrl, string filePath, string hosp_code, string bunho)
        {
            try
            {
                if (assetUrl == null)
                {
                    throw new ArgumentNullException("assetUrl");
                }
                WebRequest request = HttpWebRequest.Create(assetUrl);
                request.Headers.Add("filename", GetFileName(filePath));
                request.Headers.Add("token", "1234");
                request.Headers.Add("HOSP_CODE", hosp_code);
                request.Headers.Add("PATIENT_CODE", bunho);
                Service.WriteLog("[BEGIN DOWNLOAD] - " + filePath);
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream fileStream = File.OpenWrite(filePath))
                    {
                        CopyStream(responseStream, fileStream);
                    }
                }
                Service.WriteLog("[END DOWNLOAD] - " + filePath);
            }
            catch (Exception ex)
            {
                Service.WriteLog("DONWLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }
        private static void CopyStream(Stream sourceStream, Stream targetStream)
        {
            CopyStreamWithPreview(sourceStream, targetStream, 0);
        }

        private static byte[] CopyStreamWithPreview(Stream sourceStream, Stream targetStream,
            int maxPreviewBytes)
        {
            if (sourceStream == null)
            {
                throw new ArgumentNullException("sourceStream");
            }

            if (targetStream == null)
            {
                throw new ArgumentNullException("targetStream");
            }

            if (!sourceStream.CanRead)
            {
                throw new ArgumentException("SourceStreamIsNotReadable");
            }

            if (!targetStream.CanWrite)
            {
                throw new ArgumentException("TargetStreamIsNotWritable");
            }

            int bufferSize = 2 << 20;
            byte[] buffer = new byte[bufferSize];
            List<Byte> byteArray = new List<byte>();

            int bytesRead = 0;
            while ((bytesRead = sourceStream.Read(buffer, 0, bufferSize)) != 0)
            {
                int index = 0;
                while (byteArray.Count < maxPreviewBytes && index < bytesRead)
                {
                    byteArray.Add(buffer[index]);
                    index++;
                }
                targetStream.Write(buffer, 0, bytesRead);
            }
            return byteArray.ToArray();
        }

        private void MediaDictionaryAdd(string hashCode, string filePath)
        {
            try
            {
                if (!this.MediaDictionary.ContainsKey(hashCode))
                    this.MediaDictionary.Add(hashCode, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        #endregion
        #endregion

        #region Event
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    //if (this.CurrMQLayout == this.grdTags)
                    //{
                    //    e.IsBaseCall = false;
                    //}
                    //else
                    //{
                    //    this.grdTemplate.QueryLayout(false);
                    //    this.InitTagCollection();
                    //}
                    this.grdLoadDocAndDepart.QueryLayout(true);
                    this.grdTemplate.QueryLayout(false);
                    this.grdTags.QueryLayout(true);
                    this.InitTagCollection();
                    isCheckInsertDocAndDep = true;
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

        private void grdTemplate_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string prevTemplateTypeValue = grdTemplate.GetItemValue(e.RowNumber, TYPE_NAME, DataBufferType.PreviousBuffer).ToString();
            string prevtemplateNameValue = grdTemplate.GetItemValue(e.RowNumber, TEMPLATE_NAME, DataBufferType.PreviousBuffer).ToString();
            string prevdescriptionValue = grdTemplate.GetItemValue(e.RowNumber, DESCRIPTION, DataBufferType.PreviousBuffer).ToString();

            string currentItemCombo = grdTemplate.GetItemString(e.RowNumber, TYPE_NAME);
            if (string.IsNullOrEmpty(currentItemCombo))
            {
                grdTemplate.SetItemValue(e.RowNumber, TYPE_NAME, prevTemplateTypeValue);
                /*grdTemplate.SetItemValue(e.RowNumber, TEMPLATE_NAME, prevtemplateNameValue);
                grdTemplate.SetItemValue(e.RowNumber, DESCRIPTION, prevdescriptionValue);*/
            }

            //!string.IsNullOrEmpty(grdTemplate.GetItemString(e.RowNumber, "sys_id")) &&
            //todo: recheck
            /*if (UserInfo.UserGroup.ToString() != ADMIN && UserInfo.UserID != grdTemplate.GetItemString(e.RowNumber, SYS_ID))
            {
                grdTemplate.SetItemValue(e.RowNumber, TYPE_NAME, prevTemplateTypeValue);
                grdTemplate.SetItemValue(e.RowNumber, TEMPLATE_NAME, prevtemplateNameValue);
                grdTemplate.SetItemValue(e.RowNumber, DESCRIPTION, prevdescriptionValue);
                XMessageBox.Show(Resource.EMR_M003, Resource.EMR_M004, MessageBoxIcon.Warning);
                return;
            }*/

            if (e.ColName == DEFAULT_FLG)
            {
                string dflg = grdTemplate.GetItemString(e.RowNumber, DEFAULT_FLG);
                if (dflg == "Y")
                {
                    for (int i = 0; i < grdTemplate.RowCount; i++)
                    {
                        if (i == e.RowNumber) continue;

                        this.grdTemplate.SetItemValue(i, DEFAULT_FLG, "N");
                    }
                }
            }
        }

        private void grdTags_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName.ToString() == TYPE)
            {
                string strType = grdTags.GetItemValue(e.RowNumber, TYPE).ToString();

                if (strType == IMAGE)
                {
                    /*grdTags.SetRowVisible(e.RowNumber, false);*/
                    grdTags.SetItemValue(e.RowNumber, COL_DEFAULT_CONTENT, string.Empty);
                    grdTags.SetItemValue(e.RowNumber, COL_URLLOCATION, string.Empty);
                    /*((XTextBox)((XEditGridCell)grdTags.CellInfos[e.RowNumber, 5]).CellEditor.Editor).ReadOnly = true;*/
                }
                else
                {
                    //Set emty for col default content with typeColumn != image
                    grdTags.SetItemValue(e.RowNumber, COL_DEFAULT_CONTENT, string.Empty);
                    grdTags.SetItemValue(e.RowNumber, COL_URLLOCATION, string.Empty);
                    grdTags.SetItemValue(e.RowNumber, BINARY, string.Empty);
                    /*((XTextBox)((XEditGridCell)grdTags.CellInfos[COL_DEFAULT_CONTENT]).CellEditor.Editor).ReadOnly = true;*/
                }
            }
            else if (e.ColName.ToString() != COL_DEFAULT_CONTENT)
            {
                string prevTagCodeValue = grdTags.GetItemValue(e.RowNumber, TAG_CODE, DataBufferType.PreviousBuffer).ToString();
                string prevTagNamValue = grdTags.GetItemValue(e.RowNumber, TAG_NAME, DataBufferType.PreviousBuffer).ToString();
                /*//Check permission
                if (UserInfo.UserGroup.ToString() != ADMIN && UserInfo.UserID != grdTemplate.GetItemString(int.Parse(_currentTemRowNum), SYS_ID))
                {
                    RollBackData(sender, e);
                    XMessageBox.Show(Resource.EMR_M003, Resource.EMR_M004, MessageBoxIcon.Warning);
                    return;
                }*/
                //Validate input data when add or edit tag
                //if (!TagValidateData())
                //{
                //    grdTags.SetItemValue(e.RowNumber, TAG_CODE, prevTagCodeValue);
                //    grdTags.SetItemValue(e.RowNumber, TAG_NAME, prevTagNamValue);
                //    grdTags.SetItemValue(e.RowNumber, DISPLAY_TXT, prevDisplayTxtValue);
                //    grdTags.SetItemValue(e.RowNumber, MEMO, prevMemoValue);
                //    return;
                //} 

                string newValue = grdTags.GetItemString(e.RowNumber, e.ColName).Trim();
                object[] item = GetDataSelected(lTagObj, this.grdTags.GetItemValue(e.RowNumber, e.ColName).ToString());
                if (item == null)
                    grdTags.SetItemValue(e.RowNumber, TAG_CODE, prevTagCodeValue);
                grdTags.SetItemValue(e.RowNumber, TAG_CODE, (string.IsNullOrEmpty(newValue) || item == null) ? prevTagNamValue : item[0]);
                grdTags.SetItemValue(e.RowNumber, TAG_NAME, (string.IsNullOrEmpty(newValue) || item == null) ? prevTagNamValue : item[1]);

                string tagLevel = grdTags.GetItemString(e.RowNumber, "tagLevel");
                if (tagLevel == ROOT)
                    grdTags.SetItemValue(e.RowNumber, "tagParent", (string.IsNullOrEmpty(newValue) || item == null) ? prevTagNamValue : item[0]);

                //Add validate for new rule
                List<string> childrentIndexLst = new List<string>();
                if (string.IsNullOrEmpty(prevTagCodeValue))
                {
                    //Add tag
                    bool ret = this.UpdateTag((int)actionType.Add, this.grdTags.GetItemString(e.RowNumber, TAG_CODE), this.grdTags.GetItemString(e.RowNumber, TAG_PARENT), e.RowNumber, out childrentIndexLst);
                    if (!ret)
                    {
                        RollBackData(sender, e);
                        return;
                    }
                }
                else
                {
                    //Edit tag
                    bool ret = this.UpdateTag((int)actionType.Edit, this.grdTags.GetItemString(e.RowNumber, TAG_CODE), this.grdTags.GetItemString(e.RowNumber, TAG_PARENT), e.RowNumber, out childrentIndexLst);
                    if (!ret)
                    {
                        RollBackData(sender, e);
                        return;
                    }
                }
                string mTagContent = this.GetTagsCode();
                this.UpdateTagCollection(_currentTemplateId, mTagContent);
                //this.grdTemplate.SetItemValue(int.Parse(_currentTemRowNum), TEMPLATE_CONTENT, mTagContent);
            }
        }

        private void grdTemplate_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            ((XFindBox)((XEditGridCell)grdTemplate.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.GetFindWorker(e.ColName);
        }

        private void grdTags_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            ((XFindBox)((XEditGridCell)grdTags.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.GetFindWorker(e.ColName);
        }

        private void grdTemplate_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdTemplate.SetBindVarValue("sys_id", _userId);
        }

        private void grdTags_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdTags.SetBindVarValue("str_tag_code ", _templateName);
        }

        private void grdTemplate_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            _currentTemplateId = this.grdTemplate.GetItemString(e.CurrentRow, TEMPLATE_ID).ToString();

            if (!string.IsNullOrEmpty(_currentTemplateId))
                this.grdTags.QueryLayout(false);
            else
                this.grdTags.Reset();
        }

        private void grdTags_GridCellFocusChanged(object sender, XGridCellFocusChangedEventArgs e)
        {
            string mTagContent = this.GetTagsCode();
            this.UpdateTagCollection(_currentTemplateId, mTagContent);
            //this.grdTemplate.SetItemValue(int.Parse(_currentTemRowNum), TEMPLATE_CONTENT, mTagContent);
            this.grdTags.GridCellFocusChanged -= new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdTags_GridCellFocusChanged);
        }

        private void grdUser_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdUser.SetBindVarValue("user_id", UserInfo.UserID);
            this.grdUser.SetBindVarValue("user_group", UserInfo.UserGroup);
            _userId = UserInfo.UserID;
            _userGroup = UserInfo.UserGroup;
        }

        private void grdUser_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            _userId = string.Empty;
            _userGroup = string.Empty;
            _userId = this.grdUser.GetItemString(e.CurrentRow, USER_ID).ToString(CultureInfo.InvariantCulture);
            _userGroup = this.grdUser.GetItemString(e.CurrentRow, USER_GROUP).ToString(CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(_userId) && !string.IsNullOrEmpty(_userGroup))
                this.grdTemplate.QueryLayout(false);
            else
                this.grdTemplate.Reset();
        }

        private void grdTags_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            if (e.ColName == "btnAddChild")
            {
                int rowHandle = grdTags.CurrentRowNumber;
                grdTags.InsertRow(rowHandle);

                /*string preTagLevel = grdTags.GetItemString(rowHandle - 1, TAG_LEVEL);
                if (string.IsNullOrEmpty(preTagLevel))
                    tagLevel = ROOT;*/

                string tagParent = grdTags.GetItemString(rowHandle, "tagParent");
                grdTags.SetItemValue(rowHandle + 1, TAG_LEVEL, NODE);
                grdTags.SetItemValue(rowHandle + 1, "tagParent", tagParent);
                grdTags.SetItemValue(rowHandle + 1, TYPE, TEXT);
            }
            else if (e.ColName == "btnAddImage")
            {
                ActionInsertImage(e.RowNumber);
            }
        }

        private void ActionInsertImage(int rowNumber)
        {
            string strType = grdTags.GetItemString(rowNumber, TYPE);
            if (strType == IMAGE)
            {
                BtnClickInsertImage(rowNumber);
            }
        }

        #endregion

        private void grdTemplate_GridCellFocusChanged(object sender, XGridCellFocusChangedEventArgs e)
        {
            /*if (e.ColName == DEFAULT_FLG)
            {
                string dflg = grdTemplate.GetItemString(e.RowNumber, DEFAULT_FLG);
                if (dflg == "Y")
                {
                    for (int i = 0; i < grdTemplate.RowCount; i++)
                    {
                        if (i == e.RowNumber) continue;

                        this.grdTemplate.SetItemValue(i, DEFAULT_FLG, "N");
                    }
                }
            }*/
        }

        private void grdTemplate_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell18.ExecuteQuery = LoadDataXEditGridCell18;
        }

        private IList<object[]> LoadDataXEditGridCell18(BindVarCollection varlist)
        {
            lGrdCboObj = new List<object[]>();
            OCS2015U31EmrTemplateTypeArgs args = new OCS2015U31EmrTemplateTypeArgs();
            OCS2015U31EmrTemplateTypeResult res = CloudService.Instance.Submit<OCS2015U31EmrTemplateTypeResult, OCS2015U31EmrTemplateTypeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.EmrTemplateTypeInfo != null)
                {
                    _dtTemplateCbo = ConvertToDataTable(res.EmrTemplateTypeInfo);
                    foreach (DataRow dtRow in _dtTemplateCbo.Rows)
                    {
                        lGrdCboObj.Add(new object[]
                        {
                            dtRow["template_type_id"],
                            dtRow["type_name"]
                        });
                    }
                }
            }

            return lGrdCboObj;
        }

        private void InitCboGrdTagType()
        {
            _dtGrdCbo = new DataTable();
            _dtGrdCbo.Columns.Add("TypeId", typeof(string));
            _dtGrdCbo.Columns.Add("TypeName", typeof(string));
            _dtGrdCbo.Rows.Add("0", TEXT);
            _dtGrdCbo.Rows.Add("1", IMAGE);

            this.grdTags.SetComboItems(TYPE, _dtGrdCbo, "TypeName", "TypeName");
        }

        private void BtnClickInsertImage(int currentRowNumber)
        {
            /*string strType = grdTags.GetItemString(currentRowNumber, COL_DEFAULT_CONTENT);*/
            string strType = grdTags.GetItemString(currentRowNumber, COL_URLLOCATION);
            if (!string.IsNullOrEmpty(strType))
            {
                //For Edit Image
                InsertImage(strType, strType, currentRowNumber);
            }
            else
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CLIP";
                if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
                {
                    if (!ActionCheckImageSize(dialog.FileName)) return;

                    InsertImage(dialog.FileName, dialog.FileName, currentRowNumber);
                }
            }
        }

        private bool ActionCheckImageSize(string originalFilePath)
        {
            string max_size = string.Empty;
            if (!CheckPdfUploadFile(originalFilePath, out max_size))
            {
                XMessageBox.Show(string.Format(Resource.OCS2015U31_CheckImageSizeMessage, max_size), Resource.OCS2015U31_ActionCheckImageSize_WARNING);
                return false;
            }

            return true;
        }

        private bool CheckPdfUploadFile(string fileName, out string max_size)
        {
            max_size = DataProvider.Instance.Pdf_max_size;
            try
            {
                if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName) || string.IsNullOrEmpty(DataProvider.Instance.Pdf_max_size)) return false;
                Double confSize = Double.Parse(DataProvider.Instance.Pdf_max_size);
                FileInfo fileInfo = new FileInfo(fileName);
                return (double)fileInfo.Length / (1024 * 1024) > confSize ? false : true;
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
                return false;
            }
        }


        private void InsertImage(string imagePath, string linkLocation, int currentRowNum)
        {
            string filePath = "";
            filePath = GetAbsoluteDataPath(NextSequence(BUNHO, GetFileName(imagePath), Path.GetExtension(imagePath)), BUNHO).Trim();
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
                if (fileInfo.Directory != null) Directory.CreateDirectory(fileInfo.Directory.FullName);

            SaveStreamToFile(filePath, File.ReadAllBytes(imagePath));

            //MED-8221
            Upload(filePath);

            EditImage(filePath, TypeEnum.Image, linkLocation, currentRowNum, false, true);
        }

        private void EditImage(string filePath, TypeEnum typeEnum, string linkLocation, int currentRowNumb, bool isEditImage, bool showControl)
        {
            // Get original image which is being edited
            DataProvider.ImageEditorInstance.Edit(filePath, linkLocation, typeEnum, 50, 50,
                delegate(byte[] data, float scaleX, float scaleY)
                {
                    Image img = Image.FromStream(new MemoryStream(data));
                    grdTags.SetItemValue(currentRowNumb, COL_DEFAULT_CONTENT, filePath);
                    grdTags.SetItemValue(currentRowNumb, COL_URLLOCATION, filePath);
                    grdTags.SetItemValue(currentRowNumb, "binary", img);

                }, this, showControl);
        }

        private void grdTags_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                XGrid xGrid = sender as XGrid;
                if (xGrid != null)
                {
                    if (xGrid.CurrentColName.ToString(CultureInfo.InvariantCulture) == BINARY)
                    {
                        ActionInsertImage(xGrid.CurrentRowNumber);
                    }
                }
            }
        }
        private void CheckReadOnlyCommonTeamplate(bool isA, bool isB)
        {
            xEditGridCell18.IsReadOnly = isA;
            xEditGridCell1.IsReadOnly = isA;
            xEditGridCell2.IsReadOnly = isA;
            xEditGridCell26.IsReadOnly = isB;
            xEditGridCell6.IsReadOnly = isA;
            xEditGridCell5.IsReadOnly = isA;
        }

        private void rbtCommonTemplate_CheckedChanged(object sender, EventArgs e)
        {
            grdTemplate.AutoSizeColumn(4, 57);
            CheckReadOnlyCommonTeamplate(true, false);
        }

        private void rbtUserTemplate_CheckedChanged(object sender, EventArgs e)
        {
            grdTemplate.AutoSizeColumn(4, 0);
            CheckReadOnlyCommonTeamplate(false, true);
            grdTemplate.QueryLayout(true);
            if (grdTemplate.RowCount == 0)
            {
                grdTags.Reset();
                return;
            }
            if (rbtUserTemplate.Checked)
            {
                btnList.SetEnabled(FunctionType.Insert,true);
            }
            else btnList.SetEnabled(FunctionType.Insert,false);
        }

        private void CheckUserAdminLogin()
        {
            if (UserInfo.UserGroup.ToString() == ADMIN)
            {
                //==========Set Location for panel =================
                this.Size = new Size(935, 538);
                pnLoadDeparAndDoctor.Location = new Point(0, 3);
                pnUserTemplate.Visible = false;
                xPnlTemplateManage.Location = new Point(276, 3);
                //===================================================
                pnLoadUser.Visible = false;
                pnLoadDeparAndDoctor.Visible = true;
                pnUserTemplate.Visible = false;
                grdTemplate.AutoSizeColumn(4, 0);
                btnList.SetEnabled(FunctionType.Insert, true);
                grdLoadDocAndDepart.QueryLayout(true);
                departCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_code");
                doctorCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_code");
                CheckReadOnlyAfterSave(true);
                _countGrdDocAndDepart = grdLoadDocAndDepart.RowCount;

            }
            else
            {
                //==========Set Location for panel =================
                this.Size = new Size(935, 580);
                pnLoadUser.Location = new Point(0, 35);
                pnUserTemplate.Visible = true;
                pnUserTemplate.Location = new Point(279, 3);
                xPnlTemplateManage.Location = new Point(276, 35);
                //===================================================
                pnLoadUser.Visible = true;
                pnLoadDeparAndDoctor.Visible = false;
                pnUserTemplate.Visible = true;
                grdTemplate.AutoSizeColumn(4, 73);
                CheckReadOnlyCommonTeamplate(true, false);
                btnList.SetEnabled(FunctionType.Insert, false);
            }
        }

        private void grdLoadDocAndDepart_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string departCodeCobobox = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_name");
            if (departCodeCobobox.ToLower() == "adm")
            {
                xEditGridCell29.IsReadOnly = true;  
            }
            else
            {
                xEditGridCell29.IsReadOnly = false;
            }
            LoadDataDoctor();          
        }       
        private void QueryComboboxData()
        {
            DataTable dtGrdCbodepartmentName = new DataTable();
            dtGrdCbodepartmentName.Columns.Add("Code", typeof(string));
            dtGrdCbodepartmentName.Columns.Add("CodeName", typeof(string));
            OCS2015U31LoadComboDepartArgs args = new OCS2015U31LoadComboDepartArgs();
            OCS2015U31LoadComboDepartResult result =
                CloudService.Instance.Submit<OCS2015U31LoadComboDepartResult, OCS2015U31LoadComboDepartArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo itemInfo in result.DepartInfo)
                {
                    dtGrdCbodepartmentName.Rows.Add(itemInfo.Code, itemInfo.CodeName);
                }
            }
            this.grdLoadDocAndDepart.SetComboItems("department_name", dtGrdCbodepartmentName, "CodeName", "Code");
            //===================================================================================================           
            LoadDataDoctor();
        }

        private void 
            
            LoadDataDoctor()
        {
            DataTable dtGrdCboDoctorInfo = new DataTable();
            dtGrdCboDoctorInfo.Columns.Add("Code", typeof(string));
            dtGrdCboDoctorInfo.Columns.Add("CodeName", typeof(string));

            OCS2015U31LoadComboDoctorArgs argsDoctor = new OCS2015U31LoadComboDoctorArgs();
            argsDoctor.DepartCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_name");
            OCS2015U31LoadComboDoctorResult resultargsDoctor = CloudService.Instance.Submit<OCS2015U31LoadComboDoctorResult, OCS2015U31LoadComboDoctorArgs>(argsDoctor);
            if (resultargsDoctor != null && resultargsDoctor.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo itemInfoDoctor in resultargsDoctor.DoctorInfo)
                {
                    dtGrdCboDoctorInfo.Rows.Add(itemInfoDoctor.Code, itemInfoDoctor.CodeName);
                }
            }
            this.grdLoadDocAndDepart.SetComboItems("doctor_name", dtGrdCboDoctorInfo, "CodeName", "Code");
        }

        private void CheckReadOnlyAfterSave(bool isCheckOnly)
        {
            xEditGridCell27.IsReadOnly = isCheckOnly;
            xEditGridCell29.IsReadOnly = isCheckOnly;
        }

        private void grdLoadDocAndDepart_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            _countGrdDocAndDepart = grdLoadDocAndDepart.CurrentRowNumber;
            departCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_code");
            doctorCode = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_code");
            isCheckLoad = true;
            this.grdTemplate.QueryLayout(false);
            if (e.CurrentRow == _countGrdDocAndDepart && isCheckInsert)
            {
                CheckReadOnlyAfterSave(false);
                isCheckInsert = false;
            }
            else CheckReadOnlyAfterSave(true);            
        }

        private bool CheckInsetDataUserAdmin()
        {
            for (int i = 0; i < grdLoadDocAndDepart.RowCount; i++)
            {
                string rowState = grdLoadDocAndDepart.GetRowState(i).ToString();
                if (rowState == DataRowState.Added.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckComboDocAndDepar()
        {
            string coboDoctor = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_name");
            string coboDepar = grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_name");
            if (grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "department_name") == string.Empty)
            {
                XMessageBox.Show(Resource.MSG_DEPART, Resource.EMR_M004, MessageBoxIcon.Warning);
                grdLoadDocAndDepart.SetFocusToItem(grdLoadDocAndDepart.CurrentRowNumber, "department_name");
                return false;
            }
            else
                if (coboDepar == "ADM" && coboDoctor == string.Empty)
                {

                }
                else
                {
                    if (grdLoadDocAndDepart.GetItemString(grdLoadDocAndDepart.CurrentRowNumber, "doctor_name") == string.Empty)
                    {
                        XMessageBox.Show(Resource.MSG_DOCTOR, Resource.EMR_M004, MessageBoxIcon.Warning);
                        grdLoadDocAndDepart.SetFocusToItem(grdLoadDocAndDepart.CurrentRowNumber, "doctor_name");
                        return false;
                    }
                } 
            return true;
        }
    }
}
