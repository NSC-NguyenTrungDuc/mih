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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"IFS0001U00GrdDetailResponse")]
  public partial class IFS0001U00GrdDetailResponse : global::ProtoBuf.IExtensible
  {
    public IFS0001U00GrdDetailResponse() {}
    
    private readonly global::System.Collections.Generic.List<IFS0001U00GrdDetailInfo> _grd_detail_item = new global::System.Collections.Generic.List<IFS0001U00GrdDetailInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_detail_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<IFS0001U00GrdDetailInfo> grd_detail_item
    {
      get { return _grd_detail_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}