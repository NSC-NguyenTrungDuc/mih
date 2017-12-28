package nta.med.ext.mss.model;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author DEV-TiepNM
 */
public class ReservationModel {

    @JsonProperty("reservation_code")
    private String reservationCode;
    @JsonProperty("examination_date")
    private String examinationDate;
    @JsonProperty("examination_time")
    private String examinationTime;
    @JsonProperty("department_code")
    private String departmentCode;
    @JsonProperty("department_name")
    private String departmentName;
    @JsonProperty("patient_name")
    private String patientName;
    @JsonProperty("patient_code")
    private String patientCode;
    @JsonProperty("patient_name_kana")
    private String patientNameKana;
    @JsonProperty("doctor_code")
    private String doctorCode;
    @JsonProperty("doctor_name")
    private String doctorName;
    @JsonProperty("sys_id")
    private String sysId;
    @JsonProperty("recept_time")
    private String receptTime;

    @JsonProperty("nawon_yn")
    private String nawonYn;
    @JsonProperty("mt_calling_id")
    private String mtCallingId;

    @JsonProperty("hospital_id")
    private String hospitalId;
    @JsonProperty("hospital_code")
    private String hospitalCode;

    public String getReservationCode() {
        return reservationCode;
    }

    public void setReservationCode(String reservationCode) {
        this.reservationCode = reservationCode;
    }

    public String getExaminationDate() {
        return examinationDate;
    }

    public void setExaminationDate(String examinationDate) {
        this.examinationDate = examinationDate;
    }

    public String getExaminationTime() {
        return examinationTime;
    }

    public void setExaminationTime(String examinationTime) {
        this.examinationTime = examinationTime;
    }

    public String getDepartmentCode() {
        return departmentCode;
    }

    public void setDepartmentCode(String departmentCode) {
        this.departmentCode = departmentCode;
    }

    public String getDepartmentName() {
        return departmentName;
    }

    public void setDepartmentName(String departmentName) {
        this.departmentName = departmentName;
    }

    public String getPatientName() {
        return patientName;
    }

    public void setPatientName(String patientName) {
        this.patientName = patientName;
    }

    public String getPatientCode() {
        return patientCode;
    }

    public void setPatientCode(String patientCode) {
        this.patientCode = patientCode;
    }

    public String getPatientNameKana() {
        return patientNameKana;
    }

    public void setPatientNameKana(String patientNameKana) {
        this.patientNameKana = patientNameKana;
    }

    public String getDoctorCode() {
        return doctorCode;
    }

    public void setDoctorCode(String doctorCode) {
        this.doctorCode = doctorCode;
    }

    public String getDoctorName() {
        return doctorName;
    }

    public void setDoctorName(String doctorName) {
        this.doctorName = doctorName;
    }

    public String getSysId() {
        return sysId;
    }

    public void setSysId(String sysId) {
        this.sysId = sysId;
    }

    public String getReceptTime() {
        return receptTime;
    }

    public void setReceptTime(String receptTime) {
        this.receptTime = receptTime;
    }

    public String getNawonYn() {
        return nawonYn;
    }

    public void setNawonYn(String nawonYn) {
        this.nawonYn = nawonYn;
    }

    public String getMtCallingId() {
        return mtCallingId;
    }

    public void setMtCallingId(String mtCallingId) {
        this.mtCallingId = mtCallingId;
    }

    public String getHospitalId() {
        return hospitalId;
    }

    public void setHospitalId(String hospitalId) {
        this.hospitalId = hospitalId;
    }

	public String getHospitalCode() {
		return hospitalCode;
	}

	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}
    
}
