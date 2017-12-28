package nta.med.core.domain.event;

import org.springframework.data.mongodb.core.mapping.Document;

/**
 * @author dainguyen.
 */
@Document(collection = "booking_events")
public class BookingEvent extends AbstractEvent {

    private String patientCode;
    private String patientName;
    private String patientNameFurigana;
    private String phoneNumber;
    private String departmentId;
    private String departmentCode;
    private String departmentName;
    private Integer doctorId;
    private String doctorCode;
    private String doctorName;
    private String reservationDate;
    private String reserveTime;
    private String patientPwd;
    private String email;
    private String hospCode;

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

    public String getPatientNameFurigana() {
        return patientNameFurigana;
    }

    public void setPatientNameFurigana(String patientNameFurigana) {
        this.patientNameFurigana = patientNameFurigana;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phone_number) {
        this.phoneNumber = phone_number;
    }

    public String getDepartmentId() {
        return departmentId;
    }

    public void setDepartmentId(String departmentId) {
        this.departmentId = departmentId;
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

    public Integer getDoctorId() {
        return doctorId;
    }

    public void setDoctorId(Integer doctorId) {
        this.doctorId = doctorId;
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

    public String getReservationDate() {
        return reservationDate;
    }

    public void setReservationDate(String reservationDate) {
        this.reservationDate = reservationDate;
    }

    public String getReserveTime() {
        return reserveTime;
    }

    public void setReserveTime(String reserveTime) {
        this.reserveTime = reserveTime;
    }

    public String getPatientPwd() {
        return patientPwd;
    }

    public void setPatientPwd(String patientPwd) {
        this.patientPwd = patientPwd;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getHospCode() {
        return hospCode;
    }

    public void setHospCode(String hospCode) {
        this.hospCode = hospCode;
    }
}
