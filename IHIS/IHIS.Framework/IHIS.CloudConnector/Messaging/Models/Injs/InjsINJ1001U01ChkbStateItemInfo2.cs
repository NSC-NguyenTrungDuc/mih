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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"InjsINJ1001U01ChkbStateItemInfo2")]
  public partial class InjsINJ1001U01ChkbStateItemInfo2 : global::ProtoBuf.IExtensible
  {
    public InjsINJ1001U01ChkbStateItemInfo2() {}
    
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _result = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string result
    {
      get { return _result; }
      set { _result = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
