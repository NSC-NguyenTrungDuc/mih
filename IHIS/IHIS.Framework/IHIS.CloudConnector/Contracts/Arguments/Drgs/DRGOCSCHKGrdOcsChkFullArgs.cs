using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class DRGOCSCHKGrdOcsChkFullArgs : IContractArgs
    {
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _preSmallCode;
        private String _smallCode;
        private String _drgPackYn;
        private String _phamarcyYn;
        private String _powderYn;
        private String _hubalYn;
        private String _mayakYn;
        private String _stockYn;
        private String _beforeUseYn;
        private String _wonnaeDrgYn;
        private String _jaeryoGubun;
        private String _pageNumber;
        private String _offset;

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public String JaeryoName
        {
            get { return this._jaeryoName; }
            set { this._jaeryoName = value; }
        }

        public String PreSmallCode
        {
            get { return this._preSmallCode; }
            set { this._preSmallCode = value; }
        }

        public String SmallCode
        {
            get { return this._smallCode; }
            set { this._smallCode = value; }
        }

        public String DrgPackYn
        {
            get { return this._drgPackYn; }
            set { this._drgPackYn = value; }
        }

        public String PhamarcyYn
        {
            get { return this._phamarcyYn; }
            set { this._phamarcyYn = value; }
        }

        public String PowderYn
        {
            get { return this._powderYn; }
            set { this._powderYn = value; }
        }

        public String HubalYn
        {
            get { return this._hubalYn; }
            set { this._hubalYn = value; }
        }

        public String MayakYn
        {
            get { return this._mayakYn; }
            set { this._mayakYn = value; }
        }

        public String StockYn
        {
            get { return this._stockYn; }
            set { this._stockYn = value; }
        }

        public String BeforeUseYn
        {
            get { return this._beforeUseYn; }
            set { this._beforeUseYn = value; }
        }

        public String WonnaeDrgYn
        {
            get { return this._wonnaeDrgYn; }
            set { this._wonnaeDrgYn = value; }
        }

        public String JaeryoGubun
        {
            get { return this._jaeryoGubun; }
            set { this._jaeryoGubun = value; }
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

        public DRGOCSCHKGrdOcsChkFullArgs() { }

        public DRGOCSCHKGrdOcsChkFullArgs(String jaeryoCode, String jaeryoName, String preSmallCode, String smallCode, String drgPackYn, String phamarcyYn, String powderYn, String hubalYn, String mayakYn, String stockYn, String beforeUseYn, String wonnaeDrgYn, String jaeryoGubun, String pageNumber, String offset)
        {
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._preSmallCode = preSmallCode;
            this._smallCode = smallCode;
            this._drgPackYn = drgPackYn;
            this._phamarcyYn = phamarcyYn;
            this._powderYn = powderYn;
            this._hubalYn = hubalYn;
            this._mayakYn = mayakYn;
            this._stockYn = stockYn;
            this._beforeUseYn = beforeUseYn;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._jaeryoGubun = jaeryoGubun;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRGOCSCHKGrdOcsChkFullRequest();
        }
    }
}