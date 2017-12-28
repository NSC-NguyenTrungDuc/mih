package nta.mss.entity;

import java.util.Date;
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

import nta.mss.model.PatientModel;

/**
 * The persistent class for the patient database table.
 * 
 */
@Entity
@Table(name = "patient")
public class Patient extends BaseEntity<PatientModel> {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "patient_id", unique = true, nullable = false)
	private Integer patientId;

	@Column(name = "card_number", length = 32)
	private String cardNumber;

	@Column(name = "email", length = 128)
	private String email;
	
	@Column(name = "sex", length = 1)
	private String gender;
	
	@Column(name = "dob")
	private Date birthDay;

	@Column(name = "name", length = 64)
	private String name;

	@Column(name = "name_furigana", length = 64)
	private String nameFurigana;

	@Column(name = "phone_number", length = 32)
	private String phoneNumber;
	
	@Column(name = "kcck_parent_code")
	private String kcckParentCode;
	
	@Column(name = "profile_id")
	private Long profileId;

	// bi-directional many-to-one association to Reservation
	@OneToMany(mappedBy = "patient", fetch = FetchType.LAZY)
	private List<Reservation> reservations;

	//bi-directional many-to-one association to UserChild
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="child_id")
	private UserChild userChild;
	
	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id")
	private Hospital hospital;
	/**
	 * Instantiates a new patient.
	 */
	public Patient() {
		super(PatientModel.class);
	}

	public Integer getPatientId() {
		return this.patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	public String getCardNumber() {
		return this.cardNumber;
	}

	public void setCardNumber(String cardNumber) {
		this.cardNumber = cardNumber;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getNameFurigana() {
		return this.nameFurigana;
	}

	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}

	public String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public List<Reservation> getReservations() {
		return this.reservations;
	}

	public void setReservations(List<Reservation> reservations) {
		this.reservations = reservations;
	}

	public UserChild getUserChild() {
		return this.userChild;
	}

	public void setUserChild(UserChild userChild) {
		this.userChild = userChild;
	}

	public Hospital getHospital() {
		return hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public Date getBirthDay() {
		return birthDay;
	}

	public void setBirthDay(Date birthDay) {
		this.birthDay = birthDay;
	}

	public String getKcckParentCode() {
		return kcckParentCode;
	}

	public void setKcckParentCode(String kcckParentCode) {
		this.kcckParentCode = kcckParentCode;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}
	
}