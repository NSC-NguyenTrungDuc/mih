//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BIL2016R01GrdReportResponse")]
  public partial class BIL2016R01GrdReportResponse : global::ProtoBuf.IExtensible
  {
    public BIL2016R01GrdReportResponse() {}
    
    private readonly global::System.Collections.Generic.List<BIL2016R01GrdReportInfo> _grd_list = new global::System.Collections.Generic.List<BIL2016R01GrdReportInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<BIL2016R01GrdReportInfo> grd_list
    {
      get { return _grd_list; }
    }
  
    private string _sum_discount = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"sum_discount", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sum_discount
    {
      get { return _sum_discount; }
      set { _sum_discount = value; }
    }

    private string _sum_amount_paid = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"sum_amount_paid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sum_amount_paid
    {
        get { return _sum_amount_paid; }
        set { _sum_amount_paid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
