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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EMRGetLatestWarningStatusInfo")]
  public partial class EMRGetLatestWarningStatusInfo : global::ProtoBuf.IExtensible
  {
    public EMRGetLatestWarningStatusInfo() {}
    
    private string _clis_protocol_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"clis_protocol_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string clis_protocol_id
    {
      get { return _clis_protocol_id; }
      set { _clis_protocol_id = value; }
    }
    private string _status_id = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"status_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_id
    {
      get { return _status_id; }
      set { _status_id = value; }
    }
    private string _code_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"code_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_name
    {
      get { return _code_name; }
      set { _code_name = value; }
    }
    private string _updated = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"updated", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string updated
    {
      get { return _updated; }
      set { _updated = value; }
    }
    private string _display_flg = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"display_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string display_flg
    {
      get { return _display_flg; }
      set { _display_flg = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
