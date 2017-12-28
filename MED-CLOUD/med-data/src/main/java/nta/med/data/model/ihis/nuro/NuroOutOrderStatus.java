package nta.med.data.model.ihis.nuro;

import java.math.BigInteger;
import java.sql.Timestamp;

/**
 * @author HOANGPM
 *
 */
public class NuroOutOrderStatus {
	private Double pkOut1001;
	private String patientCode;
	private String patientName;
	private String receptionTime;
	private Timestamp comingStatusDate;
	private String reserYn;
	private String deptCode;
	private String doctorCode;
	private String deptName;
	private String doctorName;
	private String receptionType;
	private String completeExamination;
	private BigInteger numberOfItemsReq;
	private String actingPer;
	private String allEndYn;
	private String actingTime;
	private String dataEndYn;

	public NuroOutOrderStatus(Double pkOut1001, String patientCode,
			String patientName, String receptionTime,
			Timestamp comingStatusDate, String reserYn, String deptCode,
			String doctorCode, String deptName, String doctorName,
			String receptionType, String completeExamination,
			BigInteger numberOfItemsReq, String actingPer, String allEndYn,
			String actingTime, String dataEndYn) {
		super();
		this.pkOut1001 = pkOut1001;
		this.patientCode = patientCode;
		this.patientName = patientName;
		this.receptionTime = receptionTime;
		this.comingStatusDate = comingStatusDate;
		this.reserYn = reserYn;
		this.deptCode = deptCode;
		this.doctorCode = doctorCode;
		this.deptName = deptName;
		this.doctorName = doctorName;
		this.receptionType = receptionType;
		this.completeExamination = completeExamination;
		this.numberOfItemsReq = numberOfItemsReq;
		this.actingPer = actingPer;
		this.allEndYn = allEndYn;
		this.actingTime = actingTime;
		this.dataEndYn = dataEndYn;
	}

	public Double getPkOut1001() {
		return pkOut1001;
	}

	public void setPkOut1001(Double pkOut1001) {
		this.pkOut1001 = pkOut1001;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getReceptionTime() {
		return receptionTime;
	}

	public void setReceptionTime(String receptionTime) {
		this.receptionTime = receptionTime;
	}

	public Timestamp getComingStatusDate() {
		return comingStatusDate;
	}

	public void setComingStatusDate(Timestamp comingStatusDate) {
		this.comingStatusDate = comingStatusDate;
	}

	public String getReserYn() {
		return reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}

	public String getDeptCode() {
		return deptCode;
	}

	public void setDeptCode(String deptCode) {
		this.deptCode = deptCode;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	public String getDeptName() {
		return deptName;
	}

	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getReceptionType() {
		return receptionType;
	}

	public void setReceptionType(String receptionType) {
		this.receptionType = receptionType;
	}

	public String getCompleteExamination() {
		return completeExamination;
	}

	public void setCompleteExamination(String completeExamination) {
		this.completeExamination = completeExamination;
	}

	public BigInteger getNumberOfItemsReq() {
		return numberOfItemsReq;
	}

	public void setNumberOfItemsReq(BigInteger numberOfItemsReq) {
		this.numberOfItemsReq = numberOfItemsReq;
	}

	public String getActingPer() {
		return actingPer;
	}

	public void setActingPer(String actingPer) {
		this.actingPer = actingPer;
	}

	public String getAllEndYn() {
		return allEndYn;
	}

	public void setAllEndYn(String allEndYn) {
		this.allEndYn = allEndYn;
	}

	public String getActingTime() {
		return actingTime;
	}

	public void setActingTime(String actingTime) {
		this.actingTime = actingTime;
	}

	public String getDataEndYn() {
		return dataEndYn;
	}

	public void setDataEndYn(String dataEndYn) {
		this.dataEndYn = dataEndYn;
	}

}