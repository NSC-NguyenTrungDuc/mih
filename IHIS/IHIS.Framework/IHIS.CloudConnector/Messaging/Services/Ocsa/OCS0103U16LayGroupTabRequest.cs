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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U16LayGroupTabRequest")]
  public partial class OCS0103U16LayGroupTabRequest : global::ProtoBuf.IExtensible
  {
    public OCS0103U16LayGroupTabRequest() {}
    
    private string _order_mode = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"order_mode", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_mode
    {
      get { return _order_mode; }
      set { _order_mode = value; }
    }
    private string _memb = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"memb", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string memb
    {
      get { return _memb; }
      set { _memb = value; }
    }
    private string _yaksok_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"yaksok_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yaksok_code
    {
      get { return _yaksok_code; }
      set { _yaksok_code = value; }
    }
    private string _input_tab = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"input_tab", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_tab
    {
      get { return _input_tab; }
      set { _input_tab = value; }
    }
    private string _fk_in_out_key = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"fk_in_out_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fk_in_out_key
    {
      get { return _fk_in_out_key; }
      set { _fk_in_out_key = value; }
    }
    private string _order_date = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"order_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_date
    {
      get { return _order_date; }
      set { _order_date = value; }
    }
    private string _input_gubun = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"input_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_gubun
    {
      get { return _input_gubun; }
      set { _input_gubun = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
