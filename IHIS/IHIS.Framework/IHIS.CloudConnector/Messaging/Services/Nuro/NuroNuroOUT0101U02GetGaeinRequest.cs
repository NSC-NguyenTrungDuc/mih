//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_service.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroNuroOUT0101U02GetGaeinRequest")]
  public partial class NuroNuroOUT0101U02GetGaeinRequest : global::ProtoBuf.IExtensible
  {
    public NuroNuroOUT0101U02GetGaeinRequest() {}
    
    private string _johap = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"johap", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string johap
    {
      get { return _johap; }
      set { _johap = value; }
    }
    private string _gaein = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"gaein", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gaein
    {
      get { return _gaein; }
      set { _gaein = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
