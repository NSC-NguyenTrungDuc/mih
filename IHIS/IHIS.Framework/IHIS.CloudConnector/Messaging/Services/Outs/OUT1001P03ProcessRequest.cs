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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OUT1001P03ProcessRequest")]
  public partial class OUT1001P03ProcessRequest : global::ProtoBuf.IExtensible
  {
    public OUT1001P03ProcessRequest() {}
    
    private string _from_bunho = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"from_bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string from_bunho
    {
      get { return _from_bunho; }
      set { _from_bunho = value; }
    }
    private string _to_bunho = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"to_bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string to_bunho
    {
      get { return _to_bunho; }
      set { _to_bunho = value; }
    }
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private readonly global::System.Collections.Generic.List<OUT1001P03ProcessInfo> _pk_key_info = new global::System.Collections.Generic.List<OUT1001P03ProcessInfo>();
    [global::ProtoBuf.ProtoMember(4, Name=@"pk_key_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OUT1001P03ProcessInfo> pk_key_info
    {
      get { return _pk_key_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
