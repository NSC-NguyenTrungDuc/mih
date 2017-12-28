package nta.med.data.model.ihis.ocsa;

public class OCS0103U00FwkCommonInfo {
	private String yjCode               ;
	private String hotCode              ;
	private String yakKijunCode        ;
	private String sgCode               ;
	private String saleName             ;
	private String createdCompanyName  ;
	private String saledCompanyname    ;
	private String a16                   ;
	private String a18                   ;
	public OCS0103U00FwkCommonInfo(String yjCode, String hotCode,
			String yakKijunCode, String sgCode, String saleName,
			String createdCompanyName, String saledCompanyname, String a16,
			String a18) {
		super();
		this.yjCode = yjCode;
		this.hotCode = hotCode;
		this.yakKijunCode = yakKijunCode;
		this.sgCode = sgCode;
		this.saleName = saleName;
		this.createdCompanyName = createdCompanyName;
		this.saledCompanyname = saledCompanyname;
		this.a16 = a16;
		this.a18 = a18;
	}
	public String getYjCode() {
		return yjCode;
	}
	public void setYjCode(String yjCode) {
		this.yjCode = yjCode;
	}
	public String getHotCode() {
		return hotCode;
	}
	public void setHotCode(String hotCode) {
		this.hotCode = hotCode;
	}
	public String getYakKijunCode() {
		return yakKijunCode;
	}
	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}
	public String getSgCode() {
		return sgCode;
	}
	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}
	public String getSaleName() {
		return saleName;
	}
	public void setSaleName(String saleName) {
		this.saleName = saleName;
	}
	public String getCreatedCompanyName() {
		return createdCompanyName;
	}
	public void setCreatedCompanyName(String createdCompanyName) {
		this.createdCompanyName = createdCompanyName;
	}
	public String getSaledCompanyname() {
		return saledCompanyname;
	}
	public void setSaledCompanyname(String saledCompanyname) {
		this.saledCompanyname = saledCompanyname;
	}
	public String getA16() {
		return a16;
	}
	public void setA16(String a16) {
		this.a16 = a16;
	}
	public String getA18() {
		return a18;
	}
	public void setA18(String a18) {
		this.a18 = a18;
	}
}
