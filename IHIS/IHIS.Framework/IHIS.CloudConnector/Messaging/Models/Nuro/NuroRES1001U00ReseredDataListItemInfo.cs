//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroRES1001U00ReseredDataListItemInfo")]
  public partial class NuroRES1001U00ReseredDataListItemInfo : global::ProtoBuf.IExtensible
  {
    public NuroRES1001U00ReseredDataListItemInfo() {}
    
    private string _reception_time = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"reception_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reception_time
    {
      get { return _reception_time; }
      set { _reception_time = value; }
    }
    private string _patient_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"patient_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_code
    {
      get { return _patient_code; }
      set { _patient_code = value; }
    }
    private string _patient_name1 = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"patient_name1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_name1
    {
      get { return _patient_name1; }
      set { _patient_name1 = value; }
    }
    private string _patient_name2 = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"patient_name2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_name2
    {
      get { return _patient_name2; }
      set { _patient_name2 = value; }
    }
    private string _exam_status = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"exam_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string exam_status
    {
      get { return _exam_status; }
      set { _exam_status = value; }
    }
    private string _upd_date = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"upd_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string upd_date
    {
      get { return _upd_date; }
      set { _upd_date = value; }
    }
    private string _pkout1001 = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"pkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkout1001
    {
      get { return _pkout1001; }
      set { _pkout1001 = value; }
    }
    private string _coming_date = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"coming_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string coming_date
    {
      get { return _coming_date; }
      set { _coming_date = value; }
    }
    private string _department_code = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"department_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string department_code
    {
      get { return _department_code; }
      set { _department_code = value; }
    }
    private string _reception_no = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"reception_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reception_no
    {
      get { return _reception_no; }
      set { _reception_no = value; }
    }
    private string _type = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type
    {
      get { return _type; }
      set { _type = value; }
    }
    private string _doctor_code = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"doctor_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_code
    {
      get { return _doctor_code; }
      set { _doctor_code = value; }
    }
    private string _res_type = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"res_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string res_type
    {
      get { return _res_type; }
      set { _res_type = value; }
    }
    private string _res_user_name = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"res_user_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string res_user_name
    {
      get { return _res_user_name; }
      set { _res_user_name = value; }
    }
    private string _res_input_type = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"res_input_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string res_input_type
    {
      get { return _res_input_type; }
      set { _res_input_type = value; }
    }
    private string _coming_status = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"coming_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string coming_status
    {
      get { return _coming_status; }
      set { _coming_status = value; }
    }
    private string _new_row = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"new_row", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string new_row
    {
      get { return _new_row; }
      set { _new_row = value; }
    }
    private string _exam_state = "";
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"exam_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string exam_state
    {
      get { return _exam_state; }
      set { _exam_state = value; }
    }
    private string _exam_irai_state = "";
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"exam_irai_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string exam_irai_state
    {
      get { return _exam_irai_state; }
      set { _exam_irai_state = value; }
    }
    private string _res_user = "";
    [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name=@"res_user", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string res_user
    {
      get { return _res_user; }
      set { _res_user = value; }
    }
    private string _ipwon_status = "";
    [global::ProtoBuf.ProtoMember(21, IsRequired = false, Name=@"ipwon_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ipwon_status
    {
      get { return _ipwon_status; }
      set { _ipwon_status = value; }
    }
    private string _reser_comments = "";
    [global::ProtoBuf.ProtoMember(22, IsRequired = false, Name=@"reser_comments", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_comments
    {
      get { return _reser_comments; }
      set { _reser_comments = value; }
    }
    private string _reser_type = "";
    [global::ProtoBuf.ProtoMember(23, IsRequired = false, Name=@"reser_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_type
    {
      get { return _reser_type; }
      set { _reser_type = value; }
    }
    private string _clinic_name = "";
    [global::ProtoBuf.ProtoMember(24, IsRequired = false, Name=@"clinic_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string clinic_name
    {
      get { return _clinic_name; }
      set { _clinic_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
