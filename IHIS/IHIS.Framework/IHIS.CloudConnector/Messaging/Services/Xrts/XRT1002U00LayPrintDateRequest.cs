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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT1002U00LayPrintDateRequest")]
  public partial class XRT1002U00LayPrintDateRequest : global::ProtoBuf.IExtensible
  {
    public XRT1002U00LayPrintDateRequest() {}
    
    private string _order_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"order_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_date
    {
      get { return _order_date; }
      set { _order_date = value; }
    }
    private string _in_out_gubun = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"in_out_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string in_out_gubun
    {
      get { return _in_out_gubun; }
      set { _in_out_gubun = value; }
    }
    private string _fkout1001 = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"fkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkout1001
    {
      get { return _fkout1001; }
      set { _fkout1001 = value; }
    }
    private string _print_only = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"print_only", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string print_only
    {
      get { return _print_only; }
      set { _print_only = value; }
    }
    private string _jundal_part = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"jundal_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_part
    {
      get { return _jundal_part; }
      set { _jundal_part = value; }
    }
    private string _pkocs = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"pkocs", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkocs
    {
      get { return _pkocs; }
      set { _pkocs = value; }
    }
    private string _fkinp1001 = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"fkinp1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkinp1001
    {
      get { return _fkinp1001; }
      set { _fkinp1001 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
