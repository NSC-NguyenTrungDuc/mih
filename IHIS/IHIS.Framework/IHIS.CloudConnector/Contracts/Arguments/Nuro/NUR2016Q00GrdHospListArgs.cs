using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NUR2016Q00GrdHospListArgs : IContractArgs
    {
        private String _hospCode;
        private String _yoyangName;
        private String _address;
        private String _pageNumber;
        private String _offset;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public NUR2016Q00GrdHospListArgs() { }

        public NUR2016Q00GrdHospListArgs(String hospCode, String yoyangName, String address, String pageNumber, String offset)
        {
            this._hospCode = hospCode;
            this._yoyangName = yoyangName;
            this._address = address;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016Q00GrdHospListRequest();
        }
    }
}