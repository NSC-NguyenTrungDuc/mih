using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]  
    public class CPL0000Q00LayOrderResultListQueryArgs : IContractArgs
	{
      protected bool Equals(CPL0000Q00LayOrderResultListQueryArgs other)
      {
          return string.Equals(_bunho, other._bunho);
      }

      public override bool Equals(object obj)
      {
          if (ReferenceEquals(null, obj)) return false;
          if (ReferenceEquals(this, obj)) return true;
          if (obj.GetType() != this.GetType()) return false;
          return Equals((CPL0000Q00LayOrderResultListQueryArgs) obj);
      }

      public override int GetHashCode()
      {
          return (_bunho != null ? _bunho.GetHashCode() : 0);
      }

      private String _bunho;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public CPL0000Q00LayOrderResultListQueryArgs() { }

		public CPL0000Q00LayOrderResultListQueryArgs(String bunho)
		{
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00LayOrderResultListQueryRequest();
		}
	}
}