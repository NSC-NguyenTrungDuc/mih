//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RES1001U00CheckUsingOrcaRequest")]
  public partial class RES1001U00CheckUsingOrcaRequest : global::ProtoBuf.IExtensible
  {
    public RES1001U00CheckUsingOrcaRequest() {}
    
    private string _hosp_code_link = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"hosp_code_link", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code_link
    {
      get { return _hosp_code_link; }
      set { _hosp_code_link = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}