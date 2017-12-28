using System;
using EmrDocker.Glossary;

namespace EmrDocker.Models
{
    [Serializable]
    public class TagInfo
    {
        private String _id;
        private int _order;
        private String _tagCode;
        private String _tagName;
        private object _content;
        private TypeEnum _type;
        private String _createDate;
        private String _dirLocation;
        private int _permission;
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public String TagCode
        {
            get { return _tagCode; }
            set { _tagCode = value; }
        }

        public String TagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }

        public object Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public TypeEnum Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public String CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public String DirLocation
        {
            get { return _dirLocation; }
            set { _dirLocation = value; }
        }

        public int Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }

        public TagInfo()
        {
        }

        public TagInfo(String id, int order, String tagCode, String tagName, object content, TypeEnum type, String createDate, String dirLocation, int permission)
        {
            _id = id;
            _order = order;
            _tagCode = tagCode;
            _tagName = tagName;
            _content = content;
            _type = type;
            _createDate = createDate;
            _dirLocation = dirLocation;
            _permission = permission;
        }

    }
}