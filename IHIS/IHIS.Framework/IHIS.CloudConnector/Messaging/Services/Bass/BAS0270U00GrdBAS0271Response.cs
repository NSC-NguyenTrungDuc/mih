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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0270U00GrdBAS0271Response")]
  public partial class BAS0270U00GrdBAS0271Response : global::ProtoBuf.IExtensible
  {
    public BAS0270U00GrdBAS0271Response() {}
    
    private readonly global::System.Collections.Generic.List<BAS0270U00GrdBAS0271Info> _grdBAS0271 = new global::System.Collections.Generic.List<BAS0270U00GrdBAS0271Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grdBAS0271", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<BAS0270U00GrdBAS0271Info> grdBAS0271
    {
      get { return _grdBAS0271; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
