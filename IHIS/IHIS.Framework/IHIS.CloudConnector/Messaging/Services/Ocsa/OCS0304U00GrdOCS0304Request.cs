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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0304U00GrdOCS0304Request")]
  public partial class OCS0304U00GrdOCS0304Request : global::ProtoBuf.IExtensible
  {
    public OCS0304U00GrdOCS0304Request() {}
    
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _memb_gubun = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"memb_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string memb_gubun
    {
      get { return _memb_gubun; }
      set { _memb_gubun = value; }
    }
    private string _yaksok_direct_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"yaksok_direct_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yaksok_direct_code
    {
      get { return _yaksok_direct_code; }
      set { _yaksok_direct_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
