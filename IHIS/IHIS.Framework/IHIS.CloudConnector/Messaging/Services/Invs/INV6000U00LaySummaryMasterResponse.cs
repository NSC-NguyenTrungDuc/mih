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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV6000U00LaySummaryMasterResponse")]
  public partial class INV6000U00LaySummaryMasterResponse : global::ProtoBuf.IExtensible
  {
    public INV6000U00LaySummaryMasterResponse() {}
    
    private readonly global::System.Collections.Generic.List<INV6000U00LaySummaryMasterInfo> _lay_summary_m = new global::System.Collections.Generic.List<INV6000U00LaySummaryMasterInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"lay_summary_m", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INV6000U00LaySummaryMasterInfo> lay_summary_m
    {
      get { return _lay_summary_m; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
