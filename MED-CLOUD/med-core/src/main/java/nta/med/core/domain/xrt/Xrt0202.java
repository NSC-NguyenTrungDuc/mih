package nta.med.core.domain.xrt;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the XRT0202 database table.
 * 
 */
@Entity
//@NamedQuery(name="Xrt0202.findAll", query="SELECT x FROM Xrt0202 x")
@Table(name ="XRT0202")
public class Xrt0202 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double fkxrt0201;
	private String hospCode;
	private String irradiationTime;
	private Date sysDate;
	private String tubeCur;
	private String tubeCurTime;
	private String tubeVol;
	private Date updDate;
	private String updId;
	private String xrayCodeIdx;
	private String xrayCodeIdxNm;
	private String xrayDistance;
	private String xrayTime;

	public Xrt0202() {
	}


	public Double getFkxrt0201() {
		return this.fkxrt0201;
	}

	public void setFkxrt0201(Double fkxrt0201) {
		this.fkxrt0201 = fkxrt0201;
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


	@Column(name="XRAY_TIME")
	public String getXrayTime() {
		return this.xrayTime;
	}

	public void setXrayTime(String xrayTime) {
		this.xrayTime = xrayTime;
	}

}