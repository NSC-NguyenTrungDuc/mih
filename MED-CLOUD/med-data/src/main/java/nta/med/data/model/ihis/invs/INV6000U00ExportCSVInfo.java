package nta.med.data.model.ihis.invs;

public class INV6000U00ExportCSVInfo {
	private String rowNum             ;
	private String jaeryoCode         ;
	private String jaeryoName         ;
	private String ipgoDanuiName     ;
	private Double danga               ;
	private Double preMJaegoQty     ;
	private Double ipgoQty            ;
	private Double chulgoQty          ;
	private Double jaegoQty           ;
	private Double adjAmt             ;
	private Double dangaJaegoQty     ;
	public INV6000U00ExportCSVInfo(String rowNum, String jaeryoCode, String jaeryoName, String ipgoDanuiName,
			Double danga, Double preMJaegoQty, Double ipgoQty, Double chulgoQty, Double jaegoQty, Double adjAmt,
			Double dangaJaegoQty) {
		super();
		this.rowNum = rowNum;
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.ipgoDanuiName = ipgoDanuiName;
		this.danga = danga;
		this.preMJaegoQty = preMJaegoQty;
		this.ipgoQty = ipgoQty;
		this.chulgoQty = chulgoQty;
		this.jaegoQty = jaegoQty;
		this.adjAmt = adjAmt;
		this.dangaJaegoQty = dangaJaegoQty;
	}
	public String getRowNum() {
		return rowNum;
	}
	public void setRowNum(String rowNum) {
		this.rowNum = rowNum;
	}
	public String getJaeryoCode() {
		return jaeryoCode;
	}
	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}
	public String getJaeryoName() {
		return jaeryoName;
	}
	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}
	public String getIpgoDanuiName() {
		return ipgoDanuiName;
	}
	public void setIpgoDanuiName(String ipgoDanuiName) {
		this.ipgoDanuiName = ipgoDanuiName;
	}
	public Double getDanga() {
		return danga;
	}
	public void setDanga(Double danga) {
		this.danga = danga;
	}
	public Double getPreMJaegoQty() {
		return preMJaegoQty;
	}
	public void setPreMJaegoQty(Double preMJaegoQty) {
		this.preMJaegoQty = preMJaegoQty;
	}
	public Double getIpgoQty() {
		return ipgoQty;
	}
	public void setIpgoQty(Double ipgoQty) {
		this.ipgoQty = ipgoQty;
	}
	public Double getChulgoQty() {
		return chulgoQty;
	}
	public void setChulgoQty(Double chulgoQty) {
		this.chulgoQty = chulgoQty;
	}
	public Double getJaegoQty() {
		return jaegoQty;
	}
	public void setJaegoQty(Double jaegoQty) {
		this.jaegoQty = jaegoQty;
	}
	public Double getAdjAmt() {
		return adjAmt;
	}
	public void setAdjAmt(Double adjAmt) {
		this.adjAmt = adjAmt;
	}
	public Double getDangaJaegoQty() {
		return dangaJaegoQty;
	}
	public void setDangaJaegoQty(Double dangaJaegoQty) {
		this.dangaJaegoQty = dangaJaegoQty;
	}
	
}
