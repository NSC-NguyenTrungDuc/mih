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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U00GetCommonYnResponse")]
  public partial class OCS0103U00GetCommonYnResponse : global::ProtoBuf.IExtensible
  {
    public OCS0103U00GetCommonYnResponse() {}
    
    private readonly global::System.Collections.Generic.List<DataStringListItemInfo> _common_yn_list = new global::System.Collections.Generic.List<DataStringListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"common_yn_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<DataStringListItemInfo> common_yn_list
    {
      get { return _common_yn_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
