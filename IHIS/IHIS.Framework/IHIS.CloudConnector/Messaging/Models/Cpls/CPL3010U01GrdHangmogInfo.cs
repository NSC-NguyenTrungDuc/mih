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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL3010U01GrdHangmogInfo")]
  public partial class CPL3010U01GrdHangmogInfo : global::ProtoBuf.IExtensible
  {
    public CPL3010U01GrdHangmogInfo() {}
    
    private string _recode_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"recode_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string recode_gubun
    {
      get { return _recode_gubun; }
      set { _recode_gubun = value; }
    }
    private string _center_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"center_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string center_code
    {
      get { return _center_code; }
      set { _center_code = value; }
    }
    private string _request_key = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"request_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string request_key
    {
      get { return _request_key; }
      set { _request_key = value; }
    }
    private string _hospital_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"hospital_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hospital_code
    {
      get { return _hospital_code; }
      set { _hospital_code = value; }
    }
    private string _hangmog_code = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"hangmog_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_code
    {
      get { return _hangmog_code; }
      set { _hangmog_code = value; }
    }
    private string _san_code = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"san_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string san_code
    {
      get { return _san_code; }
      set { _san_code = value; }
    }
    private string _specimen_code = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"specimen_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_code
    {
      get { return _specimen_code; }
      set { _specimen_code = value; }
    }
    private string _emergency = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"emergency", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string emergency
    {
      get { return _emergency; }
      set { _emergency = value; }
    }
    private string _empty_string = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"empty_string", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string empty_string
    {
      get { return _empty_string; }
      set { _empty_string = value; }
    }
    private string _specimen_ser = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"specimen_ser", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_ser
    {
      get { return _specimen_ser; }
      set { _specimen_ser = value; }
    }
    private string _jundal_gubun_name = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"jundal_gubun_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_gubun_name
    {
      get { return _jundal_gubun_name; }
      set { _jundal_gubun_name = value; }
    }
    private string _gumsa_name = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"gumsa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gumsa_name
    {
      get { return _gumsa_name; }
      set { _gumsa_name = value; }
    }
    private string _specimen_name = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"specimen_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_name
    {
      get { return _specimen_name; }
      set { _specimen_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}