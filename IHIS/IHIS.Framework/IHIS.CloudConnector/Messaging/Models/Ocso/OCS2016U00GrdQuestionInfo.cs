//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2016U00GrdQuestionInfo")]
  public partial class OCS2016U00GrdQuestionInfo : global::ProtoBuf.IExtensible
  {
    public OCS2016U00GrdQuestionInfo() {}
    
    private string _grp_question_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"grp_question_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string grp_question_id
    {
      get { return _grp_question_id; }
      set { _grp_question_id = value; }
    }
    private string _req_date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"req_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string req_date
    {
      get { return _req_date; }
      set { _req_date = value; }
    }
    private string _req_gwa = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"req_gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string req_gwa
    {
      get { return _req_gwa; }
      set { _req_gwa = value; }
    }
    private string _req_doctor = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"req_doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string req_doctor
    {
      get { return _req_doctor; }
      set { _req_doctor = value; }
    }
    private string _consult_gwa = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"consult_gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string consult_gwa
    {
      get { return _consult_gwa; }
      set { _consult_gwa = value; }
    }
    private string _consult_doctor = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"consult_doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string consult_doctor
    {
      get { return _consult_doctor; }
      set { _consult_doctor = value; }
    }
    private string _consult_date = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"consult_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string consult_date
    {
      get { return _consult_date; }
      set { _consult_date = value; }
    }
    private string _consult_hosp_code = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"consult_hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string consult_hosp_code
    {
      get { return _consult_hosp_code; }
      set { _consult_hosp_code = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _finish_yn = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"finish_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string finish_yn
    {
      get { return _finish_yn; }
      set { _finish_yn = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _req_gwa_name = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"req_gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string req_gwa_name
    {
      get { return _req_gwa_name; }
      set { _req_gwa_name = value; }
    }
    private string _consult_gwa_name = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"consult_gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string consult_gwa_name
    {
      get { return _consult_gwa_name; }
      set { _consult_gwa_name = value; }
    }
    private string _consult_doctor_name = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"consult_doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string consult_doctor_name
    {
      get { return _consult_doctor_name; }
      set { _consult_doctor_name = value; }
    }
    private string _consult_hosp_name = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"consult_hosp_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string consult_hosp_name
    {
      get { return _consult_hosp_name; }
      set { _consult_hosp_name = value; }
    }
    private string _req_doctor_name = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"req_doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string req_doctor_name
    {
      get { return _req_doctor_name; }
      set { _req_doctor_name = value; }
    }
    private string _req_hospital_name = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"req_hospital_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string req_hospital_name
    {
      get { return _req_hospital_name; }
      set { _req_hospital_name = value; }
    }
    private string _status = "";
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status
    {
      get { return _status; }
      set { _status = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
