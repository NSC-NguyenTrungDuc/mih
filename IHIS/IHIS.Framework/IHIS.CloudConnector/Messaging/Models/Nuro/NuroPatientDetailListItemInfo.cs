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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroPatientDetailListItemInfo")]
  public partial class NuroPatientDetailListItemInfo : global::ProtoBuf.IExtensible
  {
    public NuroPatientDetailListItemInfo() {}
    
    private string _department_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"department_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string department_code
    {
      get { return _department_code; }
      set { _department_code = value; }
    }
    private string _department_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"department_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string department_name
    {
      get { return _department_name; }
      set { _department_name = value; }
    }
    private string _doctor_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"doctor_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_code
    {
      get { return _doctor_code; }
      set { _doctor_code = value; }
    }
    private string _doctor_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_name
    {
      get { return _doctor_name; }
      set { _doctor_name = value; }
    }
    private string _exam_status = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"exam_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string exam_status
    {
      get { return _exam_status; }
      set { _exam_status = value; }
    }
    private string _reception_no = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"reception_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reception_no
    {
      get { return _reception_no; }
      set { _reception_no = value; }
    }
    private string _insur_code = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"insur_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string insur_code
    {
      get { return _insur_code; }
      set { _insur_code = value; }
    }
    private string _insur_name = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"insur_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string insur_name
    {
      get { return _insur_name; }
      set { _insur_name = value; }
    }
    private string _patient_code;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"patient_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string patient_code
    {
      get { return _patient_code; }
      set { _patient_code = value; }
    }
    private string _coming_date = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"coming_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string coming_date
    {
      get { return _coming_date; }
      set { _coming_date = value; }
    }
    private string _pkout1001 = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"pkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkout1001
    {
      get { return _pkout1001; }
      set { _pkout1001 = value; }
    }
    private string _reception_time = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"reception_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reception_time
    {
      get { return _reception_time; }
      set { _reception_time = value; }
    }
    private string _coming_status = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"coming_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string coming_status
    {
      get { return _coming_status; }
      set { _coming_status = value; }
    }
    private string _coming_type = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"coming_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string coming_type
    {
      get { return _coming_type; }
      set { _coming_type = value; }
    }
    private string _sunnab_status = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"sunnab_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sunnab_status
    {
      get { return _sunnab_status; }
      set { _sunnab_status = value; }
    }
    private string _fkinp1001 = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"fkinp1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkinp1001
    {
      get { return _fkinp1001; }
      set { _fkinp1001 = value; }
    }
    private string _reception_type = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"reception_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reception_type
    {
      get { return _reception_type; }
      set { _reception_type = value; }
    }
    private string _inp_trans_status = "";
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"inp_trans_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string inp_trans_status
    {
      get { return _inp_trans_status; }
      set { _inp_trans_status = value; }
    }
    private string _bigo = "";
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"bigo", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bigo
    {
      get { return _bigo; }
      set { _bigo = value; }
    }
    private string _insur_code1 = "";
    [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name=@"insur_code1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string insur_code1
    {
      get { return _insur_code1; }
      set { _insur_code1 = value; }
    }
    private string _insur_code2 = "";
    [global::ProtoBuf.ProtoMember(21, IsRequired = false, Name=@"insur_code2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string insur_code2
    {
      get { return _insur_code2; }
      set { _insur_code2 = value; }
    }
    private string _insur_code3 = "";
    [global::ProtoBuf.ProtoMember(22, IsRequired = false, Name=@"insur_code3", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string insur_code3
    {
      get { return _insur_code3; }
      set { _insur_code3 = value; }
    }
    private string _insur_code4 = "";
    [global::ProtoBuf.ProtoMember(23, IsRequired = false, Name=@"insur_code4", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string insur_code4
    {
      get { return _insur_code4; }
      set { _insur_code4 = value; }
    }
    private string _priority1 = "";
    [global::ProtoBuf.ProtoMember(24, IsRequired = false, Name=@"priority1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string priority1
    {
      get { return _priority1; }
      set { _priority1 = value; }
    }
    private string _priority2 = "";
    [global::ProtoBuf.ProtoMember(25, IsRequired = false, Name=@"priority2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string priority2
    {
      get { return _priority2; }
      set { _priority2 = value; }
    }
    private string _priority3 = "";
    [global::ProtoBuf.ProtoMember(26, IsRequired = false, Name=@"priority3", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string priority3
    {
      get { return _priority3; }
      set { _priority3 = value; }
    }
    private string _priority4 = "";
    [global::ProtoBuf.ProtoMember(27, IsRequired = false, Name=@"priority4", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string priority4
    {
      get { return _priority4; }
      set { _priority4 = value; }
    }
    private string _sujin_no = "";
    [global::ProtoBuf.ProtoMember(28, IsRequired = false, Name=@"sujin_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sujin_no
    {
      get { return _sujin_no; }
      set { _sujin_no = value; }
    }
    private string _wonyoi_order_status = "";
    [global::ProtoBuf.ProtoMember(29, IsRequired = false, Name=@"wonyoi_order_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string wonyoi_order_status
    {
      get { return _wonyoi_order_status; }
      set { _wonyoi_order_status = value; }
    }
    private string _reser_status = "";
    [global::ProtoBuf.ProtoMember(30, IsRequired = false, Name=@"reser_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_status
    {
      get { return _reser_status; }
      set { _reser_status = value; }
    }
    private string _button = "";
    [global::ProtoBuf.ProtoMember(31, IsRequired = false, Name=@"button", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string button
    {
      get { return _button; }
      set { _button = value; }
    }
    private string _check_coming = "";
    [global::ProtoBuf.ProtoMember(32, IsRequired = false, Name=@"check_coming", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string check_coming
    {
      get { return _check_coming; }
      set { _check_coming = value; }
    }
    private string _arrive_time = "";
    [global::ProtoBuf.ProtoMember(33, IsRequired = false, Name=@"arrive_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string arrive_time
    {
      get { return _arrive_time; }
      set { _arrive_time = value; }
    }
    private string _group_key = "";
    [global::ProtoBuf.ProtoMember(34, IsRequired = false, Name=@"group_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string group_key
    {
      get { return _group_key; }
      set { _group_key = value; }
    }
    private string _cont_key = "";
    [global::ProtoBuf.ProtoMember(35, IsRequired = false, Name=@"cont_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cont_key
    {
      get { return _cont_key; }
      set { _cont_key = value; }
    }
    private string _sys_id = "";
    [global::ProtoBuf.ProtoMember(36, IsRequired = false, Name=@"sys_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_id
    {
      get { return _sys_id; }
      set { _sys_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
