//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DrgsDRG5100P01GridPaidListRequest")]
  public partial class DrgsDRG5100P01GridPaidListRequest : global::ProtoBuf.IExtensible
  {
    public DrgsDRG5100P01GridPaidListRequest() {}
    
    private string _from_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"from_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string from_date
    {
      get { return _from_date; }
      set { _from_date = value; }
    }
    private string _to_date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"to_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string to_date
    {
      get { return _to_date; }
      set { _to_date = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _wonyoi_yn = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"wonyoi_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string wonyoi_yn
    {
      get { return _wonyoi_yn; }
      set { _wonyoi_yn = value; }
    }
    private string _gubun = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gubun
    {
      get { return _gubun; }
      set { _gubun = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private bool _xrb_order_value = default(bool);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"xrb_order_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool xrb_order_value
    {
      get { return _xrb_order_value; }
      set { _xrb_order_value = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}