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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroRES1001U00ReservationScheduleListItemInfo")]
  public partial class NuroRES1001U00ReservationScheduleListItemInfo : global::ProtoBuf.IExtensible
  {
    public NuroRES1001U00ReservationScheduleListItemInfo() {}
    
    private string _exam_pre_time = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"exam_pre_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string exam_pre_time
    {
      get { return _exam_pre_time; }
      set { _exam_pre_time = value; }
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
    private string _reser_date = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"reser_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_date
    {
      get { return _reser_date; }
      set { _reser_date = value; }
    }
    private string _pkout1001 = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"pkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkout1001
    {
      get { return _pkout1001; }
      set { _pkout1001 = value; }
    }
    private string _exam_pre_date = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"exam_pre_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string exam_pre_date
    {
      get { return _exam_pre_date; }
      set { _exam_pre_date = value; }
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
    private string _res_changgu = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"res_changgu", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string res_changgu
    {
      get { return _res_changgu; }
      set { _res_changgu = value; }
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
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
