package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1009 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1009.findAll", query="SELECT n FROM Nur1009 n")
public class Nur1009 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double fkinp1001;
	private Date girokDate;
	private String hospCode;
	private String imsinBunmanSanyok;
	private String jaeteJusu;
	private double seq;
	private String sex;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private double weight;

	public Nur1009() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
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


	@Column(name="IMSIN_BUNMAN_SANYOK")
	public String getImsinBunmanSanyok() {
		return this.imsinBunmanSanyok;
	}

	public void setImsinBunmanSanyok(String imsinBunmanSanyok) {
		this.imsinBunmanSanyok = imsinBunmanSanyok;
	}


	@Column(name="JAETE_JUSU")
	public String getJaeteJusu() {
		return this.jaeteJusu;
	}

	public void setJaeteJusu(String jaeteJusu) {
		this.jaeteJusu = jaeteJusu;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
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


	public double getWeight() {
		return this.weight;
	}

	public void setWeight(double weight) {
		this.weight = weight;
	}

}