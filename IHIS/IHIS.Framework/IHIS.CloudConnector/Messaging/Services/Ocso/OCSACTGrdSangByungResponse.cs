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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACTGrdSangByungResponse")]
  public partial class OCSACTGrdSangByungResponse : global::ProtoBuf.IExtensible
  {
    public OCSACTGrdSangByungResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCSACTGrdSangByungInfo> _grd_sang_byung_lst = new global::System.Collections.Generic.List<OCSACTGrdSangByungInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_sang_byung_lst", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCSACTGrdSangByungInfo> grd_sang_byung_lst
    {
      get { return _grd_sang_byung_lst; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}