//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INJ1001U01Grouped2Request")]
  public partial class INJ1001U01Grouped2Request : global::ProtoBuf.IExtensible
  {
    public INJ1001U01Grouped2Request() {}
    
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _query_date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"query_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string query_date
    {
      get { return _query_date; }
      set { _query_date = value; }
    }
    private string _order_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"order_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_date
    {
      get { return _order_date; }
      set { _order_date = value; }
    }
    private string _post_order_yn = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"post_order_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string post_order_yn
    {
      get { return _post_order_yn; }
      set { _post_order_yn = value; }
    }
    private string _pre_order_yn = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"pre_order_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pre_order_yn
    {
      get { return _pre_order_yn; }
      set { _pre_order_yn = value; }
    }
    private string _reser_date = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"reser_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_date
    {
      get { return _reser_date; }
      set { _reser_date = value; }
    }
    private string _acting_flag = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"acting_flag", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string acting_flag
    {
      get { return _acting_flag; }
      set { _acting_flag = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _acting_date = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"acting_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string acting_date
    {
      get { return _acting_date; }
      set { _acting_date = value; }
    }
    private string _commt_gubun = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"commt_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string commt_gubun
    {
      get { return _commt_gubun; }
      set { _commt_gubun = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
