package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0601 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0601.findAll", query="SELECT c FROM Cpl0601 c")
public class Cpl0601 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bloodSungbun;
	private double danga;
	private String displayYn;
	private String hospCode;
	private double norm;
	private String plaqueYn;
	private double seq;
	private String sungbunCode;
	private String sungbunName;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private double yuhyo;

	public Cpl0601() {
	}


	@Column(name="BLOOD_SUNGBUN")
	public String getBloodSungbun() {
		return this.bloodSungbun;
	}

	public void setBloodSungbun(String bloodSungbun) {
		this.bloodSungbun = bloodSungbun;
	}


	public double getDanga() {
		return this.danga;
	}

	public void setDanga(double danga) {
		this.danga = danga;
	}


	@Column(name="DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getNorm() {
		return this.norm;
	}

	public void setNorm(double norm) {
		this.norm = norm;
	}


	@Column(name="PLAQUE_YN")
	public String getPlaqueYn() {
		return this.plaqueYn;
	}

	public void setPlaqueYn(String plaqueYn) {
		this.plaqueYn = plaqueYn;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="SUNGBUN_CODE")
	public String getSungbunCode() {
		return this.sungbunCode;
	}

	public void setSungbunCode(String sungbunCode) {
		this.sungbunCode = sungbunCode;
	}


	@Column(name="SUNGBUN_NAME")
	public String getSungbunName() {
		return this.sungbunName;
	}

	public void setSungbunName(String sungbunName) {
		this.sungbunName = sungbunName;
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


	public double getYuhyo() {
		return this.yuhyo;
	}

	public void setYuhyo(double yuhyo) {
		this.yuhyo = yuhyo;
	}

}