//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OUT0101U02GetPatientCodeRequest")]
  public partial class OUT0101U02GetPatientCodeRequest : global::ProtoBuf.IExtensible
  {
    public OUT0101U02GetPatientCodeRequest() {}
    
    private string _get_patient_code_yn = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"get_patient_code_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string get_patient_code_yn
    {
      get { return _get_patient_code_yn; }
      set { _get_patient_code_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
