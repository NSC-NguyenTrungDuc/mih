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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INJ1002R01LayQueryResponse")]
  public partial class INJ1002R01LayQueryResponse : global::ProtoBuf.IExtensible
  {
    public INJ1002R01LayQueryResponse() {}
    
    private readonly global::System.Collections.Generic.List<INJ1002R01LayQueryListItemInfo> _lay_querry_list = new global::System.Collections.Generic.List<INJ1002R01LayQueryListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"lay_querry_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INJ1002R01LayQueryListItemInfo> lay_querry_list
    {
      get { return _lay_querry_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
