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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"END1001U02GrdPaStatusResponse")]
  public partial class END1001U02GrdPaStatusResponse : global::ProtoBuf.IExtensible
  {
    public END1001U02GrdPaStatusResponse() {}
    
    private readonly global::System.Collections.Generic.List<END1001U02GrdPaStatusInfo> _grd_pastatus_item = new global::System.Collections.Generic.List<END1001U02GrdPaStatusInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_pastatus_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<END1001U02GrdPaStatusInfo> grd_pastatus_item
    {
      get { return _grd_pastatus_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
