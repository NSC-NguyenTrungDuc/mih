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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroGetRecentlyDoctorResponse")]
  public partial class NuroGetRecentlyDoctorResponse : global::ProtoBuf.IExtensible
  {
    public NuroGetRecentlyDoctorResponse() {}
    
    private string _ret_value = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"ret_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ret_value
    {
      get { return _ret_value; }
      set { _ret_value = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
