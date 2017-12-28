package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0125 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0125.findAll", query="SELECT c FROM Cpl0125 c")
public class Cpl0125 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String emergency;
	private String gumsaCode;
	private String hospCode;
	private String jundalGubun;
	private String seqCode;
	private double serial;
	private String specimenCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl0125() {
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	@Column(name="GUMSA_CODE")
	public String getGumsaCode() {
		return this.gumsaCode;
	}

	public void setGumsaCode(String gumsaCode) {
		this.gumsaCode = gumsaCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUNDAL_GUBUN")
	public String getJundalGubun() {
		return this.jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}


	@Column(name="SEQ_CODE")
	public String getSeqCode() {
		return this.seqCode;
	}

	public void setSeqCode(String seqCode) {
		this.seqCode = seqCode;
	}


	public double getSerial() {
		return this.serial;
	}

	public void setSerial(double serial) {
		this.serial = serial;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
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