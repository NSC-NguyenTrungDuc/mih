//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: system_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FormScreenInfo")]
  public partial class FormScreenInfo : global::ProtoBuf.IExtensible
  {
    public FormScreenInfo() {}
    
    private string _sys_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sys_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_id
    {
      get { return _sys_id; }
      set { _sys_id = value; }
    }
    private string _pgm_nm = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"pgm_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pgm_nm
    {
      get { return _pgm_nm; }
      set { _pgm_nm = value; }
    }
    private string _pgm_ent_grad = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"pgm_ent_grad", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pgm_ent_grad
    {
      get { return _pgm_ent_grad; }
      set { _pgm_ent_grad = value; }
    }
    private string _pgm_upd_grad = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"pgm_upd_grad", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pgm_upd_grad
    {
      get { return _pgm_upd_grad; }
      set { _pgm_upd_grad = value; }
    }
    private string _pgm_scrt = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"pgm_scrt", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pgm_scrt
    {
      get { return _pgm_scrt; }
      set { _pgm_scrt = value; }
    }
    private string _pgm_dup_yn = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"pgm_dup_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pgm_dup_yn
    {
      get { return _pgm_dup_yn; }
      set { _pgm_dup_yn = value; }
    }
    private string _asm_name = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"asm_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string asm_name
    {
      get { return _asm_name; }
      set { _asm_name = value; }
    }
    private string _asm_path = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"asm_path", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string asm_path
    {
      get { return _asm_path; }
      set { _asm_path = value; }
    }
    private string _asm_ver = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"asm_ver", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string asm_ver
    {
      get { return _asm_ver; }
      set { _asm_ver = value; }
    }
    private string _grp_id = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"grp_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string grp_id
    {
      get { return _grp_id; }
      set { _grp_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
