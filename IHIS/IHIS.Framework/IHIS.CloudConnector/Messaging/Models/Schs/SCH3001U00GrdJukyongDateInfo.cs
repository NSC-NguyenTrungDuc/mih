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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SCH3001U00GrdJukyongDateInfo")]
  public partial class SCH3001U00GrdJukyongDateInfo : global::ProtoBuf.IExtensible
  {
    public SCH3001U00GrdJukyongDateInfo() {}
    
    private string _jukyong_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"jukyong_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jukyong_date
    {
      get { return _jukyong_date; }
      set { _jukyong_date = value; }
    }
    private string _jundal_table = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"jundal_table", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_table
    {
      get { return _jundal_table; }
      set { _jundal_table = value; }
    }
    private string _jundal_part = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"jundal_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_part
    {
      get { return _jundal_part; }
      set { _jundal_part = value; }
    }
    private string _gumsaja = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"gumsaja", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gumsaja
    {
      get { return _gumsaja; }
      set { _gumsaja = value; }
    }
    private string _old_jukyong_date = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"old_jukyong_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string old_jukyong_date
    {
      get { return _old_jukyong_date; }
      set { _old_jukyong_date = value; }
    }
    private string _mon_day = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"mon_day", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mon_day
    {
      get { return _mon_day; }
      set { _mon_day = value; }
    }
    private string _tue_day = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"tue_day", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tue_day
    {
      get { return _tue_day; }
      set { _tue_day = value; }
    }
    private string _wed_day = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"wed_day", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string wed_day
    {
      get { return _wed_day; }
      set { _wed_day = value; }
    }
    private string _thu_day = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"thu_day", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string thu_day
    {
      get { return _thu_day; }
      set { _thu_day = value; }
    }
    private string _fri_day = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"fri_day", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fri_day
    {
      get { return _fri_day; }
      set { _fri_day = value; }
    }
    private string _sta_day = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"sta_day", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sta_day
    {
      get { return _sta_day; }
      set { _sta_day = value; }
    }
    private string _sun_day = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"sun_day", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sun_day
    {
      get { return _sun_day; }
      set { _sun_day = value; }
    }
    private string _data_row_state = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"data_row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string data_row_state
    {
      get { return _data_row_state; }
      set { _data_row_state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}