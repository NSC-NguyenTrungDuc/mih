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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U00GetDoctorPatientReportResponse")]
  public partial class OCS2015U00GetDoctorPatientReportResponse : global::ProtoBuf.IExtensible
  {
    public OCS2015U00GetDoctorPatientReportResponse() {}
    
    private OCS2015U00GetDoctorPatientReportInfo _list_item = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS2015U00GetDoctorPatientReportInfo list_item
    {
      get { return _list_item; }
      set { _list_item = value; }
    }
    private readonly global::System.Collections.Generic.List<OCS2015U00GetDiseaseReportInfo> _list_disease = new global::System.Collections.Generic.List<OCS2015U00GetDiseaseReportInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"list_disease", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U00GetDiseaseReportInfo> list_disease
    {
      get { return _list_disease; }
    }
  
    private readonly global::System.Collections.Generic.List<OCS2015U00GetOrderReportInfo> _list_order = new global::System.Collections.Generic.List<OCS2015U00GetOrderReportInfo>();
    [global::ProtoBuf.ProtoMember(3, Name=@"list_order", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U00GetOrderReportInfo> list_order
    {
      get { return _list_order; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}