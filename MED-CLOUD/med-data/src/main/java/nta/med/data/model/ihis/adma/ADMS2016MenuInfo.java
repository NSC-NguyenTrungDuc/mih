package nta.med.data.model.ihis.adma;

public class ADMS2016MenuInfo {
	private String sysId; 
	private String trId;
	private Double trSeq;
	private String upprMenu;  
	public ADMS2016MenuInfo(String sysId, String trId, Double trSeq, String upprMenu) {
		super();
		this.sysId = sysId;
		this.trId = trId;
		this.trSeq = trSeq;
		this.upprMenu = upprMenu;

	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getTrId() {
		return trId;
	}
	public void setTrId(String trId) {
		this.trId = trId;
	}
	public Double getTrSeq() {
		return trSeq;
	}
	public void setTrSeq(Double trSeq) {
		this.trSeq = trSeq;
	}
	public String getUpprMenu() {
		return upprMenu;
	}
	public void setUpprMenu(String upprMenu) {
		this.upprMenu = upprMenu;
	}
	
}
