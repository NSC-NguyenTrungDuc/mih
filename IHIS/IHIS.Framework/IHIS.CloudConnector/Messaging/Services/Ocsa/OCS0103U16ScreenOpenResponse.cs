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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U16ScreenOpenResponse")]
  public partial class OCS0103U16ScreenOpenResponse : global::ProtoBuf.IExtensible
  {
    public OCS0103U16ScreenOpenResponse() {}
    
    private OCS0103U13CboListResponse _cbo_lst_res_item = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"cbo_lst_res_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS0103U13CboListResponse cbo_lst_res_item
    {
      get { return _cbo_lst_res_item; }
      set { _cbo_lst_res_item = value; }
    }
    private OCS0103U14FormLoadResponse _form_load_res_item = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"form_load_res_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS0103U14FormLoadResponse form_load_res_item
    {
      get { return _form_load_res_item; }
      set { _form_load_res_item = value; }
    }
    private readonly global::System.Collections.Generic.List<LoadSearchOrder2Response> _load_search_order2_res_item = new global::System.Collections.Generic.List<LoadSearchOrder2Response>();
    [global::ProtoBuf.ProtoMember(3, Name=@"load_search_order2_res_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<LoadSearchOrder2Response> load_search_order2_res_item
    {
      get { return _load_search_order2_res_item; }
    }
  
    private OCS0103U16GrdSangyongOrderResponse _grd_sangyong_order_res_item = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"grd_sangyong_order_res_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS0103U16GrdSangyongOrderResponse grd_sangyong_order_res_item
    {
      get { return _grd_sangyong_order_res_item; }
      set { _grd_sangyong_order_res_item = value; }
    }
    private OCS0103U16SlipCodeTreeResponse _slip_code_res_item = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"slip_code_res_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS0103U16SlipCodeTreeResponse slip_code_res_item
    {
      get { return _slip_code_res_item; }
      set { _slip_code_res_item = value; }
    }
    private GetNextGroupSerResponse _next_groupser_res_item = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"next_groupser_res_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public GetNextGroupSerResponse next_groupser_res_item
    {
      get { return _next_groupser_res_item; }
      set { _next_groupser_res_item = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}