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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ComboADM1110GetByColNameRequest")]
  public partial class ComboADM1110GetByColNameRequest : global::ProtoBuf.IExtensible
  {
    public ComboADM1110GetByColNameRequest() {}
    
    private string _col_name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"col_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string col_name
    {
      get { return _col_name; }
      set { _col_name = value; }
    }
    private bool _get_all = default(bool);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"get_all", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool get_all
    {
      get { return _get_all; }
      set { _get_all = value; }
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
