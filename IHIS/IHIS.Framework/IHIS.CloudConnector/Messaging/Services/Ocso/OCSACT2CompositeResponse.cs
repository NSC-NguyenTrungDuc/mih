//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input(1).proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACT2CompositeResponse")]
  public partial class OCSACT2CompositeResponse : global::ProtoBuf.IExtensible
  {
    public OCSACT2CompositeResponse() {}
    
    private OCSACTCboTimeAndSystemResponse _cbo_time_and_sys_res = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"cbo_time_and_sys_res", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCSACTCboTimeAndSystemResponse cbo_time_and_sys_res
    {
      get { return _cbo_time_and_sys_res; }
      set { _cbo_time_and_sys_res = value; }
    }
    private ComboResponse _cbo_user_res = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"cbo_user_res", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public ComboResponse cbo_user_res
    {
      get { return _cbo_user_res; }
      set { _cbo_user_res = value; }
    }
    private OCSACT2GetGrdPaListResponse _grd_pa_list_res = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"grd_pa_list_res", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCSACT2GetGrdPaListResponse grd_pa_list_res
    {
      get { return _grd_pa_list_res; }
      set { _grd_pa_list_res = value; }
    }
    private OCSACTCboSystemSelectedIndexChangedResponse _cbo_selected_index_change_res = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"cbo_selected_index_change_res", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCSACTCboSystemSelectedIndexChangedResponse cbo_selected_index_change_res
    {
      get { return _cbo_selected_index_change_res; }
      set { _cbo_selected_index_change_res = value; }
    }
    private LayConstantInfoResponse _lay_constant_cons_res = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"lay_constant_cons_res", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public LayConstantInfoResponse lay_constant_cons_res
    {
      get { return _lay_constant_cons_res; }
      set { _lay_constant_cons_res = value; }
    }
    private LayConstantInfoResponse _lay_constant_res = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"lay_constant_res", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public LayConstantInfoResponse lay_constant_res
    {
      get { return _lay_constant_res; }
      set { _lay_constant_res = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
