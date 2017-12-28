using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPL0000Q00UpdateOCS5010Args : IContractArgs
    {
        private String _userId;
        private String _hospCode;
        private String _doctor;
        private String _bunho;
        private String _jundalTable;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public CPL0000Q00UpdateOCS5010Args() { }

        public CPL0000Q00UpdateOCS5010Args(String userId, String hospCode, String doctor, String bunho, String jundalTable)
        {
            this._userId = userId;
            this._hospCode = hospCode;
            this._doctor = doctor;
            this._bunho = bunho;
            this._jundalTable = jundalTable;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0000Q00UpdateOCS5010Request();
        }
    }
}