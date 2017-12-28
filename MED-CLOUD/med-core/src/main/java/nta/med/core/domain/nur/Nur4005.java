package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR4005 database table.
 * 
 */
@Entity
@Table(name = "NUR4005")
public class Nur4005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double fknur4001;
	private String gubun;
	private String hospCode;
	private Date reserDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String valuContents;
	private Date valuDate;
	private String valuer;

	public Nur4005() {
	}

	public Double getFknur4001() {
		return this.fknur4001;
	}

	public void setFknur4001(Double fknur4001) {
		this.fknur4001 = fknur4001;
	}

	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "RESER_DATE")
	public Date getReserDate() {
		return this.reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "VALU_CONTENTS")
	public String getValuContents() {
		return this.valuContents;
	}

	public void setValuContents(String valuContents) {
		this.valuContents = valuContents;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "VALU_DATE")
	public Date getValuDate() {
		return this.valuDate;
	}

	public void setValuDate(Date valuDate) {
		this.valuDate = valuDate;
	}

	public String getValuer() {
		return this.valuer;
	}

	public void setValuer(String valuer) {
		this.valuer = valuer;
	}

}