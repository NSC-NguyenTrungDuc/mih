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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ORDERTRANOcs1003UpdateInfo")]
  public partial class ORDERTRANOcs1003UpdateInfo : global::ProtoBuf.IExtensible
  {
    public ORDERTRANOcs1003UpdateInfo() {}
    
    private string _sunab_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sunab_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sunab_date
    {
      get { return _sunab_date; }
      set { _sunab_date = value; }
    }
    private string _pkocs1003 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"pkocs1003", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkocs1003
    {
      get { return _pkocs1003; }
      set { _pkocs1003 = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _acting_date = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"acting_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string acting_date
    {
      get { return _acting_date; }
      set { _acting_date = value; }
    }
    private string _gubun = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gubun
    {
      get { return _gubun; }
      set { _gubun = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _chojae = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"chojae", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string chojae
    {
      get { return _chojae; }
      set { _chojae = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
