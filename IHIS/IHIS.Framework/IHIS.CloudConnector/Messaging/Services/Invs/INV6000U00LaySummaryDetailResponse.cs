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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV6000U00LaySummaryDetailResponse")]
  public partial class INV6000U00LaySummaryDetailResponse : global::ProtoBuf.IExtensible
  {
    public INV6000U00LaySummaryDetailResponse() {}
    
    private readonly global::System.Collections.Generic.List<INV6000U00LaySummaryDetailInfo> _lay_summary_d = new global::System.Collections.Generic.List<INV6000U00LaySummaryDetailInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"lay_summary_d", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INV6000U00LaySummaryDetailInfo> lay_summary_d
    {
      get { return _lay_summary_d; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}