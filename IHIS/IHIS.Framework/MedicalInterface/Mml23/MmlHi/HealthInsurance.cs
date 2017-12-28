using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlHi
{
    public class HealthInsurance : Mml23.MmlContent
    {
        private string _countryType;
        private InsuranceClass _insuranceClass;
        private string _insuranceNumber;
        private string _clientIdGroup;
        private string _clientIdNumber;
        private bool _familyFlag;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _paymentInRatio;
        private int _paymentOutRatio;
        private SortedList<int, PublicInsuranceItem> _publicInsuranceList;

        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1";

        public const string NameSpacePrefix = "mmlHi";

        /// <summary>
        /// 保険の国籍タイプ
        /// 通常JPN(日本)固定
        /// </summary>
        public string CountryType
        {
            get { return _countryType; }
            set { _countryType = value; }
        }

        /// <summary>
        /// 保険種別
        /// </summary>
        public InsuranceClass InsuranceClass
        {
            get { return _insuranceClass; }
            set { _insuranceClass = value; }
        }

        /// <summary>
        /// 保険者番号
        /// </summary>
        public string InsuranceNumber
        {
            get { return _insuranceNumber; }
            set { _insuranceNumber = value; }
        }

        /// <summary>
        /// 被保険者番号・記号
        /// </summary>
        public string ClientIdGroup
        {
            get { return _clientIdGroup; }
            set { _clientIdGroup = value; }
        }

        /// <summary>
        /// 被保険者番号・番号
        /// </summary>
        public string ClientIdNumber
        {
            get { return _clientIdNumber; }
            set { _clientIdNumber = value; }
        }

        /// <summary>
        /// 本人家族区分
        /// 家族の場合はTrue
        /// </summary>
        public bool FamilyFlag
        {
            get { return _familyFlag; }
            set { _familyFlag = value; }
        }

        /// <summary>
        /// 有効開始日
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        /// <summary>
        /// 有効終了日
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        /// <summary>
        /// 入院負担割合［％｝0～100
        /// </summary>
        public int PaymentInRatio
        {
            get { return _paymentInRatio; }
            set { _paymentInRatio = value; }
        }

        /// <summary>
        /// 外来負担割合［％｝0～100
        /// </summary>
        public int PaymentOutRatio
        {
            get { return _paymentOutRatio; }
            set { _paymentOutRatio = value; }
        }

        /// <summary>
        /// 公費被保険リスト
        /// </summary>
        public SortedList<int, PublicInsuranceItem> PublicInsuranceList
        {
            get { return _publicInsuranceList; }
            set { _publicInsuranceList = value; }
        }

        public HealthInsurance()
        {

        }
        public HealthInsurance(XmlNode node)
        {
            LoadFromXml(node);
        }

        public override void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            this.InsuranceClass = new InsuranceClass(node.SelectSingleNode("mmlHi:insuranceClass", nsmgr));

            this.InsuranceNumber = node.SelectSingleNode("mmlHi:insuranceNumber", nsmgr).InnerText;

            this.ClientIdGroup = node.SelectSingleNode("mmlHi:clientId/mmlHi:group", nsmgr).InnerText;

            this.ClientIdNumber = node.SelectSingleNode("mmlHi:clientId/mmlHi:number", nsmgr).InnerText;

            bool flag;
            if (Boolean.TryParse(node.SelectSingleNode("mmlHi:familyClass", nsmgr).InnerText, out flag))
            {
                if (flag)
                {
                    this.FamilyFlag = false;
                }
                else
                {
                    this.FamilyFlag = true;
                }
            }
            else
            {
                this.FamilyFlag = false;
            }


            this.StartDate = DateTime.Parse(node.SelectSingleNode("mmlHi:startDate", nsmgr).InnerText);

            this.EndDate = DateTime.Parse(node.SelectSingleNode("mmlHi:expiredDate", nsmgr).InnerText);

            XmlNode tmpnode;
            tmpnode = node.SelectSingleNode("mmlHi:paymentOutRatio", nsmgr);
            if (tmpnode != null)
            {
                double raito;
                if (Double.TryParse(tmpnode.InnerText, out raito))
                {
                    this.PaymentOutRatio = (int)(raito * 100);
                }
                else
                {
                    this.PaymentOutRatio = -1;
                }
            }
            else
            {
                //入院負担率があれば同じとする
                this.PaymentOutRatio = -1;
            }

            tmpnode = node.SelectSingleNode("mmlHi:paymentInRatio", nsmgr);
            if (tmpnode != null)
            {
                double raito;
                if (Double.TryParse(tmpnode.InnerText, out raito))
                {
                    this.PaymentInRatio = (int)(raito * 100);
                }
                else
                {
                    this.PaymentInRatio = -1;
                }
            }
            else
            {
                //入院負担率がないときは外来と同じとする
                this.PaymentInRatio = -1;
            }

            //どちらかがないときはもう一方の負担率をセットどちらもないときは100%
            if (this.PaymentInRatio == -1 && this.PaymentOutRatio == -1)
            {
                this.PaymentInRatio = 100;
                this.PaymentOutRatio = 100;
            }
            else if (this.PaymentOutRatio == -1)
            {
                this.PaymentOutRatio = this.PaymentInRatio;
            }
            else if (this.PaymentInRatio == -1)
            {
                this.PaymentInRatio = this.PaymentOutRatio;
            }
            else
            {
                //なにもしない
            }

            //保険者情報、被保険者情報は現在読み込み対象外

            //公費
            this.PublicInsuranceList = new SortedList<int, PublicInsuranceItem>();
            foreach (XmlNode pinode in node.SelectNodes("mmlHi:publicInsurance/mmlHi:publicInsuranceItem", nsmgr))
            {
                PublicInsuranceItem pi = new PublicInsuranceItem(pinode);
                this.PublicInsuranceList.Add(pi.Priority, pi);
            }
        }

        public override XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "HealthInsuranceModule", NameSpaceURI);
            XmlElement elm;

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "countryType", NameSpaceURI);
            attr.Value = this.CountryType;
            node.Attributes.Append(attr);

            if (this.InsuranceClass != null)
            {
                // insuranceClass
                elm = doc.CreateElement(NameSpacePrefix, "insuranceClass", NameSpaceURI);
                attr = doc.CreateAttribute(NameSpacePrefix, "ClassCode", NameSpaceURI);
                attr.Value = this.InsuranceClass.Code;
                elm.Attributes.Append(attr);

                attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
                attr.Value = this.InsuranceClass.TableId;
                elm.Attributes.Append(attr);

                elm.AppendChild(doc.CreateTextNode(this.InsuranceClass.Text));
                node.AppendChild(elm);

                // insuranceClass
                if (!string.IsNullOrEmpty(this.InsuranceNumber))
                {
                    elm = doc.CreateElement(NameSpacePrefix, "insuranceNumber", NameSpaceURI);
                    elm.AppendChild(doc.CreateTextNode(this.InsuranceNumber));
                    node.AppendChild(elm);
                }

                XmlElement clientIdNode = doc.CreateElement(NameSpacePrefix, "clientId", NameSpaceURI);
                if (!string.IsNullOrEmpty(this.ClientIdGroup))
                {
                    XmlElement groupNode = doc.CreateElement(NameSpacePrefix, "group", NameSpaceURI);
                    groupNode.AppendChild(doc.CreateTextNode(this.ClientIdGroup));
                    clientIdNode.AppendChild(groupNode);
                    node.AppendChild(clientIdNode);
                }
                if (!string.IsNullOrEmpty(this.ClientIdNumber))
                {
                    XmlElement groupNode = doc.CreateElement(NameSpacePrefix, "number", NameSpaceURI);
                    groupNode.AppendChild(doc.CreateTextNode(this.ClientIdNumber));
                    clientIdNode.AppendChild(groupNode);
                    node.AppendChild(clientIdNode);
                }

                //if (!string.IsNullOrEmpty(this.ClientIdNumber))
                //{
                //    elm = doc.CreateElement(NameSpacePrefix, "clientId", NameSpaceURI);
                //    elm.AppendChild(doc.CreateTextNode(this.ClientIdNumber));
                //    node.AppendChild(elm);
                //}

                // familyClass
                //elm = doc.CreateElement(NameSpacePrefix, "familyClass", NameSpaceURI);
                //elm.AppendChild(doc.CreateTextNode(this.FamilyFlag.ToString()));
                //node.AppendChild(elm);

                // startDate
                elm = doc.CreateElement(NameSpacePrefix, "startDate", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.StartDate.ToString("yyyy-MM-dd")));
                node.AppendChild(elm);

                // startDate
                elm = doc.CreateElement(NameSpacePrefix, "expiredDate", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.EndDate.ToString("yyyy-MM-dd")));
                node.AppendChild(elm);

                // paymentOutRatio
                //decimal ratio = this.PaymentOutRatio / 100;
                //elm = doc.CreateElement(NameSpacePrefix, "paymentOutRatio", NameSpaceURI);
                //elm.AppendChild(doc.CreateTextNode("0.30")); // TODO
                //node.AppendChild(elm);
            }

            //TODO: add missing field
            return node;
        }
    }
}
