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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"END1001U02GrdComment3Info")]
  public partial class END1001U02GrdComment3Info : global::ProtoBuf.IExtensible
  {
    public END1001U02GrdComment3Info() {}
    
    private string _comments = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"comments", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string comments
    {
      get { return _comments; }
      set { _comments = value; }
    }
    private string _numb = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"numb", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string numb
    {
      get { return _numb; }
      set { _numb = value; }
    }
    private string _ser = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"ser", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ser
    {
      get { return _ser; }
      set { _ser = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
