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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NUR2001U04CheckExistMedicalRecordResponse")]
  public partial class NUR2001U04CheckExistMedicalRecordResponse : global::ProtoBuf.IExtensible
  {
    public NUR2001U04CheckExistMedicalRecordResponse() {}
    
    private readonly global::System.Collections.Generic.List<NUR2001U04CheckExistMedicalRecordInfo> _medical_record_info = new global::System.Collections.Generic.List<NUR2001U04CheckExistMedicalRecordInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"medical_record_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<NUR2001U04CheckExistMedicalRecordInfo> medical_record_info
    {
      get { return _medical_record_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
