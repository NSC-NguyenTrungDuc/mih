using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV6000U00SaveLayoutArgs : IContractArgs
    {
        private String _proc;
        private String _month;
        private String _userId;
        private String _inputUser;
        private String _inputDate;
        private String _remark;

        public String Proc
        {
            get { return this._proc; }
            set { this._proc = value; }
        }

        public String Month
        {
            get { return this._month; }
            set { this._month = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String InputUser
        {
            get { return this._inputUser; }
            set { this._inputUser = value; }
        }

        public String InputDate
        {
            get { return this._inputDate; }
            set { this._inputDate = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public INV6000U00SaveLayoutArgs() { }

        public INV6000U00SaveLayoutArgs(String proc, String month, String userId, String inputUser, String inputDate, String remark)
        {
            this._proc = proc;
            this._month = month;
            this._userId = userId;
            this._inputUser = inputUser;
            this._inputDate = inputDate;
            this._remark = remark;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV6000U00SaveLayoutRequest();
        }
    }
}