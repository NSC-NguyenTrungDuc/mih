using DevExpress.XtraBars;
using EmrDocker.Models;

namespace IHIS.OCSO
{
    using System;
    using System.Collections.Generic;

    using DevExpress.XtraEditors.Repository;

    using global::EmrDocker;
    using global::EmrDocker.Glossary;

    using IHIS.CloudConnector;
    using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
    using IHIS.CloudConnector.Contracts.Models.OcsEmr;
    using IHIS.CloudConnector.Contracts.Results;
    using IHIS.CloudConnector.Contracts.Results.OcsEmr;

    //using MediaEditor;

    public class DataProvider
    {
        //Todo: refactor code Dictionary (DicTags)
        private Dictionary<String, List<String>> tags = new Dictionary<string, List<string>>();
        private Dictionary<String, OCS2015U06Businesses.TagInfo> tagDetail = new Dictionary<string, OCS2015U06Businesses.TagInfo>();
        private Dictionary<string, string> _tagDetailCodeName = new Dictionary<string, string>();
        private Dictionary<String, OCS2015U06Businesses.TagInfo> tagDetailClinicRefer = new Dictionary<string, OCS2015U06Businesses.TagInfo>();
        private Dictionary<string, string> _tagDetailCodeNameClinicRefer = new Dictionary<string, string>();
        private Dictionary<String, OCS2015U06Businesses.TagInfo> _tagParentDetail = new Dictionary<string, OCS2015U06Businesses.TagInfo>();
        private Dictionary<String, OCS2015U06Businesses.TagInfo> _dicParentTagInfos = new Dictionary<string, OCS2015U06Businesses.TagInfo>();
        private static readonly DataProvider _instance = new DataProvider();
        private Dictionary<string, string> _dicTemplateTagItems = new Dictionary<string, string>();
        private Dictionary<string, string> _dicTemplateTagClinicReferItems = new Dictionary<string, string>();
        private static readonly IImageEditor _imageEditor = new PdnEditor();
        private List<TemplateTagItem> listTemplateTagItems = new List<TemplateTagItem>(); 
        private string pdf_max_size = string.Empty;
        //private static readonly IImageEditor _imageEditor = new MediaEditorDll();

        public Dictionary<string, OCS2015U06Businesses.TagInfo> DicParentTagInfos
        {
            get { return _dicParentTagInfos; }
        }

        /// <summary>
        /// Setup Tag display mode for U06, U09, U44
        /// </summary>
        /// <param name="cboItems">BarEditItem.Edit property</param>
        public void TagDisplayModeSetup(BarEditItem cboDisplayMode)
        {
            RepositoryItemComboBox cboItems = cboDisplayMode.Edit as RepositoryItemComboBox;

            if (cboItems != null)
            {
                cboItems.Items.Clear();
                cboItems.Items.Add(StringEnum.GetStringValue(TagOption.TagCode));
                cboItems.Items.Add(StringEnum.GetStringValue(TagOption.TagDisplay));
                cboItems.Items.Add(StringEnum.GetStringValue(TagOption.Both));

                cboDisplayMode.EditValue = cboItems.Items[2];
            }
        }

        private DataProvider()
        {
            //Get max size of PDF file
            OCS2015U00GetMaxSizeArgs args = new OCS2015U00GetMaxSizeArgs();
            OCS2015U00GetMaxSizeResult result = CloudService.Instance.Submit<OCS2015U00GetMaxSizeResult, OCS2015U00GetMaxSizeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                this.pdf_max_size = result.MaxSize;
            }
        }

