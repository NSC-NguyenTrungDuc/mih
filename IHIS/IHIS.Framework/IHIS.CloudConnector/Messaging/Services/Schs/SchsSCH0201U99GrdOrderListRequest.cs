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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201U99GrdOrderListRequest")]
  public partial class SchsSCH0201U99GrdOrderListRequest : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201U99GrdOrderListRequest() {}
    
    private string _f_bunho = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"f_bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_bunho
    {
      get { return _f_bunho; }
      set { _f_bunho = value; }
    }
    private string _f_fkocs = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"f_fkocs", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_fkocs
    {
      get { return _f_fkocs; }
      set { _f_fkocs = value; }
    }
    private string _f_reser_status = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"f_reser_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_reser_status
    {
      get { return _f_reser_status; }
      set { _f_reser_status = value; }
    }
    private string _f_flag = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"f_flag", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_flag
    {
      get { return _f_flag; }
      set { _f_flag = value; }
    }
    private string _f_reser_gubun = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"f_reser_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_reser_gubun
    {
      get { return _f_reser_gubun; }
      set { _f_reser_gubun = value; }
    }
    private string _f_reser_part = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"f_reser_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_reser_part
    {
      get { return _f_reser_part; }
      set { _f_reser_part = value; }
    }
    private string _is_my_clinnic = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"is_my_clinnic", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string is_my_clinnic
    {
      get { return _is_my_clinnic; }
      set { _is_my_clinnic = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
