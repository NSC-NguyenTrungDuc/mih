//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: model.proto
namespace IHIS.CloudConnector.Messaging
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U13LaySpecimenTreeListInfo")]
  public partial class OCS0103U13LaySpecimenTreeListInfo : global::ProtoBuf.IExtensible
  {
    public OCS0103U13LaySpecimenTreeListInfo() {}
    
    private string _slip_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"slip_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string slip_gubun
    {
      get { return _slip_gubun; }
      set { _slip_gubun = value; }
    }
    private string _slip_gubun_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"slip_gubun_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string slip_gubun_name
    {
      get { return _slip_gubun_name; }
      set { _slip_gubun_name = value; }
    }
    private string _slip_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"slip_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string slip_code
    {
      get { return _slip_code; }
      set { _slip_code = value; }
    }
    private string _slip_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"slip_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string slip_name
    {
      get { return _slip_name; }
      set { _slip_name = value; }
    }
    private string _cpl_code_yn = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"cpl_code_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cpl_code_yn
    {
      get { return _cpl_code_yn; }
      set { _cpl_code_yn = value; }
    }
    private string _zero = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"zero", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string zero
    {
      get { return _zero; }
      set { _zero = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}