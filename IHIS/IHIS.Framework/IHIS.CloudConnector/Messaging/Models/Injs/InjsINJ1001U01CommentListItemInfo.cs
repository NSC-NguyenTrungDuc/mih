//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"InjsINJ1001U01CommentListItemInfo")]
  public partial class InjsINJ1001U01CommentListItemInfo : global::ProtoBuf.IExtensible
  {
    public InjsINJ1001U01CommentListItemInfo() {}
    
    private string _comment = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"comment", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string comment
    {
      get { return _comment; }
      set { _comment = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
