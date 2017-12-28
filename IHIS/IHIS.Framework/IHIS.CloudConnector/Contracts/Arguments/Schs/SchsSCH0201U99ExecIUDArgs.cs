using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{
    public class SchsSCH0201U99ExecIUDArgs : IContractArgs
    {
        private String _iIudGubun;
        private List<SCH0201U99ListFkschInfo> _lstFksch = new List<SCH0201U99ListFkschInfo>();
        private String _iReserDate;
        private String _iReserTime;
        private String _iInputId;
        private String _jundalTable;
        private String _jundalPart;
        private String _outHospcode;

        public String IIudGubun
        {
            get { return this._iIudGubun; }
            set { this._iIudGubun = value; }
        }

        public List<SCH0201U99ListFkschInfo> LstFksch
        {
            get { return this._lstFksch; }
            set { this._lstFksch = value; }
        }

        public String IReserDate
        {
            get { return this._iReserDate; }
            set { this._iReserDate = value; }
        }

        public String IReserTime
        {
            get { return this._iReserTime; }
            set { this._iReserTime = value; }
        }

        public String IInputId
        {
            get { return this._iInputId; }
            set { this._iInputId = value; }
        }

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String OutHospcode
        {
            get { return this._outHospcode; }
            set { this._outHospcode = value; }
        }

        public SchsSCH0201U99ExecIUDArgs() { }

        public SchsSCH0201U99ExecIUDArgs(String iIudGubun, List<SCH0201U99ListFkschInfo> lstFksch, String iReserDate, String iReserTime, String iInputId, String jundalTable, String jundalPart, String outHospcode)
        {
            this._iIudGubun = iIudGubun;
            this._lstFksch = lstFksch;
            this._iReserDate = iReserDate;
            this._iReserTime = iReserTime;
            this._iInputId = iInputId;
            this._jundalTable = jundalTable;
            this._jundalPart = jundalPart;
            this._outHospcode = outHospcode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SchsSCH0201U99ExecIUDRequest();
        }
    }
}