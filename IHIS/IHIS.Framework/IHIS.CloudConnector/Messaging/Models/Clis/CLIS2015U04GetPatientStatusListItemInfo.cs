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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CLIS2015U04GetPatientStatusListItemInfo")]
  public partial class CLIS2015U04GetPatientStatusListItemInfo : global::ProtoBuf.IExtensible
  {
    public CLIS2015U04GetPatientStatusListItemInfo() {}
    
    private string _patient_status_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"patient_status_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_status_id
    {
      get { return _patient_status_id; }
      set { _patient_status_id = value; }
    }
    private string _description = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"description", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string description
    {
      get { return _description; }
      set { _description = value; }
    }
    private string _updated = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"updated", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string updated
    {
      get { return _updated; }
      set { _updated = value; }
    }
    private string _code_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"code_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_name
    {
      get { return _code_name; }
      set { _code_name = value; }
    }
    private string _sort_no = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"sort_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sort_no
    {
      get { return _sort_no; }
      set { _sort_no = value; }
    }
    private string _sys_id = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"sys_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_id
    {
      get { return _sys_id; }
      set { _sys_id = value; }
    }
    private string _update_date = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"update_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string update_date
    {
      get { return _update_date; }
      set { _update_date = value; }
    }
    private string _code = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code
    {
      get { return _code; }
      set { _code = value; }
    }
    private string _protocol_patient_id = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"protocol_patient_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string protocol_patient_id
    {
      get { return _protocol_patient_id; }
      set { _protocol_patient_id = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string row_state
    {
      get { return _row_state; }
      set { _row_state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
