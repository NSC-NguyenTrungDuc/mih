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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV2003U00GrdINV2004Info")]
  public partial class INV2003U00GrdINV2004Info : global::ProtoBuf.IExtensible
  {
    public INV2003U00GrdINV2004Info() {}
    
    private string _pkinv2004 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"pkinv2004", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkinv2004
    {
      get { return _pkinv2004; }
      set { _pkinv2004 = value; }
    }
    private string _fkinv2003 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"fkinv2003", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkinv2003
    {
      get { return _fkinv2003; }
      set { _fkinv2003 = value; }
    }
    private string _jaeryo_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"jaeryo_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jaeryo_code
    {
      get { return _jaeryo_code; }
      set { _jaeryo_code = value; }
    }
    private string _jaeryo_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"jaeryo_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jaeryo_name
    {
      get { return _jaeryo_name; }
      set { _jaeryo_name = value; }
    }
    private string _chulgo_qty = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"chulgo_qty", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string chulgo_qty
    {
      get { return _chulgo_qty; }
      set { _chulgo_qty = value; }
    }
    private string _chulgo_danui_name = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"chulgo_danui_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string chulgo_danui_name
    {
      get { return _chulgo_danui_name; }
      set { _chulgo_danui_name = value; }
    }
    private string _chulgo_danga = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"chulgo_danga", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string chulgo_danga
    {
      get { return _chulgo_danga; }
      set { _chulgo_danga = value; }
    }
    private string _remark = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"remark", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string remark
    {
      get { return _remark; }
      set { _remark = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string row_state
    {
      get { return _row_state; }
      set { _row_state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}