//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: adma_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ADM108UGrdListItemInfo")]
  public partial class ADM108UGrdListItemInfo : global::ProtoBuf.IExtensible
  {
    public ADM108UGrdListItemInfo() {}
    
    private string _sys_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sys_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_id
    {
      get { return _sys_id; }
      set { _sys_id = value; }
    }
    private string _seq = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string seq
    {
      get { return _seq; }
      set { _seq = value; }
    }
    private string _pgm_sys_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"pgm_sys_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pgm_sys_id
    {
      get { return _pgm_sys_id; }
      set { _pgm_sys_id = value; }
    }
    private string _sys_nm = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"sys_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_nm
    {
      get { return _sys_nm; }
      set { _sys_nm = value; }
    }
    private string _pgm_id = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"pgm_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pgm_id
    {
      get { return _pgm_id; }
      set { _pgm_id = value; }
    }
    private string _pgm_nm = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"pgm_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pgm_nm
    {
      get { return _pgm_nm; }
      set { _pgm_nm = value; }
    }
    private string _data_row_state = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"data_row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string data_row_state
    {
      get { return _data_row_state; }
      set { _data_row_state = value; }
    }
    private string _new_seq = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"new_seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string new_seq
    {
      get { return _new_seq; }
      set { _new_seq = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}