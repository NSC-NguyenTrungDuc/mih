using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPL3010U01ExportFileArgs : IContractArgs
    {
        private String _totalPa;
        private String _userId;
        private List<CPL3010U01GrdPaInfo> _paItem = new List<CPL3010U01GrdPaInfo>();
        private List<CPL3010U01GrdHangmogInfo> _hangmogItem = new List<CPL3010U01GrdHangmogInfo>();
        private List<CPL3010U01IsFileWriteInfo> _fileWriteItem = new List<CPL3010U01IsFileWriteInfo>();

        public String TotalPa
        {
            get { return this._totalPa; }
            set { this._totalPa = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<CPL3010U01GrdPaInfo> PaItem
        {
            get { return this._paItem; }
            set { this._paItem = value; }
        }

        public List<CPL3010U01GrdHangmogInfo> HangmogItem
        {
            get { return this._hangmogItem; }
            set { this._hangmogItem = value; }
        }

        public List<CPL3010U01IsFileWriteInfo> FileWriteItem
        {
            get { return this._fileWriteItem; }
            set { this._fileWriteItem = value; }
        }

        public CPL3010U01ExportFileArgs() { }

        public CPL3010U01ExportFileArgs(String totalPa, String userId, List<CPL3010U01GrdPaInfo> paItem, List<CPL3010U01GrdHangmogInfo> hangmogItem, List<CPL3010U01IsFileWriteInfo> fileWriteItem)
        {
            this._totalPa = totalPa;
            this._userId = userId;
            this._paItem = paItem;
            this._hangmogItem = hangmogItem;
            this._fileWriteItem = fileWriteItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3010U01ExportFileRequest();
        }
    }
}