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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL2010R01LaySpecimenListItemInfo")]
  public partial class CPL2010R01LaySpecimenListItemInfo : global::ProtoBuf.IExtensible
  {
    public CPL2010R01LaySpecimenListItemInfo() {}
    
    private string _specimen_ser = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"specimen_ser", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_ser
    {
      get { return _specimen_ser; }
      set { _specimen_ser = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _suname = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"suname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suname
    {
      get { return _suname; }
      set { _suname = value; }
    }
    private string _doctor_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_name
    {
      get { return _doctor_name; }
      set { _doctor_name = value; }
    }
    private string _specimen_no = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"specimen_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_no
    {
      get { return _specimen_no; }
      set { _specimen_no = value; }
    }
    private string _specimen_name = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"specimen_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_name
    {
      get { return _specimen_name; }
      set { _specimen_name = value; }
    }
    private string _tube_name = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"tube_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tube_name
    {
      get { return _tube_name; }
      set { _tube_name = value; }
    }
    private string _tube_count = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"tube_count", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tube_count
    {
      get { return _tube_count; }
      set { _tube_count = value; }
    }
    private string _ho_dong_name = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"ho_dong_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ho_dong_name
    {
      get { return _ho_dong_name; }
      set { _ho_dong_name = value; }
    }
    private string _reser_date = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"reser_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_date
    {
      get { return _reser_date; }
      set { _reser_date = value; }
    }
    private string _cont_key = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"cont_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cont_key
    {
      get { return _cont_key; }
      set { _cont_key = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
