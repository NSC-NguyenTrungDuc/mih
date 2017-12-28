using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using MedicalInterface.Mml23.MmlCi;
using MedicalInterface.Mml23.MmlCm;

namespace MedicalInterface.Mml23
{
    public class MmlDocumentInfo
    {
        private string _contentModuleType;
        private string _templateId;
        private List<MmlAccessRight> _accessRightList;
        private string _title;
        private string _docId;
        private List<MmlParentId> _parentIdList;
        private List<MmlGroupId> _groupIdList;
        private DateTime _confirmDate;
        private CreatorInfo _creator;
        private List<ExternalReference> _extRefList;

        public string ContentModuleType
        {
            get { return _contentModuleType; }
            set { _contentModuleType = value; }
        }

        public string TemplateId
        {
            get { return _templateId; }
            set { _templateId = value; }
        }

        public List<MmlAccessRight> AccessRightList
        {
            get { return _accessRightList; }
            set { _accessRightList = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string DocId
        {
            get { return _docId; }
            set { _docId = value; }
        }

        public List<MmlParentId> ParentIdList
        {
            get { return _parentIdList; }
            set { _parentIdList = value; }
        }

        public List<MmlGroupId> GroupIdList
        {
            get { return _groupIdList; }
            set { _groupIdList = value; }
        }

        public DateTime ConfirmDate
        {
            get { return _confirmDate; }
            set { _confirmDate = value; }
        }

        public MmlCi.CreatorInfo Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }

        public List<MmlCm.ExternalReference> ExtRefList
        {
            get { return _extRefList; }
            set { _extRefList = value; }
        }

        public MmlDocumentInfo()
        {
            this.AccessRightList = new List<MmlAccessRight>();
            this.ParentIdList = new List<MmlParentId>();
            this.GroupIdList = new List<MmlGroupId>();
            this.ExtRefList = new List<MmlCm.ExternalReference>();
        }

        public MmlDocumentInfo(XmlNode node)
        {
            this.AccessRightList = new List<MmlAccessRight>();
            this.ParentIdList = new List<MmlParentId>();
            this.GroupIdList = new List<MmlGroupId>();
            this.ExtRefList = new List<MmlCm.ExternalReference>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node)
        {
            XmlAttribute attr;

            this.ContentModuleType = node.Attributes["contentModuleType"].Value;

            attr = node.Attributes["templateId"];
            if (attr != null)
            {
                this.TemplateId = attr.Value;
            }
            else
            {
                TemplateId = "";
            }

            this.DocId = node.SelectSingleNode("docId/uid").InnerText.Trim();

            foreach (XmlNode pid in node.SelectNodes("docId/parentid"))
            {
                this.ParentIdList.Add(new MmlParentId(pid));
            }

            foreach (XmlNode gid in node.SelectNodes("docId/groupid"))
            {
                this.GroupIdList.Add(new MmlGroupId(gid));
            }

            this.Title = node.SelectSingleNode("title").InnerText.Trim();

            this.ConfirmDate = DateTime.Parse(node.SelectSingleNode("confirmDate").InnerText.Trim());

            foreach (XmlNode acc in node.SelectNodes("securityLevel/accessRight"))
            {
                this.AccessRightList.Add(new MmlAccessRight(acc));
            }

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace("mmlCi", "http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0");

            this.Creator = new MmlCi.CreatorInfo(node.SelectSingleNode("mmlCi:CreatorInfo", nsmgr));

            foreach (XmlNode er in node.SelectNodes("extRefs"))
            {
                this.ExtRefList.Add(new MmlCm.ExternalReference(er));
            }

        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("docInfo");

            XmlAttribute attr;
            attr = doc.CreateAttribute("contentModuleType");
            attr.Value = this.ContentModuleType;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute("templateId");
            attr.Value = this.TemplateId;
            node.Attributes.Append(attr);

            XmlElement elm1;
            XmlElement elm2;

            // 2015.11.07 Cloud edited START
            if (!string.IsNullOrEmpty(this.DocId))
            {
                elm1 = doc.CreateElement("docId");
                elm2 = doc.CreateElement("uid");
                elm2.AppendChild(doc.CreateTextNode(this.DocId));
                elm1.AppendChild(elm2.Clone());
                foreach (MmlParentId itm in this.ParentIdList)
                {
                    elm2.AppendChild(itm.WriteXml(doc));
                    elm1.AppendChild(elm2.Clone());
                }
                foreach (MmlGroupId itm in this.GroupIdList)
                {
                    elm2.AppendChild(itm.WriteXml(doc));
                    elm1.AppendChild(elm2.Clone());
                }
                node.AppendChild(elm1);
            }

            if (!string.IsNullOrEmpty(this.Title))
            {
                elm1 = doc.CreateElement("title");
                elm1.AppendChild(doc.CreateTextNode(this.Title));
                node.AppendChild(elm1);
            }

            if (this.ConfirmDate != DateTime.MinValue)
            {
                elm1 = doc.CreateElement("confirmDate");
                elm1.AppendChild(doc.CreateTextNode(this.ConfirmDate.ToString("yyyy/MM/dd")));
                node.AppendChild(elm1);
            }

            if (this.AccessRightList.Count > 0)
            {
                elm1 = doc.CreateElement("securityLevel");
                foreach (MmlAccessRight itm in this.AccessRightList)
                {
                    elm1.AppendChild(itm.WriteXml(doc));
                    //elm1.AppendChild(elm2);
                }
                node.AppendChild(elm1);
            }
            // 2015.11.07 Cloud edited END

            if (this.Creator != null)
            {
                node.AppendChild(this.Creator.WriteXml(doc));
            }

            foreach (MmlCm.ExternalReference itm in this.ExtRefList)
            {
                node.AppendChild(itm.WriteXml(doc));
            }


            return node;
        }

    }
}
