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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ADM101UGrdSystemGridColumnChangedRequest")]
  public partial class ADM101UGrdSystemGridColumnChangedRequest : global::ProtoBuf.IExtensible
  {
    public ADM101UGrdSystemGridColumnChangedRequest() {}
    
    private string _buseo_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"buseo_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buseo_code
    {
      get { return _buseo_code; }
      set { _buseo_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}