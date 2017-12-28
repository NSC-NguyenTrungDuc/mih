using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlBody {

        private List<MmlModuleItem> ModuleList;

        public MmlBody() {
            ModuleList = new List<MmlModuleItem>();
        }

        public MmlBody(XmlNode node) {
            ModuleList = new List<MmlModuleItem>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            foreach (XmlNode mdl in node.ChildNodes) {
                if (mdl.LocalName == "MmlModuleItem") {
                    this.ModuleList.Add(new MmlModuleItem(mdl));
                }
            }
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement("MmlBody");

            foreach (MmlModuleItem itm in this.ModuleList) {
                node.AppendChild(itm.WriteXml(doc));
            }

            return node;
        }

        public void AddModuleItem(MmlModuleItem mdl) {
            this.ModuleList.Add(mdl);
        }

        public List<MmlModuleItem> Modules
        {
            get
            {
                return ModuleList;
            }
        }

    }
}
