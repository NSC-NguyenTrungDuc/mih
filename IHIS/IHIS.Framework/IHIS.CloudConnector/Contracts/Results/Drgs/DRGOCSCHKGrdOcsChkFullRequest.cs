//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input(1).proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DRGOCSCHKGrdOcsChkFullRequest")]
  public partial class DRGOCSCHKGrdOcsChkFullRequest : global::ProtoBuf.IExtensible
  {
    public DRGOCSCHKGrdOcsChkFullRequest() {}
    
    private string _jaeryo_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"jaeryo_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jaeryo_code
    {
      get { return _jaeryo_code; }
      set { _jaeryo_code = value; }
    }
    private string _jaeryo_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"jaeryo_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jaeryo_name
    {
      get { return _jaeryo_name; }
      set { _jaeryo_name = value; }
    }
    private string _pre_small_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"pre_small_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pre_small_code
    {
      get { return _pre_small_code; }
      set { _pre_small_code = value; }
    }
    private string _small_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"small_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string small_code
    {
      get { return _small_code; }
      set { _small_code = value; }
    }
    private string _drg_pack_yn = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"drg_pack_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string drg_pack_yn
    {
      get { return _drg_pack_yn; }
      set { _drg_pack_yn = value; }
    }
    private string _phamarcy_yn = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"phamarcy_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string phamarcy_yn
    {
      get { return _phamarcy_yn; }
      set { _phamarcy_yn = value; }
    }
    private string _powder_yn = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"powder_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string powder_yn
    {
      get { return _powder_yn; }
      set { _powder_yn = value; }
    }
    private string _hubal_yn = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"hubal_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hubal_yn
    {
      get { return _hubal_yn; }
      set { _hubal_yn = value; }
    }
    private string _mayak_yn = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"mayak_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mayak_yn
    {
      get { return _mayak_yn; }
      set { _mayak_yn = value; }
    }
    private string _stock_yn = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"stock_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string stock_yn
    {
      get { return _stock_yn; }
      set { _stock_yn = value; }
    }
    private string _before_use_yn = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"before_use_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string before_use_yn
    {
      get { return _before_use_yn; }
      set { _before_use_yn = value; }
    }
    private string _wonnae_drg_yn = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"wonnae_drg_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string wonnae_drg_yn
    {
      get { return _wonnae_drg_yn; }
      set { _wonnae_drg_yn = value; }
    }
    private string _jaeryo_gubun = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"jaeryo_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jaeryo_gubun
    {
      get { return _jaeryo_gubun; }
      set { _jaeryo_gubun = value; }
    }
    private string _page_number = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"page_number", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string page_number
    {
      get { return _page_number; }
      set { _page_number = value; }
    }
    private string _offset = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"offset", DataFormat = global::ProtoBuf.DataFormat.Default)]
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