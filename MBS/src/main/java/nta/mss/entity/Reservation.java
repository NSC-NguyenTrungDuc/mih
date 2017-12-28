package nta.mss.entity;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import nta.mss.model.ReservationModel;
import nta.mss.service.IReservationService;

/**
 * The persistent class for the reservation database table.
 * 
 */
@Entity
@Table(name = "reservation")
public class Reservation extends BaseEntity<ReservationModel> implements Serializable  {
	private static final long serialVersionUID = 1L;


	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "reservation_id", unique = true, nullable = false)
	private Integer reservationId;
	
	@Column(name = "reservation_code", length = 32)
	private String reservationCode;

	@Column(name = "email", length = 128)
	private String email;

	@Column(name = "name_furigana", nullable = false, length = 64)
	private String nameFurigana;

	@Column(name = "patient_name", nullable = false, length = 64)
	private String patientName;

	@Column(name = "phone_number", nullable = false, length = 32)
	private String phoneNumber;

	@Column(name = "reg_user", length = 64)
	private String regUser;

	@Column(name = "reminder_time")
	private Integer reminderTime;

	@Column(name = "reservation_date", length = 8)
	private String reservationDate;

	@Column(name = "reservation_time", length = 6)
	private String reservationTime;
	
	@Column(name = "reservation_status")
	private Integer reservationStatus;

	// bi-directional many-to-one association to Deparment
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "dept_id")
	private Department department;
	
	// bi-directional many-to-one association to Transaction
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "transaction_id", nullable = true)
	private Transaction transaction;

	// bi-directional many-to-one association to Doctor
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "doctor_id", nullable = false)
	private Doctor doctor;

	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id")
	private Hospital hospital;

	// bi-directional many-to-one association to Patient
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "patient_id")
	private Patient patient;

	// bi-directional many-to-one association to Session
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "session_id", nullable = false)
	private Session session;
	
	@OneToMany(mappedBy = "reservation", fetch = FetchType.LAZY)
	private List<MailSending> mailSendings;

	//bi-directional many-to-one association to VaccineChildHistory
//	@OneToMany(mappedBy="reservation")
//	private List<VaccineChildHistory> vaccineChildHistories;
	
	@Column(name="depart_code")
	private String departCode;

	@Column(name="doctor_name")
	private String doctorName;

	@Column(name="dept_name")
	private String deptName;

	@Column(name="doctor_code")
	private String doctorCode;

	@Column(name="from_system")
	private String fromSystem;
	
	@Column(name = "refer_link" , length = 256)
	private String referLink;
	/**
	 * Instantiates a new reservation.
	 */
	public Reservation() {
		super(ReservationModel.class);
	}

	public Integer getReservationId() {
		return this.reservationId;
	}

	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}

	public String getReservationCode() {
		return reservationCode;
	}

	public void setReservationCode(String reservationCode) {
		this.reservationCode = reservationCode;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getNameFurigana() {
		return this.nameFurigana;
	}

	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}

	public String getPatientName() {
		return this.patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getRegUser() {
		return this.regUser;
	}

	public void setRegUser(String regUser) {
		this.regUser = regUser;
	}

	public Integer getReminderTime() {
		return this.reminderTime;
	}

	public void setReminderTime(Integer reminderTime) {
		this.reminderTime = reminderTime;
	}

	public String getReservationDate() {
		return this.reservationDate;
	}

	public void setReservationDate(String reservationDate) {
		this.reservationDate = reservationDate;
	}

	public String getReservationTime() {
		return this.reservationTime;
	}

	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}

	public Integer getReservationStatus() {
		return reservationStatus;
	}

	public void setReservationStatus(Integer reservationStatus) {
		this.reservationStatus = reservationStatus;
	}

	public Doctor getDoctor() {
		return this.doctor;
	}

	public void setDoctor(Doctor doctor) {
		this.doctor = doctor;
	}

	public Hospital getHospital() {
		return this.hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}

	public Patient getPatient() {
		return this.patient;
	}

	public void setPatient(Patient patient) {
		this.patient = patient;
	}

	public Session getSession() {
		return this.session;
	}

	public void setSession(Session session) {
		this.session = session;
	}

	public Department getDepartment() {
		return department;
	}

	public void setDepartment(Department department) {
		this.department = department;
	}

	public List<MailSending> getMailSendings() {
		return mailSendings;
	}

	public void setMailSendings(List<MailSending> mailSendings) {
		this.mailSendings = mailSendings;
	}

	public String getDepartCode() {
		return departCode;
	}

	public void setDepartCode(String departCode) {
		this.departCode = departCode;
	}

	public String getDeptName() {
		return deptName;
	}

	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	
	public String getDoctorName() {
		return doctorName;
	}

	public String getFromSystem() {
		return fromSystem;
	}

	public void setFromSystem(String fromSystem) {
		this.fromSystem = fromSystem;
	}
	
//	public List<VaccineChildHistory> getVaccineChildHistories() {
//		return this.vaccineChildHistories;
//	}
//
//	public void setVaccineChildHistories(List<VaccineChildHistory> vaccineChildHistories) {
//		this.vaccineChildHistories = vaccineChildHistories;
//	}
	public String getReferLink() {
		return referLink;
	}

	public void setReferLink(String referLink) {
		this.referLink = referLink;
	}

	public Transaction getTransaction() {
		return transaction;
	}

	public void setTransaction(Transaction transaction) {
		this.transaction = transaction;
	}
	
}