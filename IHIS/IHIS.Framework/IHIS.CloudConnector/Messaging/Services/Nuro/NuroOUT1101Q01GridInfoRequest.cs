//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_service.proto
// Note: requires additional types generated from: nuro_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroOUT1101Q01GridInfoRequest")]
  public partial class NuroOUT1101Q01GridInfoRequest : global::ProtoBuf.IExtensible
  {
    public NuroOUT1101Q01GridInfoRequest() {}
    
    private string _naewon_date;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"naewon_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string naewon_date
    {
      get { return _naewon_date; }
      set { _naewon_date = value; }
    }
    private string _gwa;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _doctor;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
