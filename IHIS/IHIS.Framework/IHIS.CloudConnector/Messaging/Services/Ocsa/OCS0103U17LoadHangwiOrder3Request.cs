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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U17LoadHangwiOrder3Request")]
  public partial class OCS0103U17LoadHangwiOrder3Request : global::ProtoBuf.IExtensible
  {
    public OCS0103U17LoadHangwiOrder3Request() {}
    
    private string _searchword = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"searchword", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string searchword
    {
      get { return _searchword; }
      set { _searchword = value; }
    }
    private string _searchcondition = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"searchcondition", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string searchcondition
    {
      get { return _searchcondition; }
      set { _searchcondition = value; }
    }
    private string _mode = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"mode", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mode
    {
      get { return _mode; }
      set { _mode = value; }
    }
    private string _slip_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"slip_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string slip_code
    {
      get { return _slip_code; }
      set { _slip_code = value; }
    }
    private string _code_yn = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"code_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_yn
    {
      get { return _code_yn; }
      set { _code_yn = value; }
    }
    private string _input_tab = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"input_tab", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_tab
    {
      get { return _input_tab; }
      set { _input_tab = value; }
    }
    private string _wonnae_drg_yn = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"wonnae_drg_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string wonnae_drg_yn
    {
      get { return _wonnae_drg_yn; }
      set { _wonnae_drg_yn = value; }
    }
    private string _user = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"user", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user
    {
      get { return _user; }
      set { _user = value; }
    }
    private string _order_date = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"order_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_date
    {
      get { return _order_date; }
      set { _order_date = value; }
    }
    private string _page_number = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"page_number", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string page_number
    {
      get { return _page_number; }
      set { _page_number = value; }
    }
    private string _offset = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"offset", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string offset
    {
      get { return _offset; }
      set { _offset = value; }
    }
    private string _protocol_id = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"protocol_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
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
