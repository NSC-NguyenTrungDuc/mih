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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U16GrdSangyongOrderRequest")]
  public partial class OCS0103U16GrdSangyongOrderRequest : global::ProtoBuf.IExtensible
  {
    public OCS0103U16GrdSangyongOrderRequest() {}
    
    private string _user = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"user", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user
    {
      get { return _user; }
      set { _user = value; }
    }
    private string _code_yn = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"code_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_yn
    {
      get { return _code_yn; }
      set { _code_yn = value; }
    }
    private string _io_gubun = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"io_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string io_gubun
    {
      get { return _io_gubun; }
      set { _io_gubun = value; }
    }
    private string _order_date = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"order_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_date
    {
      get { return _order_date; }
      set { _order_date = value; }
    }
    private string _search_word = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"search_word", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string search_word
    {
      get { return _search_word; }
      set { _search_word = value; }
    }
    private string _wonnae_drg_yn = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"wonnae_drg_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string wonnae_drg_yn
    {
      get { return _wonnae_drg_yn; }
      set { _wonnae_drg_yn = value; }
    }
    private string _order_gubun = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"order_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_gubun
    {
      get { return _order_gubun; }
      set { _order_gubun = value; }
    }
    private string _protocol_id = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"protocol_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string protocol_id
    {
      get { return _protocol_id; }
      set { _protocol_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
