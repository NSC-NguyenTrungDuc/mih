//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
// Note: requires additional types generated from: import.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT0122U00SaveLayoutInfo")]
  public partial class XRT0122U00SaveLayoutInfo : global::ProtoBuf.IExtensible
  {
    public XRT0122U00SaveLayoutInfo() {}
    
    private string _caller_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"caller_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string caller_id
    {
      get { return _caller_id; }
      set { _caller_id = value; }
    }
    private string _buwi_bunryu = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"buwi_bunryu", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buwi_bunryu
    {
      get { return _buwi_bunryu; }
      set { _buwi_bunryu = value; }
    }
    private string _buwi_bunryu_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"buwi_bunryu_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buwi_bunryu_name
    {
      get { return _buwi_bunryu_name; }
      set { _buwi_bunryu_name = value; }
    }
    private string _buwi_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"buwi_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buwi_code
    {
      get { return _buwi_code; }
      set { _buwi_code = value; }
    }
    private string _buwi_name = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"buwi_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buwi_name
    {
      get { return _buwi_name; }
      set { _buwi_name = value; }
    }
    private string _sort_seq = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"sort_seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sort_seq
    {
      get { return _sort_seq; }
      set { _sort_seq = value; }
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
