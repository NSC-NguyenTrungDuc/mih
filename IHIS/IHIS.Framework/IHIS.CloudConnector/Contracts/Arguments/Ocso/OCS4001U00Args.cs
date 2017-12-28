using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCS4001U00Args : IContractArgs
    {
        private String _bunhoCode;
        private String _hospCode;
        private String _templateId;
        private String _orderDate;
        private String _prescriptionDate;

        public String BunhoCode
        {
            get { return this._bunhoCode; }
            set { this._bunhoCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String TemplateId
        {
            get { return this._templateId; }
            set { this._templateId = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String PrescriptionDate
        {
            get { return this._prescriptionDate; }
            set { this._prescriptionDate = value; }
        }

        public OCS4001U00Args() { }

        public OCS4001U00Args(String bunhoCode, String hospCode, String templateId, String orderDate, String prescriptionDate)
        {
            this._bunhoCode = bunhoCode;
            this._hospCode = hospCode;
            this._templateId = templateId;
            this._orderDate = orderDate;
            this._prescriptionDate = prescriptionDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS4001U00Request();
        }
    }
}