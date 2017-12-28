package nta.med.data.model.ihis.ocso;

public class FwPaCommentGrdCmmtFwkInfo {
	private String comments      ;
	private String displayYn    ;
	private String bunho         ;
	private String cmmtGubun    ;
	private String jundalTable  ;
	private String jundalPart   ;
	private String iOutGubun  ;
	private Double fkocs         ;
	private String hangmogCode  ;
	private Double ser           ;
	public FwPaCommentGrdCmmtFwkInfo(String comments,
			String displayYn, String bunho, String cmmtGubun,
			String jundalTable, String jundalPart, String iOutGubun,
			Double fkocs, String hangmogCode, Double ser) {
		super();
		this.comments = comments;
		this.displayYn = displayYn;
		this.bunho = bunho;
		this.cmmtGubun = cmmtGubun;
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.iOutGubun = iOutGubun;
		this.fkocs = fkocs;
		this.hangmogCode = hangmogCode;
		this.ser = ser;
	}
	public String getComments() {
		return comments;
	}
	public void setComments(String comments) {
		this.comments = comments;
	}
	public String getDisplayYn() {
		return displayYn;
	}
	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getCmmtGubun() {
		return cmmtGubun;
	}
	public void setCmmtGubun(String cmmtGubun) {
		this.cmmtGubun = cmmtGubun;
	}
	public String getJundalTable() {
		return jundalTable;
	}
	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getiOutGubun() {
		return iOutGubun;
	}
	public void setiOutGubun(String iOutGubun) {
		this.iOutGubun = iOutGubun;
	}
	public Double getFkocs() {
		return fkocs;
	}
	public void setFkocs(Double fkocs) {
		this.fkocs = fkocs;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public Double getSer() {
		return ser;
	}
	public void setSer(Double ser) {
		this.ser = ser;
	}
	
}
