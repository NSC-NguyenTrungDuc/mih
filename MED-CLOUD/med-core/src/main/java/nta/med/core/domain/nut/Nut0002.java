package nta.med.core.domain.nut;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUT0002 database table.
 * 
 */
@Entity
@Table(name="NUT0002")
public class Nut0002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String dataKubun;
	private Double fknut0001;
	private Double fkoutsang;
	private String hospCode;
	private String ioKubun;
	private Double pknut0002;
	private Date sysDate;
	private Date updDate;
	private String userId;

	public Nut0002() {
	}


	@Column(name="DATA_KUBUN")
	public String getDataKubun() {
		return this.dataKubun;
	}

	public void setDataKubun(String dataKubun) {
		this.dataKubun = dataKubun;
	}


	public Double getFknut0001() {
		return this.fknut0001;
	}

	public void setFknut0001(Double fknut0001) {
		this.fknut0001 = fknut0001;
	}


	public Double getFkoutsang() {
		return this.fkoutsang;
	}

	public void setFkoutsang(Double fkoutsang) {
		this.fkoutsang = fkoutsang;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IO_KUBUN")
	public String getIoKubun() {
		return this.ioKubun;
	}

	public void setIoKubun(String ioKubun) {
		this.ioKubun = ioKubun;
	}


	public Double getPknut0002() {
		return this.pknut0002;
	}

	public void setPknut0002(Double pknut0002) {
		this.pknut0002 = pknut0002;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}