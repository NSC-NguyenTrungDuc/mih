//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
// Note: requires additional types generated from: import.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PHY2001U04CboJubsuGubunResponse")]
  public partial class PHY2001U04CboJubsuGubunResponse : global::ProtoBuf.IExtensible
  {
    public PHY2001U04CboJubsuGubunResponse() {}
    
    private readonly global::System.Collections.Generic.List<PHY2001U04CboJubsuGubunInfo> _cbo_jubsu_gubun = new global::System.Collections.Generic.List<PHY2001U04CboJubsuGubunInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"cbo_jubsu_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PHY2001U04CboJubsuGubunInfo> cbo_jubsu_gubun
    {
      get { return _cbo_jubsu_gubun; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
