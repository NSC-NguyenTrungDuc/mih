//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ocsa_service.proto
// Note: requires additional types generated from: system_model.proto
// Note: requires additional types generated from: ocsa_model.proto
// Note: requires additional types generated from: ocs.lib_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U19InitializeScreenResponse")]
  public partial class OCS0103U19InitializeScreenResponse : global::ProtoBuf.IExtensible
  {
    public OCS0103U19InitializeScreenResponse() {}
    
    private string _sys_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sys_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_date
    {
      get { return _sys_date; }
      set { _sys_date = value; }
    }
    private string _code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code
    {
      get { return _code; }
      set { _code = value; }
    }
    private string _user_option = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_option
    {
      get { return _user_option; }
      set { _user_option = value; }
    }
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _order_gubun_info = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(4, Name=@"order_gubun_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> order_gubun_info
    {
      get { return _order_gubun_info; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _suryang_info = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(5, Name=@"suryang_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> suryang_info
    {
      get { return _suryang_info; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _nalsu_info = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(6, Name=@"nalsu_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> nalsu_info
    {
      get { return _nalsu_info; }
    }
  
    private readonly global::System.Collections.Generic.List<LoadOftenUsedTabResponseInfo> _used_tab_info = new global::System.Collections.Generic.List<LoadOftenUsedTabResponseInfo>();
    [global::ProtoBuf.ProtoMember(7, Name=@"used_tab_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<LoadOftenUsedTabResponseInfo> used_tab_info
    {
      get { return _used_tab_info; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _lay_hangwi_gubun_info = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(8, Name=@"lay_hangwi_gubun_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> lay_hangwi_gubun_info
    {
      get { return _lay_hangwi_gubun_info; }
    }
  
    private readonly global::System.Collections.Generic.List<OCS0103U19TvwJaeryoGubunInfo> _tvw_jaeryo_gubun_info = new global::System.Collections.Generic.List<OCS0103U19TvwJaeryoGubunInfo>();
    [global::ProtoBuf.ProtoMember(9, Name=@"tvw_jaeryo_gubun_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS0103U19TvwJaeryoGubunInfo> tvw_jaeryo_gubun_info
    {
      get { return _tvw_jaeryo_gubun_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
