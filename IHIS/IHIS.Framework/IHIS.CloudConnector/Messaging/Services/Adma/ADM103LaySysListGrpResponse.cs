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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ADM103LaySysListGrpResponse")]
  public partial class ADM103LaySysListGrpResponse : global::ProtoBuf.IExtensible
  {
    public ADM103LaySysListGrpResponse() {}
    
    private readonly global::System.Collections.Generic.List<ADM103LaySysListGrpInfo> _grp_item = new global::System.Collections.Generic.List<ADM103LaySysListGrpInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grp_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ADM103LaySysListGrpInfo> grp_item
    {
      get { return _grp_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
