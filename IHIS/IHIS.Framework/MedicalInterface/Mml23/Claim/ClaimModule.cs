using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using MedicalInterface.Mml23.MmlDp;
using MedicalInterface.Mml23.MmlHi;

namespace MedicalInterface.Mml23.Claim {
    public class ClaimModule : Mml23.MmlContent {
        private string _status;
        private DateTime _orderTime;
        private DateTime _appointTime;
        private DateTime _registTime;
        private DateTime _performTime;
        private bool _admitFlag;
        private string _timeClass;
        private string _insuranceUid;
        private string _defaultTableId;
        private List<AppointItem> _appointList;
        private Department _patientDepartment;
        private Department _patientWard;
        private HealthInsurance _insurance;
        private List<BundleItem> _bundleList;
        private List<BundleDetailItem> _bundleDetailList;
        private string _gwaName;

        public const string NameSpaceURI= "http://www.medxml.net/claim/claimModule/2.1";

        public const string NameSpacePrefix = "claim";

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public DateTime OrderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        public DateTime AppointTime
        {
            get { return _appointTime; }
            set { _appointTime = value; }
        }

        public DateTime RegistTime
        {
            get { return _registTime; }
            set { _registTime = value; }
        }

        public DateTime PerformTime
        {
            get { return _performTime; }
            set { _performTime = value; }
        }

        public bool AdmitFlag
        {
            get { return _admitFlag; }
            set { _admitFlag = value; }
        }

        public string TimeClass
        {
            get { return _timeClass; }
            set { _timeClass = value; }
        }

        public string InsuranceUid
        {
            get { return _insuranceUid; }
            set { _insuranceUid = value; }
        }

        public string DefaultTableId
        {
            get { return _defaultTableId; }
            set { _defaultTableId = value; }
        }

        public List<AppointItem> AppointList
        {
            get { return _appointList; }
            set { _appointList = value; }
        }

        public MmlDp.Department PatientDepartment
        {
            get { return _patientDepartment; }
            set { _patientDepartment = value; }
        }

        public MmlDp.Department PatientWard
        {
            get { return _patientWard; }
            set { _patientWard = value; }
        }

        public MmlHi.HealthInsurance Insurance
        {
            get { return _insurance; }
            set { _insurance = value; }
        }

        public List<BundleItem> BundleList
        {
            get { return _bundleList; }
            set { _bundleList = value; }
        }

        public string GwaName
        {
            get { return _gwaName; }
            set { _gwaName = value; }
        }

        public List<BundleDetailItem> BundleDetailList
        {
            get { return _bundleDetailList; }
            set { _bundleDetailList = value; }
        }

        public ClaimModule() {
            _appointList = new List<AppointItem>();
            _bundleList = new List<BundleItem>();
        }

        public ClaimModule(XmlNode node) {
            _appointList = new List<AppointItem>();
            _bundleList = new List<BundleItem>();
            LoadFromXml(node);
        }

        public override void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            LoadInformationFromXml(node.SelectSingleNode("claim:information", nsmgr), nsmgr);

            this.BundleList = new List<BundleItem>();
            foreach (XmlNode bdlnode in node.SelectNodes("claim:bundle",nsmgr)) {
                BundleItem bdl = new BundleItem(bdlnode);
                this.BundleList.Add(bdl);
            }
        }

        private void LoadInformationFromXml(XmlNode node, XmlNamespaceManager nsmgr) {

            this.Status = node.Attributes["status", NameSpaceURI].Value;
            XmlAttribute attr;
            attr = node.Attributes["oderTime", NameSpaceURI];
            if (attr != null) {
                this.OrderTime = DateTime.Parse(attr.Value);
            }
            attr = node.Attributes["appointTime", NameSpaceURI];
            if (attr != null) {
                this.AppointTime = DateTime.Parse(attr.Value);
            }
            attr = node.Attributes["registTime", NameSpaceURI];
            if (attr != null) {
                this.RegistTime = DateTime.Parse(attr.Value);
            }
            attr = node.Attributes["performTime", NameSpaceURI];
            if (attr != null) {
                this.PerformTime = DateTime.Parse(attr.Value);
            }

            this.AdmitFlag = bool.Parse(node.Attributes["admitFlag", NameSpaceURI].Value);

            this.AppointList = new List<AppointItem>();
            foreach (XmlNode appnode in node.SelectNodes("claim:appoint",nsmgr)) {
                AppointItem app = new AppointItem(appnode);
                this.AppointList.Add(app);
            }

            XmlNode subnode;
            subnode = node.SelectSingleNode("claim:patientDepartment", nsmgr);
            if (subnode != null && subnode.ChildNodes.Count>0) {
                this.PatientDepartment = new MmlDp.Department(subnode.FirstChild);
            }
            subnode = node.SelectSingleNode("claim:patientWard", nsmgr);
            if (subnode != null && subnode.ChildNodes.Count > 0) {
                this.PatientWard = new MmlDp.Department(subnode.FirstChild);
            }

            subnode = node.SelectSingleNode("claim:insuranceClass", nsmgr);
            if (subnode != null) {
                this.Insurance = new MmlHi.HealthInsurance(subnode);
            }

        }

