//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Schs0201U99CheckORCAEnvInfoResponse")]
  public partial class Schs0201U99CheckORCAEnvInfoResponse : global::ProtoBuf.IExtensible
  {
    public Schs0201U99CheckORCAEnvInfoResponse() {}
    
    private readonly global::System.Collections.Generic.List<Schs0201U99CheckORCAEnvInfoInfo> _lstData = new global::System.Collections.Generic.List<Schs0201U99CheckORCAEnvInfoInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"lstData", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Schs0201U99CheckORCAEnvInfoInfo> lstData
    {
      get { return _lstData; }
    }
  
    private string _err_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"err_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string err_code
    {
      get { return _err_code; }
      set { _err_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
