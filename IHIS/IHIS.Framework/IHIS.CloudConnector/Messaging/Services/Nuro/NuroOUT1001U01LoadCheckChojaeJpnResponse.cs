//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroOUT1001U01LoadCheckChojaeJpnResponse")]
  public partial class NuroOUT1001U01LoadCheckChojaeJpnResponse : global::ProtoBuf.IExtensible
  {
    public NuroOUT1001U01LoadCheckChojaeJpnResponse() {}
    
    private NuroOUT1001U01LoadCheckChojaeJpnInfo _chojae_jpn_item;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"chojae_jpn_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public NuroOUT1001U01LoadCheckChojaeJpnInfo chojae_jpn_item
    {
      get { return _chojae_jpn_item; }
      set { _chojae_jpn_item = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
