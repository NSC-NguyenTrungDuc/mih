package nta.med.core.domain.res;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the RES0106 database table.
 * 
 */
@Entity
@NamedQuery(name="Res0106.findAll", query="SELECT r FROM Res0106 r")
public class Res0106 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date sysDate;
	private String sysId;
	private String time;
	private String timeTerm;
	private Date updDate;
	private String updId;

	public Res0106() {
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


	public String getTime() {
		return this.time;
	}

	public void setTime(String time) {
		this.time = time;
	}


	@Column(name="TIME_TERM")
	public String getTimeTerm() {
		return this.timeTerm;
	}

	public void setTimeTerm(String timeTerm) {
		this.timeTerm = timeTerm;
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