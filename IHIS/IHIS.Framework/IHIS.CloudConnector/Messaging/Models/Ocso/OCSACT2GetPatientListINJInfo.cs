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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACT2GetPatientListINJInfo")]
  public partial class OCSACT2GetPatientListINJInfo : global::ProtoBuf.IExtensible
  {
    public OCSACT2GetPatientListINJInfo() {}
    
    private string _trial_yn = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"trial_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string trial_yn
    {
      get { return _trial_yn; }
      set { _trial_yn = value; }
    }
    private string _reser_gubun = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"reser_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_gubun
    {
      get { return _reser_gubun; }
      set { _reser_gubun = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _suname = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"suname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suname
    {
      get { return _suname; }
      set { _suname = value; }
    }
    private string _jundal_table = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"jundal_table", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_table
    {
      get { return _jundal_table; }
      set { _jundal_table = value; }
    }
    private string _order_date = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"order_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_date
    {
      get { return _order_date; }
      set { _order_date = value; }
    }
    private string _reser_date = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"reser_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_date
    {
      get { return _reser_date; }
      set { _reser_date = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _gwa_name = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa_name
    {
      get { return _gwa_name; }
      set { _gwa_name = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _doctor_name = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_name
    {
      get { return _doctor_name; }
      set { _doctor_name = value; }
    }
    private string _pkocs1003 = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"pkocs1003", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkocs1003
    {
      get { return _pkocs1003; }
      set { _pkocs1003 = value; }
    }
    private string _pkout1001 = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"pkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkout1001
    {
      get { return _pkout1001; }
      set { _pkout1001 = value; }
    }
    private string _suname2 = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"suname2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suname2
    {
      get { return _suname2; }
      set { _suname2 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
