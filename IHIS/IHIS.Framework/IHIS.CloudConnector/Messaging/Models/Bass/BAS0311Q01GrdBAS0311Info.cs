//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0311Q01GrdBAS0311Info")]
  public partial class BAS0311Q01GrdBAS0311Info : global::ProtoBuf.IExtensible
  {
    public BAS0311Q01GrdBAS0311Info() {}
    
    private string _sg_ymd = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sg_ymd", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sg_ymd
    {
      get { return _sg_ymd; }
      set { _sg_ymd = value; }
    }
    private string _sg_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"sg_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sg_code
    {
      get { return _sg_code; }
      set { _sg_code = value; }
    }
    private string _sg_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"sg_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sg_name
    {
      get { return _sg_name; }
      set { _sg_name = value; }
    }
    private string _sg_name_kana = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"sg_name_kana", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sg_name_kana
    {
      get { return _sg_name_kana; }
      set { _sg_name_kana = value; }
    }
    private string _bun_code = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"bun_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bun_code
    {
      get { return _bun_code; }
      set { _bun_code = value; }
    }
    private string _group_gubun = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"group_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string group_gubun
    {
      get { return _group_gubun; }
      set { _group_gubun = value; }
    }
    private string _danui = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"danui", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string danui
    {
      get { return _danui; }
      set { _danui = value; }
    }
    private string _bulyong_ymd = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"bulyong_ymd", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bulyong_ymd
    {
      get { return _bulyong_ymd; }
      set { _bulyong_ymd = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}