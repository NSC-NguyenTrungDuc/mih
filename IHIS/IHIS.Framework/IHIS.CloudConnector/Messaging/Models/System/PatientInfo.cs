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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PatientInfo")]
  public partial class PatientInfo : global::ProtoBuf.IExtensible
  {
    public PatientInfo() {}
    
    private string _patient_name1 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"patient_name1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_name1
    {
      get { return _patient_name1; }
      set { _patient_name1 = value; }
    }
    private string _patient_name2 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"patient_name2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_name2
    {
      get { return _patient_name2; }
      set { _patient_name2 = value; }
    }
    private string _sex = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"sex", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sex
    {
      get { return _sex; }
      set { _sex = value; }
    }
    private string _year_age = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"year_age", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string year_age
    {
      get { return _year_age; }
      set { _year_age = value; }
    }
    private string _month_age = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"month_age", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string month_age
    {
      get { return _month_age; }
      set { _month_age = value; }
    }
    private string _type = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type
    {
      get { return _type; }
      set { _type = value; }
    }
    private string _code_nm = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"code_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_nm
    {
      get { return _code_nm; }
      set { _code_nm = value; }
    }
    private string _birth = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"birth", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string birth
    {
      get { return _birth; }
      set { _birth = value; }
    }
    private string _tel = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"tel", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tel
    {
      get { return _tel; }
      set { _tel = value; }
    }
    private string _tel1 = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"tel1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tel1
    {
      get { return _tel1; }
      set { _tel1 = value; }
    }
    private string _tel_hp = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"tel_hp", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tel_hp
    {
      get { return _tel_hp; }
      set { _tel_hp = value; }
    }
    private string _email = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"email", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string email
    {
      get { return _email; }
      set { _email = value; }
    }
    private string _zip_code1 = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"zip_code1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string zip_code1
    {
      get { return _zip_code1; }
      set { _zip_code1 = value; }
    }
    private string _zip_code2 = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"zip_code2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string zip_code2
    {
      get { return _zip_code2; }
      set { _zip_code2 = value; }
    }
    private string _address1 = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"address1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string address1
    {
      get { return _address1; }
      set { _address1 = value; }
    }
    private string _address2 = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"address2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string address2
    {
      get { return _address2; }
      set { _address2 = value; }
    }
    private string _tel_gubun1 = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"tel_gubun1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tel_gubun1
    {
      get { return _tel_gubun1; }
      set { _tel_gubun1 = value; }
    }
    private string _tel_gubun2 = "";
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"tel_gubun2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tel_gubun2
    {
      get { return _tel_gubun2; }
      set { _tel_gubun2 = value; }
    }
    private string _tel_gubun3 = "";
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"tel_gubun3", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tel_gubun3
    {
      get { return _tel_gubun3; }
      set { _tel_gubun3 = value; }
    }
    private string _pwd = "";
    [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name=@"pwd", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pwd
    {
      get { return _pwd; }
      set { _pwd = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}