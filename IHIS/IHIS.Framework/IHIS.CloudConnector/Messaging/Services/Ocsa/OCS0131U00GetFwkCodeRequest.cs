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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0131U00GetFwkCodeRequest")]
  public partial class OCS0131U00GetFwkCodeRequest : global::ProtoBuf.IExtensible
  {
    public OCS0131U00GetFwkCodeRequest() {}
    
    private string _find1 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"find1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string find1
    {
      get { return _find1; }
      set { _find1 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}