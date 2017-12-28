using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlContent {

        public MmlContent() {
        }

        public MmlContent(XmlNode node) {
            LoadFromXml(node);
        }

        public virtual void LoadFromXml(XmlNode node) {
            throw new NotImplementedException();
        }

        protected XmlAttribute GetAttribute(XmlNode node, string attrname) {
            List<XmlAttribute> lst = new List<XmlAttribute>(GetAttributeByName(node, attrname));
            if (lst.Count > 0) {
                return lst[0];
            } else {
                return null;
            }
        }

        private IEnumerable<XmlAttribute> GetAttributeByName(XmlNode node, string attrname)
        {
            // from XmlAttribute attr in node.Attributes where attr.Name == attrname select attr
            List<XmlAttribute> attrs = new List<XmlAttribute>();
            foreach (XmlAttribute attribute in node.Attributes)
            {
                if(attribute.Name == attrname) attrs.Add(attribute);
            }
            return attrs;
        }

        public virtual XmlElement WriteXml(XmlDocument doc) {
            throw new NotImplementedException("MmlContentの実装が行われていません。");
        }

    }
}
