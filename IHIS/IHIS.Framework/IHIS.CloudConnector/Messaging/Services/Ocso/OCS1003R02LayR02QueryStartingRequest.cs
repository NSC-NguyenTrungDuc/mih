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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS1003R02LayR02QueryStartingRequest")]
  public partial class OCS1003R02LayR02QueryStartingRequest : global::ProtoBuf.IExtensible
  {
    public OCS1003R02LayR02QueryStartingRequest() {}
    
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _naewon_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"naewon_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_date
    {
      get { return _naewon_date; }
      set { _naewon_date = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _naewon_type = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"naewon_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_type
    {
      get { return _naewon_type; }
      set { _naewon_type = value; }
    }
    private string _jubsu_no = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"jubsu_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jubsu_no
    {
      get { return _jubsu_no; }
      set { _jubsu_no = value; }
    }
    private string _fkout1001 = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"fkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkout1001
    {
      get { return _fkout1001; }
      set { _fkout1001 = value; }
    }
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}