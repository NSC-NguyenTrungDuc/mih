package nta.med.data.model.ihis.xrts;

public class XRT0001U00GrdRadioListInfo {

	private String xrayCode;
	private String xrayGubun;
	private String xrayCodeIdx;
	private String xrayCodeIdxNm;
	private String tubeVol;
	private String tubeCur;
	private String xrayTime;
	private String tubeCurTime;
	private String irradiationTime;
	private String xrayDistance;
	public XRT0001U00GrdRadioListInfo(String xrayCode, String xrayGubun,
			String xrayCodeIdx, String xrayCodeIdxNm, String tubeVol,
			String tubeCur, String xrayTime, String tubeCurTime,
			String irradiationTime, String xrayDistance) {
		super();
		this.xrayCode = xrayCode;
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
	public String getXrayCode() {
		return xrayCode;
	}
	public void setXrayCode(String xrayCode) {
		this.xrayCode = xrayCode;
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
