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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ORCALibGetClaimInfoResponse")]
  public partial class ORCALibGetClaimInfoResponse : global::ProtoBuf.IExtensible
  {
    public ORCALibGetClaimInfoResponse() {}
    
    private readonly global::System.Collections.Generic.List<ORCALibGetDocInfo> _doc_item = new global::System.Collections.Generic.List<ORCALibGetDocInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"doc_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCALibGetDocInfo> doc_item
    {
      get { return _doc_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ORCALibGetClaimPatientInfo> _patient_item = new global::System.Collections.Generic.List<ORCALibGetClaimPatientInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"patient_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCALibGetClaimPatientInfo> patient_item
    {
      get { return _patient_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ORCALibAcquisitionInfo> _acquis_item = new global::System.Collections.Generic.List<ORCALibAcquisitionInfo>();
    [global::ProtoBuf.ProtoMember(3, Name=@"acquis_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCALibAcquisitionInfo> acquis_item
    {
      get { return _acquis_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ORCALibGetClaimInsuredInfo> _insurance_item = new global::System.Collections.Generic.List<ORCALibGetClaimInsuredInfo>();
    [global::ProtoBuf.ProtoMember(4, Name=@"insurance_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCALibGetClaimInsuredInfo> insurance_item
    {
      get { return _insurance_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ORCALibGetClaimOrderInfo> _claim_order_item = new global::System.Collections.Generic.List<ORCALibGetClaimOrderInfo>();
    [global::ProtoBuf.ProtoMember(5, Name=@"claim_order_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCALibGetClaimOrderInfo> claim_order_item
    {
      get { return _claim_order_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ORCALibGetClaimDiagnosisInfo> _diagnosis_item = new global::System.Collections.Generic.List<ORCALibGetClaimDiagnosisInfo>();
    [global::ProtoBuf.ProtoMember(6, Name=@"diagnosis_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCALibGetClaimDiagnosisInfo> diagnosis_item
    {
      get { return _diagnosis_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
