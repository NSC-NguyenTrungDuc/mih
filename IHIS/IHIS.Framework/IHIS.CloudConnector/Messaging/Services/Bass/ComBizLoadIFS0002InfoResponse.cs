//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ComBizLoadIFS0002InfoResponse")]
  public partial class ComBizLoadIFS0002InfoResponse : global::ProtoBuf.IExtensible
  {
    public ComBizLoadIFS0002InfoResponse() {}
    
    private readonly global::System.Collections.Generic.List<ComBizLoadIFS0002Info> _info_list = new global::System.Collections.Generic.List<ComBizLoadIFS0002Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"info_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComBizLoadIFS0002Info> info_list
    {
      get { return _info_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}