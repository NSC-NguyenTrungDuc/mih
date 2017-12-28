package nta.med.data.model.ihis.adma;


public class ADMS2015U00GetGroupHospitalInfo {
	private String admsGroupId;
	private String grpId;
	private String grpNm;
	private String grpSeq;
	private String hospCode;
	private String selectFlg;
	public ADMS2015U00GetGroupHospitalInfo(String admsGroupId, String grpId,
			String grpNm, String grpSeq, String hospCode, String selectFlg) {
		super();
		this.admsGroupId = admsGroupId;
		this.grpId = grpId;
		this.grpNm = grpNm;
		this.grpSeq = grpSeq;
		this.hospCode = hospCode;
		this.selectFlg = selectFlg;
	}
	public String getAdmsGroupId() {
		return admsGroupId;
	}
	public void setAdmsGroupId(String admsGroupId) {
		this.admsGroupId = admsGroupId;
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
	public String getGrpSeq() {
		return grpSeq;
	}
	public void setGrpSeq(String grpSeq) {
		this.grpSeq = grpSeq;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getSelectFlg() {
		return selectFlg;
	}
	public void setSelectFlg(String selectFlg) {
		this.selectFlg = selectFlg;
	}
	
}
