//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input(1).proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BIL0102U00GetPatientEmailResponse")]
  public partial class BIL0102U00GetPatientEmailResponse : global::ProtoBuf.IExtensible
  {
    public BIL0102U00GetPatientEmailResponse() {}
    
    private string _email = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"email", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string email
    {
      get { return _email; }
      set { _email = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
