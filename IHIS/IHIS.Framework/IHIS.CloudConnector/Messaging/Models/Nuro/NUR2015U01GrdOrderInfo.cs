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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NUR2015U01GrdOrderInfo")]
  public partial class NUR2015U01GrdOrderInfo : global::ProtoBuf.IExtensible
  {
    public NUR2015U01GrdOrderInfo() {}
    
    private string _exam_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"exam_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string exam_date
    {
      get { return _exam_date; }
      set { _exam_date = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _naewon_key = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"naewon_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_key
    {
      get { return _naewon_key; }
      set { _naewon_key = value; }
    }
    private string _gwa_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa_name
    {
        get { return _gwa_name; }
        set { _gwa_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
