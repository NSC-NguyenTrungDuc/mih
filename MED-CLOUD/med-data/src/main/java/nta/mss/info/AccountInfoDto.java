package nta.mss.info;

import java.math.BigDecimal;
import java.math.BigInteger;

public class AccountInfoDto {
	private BigInteger accountId;
	private String email;
	private String fullname;
	private String fullnameKana;
	private String sex;
	private BigDecimal babyFlg;
	private String relationship;
	private String familyMemberType;
	private BigDecimal activeProfileFlg;
	private String birthday;
	private String phone;

	public AccountInfoDto(BigInteger accountId, String email, String fullname, String fullnameKana, String sex, BigDecimal babyFlg,
			String relationship, String familyMemberType, BigDecimal activeProfileFlg, String birthday, String phone) {
		super();
		this.accountId = accountId;
		this.email = email;
		this.fullname = fullname;
		this.fullnameKana = fullnameKana;
		this.sex = sex;
		this.babyFlg = babyFlg;
		this.relationship = relationship;
		this.familyMemberType = familyMemberType;
		this.activeProfileFlg = activeProfileFlg;
		this.birthday = birthday;
		this.phone = phone;
	}
	
	public BigInteger getAccountId() {
		return accountId;
	}

	public void setAccountId(BigInteger accountId) {
		this.accountId = accountId;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getFullname() {
		return fullname;
	}

	public void setFullname(String fullname) {
		this.fullname = fullname;
	}

	public String getFullnameKana() {
		return fullnameKana;
	}

	public void setFullnameKana(String fullnameKana) {
		this.fullnameKana = fullnameKana;
	}
	
	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public BigDecimal getBabyFlg() {
		return babyFlg;
	}

	public void setBabyFlg(BigDecimal babyFlg) {
		this.babyFlg = babyFlg;
	}

	public String getRelationship() {
		return relationship;
	}

	public void setRelationship(String relationship) {
		this.relationship = relationship;
	}

	public String getFamilyMemberType() {
		return familyMemberType;
	}

	public void setFamilyMemberType(String familyMemberType) {
		this.familyMemberType = familyMemberType;
	}

	public BigDecimal getActiveProfileFlg() {
		return activeProfileFlg;
	}

	public void setActiveProfileFlg(BigDecimal activeProfileFlg) {
		this.activeProfileFlg = activeProfileFlg;
	}
	
	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}
	
	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	@Override
	public String toString() {
		return "AccountInfoDto [accountId=" + accountId + ", email=" + email + ", fullname="
				+ fullname + ", fullnameKana=" + fullnameKana + ", sex=" + sex + ", babyFlg=" + babyFlg
				+ ", relationship=" + relationship + ", familyMemberType=" + familyMemberType 
				+ ", activeProfileFlg=" + activeProfileFlg + ", phone=" + birthday + ", phone=" + phone + "]";
	}
	
}
