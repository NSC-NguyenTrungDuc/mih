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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NUR2016Q00GrdPatientListResponse")]
  public partial class NUR2016Q00GrdPatientListResponse : global::ProtoBuf.IExtensible
  {
    public NUR2016Q00GrdPatientListResponse() {}
    
    private readonly global::System.Collections.Generic.List<NUR2016Q00GrdPatientListInfo> _grd_pat_list_item = new global::System.Collections.Generic.List<NUR2016Q00GrdPatientListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_pat_list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<NUR2016Q00GrdPatientListInfo> grd_pat_list_item
    {
      get { return _grd_pat_list_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
