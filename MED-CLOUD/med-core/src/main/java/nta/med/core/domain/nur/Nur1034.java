package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1034 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1034.findAll", query="SELECT n FROM Nur1034 n")
public class Nur1034 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bigo;
	private String bunho;
	private Date gugubBansongDate;
	private String gugubBansongTime;
	private String gwa;
	private String hochul;
	private String hospCode;
	private String jindanName;
	private double pknur1034;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1034() {
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUGUB_BANSONG_DATE")
	public Date getGugubBansongDate() {
		return this.gugubBansongDate;
	}

	public void setGugubBansongDate(Date gugubBansongDate) {
		this.gugubBansongDate = gugubBansongDate;
	}


	@Column(name="GUGUB_BANSONG_TIME")
	public String getGugubBansongTime() {
		return this.gugubBansongTime;
	}

	public void setGugubBansongTime(String gugubBansongTime) {
		this.gugubBansongTime = gugubBansongTime;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	public String getHochul() {
		return this.hochul;
	}

	public void setHochul(String hochul) {
		this.hochul = hochul;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JINDAN_NAME")
	public String getJindanName() {
		return this.jindanName;
	}

	public void setJindanName(String jindanName) {
		this.jindanName = jindanName;
	}


	public double getPknur1034() {
		return this.pknur1034;
	}

	public void setPknur1034(double pknur1034) {
		this.pknur1034 = pknur1034;
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