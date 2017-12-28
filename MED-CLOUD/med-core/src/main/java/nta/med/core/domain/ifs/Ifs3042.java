package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS3042 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs3042.findAll", query="SELECT i FROM Ifs3042 i")
public class Ifs3042 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fkifs3041;
	private String hospCode;
	private double ilja;
	private String jo;
	private String ju;
	private String seok;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs3042() {
	}


	public double getFkifs3041() {
		return this.fkifs3041;
	}

	public void setFkifs3041(double fkifs3041) {
		this.fkifs3041 = fkifs3041;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getIlja() {
		return this.ilja;
	}

	public void setIlja(double ilja) {
		this.ilja = ilja;
	}


	public String getJo() {
		return this.jo;
	}

	public void setJo(String jo) {
		this.jo = jo;
	}


	public String getJu() {
		return this.ju;
	}

	public void setJu(String ju) {
		this.ju = ju;
	}


	public String getSeok() {
		return this.seok;
	}

	public void setSeok(String seok) {
		this.seok = seok;
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