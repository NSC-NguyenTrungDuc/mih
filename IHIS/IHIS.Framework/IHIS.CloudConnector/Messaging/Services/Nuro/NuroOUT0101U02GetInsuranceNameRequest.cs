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

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"NuroOUT0101U02GetInsuranceNameRequest")]
    public partial class NuroOUT0101U02GetInsuranceNameRequest : global::ProtoBuf.IExtensible
    {
        public NuroOUT0101U02GetInsuranceNameRequest() { }

        private string _gongbi_code = "";
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"gongbi_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string gongbi_code
        {
            get { return _gongbi_code; }
            set { _gongbi_code = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

}
