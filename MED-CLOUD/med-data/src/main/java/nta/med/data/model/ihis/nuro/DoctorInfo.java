package nta.med.data.model.ihis.nuro;

import java.math.BigInteger;

/**
 * @author DEV-TiepNM
 */
public class DoctorInfo {
    private String doctor;
    private String doctorGrade;
    private String doctorName;
    private BigInteger departmentId;
    private String departmentCode;
    private BigInteger doctorId;

    public DoctorInfo(String doctor, String doctorGrade, String doctorName, BigInteger departmentId, String departmentCode, BigInteger doctorId) {
        this.doctor = doctor;
        this.doctorGrade = doctorGrade;
        this.doctorName = doctorName;
        this.departmentId = departmentId;
        this.departmentCode = departmentCode;
        this.doctorId = doctorId;
    }

    public String getDoctor() {
        return doctor;
    }

    public void setDoctor(String doctor) {
        this.doctor = doctor;
    }

    public String getDoctorGrade() {
        return doctorGrade;
    }

    public void setDoctorGrade(String doctorGrade) {
        this.doctorGrade = doctorGrade;
    }

    public String getDoctorName() {
        return doctorName;
    }

    public void setDoctorName(String doctorName) {
        this.doctorName = doctorName;
    }

    public BigInteger getDepartmentId() {
        return departmentId;
    }

    public void setDepartmentId(BigInteger departmentId) {
        this.departmentId = departmentId;
    }

    public String getDepartmentCode() {
        return departmentCode;
    }

    public void setDepartmentCode(String departmentCode) {
        this.departmentCode = departmentCode;
    }

    public BigInteger getDoctorId() {
        return doctorId;
    }

    public void setDoctorId(BigInteger doctorId) {
        this.doctorId = doctorId;
    }
}
