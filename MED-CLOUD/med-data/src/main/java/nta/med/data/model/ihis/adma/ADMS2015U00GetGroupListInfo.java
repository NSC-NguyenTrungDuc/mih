package nta.med.data.model.ihis.adma;

public class ADMS2015U00GetGroupListInfo {
	private String grpId;
	private String grpNm;
	private Double grpSeq;
	public ADMS2015U00GetGroupListInfo(String grpId, String grpNm, Double grpSeq) {
		super();
		this.grpId = grpId;
		this.grpNm = grpNm;
		this.grpSeq = grpSeq;
	}
	public String getGrpId() {
		return grpId;
	}
	public void setGrpId(String grpId) {
		this.grpId = grpId;
	}
	public String getGrpNm() {
		return grpNm;
	}
	public void setGrpNm(String grpNm) {
		this.grpNm = grpNm;
	}
	public Double getGrpSeq() {
		return grpSeq;
	}
	public void setGrpSeq(Double grpSeq) {
		this.grpSeq = grpSeq;
	}
	
}
