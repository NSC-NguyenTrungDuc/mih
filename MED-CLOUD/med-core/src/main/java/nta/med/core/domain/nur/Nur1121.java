package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1121 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1121.findAll", query="SELECT n FROM Nur1121 n")
public class Nur1121 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String valid;
	private String watchGwa;
	private String watchHangmog;

	public Nur1121() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="SORT_KEY")
	public double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(double sortKey) {
		this.sortKey = sortKey;
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


	public String getValid() {
		return this.valid;
	}

	public void setValid(String valid) {
		this.valid = valid;
	}


	@Column(name="WATCH_GWA")
	public String getWatchGwa() {
		return this.watchGwa;
	}

	public void setWatchGwa(String watchGwa) {
		this.watchGwa = watchGwa;
	}


	@Column(name="WATCH_HANGMOG")
	public String getWatchHangmog() {
		return this.watchHangmog;
	}

	public void setWatchHangmog(String watchHangmog) {
		this.watchHangmog = watchHangmog;
	}

}