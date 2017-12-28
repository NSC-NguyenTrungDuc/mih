using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [Serializable]
    [global::ProtoBuf.ProtoContract(Name=@"KinkiType")]
    public enum KinkiType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"KINKI_MSG", Value=0)]
      KINKI_MSG = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"KINKI_DIEASE", Value=1)]
      KINKI_DIEASE = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DOSAGE", Value=2)]
      DOSAGE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DRUG_CHECKING", Value=3)]
      DRUG_CHECKING = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INTERATION", Value=4)]
      INTERATION = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GENERIC_NAME", Value=5)]
      GENERIC_NAME = 5
    }
}
