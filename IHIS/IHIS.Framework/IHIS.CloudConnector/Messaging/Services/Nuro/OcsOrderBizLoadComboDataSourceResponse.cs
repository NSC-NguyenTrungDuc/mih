//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: nuro_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsOrderBizLoadComboDataSourceResponse")]
  public partial class OcsOrderBizLoadComboDataSourceResponse : global::ProtoBuf.IExtensible
  {
    public OcsOrderBizLoadComboDataSourceResponse() {}
    
    private readonly global::System.Collections.Generic.List<OcsOrderBizLoadComboDataSourceListItemInfo> _result = new global::System.Collections.Generic.List<OcsOrderBizLoadComboDataSourceListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OcsOrderBizLoadComboDataSourceListItemInfo> result
    {
      get { return _result; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
