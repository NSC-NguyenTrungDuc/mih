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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PHY2001U04GrdExcelRequest")]
  public partial class PHY2001U04GrdExcelRequest : global::ProtoBuf.IExtensible
  {
    public PHY2001U04GrdExcelRequest() {}
    
    private string _naewon_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"naewon_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_date
    {
      get { return _naewon_date; }
      set { _naewon_date = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _jubsu_gubun = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"jubsu_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jubsu_gubun
    {
      get { return _jubsu_gubun; }
      set { _jubsu_gubun = value; }
    }
    private string _jinryo_yn = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"jinryo_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jinryo_yn
    {
      get { return _jinryo_yn; }
      set { _jinryo_yn = value; }
    }
    private string _naewon_yn = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"naewon_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_yn
    {
      get { return _naewon_yn; }
      set { _naewon_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
