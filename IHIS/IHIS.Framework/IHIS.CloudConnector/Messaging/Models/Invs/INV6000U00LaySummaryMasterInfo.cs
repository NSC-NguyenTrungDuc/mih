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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV6000U00LaySummaryMasterInfo")]
  public partial class INV6000U00LaySummaryMasterInfo : global::ProtoBuf.IExtensible
  {
    public INV6000U00LaySummaryMasterInfo() {}
    
    private string _slip_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"slip_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string slip_code
    {
      get { return _slip_code; }
      set { _slip_code = value; }
    }
    private string _slip_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"slip_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string slip_name
    {
      get { return _slip_name; }
      set { _slip_name = value; }
    }
    private string _drg_count = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"drg_count", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string drg_count
    {
      get { return _drg_count; }
      set { _drg_count = value; }
    }
    private string _sougaku = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"sougaku", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sougaku
    {
      get { return _sougaku; }
      set { _sougaku = value; }
    }
    private string _magam_date = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"magam_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string magam_date
    {
      get { return _magam_date; }
      set { _magam_date = value; }
    }
    private string _magam_month_jp = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"magam_month_jp", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string magam_month_jp
    {
      get { return _magam_month_jp; }
      set { _magam_month_jp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
