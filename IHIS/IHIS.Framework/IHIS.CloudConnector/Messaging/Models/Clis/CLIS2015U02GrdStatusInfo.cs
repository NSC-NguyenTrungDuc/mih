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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CLIS2015U02GrdStatusInfo")]
  public partial class CLIS2015U02GrdStatusInfo : global::ProtoBuf.IExtensible
  {
    public CLIS2015U02GrdStatusInfo() {}
    
    private string _protocol_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"protocol_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string protocol_id
    {
      get { return _protocol_id; }
      set { _protocol_id = value; }
    }
    private string _status_id = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"status_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_id
    {
      get { return _status_id; }
      set { _status_id = value; }
    }
    private string _status_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"status_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_code
    {
      get { return _status_code; }
      set { _status_code = value; }
    }
    private string _status_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"status_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_name
    {
      get { return _status_name; }
      set { _status_name = value; }
    }
    private string _sort_no = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"sort_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sort_no
    {
      get { return _sort_no; }
      set { _sort_no = value; }
    }
    private string _display_flg = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"display_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string display_flg
    {
      get { return _display_flg; }
      set { _display_flg = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
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
