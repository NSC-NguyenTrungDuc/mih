//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroOUT1001U01LayoutBarCodeInfo")]
  public partial class NuroOUT1001U01LayoutBarCodeInfo : global::ProtoBuf.IExtensible
  {
    public NuroOUT1001U01LayoutBarCodeInfo() {}
    
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _suname = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"suname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suname
    {
      get { return _suname; }
      set { _suname = value; }
    }
    private string _sex = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"sex", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sex
    {
      get { return _sex; }
      set { _sex = value; }
    }
    private string _bunho2 = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"bunho2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho2
    {
      get { return _bunho2; }
      set { _bunho2 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
