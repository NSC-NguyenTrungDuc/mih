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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RES1001U00FbxHospCodeLinkResponse")]
  public partial class RES1001U00FbxHospCodeLinkResponse : global::ProtoBuf.IExtensible
  {
    public RES1001U00FbxHospCodeLinkResponse() {}
    
    private readonly global::System.Collections.Generic.List<RES1001U00FbxHospCodeLinkListItemInfo> _fbx_hosp_code_list = new global::System.Collections.Generic.List<RES1001U00FbxHospCodeLinkListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"fbx_hosp_code_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<RES1001U00FbxHospCodeLinkListItemInfo> fbx_hosp_code_list
    {
      get { return _fbx_hosp_code_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}