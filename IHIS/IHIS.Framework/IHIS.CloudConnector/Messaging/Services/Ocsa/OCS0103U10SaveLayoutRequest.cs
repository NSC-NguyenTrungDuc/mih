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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U10SaveLayoutRequest")]
  public partial class OCS0103U10SaveLayoutRequest : global::ProtoBuf.IExtensible
  {
    public OCS0103U10SaveLayoutRequest() {}
    
    private readonly global::System.Collections.Generic.List<OCS0103U10SaveLayoutInfo> _save_layout_item = new global::System.Collections.Generic.List<OCS0103U10SaveLayoutInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"save_layout_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS0103U10SaveLayoutInfo> save_layout_item
    {
      get { return _save_layout_item; }
    }
  
    private readonly global::System.Collections.Generic.List<PrOcsInterfaceInsertInfo> _interface_insert_item = new global::System.Collections.Generic.List<PrOcsInterfaceInsertInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"interface_insert_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PrOcsInterfaceInsertInfo> interface_insert_item
    {
      get { return _interface_insert_item; }
    }
  
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _order_date = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"order_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_date
    {
      get { return _order_date; }
      set { _order_date = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
