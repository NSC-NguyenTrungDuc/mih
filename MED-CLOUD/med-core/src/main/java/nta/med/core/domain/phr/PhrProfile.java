package nta.med.core.domain.phr;

import java.math.BigDecimal;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the PHR_PROFILE database table.
 * 
 */
@Entity
@Table(name = "PHR_PROFILE")
@NamedQuery(name = "PhrProfile.findAll", query = "SELECT p FROM PhrProfile p")
public class PhrProfile extends PhrBaseEntity{
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "ACCOUNT_ID")
	private PhrAccount account;

	@Column(name = "ACTIVE_PROFILE_FLG")
	private BigDecimal activeProfileFlg;

	private String address;

	@Column(name = "BABY_FLG")
	private BigDecimal babyFlg;
	
	@Column(name = "SEX")
	private String gender;

	private String birthday;

	private String city;

	@Column(name = "FAMILY_MEMBER_TYPE")
	private String familyMemberType;

	@Column(name = "FULL_NAME")
	private String fullName;

	@Column(name = "FULL_NAME_KANA")
	private String fullNameKana;

	private String locale;

	private String nickname;

	private String occupation;

	@Column(name = "PICTURE_PROFILE_URL")
	private String pictureProfileUrl;

	private String prefecture;

	private String relationship;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "UPD_ID")
	private String updId;

	@Column(name = "ZIP_CODE")
	private String zipCode;

	@Column(name = "SYNC_FLG")
	private BigDecimal syncFlg;

	@Column(name = "UDID")
	private String udid;
	
	@Column(name = "PHONE")
	private String phone;

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public PhrAccount getAccount() {
		return account;
	}

	public void setAccount(PhrAccount account) {
		this.account = account;
	}

	public BigDecimal getActiveProfileFlg() {
		return this.activeProfileFlg;
	}

	public void setActiveProfileFlg(BigDecimal activeProfileFlg) {
		this.activeProfileFlg = activeProfileFlg;
	}

	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public BigDecimal getBabyFlg() {
		return this.babyFlg;
	}

	public void setBabyFlg(BigDecimal babyFlg) {
		this.babyFlg = babyFlg;
	}

	public String getBirthday() {
		return this.birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}

	public String getCity() {
		return this.city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public String getFamilyMemberType() {
		return this.familyMemberType;
	}

	public void setFamilyMemberType(String familyMemberType) {
		this.familyMemberType = familyMemberType;
	}

	public String getFullName() {
		return this.fullName;
	}

	public void setFullName(String fullName) {
		this.fullName = fullName;
	}

	public String getFullNameKana() {
		return this.fullNameKana;
	}

	public void setFullNameKana(String fullNameKana) {
		this.fullNameKana = fullNameKana;
	}

	public String getLocale() {
		return this.locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getNickname() {
		return this.nickname;
	}

	public void setNickname(String nickname) {
		this.nickname = nickname;
	}

	public String getOccupation() {
		return this.occupation;
	}

	public void setOccupation(String occupation) {
		this.occupation = occupation;
	}

	public String getPictureProfileUrl() {
		return this.pictureProfileUrl;
	}

	public void setPictureProfileUrl(String pictureProfileUrl) {
		this.pictureProfileUrl = pictureProfileUrl;
	}

	public String getPrefecture() {
		return this.prefecture;
	}

	public void setPrefecture(String prefecture) {
		this.prefecture = prefecture;
	}

	public String getRelationship() {
		return this.relationship;
	}

	public void setRelationship(String relationship) {
		this.relationship = relationship;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public String getZipCode() {
		return this.zipCode;
	}

	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public BigDecimal getSyncFlg() {
		return syncFlg;
	}

	public void setSyncFlg(BigDecimal syncFlg) {
		this.syncFlg = syncFlg;
	}

	public String getUdid() {
		return udid;
	}

	public void setUdid(String udid) {
		this.udid = udid;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}
	
}