package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR8003 database table.
 * 
 */
@Entity
@Table(name = "NUR8003")
public class Nur8003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String firstGubun;
	private Double fkinp1001;
	private String grCode;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Date writeDate;
	private String writeHodong;
	private String hFileString;

	public Nur8003() {
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "FIRST_GUBUN")
	public String getFirstGubun() {
		return this.firstGubun;
	}

	public void setFirstGubun(String firstGubun) {
		this.firstGubun = firstGubun;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Column(name = "GR_CODE")
	public String getGrCode() {
		return this.grCode;
	}

	public void setGrCode(String grCode) {
		this.grCode = grCode;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "WRITE_DATE")
	public Date getWriteDate() {
		return this.writeDate;
	}

	public void setWriteDate(Date writeDate) {
		this.writeDate = writeDate;
	}

	@Column(name = "WRITE_HODONG")
	public String getWriteHodong() {
		return this.writeHodong;
	}

	public void setWriteHodong(String writeHodong) {
		this.writeHodong = writeHodong;
	}

	@Column(name = "H_FILE_STRING")
	public String gethFileString() {
		return hFileString;
	}

	public void sethFileString(String hFileString) {
		this.hFileString = hFileString;
	}

}