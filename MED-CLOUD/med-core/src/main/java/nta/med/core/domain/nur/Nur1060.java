package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1060 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1060.findAll", query="SELECT n FROM Nur1060 n")
public class Nur1060 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String dataGubun;
	private String doctor;
	private Date endDate;
	private String hospCode;
	private String jangbiCompany;
	private String jangbiKind;
	private double pknur1060;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1060() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DATA_GUBUN")
	public String getDataGubun() {
		return this.dataGubun;
	}

	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JANGBI_COMPANY")
	public String getJangbiCompany() {
		return this.jangbiCompany;
	}

	public void setJangbiCompany(String jangbiCompany) {
		this.jangbiCompany = jangbiCompany;
	}


	@Column(name="JANGBI_KIND")
	public String getJangbiKind() {
		return this.jangbiKind;
	}

	public void setJangbiKind(String jangbiKind) {
		this.jangbiKind = jangbiKind;
	}


	public double getPknur1060() {
		return this.pknur1060;
	}

	public void setPknur1060(double pknur1060) {
		this.pknur1060 = pknur1060;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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