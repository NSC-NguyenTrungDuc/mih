//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"NuroPatientGridViewRequest")]
    public partial class NuroPatientGridViewRequest : global::ProtoBuf.IExtensible
    {
        public NuroPatientGridViewRequest() { }

        private string _patient_code = "";
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"patient_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string patient_code
        {
            get { return _patient_code; }
            set { _patient_code = value; }
        }
        private string _coming_date = "";
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"coming_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string coming_date
        {
            get { return _coming_date; }
            set { _coming_date = value; }
        }
        private bool _change_coming_date;
        [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name = @"change_coming_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public bool change_coming_date
        {
            get { return _change_coming_date; }
            set { _change_coming_date = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

}