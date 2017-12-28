package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF4001 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif4001.findAll", query="SELECT o FROM Oif4001 o")
public class Oif4001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String appTime;
	private String cmId;
	private String depId;
	private String docUid;
	private String doctor;
	private String endFlag;
	private String errMsg;
	private double fkoif1101;
	private String gwa;
	private String hospCode;
	private String insurGubun;
	private String ioFlag;
	private String license;
	private String orderTime;
	private String performTime;
	private double pkoif4001;
	private String registTime;
	private Date sendDate;
	private String status;
	private Date sysDate;
	private String sysId;
	private String timeClass;
	private Date updDate;
	private String updId;
	private String uuid;
	private String wardId;

	public Oif4001() {
	}


	@Column(name="APP_TIME")
	public String getAppTime() {
		return this.appTime;
	}

	public void setAppTime(String appTime) {
		this.appTime = appTime;
	}


	@Column(name="CM_ID")
	public String getCmId() {
		return this.cmId;
	}

	public void setCmId(String cmId) {
		this.cmId = cmId;
	}


	@Column(name="DEP_ID")
	public String getDepId() {
		return this.depId;
	}

	public void setDepId(String depId) {
		this.depId = depId;
	}


	@Column(name="DOC_UID")
	public String getDocUid() {
		return this.docUid;
	}

	public void setDocUid(String docUid) {
		this.docUid = docUid;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="END_FLAG")
	public String getEndFlag() {
		return this.endFlag;
	}

	public void setEndFlag(String endFlag) {
		this.endFlag = endFlag;
	}


	@Column(name="ERR_MSG")
	public String getErrMsg() {
		return this.errMsg;
	}

	public void setErrMsg(String errMsg) {
		this.errMsg = errMsg;
	}


	public double getFkoif1101() {
		return this.fkoif1101;
	}

	public void setFkoif1101(double fkoif1101) {
		this.fkoif1101 = fkoif1101;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INSUR_GUBUN")
	public String getInsurGubun() {
		return this.insurGubun;
	}

	public void setInsurGubun(String insurGubun) {
		this.insurGubun = insurGubun;
	}


	@Column(name="IO_FLAG")
	public String getIoFlag() {
		return this.ioFlag;
	}

	public void setIoFlag(String ioFlag) {
		this.ioFlag = ioFlag;
	}


	public String getLicense() {
		return this.license;
	}

	public void setLicense(String license) {
		this.license = license;
	}


	@Column(name="ORDER_TIME")
	public String getOrderTime() {
		return this.orderTime;
	}

	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}


	@Column(name="PERFORM_TIME")
	public String getPerformTime() {
		return this.performTime;
	}

	public void setPerformTime(String performTime) {
		this.performTime = performTime;
	}


	public double getPkoif4001() {
		return this.pkoif4001;
	}

	public void setPkoif4001(double pkoif4001) {
		this.pkoif4001 = pkoif4001;
	}


	@Column(name="REGIST_TIME")
	public String getRegistTime() {
		return this.registTime;
	}

	public void setRegistTime(String registTime) {
		this.registTime = registTime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SEND_DATE")
	public Date getSendDate() {
		return this.sendDate;
	}

	public void setSendDate(Date sendDate) {
		this.sendDate = sendDate;
	}


	public String getStatus() {
		return this.status;
	}

	public void setStatus(String status) {
		this.status = status;
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


	@Column(name="TIME_CLASS")
	public String getTimeClass() {
		return this.timeClass;
	}

	public void setTimeClass(String timeClass) {
		this.timeClass = timeClass;
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


	public String getUuid() {
		return this.uuid;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}


	@Column(name="WARD_ID")
	public String getWardId() {
		return this.wardId;
	}

	public void setWardId(String wardId) {
		this.wardId = wardId;
	}

}