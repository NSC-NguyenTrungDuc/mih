//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U14FirstOpenScreenRequest")]
  public partial class OCS0103U14FirstOpenScreenRequest : global::ProtoBuf.IExtensible
  {
    public OCS0103U14FirstOpenScreenRequest() {}
    
    private OCS0103U14FormLoadRequest _form_load_rq = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"form_load_rq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS0103U14FormLoadRequest form_load_rq
    {
      get { return _form_load_rq; }
      set { _form_load_rq = value; }
    }
    private OCS0103U13GrdSangyongOrderListRequest _sangyong_rq = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"sangyong_rq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS0103U13GrdSangyongOrderListRequest sangyong_rq
    {
      get { return _sangyong_rq; }
      set { _sangyong_rq = value; }
    }
    private OCS0103U14LaySlipCodeTreeRequest _lay_slipcode_rq = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"lay_slipcode_rq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS0103U14LaySlipCodeTreeRequest lay_slipcode_rq
    {
      get { return _lay_slipcode_rq; }
      set { _lay_slipcode_rq = value; }
    }
    private OCS0103U14GrdSlipHangmogRequest _grd_sliphangmog_rq = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"grd_sliphangmog_rq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS0103U14GrdSlipHangmogRequest grd_sliphangmog_rq
    {
      get { return _grd_sliphangmog_rq; }
      set { _grd_sliphangmog_rq = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
