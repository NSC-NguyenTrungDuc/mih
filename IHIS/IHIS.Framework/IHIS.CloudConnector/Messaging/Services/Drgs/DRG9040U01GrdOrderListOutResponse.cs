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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DRG9040U01GrdOrderListOutResponse")]
  public partial class DRG9040U01GrdOrderListOutResponse : global::ProtoBuf.IExtensible
  {
    public DRG9040U01GrdOrderListOutResponse() {}
    
    private readonly global::System.Collections.Generic.List<DRG9040U01GrdOrderListOutInfo> _grd_order_list_out_info = new global::System.Collections.Generic.List<DRG9040U01GrdOrderListOutInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_order_list_out_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<DRG9040U01GrdOrderListOutInfo> grd_order_list_out_info
    {
      get { return _grd_order_list_out_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
