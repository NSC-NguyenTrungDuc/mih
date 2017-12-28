/**
 * 
 */
package nta.med.data.model.mss;

import java.math.BigInteger;
import java.util.Date;

/**
 * @author DEV-HuanLT
 *
 */
public class BookingExamInfo {

    private String patientCode;

	private BigInteger departmentId;
	private String departmentCode;
    private String departmentName;
    private BigInteger doctorId;
	private String doctorCode;
	private String doctorName;
    private String reservationDate;
    private String reservationTime;
    private String reservationCode;

	public BookingExamInfo(String patientCode, BigInteger departmentId, String departmentCode,
						   String departmentName, BigInteger doctorId, String doctorCode,
						   String doctorName, String reservationDate, String reservationTime, String reservationCode) {
		this.patientCode = patientCode;
		this.departmentId = departmentId;
		this.departmentCode = departmentCode;
		this.departmentName = departmentName;
		this.doctorId = doctorId;
		this.doctorCode = doctorCode;
		this.doctorName = doctorName;
		this.reservationDate = reservationDate;
		this.reservationTime = reservationTime;
		this.reservationCode = reservationCode;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
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

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	public BigInteger getDoctorId() {
		return doctorId;
	}

	public void setDoctorId(BigInteger doctorId) {
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

	public String getReservationTime() {
		return reservationTime;
	}

	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}


}
