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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0270U00LayGwaResponse")]
  public partial class BAS0270U00LayGwaResponse : global::ProtoBuf.IExtensible
  {
    public BAS0270U00LayGwaResponse() {}
    
    private readonly global::System.Collections.Generic.List<DataStringListItemInfo> _gwa_name = new global::System.Collections.Generic.List<DataStringListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<DataStringListItemInfo> gwa_name
    {
      get { return _gwa_name; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
