using System;
using System.Collections.Generic;
using System.Text;
using MedicalInterface.Mml23.MmlFc;
using MedicalInterface.Mml23.MmlDp;
using System.Xml;

namespace IHIS.Framework.Mml23.MmlRe
{
    public class ReferToFacility
    {
        private Facility facility;
        private Department department;

        public Facility Facility
        {
            get { return facility; }
            set { facility = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public string NameSpaceURI
        {
            get { return ReferralModule.NameSpaceURI; }
        }

        public string NameSpacePrefix
        {
            get { return ReferralModule.NameSpacePrefix; }
        }

        public ReferToFacility()
        {
            Facility = new Facility();
            Department = new Department();
        }

        public ReferToFacility(XmlNode node)
        {
            Facility = new Facility();
            Department = new Department();
            this.LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            nsmgr.AddNamespace(MedicalInterface.Mml23.MmlFc.Facility.NameSpacePrefix, MedicalInterface.Mml23.MmlFc.Facility.NameSpaceURI);
            nsmgr.AddNamespace(MedicalInterface.Mml23.MmlDp.Department.NameSpacePrefix, MedicalInterface.Mml23.MmlDp.Department.NameSpaceURI);
            //XmlNode subnode = node.SelectSingleNode("mmlRe:referToFacility", nsmgr);
            XmlNode subnode = node;

            if (subnode != null)
            {
                this.Facility = new Facility(subnode.SelectSingleNode("mmlFc:Facility", nsmgr));
                this.Department = new Department(subnode.SelectSingleNode("mmlDp:Department", nsmgr));
            }
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "referToFacility", NameSpaceURI);

            node.AppendChild(Facility.WriteXml(doc));
            node.AppendChild(Department.WriteXml(doc));

            return node;
        }
    }
}
