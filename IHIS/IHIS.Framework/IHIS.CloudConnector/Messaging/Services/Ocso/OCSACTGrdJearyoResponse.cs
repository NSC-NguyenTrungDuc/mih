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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACTGrdJearyoResponse")]
  public partial class OCSACTGrdJearyoResponse : global::ProtoBuf.IExtensible
  {
    public OCSACTGrdJearyoResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCSACTGrdJearyoInfo> _grd_jearyo_lst = new global::System.Collections.Generic.List<OCSACTGrdJearyoInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_jearyo_lst", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCSACTGrdJearyoInfo> grd_jearyo_lst
    {
      get { return _grd_jearyo_lst; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}