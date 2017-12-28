package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC1007 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc1007.findAll", query="SELECT d FROM Doc1007 d")
public class Doc1007 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String baseDisease;
	private String bunho;
	private String causeGyunYn;
	private String docGubun;
	private String doctor;
	private String doctorName;
	private String gwa;
	private String gyunName;
	private String hoDong1;
	private String hospCode;
	private String infectionSign;
	private Date issueDate;
	private String orderSayu;
	private double pkdoc1007;
	private String resident;
	private String residentName;
	private String suname;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Date useReserDate;

	public Doc1007() {
	}


	@Column(name="BASE_DISEASE")
	public String getBaseDisease() {
		return this.baseDisease;
	}

	public void setBaseDisease(String baseDisease) {
		this.baseDisease = baseDisease;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CAUSE_GYUN_YN")
	public String getCauseGyunYn() {
		return this.causeGyunYn;
	}

	public void setCauseGyunYn(String causeGyunYn) {
		this.causeGyunYn = causeGyunYn;
	}


	@Column(name="DOC_GUBUN")
	public String getDocGubun() {
		return this.docGubun;
	}

	public void setDocGubun(String docGubun) {
		this.docGubun = docGubun;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DOCTOR_NAME")
	public String getDoctorName() {
		return this.doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GYUN_NAME")
	public String getGyunName() {
		return this.gyunName;
	}

	public void setGyunName(String gyunName) {
		this.gyunName = gyunName;
	}


	@Column(name="HO_DONG1")
	public String getHoDong1() {
		return this.hoDong1;
	}

	public void setHoDong1(String hoDong1) {
		this.hoDong1 = hoDong1;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INFECTION_SIGN")
	public String getInfectionSign() {
		return this.infectionSign;
	}

	public void setInfectionSign(String infectionSign) {
		this.infectionSign = infectionSign;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ISSUE_DATE")
	public Date getIssueDate() {
		return this.issueDate;
	}

	public void setIssueDate(Date issueDate) {
		this.issueDate = issueDate;
	}


	@Column(name="ORDER_SAYU")
	public String getOrderSayu() {
		return this.orderSayu;
	}

	public void setOrderSayu(String orderSayu) {
		this.orderSayu = orderSayu;
	}


	public double getPkdoc1007() {
		return this.pkdoc1007;
	}

	public void setPkdoc1007(double pkdoc1007) {
		this.pkdoc1007 = pkdoc1007;
	}


	public String getResident() {
		return this.resident;
	}

	public void setResident(String resident) {
		this.resident = resident;
	}


	@Column(name="RESIDENT_NAME")
	public String getResidentName() {
		return this.residentName;
	}

	public void setResidentName(String residentName) {
		this.residentName = residentName;
	}


	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="USE_RESER_DATE")
	public Date getUseReserDate() {
		return this.useReserDate;
	}

	public void setUseReserDate(Date useReserDate) {
		this.useReserDate = useReserDate;
	}

}