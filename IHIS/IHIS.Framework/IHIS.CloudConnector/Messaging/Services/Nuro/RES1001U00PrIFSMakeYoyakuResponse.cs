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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RES1001U00PrIFSMakeYoyakuResponse")]
  public partial class RES1001U00PrIFSMakeYoyakuResponse : global::ProtoBuf.IExtensible
  {
    public RES1001U00PrIFSMakeYoyakuResponse() {}
    
    private string _pkifs1002 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"pkifs1002", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkifs1002
    {
      get { return _pkifs1002; }
      set { _pkifs1002 = value; }
    }
    private string _err_msg = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"err_msg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string err_msg
    {
      get { return _err_msg; }
      set { _err_msg = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}