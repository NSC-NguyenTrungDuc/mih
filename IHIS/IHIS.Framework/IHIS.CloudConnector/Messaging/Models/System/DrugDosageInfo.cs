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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DrugDosageInfo")]
  public partial class DrugDosageInfo : global::ProtoBuf.IExtensible
  {
    public DrugDosageInfo() {}
    
    private string _drug_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"drug_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string drug_id
    {
      get { return _drug_id; }
      set { _drug_id = value; }
    }
    private string _branch_number = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"branch_number", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string branch_number
    {
      get { return _branch_number; }
      set { _branch_number = value; }
    }
    private string _dosage_branch_number = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"dosage_branch_number", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string dosage_branch_number
    {
      get { return _dosage_branch_number; }
      set { _dosage_branch_number = value; }
    }
    private string _a4 = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"a4", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string a4
    {
      get { return _a4; }
      set { _a4 = value; }
    }
    private string _a5 = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"a5", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string a5
    {
      get { return _a5; }
      set { _a5 = value; }
    }
    private string _adaptation = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"adaptation", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string adaptation
    {
      get { return _adaptation; }
      set { _adaptation = value; }
    }
    private string _adaptation_related = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"adaptation_related", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string adaptation_related
    {
      get { return _adaptation_related; }
      set { _adaptation_related = value; }
    }
    private string _a8 = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"a8", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string a8
    {
      get { return _a8; }
      set { _a8 = value; }
    }
    private string _age_clssification = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"age_clssification", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string age_clssification
    {
      get { return _age_clssification; }
      set { _age_clssification = value; }
    }
    private string _appropriate = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"appropriate", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string appropriate
    {
      get { return _appropriate; }
      set { _appropriate = value; }
    }
    private string _appropriate_condition = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"appropriate_condition", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string appropriate_condition
    {
      get { return _appropriate_condition; }
      set { _appropriate_condition = value; }
    }
    private string _a12 = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"a12", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string a12
    {
      get { return _a12; }
      set { _a12 = value; }
    }
    private string _a13 = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"a13", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string a13
    {
      get { return _a13; }
      set { _a13 = value; }
    }
    private string _one_dose = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"one_dose", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string one_dose
    {
      get { return _one_dose; }
      set { _one_dose = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
