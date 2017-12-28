package nta.med.data.model.ihis.adma;

import java.math.BigDecimal;

public class ADMS2015U00GroupHospitalInfo {
	private Integer admsGroupId;
	private Integer grpSeq;
	private String hospCode;
	private BigDecimal selectFlg;
	private String grpId;
	private String grpNm;
	private String dataRowState;
	public ADMS2015U00GroupHospitalInfo(Integer admsGroupId, Integer grpSeq,
			String hospCode, BigDecimal selectFlg, String grpId, String grpNm,
			String dataRowState) {
		super();
		this.admsGroupId = admsGroupId;
		this.grpSeq = grpSeq;
		this.hospCode = hospCode;
		this.selectFlg = selectFlg;
		this.grpId = grpId;
		this.grpNm = grpNm;
		this.dataRowState = dataRowState;
	}
	public Integer getAdmsGroupId() {
		return admsGroupId;
	}
	public void setAdmsGroupId(Integer admsGroupId) {
		this.admsGroupId = admsGroupId;
	}
	public Integer getGrpSeq() {
		return grpSeq;
	}
	public void setGrpSeq(Integer grpSeq) {
		this.grpSeq = grpSeq;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public BigDecimal getSelectFlg() {
		return selectFlg;
	}
	public void setSelectFlg(BigDecimal selectFlg) {
		this.selectFlg = selectFlg;
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
	public String getDataRowState() {
		return dataRowState;
	}
	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}

}
