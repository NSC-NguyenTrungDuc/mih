package nta.med.data.model.ihis.nuri;

import java.math.BigInteger;

public class NUR5020U00layNurCntInfo {

	private BigInteger nurseGradeName;
	private BigInteger earlyCnt;
	private BigInteger dayCnt;
	private BigInteger lateCnt;
	private BigInteger nightCnt;
	private BigInteger holyCnt;
	private BigInteger vacCnt;

	public NUR5020U00layNurCntInfo(BigInteger nurseGradeName, BigInteger earlyCnt, BigInteger dayCnt,
			BigInteger lateCnt, BigInteger nightCnt, BigInteger holyCnt, BigInteger vacCnt) {
		super();
		this.nurseGradeName = nurseGradeName;
		this.earlyCnt = earlyCnt;
		this.dayCnt = dayCnt;
		this.lateCnt = lateCnt;
		this.nightCnt = nightCnt;
		this.holyCnt = holyCnt;
		this.vacCnt = vacCnt;
	}

	public BigInteger getNurseGradeName() {
		return nurseGradeName;
	}

	public void setNurseGradeName(BigInteger nurseGradeName) {
		this.nurseGradeName = nurseGradeName;
	}

	public BigInteger getEarlyCnt() {
		return earlyCnt;
	}

	public void setEarlyCnt(BigInteger earlyCnt) {
		this.earlyCnt = earlyCnt;
	}

	public BigInteger getDayCnt() {
		return dayCnt;
	}

	public void setDayCnt(BigInteger dayCnt) {
		this.dayCnt = dayCnt;
	}

	public BigInteger getLateCnt() {
		return lateCnt;
	}

	public void setLateCnt(BigInteger lateCnt) {
		this.lateCnt = lateCnt;
	}

	public BigInteger getNightCnt() {
		return nightCnt;
	}

	public void setNightCnt(BigInteger nightCnt) {
		this.nightCnt = nightCnt;
	}

	public BigInteger getHolyCnt() {
		return holyCnt;
	}

	public void setHolyCnt(BigInteger holyCnt) {
		this.holyCnt = holyCnt;
	}

	public BigInteger getVacCnt() {
		return vacCnt;
	}

	public void setVacCnt(BigInteger vacCnt) {
		this.vacCnt = vacCnt;
	}

}
