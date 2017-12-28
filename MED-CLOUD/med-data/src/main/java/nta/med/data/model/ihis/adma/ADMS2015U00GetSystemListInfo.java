package nta.med.data.model.ihis.adma;

public class ADMS2015U00GetSystemListInfo {
	private String sysId;
	private String sysNm;
	private Double sysSeq;
	public ADMS2015U00GetSystemListInfo(String sysId, String sysNm, Double sysSeq) {
		super();
		this.sysId = sysId;
		this.sysNm = sysNm;
		this.sysSeq = sysSeq;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getSysNm() {
		return sysNm;
	}
	public void setSysNm(String sysNm) {
		this.sysNm = sysNm;
	}
	public Double getSysSeq() {
		return sysSeq;
	}
	public void setSysSeq(Double sysSeq) {
		this.sysSeq = sysSeq;
	}
}
