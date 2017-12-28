package nta.med.data.model.ihis.orca;

public class ORCALibGetClaimDiagnosisInfo {
	private String updDate           ;
	private Double pkoif5101          ;
	private String license            ;
	private String gwa                ;
	private String gwaName           ;
	private String categoriTd        ;
	private String categoriName      ;
	private String code               ;
	private String system             ;
	private String codeName          ;
	private String startDate         ;
	private String endDate           ;
	private String outCome           ;
	private String docId             ;
	public ORCALibGetClaimDiagnosisInfo(String updDate, Double pkoif5101,
			String license, String gwa, String gwaName, String categoriTd,
			String categoriName, String code, String system, String codeName,
			String startDate, String endDate, String outCome, String docId) {
		super();
		this.updDate = updDate;
		this.pkoif5101 = pkoif5101;
		this.license = license;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.categoriTd = categoriTd;
		this.categoriName = categoriName;
		this.code = code;
		this.system = system;
		this.codeName = codeName;
		this.startDate = startDate;
		this.endDate = endDate;
		this.outCome = outCome;
		this.docId = docId;
	}
	public String getUpdDate() {
		return updDate;
	}
	public void setUpdDate(String updDate) {
		this.updDate = updDate;
	}
	public Double getPkoif5101() {
		return pkoif5101;
	}
	public void setPkoif5101(Double pkoif5101) {
		this.pkoif5101 = pkoif5101;
	}
	public String getLicense() {
		return license;
	}
	public void setLicense(String license) {
		this.license = license;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getCategoriTd() {
		return categoriTd;
	}
	public void setCategoriTd(String categoriTd) {
		this.categoriTd = categoriTd;
	}
	public String getCategoriName() {
		return categoriName;
	}
	public void setCategoriName(String categoriName) {
		this.categoriName = categoriName;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public String getSystem() {
		return system;
	}
	public void setSystem(String system) {
		this.system = system;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	public String getStartDate() {
		return startDate;
	}
	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}
	public String getEndDate() {
		return endDate;
	}
	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}
	public String getOutCome() {
		return outCome;
	}
	public void setOutCome(String outCome) {
		this.outCome = outCome;
	}
	public String getDocId() {
		return docId;
	}
	public void setDocId(String docId) {
		this.docId = docId;
	}
	
}
