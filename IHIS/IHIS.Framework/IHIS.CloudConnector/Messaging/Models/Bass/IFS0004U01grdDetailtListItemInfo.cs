//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"IFS0004U01grdDetailtListItemInfo")]
  public partial class IFS0004U01grdDetailtListItemInfo : global::ProtoBuf.IExtensible
  {
    public IFS0004U01grdDetailtListItemInfo() {}
    
    private string _nu_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"nu_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string nu_gubun
    {
      get { return _nu_gubun; }
      set { _nu_gubun = value; }
    }
    private string _nu_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"nu_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string nu_code
    {
      get { return _nu_code; }
      set { _nu_code = value; }
    }
    private string _nu_ymd = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"nu_ymd", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string nu_ymd
    {
      get { return _nu_ymd; }
      set { _nu_ymd = value; }
    }
    private string _bun_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"bun_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bun_code
    {
      get { return _bun_code; }
      set { _bun_code = value; }
    }
    private string _bun_name = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"bun_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bun_name
    {
      get { return _bun_name; }
      set { _bun_name = value; }
    }
    private string _sg_code = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"sg_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sg_code
    {
      get { return _sg_code; }
      set { _sg_code = value; }
    }
    private string _sg_name = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"sg_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sg_name
    {
      get { return _sg_name; }
      set { _sg_name = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string row_state
    {
      get { return _row_state; }
      set { _row_state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}