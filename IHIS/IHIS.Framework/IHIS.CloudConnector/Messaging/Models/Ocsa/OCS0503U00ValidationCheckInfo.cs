//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0503U00ValidationCheckInfo")]
  public partial class OCS0503U00ValidationCheckInfo : global::ProtoBuf.IExtensible
  {
    public OCS0503U00ValidationCheckInfo() {}
    
    private string _naewon = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"naewon", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon
    {
      get { return _naewon; }
      set { _naewon = value; }
    }
    private string _order_yn = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"order_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_yn
    {
      get { return _order_yn; }
      set { _order_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
