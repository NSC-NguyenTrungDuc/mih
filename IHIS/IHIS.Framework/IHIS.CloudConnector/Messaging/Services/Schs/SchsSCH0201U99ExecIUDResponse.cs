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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201U99ExecIUDResponse")]
  public partial class SchsSCH0201U99ExecIUDResponse : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201U99ExecIUDResponse() {}
    
    private string _io_err = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"io_err", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string io_err
    {
      get { return _io_err; }
      set { _io_err = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
