//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_service.proto
// Note: requires additional types generated from: nuro_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroRES1001U00UserNameResponse")]
  public partial class NuroRES1001U00UserNameResponse : global::ProtoBuf.IExtensible
  {
    public NuroRES1001U00UserNameResponse() {}
    
    private string _user_name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"user_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string user_name
    {
      get { return _user_name; }
      set { _user_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}