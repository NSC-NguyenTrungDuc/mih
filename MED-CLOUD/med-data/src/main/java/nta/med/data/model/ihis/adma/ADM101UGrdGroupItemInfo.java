package nta.med.data.model.ihis.adma;

public class ADM101UGrdGroupItemInfo {
	private String grpId      ;
	private String grpNm      ;
	private Double grpSeq     ;
	private String grpDesc    ;
	private String dispGrpId ;
	public ADM101UGrdGroupItemInfo(String grpId, String grpNm, Double grpSeq,
			String grpDesc, String dispGrpId) {
		super();
		this.grpId = grpId;
		this.grpNm = grpNm;
		this.grpSeq = grpSeq;
		this.grpDesc = grpDesc;
		this.dispGrpId = dispGrpId;
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
	public String getGrpDesc() {
		return grpDesc;
	}
	public void setGrpDesc(String grpDesc) {
		this.grpDesc = grpDesc;
	}
	public String getDispGrpId() {
		return dispGrpId;
	}
	public void setDispGrpId(String dispGrpId) {
		this.dispGrpId = dispGrpId;
	}
}
