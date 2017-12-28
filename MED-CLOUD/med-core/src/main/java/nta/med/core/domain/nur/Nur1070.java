package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1070 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1070.findAll", query="SELECT n FROM Nur1070 n")
public class Nur1070 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String doctor;
	private String hospCode;
	private Date noSmoking1;
	private String noSmoking1Yn;
	private Date noSmoking2;
	private String noSmoking2Yn;
	private Date noSmoking3;
	private String noSmoking3Yn;
	private Date noSmoking4;
	private String noSmoking4Yn;
	private Date noSmoking5;
	private String noSmoking5Yn;
	private double pknur1070;
	private String successYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1070() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NO_SMOKING_1")
	public Date getNoSmoking1() {
		return this.noSmoking1;
	}

	public void setNoSmoking1(Date noSmoking1) {
		this.noSmoking1 = noSmoking1;
	}


	@Column(name="NO_SMOKING_1_YN")
	public String getNoSmoking1Yn() {
		return this.noSmoking1Yn;
	}

	public void setNoSmoking1Yn(String noSmoking1Yn) {
		this.noSmoking1Yn = noSmoking1Yn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NO_SMOKING_2")
	public Date getNoSmoking2() {
		return this.noSmoking2;
	}

	public void setNoSmoking2(Date noSmoking2) {
		this.noSmoking2 = noSmoking2;
	}


	@Column(name="NO_SMOKING_2_YN")
	public String getNoSmoking2Yn() {
		return this.noSmoking2Yn;
	}

	public void setNoSmoking2Yn(String noSmoking2Yn) {
		this.noSmoking2Yn = noSmoking2Yn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NO_SMOKING_3")
	public Date getNoSmoking3() {
		return this.noSmoking3;
	}

	public void setNoSmoking3(Date noSmoking3) {
		this.noSmoking3 = noSmoking3;
	}


	@Column(name="NO_SMOKING_3_YN")
	public String getNoSmoking3Yn() {
		return this.noSmoking3Yn;
	}

	public void setNoSmoking3Yn(String noSmoking3Yn) {
		this.noSmoking3Yn = noSmoking3Yn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NO_SMOKING_4")
	public Date getNoSmoking4() {
		return this.noSmoking4;
	}

	public void setNoSmoking4(Date noSmoking4) {
		this.noSmoking4 = noSmoking4;
	}


	@Column(name="NO_SMOKING_4_YN")
	public String getNoSmoking4Yn() {
		return this.noSmoking4Yn;
	}

	public void setNoSmoking4Yn(String noSmoking4Yn) {
		this.noSmoking4Yn = noSmoking4Yn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NO_SMOKING_5")
	public Date getNoSmoking5() {
		return this.noSmoking5;
	}

	public void setNoSmoking5(Date noSmoking5) {
		this.noSmoking5 = noSmoking5;
	}


	@Column(name="NO_SMOKING_5_YN")
	public String getNoSmoking5Yn() {
		return this.noSmoking5Yn;
	}

	public void setNoSmoking5Yn(String noSmoking5Yn) {
		this.noSmoking5Yn = noSmoking5Yn;
	}


	public double getPknur1070() {
		return this.pknur1070;
	}

	public void setPknur1070(double pknur1070) {
		this.pknur1070 = pknur1070;
	}


	@Column(name="SUCCESS_YN")
	public String getSuccessYn() {
		return this.successYn;
	}

	public void setSuccessYn(String successYn) {
		this.successYn = successYn;
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