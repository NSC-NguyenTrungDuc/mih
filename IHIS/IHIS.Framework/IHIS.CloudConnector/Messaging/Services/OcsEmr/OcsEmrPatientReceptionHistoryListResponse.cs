//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service2.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsEmrPatientReceptionHistoryListResponse")]
  public partial class OcsEmrPatientReceptionHistoryListResponse : global::ProtoBuf.IExtensible
  {
    public OcsEmrPatientReceptionHistoryListResponse() {}
    
    private readonly global::System.Collections.Generic.List<OcsEmrPatientReceptionHistoryListItemInfo> _patient_reception_history_list_item = new global::System.Collections.Generic.List<OcsEmrPatientReceptionHistoryListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"patient_reception_history_list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OcsEmrPatientReceptionHistoryListItemInfo> patient_reception_history_list_item
    {
      get { return _patient_reception_history_list_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
