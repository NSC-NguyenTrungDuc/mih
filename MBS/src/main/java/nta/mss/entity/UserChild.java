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
import javax.persistence.OneToOne;
import javax.persistence.Table;

import nta.mss.model.UserChildModel;


/**
 * The persistent class for the user_child database table.
 * 
 */
@Entity
@Table(name="user_child")
public class UserChild extends BaseEntity<UserChildModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="child_id", unique=true, nullable=false)
	private Integer childId;

	@Column(name="child_name", length=64)
	private String childName;

	@Column(name="child_name_furigana", length=64)
	private String childNameFurigana;
	
	@OneToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="patient_id")
	private Patient patient;
	
	@Column(length=8)
	private String dob;

	@Column(length=2)
	private String sex;

	//bi-directional many-to-one association to Patient
	@OneToMany(mappedBy="userChild")
	private List<Patient> patients;

	//bi-directional many-to-one association to User
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="user_id", nullable=false)
	private User user;

	//bi-directional many-to-one association to VaccineChildHistory
	@OneToMany(mappedBy="userChild")
	private List<VaccineChildHistory> vaccineChildHistories;

	public UserChild() {
		super(UserChildModel.class);
	}

	public Integer getChildId() {
		return this.childId;
	}

	public void setChildId(Integer childId) {
		this.childId = childId;
	}

	public String getChildName() {
		return this.childName;
	}

	public void setChildName(String childName) {
		this.childName = childName;
	}

	public String getChildNameFurigana() {
		return this.childNameFurigana;
	}

	public void setChildNameFurigana(String childNameFurigana) {
		this.childNameFurigana = childNameFurigana;
	}

	public String getDob() {
		return this.dob;
	}

	public void setDob(String dob) {
		this.dob = dob;
	}

	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public List<Patient> getPatients() {
		return this.patients;
	}

	public void setPatients(List<Patient> patients) {
		this.patients = patients;
	}

	public User getUser() {
		return this.user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public List<VaccineChildHistory> getVaccineChildHistories() {
		return this.vaccineChildHistories;
	}

	public void setVaccineChildHistories(List<VaccineChildHistory> vaccineChildHistories) {
		this.vaccineChildHistories = vaccineChildHistories;
	}

	public Patient getPatient() {
		return patient;
	}

	public void setPatient(Patient patient) {
		this.patient = patient;
	}
	
		
}