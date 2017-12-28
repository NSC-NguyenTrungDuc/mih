package nta.med.core.domain.mss;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;

/**
 * The persistent class for the reservation database table.
 * 
 */
@Entity
@Table(name = "reservation")
@NamedQuery(name = "Reservation.findAll", query = "SELECT r FROM Reservation r")
public class Reservation implements Serializable {

	private static final long serialVersionUID = 1L;
	private Integer reservationId;
	private BigDecimal activeFlg;
	private Timestamp created;
	private String departCode;
	private Integer deptId;
	private String deptName;
	private String doctorCode;
	private Integer doctorId;
	private String doctorName;
	private String email;
	private String fromSystem;
	private Integer hospitalId;
	private String nameFurigana;
	private Integer patientId;
	private String patientName;
	private String phoneNumber;
	private String regUser;
	private Integer reminderTime;
	private String reservationCode;
	private String reservationDate;
	private BigDecimal reservationStatus;
	private String reservationTime;
	private String sessionId;
	private Timestamp updated;
	private String mtCallingId;

	public Reservation() {
	}

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "reservation_id", unique = true, nullable = false)
	public Integer getReservationId() {
		return this.reservationId;
	}

	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}

	@Column(name = "active_flg")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Column(name = "depart_code")
	public String getDepartCode() {
		return this.departCode;
	}

	public void setDepartCode(String departCode) {
		this.departCode = departCode;
	}

	@Column(name = "dept_id")
	public Integer getDeptId() {
		return this.deptId;
	}

	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}

	@Column(name = "dept_name")
	public String getDeptName() {
		return this.deptName;
	}

	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}

	@Column(name = "doctor_code")
	public String getDoctorCode() {
		return this.doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	@Column(name = "doctor_id")
	public Integer getDoctorId() {
		return this.doctorId;
	}

	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}

	@Column(name = "doctor_name")
	public String getDoctorName() {
		return this.doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	@Column(name = "from_system")
	public String getFromSystem() {
		return this.fromSystem;
	}

	public void setFromSystem(String fromSystem) {
		this.fromSystem = fromSystem;
	}

	@Column(name = "hospital_id")
	public Integer getHospitalId() {
		return this.hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	@Column(name = "name_furigana")
	public String getNameFurigana() {
		return this.nameFurigana;
	}

	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}

	@Column(name = "patient_id")
	public Integer getPatientId() {
		return this.patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	@Column(name = "patient_name")
	public String getPatientName() {
		return this.patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	@Column(name = "phone_number")
	public String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	@Column(name = "reg_user")
	public String getRegUser() {
		return this.regUser;
	}

	public void setRegUser(String regUser) {
		this.regUser = regUser;
	}

	@Column(name = "reminder_time")
	public Integer getReminderTime() {
		return this.reminderTime;
	}

	public void setReminderTime(Integer reminderTime) {
		this.reminderTime = reminderTime;
	}

	@Column(name = "reservation_code")
	public String getReservationCode() {
		return this.reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}

	@Column(name = "reservation_date")
	public String getReservationDate() {
		return this.reservationDate;
	}

	public void setReservationDate(String reservationDate) {
		this.reservationDate = reservationDate;
	}

	@Column(name = "reservation_status")
	public BigDecimal getReservationStatus() {
		return this.reservationStatus;
	}

	public void setReservationStatus(BigDecimal reservationStatus) {
		this.reservationStatus = reservationStatus;
	}

	@Column(name = "reservation_time")
	public String getReservationTime() {
		return this.reservationTime;
	}

	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}

	@Column(name = "session_id")
	public String getSessionId() {
		return this.sessionId;
	}

	@Column(name = "mt_calling_id")
	public String getMtCallingId() {
		return mtCallingId;
	}

	public void setMtCallingId(String mtCallingId) {
		this.mtCallingId = mtCallingId;
	}

	public void setSessionId(String sessionId) {
		this.sessionId = sessionId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}