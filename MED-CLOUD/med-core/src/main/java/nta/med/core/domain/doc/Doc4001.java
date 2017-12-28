package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC4001 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc4001.findAll", query="SELECT d FROM Doc4001 d")
public class Doc4001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Date certDate;
	private String certDoctor;
	private String certGubun;
	private String certGwa;
	private double fkdoc1001;
	private double fkinp1001;
	private double fkout1001;
	private String hospCode;
	private double pkdoc4001;
	private Date printDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Doc4001() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CERT_DATE")
	public Date getCertDate() {
		return this.certDate;
	}

	public void setCertDate(Date certDate) {
		this.certDate = certDate;
	}


	@Column(name="CERT_DOCTOR")
	public String getCertDoctor() {
		return this.certDoctor;
	}

	public void setCertDoctor(String certDoctor) {
		this.certDoctor = certDoctor;
	}


	@Column(name="CERT_GUBUN")
	public String getCertGubun() {
		return this.certGubun;
	}

	public void setCertGubun(String certGubun) {
		this.certGubun = certGubun;
	}


	@Column(name="CERT_GWA")
	public String getCertGwa() {
		return this.certGwa;
	}

	public void setCertGwa(String certGwa) {
		this.certGwa = certGwa;
	}


	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getPkdoc4001() {
		return this.pkdoc4001;
	}

	public void setPkdoc4001(double pkdoc4001) {
		this.pkdoc4001 = pkdoc4001;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PRINT_DATE")
	public Date getPrintDate() {
		return this.printDate;
	}

	public void setPrintDate(Date printDate) {
		this.printDate = printDate;
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


	public String getVald() {
		return this.vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

}