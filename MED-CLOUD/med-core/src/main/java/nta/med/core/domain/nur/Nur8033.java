package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR8033 database table.
 * 
 */
@Entity
@Table(name = "NUR8033")
public class Nur8033 extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String bunho;
	private String firstGubun;
	private Double fkinp1001;
	private String grCode;
	private String hospCode;
	private Double newNurPoint;
	private String newSmCode;
	private String newSmDetail;
	private Double nurPoint;
	private String rsCode;
	private String smCode;
	private String smDetail;
	private String sumGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Date writeDate;
	private String writeHodong;

	public Nur8033() {
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

	@Column(name = "NEW_NUR_POINT")
	public Double getNewNurPoint() {
		return this.newNurPoint;
	}

	public void setNewNurPoint(Double newNurPoint) {
		this.newNurPoint = newNurPoint;
	}

	@Column(name = "NEW_SM_CODE")
	public String getNewSmCode() {
		return this.newSmCode;
	}

	public void setNewSmCode(String newSmCode) {
		this.newSmCode = newSmCode;
	}

	@Column(name = "NEW_SM_DETAIL")
	public String getNewSmDetail() {
		return this.newSmDetail;
	}

	public void setNewSmDetail(String newSmDetail) {
		this.newSmDetail = newSmDetail;
	}

	@Column(name = "NUR_POINT")
	public Double getNurPoint() {
		return this.nurPoint;
	}

	public void setNurPoint(Double nurPoint) {
		this.nurPoint = nurPoint;
	}

	@Column(name = "RS_CODE")
	public String getRsCode() {
		return this.rsCode;
	}

	public void setRsCode(String rsCode) {
		this.rsCode = rsCode;
	}

	@Column(name = "SM_CODE")
	public String getSmCode() {
		return this.smCode;
	}

	public void setSmCode(String smCode) {
		this.smCode = smCode;
	}

	@Column(name = "SM_DETAIL")
	public String getSmDetail() {
		return this.smDetail;
	}

	public void setSmDetail(String smDetail) {
		this.smDetail = smDetail;
	}

	@Column(name = "SUM_GUBUN")
	public String getSumGubun() {
		return this.sumGubun;
	}

	public void setSumGubun(String sumGubun) {
		this.sumGubun = sumGubun;
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

}