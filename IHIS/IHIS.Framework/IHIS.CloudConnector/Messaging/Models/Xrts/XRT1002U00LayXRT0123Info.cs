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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT1002U00LayXRT0123Info")]
  public partial class XRT1002U00LayXRT0123Info : global::ProtoBuf.IExtensible
  {
    public XRT1002U00LayXRT0123Info() {}
    
    private string _valtage = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"valtage", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string valtage
    {
      get { return _valtage; }
      set { _valtage = value; }
    }
    private string _cur_electric = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"cur_electric", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cur_electric
    {
      get { return _cur_electric; }
      set { _cur_electric = value; }
    }
    private string _time = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string time
    {
      get { return _time; }
      set { _time = value; }
    }
    private string _distance = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"distance", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string distance
    {
      get { return _distance; }
      set { _distance = value; }
    }
    private string _grid = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"grid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string grid
    {
      get { return _grid; }
      set { _grid = value; }
    }
    private string _note = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"note", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string note
    {
      get { return _note; }
      set { _note = value; }
    }
    private string _mas_val = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"mas_val", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mas_val
    {
      get { return _mas_val; }
      set { _mas_val = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
