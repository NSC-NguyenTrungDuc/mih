package nta.med.data.model.ihis.invs;

public class INV6000U00GrdINV6001Info {
	private String jaeryoCode          ;
	private String jaeryoName          ;
	private Double preMJaegoQty      ;
	private Double ipgoQty             ;
	private Double chulgoQty           ;
	private Double jaegoQty            ;
	private Double existCnt            ;
	private Double deltaQty            ;
	private String subulDanuiName     ;
	private String danga                ;
	private String adjAmt              ;
	public INV6000U00GrdINV6001Info(String jaeryoCode, String jaeryoName, Double preMJaegoQty, Double ipgoQty,
			Double chulgoQty, Double jaegoQty, Double existCnt, Double deltaQty, String subulDanuiName, String danga,
			String adjAmt) {
		super();
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.preMJaegoQty = preMJaegoQty;
		this.ipgoQty = ipgoQty;
		this.chulgoQty = chulgoQty;
		this.jaegoQty = jaegoQty;
		this.existCnt = existCnt;
		this.deltaQty = deltaQty;
		this.subulDanuiName = subulDanuiName;
		this.danga = danga;
		this.adjAmt = adjAmt;
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
	public Double getExistCnt() {
		return existCnt;
	}
	public void setExistCnt(Double existCnt) {
		this.existCnt = existCnt;
	}
	public Double getDeltaQty() {
		return deltaQty;
	}
	public void setDeltaQty(Double deltaQty) {
		this.deltaQty = deltaQty;
	}
	public String getSubulDanuiName() {
		return subulDanuiName;
	}
	public void setSubulDanuiName(String subulDanuiName) {
		this.subulDanuiName = subulDanuiName;
	}
	public String getDanga() {
		return danga;
	}
	public void setDanga(String danga) {
		this.danga = danga;
	}
	public String getAdjAmt() {
		return adjAmt;
	}
	public void setAdjAmt(String adjAmt) {
		this.adjAmt = adjAmt;
	}
	
}
