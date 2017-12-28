package nta.med.core.domain.xrt;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the XRT0123 database table.
 * 
 */
@Entity
@Table(name="XRT0123")
public class Xrt0123 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String buwiCode;
	private Double curElectric;
	private Double distance;
	private Double fromAge;
	private String grid;
	private String hospCode;
	private Double masVal;
	private String note;
	private Date sysDate;
	private String sysId;
	private Double time;
	private Double toAge;
	private Date updDate;
	private String updId;
	private Double valtage;
	private String xrayGubun;

	public Xrt0123() {
	}


	@Column(name="BUWI_CODE")
	public String getBuwiCode() {
		return this.buwiCode;
	}

	public void setBuwiCode(String buwiCode) {
		this.buwiCode = buwiCode;
	}


	@Column(name="CUR_ELECTRIC")
	public Double getCurElectric() {
		return this.curElectric;
	}

	public void setCurElectric(Double curElectric) {
		this.curElectric = curElectric;
	}


	public Double getDistance() {
		return this.distance;
	}

	public void setDistance(Double distance) {
		this.distance = distance;
	}


	@Column(name="FROM_AGE")
	public Double getFromAge() {
		return this.fromAge;
	}

	public void setFromAge(Double fromAge) {
		this.fromAge = fromAge;
	}


	public String getGrid() {
		return this.grid;
	}

	public void setGrid(String grid) {
		this.grid = grid;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MAS_VAL")
	public Double getMasVal() {
		return this.masVal;
	}

	public void setMasVal(Double masVal) {
		this.masVal = masVal;
	}


	public String getNote() {
		return this.note;
	}

	public void setNote(String note) {
		this.note = note;
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


	public Double getTime() {
		return this.time;
	}

	public void setTime(Double time) {
		this.time = time;
	}


	@Column(name="TO_AGE")
	public Double getToAge() {
		return this.toAge;
	}

	public void setToAge(Double toAge) {
		this.toAge = toAge;
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


	public Double getValtage() {
		return this.valtage;
	}

	public void setValtage(Double valtage) {
		this.valtage = valtage;
	}


	@Column(name="XRAY_GUBUN")
	public String getXrayGubun() {
		return this.xrayGubun;
	}

	public void setXrayGubun(String xrayGubun) {
		this.xrayGubun = xrayGubun;
	}

}