//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV6000U00LayINV6000Info")]
  public partial class INV6000U00LayINV6000Info : global::ProtoBuf.IExtensible
  {
    public INV6000U00LayINV6000Info() {}
    
    private string _pkinv6001 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"pkinv6001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkinv6001
    {
      get { return _pkinv6001; }
      set { _pkinv6001 = value; }
    }
    private string _magam_month = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"magam_month", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string magam_month
    {
      get { return _magam_month; }
      set { _magam_month = value; }
    }
    private string _input_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"input_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_date
    {
      get { return _input_date; }
      set { _input_date = value; }
    }
    private string _user_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"user_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_name
    {
      get { return _user_name; }
      set { _user_name = value; }
    }
    private string _remark = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"remark", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string remark
    {
      get { return _remark; }
      set { _remark = value; }
    }
    private string _process_time = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"process_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string process_time
    {
      get { return _process_time; }
      set { _process_time = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}