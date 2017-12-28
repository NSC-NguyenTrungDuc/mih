namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LogoutRequest")]
    public partial class LogoutRequest : global::ProtoBuf.IExtensible
    {
        public LogoutRequest() {}
    
        private string _ticket;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ticket", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }
        private string _customer_id = "";
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"customer_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string customer_id
        {
            get { return _customer_id; }
            set { _customer_id = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}