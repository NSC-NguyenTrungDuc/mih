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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS1003R00LayOUT1001Info")]
  public partial class OCS1003R00LayOUT1001Info : global::ProtoBuf.IExtensible
  {
    public OCS1003R00LayOUT1001Info() {}
    
    private string _reser_yn = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"reser_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_yn
    {
      get { return _reser_yn; }
      set { _reser_yn = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _suname = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"suname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suname
    {
      get { return _suname; }
      set { _suname = value; }
    }
    private string _suname2 = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"suname2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suname2
    {
      get { return _suname2; }
      set { _suname2 = value; }
    }
    private string _birth = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"birth", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string birth
    {
      get { return _birth; }
      set { _birth = value; }
    }
    private string _sex_age = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"sex_age", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sex_age
    {
      get { return _sex_age; }
      set { _sex_age = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _doctor_name = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_name
    {
      get { return _doctor_name; }
      set { _doctor_name = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _gwa_name = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa_name
    {
      get { return _gwa_name; }
      set { _gwa_name = value; }
    }
    private string _chojae = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"chojae", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string chojae
    {
      get { return _chojae; }
      set { _chojae = value; }
    }
    private string _chojae_name = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"chojae_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string chojae_name
    {
      get { return _chojae_name; }
      set { _chojae_name = value; }
    }
    private string _naewon_date = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"naewon_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_date
    {
      get { return _naewon_date; }
      set { _naewon_date = value; }
    }
    private string _input_gubun = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"input_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_gubun
    {
      get { return _input_gubun; }
      set { _input_gubun = value; }
    }
    private string _order_end_yn = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"order_end_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_end_yn
    {
      get { return _order_end_yn; }
      set { _order_end_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
