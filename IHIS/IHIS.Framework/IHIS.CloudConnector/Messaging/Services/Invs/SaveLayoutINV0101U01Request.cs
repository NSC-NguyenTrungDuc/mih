//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SaveLayoutINV0101U01Request")]
  public partial class SaveLayoutINV0101U01Request : global::ProtoBuf.IExtensible
  {
    public SaveLayoutINV0101U01Request() {}
    
    private readonly global::System.Collections.Generic.List<INV0101U01GridMasterInfo> _list_master = new global::System.Collections.Generic.List<INV0101U01GridMasterInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"list_master", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INV0101U01GridMasterInfo> list_master
    {
      get { return _list_master; }
    }
  
    private readonly global::System.Collections.Generic.List<INV0101U01GridDetailInfo> _list_detail = new global::System.Collections.Generic.List<INV0101U01GridDetailInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"list_detail", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INV0101U01GridDetailInfo> list_detail
    {
      get { return _list_detail; }
    }
  
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}