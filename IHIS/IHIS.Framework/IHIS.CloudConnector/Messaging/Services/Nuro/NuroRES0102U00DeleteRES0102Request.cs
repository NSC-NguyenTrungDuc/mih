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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroRES0102U00DeleteRES0102Request")]
  public partial class NuroRES0102U00DeleteRES0102Request : global::ProtoBuf.IExtensible
  {
    public NuroRES0102U00DeleteRES0102Request() {}
    
    private string _start_date;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"start_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string start_date
    {
      get { return _start_date; }
      set { _start_date = value; }
    }
    private string _doctor;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
