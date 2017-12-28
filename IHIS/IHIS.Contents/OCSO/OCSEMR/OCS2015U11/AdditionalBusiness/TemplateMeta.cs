using System.Collections.Generic;

namespace EmrDocker.AdditionalBusiness
{
    public class TemplateMeta
    {
        private string _emr_template_id = "";
        private string _emr_template_type_id = "";
        private string _template_code = "";
        private string _template_name = "";
        private string _template_content = "";
        private string _description = "";
        private string _permission_type = "";
        private string _sys_id = "";
        private string _upd_id = "";
        private string _default_yn = "";
        private Dictionary<string,string> _tag_list = new Dictionary<string, string>();

        public string EmrTemplateId
        {
            get { return _emr_template_id; }
            set { _emr_template_id = value; }
        }

        public string EmrTemplateTypeId
        {
            get { return _emr_template_type_id; }
            set { _emr_template_type_id = value; }
        }

        public string TemplateCode
        {
            get { return _template_code; }
            set { _template_code = value; }
        }

        public string TemplateName
        {
            get { return _template_name; }
            set { _template_name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string PermissionType
        {
            get { return _permission_type; }
            set { _permission_type = value; }
        }

        public string SysId
        {
            get { return _sys_id; }
            set { _sys_id = value; }
        }

        public string UpdId
        {
            get { return _upd_id; }
            set { _upd_id = value; }
        }
        public string DefaultYn
        {
            get { return _default_yn; }
            set { _default_yn = value; }
        }

        public Dictionary<string, string> TagList
        {
            get { return _tag_list; }
        }

        public string TemplateContent
        {
            get { return _template_content; }
            set
            {
                _template_content = value;
                _tag_list.Clear();
                string[] tmp = _template_content.Split(',');
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                // Count number of occurences of a tag in template
                foreach (string word in tmp)
                {
                    if (dictionary.ContainsKey(word))
                    {
                        dictionary[word] += 1;
                    }
                    else
                    {
                        dictionary.Add(word, 1);
                    }
                }
                foreach (KeyValuePair<string, int> keyValuePair in dictionary)
                {
                    // if a tag occurs more than 1, indexing it by format <tag_code>_i
                    if (keyValuePair.Value > 1)
                    {
                        for (int i = 1; i <= keyValuePair.Value; i++)
                        {
                            _tag_list.Add(keyValuePair.Key + "_" + i, "");
                        }
                    }
                    else
                    {
                        _tag_list.Add(keyValuePair.Key, "");
                    }
                }
            }
        }
    }

    public class TagMeta
    {
        private string _emr_tag_id = "";
        private string _tag_code = "";
        private string _tag_name = "";
        private string _tag_level = "";
        private string _tag_display_text = "";
        private string _tag_parent = "";
        private string _description = "";
        private string _permission_type = "";
        private string _sys_id = "";
        private string _upd_id = "";

        public string EmrTagId
        {
            get { return _emr_tag_id; }
            set { _emr_tag_id = value; }
        }

        public string TagCode
        {
            get { return _tag_code; }
            set { _tag_code = value; }
        }

        public string TagName
        {
            get { return _tag_name; }
            set { _tag_name = value; }
        }

        public string TagLevel
        {
            get { return _tag_level; }
            set { _tag_level = value; }
        }

        public string TagDisplayText
        {
            get { return _tag_display_text; }
            set { _tag_display_text = value; }
        }

        public string TagParent
        {
            get { return _tag_parent; }
            set { _tag_parent = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string PermissionType
        {
            get { return _permission_type; }
            set { _permission_type = value; }
        }

        public string SysId
        {
            get { return _sys_id; }
            set { _sys_id = value; }
        }

        public string UpdId
        {
            get { return _upd_id; }
            set { _upd_id = value; }
        }
    }

}
