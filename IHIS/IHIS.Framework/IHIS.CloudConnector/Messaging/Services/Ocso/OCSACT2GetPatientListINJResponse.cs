//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
// Note: requires additional types generated from: import.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACT2GetPatientListINJResponse")]
  public partial class OCSACT2GetPatientListINJResponse : global::ProtoBuf.IExtensible
  {
    public OCSACT2GetPatientListINJResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCSACT2GetPatientListINJInfo> _pat_inj_item = new global::System.Collections.Generic.List<OCSACT2GetPatientListINJInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"pat_inj_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCSACT2GetPatientListINJInfo> pat_inj_item
    {
      get { return _pat_inj_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
