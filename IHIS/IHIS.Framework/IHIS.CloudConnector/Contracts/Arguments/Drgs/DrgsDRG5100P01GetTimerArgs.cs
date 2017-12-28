using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01GetTimerArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01GetTimerArgs other)
        {
            return string.Equals(_currentDate, other._currentDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01GetTimerArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_currentDate != null ? _currentDate.GetHashCode() : 0);
        }

        private String _currentDate;

		public String CurrentDate
		{
			get { return this._currentDate; }
			set { this._currentDate = value; }
		}

		public DrgsDRG5100P01GetTimerArgs() { }

		public DrgsDRG5100P01GetTimerArgs(String currentDate)
		{
			this._currentDate = currentDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01GetTimerRequest();
		}
	}
}