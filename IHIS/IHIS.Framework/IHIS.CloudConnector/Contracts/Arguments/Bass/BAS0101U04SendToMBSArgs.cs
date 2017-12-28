using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    public class BAS0101U04SendToMBSArgs : IContractArgs
    {
        private String _hospCode;
        private String _useMovieTalk;
        private String _useSurvey;
        private String _locale;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String UseMovieTalk
        {
            get { return this._useMovieTalk; }
            set { this._useMovieTalk = value; }
        }

        public String UseSurvey
        {
            get { return this._useSurvey; }
            set { this._useSurvey = value; }
        }

        public String Locale
        {
            get { return this._locale; }
            set { this._locale = value; }
        }

        public BAS0101U04SendToMBSArgs() { }

        public BAS0101U04SendToMBSArgs(String hospCode, String useMovieTalk, String useSurvey, String locale)
        {
            this._hospCode = hospCode;
            this._useMovieTalk = useMovieTalk;
            this._useSurvey = useSurvey;
            this._locale = locale;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0101U04SendToMBSRequest();
        }
    }
}