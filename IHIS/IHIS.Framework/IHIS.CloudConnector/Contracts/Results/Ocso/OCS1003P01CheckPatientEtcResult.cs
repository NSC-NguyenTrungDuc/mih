using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003P01CheckPatientEtcResult : AbstractContractResult
	{
        private String _kensaReserValue;
        private String _specificComment;
        private String _userOption;
        private String _outTaGwaJinryoCnt;
        private String _outJinryoComment;
        private Boolean _allergyData;
        private Boolean _ipwonReserStatus;

        public String KensaReserValue
        {
            get { return this._kensaReserValue; }
            set { this._kensaReserValue = value; }
        }

        public String SpecificComment
        {
            get { return this._specificComment; }
            set { this._specificComment = value; }
        }

        public String UserOption
        {
            get { return this._userOption; }
            set { this._userOption = value; }
        }

        public String OutTaGwaJinryoCnt
        {
            get { return this._outTaGwaJinryoCnt; }
            set { this._outTaGwaJinryoCnt = value; }
        }

        public String OutJinryoComment
        {
            get { return this._outJinryoComment; }
            set { this._outJinryoComment = value; }
        }

        public Boolean AllergyData
        {
            get { return this._allergyData; }
            set { this._allergyData = value; }
        }

        public Boolean IpwonReserStatus
        {
            get { return this._ipwonReserStatus; }
            set { this._ipwonReserStatus = value; }
        }

        public OCS1003P01CheckPatientEtcResult() { }

	}
}