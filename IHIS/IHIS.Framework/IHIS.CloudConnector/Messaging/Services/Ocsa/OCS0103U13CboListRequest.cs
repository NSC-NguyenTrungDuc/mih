//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service.proto
// Note: requires additional types generated from: import.proto
namespace IHIS.CloudConnector.Messaging
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U13CboListRequest")]
  public partial class OCS0103U13CboListRequest : global::ProtoBuf.IExtensible
  {
    public OCS0103U13CboListRequest() {}
    
    private readonly global::System.Collections.Generic.List<ComboDataSourceInfo> _combo_item_list_info = new global::System.Collections.Generic.List<ComboDataSourceInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"combo_item_list_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboDataSourceInfo> combo_item_list_info
    {
      get { return _combo_item_list_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}