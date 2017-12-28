using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
	[global::ProtoBuf.ProtoContract(Name=@"ActionType")]
    public enum ActionType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"IMPORT", Value=0)]
      IMPORT = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EXPORT", Value=1)]
      EXPORT = 1
    }
}