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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACT2CompositeSecondRequest")]
  public partial class OCSACT2CompositeSecondRequest : global::ProtoBuf.IExtensible
  {
    public OCSACT2CompositeSecondRequest() {}
    
    private OCS2015U00GetPatientInfoRequest _get_patient_info = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"get_patient_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCS2015U00GetPatientInfoRequest get_patient_info
    {
      get { return _get_patient_info; }
      set { _get_patient_info = value; }
    }
    private NUR1016U00GrdNUR1016Request _grd_nur1016 = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"grd_nur1016", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public NUR1016U00GrdNUR1016Request grd_nur1016
    {
      get { return _grd_nur1016; }
      set { _grd_nur1016 = value; }
    }
    private NUR1017U00GrdNUR1017Request _grd_nur1017 = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"grd_nur1017", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public NUR1017U00GrdNUR1017Request grd_nur1017
    {
      get { return _grd_nur1017; }
      set { _grd_nur1017 = value; }
    }
    private OUT0106U00GridListRequest _grd_list_out0106u00 = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"grd_list_out0106u00", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OUT0106U00GridListRequest grd_list_out0106u00
    {
      get { return _grd_list_out0106u00; }
      set { _grd_list_out0106u00 = value; }
    }
    private GetPatientByCodeRequest _get_patient_bycode = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"get_patient_bycode", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public GetPatientByCodeRequest get_patient_bycode
    {
      get { return _get_patient_bycode; }
      set { _get_patient_bycode = value; }
    }
    private OcsLoadInputAndVisibleControlRequest _input_visible = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"input_visible", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OcsLoadInputAndVisibleControlRequest input_visible
    {
      get { return _input_visible; }
      set { _input_visible = value; }
    }
    private OcsLoadInputTabRequest _input_tab = null;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"input_tab", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OcsLoadInputTabRequest input_tab
    {
      get { return _input_tab; }
      set { _input_tab = value; }
    }
    private InjsINJ1001U01DetailListRequest _detail_list = null;
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"detail_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public InjsINJ1001U01DetailListRequest detail_list
    {
      get { return _detail_list; }
      set { _detail_list = value; }
    }
    private CPL2010U00CheckInjCplOrderRequest _check_inj = null;
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"check_inj", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public CPL2010U00CheckInjCplOrderRequest check_inj
    {
      get { return _check_inj; }
      set { _check_inj = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
