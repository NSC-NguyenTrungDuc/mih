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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RES1001R00PrintBookingResponse")]
  public partial class RES1001R00PrintBookingResponse : global::ProtoBuf.IExtensible
  {
    public RES1001R00PrintBookingResponse() {}
    
    private string _yoyang_name_link = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"yoyang_name_link", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yoyang_name_link
    {
      get { return _yoyang_name_link; }
      set { _yoyang_name_link = value; }
    }
    private string _suname = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"suname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suname
    {
      get { return _suname; }
      set { _suname = value; }
    }
    private string _birth = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"birth", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string birth
    {
      get { return _birth; }
      set { _birth = value; }
    }
    private string _age = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"age", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string age
    {
      get { return _age; }
      set { _age = value; }
    }
    private string _yoyang_name = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"yoyang_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yoyang_name
    {
      get { return _yoyang_name; }
      set { _yoyang_name = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _bunho_link = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"bunho_link", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho_link
    {
      get { return _bunho_link; }
      set { _bunho_link = value; }
    }
    private string _gwa_name = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa_name
    {
      get { return _gwa_name; }
      set { _gwa_name = value; }
    }
    private string _doctor_name = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_name
    {
      get { return _doctor_name; }
      set { _doctor_name = value; }
    }
    private string _naewon_date = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"naewon_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_date
    {
      get { return _naewon_date; }
      set { _naewon_date = value; }
    }
    private string _jubsu_time = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"jubsu_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jubsu_time
    {
      get { return _jubsu_time; }
      set { _jubsu_time = value; }
    }
    private string _address = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"address", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string address
    {
      get { return _address; }
      set { _address = value; }
    }
    private string _tel = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"tel", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tel
    {
      get { return _tel; }
      set { _tel = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
