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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroChkGetWonyoiYnRequest")]
  public partial class NuroChkGetWonyoiYnRequest : global::ProtoBuf.IExtensible
  {
    public NuroChkGetWonyoiYnRequest() {}
    
    private string _gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gubun
    {
      get { return _gubun; }
      set { _gubun = value; }
    }
    private string _gongbi_code1 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"gongbi_code1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_code1
    {
      get { return _gongbi_code1; }
      set { _gongbi_code1 = value; }
    }
    private string _gongbi_code2 = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"gongbi_code2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_code2
    {
      get { return _gongbi_code2; }
      set { _gongbi_code2 = value; }
    }
    private string _gongbi_code3 = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"gongbi_code3", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_code3
    {
      get { return _gongbi_code3; }
      set { _gongbi_code3 = value; }
    }
    private string _gongbi_code4 = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"gongbi_code4", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_code4
    {
      get { return _gongbi_code4; }
      set { _gongbi_code4 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
