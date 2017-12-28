package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS6010 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs6010.findAll", query="SELECT o FROM Ocs6010 o")
public class Ocs6010 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date appDate;
	private String bunho;
	private String cpCode;
	private String cpEndCode;
	private Date cpEndDate;
	private String cpEndYn;
	private String cpName;
	private String cpYn;
	private String doctor;
	private double fkinp1001;
	private String gwa;
	private String hospCode;
	private String inputId;
	private String memb;
	private String ordOccurGubun;
	private double pkocs6010;
	private String remark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs6010() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="APP_DATE")
	public Date getAppDate() {
		return this.appDate;
	}

	public void setAppDate(Date appDate) {
		this.appDate = appDate;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CP_CODE")
	public String getCpCode() {
		return this.cpCode;
	}

	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}


	@Column(name="CP_END_CODE")
	public String getCpEndCode() {
		return this.cpEndCode;
	}

	public void setCpEndCode(String cpEndCode) {
		this.cpEndCode = cpEndCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CP_END_DATE")
	public Date getCpEndDate() {
		return this.cpEndDate;
	}

	public void setCpEndDate(Date cpEndDate) {
		this.cpEndDate = cpEndDate;
	}


	@Column(name="CP_END_YN")
	public String getCpEndYn() {
		return this.cpEndYn;
	}

	public void setCpEndYn(String cpEndYn) {
		this.cpEndYn = cpEndYn;
	}


	@Column(name="CP_NAME")
	public String getCpName() {
		return this.cpName;
	}

	public void setCpName(String cpName) {
		this.cpName = cpName;
	}


	@Column(name="CP_YN")
	public String getCpYn() {
		return this.cpYn;
	}

	public void setCpYn(String cpYn) {
		this.cpYn = cpYn;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}


	public String getMemb() {
		return this.memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}


	@Column(name="ORD_OCCUR_GUBUN")
	public String getOrdOccurGubun() {
		return this.ordOccurGubun;
	}

	public void setOrdOccurGubun(String ordOccurGubun) {
		this.ordOccurGubun = ordOccurGubun;
	}


	public double getPkocs6010() {
		return this.pkocs6010;
	}

	public void setPkocs6010(double pkocs6010) {
		this.pkocs6010 = pkocs6010;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
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