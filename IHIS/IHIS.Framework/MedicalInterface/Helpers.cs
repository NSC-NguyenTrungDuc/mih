using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface {

    public class XmlNodeHelper {

        private XmlNode _Node;

        public XmlNode Node {
            get { return _Node; }
        }

        private XmlNamespaceManager _NameSpaceManager;

        public XmlNamespaceManager NamespaceManager {
            get { return _NameSpaceManager; }
        }

        public XmlNodeHelper(XmlNode node) {
            this._Node = node;
            this._NameSpaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
        }

        public string GetAttributeString(string attrname) {
            return GetAttributeString(attrname, null);
        }

        public string GetAttributeString(string attrname,string nullval) {
            XmlAttribute attr;
            attr = Node.Attributes[attrname];
            if (attr != null) {
                return attr.Value;
            } else {
                return nullval;
            }

        }

        public DateTime GetAttributeDate(string attrname, DateTime nullval) {
            string dttxt = GetAttributeString(attrname);
            if (dttxt != null) {
                DateTime ret;
                if(DateTime.TryParse(dttxt,out ret)){
                    return ret;
                }
            }
            return nullval;
        }

        public string GetNodeText(string xpath) {
            return GetNodeText(xpath, null);
        }

        public string GetNodeText(string xpath, string nullval) {
            XmlNode node = this.Node.SelectSingleNode(xpath,this.NamespaceManager);
            if (node != null) {
                return node.InnerText;
            } else {
                return nullval;
            }
        }

        public int GetNodeTextToInteger(string xpath, int nullval) {
            string ndtxt = GetNodeText(xpath);
            int ret;
            if (!int.TryParse(ndtxt, out ret)) {
                ret = nullval;
            }
            return ret;
        }

        public string GetChildNodeAttributeString(string xpath, string attrname) {
            return GetChildNodeAttributeString(xpath, attrname, null);
        }

        public string GetChildNodeAttributeString(string xpath, string attrname, string nullval) {
            XmlNode node = this.Node.SelectSingleNode(xpath, this.NamespaceManager);
            if (node != null) {
                XmlAttribute attr;
                attr = node.Attributes[attrname];
                if (attr != null) {
                    return attr.Value;
                }
            }
            return nullval;
        }

        public XmlNode GetNode(string xpath) {
            return this.Node.SelectSingleNode(xpath, NamespaceManager);
        }

        public XmlNodeList SelectNodes(string xpath) {
            return this.Node.SelectNodes(xpath, NamespaceManager);
        }
    }

}