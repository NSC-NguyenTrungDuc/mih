//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuri_service.proto
// Note: requires additional types generated from: nuri_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuriNUR7001U00InsertNUR7001Request")]
  public partial class NuriNUR7001U00InsertNUR7001Request : global::ProtoBuf.IExtensible
  {
    public NuriNUR7001U00InsertNUR7001Request() {}
    
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _measure_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"measure_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string measure_date
    {
      get { return _measure_date; }
      set { _measure_date = value; }
    }
    private string _new_seq = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"new_seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string new_seq
    {
      get { return _new_seq; }
      set { _new_seq = value; }
    }
    private string _height = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"height", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string height
    {
      get { return _height; }
      set { _height = value; }
    }
    private string _weight = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"weight", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string weight
    {
      get { return _weight; }
      set { _weight = value; }
    }
    private string _bp_from = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"bp_from", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bp_from
    {
      get { return _bp_from; }
      set { _bp_from = value; }
    }
    private string _bp_to = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"bp_to", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bp_to
    {
      get { return _bp_to; }
      set { _bp_to = value; }
    }
    private string _body_heat = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"body_heat", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string body_heat
    {
      get { return _body_heat; }
      set { _body_heat = value; }
    }
    private string _pulse = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"pulse", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pulse
    {
      get { return _pulse; }
      set { _pulse = value; }
    }
    private string _spo2 = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"spo2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string spo2
    {
      get { return _spo2; }
      set { _spo2 = value; }
    }
    private string _measure_time = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"measure_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string measure_time
    {
      get { return _measure_time; }
      set { _measure_time = value; }
    }
    private string _breath = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"breath", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string breath
    {
      get { return _breath; }
      set { _breath = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
