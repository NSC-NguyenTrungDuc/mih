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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0108U00grdOCS0108ItemInfo")]
  public partial class OCS0108U00grdOCS0108ItemInfo : global::ProtoBuf.IExtensible
  {
    public OCS0108U00grdOCS0108ItemInfo() {}
    
    private string _hangmog_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"hangmog_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_code
    {
      get { return _hangmog_code; }
      set { _hangmog_code = value; }
    }
    private string _seq = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string seq
    {
      get { return _seq; }
      set { _seq = value; }
    }
    private string _ord_danui = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"ord_danui", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ord_danui
    {
      get { return _ord_danui; }
      set { _ord_danui = value; }
    }
    private string _change_qty1 = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"change_qty1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string change_qty1
    {
      get { return _change_qty1; }
      set { _change_qty1 = value; }
    }
    private string _change_qty2 = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"change_qty2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string change_qty2
    {
      get { return _change_qty2; }
      set { _change_qty2 = value; }
    }
    private string _sunab_danui = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"sunab_danui", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sunab_danui
    {
      get { return _sunab_danui; }
      set { _sunab_danui = value; }
    }
    private string _subul_danui = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"subul_danui", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string subul_danui
    {
      get { return _subul_danui; }
      set { _subul_danui = value; }
    }
    private string _hangmog_start_date = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"hangmog_start_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_start_date
    {
      get { return _hangmog_start_date; }
      set { _hangmog_start_date = value; }
    }
    private string _data_row_state = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"data_row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string data_row_state
    {
      get { return _data_row_state; }
      set { _data_row_state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}