//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
// Note: requires additional types generated from: import.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACTProcEkgInterfaceRequest")]
  public partial class OCSACTProcEkgInterfaceRequest : global::ProtoBuf.IExtensible
  {
    public OCSACTProcEkgInterfaceRequest() {}
    
    private string _order_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"order_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_date
    {
      get { return _order_date; }
      set { _order_date = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _fkout1001 = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"fkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkout1001
    {
      get { return _fkout1001; }
      set { _fkout1001 = value; }
    }
    private string _pkocs = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"pkocs", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkocs
    {
      get { return _pkocs; }
      set { _pkocs = value; }
    }
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _io_gubun = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"io_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string io_gubun
    {
      get { return _io_gubun; }
      set { _io_gubun = value; }
    }
    private string _send_yn = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"send_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string send_yn
    {
      get { return _send_yn; }
      set { _send_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
