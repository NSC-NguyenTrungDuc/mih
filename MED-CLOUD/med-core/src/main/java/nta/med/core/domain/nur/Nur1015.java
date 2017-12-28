package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1015 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1015.findAll", query="SELECT n FROM Nur1015 n")
public class Nur1015 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bigo;
	private String bunho;
	private String chamgaja;
	private double fkinp1001;
	private Date girokDate;
	private String hospCode;
	private String note;
	private double seq;
	private Date sysDate;
	private String sysId;
	private String tema;
	private Date updDate;
	private String updId;

	public Nur1015() {
	}


	public String getBigo() {
		return this.bigo;
	}

	public void setBigo(String bigo) {
		this.bigo = bigo;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getChamgaja() {
		return this.chamgaja;
	}

	public void setChamgaja(String chamgaja) {
		this.chamgaja = chamgaja;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GIROK_DATE")
	public Date getGirokDate() {
		return this.girokDate;
	}

	public void setGirokDate(Date girokDate) {
		this.girokDate = girokDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getNote() {
		return this.note;
	}

	public void setNote(String note) {
		this.note = note;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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


	public String getTema() {
		return this.tema;
	}

	public void setTema(String tema) {
		this.tema = tema;
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