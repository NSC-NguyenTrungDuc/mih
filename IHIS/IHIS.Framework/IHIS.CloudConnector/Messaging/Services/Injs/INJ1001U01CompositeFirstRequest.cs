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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INJ1001U01CompositeFirstRequest")]
  public partial class INJ1001U01CompositeFirstRequest : global::ProtoBuf.IExtensible
  {
    public INJ1001U01CompositeFirstRequest() {}
    
    private INJ1001U01CboTimeRequest _cbo_time_param = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"cbo_time_param", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public INJ1001U01CboTimeRequest cbo_time_param
    {
      get { return _cbo_time_param; }
      set { _cbo_time_param = value; }
    }
    private InjsINJ1001U01MasterListRequest _grd_master_param = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"grd_master_param", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public InjsINJ1001U01MasterListRequest grd_master_param
    {
      get { return _grd_master_param; }
      set { _grd_master_param = value; }
    }
    private GetPatientByCodeRequest _patient_info = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"patient_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public GetPatientByCodeRequest patient_info
    {
      get { return _patient_info; }
      set { _patient_info = value; }
    }
    private InjsINJ1001U01CplOrderStatusRequest _order_status = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"order_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public InjsINJ1001U01CplOrderStatusRequest order_status
    {
      get { return _order_status; }
      set { _order_status = value; }
    }
    private INJ1001U01MlayConstantInfoRequest _constant_info = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"constant_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public INJ1001U01MlayConstantInfoRequest constant_info
    {
      get { return _constant_info; }
      set { _constant_info = value; }
    }
    private InjsINJ1001U01ScheduleRequest _schedule = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"schedule", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public InjsINJ1001U01ScheduleRequest schedule
    {
      get { return _schedule; }
      set { _schedule = value; }
    }
    private InjsINJ1001U01DetailListRequest _detailt_list = null;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"detailt_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public InjsINJ1001U01DetailListRequest detailt_list
    {
      get { return _detailt_list; }
      set { _detailt_list = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}