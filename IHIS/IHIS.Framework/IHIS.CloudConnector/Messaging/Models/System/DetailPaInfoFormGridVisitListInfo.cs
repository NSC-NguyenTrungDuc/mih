//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: DetailPaInfoForm.proto
namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"DetailPaInfoFormGridVisitListInfo")]
    public partial class DetailPaInfoFormGridVisitListInfo : global::ProtoBuf.IExtensible
    {
        public DetailPaInfoFormGridVisitListInfo() { }

        private string _coming_date = "";
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"coming_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string coming_date
        {
            get { return _coming_date; }
            set { _coming_date = value; }
        }
        private string _department_name = "";
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"department_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string department_name
        {
            get { return _department_name; }
            set { _department_name = value; }
        }
        private string _type_name = "";
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"type_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string type_name
        {
            get { return _type_name; }
            set { _type_name = value; }
        }
        private string _doctor_name = "";
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string doctor_name
        {
            get { return _doctor_name; }
            set { _doctor_name = value; }
        }
        private string _out_date = "";
        [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"out_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string out_date
        {
            get { return _out_date; }
            set { _out_date = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
