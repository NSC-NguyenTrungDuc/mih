using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    public class OCS0103U17ScreenOpenArgs : IContractArgs
    {
        private String _orderMode;
        private String _userGubun;
        private String _doctorId;
        private String _userId;
        private OCS0103U12ScreenOpenArgs _scrOpenReqItem;
        private OCS0103U12InitializeScreenArgs _initScreenReqItem;
        private OCS0103U12MakeSangyongTabArgs _sangyongTabReqItem;
        private OCS0103U12GrdSangyongOrderArgs _sangyongOrderReqItem;
        private OCS0103U17LayHangwiGubunArgs _hangwiGubunReqItem;
        private OCS0103U17MakeJaeryoGubunTabArgs _jaeryoGubunReqItem;
        private GetNextGroupSerArgs _groupserReqItem;
        private OCS0103U17LoadHangwiOrder3Args _hangwiOrderReqItem;

        public String OrderMode
        {
            get { return this._orderMode; }
            set { this._orderMode = value; }
        }

        public String UserGubun
        {
            get { return this._userGubun; }
            set { this._userGubun = value; }
        }

        public String DoctorId
        {
            get { return this._doctorId; }
            set { this._doctorId = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public OCS0103U12ScreenOpenArgs ScrOpenReqItem
        {
            get { return this._scrOpenReqItem; }
            set { this._scrOpenReqItem = value; }
        }

        public OCS0103U12InitializeScreenArgs InitScreenReqItem
        {
            get { return this._initScreenReqItem; }
            set { this._initScreenReqItem = value; }
        }

        public OCS0103U12MakeSangyongTabArgs SangyongTabReqItem
        {
            get { return this._sangyongTabReqItem; }
            set { this._sangyongTabReqItem = value; }
        }

        public OCS0103U12GrdSangyongOrderArgs SangyongOrderReqItem
        {
            get { return this._sangyongOrderReqItem; }
            set { this._sangyongOrderReqItem = value; }
        }

        public OCS0103U17LayHangwiGubunArgs HangwiGubunReqItem
        {
            get { return this._hangwiGubunReqItem; }
            set { this._hangwiGubunReqItem = value; }
        }

        public OCS0103U17MakeJaeryoGubunTabArgs JaeryoGubunReqItem
        {
            get { return this._jaeryoGubunReqItem; }
            set { this._jaeryoGubunReqItem = value; }
        }

        public GetNextGroupSerArgs GroupserReqItem
        {
            get { return this._groupserReqItem; }
            set { this._groupserReqItem = value; }
        }

        public OCS0103U17LoadHangwiOrder3Args HangwiOrderReqItem
        {
            get { return this._hangwiOrderReqItem; }
            set { this._hangwiOrderReqItem = value; }
        }

        public OCS0103U17ScreenOpenArgs() { }

        public OCS0103U17ScreenOpenArgs(String orderMode, String userGubun, String doctorId, String userId, OCS0103U12ScreenOpenArgs scrOpenReqItem, OCS0103U12InitializeScreenArgs initScreenReqItem, OCS0103U12MakeSangyongTabArgs sangyongTabReqItem, OCS0103U12GrdSangyongOrderArgs sangyongOrderReqItem, OCS0103U17LayHangwiGubunArgs hangwiGubunReqItem, OCS0103U17MakeJaeryoGubunTabArgs jaeryoGubunReqItem, GetNextGroupSerArgs groupserReqItem, OCS0103U17LoadHangwiOrder3Args hangwiOrderReqItem)
        {
            this._orderMode = orderMode;
            this._userGubun = userGubun;
            this._doctorId = doctorId;
            this._userId = userId;
            this._scrOpenReqItem = scrOpenReqItem;
            this._initScreenReqItem = initScreenReqItem;
            this._sangyongTabReqItem = sangyongTabReqItem;
            this._sangyongOrderReqItem = sangyongOrderReqItem;
            this._hangwiGubunReqItem = hangwiGubunReqItem;
            this._jaeryoGubunReqItem = jaeryoGubunReqItem;
            this._groupserReqItem = groupserReqItem;
            this._hangwiOrderReqItem = hangwiOrderReqItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U17ScreenOpenRequest();
        }
    }
}