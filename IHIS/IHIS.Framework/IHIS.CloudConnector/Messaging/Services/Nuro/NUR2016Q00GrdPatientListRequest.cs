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

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"NUR2016Q00GrdPatientListRequest")]
    public partial class NUR2016Q00GrdPatientListRequest : global::ProtoBuf.IExtensible
    {
        public NUR2016Q00GrdPatientListRequest() { }

        private string _bunho = "";
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string bunho
        {
            get { return _bunho; }
            set { _bunho = value; }
        }
        private string _suname = "";
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"suname", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string suname
        {
            get { return _suname; }
            set { _suname = value; }
        }
        private string _suname2 = "";
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"suname2", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string suname2
        {
            get { return _suname2; }
            set { _suname2 = value; }
        }
        private string _address = "";
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"address", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _birth = "";
        [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"birth", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string birth
        {
            get { return _birth; }
            set { _birth = value; }
        }
        private string _hosp_code_link = "";
        [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"hosp_code_link", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string hosp_code_link
        {
            get { return _hosp_code_link; }
            set { _hosp_code_link = value; }
        }
        private string _page_number = "";
        [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"page_number", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string page_number
        {
            get { return _page_number; }
            set { _page_number = value; }
        }
        private string _offset = "";
        [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"offset", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string offset
        {
            get { return _offset; }
            set { _offset = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
  
}
