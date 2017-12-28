package nta.med.core.domain.cpl;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the CPL0104 database table.
 * 
 */
@Entity
@Table(name = "CPL0104")
public class Cpl0104 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String emergency;
	private double fromAge;
	private String fromStandard;
	private String hangmogCode;
	private String hospCode;
	private String naiFrom;
	private String naiTo;
	private String sex;
	private String specimenCode;
	private Date sysDate;
	private String sysId;
	private double toAge;
	private String toStandard;
	private Date updDate;
	private String updId;
	private String modifyFlg;

	public Cpl0104() {
	}

	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	@Column(name = "FROM_AGE")
	public double getFromAge() {
		return this.fromAge;
	}

	public void setFromAge(double fromAge) {
		this.fromAge = fromAge;
	}

	@Column(name = "FROM_STANDARD")
	public String getFromStandard() {
		return this.fromStandard;
	}

	public void setFromStandard(String fromStandard) {
		this.fromStandard = fromStandard;
	}

	@Column(name = "HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "NAI_FROM")
	public String getNaiFrom() {
		return this.naiFrom;
	}

	public void setNaiFrom(String naiFrom) {
		this.naiFrom = naiFrom;
	}

	@Column(name = "NAI_TO")
	public String getNaiTo() {
		return this.naiTo;
	}

	public void setNaiTo(String naiTo) {
		this.naiTo = naiTo;
	}

	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	@Column(name = "SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
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

	@Column(name = "TO_AGE")
	public double getToAge() {
		return this.toAge;
	}

	public void setToAge(double toAge) {
		this.toAge = toAge;
	}

	@Column(name = "TO_STANDARD")
	public String getToStandard() {
		return this.toStandard;
	}

	public void setToStandard(String toStandard) {
		this.toStandard = toStandard;
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

	@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}
}