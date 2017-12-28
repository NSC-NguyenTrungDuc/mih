package nta.med.data.model.ihis.endo;

public class END1001U02DsvDwInfo {
	private Double pkpfe1000      ;
	private String c3             ;
	private Double fkocs          ;
	private String bunho          ;
	private String hangmogCode   ;
	private String hangmogName   ;
	private String residentYn    ;
	public END1001U02DsvDwInfo(Double pkpfe1000, String c3, Double fkocs,
			String bunho, String hangmogCode, String hangmogName,
			String residentYn) {
		super();
		this.pkpfe1000 = pkpfe1000;
		this.c3 = c3;
		this.fkocs = fkocs;
		this.bunho = bunho;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.residentYn = residentYn;
	}
	public Double getPkpfe1000() {
		return pkpfe1000;
	}
	public void setPkpfe1000(Double pkpfe1000) {
		this.pkpfe1000 = pkpfe1000;
	}
	public String getC3() {
		return c3;
	}
	public void setC3(String c3) {
		this.c3 = c3;
	}
	public Double getFkocs() {
		return fkocs;
	}
	public void setFkocs(Double fkocs) {
		this.fkocs = fkocs;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getResidentYn() {
		return residentYn;
	}
	public void setResidentYn(String residentYn) {
		this.residentYn = residentYn;
	}
	
}	
