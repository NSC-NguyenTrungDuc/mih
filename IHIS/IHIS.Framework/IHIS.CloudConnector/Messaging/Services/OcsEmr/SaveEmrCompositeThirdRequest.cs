using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"SaveEmrCompositeThirdRequest")]
    public partial class SaveEmrCompositeThirdRequest : global::ProtoBuf.IExtensible
    {
        public SaveEmrCompositeThirdRequest() { }

        private OCS2015U09EmrRecordUpdateRequest _emr_record_update = null;
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"emr_record_update", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U09EmrRecordUpdateRequest emr_record_update
        {
            get { return _emr_record_update; }
            set { _emr_record_update = value; }
        }
        private OCS2015U06EmrRecordRequest _emr_record = null;
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"emr_record", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U06EmrRecordRequest emr_record
        {
            get { return _emr_record; }
            set { _emr_record = value; }
        }
        private OCS0103U12GrdSangyongOrderRequest _grd_sangyong_order = null;
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"grd_sangyong_order", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS0103U12GrdSangyongOrderRequest grd_sangyong_order
        {
            get { return _grd_sangyong_order; }
            set { _grd_sangyong_order = value; }
        }
        private OCS0103U10FormLoadRequest _u10_form_load = null;
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"u10_form_load", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS0103U10FormLoadRequest u10_form_load
        {
            get { return _u10_form_load; }
            set { _u10_form_load = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
