//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service2.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U44EmrHistoricRecordUpdateRequest")]
  public partial class OCS2015U44EmrHistoricRecordUpdateRequest : global::ProtoBuf.IExtensible
  {
    public OCS2015U44EmrHistoricRecordUpdateRequest() {}
    
    private string _record_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"record_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string record_id
    {
      get { return _record_id; }
      set { _record_id = value; }
    }
    private string _upd_id = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"upd_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string upd_id
    {
      get { return _upd_id; }
      set { _upd_id = value; }
    }
    private string _content = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"content", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string content
    {
      get { return _content; }
      set { _content = value; }
    }
    private string _metadata = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"metadata", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string metadata
    {
      get { return _metadata; }
      set { _metadata = value; }
    }
    private string _record_log = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"record_log", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string record_log
    {
      get { return _record_log; }
      set { _record_log = value; }
    }
    private string _email_flg = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"email_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string email_flg
    {
      get { return _email_flg; }
      set { _email_flg = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}