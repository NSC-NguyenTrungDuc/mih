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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DrugKinkiDiseaseInfo")]
  public partial class DrugKinkiDiseaseInfo : global::ProtoBuf.IExtensible
  {
    public DrugKinkiDiseaseInfo() {}
    
    private string _kinki_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"kinki_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string kinki_id
    {
      get { return _kinki_id; }
      set { _kinki_id = value; }
    }
    private string _disease_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"disease_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string disease_name
    {
      get { return _disease_name; }
      set { _disease_name = value; }
    }
    private string _index_term = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"index_term", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string index_term
    {
      get { return _index_term; }
      set { _index_term = value; }
    }
    private string _standard_disease_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"standard_disease_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string standard_disease_name
    {
      get { return _standard_disease_name; }
      set { _standard_disease_name = value; }
    }
    private string _disease_code = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"disease_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string disease_code
    {
      get { return _disease_code; }
      set { _disease_code = value; }
    }
    private string _icd10 = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"icd10", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string icd10
    {
      get { return _icd10; }
      set { _icd10 = value; }
    }
    private string _decision_flg = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"decision_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string decision_flg
    {
      get { return _decision_flg; }
      set { _decision_flg = value; }
    }
    private string _comment = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"comment", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string comment
    {
      get { return _comment; }
      set { _comment = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
