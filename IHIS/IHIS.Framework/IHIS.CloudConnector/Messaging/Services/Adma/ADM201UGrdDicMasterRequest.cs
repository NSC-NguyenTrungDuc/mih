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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ADM201UGrdDicMasterRequest")]
  public partial class ADM201UGrdDicMasterRequest : global::ProtoBuf.IExtensible
  {
    public ADM201UGrdDicMasterRequest() {}
    
    private string _col_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"col_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string col_id
    {
      get { return _col_id; }
      set { _col_id = value; }
    }
    private string _col_nm = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"col_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string col_nm
    {
      get { return _col_nm; }
      set { _col_nm = value; }
    }
    private string _page_number = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"page_number", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string page_number
    {
      get { return _page_number; }
      set { _page_number = value; }
    }
    private string _offset = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"offset", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string offset
    {
      get { return _offset; }
      set { _offset = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
