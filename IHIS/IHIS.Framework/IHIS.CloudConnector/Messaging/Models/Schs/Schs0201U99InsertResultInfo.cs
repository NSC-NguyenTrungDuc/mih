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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Schs0201U99InsertResultInfo")]
  public partial class Schs0201U99InsertResultInfo : global::ProtoBuf.IExtensible
  {
    public Schs0201U99InsertResultInfo() {}
    
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _fkout1001 = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"fkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkout1001
    {
      get { return _fkout1001; }
      set { _fkout1001 = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
