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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DrgsDRG5100P01ProcAtcInterfaceResponse")]
  public partial class DrgsDRG5100P01ProcAtcInterfaceResponse : global::ProtoBuf.IExtensible
  {
    public DrgsDRG5100P01ProcAtcInterfaceResponse() {}
    
    private string _pkdrg4010 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"pkdrg4010", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkdrg4010
    {
      get { return _pkdrg4010; }
      set { _pkdrg4010 = value; }
    }
    private string _rtnIfsCnt = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"rtnIfsCnt", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string rtnIfsCnt
    {
      get { return _rtnIfsCnt; }
      set { _rtnIfsCnt = value; }
    }
    private bool _proc_atc_interface = default(bool);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"proc_atc_interface", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool proc_atc_interface
    {
      get { return _proc_atc_interface; }
      set { _proc_atc_interface = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}