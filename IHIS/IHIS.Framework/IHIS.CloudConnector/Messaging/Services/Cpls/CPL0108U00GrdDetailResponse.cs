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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL0108U00GrdDetailResponse")]
  public partial class CPL0108U00GrdDetailResponse : global::ProtoBuf.IExtensible
  {
    public CPL0108U00GrdDetailResponse() {}
    
    private readonly global::System.Collections.Generic.List<CPL0108U00InitGrdDetailListItemInfo> _grd_detail = new global::System.Collections.Generic.List<CPL0108U00InitGrdDetailListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_detail", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CPL0108U00InitGrdDetailListItemInfo> grd_detail
    {
      get { return _grd_detail; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
