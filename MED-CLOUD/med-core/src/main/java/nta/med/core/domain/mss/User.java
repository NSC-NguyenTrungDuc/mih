package nta.med.core.domain.mss;



import javax.persistence.*;
import java.io.Serializable;
import java.util.Date;
import java.util.List;


/**
 * The persistent class for the user database table.
 * 
 */
@Entity
@Table(name="user")
public class User implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="user_id", unique=true, nullable=false)
	private Integer userId;
	private String dob;
	private String email;
	@Column(name="login_id", length=32)
	private String loginId;
	private String name;
	@Column(name="name_furigana", length=64)
	private String nameFurigana;
	private String password;
	@Column(name="phone_number", length=32)
	private String phoneNumber;
	private String sex;
	@Column(name="hospital_id", length=128)
	private Integer hospitalId;
	@Column(name="token_id", length=128)
	private String tokenId;
	@Column(name="user_status")
	private Integer userStatus;

	@Column(name = "active_flg", insertable = false, updatable = true)
	private Integer activeFlg;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="created")
	private Date created;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="updated")
	private Date updated;

	public User() {

	}
	@Column(name = "active_flg", insertable = false, updatable = true)
	public Integer getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}
	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="created")
	public Date getCreated() {
		return created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}
	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="updated")
	public Date getUpdated() {
		return updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}

	public Integer getUserId() {
		return this.userId;
	}

	public void setUserId(Integer userId) {
		this.userId = userId;
	}
	@Column(name="dob", length=8)
	public String getDob() {
		return this.dob;
	}

	public void setDob(String dob) {
		this.dob = dob;
	}
	@Column(name="email", length=128)
	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}
	@Column(name="login_id", length=32)
	public String getLoginId() {
		return this.loginId;
	}

	public void setLoginId(String loginId) {
		this.loginId = loginId;
	}
	@Column(name="name", length=64)
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}
	@Column(name="name_furigana", length=64)
	public String getNameFurigana() {
		return this.nameFurigana;
	}

	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}
	@Column(length=128)
	public String getPassword() {
		return this.password;
	}

	public void setPassword(String password) {
		this.password = password;
	}
	@Column(name="phone_number", length=32)
	public String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}
	@Column(name="sex", length=1)
	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}
	@Column(name="user_status")
	public Integer getUserStatus() {
		return userStatus;
	}

	public void setUserStatus(Integer userStatus) {
		this.userStatus = userStatus;
	}

	@Column(name="token_id", length=128)
	public String getTokenId() {
		return tokenId;
	}

	public void setTokenId(String tokenId) {
		this.tokenId = tokenId;
	}
	@Column(name="hospital_id", length=128)
	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
}