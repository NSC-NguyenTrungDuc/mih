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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PHY2001U04CreateAutoJubsuResponse")]
  public partial class PHY2001U04CreateAutoJubsuResponse : global::ProtoBuf.IExtensible
  {
    public PHY2001U04CreateAutoJubsuResponse() {}
    
    private string _output_list0 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"output_list0", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string output_list0
    {
      get { return _output_list0; }
      set { _output_list0 = value; }
    }
    private string _output_list1 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"output_list1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string output_list1
    {
      get { return _output_list1; }
      set { _output_list1 = value; }
    }
    private string _output_sin0 = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"output_sin0", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string output_sin0
    {
      get { return _output_sin0; }
      set { _output_sin0 = value; }
    }
    private string _output_sin1 = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"output_sin1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string output_sin1
    {
      get { return _output_sin1; }
      set { _output_sin1 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}