//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
// Note: requires additional types generated from: import.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL3010U01SearchMaxRequest")]
  public partial class CPL3010U01SearchMaxRequest : global::ProtoBuf.IExtensible
  {
    public CPL3010U01SearchMaxRequest() {}
    
    private string _info_gb = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"info_gb", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string info_gb
    {
      get { return _info_gb; }
      set { _info_gb = value; }
    }
    private string _from_part_jubsu_date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"from_part_jubsu_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string from_part_jubsu_date
    {
      get { return _from_part_jubsu_date; }
      set { _from_part_jubsu_date = value; }
    }
    private string _to_part_jubsu_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"to_part_jubsu_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string to_part_jubsu_date
    {
      get { return _to_part_jubsu_date; }
      set { _to_part_jubsu_date = value; }
    }
    private string _from_seq = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"from_seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string from_seq
    {
      get { return _from_seq; }
      set { _from_seq = value; }
    }
    private string _to_seq = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"to_seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string to_seq
    {
      get { return _to_seq; }
      set { _to_seq = value; }
    }
    private string _from_specimen_ser = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"from_specimen_ser", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string from_specimen_ser
    {
      get { return _from_specimen_ser; }
      set { _from_specimen_ser = value; }
    }
    private string _to_specimen_ser = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"to_specimen_ser", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string to_specimen_ser
    {
      get { return _to_specimen_ser; }
      set { _to_specimen_ser = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
