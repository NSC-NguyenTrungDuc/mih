//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NUR2016U02TranferResponse")]
  public partial class NUR2016U02TranferResponse : global::ProtoBuf.IExtensible
  {
    public NUR2016U02TranferResponse() {}
    
    private ORCATransferOrdersHeaderInfo _header_item = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"header_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public ORCATransferOrdersHeaderInfo header_item
    {
      get { return _header_item; }
      set { _header_item = value; }
    }
    private readonly global::System.Collections.Generic.List<ORCATransferOrdersHealthInsuranceInfo> _health_ins_item = new global::System.Collections.Generic.List<ORCATransferOrdersHealthInsuranceInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"health_ins_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCATransferOrdersHealthInsuranceInfo> health_ins_item
    {
      get { return _health_ins_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ORCATransferOrdersDiseaseInfo> _disease_item = new global::System.Collections.Generic.List<ORCATransferOrdersDiseaseInfo>();
    [global::ProtoBuf.ProtoMember(3, Name=@"disease_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCATransferOrdersDiseaseInfo> disease_item
    {
      get { return _disease_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ORCATransferOrdersClaimExaminationFeeInfo> _claim_exam_item = new global::System.Collections.Generic.List<ORCATransferOrdersClaimExaminationFeeInfo>();
    [global::ProtoBuf.ProtoMember(4, Name=@"claim_exam_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCATransferOrdersClaimExaminationFeeInfo> claim_exam_item
    {
      get { return _claim_exam_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ORCATransferOrdersClaimOrdersFeeInfo> _claim_orders_item = new global::System.Collections.Generic.List<ORCATransferOrdersClaimOrdersFeeInfo>();
    [global::ProtoBuf.ProtoMember(5, Name=@"claim_orders_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCATransferOrdersClaimOrdersFeeInfo> claim_orders_item
    {
      get { return _claim_orders_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ORCATransferOrdersErrMsgInfo> _err_msg_item = new global::System.Collections.Generic.List<ORCATransferOrdersErrMsgInfo>();
    [global::ProtoBuf.ProtoMember(6, Name=@"err_msg_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORCATransferOrdersErrMsgInfo> err_msg_item
    {
      get { return _err_msg_item; }
    }
  
    private readonly global::System.Collections.Generic.List<NUR2016U02TranferInfo> _listinfo_item = new global::System.Collections.Generic.List<NUR2016U02TranferInfo>();
    [global::ProtoBuf.ProtoMember(7, Name=@"listinfo_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<NUR2016U02TranferInfo> listinfo_item
    {
      get { return _listinfo_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
