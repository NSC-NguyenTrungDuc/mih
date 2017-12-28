package nta.med.core.domain.xrt;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the XRT0001 database table.
 * 
 */
@Entity
@Table(name="XRT0001")
public class Xrt0001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String frequentUseYn;
	private String hospCode;
	private String irradiationTime;
	private String jaeryoYn;
	private String modality;
	private String namePrintYn;
	private String requestYn;
	private String reserType;
	private String reserYnInp;
	private String reserYnOut;
	private String slipCode;
	private String sort;
	private String specialYn;
	private String sugaCode;
	private Date sysDate;
	private String sysId;
	private String tongGubun;
	private String tubeCur;
	private String tubeCurTime;
	private String tubeVol;
	private Date updDate;
	private String updId;
	private String xrayBuwi;
	private String xrayBuwiKaikei;
	private String xrayBuwiTong;
	private Double xrayCnt;
	private String xrayCode;
	private String xrayDistance;
	private String xrayGubun;
	private String xrayName;
	private String xrayName2;
	private Double xrayRealCnt;
	private String xrayRight;
	private String xrayRoom;
	private String xrayRoomInp;
	private String xrayTime;
	private String xrayWay;
	private String xrtGroup;

	public Xrt0001() {
	}


	@Column(name="FREQUENT_USE_YN")
	public String getFrequentUseYn() {
		return this.frequentUseYn;
	}

	public void setFrequentUseYn(String frequentUseYn) {
		this.frequentUseYn = frequentUseYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IRRADIATION_TIME")
	public String getIrradiationTime() {
		return this.irradiationTime;
	}

	public void setIrradiationTime(String irradiationTime) {
		this.irradiationTime = irradiationTime;
	}


	@Column(name="JAERYO_YN")
	public String getJaeryoYn() {
		return this.jaeryoYn;
	}

	public void setJaeryoYn(String jaeryoYn) {
		this.jaeryoYn = jaeryoYn;
	}


	public String getModality() {
		return this.modality;
	}

	public void setModality(String modality) {
		this.modality = modality;
	}


	@Column(name="NAME_PRINT_YN")
	public String getNamePrintYn() {
		return this.namePrintYn;
	}

	public void setNamePrintYn(String namePrintYn) {
		this.namePrintYn = namePrintYn;
	}


	@Column(name="REQUEST_YN")
	public String getRequestYn() {
		return this.requestYn;
	}

	public void setRequestYn(String requestYn) {
		this.requestYn = requestYn;
	}


	@Column(name="RESER_TYPE")
	public String getReserType() {
		return this.reserType;
	}

	public void setReserType(String reserType) {
		this.reserType = reserType;
	}


	@Column(name="RESER_YN_INP")
	public String getReserYnInp() {
		return this.reserYnInp;
	}

	public void setReserYnInp(String reserYnInp) {
		this.reserYnInp = reserYnInp;
	}


	@Column(name="RESER_YN_OUT")
	public String getReserYnOut() {
		return this.reserYnOut;
	}

	public void setReserYnOut(String reserYnOut) {
		this.reserYnOut = reserYnOut;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	public String getSort() {
		return this.sort;
	}

	public void setSort(String sort) {
		this.sort = sort;
	}


	@Column(name="SPECIAL_YN")
	public String getSpecialYn() {
		return this.specialYn;
	}

	public void setSpecialYn(String specialYn) {
		this.specialYn = specialYn;
	}


	@Column(name="SUGA_CODE")
	public String getSugaCode() {
		return this.sugaCode;
	}

	public void setSugaCode(String sugaCode) {
		this.sugaCode = sugaCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="TONG_GUBUN")
	public String getTongGubun() {
		return this.tongGubun;
	}

	public void setTongGubun(String tongGubun) {
		this.tongGubun = tongGubun;
	}


	@Column(name="TUBE_CUR")
	public String getTubeCur() {
		return this.tubeCur;
	}

	public void setTubeCur(String tubeCur) {
		this.tubeCur = tubeCur;
	}


	@Column(name="TUBE_CUR_TIME")
	public String getTubeCurTime() {
		return this.tubeCurTime;
	}

	public void setTubeCurTime(String tubeCurTime) {
		this.tubeCurTime = tubeCurTime;
	}


	@Column(name="TUBE_VOL")
	public String getTubeVol() {
		return this.tubeVol;
	}

	public void setTubeVol(String tubeVol) {
		this.tubeVol = tubeVol;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	@Column(name="XRAY_BUWI")
	public String getXrayBuwi() {
		return this.xrayBuwi;
	}

	public void setXrayBuwi(String xrayBuwi) {
		this.xrayBuwi = xrayBuwi;
	}


	@Column(name="XRAY_BUWI_KAIKEI")
	public String getXrayBuwiKaikei() {
		return this.xrayBuwiKaikei;
	}

	public void setXrayBuwiKaikei(String xrayBuwiKaikei) {
		this.xrayBuwiKaikei = xrayBuwiKaikei;
	}


	@Column(name="XRAY_BUWI_TONG")
	public String getXrayBuwiTong() {
		return this.xrayBuwiTong;
	}

	public void setXrayBuwiTong(String xrayBuwiTong) {
		this.xrayBuwiTong = xrayBuwiTong;
	}


	@Column(name="XRAY_CNT")
	public Double getXrayCnt() {
		return this.xrayCnt;
	}

	public void setXrayCnt(Double xrayCnt) {
		this.xrayCnt = xrayCnt;
	}


	@Column(name="XRAY_CODE")
	public String getXrayCode() {
		return this.xrayCode;
	}

	public void setXrayCode(String xrayCode) {
		this.xrayCode = xrayCode;
	}


	@Column(name="XRAY_DISTANCE")
	public String getXrayDistance() {
		return this.xrayDistance;
	}

	public void setXrayDistance(String xrayDistance) {
		this.xrayDistance = xrayDistance;
	}


	@Column(name="XRAY_GUBUN")
	public String getXrayGubun() {
		return this.xrayGubun;
	}

	public void setXrayGubun(String xrayGubun) {
		this.xrayGubun = xrayGubun;
	}


	@Column(name="XRAY_NAME")
	public String getXrayName() {
		return this.xrayName;
	}

	public void setXrayName(String xrayName) {
		this.xrayName = xrayName;
	}


	@Column(name="XRAY_NAME2")
	public String getXrayName2() {
		return this.xrayName2;
	}

	public void setXrayName2(String xrayName2) {
		this.xrayName2 = xrayName2;
	}


	@Column(name="XRAY_REAL_CNT")
	public Double getXrayRealCnt() {
		return this.xrayRealCnt;
	}

	public void setXrayRealCnt(Double xrayRealCnt) {
		this.xrayRealCnt = xrayRealCnt;
	}


	@Column(name="XRAY_RIGHT")
	public String getXrayRight() {
		return this.xrayRight;
	}

	public void setXrayRight(String xrayRight) {
		this.xrayRight = xrayRight;
	}


	@Column(name="XRAY_ROOM")
	public String getXrayRoom() {
		return this.xrayRoom;
	}

	public void setXrayRoom(String xrayRoom) {
		this.xrayRoom = xrayRoom;
	}


	@Column(name="XRAY_ROOM_INP")
	public String getXrayRoomInp() {
		return this.xrayRoomInp;
	}

	public void setXrayRoomInp(String xrayRoomInp) {
		this.xrayRoomInp = xrayRoomInp;
	}


	@Column(name="XRAY_TIME")
	public String getXrayTime() {
		return this.xrayTime;
	}

	public void setXrayTime(String xrayTime) {
		this.xrayTime = xrayTime;
	}


	@Column(name="XRAY_WAY")
	public String getXrayWay() {
		return this.xrayWay;
	}

	public void setXrayWay(String xrayWay) {
		this.xrayWay = xrayWay;
	}


	@Column(name="XRT_GROUP")
	public String getXrtGroup() {
		return this.xrtGroup;
	}

	public void setXrtGroup(String xrtGroup) {
		this.xrtGroup = xrtGroup;
	}

}