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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0001U00ControlDataValidatingRequest")]
  public partial class BAS0001U00ControlDataValidatingRequest : global::ProtoBuf.IExtensible
  {
    public BAS0001U00ControlDataValidatingRequest() {}
    
    private string _zip_code1 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"zip_code1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string zip_code1
    {
      get { return _zip_code1; }
      set { _zip_code1 = value; }
    }
    private string _zip_code2 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"zip_code2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string zip_code2
    {
      get { return _zip_code2; }
      set { _zip_code2 = value; }
    }
    private string _ctl_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"ctl_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ctl_name
    {
      get { return _ctl_name; }
      set { _ctl_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
