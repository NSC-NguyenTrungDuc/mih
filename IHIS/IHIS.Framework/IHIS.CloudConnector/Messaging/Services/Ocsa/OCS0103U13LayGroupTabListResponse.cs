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
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U13LayGroupTabListResponse")]
  public partial class OCS0103U13LayGroupTabListResponse : global::ProtoBuf.IExtensible
  {
    public OCS0103U13LayGroupTabListResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS0103U13LayGroupTabListInfo> _lay_group_tab_item = new global::System.Collections.Generic.List<OCS0103U13LayGroupTabListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"lay_group_tab_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS0103U13LayGroupTabListInfo> lay_group_tab_item
    {
      get { return _lay_group_tab_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}