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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroOUT1001U01GetDbMaxJubsuNoResponse")]
  public partial class NuroOUT1001U01GetDbMaxJubsuNoResponse : global::ProtoBuf.IExtensible
  {
    public NuroOUT1001U01GetDbMaxJubsuNoResponse() {}
    
    private string _max_jubsu_no = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"max_jubsu_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string max_jubsu_no
    {
      get { return _max_jubsu_no; }
      set { _max_jubsu_no = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
