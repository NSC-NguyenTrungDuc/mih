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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACT2GetPatientListCPLResponse")]
  public partial class OCSACT2GetPatientListCPLResponse : global::ProtoBuf.IExtensible
  {
    public OCSACT2GetPatientListCPLResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCSACT2GetPatientListCPLInfo> _pat_cpl_item = new global::System.Collections.Generic.List<OCSACT2GetPatientListCPLInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"pat_cpl_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCSACT2GetPatientListCPLInfo> pat_cpl_item
    {
      get { return _pat_cpl_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}