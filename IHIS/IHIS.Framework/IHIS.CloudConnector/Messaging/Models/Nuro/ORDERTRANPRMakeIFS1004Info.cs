//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ORDERTRANPRMakeIFS1004Info")]
  public partial class ORDERTRANPRMakeIFS1004Info : global::ProtoBuf.IExtensible
  {
    public ORDERTRANPRMakeIFS1004Info() {}
    
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _io_gubun = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"io_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string io_gubun
    {
      get { return _io_gubun; }
      set { _io_gubun = value; }
    }
    private string _pkout1003 = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"pkout1003", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkout1003
    {
      get { return _pkout1003; }
      set { _pkout1003 = value; }
    }
    private string _trans_yn = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"trans_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string trans_yn
    {
      get { return _trans_yn; }
      set { _trans_yn = value; }
    }
    private string _trans_gubun = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"trans_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string trans_gubun
    {
      get { return _trans_gubun; }
      set { _trans_gubun = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
