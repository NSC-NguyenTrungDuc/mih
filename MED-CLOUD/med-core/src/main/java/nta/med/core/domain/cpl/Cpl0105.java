package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0105 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0105.findAll", query="SELECT c FROM Cpl0105 c")
public class Cpl0105 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String emergency;
	private double fromAge;
	private double fromPanicValue;
	private String fromValue;
	private String hangmogCode;
	private String hospCode;
	private String naiFrom;
	private String naiTo;
	private String sex;
	private String specimenCode;
	private Date sysDate;
	private String sysId;
	private double toAge;
	private double toPanicValue;
	private String toValue;
	private Date updDate;
	private String updId;

	public Cpl0105() {
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	@Column(name="FROM_AGE")
	public double getFromAge() {
		return this.fromAge;
	}

	public void setFromAge(double fromAge) {
		this.fromAge = fromAge;
	}


	@Column(name="FROM_PANIC_VALUE")
	public double getFromPanicValue() {
		return this.fromPanicValue;
	}

	public void setFromPanicValue(double fromPanicValue) {
		this.fromPanicValue = fromPanicValue;
	}


	@Column(name="FROM_VALUE")
	public String getFromValue() {
		return this.fromValue;
	}

	public void setFromValue(String fromValue) {
		this.fromValue = fromValue;
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


	@Column(name="NAI_FROM")
	public String getNaiFrom() {
		return this.naiFrom;
	}

	public void setNaiFrom(String naiFrom) {
		this.naiFrom = naiFrom;
	}


	@Column(name="NAI_TO")
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


	@Column(name="TO_AGE")
	public double getToAge() {
		return this.toAge;
	}

	public void setToAge(double toAge) {
		this.toAge = toAge;
	}


	@Column(name="TO_PANIC_VALUE")
	public double getToPanicValue() {
		return this.toPanicValue;
	}

	public void setToPanicValue(double toPanicValue) {
		this.toPanicValue = toPanicValue;
	}


	@Column(name="TO_VALUE")
	public String getToValue() {
		return this.toValue;
	}

	public void setToValue(String toValue) {
		this.toValue = toValue;
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