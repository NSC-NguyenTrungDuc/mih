//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input(1).proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0101U04SendToMBSResponse")]
  public partial class BAS0101U04SendToMBSResponse : global::ProtoBuf.IExtensible
  {
    public BAS0101U04SendToMBSResponse() {}
    
    private string _status = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status
    {
      get { return _status; }
      set { _status = value; }
    }
    private string _message = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string message
    {
      get { return _message; }
      set { _message = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
