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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT1002U00DsvXrayGubunResponse")]
  public partial class XRT1002U00DsvXrayGubunResponse : global::ProtoBuf.IExtensible
  {
    public XRT1002U00DsvXrayGubunResponse() {}
    
    private readonly global::System.Collections.Generic.List<XRT1002U00DsvXrayGubunInfo> _xray_gubun_item = new global::System.Collections.Generic.List<XRT1002U00DsvXrayGubunInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"xray_gubun_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<XRT1002U00DsvXrayGubunInfo> xray_gubun_item
    {
      get { return _xray_gubun_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}