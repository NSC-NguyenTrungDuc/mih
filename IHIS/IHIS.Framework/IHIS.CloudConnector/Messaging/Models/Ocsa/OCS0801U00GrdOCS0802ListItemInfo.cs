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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0801U00GrdOCS0802ListItemInfo")]
  public partial class OCS0801U00GrdOCS0802ListItemInfo : global::ProtoBuf.IExtensible
  {
    public OCS0801U00GrdOCS0802ListItemInfo() {}
    
    private string _pat_status = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"pat_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pat_status
    {
      get { return _pat_status; }
      set { _pat_status = value; }
    }
    private string _pat_status_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"pat_status_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pat_status_code
    {
      get { return _pat_status_code; }
      set { _pat_status_code = value; }
    }
    private string _pat_status_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"pat_status_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pat_status_name
    {
      get { return _pat_status_name; }
      set { _pat_status_name = value; }
    }
    private string _ment = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"ment", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ment
    {
      get { return _ment; }
      set { _ment = value; }
    }
    private string _seq = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string seq
    {
      get { return _seq; }
      set { _seq = value; }
    }
    private string _cont_key = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"cont_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cont_key
    {
      get { return _cont_key; }
      set { _cont_key = value; }
    }
    private string _row_sate = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"row_sate", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string row_sate
    {
      get { return _row_sate; }
      set { _row_sate = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
