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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DRG9040U01GrdOrderResponse")]
  public partial class DRG9040U01GrdOrderResponse : global::ProtoBuf.IExtensible
  {
    public DRG9040U01GrdOrderResponse() {}
    
    private readonly global::System.Collections.Generic.List<DRG9040U01GrdOrderInfo> _grd_order_info = new global::System.Collections.Generic.List<DRG9040U01GrdOrderInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_order_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<DRG9040U01GrdOrderInfo> grd_order_info
    {
      get { return _grd_order_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
