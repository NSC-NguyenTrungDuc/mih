//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SyncKinkiCacheResponse")]
  public partial class SyncKinkiCacheResponse : global::ProtoBuf.IExtensible
  {
    public SyncKinkiCacheResponse() {}
    
    private KinkiType _kinki_type = KinkiType.KINKI_MSG;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"kinki_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(KinkiType.KINKI_MSG)]
    public KinkiType kinki_type
    {
      get { return _kinki_type; }
      set { _kinki_type = value; }
    }
    private readonly global::System.Collections.Generic.List<byte[]> _data = new global::System.Collections.Generic.List<byte[]>();
    [global::ProtoBuf.ProtoMember(2, Name=@"data", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<byte[]> data
    {
      get { return _data; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }     
  
}