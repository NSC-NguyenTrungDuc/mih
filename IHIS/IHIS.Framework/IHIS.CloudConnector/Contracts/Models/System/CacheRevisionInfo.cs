using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class CacheRevisionInfo
    {
        private String _tableName;
        private Int32 _revision;

        public String TableName
        {
            get { return this._tableName; }
            set { this._tableName = value; }
        }

        public Int32 Revision
        {
            get { return this._revision; }
            set { this._revision = value; }
        }

        public CacheRevisionInfo() { }

        public CacheRevisionInfo(String tableName, Int32 revision)
        {
            this._tableName = tableName;
            this._revision = revision;
        }

    }
}