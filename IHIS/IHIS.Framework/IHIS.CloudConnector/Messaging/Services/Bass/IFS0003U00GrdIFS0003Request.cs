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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"IFS0003U00GrdIFS0003Request")]
  public partial class IFS0003U00GrdIFS0003Request : global::ProtoBuf.IExtensible
  {
    public IFS0003U00GrdIFS0003Request() {}
    
    private string _map_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"map_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string map_gubun
    {
      get { return _map_gubun; }
      set { _map_gubun = value; }
    }
    private string _map_gubun_ymd = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"map_gubun_ymd", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string map_gubun_ymd
    {
      get { return _map_gubun_ymd; }
      set { _map_gubun_ymd = value; }
    }
    private string _code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code
    {
      get { return _code; }
      set { _code = value; }
    }
    private string _acct_type = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"acct_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string acct_type
    {
      get { return _acct_type; }
      set { _acct_type = value; }
    }
    private string _page_number = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"page_number", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string page_number
    {
      get { return _page_number; }
      set { _page_number = value; }
    }
    private string _offset = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"offset", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string offset
    {
      get { return _offset; }
      set { _offset = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