        public override XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement rootNode = doc.CreateElement(NameSpacePrefix, "ClaimModule", NameSpaceURI);
            XmlElement nodeLevel1;
            XmlElement nodeLevel2;
            XmlElement nodeLevel3;
            XmlElement nodeLevel4;
            XmlAttribute attr;

            #region Infomation

            // information - Level 1
            nodeLevel1 = doc.CreateElement(NameSpacePrefix, "information", NameSpaceURI);
            attr = doc.CreateAttribute(NameSpacePrefix, "status", NameSpaceURI);
            attr.Value = this.Status;
            nodeLevel1.Attributes.Append(attr);
            // registTime attr
            if (this.RegistTime != DateTime.MinValue)
            {
                attr = doc.CreateAttribute(NameSpacePrefix, "registTime", NameSpaceURI);
                attr.Value = this.RegistTime.ToString("yyyy-MM-ddTHH:mm:ss");
                nodeLevel1.Attributes.Append(attr);
            }

            // Perform time
            if (this.PerformTime != DateTime.MinValue)
            {
                attr = doc.CreateAttribute(NameSpacePrefix, "performTime", NameSpaceURI);
                attr.Value = this.PerformTime.ToString("yyyy-MM-ddTHH:mm:ss");
                nodeLevel1.Attributes.Append(attr);
            }

            // admitFlag attr
            attr = doc.CreateAttribute(NameSpacePrefix, "admitFlag", NameSpaceURI);
            attr.Value = this.AdmitFlag.ToString();
            nodeLevel1.Attributes.Append(attr);
            // classTime attr
            if (!string.IsNullOrEmpty(this.TimeClass))
            {
                attr = doc.CreateAttribute(NameSpacePrefix, "timeClass", NameSpaceURI);
                attr.Value = this.TimeClass;
                nodeLevel1.Attributes.Append(attr);
            }
            // insuranceUid attr
            if (!string.IsNullOrEmpty(this.InsuranceUid))
            {
                attr = doc.CreateAttribute(NameSpacePrefix, "insuranceUid", NameSpaceURI);
                attr.Value = this.InsuranceUid;
                nodeLevel1.Attributes.Append(attr);
            }

            // appoint - Level 2
            //nodeLevel2 = doc.CreateElement(NameSpacePrefix, "appoint", NameSpaceURI);
            //nodeLevel1.AppendChild(nodeLevel2);

            // memo - Level 3
            //nodeLevel3 = doc.CreateElement(NameSpacePrefix, "memo", NameSpaceURI);
            //if (this.AppointList.Count > 0)
            //{
            //    nodeLevel3.AppendChild(doc.CreateTextNode(this.AppointList[0].Memo));
            //}
            //nodeLevel2.AppendChild(nodeLevel3);
            //nodeLevel1.AppendChild(nodeLevel2);
            rootNode.AppendChild(nodeLevel1);