        public void ReloadLatestTags()
        {
            tags.Clear();
            tagDetail.Clear();
            OCS2015U06EmrTagArgs args = new OCS2015U06EmrTagArgs();
            OCS2015U06EmrTagResult result = CloudService.Instance.Submit<OCS2015U06EmrTagResult, OCS2015U06EmrTagArgs>(args, true);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                _dicParentTagInfos.Clear();
                foreach (OCS2015U06EmrTagInfo tag in result.EmrTagList)
                {
                    if (tag.TagCode == "CR")
                    {
                        int a = 0;
                    }
                    if (tag.TagLevel == "R")
                    {
                        if (!tags.ContainsKey(tag.TagCode.Trim()))
                        {
                            tags.Add(tag.TagCode.Trim(), new List<string>());
                            tagDetail.Add(tag.TagCode.Trim(), new OCS2015U06Businesses.TagInfo(tag.TagCode.Trim(), tag.TagName.Trim()));

                            if (!_dicTemplateTagItems.ContainsKey(tag.TagCode.Trim()))
                            {
                                _dicTemplateTagItems.Add(tag.TagCode.Trim(), tag.TagName.Trim());
                            }
                        }

                        if (!_dicParentTagInfos.ContainsKey(tag.TagCode.Trim()))
                        {
                            _dicParentTagInfos.Add(tag.TagCode.Trim(), new OCS2015U06Businesses.TagInfo(tag.TagCode.Trim(), tag.TagName.Trim()));
                        }
                    }
                    else if (tag.TagLevel == "N")// && tag.TagParent.Trim().Equals("")) // node tags which have no parent
                    {
                        if (!tags.ContainsKey(tag.TagCode.Trim()))
                        {
                            tags.Add(tag.TagCode.Trim(), new List<string>());
                            tagDetail.Add(tag.TagCode.Trim(), new OCS2015U06Businesses.TagInfo(tag.TagCode.Trim(), tag.TagName.Trim()));
                            if (!_tagParentDetail.ContainsKey(tag.TagCode.Trim()))
                            {
                                _tagParentDetail.Add(tag.TagCode.Trim(), new OCS2015U06Businesses.TagInfo(tag.TagCode.Trim(), tag.TagName.Trim()));
                            }
                            if (!_dicTemplateTagItems.ContainsKey(tag.TagCode.Trim()))
                            {
                                _dicTemplateTagItems.Add(tag.TagCode.Trim(), tag.TagName.Trim());
                            }
                        }

                        if (!_tagDetailCodeName.ContainsKey(tag.TagCode.Trim()))
                        {
                            _tagDetailCodeName.Add(tag.TagCode.Trim(), tag.TagName.Trim());

                            if (!_dicTemplateTagItems.ContainsKey(tag.TagCode.Trim()))
                            {
                                _dicTemplateTagItems.Add(tag.TagCode.Trim(), tag.TagName.Trim());
                            }
                        }
                    }
                }
            }
        }


        public void ReloadLatestTagsClinicRefer(string hospCode)
        {
            OCS2015U06EmrTagArgs args = new OCS2015U06EmrTagArgs();
            args.HospCode = hospCode;
            OCS2015U06EmrTagResult result = CloudService.Instance.Submit<OCS2015U06EmrTagResult, OCS2015U06EmrTagArgs>(args, true);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                tagDetailClinicRefer.Clear();
                _tagDetailCodeNameClinicRefer.Clear();
                foreach (OCS2015U06EmrTagInfo tag in result.EmrTagList)
                {
                    if (tag.TagLevel == "R")
                    {
                        tagDetailClinicRefer.Add(tag.TagCode.Trim(), new OCS2015U06Businesses.TagInfo(tag.TagCode.Trim(), tag.TagName.Trim()));
                        if (!_dicTemplateTagClinicReferItems.ContainsKey(tag.TagCode.Trim()))
                        {
                            _dicTemplateTagClinicReferItems.Add(tag.TagCode.Trim(), tag.TagName.Trim());
                        }
                    }
                    else if (tag.TagLevel == "N" && tag.TagParent.Trim().Equals("")) // node tags which have no parent
                    {
                        tagDetailClinicRefer.Add(tag.TagCode.Trim(), new OCS2015U06Businesses.TagInfo(tag.TagCode.Trim(), tag.TagName.Trim()));
                        if (!_dicTemplateTagClinicReferItems.ContainsKey(tag.TagCode.Trim()))
                        {
                            _dicTemplateTagClinicReferItems.Add(tag.TagCode.Trim(), tag.TagName.Trim());
                        }
                    }
                    else if (tag.TagLevel == "N" && !tag.TagParent.Trim().Equals(""))
                    {
                        //tagDetailClinicRefer.Add(tag.TagCode.Trim(), new OCS2015U06Businesses.TagInfo(tag.TagCode.Trim(), tag.TagName.Trim()));
                        if (!_dicTemplateTagClinicReferItems.ContainsKey(tag.TagCode.Trim()))
                        {
                            _dicTemplateTagClinicReferItems.Add(tag.TagCode.Trim(), tag.TagName.Trim());
                        }
                    }
                }

                foreach (OCS2015U06EmrTagInfo tag in result.EmrTagList)
                {
                    if (tag.TagLevel == "N" && !tag.TagParent.Trim().Equals("")) // node tags which have parent
                    {
                        if (tags.ContainsKey(tag.TagParent.Trim()))
                        {
                            tags[tag.TagParent.Trim()].Add(tag.TagCode.Trim());

                            if (!_dicTemplateTagClinicReferItems.ContainsKey(tag.TagCode.Trim()))
                            {
                                _dicTemplateTagClinicReferItems.Add(tag.TagCode.Trim(), tag.TagName.Trim());
                            }
                        }
                        string tagMix = string.Format("{0}-{1}", tag.TagParent.Trim(), tag.TagCode.Trim());
                        if (!tagDetail.ContainsKey(tagMix))
                        {
                            tagDetail.Add(tagMix, new OCS2015U06Businesses.TagInfo(tag.TagCode.Trim(), tag.TagName.Trim()));

                            if (!_dicTemplateTagClinicReferItems.ContainsKey(tag.TagCode.Trim()))
                            {
                                _dicTemplateTagClinicReferItems.Add(tag.TagCode.Trim(), tag.TagName.Trim());
                            }
                        }
                        if (!_tagDetailCodeNameClinicRefer.ContainsKey(tag.TagCode.Trim()))
                        {
                            _tagDetailCodeNameClinicRefer.Add(tag.TagCode.Trim(), tag.TagName.Trim());

                            if (!_dicTemplateTagClinicReferItems.ContainsKey(tag.TagCode.Trim()))
                            {
                                _dicTemplateTagClinicReferItems.Add(tag.TagCode.Trim(), tag.TagName.Trim());
                            }
                        }
                    }
                }

            }
        }


        

        public static DataProvider Instance
        {
            get
            {
                return _instance;
            }
        }

        public Dictionary<string, List<string>> Tags
        {
            get
            {
                return tags;
            }
        }

        public Dictionary<string, string> DicTemplateTagItems
        {
            get
            {
                return _dicTemplateTagItems;
            }
        }

        public Dictionary<string, string> DicTemplateTagClinicReferItems
        {
            get
            {
                return _dicTemplateTagClinicReferItems;
            }
        }

        public Dictionary<string, string> TagDetailCodeName
        {
            get
            {
                return _tagDetailCodeName;
            }
        }

        public Dictionary<string, string> TagDetailCodeNameClinicRefer
        {
            get
            {
                return _tagDetailCodeNameClinicRefer;
            }
        }

        public Dictionary<string, OCS2015U06Businesses.TagInfo> TagDetail
        {
            get
            {
                return tagDetail;
            }
        }
        public Dictionary<string, OCS2015U06Businesses.TagInfo> TagDetailClinicRefer
        {
            get
            {
                return tagDetailClinicRefer;
            }
        }

        

        public Dictionary<string, OCS2015U06Businesses.TagInfo> TagParentDetail
        {
            get
            {
                return _tagParentDetail;
            }
        }

        public List<string> AllTags
        {
            get
            {
                List<string> ret = new List<string>();
                foreach (KeyValuePair<string, List<string>> pair in tags)
                {
                    ret.Add(pair.Key);
                    foreach (string subTag in pair.Value)
                    {
                        ret.Add(String.Format("{0}-{1}", pair.Key, subTag));
                    }

                }
                return ret;
            }
        }

        public static IImageEditor ImageEditorInstance
        {
            get
            {
                return _imageEditor;
            }
        }
        public string Pdf_max_size
        {
            get
            {
                return pdf_max_size;
            }
        }
    }
}