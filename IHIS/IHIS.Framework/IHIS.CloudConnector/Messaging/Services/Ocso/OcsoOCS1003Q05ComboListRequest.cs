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
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsoOCS1003Q05ComboListRequest")]
  public partial class OcsoOCS1003Q05ComboListRequest : global::ProtoBuf.IExtensible
  {
    public OcsoOCS1003Q05ComboListRequest() {}
    
    private readonly global::System.Collections.Generic.List<ComboDataSourceInfo> _cbo_item = new global::System.Collections.Generic.List<ComboDataSourceInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"cbo_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboDataSourceInfo> cbo_item
    {
      get { return _cbo_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}