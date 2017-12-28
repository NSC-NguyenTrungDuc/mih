package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR1014 database table.
 * 
 */
@Entity
@Table(name = "NUR1014")
public class Nur1014 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String destAddr;
	private String destIshome;
	private String destTel;
	private Double fkinp1001;
	private String hospCode;
	private Date ifDataSendDate;
	private String ifDataSendYn;
	private Date inHopeDate;
	private String inHopeTime;
	private Date inTrueDate;
	private String inTrueTime;
	private Date nutEndDate;
	private String nutEndKini;
	private String nutEndYn;
	private Date nutStartDate;
	private String nutStartKini;
	private Date outDate;
	private String outObject;
	private String outTime;
	private Date sunabInDate;
	private Date sunabOutDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String woichulWoibakGubun;

	public Nur1014() {
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "DEST_ADDR")
	public String getDestAddr() {
		return this.destAddr;
	}

	public void setDestAddr(String destAddr) {
		this.destAddr = destAddr;
	}

	@Column(name = "DEST_ISHOME")
	public String getDestIshome() {
		return this.destIshome;
	}

	public void setDestIshome(String destIshome) {
		this.destIshome = destIshome;
	}

	@Column(name = "DEST_TEL")
	public String getDestTel() {
		return this.destTel;
	}

	public void setDestTel(String destTel) {
		this.destTel = destTel;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "IF_DATA_SEND_DATE")
	public Date getIfDataSendDate() {
		return this.ifDataSendDate;
	}

	public void setIfDataSendDate(Date ifDataSendDate) {
		this.ifDataSendDate = ifDataSendDate;
	}

	@Column(name = "IF_DATA_SEND_YN")
	public String getIfDataSendYn() {
		return this.ifDataSendYn;
	}

	public void setIfDataSendYn(String ifDataSendYn) {
		this.ifDataSendYn = ifDataSendYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "IN_HOPE_DATE")
	public Date getInHopeDate() {
		return this.inHopeDate;
	}

	public void setInHopeDate(Date inHopeDate) {
		this.inHopeDate = inHopeDate;
	}

	@Column(name = "IN_HOPE_TIME")
	public String getInHopeTime() {
		return this.inHopeTime;
	}

	public void setInHopeTime(String inHopeTime) {
		this.inHopeTime = inHopeTime;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "IN_TRUE_DATE")
	public Date getInTrueDate() {
		return this.inTrueDate;
	}

	public void setInTrueDate(Date inTrueDate) {
		this.inTrueDate = inTrueDate;
	}

	@Column(name = "IN_TRUE_TIME")
	public String getInTrueTime() {
		return this.inTrueTime;
	}

	public void setInTrueTime(String inTrueTime) {
		this.inTrueTime = inTrueTime;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "NUT_END_DATE")
	public Date getNutEndDate() {
		return this.nutEndDate;
	}

	public void setNutEndDate(Date nutEndDate) {
		this.nutEndDate = nutEndDate;
	}

	@Column(name = "NUT_END_KINI")
	public String getNutEndKini() {
		return this.nutEndKini;
	}

	public void setNutEndKini(String nutEndKini) {
		this.nutEndKini = nutEndKini;
	}

	@Column(name = "NUT_END_YN")
	public String getNutEndYn() {
		return this.nutEndYn;
	}

	public void setNutEndYn(String nutEndYn) {
		this.nutEndYn = nutEndYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "NUT_START_DATE")
	public Date getNutStartDate() {
		return this.nutStartDate;
	}

	public void setNutStartDate(Date nutStartDate) {
		this.nutStartDate = nutStartDate;
	}

	@Column(name = "NUT_START_KINI")
	public String getNutStartKini() {
		return this.nutStartKini;
	}

	public void setNutStartKini(String nutStartKini) {
		this.nutStartKini = nutStartKini;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "OUT_DATE")
	public Date getOutDate() {
		return this.outDate;
	}

	public void setOutDate(Date outDate) {
		this.outDate = outDate;
	}

	@Column(name = "OUT_OBJECT")
	public String getOutObject() {
		return this.outObject;
	}

	public void setOutObject(String outObject) {
		this.outObject = outObject;
	}

	@Column(name = "OUT_TIME")
	public String getOutTime() {
		return this.outTime;
	}

	public void setOutTime(String outTime) {
		this.outTime = outTime;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SUNAB_IN_DATE")
	public Date getSunabInDate() {
		return this.sunabInDate;
	}

	public void setSunabInDate(Date sunabInDate) {
		this.sunabInDate = sunabInDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SUNAB_OUT_DATE")
	public Date getSunabOutDate() {
		return this.sunabOutDate;
	}

	public void setSunabOutDate(Date sunabOutDate) {
		this.sunabOutDate = sunabOutDate;
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

	@Column(name = "WOICHUL_WOIBAK_GUBUN")
	public String getWoichulWoibakGubun() {
		return this.woichulWoibakGubun;
	}

	public void setWoichulWoibakGubun(String woichulWoibakGubun) {
		this.woichulWoibakGubun = woichulWoibakGubun;
	}

}