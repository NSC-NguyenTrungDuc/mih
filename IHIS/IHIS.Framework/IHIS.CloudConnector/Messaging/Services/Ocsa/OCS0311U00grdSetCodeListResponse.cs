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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0311U00grdSetCodeListResponse")]
  public partial class OCS0311U00grdSetCodeListResponse : global::ProtoBuf.IExtensible
  {
    public OCS0311U00grdSetCodeListResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS0311U00grdSetCodeListInfo> _grd_set_code = new global::System.Collections.Generic.List<OCS0311U00grdSetCodeListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_set_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS0311U00grdSetCodeListInfo> grd_set_code
    {
      get { return _grd_set_code; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}