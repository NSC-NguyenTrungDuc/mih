package nta.med.data.model.ihis.bass;


import java.util.Date;
/**
 * @author DEV-TiepNM
 */
public class WaitingPatientInfo {

    private Double reservationCode;
    private Date examinationDate;
    private String examinationTime;
    private String departmentCode;
    private String departmentName;
    private String patientName;
    private String patientCode;
    private String patientNameKana;
    private String doctorCode;
    private String doctorName;
    private String sysId;
    private String receptTime;
    private String nawonYn;

    public WaitingPatientInfo(Double reservationCode, Date examinationDate, String examinationTime, String departmentCode, String departmentName, String patientName, String patientCode, String patientNameKana,
                              String doctorCode, String doctorName, String sysId, String receptTime, String nawonYn) {
        this.reservationCode = reservationCode;
        this.examinationDate = examinationDate;
        this.examinationTime = examinationTime;
        this.departmentCode = departmentCode;
        this.departmentName = departmentName;
        this.patientName = patientName;
        this.patientCode = patientCode;
        this.patientNameKana = patientNameKana;
        this.doctorCode = doctorCode;
        this.doctorName = doctorName;
        this.sysId = sysId;
        this.receptTime = receptTime;
        this.nawonYn = nawonYn;
    }

    public Double getReservationCode() {
        return reservationCode;
    }

    public void setReservationCode(Double reservationCode) {
        this.reservationCode = reservationCode;
    }

    public Date getExaminationDate() {
        return examinationDate;
    }

    public void setExaminationDate(Date examinationDate) {
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
}
