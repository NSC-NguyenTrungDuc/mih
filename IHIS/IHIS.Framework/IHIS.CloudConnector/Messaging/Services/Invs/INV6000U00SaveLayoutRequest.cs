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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV6000U00SaveLayoutRequest")]
  public partial class INV6000U00SaveLayoutRequest : global::ProtoBuf.IExtensible
  {
    public INV6000U00SaveLayoutRequest() {}
    
    private string _proc = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"proc", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string proc
    {
      get { return _proc; }
      set { _proc = value; }
    }
    private string _month = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"month", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string month
    {
      get { return _month; }
      set { _month = value; }
    }
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _input_user = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"input_user", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_user
    {
      get { return _input_user; }
      set { _input_user = value; }
    }
    private string _input_date = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"input_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_date
    {
      get { return _input_date; }
      set { _input_date = value; }
    }
    private string _remark = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"remark", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string remark
    {
      get { return _remark; }
      set { _remark = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
