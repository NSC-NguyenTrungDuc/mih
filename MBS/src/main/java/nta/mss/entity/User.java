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

import nta.mss.model.UserModel;


/**
 * The persistent class for the user database table.
 * 
 */
@Entity
@Table(name="user")
public class User extends BaseEntity<UserModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="user_id", unique=true, nullable=false)
	private Integer userId;

	@Column(name="dob", length=8)
	private String dob;

	@Column(name="email", length=128)
	private String email;

	@Column(name="login_id", length=32)
	private String loginId;

	@Column(name="name", length=64)
	private String name;

	@Column(name="name_furigana", length=64)
	private String nameFurigana;

	@Column(length=128)
	private String password;

	@Column(name="phone_number", length=32)
	private String phoneNumber;

	@Column(name="sex", length=1)
	private String sex;

	@Column(name="token_id", length=128)
	private String tokenId;
	
	//bi-directional many-to-one association to UserChild
	@OneToMany(mappedBy="user")
	private List<UserChild> userChilds;
	
	@Column(name="user_status")
	private Integer userStatus;
	
	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id")
	private Hospital hospital;
	
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="patient_id")
	private Patient patient;

	public User() {
		super(UserModel.class);
	}

	public Integer getUserId() {
		return this.userId;
	}

	public void setUserId(Integer userId) {
		this.userId = userId;
	}

	public String getDob() {
		return this.dob;
	}

	public void setDob(String dob) {
		this.dob = dob;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getLoginId() {
		return this.loginId;
	}

	public void setLoginId(String loginId) {
		this.loginId = loginId;
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

	public String getPassword() {
		return this.password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public List<UserChild> getUserChilds() {
		return this.userChilds;
	}

	public void setUserChilds(List<UserChild> userChilds) {
		this.userChilds = userChilds;
	}

	public Integer getUserStatus() {
		return userStatus;
	}

	public void setUserStatus(Integer userStatus) {
		this.userStatus = userStatus;
	}

	public Hospital getHospital() {
		return this.hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}

	public String getTokenId() {
		return tokenId;
	}

	public void setTokenId(String tokenId) {
		this.tokenId = tokenId;
	}

	public Patient getPatient() {
		return patient;
	}

	public void setPatient(Patient patient) {
		this.patient = patient;
	}
	
}