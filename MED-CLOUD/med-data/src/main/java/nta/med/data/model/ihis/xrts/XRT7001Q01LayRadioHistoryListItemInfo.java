package nta.med.data.model.ihis.xrts;

import java.util.Date;

public class XRT7001Q01LayRadioHistoryListItemInfo {
	
	private String bunho;
	private String suname;
	private String gwa;
	private String doctor;
	private Date orderDate;
	private String jundalPart;
	private String xrayCode;
	private String xrayName;
	private String xrayCodeIdx;
	private String xrayCodeIdxNm;
	private String tubeVol;
	private String tubeCur;
	private String xrayTime;
	private String tubeCurTime;
	private String irradiationTime;
	private String xrayDistance;
	public XRT7001Q01LayRadioHistoryListItemInfo(String bunho, String suname,
			String gwa, String doctor, Date orderDate, String jundalPart,
			String xrayCode, String xrayName, String xrayCodeIdx,
			String xrayCodeIdxNm, String tubeVol, String tubeCur,
			String xrayTime, String tubeCurTime, String irradiationTime,
			String xrayDistance) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.gwa = gwa;
		this.doctor = doctor;
		this.orderDate = orderDate;
		this.jundalPart = jundalPart;
		this.xrayCode = xrayCode;
		this.xrayName = xrayName;
		this.xrayCodeIdx = xrayCodeIdx;
		this.xrayCodeIdxNm = xrayCodeIdxNm;
		this.tubeVol = tubeVol;
		this.tubeCur = tubeCur;
		this.xrayTime = xrayTime;
		this.tubeCurTime = tubeCurTime;
		this.irradiationTime = irradiationTime;
		this.xrayDistance = xrayDistance;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getXrayCode() {
		return xrayCode;
	}
	public void setXrayCode(String xrayCode) {
		this.xrayCode = xrayCode;
	}
	public String getXrayName() {
		return xrayName;
	}
	public void setXrayName(String xrayName) {
		this.xrayName = xrayName;
	}
	public String getXrayCodeIdx() {
		return xrayCodeIdx;
	}
	public void setXrayCodeIdx(String xrayCodeIdx) {
		this.xrayCodeIdx = xrayCodeIdx;
	}
	public String getXrayCodeIdxNm() {
		return xrayCodeIdxNm;
	}
	public void setXrayCodeIdxNm(String xrayCodeIdxNm) {
		this.xrayCodeIdxNm = xrayCodeIdxNm;
	}
	public String getTubeVol() {
		return tubeVol;
	}
	public void setTubeVol(String tubeVol) {
		this.tubeVol = tubeVol;
	}
	public String getTubeCur() {
		return tubeCur;
	}
	public void setTubeCur(String tubeCur) {
		this.tubeCur = tubeCur;
	}
	public String getXrayTime() {
		return xrayTime;
	}
	public void setXrayTime(String xrayTime) {
		this.xrayTime = xrayTime;
	}
	public String getTubeCurTime() {
		return tubeCurTime;
	}
	public void setTubeCurTime(String tubeCurTime) {
		this.tubeCurTime = tubeCurTime;
	}
	public String getIrradiationTime() {
		return irradiationTime;
	}
	public void setIrradiationTime(String irradiationTime) {
		this.irradiationTime = irradiationTime;
	}
	public String getXrayDistance() {
		return xrayDistance;
	}
	public void setXrayDistance(String xrayDistance) {
		this.xrayDistance = xrayDistance;
	}
}
