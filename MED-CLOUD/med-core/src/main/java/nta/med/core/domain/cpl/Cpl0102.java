package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0102 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0102.findAll", query="SELECT c FROM Cpl0102 c")
public class Cpl0102 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String emergency;
	private String hangmogCode;
	private String hospCode;
	private String irradiationYn;
	private String specimenCode;
	private String sungbunCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl0102() {
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IRRADIATION_YN")
	public String getIrradiationYn() {
		return this.irradiationYn;
	}

	public void setIrradiationYn(String irradiationYn) {
		this.irradiationYn = irradiationYn;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	@Column(name="SUNGBUN_CODE")
	public String getSungbunCode() {
		return this.sungbunCode;
	}

	public void setSungbunCode(String sungbunCode) {
		this.sungbunCode = sungbunCode;
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

}