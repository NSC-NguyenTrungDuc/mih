using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NUR2015U01EmrRecordUpdateArgs : IContractArgs
    {
        private String _bunho;
        private String _content;
        private String _metadata;
        private String _sysId;
        private String _recordLog;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public String Metadata
        {
            get { return this._metadata; }
            set { this._metadata = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String RecordLog
        {
            get { return this._recordLog; }
            set { this._recordLog = value; }
        }

        public NUR2015U01EmrRecordUpdateArgs() { }

        public NUR2015U01EmrRecordUpdateArgs(String bunho, String content, String metadata, String sysId, String recordLog)
        {
            this._bunho = bunho;
            this._content = content;
            this._metadata = metadata;
            this._sysId = sysId;
            this._recordLog = recordLog;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2015U01EmrRecordUpdateRequest();
        }
    }
}