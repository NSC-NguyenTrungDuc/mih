//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_service.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INJ1001U01GrdSangReponse")]
  public partial class INJ1001U01GrdSangResponse : global::ProtoBuf.IExtensible
  {
    public INJ1001U01GrdSangResponse() {}
    
    private readonly global::System.Collections.Generic.List<INJ1001U01GrdSangItemInfo> _schedule_item = new global::System.Collections.Generic.List<INJ1001U01GrdSangItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"schedule_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INJ1001U01GrdSangItemInfo> schedule_item
    {
      get { return _schedule_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
