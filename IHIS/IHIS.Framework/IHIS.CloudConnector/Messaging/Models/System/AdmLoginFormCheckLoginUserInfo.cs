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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"AdmLoginFormCheckLoginUserInfo")]
  public partial class AdmLoginFormCheckLoginUserInfo : global::ProtoBuf.IExtensible
  {
    public AdmLoginFormCheckLoginUserInfo() {}
    
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _user_nm = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"user_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_nm
    {
      get { return _user_nm; }
      set { _user_nm = value; }
    }
    private string _user_group = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_group", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_group
    {
      get { return _user_group; }
      set { _user_group = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _doctor_drug_check = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"doctor_drug_check", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_drug_check
    {
      get { return _doctor_drug_check; }
      set { _doctor_drug_check = value; }
    }
    private string _check_kinki = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"check_kinki", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string check_kinki
    {
      get { return _check_kinki; }
      set { _check_kinki = value; }
    }
    private string _check_interaction = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"check_interaction", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string check_interaction
    {
      get { return _check_interaction; }
      set { _check_interaction = value; }
    }
    private string _check_dosage = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"check_dosage", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string check_dosage
    {
      get { return _check_dosage; }
      set { _check_dosage = value; }
    }
    private string _rev_kinki_message = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"rev_kinki_message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string rev_kinki_message
    {
      get { return _rev_kinki_message; }
      set { _rev_kinki_message = value; }
    }
    private string _rev_kinki_disease = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"rev_kinki_disease", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string rev_kinki_disease
    {
      get { return _rev_kinki_disease; }
      set { _rev_kinki_disease = value; }
    }
    private string _rev_dosage = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"rev_dosage", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string rev_dosage
    {
      get { return _rev_dosage; }
      set { _rev_dosage = value; }
    }
    private string _rev_drug_checking = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"rev_drug_checking", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string rev_drug_checking
    {
      get { return _rev_drug_checking; }
      set { _rev_drug_checking = value; }
    }
    private string _rev_interaction = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"rev_interaction", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string rev_interaction
    {
      get { return _rev_interaction; }
      set { _rev_interaction = value; }
    }
    private string _rev_generic_name = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"rev_generic_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string rev_generic_name
    {
      get { return _rev_generic_name; }
      set { _rev_generic_name = value; }
    }
    private string _language = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"language", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string language
    {
      get { return _language; }
      set { _language = value; }
    }
    private string _change_pwd_flg = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"change_pwd_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string change_pwd_flg
    {
      get { return _change_pwd_flg; }
      set { _change_pwd_flg = value; }
    }
    private string _first_login_flg = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"first_login_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string first_login_flg
    {
      get { return _first_login_flg; }
      set { _first_login_flg = value; }
    }
    private string _last_pwd_change = "";
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"last_pwd_change", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string last_pwd_change
    {
      get { return _last_pwd_change; }
      set { _last_pwd_change = value; }
    }
    private string _pwd_history = "";
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"pwd_history", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pwd_history
    {
      get { return _pwd_history; }
      set { _pwd_history = value; }
    }
    private string _current_time = "";
    [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name=@"current_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string current_time
    {
      get { return _current_time; }
      set { _current_time = value; }
    }
    private string _end_time = "";
    [global::ProtoBuf.ProtoMember(21, IsRequired = false, Name=@"end_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string end_time
    {
      get { return _end_time; }
      set { _end_time = value; }
    }
    private int _clis_smo_id = default(int);
    [global::ProtoBuf.ProtoMember(22, IsRequired = false, Name=@"clis_smo_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int clis_smo_id
    {
      get { return _clis_smo_id; }
      set { _clis_smo_id = value; }
    }
    private string _cert_expired = "";
    [global::ProtoBuf.ProtoMember(23, IsRequired = false, Name=@"cert_expired", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cert_expired
    {
      get { return _cert_expired; }
      set { _cert_expired = value; }
    }
    private string _inv_usage = "";
    [global::ProtoBuf.ProtoMember(24, IsRequired = false, Name=@"inv_usage", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string inv_usage
    {
      get { return _inv_usage; }
      set { _inv_usage = value; }
    }
    private string _use_phr = "";
    [global::ProtoBuf.ProtoMember(25, IsRequired = false, Name=@"use_phr", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string use_phr
    {
      get { return _use_phr; }
      set { _use_phr = value; }
    }
    private string _time_zone = "";
    [global::ProtoBuf.ProtoMember(26, IsRequired = false, Name=@"time_zone", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string time_zone
    {
      get { return _time_zone; }
      set { _time_zone = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}