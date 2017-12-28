using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LoadOUT0105Info
    {
        private String _gongbiCode;
        private String _priority;

        public String GongbiCode
        {
            get { return this._gongbiCode; }
            set { this._gongbiCode = value; }
        }

        public String Priority
        {
            get { return this._priority; }
            set { this._priority = value; }
        }

        public NuroOUT1001U01LoadOUT0105Info() { }

        public NuroOUT1001U01LoadOUT0105Info(String gongbiCode, String priority)
        {
            this._gongbiCode = gongbiCode;
            this._priority = priority;
        }

    }
}
