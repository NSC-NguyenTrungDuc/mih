using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0101U00CheckHangMogCopyResult : AbstractContractResult
	{
        protected bool Equals(CPL0101U00CheckHangMogCopyResult other)
        {
            return _result.Equals(other._result);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0101U00CheckHangMogCopyResult) obj);
        }

        public override int GetHashCode()
        {
            return _result.GetHashCode();
        }

        private Boolean _result;

		public Boolean Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public CPL0101U00CheckHangMogCopyResult() { }

	}
}