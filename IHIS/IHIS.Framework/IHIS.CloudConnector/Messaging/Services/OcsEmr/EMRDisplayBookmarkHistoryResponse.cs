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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EMRDisplayBookmarkHistoryResponse")]
  public partial class EMRDisplayBookmarkHistoryResponse : global::ProtoBuf.IExtensible
  {
    public EMRDisplayBookmarkHistoryResponse() {}
    
    private readonly global::System.Collections.Generic.List<PatientInfo> _patient_list_item = new global::System.Collections.Generic.List<PatientInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"patient_list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PatientInfo> patient_list_item
    {
      get { return _patient_list_item; }
    }
  
    private readonly global::System.Collections.Generic.List<NuroPatientReceptionHistoryListItemInfo> _history_list_item = new global::System.Collections.Generic.List<NuroPatientReceptionHistoryListItemInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"history_list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<NuroPatientReceptionHistoryListItemInfo> history_list_item
    {
      get { return _history_list_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
