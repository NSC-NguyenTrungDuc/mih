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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsaOCS0503U01CommonDataRequest")]
  public partial class OcsaOCS0503U01CommonDataRequest : global::ProtoBuf.IExtensible
  {
    public OcsaOCS0503U01CommonDataRequest() {}
    
    private string _f_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"f_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_code
    {
      get { return _f_code; }
      set { _f_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