            // patientDepartment - Level 2
            nodeLevel2 = doc.CreateElement(Department.NameSpacePrefix, "patientDepartment", Department.NameSpaceURI);
            // Department - Level 3
            nodeLevel3 = doc.CreateElement(Department.NameSpacePrefix, "Department", Department.NameSpaceURI);
            // name - Level 4
            nodeLevel4 = doc.CreateElement(Department.NameSpacePrefix, "name", NameSpaceURI);
            nodeLevel4.AppendChild(doc.CreateTextNode(this.GwaName));
            // attr of name: repCode
            attr = doc.CreateAttribute(Department.NameSpacePrefix, "repCode", NameSpaceURI);
            attr.Value = "I"; // TODO
            nodeLevel4.Attributes.Append(attr);
            // attr of name: tableId
            attr = doc.CreateAttribute(Department.NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = "MML0025"; // TODO
            nodeLevel4.Attributes.Append(attr);

            nodeLevel3.AppendChild(nodeLevel4);
            nodeLevel2.AppendChild(nodeLevel3);
            nodeLevel1.AppendChild(nodeLevel2);

            rootNode.AppendChild(nodeLevel1);

            #endregion

            #region Bundle

            // bundle - Level 1
            if (this.BundleList != null)
            {
                foreach (BundleItem item in this.BundleList)
                {
                    // bundle node
                    nodeLevel1 = doc.CreateElement(NameSpacePrefix, "bundle", NameSpaceURI);
                    // classCode attr
                    attr = doc.CreateAttribute(NameSpacePrefix, "classCode", NameSpaceURI);
                    attr.Value = item.ClassCode; // TODO
                    nodeLevel1.Attributes.Append(attr);
                    // classCodeId - attr
                    attr = doc.CreateAttribute(NameSpacePrefix, "classCodeId", NameSpaceURI);
                    //attr.Value = item.ClassCodeId; TODO
                    attr.Value = "Claim007";
                    nodeLevel1.Attributes.Append(attr);

                    // className - Level 2
                    nodeLevel2 = doc.CreateElement(NameSpacePrefix, "className", NameSpaceURI);
                    nodeLevel2.AppendChild(doc.CreateTextNode(item.ClassName));
                    nodeLevel1.AppendChild(nodeLevel2);
                    // className - Level 2
                    nodeLevel2 = doc.CreateElement(NameSpacePrefix, "bundleNumber", NameSpaceURI);
                    nodeLevel2.AppendChild(doc.CreateTextNode(item.BundleNumber.ToString()));
                    nodeLevel1.AppendChild(nodeLevel2);

                    // 
                    nodeLevel2 = doc.CreateElement(NameSpacePrefix, "item", NameSpaceURI);
                    // item - attr
                    attr = doc.CreateAttribute(NameSpacePrefix, "subclassCode", NameSpaceURI);
                    attr.Value = "1"; // TODO
                    nodeLevel2.Attributes.Append(attr);
                    attr = doc.CreateAttribute(NameSpacePrefix, "subclassCodeId", NameSpaceURI);
                    attr.Value = "Claim003"; // TODO
                    nodeLevel2.Attributes.Append(attr);
                    attr = doc.CreateAttribute(NameSpacePrefix, "code", NameSpaceURI);
                    attr.Value = item.Code;
                    nodeLevel2.Attributes.Append(attr);
                    attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
                    attr.Value = "tbl_tensu"; // TODO
                    nodeLevel2.Attributes.Append(attr);

                    if (item.NumberCode != string.Empty && item.Number != string.Empty)
                    {
                        //Number code - level 3
                        nodeLevel3 = doc.CreateElement(NameSpacePrefix, "number", NameSpaceURI);
                        nodeLevel3.AppendChild(doc.CreateTextNode(item.Number));
                        //item - att
                        attr = doc.CreateAttribute(NameSpacePrefix, "numberCode", NameSpaceURI);
                        attr.Value = item.NumberCode; // TODO
                        nodeLevel3.Attributes.Append(attr);
                        attr = doc.CreateAttribute(NameSpacePrefix, "numberCodeID", NameSpaceURI);
                        attr.Value = "Claim004"; // TODO
                        nodeLevel3.Attributes.Append(attr);

                        nodeLevel2.AppendChild(nodeLevel3);
                    }

                    //level 3
                    //nodeLevel3 = doc.CreateElement(NameSpacePrefix, "name", NameSpaceURI);
                    //nodeLevel3.AppendChild(doc.CreateTextNode("ｽ鯀ﾇ")); // TODO
                    //nodeLevel2.AppendChild(nodeLevel3);

                    nodeLevel1.AppendChild(nodeLevel2);
                    //nodeLevel2.AppendChild(nodeLevel3);
                    rootNode.AppendChild(nodeLevel1);
                }
            }

            #endregion

            return rootNode;
        }
    }
}
