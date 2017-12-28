package nta.med.core.domain.xrt;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the XRT0002 database table.
 * 
 */
@Entity
@NamedQuery(name="Xrt0002.findAll", query="SELECT x FROM Xrt0002 x")
@Table(name="XRT0002")
public class Xrt0002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String irradiationTime;
	private Date sysDate;
	private String tubeCur;
	private String tubeCurTime;
	private String tubeVol;
	private Date updDate;
	private String updId;
	private String xrayCode;
	private String xrayCodeIdx;
	private String xrayCodeIdxNm;
	private String xrayDistance;
	private String xrayGubun;
	private String xrayTime;

	public Xrt0002() {
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
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


	@Column(name="XRAY_CODE")
	public String getXrayCode() {
		return this.xrayCode;
	}

	public void setXrayCode(String xrayCode) {
		this.xrayCode = xrayCode;
	}


	@Column(name="XRAY_CODE_IDX")
	public String getXrayCodeIdx() {
		return this.xrayCodeIdx;
	}

	public void setXrayCodeIdx(String xrayCodeIdx) {
		this.xrayCodeIdx = xrayCodeIdx;
	}


	@Column(name="XRAY_CODE_IDX_NM")
	public String getXrayCodeIdxNm() {
		return this.xrayCodeIdxNm;
	}

	public void setXrayCodeIdxNm(String xrayCodeIdxNm) {
		this.xrayCodeIdxNm = xrayCodeIdxNm;
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


	@Column(name="XRAY_TIME")
	public String getXrayTime() {
		return this.xrayTime;
	}

	public void setXrayTime(String xrayTime) {
		this.xrayTime = xrayTime;
	}

}