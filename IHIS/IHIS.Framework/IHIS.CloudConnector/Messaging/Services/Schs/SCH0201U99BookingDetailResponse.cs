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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SCH0201U99BookingDetailResponse")]
  public partial class SCH0201U99BookingDetailResponse : global::ProtoBuf.IExtensible
  {
    public SCH0201U99BookingDetailResponse() {}
    
    private readonly global::System.Collections.Generic.List<SCH0201U99BookingDetailInfo> _detail_info = new global::System.Collections.Generic.List<SCH0201U99BookingDetailInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"detail_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<SCH0201U99BookingDetailInfo> detail_info
    {
      get { return _detail_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
