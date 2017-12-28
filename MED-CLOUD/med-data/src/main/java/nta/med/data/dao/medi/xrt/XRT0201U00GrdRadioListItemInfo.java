package nta.med.data.dao.medi.xrt;

import java.util.Date;

public class XRT0201U00GrdRadioListItemInfo {
	private String bunho ;
	private Date orderDate ;
	private Double fkxrt0201 ;
	private String xrayCode ;
	private String xrayName ;
	private String xrayGubun ;
	private String xrayCodeIdx ;
	private String xrayCodeIdxNm ;
	private String tubeVol ;
	private String tubeCur ;
	private String xrayTime ;
	private String tubeCurTime;
	private String irradiationTime ;
	private String xrayDistance ;
	public XRT0201U00GrdRadioListItemInfo(String bunho, Date orderDate,
			Double fkxrt0201, String xrayCode, String xrayName,
			String xrayGubun, String xrayCodeIdx, String xrayCodeIdxNm,
			String tubeVol, String tubeCur, String xrayTime,
			String tubeCurTime, String irradiationTime, String xrayDistance) {
		super();
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.fkxrt0201 = fkxrt0201;
		this.xrayCode = xrayCode;
		this.xrayName = xrayName;
		this.xrayGubun = xrayGubun;
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
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	public Double getFkxrt0201() {
		return fkxrt0201;
	}
	public void setFkxrt0201(Double fkxrt0201) {
		this.fkxrt0201 = fkxrt0201;
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
	public String getXrayGubun() {
		return xrayGubun;
	}
	public void setXrayGubun(String xrayGubun) {
		this.xrayGubun = xrayGubun;
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
