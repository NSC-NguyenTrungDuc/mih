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

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"INJ1001U01CompositeSecondRequest")]
    public partial class INJ1001U01CompositeSecondRequest : global::ProtoBuf.IExtensible
    {
        public INJ1001U01CompositeSecondRequest() { }

        private InjsINJ1001U01DetailListRequest _grd_detail = null;
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"grd_detail", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public InjsINJ1001U01DetailListRequest grd_detail
        {
            get { return _grd_detail; }
            set { _grd_detail = value; }
        }
        private INJ1001U01GrdSangRequest _grd_sang = null;
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"grd_sang", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public INJ1001U01GrdSangRequest grd_sang
        {
            get { return _grd_sang; }
            set { _grd_sang = value; }
        }
        private InjsINJ1001U01CplOrderStatusRequest _cpl_order = null;
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"cpl_order", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public InjsINJ1001U01CplOrderStatusRequest cpl_order
        {
            get { return _cpl_order; }
            set { _cpl_order = value; }
        }
        private INJ1001U01Grouped2Request _grouped = null;
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"grouped", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public INJ1001U01Grouped2Request grouped
        {
            get { return _grouped; }
            set { _grouped = value; }
        }
        private InjsINJ1001U01AllergyListRequest _allergy = null;
        [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"allergy", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public InjsINJ1001U01AllergyListRequest allergy
        {
            get { return _allergy; }
            set { _allergy = value; }
        }
        private InjsINJ1001U01ReserDateListRequest _reser_date = null;
        [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"reser_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public InjsINJ1001U01ReserDateListRequest reser_date
        {
            get { return _reser_date; }
            set { _reser_date = value; }
        }
        private readonly global::System.Collections.Generic.List<InjsINJ1001U01ChkbStateRequest> _chkb_state = new global::System.Collections.Generic.List<InjsINJ1001U01ChkbStateRequest>();
        [global::ProtoBuf.ProtoMember(7, Name = @"chkb_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<InjsINJ1001U01ChkbStateRequest> chkb_state
        {
            get { return _chkb_state; }
        }

        private GetPatientByCodeRequest _patient_info = null;
        [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"patient_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public GetPatientByCodeRequest patient_info
        {
            get { return _patient_info; }
            set { _patient_info = value; }
        }
        private InjsINJ1001U01ScheduleRequest _schedule = null;
        [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name = @"schedule", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public InjsINJ1001U01ScheduleRequest schedule
        {
            get { return _schedule; }
            set { _schedule = value; }
        }
        private INJ1001U01MlayConstantInfoRequest _cons_info = null;
        [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name = @"cons_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public INJ1001U01MlayConstantInfoRequest cons_info
        {
            get { return _cons_info; }
            set { _cons_info = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
  
}