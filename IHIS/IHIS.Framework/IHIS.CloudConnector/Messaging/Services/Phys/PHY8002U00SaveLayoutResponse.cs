//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: phys_service.proto
// Note: requires additional types generated from: phys_model.proto
// Note: requires additional types generated from: system_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PHY8002U00SaveLayoutResponse")]
  public partial class PHY8002U00SaveLayoutResponse : global::ProtoBuf.IExtensible
  {
    public PHY8002U00SaveLayoutResponse() {}
    
    private bool _result_8002 = default(bool);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"result_8002", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool result_8002
    {
      get { return _result_8002; }
      set { _result_8002 = value; }
    }
    private bool _result_8003 = default(bool);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"result_8003", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool result_8003
    {
      get { return _result_8003; }
      set { _result_8003 = value; }
    }
    private bool _result_8004 = default(bool);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"result_8004", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool result_8004
    {
      get { return _result_8004; }
      set { _result_8004 = value; }
    }
    private string _pk_phy8002 = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"pk_phy8002", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pk_phy8002
    {
      get { return _pk_phy8002; }
      set { _pk_phy8002 = value; }
    }
    private string _msg_case3 = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"msg_case3", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string msg_case3
    {
      get { return _msg_case3; }
      set { _msg_case3 = value; }
    }
    private readonly global::System.Collections.Generic.List<PHY8002U00GrdPHY8002Info> _setPHY8002Info = new global::System.Collections.Generic.List<PHY8002U00GrdPHY8002Info>();
    [global::ProtoBuf.ProtoMember(6, Name=@"setPHY8002Info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PHY8002U00GrdPHY8002Info> setPHY8002Info
    {
      get { return _setPHY8002Info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}