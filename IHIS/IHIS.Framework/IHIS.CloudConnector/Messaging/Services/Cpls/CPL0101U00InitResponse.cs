//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL0101U00InitResponse")]
  public partial class CPL0101U00InitResponse : global::ProtoBuf.IExtensible
  {
    public CPL0101U00InitResponse() {}
    
    private readonly global::System.Collections.Generic.List<CPL0101U00InitListItemInfo> _init_info = new global::System.Collections.Generic.List<CPL0101U00InitListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"init_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CPL0101U00InitListItemInfo> init_info
    {
      get { return _init_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
