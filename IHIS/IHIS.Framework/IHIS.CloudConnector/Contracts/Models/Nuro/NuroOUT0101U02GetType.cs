using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GetType
	{
		private String _type;
		private String _typeName;

		public String Type
		{
			get { return this._type; }
			set { this._type = value; }
		}

		public String TypeName
		{
			get { return this._typeName; }
			set { this._typeName = value; }
		}

		public NuroOUT0101U02GetType() { }

		public NuroOUT0101U02GetType(String type, String typeName)
		{
			this._type = type;
			this._typeName = typeName;
		}

	}
}