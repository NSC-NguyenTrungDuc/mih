//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: adma_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ADM401UAsmItemInfo")]
  public partial class ADM401UAsmItemInfo : global::ProtoBuf.IExtensible
  {
    public ADM401UAsmItemInfo() {}
    
    private string _asm_type = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"asm_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string asm_type
    {
      get { return _asm_type; }
      set { _asm_type = value; }
    }
    private string _grp_id = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"grp_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string grp_id
    {
      get { return _grp_id; }
      set { _grp_id = value; }
    }
    private string _sys_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"sys_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_id
    {
      get { return _sys_id; }
      set { _sys_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
