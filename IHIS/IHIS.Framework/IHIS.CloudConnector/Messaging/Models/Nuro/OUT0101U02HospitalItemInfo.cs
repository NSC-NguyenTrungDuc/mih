//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OUT0101U02HospitalItemInfo")]
  public partial class OUT0101U02HospitalItemInfo : global::ProtoBuf.IExtensible
  {
    public OUT0101U02HospitalItemInfo() {}
    
    private string _yoyang_name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"yoyang_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yoyang_name
    {
      get { return _yoyang_name; }
      set { _yoyang_name = value; }
    }
    private string _address = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"address", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string address
    {
      get { return _address; }
      set { _address = value; }
    }
    private string _tel = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"tel", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tel
    {
      get { return _tel; }
      set { _tel = value; }
    }
    private string _patient_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"patient_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_name
    {
      get { return _patient_name; }
      set { _patient_name = value; }
    }
    private string _password = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"password", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string password
    {
      get { return _password; }
      set { _password = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
