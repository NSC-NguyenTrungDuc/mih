//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"LoadGridPayHistoryBIL2016U02Info")]
    public partial class LoadGridPayHistoryBIL2016U02Info : global::ProtoBuf.IExtensible
    {
        public LoadGridPayHistoryBIL2016U02Info() { }

        private string _invoice_no = "";
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"invoice_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string invoice_no
        {
            get { return _invoice_no; }
            set { _invoice_no = value; }
        }
        private string _invoice_date = "";
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"invoice_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string invoice_date
        {
            get { return _invoice_date; }
            set { _invoice_date = value; }
        }
        private string _amount = "";
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"amount", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private string _discount = "";
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"discount", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        private string _amount_paid = "";
        [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"amount_paid", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string amount_paid
        {
            get { return _amount_paid; }
            set { _amount_paid = value; }
        }
        private string _parent_invoice_no = "";
        [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"parent_invoice_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string parent_invoice_no
        {
            get { return _parent_invoice_no; }
            set { _parent_invoice_no = value; }
        }
        private string _active_flg = "";
        [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"active_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string active_flg
        {
            get { return _active_flg; }
            set { _active_flg = value; }
        }
        private string _amount_debt = "";
        [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"amount_debt", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string amount_debt
        {
            get { return _amount_debt; }
            set { _amount_debt = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

}
