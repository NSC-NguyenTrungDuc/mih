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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsoOCS1003P01GridReserOrderListResponse")]
  public partial class OcsoOCS1003P01GridReserOrderListResponse : global::ProtoBuf.IExtensible
  {
    public OcsoOCS1003P01GridReserOrderListResponse() {}
    
    private readonly global::System.Collections.Generic.List<OcsoOCS1003P01GridReserOrderListInfo> _grid_reser_order_list = new global::System.Collections.Generic.List<OcsoOCS1003P01GridReserOrderListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grid_reser_order_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OcsoOCS1003P01GridReserOrderListInfo> grid_reser_order_list
    {
      get { return _grid_reser_order_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
