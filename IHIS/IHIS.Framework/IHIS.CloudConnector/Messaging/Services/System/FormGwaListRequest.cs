//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: system_service.proto
// Note: requires additional types generated from: system_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FormGwaListRequest")]
  public partial class FormGwaListRequest : global::ProtoBuf.IExtensible
  {
    public FormGwaListRequest() {}
    
    private string _user_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
