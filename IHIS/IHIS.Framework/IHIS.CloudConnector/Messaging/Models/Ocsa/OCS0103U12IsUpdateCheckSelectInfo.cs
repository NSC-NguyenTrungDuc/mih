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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U12IsUpdateCheckSelectInfo")]
  public partial class OCS0103U12IsUpdateCheckSelectInfo : global::ProtoBuf.IExtensible
  {
    public OCS0103U12IsUpdateCheckSelectInfo() {}
    
    private string _suryang = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"suryang", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suryang
    {
      get { return _suryang; }
      set { _suryang = value; }
    }
    private string _dv = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"dv", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string dv
    {
      get { return _dv; }
      set { _dv = value; }
    }
    private string _dv_time = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"dv_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string dv_time
    {
      get { return _dv_time; }
      set { _dv_time = value; }
    }
    private string _nalsu = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"nalsu", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string nalsu
    {
      get { return _nalsu; }
      set { _nalsu = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
