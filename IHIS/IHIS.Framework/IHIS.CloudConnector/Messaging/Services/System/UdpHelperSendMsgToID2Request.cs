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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UdpHelperSendMsgToID2Request")]
  public partial class UdpHelperSendMsgToID2Request : global::ProtoBuf.IExtensible
  {
    public UdpHelperSendMsgToID2Request() {}
    
    private string _sender_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sender_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sender_id
    {
      get { return _sender_id; }
      set { _sender_id = value; }
    }
    private string _send_seq = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"send_seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string send_seq
    {
      get { return _send_seq; }
      set { _send_seq = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
