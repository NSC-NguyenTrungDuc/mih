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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ADMS2015U01SystemIdValidatingResponse")]
  public partial class ADMS2015U01SystemIdValidatingResponse : global::ProtoBuf.IExtensible
  {
    public ADMS2015U01SystemIdValidatingResponse() {}
    
    private string _sys_name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sys_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_name
    {
      get { return _sys_name; }
      set { _sys_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
