//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: xrts_service.proto
// Note: requires additional types generated from: system_model.proto
// Note: requires additional types generated from: xrts_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT0201U00NaewonDateRequest")]
  public partial class XRT0201U00NaewonDateRequest : global::ProtoBuf.IExtensible
  {
    public XRT0201U00NaewonDateRequest() {}
    
    private string _naewon_key = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"naewon_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_key
    {
      get { return _naewon_key; }
      set { _naewon_key = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}